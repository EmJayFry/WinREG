'	$Date: 2014-01-02 10:51:19 +0200 (Thu, 02 Jan 2014) $
'	$Rev: 299 $
'	$Id: MainForm.vb 299 2014-01-02 08:51:19Z Mikefry $
'
'	WinREG/3 - Version 3.2.3
'

Imports Microsoft.Win32
Imports Microsoft.VisualBasic.FileIO

Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.ComponentModel
Imports System.Threading
Imports System.Collections.Specialized
Imports System.Security
Imports System.Runtime.Serialization.Formatters.Binary

'Imports DataGridViewAutoFilter
Imports CaseText
Imports DefaultPrograms

Imports WinREG.TranscriptionTables
Imports WinREG.MessageBoxes
Imports WinREG.LookupTables
Imports WinREG.FreeRegBrowser
Imports WinREG.BadRecordsDataSet

Imports Microsoft.WindowsAPICodePack.Shell
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports Microsoft.WindowsAPICodePack.ApplicationServices
Imports System.Windows.Forms.Integration
Imports System.Windows.Interop

'Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class MainForm

	Private startTime As DateTime

	Public LookUpsDataSet As New LookupTables()
	Public tabBapSex As DataTable = LookUpsDataSet.BaptismSex
	Public tabBurialRelationship As DataTable = LookUpsDataSet.BurialRelationship
	Public tabGroomCondition As DataTable = LookUpsDataSet.GroomCondition
	Public tabBrideCondition As DataTable = LookUpsDataSet.BrideCondition
	Public tabRecordTypes As DataTable = LookUpsDataSet.RecordTypes
	Public tabChapmanCodes As DataTable = LookUpsDataSet.ChapmanCodes

	<Serializable()> Public Structure FileHeader
		Public Pathname As String
		Public Filename As String
		Public Username As String
		Public County As String
		Public CountyCode As String
		Public EmailAddress As String
		Public Password As String
		Public FileType As String
		Public InternalFilename As String
		Public DateLastUpdated As String
		Public CreditToName As String
		Public CreditToAddress As String
		Public DateCreated As String
		Public FileSource As String
		Public FileComments As String
		Public PlaceName As String
		Public ChurchName As String
		Public fileOpen As Boolean
		Public fileChanged As Boolean
		Public fileNew As Boolean
		Public ldsFile As Boolean
	End Structure

	Public _BaseDataDirectory As String = ""

	Public Shared ldsFile As Boolean = False, excelFile As Boolean = False, fileOpen As Boolean = False, fileNew As Boolean = False, fileChanged As Boolean = False, fileHeaderCorrected As Boolean = False, recordHeadersCorrected As Boolean

	Public acscAbodes As AutoCompleteStringCollection = New AutoCompleteStringCollection
	Public acscOccupations As AutoCompleteStringCollection = New AutoCompleteStringCollection
	Public acscFiche As AutoCompleteStringCollection = New AutoCompleteStringCollection
	Public acscImage As AutoCompleteStringCollection = New AutoCompleteStringCollection

	Public bsDGV As BindingSource

	Public Shared _File As New FileHeader
	Public Shared _User As New UserDetails
	Public Shared _Options As New ProgramOptions(False)

	Public _OS As OperatingSystem
	Public _PID As PlatformID
	Public _FULLNAME As String
	Public _PLATFORM As String
	Public _VERNUM As String

	Public _Culture As CultureInfo = CultureInfo.InvariantCulture
	Public _Encoding As Encoding = Encoding.GetEncoding("iso-8859-1")
	Private isamList As List(Of String) = Nothing

	Private badRecords As New BadRecordsDataSet.BadRecordsDataTable()

	Public boolTablesChanged As Boolean
	Public boolUpdaterAvailable As Boolean
	Public boolRunUpdater As Boolean = True
	Public boolThreadActive As Boolean
	Public boolFileContainsErrors As Boolean
	Public boolCorruptionThreadActive As Boolean
	Private CanImportXLS As Boolean = False
	Private CanImportXLSX As Boolean = False

	Public strModulePath As String
	Public strUpdaterPath As String
	Public strDefaultTitle As String

	Public _ID As String = "$Id: MainForm.vb 299 2014-01-02 08:51:19Z Mikefry $"

	Public FreeRegbrowser As FreeRegBrowser
	Public ErrorFileObj As ErrorFileCreated

	Public frmImageViewer As Form
	Public winImageViewer As ImageViewer
	Public cellRightClicked As DataGridViewCell

	Private Shared ReadOnly RecoveryFile As String = Path.Combine(Path.GetDirectoryName(Application.CommonAppDataPath), "WinREGRestart.osl")
	Private Shared ReadOnly RecoveryData As String = Path.Combine(Path.GetDirectoryName(Application.CommonAppDataPath), "WinREGRestart.osd")
	Private Shared ReadOnly RecoveryTable As String = Path.Combine(Path.GetDirectoryName(Application.CommonAppDataPath), "WinREGRestart.xml")

	Private ContentPanelBackground As Color

	Public jlist As JumpList
	Private boolJumpListEnabled As Boolean = False

#Region "Main Form"

	Private Sub LoadIsamTable()
		isamList = New List(Of String)

		Dim enumerator As New OleDbEnumerator
		Using reader As OleDbDataReader = OleDbEnumerator.GetRootEnumerator()
			While reader.Read()
				isamList.Add(reader.GetValue(0))
				My.Application.Log.WriteEntry(Date.Now() + " ISAM entry: " + reader.GetValue(0), TraceEventType.Information)
			End While
		End Using

		CanImportXLS = isamList.Contains("Microsoft.Jet.OLEDB.4.0")
		CanImportXLSX = isamList.Contains("Microsoft.ACE.OLEDB.12.0")
	End Sub

	Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		If My.Application.CommandLineArgs.Count > 0 Then
			If String.Compare(My.Application.CommandLineArgs(0), "/nosplash", True) <> 0 OrElse String.Compare(My.Application.CommandLineArgs(0), "-nosplash", True) <> 0 Then
				If Not My.Application.SplashScreen Is Nothing Then
					While My.Settings.LoadFinished = False
						System.Threading.Thread.Sleep(100)
					End While
					My.Settings.LoadFinished = False
				End If
			End If
		Else
			If Not My.Application.SplashScreen Is Nothing Then
				While My.Settings.LoadFinished = False
					System.Threading.Thread.Sleep(100)
				End While
				My.Settings.LoadFinished = False
			End If
		End If

		'If SplashScreen IsNot Nothing Then
		'	If SplashScreen.Visible Then
		'		SplashScreen.Hide()
		'	End If
		'End If

		_OS = Environment.OSVersion()
		_PID = Environment.OSVersion.Platform()
		_FULLNAME = My.Computer.Info.OSFullName()
		_PLATFORM = My.Computer.Info.OSPlatform()
		_VERNUM = My.Computer.Info.OSVersion()

		' If we're running on a version of Windows prior to Vista, then the
		' ability to launch the SPAD UI is unavailable
		'
		' Operating system		 Version number 
		' Windows 7							6.1 
		' Windows Server 2008 R2		6.1 
		' Windows Server 2008			6.0 
		' Windows Vista					6.0 
		' Windows Server 2003 R2		5.2 
		' Windows Server 2003			5.2 
		' Windows XP 64-Bit Edition	5.2 
		' Windows XP						5.1 
		' Windows 2000						5.0 
		'		If _OS.Version.Major < 6 Then
		'		Else
		'		RegisterForRestart()
		'		RegisterForRecovery()
		'		End If

		If My.Settings.UpgradeSettings = True Then
			My.Settings.Upgrade()
			My.Settings.UpgradeSettings = False
			My.Settings.Save()
		End If

		Try
			My.Computer.Clipboard.Clear()

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} Error clearing clipboard <{1}>", Date.Now(), ex.Message))
			MessageBox.Show(String.Format(My.Resources.err0055, ex.Message), "Clear Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0055)
		End Try

		MainForm.CheckForIllegalCrossThreadCalls = False

		'
		'	Balloon-type tooltips only display when the Registry entry
		'	[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\EnableBalloonTips]
		'	is enabled
		'
		Try
			Dim rk As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", True)
			Try
				If rk Is Nothing Then rk = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced")
				If rk IsNot Nothing Then
					Try
						Dim rkv As Boolean = CType(rk.GetValue("EnableBalloonTips", False), Boolean)
						If Not rkv Then
							Try
								rk.SetValue("EnableBalloonTips", True, RegistryValueKind.DWord)

							Catch ex As ArgumentNullException
								My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ArgumentNullException whilst SetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
							Catch ex As ArgumentException
								My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ArgumentException whilst SetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
							Catch ex As ObjectDisposedException
								My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ObjectDisposedException whilst SetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
							Catch ex As UnauthorizedAccessException
								My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} UnauthorizedAccessException whilst SetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
							Catch ex As SecurityException
								My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} SecurityException whilst SetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
							Catch ex As IOException
								My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} IOException whilst SetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
							Catch ex As Exception
								My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} Error whilst SetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))

							End Try
						End If

						boolJumpListEnabled = rk.GetValue("Start_TrackDocs", 0)

					Catch ex As SecurityException
						My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} SecurityException whilst GetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
					Catch ex As ObjectDisposedException
						My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ObjectDisposedException whilst GetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
					Catch ex As IOException
						My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} IOException whilst GetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
					Catch ex As UnauthorizedAccessException
						My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} UnauthorizedAccessException whilst GetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))
					Catch ex As Exception
						My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} Error whilst GetValue(EnableBalloonTips) <{1}>", Date.Now(), ex.Message))

					End Try
				End If

			Catch ex As ArgumentNullException
				My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ArgumentNullException whilst CreateSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
			Catch ex As SecurityException
				My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} SecurityException whilst CreateSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
			Catch ex As ArgumentException
				My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ArgumentException whilst CreateSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
			Catch ex As ObjectDisposedException
				My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ObjectDisposedException whilst CreateSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
			Catch ex As UnauthorizedAccessException
				My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} UnauthorizedAccessException whilst CreateSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
			Catch ex As IOException
				My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} IOException whilst CreateSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} Error whilst CreateSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))

			Finally
				rk.Close()
			End Try

		Catch ex As ArgumentNullException
			My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ArgumentNullException whilst OpenSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
		Catch ex As ArgumentException
			My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ArgumentException whilst OpenSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
		Catch ex As ObjectDisposedException
			My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} ObjectDisposedException whilst OpenSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
		Catch ex As SecurityException
			My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} SecurityException whilst OpenSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))
		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} Error whilst OpenSubKey(Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced) <{1}>", Date.Now(), ex.Message))

		End Try

		If isamList Is Nothing Then LoadIsamTable()

		' Set the default base directory for storing the various data files
		'		My Documents\<Company name>\<Product name>
		'
		_BaseDataDirectory = String.Format("{0}\{1}\{2}", My.Computer.FileSystem.SpecialDirectories.MyDocuments, Application.CompanyName, Application.ProductName)

		' Use the Role of the User to set the availability of certain menu items
		'
		Try
			tsMyTools.Enabled = False
			tsMyTools.Visible = False
			'mnuMyToolsCreateLookupTables.Enabled = False
			'mnuMyToolsCreateLookupTables.Visible = False
			mnuSettingsUserSettings.Enabled = False
			mnuSettingsUserSettings.Visible = False
			If _User.IsAdministrator Then
				If _User.Username = "Mikefry" Then
					tsMyTools.Enabled = True
					tsMyTools.Visible = True
					ToolStripSeparator21.Visible = True
					mnuToolsRebuildLookUpTables.Enabled = True
					mnuToolsRebuildLookUpTables.Visible = True
					'mnuMyToolsCreateLookupTables.Enabled = True
					'mnuMyToolsCreateLookupTables.Visible = True
					mnuMyToolsCrashProgram.Enabled = True
					mnuMyToolsCrashProgram.Visible = True
					mnuMyToolsException.Enabled = True
					mnuMyToolsException.Visible = True
					mnuSettingsUserSettings.Enabled = True
					mnuSettingsUserSettings.Visible = True
				Else
					ToolStripSeparator21.Visible = True
					mnuToolsRebuildLookUpTables.Enabled = True
					mnuToolsRebuildLookUpTables.Visible = True
				End If
			End If

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst determining User Role")
			MessageBox.Show(ex.Message, "Exception whilst determining User Role", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

			_User.IsAdministrator = False
			tsMyTools.Enabled = False
			tsMyTools.Visible = False
			'mnuMyToolsCreateLookupTables.Enabled = False
			'mnuMyToolsCreateLookupTables.Visible = False
		End Try

		strDefaultTitle = Text()
		If _User.IsAdministrator Then
			Dim str As String = String.Format("{0} (Administrator)", Text())
			Text = str
		End If
		mainWelcomeText.SelectionStart = 0
		mainWelcomeText.SelectionLength = 0
		mnuToolsFiltering.CheckState = CheckState.Unchecked
		tsFilters.Visible = False

		' Compute the updater.exe path relative to the application main module path.
		'
		Dim pgmModule As ProcessModule = Process.GetCurrentProcess().MainModule
		Dim pos As Integer = pgmModule.FileName.LastIndexOf("\"c)
		If pos > 0 Then
			strModulePath = pgmModule.FileName.Substring(0, pos)
		End If

		' Has the Advanced Installer bits and pieces been installed
		'
		strUpdaterPath = My.Application.Info.DirectoryPath & "\updater.exe"
		If File.Exists(strUpdaterPath) Then
			Dim s As String = My.Application.Info.DirectoryPath & "\updater.ini"
			If File.Exists(s) Then
				mnuHelpSeparator3.Visible = True
				mnuHelpConfigureUpdates.Enabled = True
				mnuHelpConfigureUpdates.Visible = True
				mnuHelpCheckForUpdates.Enabled = True
				mnuHelpCheckForUpdates.Visible = True
				boolUpdaterAvailable = True
				Dim PGMID As String = GetID(s)
				If PGMID <> Nothing Then
					Dim rk As RegistryKey = Registry.CurrentUser
					Try
						Dim rki As RegistryKey = rk.OpenSubKey(String.Format("Software\Caphyon\Advanced Updater\{0}\Settings", PGMID), True)
						Dim rvk As RegistryValueKind = rki.GetValueKind("AutoUpdatePolicy")
						Dim updatepolicy As Integer = CType(rki.GetValue("AutoUpdatePolicy"), Integer)
						Select Case updatepolicy
							Case 0	' Do not check for updates automatically
								boolRunUpdater = False
							Case 1	' Check and prompt me to download and install the updates
							Case 2	' Check and automatically download and install
							Case Else
						End Select
						rki.Close()

					Catch ex As SecurityException
						My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} Security Exception whilst setting Registry AutoUpdatePolicy <{1}>", Date.Now(), ex.Message))

					Catch ex As Exception
						My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} Error whilst setting Registry AutoUpdatePolicy <{1}>", Date.Now(), ex.Message))
					End Try
					rk.Close()
				End If
			Else
				My.Application.Log.WriteEntry(String.Format("{0} Updater INI file not found <{1}>", Date.Now(), s), TraceEventType.Information)
				MessageBox.Show(String.Format(My.Resources.err0029, s), "Check for Updates", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0029)
			End If
		Else
			My.Application.Log.WriteEntry(String.Format("{0} Updater program not found <{1}>", Date.Now(), strUpdaterPath), TraceEventType.Information)
			MessageBox.Show(String.Format(My.Resources.err0028, strUpdaterPath), "Check for Updates", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0028)
		End If

		' Make sure the the basic data storage folder structure exists
		'
		If My.Settings.DataFolderName = "" Then
			My.Settings.DataFolderName = _BaseDataDirectory & "\Transcripts"
		End If

		If My.Settings.BackupFolderName = "" Then
			My.Settings.BackupFolderName = _BaseDataDirectory & "\Backup Files"
		End If

		If Not Directory.Exists(My.Settings.DataFolderName) Then
			Directory.CreateDirectory(My.Settings.DataFolderName)
		End If

		If Not Directory.Exists(My.Settings.BackupFolderName) Then
			Directory.CreateDirectory(My.Settings.BackupFolderName)
		End If

		If Not Directory.Exists(_BaseDataDirectory & "\Document Templates") Then
			Directory.CreateDirectory(_BaseDataDirectory & "\Document Templates")
		End If

		If Not Directory.Exists(_BaseDataDirectory & "\Screen Layouts") Then
			Directory.CreateDirectory(_BaseDataDirectory & "\Screen Layouts")
		End If

		Environment.CurrentDirectory = My.Settings.DataFolderName

		' Restore window state & position
		'
		Size = My.Settings.Size_MainForm
		Location = My.Settings.Location_MainForm
		If My.Settings.WindowState_MainForm = FormWindowState.Minimized Then
			WindowState = FormWindowState.Normal
		Else
			WindowState = My.Settings.WindowState_MainForm
		End If
		ttMain.Active = My.Settings.MyDisplayTooltips
		If My.Settings.MyDisplayTooltips Then ttMain.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
		panelWinREG2.enableToolTip = My.Settings.MyDisplayTooltips
		ssMain.ShowItemToolTips = My.Settings.MyDisplayTooltips

		My.Settings.ProductFolderName = My.Application.Info.DirectoryPath

		'	Load the Lookup Tables
		'
		LoadLookupTables()

		ErrorFileObj = New ErrorFileCreated()
		AddHandler ErrorFileObj.ErrorFileCreated, AddressOf BindingNavigatorViewErrorsButton_EventHandler
		FreeRegbrowser = New FreeRegBrowser(ErrorFileObj, My.Settings.DataFolderName, My.Settings.MyUserName, My.Settings.MyUserPassword)
		AddHandler FreeRegbrowser.UserDetailsChanged, AddressOf FreeREG_UserDetailsChanged
		If My.Settings.MyMRUList Is Nothing Then My.Settings.MyMRUList = New StringCollection
		UpdateMRU()

		' If the AI Updater is available then we can start the BackgroundWorker thread
		'
		If boolUpdaterAvailable Then
			bwUpdater.RunWorkerAsync(boolRunUpdater)
			My.Application.Log.WriteEntry(Date.Now() + " Software Update task started", TraceEventType.Information)
		End If

		' Process any command-line arguments
		'
		If My.Application.CommandLineArgs.Count = 1 Then
			If String.Compare(My.Application.CommandLineArgs(0), "/restart", True) = 0 Then
				RecoverLastSession(My.Application.CommandLineArgs(0))
				If File.Exists(RecoveryTable) Then File.Delete(RecoveryTable)
				If File.Exists(RecoveryData) Then File.Delete(RecoveryData)
				If File.Exists(RecoveryFile) Then File.Delete(RecoveryFile)
			ElseIf String.Compare(My.Application.CommandLineArgs(0), "/nosplash", True) = 0 Or String.Compare(My.Application.CommandLineArgs(0), "-nosplash", True) = 0 Then
				My.Application.Log.WriteEntry(String.Format("{0} Count:{1} Parameter: <{2}>", Date.Now(), My.Application.CommandLineArgs.Count, My.Application.CommandLineArgs(0)), TraceEventType.Information)
			Else
				My.Application.Log.WriteEntry(String.Format("{0} Count:{1} Parameter: <{2}>", Date.Now(), My.Application.CommandLineArgs.Count, My.Application.CommandLineArgs(0)), TraceEventType.Information)
				OpenTranscriptionFile(My.Application.CommandLineArgs(0))
			End If
		Else
			If My.Application.CommandLineArgs.Count = 2 Then
				My.Application.Log.WriteEntry(String.Format("{0} Count:{1} Parameter: <{2}> <{3}>", Date.Now(), My.Application.CommandLineArgs.Count, My.Application.CommandLineArgs(0), My.Application.CommandLineArgs(1)), TraceEventType.Information)
				If String.Compare(My.Application.CommandLineArgs(0), "/nosplash", True) = 0 Or String.Compare(My.Application.CommandLineArgs(0), "-nosplash", True) = 0 Then
					OpenTranscriptionFile(My.Application.CommandLineArgs(1))
				Else
					OpenTranscriptionFile(My.Application.CommandLineArgs(0))
				End If
			End If
		End If

		'	If the User Details have not been completely entered, then force the user to do so
		'
		If String.IsNullOrEmpty(My.Settings.Name) OrElse String.IsNullOrEmpty(My.Settings.EmailAddress) OrElse String.IsNullOrEmpty(My.Settings.Syndicate) Then
			Using dlg As New dlgOptions

				dlg.cbSyndicate.DataSource = tabChapmanCodes
				dlg.cbSyndicate.DisplayMember = "County"
				dlg.cbSyndicate.ValueMember = "Code"
				dlg.cbSyndicate.Text = My.Settings.Syndicate
				My.Settings.MyOptionsTab = 0

				If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
					My.Settings.Syndicate = dlg.cbSyndicate.Text
					ttMain.Active = My.Settings.MyDisplayTooltips
					If My.Settings.MyDisplayTooltips Then ttMain.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
					panelWinREG2.enableToolTip = My.Settings.MyDisplayTooltips
					ssMain.ShowItemToolTips = My.Settings.MyDisplayTooltips

					If String.IsNullOrEmpty(My.Settings.Name) OrElse String.IsNullOrEmpty(My.Settings.EmailAddress) OrElse String.IsNullOrEmpty(My.Settings.Syndicate) Then
						MessageBox.Show(My.Resources.err0034, "Missing User Details", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0034)
						Application.Exit()
					End If
				Else
					My.Settings.MyOptionsTab = 0
					Application.Exit()
				End If
			End Using
		End If

		' Initialise the FileSystemWatcher
		fswTranscripts.Path = My.Settings.DataFolderName
		fswTranscripts.Filter = "*.csv"
		fswTranscripts.NotifyFilter = NotifyFilters.Size Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName
		fswTranscripts.EnableRaisingEvents = True

		If Not Focused() Then
			mainDGV.Focus()
		End If
	End Sub

	Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
		ContentPanelBackground = tscMain.ContentPanel.BackColor

		'If TaskDialog.IsPlatformSupported Then
		'	Using tw As New TaskDialog()
		'		tw.Caption = "Caption"
		'		tw.Icon = TaskDialogStandardIcon.Warning
		'		tw.InstructionText = "Instruction text"
		'		tw.Text = "Text"
		'		tw.FooterText = "Footer"
		'		tw.OwnerWindowHandle = Me.Handle
		'		tw.Show()
		'	End Using
		'End If

		If TaskbarManager.IsPlatformSupported Then
			If boolJumpListEnabled Then
				jlist = JumpList.CreateJumpList()
				jlist.ClearAllUserTasks()
				jlist.KnownCategoryToDisplay = JumpListKnownCategoryType.Neither

				Dim Category As New JumpListCustomCategory("Recent File List")
				Dim appPath As String = My.Application.Info.DirectoryPath
				Dim appName As String = Path.Combine(appPath, "WinREG.exe")
				For Each s As String In My.Settings.MyMRUList
					Dim Link4 As New JumpListLink(appName, Path.GetFileNameWithoutExtension(s))
					Link4.IconReference = New IconReference(appName, 0)
					Link4.Arguments = s
					Category.AddJumpListItems(Link4)
				Next
				jlist.AddCustomCategories(Category)

				Try
					jlist.Refresh()

				Catch ex As UnauthorizedAccessException
					MessageBox.Show(My.Resources.msgJumpListDisabled, "Creat JumpList", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
				End Try
			End If
		End If

		mainWelcomeText.AllowDrop = True
		mainDGV.AllowDrop = True

	End Sub

	Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

		If boolThreadActive Then
			bwUpdater.CancelAsync()
			e.Cancel = True
			Return
		End If

		If boolCorruptionThreadActive Then
			bwCheckFile.CancelAsync()
			e.Cancel = True
			Return
		End If

		' If we still have a file open, then close it. If necessary, tell the user.
		'
		If fileOpen Then
			If e.CloseReason = CloseReason.UserClosing Or e.CloseReason = CloseReason.ApplicationExitCall Then
				If MessageBox.Show(My.Resources.msgConfirmExit, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
					e.Cancel = True
					Return
				End If
			End If
			CloseTranscriptionFile(e.CloseReason)
		End If

		' If the Lookup Tables have been changed, save them
		'
		If boolTablesChanged Then
			Dim fs As FileStream = Nothing
			Dim stmWriter As StreamWriter = Nothing

			Try
				fs = New FileStream(String.Format("{0}\{1}", _BaseDataDirectory, My.Resources.nameUserTablesFile), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite)
				stmWriter = New StreamWriter(fs, _Encoding)
				LookUpsDataSet.WriteXml(stmWriter, XmlWriteMode.WriteSchema)

			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst saving the Tables File")

			Finally
				If Not (stmWriter Is Nothing) Then stmWriter.Close()
				If Not (fs Is Nothing) Then fs.Close()
			End Try
		End If

		If LookUpsDataSet IsNot Nothing Then
			LookUpsDataSet.Dispose()
		End If

		If FreeRegbrowser IsNot Nothing Then
			FreeRegbrowser.Dispose()
		End If

		My.Settings.WindowState_MainForm = WindowState

		If WindowState = FormWindowState.Normal Then
			My.Settings.Size_MainForm = Size
			My.Settings.Location_MainForm = Location
		Else
			My.Settings.Size_MainForm = RestoreBounds.Size
			My.Settings.Location_MainForm = RestoreBounds.Location
		End If

		My.Application.Log.WriteEntry(String.Format("{0} FormClosing reason:<{1}>", Date.Now(), [Enum].GetName(GetType(CloseReason), e.CloseReason)), TraceEventType.Information)
	End Sub

	Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

		' Cleaning up (removal) of old log files - those over 7 days old
		'
		Dim di As DirectoryInfo = New DirectoryInfo(My.Settings.DataFolderName)
		For Each fi As FileInfo In di.GetFiles("*.log")
			Dim age = DateTime.Now().Date - fi.LastWriteTime.Date
			If age.Days > 7 Then
				My.Application.Log.WriteEntry(Date.Now() + " LogFile: " + fi.Name + " Age: " + age.ToString, TraceEventType.Information)
				File.Delete(fi.FullName)
			End If
		Next

		If File.Exists(RecoveryTable) Then File.Delete(RecoveryTable)
		If File.Exists(RecoveryData) Then File.Delete(RecoveryData)
		If File.Exists(RecoveryFile) Then File.Delete(RecoveryFile)
	End Sub

	Private Sub MainForm_HelpRequested(ByVal sender As Object, ByVal hlpevent As HelpEventArgs) Handles MyBase.HelpRequested
		Help.ShowHelp(Me, My.Settings.HelpFileName, HelpNavigator.TableOfContents)
		hlpevent.Handled = True
	End Sub

	Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
		Dim keycode = keyData And Keys.KeyCode
		Dim modifiers = keyData And Keys.Modifiers

		If modifiers = Keys.Control And keycode = Keys.S Then
			If fileChanged Then
				If SaveTranscriptionFile() Then
					fileChanged = False
					BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
				End If
			End If
			Return True
		ElseIf keyData = (Keys.Control Or Keys.End) Then								' Last Record
			BindingNavigatorMoveLastItem.PerformClick()
			Return True
		End If
		Return MyBase.ProcessCmdKey(msg, keyData)
	End Function

	''' <summary>
	''' Load the Lookup Tables from the WINREG.TABLES file
	''' </summary><remarks>
	''' Initially, all that exists will be the WINREG.TABLES file installed in the parent
	''' directory (the BaseDataDirectory). Since this file can be updated by the user, and
	''' we wish to preserve the updated file across upgrades, a separate, private user file
	''' needs to be used. Initially, this file will not exist and so can be created from the
	''' default WINREG.TABLES file.
	''' a) If WINREG.TABLES doesn't exist, create it and fill it
	''' b) If user file doesn't exist, create it from WINREG.TABLES
	''' c) Load the datatables
	''' </remarks>
	Private Sub LoadLookupTables()
		Dim fiDefault As FileInfo = New FileInfo(String.Format("{0}\{1}", _BaseDataDirectory, My.Resources.nameTablesFile))
		Dim fiUser As FileInfo = New FileInfo(String.Format("{0}\{1}", _BaseDataDirectory, My.Resources.nameUserTablesFile))
		Dim fname As String = fiDefault.FullName
		Dim fs As FileStream = Nothing
		Dim stmReader As StreamReader = Nothing
		Dim stmWriter As StreamWriter = Nothing

		If Not fiDefault.Exists Then
			Dim dsDefault As LookupTables = New LookupTables

			If dsDefault.RecordTypes.Rows.Count = 0 Then
				dsDefault.RecordTypes.AddRecordTypesRow("BA", "Baptisms")
				dsDefault.RecordTypes.AddRecordTypesRow("BU", "Burials")
				dsDefault.RecordTypes.AddRecordTypesRow("MA", "Marriages")
			End If

			If dsDefault.ChapmanCodes.Rows.Count = 0 Then
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CHI", "Channel Isles")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ENG", "England")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("IOM", "Isle of Man")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("IRL", "Ireland")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SCT", "Scotland")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WLS", "Wales")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ALL", "All countries")

				dsDefault.ChapmanCodes.AddChapmanCodesRow("ALD", "Alderney")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("GSY", "Guernsey")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("JSY", "Jersey")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SRK", "Sark")

				dsDefault.ChapmanCodes.AddChapmanCodesRow("BDF", "Bedfordshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("BRK", "Berkshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("BKM", "Buckinghamshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CAM", "Cambridgeshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CHS", "Cheshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CON", "Cornwall")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CUL", "Cumberland")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DBY", "Derbyshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DEV", "Devonshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DOR", "Dorset")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DUR", "Durham")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ESS", "Essex")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("GLS", "Gloucestershire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("HAM", "Hampshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("HEF", "Herefordshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("HRT", "Hertfordshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("HUN", "Huntingdonshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("IOW", "Isle of Wight")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("KEN", "Kent")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LAN", "Lancashire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LEI", "Leicestershire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LIN", "Lincolnshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LND", "London")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MDX", "Middlesex")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("NFK", "Norfolk")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("NTH", "Northamptonshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("NBL", "Northumberland")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("NTT", "Nottinghamshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("OXF", "Oxfordshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("RUT", "Rutland")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SAL", "Shropshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SOM", "Somerset")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("STS", "Staffordshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SFK", "Suffolk")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SRY", "Surrey")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SSX", "Sussex")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WAR", "Warwickshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WES", "Westmorland")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WIL", "Wiltshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WOR", "Worcestershire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("YKS", "Yorkshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ERY", "East Riding Yorkshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("NRY", "North Riding Yorkshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WRY", "West Riding Yorkshire")

				dsDefault.ChapmanCodes.AddChapmanCodesRow("ABD", "Aberdeenshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ANS", "Angus")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ARL", "Argyllshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("AYR", "Ayrshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("BAN", "Banffshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("BEW", "Berwickshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("BUT", "Bute")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CAI", "Caithness")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CLK", "Clackmannanshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DFS", "Dumfriesshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DNB", "Dunbartonshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ELN", "East Lothian")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("FIF", "Fifeshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("INV", "Inverness-shire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("KCD", "Kincardineshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("KRS", "Kinross-shire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("KKD", "Kircudbrightshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LKS", "Lanarkshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MLN", "Midlothian")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MOR", "Moray")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("NAI", "Nairnshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("OKI", "Orkney")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("PEE", "Peeblesshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("PER", "Perthshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("RFW", "Renfrewshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ROC", "Ross & Cromarty")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ROX", "Roxburghshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SEL", "Selkirkshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SHI", "Shetland")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("STI", "Stirlingshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SUT", "Sutherland")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WLN", "West Lothian")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WIG", "Wigtownshire")

				dsDefault.ChapmanCodes.AddChapmanCodesRow("BOR", "Borders")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CEN", "Central")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DGY", "Dumfries & Galloway")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("GMP", "Grampian")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("HLD", "Highland")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LTN", "Lothian")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("STD", "Strathclyde")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("TAY", "Tayside")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WIS", "Western Isles")

				dsDefault.ChapmanCodes.AddChapmanCodesRow("AGY", "Anglesey")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("BRE", "Brecknockshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CAE", "Caernarfonshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CGN", "Cardiganshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CMN", "Carmarthenshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DEN", "Denbighshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("FLN", "Flintshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("GLA", "Glamorgan")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MER", "Merionethshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MON", "Monmouthshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MGY", "Montgomeryshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("PEM", "Pembrokeshire")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("RAD", "Radnorshire")

				dsDefault.ChapmanCodes.AddChapmanCodesRow("CWD", "Clywd")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DFD", "Dyfed")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("GNT", "Gwent")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("GWN", "Gwynedd")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MGM", "Mid Glamorgan")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("POW", "Powys")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SGM", "South Glamorgan")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WGM", "West Glamorgan")

				dsDefault.ChapmanCodes.AddChapmanCodesRow("ANT", "Antrim")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ARM", "Armagh")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CAR", "Carlow")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CAV", "Cavan")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("CLA", "Clare")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("COR", "Cork")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DON", "Donegal")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DOW", "Down")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("DUB", "Dublin")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("FER", "Fermanagh")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("GAL", "Galway")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("KER", "Kerry")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("KID", "Kildare")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("KIK", "Kilkenny")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LET", "Leitrim")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LEX", "Leix")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LIM", "Limerick")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LDY", "Londonderry")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LOG", "Longford")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("LOU", "Louth")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MAY", "Mayo")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MEA", "Meath")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("MOG", "Monaghan")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("OFF", "Offaly")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("ROS", "Roscommon")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("SLI", "Sligo")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("TIP", "Tipperary")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("TYR", "Tyrone")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WAT", "Waterford")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WEM", "Westmeath")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WEX", "Wexford")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("WIC", "Wicklow")

				dsDefault.ChapmanCodes.AddChapmanCodesRow("OVB", "Overseas (British Subject)")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("OVF", "Overseas (Foreign)")
				dsDefault.ChapmanCodes.AddChapmanCodesRow("UNK", "Unknown")
			End If

			If dsDefault.BaptismSex.Rows.Count = 0 Then
				dsDefault.BaptismSex.AddBaptismSexRow("Application", String.Empty, String.Empty)
				dsDefault.BaptismSex.AddBaptismSexRow("Application", "-", "Unknown")
				dsDefault.BaptismSex.AddBaptismSexRow("Application", "M", "Male")
				dsDefault.BaptismSex.AddBaptismSexRow("Application", "F", "Female")
			End If

			If dsDefault.BurialRelationship.Rows.Count = 0 Then
				dsDefault.BurialRelationship.AddBurialRelationshipRow("Application", String.Empty, String.Empty)
				dsDefault.BurialRelationship.AddBurialRelationshipRow("Application", "son of", "son of")
				dsDefault.BurialRelationship.AddBurialRelationshipRow("Application", "dau of", "dau of")
				dsDefault.BurialRelationship.AddBurialRelationshipRow("Application", "wife of", "wife of")
				dsDefault.BurialRelationship.AddBurialRelationshipRow("Application", "husband of", "husband of")
				dsDefault.BurialRelationship.AddBurialRelationshipRow("Application", "widow of", "widow of")
				dsDefault.BurialRelationship.AddBurialRelationshipRow("Application", "relict of", "relict of")
			End If

			If dsDefault.GroomCondition.Rows.Count = 0 Then
				dsDefault.GroomCondition.AddGroomConditionRow("Application", String.Empty, String.Empty)
				dsDefault.GroomCondition.AddGroomConditionRow("Application", "bachelor", "bachelor")
				dsDefault.GroomCondition.AddGroomConditionRow("Application", "widower", "widower")
				dsDefault.GroomCondition.AddGroomConditionRow("Application", "single", "single man")
				dsDefault.GroomCondition.AddGroomConditionRow("Application", "virgin", "virgin")
				dsDefault.GroomCondition.AddGroomConditionRow("Application", "annulled", "previous marriage annulled")
				dsDefault.GroomCondition.AddGroomConditionRow("Application", "divorced", "divorced man")
				dsDefault.GroomCondition.AddGroomConditionRow("Application", "dissolved", "previous marriage dissolved")
				dsDefault.GroomCondition.AddGroomConditionRow("Application", "minor", "minor")
			End If

			If dsDefault.BrideCondition.Rows.Count = 0 Then
				dsDefault.BrideCondition.AddBrideConditionRow("Application", String.Empty, String.Empty)
				dsDefault.BrideCondition.AddBrideConditionRow("Application", "spinster", "spinster")
				dsDefault.BrideCondition.AddBrideConditionRow("Application", "widow", "widow")
				dsDefault.BrideCondition.AddBrideConditionRow("Application", "single", "single woman")
				dsDefault.BrideCondition.AddBrideConditionRow("Application", "maiden", "maiden")
				dsDefault.BrideCondition.AddBrideConditionRow("Application", "virgin", "virgin")
				dsDefault.BrideCondition.AddBrideConditionRow("Application", "minor", "minor")
				dsDefault.BrideCondition.AddBrideConditionRow("Application", "divorcee", "divorcee")
				dsDefault.BrideCondition.AddBrideConditionRow("Application", "annulled", "previous marriage annulled")
				dsDefault.BrideCondition.AddBrideConditionRow("Application", "dissolved", "previous marriage dissolved")
			End If

			Try
				fs = New FileStream(fname, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
				stmWriter = New StreamWriter(fs, _Encoding)
				dsDefault.AcceptChanges()
				dsDefault.WriteXml(stmWriter, Data.XmlWriteMode.WriteSchema)

			Catch ex As Exception
				My.Application.Log.WriteEntry(Date.Now() + " Unable to create the Tables File.", TraceEventType.Error)
				MessageBox.Show(My.Resources.err0010, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0010)
				Application.Exit()

			Finally
				If Not (stmWriter Is Nothing) Then stmWriter.Close()
				If Not (fs Is Nothing) Then fs.Close()
				My.Application.Log.WriteEntry(Date.Now() + " Tables file has been created", TraceEventType.Information)
			End Try
		End If

		'	Check for the user version of the file
		'
		If Not fiUser.Exists Then
			Try
				'	Create the missing user file
				'
				File.Copy(fiDefault.FullName, fiUser.FullName)
				fname = fiUser.FullName

			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst creating User copy of the Tables File")
			End Try

		Else
			fname = fiUser.FullName
			If fiDefault.LastWriteTime > fiUser.LastWriteTime Then
				'	Incoming default file is more recent than the user file - Try and merge the two
				'
				Dim dsDefault As LookupTables = New LookupTables
				fs = New FileStream(fiDefault.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
				stmReader = New StreamReader(fs, _Encoding)
				dsDefault.ReadXml(stmReader, Data.XmlReadMode.ReadSchema)
				stmReader.Close()
				fs.Close()

				Dim dsUser As LookupTables = New LookupTables
				fs = New FileStream(fiUser.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
				stmReader = New StreamReader(fs, _Encoding)
				dsUser.ReadXml(stmReader, Data.XmlReadMode.ReadSchema)
				stmReader.Close()
				fs.Close()

				For Each dt As DataTable In dsDefault.Tables
					Dim dt1 As DataTable = dt
					Dim seq1 As IEnumerable(Of DataRow) = dt1.AsEnumerable()
					Dim union1 As IEnumerable(Of DataRow)
					If dsDefault.Tables.Contains(dt1.TableName + "Table") Then
						Dim dt3 As DataTable = dsDefault.Tables(dt1.TableName + "Table")
						Dim seq3 As IEnumerable(Of DataRow) = dt3.AsEnumerable()
						union1 = seq1.Union(seq3, DataRowComparer.Default)
					Else
						union1 = seq1
					End If

					'	Need to merge all of fiDefault with just the User records from fiUser
					'
					Dim dt2 As DataTable = dsUser.Tables(dt.TableName)
					If dt2 IsNot Nothing Then
						Dim seq2 As IEnumerable(Of DataRow) = dt2.AsEnumerable().Where(Function(row As DataRow) row(0) = "User")
						Dim union2 As IEnumerable(Of DataRow)
						If dsUser.Tables.Contains(dt2.TableName + "Table") Then
							Dim dt4 As DataTable = dsUser.Tables(dt2.TableName + "Table")
							Dim seq4 As IEnumerable(Of DataRow) = dt4.AsEnumerable().Where(Function(row As DataRow) row(0) = "User")
							union2 = seq2.Union(seq4, DataRowComparer.Default)
						Else
							union2 = seq2
						End If

						Dim union As IEnumerable(Of DataRow) = union1.Union(union2, DataRowComparer.Default)
						If union.Count > 0 Then
							If Not dt.TableName.Contains("Table") Then
								Dim dtu = union.CopyToDataTable()
								dsUser.Tables(dt.TableName).Clear()
								For Each row In dtu.Rows
									dsUser.Tables(dt.TableName).ImportRow(row)
								Next
								dsUser.Tables(dt.TableName).AcceptChanges()
							Else
								dsUser.Tables.Remove(dt.TableName)
							End If
						End If
					End If
				Next

				fs = New FileStream(fname, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
				stmWriter = New StreamWriter(fs, _Encoding)
				dsUser.WriteXml(stmWriter, XmlWriteMode.WriteSchema)
				boolTablesChanged = True
				stmWriter.Close()
				fs.Close()
			End If
		End If

		'	Load the tables
		'
		Try
			fs = New FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
			stmReader = New StreamReader(fs, _Encoding)
			LookUpsDataSet.ReadXml(stmReader, XmlReadMode.ReadSchema)

		Catch ex As Xml.XmlException
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst loading the Tables File")

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst loading the Tables File")

		Finally
			For Each dt As DataTable In LookUpsDataSet.Tables
				dt.AcceptChanges()
				My.Application.Log.WriteEntry(String.Format("{0} Table:{1} has {2} entries", Date.Now(), dt.TableName, dt.Rows.Count), TraceEventType.Information)
			Next
			If Not (stmReader Is Nothing) Then stmReader.Close()
			If Not (fs Is Nothing) Then fs.Close()
		End Try

	End Sub

#End Region

#Region "Restart and Recovery"
	Public Sub RegisterForRestart()
		' Register for automatic restart if the 
		' application was terminated for any reason
		' other than a system reboot or a system update.
		ApplicationRestartRecoveryManager.RegisterForApplicationRestart(New RestartSettings("/restart", RestartRestrictions.NotOnReboot Or RestartRestrictions.NotOnPatch))
		My.Application.Log.WriteEntry(String.Format("{0} Registered for ApplicationRestart", Date.Now()), TraceEventType.Information)
	End Sub

	Public Sub RegisterForRecovery()
		' Don't pass any state. We'll use our static variable "CurrentFile" to determine
		' the current state of the application.
		' Since this registration is being done on application startup, we don't have a state currently.
		' In some cases it might make sense to pass this initial state.
		' Another approach: When doing "auto-save", register for recovery everytime, and pass
		' the current state at that time. 
		Dim data As New RecoveryData(New RecoveryCallback(AddressOf RecoveryProcedure), Nothing)
		Dim settings As New RecoverySettings(data, 60000)
		startTime = DateTime.Now
		tickRecovery.Enabled = True
		ApplicationRestartRecoveryManager.RegisterForApplicationRecovery(settings)
		My.Application.Log.WriteEntry(String.Format("{0} Registered for ApplicationRecovery", Date.Now()), TraceEventType.Information)
	End Sub

	Private Function RecoveryProcedure(ByVal state As Object) As Integer

		' Do recovery work here.
		' Signal to WER that the recovery is still in progress.
		If fileOpen Then
			My.Application.Log.WriteEntry(String.Format("{0} Saving Recovery Information for : {1}", Date.Now(), _File.Filename), TraceEventType.Information)

			PingSystem()
			Dim myFile As FileStream = New FileStream(RecoveryFile, FileMode.Create, FileAccess.Write, FileShare.None)
			Dim ser As BinaryFormatter = New BinaryFormatter()

			Try
				_File.fileOpen = fileOpen
				_File.fileChanged = fileChanged
				_File.ldsFile = ldsFile
				_File.fileNew = fileNew

				ser.Serialize(myFile, _File)
				myFile.Close()
				ApplicationRestartRecoveryManager.ApplicationRecoveryFinished(True)

			Catch ex As Exception
				ApplicationRestartRecoveryManager.ApplicationRecoveryFinished(False)
			End Try
		Else
			If File.Exists(RecoveryTable) Then File.Delete(RecoveryTable)
			If File.Exists(RecoveryData) Then File.Delete(RecoveryData)
			If File.Exists(RecoveryFile) Then File.Delete(RecoveryFile)
			ApplicationRestartRecoveryManager.ApplicationRecoveryFinished(True)
		End If

		Return 0
	End Function

	Private Sub PingSystem()
		If ApplicationRestartRecoveryManager.ApplicationRecoveryInProgress() Then
			My.Application.Log.WriteEntry(String.Format("{0} Recovery has been cancelled by user.", Date.Now()), TraceEventType.Information)
			Environment.Exit(2)
		End If
	End Sub

	Private Sub RecoverLastSession(ByVal command As String)
		If Not File.Exists(RecoveryFile) Then
			MessageBox.Show(String.Format("Recovery file {0} does not exist", RecoveryFile), "File Recovery")
			Return
		End If

		If Not File.Exists(RecoveryTable) Then
			MessageBox.Show(String.Format("Recovery file {0} does not exist", RecoveryTable), "File Recovery")
			Return
		End If

		Dim myReader As FileStream = New FileStream(RecoveryFile, FileMode.Open, FileAccess.Read, FileShare.Read)
		Dim ser As BinaryFormatter = New BinaryFormatter()

		Try
			Dim tf As FileHeader = ser.Deserialize(myReader)
			_File = tf
			fileOpen = _File.fileOpen
			fileChanged = _File.fileChanged
			ldsFile = _File.ldsFile
			fileNew = _File.fileNew
			MessageBox.Show(String.Format("Recovering file: {0}", tf.Filename), "File Recovery", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

			My.Application.Log.WriteEntry(String.Format("{0} Recovering: {1}", Date.Now(), _File.Filename), TraceEventType.Information)
			Dim ds As TranscriptionTables = New TranscriptionTables()
			Dim dt As DataTable

			acscAbodes.Clear()
			acscOccupations.Clear()
			acscFiche.Clear()
			acscImage.Clear()
			My.Settings.UseDataGrid = True
			mainDGV.RowOffset = IIf(ldsFile, 5, 4)

			Select Case _File.FileType
				Case "BAPTISMS"
					Dim mode = ds.Baptisms.ReadXml(RecoveryTable)
					dt = ds.Baptisms

					For Each nrow As BaptismsRow In dt.Rows
						AddStringToCollection(acscAbodes, nrow.Abode)
						AddStringToCollection(acscOccupations, nrow.FathersOccupation)

						AddStringToCollection(acscFiche, nrow.LDSFiche)
						AddStringToCollection(acscImage, nrow.LDSImage)
					Next

				Case "BURIALS"
					Dim mode = ds.Burials.ReadXml(RecoveryTable)
					dt = ds.Burials

					For Each nrow As BurialsRow In dt.Rows
						AddStringToCollection(acscAbodes, nrow.Abode)

						AddStringToCollection(acscFiche, nrow.LDSFiche)
						AddStringToCollection(acscImage, nrow.LDSImage)
					Next

				Case "MARRIAGES"
					Dim mode = ds.Marriages.ReadXml(RecoveryTable)
					dt = ds.Marriages

					For Each nrow As MarriagesRow In dt.Rows
						AddStringToCollection(acscAbodes, nrow.GroomParish)
						AddStringToCollection(acscAbodes, nrow.GroomAbode)
						AddStringToCollection(acscAbodes, nrow.BrideParish)
						AddStringToCollection(acscAbodes, nrow.BrideAbode)

						AddStringToCollection(acscOccupations, nrow.GroomOccupation)
						AddStringToCollection(acscOccupations, nrow.BrideOccupation)
						AddStringToCollection(acscOccupations, nrow.GroomFatherOccupation)
						AddStringToCollection(acscOccupations, nrow.BrideFatherOccupation)

						AddStringToCollection(acscFiche, nrow.LDSFiche)
						AddStringToCollection(acscImage, nrow.LDSImage)
					Next

				Case Else
					dt = New DataTable()
			End Select

			mainDGV.Columns.Clear()
			mainDGV.Rows.Clear()
			mainDGV.AutoGenerateColumns = False
			SetDataGridViewHeadings(_File.FileType)
			PopulateDataGridView(dt)
			BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
			tsEdit.Visible = fileOpen And My.Settings.UseDataGrid
			BindingNavigatorCopyButton.Enabled = fileOpen And My.Settings.UseDataGrid
			BindingNavigatorCutButton.Enabled = fileOpen And My.Settings.UseDataGrid
			BindingNavigatorPasteButton.Enabled = fileOpen And My.Settings.UseDataGrid
			tsRecord.Visible = fileOpen
			ShowContentDisplay()

			If ldsFile Then
				Text = String.Format("{0} LDS - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
			Else
				Text = String.Format("{0} - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
			End If

			If _User.IsAdministrator Then
				Dim str As String = String.Format("{0} (Administrator)", Text())
				Text = str
			End If
			My.Application.Log.WriteEntry(String.Format("{0} Recovered {2} records in {1}", Date.Now(), _File.Filename, dt.Rows.Count), TraceEventType.Information)

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst Recovering Last Session")
		End Try

		myReader.Close()

	End Sub

	Private Sub tickRecovery_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tickRecovery.Tick
		Dim span As TimeSpan = DateTime.Now.Subtract(startTime)
		Dim running As Integer = CInt(Fix(span.TotalSeconds))
		If running >= 60 Then
			My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
			tickRecovery.Enabled = False
			lblInformation.Text = "Windows has now enabled Restart & Recovery"
			tickDisplay.Enabled = True
		End If
	End Sub

#End Region

#Region "Table & DataGridView Headings"

	Private Sub SetDataTableHeadings(ByRef dt As DataTable, ByVal fileType As String)
		Dim boolNewTable As Boolean = dt.Columns.Count = 0

		If boolNewTable Then
			With dt.Columns
				.Add("County")
				.Add("Place")
				.Add("Church")
				.Add("RegNo")
				Select Case fileType
					Case "BAPTISMS"
						.Add("BirthDate")
						.Add("BaptismDate")
						.Add("Forenames")
						.Add("Sex")
						.Add("FathersName")
						.Add("MothersName")
						.Add("FathersSurname")
						.Add("MothersSurname")
						.Add("Abode")
						.Add("FathersOccupation")

					Case "BURIALS"
						.Add("BurialDate")
						.Add("Forenames")
						.Add("Relationship")
						.Add("MaleForenames")
						.Add("FemaleForenames")
						.Add("RelativeSurname")
						.Add("Surname")
						.Add("Age")
						.Add("Abode")

					Case "MARRIAGES"
						.Add("MarriageDate")
						.Add("GroomForenames")
						.Add("GroomSurname")
						.Add("GroomAge")
						.Add("GroomParish")
						.Add("GroomCondition")
						.Add("GroomOccupation")
						.Add("GroomAbode")
						.Add("BrideForenames")
						.Add("BrideSurname")
						.Add("BrideAge")
						.Add("BrideParish")
						.Add("BrideCondition")
						.Add("BrideOccupation")
						.Add("BrideAbode")
						.Add("GroomFatherForenames")
						.Add("GroomFatherSurname")
						.Add("GroomFatherOccupation")
						.Add("BrideFatherForenames")
						.Add("BrideFatherSurname")
						.Add("BrideFatherOccupation")
						.Add("Witness1Forenames")
						.Add("Witness1Surname")
						.Add("Witness2Forenames")
						.Add("Witness2Surname")

				End Select
				.Add("Notes")
				.Add("Fiche")
				.Add("Image")
			End With
		End If

		dt.Columns(0).ColumnName = "County"
		dt.Columns(0).Caption = "County"

		dt.Columns(1).ColumnName = "Place"
		dt.Columns(1).Caption = "Place name"

		dt.Columns(2).ColumnName = "Church"
		dt.Columns(2).Caption = "Church name"

		dt.Columns(3).ColumnName = "RegNo"
		dt.Columns(3).Caption = "Register number"

		Select Case fileType
			Case "BAPTISMS"
				dt.Columns(4).ColumnName = "BirthDate"
				dt.Columns(4).Caption = "Birth date"

				dt.Columns(5).ColumnName = "BaptismDate"
				dt.Columns(5).Caption = "Baptism date"

				dt.Columns(6).ColumnName = "Forenames"
				dt.Columns(6).Caption = "First names"

				dt.Columns(7).ColumnName = "Sex"
				dt.Columns(7).Caption = "Sex"

				dt.Columns(8).ColumnName = "FathersName"
				dt.Columns(8).Caption = "Father's name"

				dt.Columns(9).ColumnName = "MothersName"
				dt.Columns(9).Caption = "Mother's name"

				dt.Columns(10).ColumnName = "FathersSurname"
				dt.Columns(10).Caption = "Father's Surname"

				dt.Columns(11).ColumnName = "MothersSurname"
				dt.Columns(11).Caption = "Mother's Surname"

				dt.Columns(12).ColumnName = "Abode"
				dt.Columns(12).Caption = "Abode"

				dt.Columns(13).ColumnName = "FathersOccupation"
				dt.Columns(13).Caption = "Father's occupation"

				dt.Columns(14).ColumnName = "Notes"
				dt.Columns(14).Caption = "Notes"

				If ldsFile Then
					dt.Columns(15).ColumnName = "Fiche"
					dt.Columns(15).Caption = "File/Fiche"
					dt.Columns(16).ColumnName = "Image"
					dt.Columns(16).Caption = "Image"
				End If

			Case "BURIALS"
				dt.Columns(4).ColumnName = "BurialDate"
				dt.Columns(4).Caption = "Burial date"

				dt.Columns(5).ColumnName = "Forenames"
				dt.Columns(5).Caption = "First names"

				dt.Columns(6).ColumnName = "Relationship"
				dt.Columns(6).Caption = "Relationship"

				dt.Columns(7).ColumnName = "MaleForenames"
				dt.Columns(7).Caption = "Male relative forenames"

				dt.Columns(8).ColumnName = "FemaleForenames"
				dt.Columns(8).Caption = "Female relative forenames"

				dt.Columns(9).ColumnName = "RelativeSurname"
				dt.Columns(9).Caption = "Relative surname"

				dt.Columns(10).ColumnName = "Surname"
				dt.Columns(10).Caption = "Surname"

				dt.Columns(11).ColumnName = "Age"
				dt.Columns(11).Caption = "Age"

				dt.Columns(12).ColumnName = "Abode"
				dt.Columns(12).Caption = "Abode"

				dt.Columns(13).ColumnName = "Notes"
				dt.Columns(13).Caption = "Notes"

				If ldsFile Then
					dt.Columns(14).ColumnName = "Fiche"
					dt.Columns(14).Caption = "File/Fiche"
					dt.Columns(15).ColumnName = "Image"
					dt.Columns(15).Caption = "Image"
				End If

			Case "MARRIAGES"
				dt.Columns(4).ColumnName = "MarriageDate"
				dt.Columns(4).Caption = "Marriage date"

				dt.Columns(5).ColumnName = "GroomForenames"
				dt.Columns(5).Caption = "Groom forenames"

				dt.Columns(6).ColumnName = "GroomSurname"
				dt.Columns(6).Caption = "Groom surname"

				dt.Columns(7).ColumnName = "GroomAge"
				dt.Columns(7).Caption = "Groom Age"

				dt.Columns(8).ColumnName = "GroomParish"
				dt.Columns(8).Caption = "Groom Parish"

				dt.Columns(9).ColumnName = "GroomCondition"
				dt.Columns(9).Caption = "Groom condition"

				dt.Columns(10).ColumnName = "GroomOccupation"
				dt.Columns(10).Caption = "Groom occupation"

				dt.Columns(11).ColumnName = "GroomAbode"
				dt.Columns(11).Caption = "Groom Abode"

				dt.Columns(12).ColumnName = "BrideForenames"
				dt.Columns(12).Caption = "Bride forenames"

				dt.Columns(13).ColumnName = "BrideSurname"
				dt.Columns(13).Caption = "Bride surname"

				dt.Columns(14).ColumnName = "BrideAge"
				dt.Columns(14).Caption = "Bride Age"

				dt.Columns(15).ColumnName = "BrideParish"
				dt.Columns(15).Caption = "Bride Parish"

				dt.Columns(16).ColumnName = "BrideCondition"
				dt.Columns(16).Caption = "Bride condition"

				dt.Columns(17).ColumnName = "BrideOccupation"
				dt.Columns(17).Caption = "Bride occupation"

				dt.Columns(18).ColumnName = "BrideAbode"
				dt.Columns(18).Caption = "Bride Abode"

				dt.Columns(19).ColumnName = "GroomFatherForenames"
				dt.Columns(19).Caption = "Groom Father forenames"

				dt.Columns(20).ColumnName = "GroomFatherSurname"
				dt.Columns(20).Caption = "Groom Father surname"

				dt.Columns(21).ColumnName = "GroomFatherOccupation"
				dt.Columns(21).Caption = "Groom Father occupation"

				dt.Columns(22).ColumnName = "BrideFatherForenames"
				dt.Columns(22).Caption = "Bride Father forenames"

				dt.Columns(23).ColumnName = "BrideFatherSurname"
				dt.Columns(23).Caption = "Bride Father surname"

				dt.Columns(24).ColumnName = "BrideFatherOccupation"
				dt.Columns(24).Caption = "Bride Father occupation"

				dt.Columns(25).ColumnName = "Witness1Forenames"
				dt.Columns(25).Caption = "Witness 1 forenames"

				dt.Columns(26).ColumnName = "Witness1Surname"
				dt.Columns(26).Caption = "Witness 1 surname"

				dt.Columns(27).ColumnName = "Witness2Forenames"
				dt.Columns(27).Caption = "Witness 2 forenames"

				dt.Columns(28).ColumnName = "Witness2Surname"
				dt.Columns(28).Caption = "Witness 2 surname"

				dt.Columns(29).ColumnName = "Notes"
				dt.Columns(29).Caption = "Notes"

				If ldsFile Then
					dt.Columns(30).ColumnName = "Fiche"
					dt.Columns(30).Caption = "File/Fiche"
					dt.Columns(31).ColumnName = "Image"
					dt.Columns(31).Caption = "Image"
				End If

		End Select
	End Sub

	Private Sub SetDataGridViewHeadings(ByVal fileType As String)
		Dim col As DataGridViewTextBoxColumn
		Dim col1 As DataGridViewComboBoxColumn
		Dim col2 As CaseTextColumn
		Dim idx As Integer

		'		mainDGV
		col = New DataGridViewTextBoxColumn() With {.Name = "County", .HeaderText = "County", .DataPropertyName = "County", .SortMode = DataGridViewColumnSortMode.NotSortable, .Visible = False}
		col.HeaderCell.ContextMenuStrip = popColumnsVisibility
		col.ToolTipText = _
		"The Chapman Code for the county in which the register belongs"
		idx = mainDGV.Columns.Add(col)

		col = New DataGridViewTextBoxColumn() With {.Name = "Place", .HeaderText = "Place name", .DataPropertyName = "Place", .SortMode = DataGridViewColumnSortMode.NotSortable}
		col.HeaderCell.ContextMenuStrip = popColumnsVisibility
		col.ToolTipText = _
		"The name of the Parish or Place/Village in which the Church" + vbCrLf + _
		"is located"
		idx = mainDGV.Columns.Add(col)

		col = New DataGridViewTextBoxColumn() With {.Name = "Church", .HeaderText = "Church name", .DataPropertyName = "Church", .SortMode = DataGridViewColumnSortMode.NotSortable}
		col.HeaderCell.ContextMenuStrip = popColumnsVisibility
		col.ToolTipText = _
		"The name of the Church as it appears on the title page of the" + vbCrLf + _
		"register or source document. Use the suffix BT or AT to indicate" + vbCrLf + _
		"that the transcript is of Bishops or Archdeacons Transcripts" + vbCrLf + _
		"rather than the actual register"
		idx = mainDGV.Columns.Add(col)

		col = New DataGridViewTextBoxColumn() With {.Name = "RegNo", .HeaderText = "Register number", .DataPropertyName = "RegNo", .SortMode = DataGridViewColumnSortMode.Programmatic}
		col.DefaultCellStyle.NullValue = String.Empty
		col.DefaultCellStyle.DataSourceNullValue = String.Empty
		col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
		col.MaxInputLength = 5
		col.ValueType = GetType(String)
		col.HeaderCell.ContextMenuStrip = popColumnsVisibility
		col.ToolTipText = _
		 "The Register Number for the entry. This is the number of the" + vbCrLf + _
		 "entry within the register. Not all registers number their" + vbCrLf + _
		 "entries. If no number is present, leave the field blank."
		'		col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
		idx = mainDGV.Columns.Add(col)

		col2 = New CaseTextColumn() With {.Name = "Fiche", .HeaderText = "Fiche/Film number", .DataPropertyName = "LDSFiche", .SortMode = DataGridViewColumnSortMode.Programmatic}
		col2.DefaultCellStyle.NullValue = String.Empty
		col2.DefaultCellStyle.DataSourceNullValue = String.Empty
		col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
		col2.Visible = ldsFile
		col2.ValueType = GetType(String)
		col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
		col2.ToolTipText = _
		 "Fiche or Film number"
		'		col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
		idx = mainDGV.Columns.Add(col2)

		col2 = New CaseTextColumn() With {.Name = "Image", .HeaderText = "Image", .DataPropertyName = "LDSImage", .SortMode = DataGridViewColumnSortMode.Programmatic}
		col2.DefaultCellStyle.NullValue = String.Empty
		col2.DefaultCellStyle.DataSourceNullValue = String.Empty
		col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
		col2.Visible = ldsFile
		col2.ValueType = GetType(String)
		col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
		col2.ToolTipText = _
		 "Image number"
		'		col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
		idx = mainDGV.Columns.Add(col2)

		Select Case fileType
			Case "BAPTISMS"
				col = New DataGridViewTextBoxColumn()
				col.Name = "BirthDate"
				col.HeaderText = "Birth date"
				col.DataPropertyName = "BirthDate"
				col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				col.DefaultCellStyle.NullValue = String.Empty
				col.DefaultCellStyle.DataSourceNullValue = String.Empty
				col.SortMode = DataGridViewColumnSortMode.Programmatic
				col.ValueType = GetType(String)
				col.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col.ToolTipText = _
				"The date of birth of the person. Enter this in the standard way" + vbCrLf + _
				"for dates. Use the F4 key for assistance with entering the date"
				'				col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
				idx = mainDGV.Columns.Add(col)

				col = New DataGridViewTextBoxColumn()
				col.Name = "BaptismDate"
				col.HeaderText = "Baptism date"
				col.DataPropertyName = "BaptismDate"
				col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				col.DefaultCellStyle.NullValue = String.Empty
				col.DefaultCellStyle.DataSourceNullValue = String.Empty
				col.SortMode = DataGridViewColumnSortMode.Programmatic
				col.ValueType = GetType(String)
				col.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col.ToolTipText = _
				"The date of the baptism of the person. Enter this in the standard" + vbCrLf + _
				"way for dates. Use the F4 key for assistance with entering the date"
				'				col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
				idx = mainDGV.Columns.Add(col)

				col2 = New CaseTextColumn()
				col2.Name = "Forenames"
				col2.HeaderText = "First name(s)"
				col2.DataPropertyName = "Forenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the person being baptised." + vbCrLf + _
				"Where multiple names or initials have been recorded, enter them as" + vbCrLf + _
				"they have been recorded. The program will capitalise the first letter" + vbCrLf + _
				"of each name. Any or all of the names can be entered using the UCF" + vbCrLf + _
				"notation. Pressing the F5 key will present a dialog which will" + vbCrLf + _
				"facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col1 = New DataGridViewComboBoxColumn()
				col1.Name = "Sex"
				col1.HeaderText = "Sex"
				col1.DataPropertyName = "Sex"
				col1.DefaultCellStyle.NullValue = String.Empty
				col1.DefaultCellStyle.DataSourceNullValue = String.Empty
				col1.DataSource = tabBapSex
				col1.ValueMember = tabBapSex.Columns("Code").ColumnName
				col1.DisplayMember = tabBapSex.Columns("Description").ColumnName
				col1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
				col1.SortMode = DataGridViewColumnSortMode.NotSortable
				col1.AutoComplete = True
				col1.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col1.ToolTipText = _
				"The Sex of the person being baptised. Select one of the entries from" + vbCrLf + _
				"the drop-down list. If there is no indication in the actual entry," + vbCrLf + _
				"leave the field blank. If the actual entry is unreadable, select the" + vbCrLf + _
				"hyphen. Otherwise select eith Male or Female. Translate Latin words" + vbCrLf + _
				"as appropriate. Son and Daughter are to be translated into Male and" + vbCrLf + _
				"Female."
				idx = mainDGV.Columns.Add(col1)

				col2 = New CaseTextColumn()
				col2.Name = "FathersName"
				col2.HeaderText = "Father's first name(s)"
				col2.DataPropertyName = "FathersName"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the father of the person" + vbCrLf + _
				"being baptised. Where multiple names or initials have been recorded," + vbCrLf + _
				"enter them as they have been recorded. The program will capitalise" + vbCrLf + _
				"the first letter of each name. Any or all of the names can be entered" + vbCrLf + _
				"using the UCF notation. Pressing the F5 key will present a dialog which" + vbCrLf + _
				"will facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "MothersName"
				col2.HeaderText = "Mother's first name(s)"
				col2.DataPropertyName = "MothersName"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the mother of the person" + vbCrLf + _
				"being baptised. Where multiple names or initials have been recorded," + vbCrLf + _
				"enter them as they have been recorded. The program will capitalise" + vbCrLf + _
				"the first letter of each name. Any or all of the names can be entered" + vbCrLf + _
				"using the UCF notation. Pressing the F5 key will present a dialog which" + vbCrLf + _
				"will facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "FathersSurname"
				col2.HeaderText = "Father's surname"
				col2.DataPropertyName = "FathersSurname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The surname of the father. The program will automatically" + vbCrLf + _
				"capitalise the name as it is entered. The field will accept a" + vbCrLf + _
				"name entered in the UCF format. To facilitate this, pressing" + vbCrLf + _
				"the F5 key will present a dialog to assist with the entry of" + vbCrLf + _
				"a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "MothersSurname"
				col2.HeaderText = "Mother's surname"
				col2.DataPropertyName = "MothersSurname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The surname of the mother. The program will automatically" + vbCrLf + _
				"capitalise the name as it is entered. The field will accept a" + vbCrLf + _
				"name entered in the UCF format. To facilitate this, pressing" + vbCrLf + _
				"the F5 key will present a dialog to assist with the entry of" + vbCrLf + _
				"a UCF-formatted name." + vbCrLf + _
				"" + vbCrLf + _
				"Only enter the mother's surname when it is different to that" + vbCrLf + _
				"of the father. The intention here is to record the maiden or" + vbCrLf + _
				"former name of the mother, not her married name"
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "Abode"
				col2.HeaderText = "Abode"
				col2.DataPropertyName = "Abode"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The Abode of the parents, if given. If the actual entry states" + vbCrLf + _
				"where the family comes from, enter it. Otherwise, leave it blank." + vbCrLf + _
				"The program will automatically capitalise the name as it is" + vbCrLf + _
				"entered. The field will accept a name entered in the UCF format." + vbCrLf + _
				"To facilitate this, pressing the F5 key will present a dialog" + vbCrLf + _
				"to assist with the entry of a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "FathersOccupation"
				col2.HeaderText = "Father's occupation"
				col2.DataPropertyName = "FathersOccupation"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The occupation or standing of the father of the person being" + vbCrLf + _
				"baptised - if it was stated" + vbCrLf + _
				"" + vbCrLf + _
				"The program maintains a list of all the values entered in this" + vbCrLf + _
				"column within a file. The list can, if it has been enabled in" + vbCrLf + _
				"Options dialog, provide a short-hand means of entering a set" + vbCrLf + _
				"of consistent values." + vbCrLf + _
				"" + vbCrLf + _
				"When enabled, typing a letter should present a shortlist of all" + vbCrLf + _
				"the previously entered values that begin with the characters" + vbCrLf + _
				"entered so far. You can either continue entering characters one" + vbCrLf + _
				"by one and see the list shorten, or use the up and down arrow" + vbCrLf + _
				"keys to select a previously entered value. Clicking the mouse" + vbCrLf + _
				"on an entry from the list will also select that entry. Then," + vbCrLf + _
				"press the ENTER key to insert the selected value into the field."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

			Case "BURIALS"
				col = New DataGridViewTextBoxColumn()
				col.Name = "BurialDate"
				col.HeaderText = "Burial date"
				col.DataPropertyName = "BurialDate"
				col.DefaultCellStyle.NullValue = String.Empty
				col.DefaultCellStyle.DataSourceNullValue = String.Empty
				col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				col.SortMode = DataGridViewColumnSortMode.Programmatic
				col.ValueType = GetType(String)
				col.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col.ToolTipText = _
				"The date on which the burial of the person took place. Enter" + vbCrLf + _
				"this in the standard way for dates. Use the F4 key for" + vbCrLf + _
				"assistance with entering the date"
				'				col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
				idx = mainDGV.Columns.Add(col)

				col2 = New CaseTextColumn()
				col2.Name = "Forenames"
				col2.HeaderText = "First name(s)"
				col2.DataPropertyName = "Forenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the person being buried." + vbCrLf + _
				"Where multiple names or initials have been recorded, enter them" + vbCrLf + _
				"as they have been recorded. The program will capitalise the first" + vbCrLf + _
				"letter of each name. Any or all of the names can be entered using" + vbCrLf + _
				"the UCF notation. Pressing the F5 key will present a dialog which" + vbCrLf + _
				"will facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col1 = New DataGridViewComboBoxColumn()
				col1.Name = "Relationship"
				col1.HeaderText = "Relationship"
				col1.DataPropertyName = "Relationship"
				col1.DefaultCellStyle.NullValue = String.Empty
				col1.DefaultCellStyle.DataSourceNullValue = String.Empty
				col1.DataSource = tabBurialRelationship
				col1.ValueMember = tabBurialRelationship.Columns("FileValue").ColumnName
				col1.DisplayMember = tabBurialRelationship.Columns("DisplayValue").ColumnName
				col1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
				col1.SortMode = DataGridViewColumnSortMode.NotSortable
				col1.AutoComplete = True
				col1.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col1.ToolTipText = _
				"Select the Relationship of the person being buried to one or other" + vbCrLf + _
				"of the given relatives. You must select an entry from the drop-down" + vbCrLf + _
				"list. FreeREG does not appear to validate the relationship, so if" + vbCrLf + _
				"the entry you want is not in the list, go to Settings--> Burial" + vbCrLf + _
				"Relationships table and add the new entry."
				idx = mainDGV.Columns.Add(col1)

				col2 = New CaseTextColumn()
				col2.Name = "MaleForenames"
				col2.HeaderText = "Male relative first name(s)"
				col2.DataPropertyName = "MaleForenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of any male relative of" + vbCrLf + _
				"the person being buried, if one is mentioned. Where multiple" + vbCrLf + _
				"names or initials have been recorded, enter them as they have" + vbCrLf + _
				"been recorded. The program will capitalise the first letter of" + vbCrLf + _
				"each name. Any or all of the names can be entered using the UCF" + vbCrLf + _
				"notation. Pressing the F5 key will present a dialog which will" + vbCrLf + _
				"facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "FemaleForenames"
				col2.HeaderText = "Female relative first name(s)"
				col2.DataPropertyName = "FemaleForenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of any female relative" + vbCrLf + _
				"of the person being buried, if one is mentioned. Where multiple" + vbCrLf + _
				"names or initials have been recorded, enter them as they have" + vbCrLf + _
				"been recorded. The program will capitalise the first letter of" + vbCrLf + _
				"each name. Any or all of the names can be entered using the UCF" + vbCrLf + _
				"notation. Pressing the F5 key will present a dialog which will" + vbCrLf + _
				"facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "RelativeSurname"
				col2.HeaderText = "Relative surname"
				col2.DataPropertyName = "RelativeSurname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the surname of one or other of the given Relatives. Usually" + vbCrLf + _
				"only one surname will be listed as two relatives generally only" + vbCrLf + _
				"occur when the person being buried is a child."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "Surname"
				col2.HeaderText = "Surname"
				col2.DataPropertyName = "Surname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The surname of the person being buried. The program will" + vbCrLf + _
				"automatically capitalise the name as it is entered. The" + vbCrLf + _
				"field will accept a name entered in the UCF format. To" + vbCrLf + _
				"facilitate this, pressing the F5 key will present a dialog" + vbCrLf + _
				"to assist with the entry of a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col = New DataGridViewTextBoxColumn()
				col.Name = "Age"
				col.HeaderText = "Age"
				col.DataPropertyName = "Age"
				col.MaxInputLength = 11
				col.DefaultCellStyle.NullValue = String.Empty
				col.DefaultCellStyle.DataSourceNullValue = String.Empty
				col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				col.SortMode = DataGridViewColumnSortMode.NotSortable
				col.ValueType = GetType(String)
				col.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col.ToolTipText = _
				"The age of the person being buried. Enter the age as it is" + vbCrLf + _
				"given in the actual entry. It can be the age as a number of" + vbCrLf + _
				"years, in the case of an adult. Or a word in the case of a" + vbCrLf + _
				"very young child. It is very common to see the words 'infant'" + vbCrLf + _
				"or 'child' used for very young children, and these words can" + vbCrLf + _
				"be entered exactly like this." + vbCrLf + _
				"" + vbCrLf + _
				"It is also very common for the age of children to be expressed" + vbCrLf + _
				"as a number of days or weeks or months. To this end, the program" + vbCrLf + _
				"will accept an age entered as a combination of numbers and units" + vbCrLf + _
				"corresponding to these periods. Multiple units can be entered. For" + vbCrLf + _
				"example: 3m4d for 3months and 4 days. Note, spaces should not be" + vbCrLf + _
				"used to separate the various parts of the age" + vbCrLf + _
				"" + vbCrLf + _
				"It's also possible to find the age expressed as a factional number" + vbCrLf + _
				"of years. The half, quarter and three-quarter symbols can be entered" + vbCrLf + _
				"by using the Alt key and the numeric keypad. The symbols are achieved" + vbCrLf + _
				"by Alt-0188, Alt-0189 and Alt-0190. Note: the leading zero is mandatory"
				'				col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
				idx = mainDGV.Columns.Add(col)

				col2 = New CaseTextColumn()
				col2.Name = "Abode"
				col2.HeaderText = "Abode"
				col2.DataPropertyName = "Abode"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The Abode of the person being buried, if it is given. If the" + vbCrLf + _
				"actual entry states where the person lived, enter it. Otherwise," + vbCrLf + _
				"leave it blank. The program will automatically capitalise the name" + vbCrLf + _
				"as it is entered. The field will accept a name entered in the UCF" + vbCrLf + _
				"format. To facilitate this, pressing the F5 key will present a " + vbCrLf + _
				"dialog to assist with the entry of a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

			Case "MARRIAGES"
				col = New DataGridViewTextBoxColumn()
				col.Name = "MarriageDate"
				col.HeaderText = "Marriage date"
				col.DataPropertyName = "MarriageDate"
				col.DefaultCellStyle.NullValue = String.Empty
				col.DefaultCellStyle.DataSourceNullValue = String.Empty
				col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				col.SortMode = DataGridViewColumnSortMode.Programmatic
				col.ValueType = GetType(String)
				col.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col.ToolTipText = _
				"The date on which the marriage took place. Enter this in the" + vbCrLf + _
				"standard way for dates. Use the F4 key for assistance with" + vbCrLf + _
				"entering the date"
				'				col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
				idx = mainDGV.Columns.Add(col)

				col2 = New CaseTextColumn()
				col2.Name = "GroomForenames"
				col2.HeaderText = "Groom first name(s)"
				col2.DataPropertyName = "GroomForenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the bridegroom. Where" + vbCrLf + _
				"multiple names or initials have been recorded, enter them as they" + vbCrLf + _
				"have been recorded. The program will capitalise the first letter" + vbCrLf + _
				"of each name. Any or all of the names can be entered using the" + vbCrLf + _
				"UCF notation. Pressing the F5 key will present a dialog which" + vbCrLf + _
				"will facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "GroomSurname"
				col2.HeaderText = "Groom surname"
				col2.DataPropertyName = "GroomSurname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The surname of the bridegroom. The program will automatically" + vbCrLf + _
				"capitalise the name as it is entered. The field will accept a" + vbCrLf + _
				"name entered in the UCF format. To facilitate this, pressing" + vbCrLf + _
				"the F5 key will present a dialog to assist with the entry of" + vbCrLf + _
				"a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col = New DataGridViewTextBoxColumn()
				col.Name = "GroomAge"
				col.HeaderText = "Groom Age"
				col.DataPropertyName = "GroomAge"
				col.DefaultCellStyle.NullValue = String.Empty
				col.DefaultCellStyle.DataSourceNullValue = String.Empty
				col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				col.MaxInputLength = 11
				col.SortMode = DataGridViewColumnSortMode.NotSortable
				col.ValueType = GetType(String)
				col.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col.ToolTipText = _
				"Enter the Age of the groom, if given. If not given, leave the" + vbCrLf + _
				"field blank. If it is unreadable, enter a single '*'. Otherwise" + vbCrLf + _
				"enter the age as given, which would normally be a number of years," + vbCrLf + _
				"one of the standard phrases (minor or of full age or over 21), or a" + vbCrLf + _
				"number containing units of years, days, weeks or months."
				'				col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
				idx = mainDGV.Columns.Add(col)

				col2 = New CaseTextColumn()
				col2.Name = "GroomParish"
				col2.HeaderText = "Groom Parish"
				col2.DataPropertyName = "GroomParish"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The Parish from which the groom originates, if given. If the" + vbCrLf + _
				"actual entry states where the groom comes from, enter it." + vbCrLf + _
				"Otherwise, leave it blank. Also, a very common entry that can" + vbCrLf + _
				"be found is 'of this parish' or 'otp'. The program will automatically" + vbCrLf + _
				"capitalise the name as it is entered. The field will accept" + vbCrLf + _
				"a name entered in the UCF format. To facilitate this, pressing" + vbCrLf + _
				"the F5 key will present a dialog to assist with the entry of a" + vbCrLf + _
				"UCF-formatted name." + vbCrLf + _
				"" + vbCrLf + _
				"The program maintains a list of all the values entered in the" + vbCrLf + _
				"Parish and Abode columns within a file. The list can, if it has" + vbCrLf + _
				"been enabled in the Options dialog, provide a short-hand means" + vbCrLf + _
				"of entering a set of consistent values." + vbCrLf + _
				"" + vbCrLf + _
				"When enabled, typing a letter should present a shortlist of all" + vbCrLf + _
				"the previously entered values that begin with the characters" + vbCrLf + _
				"entered so far. You can either continue entering characters one" + vbCrLf + _
				"by one and see the list shorten, or use the up and down arrow" + vbCrLf + _
				"keys to select a previously entered value. Clicking the mouse" + vbCrLf + _
				"on an entry from the list will also select that entry. Then," + vbCrLf + _
				"press the ENTER key to insert the selected value into the field."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col1 = New DataGridViewComboBoxColumn()
				col1.Name = "GroomCondition"
				col1.HeaderText = "Groom Condition"
				col1.DataPropertyName = "GroomCondition"
				col1.DefaultCellStyle.NullValue = String.Empty
				col1.DefaultCellStyle.DataSourceNullValue = String.Empty
				col1.DataSource = tabGroomCondition
				col1.ValueMember = tabGroomCondition.Columns("FileValue").ColumnName
				col1.DisplayMember = tabGroomCondition.Columns("DisplayValue").ColumnName
				col1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
				col1.SortMode = DataGridViewColumnSortMode.NotSortable
				col1.AutoComplete = True
				col1.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col1.ToolTipText = _
				"Enter the Condition of the groom at the time of the marriage. In" + vbCrLf + _
				"general, the groom will be a bachelor or a widower. Select the" + vbCrLf + _
				"appropriate entry from the drop-down list. If you think an entry" + vbCrLf + _
				"is missing, go to Settings--> Groom Marriage States and add the" + vbCrLf + _
				"missing entry."
				'				col1.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col1.HeaderCell)
				idx = mainDGV.Columns.Add(col1)

				col2 = New CaseTextColumn()
				col2.Name = "GroomOccupation"
				col2.HeaderText = "Groom occupation"
				col2.DataPropertyName = "GroomOccupation"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The occupation or standing of the bridegroom - if stated." + vbCrLf + _
				"" + vbCrLf + _
				"The program maintains a list of all the values entered in this" + vbCrLf + _
				"column within a file. The list can, if it has been enabled in" + vbCrLf + _
				"Options dialog, provide a short-hand means of entering a set" + vbCrLf + _
				"of consistent values." + vbCrLf + _
				"" + vbCrLf + _
				"When enabled, typing a letter should present a shortlist of all" + vbCrLf + _
				"the previously entered values that begin with the characters" + vbCrLf + _
				"entered so far. You can either continue entering characters one" + vbCrLf + _
				"by one and see the list shorten, or use the up and down arrow" + vbCrLf + _
				"keys to select a previously entered value. Clicking the mouse" + vbCrLf + _
				"on an entry from the list will also select that entry. Then," + vbCrLf + _
				"press the ENTER key to insert the selected value into the field."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "GroomAbode"
				col2.HeaderText = "Groom Abode"
				col2.DataPropertyName = "GroomAbode"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The Abode of the groom, if given. If the actual entry states" + vbCrLf + _
				"where the groom comes from, enter it. Otherwise, leave it blank." + vbCrLf + _
				"The program will automatically capitalise the name as it is" + vbCrLf + _
				"entered. The field will accept a name entered in the UCF format." + vbCrLf + _
				"To facilitate this, pressing the F5 key will present a dialog" + vbCrLf + _
				"to assist with the entry of a UCF-formatted name." + vbCrLf + _
				"" + vbCrLf + _
				"The program maintains a list of all the values entered in this" + vbCrLf + _
				"column within a file. The list can, if it has been enabled in" + vbCrLf + _
				"Options dialog, provide a short-hand means of entering a set" + vbCrLf + _
				"of consistent values." + vbCrLf + _
				"" + vbCrLf + _
				"When enabled, typing a letter should present a shortlist of all" + vbCrLf + _
				"the previously entered values that begin with the characters" + vbCrLf + _
				"entered so far. You can either continue entering characters one" + vbCrLf + _
				"by one and see the list shorten, or use the up and down arrow" + vbCrLf + _
				"keys to select a previously entered value. Clicking the mouse" + vbCrLf + _
				"on an entry from the list will also select that entry. Then," + vbCrLf + _
				"press the ENTER key to insert the selected value into the field."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "BrideForenames"
				col2.HeaderText = "Bride first name(s)"
				col2.DataPropertyName = "BrideForenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the bride. Where multiple" + vbCrLf + _
				"names or initials have been recorded, enter them as they have been" + vbCrLf + _
				"recorded. The program will capitalise the first letter of each name." + vbCrLf + _
				"Any or all of the names can be entered using the UCF notation." + vbCrLf + _
				"Pressing the F5 key will present a dialog which will facilitate" + vbCrLf + _
				"the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "BrideSurname"
				col2.HeaderText = "Bride surname"
				col2.DataPropertyName = "BrideSurname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The surname of the bride. The program will automatically" + vbCrLf + _
				"capitalise the name as it is entered. The field will accept a" + vbCrLf + _
				"name entered in the UCF format. To facilitate this, pressing" + vbCrLf + _
				"the F5 key will present a dialog to assist with the entry of" + vbCrLf + _
				"a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col = New DataGridViewTextBoxColumn()
				col.Name = "BrideAge"
				col.HeaderText = "Bride Age"
				col.DataPropertyName = "BrideAge"
				col.DefaultCellStyle.NullValue = String.Empty
				col.DefaultCellStyle.DataSourceNullValue = String.Empty
				col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
				col.SortMode = DataGridViewColumnSortMode.NotSortable
				col.MaxInputLength = 11
				col.ValueType = GetType(String)
				col.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col.ToolTipText = _
				"Enter the Age of the bride, if given. If not given, leave the" + vbCrLf + _
				"field blank. If it is unreadable, enter a single '*'. Otherwise" + vbCrLf + _
				"enter the age as given, which would normally be a number of years," + vbCrLf + _
				"one of the standard phrases (minor or of full age or over 21), or a" + vbCrLf + _
				"number containing units of years, days, weeks or months."
				'				col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
				idx = mainDGV.Columns.Add(col)

				col2 = New CaseTextColumn()
				col2.Name = "BrideParish"
				col2.HeaderText = "Bride Parish"
				col2.DataPropertyName = "BrideParish"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The Parish from which the bride originates, if given. If the" + vbCrLf + _
				"actual entry states where the bride comes from, enter it." + vbCrLf + _
				"Otherwise, leave it blank. Also, a very common entry that can" + vbCrLf + _
				"be found is 'of this parish' or 'otp'. The program will automatically" + vbCrLf + _
				"capitalise the name as it is entered. The field will accept" + vbCrLf + _
				"a name entered in the UCF format. To facilitate this, pressing" + vbCrLf + _
				"the F5 key will present a dialog to assist with the entry of a" + vbCrLf + _
				"UCF-formatted name." + vbCrLf + _
				"" + vbCrLf + _
				"The program maintains a list of all the values entered in the" + vbCrLf + _
				"Parish and Abode columns within a file. The list can, if it has" + vbCrLf + _
				"been enabled in the Options dialog, provide a short-hand means" + vbCrLf + _
				"of entering a set of consistent values." + vbCrLf + _
				"" + vbCrLf + _
				"When enabled, typing a letter should present a shortlist of all" + vbCrLf + _
				"the previously entered values that begin with the characters" + vbCrLf + _
				"entered so far. You can either continue entering characters one" + vbCrLf + _
				"by one and see the list shorten, or use the up and down arrow" + vbCrLf + _
				"keys to select a previously entered value. Clicking the mouse" + vbCrLf + _
				"on an entry from the list will also select that entry. Then," + vbCrLf + _
				"press the ENTER key to insert the selected value into the field."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col1 = New DataGridViewComboBoxColumn()
				col1.Name = "BrideCondition"
				col1.HeaderText = "Bride Condition"
				col1.DataPropertyName = "BrideCondition"
				col1.DefaultCellStyle.NullValue = String.Empty
				col1.DefaultCellStyle.DataSourceNullValue = String.Empty
				col1.DataSource = tabBrideCondition
				col1.ValueMember = tabBrideCondition.Columns("FileValue").ColumnName
				col1.DisplayMember = tabBrideCondition.Columns("DisplayValue").ColumnName
				col1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
				col1.SortMode = DataGridViewColumnSortMode.NotSortable
				col1.AutoComplete = True
				col1.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col1.ToolTipText = _
				"Enter the Condition of the bride at the time of the marriage. In" + vbCrLf + _
				"general, the bride will be a spinster or a widow. Select the" + vbCrLf + _
				"appropriate entry from the drop-down list. If you think an entry" + vbCrLf + _
				"is missing, go to Settings--> Groom Marriage States and add the" + vbCrLf + _
				"missing entry."
				'				col1.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col1.HeaderCell)
				idx = mainDGV.Columns.Add(col1)

				col2 = New CaseTextColumn()
				col2.Name = "BrideOccupation"
				col2.HeaderText = "Bride occupation"
				col2.DataPropertyName = "BrideOccupation"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The occupation or standing of the bride - if stated." + vbCrLf + _
				"" + vbCrLf + _
				"The program maintains a list of all the values entered in this" + vbCrLf + _
				"column within a file. The list can, if it has been enabled in" + vbCrLf + _
				"Options dialog, provide a short-hand means of entering a set" + vbCrLf + _
				"of consistent values." + vbCrLf + _
				"" + vbCrLf + _
				"When enabled, typing a letter should present a shortlist of all" + vbCrLf + _
				"the previously entered values that begin with the characters" + vbCrLf + _
				"entered so far. You can either continue entering characters one" + vbCrLf + _
				"by one and see the list shorten, or use the up and down arrow" + vbCrLf + _
				"keys to select a previously entered value. Clicking the mouse" + vbCrLf + _
				"on an entry from the list will also select that entry. Then," + vbCrLf + _
				"press the ENTER key to insert the selected value into the field."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "BrideAbode"
				col2.HeaderText = "Bride Abode"
				col2.DataPropertyName = "BrideAbode"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The Abode of the bride, if given. If the actual entry states" + vbCrLf + _
				"where the bride comes from, enter it. Otherwise, leave it blank." + vbCrLf + _
				"The program will automatically capitalise the name as it is" + vbCrLf + _
				"entered. The field will accept a name entered in the UCF format." + vbCrLf + _
				"To facilitate this, pressing the F5 key will present a dialog" + vbCrLf + _
				"to assist with the entry of a UCF-formatted name." + vbCrLf + _
				"" + vbCrLf + _
				"The program maintains a list of all the values entered in this" + vbCrLf + _
				"column within a file. The list can, if it has been enabled in" + vbCrLf + _
				"Options dialog, provide a short-hand means of entering a set" + vbCrLf + _
				"of consistent values." + vbCrLf + _
				"" + vbCrLf + _
				"When enabled, typing a letter should present a shortlist of all" + vbCrLf + _
				"the previously entered values that begin with the characters" + vbCrLf + _
				"entered so far. You can either continue entering characters one" + vbCrLf + _
				"by one and see the list shorten, or use the up and down arrow" + vbCrLf + _
				"keys to select a previously entered value. Clicking the mouse" + vbCrLf + _
				"on an entry from the list will also select that entry. Then," + vbCrLf + _
				"press the ENTER key to insert the selected value into the field."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "GroomFatherForenames"
				col2.HeaderText = "Groom Father's forename(s)"
				col2.DataPropertyName = "GroomFatherForenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the groom's father. Where" + vbCrLf + _
				"multiple names or initials have been recorded, enter them as they" + vbCrLf + _
				"have been recorded. The program will capitalise the first letter" + vbCrLf + _
				"of each name. Any or all of the names can be entered using the" + vbCrLf + _
				"UCF notation. Pressing the F5 key will present a dialog which" + vbCrLf + _
				"will facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "GroomFatherSurname"
				col2.HeaderText = "Groom Father's surname"
				col2.DataPropertyName = "GroomFatherSurname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The surname of the bridegroom's father. The program will" + vbCrLf + _
				"automatically capitalise the name as it is entered. The" + vbCrLf + _
				"field will accept a name entered in the UCF format. To" + vbCrLf + _
				"facilitate this, pressing the F5 key will present a dialog" + vbCrLf + _
				"to assist with the entry of" + vbCrLf + _
				"a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "GroomFatherOccupation"
				col2.HeaderText = "Groom Father's occupation"
				col2.DataPropertyName = "GroomFatherOccupation"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The occupation or standing of the groom's father." + vbCrLf + _
				"" + vbCrLf + _
				"The program maintains a list of all the values entered in this" + vbCrLf + _
				"column within a file. The list can, if it has been enabled in" + vbCrLf + _
				"Options dialog, provide a short-hand means of entering a set" + vbCrLf + _
				"of consistent values." + vbCrLf + _
				"" + vbCrLf + _
				"When enabled, typing a letter should present a shortlist of all" + vbCrLf + _
				"the previously entered values that begin with the characters" + vbCrLf + _
				"entered so far. You can either continue entering characters one" + vbCrLf + _
				"by one and see the list shorten, or use the up and down arrow" + vbCrLf + _
				"keys to select a previously entered value. Clicking the mouse" + vbCrLf + _
				"on an entry from the list will also select that entry. Then," + vbCrLf + _
				"press the ENTER key to insert the selected value into the field."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "BrideFatherForenames"
				col2.HeaderText = "Bride Father's forename(s)"
				col2.DataPropertyName = "BrideFatherForenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the bride's father. Where" + vbCrLf + _
				"multiple names or initials have been recorded, enter them as they" + vbCrLf + _
				"have been recorded. The program will capitalise the first letter" + vbCrLf + _
				"of each name. Any or all of the names can be entered using the" + vbCrLf + _
				"UCF notation. Pressing the F5 key will present a dialog which" + vbCrLf + _
				"will facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "BrideFatherSurname"
				col2.HeaderText = "Bride Father's surname"
				col2.DataPropertyName = "BrideFatherSurname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The surname of the bride's father. The program will automatically" + vbCrLf + _
				"capitalise the name as it is entered. The field will accept a" + vbCrLf + _
				"name entered in the UCF format. To facilitate this, pressing" + vbCrLf + _
				"the F5 key will present a dialog to assist with the entry of" + vbCrLf + _
				"a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "BrideFatherOccupation"
				col2.HeaderText = "Bride Father's occupation"
				col2.DataPropertyName = "BrideFatherOccupation"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The occupation or standing of the bride's father." + vbCrLf + _
				"" + vbCrLf + _
				"The program maintains a list of all the values entered in this" + vbCrLf + _
				"column within a file. The list can, if it has been enabled in" + vbCrLf + _
				"Options dialog, provide a short-hand means of entering a set" + vbCrLf + _
				"of consistent values." + vbCrLf + _
				"" + vbCrLf + _
				"When enabled, typing a letter should present a shortlist of all" + vbCrLf + _
				"the previously entered values that begin with the characters" + vbCrLf + _
				"entered so far. You can either continue entering characters one" + vbCrLf + _
				"by one and see the list shorten, or use the up and down arrow" + vbCrLf + _
				"keys to select a previously entered value. Clicking the mouse" + vbCrLf + _
				"on an entry from the list will also select that entry. Then," + vbCrLf + _
				"press the ENTER key to insert the selected value into the field."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "Witness1Forenames"
				col2.HeaderText = "Witness 1 forename(s)"
				col2.DataPropertyName = "Witness1Forenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the first witness. Where" + vbCrLf + _
				"multiple names or initials have been recorded, enter them as they" + vbCrLf + _
				"have been recorded. The program will capitalise the first letter" + vbCrLf + _
				"of each name. Any or all of the names can be entered using the" + vbCrLf + _
				"UCF notation. Pressing the F5 key will present a dialog which" + vbCrLf + _
				"will facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "Witness1Surname"
				col2.HeaderText = "Witness 1 surname"
				col2.DataPropertyName = "Witness1Surname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The surname of the first witness. The program will automatically" + vbCrLf + _
				"capitalise the name as it is entered. The field will accept a" + vbCrLf + _
				"name entered in the UCF format. To facilitate this, pressing" + vbCrLf + _
				"the F5 key will present a dialog to assist with the entry of" + vbCrLf + _
				"a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "Witness2Forenames"
				col2.HeaderText = "Witness 2 forename(s)"
				col2.DataPropertyName = "Witness2Forenames"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"Enter the fore-, or christian, names of the second witness. Where" + vbCrLf + _
				"multiple names or initials have been recorded, enter them as they" + vbCrLf + _
				"have been recorded. The program will capitalise the first letter" + vbCrLf + _
				"of each name. Any or all of the names can be entered using the" + vbCrLf + _
				"UCF notation. Pressing the F5 key will present a dialog which" + vbCrLf + _
				"will facilitate the entry of the name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

				col2 = New CaseTextColumn()
				col2.Name = "Witness2Surname"
				col2.HeaderText = "Witness 2 surname"
				col2.DataPropertyName = "Witness2Surname"
				col2.DefaultCellStyle.NullValue = String.Empty
				col2.DefaultCellStyle.DataSourceNullValue = String.Empty
				col2.SortMode = DataGridViewColumnSortMode.Programmatic
				col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
				col2.ToolTipText = _
				"The surname of the second witness. The program will automatically" + vbCrLf + _
				"capitalise the name as it is entered. The field will accept a" + vbCrLf + _
				"name entered in the UCF format. To facilitate this, pressing" + vbCrLf + _
				"the F5 key will present a dialog to assist with the entry of" + vbCrLf + _
				"a UCF-formatted name."
				'				col2.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col2.HeaderCell)
				idx = mainDGV.Columns.Add(col2)

		End Select

		col2 = New CaseTextColumn() With {.Name = "Notes", .HeaderText = "Notes", .DataPropertyName = "Notes"}
		col2.DefaultCellStyle.NullValue = String.Empty
		col2.DefaultCellStyle.DataSourceNullValue = String.Empty
		col2.SortMode = DataGridViewColumnSortMode.NotSortable
		col2.HeaderCell.ContextMenuStrip = popColumnsVisibility
		col2.DefaultCellStyle.WrapMode = DataGridViewTriState.True
		col2.ToolTipText = _
		"Here, you can enter any additional notes from the entry that are" + vbCrLf + _
		"not recorded elsewhere in the record. You can also add any comments" + vbCrLf + _
		"that you feel may explain your interpretation of the transcription"
		idx = mainDGV.Columns.Add(col2)

		col = New DataGridViewTextBoxColumn() With {.Name = "LoadOrder", .HeaderText = "LoadOrder", .DataPropertyName = "LoadOrder", .SortMode = DataGridViewColumnSortMode.Programmatic, .Visible = False}
		col.ReadOnly = True
		idx = mainDGV.Columns.Add(col)

		mainDGV.AutoResizeColumns()
		mainDGV.Columns("County").Visible = False
		mainDGV.Columns("Place").Visible = False
		mainDGV.Columns("Church").Visible = False

		mainDGV.DefaultCellStyle.Font = My.Settings.MyCellFont
		mainDGV.DefaultCellStyle.BackColor = My.Settings.MyCellColour
		mainDGV.AlternatingRowsDefaultCellStyle.BackColor = My.Settings.MyAlternateCellColour
	End Sub

#End Region

#Region "File Operations"

	Private Sub PopulateDataGridView(ByVal dt As DataTable)
		Dim c As Cursor = Cursor
		Cursor = Cursors.WaitCursor
		lblInformation.Text = My.Resources.infLoadData
		Application.DoEvents()

		Try
			bsDGV = New BindingSource
			AddHandler bsDGV.ListChanged, AddressOf bsDGV_ListChanged
			bsDGV.DataMember = Nothing
			bsDGV.DataSource = dt
			mainDGV.AutoGenerateColumns = True
			mainDGV.DataSource = bsDGV
			bnDGV.BindingSource = bsDGV

			BindingNavigatorMoveFirstItem.Enabled = True
			BindingNavigatorMoveLastItem.Enabled = True
			BindingNavigatorMoveNextItem.Enabled = True
			BindingNavigatorMovePreviousItem.Enabled = True
			BindingNavigatorAddNewItem.Enabled = True
			BindingNavigatorDeleteItem.Enabled = True
			BindingNavigatorCutButton.Enabled = True
			BindingNavigatorCopyButton.Enabled = True
			BindingNavigatorPasteButton.Enabled = True
			If mainDGV.Rows.Count > 0 Then
				bsDGV.MoveFirst()
				mainDGV.Rows(0).Selected = True
			End If

			Try
				'
				'	If we can, set the columns layout to the last stored configuration for the type of file
				'
				Dim strCollection As StringCollection = Nothing
				Select Case _File.FileType
					Case "BAPTISMS"
						strCollection = My.Settings.colLayoutBaptisms

					Case "BURIALS"
						strCollection = My.Settings.colLayoutBurials

					Case "MARRIAGES"
						strCollection = My.Settings.colLayoutMarriages

				End Select
				mainDGV.SetColumnLayout(strCollection)

				If boolFileContainsErrors Then
					MessageBox.Show(String.Format(My.Resources.infResidualErrors, "open"), "File Open", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, INF0012)
				End If

			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst loading saved column configuration")
				MessageBox.Show(ex.ToString, "Exception whilst loading saved column configuration", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
			End Try

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst populating the DataGrid")
			MessageBox.Show(ex.ToString, "Exception whilst populating the DataGrid", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
		End Try

		lblInformation.Text = String.Empty
		Cursor = c
	End Sub

	Private Function ValidateHeaderLine_1(ByRef aLine As String(), ByVal max As Integer) As Boolean
		Dim valid As Boolean = False
		If aLine(0) = "#NAME?" Then
			excelFile = True
			aLine(0) = "+INFO"
		End If
		If aLine.Length <> max Then
			Array.Resize(aLine, max)
			For i As Integer = 0 To max - 1
				If aLine(i) Is Nothing Then aLine(i) = ""
			Next
		End If

		If aLine.Length >= 5 And aLine.Length <= 10 Then
			If aLine(0) = "+INFO" Then
				If UCase(aLine(2)) = "PASSWORD" Then
					If UCase(aLine(3)) = "SEQUENCED" Then
						If (UCase(aLine(4)) = "BAPTISMS" Or UCase(aLine(4)) = "MARRIAGES" Or UCase(aLine(4)) = "BURIALS") Then
							valid = True
						Else
						End If
					Else
					End If
				Else
				End If
			Else
			End If
		Else
		End If
		Return valid
	End Function

	Private Function ValidateHeaderLine_2(ByRef aLine As String(), ByVal max As Integer) As Boolean
		Dim valid As Boolean = False
		If aLine.Length > max Then excelFile = True
		If aLine.Length <> max Then
			Array.Resize(aLine, max)
			For i As Integer = 0 To max - 1
				If aLine(i) Is Nothing Then aLine(i) = ""
			Next
		End If

		If aLine.Length >= 6 And aLine.Length <= 10 Then
			If aLine(0) = "#" Then
				If UCase(aLine(1)) = "CCC" Then
					If UCase(aLine(4)) = _File.Filename Then
						valid = True
					Else
					End If
				Else
				End If
			Else
			End If
		Else
		End If
		Return valid
	End Function

	Private Function ValidateHeaderLine_3(ByRef aLine As String(), ByVal max As Integer) As Boolean
		Dim valid As Boolean = False
		If aLine.Length > max Then excelFile = True
		If aLine.Length <> max Then
			Array.Resize(aLine, max)
			For i As Integer = 0 To max - 1
				If aLine(i) Is Nothing Then aLine(i) = ""
			Next
		End If

		If aLine.Length >= 4 Then
			If aLine(0) = "#" Then
				If UCase(aLine(1)) = "CREDIT" Then
					valid = True
				Else
				End If
			Else
			End If
		Else
		End If
		Return valid
	End Function

	Private Shared Function ValidateHeaderLine_4(ByRef aLine As String(), ByVal max As Integer) As Boolean
		Dim valid As Boolean = False
		If aLine.Length <> max Then
			Array.Resize(aLine, max)
			For i As Integer = 0 To max - 1
				If aLine(i) Is Nothing Then aLine(i) = ""
			Next
		End If

		If aLine.Length >= 2 And aLine.Length <= 10 Then
			If aLine(0) = "#" Then
				valid = True
			Else
			End If
		Else
		End If
		Return valid
	End Function

	Private Function ExtractHeaderInfo(ByVal strFilename As String) As Boolean
		Dim rc As Boolean = False
		Dim fs As FileStream = Nothing
		Dim csv As TextFieldParser = Nothing
		Dim aLine1, aLine2, aLine3, aLine4, aLine5 As String()
		Dim valid1, valid2, valid3, valid4 As Boolean
		fileHeaderCorrected = False

		ldsFile = False
		Try
			fs = New FileStream(strFilename, FileMode.Open, FileAccess.Read, FileShare.None)
			csv = New TextFieldParser(fs, _Encoding)
			csv.TextFieldType = FieldType.Delimited
			csv.SetDelimiters(",")
			csv.HasFieldsEnclosedInQuotes = True
			csv.TrimWhiteSpace = True

			'
			'	Validate Header line 1
			'
			aLine1 = csv.ReadFields()
			If aLine1 IsNot Nothing Then
				valid1 = ValidateHeaderLine_1(aLine1, 6)
				If valid1 Then
					_File.EmailAddress = aLine1(1)
					_File.Password = aLine1(2)
					_File.FileType = aLine1(4)

					'
					'	Validate Header line 2
					'
					aLine2 = csv.ReadFields()
					If aLine2 IsNot Nothing Then
						valid2 = ValidateHeaderLine_2(aLine2, 6)
						If valid2 Then
							_File.Username = aLine2(2)
							_File.County = aLine2(3)
							_File.InternalFilename = UCase(aLine2(4))
							_File.DateCreated = aLine2(5)

							'
							'	Validate Header line 3
							'
							aLine3 = csv.ReadFields()
							If aLine3 IsNot Nothing Then
								valid3 = ValidateHeaderLine_3(aLine3, 4)
								If valid3 Then
									_File.CreditToName = aLine3(2)
									_File.CreditToAddress = aLine3(3)

									'
									'	Validate Header line 4
									'
									aLine4 = csv.ReadFields()
									If aLine4 IsNot Nothing Then
										valid4 = ValidateHeaderLine_4(aLine4, 4)
										If valid4 Then
											_File.DateLastUpdated = aLine4(1)
											If aLine4(2) Is Nothing Then _File.FileSource = "" Else _File.FileSource = aLine4(2)
											If aLine4(3) Is Nothing Then _File.FileComments = "" Else _File.FileComments = aLine4(3)

											aLine5 = csv.ReadFields()
											If aLine5 IsNot Nothing Then
												If aLine5.Length >= 1 Then
													If aLine5(0) = "+LDS" Then
														ldsFile = True
														Dim aLineData As String() = csv.ReadFields()
														If aLineData IsNot Nothing Then
															If tabChapmanCodes.Rows.Contains(aLineData(0)) Then
																Dim cty = tabChapmanCodes.Rows.Find(aLineData(0))
																_File.CountyCode = cty("Code")
																If String.Compare(_File.County, cty("County"), True) <> 0 Then
																	If String.Compare(_File.County, _File.CountyCode, True) = 0 Then
																		MessageBox.Show(String.Format(My.Resources.err0056, _File.County, cty("County")), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0056)
																		fileHeaderCorrected = True
																		_File.County = cty("County")
																	Else
																		MessageBox.Show(String.Format(My.Resources.err0053, cty("County"), _File.County), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0053)
																		fileHeaderCorrected = True
																		_File.County = cty("County")
																	End If
																End If
																rc = True
															Else
																MessageBox.Show(My.Resources.err0054, "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0054)
															End If
														Else
															MessageBox.Show(My.Resources.err0052, "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0052)
														End If
													Else
														If tabChapmanCodes.Rows.Contains(aLine5(0)) Then
															Dim cty = tabChapmanCodes.Rows.Find(aLine5(0))
															_File.CountyCode = cty("Code")
															If String.Compare(_File.County, cty("County"), True) <> 0 Then
																If String.Compare(_File.County, _File.CountyCode, True) = 0 Then
																	MessageBox.Show(String.Format(My.Resources.err0056, _File.County, cty("County")), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0056)
																	fileHeaderCorrected = True
																	_File.County = cty("County")
																Else
																	MessageBox.Show(String.Format(My.Resources.err0053, cty("County"), _File.County), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0053)
																	fileHeaderCorrected = True
																	_File.County = cty("County")
																End If
															End If
															rc = True
														Else
															MessageBox.Show(My.Resources.err0054, "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0054)
														End If
													End If
												Else
													MessageBox.Show(My.Resources.err0052, "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0052)
												End If
											Else
												MessageBox.Show(My.Resources.err0052, "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0052)
											End If
										Else
											Dim sb As New StringBuilder()
											For Each s In aLine4
												sb.AppendFormat(",{0}", s)
											Next
											sb.Remove(0, 1)
											MessageBox.Show(String.Format(My.Resources.err0003, 4, vbCrLf, sb, My.Resources.infRecord4), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0003)
										End If
									Else
										MessageBox.Show(String.Format(My.Resources.err0051, 4), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0051)
									End If
								Else
									Dim sb As New StringBuilder()
									For Each s In aLine3
										sb.AppendFormat(",{0}", s)
									Next
									sb.Remove(0, 1)
									MessageBox.Show(String.Format(My.Resources.err0003, 3, vbCrLf, sb, My.Resources.infRecord3), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0003)
								End If
							Else
								MessageBox.Show(String.Format(My.Resources.err0051, 3), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0051)
							End If
						Else
							Dim sb As New StringBuilder()
							For Each s In aLine2
								sb.AppendFormat(",{0}", s)
							Next
							sb.Remove(0, 1)
							MessageBox.Show(String.Format(My.Resources.err0003, 2, vbCrLf, sb, My.Resources.infRecord2), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0003)
						End If
					Else
						MessageBox.Show(String.Format(My.Resources.err0051, 2), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0051)
					End If
				Else
					Dim sb As New StringBuilder()
					For Each s In aLine1
						sb.AppendFormat(",{0}", s)
					Next
					sb.Remove(0, 1)
					MessageBox.Show(String.Format(My.Resources.err0003, 1, vbCrLf, sb, My.Resources.infRecord1), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0003)
				End If
			Else
				MessageBox.Show(String.Format(My.Resources.err0051, 1), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0051)
			End If

		Catch ex As FileNotFoundException
			MessageBox.Show(My.Resources.err0002, "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0002)

		Catch ex As MalformedLineException
			MessageBox.Show(String.Format(My.Resources.err0057, ex.LineNumber), "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0057)

		Catch ex As IOException
			MessageBox.Show(ex.Message, "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Catch ex As Exception
			MessageBox.Show(My.Resources.err0001 + ex.Message, "Open Existing Project", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0001)

		Finally
			If csv IsNot Nothing Then
				csv.Close()
				csv.Dispose()
			End If
			If fs IsNot Nothing Then
				fs.Close()
				fs.Dispose()
			End If
		End Try

		Return rc
	End Function

	Private Sub OpenTranscriptionFile(ByVal strFileName As String)
		Dim c As Cursor = Cursor
		Cursor = Cursors.WaitCursor

		Dim ds As TranscriptionTables
		Dim dt As DataTable

		Dim io As FileInfo = My.Computer.FileSystem.GetFileInfo(strFileName)
		lblInformation.Text = String.Format(My.Resources.infLoadingFile, strFileName)
		Application.DoEvents()

		_File.Filename = UCase(io.Name)
		If ExtractHeaderInfo(strFileName) Then
			Dim fs As FileStream = Nothing, fs2 As FileStream = Nothing
			Dim csv As TextFieldParser = Nothing, csv2 As TextFieldParser = Nothing

			Try
				Dim aLine1, aLine2, aLine3, aLine4, aLine5 As String()
				Dim arow As String() = {}
				Dim bLine1, bLine2, bLine3, bLine4, bLine5 As String
				Dim brow As String = String.Empty
				fs = New FileStream(strFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
				fs2 = New FileStream(strFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
				csv = New TextFieldParser(fs, _Encoding)
				csv.TextFieldType = FieldType.Delimited
				csv.SetDelimiters(",")
				csv.HasFieldsEnclosedInQuotes = True
				csv.TrimWhiteSpace = True

				csv2 = New TextFieldParser(fs2, _Encoding)
				csv2.TextFieldType = FieldType.Delimited
				csv2.SetDelimiters(",")
				csv2.HasFieldsEnclosedInQuotes = True
				csv2.TrimWhiteSpace = True

				aLine1 = csv.ReadFields()
				bLine1 = csv2.ReadLine()
				aLine2 = csv.ReadFields()
				bLine2 = csv2.ReadLine()
				aLine3 = csv.ReadFields()
				bLine3 = csv2.ReadLine()
				aLine4 = csv.ReadFields()
				bLine4 = csv2.ReadLine()
				If ldsFile Then
					aLine5 = csv.ReadFields()
					bLine5 = csv2.ReadLine()
				End If
				mainDGV.RowOffset = IIf(ldsFile, 5, 4)

				acscAbodes.Clear()
				acscOccupations.Clear()
				acscFiche.Clear()
				acscImage.Clear()

				ds = New TranscriptionTables
				badRecords.Clear()
				Dim record_count As Integer = 0
				recordHeadersCorrected = False

				Select Case _File.FileType
					Case "BAPTISMS"
						Dim recnum As Integer = 0
						While Not csv.EndOfData
							Try
								brow = csv2.ReadLine()
								arow = csv.ReadFields()

								For i = 0 To arow.Count - 1
									If arow(i).Contains(vbCrLf) Then
										arow(i) = arow(i).Replace(vbCrLf, " ")
										Dim nextbit As String = csv2.ReadLine()
										brow += " " + nextbit
									End If
								Next

								If recnum = 0 Then
									_File.PlaceName = arow(1)
									_File.ChurchName = arow(2)
								End If

								If arow.Length < 15 Then
									Array.Resize(arow, 15)
								End If
								If ldsFile AndAlso arow.Length < 17 Then
									Array.Resize(arow, 17)
								End If

								Dim nrow As BaptismsRow = ds.Baptisms.NewBaptismsRow

								If arow(0) <> _File.CountyCode Then
									arow(0) = _File.CountyCode
									recordHeadersCorrected = True
								End If
								If arow(1) <> _File.PlaceName Then
									arow(1) = _File.PlaceName
									recordHeadersCorrected = True
								End If
								If arow(2) <> _File.ChurchName Then
									arow(2) = _File.ChurchName
									recordHeadersCorrected = True
								End If

								If Not ((arow.Length = 15 AndAlso Not ldsFile) OrElse (ldsFile AndAlso arow.Length = 17)) Then
									Dim x = badRecords.AddBadRecordsRow(recnum + 1, brow, String.Format("Incorrect number of fields. Got {0}. Should be {1}", arow.Length, IIf(ldsFile, 17, 15)), arow)
									nrow.RowError = String.Format("Incorrect number of fields <{0}>", brow)
								End If

								nrow.County = arow(0)
								nrow.Place = arow(1)
								nrow.Church = arow(2)
								If Not String.IsNullOrEmpty(arow(3)) AndAlso Not IsNumeric(arow(3)) Then
									Dim msg As String = String.Format(My.Resources.infBadRegisterNumber, recnum + 1, arow(3))
									Select Case MessageBox.Show(msg, "Bad Register Number", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, INF0002)
										Case Windows.Forms.DialogResult.Yes
											arow(3) = ""
										Case Windows.Forms.DialogResult.No

										Case Windows.Forms.DialogResult.Cancel
											Throw New CancelFileOpenException("File Open operation cancelled")

									End Select
								End If
								nrow.RegNo = arow(3)
								nrow.BirthDate = arow(4)
								nrow.BaptismDate = arow(5)
								nrow.Forenames = arow(6)
								nrow.Sex = arow(7)
								nrow.FathersName = arow(8)
								nrow.MothersName = arow(9)
								If String.IsNullOrEmpty(arow(10)) Then nrow.FathersSurname = "" Else nrow.FathersSurname = arow(10).ToUpper()
								If String.IsNullOrEmpty(arow(11)) Then nrow.MothersSurname = "" Else nrow.MothersSurname = arow(11).ToUpper()
								nrow.Abode = arow(12)
								nrow.FathersOccupation = arow(13)
								nrow.Notes = arow(14)
								If ldsFile Then
									If arow(15) Is Nothing Then nrow.LDSFiche = "" Else nrow.LDSFiche = arow(15)
									If arow(16) Is Nothing Then nrow.LDSImage = "" Else nrow.LDSImage = arow(16)
								End If
								ds.Baptisms.AddBaptismsRow(nrow)
								AddStringToCollection(acscAbodes, nrow.Abode)
								AddStringToCollection(acscOccupations, nrow.FathersOccupation)

								AddStringToCollection(acscFiche, nrow.LDSFiche)
								AddStringToCollection(acscImage, nrow.LDSImage)

							Catch ex As MalformedLineException
								Dim x = badRecords.AddBadRecordsRow(recnum + 1, brow, "Malformed Line Exception", Nothing)

							Catch ex As CancelFileOpenException
								Throw

							Catch ex As Exception
								Dim x = badRecords.AddBadRecordsRow(recnum + 1, brow, "General Exception:" + ex.Message, Nothing)
							End Try

							recnum += 1
						End While
						record_count = ds.Baptisms.Rows.Count
						dt = ds.Baptisms

					Case "BURIALS"
						Dim recnum As Integer = 0
						While Not csv.EndOfData
							Try
								brow = csv2.ReadLine()
								arow = csv.ReadFields()

								For i = 0 To arow.Count - 1
									If arow(i).Contains(vbCrLf) Then
										arow(i) = arow(i).Replace(vbCrLf, " ")
										Dim nextbit As String = csv2.ReadLine()
										brow += " " + nextbit
									End If
								Next

								If recnum = 0 Then
									_File.PlaceName = arow(1)
									_File.ChurchName = arow(2)
								End If

								If arow.Length < 14 Then
									Array.Resize(arow, 14)
								End If
								If ldsFile AndAlso arow.Length < 16 Then
									Array.Resize(arow, 16)
								End If

								Dim nrow As BurialsRow = ds.Burials.NewBurialsRow

								If arow(0) <> _File.CountyCode Then
									arow(0) = _File.CountyCode
									recordHeadersCorrected = True
								End If
								If arow(1) <> _File.PlaceName Then
									arow(1) = _File.PlaceName
									recordHeadersCorrected = True
								End If
								If arow(2) <> _File.ChurchName Then
									arow(2) = _File.ChurchName
									recordHeadersCorrected = True
								End If

								If Not ((arow.Length = 14 AndAlso Not ldsFile) OrElse (ldsFile AndAlso arow.Length = 16)) Then
									Dim x = badRecords.AddBadRecordsRow(recnum + 1, brow, String.Format("Incorrect number of fields. Got {0}. Should be {1}", arow.Length, IIf(ldsFile, 16, 14)), arow)
									nrow.RowError = String.Format("Incorrect number of fields <{0}>", brow)
								End If

								nrow.County = arow(0)
								nrow.Place = arow(1)
								nrow.Church = arow(2)
								If Not String.IsNullOrEmpty(arow(3)) AndAlso Not IsNumeric(arow(3)) Then
									Dim msg As String = String.Format(My.Resources.infBadRegisterNumber, recnum + 1, arow(3))
									Select Case MessageBox.Show(msg, "Bad Register Number", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, INF0003)
										Case Windows.Forms.DialogResult.Yes
											arow(3) = ""
										Case Windows.Forms.DialogResult.No

										Case Windows.Forms.DialogResult.Cancel
											Throw New CancelFileOpenException("File Open operation cancelled")

									End Select
								End If
								nrow.RegNo = arow(3)
								nrow.BurialDate = arow(4)
								nrow.Forenames = arow(5)
								nrow.Relationship = arow(6)
								nrow.MaleForenames = arow(7)
								nrow.FemaleForenames = arow(8)
								If String.IsNullOrEmpty(arow(9)) Then nrow.RelativeSurname = "" Else nrow.RelativeSurname = arow(9).ToUpper()
								If String.IsNullOrEmpty(arow(10)) Then nrow.Surname = "" Else nrow.Surname = arow(10).ToUpper()
								nrow.Age = arow(11)
								nrow.Abode = arow(12)
								nrow.Notes = arow(13)
								If ldsFile Then
									If arow(14) Is Nothing Then nrow.LDSFiche = "" Else nrow.LDSFiche = arow(14)
									If arow(15) Is Nothing Then nrow.LDSImage = "" Else nrow.LDSImage = arow(15)
								End If
								ds.Burials.AddBurialsRow(nrow)
								AddStringToCollection(acscAbodes, nrow.Abode)

								AddStringToCollection(acscFiche, nrow.LDSFiche)
								AddStringToCollection(acscImage, nrow.LDSImage)

							Catch ex As MalformedLineException
								Dim x = badRecords.AddBadRecordsRow(recnum + 1, brow, "Malformed Line Exception", Nothing)

							Catch ex As CancelFileOpenException
								Throw

							Catch ex As Exception
								Dim x = badRecords.AddBadRecordsRow(recnum + 1, brow, "General Exception:" + ex.Message, Nothing)
							End Try

							recnum += 1
						End While
						record_count = ds.Burials.Rows.Count
						dt = ds.Burials

					Case "MARRIAGES"
						Dim recnum As Integer = 0
						While Not csv.EndOfData
							Try
								brow = csv2.ReadLine()
								arow = csv.ReadFields()

								For i = 0 To arow.Count - 1
									If arow(i).Contains(vbCrLf) Then
										arow(i) = arow(i).Replace(vbCrLf, " ")
										Dim nextbit As String = csv2.ReadLine()
										brow += " " + nextbit
									End If
								Next

								If recnum = 0 Then
									_File.PlaceName = arow(1)
									_File.ChurchName = arow(2)
								End If

								If arow.Length < 30 Then
									Array.Resize(arow, 30)
								End If
								If ldsFile AndAlso arow.Length < 32 Then
									Array.Resize(arow, 32)
								End If
								Dim nrow As MarriagesRow = ds.Marriages.NewMarriagesRow

								If arow(0) <> _File.CountyCode Then
									arow(0) = _File.CountyCode
									recordHeadersCorrected = True
								End If
								If arow(1) <> _File.PlaceName Then
									arow(1) = _File.PlaceName
									recordHeadersCorrected = True
								End If
								If arow(2) <> _File.ChurchName Then
									arow(2) = _File.ChurchName
									recordHeadersCorrected = True
								End If

								If Not ((arow.Length = 30 AndAlso Not ldsFile) OrElse (ldsFile AndAlso arow.Length = 32)) Then
									Dim x = badRecords.AddBadRecordsRow(recnum + 1, brow, String.Format("Incorrect number of fields. Got {0}. Should be {1}", arow.Length, IIf(ldsFile, 32, 30)), arow)
									nrow.RowError = String.Format("Incorrect number of fields <{0}>", brow)
								End If

								nrow.County = arow(0)
								nrow.Place = arow(1)
								nrow.Church = arow(2)
								If Not String.IsNullOrEmpty(arow(3)) AndAlso Not IsNumeric(arow(3)) Then
									Dim msg As String = String.Format(My.Resources.infBadRegisterNumber, recnum + 1, arow(3))
									Select Case MessageBox.Show(msg, "Bad Register Number", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, INF0003)
										Case Windows.Forms.DialogResult.Yes
											arow(3) = ""
										Case Windows.Forms.DialogResult.No

										Case Windows.Forms.DialogResult.Cancel
											Throw New CancelFileOpenException("File Open operation cancelled")

									End Select
								End If
								nrow.RegNo = arow(3)
								nrow.MarriageDate = arow(4)
								nrow.GroomForenames = arow(5)
								If String.IsNullOrEmpty(arow(6)) Then nrow.GroomSurname = "" Else nrow.GroomSurname = arow(6).ToUpper()
								nrow.GroomAge = arow(7)
								nrow.GroomParish = arow(8)
								nrow.GroomCondition = arow(9)
								nrow.GroomOccupation = arow(10)
								nrow.GroomAbode = arow(11)
								nrow.BrideForenames = arow(12)
								If String.IsNullOrEmpty(arow(13)) Then nrow.BrideSurname = "" Else nrow.BrideSurname = arow(13).ToUpper()
								nrow.BrideAge = arow(14)
								nrow.BrideParish = arow(15)
								nrow.BrideCondition = arow(16)
								nrow.BrideOccupation = arow(17)
								nrow.BrideAbode = arow(18)
								nrow.GroomFatherForenames = arow(19)
								If String.IsNullOrEmpty(arow(20)) Then nrow.GroomFatherSurname = "" Else nrow.GroomFatherSurname = arow(20).ToUpper()
								nrow.GroomFatherOccupation = arow(21)
								nrow.BrideFatherForenames = arow(22)
								If String.IsNullOrEmpty(arow(23)) Then nrow.BrideFatherSurname = "" Else nrow.BrideFatherSurname = arow(23).ToUpper()
								nrow.BrideFatherOccupation = arow(24)
								nrow.Witness1Forenames = arow(25)
								If String.IsNullOrEmpty(arow(26)) Then nrow.Witness1Surname = "" Else nrow.Witness1Surname = arow(26).ToUpper()
								nrow.Witness2Forenames = arow(27)
								If String.IsNullOrEmpty(arow(28)) Then nrow.Witness2Surname = "" Else nrow.Witness2Surname = arow(28).ToUpper()
								nrow.Notes = arow(29)
								If ldsFile Then
									If arow(30) Is Nothing Then nrow.LDSFiche = "" Else nrow.LDSFiche = arow(30)
									If arow(31) Is Nothing Then nrow.LDSImage = "" Else nrow.LDSImage = arow(31)
								End If
								ds.Marriages.AddMarriagesRow(nrow)
								AddStringToCollection(acscAbodes, nrow.GroomParish)
								AddStringToCollection(acscAbodes, nrow.GroomAbode)
								AddStringToCollection(acscAbodes, nrow.BrideParish)
								AddStringToCollection(acscAbodes, nrow.BrideAbode)

								AddStringToCollection(acscOccupations, nrow.GroomOccupation)
								AddStringToCollection(acscOccupations, nrow.BrideOccupation)
								AddStringToCollection(acscOccupations, nrow.GroomFatherOccupation)
								AddStringToCollection(acscOccupations, nrow.BrideFatherOccupation)

								AddStringToCollection(acscFiche, nrow.LDSFiche)
								AddStringToCollection(acscImage, nrow.LDSImage)

							Catch ex As MalformedLineException
								Dim x = badRecords.AddBadRecordsRow(recnum + 1, brow, "Malformed Line Exception", Nothing)

							Catch ex As CancelFileOpenException
								Throw

							Catch ex As Exception
								Dim x = badRecords.AddBadRecordsRow(recnum + 1, brow, "General Exception:" + ex.Message, Nothing)
							End Try

							recnum += 1
						End While
						record_count = ds.Marriages.Rows.Count
						dt = ds.Marriages

					Case Else
						dt = New DataTable
				End Select

				If Not ldsFile Then
					mnuFileShowLDSColumns.Enabled = True
					mnuFileShowLDSColumns.Visible = True
				End If

				If dt.Rows.Count = 0 Then
					_File.PlaceName = "?"
					_File.ChurchName = "?"
				Else
					_File.PlaceName = dt.Rows(0)("Place")
					_File.ChurchName = dt.Rows(0)("Church")
				End If
				_File.Pathname = strFileName

				If ldsFile Then
					Text = String.Format("{0} LDS - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
				Else
					Text = String.Format("{0} - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
				End If

				If _User.IsAdministrator Then
					Dim str As String = String.Format("{0} (Administrator)", Text())
					Text = str
				End If

				fileOpen = True
				fileNew = False
				fileChanged = fileHeaderCorrected Or recordHeadersCorrected
				ShowContentDisplay()

				If My.Settings.UseDataGrid Then
					mainDGV.Columns.Clear()
					mainDGV.Rows.Clear()
					mainDGV.AutoGenerateColumns = False
					SetDataGridViewHeadings(_File.FileType)
					PopulateDataGridView(dt)
					ttMain.ToolTipTitle = _File.FileType

					' Mark lines that have errors in them with a RowError
					'
					ImportErrorsFromFreeREG()
					My.Application.Log.WriteEntry(String.Format("{0} Opened file {1}", Date.Now(), _File.Filename), TraceEventType.Information)

					If badRecords.Count > 0 Then
						For Each b In badRecords
							Dim msg As String = String.Format(" {0,4:####} {1} - <{2}>", b.RowNumber, b.ErrorMessage, b.OriginalSource)
							My.Application.Log.WriteEntry(Date.Now() + msg, TraceEventType.Information)
							mainDGV.Rows(b.RowNumber - 1).ReadOnly = True
							mainDGV.Rows(b.RowNumber - 1).DefaultCellStyle.BackColor = Color.Red
							mainDGV.Rows(b.RowNumber - 1).DefaultCellStyle.ForeColor = Color.White
						Next

						Do While badRecords.Count > 0
							Dim rc = MessageBox.Show(String.Format(My.Resources.infBadlyFormattedRecords, badRecords.Count, _File.Filename), String.Format("Load {0} File", _File.FileType), MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, INF0001)
							If rc = Windows.Forms.DialogResult.Yes Then
								If (dt.HasErrors) Then
									Using dlg As New dlgBadRecords(badRecords)
										rc = dlg.ShowDialog()
										If dlg.DataHasBeenUpdated Then
											Dim results = dlg.GetUpdatedRecords()
											For Each row In results
												Dim nrow = mainDGV.Rows(row.RowNumber - 1)
												Dim drv As DataRowView = mainDGV.Rows(row.RowNumber - 1).DataBoundItem
												Dim aLine As String() = row.csv
												Dim OriginalBadRecord As BadRecordsRow = badRecords.FindByRowNumber(row.RowNumber)
												OriginalBadRecord.OriginalSource = row.OriginalSource
												OriginalBadRecord.csv = row.csv
												fileChanged = True
												BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged

												For fld As Integer = 0 To nrow.Cells.Count - IIf(ldsFile, 1, 3)
													If fld < arow.Length Then
														nrow.Cells(fld).Value = aLine(fld)
													End If
												Next

												If TypeOf drv.Row Is BaptismsRow Then
													If Not ((aLine.Length = 15 AndAlso Not ldsFile) OrElse (ldsFile AndAlso aLine.Length = 17)) Then
														OriginalBadRecord.ErrorMessage = String.Format("Incorrect number of fields. Got {1}. Should be {0}", IIf(ldsFile, 17, 15), aLine.Length)
														nrow.DataBoundItem.Row.RowError = String.Format("Incorrect number of fields <{0}>", row.OriginalSource)
													Else
														nrow.DefaultCellStyle.BackColor = nrow.DefaultCellStyle.SelectionBackColor
														nrow.DefaultCellStyle.ForeColor = nrow.DefaultCellStyle.SelectionForeColor
														nrow.DataBoundItem.Row.RowError = String.Empty
														nrow.ReadOnly = False
														OriginalBadRecord.Delete()
													End If

												ElseIf TypeOf drv.Row Is BurialsRow Then
													If Not ((aLine.Length = 14 AndAlso Not ldsFile) OrElse (ldsFile AndAlso aLine.Length = 16)) Then
														OriginalBadRecord.ErrorMessage = String.Format("Incorrect number of fields. Got {1}. Should be {0}", IIf(ldsFile, 16, 14), aLine.Length)
														nrow.DataBoundItem.Row.RowError = String.Format("Incorrect number of fields <{0}>", row.OriginalSource)
													Else
														nrow.DefaultCellStyle.BackColor = nrow.DefaultCellStyle.SelectionBackColor
														nrow.DefaultCellStyle.ForeColor = nrow.DefaultCellStyle.SelectionForeColor
														nrow.DataBoundItem.Row.RowError = String.Empty
														nrow.ReadOnly = False
														OriginalBadRecord.Delete()
													End If

												ElseIf TypeOf drv.Row Is MarriagesRow Then
													If Not ((aLine.Length = 30 AndAlso Not ldsFile) OrElse (ldsFile AndAlso aLine.Length = 32)) Then
														OriginalBadRecord.ErrorMessage = String.Format("Incorrect number of fields. Got {1}. Should be {0}", IIf(ldsFile, 32, 30), aLine.Length)
														nrow.DataBoundItem.Row.RowError = String.Format("Incorrect number of fields <{0}>", row.OriginalSource)
													Else
														nrow.DefaultCellStyle.BackColor = nrow.DefaultCellStyle.SelectionBackColor
														nrow.DefaultCellStyle.ForeColor = nrow.DefaultCellStyle.SelectionForeColor
														nrow.DataBoundItem.Row.RowError = String.Empty
														nrow.ReadOnly = False
														OriginalBadRecord.Delete()
													End If
												End If
											Next
										End If
									End Using
								Else
									badRecords.Clear()
								End If
							Else
								Exit Do
							End If
						Loop
					End If
				Else
					With panelWinREG2
						' Display information about the file
						'
						.lblCounty.Text = _File.CountyCode
						.lblPlaceName.Text = _File.PlaceName
						.lblChurchName.Text = _File.ChurchName
						.lblCreditName.Text = _File.CreditToName
						.lblCreditEmailAddress.Text = _File.CreditToAddress
						.lblSource.Text = _File.FileSource
						.lblComments.Text = _File.FileComments
						.lblRecordCount.Text = record_count.ToString

						' Load the BindingSource with the file data, and set up the BindingNavigator
						'
						bsDGV = New BindingSource
						AddHandler bsDGV.ListChanged, AddressOf bsDGV_ListChanged
						bsDGV.DataMember = Nothing
						bsDGV.DataSource = dt
						bnDGV.BindingSource = bsDGV
						.ttipPanel.ToolTipTitle = _File.FileType

						' Attach the BindingSource to the ListView
						'
						.lvData.DataSource = bsDGV
						.lvData.Columns("County").Width = 0
						.lvData.Columns("Place").Width = 0
						.lvData.Columns("Church").Width = 0
						.lvData.Columns("LoadOrder").Width = 0
						If Not ldsFile Then
							.lvData.Columns("LDSFiche").Width = 0
							.lvData.Columns("LDSImage").Width = 0
						End If

						BindingNavigatorMoveFirstItem.Enabled = True
						BindingNavigatorMoveLastItem.Enabled = True
						BindingNavigatorMoveNextItem.Enabled = True
						BindingNavigatorMovePreviousItem.Enabled = True
						BindingNavigatorAddNewItem.Enabled = True
						BindingNavigatorDeleteItem.Enabled = True
						BindingNavigatorCutButton.Enabled = True
						BindingNavigatorCopyButton.Enabled = True
						BindingNavigatorPasteButton.Enabled = True
						If .lvData.Items.Count > 0 Then
							bsDGV.MoveFirst()
							.lvData.Items(0).EnsureVisible()
						End If
					End With
				End If

				BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
				tsEdit.Visible = fileOpen And My.Settings.UseDataGrid
				BindingNavigatorCopyButton.Enabled = fileOpen And My.Settings.UseDataGrid
				BindingNavigatorCutButton.Enabled = fileOpen And My.Settings.UseDataGrid
				BindingNavigatorPasteButton.Enabled = fileOpen And My.Settings.UseDataGrid
				tsRecord.Visible = fileOpen

				AddToMRU(_File.Pathname)
				boolFileContainsErrors = File.Exists(Path.ChangeExtension(strFileName, "ERR"))
				BindingNavigatorViewErrorsButton.Enabled = boolFileContainsErrors

			Catch ex As OleDbException
				Dim msg As String = ex.Message.Replace("''", "{0}")
				MessageBox.Show(String.Format(msg, strFileName), "Open Transcription File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

			Catch ex As CancelFileOpenException
				MessageBox.Show(ex.Message, "Open Transcription File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

			Catch ex As Exception
				MessageBox.Show(ex.Message, "Open Transcription File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

			Finally
				If csv2 IsNot Nothing Then
					csv2.Close()
					csv2.Dispose()
				End If
				If fs2 IsNot Nothing Then
					fs2.Close()
					fs2.Dispose()
				End If

				If csv IsNot Nothing Then
					csv.Close()
					csv.Dispose()
				End If
				If fs IsNot Nothing Then
					fs.Close()
					fs.Dispose()
				End If

				If My.Settings.MyCreateBackups Then
					CreateBackupFile(strFileName)
				End If

			End Try

		Else
		End If

		lblInformation.Text = String.Empty
		Cursor = c
	End Sub

	Private Sub CreateBackupFile(ByVal strFileName As String)
		Dim fi As FileInfo = New FileInfo(strFileName)
		Dim fdate As String = String.Format(" {0:yyyy-MM-dd HH.mm.ss}", fi.LastWriteTime)
		Dim fname As String = Path.GetFileNameWithoutExtension(strFileName) + fdate + Path.GetExtension(strFileName)
		Dim strBackupFilename As String = Path.Combine(My.Settings.BackupFolderName, fname)

		Try
			File.Copy(strFileName, strBackupFilename, True)
			My.Application.Log.WriteEntry(String.Format("{0} backup file {1} created", Date.Now(), strBackupFilename), TraceEventType.Information)

		Catch ex As Exception
			MessageBox.Show(ex.Message, "Create Backup File", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			My.Application.Log.WriteException(ex, TraceEventType.Error, String.Format("{0} backup file {1} not created. {2}", Date.Now(), strBackupFilename, ex.Message))

		End Try
	End Sub

	Private Function GetWorksheet(ByVal schemaTable As DataTable) As String
		Dim selectedWorksheet = 0
		If schemaTable.Rows.Count > 1 Then
			'
			'	File contains multiple worksheets.
			'	Get the user to either select one of the sheets, or exit
			'
			MessageBox.Show(My.Resources.err0035, "Import Excel File", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0035)
			Using dlg1 As New dlgMultipleWorksheets
				Try
					dlg1.BindingNavigator1.BindingSource = dlg1.BindingSource1
					dlg1.BindingSource1.DataSource = schemaTable
					dlg1.DataGridView1.Columns.Clear()
					dlg1.DataGridView1.DataSource = dlg1.BindingSource1
					dlg1.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
					dlg1.DataGridView1.AllowUserToDeleteRows = False
					If dlg1.ShowDialog() = Windows.Forms.DialogResult.OK Then
						If dlg1.DataGridView1.SelectedRows.Count > 0 Then
							selectedWorksheet = dlg1.DataGridView1.SelectedRows(0).Index
						Else
							Return String.Empty
						End If
					Else
						Return String.Empty
					End If
				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst Selecting Excel Worksheet")
				End Try
			End Using
		End If
		Return schemaTable.Rows(selectedWorksheet)("TABLE_NAME").ToString()
	End Function

	Private Sub ImportExcelXLS(ByVal strFileName As String)
		Dim c As Cursor = Cursor
		Cursor = Cursors.WaitCursor

		lblInformation.Text = String.Format(My.Resources.infLoadingFile, strFileName)
		Application.DoEvents()

		Dim detailsNeeded As Boolean = True
		ldsFile = False
		Dim io As FileInfo = My.Computer.FileSystem.GetFileInfo(strFileName)
		Dim strConnection As New OleDbConnectionStringBuilder
		_File.Filename = Path.ChangeExtension(io.Name, "CSV")

		acscAbodes.Clear()
		acscOccupations.Clear()
		acscFiche.Clear()
		acscImage.Clear()

		If isamList Is Nothing Then LoadIsamTable()

		If CanImportXLSX Then											' Can Import both XLS and XLSX files
			If String.Compare(io.Extension, ".xls", True) = 0 OrElse String.Compare(io.Extension, ".xlsx", True) = 0 Then
				strConnection.Provider = "Microsoft.ACE.OLEDB.12.0"
				strConnection.DataSource = strFileName
				strConnection.Add("Extended Properties", "Excel 12.0;HDR=No;IMEX=1")
			Else																' Not a valid extension for a spreadsheet file
				MessageBox.Show(My.Resources.err0047, "Import Spreadsheet File", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0047)
			End If
		Else
			If CanImportXLS Then											' Can only Import XLS files
				If String.Compare(io.Extension, ".xls", True) = 0 Then
					strConnection.Provider = "Microsoft.Jet.OLEDB.4.0"
					strConnection.DataSource = strFileName
					strConnection.Add("Extended Properties", "Excel 8.0;HDR=No;IMEX=1")
				Else															' Can not import XLSX files
					MessageBox.Show(My.Resources.err0061, "Import Spreadsheet File", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0047)
				End If
			Else
				MessageBox.Show(My.Resources.err0060, "Import Spreadsheet File", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0047)
				Return														' Can't Import spreadsheets
			End If
		End If


		Dim oledbConnection As OleDbConnection = New OleDbConnection(strConnection.ConnectionString)
		Try
			oledbConnection.Open()
			Using schemaTable As DataTable = oledbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
				Dim sheet As String = GetWorksheet(schemaTable)
				If sheet = String.Empty Then Return

				'
				'	Check the first 4 or 5 records to see if they contain the CSV header stuff
				'
				Dim sqlStatement1 As String = String.Format("Select * from [{0}]", sheet)
				Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(sqlStatement1, oledbConnection)
				Dim dtRaw As DataTable = New DataTable(sheet)
				adapter.FillSchema(dtRaw, SchemaType.Mapped)
				Dim record_count As Integer = adapter.Fill(dtRaw)

				If record_count >= 4 Then
					Try
						If dtRaw.Rows(0)("F1").contains("#NAME?") Or dtRaw.Rows(0)("F1").contains("+INFO") Then
							detailsNeeded = False
							If dtRaw.Rows(0)("F1").Contains("#NAME?") Then excelFile = True
							If dtRaw.Rows(0)("F1").Contains(",") Then
								Dim split As String() = dtRaw.Rows(0)("F1").Split(New [Char]() {","c})
								_File.EmailAddress = split(1)
								_File.Password = split(2)
								_File.FileType = split(4)
								split = dtRaw.Rows(1)("F1").Split(New [Char]() {","c})
								_File.Username = split(2)
								_File.County = split(3)
								_File.InternalFilename = split(4)
								_File.DateCreated = split(5)
								split = dtRaw.Rows(2)("F1").Split(New [Char]() {","c})
								_File.CreditToName = split(2)
								_File.CreditToAddress = split(3)
								split = dtRaw.Rows(3)("F1").Split(New [Char]() {","c})
								_File.DateLastUpdated = split(1)
								_File.FileSource = split(2)
								_File.FileComments = split(3)
							Else
								_File.EmailAddress = dtRaw.Rows(0)("F2")
								_File.Password = dtRaw.Rows(0)("F3")
								_File.FileType = dtRaw.Rows(0)("F5")
								_File.Username = dtRaw.Rows(1)("F1")
								_File.County = dtRaw.Rows(1)("F2")
								_File.InternalFilename = dtRaw.Rows(1)("F3")
								_File.DateCreated = dtRaw.Rows(1)("F4")
								If IsDBNull(dtRaw.Rows(2)("F4")) Then _File.CreditToName = String.Empty Else _File.CreditToName = dtRaw.Rows(2)("F4")
								If IsDBNull(dtRaw.Rows(2)("F5")) Then _File.CreditToAddress = String.Empty Else _File.CreditToAddress = dtRaw.Rows(2)("F5")
								If IsDBNull(dtRaw.Rows(3)("F1")) Then _File.DateLastUpdated = String.Empty Else _File.DateLastUpdated = dtRaw.Rows(3)("F1")
								If IsDBNull(dtRaw.Rows(3)("F2")) Then _File.FileSource = String.Empty Else _File.FileSource = dtRaw.Rows(3)("F2")
								If IsDBNull(dtRaw.Rows(3)("F3")) Then _File.FileComments = String.Empty Else _File.FileComments = dtRaw.Rows(3)("F3")
							End If
							If dtRaw.Rows(4)("F1") = "+LDS" Then
								ldsFile = True
							End If

						Else								' No Headers in the file
						End If

					Catch ex As OleDbException
						Throw

					Catch ex As Exception
						MessageBox.Show(ex.Message, "Import Excel File", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					End Try

				Else										' Less than 4 records in the file. Check for just data.
				End If

				'
				'	Now get the real data
				'
				Dim ds As TranscriptionTables = New TranscriptionTables
				Dim sqlStatement = String.Format("Select * from [{0}] Where F1 NOT LIKE '[+#]%'", sheet)
				adapter = New OleDbDataAdapter(sqlStatement, oledbConnection)
				dtRaw = New DataTable(sheet)
				_File.FileType = GetFileType(_File.Filename)

				adapter.FillSchema(dtRaw, SchemaType.Mapped)
				record_count = adapter.Fill(dtRaw)
				If Not ldsFile Then
					mnuFileShowLDSColumns.Enabled = True
					mnuFileShowLDSColumns.Visible = True
				End If
				SetDataTableHeadings(dtRaw, _File.FileType)

				'
				'	We should now take a look at what we've got, to make sure that we can actuallly use it
				'
				Dim boolCountyPresent = True
				If IsDBNull(dtRaw.Rows(0)("County")) Then
					For Each r In tabChapmanCodes.Rows
						If r.County = My.Settings.Syndicate Then
							_File.CountyCode = r.Code
							boolCountyPresent = False
							MessageBox.Show("There appears to be a lack of the presence of a valid county code in column A of the file. WinREG has inserted your default county. If this is not correct, please abandon this import and add a valid Chapman code in column A", _
							"Import Spreadsheet File", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Exit For
						End If
					Next
				Else
					_File.CountyCode = dtRaw.Rows(0)("County")
				End If

				Dim boolPlacePresent = True
				If IsDBNull(dtRaw.Rows(0)("Place")) Then
					boolPlacePresent = False
				Else
					_File.PlaceName = dtRaw.Rows(0)("Place")
				End If

				Dim boolChurchPresent = True
				If IsDBNull(dtRaw.Rows(0)("Church")) Then
					boolChurchPresent = False
				Else
					_File.ChurchName = dtRaw.Rows(0)("Church")
				End If

				Try
					_File.Pathname = Path.ChangeExtension(strFileName, "CSV")
					If detailsNeeded Then
						If tabChapmanCodes.Rows.Contains(_File.CountyCode) Then
							_File.County = tabChapmanCodes.Rows.Find(_File.CountyCode)("County")
						Else
						End If
						_File.InternalFilename = _File.Filename
						_File.Username = My.Settings.Name
						_File.Password = "password"
						_File.EmailAddress = My.Settings.EmailAddress
						_File.DateCreated = Format(Now(), "dd-MMM-yyyy")
						_File.DateLastUpdated = Format(Now(), "dd-MMM-yyyy")
						_File.FileComments = String.Empty
						_File.FileSource = String.Empty
						_File.CreditToName = String.Empty
						_File.CreditToAddress = String.Empty
					End If

					'
					'	Complete the missing, mandatory file details
					'
					If Not (boolPlacePresent AndAlso boolChurchPresent) Then
						MessageBox.Show("Neither a Placename or a Churchname can be found in the first record. These are mandatory fields. Please add them in the dialog that follows", _
						  "Import Spreadsheet File", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Using dlg As New dlgEditFileDetails With {._place = _File.PlaceName, ._church = _File.ChurchName, ._source = _File.FileSource, ._comments = _File.FileComments}
							If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
								If _File.PlaceName <> dlg._place Or _File.ChurchName <> dlg._church Or _File.FileSource <> dlg._source Or _File.FileComments <> dlg._comments Then
									If _File.FileSource <> dlg._source Then
										_File.FileSource = dlg._source
										fileChanged = True
									End If

									If _File.FileComments <> dlg._comments Then
										_File.FileComments = dlg._comments
										fileChanged = True
									End If

									If _File.ChurchName <> dlg._church Then
										_File.ChurchName = dlg._church
										For Each row In dtRaw.Rows
											row("Church") = _File.ChurchName
										Next
										fileChanged = True
									End If

									If _File.PlaceName <> dlg._place Then
										_File.PlaceName = dlg._place
										For Each row In dtRaw.Rows
											row("Place") = _File.PlaceName
										Next
										fileChanged = True
									End If
									BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
								End If
							Else
								Exit Sub
							End If
						End Using
					End If

					'
					'	Let the User now check/edit the CSV file header records
					'
					MessageBox.Show("File Header details should be checked before proceeding any further", "Header Information May Be Missing or Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Using dlg As New dlgExcelFileDetails()
						If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
						End If
					End Using

					If ldsFile Then
						Text = String.Format("{0} LDS - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
					Else
						Text = String.Format("{0} - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
					End If

					If _User.IsAdministrator Then
						Dim str As String = String.Format("{0} (Administrator)", Text())
						Text = str
					End If

				Catch ex As OleDbException
					Throw

				Catch ex As Exception
					MessageBox.Show(ex.Message, "Import Excel File", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				End Try

				'
				'	Now, we need to "convert" the DataTable as read from the file into a Transcription Files DataTable
				'	so that we can use it as a DataSource in the DataGridView - and save the contents as a CSV File!
				'
				Try
					Dim dtTranscription As DataTable = Nothing
					Select Case _File.FileType
						Case "BAPTISMS"
							dtTranscription = ds.Baptisms
							For Each row As DataRow In dtRaw.Rows
								Dim nrow As BaptismsRow = ds.Baptisms.NewBaptismsRow
								nrow.County = row("County")
								nrow.Place = row("Place")
								nrow.Church = row("Church")
								nrow.RegNo = IIf(IsDBNull(row("RegNo")), "", row("RegNo"))

								nrow.BirthDate = IIf(IsDBNull(row("BirthDate")), "", row("BirthDate"))
								nrow.BaptismDate = IIf(IsDBNull(row("BaptismDate")), "", row("BaptismDate"))
								nrow.Forenames = IIf(IsDBNull(row("Forenames")), "", row("Forenames"))
								nrow.Sex = IIf(IsDBNull(row("Sex")), "", row("Sex"))
								nrow.FathersName = IIf(IsDBNull(row("FathersName")), "", row("FathersName"))
								nrow.MothersName = IIf(IsDBNull(row("MothersName")), "", row("MothersName"))
								nrow.FathersSurname = IIf(IsDBNull(row("FathersSurname")), "", row("FathersSurname"))
								nrow.MothersSurname = IIf(IsDBNull(row("MothersSurname")), "", row("MothersSurname"))
								nrow.Abode = IIf(IsDBNull(row("Abode")), "", row("Abode"))
								nrow.FathersOccupation = IIf(IsDBNull(row("FathersOccupation")), "", row("FathersOccupation"))

								nrow.Notes = IIf(IsDBNull(row("Notes")), "", row("Notes"))
								If ldsFile Then
									nrow.LDSFiche = IIf(IsDBNull(row("Fiche")), "", row("Fiche"))
									nrow.LDSImage = IIf(IsDBNull(row("Image")), "", row("Image"))
								End If
								ds.Baptisms.AddBaptismsRow(nrow)
								AddStringToCollection(acscAbodes, nrow.Abode)
								AddStringToCollection(acscOccupations, nrow.FathersOccupation)

								AddStringToCollection(acscFiche, nrow.LDSFiche)
								AddStringToCollection(acscImage, nrow.LDSImage)
							Next

						Case "BURIALS"
							dtTranscription = ds.Burials
							For Each row As DataRow In dtRaw.Rows
								Dim nrow As BurialsRow = ds.Burials.NewBurialsRow
								nrow.County = row("County")
								nrow.Place = row("Place")
								nrow.Church = row("Church")
								nrow.RegNo = IIf(IsDBNull(row("RegNo")), "", row("RegNo"))

								nrow.BurialDate = IIf(IsDBNull(row("BurialDate")), "", row("BurialDate"))
								nrow.Forenames = IIf(IsDBNull(row("Forenames")), "", row("Forenames"))
								nrow.Relationship = IIf(IsDBNull(row("Relationship")), "", row("Relationship"))
								nrow.MaleForenames = IIf(IsDBNull(row("MaleForenames")), "", row("MaleForenames"))
								nrow.FemaleForenames = IIf(IsDBNull(row("FemaleForenames")), "", row("FemaleForenames"))
								nrow.RelativeSurname = IIf(IsDBNull(row("RelativeSurname")), "", row("RelativeSurname"))
								nrow.Surname = IIf(IsDBNull(row("Surname")), "", row("Surname"))
								nrow.Age = IIf(IsDBNull(row("Age")), "", row("Age"))
								nrow.Abode = IIf(IsDBNull(row("Abode")), "", row("Abode"))

								nrow.Notes = IIf(IsDBNull(row("Notes")), "", row("Notes"))
								If ldsFile Then
									nrow.LDSFiche = IIf(IsDBNull(row("Fiche")), "", row("Fiche"))
									nrow.LDSImage = IIf(IsDBNull(row("Image")), "", row("Image"))
								End If
								ds.Burials.AddBurialsRow(nrow)
								AddStringToCollection(acscAbodes, nrow.Abode)

								AddStringToCollection(acscFiche, nrow.LDSFiche)
								AddStringToCollection(acscImage, nrow.LDSImage)
							Next

						Case "MARRIAGES"
							dtTranscription = ds.Marriages
							For Each row As DataRow In dtRaw.Rows
								Dim nrow As MarriagesRow = ds.Marriages.NewMarriagesRow
								nrow.County = row("County")
								nrow.Place = row("Place")
								nrow.Church = row("Church")
								nrow.RegNo = IIf(IsDBNull(row("RegNo")), "", row("RegNo"))

								nrow.MarriageDate = IIf(IsDBNull(row("MarriageDate")), "", row("MarriageDate"))
								nrow.GroomForenames = IIf(IsDBNull(row("GroomForenames")), "", row("GroomForenames"))
								nrow.GroomSurname = IIf(IsDBNull(row("GroomSurname")), "", row("GroomSurname"))
								nrow.GroomAge = IIf(IsDBNull(row("GroomAge")), "", row("GroomAge"))
								nrow.GroomParish = IIf(IsDBNull(row("GroomParish")), "", row("GroomParish"))
								nrow.GroomCondition = IIf(IsDBNull(row("GroomCondition")), "", row("GroomCondition"))
								nrow.GroomOccupation = IIf(IsDBNull(row("GroomOccupation")), "", row("GroomOccupation"))
								nrow.GroomAbode = IIf(IsDBNull(row("GroomAbode")), "", row("GroomAbode"))
								nrow.BrideForenames = IIf(IsDBNull(row("BrideForenames")), "", row("BrideForenames"))
								nrow.BrideSurname = IIf(IsDBNull(row("BrideSurname")), "", row("BrideSurname"))
								nrow.BrideAge = IIf(IsDBNull(row("BrideAge")), "", row("BrideAge"))
								nrow.BrideParish = IIf(IsDBNull(row("BrideParish")), "", row("BrideParish"))
								nrow.BrideCondition = IIf(IsDBNull(row("BrideCondition")), "", row("BrideCondition"))
								nrow.BrideOccupation = IIf(IsDBNull(row("BrideOccupation")), "", row("BrideOccupation"))
								nrow.BrideAbode = IIf(IsDBNull(row("BrideAbode")), "", row("BrideAbode"))
								nrow.GroomFatherForenames = IIf(IsDBNull(row("GroomFatherForenames")), "", row("GroomFatherForenames"))
								nrow.GroomFatherSurname = IIf(IsDBNull(row("GroomFatherSurname")), "", row("GroomFatherSurname"))
								nrow.GroomFatherOccupation = IIf(IsDBNull(row("GroomFatherOccupation")), "", row("GroomFatherOccupation"))
								nrow.BrideFatherForenames = IIf(IsDBNull(row("BrideFatherForenames")), "", row("BrideFatherForenames"))
								nrow.BrideFatherSurname = IIf(IsDBNull(row("BrideFatherSurname")), "", row("BrideFatherSurname"))
								nrow.BrideFatherOccupation = IIf(IsDBNull(row("BrideFatherOccupation")), "", row("BrideFatherOccupation"))
								nrow.Witness1Forenames = IIf(IsDBNull(row("Witness1Forenames")), "", row("Witness1Forenames"))
								nrow.Witness1Surname = IIf(IsDBNull(row("Witness1Surname")), "", row("Witness1Surname"))
								nrow.Witness2Forenames = IIf(IsDBNull(row("Witness2Forenames")), "", row("Witness2Forenames"))
								nrow.Witness2Surname = IIf(IsDBNull(row("Witness2Surname")), "", row("Witness2Surname"))

								nrow.Notes = IIf(IsDBNull(row("Notes")), "", row("Notes"))
								If ldsFile Then
									nrow.LDSFiche = IIf(IsDBNull(row("Fiche")), "", row("Fiche"))
									nrow.LDSImage = IIf(IsDBNull(row("Image")), "", row("Image"))
								End If
								ds.Marriages.AddMarriagesRow(nrow)
								AddStringToCollection(acscAbodes, nrow.GroomParish)
								AddStringToCollection(acscAbodes, nrow.GroomAbode)
								AddStringToCollection(acscAbodes, nrow.BrideParish)
								AddStringToCollection(acscAbodes, nrow.BrideAbode)

								AddStringToCollection(acscOccupations, nrow.GroomOccupation)
								AddStringToCollection(acscOccupations, nrow.BrideOccupation)
								AddStringToCollection(acscOccupations, nrow.GroomFatherOccupation)
								AddStringToCollection(acscOccupations, nrow.BrideFatherOccupation)

								AddStringToCollection(acscFiche, nrow.LDSFiche)
								AddStringToCollection(acscImage, nrow.LDSImage)
							Next
					End Select

					My.Settings.UseDataGrid = True							' Enforce use of the Datagrid for the initial import and creation of the CSV
					mainDGV.Columns.Clear()
					mainDGV.Rows.Clear()
					mainDGV.AutoGenerateColumns = False
					SetDataGridViewHeadings(_File.FileType)
					fileOpen = True
					fileNew = False
					fileChanged = True
					PopulateDataGridView(dtTranscription)
					BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
					tsEdit.Visible = fileOpen And My.Settings.UseDataGrid
					BindingNavigatorCopyButton.Enabled = fileOpen And My.Settings.UseDataGrid
					BindingNavigatorCutButton.Enabled = fileOpen And My.Settings.UseDataGrid
					BindingNavigatorPasteButton.Enabled = fileOpen And My.Settings.UseDataGrid
					tsRecord.Visible = fileOpen

					My.Application.Log.WriteEntry(String.Format("{0} Imported file {1}", Date.Now(), _File.Filename), TraceEventType.Information)
					ShowContentDisplay()

				Catch ex As OleDbException
					Throw

				Catch ex As Exception
					MessageBox.Show(ex.Message, "Import Excel File", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				End Try

			End Using

		Catch ex As OleDbException
			Dim msg As String = ex.Message.Replace("''", "{0}")
			MessageBox.Show(String.Format(msg, strFileName), "Import Excel File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Catch ex As Exception
			MessageBox.Show(ex.Message, "Import Excel File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Finally
			oledbConnection.Close()
		End Try

		lblInformation.Text = String.Empty
		Cursor = c

	End Sub

	Private Function BuildRecord(ByVal row As Object) As String
		Dim DataLine As String
		Dim strFiche As String = "", strImage As String = ""

		DataLine = ""
		If IsNothing(row.County) Or IsDBNull(row.County) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.County)
		If IsNothing(row.Place) Or IsDBNull(row.Place) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Place)
		If IsNothing(row.Church) Or IsDBNull(row.Church) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Church)
		If IsNothing(row.RegNo) Or IsDBNull(row.RegNo) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.RegNo)

		Select Case _File.FileType
			Case "BAPTISMS"
				If IsNothing(row.BirthDate) Or IsDBNull(row.BirthDate) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BirthDate)
				If IsNothing(row.BaptismDate) Or IsDBNull(row.BaptismDate) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BaptismDate)
				If IsNothing(row.Forenames) Or IsDBNull(row.Forenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Forenames)
				If IsNothing(row.Sex) Or IsDBNull(row.Sex) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Sex)
				If IsNothing(row.FathersName) Or IsDBNull(row.FathersName) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.FathersName)
				If IsNothing(row.MothersName) Or IsDBNull(row.MothersName) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.MothersName)
				If IsNothing(row.FathersSurname) Or IsDBNull(row.FathersSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.FathersSurname)
				If IsNothing(row.MothersSurname) Or IsDBNull(row.MothersSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.MothersSurname)
				If IsNothing(row.Abode) Or IsDBNull(row.Abode) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Abode)
				If IsNothing(row.FathersOccupation) Or IsDBNull(row.FathersOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.FathersOccupation)

			Case "BURIALS"
				If IsNothing(row.BurialDate) Or IsDBNull(row.BurialDate) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BurialDate)
				If IsNothing(row.Forenames) Or IsDBNull(row.Forenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Forenames)
				If IsNothing(row.Relationship) Or IsDBNull(row.Relationship) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Relationship)
				If IsNothing(row.MaleForenames) Or IsDBNull(row.MaleForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.MaleForenames)
				If IsNothing(row.FemaleForenames) Or IsDBNull(row.FemaleForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.FemaleForenames)
				If IsNothing(row.RelativeSurname) Or IsDBNull(row.RelativeSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.RelativeSurname)
				If IsNothing(row.Surname) Or IsDBNull(row.Surname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Surname)
				If IsNothing(row.Age) Or IsDBNull(row.Age) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Age)
				If IsNothing(row.Abode) Or IsDBNull(row.Abode) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Abode)

			Case "MARRIAGES"
				If IsNothing(row.MarriageDate) Or IsDBNull(row.MarriageDate) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.MarriageDate)
				If IsNothing(row.GroomForenames) Or IsDBNull(row.GroomForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomForenames)
				If IsNothing(row.GroomSurname) Or IsDBNull(row.GroomSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomSurname)
				If IsNothing(row.GroomAge) Or IsDBNull(row.GroomAge) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomAge)
				If IsNothing(row.GroomParish) Or IsDBNull(row.GroomParish) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomParish)
				If IsNothing(row.GroomCondition) Or IsDBNull(row.GroomCondition) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomCondition)
				If IsNothing(row.GroomOccupation) Or IsDBNull(row.GroomOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomOccupation)
				If IsNothing(row.GroomAbode) Or IsDBNull(row.GroomAbode) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomAbode)
				If IsNothing(row.BrideForenames) Or IsDBNull(row.BrideForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideForenames)
				If IsNothing(row.BrideSurname) Or IsDBNull(row.BrideSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideSurname)
				If IsNothing(row.BrideAge) Or IsDBNull(row.BrideAge) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideAge)
				If IsNothing(row.BrideParish) Or IsDBNull(row.BrideParish) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideParish)
				If IsNothing(row.BrideCondition) Or IsDBNull(row.BrideCondition) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideCondition)
				If IsNothing(row.BrideOccupation) Or IsDBNull(row.BrideOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideOccupation)
				If IsNothing(row.BrideAbode) Or IsDBNull(row.BrideAbode) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideAbode)
				If IsNothing(row.GroomFatherForenames) Or IsDBNull(row.GroomFatherForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomFatherForenames)
				If IsNothing(row.GroomFatherSurname) Or IsDBNull(row.GroomFatherSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomFatherSurname)
				If IsNothing(row.GroomFatherOccupation) Or IsDBNull(row.GroomFatherOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.GroomFatherOccupation)
				If IsNothing(row.BrideFatherForenames) Or IsDBNull(row.BrideFatherForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideFatherForenames)
				If IsNothing(row.BrideFatherSurname) Or IsDBNull(row.BrideFatherSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideFatherSurname)
				If IsNothing(row.BrideFatherOccupation) Or IsDBNull(row.BrideFatherOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.BrideFatherOccupation)
				If IsNothing(row.Witness1Forenames) Or IsDBNull(row.Witness1Forenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Witness1Forenames)
				If IsNothing(row.Witness1Surname) Or IsDBNull(row.Witness1Surname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Witness1Surname)
				If IsNothing(row.Witness2Forenames) Or IsDBNull(row.Witness2Forenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Witness2Forenames)
				If IsNothing(row.Witness2Surname) Or IsDBNull(row.Witness2Surname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Witness2Surname)
		End Select

		If IsNothing(row.Notes) Or IsDBNull(row.Notes) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(row.Notes)

		If ldsFile Then
			If IsDBNull(row.LDSFiche) OrElse row.LDSFiche Is Nothing Then
				If strFiche <> "" Then DataLine = DataLine & "," & QuoteString(strFiche) Else DataLine = DataLine & ","
			Else
				DataLine = DataLine & "," & QuoteString(row.LDSFiche)
				strFiche = row.LDSFiche
			End If
			If IsDBNull(row.LDSImage) OrElse row.LDSImage Is Nothing Then
				If strImage <> "" Then DataLine = DataLine & "," & QuoteString(strImage) Else DataLine = DataLine & ","
			Else
				DataLine = String.Format("{0},{1}", DataLine, QuoteString(row.LDSImage))
				strImage = row.LDSImage
			End If
		End If
		Return DataLine
	End Function

	Private Function SaveTranscriptionFile() As Boolean
		SaveTranscriptionFile = False
		lblInformation.Text = String.Format(My.Resources.infSavingFile, _File.Pathname)
		Application.DoEvents()

		Dim c As Cursor = Cursor
		Cursor = Cursors.WaitCursor

		Dim cp As String
		If _Encoding.CodePage = 437 Then
			cp = ",cp437"
		Else
			cp = ","
		End If
		If _Encoding.CodePage = 850 Then cp = ",cp850"

		Dim fs As FileStream = Nothing
		Dim sw As StreamWriter = Nothing
		Dim Line1, Line2, Line3, Line4, DataLine As String

		Try
			fs = New FileStream(Path.ChangeExtension(_File.Pathname, ".tmp"), FileMode.Create, FileAccess.Write, FileShare.None)
			sw = New StreamWriter(fs, _Encoding)
			_File.DateLastUpdated = Format(Now(), "dd-MMM-yyyy")

			Dim fv As String = String.Format(",{0}.{1:00}.{2:00}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)

			Line1 = "+INFO," & QuoteString(_File.EmailAddress) & "," & QuoteString(_File.Password) & ",SEQUENCED," & QuoteString(_File.FileType) & cp & fv
			Line2 = "#,CCC," & QuoteString(_File.Username) & "," & QuoteString(_File.County) & "," & QuoteString(_File.Filename) & "," & _File.DateCreated
			Line3 = "#,CREDIT," & QuoteString(_File.CreditToName) & "," & QuoteString(_File.CreditToAddress)
			Line4 = "#," & _File.DateLastUpdated & "," & QuoteString(_File.FileSource) & "," & QuoteString(_File.FileComments)

			sw.WriteLine(Line1, _Culture)
			sw.WriteLine(Line2, _Culture)
			sw.WriteLine(Line3, _Culture)
			sw.WriteLine(Line4, _Culture)

			If ldsFile Then
				sw.WriteLine("+LDS", _Culture)
			End If

			Dim charComma As Char() = {","}
			Dim boolFileCorrected As Boolean = False
			Dim recnum As Integer = 0

			For Each row In bsDGV.DataSource.Rows
				recnum += 1
				Try
					If row.County <> _File.CountyCode Then
						Dim msg As String = String.Format(" {0,4:####} <{1}> - <{2}>", recnum, row.County, _File.CountyCode)
						My.Application.Log.WriteEntry(String.Format("{0} Bad <County> {1}", Date.Now(), msg), TraceEventType.Information)
						row.County = _File.CountyCode
						boolFileCorrected = True
					End If
					If row.Place <> _File.PlaceName Then
						Dim msg As String = String.Format(" {0,4:####} <{1}> - <{2}>", recnum, row.Place, _File.PlaceName)
						My.Application.Log.WriteEntry(String.Format("{0} Bad <Placename> {1}", Date.Now(), msg), TraceEventType.Information)
						row.Place = _File.PlaceName
						boolFileCorrected = True
					End If
					If row.Church <> _File.ChurchName Then
						Dim msg As String = String.Format(" {0,4:####} <{1}> - <{2}>", recnum, row.Church, _File.ChurchName)
						My.Application.Log.WriteEntry(String.Format("{0} Bad <Church> {1}", Date.Now(), msg), TraceEventType.Information)
						row.Church = _File.ChurchName
						boolFileCorrected = True
					End If
					If Not String.IsNullOrEmpty(row.RegNo) AndAlso Not IsNumeric(row.RegNo) Then
						Dim msg As String = String.Format(" {0,4:####} <{1}>", recnum, row.RegNo)
						My.Application.Log.WriteEntry(String.Format("{0} Bad <RegNo> {1}", Date.Now(), msg), TraceEventType.Information)
						row.RegNo = ""
						boolFileCorrected = True
					End If

					If badRecords.Rows.Count = 0 Then
						DataLine = BuildRecord(row)
					Else
						Dim targetRow = mainDGV.Rows(bsDGV.Find("LoadOrder", row.LoadOrder))
						If targetRow.ReadOnly Then
							Dim x = badRecords.FindByRowNumber(row.LoadOrder + 1)
							DataLine = x.OriginalSource
						Else
							DataLine = BuildRecord(row)
						End If
					End If

					DataLine = DataLine.TrimStart(charComma)
					sw.WriteLine(DataLine, _Culture)

				Catch ex As Exception
					MessageBox.Show(ex.Message, "Saving File - Row Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
				End Try
			Next

			'	Clear the data-changed indications from the DataGrid
			'
			For Each row As DataGridViewRow In mainDGV.Rows
				For Each cell As DataGridViewCell In row.Cells
					If cell.Style.BackColor = Color.LightPink Then
						If recnum Mod 2 Then
							cell.Style.BackColor = mainDGV.DefaultCellStyle.BackColor
						Else
							cell.Style.BackColor = mainDGV.AlternatingRowsDefaultCellStyle.BackColor
						End If
					End If
				Next
			Next

			If boolFileCorrected Then
				MessageBox.Show(My.Resources.msgFileCorrupted, "Saving File", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0006)
			End If

			If sw IsNot Nothing Then sw.Close()
			If fs IsNot Nothing Then fs.Close()

			If File.Exists(Path.ChangeExtension(_File.Pathname, "ERR")) Then File.Delete(Path.ChangeExtension(_File.Pathname, "ERR"))
			File.Delete(_File.Pathname)
			My.Computer.FileSystem.RenameFile(Path.ChangeExtension(_File.Pathname, ".tmp"), Path.GetFileName(_File.Pathname))
			My.Application.Log.WriteEntry(String.Format("{0} Saved file {1}", Date.Now(), _File.Filename), TraceEventType.Information)
			SaveTranscriptionFile = True

		Catch ex As Exception
			MessageBox.Show(ex.Message, "Saving File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

		End Try

		lblInformation.Text = String.Empty
		Cursor = c

	End Function

	Private Sub CloseTranscriptionFile(ByVal fExit As CloseReason)
		Dim c As Cursor = Cursor
		Cursor = Cursors.WaitCursor

		If _OS.Version.Major >= 6 Then
			If Not winImageViewer Is Nothing Then
				If winImageViewer.IsVisible Then
					winImageViewer.Hide()
				End If
			End If
		Else
			If Not frmImageViewer Is Nothing Then
				If Not frmImageViewer.IsDisposed Then
					If frmImageViewer.Visible Then frmImageViewer.Hide()
				End If
			End If
		End If

		If fileChanged Then
			'	Validate the DataGridView to see if there are any residual errors
			'
			lblInformation.Text = String.Format(My.Resources.infCheckingFile, _File.Pathname)
			Application.DoEvents()

			Dim boolFileContainsErrors As Boolean = False
			Dim rc As DialogResult = Windows.Forms.DialogResult.Yes
			For Each row As DataGridViewRow In mainDGV.Rows
				If row.ErrorText <> "" Then
					boolFileContainsErrors = True
					Exit For
				Else
					For Each cell As DataGridViewCell In row.Cells
						If cell.ErrorText <> "" Then
							boolFileContainsErrors = True
							Exit For
						End If
					Next
					If boolFileContainsErrors Then Exit For
				End If
			Next

			Select Case fExit
				Case CloseReason.None
					If boolFileContainsErrors Then
						If MessageBox.Show(String.Format(My.Resources.infResidualErrors, "save"), "Save Transcription File Data", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, INF0012) = Windows.Forms.DialogResult.Yes Then
							If SaveTranscriptionFile() Then
								fileChanged = False
							End If
						End If
					Else
						If MessageBox.Show(String.Format(My.Resources.msgSaveFile, ""), "Save Transcription File Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0009) = Windows.Forms.DialogResult.Yes Then
							If SaveTranscriptionFile() Then
								fileChanged = False
							End If
						End If
					End If

				Case CloseReason.WindowsShutDown
					If SaveTranscriptionFile() Then
						fileChanged = False
					End If

				Case Else
					If MessageBox.Show(String.Format(My.Resources.msgSaveFile, My.Resources.infLastChance), "Save Transcription File Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0009) = Windows.Forms.DialogResult.Yes Then
						If SaveTranscriptionFile() Then
							fileChanged = False
						End If
					End If
			End Select

			lblInformation.Text = String.Empty
		End If

		'
		'	Save the current configuration of the DGV columns - visibility, width and order
		'	This needs to be kept separate for each of the 3 file types - Baptisms, Burials and Marriages
		'
		'		Dim columns As DataGridViewColumnCollection = mainDGV.Columns
		Dim strCollection As StringCollection = mainDGV.CurrentColumnLayout()

		Select Case _File.FileType
			Case "BAPTISMS"
				My.Settings.colLayoutBaptisms = strCollection

			Case "BURIALS"
				My.Settings.colLayoutBurials = strCollection

			Case "MARRIAGES"
				My.Settings.colLayoutMarriages = strCollection

		End Select
		My.Settings.Save()

		bnDGV.BindingSource = Nothing
		mainDGV.DataSource = Nothing

		boolFileContainsErrors = False
		fileOpen = False
		fileNew = False
		HideContentDisplay()
		mainWelcomeText.SelectionStart = 0
		mainWelcomeText.SelectionLength = 0
		tsEdit.Visible = fileOpen And My.Settings.UseDataGrid
		BindingNavigatorCopyButton.Enabled = fileOpen And My.Settings.UseDataGrid
		BindingNavigatorCutButton.Enabled = fileOpen And My.Settings.UseDataGrid
		BindingNavigatorPasteButton.Enabled = fileOpen And My.Settings.UseDataGrid
		tsRecord.Visible = fileOpen
		mnuToolsFiltering.CheckState = CheckState.Unchecked
		tsFilters.Visible = False
		panelWinREG2._ItemActivated = False

		If bsDGV IsNot Nothing Then
			If Not String.IsNullOrEmpty(bsDGV.Filter) Then
				bsDGV.RemoveFilter()
			End If
			RemoveHandler bsDGV.ListChanged, AddressOf bsDGV_ListChanged
			Select Case _File.FileType
				Case "BAPTISMS"
					Dim dt As BaptismsDataTable = bsDGV.DataSource
					dt.Clear()
				Case "BURIALS"
					Dim dt As BurialsDataTable = bsDGV.DataSource
					dt.Clear()
				Case "MARRIAGES"
					Dim dt As MarriagesDataTable = bsDGV.DataSource
					dt.Clear()
			End Select
			bsDGV.DataSource = Nothing
			bsDGV.Dispose()
			bsDGV = Nothing
		End If

		BindingNavigatorMoveFirstItem.Enabled = False
		BindingNavigatorMoveLastItem.Enabled = False
		BindingNavigatorMoveNextItem.Enabled = False
		BindingNavigatorMovePreviousItem.Enabled = False
		BindingNavigatorAddNewItem.Enabled = False
		BindingNavigatorDeleteItem.Enabled = False
		BindingNavigatorDuplicateRecord.Enabled = False
		BindingNavigatorCutButton.Enabled = False
		BindingNavigatorCopyButton.Enabled = False
		BindingNavigatorPasteButton.Enabled = False
		BindingNavigatorViewErrorsButton.Enabled = False
		BindingNavigatorSaveFileButton.Enabled = False
		mnuFileUnsortRecords.Enabled = False
		mnuFileUnsortRecords.Visible = False
		BindingNavigatorUnsortFileButton.Enabled = False
		My.Application.Log.WriteEntry(String.Format("{0} Closed file {1}", Date.Now(), _File.Filename), TraceEventType.Information)
		Text = strDefaultTitle
		hlpMain.SetHelpKeyword(Me, "GettingStarted.html")

		If _OS.Version.Major >= 6 Then
			If Not winImageViewer Is Nothing Then
				If Not winImageViewer.IsVisible Then
					winImageViewer.Show()
				End If
			End If
		Else
			If Not frmImageViewer Is Nothing Then
				If Not frmImageViewer.IsDisposed Then
					If Not frmImageViewer.Visible Then frmImageViewer.Show()
				End If
			End If
		End If

		Cursor = c
	End Sub

	Private Sub ImportErrorsFromFreeREG()
		If boolFileContainsErrors Then
			Dim lines As String() = File.ReadAllLines(Path.ChangeExtension(_File.Pathname, "ERR"), _Encoding)
			For Each line In lines
				If line <> String.Empty Then
					Dim ele As String() = line.Split(New [Char]() {"("c, ")"c}, StringSplitOptions.RemoveEmptyEntries)
					For Each str As String In ele
						If str.Contains(" line ") Then
							Dim l As String = str.Substring(str.Trim.IndexOf(" line ") + 6)
							Dim lineNumber As Integer = l - IIf(ldsFile, 5, 4)

							Dim x1 = mainDGV.DataSource
							Dim x2 = x1.DataSource
							Dim x3 = x2.rows(lineNumber - 1)
							mainDGV.Rows(lineNumber - 1).DefaultCellStyle.BackColor = Color.Red
							mainDGV.Rows(lineNumber - 1).DefaultCellStyle.ForeColor = Color.White
							x3.RowError = ele(0)

							Exit For
						End If
					Next
				End If
			Next
			mainDGV.EndEdit()
		End If
	End Sub

	Private Sub HideContentDisplay()
		If My.Settings.UseDataGrid Then
			mainDGV.Visible = False
			panelWinREG2.Visible = False
		Else
			panelWinREG2.Visible = False
			mainDGV.Visible = False
			Select Case _File.FileType
				Case "BAPTISMS"
					panelWinREG2.grpBaptisms.Visible = False
				Case "BURIALS"
					panelWinREG2.grpBurials.Visible = False
				Case "MARRIAGES"
					panelWinREG2.grpMarriages.Visible = False
			End Select
		End If
		mainWelcomeText.Visible = True
		tscMain.ContentPanel.BackColor = ContentPanelBackground
	End Sub

	Private Sub ShowContentDisplay()
		mainWelcomeText.Visible = False
		If My.Settings.UseDataGrid Then
			tscMain.ContentPanel.BackColor = ContentPanelBackground
			mainDGV.Visible = True
			panelWinREG2.Visible = False
		Else
			panelWinREG2.Visible = True
			mainDGV.Visible = False
			Select Case _File.FileType
				Case "BAPTISMS"
					panelWinREG2.grpBaptisms.Visible = True
					tscMain.ContentPanel.BackColor = panelWinREG2.grpBaptisms.BackColor
					panelWinREG2.lvData.BackColor = panelWinREG2.grpBaptisms.BackColor
				Case "BURIALS"
					panelWinREG2.grpBurials.Visible = True
					tscMain.ContentPanel.BackColor = panelWinREG2.grpBurials.BackColor
					panelWinREG2.lvData.BackColor = panelWinREG2.grpBurials.BackColor
				Case "MARRIAGES"
					panelWinREG2.grpMarriages.Visible = True
					tscMain.ContentPanel.BackColor = panelWinREG2.grpMarriages.BackColor
					panelWinREG2.lvData.BackColor = panelWinREG2.grpMarriages.BackColor
			End Select
		End If
	End Sub

	Private Sub SwitchFileView(ByVal UseGrid As Boolean)
		HideContentDisplay()
		If UseGrid Then
			' Switch from WinREG/2 to WinREG/3
			'
			If mainDGV.Columns.Count > 0 Then mainDGV.Columns.Clear()
			If mainDGV.Rows.Count > 0 Then mainDGV.Rows.Clear()
			mainDGV.AutoGenerateColumns = False
			ttMain.ToolTipTitle = _File.FileType
			SetDataGridViewHeadings(_File.FileType)
			PopulateDataGridView(bsDGV.DataSource)
		Else
			' Switch from WinREG/3 to WinREG/2
			'
			With panelWinREG2
				' Display information about the file
				'
				.lblCounty.Text = _File.CountyCode
				.lblPlaceName.Text = _File.PlaceName
				.lblChurchName.Text = _File.ChurchName
				.lblCreditName.Text = _File.CreditToName
				.lblCreditEmailAddress.Text = _File.CreditToAddress
				.lblSource.Text = _File.FileSource
				.lblComments.Text = _File.FileComments

				' Attach the BindingSource to the ListView
				'
				.lvData.DataSource = bsDGV
				.lvData.Columns("County").Width = 0
				.lvData.Columns("Place").Width = 0
				.lvData.Columns("Church").Width = 0
				.lvData.Columns("LoadOrder").Width = 0

				.ttipPanel.ToolTipTitle = _File.FileType
				If .lvData.Items.Count > 0 Then
					bsDGV.MoveFirst()
					.lvData.Items(0).EnsureVisible()
					.lblRecordCount.Text = .lvData.Items.Count.ToString
				End If
			End With
		End If
		My.Settings.UseDataGrid = UseGrid
		ShowContentDisplay()
	End Sub

#End Region

#Region "ToolStrip"

	Private Sub tsFile_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles tsFile.DropDownOpening
		mnuFileMRUList.Enabled = My.Settings.MyMRUList.Count > 0
		mnuFileMRUList.Visible = My.Settings.MyMRUList.Count > 0

		mnuFileCloseFile.Enabled = fileOpen
		mnuFileEditFileDetails.Enabled = fileOpen
		mnuFileRenameFile.Enabled = fileOpen
		mnuFileSaveFile.Enabled = fileOpen And fileChanged
		mnuFileSaveFileAs.Enabled = fileOpen And (mainDGV.RowCount > 0)
		mnuFileValidateFileData.Enabled = fileOpen And (mainDGV.RowCount > 0) And My.Settings.UseDataGrid
		mnuFileImportExcel.Enabled = CanImportXLS Or CanImportXLSX
	End Sub

	Private Sub tsEdit_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles tsEdit.DropDownOpening
		mnuEditUndo.Enabled = mainDGV.CanUndo

		'mnuEditCopy.Enabled = False
		'mnuEditCut.Enabled = False
		'mnuEditPaste.Enabled = False
		'If mainDGV.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
		'	mnuEditCopy.Enabled = True
		'	mnuEditCut.Enabled = True
		'End If

		'If Clipboard.ContainsText() Then
		'	If Clipboard.ContainsText(TextDataFormat.Text) Then
		'		mnuEditPaste.Enabled = True
		'	ElseIf Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue) Then

		'	End If
		'End If
	End Sub

	Private Sub tsSettings_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles tsSettings.DropDownOpening
		mnuSettingsColumnVisibility.Visible = fileOpen And My.Settings.UseDataGrid
		mnuSettingsColumnVisibility.Enabled = fileOpen And My.Settings.UseDataGrid

		mnuSettingsSelectLayout.Visible = fileOpen And My.Settings.UseDataGrid
		mnuSettingsSelectLayout.Enabled = fileOpen And My.Settings.UseDataGrid

		mnuSettingsSaveLayout.Visible = fileOpen And My.Settings.UseDataGrid
		mnuSettingsSaveLayout.Enabled = fileOpen And My.Settings.UseDataGrid

		mnuSettingsAutocompletion.Visible = fileOpen
		mnuSettingsAutocompletion.Enabled = fileOpen
		If fileOpen Then
			Dim tsi As ToolStripMenuItem
			mnuSettingsAutocompletion.DropDownItems.Clear()

			Select Case _File.FileType
				Case "BAPTISMS"
					tsi = mnuSettingsAutocompletion.DropDownItems.Add("Abodes")
					tsi.CheckOnClick = True
					tsi.Checked = acscAbodes.Count <> 0
					tsi.Enabled = acscAbodes.Count <> 0
					AddHandler tsi.CheckedChanged, AddressOf popItem_ShowAutoCompletionList

					tsi = mnuSettingsAutocompletion.DropDownItems.Add("Occupations")
					tsi.CheckOnClick = True
					tsi.Checked = acscOccupations.Count <> 0
					tsi.Enabled = acscOccupations.Count <> 0
					AddHandler tsi.CheckedChanged, AddressOf popItem_ShowAutoCompletionList

				Case "BURIALS"
					tsi = mnuSettingsAutocompletion.DropDownItems.Add("Abodes")
					tsi.CheckOnClick = True
					tsi.Checked = acscAbodes.Count <> 0
					tsi.Enabled = acscAbodes.Count <> 0
					AddHandler tsi.CheckedChanged, AddressOf popItem_ShowAutoCompletionList

				Case "MARRIAGES"
					tsi = mnuSettingsAutocompletion.DropDownItems.Add("Abodes")
					tsi.CheckOnClick = True
					tsi.Checked = acscAbodes.Count <> 0
					tsi.Enabled = acscAbodes.Count <> 0
					AddHandler tsi.CheckedChanged, AddressOf popItem_ShowAutoCompletionList

					tsi = mnuSettingsAutocompletion.DropDownItems.Add("Occupations")
					tsi.CheckOnClick = True
					tsi.Checked = acscOccupations.Count <> 0
					tsi.Enabled = acscOccupations.Count <> 0
					AddHandler tsi.CheckedChanged, AddressOf popItem_ShowAutoCompletionList

			End Select

		End If
	End Sub

	Private Sub tsTools_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles tsTools.DropDownOpening
		If _OS.Version.Major >= 6 Then
			If winImageViewer Is Nothing Then
				mnuToolsImageViewer.Checked = False
			Else
				If winImageViewer.IsVisible Then
					mnuToolsImageViewer.Checked = True
				Else
					mnuToolsImageViewer.Checked = False
				End If
			End If
		Else
			If frmImageViewer Is Nothing Then
				mnuToolsImageViewer.Checked = False
			Else
				If frmImageViewer.IsDisposed Then
					mnuToolsImageViewer.Checked = False
				Else
					If frmImageViewer.Visible Then
						mnuToolsImageViewer.Checked = True
					Else
						mnuToolsImageViewer.Checked = False
					End If
				End If
			End If
		End If

		mnuToolsFiltering.Visible = _Options.boolFiltering
		mnuToolsFiltering.Enabled = fileOpen
		mnuToolsRecoverBackup.Enabled = Not fileOpen
		mnuToolsUseDataGrid.Checked = My.Settings.UseDataGrid
	End Sub

	Private Sub tsRecord_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles tsRecord.DropDownOpening
		mnuRecordAddNewRecord.Image = BindingNavigatorAddNewItem.Image
		mnuRecordAddNewRecord.Enabled = fileOpen
		mnuRecordDeleteRecord.Image = BindingNavigatorDeleteItem.Image
		mnuRecordDeleteRecord.Enabled = fileOpen
		mnuRecordDuplicateRecord.Image = BindingNavigatorDuplicateRecord.Image
		mnuRecordDuplicateRecord.Enabled = fileOpen And My.Settings.UseDataGrid
		mnuRecordInsertRecord.Enabled = fileOpen And My.Settings.UseDataGrid
	End Sub

	Private Sub tsHelp_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles tsHelp.DropDownOpening
		If File.Exists(Path.Combine(My.Application.Info.DirectoryPath, "ChangeHistory.rtf")) Then
			mnuHelpChangeHistory.Visible = True
			mnuHelpChangeHistory.Enabled = True
		ElseIf File.Exists(Path.Combine(My.Application.Info.DirectoryPath, "ChangeHistory.txt")) Then
			mnuHelpChangeHistory.Visible = True
			mnuHelpChangeHistory.Enabled = True
		Else
			mnuHelpChangeHistory.Visible = False
			mnuHelpChangeHistory.Enabled = False
		End If

		If File.Exists(Path.Combine(My.Application.Info.DirectoryPath, "ViewHelp.chm")) Then
			mnuHelpHowToUseTheHelpViewer.Visible = True
		End If

	End Sub

#End Region

#Region "Menu - File"

	Private Sub mnuFileNewDataFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileNewDataFile.Click
		'		If fileOpen Then CloseTranscriptionFile()

		Using dlg As New dlgNewTranscriptionFile

			dlg.cbRecordType.DataSource = tabRecordTypes
			dlg.cbRecordType.DisplayMember = "Description"
			dlg.cbRecordType.ValueMember = "Type"

			dlg.cbCounty.DataSource = tabChapmanCodes
			dlg.cbCounty.DisplayMember = "County"
			dlg.cbCounty.ValueMember = "Code"

			dlg.MyTranscripts = My.Settings.DataFolderName

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				If fileOpen Then CloseTranscriptionFile(CloseReason.None)

				_File = dlg._File
				_File.Pathname = String.Format("{0}\{1}", My.Settings.DataFolderName, _File.Filename)
				_File.Username = My.Settings.Name
				_File.Password = "password"
				_File.EmailAddress = My.Settings.EmailAddress
				_File.DateCreated = Format(Now(), "dd-MMM-yyyy")
				_File.DateLastUpdated = Format(Now(), "dd-MMM-yyyy")
				_File.CreditToName = String.Empty
				_File.CreditToAddress = String.Empty

				Text = String.Format("{0} - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
				If _User.IsAdministrator Then
					Dim str As String = String.Format("{0} (Administrator)", Text())
					Text = str
				End If

				mainDGV.Columns.Clear()
				mainDGV.Rows.Clear()
				mainDGV.AutoGenerateColumns = False
				SetDataGridViewHeadings(_File.FileType)
				bsDGV = New BindingSource
				AddHandler bsDGV.ListChanged, AddressOf bsDGV_ListChanged

				Select Case _File.FileType
					Case "BAPTISMS"
						bsDGV.DataSource = New BaptismsDataTable

					Case "BURIALS"
						bsDGV.DataSource = New BurialsDataTable

					Case "MARRIAGES"
						bsDGV.DataSource = New MarriagesDataTable
				End Select

				mainDGV.DataSource = bsDGV
				bnDGV.BindingSource = bsDGV
				mainDGV.AutoGenerateColumns = True

				BindingNavigatorMoveFirstItem.Enabled = True
				BindingNavigatorMoveLastItem.Enabled = True
				BindingNavigatorMoveNextItem.Enabled = True
				BindingNavigatorMovePreviousItem.Enabled = True
				BindingNavigatorAddNewItem.Enabled = True
				BindingNavigatorDeleteItem.Enabled = True
				My.Application.Log.WriteEntry(String.Format("{0} Creating file {1}", Date.Now(), _File.Filename), TraceEventType.Information)

				Select Case dlg.MyScreenLayout.Type
					Case ColumnLayoutType.DefaultLayout
						For index = 0 To mainDGV.Columns.Count() - 1
							mainDGV.Columns(index).DisplayIndex = index
							mainDGV.Columns(index).Visible = (index > 2)
						Next

					Case ColumnLayoutType.LastUsed
						'
						'	If we can, set the columns layout to the last stored configuration for the type of file
						'
						Try
							Dim strCollection As StringCollection = Nothing

							Select Case _File.FileType
								Case "BAPTISMS"
									strCollection = My.Settings.colLayoutBaptisms

								Case "BURIALS"
									strCollection = My.Settings.colLayoutBurials

								Case "MARRIAGES"
									strCollection = My.Settings.colLayoutMarriages

							End Select
							mainDGV.SetColumnLayout(strCollection)

						Catch ex As Exception
							My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst loading saved column configuration")
							MessageBox.Show(ex.ToString, "Exception whilst loading saved column configuration", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

						End Try

					Case ColumnLayoutType.File
						If dlg.MyScreenLayout.Path <> "" Then
							Dim sr As StreamReader = New StreamReader(dlg.MyScreenLayout.Path, True)
							If sr IsNot Nothing Then
								Dim a() As String
								Dim index As Integer

								Do While sr.Peek() >= 0
									a = sr.ReadLine().Split(","c)
									index = Integer.Parse(a(3))
									mainDGV.Columns(index).DisplayIndex = Integer.Parse(a(0))
									mainDGV.Columns(index).Width = Integer.Parse(a(1))
									mainDGV.Columns(index).Visible = Boolean.Parse(a(2))
								Loop
								sr.Close()
							End If
						End If

				End Select

				acscAbodes.Clear()
				acscOccupations.Clear()
				acscFiche.Clear()
				acscImage.Clear()

				fileOpen = True
				fileNew = True
				tsEdit.Visible = fileOpen And My.Settings.UseDataGrid
				BindingNavigatorCopyButton.Enabled = fileOpen And My.Settings.UseDataGrid
				BindingNavigatorCutButton.Enabled = fileOpen And My.Settings.UseDataGrid
				BindingNavigatorPasteButton.Enabled = fileOpen And My.Settings.UseDataGrid
				tsRecord.Visible = fileOpen
				ShowContentDisplay()
				mnuFileShowLDSColumns.Enabled = True
				mnuFileShowLDSColumns.Visible = True
				BindingNavigatorAddNewItem.PerformClick()
			End If

		End Using
	End Sub

	Private Sub mnuFileOpenDataFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileOpenDataFile.Click
		With ofdTranscript
			.InitialDirectory = My.Settings.DataFolderName
			If .ShowDialog() = Windows.Forms.DialogResult.OK Then

				'	Validate the format of the selected file name
				'	It should match the <county><place><type>[<suffix>] scheme
				Try
					ValidateFormatFilename(.FileName, KindOfFile.CommaSeparatedVariable)
					If fileOpen Then CloseTranscriptionFile(CloseReason.None)
					OpenTranscriptionFile(.FileName())

				Catch ex As FilenameFormatException
					MessageBox.Show(ex.Message, "Open Transcription File", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ex.Data("Topic"))
				End Try

			End If
		End With
	End Sub

	Enum KindOfFile
		CommaSeparatedVariable
		Spreadsheet
	End Enum

	Private Sub ValidateFormatFilename(ByVal fname As String, ByVal filetype As KindOfFile)
		Dim fn As String = UCase(Path.GetFileNameWithoutExtension(fname))
		Dim ext As String = UCase(Path.GetExtension(fname))
		If (filetype = KindOfFile.CommaSeparatedVariable AndAlso ext = ".CSV") Or (filetype = KindOfFile.Spreadsheet AndAlso (ext = ".XLS" OrElse ext = ".XSLX")) Then
			Dim county As String = Microsoft.VisualBasic.Left(fn, 3)
			Dim place As String = Mid(fn, 4, 3)
			Dim type As String = Mid(fn, 7, 2)
			Dim suffix As String
			If Len(fn) > 8 Then
				suffix = Microsoft.VisualBasic.Right(fn, Len(fn) - 8)
			Else
				suffix = String.Empty
			End If

			If tabChapmanCodes.Rows.Contains(county) Then
				If tabRecordTypes.Rows.Contains(type) Then
					If Not String.IsNullOrEmpty(suffix) Then
						If Not IsNumeric(suffix) Then
							Dim ex As New FilenameFormatException(String.Format(My.Resources.err0048, "The optional suffix is not numeric"))
							ex.Data.Add("Topic", ERR0048)
							Throw ex
						End If
					End If
				Else
					Dim ex As New FilenameFormatException(String.Format(My.Resources.err0048, "The type field is not valid"))
					ex.Data.Add("Topic", ERR0048)
					Throw ex
				End If
			Else
				Dim ex As New FilenameFormatException(String.Format(My.Resources.err0048, "The county part is not a valid Chapman County Code"))
				ex.Data.Add("Topic", ERR0048)
				Throw ex
			End If
		Else
			If filetype = KindOfFile.CommaSeparatedVariable Then
				Dim ex As New FilenameFormatException(My.Resources.err0046)
				ex.Data.Add("Topic", ERR0046)
				Throw ex
			Else
				Dim ex As New FilenameFormatException(My.Resources.err0047)
				ex.Data.Add("Topic", ERR0047)
				Throw ex
			End If
		End If
	End Sub

	Private Sub mnuFileCloseFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileCloseFile.Click
		If fileOpen Then CloseTranscriptionFile(CloseReason.None)
	End Sub

	Private Sub mnuFileSaveFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileSaveFile.Click, BindingNavigatorSaveFileButton.Click
		If fileChanged Then
			If SaveTranscriptionFile() Then
				fileChanged = False
				BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
			End If
		End If
	End Sub

	Private Sub mnuFileSaveFileAs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileSaveFileAs.Click
		With sfdTranscript
			Dim oldName As String = _File.Filename

			.Title = "Save a Copy of a Transcription File Under Another Name"
			.Filter = "Transcription files (*.csv)|*.csv|All files (*.*)|*.*"
			.FilterIndex = 1
			.DefaultExt = "CSV"
			.InitialDirectory = My.Settings.DataFolderName
			.FileName = _File.Filename

			If .ShowDialog() = Windows.Forms.DialogResult.OK Then
				Try
					ValidateFormatFilename(.FileName, KindOfFile.CommaSeparatedVariable)

					Dim fn As String = UCase(Path.GetFileNameWithoutExtension(.FileName))
					Dim ext As String = UCase(Path.GetExtension(.FileName))
					Dim county As String = Microsoft.VisualBasic.Left(fn, 3)

					'
					'	If we get to here, the validations have succeeded, so it's time to save the file
					'
					'	Each file has two name : the internal name and the external name. For the time being, both
					'	file names are the same. To perform the SaveAs operation, both names need to be changed in
					'	the _FILEHEADER structure. At the same time, the path and full names also need to be changed.
					'	Once these items have been changed, the SaveTranscriptionFile function can be called.
					'
					If county <> _File.CountyCode Then
						Dim row1 As ChapmanCodesRow = tabChapmanCodes.Rows.Find(county)
						If row1 IsNot Nothing Then
							For Each row As DataGridViewRow In mainDGV.Rows
								row.Cells("County").Value = county
							Next

							_File.County = row1.County
							_File.CountyCode = row1.Code
						End If
					End If

					_File.Filename = fn + ext
					_File.InternalFilename = fn + ext
					_File.Pathname = sfdTranscript.FileName
					If SaveTranscriptionFile() Then
						fileChanged = False
						My.Application.Log.WriteEntry(Date.Now() + String.Format(" Saved {0} as {1} ", oldName, _File.Filename), TraceEventType.Information)
					End If

				Catch ex As FilenameFormatException
					MessageBox.Show(ex.Message, "SaveAs Transcript File", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ex.Data("Topic"))
				End Try
			End If
		End With
	End Sub

	Private Sub mnuFileImportExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileImportExcel.Click
		With ofdExcel
			.InitialDirectory = My.Settings.DataFolderName
			If CanImportXLS AndAlso CanImportXLSX Then
				.Filter = "Microsoft Excel 97-2003 Worksheets (*.xls)|*.xls|Microsoft Excel Worksheets (*.xlsx)|*.xlsx"
			ElseIf CanImportXLS Then
				.Filter = "Microsoft Excel 97-2003 Worksheets (*.xls)|*.xls"
			ElseIf CanImportXLSX Then
				.Filter = "Microsoft Excel Worksheets (*.xlsx)|*.xlsx"
			Else
				.Filter = ""
			End If
			If .ShowDialog() = Windows.Forms.DialogResult.OK Then

				'	Validate the format of the selected file name
				'	It should match the <county><place><type>[<suffix>] scheme
				Try
					ValidateFormatFilename(.FileName, KindOfFile.Spreadsheet)

					If fileOpen Then CloseTranscriptionFile(CloseReason.None)
					ImportExcelXLS(ofdExcel.FileName)

				Catch ex As FilenameFormatException
					MessageBox.Show(ex.Message, "Import Spreadsheet File", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ex.Data("Topic"))
				End Try
			End If
		End With
	End Sub

	Private Sub mnuFileEditFileDetails_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileEditFileDetails.Click
		Using dlg As New dlgEditFileDetails() With {._place = _File.PlaceName, ._church = _File.ChurchName, ._creditname = _File.CreditToName, ._creditemail = _File.CreditToAddress, ._source = _File.FileSource, ._comments = _File.FileComments}

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				If _File.FileSource <> dlg._source Then
					_File.FileSource = dlg._source
					fileChanged = True
					BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
					If Not My.Settings.UseDataGrid Then panelWinREG2.lblSource.Text = dlg._source
				End If

				If _File.FileComments <> dlg._comments Then
					_File.FileComments = dlg._comments
					fileChanged = True
					BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
					If Not My.Settings.UseDataGrid Then panelWinREG2.lblComments.Text = dlg._comments
				End If

				If _File.CreditToName <> dlg._creditname Then
					_File.CreditToName = dlg._creditname
					fileChanged = True
					BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
					If Not My.Settings.UseDataGrid Then panelWinREG2.lblCreditName.Text = dlg._creditname
				End If

				If _File.CreditToAddress <> dlg._creditemail Then
					_File.CreditToAddress = dlg._creditemail
					fileChanged = True
					BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
					If Not My.Settings.UseDataGrid Then panelWinREG2.lblCreditEmailAddress.Text = dlg._creditemail
				End If

				'				Dim bs As BindingSource = bsDGV.DataSource
				Dim dt = bsDGV.DataSource
				If _File.ChurchName <> dlg._church Then
					_File.ChurchName = dlg._church

					For Each row In dt.rows
						row.Church = _File.ChurchName
					Next

					Text = String.Format("{0} - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
					If _User.IsAdministrator Then
						Dim str As String = String.Format("{0} (Administrator)", Text())
						Text = str
					End If

					fileChanged = True
					BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
					If Not My.Settings.UseDataGrid Then panelWinREG2.lblChurchName.Text = dlg._church
				End If

				If _File.PlaceName <> dlg._place Then
					_File.PlaceName = dlg._place

					For Each row In dt.rows
						row.Place = _File.PlaceName
					Next

					Text = String.Format("{0} - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
					If _User.IsAdministrator Then
						Dim str As String = String.Format("{0} (Administrator)", Text())
						Text = str
					End If

					fileChanged = True
					BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
					If Not My.Settings.UseDataGrid Then panelWinREG2.lblPlaceName.Text = dlg._place
				End If
			End If
		End Using
	End Sub

	Private Sub mnuFileRenameFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileRenameFile.Click
		Using dlg As New dlgEditFileName
			dlg.lblFileName.Text = _File.Filename

			Dim rc As DialogResult = dlg.ShowDialog()
			If rc = Windows.Forms.DialogResult.OK Then
				Dim newFileName As String
				If dlg.mtbFileName.Text.Length > 12 Then
					newFileName = dlg.mtbFileName.Text.Substring(0, 3) & dlg.mtbFileName.Text.Substring(3, 3) & dlg.mtbFileName.Text.Substring(6, 2) & dlg.mtbFileName.Text.Substring(8, dlg.mtbFileName.Text.Length - 12)
				Else
					newFileName = dlg.mtbFileName.Text.Substring(0, 3) & dlg.mtbFileName.Text.Substring(3, 3) & dlg.mtbFileName.Text.Substring(6, 2)
				End If
				newFileName = newFileName & ".CSV"
				If _File.Filename = newFileName Then
					MsgBox(String.Format("The new name {0} is the same as the existing name" + vbCrLf + " as {1}. Pick another name.", newFileName, _File.Filename), MsgBoxStyle.OkOnly, "File Rename")
				Else
					Try
						If dlg.chkChangeCounty.Checked Then
							Dim x As ChapmanCodesRow = dlg.cboCountyList.SelectedItem.Row
							_File.CountyCode = x.Code
							_File.County = x.County

							'							Dim bs As BindingSource = mainDGV.DataSource
							Dim dt = bsDGV.DataSource

							For Each row In dt.rows
								row.County = _File.CountyCode
							Next
							If Not My.Settings.UseDataGrid Then panelWinREG2.lblCounty.Text = _File.CountyCode
						End If

						Dim fi As FileInfo = My.Computer.FileSystem.GetFileInfo(_File.Pathname)
						'						My.Computer.FileSystem.RenameFile(_File.Pathname, newFileName)

						_File.Pathname = My.Computer.FileSystem.CombinePath(fi.DirectoryName, newFileName)
						_File.Filename = newFileName
						_File.InternalFilename = newFileName
						fileChanged = True
						Text = String.Format("{0} - {1} - {2} - {3}", _File.Filename, _File.FileType, _File.PlaceName, _File.ChurchName)
						If _User.IsAdministrator Then
							Dim str As String = String.Format("{0} (Administrator)", Text())
							Text = str
						End If

						BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged

						MessageBox.Show(String.Format(My.Resources.err0043, fi.FullName, _File.Filename), "File Rename", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0043)

					Catch ex As NotSupportedException
						MsgBox("A file or directory name in the path contains a colon (:) or is in an invalid format", MsgBoxStyle.OkOnly, "File Rename")
					Catch ex As PathTooLongException
						MsgBox("The path exceeds the system-defined maximum length", MsgBoxStyle.OkOnly, "File Rename")
					Catch ex As FileNotFoundException
						MsgBox(String.Format("The source file {0} is not valid or does not exist", _File.Pathname), MsgBoxStyle.OkOnly, "File Rename")
					Catch ex As ArgumentNullException
						MsgBox(ex.Message, MsgBoxStyle.OkOnly, "File Rename")
					Catch ex As ArgumentException
						MsgBox(ex.Message, MsgBoxStyle.OkOnly, "File Rename")
					Catch ex As UnauthorizedAccessException
						MsgBox("The user does not have the required permission", MsgBoxStyle.OkOnly, "File Rename")
					Catch ex As IOException
						MsgBox(String.Format("There is an existing file or directory with the same name" + vbCrLf + " as {0}. Pick another name.", newFileName), MsgBoxStyle.OkOnly, "File Rename")
					Catch ex As Exception
						Dim extra As String = ""
						If Not (ex.Data Is Nothing) Then
							If ex.Data.Count > 0 Then
								extra = vbCrLf & "Extra information" & vbCrLf
								Dim de As DictionaryEntry
								For Each de In ex.Data
									extra += String.Format("{0}:{1}{2}", de.Key, de.Value, vbCrLf)
								Next de
							End If
						End If
						MsgBox(ex.Message & extra)
					End Try
				End If
			End If
		End Using
	End Sub

	Private Sub mnuFileValidateFileData_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileValidateFileData.Click
		Using dlg As New dlgFileValidation

			If Not fileOpen Then
				MessageBox.Show(My.Resources.err0030, "Validate Records", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0030)
			Else
				dlg._File = _File
				dlg.dgv = mainDGV
				dlg.tabBaptismSex = tabBapSex
				dlg.tabBurialRelationships = tabBurialRelationship
				dlg.tabMarriageBrideConditions = tabBrideCondition
				dlg.tabMarriageGroomConditions = tabGroomCondition
				If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				End If
			End If

		End Using
	End Sub

	Private Sub mnuFileUnsortRecords_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileUnsortRecords.Click, BindingNavigatorUnsortFileButton.Click
		If Not badDates Is Nothing Then badDates.Clear()

		If My.Settings.UseDataGrid Then
			Try
				mainDGV.Cursor = Cursors.WaitCursor

				'Get the column whose header was clicked.
				Dim col As DataGridViewColumn = mainDGV.Columns("LoadOrder")

				'Decide the Sort order, based on whether this column has a sorting glyph set, indicating
				'that it was the last sorted column & also the sort direction.
				Dim sortOrder As Windows.Forms.SortOrder
				If (col.HeaderCell.SortGlyphDirection = Windows.Forms.SortOrder.Ascending) Then
					sortOrder = Windows.Forms.SortOrder.Descending
				Else
					sortOrder = Windows.Forms.SortOrder.Ascending
				End If

				Dim strCollection As StringCollection = mainDGV.CurrentColumnLayout()

				'Get the DataSource of the Grid, which is a BindingSource in this case.
				Dim bs As BindingSource = CType(mainDGV.DataSource, BindingSource)
				Dim table = CType(bs.DataSource, DataTable)

				'			table.Select(Nothing, col.DataPropertyName, DataViewRowState.CurrentRows)
				'			Exit Sub

				'Instantize a IComparer object that will compare two DataRows in the DataTable
				'based on the desired field, & the sortOrder.
				Dim comparer As New CustomSortColComparer(col.DataPropertyName, sortOrder)

				'Add all rows in the table to a list, WITHOUT removing them from the table.
				Dim rowList As New List(Of DataRow)
				For Each row In table.Rows
					rowList.Add(row)
				Next

				'Sort the rows, using the desired comparer.
				rowList.Sort(comparer)

				'Copy sorted rows to a new DataTable.
				Dim sortedTable As DataTable
				'Following two instructions amount to copying of the Schema of the original table to the
				'new table.
				sortedTable = table.Clone()
				sortedTable.Clear()

				sortedTable.BeginLoadData()
				For Each row In rowList
					'Note that importing rows preserves property settings of the row.
					'However, I have not checked whether this would also preserve the rows parent or child
					'relationships to rows in other tables.
					sortedTable.ImportRow(row)
				Next
				sortedTable.EndLoadData()

				'Set the new sorted table as the Grid's datasource.
				bs.DataSource = sortedTable

				'Set the glyph for the column, setting its sort mode to Progrmmatic is necessary,
				'or it raises an exception.
				'Use col.Name to index into the column collection, as the user might have reordered
				'the columns in the DGV, so a column's index in the DGV & the source DataTable might not be the same.
				mainDGV.Columns(col.Name).HeaderCell.SortGlyphDirection = sortOrder
				mainDGV.SetColumnLayout(strCollection)

				mnuFileUnsortRecords.Enabled = False
				mnuFileUnsortRecords.Visible = False
				BindingNavigatorUnsortFileButton.Enabled = False
			Finally
				mainDGV.Cursor = Cursors.Arrow
			End Try
		Else
			Dim colHeader As ColumnHeader = panelWinREG2.lvData.Columns("LoadOrder")
			panelWinREG2.lvData.ListViewItemSorter = New WinREG2_Panel.ListViewItemComparer(colHeader)

			mnuFileUnsortRecords.Enabled = False
			mnuFileUnsortRecords.Visible = False
			BindingNavigatorUnsortFileButton.Enabled = False
		End If
	End Sub

	Private Sub mnuFileShowLDSColumns_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileShowLDSColumns.Click
		If My.Settings.UseDataGrid Then
			mainDGV.Columns("Fiche").Visible = True
			mainDGV.Columns("Image").Visible = True
		Else
			panelWinREG2.lvData.Columns("LDSFiche").Width = -2
			panelWinREG2.lvData.Columns("LDSImage").Width = -2
		End If
		mnuFileShowLDSColumns.Enabled = False
		mnuFileShowLDSColumns.Visible = False
		ldsFile = True
		_File.ldsFile = True
	End Sub

	Private Sub mnuFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileExit.Click
		If fileOpen Then CloseTranscriptionFile(CloseReason.ApplicationExitCall)
		Application.Exit()
	End Sub

#End Region

#Region "Menu - Record"

	Private Sub mnuRecordInsertRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRecordInsertRecord.Click
		Dim tab = bsDGV.DataSource
		Dim row = tab.NewRow()
		row.County = _File.CountyCode
		row.Place = _File.PlaceName
		row.Church = _File.ChurchName

		If bsDGV.DataSource.Count > 0 Then
			Dim currentrow = bsDGV.Current.Row()

			If Not IsDBNull(currentrow.RegNo) Then
				If currentrow.RegNo <> String.Empty Then
					If IsNumeric(currentrow.RegNo) Then
						row.RegNo = currentrow.RegNo + 1
					Else
						row.RegNo = currentrow.RegNo
					End If
				Else
					row.RegNo = String.Empty
				End If
			Else
				row.RegNo = String.Empty
			End If

			row.LDSFiche = currentrow.LDSFiche
			row.LDSImage = currentrow.LDSImage

			If My.Settings.AutoCopyDates Then
				If TypeOf bsDGV.DataSource Is BaptismsDataTable Then
					row.BirthDate = currentrow.BirthDate
					row.BaptismDate = currentrow.BaptismDate
				ElseIf TypeOf bsDGV.DataSource Is BurialsDataTable Then
					row.BurialDate = currentrow.BurialDate
				ElseIf TypeOf bsDGV.DataSource Is MarriagesDataTable Then
					row.MarriageDate = currentrow.MarriageDate
				End If
			End If
		Else
			row.RegNo = String.Empty
			row.LDSFiche = String.Empty
			row.LDSImage = String.Empty
			If TypeOf bsDGV.DataSource Is BaptismsDataTable Then
				row.BirthDate = String.Empty
				row.BaptismDate = String.Empty
			ElseIf TypeOf bsDGV.DataSource Is BurialsDataTable Then
				row.BurialDate = String.Empty
			ElseIf TypeOf bsDGV.DataSource Is MarriagesDataTable Then
				row.MarriageDate = String.Empty
			End If
		End If

		tab.Rows.InsertAt(row, bsDGV.Position + 1)
		fileChanged = True
		bsDGV.EndEdit()
	End Sub

#End Region

#Region "Menu - Edit"

	Private Sub mnuEditUndo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuEditUndo.Click
		mainDGV.UnDo()
	End Sub

#End Region

#Region "Menu - Settings"

	Private Sub mnuSettingsOptionsUserProgramOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsOptionsUserProgramOptions.Click
		Using dlg As New dlgOptions

			dlg.cbSyndicate.DataSource = tabChapmanCodes
			dlg.cbSyndicate.DisplayMember = "County"
			dlg.cbSyndicate.ValueMember = "Code"
			dlg.cbSyndicate.Text = My.Settings.Syndicate

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				My.Settings.Syndicate = dlg.cbSyndicate.Text
				ttMain.Active = My.Settings.MyDisplayTooltips
				If My.Settings.MyDisplayTooltips Then ttMain.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
				panelWinREG2.enableToolTip = My.Settings.MyDisplayTooltips
				ssMain.ShowItemToolTips = My.Settings.MyDisplayTooltips

				mainDGV.DefaultCellStyle.Font = My.Settings.MyCellFont
				mainDGV.DefaultCellStyle.BackColor = My.Settings.MyCellColour
				mainDGV.AlternatingRowsDefaultCellStyle.BackColor = My.Settings.MyAlternateCellColour
			End If
		End Using
	End Sub

	Private Sub mnuSettingsColumnVisibility_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsColumnVisibility.Click
		If fileOpen Then
			Using dlg As New dlgColumnVisibility() With {.dgv = mainDGV}
				dlg.ShowDialog()
				dlg.Close()
			End Using
		End If

	End Sub

	Private Sub mnuSettingsOptionsRecordTypesTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsOptionsRecordTypesTable.Click
		Using dlg As New dlgLookupTables() With {.Text = "Record Types"}
			dlg.bnTables.BindingSource = dlg.bsTables
			dlg.bsTables.DataSource = tabRecordTypes
			dlg.dgvTables.Columns.Clear()
			dlg.dgvTables.DataSource = dlg.bsTables
			dlg.dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			dlg.dgvTables.Columns("Description").SortMode = DataGridViewColumnSortMode.NotSortable
			dlg.dgvTables.AllowUserToDeleteRows = False

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				boolTablesChanged = boolTablesChanged Or dlg.boolTablesChanged
			End If
		End Using
	End Sub

	Private Sub mnuSettingsOptionsChapmanCodesTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsOptionsChapmanCodesTable.Click
		Using dlg As New dlgLookupTables() With {.Text = "Chapman Codes"}
			dlg.bnTables.BindingSource = dlg.bsTables
			dlg.bsTables.DataSource = tabChapmanCodes
			dlg.dgvTables.Columns.Clear()
			dlg.dgvTables.DataSource = dlg.bsTables
			dlg.dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			dlg.dgvTables.Columns("County").SortMode = DataGridViewColumnSortMode.NotSortable
			dlg.dgvTables.AllowUserToDeleteRows = False

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				boolTablesChanged = boolTablesChanged Or dlg.boolTablesChanged
			End If
		End Using
	End Sub

	Private Sub mnuSettingsOptionsBaptismSexTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsOptionsBaptismSexTable.Click
		Using dlg As New dlgLookupTables() With {.Text = "Baptism Sex"}
			dlg.bnTables.BindingSource = dlg.bsTables
			dlg.bsTables.DataSource = tabBapSex
			dlg.dgvTables.Columns.Clear()
			dlg.dgvTables.DataSource = dlg.bsTables
			dlg.dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			dlg.dgvTables.Columns("Type").Visible = False
			dlg.dgvTables.Columns("Description").SortMode = DataGridViewColumnSortMode.NotSortable
			dlg.dgvTables.AllowUserToDeleteRows = False

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				boolTablesChanged = boolTablesChanged Or dlg.boolTablesChanged
			End If
		End Using
	End Sub

	Private Sub mnuSettingsOptionsBurialRelationshipsTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsOptionsBurialRelationshipsTable.Click
		Using dlg As New dlgLookupTables() With {.Text = "Burial Relationships"}
			dlg.bnTables.BindingSource = dlg.bsTables
			dlg.bsTables.DataSource = tabBurialRelationship
			dlg.dgvTables.Columns.Clear()
			dlg.dgvTables.DataSource = dlg.bsTables
			dlg.dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			dlg.dgvTables.Columns("Type").Visible = False
			dlg.dgvTables.Columns("DisplayValue").SortMode = DataGridViewColumnSortMode.NotSortable
			dlg.dgvTables.AllowUserToDeleteRows = False

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				boolTablesChanged = boolTablesChanged Or dlg.boolTablesChanged
			End If
		End Using
	End Sub

	Private Sub mnuSettingsOptionsGroomMarriageStates_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsOptionsGroomMarriageStates.Click
		Using dlg As New dlgLookupTables() With {.Text = "Groom Marriage States"}
			dlg.bnTables.BindingSource = dlg.bsTables
			dlg.bsTables.DataSource = tabGroomCondition
			dlg.dgvTables.Columns.Clear()
			dlg.dgvTables.DataSource = dlg.bsTables
			dlg.dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			dlg.dgvTables.Columns("Type").Visible = False
			dlg.dgvTables.Columns("DisplayValue").SortMode = DataGridViewColumnSortMode.NotSortable
			dlg.dgvTables.AllowUserToDeleteRows = False

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				boolTablesChanged = boolTablesChanged Or dlg.boolTablesChanged
			End If
		End Using
	End Sub

	Private Sub mnuSettingsOptionsBrideMarriageStates_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsOptionsBrideMarriageStates.Click
		Using dlg As New dlgLookupTables() With {.Text = "Bride Marriage States"}
			dlg.bnTables.BindingSource = dlg.bsTables
			dlg.bsTables.DataSource = tabBrideCondition
			dlg.dgvTables.Columns.Clear()
			dlg.dgvTables.DataSource = dlg.bsTables
			dlg.dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			dlg.dgvTables.Columns("Type").Visible = False
			dlg.dgvTables.Columns("DisplayValue").SortMode = DataGridViewColumnSortMode.NotSortable
			dlg.dgvTables.AllowUserToDeleteRows = False

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				boolTablesChanged = boolTablesChanged Or dlg.boolTablesChanged
			End If
		End Using
	End Sub

	Private Sub mnuSettingsUserSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsUserSettings.Click
		Using dlg As New dlgUserSettings
			dlg.ShowDialog()
		End Using
	End Sub

	Private Sub mnuSettingsSelectLayout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsSelectLayout.Click
		Dim dir = _BaseDataDirectory + "\Screen Layouts"

		If fileOpen Then
			With ofdColumnLayout
				.InitialDirectory = dir
				.Filter = "All files (*.*)|*.*"
				For Each row As RecordTypesRow In tabRecordTypes.Rows
					If String.Compare(row.Description, _File.FileType, True) = 0 Then
						.Filter = String.Format("Column Layouts for {0}|*.{1}", _File.FileType, row.Type)
						.DefaultExt = row.Type
						Exit For
					End If
				Next
				.FilterIndex = 1

				If .ShowDialog() = Windows.Forms.DialogResult.OK Then
					If .FileName <> "" Then
						Dim sr As StreamReader = New StreamReader(.FileName, True)
						If sr IsNot Nothing Then
							Dim a() As String

							Do While sr.Peek() >= 0
								a = sr.ReadLine().Split(","c)
								Dim colName As String = a(4)
								Dim colIndex As Integer = Integer.Parse(a(3))
								Dim colVisible As Boolean = Boolean.Parse(a(2))
								Dim colWidth As Integer = Integer.Parse(a(1))
								Dim colDisplayIndex As Integer = Integer.Parse(a(0))
								mainDGV.Columns(colIndex).DisplayIndex = colDisplayIndex
								mainDGV.Columns(colIndex).Width = colWidth
								mainDGV.Columns(colIndex).Visible = colVisible
							Loop
							sr.Close()
						End If
					End If
				End If

			End With
		End If
	End Sub

	Private Sub mnuSettingsSaveLayout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuSettingsSaveLayout.Click
		Dim dir = _BaseDataDirectory + "\Screen Layouts"

		If fileOpen Then
			With sfdColumnLayout
				.InitialDirectory = dir
				.Filter = "All files (*.*)|*.*"
				For Each row As RecordTypesRow In tabRecordTypes.Rows
					If String.Compare(row.Description, _File.FileType, True) = 0 Then
						.Filter = String.Format("Column Layouts for {0}|*.{1}", _File.FileType, row.Type)
						.DefaultExt = row.Type
						Exit For
					End If
				Next
				.FilterIndex = 1

				If .ShowDialog() = Windows.Forms.DialogResult.OK Then
					If .FileName <> "" Then
						Using sw As StreamWriter = New StreamWriter(.FileName, False, _Encoding)
							If sw IsNot Nothing Then
								For Each column As DataGridViewColumn In mainDGV.Columns
									sw.WriteLine(String.Format("{0},{1},{2},{3},{4}", column.DisplayIndex.ToString("D2"), column.Width, column.Visible, column.Index, column.Name))
								Next
								sw.Close()
							End If
						End Using
					End If
				End If

			End With
		End If
	End Sub

#End Region

#Region "Menu - Tools"

	Private Sub mnuToolsUseDataGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsUseDataGrid.CheckedChanged
		If fileOpen Then
			SwitchFileView(mnuToolsUseDataGrid.Checked)
		Else
			My.Settings.UseDataGrid = mnuToolsUseDataGrid.Checked
		End If
	End Sub

	Private Sub mnuToolsImageViewer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuToolsImageViewer.Click
		If _OS.Version.Major >= 6 Then
			If winImageViewer Is Nothing Then
				winImageViewer = New ImageViewer
				ElementHost.EnableModelessKeyboardInterop(winImageViewer)
				Dim helper As WindowInteropHelper = New WindowInteropHelper(winImageViewer)
				helper.Owner = Me.Handle
				winImageViewer.Height = My.Settings.MyImageViewerSize.Height
				winImageViewer.Width = My.Settings.MyImageViewerSize.Width
				winImageViewer.Top = My.Settings.MyImageViewerLocation.Y
				winImageViewer.Left = My.Settings.MyImageViewerLocation.X
				winImageViewer.WindowState = My.Settings.MyImageViewerWindowState

				winImageViewer.FileViewGrid.Columns(0).Width = My.Settings.MyColumnWidth1
				winImageViewer.FileViewGrid.Columns(1).Width = My.Settings.MyColumnWidth2
				winImageViewer.FileViewGrid.Columns(2).Width = My.Settings.MyColumnWidth3

				winImageViewer.Show()
				'				winImageViewer.GridSplitter1.Width = My.Settings.MyImageViewerSplitterDistance
			Else
				If winImageViewer.IsVisible Then
					winImageViewer.Hide()
				Else
					winImageViewer.Show()
				End If
			End If
		Else
			If frmImageViewer Is Nothing Then
				frmImageViewer = New frmImageViewer
				frmImageViewer.Show()
			Else
				If frmImageViewer.IsDisposed Then
					frmImageViewer = New frmImageViewer
					frmImageViewer.Show()
				Else
					If frmImageViewer.Visible Then
						frmImageViewer.Hide()
					Else
						frmImageViewer.Show()
					End If
				End If
			End If
		End If
	End Sub

	Private Sub mnuToolsFreeREGServerGateway_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuToolsFreeREGServerGateway.Click
		If FreeRegbrowser Is Nothing Then
		Else
			If FreeRegbrowser.IsDisposed Then
				AddHandler ErrorFileObj.ErrorFileCreated, AddressOf BindingNavigatorViewErrorsButton_EventHandler
				FreeRegbrowser = New FreeRegBrowser(ErrorFileObj, My.Settings.DataFolderName, My.Settings.MyUserName, My.Settings.MyUserPassword)
				FreeRegbrowser.Show()
			Else
				If FreeRegbrowser.Visible = False Then
					FreeRegbrowser.TranscriptsPath = My.Settings.DataFolderName
					FreeRegbrowser.Show()
				End If
			End If
		End If
	End Sub

	Private Sub mnuToolsRecoverBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsRecoverBackup.Click
		Using dlg As New dlgRecoverFromBackup
			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				If File.Exists(dlg.tf.FileName.FullName) AndAlso File.Exists(dlg.btf.FileName.FullName) Then
					If MessageBox.Show(String.Format("Are you absolutely sure that you want to overwrite {1} with {0}?", dlg.btf.FileName.Name, dlg.tf.FileName.Name), "Recover From Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
						Try
							File.Copy(dlg.btf.FileName.FullName, dlg.tf.FileName.FullName, True)

						Catch ex As Exception
							MessageBox.Show(ex.ToString, "Recover From Backup", MessageBoxButtons.OK, MessageBoxIcon.Error)
						End Try
					End If
				Else
					MessageBox.Show(String.Format("Bad copy operation. {0} to {1}", dlg.btf.FileName.FullName, dlg.tf.FileName.FullName), "Recover From Backup", MessageBoxButtons.OK, MessageBoxIcon.Error)
				End If
			End If
		End Using
	End Sub

	Private Sub mnuToolsBackupRestore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuToolsBackupRestore.Click
		Using dlg As New dlgBackupRestore
			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
			End If
		End Using
	End Sub

	Private Sub mnuToolsFiltering_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsFiltering.CheckedChanged
		If mnuToolsFiltering.CheckState = CheckState.Checked Then
			tsFilters.Visible = True
		Else
			tsFilters.Visible = False
		End If
	End Sub

	Private Sub mnuToolsRebuildLookUpTables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsRebuildLookUpTables.Click
		Dim fiDefault As FileInfo = New FileInfo(String.Format("{0}\{1}", _BaseDataDirectory, My.Resources.nameTablesFile))
		Dim fiUser As FileInfo = New FileInfo(String.Format("{0}\{1}", _BaseDataDirectory, My.Resources.nameUserTablesFile))

		If fiDefault.Exists Then fiDefault.Delete()
		If fiUser.Exists Then fiUser.Delete()
		LookUpsDataSet.Dispose()
		LookUpsDataSet = Nothing
		LookUpsDataSet = New LookupTables()
		LoadLookupTables()

		MessageBox.Show(My.Resources.infLookUpTablesCreated, "Recreate LookUp Tables", MessageBoxButtons.OK, MessageBoxIcon.Information)
	End Sub

	Private Sub CrashToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuMyToolsCrashProgram.Click
		'		RecoveryProcedure("/restart")

		'		Thread.CurrentThread.Abort()
		Environment.FailFast("WinREG intentional crash.")
	End Sub

	Private Sub mnuMyToolsException_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMyToolsException.Click
		Throw New System.Exception("Die!")
	End Sub

#End Region

#Region "Menu - Help"

	Private Sub mnuHelpContents_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpContents.Click
		Help.ShowHelp(Me, My.Settings.HelpFileName, HelpNavigator.TableOfContents)
	End Sub

	Private Sub mnuHelpIndex_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpIndex.Click
		Help.ShowHelpIndex(Me, My.Settings.HelpFileName)
	End Sub

	Private Sub mnuHelpSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpSearch.Click
		Help.ShowHelp(Me, My.Settings.HelpFileName, HelpNavigator.Find, "")
	End Sub

	Private Sub mnuHelpHowToUseTheHelpViewer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpHowToUseTheHelpViewer.Click
		Help.ShowHelp(Me, "ViewHelp.chm", HelpNavigator.TableOfContents)
	End Sub

	Private Sub mnuHelpTheWinREGBlog_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpTheWinREGBlog.Click
		Try
			LaunchDefaultBrowser("http://winreg.wordpress.com/about")

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst Viewing the Blog")

		End Try
	End Sub

	Private Sub mnuHelpVisitFreeREG_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpVisitFreeREG.Click
		Try
			LaunchDefaultBrowser("http://www.freeREG.org.uk")

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst Visting FreeRG")

		End Try
	End Sub

	Private Sub mnuHelpTranscriberInformation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpTranscriberInformation.Click
		Try
			LaunchDefaultBrowser("http://www.freereg.org.uk/transcribers.shtml")

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst Viewing Transcriber Information")

		End Try
	End Sub

	Private Sub mnuHelpEmailBugReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpEmailBugReport.Click
		Dim cmdString As New StringBuilder

		Try
			cmdString.Append("mailto:mikefry@iafrica.com")
			cmdString.Append("?cc=freereg.edickens@gmail.com")
			cmdString.AppendFormat("&subject=WinREG [Version {0}.{1:00}.{2}] Bug Report", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
			cmdString.AppendFormat("&body={0} ({1}) {2}%0D%0A%0D%0A", My.Computer.Info.OSFullName(), My.Computer.Info.OSPlatform(), My.Computer.Info.OSVersion())
			System.Diagnostics.Process.Start(cmdString.ToString)

		Catch ex As Exception
			MessageBox.Show(ex.Message, "Sending Email", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			My.Application.Log.WriteException(ex, TraceEventType.Critical, "Application shut down at " + Date.Now())
		End Try
	End Sub

	Private Sub mnuHelpVisitFreeREGForum_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpVisitFreeREGForum.Click
		Try
			LaunchDefaultBrowser("http://www.british-genealogy.com/forums/forumdisplay.php?f=351")

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst visiting the FreeREG Forum")

		End Try
	End Sub

	Private Sub mnuHelpProgramDefaults_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpSetProgramDefaults.Click
		If _OS.Version.Major >= 6 Then
			Dim aar = New ApplicationAssociationRegistration()
			Dim iaar = DirectCast(aar, IApplicationAssociationRegistration)
			Dim ext As String = ".csv", s As String = "WinREG for Windows", s1 As String = Nothing
			Try
				Dim b As Boolean
				iaar.QueryAppIsDefault(ext, AssociationType.FileExtension, AssociationLevel.Effective, s, b)
				If Not b Then
					Dim r As DialogResult = MessageBox.Show(My.Resources.msgAssociateWithCsvFiles, "Set Program Defaults", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0002)
					If r = Windows.Forms.DialogResult.Yes Then
						iaar.QueryCurrentDefault(ext, AssociationType.FileExtension, AssociationLevel.Effective, s1)
						'Dim aarui = New ApplicationAssociationRegistrationUI()
						'Dim iaarui = DirectCast(aarui, IApplicationAssociationRegistrationUI)
						'Try
						'	iaarui.LaunchAdvancedAssociationUI(s)

						'Catch ex As Exception
						'	MessageBox.Show(ex.Message, "Set Program Defaults", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
						'End Try
						iaar.SetAppAsDefault(s, ext, AssociationType.FileExtension)
					Else
					End If
				Else
					Dim r As DialogResult = MessageBox.Show(My.Resources.msgAlreadyDefaultProgram, "Set Program Defaults", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0001)
					If r = Windows.Forms.DialogResult.Yes Then
						'iaar.QueryCurrentDefault(ext, AssociationType.FileExtension, AssociationLevel.Effective, s1)
						'Dim aarui = New ApplicationAssociationRegistrationUI()
						'Dim iaarui = DirectCast(aarui, IApplicationAssociationRegistrationUI)
						'Try
						'	iaarui.LaunchAdvancedAssociationUI(s)

						'Catch ex As Exception
						'	MessageBox.Show(ex.Message, "Set Program Defaults", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
						'End Try
						iaar.ClearUserAssociations()
					Else
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Set Program Defaults", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			End Try
		Else
			'			MessageBox.Show("Running on XP or earlier", "Set program Defaults", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
		End If
	End Sub

	Private Sub mnuHelpConfigureUpdates_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpConfigureUpdates.Click
		Dim Process As Process = Process.Start(strUpdaterPath, "/configure")
		Process.Close()
	End Sub

	Private Sub mnuHelpCheckForUpdates_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpCheckForUpdates.Click
		Dim Process As Process = Process.Start(strUpdaterPath, "/checknow")
		Process.Close()
	End Sub

	Private Sub mnuHelpViewLogFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpViewLogFile.Click
		Dim filename As String = My.Application.Log.DefaultFileLogWriter.FullLogFileName()
		Dim fs As FileStream = Nothing
		Dim sr As StreamReader = Nothing

		Using dlg As New dlgViewLogFile
			Try
				fs = New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
				sr = New StreamReader(fs)
				Dim str As String
				dlg.txtLogFile.Clear()
				Do
					str = sr.ReadLine()
					dlg.txtLogFile.Text += str + Environment.NewLine
				Loop Until str Is Nothing

				dlg.Text += " - " & Path.GetFileName(filename)
				dlg.ShowDialog()

			Catch ex As Exception
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

			Finally
				If sr IsNot Nothing Then sr.Close()
				If fs IsNot Nothing Then fs.Close()
			End Try
		End Using
	End Sub

	Private Sub mnuHelpChangeHistory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpChangeHistory.Click
		Dim filename As String = Path.Combine(My.Application.Info.DirectoryPath, "ChangeHistory.rtf")

		Using dlg As New dlgChangeHistory
			If File.Exists(filename) Then
				dlg.rtfChangeHistory.Clear()
				dlg.rtfChangeHistory.LoadFile(filename, RichTextBoxStreamType.RichText)
				dlg.Text += " - " & Path.GetFileName(filename)
				dlg.ShowDialog()
			Else
				filename = Path.Combine(My.Application.Info.DirectoryPath, "ChangeHistory.txt")
				If File.Exists(filename) Then
					dlg.rtfChangeHistory.Clear()
					dlg.rtfChangeHistory.LoadFile(filename, RichTextBoxStreamType.PlainText)
					dlg.Text += " - " & Path.GetFileName(filename)
					dlg.ShowDialog()
				End If
			End If
		End Using
	End Sub

	Private Sub mnuHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelpAbout.Click
		AboutBox.ShowDialog()
	End Sub

#End Region

#Region "Binding Navigator"

	Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
		Try
			If My.Settings.UseDataGrid Then
				mainDGV.Rows(bsDGV.Position).Selected = False
				bsDGV.MoveFirst()
				mainDGV.FirstDisplayedScrollingRowIndex = bsDGV.Position
				mainDGV.Rows(bsDGV.Position).Selected = True
				mainDGV.CurrentCell = mainDGV.Rows(bsDGV.Position).Cells(mainDGV.FirstDisplayedCell.ColumnIndex)
			Else
				panelWinREG2.lvData.Items(bsDGV.Position).Selected = False
				bsDGV.MoveFirst()
				panelWinREG2.lvData.Items(bsDGV.Position).Selected = True
				panelWinREG2.lvData.Items(bsDGV.Position).EnsureVisible()
			End If

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in BindingNavigatorMoveFirstItem")
			MessageBox.Show(ex.StackTrace, "BindingNavigatorMoveFirstItem - " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
		Try
			If My.Settings.UseDataGrid Then
				mainDGV.Rows(bsDGV.Position).Selected = False
				bsDGV.MoveLast()
				mainDGV.FirstDisplayedScrollingRowIndex = bsDGV.Position
				mainDGV.Rows(bsDGV.Position).Selected = True
				mainDGV.CurrentCell = mainDGV.Rows(bsDGV.Position).Cells(mainDGV.FirstDisplayedCell.ColumnIndex)
			Else
				panelWinREG2.lvData.Items(bsDGV.Position).Selected = False
				bsDGV.MoveLast()
				panelWinREG2.lvData.Items(bsDGV.Position).Selected = True
				panelWinREG2.lvData.Items(bsDGV.Position).EnsureVisible()
			End If

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in BindingNavigatorMoveLastItem")
			MessageBox.Show(ex.StackTrace, "BindingNavigatorMoveLastItem - " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub BindingNavigatorMoveNextItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
		Try
			If My.Settings.UseDataGrid Then
				mainDGV.Rows(bsDGV.Position).Selected = False
				bsDGV.MoveNext()
				mainDGV.Rows(bsDGV.Position).Selected = True
				mainDGV.CurrentCell = mainDGV.Rows(bsDGV.Position).Cells(mainDGV.FirstDisplayedCell.ColumnIndex)
			Else
				panelWinREG2.lvData.Items(bsDGV.Position).Selected = False
				bsDGV.MoveNext()
				panelWinREG2.lvData.Items(bsDGV.Position).Selected = True
				panelWinREG2.lvData.Items(bsDGV.Position).EnsureVisible()
			End If

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in BindingNavigatorMoveNextItem")
			MessageBox.Show(ex.StackTrace, "BindingNavigatorMoveNextItem - " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
		Try
			If My.Settings.UseDataGrid Then
				mainDGV.Rows(bsDGV.Position).Selected = False
				bsDGV.MovePrevious()
				mainDGV.Rows(bsDGV.Position).Selected = True
				mainDGV.CurrentCell = mainDGV.Rows(bsDGV.Position).Cells(mainDGV.FirstDisplayedCell.ColumnIndex)
			Else
				panelWinREG2.lvData.Items(bsDGV.Position).Selected = False
				bsDGV.MovePrevious()
				panelWinREG2.lvData.Items(bsDGV.Position).Selected = True
				panelWinREG2.lvData.Items(bsDGV.Position).EnsureVisible()
			End If

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in BindingNavigatorMovePreviousItem")
			MessageBox.Show(ex.StackTrace, "BindingNavigatorMovePreviousItem - " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuRecordAddNewRecord.Click, BindingNavigatorAddNewItem.Click

		Dim row = bsDGV.DataSource.NewRow()
		row.County = _File.CountyCode
		row.Place = _File.PlaceName
		row.Church = _File.ChurchName

		If bsDGV.DataSource.Count > 0 Then
			Dim lastrow = bsDGV.DataSource.rows(bsDGV.DataSource.Count - 1)

			If Not IsDBNull(lastrow.RegNo) Then
				If lastrow.RegNo <> String.Empty Then
					If IsNumeric(lastrow.RegNo) Then
						row.RegNo = lastrow.RegNo + 1
					Else
						row.RegNo = lastrow.RegNo
					End If
				Else
					row.RegNo = String.Empty
				End If
			Else
				row.RegNo = String.Empty
			End If

			row.LDSFiche = lastrow.LDSFiche
			row.LDSImage = lastrow.LDSImage

			If My.Settings.AutoCopyDates Then
				If TypeOf bsDGV.DataSource Is BaptismsDataTable Then
					row.BirthDate = lastrow.BirthDate
					row.BaptismDate = lastrow.BaptismDate
				ElseIf TypeOf bsDGV.DataSource Is BurialsDataTable Then
					row.BurialDate = lastrow.BurialDate
				ElseIf TypeOf bsDGV.DataSource Is MarriagesDataTable Then
					row.MarriageDate = lastrow.MarriageDate
				End If
			End If
		Else
			row.RegNo = String.Empty
			row.LDSFiche = String.Empty
			row.LDSImage = String.Empty
			If TypeOf bsDGV.DataSource Is BaptismsDataTable Then
				row.BirthDate = String.Empty
				row.BaptismDate = String.Empty
			ElseIf TypeOf bsDGV.DataSource Is BurialsDataTable Then
				row.BurialDate = String.Empty
			ElseIf TypeOf bsDGV.DataSource Is MarriagesDataTable Then
				row.MarriageDate = String.Empty
			End If
		End If

		If TypeOf bsDGV.DataSource Is BaptismsDataTable Then
			bsDGV.DataSource.AddBaptismsRow(row)
		ElseIf TypeOf bsDGV.DataSource Is BurialsDataTable Then
			bsDGV.DataSource.AddBurialsRow(row)
		ElseIf TypeOf bsDGV.DataSource Is MarriagesDataTable Then
			bsDGV.DataSource.AddMarriagesRow(row)
		End If

		fileChanged = True
		bsDGV.EndEdit()

		If Not My.Settings.UseDataGrid Then
			With panelWinREG2
				.lblRecordCount.Text = bsDGV.List.Count
			End With
		End If
	End Sub

	Private Sub BindingNavigatorDuplicateRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuRecordDuplicateRecord.Click, BindingNavigatorDuplicateRecord.Click
		DuplicateRecord(mainDGV.CurrentRow())
	End Sub

	Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuRecordDeleteRecord.Click, BindingNavigatorDeleteItem.Click
		If _OS.Version.Major >= 6 Then
			If Not winImageViewer Is Nothing Then
				If winImageViewer.IsVisible Then
					winImageViewer.Hide()
				End If
			End If
		Else
			If Not frmImageViewer Is Nothing Then
				If Not frmImageViewer.IsDisposed Then
					If frmImageViewer.Visible Then frmImageViewer.Hide()
				End If
			End If
		End If
		If My.Settings.UseDataGrid Then
			If mainDGV.SelectedRows.Count > 0 Then
				Do Until mainDGV.SelectedRows.Count = 0
					Dim index = mainDGV.SelectedRows(0).Index
					If mainDGV.Rows(index).IsNewRow Then
						MessageBox.Show(My.Resources.err0036, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0036)
					Else
						If MessageBox.Show(My.Resources.msgDeleteRow, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0005) = Windows.Forms.DialogResult.Yes Then
							bsDGV.RemoveAt(index)
							bsDGV.EndEdit()
							CType(bsDGV.DataSource, DataTable).WriteXml(RecoveryTable, False)
							fileChanged = True
							BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
							'							Exit Do
						End If
					End If
					index += 1
				Loop

				For dr As Integer = 0 To mainDGV.Rows.Count - 1
					mainDGV.Rows(dr).HeaderCell.ValueType = System.Type.GetType("System.String")
					mainDGV.Rows(dr).HeaderCell.Value = (dr + 1).ToString()
				Next

			Else
				If mainDGV.SelectedCells.Count > 0 Then
					For Each cell As DataGridViewCell In mainDGV.SelectedCells()
						If cell.RowIndex <> -1 Then
							If mainDGV.Rows(cell.RowIndex).IsNewRow Then
								MessageBox.Show(My.Resources.err0036, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0036)
							Else
								If MessageBox.Show(My.Resources.msgDeleteRow, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0005) = Windows.Forms.DialogResult.Yes Then
									bsDGV.RemoveAt(cell.RowIndex)
									bsDGV.EndEdit()
									CType(bsDGV.DataSource, DataTable).WriteXml(RecoveryTable, False)
									fileChanged = True
									BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
								End If
							End If
						End If
					Next

					For dr As Integer = 0 To mainDGV.Rows.Count - 1
						mainDGV.Rows(dr).HeaderCell.ValueType = System.Type.GetType("System.String")
						mainDGV.Rows(dr).HeaderCell.Value = (dr + 1).ToString()
					Next

				End If
			End If
		Else
			With panelWinREG2
				If ._ItemActivated Then
					If MessageBox.Show(My.Resources.msgDeleteRow, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
						bsDGV.RemoveAt(._ActivatedListItem)
						bsDGV.EndEdit()
						CType(bsDGV.DataSource, DataTable).WriteXml(RecoveryTable, False)
						.ClearPanel()
						.lblRecordCount.Text = bsDGV.List.Count
						fileChanged = True
						BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
					End If
				End If
			End With
		End If
		If _OS.Version.Major >= 6 Then
			If Not winImageViewer Is Nothing Then
				If Not winImageViewer.IsVisible Then
					winImageViewer.Show()
				End If
			End If
		Else
			If Not frmImageViewer Is Nothing Then
				If Not frmImageViewer.IsDisposed Then
					If Not frmImageViewer.Visible Then frmImageViewer.Show()
				End If
			End If
		End If
	End Sub

	Private Sub BindingNavigatorCutButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BindingNavigatorCutButton.Click, mnuEditCut.Click
		CutDataGridToClipboard()
	End Sub

	Private Sub BindingNavigatorCopyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BindingNavigatorCopyButton.Click, mnuEditCopy.Click
		CopyDataGridToClipboard()
	End Sub

	Private Sub BindingNavigatorPasteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BindingNavigatorPasteButton.Click, mnuEditPaste.Click
		PasteClipboardToDataGrid()
	End Sub

	Private Sub BindingNavigatorViewErrorsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BindingNavigatorViewErrorsButton.Click
		If boolFileContainsErrors Then
			Dim lines As String() = File.ReadAllLines(Path.ChangeExtension(_File.Pathname, "ERR"), _Encoding)
			Using dlg As New dlgViewLogFile() With {.Text = lines(0)}
				dlg.txtLogFile.Text = String.Join(vbCrLf, lines, 1, lines.Length - 1)
				For Each line In lines
					If line <> String.Empty Then
						Dim ele As String() = line.Split(New [Char]() {"("c, ")"c}, StringSplitOptions.RemoveEmptyEntries)
						For Each str As String In ele
							If str.Contains(" line ") Then
								Dim l As String = str.Substring(str.Trim.IndexOf(" line ") + 6)
								Dim lineNumber As Integer = l

								If ele.Length = 1 Then
									Beep()
								ElseIf ele.Length = 2 Then
								Else
								End If

								Exit For
							End If
						Next
					End If
				Next
				dlg.ShowDialog()
			End Using
		Else
			MessageBox.Show(String.Format(My.Resources.err0050, Path.ChangeExtension(_File.Pathname, "ERR")), "View Errors", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0050)
			BindingNavigatorViewErrorsButton.Enabled = False
			boolFileContainsErrors = False
		End If
	End Sub

	Private Sub BindingNavigatorPositionItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BindingNavigatorPositionItem.KeyDown
		Dim result As Boolean = True
		Dim numericKeys As Boolean = (((e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) OrElse (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9)) AndAlso e.Modifiers <> Keys.Shift)
		Dim editKeys As Boolean = ((e.KeyCode = Keys.Z AndAlso e.Modifiers = Keys.Control) OrElse (e.KeyCode = Keys.X AndAlso e.Modifiers = Keys.Control) OrElse (e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Control) OrElse (e.KeyCode = Keys.V AndAlso e.Modifiers = Keys.Control) OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back)
		Dim navigationKeys As Boolean = (e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Home OrElse e.KeyCode = Keys.End)

		If (Not (numericKeys OrElse editKeys OrElse navigationKeys OrElse e.KeyCode = Keys.Return)) Then
			result = False
		End If

		If (Not result) Then	' If not valid key then suppress and handle.
			Beep()
			e.SuppressKeyPress = True
			e.Handled = True
		End If

	End Sub

	Sub BindingNavigatorViewErrorsButton_EventHandler(ByVal strFileName As String)
		If fileOpen Then
			If _File.Filename <> String.Empty Then
				If String.Compare(_File.Pathname, strFileName, True) = 0 OrElse String.Compare(_File.Filename, strFileName, True) = 0 Then
					boolFileContainsErrors = File.Exists(Path.ChangeExtension(strFileName, "ERR"))
					BindingNavigatorViewErrorsButton.Enabled = boolFileContainsErrors

					' Mark lines that have errors in them with a RowError
					'
					ImportErrorsFromFreeREG()
				End If
			End If
		End If
	End Sub

#End Region

#Region "Binding Source"

	Private Sub bsDGV_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
		Dim bs As BindingSource = CType(sender, BindingSource)
		Try
			My.Application.Log.WriteEntry(String.Format("bsDGV_ListChanged - Type={0} NewIndex={1} OldIndex={2}", e.ListChangedType.ToString, e.NewIndex, e.OldIndex))
			Select Case e.ListChangedType
				Case ListChangedType.ItemAdded
					Try
						If My.Settings.UseDataGrid Then
							With mainDGV
								If e.NewIndex < .Rows.Count Then
									.ClearSelection()
									.FirstDisplayedScrollingRowIndex = e.NewIndex
									.Rows(e.NewIndex).Selected = True
									If .CurrentCell IsNot Nothing Then
										If .AllowUserToAddRows Then
											.CurrentCell = .Item(.CurrentCell.ColumnIndex, e.NewIndex - 1)
										Else
											.CurrentCell = .Item(.CurrentCell.ColumnIndex, e.NewIndex)
										End If
									Else
										If .AllowUserToAddRows Then
											.CurrentCell = .Item(.FirstDisplayedScrollingColumnIndex, e.NewIndex - 1)
										Else
											.CurrentCell = .Item(.FirstDisplayedScrollingColumnIndex, e.NewIndex)
										End If
									End If
								Else
									Beep()
								End If
							End With
						Else
							With panelWinREG2
								.lvData.SelectedIndices.Add(e.NewIndex)
								.lvData.Items(e.NewIndex).Selected = True
								.lvData.Items(e.NewIndex).EnsureVisible()
							End With
						End If
						CType(bs.DataSource, DataTable).WriteXml(RecoveryTable, False)

					Catch ex As Exception
						My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in bsDGV_ListChanged ItemAdded")
						MessageBox.Show(ex.Message + ex.StackTrace, "bsDGV_ListChanged ItemAdded", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					End Try

				Case ListChangedType.ItemChanged
					CType(bs.DataSource, DataTable).WriteXml(RecoveryTable, False)

			End Select

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in bsDGV_ListChanged")
			MessageBox.Show(ex.Message + ex.StackTrace, "bsDGV_ListChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
		End Try
	End Sub

#End Region

#Region "MRU"

	Private Sub AddToMRU(ByVal pathname As String)
		If My.Settings.MyMRUList Is Nothing Then My.Settings.MyMRUList = New StringCollection
		If My.Settings.MyMRUList.Contains(pathname.ToUpper()) Then My.Settings.MyMRUList.Remove(pathname.ToUpper())
		My.Settings.MyMRUList.Add(pathname.ToUpper())
		While My.Settings.MyMRUList.Count > My.Settings.MyMRUSize
			My.Settings.MyMRUList.RemoveAt(0)
		End While
		UpdateMRU()
	End Sub

	Private Sub UpdateMRU()
		Dim cisItems As New List(Of ToolStripItem)
		For Each cisMenu As ToolStripItem In mnuFileMRUList.DropDownItems
			If Not cisMenu.Tag Is Nothing Then
				If (cisMenu.Tag.ToString().StartsWith("MRU:")) Then
					cisItems.Add(cisMenu)
				End If
			End If
		Next

		For Each cismenu As ToolStripItem In cisItems
			mnuFileMRUList.DropDownItems.Remove(cismenu)
		Next

		Dim x As Integer = 1
		For iCounter As Integer = My.Settings.MyMRUList.Count - 1 To 0 Step -1
			Dim sPath As String = My.Settings.MyMRUList(iCounter)
			Dim cisItem As New ToolStripMenuItem(String.Format("{0} {1}", x, Path.GetFileName(sPath))) With {.Tag = "MRU:" & sPath}
			AddHandler cisItem.Click, AddressOf mnuFileMRU_Click
			mnuFileMRUList.DropDownItems.Insert(mnuFileMRUList.DropDownItems.IndexOf(ToolStripSeparator15), cisItem)
			x += 1
		Next

		mnuFileMRUList.Visible = True
		mnuFileMRUList.Enabled = True
		ToolStripSeparator10.Visible = True
	End Sub

	Private Sub mnuFileMRU_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileMRUList.Click
		Dim tsi As ToolStripItem = DirectCast(sender, ToolStripItem)
		If tsi.Tag <> Nothing Then
			Dim filename As String = tsi.Tag.ToString().Substring(4)

			If File.Exists(filename) Then
				If fileOpen Then CloseTranscriptionFile(CloseReason.None)

				OpenTranscriptionFile(filename)
			Else
				If MessageBox.Show(String.Format(My.Resources.msgMRUFileMissing, filename), "MRU Files", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0007) = Windows.Forms.DialogResult.Yes Then
					For Each cisMenu As ToolStripItem In mnuFileMRUList.DropDownItems
						If Not cisMenu.Tag Is Nothing Then
							If (cisMenu.Tag.ToString().StartsWith("MRU:")) Then
								If cisMenu.Tag.ToString.Contains(filename.ToUpper()) Then
									mnuFileMRUList.DropDownItems.Remove(cisMenu)
									If My.Settings.MyMRUList.Contains(filename.ToUpper()) Then
										My.Settings.MyMRUList.Remove(filename)
									End If
									Exit For
								End If
							End If
						End If
					Next
				End If
			End If
		Else
			Beep()
		End If
	End Sub

	Private Sub mnuFileMRUClearList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileMRUClearList.Click
		Dim cisItems As New List(Of ToolStripItem)
		For Each cisMenu As ToolStripItem In mnuFileMRUList.DropDownItems
			If Not cisMenu.Tag Is Nothing Then
				If (cisMenu.Tag.ToString().StartsWith("MRU:")) Then
					cisItems.Add(cisMenu)
				End If
			End If
		Next

		For Each cismenu As ToolStripItem In cisItems
			mnuFileMRUList.DropDownItems.Remove(cismenu)
		Next

		My.Settings.MyMRUList.Clear()

		mnuFileMRUList.Visible = False
		mnuFileMRUList.Enabled = False
		ToolStripSeparator10.Visible = False
	End Sub

#End Region

#Region "Background Threads"

	Private Sub bwUpdater_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bwUpdater.DoWork
		Dim bw As BackgroundWorker = CType(sender, BackgroundWorker)
		boolThreadActive = True
		e.Result = CheckForUpdates(bw, e)
	End Sub

	Private Sub bwUpdater_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bwUpdater.RunWorkerCompleted

		tickDisplay.Enabled = True
		boolThreadActive = False
		If e.Error IsNot Nothing Then
			MessageBox.Show(e.Error.Message)
			My.Application.Log.WriteEntry(String.Format("{0} Software Update task aborted <{1}>", Date.Now(), e.Error.Message), TraceEventType.Error)
		ElseIf e.Cancelled Then
			My.Application.Log.WriteEntry(Date.Now() + " Software Update task cancelled", TraceEventType.Information)
			Close()
		Else
			Dim x As UpdaterReturnValue = e.Result
			Dim s As String = [Enum].GetName(GetType(UpdaterReturnValue), x)

			If x = UpdaterReturnValue.NO_UPDATE_RUN Then Return
			lblInformation.Text = "Automatic check for software updates completed. Code: " + s
			My.Application.Log.WriteEntry(String.Format("{0} Software Update task completed - code: {1}", Date.Now(), s), TraceEventType.Information)

			Select Case x
				Case UpdaterReturnValue.NEW_UPDATES_AVAILABLE
					My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)

					If _OS.Version.Major >= 6 Then
						If Not winImageViewer Is Nothing Then
							If winImageViewer.IsVisible Then
								winImageViewer.Hide()
							End If
						End If
					Else
						If Not frmImageViewer Is Nothing Then
							If Not frmImageViewer.IsDisposed Then
								If frmImageViewer.Visible Then frmImageViewer.Hide()
							End If
						End If
					End If

					If MessageBox.Show(My.Resources.infUpdatesAvailable, "New Software Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, 0, "MessageBoxes.chm", HelpNavigator.TopicId, INF0011) = Windows.Forms.DialogResult.Yes Then
						If fileOpen Then CloseTranscriptionFile(CloseReason.None)

						Using p As Process = Process.Start(strUpdaterPath, "/checknow")
							p.WaitForExit()
							p.Close()
						End Using
					End If

				Case UpdaterReturnValue.NO_UPDATES_AVAILABLE
					My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)

				Case UpdaterReturnValue.PATH_EXPAND_ERROR
				Case UpdaterReturnValue.CONFIG_FILE_NOT_FOUND
				Case UpdaterReturnValue.UNDEFINED_CONFIG_FILE_FORMAT
				Case UpdaterReturnValue.UNDEFINED_FILE_VERSION
				Case UpdaterReturnValue.UNABLE_TO_SAVE_FILE
				Case UpdaterReturnValue.INVALID_COMMAND_LINE
				Case UpdaterReturnValue.INVALID_CLIENT_CONFIG
				Case UpdaterReturnValue.INVALID_SERVER_CONFIG
				Case UpdaterReturnValue.ERROR_INVALID_UPDATE_ENTRY
				Case UpdaterReturnValue.ERROR_URL_NOT_FOUND
					My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
					MessageBox.Show([String].Format(My.Resources.err0044, s), "Updater Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0044)

			End Select

		End If

	End Sub

	Private Sub tickDisplay_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tickDisplay.Tick
		lblInformation.Text = String.Empty
		tickDisplay.Enabled = False
	End Sub

	Enum UpdaterReturnValue As Integer
		NEW_UPDATES_AVAILABLE = &H0
		NO_UPDATES_AVAILABLE = &HE0000011
		PATH_EXPAND_ERROR = &HE0000001						' Unable to expand a dynamic path.
		CONFIG_FILE_NOT_FOUND = &HE0000002					' Unable to find the updater configuration file. It should be located near the updater.exe.
		UNDEFINED_CONFIG_FILE_FORMAT = &HE0000003			' The updates configuration file format is invalid.
		UNDEFINED_FILE_VERSION = &HE0000004					' The updater is unable to extract a file version.
		UNABLE_TO_SAVE_FILE = &HE0000005						' The updater is unable to save a file.
		INVALID_COMMAND_LINE = &HE0000006					' The command line is not recognized.
		INVALID_CLIENT_CONFIG = &HE0000007					' The updater configuration file is invalid. It is required that certain entries must not be empty.
		INVALID_SERVER_CONFIG = &HE000000E					' The signature of the updates configuration file is missing or is invalid.
		ERROR_INVALID_UPDATE_ENTRY = &HE0000014			' The updates configuration file is invalid. It is required that certain entries must not be empty
		ERROR_URL_NOT_FOUND = &HE0000018						' The updates configuration file or an update file may be 
		NO_UPDATE_RUN = &HFFFFFFFF
	End Enum

	Private Function CheckForUpdates(ByVal bw As BackgroundWorker, ByVal e As DoWorkEventArgs) As Integer
		Dim result As UpdaterReturnValue = UpdaterReturnValue.NO_UPDATES_AVAILABLE, ticks As Integer = 30
		Dim bool As Boolean = CType(e.Argument, Boolean)
		If Not bool Then Return UpdaterReturnValue.NO_UPDATE_RUN
		Dim ts As New TimeSpan(0, 0, 1)

		While ticks > 0
			Thread.Sleep(ts)

			If bw.CancellationPending Then
				e.Cancel = True
				Return result
			End If

			ticks -= 1
		End While

		lblInformation.Text = "Automatic check for software updates started"
		Application.DoEvents()
		Dim p As Process = Process.Start(strUpdaterPath, "/justcheck")
		p.WaitForExit()
		result = p.ExitCode
		p.Close()
		Return result
	End Function

	Private Sub bwCheckFile_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bwCheckFile.DoWork
		Dim bw As BackgroundWorker = CType(sender, BackgroundWorker)
		boolCorruptionThreadActive = True
		e.Result = CheckFileCorruption(bw, e)
	End Sub

	Private Sub bwCheckFile_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bwCheckFile.RunWorkerCompleted
		boolCorruptionThreadActive = False
		If e.Error IsNot Nothing Then
			MessageBox.Show(e.Error.Message)
			My.Application.Log.WriteEntry(String.Format("{0} File Corruption Check task aborted <{1}>", Date.Now(), e.Error.Message), TraceEventType.Error)
		ElseIf e.Cancelled Then
			My.Application.Log.WriteEntry(Date.Now() + " File Corruption Check task cancelled", TraceEventType.Information)
			Close()
		Else
			Dim x As Integer = e.Result
		End If
	End Sub

	Private Function CheckFileCorruption(ByVal bw As BackgroundWorker, ByVal e As DoWorkEventArgs) As Integer
		Dim result As Integer = 0

		If bw.CancellationPending Then
			e.Cancel = True
			Return result
		End If
	End Function

#End Region

#Region "Utility"

	Private Sub FreeREG_UserDetailsChanged(ByVal userid As String, ByVal password As String)
		My.Settings.MyUserName = userid
		My.Settings.MyUserPassword = password
		My.Settings.Save()
	End Sub

	Function GetID(ByVal fname As String) As String
		GetID = ""
		Dim files As List(Of String) = New List(Of String)()
		Using sr As StreamReader = New StreamReader(fname)
			Dim inp As String
			Do While sr.Peek() >= 0
				inp = sr.ReadLine()
				Dim sep() As Char = {","c, "="c}
				Dim parts As String() = inp.Split(sep)
				If parts.Length = 2 Then
					If parts(0) = "ID" Then
						GetID = parts(1)
						Exit Do
					End If
				End If
			Loop
			sr.Close()
		End Using
	End Function

	Function GetFileType(ByVal filename As String) As String
		GetFileType = Nothing
		If tabRecordTypes.Rows.Contains(filename.Substring(6, 2)) Then
			GetFileType = tabRecordTypes.Rows.Find(filename.Substring(6, 2))("Description")
			Return GetFileType.ToUpper()
		End If
	End Function

	Public Function QuoteString(ByVal str As String) As String
		Dim ch1 As Char = """", ch2 As String = """"
		Dim NewString As String

		If str.IndexOf(ch1) = 0 Then
			NewString = str.Trim(ch2.ToCharArray())
		Else
			NewString = str
		End If

		If NewString.Contains("{") Then
			NewString = NewString.Replace("{", "{{")
		End If

		If NewString.Contains("}") Then
			NewString = NewString.Replace("}", "}}")
		End If

		If NewString.Contains(",") Or NewString.Contains("""") Then
			If NewString.Contains("""") Then
				NewString = NewString.Replace(ch1, Chr(34) & Chr(34))
			End If

			If Not (NewString.IndexOf(ch1) = 0 And NewString.LastIndexOf(ch1) = NewString.Length - 1) Then
				NewString = String.Format("""{0}""", NewString)
			End If
		End If

		Return NewString
	End Function

	Private currentEditingCell As TextBox

	Private Sub lblDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDate.Click
		Dim rc = StartDateHelper(currentEditingCell)
	End Sub

	Private Sub lblUCF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblUCF.Click
		Dim rc = StartUCFHelper(currentEditingCell)
	End Sub

	Private Function StartDateHelper(ByVal sender As Object) As Windows.Forms.DialogResult
		If sender Is Nothing Then Return Windows.Forms.DialogResult.Cancel
		Using dlg As New dlgDateHelper
			dlg._Date.FieldName = sender.Name
			dlg._Date.FieldText = sender.Text
			dlg._Date.InsertionPoint = sender.SelectionStart

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				sender.Text = dlg._Date.FieldText
			End If
		End Using
	End Function

	Private Sub DateHelper_Detector(ByVal sender As Object, ByVal e As KeyEventArgs)
		If e.KeyCode = Keys.F4 AndAlso e.Modifiers = 0 Then
			Dim rc = StartDateHelper(sender)
			e.Handled = True
		End If
	End Sub

	Private Function StartUCFHelper(ByVal sender As Object) As Windows.Forms.DialogResult
		If sender Is Nothing Then Return Windows.Forms.DialogResult.Cancel
		Using dlg As New dlgUCF
			dlg._ucf.FieldName = sender.Name
			dlg._ucf.FieldText = sender.Text
			dlg._ucf.InsertionPoint = sender.SelectionStart

			If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
				sender.Text = dlg._ucf.FieldText
			End If
		End Using
	End Function

	Private Sub UCF_Detector(ByVal sender As Object, ByVal e As KeyEventArgs)
		If e.KeyCode = Keys.F5 AndAlso e.Modifiers = 0 Then
			Dim rc = StartUCFHelper(sender)
			e.Handled = True
		End If
	End Sub

	Private hotkey As Boolean
	Private txtToInsert As String = ""

	Public Sub BurialAge_HotkeyDetector(ByVal sender As Object, ByVal e As KeyEventArgs)
		Dim ctlEdit As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
		hotkey = False
		txtToInsert = ""
		If ctlEdit.TextLength = 0 Then
			If e.KeyCode = Keys.I AndAlso e.Modifiers = 0 Then
				txtToInsert = "nfant"
				hotkey = True
			ElseIf e.KeyCode = Keys.C AndAlso e.Modifiers = 0 Then
				txtToInsert = "hild"
				hotkey = True
			End If
		End If
	End Sub

	Public Sub MarriageAge_HotkeyDetector(ByVal sender As Object, ByVal e As KeyEventArgs)
		Dim ctlEdit As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
		hotkey = False
		txtToInsert = ""
		If ctlEdit.TextLength = 0 Then
			If e.KeyCode = Keys.O AndAlso e.Modifiers = 0 Then
				txtToInsert = "f full age"
				hotkey = True
			ElseIf e.KeyCode = Keys.F AndAlso e.Modifiers = 0 Then
				txtToInsert = "ull age"
				hotkey = True
			ElseIf e.KeyCode = Keys.M AndAlso e.Modifiers = 0 Then
				txtToInsert = "inor"
				hotkey = True
			End If
		End If
	End Sub

	Private Sub CompleteHotkeyText(ByVal sender As [Object], ByVal e As KeyPressEventArgs)
		Dim ctlEdit As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
		If hotkey AndAlso txtToInsert <> "" Then
			ctlEdit.Text += txtToInsert
		End If
	End Sub

	Public Sub EnableDate(ByVal ctl As TextBox)
		lblDate.Visible = True
		RemoveHandler ctl.KeyDown, AddressOf DateHelper_Detector
		AddHandler ctl.KeyDown, AddressOf DateHelper_Detector
		currentEditingCell = ctl
	End Sub

	Public Sub EnableUCF(ByVal ctl As CaseTextEditingControl)
		lblUCF.Visible = True
		RemoveHandler ctl.KeyDown, AddressOf UCF_Detector
		AddHandler ctl.KeyDown, AddressOf UCF_Detector
		currentEditingCell = ctl
	End Sub

	Private Sub popColumnsVisibility_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles popColumnsVisibility.Opening
		Dim menu As ContextMenuStrip = CType(sender, ContextMenuStrip)
		Dim tsi As ToolStripMenuItem
		menu.Items.Clear()

		tsi = menu.Items.Add("Restore Column Sequence")
		AddHandler tsi.Click, AddressOf popitem_Click_Autosize
		tsi = menu.Items.Add("Autosize Column Widths")
		AddHandler tsi.Click, AddressOf popitem_Click_Autosize
		menu.Items.Add("-")

		For Each col As DataGridViewColumn In mainDGV.Columns
			If col.Name <> "County" AndAlso col.Name <> "LoadOrder" Then
				tsi = menu.Items.Add(col.Name)
				tsi.CheckOnClick = True
				tsi.Checked = col.Visible
				AddHandler tsi.CheckedChanged, AddressOf popItem_CheckChanged
			End If
		Next
	End Sub

	Private Sub popColumnsVisibility_Closing(ByVal sender As Object, ByVal e As ToolStripDropDownClosingEventArgs) Handles popColumnsVisibility.Closing
		If e.CloseReason = ToolStripDropDownCloseReason.ItemClicked Then e.Cancel = True
	End Sub

	Private Sub popItem_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim tsi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
		Try
			If tsi.Text <> "" AndAlso tsi.Text <> "County" Then mainDGV.Columns(tsi.Text).Visible = tsi.Checked
			If Not mainDGV.Columns("Fiche").Visible AndAlso Not mainDGV.Columns("Image").Visible Then
				mnuFileShowLDSColumns.Enabled = True
				mnuFileShowLDSColumns.Visible = True
			End If

		Catch ex As Exception
		End Try
	End Sub

	Private Sub popItem_ShowAutoCompletionList(ByVal sender As Object, ByVal e As EventArgs)
		Dim tsi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
		Dim dlg As New dlgEditAutoCompletionList

		Select Case tsi.Text
			Case "Abodes"
				dlg.Text = "Abodes Autocompletion List"
				dlg.acs = acscAbodes

			Case "Occupations"
				dlg.Text = "Occupations Autocompletion List"
				dlg.acs = acscOccupations

		End Select

		If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
		End If

		dlg.Dispose()
	End Sub

	Private popIdx As Integer = -1

	Private Sub popitem_Click_Autosize(ByVal sender As Object, ByVal e As EventArgs)
		Dim tsi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

		If tsi.Text = "Restore Column Sequence" Then
			For Each col As DataGridViewColumn In mainDGV.Columns
				col.DisplayIndex = col.Index
			Next
		ElseIf tsi.Text = "Autosize Column Widths" Then
			mainDGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)
		End If
		popColumnsVisibility.Close()
	End Sub

	Public Function ReformatDateString(ByVal dateIn() As String) As String
		Dim dateOut As String = "'"
		Dim strMonthNames() = {"*", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

		If dateIn(4) <> "" Then
			If IsNumeric(dateIn(3)) Then
				dateIn(3) += 1
			End If
		End If
		dateOut = dateIn(3)

		If dateIn(2) <> "" Then
			If Array.IndexOf(strMonthNames, dateIn(2)) >= 0 Then
				dateOut += " " + Array.IndexOf(strMonthNames, dateIn(2)).ToString("d2")
			Else
				dateOut += " " + dateIn(2)
			End If
		Else
			dateOut += " *"
		End If

		If dateIn(1) <> "" Then
			If dateIn(1).Length = 1 Then
				dateIn(1) = "0" + dateIn(1)
			End If
			dateOut += " " + dateIn(1)
		Else
			dateOut += " *"
		End If

		Return dateOut
	End Function

	Public Sub AddStringToCollection(ByRef coll As AutoCompleteStringCollection, ByVal cell As String)
		If coll IsNot Nothing Then
			If cell IsNot Nothing Then
				If Not IsDBNull(cell) Then
					Dim str As String = cell.Trim()
					If str <> String.Empty Then
						If Not coll.Contains(str) Then
							coll.Add(str)
						End If
					End If
				End If
			End If
		End If
	End Sub

	Public Sub DuplicateRecord(ByVal row As DataGridViewRow)
		If row Is Nothing Then Return
		Dim b As Windows.Forms.DialogResult
		If My.Settings.ConfirmRecordDuplication Then
			b = MessageBox.Show(String.Format(My.Resources.msgCopyRecord, row.Index + 1), "Copy Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0003)
		Else
			b = Windows.Forms.DialogResult.Yes
		End If
		If b = Windows.Forms.DialogResult.Yes Then
			Dim rv As DataRowView = bsDGV.AddNew()
			Dim sourceRow = rv.Row()
			For Each cell In mainDGV.Rows(row.Index).Cells
				If mainDGV.Columns(cell.columnindex).name <> "LoadOrder" Then
					If mainDGV.Columns(cell.columnindex).name = "Fiche" Then
						sourceRow.Item("LDSFiche") = cell.value
					ElseIf mainDGV.Columns(cell.columnindex).name = "Image" Then
						sourceRow.Item("LDSImage") = cell.value
					Else
						sourceRow.Item(mainDGV.Columns(cell.columnindex).name) = cell.value
					End If
				End If
			Next
			fileChanged = True
			bsDGV.EndEdit()
		End If
	End Sub

	Public Sub CutDataGridToClipboard()
		'
		'	Clear the selected cell or cells, and copy the data to the ClipBoard
		'
		If mainDGV.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
			Dim coll As System.Collections.ObjectModel.Collection(Of myDGV.CellContents) = New System.Collections.ObjectModel.Collection(Of myDGV.CellContents)
			If mainDGV.GetCellCount(DataGridViewElementStates.Selected) = 1 Then
				Try
					Dim item As myDGV.CellContents = New myDGV.CellContents() With {.row = mainDGV.CurrentCell.RowIndex, .col = mainDGV.CurrentCell.ColumnIndex, .str = mainDGV.Item(mainDGV.CurrentCell.ColumnIndex, mainDGV.CurrentCell.RowIndex).Value()}
					coll.Add(item)
					mainDGV.UnDoable("Cut Single Cell", coll)

					My.Computer.Clipboard.SetText(mainDGV.CurrentCell.FormattedValue.ToString())
					mainDGV.CurrentCell.Value = ""
					mainDGV.CurrentCell.ValueType = GetType(String)
					mainDGV.NotifyCurrentCellDirty(True)
				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception during Cut operation")
				End Try
			Else
				Try
					My.Computer.Clipboard.SetDataObject(mainDGV.GetClipboardContent)
					lblInformation.Text = "Deleted data copied to clipboard"
					tickDisplay.Enabled = True
					For Each cell As DataGridViewCell In mainDGV.SelectedCells()
						Dim item As myDGV.CellContents = New myDGV.CellContents() With {.row = cell.RowIndex, .col = cell.ColumnIndex, .str = mainDGV.Item(cell.ColumnIndex, cell.RowIndex).Value()}
						coll.Add(item)

						cell.Value = ""
						cell.ValueType = GetType(String)
					Next
					mainDGV.UnDoable("Cut Multiple Cells", coll)
				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception during Cut operation")
				End Try
			End If
		Else
			Beep()
		End If
	End Sub

	Public Sub CopyDataGridToClipboard()
		'
		'	Copy the data from the selected cell or cells to the CLipboard
		'
		If mainDGV.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
			If mainDGV.GetCellCount(DataGridViewElementStates.Selected) = 1 Then
				Try
					My.Computer.Clipboard.SetText(mainDGV.CurrentCell.FormattedValue.ToString())
					lblInformation.Text = "Cell copied to clipboard"
					tickDisplay.Enabled = True
				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception during Copy operation")
				End Try
			Else
				Try
					My.Computer.Clipboard.SetDataObject(mainDGV.GetClipboardContent)
					lblInformation.Text = "Visible columns of row copied to clipboard"
					tickDisplay.Enabled = True
				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception during Copy operation")
				End Try
			End If
		Else
			Beep()
		End If
	End Sub

	Public Sub PasteClipboardToDataGrid()
		'
		'	Paste the data from the Clipboard into the DataGRid using the selected cell or cells as the anchor point
		'
		If My.Computer.Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue) Then
			mainDGV.CancelEdit()
			Dim sText As String = My.Computer.Clipboard.GetText(TextDataFormat.CommaSeparatedValue)
			sText = sText.TrimEnd

			Try
				If mainDGV.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText Then
					Dim lines() As String = Split(sText, vbLf)
					Dim chTrim() As Char = {vbCr, vbLf}
					Dim hdrs() As String = Split(lines(0).TrimEnd(chTrim), ",")
					For line = 1 To lines.Length - 1
						Dim data() As String = Split(lines(line).TrimEnd(chTrim), ",", hdrs.Length, CompareMethod.Text)
						For i As Integer = 1 To data.Length - 1
							Console.WriteLine(String.Format("{0}:{1}", hdrs(i), data(i)))
						Next
					Next
				End If

			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception during Paste Block operation")
			End Try

		ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.Text) Then
			Dim sText As String = My.Computer.Clipboard.GetText()
			sText = sText.TrimEnd

			If mainDGV.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
				Dim coll As System.Collections.ObjectModel.Collection(Of myDGV.CellContents) = New System.Collections.ObjectModel.Collection(Of myDGV.CellContents)
				If mainDGV.GetCellCount(DataGridViewElementStates.Selected) = 1 Then
					Try
						Dim item As myDGV.CellContents = New myDGV.CellContents() With {.row = mainDGV.CurrentCell.RowIndex, .col = mainDGV.CurrentCell.ColumnIndex, .str = mainDGV.Item(mainDGV.CurrentCell.ColumnIndex, mainDGV.CurrentCell.RowIndex).Value()}
						coll.Add(item)
						mainDGV.UnDoable("Paste Single Cell to Single Cell", coll)

						mainDGV.CurrentCell.Value = sText
						mainDGV.CurrentCell.ValueType = GetType(String)
					Catch ex As Exception
						My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception during Paste Cell operation")
					End Try
				Else
					Try
						For Each cell As DataGridViewCell In mainDGV.SelectedCells()
							Dim item As myDGV.CellContents = New myDGV.CellContents() With {.row = cell.RowIndex, .col = cell.ColumnIndex, .str = mainDGV.Item(cell.ColumnIndex, cell.RowIndex).Value()}
							coll.Add(item)

							cell.Value = sText
							cell.ValueType = GetType(String)
						Next
						mainDGV.UnDoable("Paste Single Cell to Multiple Cells", coll)
					Catch ex As Exception
						My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception during Paste to Multiple Cells operation")
					End Try
				End If
			Else
				Beep()
			End If
		ElseIf My.Computer.Clipboard.ContainsAudio() OrElse My.Computer.Clipboard.ContainsImage() OrElse My.Computer.Clipboard.ContainsFileDropList() Then
			lblInformation.Text = "Clipboard contents inappropriate for pasting"
			tickDisplay.Enabled = True
			Beep()
		ElseIf My.Computer.Clipboard.ContainsText() Then
			lblInformation.Text = "Text data on clipboard is inappropriate for pasting"
			tickDisplay.Enabled = True
			Beep()
		Else
			lblInformation.Text = "Unable to decipher clipboard contents"
			tickDisplay.Enabled = True
			Beep()
		End If
	End Sub

	Public Sub DeleteDataFromDataGrid()
		'
		'	Clear any data from the selected cell or cells
		'
		If mainDGV.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
			Dim coll As System.Collections.ObjectModel.Collection(Of myDGV.CellContents) = New System.Collections.ObjectModel.Collection(Of myDGV.CellContents)
			If mainDGV.GetCellCount(DataGridViewElementStates.Selected) = 1 Then
				Try
					Dim item As myDGV.CellContents = New myDGV.CellContents() With {.row = mainDGV.CurrentCell.RowIndex, .col = mainDGV.CurrentCell.ColumnIndex, .str = mainDGV.Item(mainDGV.CurrentCell.ColumnIndex, mainDGV.CurrentCell.RowIndex).Value()}
					coll.Add(item)
					mainDGV.UnDoable("Delete Single Cell", coll)

					mainDGV.CurrentCell.Value = ""
					mainDGV.CurrentCell.ValueType = GetType(String)
					mainDGV.NotifyCurrentCellDirty(True)
				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception during Delete operation")
				End Try
			Else
				Try
					For Each cell As DataGridViewCell In mainDGV.SelectedCells()
						Dim item As myDGV.CellContents = New myDGV.CellContents() With {.row = cell.RowIndex, .col = cell.ColumnIndex, .str = mainDGV.Item(cell.ColumnIndex, cell.RowIndex).Value()}
						coll.Add(item)

						cell.Value = ""
						cell.ValueType = GetType(String)
					Next
					mainDGV.UnDoable("Delete Multiple Cells", coll)
				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception during Delete operation")
				End Try
			End If
		Else
			Beep()
		End If
	End Sub

	Private Sub LaunchDefaultBrowser(Optional ByVal URL As String = "")
		Dim AppPath As String = GetDefaultBrowserPath()
		Dim Splitters As String() = {""""c}
		Dim ThisUrl As String = URL.Trim

		If AppPath = String.Empty Then
			MsgBox("Unable to locate default browser path.", MsgBoxStyle.Exclamation, String.Format("LaunchDefaultBrowser({0})", ThisUrl))
			Exit Sub
		End If

		Dim s() As String = AppPath.Split(Splitters, StringSplitOptions.RemoveEmptyEntries)
		Dim AppToLaunch As String

		If s.Length > 0 Then
			AppToLaunch = s(0)
		Else
			AppToLaunch = ""
		End If

		If AppToLaunch = String.Empty Then
			MsgBox("Unable to launch default browser.", MsgBoxStyle.Exclamation, String.Format("LaunchDefaultBrowser({0})", ThisUrl))
		Else
			System.Diagnostics.Process.Start(AppToLaunch, ThisUrl)
		End If
	End Sub

	Public Function GetDefaultBrowserPath() As String
		' Check if we are on Vista or Higher
		Dim OS As OperatingSystem = Environment.OSVersion
		If (OS.Platform = PlatformID.Win32NT) AndAlso (OS.Version.Major >= 6) Then
			Using regkey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\shell\Associations\UrlAssociations\http\UserChoice", False)
				If regkey IsNot Nothing Then
					Using regkey1 As RegistryKey = Registry.LocalMachine.OpenSubKey(String.Format("SOFTWARE\Classes\{0}\shell\open\command", regkey.GetValue("Progid").ToString()), False)
						GetDefaultBrowserPath = regkey1.GetValue("").ToString()
					End Using
				Else
					Using regkey1 As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Classes\IE.HTTP\shell\open\command", False)
						GetDefaultBrowserPath = regkey1.GetValue("").ToString()
					End Using
				End If
			End Using
		Else
			Using regkey As RegistryKey = Registry.ClassesRoot.OpenSubKey("http\shell\open\command", False)
				GetDefaultBrowserPath = regkey.GetValue("").ToString()
			End Using
		End If
	End Function

#End Region

#Region "DataGrid Context Menu"

	Private Sub ctxStripGrid_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles ctxStripGrid.Opening
		If e.Cancel AndAlso fileOpen Then
			e.Cancel = False
		End If

		If Not fileOpen Then
			e.Cancel = True
			Return
		End If

		If mainDGV.SelectedCells.Count > 0 Then
		Else
			e.Cancel = True
		End If
	End Sub

	Private Sub miCut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miCut.Click
		CutDataGridToClipboard()
	End Sub

	Private Sub miCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miCopy.Click
		CopyDataGridToClipboard()
	End Sub

	Private Sub miPaste_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miPaste.Click
		PasteClipboardToDataGrid()
	End Sub

	Private Sub miDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miDelete.Click
		DeleteDataFromDataGrid()
	End Sub

#End Region

#Region "DataGridView"

	Private editcellColumn As Integer = -1
	Private editcellRow As Integer = -1
	Private editcellBackColor As Color = Nothing
	Private editcellInitialContents As String
	Public badDates As StringCollection

	Private Sub mainDGV_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles mainDGV.CellBeginEdit

		Select Case _File.FileType
			Case "BAPTISMS"

			Case "BURIALS"

			Case "MARRIAGES"

		End Select

		editcellColumn = e.ColumnIndex
		editcellRow = e.RowIndex
		editcellBackColor = mainDGV.Item(e.ColumnIndex, e.RowIndex).Style.BackColor
		mainDGV.Item(e.ColumnIndex, e.RowIndex).ErrorText = String.Empty
		Try
			If TypeOf (mainDGV.Item(e.ColumnIndex, e.RowIndex)) Is DataGridViewComboBoxCell Then
				If IsDBNull(mainDGV.Item(e.ColumnIndex, e.RowIndex).Value()) Then editcellInitialContents = String.Empty Else editcellInitialContents = mainDGV.Item(e.ColumnIndex, e.RowIndex).Value()
			Else
				editcellInitialContents = mainDGV.Item(e.ColumnIndex, e.RowIndex).FormattedValue.ToString()
			End If

		Catch ex As Exception
			MessageBox.Show(String.Format("Row:{0} Column:{1}", e.RowIndex, e.ColumnIndex), "CellBeginEdit", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

		End Try
		mainDGV.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightGreen
	End Sub

	Private Sub mainDGV_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles mainDGV.CellClick
		If e.RowIndex = -1 AndAlso e.ColumnIndex = -1 Then				' Clicked on the top-left cell (select all in a multi-select grid)
		ElseIf e.RowIndex = -1 Then											' Clicked on a column header
		ElseIf e.ColumnIndex = -1 Then										' Clicked on a row header
		Else
			bsDGV.Position = e.RowIndex
		End If
	End Sub

	Private Sub mainDGV_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles mainDGV.CellEndEdit

		Select Case _File.FileType
			Case "BAPTISMS"

			Case "BURIALS"

			Case "MARRIAGES"

		End Select

		mainDGV.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = editcellBackColor
		editcellColumn = -1
		editcellRow = -1

		lblDate.Visible = False
		lblUCF.Visible = False
	End Sub

	Private Sub mainDGV_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles mainDGV.CellEnter

		'If mainDGV(e.ColumnIndex, e.RowIndex).EditType.ToString() = "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then
		'	SendKeys.Send("{F4}")
		'End If

		Dim entireRect As Rectangle = mainDGV.GetColumnDisplayRectangle(e.ColumnIndex, False)
		Dim visiblePart As Rectangle = mainDGV.GetColumnDisplayRectangle(e.ColumnIndex, True)

		If visiblePart.Width <= entireRect.Width Then
			mainDGV.HorizontalScrollingOffset += entireRect.Width - visiblePart.Width
		Else
			If visiblePart.Width <= mainDGV.Columns(e.ColumnIndex).Width Then
				mainDGV.HorizontalScrollingOffset += (mainDGV.Columns(e.ColumnIndex).Width - visiblePart.Width)
			Else
				Beep()
			End If
		End If
	End Sub

	Private Sub mainDGV_CellMouseEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles mainDGV.CellMouseEnter
		If e.RowIndex = -1 AndAlso e.ColumnIndex <> -1 Then
			If ttMain.Active Then
				ttMain.ToolTipTitle = mainDGV.Columns(e.ColumnIndex).HeaderText
				ttMain.SetToolTip(mainDGV, mainDGV.Columns(e.ColumnIndex).ToolTipText)
			End If
		End If
	End Sub

	Private Sub mainDGV_CellMouseLeave(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles mainDGV.CellMouseLeave
		If ttMain.Active Then
			ttMain.RemoveAll()
		End If
	End Sub

	Private Sub mainDGV_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles mainDGV.CellValidating
		' Don't try to validate the 'new row' until finished 
		' editing since there
		' is not any point in validating its initial value.
		If mainDGV.Rows(e.RowIndex).IsNewRow Then Return

		If mainDGV.Columns(e.ColumnIndex).Name.Contains("Date") Then
			Dim row = mainDGV.Rows(e.RowIndex)
			Dim strDate As String
			Dim errMsg As String = String.Empty
			Dim m() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}

			If Not IsDBNull(row.Cells(e.ColumnIndex).EditedFormattedValue.ToString()) Then
				strDate = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString().Trim()
			Else
				strDate = ""
			End If
			If Not Validations.ValidateDate(strDate, errMsg, m) Then
				mainDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = errMsg
			Else
				mainDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = String.Empty
				mainDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = strDate
			End If
		End If
	End Sub

	Private Sub mainDGV_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles mainDGV.CellValueChanged
		If e.RowIndex = -1 AndAlso e.ColumnIndex = -1 Then Return
		Try
			If e.RowIndex = editcellRow And e.ColumnIndex = editcellColumn Then
				If TypeOf (mainDGV.Item(e.ColumnIndex, e.RowIndex)) Is DataGridViewComboBoxCell Then
					If editcellInitialContents <> mainDGV.Item(e.ColumnIndex, e.RowIndex).Value() Then
						If mainDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = String.Empty Then
							editcellBackColor = Color.LightPink
							fileChanged = True
							BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
						End If
					End If
				Else
					If editcellInitialContents <> mainDGV.Item(e.ColumnIndex, e.RowIndex).FormattedValue.ToString() Then
						If mainDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = String.Empty Then
							editcellBackColor = Color.LightPink
							fileChanged = True
							BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
						End If
					End If
				End If
			Else
				If e.ColumnIndex <> -1 Then
					If mainDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = String.Empty Then
						mainDGV.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightPink
						fileChanged = True
						If bnDGV.InvokeRequired Then
						Else
							BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
						End If
					End If
				End If
			End If

		Catch ex As Exception

		End Try
	End Sub

	Private Sub mainDGV_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles mainDGV.ColumnHeaderMouseClick
		If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.Clicks = 1 Then
			popIdx = e.ColumnIndex
			popColumnsVisibility.Show(mainDGV, e.X, e.Y)
		End If
	End Sub

	Private Sub mainDGV_ColumnHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles mainDGV.ColumnHeaderMouseDoubleClick
		If IsNothing(badDates) Then
			badDates = New StringCollection
		Else
			badDates.Clear()
		End If

		If e.ColumnIndex >= 0 Then
			Dim newColumn As DataGridViewColumn = mainDGV.Columns(e.ColumnIndex)
			If newColumn Is Nothing Then
				MessageBox.Show("Select a single column and try again.", "Column Sort", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Else
				If newColumn.SortMode <> DataGridViewColumnSortMode.NotSortable Then

					Dim oldColumn As DataGridViewColumn = mainDGV.SortedColumn
					Dim direction As ListSortDirection

					' If oldColumn is null, then the DataGridView is not currently sorted.
					If oldColumn IsNot Nothing Then

						' Sort the same column again, reversing the SortOrder.
						If oldColumn Is newColumn AndAlso mainDGV.SortOrder = SortOrder.Ascending Then
							direction = ListSortDirection.Descending
						Else

							' Sort a new column and remove the old SortGlyph.
							direction = ListSortDirection.Ascending
							oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None
						End If
					Else
						direction = ListSortDirection.Ascending
					End If

					' If no column has been selected, display an error dialog  box.
					DataGridView_CustomSort(sender, e)

					mnuFileUnsortRecords.Visible = True
					mnuFileUnsortRecords.Enabled = True
					BindingNavigatorUnsortFileButton.Enabled = True
				Else
					MessageBox.Show(String.Format(My.Resources.err0031, newColumn.Name), "Column Sort", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0031)
				End If
			End If
		End If
	End Sub

	Private Sub DataGridView_CustomSort(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
		Try
			mainDGV.Cursor = Cursors.WaitCursor

			'Get the column whose header was clicked.
			Dim col As DataGridViewColumn = mainDGV.Columns(e.ColumnIndex)

			'Decide the Sort order, based on whether this column has a sorting glyph set, indicating
			'that it was the last sorted column & also the sort direction.
			Dim sortOrder As Windows.Forms.SortOrder
			If (col.HeaderCell.SortGlyphDirection = Windows.Forms.SortOrder.Ascending) Then
				sortOrder = Windows.Forms.SortOrder.Descending
			Else
				sortOrder = Windows.Forms.SortOrder.Ascending
			End If

			Dim strCollection As StringCollection = mainDGV.CurrentColumnLayout()

			'Get the DataSource of the Grid, which is a BindingSource in this case.
			Dim bs As BindingSource = CType(mainDGV.DataSource, BindingSource)
			Dim table = CType(bs.DataSource, DataTable)

			'			table.Select(Nothing, col.DataPropertyName, DataViewRowState.CurrentRows)
			'			Exit Sub

			'Instantize a IComparer object that will compare two DataRows in the DataTable
			'based on the desired field, & the sortOrder.
			Dim comparer As New CustomSortColComparer(col.DataPropertyName, sortOrder)

			'Add all rows in the table to a list, WITHOUT removing them from the table.
			Dim rowList As New List(Of DataRow)
			For Each row In table.Rows
				rowList.Add(row)
			Next

			'Sort the rows, using the desired comparer.
			rowList.Sort(comparer)

			'Copy sorted rows to a new DataTable.
			Dim sortedTable As DataTable
			'Following two instructions amount to copying of the Schema of the original table to the
			'new table.
			sortedTable = table.Clone()
			sortedTable.Clear()

			sortedTable.BeginLoadData()
			For Each row In rowList
				'Note that importing rows preserves property settings of the row.
				'However, I have not checked whether this would also preserve the rows parent or child
				'relationships to rows in other tables.
				sortedTable.ImportRow(row)
			Next
			sortedTable.EndLoadData()

			'Set the new sorted table as the Grid's datasource.
			bs.DataSource = sortedTable

			'Set the glyph for the column, setting its sort mode to Progrmmatic is necessary,
			'or it raises an exception.
			'Use col.Name to index into the column collection, as the user might have reordered
			'the columns in the DGV, so a column's index in the DGV & the source DataTable might not be the same.
			mainDGV.Columns(col.Name).HeaderCell.SortGlyphDirection = sortOrder
			mainDGV.SetColumnLayout(strCollection)

		Finally
			mainDGV.Cursor = Cursors.Arrow
		End Try
	End Sub



	'Private Sub mainDGV_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles mainDGV.DataBindingComplete
	'	Dim filterStatus As String = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(mainDGV)
	'	If String.IsNullOrEmpty(filterStatus) Then
	'		lblShowAll.Visible = False
	'		lblFfilterStatus.Visible = False
	'	Else
	'		lblShowAll.Visible = True
	'		lblFfilterStatus.Visible = True
	'		lblFfilterStatus.Text = filterStatus
	'	End If
	'End Sub

	Private Sub mainDGV_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles mainDGV.DataError

		'	Select Case e.Context
		'		Case DataGridViewDataErrorContexts.ClipboardContent
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.Commit
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.CurrentCellChange
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.Display
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.Formatting
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.InitialValueRestoration
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.LeaveControl
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.Parsing
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.PreferredSize
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.RowDeletion
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'		Case DataGridViewDataErrorContexts.Scroll
		'			My.Application.Log.WriteEntry(String.Format("{0} DataError Context:{1}", Now(), e.Context.ToString), TraceEventType.Information)
		'	End Select

		'	Select Case _File.FileType
		'		Case "BAPTISMS"
		'			If e.ColumnIndex <> -1 Then
		'				If mainDGV.Columns(e.ColumnIndex).Name = "Sex" Then
		'					Dim str As String = mainDGV.Item(e.ColumnIndex, e.RowIndex).Value
		'					If Not tabBapSex.Rows.Contains(str) Then

		'						For Each row As BaptismSexTableRow In tabBapSex.Rows
		'							If String.Compare(row.Description, str, True) = 0 Then
		'								mainDGV.Item(e.ColumnIndex, e.RowIndex).Value = row.Code
		'								Exit Sub
		'							End If
		'						Next

		'						mainDGV.Item(e.ColumnIndex, e.RowIndex).ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Baptism Sex")
		'						My.Application.Log.WriteEntry(String.Format("{0} Sex: '{1}' not in table", Now(), str), TraceEventType.Error)
		'					End If
		'					Exit Sub
		'				End If
		'			End If

		'		Case "BURIALS"
		'			If e.ColumnIndex <> -1 Then
		'				If mainDGV.Columns(e.ColumnIndex).Name = "Relationship" Then
		'					Dim str As String = mainDGV.Item(e.ColumnIndex, e.RowIndex).Value
		'					If Not tabBurialRelationship.Rows.Contains(str) Then

		'						For Each row As BurialRelationshipTableRow In tabBurialRelationship.Rows
		'							If String.Compare(row.DisplayValue, str, True) = 0 Then
		'								mainDGV.Item(e.ColumnIndex, e.RowIndex).Value = row.FileValue
		'								Exit Sub
		'							End If
		'						Next

		'						mainDGV.Item(e.ColumnIndex, e.RowIndex).ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Burial Relationship")
		'						My.Application.Log.WriteEntry(String.Format("{0} Relationship: '{1}' not in table", Now(), str), TraceEventType.Error)
		'					End If
		'					Exit Sub
		'				End If
		'				If mainDGV.Columns(e.ColumnIndex).Name = "BurialDate" Then
		'					If mainDGV.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
		'						mainDGV.Item(e.ColumnIndex, e.RowIndex).Value = ""
		'						Exit Sub
		'					End If
		'					e.Cancel = True
		'				End If
		'			End If

		'		Case "MARRIAGES"
		'			If e.ColumnIndex <> -1 Then
		'				If mainDGV.Columns(e.ColumnIndex).Name = "BrideCondition" Then
		'					Dim str As String = mainDGV.Item(e.ColumnIndex, e.RowIndex).Value
		'					If Not tabBrideCondition.Rows.Contains(str) Then

		'						For Each row As BrideConditionTableRow In tabBrideCondition.Rows
		'							If String.Compare(row.DisplayValue, str, True) = 0 Then
		'								mainDGV.Item(e.ColumnIndex, e.RowIndex).Value = row.FileValue
		'								Exit Sub
		'							End If
		'						Next

		'						mainDGV.Item(e.ColumnIndex, e.RowIndex).ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Bride Conditions")
		'						My.Application.Log.WriteEntry(String.Format("{0} Bride Condition: '{1}' not in table", Now(), str), TraceEventType.Error)
		'					End If
		'					Exit Sub
		'				End If

		'				If mainDGV.Columns(e.ColumnIndex).Name = "GroomCondition" Then
		'					Dim str As String = mainDGV.Item(e.ColumnIndex, e.RowIndex).Value
		'					If Not tabGroomCondition.Rows.Contains(str) Then

		'						For Each row As GroomConditionTableRow In tabGroomCondition.Rows
		'							If String.Compare(row.DisplayValue, str, True) = 0 Then
		'								mainDGV.Item(e.ColumnIndex, e.RowIndex).Value = row.FileValue
		'								Exit Sub
		'							End If
		'						Next

		'						mainDGV.Item(e.ColumnIndex, e.RowIndex).ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Groom Conditions")
		'						My.Application.Log.WriteEntry(String.Format("{0} Groom Condition: '{1}' not in table", Now(), str), TraceEventType.Error)
		'					End If
		'					Exit Sub
		'				End If
		'			End If
		'	End Select

		'	If e.ColumnIndex <> -1 Then
		'		If mainDGV.Columns(e.ColumnIndex).Name = "Fiche" OrElse mainDGV.Columns(e.ColumnIndex).Name = "Image" OrElse mainDGV.Columns(e.ColumnIndex).Name = "LoadOrder" Then
		'			Dim errStr As String = String.Empty
		'			If e.Context And DataGridViewDataErrorContexts.Formatting Then
		'				errStr += ": Formatting error"
		'			End If
		'			If e.Context And DataGridViewDataErrorContexts.Display Then
		'				errStr += ": Display error"
		'			End If
		'			If e.Context And DataGridViewDataErrorContexts.Parsing Then
		'				errStr += ": Parsing error"
		'			End If
		'			If e.Context And DataGridViewDataErrorContexts.Commit Then
		'				errStr += ": Commit error"
		'			End If
		'			If e.Context And DataGridViewDataErrorContexts.InitialValueRestoration Then
		'				errStr += ": InitialValueRestoration error"
		'			End If
		'			If e.Context And DataGridViewDataErrorContexts.LeaveControl Then
		'				errStr += ": Leave control error"
		'			End If
		'			If e.Context And DataGridViewDataErrorContexts.CurrentCellChange Then
		'				errStr += ": Cell change"
		'			End If
		'			If errStr <> String.Empty Then
		'				My.Application.Log.WriteEntry(String.Format("{0} DataError: {1} Exception:{2} Context:{3}", Now(), mainDGV.Columns(e.ColumnIndex).Name, e.Exception.Message, errStr), TraceEventType.Information)
		'			End If

		'			If TypeOf (e.Exception) Is ConstraintException Then
		'				Dim view As DataGridView = CType(sender, DataGridView)
		'				view.Rows(e.RowIndex).ErrorText = "an error"
		'				view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
		'				e.ThrowException = False
		'			End If
		'			Exit Sub
		'		End If
		'		My.Application.Log.WriteEntry(String.Format("{0} DataError: {1}: {2} {3}", Now(), mainDGV.Columns(e.ColumnIndex).Name, e.Exception, e.Context), TraceEventType.Information)
		'		Exit Sub
		'	End If

		'	My.Application.Log.WriteEntry(String.Format("{0} DataError: {1}: {2} {3}", Now(), If(e.ColumnIndex <> -1, mainDGV.Columns(e.ColumnIndex).Name, e.ColumnIndex.ToString), e.Exception, e.Context), TraceEventType.Information)

	End Sub

	Private Sub mainDGV_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles mainDGV.EditingControlShowing
		Dim widFull = mainDGV.GetColumnDisplayRectangle(mainDGV.CurrentCell.ColumnIndex, False)
		Dim widShowing = mainDGV.GetColumnDisplayRectangle(mainDGV.CurrentCell.ColumnIndex, True)
		If widShowing.Width <> widFull.Width Then
		End If

		Dim row = mainDGV.Rows(mainDGV.CurrentCellAddress.Y)
		Select Case _File.FileType
			Case "BAPTISMS"
				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Forenames").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("FathersName").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("MothersName").Index Then
						If TypeOf (e.Control) Is CaseTextEditingControl Then
							Dim ctl As CaseTextEditingControl = e.Control
							ctl.TextCase = CaseText.CaseText.CaseType.ChristianNames
							ctl.Text = editcellInitialContents
							ctl.AutoCompleteCustomSource.Clear()
							ctl.AutoCompleteMode = AutoCompleteMode.None
							ctl.AutoCompleteSource = AutoCompleteSource.None
							EnableUCF(ctl)
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BAPTISMS Names")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("FathersSurname").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("MothersSurname").Index Then
						If TypeOf (e.Control) Is CaseTextEditingControl Then
							Dim ctl As CaseTextEditingControl = e.Control
							ctl.TextCase = CaseText.CaseText.CaseType.Upper
							ctl.Text = editcellInitialContents
							ctl.AutoCompleteCustomSource.Clear()
							ctl.AutoCompleteMode = AutoCompleteMode.None
							ctl.AutoCompleteSource = AutoCompleteSource.None
							EnableUCF(ctl)
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BAPTISMS Surnames")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Abode").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("FathersOccupation").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("Notes").Index Then
						If TypeOf (e.Control) Is CaseTextEditingControl Then
							Dim ctl As CaseTextEditingControl = e.Control
							ctl.TextCase = CaseText.CaseText.CaseType.Sentence
							ctl.AutoCompleteCustomSource.Clear()
							ctl.Text = editcellInitialContents
							ctl.AutoCompleteMode = AutoCompleteMode.None
							ctl.AutoCompleteSource = AutoCompleteSource.None
							EnableUCF(ctl)

							If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Abode").Index Then
								If My.Settings.MyAutofillFields Then
									ctl.AutoCompleteSource = AutoCompleteSource.CustomSource
									ctl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
									For Each s As String In acscAbodes
										ctl.AutoCompleteCustomSource.Add(s)
									Next
								End If
							End If

							If mainDGV.CurrentCellAddress.X = mainDGV.Columns("FathersOccupation").Index Then
								If My.Settings.MyAutofillFields Then
									ctl.AutoCompleteSource = AutoCompleteSource.CustomSource
									ctl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
									For Each s As String In acscOccupations
										ctl.AutoCompleteCustomSource.Add(s)
									Next
								End If
							End If
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BAPTISMS Abode or Occupation")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Sex").Index Then
						If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
							Dim ctl As DataGridViewComboBoxEditingControl = e.Control
							ctl.DropDownStyle = ComboBoxStyle.DropDownList
							ctl.BackColor = Color.LightGreen
							Return
						End If
					End If

				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BAPTISMS Sex")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("BirthDate").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BaptismDate").Index Then
						If TypeOf (e.Control) Is TextBox Then
							Dim ctl As TextBox = e.Control
							EnableDate(ctl)
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BAPTISMS Dates")

				End Try

			Case "BURIALS"
				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Forenames").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("MaleForenames").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("FemaleForenames").Index Then
						If TypeOf (e.Control) Is CaseTextEditingControl Then
							Dim ctl As CaseTextEditingControl = e.Control
							ctl.TextCase = CaseText.CaseText.CaseType.ChristianNames
							ctl.Text = editcellInitialContents
							ctl.AutoCompleteCustomSource.Clear()
							ctl.AutoCompleteMode = AutoCompleteMode.None
							ctl.AutoCompleteSource = AutoCompleteSource.None
							EnableUCF(ctl)
							Return
						End If
					End If

				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BURIALS Names")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("RelativeSurname").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("Surname").Index Then
						If TypeOf (e.Control) Is CaseTextEditingControl Then
							Dim ctl As CaseTextEditingControl = e.Control
							ctl.TextCase = CaseText.CaseText.CaseType.Upper
							ctl.Text = editcellInitialContents
							ctl.AutoCompleteCustomSource.Clear()
							ctl.AutoCompleteMode = AutoCompleteMode.None
							ctl.AutoCompleteSource = AutoCompleteSource.None
							EnableUCF(ctl)
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BURIALS Surnames")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Abode").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("Notes").Index Then
						If TypeOf (e.Control) Is CaseTextEditingControl Then
							Dim ctl As CaseTextEditingControl = e.Control
							ctl.TextCase = CaseText.CaseText.CaseType.Sentence
							ctl.Text = editcellInitialContents
							ctl.AutoCompleteCustomSource.Clear()
							ctl.AutoCompleteMode = AutoCompleteMode.None
							ctl.AutoCompleteSource = AutoCompleteSource.None
							EnableUCF(ctl)

							If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Abode").Index Then
								If My.Settings.MyAutofillFields Then
									ctl.AutoCompleteSource = AutoCompleteSource.CustomSource
									ctl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
									For Each s As String In acscAbodes
										ctl.AutoCompleteCustomSource.Add(s)
									Next
								End If
							End If
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BURIALS Abode")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Relationship").Index Then
						If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
							Dim ctl As DataGridViewComboBoxEditingControl = e.Control
							ctl.DropDownStyle = ComboBoxStyle.DropDownList
							ctl.BackColor = Color.LightGreen
							Return
						End If
					End If

				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BURIALS Relationship")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("BurialDate").Index Then
						If TypeOf (e.Control) Is TextBox Then
							Dim ctl As TextBox = e.Control
							EnableDate(ctl)
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BURIALS Date")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Age").Index Then
						If TypeOf (e.Control) Is DataGridViewTextBoxEditingControl Then
							Dim ctl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)

							RemoveHandler ctl.KeyDown, New KeyEventHandler(AddressOf BurialAge_HotkeyDetector)
							AddHandler ctl.KeyDown, New KeyEventHandler(AddressOf BurialAge_HotkeyDetector)

							RemoveHandler ctl.KeyPress, New KeyPressEventHandler(AddressOf CompleteHotkeyText)
							AddHandler ctl.KeyPress, New KeyPressEventHandler(AddressOf CompleteHotkeyText)
							Return
						End If
					End If

				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing BURIALS Age")

				End Try

			Case "MARRIAGES"
				Select Case mainDGV.Columns(mainDGV.CurrentCellAddress.X).Name
					Case "GroomFatherForenames"
						If String.IsNullOrEmpty(row.Cells("GroomFatherForenames").Value) AndAlso String.IsNullOrEmpty(row.Cells("GroomFatherSurname").Value) Then
							If Not String.IsNullOrEmpty(row.Cells("GroomSurname").Value) Then
								mainDGV.Rows(mainDGV.CurrentCellAddress.Y).Cells("GroomFatherSurname").Value = row.Cells("GroomSurname").Value
							End If
						End If

					Case "BrideFatherForenames"
						If String.IsNullOrEmpty(row.Cells("BrideFatherForenames").Value) AndAlso String.IsNullOrEmpty(row.Cells("BrideFatherSurname").Value) Then
							If Not String.IsNullOrEmpty(row.Cells("BrideSurname").Value) Then
								mainDGV.Rows(mainDGV.CurrentCellAddress.Y).Cells("BrideFatherSurname").Value = row.Cells("BrideSurname").Value
							End If
						End If

				End Select

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomForenames").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideForenames").Index OrElse _
					 mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomFatherForenames").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideFatherForenames").Index OrElse _
					 mainDGV.CurrentCellAddress.X = mainDGV.Columns("Witness1Forenames").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("Witness2Forenames").Index Then
						If TypeOf (e.Control) Is CaseTextEditingControl Then
							Dim ctl As CaseTextEditingControl = e.Control
							ctl.TextCase = CaseText.CaseText.CaseType.ChristianNames
							ctl.Text = editcellInitialContents
							ctl.AutoCompleteCustomSource.Clear()
							ctl.AutoCompleteMode = AutoCompleteMode.None
							ctl.AutoCompleteSource = AutoCompleteSource.None
							EnableUCF(ctl)
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing MARRIAGES Names")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomSurname").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideSurname").Index OrElse _
					 mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomFatherSurname").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideFatherSurname").Index OrElse _
					 mainDGV.CurrentCellAddress.X = mainDGV.Columns("Witness1Surname").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("Witness2Surname").Index Then
						If TypeOf (e.Control) Is CaseTextEditingControl Then
							Dim ctl As CaseTextEditingControl = e.Control
							ctl.TextCase = CaseText.CaseText.CaseType.Upper
							ctl.Text = editcellInitialContents
							ctl.AutoCompleteCustomSource.Clear()
							ctl.AutoCompleteMode = AutoCompleteMode.None
							ctl.AutoCompleteSource = AutoCompleteSource.None
							EnableUCF(ctl)
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing MARRIAGES Surnames")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomParish").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomAbode").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomOccupation").Index OrElse _
					 mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideParish").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideAbode").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideOccupation").Index OrElse _
					 mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomFatherOccupation").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideFatherOccupation").Index OrElse _
					 mainDGV.CurrentCellAddress.X = mainDGV.Columns("Notes").Index Then
						If TypeOf (e.Control) Is CaseTextEditingControl Then
							Dim ctl As CaseTextEditingControl = e.Control
							ctl.TextCase = CaseText.CaseText.CaseType.Sentence
							ctl.Text = editcellInitialContents
							ctl.AutoCompleteCustomSource.Clear()
							ctl.AutoCompleteMode = AutoCompleteMode.None
							ctl.AutoCompleteSource = AutoCompleteSource.None
							EnableUCF(ctl)

							If mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomParish").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomAbode").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideParish").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideAbode").Index Then
								If My.Settings.MyAutofillFields Then
									ctl.AutoCompleteSource = AutoCompleteSource.CustomSource
									ctl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
									For Each s As String In acscAbodes
										ctl.AutoCompleteCustomSource.Add(s)
									Next
								End If
							End If

							If mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomOccupation").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideOccupation").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomFatherOccupation").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideFatherOccupation").Index Then
								If My.Settings.MyAutofillFields Then
									ctl.AutoCompleteSource = AutoCompleteSource.CustomSource
									ctl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
									For Each s As String In acscOccupations
										ctl.AutoCompleteCustomSource.Add(s)
									Next
								End If
							End If
							Return
						End If
					End If

				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing MARRIAGES Abodes or Occupations")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomCondition").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideCondition").Index Then
						If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
							Dim ctl As DataGridViewComboBoxEditingControl = e.Control
							ctl.DropDownStyle = ComboBoxStyle.DropDownList
							ctl.BackColor = Color.LightGreen
							Return
						End If
					End If

				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing MARRIAGES Conditions")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("MarriageDate").Index Then
						If TypeOf (e.Control) Is TextBox Then
							Dim ctl As TextBox = e.Control
							EnableDate(ctl)
							Return
						End If
					End If
				Catch ex As NullReferenceException
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing MARRIAGES Date")

				End Try

				Try
					If mainDGV.CurrentCellAddress.X = mainDGV.Columns("GroomAge").Index OrElse mainDGV.CurrentCellAddress.X = mainDGV.Columns("BrideAge").Index Then
						If TypeOf (e.Control) Is DataGridViewTextBoxEditingControl Then
							Dim ctl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)

							RemoveHandler ctl.KeyDown, New KeyEventHandler(AddressOf MarriageAge_HotkeyDetector)
							AddHandler ctl.KeyDown, New KeyEventHandler(AddressOf MarriageAge_HotkeyDetector)

							RemoveHandler ctl.KeyPress, New KeyPressEventHandler(AddressOf CompleteHotkeyText)
							AddHandler ctl.KeyPress, New KeyPressEventHandler(AddressOf CompleteHotkeyText)
							Return
						End If
					End If

				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing MARRIAGES Age")

				End Try

		End Select

		If ldsFile Then
			Try
				If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Fiche").Index Then
					If TypeOf (e.Control) Is CaseTextEditingControl Then
						Dim ctl As CaseTextEditingControl = e.Control
						ctl.TextCase = CaseText.CaseText.CaseType.Normal
						ctl.Text = editcellInitialContents
						EnableUCF(ctl)

						If My.Settings.MyAutofillFields Then
							ctl.AutoCompleteSource = AutoCompleteSource.CustomSource
							ctl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
							For Each s As String In acscFiche
								ctl.AutoCompleteCustomSource.Add(s)
							Next
							Return
						End If
					End If
				End If
			Catch ex As NullReferenceException
				My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing Fiche")

			End Try

			Try
				If mainDGV.CurrentCellAddress.X = mainDGV.Columns("Image").Index Then
					If TypeOf (e.Control) Is CaseTextEditingControl Then
						Dim ctl As CaseTextEditingControl = e.Control
						ctl.TextCase = CaseText.CaseText.CaseType.Normal
						ctl.Text = editcellInitialContents
						EnableUCF(ctl)

						If My.Settings.MyAutofillFields Then
							ctl.AutoCompleteSource = AutoCompleteSource.CustomSource
							ctl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
							For Each s As String In acscImage
								ctl.AutoCompleteCustomSource.Add(s)
							Next
							Return
						End If
					End If
				End If
			Catch ex As NullReferenceException
				My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while editing Image")

			End Try
		End If

	End Sub

	Private Sub mainDGV_HelpRequested(ByVal sender As Object, ByVal hlpevent As HelpEventArgs) Handles mainDGV.HelpRequested
		Dim cell = mainDGV.CurrentCellAddress()
		If cell.X <> -1 AndAlso cell.Y <> -1 Then
			hlpMain.SetShowHelp(sender, True)
			hlpMain.SetHelpNavigator(sender, HelpNavigator.Topic)
			Dim topic As String = String.Format("{0}.htm#{1}", _File.FileType, mainDGV.Columns(cell.X).Name)
			hlpMain.SetHelpKeyword(sender, topic)
			Console.WriteLine(String.Format("{0}: row:{1} column:{2} {3} - {4}", sender, cell.Y, cell.X, mainDGV.Columns(cell.X).Name, topic))
		ElseIf cell.X = -1 AndAlso cell.Y = -1 Then
		Else
		End If
	End Sub

	Private Sub mainDGV_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles mainDGV.RowHeaderMouseClick
		If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.Clicks = 1 Then
			If mainDGV.SelectedRows.Count > 0 Then
				If e.RowIndex = mainDGV.SelectedRows(0).Index Then
					If mainDGV.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
						Clipboard.SetDataObject(mainDGV.GetClipboardContent())
					End If
				End If
			End If
		End If
		bsDGV.Position = e.RowIndex
		'		mainDGV.FirstDisplayedScrollingRowIndex = bsDGV.Position
		mainDGV.Rows(bsDGV.Position).Selected = True
		'		mainDGV.CurrentCell = mainDGV.Item(mainDGV.FirstDisplayedScrollingColumnIndex, bsDGV.Position)
	End Sub

	Private Sub mainDGV_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles mainDGV.RowHeaderMouseDoubleClick
		If e.Button = Windows.Forms.MouseButtons.Left AndAlso e.Clicks = 2 Then
			If _OS.Version.Major >= 6 Then
				If Not winImageViewer Is Nothing Then
					If winImageViewer.IsVisible Then
						winImageViewer.Hide()
					End If
				End If
			Else
				If Not frmImageViewer Is Nothing Then
					If Not frmImageViewer.IsDisposed Then
						If frmImageViewer.Visible Then frmImageViewer.Hide()
					End If
				End If
			End If

			If [String].IsNullOrEmpty(mainDGV.Rows(e.RowIndex).ErrorText) Then
				DuplicateRecord(mainDGV.Rows(e.RowIndex))
			Else
				Dim workTable As BadRecordsDataTable = badRecords.Copy()
				Dim dataRow = mainDGV.Rows(e.RowIndex).DataBoundItem.Row
				Dim SelectedBadRecord As BadRecordsRow = workTable.FindByRowNumber(dataRow.LoadOrder + 1)
				Dim index As Integer = workTable.Rows.IndexOf(SelectedBadRecord)
				Dim dlg = New dlgEditBadRecord(SelectedBadRecord)
				Dim rc = dlg.ShowDialog()
				If rc = Windows.Forms.DialogResult.OK Then
					Dim OriginalBadRecord As BadRecordsRow = badRecords.Rows(index)
					If OriginalBadRecord.OriginalSource <> SelectedBadRecord.OriginalSource Then
						OriginalBadRecord.OriginalSource = SelectedBadRecord.OriginalSource
						OriginalBadRecord.csv = SelectedBadRecord.csv

						Dim nrow = mainDGV.Rows(e.RowIndex)
						Dim arow As String() = OriginalBadRecord.csv

						For fld As Integer = 0 To dataRow.ItemArray.Length - IIf(ldsFile, 1, 3)
							If fld < arow.Length Then
								dataRow.ItemArray(fld) = arow(fld)
							End If
						Next

						If TypeOf dataRow Is BaptismsRow Then
							If Not ((arow.Length = 15 AndAlso Not ldsFile) OrElse (ldsFile AndAlso arow.Length = 17)) Then
								OriginalBadRecord.ErrorMessage = String.Format("Incorrect number of fields. Got {1}. Should be {0}", IIf(ldsFile, 17, 15), arow.Length)
								nrow.DataBoundItem.Row.RowError = String.Format("Incorrect number of fields <{0}>", OriginalBadRecord.OriginalSource)
							Else
								nrow.DefaultCellStyle.BackColor = nrow.DefaultCellStyle.SelectionBackColor
								nrow.DefaultCellStyle.ForeColor = nrow.DefaultCellStyle.SelectionForeColor
								nrow.DataBoundItem.Row.RowError = String.Empty
								nrow.ReadOnly = False
								OriginalBadRecord.Delete()
							End If

						ElseIf TypeOf dataRow Is BurialsRow Then
							If Not ((arow.Length = 14 AndAlso Not ldsFile) OrElse (ldsFile AndAlso arow.Length = 16)) Then
								OriginalBadRecord.ErrorMessage = String.Format("Incorrect number of fields. Got {1}. Should be {0}", IIf(ldsFile, 16, 14), arow.Length)
								nrow.DataBoundItem.Row.RowError = String.Format("Incorrect number of fields <{0}>", OriginalBadRecord.OriginalSource)
							Else
								nrow.DefaultCellStyle.BackColor = nrow.DefaultCellStyle.SelectionBackColor
								nrow.DefaultCellStyle.ForeColor = nrow.DefaultCellStyle.SelectionForeColor
								nrow.DataBoundItem.Row.RowError = String.Empty
								nrow.ReadOnly = False
								OriginalBadRecord.Delete()
							End If

						ElseIf TypeOf dataRow Is MarriagesRow Then
							If Not ((arow.Length = 30 AndAlso Not ldsFile) OrElse (ldsFile AndAlso arow.Length = 32)) Then
								OriginalBadRecord.ErrorMessage = String.Format("Incorrect number of fields. Got {1}. Should be {0}", IIf(ldsFile, 32, 30), arow.Length)
								nrow.DataBoundItem.Row.RowError = String.Format("Incorrect number of fields <{0}>", OriginalBadRecord.OriginalSource)
							Else
								nrow.DefaultCellStyle.BackColor = nrow.DefaultCellStyle.SelectionBackColor
								nrow.DefaultCellStyle.ForeColor = nrow.DefaultCellStyle.SelectionForeColor
								nrow.DataBoundItem.Row.RowError = String.Empty
								nrow.ReadOnly = False
								OriginalBadRecord.Delete()
							End If

						End If

						fileChanged = True
					End If
					BindingNavigatorSaveFileButton.Enabled = fileOpen And fileChanged
				End If
			End If

			If _OS.Version.Major >= 6 Then
				If Not winImageViewer Is Nothing Then
					If Not winImageViewer.IsVisible Then
						winImageViewer.Show()
					End If
				End If
			Else
				If Not frmImageViewer Is Nothing Then
					If Not frmImageViewer.IsDisposed Then
						If Not frmImageViewer.Visible Then frmImageViewer.Show()
					End If
				End If
			End If
		End If
	End Sub

	Private Sub mainDGV_RowStateChanged(ByVal sender As Object, ByVal e As DataGridViewRowStateChangedEventArgs) Handles mainDGV.RowStateChanged
		If e.StateChanged = DataGridViewElementStates.Selected Then
			BindingNavigatorDuplicateRecord.Enabled = True
		End If
	End Sub

	Private Sub mainDGV_RowValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles mainDGV.RowValidated
		'		If My.Settings.MyAutofillFields Then
		Try
			Using row As DataGridViewRow = mainDGV.Rows(e.RowIndex)
				Select Case _File.FileType
					Case "BAPTISMS"
						AddStringToCollection(acscAbodes, row.Cells("Abode").Value)
						AddStringToCollection(acscOccupations, row.Cells("FathersOccupation").Value)
					Case "BURIALS"
						AddStringToCollection(acscAbodes, row.Cells("Abode").Value)
					Case "MARRIAGES"
						AddStringToCollection(acscAbodes, row.Cells("GroomParish").Value)
						AddStringToCollection(acscAbodes, row.Cells("GroomAbode").Value)
						AddStringToCollection(acscAbodes, row.Cells("BrideParish").Value)
						AddStringToCollection(acscAbodes, row.Cells("BrideAbode").Value)
						AddStringToCollection(acscOccupations, row.Cells("GroomOccupation").Value)
						AddStringToCollection(acscOccupations, row.Cells("BrideOccupation").Value)
						AddStringToCollection(acscOccupations, row.Cells("GroomFatherOccupation").Value)
						AddStringToCollection(acscOccupations, row.Cells("BrideFatherOccupation").Value)
				End Select
				If ldsFile Then
					AddStringToCollection(acscFiche, row.Cells("Fiche").Value)
					AddStringToCollection(acscImage, row.Cells("Image").Value)
				End If
			End Using

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while adding AutoCompletion string")

		End Try
		'		End If
	End Sub

	Private Sub mainDGV_RowValidating(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles mainDGV.RowValidating
		Dim row = mainDGV.Rows(e.RowIndex)
		Dim strDate As String = ""
		Dim errMsg As String = String.Empty
		Dim str As String = ""
		Dim strAge As String = ""
		Dim m() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}
		Dim mBirth() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}
		Dim mBaptism() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}

		Select Case _File.FileType
			Case "BAPTISMS"
				If Not IsDBNull(row.Cells("BirthDate").EditedFormattedValue.ToString()) Then strDate = row.Cells("BirthDate").EditedFormattedValue.ToString().Trim() Else strDate = ""
				errMsg = String.Empty
				If Not Validations.ValidateDate(strDate, errMsg, mBirth) Then
					row.Cells("BirthDate").ErrorText = errMsg
				Else
					row.Cells("BirthDate").ErrorText = String.Empty
					row.Cells("BirthDate").Value = strDate
				End If

				If Not IsDBNull(row.Cells("BaptismDate").EditedFormattedValue.ToString()) Then strDate = row.Cells("BaptismDate").EditedFormattedValue.ToString().Trim() Else strDate = ""
				errMsg = String.Empty
				If Not Validations.ValidateDate(strDate, errMsg, mBaptism) Then
					row.Cells("BaptismDate").ErrorText = errMsg
				Else
					row.Cells("BaptismDate").ErrorText = String.Empty
					row.Cells("BaptismDate").Value = strDate
				End If

				'	If both Birth and Baptism dates are given, the Baptism date should be on or after the Birth date
				'
				If row.Cells("BirthDate").ErrorText = String.Empty AndAlso row.Cells("BaptismDate").ErrorText = String.Empty Then
					If row.Cells("BirthDate").EditedFormattedValue.ToString() <> String.Empty AndAlso row.Cells("BaptismDate").EditedFormattedValue.ToString() <> String.Empty Then

						' TODO: This check fails when either date is double-dated, because DateTime doen't understand the date format
						'
						Try
							Dim dateBirth, dateBaptism As DateTime
							Dim fBirth, fBaptism As Boolean

							fBirth = DateTime.TryParse(row.Cells("BirthDate").EditedFormattedValue.ToString(), dateBirth)
							fBaptism = DateTime.TryParse(row.Cells("BaptismDate").EditedFormattedValue.ToString(), dateBaptism)
							If fBirth AndAlso fBaptism Then
								If dateBirth > dateBaptism Then
									row.Cells("BaptismDate").ErrorText = My.Resources.err0049
								End If
							Else
							End If

						Catch ex As Exception
							My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst Checking Birth and Baptism dates")
						End Try
					End If
				End If

				If row.Cells("Sex").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Sex").Value.ToString()) Then str = row.Cells("Sex").Value.ToString() Else str = ""
				If Not tabBapSex.Rows.Contains(str) Then
					row.Cells("Sex").ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Baptism Sex")
				Else
					row.Cells("Sex").ErrorText = String.Empty
					row.Cells("Sex").Value = str
				End If

			Case "BURIALS"
				'					row.Cells("BurialDate").Value = strDate
				If Not IsDBNull(row.Cells("BurialDate").EditedFormattedValue.ToString()) Then strDate = row.Cells("BurialDate").EditedFormattedValue.ToString().Trim() Else strDate = ""
				errMsg = String.Empty
				If Not Validations.ValidateDate(strDate, errMsg, m) Then
					row.Cells("BurialDate").ErrorText = errMsg
				Else
					row.Cells("BurialDate").ErrorText = String.Empty
					row.Cells("BurialDate").Value = strDate
				End If

				If Not IsDBNull(row.Cells("Age").EditedFormattedValue.ToString()) Then strAge = row.Cells("Age").EditedFormattedValue.ToString() Else strAge = ""
				errMsg = String.Empty
				If Not Validations.ValidateBurialAge(strAge, errMsg, False) Then
					' TODO: The over-100 message and condition is not really an error. Use a different warning-type icon
					row.Cells("Age").ErrorText = errMsg
				Else
					row.Cells("Age").ErrorText = String.Empty
				End If

				If row.Cells("Relationship").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Relationship").Value.ToString()) Then str = row.Cells("Relationship").Value.ToString() Else str = ""
				If Not tabBurialRelationship.Rows.Contains(str) Then
					row.Cells("Relationship").ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Burial Relationship")
				Else
					row.Cells("Relationship").ErrorText = String.Empty
					row.Cells("Relationship").Value = str
				End If

			Case "MARRIAGES"
				If Not IsDBNull(row.Cells("MarriageDate").EditedFormattedValue.ToString()) Then strDate = row.Cells("MarriageDate").EditedFormattedValue.ToString().Trim() Else strDate = ""
				errMsg = String.Empty
				If Not Validations.ValidateDate(strDate, errMsg, m) Then
					row.Cells("MarriageDate").ErrorText = errMsg
				Else
					row.Cells("MarriageDate").ErrorText = String.Empty
					row.Cells("MarriageDate").Value = strDate
				End If

				If Not IsDBNull(row.Cells("BrideAge").FormattedValue.ToString()) Then strAge = row.Cells("BrideAge").FormattedValue.ToString() Else strAge = ""
				errMsg = String.Empty
				If Not Validations.ValidateBrideAge(strAge, errMsg, False) Then
					row.Cells("BrideAge").ErrorText = errMsg
				Else
					row.Cells("BrideAge").ErrorText = String.Empty
				End If

				If row.Cells("BrideCondition").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("BrideCondition").Value.ToString()) Then str = row.Cells("BrideCondition").Value.ToString() Else str = ""
				If Not tabBrideCondition.Rows.Contains(str) Then
					row.Cells("BrideCondition").ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Bride Conditions")
				Else
					row.Cells("BrideCondition").ErrorText = String.Empty
					row.Cells("BrideCondition").Value = str
				End If

				If Not IsDBNull(row.Cells("GroomAge").FormattedValue.ToString()) Then strAge = row.Cells("GroomAge").FormattedValue.ToString() Else strAge = ""
				errMsg = String.Empty
				If Not Validations.ValidateGroomAge(strAge, errMsg, False) Then
					row.Cells("GroomAge").ErrorText = errMsg
				Else
					row.Cells("GroomAge").ErrorText = String.Empty
				End If

				If row.Cells("GroomCondition").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("GroomCondition").Value.ToString()) Then str = row.Cells("GroomCondition").Value.ToString() Else str = ""
				If Not tabGroomCondition.Rows.Contains(str) Then
					row.Cells("GroomCondition").ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Groom Conditions")
				Else
					row.Cells("GroomCondition").ErrorText = String.Empty
					row.Cells("GroomCondition").Value = str
				End If

		End Select

		If Not IsDBNull(row.Cells("Fiche").FormattedValue.ToString()) Then str = row.Cells("Fiche").FormattedValue.ToString() Else str = ""
		If str IsNot Nothing AndAlso str <> "" Then
			ldsFile = True
			'			My.Application.Log.WriteEntry(Now() + " RowValidating: Fiche: " + row.Cells("Fiche").FormattedValue.ToString(), TraceEventType.Information)
		End If

		If Not IsDBNull(row.Cells("Image").FormattedValue.ToString()) Then str = row.Cells("Image").FormattedValue.ToString() Else str = ""
		If str IsNot Nothing AndAlso str <> "" Then
			ldsFile = True
			'			My.Application.Log.WriteEntry(Now() + " RowValidating: Image: " + row.Cells("Image").FormattedValue.ToString(), TraceEventType.Information)
		End If

	End Sub

	'Private Sub mainDGV_SortCompare(ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs) Handles mainDGV.SortCompare

	'	'	Comparing two blank fields is a no-brainer
	'	'
	'	If e.CellValue1 = String.Empty AndAlso e.CellValue2 = String.Empty Then
	'		e.SortResult = 0
	'		e.Handled = True
	'		Return
	'	End If

	'	'	For the RegNo and LoadOrder fields, we have numbers to be compared
	'	'
	'	If e.Column.DataPropertyName = "RegNo" OrElse e.Column.DataPropertyName = "LoadOrder" Then
	'		Try
	'			Dim res1 As Integer, res2 As Integer
	'			Dim v1 = Integer.TryParse(e.CellValue1, res1)
	'			Dim v2 = Integer.TryParse(e.CellValue2, res2)

	'			If v1 AndAlso v2 Then
	'				If res1 < res2 Then e.SortResult = -1 Else If res1 = res2 Then e.SortResult = 0 Else e.SortResult = 1
	'			Else
	'				e.SortResult = String.Compare(e.CellValue1, e.CellValue2, True)
	'			End If

	'		Catch ex As Exception
	'			My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception while sorting Regno or LoadOrder columns")
	'		End Try

	'		e.Handled = True
	'		Return
	'	End If

	'	'	For dates, we have a lot of jiggery-pokery to go through in order to compare two fields
	'	'
	'	If e.Column.DataPropertyName.Contains("Date") Then
	'		Dim msg As String = ""
	'		Dim m1() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}
	'		Dim m2() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}

	'		'	One of the fields blank and the other non-blank is simple
	'		'
	'		If e.CellValue1.ToString() = String.Empty AndAlso e.CellValue2.ToString() <> String.Empty Then
	'			e.SortResult = -1
	'			e.Handled = True
	'			Return
	'		ElseIf e.CellValue1 <> String.Empty AndAlso e.CellValue2 = String.Empty Then
	'			e.SortResult = 1
	'			e.Handled = True
	'			Return
	'		End If

	'		Dim d1 As DateTime, d2 As DateTime
	'		If DateTime.TryParse(e.CellValue1.ToString(), d1) Then
	'			If DateTime.TryParse(e.CellValue2.ToString(), d2) Then
	'				e.SortResult = DateTime.Compare(d1, d2)
	'				e.Handled = True
	'				Return
	'			Else
	'			End If
	'		End If

	'		If e.CellValue1.ToString() <> String.Empty AndAlso Not ValidateDate(e.CellValue1.ToString(), msg, m1) Then
	'			If Not badDates.Contains(e.CellValue1.ToString()) Then
	'				badDates.Add(e.CellValue1.ToString())
	'			End If
	'		End If

	'		If e.CellValue2.ToString() <> String.Empty AndAlso Not ValidateDate(e.CellValue2.ToString(), msg, m2) Then
	'			If Not badDates.Contains(e.CellValue2.ToString()) Then
	'				badDates.Add(e.CellValue2.ToString())
	'			End If
	'		End If

	'		Dim date1 As String = ReformatDateString(m1)
	'		Dim date2 As String = ReformatDateString(m2)

	'		e.SortResult = String.Compare(date1, date2)
	'		e.Handled = True
	'		Return
	'	End If

	'End Sub

	Private Sub mainDGV_Sorted(ByVal sender As Object, ByVal e As EventArgs) Handles mainDGV.Sorted
		If Not badDates Is Nothing AndAlso badDates.Count >= 1 Then
			Dim strErr As New StringBuilder

			strErr.Append(My.Resources.err0037 & vbCrLf)
			For Each strDate As String In badDates
				strErr.Append(strDate & vbCrLf)
			Next
			strErr.Append(vbCrLf & My.Resources.err0038)
			MessageBox.Show(strErr.ToString(), "Bad Dates", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
		End If

		'mainDGV.FirstDisplayedCell = mainDGV.CurrentCell
		BindingNavigatorUnsortFileButton.Enabled = True
	End Sub

	Private Sub mainDGV_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mainDGV.SelectionChanged
		For counter = 0 To (mainDGV.SelectedCells.Count - 1)
			Dim row = mainDGV.SelectedCells(counter).RowIndex
			Dim col = mainDGV.SelectedCells(counter).ColumnIndex
		Next

	End Sub

	Private Sub mainDGV_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles mainDGV.MouseDown
		If e.Button = Windows.Forms.MouseButtons.Right Then
			Dim hit As DataGridView.HitTestInfo = mainDGV.HitTest(e.X, e.Y)
			If hit.Type = DataGridViewHitTestType.Cell Then
				cellRightClicked = mainDGV.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
			End If
		End If
	End Sub

	Private Sub mainDGV_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles mainDGV.RowPrePaint
		mainDGV.AutoResizeRow(e.RowIndex)
	End Sub

	'Private Sub mainDGV_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles mainDGV.RowsAdded
	'	Dim hpadding As Integer = 45
	'	Dim graphic As Graphics = mainDGV.CreateGraphics()
	'	mainDGV.RowHeadersWidth = graphic.MeasureString(mainDGV.RowCount.ToString(), mainDGV.RowHeadersDefaultCellStyle.Font).Width + hpadding
	'	graphic.Dispose()
	'	mainDGV.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

	'	For dr As Integer = 1 To e.RowCount
	'		mainDGV.Rows(e.RowIndex + dr - 1).HeaderCell.ValueType = System.Type.GetType("System.String")
	'		mainDGV.Rows(e.RowIndex + dr - 1).HeaderCell.Value = (e.RowIndex + dr).ToString()
	'	Next

	'	For dr As Integer = e.RowIndex + e.RowCount To mainDGV.Rows.Count - 1
	'		mainDGV.Rows(dr).HeaderCell.ValueType = System.Type.GetType("System.String")
	'		mainDGV.Rows(dr).HeaderCell.Value = (dr + 1).ToString()
	'	Next

	'End Sub

#End Region

#Region "DateViewColumn"

	'Class DateViewColumn
	'	Inherits DataGridViewColumn

	'	Public Sub New()
	'		MyBase.New(New DateCell())
	'	End Sub

	'	Public Overrides Property CellTemplate() As DataGridViewCell
	'		Get
	'			Return MyBase.CellTemplate
	'		End Get
	'		Set(ByVal value As DataGridViewCell)

	'			' Ensure that the cell used for the template is a CalendarCell.
	'			If (value IsNot Nothing) AndAlso Not value.GetType().IsAssignableFrom(GetType(DateCell)) Then
	'				Throw New InvalidCastException("Must be a DateCell")
	'			End If
	'			MyBase.CellTemplate = value

	'		End Set
	'	End Property

	'End Class

	'Class DateCell
	'	Inherits DataGridViewTextBoxCell

	'	Public Sub New()
	'		' Use the short date format.
	'		Me.Style.Format = "d"
	'	End Sub

	'	Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)

	'		' Set the value of the editing control to the current cell value.
	'		MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

	'		Dim ctl As DateEditingControl = CType(DataGridView.EditingControl, DateEditingControl)

	'		' Use the default row value when Value property is null.
	'		If (Me.Value Is Nothing) Then
	'			ctl.Text = String.Empty
	'		Else
	'			ctl.Text = CType(Me.Value, String)
	'		End If
	'	End Sub

	'	Public Overrides ReadOnly Property EditType() As Type
	'		Get
	'			Return GetType(DateEditingControl)
	'		End Get
	'	End Property

	'	Public Overrides ReadOnly Property ValueType() As Type
	'		Get
	'			Return GetType(String)
	'		End Get
	'	End Property

	'	Public Overrides ReadOnly Property DefaultNewRowValue() As Object
	'		Get
	'			Return String.Empty
	'		End Get
	'	End Property

	'End Class

	'Class DateEditingControl
	'	Inherits System.Windows.Forms.TextBox
	'	Implements IDataGridViewEditingControl

	'	Private dataGridViewControl As DataGridView
	'	Private valueIsChanged As Boolean = False
	'	Private rowIndexNum As Integer

	'	Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As System.Windows.Forms.DataGridViewCellStyle) Implements System.Windows.Forms.IDataGridViewEditingControl.ApplyCellStyleToEditingControl

	'	End Sub

	'	Public Property EditingControlDataGridView() As System.Windows.Forms.DataGridView Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlDataGridView
	'		Get
	'			Return dataGridViewControl
	'		End Get
	'		Set(ByVal value As System.Windows.Forms.DataGridView)
	'			dataGridViewControl = value
	'		End Set
	'	End Property

	'	Public Property EditingControlFormattedValue() As Object Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlFormattedValue
	'		Get
	'			Return Me.Text
	'		End Get
	'		Set(ByVal value As Object)
	'			Me.Text = value
	'		End Set
	'	End Property

	'	Public Property EditingControlRowIndex() As Integer Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlRowIndex
	'		Get
	'			Return rowIndexNum
	'		End Get
	'		Set(ByVal value As Integer)
	'			rowIndexNum = value
	'		End Set
	'	End Property

	'	Public Property EditingControlValueChanged() As Boolean Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlValueChanged
	'		Get
	'			Return valueIsChanged
	'		End Get
	'		Set(ByVal value As Boolean)
	'			valueIsChanged = value
	'		End Set
	'	End Property

	'	Public Function EditingControlWantsInputKey(ByVal keyData As System.Windows.Forms.Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlWantsInputKey

	'	End Function

	'	Public ReadOnly Property EditingPanelCursor() As System.Windows.Forms.Cursor Implements System.Windows.Forms.IDataGridViewEditingControl.EditingPanelCursor
	'		Get
	'			Return MyBase.Cursor
	'		End Get
	'	End Property

	'	Public Function GetEditingControlFormattedValue(ByVal context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object Implements System.Windows.Forms.IDataGridViewEditingControl.GetEditingControlFormattedValue
	'		Return Me.Text
	'	End Function

	'	Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements System.Windows.Forms.IDataGridViewEditingControl.PrepareEditingControlForEdit

	'	End Sub

	'	Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements System.Windows.Forms.IDataGridViewEditingControl.RepositionEditingControlOnValueChange
	'		Get
	'			Return False
	'		End Get
	'	End Property
	'End Class

#End Region

#Region "Exceptions"
	<Serializable()> _
	Public Class CancelFileOpenException
		Inherits Exception

		Public Sub New()
			' Add other code for custom properties here.
		End Sub

		Public Sub New(ByVal message As String)
			MyBase.New(message)
			' Add other code for custom properties here.
		End Sub

		Public Sub New(ByVal message As String, ByVal inner As Exception)
			MyBase.New(message, inner)
			' Add other code for custom properties here.
		End Sub

		Public Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
			MyBase.New(info, context)
			' Insert code here for custom properties here.
		End Sub
	End Class

	<Serializable()> _
	Public Class FilenameFormatException
		Inherits Exception

		Public Sub New()
			' Add other code for custom properties here.
		End Sub

		Public Sub New(ByVal message As String)
			MyBase.New(message)
			' Add other code for custom properties here.
		End Sub

		Public Sub New(ByVal message As String, ByVal inner As Exception)
			MyBase.New(message, inner)
			' Add other code for custom properties here.
		End Sub

		Public Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
			MyBase.New(info, context)
			' Insert code here for custom properties here.
		End Sub
	End Class
#End Region

#Region "ProgramOptions"
	Public Class ProgramOptions
		Public Sub New()
		End Sub

		Public Sub New(ByVal filtering As Boolean)
			boolFiltering = filtering
		End Sub

		Private _filtering As Boolean
		Public Property boolFiltering() As Boolean
			Get
				Return _filtering
			End Get
			Set(ByVal value As Boolean)
				_filtering = value
			End Set
		End Property
	End Class
#End Region

#Region "ColumnItems"
	Private Class ColumnItem
		Public Sub New()
		End Sub

		Private _name As String
		Private _datamember As String
		Private _operators As Collections.Specialized.StringCollection

		Public Sub New(ByVal objname As String)
			Name = objname
			DataMember = Name
			Operators = Nothing
		End Sub

		Public Sub New(ByVal objname As String, ByVal mbrname As String)
			Name = objname
			DataMember = mbrname
			Operators = Nothing
		End Sub

		Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				_name = value
			End Set
		End Property

		Property DataMember() As String
			Get
				Return _datamember
			End Get
			Set(ByVal value As String)
				_datamember = value
			End Set
		End Property

		Property Operators() As Collections.Specialized.StringCollection
			Get
				Return _operators
			End Get
			Set(ByVal value As Collections.Specialized.StringCollection)
				_operators = value
			End Set
		End Property

		Overrides Function ToString() As String
			Return Name
		End Function

	End Class
#End Region

#Region "SortComparer"
	Class CustomSortColComparer
		Implements IComparer(Of DataRow)

		Private accNoColName As String
		Private sortOrder As Windows.Forms.SortOrder

		Friend Sub New(ByVal accNoColName As String, ByVal sortOrder As Windows.Forms.SortOrder)
			'Store the name of the column on which custom sorting is to be performed & the sortOrder.
			Me.accNoColName = accNoColName
			Me.sortOrder = sortOrder
		End Sub

		Public Function Compare(ByVal row1 As DataRow, ByVal row2 As DataRow) As Integer Implements System.Collections.Generic.IComparer(Of DataRow).Compare
			'Extract the column values on which custom sorting is to be performed from the two rows.
			Dim compareresult
			Dim value1 As String = row1(Me.accNoColName)
			Dim value2 As String = row2(Me.accNoColName)

			'Provide your custom sort logic for comparing value1 & value2 here.
			'	Comparing two blank fields is a no-brainer
			'
			If value1 = String.Empty AndAlso value2 = String.Empty Then
				compareresult = 0
			Else
				'	For the RegNo and LoadOrder fields, we have numbers to be compared
				'
				If Me.accNoColName = "RegNo" OrElse Me.accNoColName = "LoadOrder" Then
					Dim res1 As Integer, res2 As Integer
					Dim v1 = Integer.TryParse(value1, res1)
					Dim v2 = Integer.TryParse(value2, res2)

					If v1 AndAlso v2 Then
						If res1 < res2 Then compareresult = -1 Else If res1 = res2 Then compareresult = 0 Else compareresult = 1
					Else
						compareresult = String.Compare(value1, value2, True)
					End If
				ElseIf Me.accNoColName.Contains("Date") Then
					'	For any Date field, this gets complicated
					'
					Dim msg As String = ""
					Dim m1() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}
					Dim m2() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}

					'	One of the fields blank and the other non-blank is simple
					'
					If value1 = String.Empty AndAlso value2 <> String.Empty Then
						compareresult = -1
					ElseIf value1 <> String.Empty AndAlso value2 = String.Empty Then
						compareresult = 1
					Else
						Dim d1 As DateTime, d2 As DateTime
						If DateTime.TryParse(value1, d1) Then
							If DateTime.TryParse(value2, d2) Then
								compareresult = DateTime.Compare(d1, d2)
							Else
								If value1 <> String.Empty AndAlso Not Validations.ValidateDate(value1, msg, m1) Then
									If Not WinREG.MainForm.badDates.Contains(value1) Then
										WinREG.MainForm.badDates.Add(value1)
									End If
								End If

								If value2 <> String.Empty AndAlso Not Validations.ValidateDate(value2, msg, m2) Then
									If Not WinREG.MainForm.badDates.Contains(value2) Then
										WinREG.MainForm.badDates.Add(value2)
									End If
								End If

								Dim date1 As String = WinREG.MainForm.ReformatDateString(m1)
								Dim date2 As String = WinREG.MainForm.ReformatDateString(m2)

								compareresult = String.Compare(date1, date2)
							End If
						Else
							If value1 <> String.Empty AndAlso Not Validations.ValidateDate(value1, msg, m1) Then
								If Not WinREG.MainForm.badDates.Contains(value1) Then
									WinREG.MainForm.badDates.Add(value1)
								End If
							End If

							If value2 <> String.Empty AndAlso Not Validations.ValidateDate(value2, msg, m2) Then
								If Not WinREG.MainForm.badDates.Contains(value2) Then
									WinREG.MainForm.badDates.Add(value2)
								End If
							End If

							Dim date1 As String = WinREG.MainForm.ReformatDateString(m1)
							Dim date2 As String = WinREG.MainForm.ReformatDateString(m2)

							compareresult = String.Compare(date1, date2)
						End If
					End If
				Else
					'	For general text strings this is easy
					'
					compareresult = String.Compare(value1, value2, True)
				End If
			End If

			'If sortOrder is descending, invert the compareResult sign.
			If (Me.sortOrder = Windows.Forms.SortOrder.Descending) Then compareresult = -compareresult
			Return (compareresult)
		End Function
	End Class
#End Region

#Region "Filtering Controls"

	Private Function AdjustDropDownWidth(ByVal senderComboBox As ComboBox) As Integer
		Dim Width As Integer = senderComboBox.DropDownWidth
		Dim g As Graphics = senderComboBox.CreateGraphics()
		Dim font As Font = senderComboBox.Font
		Dim vertScrollBarWidth As Integer = If(senderComboBox.Items.Count > senderComboBox.MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0)
		For Each c In senderComboBox.Items
			If TypeOf (c) Is ColumnItem Then
				Dim newWidth As Integer = g.MeasureString(c.Name, font).Width + vertScrollBarWidth
				If Width < newWidth Then
					Width = newWidth
				End If
			ElseIf TypeOf (c) Is String Then
				Dim newWidth As Integer = g.MeasureString(c, font).Width + vertScrollBarWidth
				If Width < newWidth Then
					Width = newWidth
				End If
			End If
		Next
		Return Width
	End Function

	Private Sub cbFilterColumns_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFilterColumns.DropDown
		cbFilterColumns.Items.Clear()
		cbFilterColumns.Items.Add(New ColumnItem("<None>", ""))
		cbFilterColumns.Items.Add(New ColumnItem("<Clear>", ""))
		For Each col As DataGridViewColumn In mainDGV.Columns
			If col.Visible Then
				If col.HeaderText <> "Notes" AndAlso col.HeaderText <> "Register number" AndAlso col.HeaderText <> "Place name" AndAlso col.HeaderText <> "Church name" Then
					If col.HeaderText.Contains("date") Then
						cbFilterColumns.Items.Add(New ColumnItem(col.HeaderText, col.DataPropertyName))
					Else
						If TypeOf (col) Is CaseTextColumn Then
							cbFilterColumns.Items.Add(New ColumnItem(col.HeaderText, col.DataPropertyName))
						Else
							Select Case _File.FileType
								Case "BAPTISMS"
									If col.HeaderText <> "Sex" Then
										cbFilterColumns.Items.Add(New ColumnItem(col.HeaderText, col.DataPropertyName))
									End If
								Case "BURIALS"
									If col.HeaderText <> "Relationship" Then
										cbFilterColumns.Items.Add(New ColumnItem(col.HeaderText, col.DataPropertyName))
									End If
								Case "MARRIAGES"
									If Not col.HeaderText.Contains("Condition") AndAlso Not col.HeaderText.Contains("Age") Then
										cbFilterColumns.Items.Add(New ColumnItem(col.HeaderText, col.DataPropertyName))
									End If
							End Select
						End If
					End If
				End If
			End If
		Next

		cbFilterColumns.DropDownWidth = AdjustDropDownWidth(cbFilterColumns.ComboBox)
		txtFilterString.Clear()
		cbFilterColumns.SelectedIndex = 0
	End Sub

	Private Sub cbFilterOperators_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFilterOperators.DropDown
		cbFilterOperators.Items.Clear()
		cbFilterOperators.Items.Add(New ColumnItem("IS", "="))
		cbFilterOperators.Items.Add(New ColumnItem("CONTAINS", "LIKE"))
		cbFilterOperators.SelectedIndex = 0
	End Sub

	Private Sub cbFilterValues_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFilterValues.DropDown
		cbFilterValues.Items.Clear()
		If cbFilterColumns.SelectedItem.Name = "<None>" Then
			txtFilterString.Clear()
			bsDGV.RemoveFilter()
		ElseIf cbFilterColumns.SelectedItem.Name = "<Clear>" Then
			txtFilterString.Clear()
			bsDGV.RemoveFilter()
		Else
			cbFilterValues.Items.AddRange(New String() {"<All>"})
			For Each row In bsDGV.DataSource.Rows
				If Not String.IsNullOrEmpty(row.Item(cbFilterColumns.SelectedItem.DataMember)) Then
					If Not cbFilterValues.Items.Contains(row.Item(cbFilterColumns.SelectedItem.DataMember)) Then cbFilterValues.Items.Add(row.Item(cbFilterColumns.SelectedItem.DataMember))
				End If
			Next
			cbFilterValues.DropDownWidth = AdjustDropDownWidth(cbFilterValues.ComboBox)
			cbFilterValues.SelectedIndex = 0
		End If
	End Sub

	Private Sub cbFilterValues_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFilterValues.SelectedIndexChanged
		If cbFilterValues.SelectedIndex = -1 OrElse cbFilterOperators.SelectedIndex = -1 Then Return

		If cbFilterValues.SelectedItem = "<All>" Then
			txtFilterString.Clear()
			bsDGV.RemoveFilter()
		Else
			txtFilterString.Text = String.Format("{0} {1} '{2}'", cbFilterColumns.SelectedItem.DataMember, cbFilterOperators.SelectedItem.DataMember, cbFilterValues.SelectedItem)
			bsDGV.Filter = txtFilterString.Text
		End If
	End Sub

	'Private Sub lblShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShowAll.Click
	'	DataGridViewAutoFilterTextBoxColumn.RemoveFilter(mainDGV)
	'End Sub

#End Region

#Region "Drag and Drop"

	Private Sub mainDGV_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles mainDGV.DragEnter
		e.Effect = DragDropEffects.None
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
			If files.Length = 1 Then
				If files(0).EndsWith(".CSV", True, Nothing) Then
					e.Effect = DragDropEffects.Copy
				End If
			End If
		End If
	End Sub

	Private Sub mainDGV_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles mainDGV.DragDrop
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
			If files.Length = 1 Then
				If files(0).EndsWith(".CSV", True, Nothing) Then
					If MessageBox.Show(String.Format(My.Resources.msgCloseAndOpenDroppedFile, files(0)), "Open Alternative File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
						If fileOpen Then CloseTranscriptionFile(CloseReason.None)
						OpenTranscriptionFile(files(0))
					End If
				End If
			End If
		End If
	End Sub

	Private Sub mainWelcomeText_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles mainWelcomeText.DragEnter
		e.Effect = DragDropEffects.None
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
			If files.Length = 1 Then
				If files(0).EndsWith(".CSV", True, Nothing) Then
					e.Effect = DragDropEffects.Copy
				End If
			End If
		End If
	End Sub

	Private Sub mainWelcomeText_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles mainWelcomeText.DragDrop
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
			If files.Length = 1 Then
				If files(0).EndsWith(".CSV", True, Nothing) Then
					If MessageBox.Show(String.Format(My.Resources.msgOpenDroppedFile, files(0)), "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
						If fileOpen Then CloseTranscriptionFile(CloseReason.None)
						OpenTranscriptionFile(files(0))
					End If
				End If
			End If
		End If
	End Sub

#End Region

#Region "FileSystemWatcher"

	Private Shared Sub TranscriptsDeleted(ByVal source As Object, ByVal e As FileSystemEventArgs) Handles fswTranscripts.Deleted
		' Specify what is done when a file is deleted.
		If e.ChangeType = WatcherChangeTypes.Deleted Then
			If fileOpen Then
				If [String].Compare(_File.Pathname, e.FullPath, True) = 0 Then
					My.Application.Log.WriteEntry(String.Format("TranscriptDeleted: Filename:{0} is open", e.Name), TraceEventType.Information)
				Else
					My.Application.Log.WriteEntry(String.Format("TranscriptDeleted: Filename:{0}", e.Name), TraceEventType.Information)
				End If
			Else
				My.Application.Log.WriteEntry(String.Format("TranscriptDeleted: Filename:{0} No file open", e.Name), TraceEventType.Information)
			End If
		Else
			My.Application.Log.WriteEntry(String.Format("TranscriptDeleted: Unexpected Action:{0} on Filename:{1} Path:{2}", e.ChangeType.ToString, e.Name, e.FullPath), TraceEventType.Information)
		End If
	End Sub

	Private Shared Sub TranscriptsCreated(ByVal source As Object, ByVal e As FileSystemEventArgs) Handles fswTranscripts.Created
		' Specify what is done when a file is created.
		If e.ChangeType = WatcherChangeTypes.Created Then
			If fileOpen Then
				If [String].Compare(_File.Pathname, e.FullPath, True) = 0 Then
					My.Application.Log.WriteEntry(String.Format("TranscriptCreated: Filename:{0} is open", e.Name), TraceEventType.Information)
				Else
					My.Application.Log.WriteEntry(String.Format("TranscriptCreated: Filename:{0}", e.Name), TraceEventType.Information)
				End If
			Else
				My.Application.Log.WriteEntry(String.Format("TranscriptCreated: Filename:{0} No file open", e.Name), TraceEventType.Information)
			End If
		Else
			My.Application.Log.WriteEntry(String.Format("TranscriptCreated: Unexpected Action:{0} on Filename:{1} Path:{2}", e.ChangeType.ToString, e.Name, e.FullPath), TraceEventType.Information)
		End If
	End Sub

	Private Shared Sub TranscriptsChanged(ByVal source As Object, ByVal e As FileSystemEventArgs) Handles fswTranscripts.Changed
		' Specify what is done when a file is changed.
		If e.ChangeType = WatcherChangeTypes.Changed Then
			If fileOpen Then
				If [String].Compare(_File.Pathname, e.FullPath, True) = 0 Then
					My.Application.Log.WriteEntry(String.Format("TranscriptChanged: Filename:{0} is open", e.Name), TraceEventType.Information)
				Else
					My.Application.Log.WriteEntry(String.Format("TranscriptChanged: Filename:{0}", e.Name), TraceEventType.Information)
				End If
			Else
				My.Application.Log.WriteEntry(String.Format("TranscriptChanged: Filename:{0} No file open", e.Name), TraceEventType.Information)
			End If
		Else
			My.Application.Log.WriteEntry(String.Format("TranscriptChanged: Unexpected Action:{0} on Filename:{1} Path:{2}", e.ChangeType.ToString, e.Name, e.FullPath), TraceEventType.Information)
		End If
	End Sub

	Private Shared Sub TranscriptsRenamed(ByVal source As Object, ByVal e As RenamedEventArgs) Handles fswTranscripts.Renamed
		' Specify what is done when a file is renamed.
		If e.ChangeType = WatcherChangeTypes.Renamed Then
			If fileOpen Then
				If [String].Compare(_File.Pathname, e.OldFullPath, True) = 0 Then
					My.Application.Log.WriteEntry(String.Format("TranscriptRenamed: Filename:{0} Old:{1} is open", e.Name, e.OldName), TraceEventType.Information)
				Else
					My.Application.Log.WriteEntry(String.Format("TranscriptRenamed: Filename:{0} Old:{1}", e.Name, e.OldName), TraceEventType.Information)
				End If
			Else
				My.Application.Log.WriteEntry(String.Format("TranscriptRenamed: Filename:{0} Old:{1} No file open", e.Name, e.OldName), TraceEventType.Information)
			End If
		Else
			My.Application.Log.WriteEntry(String.Format("TranscriptRenamed: Unexpected Action:{0} on Filename:{1} Path:{2} and {3} Path:{4}", e.ChangeType.ToString, e.OldName, e.OldFullPath, e.Name, e.FullPath), TraceEventType.Information)
		End If
	End Sub

#End Region

#Region "UserDetails"
	Class UserDetails

		Private _Username As String
		Public Property Username() As String
			Get
				Return _Username
			End Get
			Set(ByVal value As String)
				_Username = value
			End Set
		End Property

		Private _Password As String
		Public Property Password() As String
			Get
				Return _Password
			End Get
			Set(ByVal value As String)
				_Password = value
			End Set
		End Property

		Private _IsAdministrator As Boolean
		Public Property IsAdministrator() As Boolean
			Get
				Return _IsAdministrator
			End Get
			Set(ByVal value As Boolean)
				_IsAdministrator = value
			End Set
		End Property

		Public Sub New()
			If TypeOf My.User.CurrentPrincipal Is Security.Principal.WindowsPrincipal Then
				' The application is using Windows authentication.
				' The name format is DOMAIN\USERNAME.
				Dim parts() As String = Split(My.User.Name, "\")
				Dim username As String = parts(1)
				Me.Username = username
			Else
				' The application is using custom authentication.
				Me.Username = My.User.Name
			End If
			Me.Password = String.Empty
			Me.IsAdministrator = My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Or My.User.IsInRole("Administrators")
		End Sub

	End Class

#End Region

End Class
