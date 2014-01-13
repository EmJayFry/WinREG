'	$Date: 2012-08-22 11:10:14 +0200 (Wed, 22 Aug 2012) $
'	$Rev: 174 $
'	$Id: dlgOptions.vb 174 2012-08-22 09:10:14Z Mikefry $
'
'	WinREG/3 - Version 3.1.10
'

Imports System.IO
Imports System.Runtime.InteropServices

Imports WinREG.MainForm
Imports WinREG.FreeRegBrowser

Public Class dlgOptions

	Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
		DialogResult = DialogResult.OK

		'If fileOpen Then
		'	If MainForm._File.Username <> My.Settings.Name OrElse MainForm._File.EmailAddress <> My.Settings.EmailAddress Then
		'		If MessageBox.Show(String.Format(My.Resources.msgUpdateHeader, MainForm._File.Filename, "that you currently have opened", MainForm._File.Username, MainForm._File.EmailAddress), "Opening File", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then
		'			MainForm._File.Username = My.Settings.Name
		'			MainForm._File.EmailAddress = My.Settings.EmailAddress
		'			fileChanged = True
		'		End If
		'	End If
		'End If

		If Not MainForm.FreeRegbrowser.FreeREG_Id = txtFreeREG_Id.Text Then
			MainForm.FreeRegbrowser.FreeREG_Id = txtFreeREG_Id.Text
		End If

		If Not MainForm.FreeRegbrowser.FreeREG_Password = txtFreeREG_Password.Text Then
			MainForm.FreeRegbrowser.FreeREG_Password = txtFreeREG_Password.Text
		End If

		If Not My.Settings.DataFolderName = txtDataFolder.Text Then
			'
			'	Move files and subdirectories from "My.Settings.DataFolderName" to "txtDataFolder.Text"
			'
			Dim listFiles = My.Computer.FileSystem.GetFiles(My.Settings.DataFolderName, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
			For Each foundFile As String In listFiles
				Try
					Dim foundFileInfo As New FileInfo(foundFile)
					If foundFileInfo.FullName <> My.Application.Log.DefaultFileLogWriter.FullLogFileName Then
						Dim destFile = foundFileInfo.FullName.Replace(My.Settings.DataFolderName, txtDataFolder.Text)
						txtOperation.Text = String.Format("Moving {0} to {1}", foundFile, destFile)
						txtOperation.Update()
						My.Computer.FileSystem.MoveFile(foundFile, destFile, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
					Else
						Beep()
					End If

				Catch ex As Exception
					Dim msgText As String = ex.Message
					MessageBox.Show(msgText, "Change Data Folder - Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				End Try
			Next

			MessageBox.Show(String.Format("The transcripts data folder ({0}) and it's contents have been moved to {1}", My.Settings.DataFolderName, txtDataFolder.Text), "Data Folder Changed", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

			'	Remove old value (My.Settings.DataFolderName) from FreeREGbrowser list
			'
			MainForm.FreeRegbrowser.RemovePath(My.Settings.DataFolderName)

			'	Add new value (txtDataFolder.Text) to the FreeREGbrowser list
			'
			MainForm.FreeRegbrowser.TranscriptsPath = txtDataFolder.Text

			My.Settings.DataFolderName = txtDataFolder.Text
		End If

		If Not My.Settings.BackupFolderName = txtBackupsFolder.Text Then
			'
			'	Move files and subdirectories from "My.Settings.BackupFolderName" to "txtBackupsFolder.Text"
			'
			Dim listFiles = My.Computer.FileSystem.GetFiles(My.Settings.BackupFolderName, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
			For Each foundFile As String In listFiles
				Try
					Dim foundFileInfo As New FileInfo(foundFile)
					Dim destFile = foundFileInfo.FullName.Replace(My.Settings.BackupFolderName, txtBackupsFolder.Text)
					txtOperation.Text = String.Format("Moving {0} to {1}", foundFile, destFile)
					txtOperation.Update()
					My.Computer.FileSystem.MoveFile(foundFile, destFile, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

				Catch ex As Exception
					Dim msgText As String = ex.Message
					MessageBox.Show(msgText, "Change Backup Folder - Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				End Try
			Next

			MessageBox.Show(String.Format("The transcripts backup folder ({0}) and it's contents have been moved to {1}", My.Settings.BackupFolderName, txtBackupsFolder.Text), "Backup Folder Changed", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			My.Settings.BackupFolderName = txtBackupsFolder.Text

		End If

		If Not My.Settings.ImageFolderName = txtImagesFolder.Text Then
			My.Settings.ImageFolderName = txtImagesFolder.Text
		End If
		Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

	Private Sub dlgOptions_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		Location = My.Settings.MyOptionsLocation
		WindowState = My.Settings.MyOptionsWindowState
		tabOptions.SelectedIndex = My.Settings.MyOptionsTab
		txtDataFolder.Text = My.Settings.DataFolderName
		txtBackupsFolder.Text = My.Settings.BackupFolderName
		txtImagesFolder.Text = My.Settings.ImageFolderName
		txtFreeREG_Id.Text = MainForm.FreeRegbrowser.FreeREG_Id
		txtFreeREG_Password.Text = MainForm.FreeRegbrowser.FreeREG_Password

		If My.Settings.MyDisplayTooltips Then ttOptions.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
		mtbMRUSize.Text = My.Settings.MyMRUSize.ToString()

		tabOptions.TabPages.Remove(tabSystemPage)

		' If we're running on a version of Windows prior to Vista, then we
		' need the ability to check if the Program/CVS file association is
		' active and allow the user to remove it
		'
		'If MainForm._OS.Version.Major < 6 Then
		'Else
		'	btnRemoveAssociations.Enabled = True
		'	btnRemoveAssociations.Visible = True
		'End If

	End Sub

	Private Sub dlgOptions_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
		My.Settings.MyMRUSize = Integer.Parse(mtbMRUSize.Text())
		My.Settings.MyOptionsTab = tabOptions.SelectedIndex
		My.Settings.MyOptionsWindowState = WindowState
		If WindowState = FormWindowState.Normal Then
			My.Settings.MyOptionsLocation = Location
		Else
			My.Settings.MyOptionsLocation = RestoreBounds.Location
		End If
	End Sub

	Private Sub btnBrowseDataFolder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowseDataFolder.Click
		fbdFolderBrowser.Description = "Select the default location of the Transcriptions Data Folder"
		fbdFolderBrowser.RootFolder = Environment.SpecialFolder.Desktop
		fbdFolderBrowser.SelectedPath = txtDataFolder.Text
		fbdFolderBrowser.ShowNewFolderButton = True
		If fbdFolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
			txtDataFolder.Text = fbdFolderBrowser.SelectedPath
		End If
	End Sub

	Private Sub btnBrowseBackupsFolder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowseBackupsFolder.Click
		fbdFolderBrowser.Description = "Select the default location of the Transcriptions Backups Folder"
		fbdFolderBrowser.RootFolder = Environment.SpecialFolder.Desktop
		fbdFolderBrowser.SelectedPath = txtBackupsFolder.Text
		fbdFolderBrowser.ShowNewFolderButton = True
		If fbdFolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
			txtBackupsFolder.Text = fbdFolderBrowser.SelectedPath
		End If
	End Sub

	Private Sub btnBrowseImagesFolder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowseImagesFolder.Click
		fbdFolderBrowser.Description = "Select the default location of the Images Folder"
		fbdFolderBrowser.RootFolder = Environment.SpecialFolder.Desktop
		fbdFolderBrowser.SelectedPath = txtImagesFolder.Text
		fbdFolderBrowser.ShowNewFolderButton = False
		If fbdFolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
			txtImagesFolder.Text = fbdFolderBrowser.SelectedPath
		End If
	End Sub

	Private Sub chkEnableTooltips_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkEnableTooltips.CheckedChanged
		If chkEnableTooltips.CheckState = CheckState.Checked Then
			lblTooltips1.Visible = True
			lblTooltips2.Visible = True
			nupTooltips.Visible = True
			nupTooltips.Enabled = True
		Else
			lblTooltips1.Visible = False
			lblTooltips2.Visible = False
			nupTooltips.Visible = False
			nupTooltips.Enabled = False
		End If
	End Sub

	Private Sub Folder_Validating(ByVal sender As Object, ByVal e As CustomValidation.CustomValidator.ValidatingCancelEventArgs) Handles cstmDataFolder.Validating, cstmImagesFolder.Validating, cstmBackupsFolder.Validating
		If e.ControlToValidate.Text <> String.Empty Then
			e.Valid = Directory.Exists(e.ControlToValidate.Text)
			If Not e.Valid Then
				If MessageBox.Show(My.Resources.msgCreateDirectory, "Folder Selection", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
					Try
						Directory.CreateDirectory(e.ControlToValidate.Text)
						e.Valid = True

					Catch ex As UnauthorizedAccessException
						MessageBox.Show(ex.Message, "Create Directory", MessageBoxButtons.OK, MessageBoxIcon.Stop)

					Catch ex As Exception
						MessageBox.Show(ex.Message, "Create Directory Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					End Try
				End If
			End If
		Else
			e.Valid = True
		End If
	End Sub

	Private Sub tabOptions_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tabOptions.SelectedIndexChanged
		If tabOptions.SelectedTab.Name = "tabMyInformationPage" Then
		ElseIf tabOptions.SelectedTab.Name = "tabDataEntry" Then
			If _User.Username = "Mikefry" Then
				chkEnableFiltering.Visible = True
				chkEnableFiltering.Checked = _Options.boolFiltering
			End If
		ElseIf tabOptions.SelectedTab.Name = "tabFoldersPage" Then
			If WinREG.MainForm.fileOpen = True Then
				tabFoldersPage.Enabled = False
				lblFileOpen.Visible = True
			End If
		ElseIf tabOptions.SelectedTab.Name = "tabColoursAndFonts" Then
			txtCellFont.Text = String.Format("{0}, {1}pt", My.Settings.MyCellFont.Name, My.Settings.MyCellFont.SizeInPoints)

			For Each aColorName As String In System.Enum.GetNames(GetType(KnownColor))
				cbColourNormal.Items.Add(Color.FromName(aColorName))
				cbColourAlternate.Items.Add(Color.FromName(aColorName))
			Next
			cbColourNormal.SelectedItem = My.Settings.MyCellColour
			cbColourAlternate.SelectedItem = My.Settings.MyAlternateCellColour

			'ElseIf tabOptions.SelectedTab.Name = "tabSystemPage" Then
			'	' Get System Information for the current machine.
			'	lbSystemInformation.Items.Add("ComputerName : " + SystemInformation.ComputerName)
			'	lbSystemInformation.Items.Add("Network  : " + SystemInformation.Network.ToString())
			'	lbSystemInformation.Items.Add("UserDomainName  : " + SystemInformation.UserDomainName)
			'	lbSystemInformation.Items.Add("UserName   : " + SystemInformation.UserName)
			'	lbSystemInformation.Items.Add("BootMode : " + SystemInformation.BootMode.ToString())
			'	lbSystemInformation.Items.Add("MenuFont : " + SystemInformation.MenuFont.ToString())
			'	lbSystemInformation.Items.Add("MonitorCount : " + SystemInformation.MonitorCount.ToString())
			'	lbSystemInformation.Items.Add("MonitorsSameDisplayFormat : " + SystemInformation.MonitorsSameDisplayFormat.ToString())
			'	lbSystemInformation.Items.Add("ArrangeDirection: " + SystemInformation.ArrangeDirection.ToString())
			'	lbSystemInformation.Items.Add("MousePresent : " + SystemInformation.MousePresent.ToString())
			'	lbSystemInformation.Items.Add("MouseButtonsSwapped    : " + SystemInformation.MouseButtonsSwapped.ToString())
			'	lbSystemInformation.Items.Add("UserInteractive    : " + SystemInformation.UserInteractive.ToString())
			'	lbSystemInformation.Items.Add("VirtualScreen: " + SystemInformation.VirtualScreen.ToString())
		End If

	End Sub

	Private Sub txtDataFolder_MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles txtDataFolder.MouseHover
		If My.Settings.DataFolderName = String.Empty Then
			ttOptions.SetToolTip(txtDataFolder, "The default place to store Transcription files")
		Else
			ttOptions.SetToolTip(txtDataFolder, My.Settings.DataFolderName)
		End If
	End Sub

	Private Sub txtBackupsFolder_MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles txtBackupsFolder.MouseHover
		If My.Settings.BackupFolderName = String.Empty Then
			ttOptions.SetToolTip(txtBackupsFolder, "The default place to store Backups")
		Else
			ttOptions.SetToolTip(txtBackupsFolder, My.Settings.BackupFolderName)
		End If
	End Sub

	Private Sub txtImagesFolder_MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles txtImagesFolder.MouseHover
		If My.Settings.ImageFolderName = String.Empty Then
			ttOptions.SetToolTip(txtImagesFolder, "The default place to find Images")
		Else
			ttOptions.SetToolTip(txtBackupsFolder, My.Settings.ImageFolderName)
		End If
	End Sub

	Private Sub ttOptions_Popup(ByVal sender As Object, ByVal e As PopupEventArgs) Handles ttOptions.Popup
		If tabOptions.SelectedTab.Name = "tabMyInformationPage" Then
			If e.AssociatedControl.Name = "txtName" Then
				ttOptions.ToolTipTitle = "Name"
			ElseIf e.AssociatedControl.Name = "txtEmailAddress" Then
				ttOptions.ToolTipTitle = "Email Address"
			ElseIf e.AssociatedControl.Name = "cbSyndicate" Then
				ttOptions.ToolTipTitle = "Syndicate"
			ElseIf e.AssociatedControl.Name = "txtFreeREG_Id" Then
				ttOptions.ToolTipTitle = "FreeREG User Id."
			ElseIf e.AssociatedControl.Name = "txtFreeREG_Password" Then
				ttOptions.ToolTipTitle = "FreeREG Password"
			End If
		ElseIf tabOptions.SelectedTab.Name = "tabDataEntry" Then
			If TypeOf (e.AssociatedControl) Is CheckBox Then
				ttOptions.ToolTipTitle = e.AssociatedControl.Text
			ElseIf e.AssociatedControl.Name = "mtbMRUSize" Then
				ttOptions.ToolTipTitle = "MRU Size"
			Else
				ttOptions.ToolTipTitle = "DisplayTime"
			End If
		ElseIf tabOptions.SelectedTab.Name = "tabFoldersPage" Then
			If e.AssociatedControl.Name = "txtDataFolder" Then
				ttOptions.ToolTipTitle = "Data Folder"
			ElseIf e.AssociatedControl.Name = "txtBackupsFolder" Then
				ttOptions.ToolTipTitle = "Backups Folder"
			ElseIf e.AssociatedControl.Name = "txtImagesFolder" Then
				ttOptions.ToolTipTitle = "Images Folder"
				'ElseIf e.AssociatedControl.Name = "btnRemoveAssociations" Then
				'	ttOptions.ToolTipTitle = "Remove File Associations"
			End If
			'ElseIf tabOptions.SelectedTab.Name = "tabSystemPage" Then
			'	ttOptions.ToolTipTitle = "System Information"
		End If
	End Sub

	Private Sub ListBox1_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles lbSystemInformation.DrawItem
		If e.Index = -1 Then Return
		e.DrawBackground()
		e.Graphics.DrawString(lbSystemInformation.Items(e.Index).ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault)
		e.DrawFocusRectangle()
	End Sub

	'Private Sub btnRemoveAssociations_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemoveAssociations.Click
	'	If MainForm._OS.Version.Major < 6 Then
	'		CreateFileAssociation(".csv", "FreeREGTranscript", "FreeREG Transcription File", Application.ExecutablePath)
	'	Else
	'		Try
	'			'System.Windows.DefaultApplications.ClearUserAssociations()
	'			'System.Windows.DefaultApplications.ShowAssociationsWindow("WinREG for Windows")
	'		Catch ex As Exception
	'			MessageBox.Show(ex.Message, "Set Program Defaults", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
	'		End Try
	'	End If
	'End Sub


	' Create the new file association
	'
	' Extension is the extension to be registered (eg ".cvs"
	' ClassName is the name of the associated class (eg "CADDoc")
	' Description is the textual description (eg "CVS Document"
	' ExeProgram is the app that manages that extension (eg "c:\Cad\MyCad.exe")

	Function CreateFileAssociation(ByVal extension As String, ByVal className As String, ByVal description As String, ByVal exeProgram As String) As Boolean
		Const SHCNE_ASSOCCHANGED = &H8000000
		Const SHCNF_IDLIST = 0

		' ensure that there is a leading dot
		If extension.Substring(0, 1) <> "." Then
			extension = "." & extension
		End If

		Dim fa = New FileAssociation
		fa.SetFileType(extension, className)
		fa.SetFileDescription(className, description)
		fa.AddAction(className, "open", "Open")
		fa.SetExtensionCommandLine("open", className, exeProgram & " ""%1"" ")
		fa.SetDefaultAction(className, "open")
		fa.SetDefaultIcon(className, "")

		' notify Windows that file associations have changed
		Win32.SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_IDLIST, 0, 0)
		Return True
	End Function

	Private Sub cbColor_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles cbColourNormal.DrawItem, cbColourAlternate.DrawItem
		If e.Index < 0 Then
			e.DrawBackground()
			e.DrawFocusRectangle()
			Exit Sub
		End If

		Dim aColor As Color = CType(cbColourNormal.Items(e.Index), Color)
		Dim rect As Rectangle = New Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4)
		Dim br As Brush

		e.DrawBackground()
		e.DrawFocusRectangle()

		If e.State = Windows.Forms.DrawItemState.Selected Then
			br = Brushes.White
		Else
			br = Brushes.Black
		End If

		e.Graphics.DrawRectangle(New Pen(aColor), rect)
		e.Graphics.FillRectangle(New SolidBrush(aColor), rect)
		rect.Inflate(1, 1)
		e.Graphics.DrawRectangle(Pens.Black, rect)
		e.Graphics.DrawString(aColor.Name, cbColourNormal.Font, Brushes.Brown, e.Bounds.Height + 5, ((e.Bounds.Height - cbColourNormal.Font.Height) \ 2) + e.Bounds.Top)
	End Sub

	Private Sub cbColourNormal_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbColourNormal.SelectedIndexChanged
		My.Settings.MyCellColour = cbColourNormal.SelectedItem()
	End Sub

	Private Sub cbColourAlternate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbColourAlternate.SelectedIndexChanged
		My.Settings.MyAlternateCellColour = cbColourAlternate.SelectedItem()
	End Sub

	Private Sub btnRestoreDefaults_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRestoreDefaults.Click
		cbColourNormal.SelectedItem = My.Settings.DefaultCellColour
		cbColourAlternate.SelectedItem = My.Settings.DefaultAlternateCellColour
		My.Settings.MyCellFont = My.Settings.DefaultCellFont
		txtCellFont.Text = String.Format("{0}, {1}pt", My.Settings.MyCellFont.Name, My.Settings.MyCellFont.SizeInPoints)
	End Sub

	Private Sub btnCellFont_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCellFont.Click
		fdDefaultCellFont.Font = My.Settings.MyCellFont
		If fdDefaultCellFont.ShowDialog() = Windows.Forms.DialogResult.OK Then
			My.Settings.MyCellFont = fdDefaultCellFont.Font
			txtCellFont.Text = String.Format("{0}, {1}pt", My.Settings.MyCellFont.Name, My.Settings.MyCellFont.SizeInPoints)
		End If
	End Sub

	Private Sub chkEnableFiltering_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableFiltering.CheckedChanged
		_Options.boolFiltering = chkEnableFiltering.Checked
		WinREG.MainForm.mnuToolsFiltering.Visible = _Options.boolFiltering
		If WinREG.MainForm.fileOpen Then WinREG.MainForm.mnuToolsFiltering.Checked = _Options.boolFiltering
	End Sub

End Class

#Region "Win32 Functions Class"
Friend Class Win32

	<DllImport("shell32.dll")> Shared Sub SHChangeNotify(ByVal wEventId As Integer, ByVal uFlags As Integer, ByVal dwItem1 As Integer, ByVal dwItem2 As Integer)
	End Sub

End Class
#End Region

