'	$Date: 2013-12-07 09:43:24 +0200 (Sat, 07 Dec 2013) $
'	$Rev: 279 $
'	$Id: FreeRegBrowser.vb 279 2013-12-07 07:43:24Z Mikefry $
'
'	FreeRegBrowser - Version 1.0.7
'

Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports WinREG.ErrorFileCreated
'Imports WinREG

Public Class FreeRegBrowser
	Inherits System.Windows.Forms.Form

	Private fLoggedIn As Boolean = False
	Private fLoggingOut As Boolean = False
	'	Private strCookie As String = ""
	Private numFiles As Integer = 0
	Private cntFiles As Integer = 0

	Private personalPath As String = ""
	Private listDirectories As System.Collections.Specialized.StringCollection = Nothing
	Private errEvent As WinREG.ErrorFileCreated

	Private btnFileManagement As HtmlElement = Nothing
	Private btnUpload As HtmlElement = Nothing
	Private btnSearch As HtmlElement = Nothing
	Private btnUserAdmin As HtmlElement = Nothing
	Private btnLogout As HtmlElement = Nothing

	Private btnFileName As HtmlElement = Nothing
	Private btnFileActions As HtmlElementCollection = Nothing

	Private currentPageNumber As Integer = 0
	Private DownLoadedFile As String

	Private dt As DataTable = New DataTable("FreeREGfiles")

	Public Sub New()

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		TranscriptsPath = ""
		ErrorFileEvent = Nothing
		FreeREG_Id = ""
		_user_password = ""
	End Sub

	Public Sub New(ByVal obj As ErrorFileCreated, ByVal value As String, ByVal userid As String, ByVal password As String)

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		TranscriptsPath = value
		ErrorFileEvent = obj
		FreeREG_Id = userid
		_user_password = password
	End Sub

	Public Property ErrorFileEvent() As ErrorFileCreated
		Get
			Return Me.errEvent
		End Get
		Set(ByVal value As ErrorFileCreated)
			Me.errEvent = value
		End Set
	End Property

	Public Property TranscriptsPath() As String
		Get
			Return Me.personalPath
		End Get
		Set(ByVal value As String)
			Me.personalPath = value
			If My.Settings.listDirectories Is Nothing Then
				My.Settings.listDirectories = New System.Collections.Specialized.StringCollection()
				My.Settings.listDirectories.Add(value)
				My.Settings.Save()
			Else
				If Not My.Settings.listDirectories.Contains(value) Then
					My.Settings.listDirectories.Add(value)
					My.Settings.Save()
				End If
			End If
		End Set
	End Property

	Public Sub RemovePath(ByVal value As String)
		If My.Settings.listDirectories.Contains(value) Then
			My.Settings.listDirectories.Remove(value)
			My.Settings.Save()
		End If
	End Sub

	Private _user_name As String
	Public Property FreeREG_Id() As String
		Get
			Return _user_name
		End Get
		Set(ByVal value As String)
			_user_name = value
		End Set
	End Property

	Private _user_password As String
	Public Property FreeREG_Password() As String
		Get
			Return _user_password
		End Get
		Set(ByVal value As String)
			_user_password = value
		End Set
	End Property

	Public Event UserDetailsChanged(ByVal userid As String, ByVal password As String)

	Private Sub FreeRegBrowser_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If txtUserid.Text <> FreeREG_Id OrElse txtPassword.Text <> FreeREG_Password Then
			FreeREG_Id = txtUserid.Text
			FreeREG_Password = txtPassword.Text
			RaiseEvent UserDetailsChanged(FreeREG_Id, FreeREG_Password)
		End If
		My.Application.Log.WriteEntry(Date.Now() + " FreeREGbrowser Closed", TraceEventType.Information)
	End Sub

	Private Sub FreeRegBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		My.MySettings.Default.Upgrade()

		' Restore window state & position
		Me.Size = My.Settings.MyFormSize
		Me.Location = My.Settings.MyFormLocation
		Me.WindowState = My.Settings.MyFormWindowState

		txtUserid.Text = FreeREG_Id
		txtPassword.Text = _user_password

		Dim dc As DataColumn
		dc = Me.dt.Columns.Add("FileNumber", Type.GetType("System.UInt32"))
		dc.Caption = "File Number"

		dc = Me.dt.Columns.Add("FileName", Type.GetType("System.String"))
		Dim dcols(1) As DataColumn
		dcols(0) = dc
		dt.PrimaryKey = dcols
		dc.Unique = True
		dc.Caption = "File name"

		dc = Me.dt.Columns.Add("FileDate", Type.GetType("System.DateTime"))
		dc.Caption = "File Date & Time"

		dc = Me.dt.Columns.Add("FreeREGDate", Type.GetType("System.DateTime"))
		dc.Caption = "FreeREG Date & Time"

		dc = Me.dt.Columns.Add("FileSize", Type.GetType("System.UInt32"))
		dc.Caption = "Size"

		dc = Me.dt.Columns.Add("FreeREGSize", Type.GetType("System.UInt32"))
		dc.Caption = "Uploaded Size"

		dc = Me.dt.Columns.Add("PageNumber", Type.GetType("System.UInt32"))
		dc.Caption = "Page Number"

		dc = Me.dt.Columns.Add("Notes", Type.GetType("System.String"))
		dc.Caption = "Notes"

		LoadLocalFiles()

		Me.dgvFileList.DataSource = dt

		With Me.dgvFileList.Columns("FileNumber")
			.HeaderText = "File#"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.SortMode = DataGridViewColumnSortMode.Automatic
		End With

		With Me.dgvFileList.Columns("FileName")
			.HeaderText = "File name"
			.SortMode = DataGridViewColumnSortMode.Automatic
		End With

		With Me.dgvFileList.Columns("FileDate")
			.HeaderText = "Date written"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
			.DefaultCellStyle.Format = "dd MMM yyyy HH:mm:ss"
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.SortMode = DataGridViewColumnSortMode.Automatic
		End With

		With Me.dgvFileList.Columns("FileSize")
			.HeaderText = "File size"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
			.SortMode = DataGridViewColumnSortMode.NotSortable
		End With

		With Me.dgvFileList.Columns("FreeREGDate")
			.HeaderText = "Date uploaded"
			.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
			.DefaultCellStyle.Format = "dd MMM yyyy HH:mm:ss"
			.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
			.SortMode = DataGridViewColumnSortMode.Automatic
		End With

		Me.dgvFileList.Columns("FreeREGSize").Visible = False
		Me.dgvFileList.Columns("PageNumber").Visible = False
		Me.dgvFileList.Columns("Notes").SortMode = DataGridViewColumnSortMode.NotSortable

		My.Application.Log.DefaultFileLogWriter.LogFileCreationSchedule = Logging.LogFileCreationScheduleOption.Daily
		My.Application.Log.DefaultFileLogWriter.Location = Logging.LogFileLocation.Custom
		If String.IsNullOrEmpty(TranscriptsPath) Then
			My.Application.Log.DefaultFileLogWriter.CustomLocation = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & My.Application.Info.CompanyName & "\" & My.Application.Info.ProductName
		Else
			My.Application.Log.DefaultFileLogWriter.CustomLocation = TranscriptsPath
		End If

		If System.IO.File.Exists(My.Application.Log.DefaultFileLogWriter.FullLogFileName) Then
			Dim fi = New System.IO.FileInfo(My.Application.Log.DefaultFileLogWriter.FullLogFileName)
			If fi.IsReadOnly() Then
				fi.IsReadOnly = False
			End If
		Else
		End If

		My.Application.Log.DefaultFileLogWriter.AutoFlush = True
		My.Application.Log.WriteEntry(Date.Now() + " FreeREGbrowser Started", TraceEventType.Information)
	End Sub

	Private Sub LoadLocalFiles()
		For Each dirPath As String In My.Settings.listDirectories
			Try
				Dim filelist() As String = Directory.GetFiles(dirPath)
				Dim i As Integer = 1

				For Each filename As String In filelist
					Dim fi As FileInfo = My.Computer.FileSystem.GetFileInfo(filename)
					If String.Compare(fi.Extension(), ".CSV", True) = 0 Then
						Dim dr As DataRow = dt.NewRow()
						dr("FileNumber") = i
						dr("FileName") = fi.Name
						dr("FileSize") = fi.Length
						dr("FileDate") = fi.LastWriteTime
						dt.Rows.Add(dr)
						i += 1
					End If
				Next

			Catch ex As DirectoryNotFoundException
				MessageBox.Show(ex.Message, "Transcription Folder", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

			Catch ex As Exception
				MessageBox.Show(ex.Message, "Load Local Files", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

			End Try
		Next

	End Sub

	Private Sub ReloadTables()
		Dim fname As String = Path.Combine(Me.personalPath, FreeREG_Id + ".files.xml")
		Dim fs As New FileStream(fname, FileMode.Create, FileAccess.ReadWrite, FileShare.None)
		Dim sw As New StreamWriter(fs)
		Try
			dt.WriteXml(sw, XmlWriteMode.WriteSchema)

		Catch io As IOException
			Dim msg As String = vbCrLf & "Message ---" & vbCrLf & io.Message & vbCrLf & "HelpLink ---" & vbCrLf & io.HelpLink & vbCrLf & "Source ---" & vbCrLf & io.Source & vbCrLf & "StackTrace ---" & vbCrLf & io.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & io.TargetSite.ToString()
			MessageBox.Show(msg, "View File IOexception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

		Catch ex As Exception
			Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
			MessageBox.Show(msg, "View File exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

		Finally
			If sw IsNot Nothing Then sw.Close()
			If fs IsNot Nothing Then fs.Close()
		End Try

		dt.Clear()
		cntFiles = 0
		numFiles = 0
		LoadLocalFiles()
	End Sub

	Private Sub FreeRegBrowser_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
		My.Settings.MyFormWindowState = Me.WindowState
		If Me.WindowState = FormWindowState.Normal Then
			My.Settings.MyFormSize = Me.Size
			My.Settings.MyFormLocation = Me.Location
		Else
			My.Settings.MyFormSize = Me.RestoreBounds.Size
			My.Settings.MyFormLocation = Me.RestoreBounds.Location
		End If
		My.Settings.Save()

	End Sub

	Private Sub wbFreeREG_DocumentTitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles wbFreeREG.DocumentTitleChanged
		Me.Text = wbFreeREG.DocumentTitle
	End Sub

	Private Sub WebBrowser1_StatusTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wbFreeREG.StatusTextChanged
		Me.ToolStripStatusLabel1.Text = Me.wbFreeREG.StatusText
	End Sub

	Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wbFreeREG.DocumentCompleted

		My.Application.Log.WriteEntry(String.Format("{0} Page:{1} <{2}>", Date.Now(), wbFreeREG.Document.Title, wbFreeREG.Document.Url.AbsolutePath), TraceEventType.Information)

		btnFileManagement = wbFreeREG.Document.All("FileManagement")
		btnUpload = wbFreeREG.Document.All("Upload")
		btnSearch = wbFreeREG.Document.All("Search")
		btnUserAdmin = wbFreeREG.Document.All("UserAdmin")
		btnLogout = wbFreeREG.Document.All("Logout")
		Me.btnLogon.Enabled = btnLogout IsNot Nothing

		If wbFreeREG.DocumentTitle = "Welcome to FreeREG" Then
			Process_OpenAndLogin()
			Return
		End If

		If wbFreeREG.DocumentTitle = "File Management" Then
			Process_FileManagement()
			Return
		End If

		If wbFreeREG.DocumentTitle = "Viewing " & DownLoadedFile Then
			Process_ViewFile()
			Return
		End If

		If wbFreeREG.DocumentTitle = "FreeREG File Replacement" Then
			Process_FileReplace()
			Return
		End If

		If Me.wbFreeREG.DocumentTitle = "FreeREG File Rename" Then
			Process_FileRename()
			Return
		End If

		If Me.wbFreeREG.DocumentTitle = "File Deletion" Then
			Process_FileDelete()
			Return
		End If

		If Me.wbFreeREG.DocumentTitle = "FreeREG File Upload and Validation" Then
			Process_FileUpload()
			Return
		End If

		If Me.wbFreeREG.DocumentTitle <> "" Then MessageBox.Show(Me.wbFreeREG.Document.Body.InnerText, "Unhandled WebPage - " & wbFreeREG.DocumentTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
		ReloadTables()
		wbFreeREG.Navigate(My.Settings.urlFreeREG)

	End Sub

	Private Sub Process_OpenAndLogin()
		'If wbFreeREG.Document.Cookie Is Nothing Then
		'Else
		'	fLoggingOut = False
		'	fLoggedIn = False
		'	Me.btnUploadFile.Enabled = False
		'	Me.btnLogon.Enabled = True
		'	strCookie = ""
		'End If

		If fLoggedIn Then
			fLoggedIn = False
			fLoggingOut = False
			Me.btnLogon.Text = "Logon"
			Me.txtUserid.Enabled = True
			Me.txtPassword.Enabled = True
			ReloadTables()
			Me.btnUploadFile.Enabled = False
			Me.btnLogon.Enabled = True
			'			strCookie = ""
			Exit Sub
		End If

		Try
			Dim body As HtmlElement = wbFreeREG.Document.Body()
			If body.GetElementsByTagName("CENTER").Count = 0 Then
				Dim form As HtmlElement = wbFreeREG.Document.Forms(0)
				Dim user As HtmlElement = wbFreeREG.Document.All("UserID")
				Dim pswd As HtmlElement = wbFreeREG.Document.All("Password")
				Dim Lgin As HtmlElement = wbFreeREG.Document.All("Action")
				Dim Rset As HtmlElement = wbFreeREG.Document.All(".reset")

				user.SetAttribute("value", txtUserid.Text)				' Insert the UserID into the textbox
				pswd.SetAttribute("value", txtPassword.Text)				' Insert the password into the textbox
				fLoggingOut = False
				Lgin.InvokeMember("click")										' Press the Login button
			Else
				Dim msg As String = body.InnerText()
				MessageBox.Show(msg, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
				Me.btnLogon.Text = "Logon"
				Me.txtUserid.Enabled = True
				Me.txtPassword.Enabled = True
				ReloadTables()
				Me.btnUploadFile.Enabled = False
				Me.btnLogon.Enabled = True
				'				strCookie = ""
			End If

		Catch ex As Exception
			Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
			MessageBox.Show(msg, "Login/out exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
		Return
	End Sub

	Private Sub Process_FileManagement()
		Try
			'If strCookie = "" Then
			'	strCookie = wbFreeREG.Document.Cookie()
			'	fLoggedIn = True
			'	Me.txtUserid.Enabled = False
			'	Me.txtPassword.Enabled = False
			'	Me.btnLogon.Text = "Logout"
			'	Me.btnReplace.Enabled = False
			'	Me.btnDownload.Enabled = False
			'	Me.btnRename.Enabled = False
			'	Me.btnDelete.Enabled = False
			'End If

			Dim body As HtmlElement = wbFreeREG.Document.Body()

			If numFiles = 0 Then
				If (Not body.InnerText() Is Nothing) AndAlso body.InnerText().Contains("Total files:") Then
					Dim idx1 As Integer = body.InnerText().IndexOf("Total files: ") + 13
					Dim idx2 As Integer = body.InnerText().IndexOf(vbCr, idx1)
					Dim str As String = body.InnerText().Substring(idx1, idx2 - idx1)
					numFiles = Convert.ToInt32(str)
				End If
			End If

			Dim FormCollection As HtmlElementCollection = wbFreeREG.Document.GetElementsByTagName("FORM")

			Dim btnGotoPage As HtmlElement = Nothing
			Dim selPage As HtmlElement = Nothing
			Dim nextPageNumber As Integer = 0

			If numFiles > 25 Then
				btnGotoPage = wbFreeREG.Document.All("GotoPage")
				selPage = wbFreeREG.Document.All("Page")
				currentPageNumber = Convert.ToInt32(selPage.GetAttribute("value"))
			End If

			Dim fNumber As String, c2 As HtmlElement, fDate As String, fSize As String
			Dim fName As String

			'			If strCookie = wbFreeREG.Document.Cookie() Then
			Dim first As Integer = 2, last As Integer = FormCollection.Count - 2

			If numFiles <= 25 Then
				first = 1
				last = FormCollection.Count - 1
			End If

			For itemno As Integer = first To last
				Try
					fNumber = FormCollection.Item(itemno).Children.Item(0).InnerText()
					c2 = FormCollection.Item(itemno).Children.Item(0)
					fName = FormCollection.Item(itemno).Children.Item(1).GetElementsByTagName("INPUT").Item(0).GetAttribute("value")
					fDate = FormCollection.Item(itemno).Children.Item(2).InnerText()
					fSize = FormCollection.Item(itemno).Children.Item(3).InnerText()
					cntFiles += 1

					Dim dr As DataRow
					dr = dt.Rows.Find(fName)
					If dr IsNot Nothing Then
						dr("PageNumber") = currentPageNumber
						dr("FreeREGSize") = fSize
						dr("FreeREGDate") = DateTime.ParseExact(fDate, "ddd MMM d HH:mm:ss yyyy", Globalization.DateTimeFormatInfo.CurrentInfo).ToLocalTime
					Else
						dr = dt.NewRow()
						dr("FileNumber") = cntFiles
						dr("FileName") = fName
						dr("FreeREGSize") = fSize
						dr("FreeREGDate") = DateTime.ParseExact(fDate, "ddd MMM d HH:mm:ss yyyy", Globalization.DateTimeFormatInfo.CurrentInfo).ToLocalTime
						dr("PageNumber") = currentPageNumber
						dt.Rows.Add(dr)
					End If

					btnFileName = FormCollection.Item(itemno).Children(1)
					btnFileActions = FormCollection.Item(itemno).Children(4).GetElementsByTagName("INPUT")
					If btnFileActions.Count = 5 Then
						For Each dg As DataGridViewRow In Me.dgvFileList.Rows
							If dg.Cells("FileName").Value = fName Then
								dg.DefaultCellStyle.BackColor = Color.White
								dg.DefaultCellStyle.ForeColor = Color.Red
								dg.DefaultCellStyle.SelectionForeColor = Color.White
								dg.DefaultCellStyle.SelectionBackColor = Color.Red
								dg.ErrorText = "Contains Errors"
								Exit For
							End If
						Next
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Update DataTable", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
				End Try
			Next
			'			Else
			'			fLoggedIn = False
			'			strCookie = ""
			'			Me.btnReplace.Enabled = False
			'			Me.btnDownload.Enabled = False
			'			Me.btnRename.Enabled = False
			'			Me.btnDelete.Enabled = False
			'			End If

			If cntFiles < numFiles Then
				If numFiles > 25 Then
					nextPageNumber = currentPageNumber + 1
					selPage.SetAttribute("value", nextPageNumber.ToString())
					btnGotoPage.InvokeMember("click")
				End If
				Return
			End If

			fLoggedIn = True
			Me.txtUserid.Enabled = False
			Me.txtPassword.Enabled = False
			Me.btnLogon.Text = "Logout"
			Me.btnReplace.Enabled = False
			Me.btnDownload.Enabled = False
			Me.btnRename.Enabled = False
			Me.btnDelete.Enabled = False

			For Each r As DataGridViewRow In Me.dgvFileList.Rows
				Try
					If r.DefaultCellStyle.ForeColor = Color.Red Then
						r.Cells("Notes").Value &= "CONTAINS ERRORS - "
					End If
					If r.Cells("Filedate").FormattedValue = "" Then
						If r.Cells("FreeREGDate").FormattedValue = "" Then
						Else
							r.Cells("Notes").Value &= "File is not present on the local system. You can DOWNLOAD it from FreeREG."
						End If
					Else
						If r.Cells("FreeREGDate").FormattedValue = "" Then
							r.Cells("Notes").Value &= "New file. Needs to be uploaded to FreeREG"
						Else
							Dim dt1 As System.DateTime = r.Cells("FileDate").Value
							Dim dt2 As System.DateTime = r.Cells("FreeREGDate").Value
							If dt1.CompareTo(dt2) > 0 Then
								r.Cells("Notes").Value &= "Data on the PC is more recent than on FreeREG. Suggest file is REPLACED on FreeREG."
							End If
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Update DataGrid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
				End Try
			Next

			Me.dgvFileList.ClearSelection()
			Me.dgvFileList.Columns("Notes").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			Me.dgvFileList.CurrentCell = Nothing

		Catch ex As Exception
			Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
			MessageBox.Show(msg, "File Management exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	Private Sub Process_ViewFile()
		Dim body As HtmlElement = wbFreeREG.Document.Body()
		Dim strFileData As String = body.InnerText.Substring(body.InnerText.IndexOf("+INFO"), body.InnerText.IndexOf("Click here to return to file management") - body.InnerText.IndexOf("+INFO"))
		Dim len As Integer = strFileData.Length()
		Dim chs() As Char = {Chr(&HD), Chr(&HA)}
		Dim strLines() As String = strFileData.Split(chs, StringSplitOptions.RemoveEmptyEntries)
		Dim fc As FileDownload = Nothing
		Dim dlg As SaveFileDialog = Nothing

		Try
			fc = New FileDownload
			fc.Text = "File Download"
			fc.btnCancel.Visible = True
			fc.btnCancel.Enabled = True
			fc.btnSave.Text = "Save"
			fc.txtFileContents.Clear()
			fc.txtFileContents.ScrollBars = ScrollBars.Both
			For i As Integer = 0 To strLines.Length - 1
				fc.txtFileContents.Text += strLines(i).Trim() & vbCrLf
			Next

			If fc.ShowDialog() = DialogResult.OK Then
				dlg = New SaveFileDialog()
				Try
					dlg.Title = "Save " & DownLoadedFile
					dlg.Filter = "Transcription files|*.csv"
					dlg.InitialDirectory = personalPath
					dlg.AddExtension = False
					dlg.CreatePrompt = False
					dlg.OverwritePrompt = True
					dlg.RestoreDirectory = True
					dlg.FileName = DownLoadedFile

					Dim rc As DialogResult = dlg.ShowDialog()
					If rc = DialogResult.OK Then
						Dim fs As FileStream = Nothing
						Dim sw As StreamWriter = Nothing
						Try
							fs = CType(dlg.OpenFile(), System.IO.FileStream)
							sw = New StreamWriter(fs)
							For i As Integer = 0 To strLines.Length - 1
								sw.WriteLine(strLines(i))
							Next

						Catch io As IOException
							Dim msg As String = vbCrLf & "Message ---" & vbCrLf & io.Message & vbCrLf & "HelpLink ---" & vbCrLf & io.HelpLink & vbCrLf & "Source ---" & vbCrLf & io.Source & vbCrLf & "StackTrace ---" & vbCrLf & io.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & io.TargetSite.ToString()
							MessageBox.Show(msg, "View File IOexception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

						Catch ex As Exception
							Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
							MessageBox.Show(msg, "View File exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

						Finally
							If sw IsNot Nothing Then sw.Close()
							If fs IsNot Nothing Then fs.Close()
						End Try
					End If

				Catch ex As Exception
					Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
					MessageBox.Show(msg, "View File exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

				Finally
					If dlg IsNot Nothing Then dlg.Dispose()
				End Try
			End If

		Catch ex As Exception
			Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
			MessageBox.Show(msg, "View File exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

		Finally
			If fc IsNot Nothing Then fc.Dispose()
		End Try

		Dim fileElem As HtmlElementCollection = body.GetElementsByTagName("A")
		fileElem.Item(1).InvokeMember("click")
		ReloadTables()
	End Sub

	Private Sub Process_FileReplace()
		Dim ReplaceFile As HtmlElement = Me.wbFreeREG.Document.All("ReplaceFile")
		If ReplaceFile IsNot Nothing Then
			Dim ReplacementFile As HtmlElement = Me.wbFreeREG.Document.All("ReplacementFile")
			Dim Filename As HtmlElement = Me.wbFreeREG.Document.All("Filename")

			ReplacementFile.InvokeMember("click")
			ReplaceFile.InvokeMember("click")
		Else
			Dim fileElem As HtmlElementCollection = Me.wbFreeREG.Document.Body.GetElementsByTagName("A")
			If fileElem.Count = 2 Then
				MessageBox.Show("You have successfully replaced " & DownLoadedFile, "File Replace", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				My.Application.Log.WriteEntry(Date.Now() + String.Format(" Replaced {0} on FreeREG without errors ", DownLoadedFile), TraceEventType.Information)
				ReloadTables()
				fileElem.Item(1).InvokeMember("click")
				If File.Exists(Path.ChangeExtension(DownLoadedFile, "ERR")) Then
					File.Delete(Path.ChangeExtension(DownLoadedFile, "ERR"))
				End If
				errEvent.CauseEvent(DownLoadedFile)
			Else
				Dim fc As FileDownload = Nothing
				Dim line As HtmlElementCollection = Me.wbFreeREG.Document.Body.GetElementsByTagName("H3")
				Dim startOfErrors As Integer = Me.wbFreeREG.Document.Body.InnerHtml.IndexOf(line.Item(0).OuterHtml)
				startOfErrors += line.Item(0).OuterHtml.Length + 7
				Dim str As String = Me.wbFreeREG.Document.Body.InnerHtml.Substring(startOfErrors)
				For Each ele As HtmlElement In fileElem
					str = str.Replace(ele.OuterHtml, "")
				Next
				str = str.Replace("<HR>", "")
				str = str.Replace(" ( )", "")
				Dim idxForm As Integer = str.IndexOf("<FORM")
				If idxForm <> -1 Then str = str.Substring(0, idxForm)

				Dim sep() As String = {"<BR>"}
				Dim err() As String = str.Split(sep, StringSplitOptions.RemoveEmptyEntries)

				fc = New FileDownload
				fc.Text = "File Replace - Errors"
				fc.btnCancel.Visible = False
				fc.btnCancel.Enabled = False
				fc.btnSave.Text = "OK"
				fc.txtFileContents.Clear()
				fc.txtFileContents.ScrollBars = ScrollBars.Both
				fc.txtFileContents.Text = line.Item(0).OuterText & vbCrLf & vbCrLf
				For Each e As String In err
					fc.txtFileContents.Text += e.Trim() & vbCrLf
				Next
				fc.ShowDialog()
				My.Application.Log.WriteEntry(Date.Now() + String.Format(" Replaced {0} on FreeREG with errors {1}", DownLoadedFile, fc.txtFileContents.Text), TraceEventType.Information)

				Dim dlg As SaveFileDialog = Nothing
				dlg = New SaveFileDialog()
				Try
					dlg.Title = "Save " & DownLoadedFile
					dlg.Filter = "Error files|*.err"
					dlg.InitialDirectory = personalPath
					dlg.AddExtension = False
					dlg.CreatePrompt = False
					dlg.OverwritePrompt = True
					dlg.RestoreDirectory = True
					dlg.FileName = Path.ChangeExtension(DownLoadedFile, "ERR")

					Dim rc As DialogResult = dlg.ShowDialog()
					If rc = DialogResult.OK Then
						Dim fs As FileStream = Nothing
						Dim sw As StreamWriter = Nothing
						Try
							fs = CType(dlg.OpenFile(), System.IO.FileStream)
							sw = New StreamWriter(fs)
							sw.WriteLine(fc.txtFileContents.Text)

						Catch io As IOException
							Dim msg As String = vbCrLf & "Message ---" & vbCrLf & io.Message & vbCrLf & "HelpLink ---" & vbCrLf & io.HelpLink & vbCrLf & "Source ---" & vbCrLf & io.Source & vbCrLf & "StackTrace ---" & vbCrLf & io.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & io.TargetSite.ToString()
							MessageBox.Show(msg, "View File IOexception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

						Catch ex As Exception
							Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
							MessageBox.Show(msg, "View File exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

						Finally
							If sw IsNot Nothing Then sw.Close()
							If fs IsNot Nothing Then fs.Close()
						End Try
						errEvent.CauseEvent(Path.ChangeExtension(fs.Name, "CSV"))
					End If

				Catch ex As Exception
					Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
					MessageBox.Show(msg, "View File exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

				Finally
					If dlg IsNot Nothing Then dlg.Dispose()
				End Try

				ReloadTables()
				fileElem.Item(fileElem.Count - 1).InvokeMember("click")
			End If
		End If
	End Sub

	Private Sub Process_FileRename()
		Dim RenameFile As HtmlElement = Me.wbFreeREG.Document.All("RenameFile")
		If RenameFile IsNot Nothing Then
			Dim RenamedFilename As HtmlElement = Me.wbFreeREG.Document.All("RenamedFilename")
			Dim RenamedFilenameConfirm As HtmlElement = Me.wbFreeREG.Document.All("RenamedFilenameConfirm")
			Dim strNewName As String = ""
			Dim strNewNameConfirmed As String = ""
			Dim fc As FileRename = Nothing

			Try
				fc = New FileRename
				fc.lblRequest.Text = Me.wbFreeREG.Document.GetElementsByTagName("FORM")(1).GetElementsByTagName("H2")(0).InnerText
				fc.txtNewName.Text = strNewName
				fc.txtNewNameConfirm.Text = strNewNameConfirmed
				If fc.ShowDialog() = DialogResult.OK Then
					strNewName = fc.txtNewName.Text.Trim()
					strNewNameConfirmed = fc.txtNewNameConfirm.Text.Trim()
					If strNewName <> "" And strNewNameConfirmed <> "" Then
						If strNewName.EndsWith(".CSV") And strNewNameConfirmed.EndsWith(".CSV") Then
							If strNewName = strNewNameConfirmed Then
								RenamedFilename.SetAttribute("value", strNewName)
								RenamedFilenameConfirm.SetAttribute("value", strNewNameConfirmed)
								RenameFile.InvokeMember("click")
							Else
								MessageBox.Show("Both entries must be the same", "Rename File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
								ReloadTables()
								Me.btnFileManagement.InvokeMember("click")
							End If
						Else
							MessageBox.Show("The CSV extension must be entered", "Rename File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
							ReloadTables()
							Me.btnFileManagement.InvokeMember("click")
						End If
					Else
						MessageBox.Show("Both fields must be entered", "Rename File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
						ReloadTables()
						Me.btnFileManagement.InvokeMember("click")
					End If
				Else
					ReloadTables()
					Me.btnFileManagement.InvokeMember("click")
				End If

			Catch ex As Exception
				Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
				MessageBox.Show(msg, "Rename File exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

			Finally
				If fc IsNot Nothing Then fc.Dispose()
			End Try
		Else
			Dim fileElem As HtmlElementCollection = Me.wbFreeREG.Document.Body.GetElementsByTagName("A")
			My.Application.Log.WriteEntry(Date.Now() + String.Format(" Renamed {0} on FreeREG ", DownLoadedFile), TraceEventType.Information)
			ReloadTables()
			fileElem.Item(1).InvokeMember("click")
		End If
	End Sub

	Private Sub Process_FileDelete()
		Dim DeleteFile As HtmlElement = Me.wbFreeREG.Document.All("DeleteConfirmation")
		If DeleteFile IsNot Nothing Then
			Dim DeleteOptions As HtmlElementCollection = wbFreeREG.Document.GetElementsByTagName("FORM").Item(1).GetElementsByTagName("INPUT")

			For Each he As HtmlElement In DeleteOptions
				Dim cn As String = he.GetAttribute("name")
				If cn = "ConfirmDelete" Then
					Dim cv As String = he.GetAttribute("value")
					If cv = "Yes, Delete " & DownLoadedFile Then
						he.InvokeMember("click")
					End If
				End If
			Next

			DeleteFile.InvokeMember("click")
		Else
			Dim pathname As String = TranscriptsPath + "\" + DownLoadedFile
			If File.Exists(Path.ChangeExtension(pathname, "ERR")) Then
				File.Delete(Path.ChangeExtension(pathname, "ERR"))
			End If
			Dim fileElem As HtmlElementCollection = Me.wbFreeREG.Document.Body.GetElementsByTagName("A")
			My.Application.Log.WriteEntry(Date.Now() + String.Format(" Deleted {0} from FreeREG ", DownLoadedFile), TraceEventType.Information)
			errEvent.CauseEvent(pathname)
			ReloadTables()
			fileElem.Item(fileElem.Count - 1).InvokeMember("click")
		End If
	End Sub

	Private Sub Process_FileUpload()
		Dim body As HtmlElement = wbFreeREG.Document.Body()
		Dim btns As HtmlElementCollection = body.GetElementsByTagName("INPUT")

		If btns.Count = 7 Then										' Processing the page that asks for the names of files to upload
			Dim msg As String = "Do you want to upload " & DownLoadedFile & "?"
			If MessageBox.Show(msg, "Upload File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
				Me.btnUploadFile.Enabled = False
				ReloadTables()
				btns.Item(6).InvokeMember("click")
				Return
			End If

			btns.Item(0).InvokeMember("click")					' Only do a single file at a time
			btns.Item(5).InvokeMember("click")
			Return
		End If

		If btns.Count = 2 Then										' Results containing errors or successful upload
			Dim line As HtmlElementCollection = wbFreeREG.Document.GetElementsByTagName("H3")
			If line.Item(0).InnerText.Contains("You have uploaded the error free file") Then
				MessageBox.Show(line.Item(0).InnerText, "File Upload", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				If File.Exists(Path.ChangeExtension(DownLoadedFile, "ERR")) Then
					File.Delete(Path.ChangeExtension(DownLoadedFile, "ERR"))
				End If
				My.Application.Log.WriteEntry(Date.Now() + String.Format(" Uploaded {0} to FreeREG without errors ", DownLoadedFile), TraceEventType.Information)
				errEvent.CauseEvent(DownLoadedFile)
			Else
				Dim fc As FileDownload = Nothing
				Dim fileElem As HtmlElementCollection = Me.wbFreeREG.Document.Body.GetElementsByTagName("A")
				Dim startOfErrors As Integer = Me.wbFreeREG.Document.Body.InnerHtml.IndexOf(line.Item(0).OuterHtml)
				startOfErrors += line.Item(0).OuterHtml.Length + 7
				Dim str As String = Me.wbFreeREG.Document.Body.InnerHtml.Substring(startOfErrors)
				For Each ele As HtmlElement In fileElem
					str = str.Replace(ele.OuterHtml, "")
				Next
				str = str.Replace("<HR>", "")
				str = str.Replace(" ( )", "")
				Dim idxForm As Integer = str.IndexOf("<FORM")
				If idxForm <> -1 Then str = str.Substring(0, idxForm)

				Dim sep() As String = {"<BR>"}
				Dim err() As String = str.Split(sep, StringSplitOptions.RemoveEmptyEntries)
				Dim i As Integer = 0

				fc = New FileDownload
				fc.Text = "File Upload - Errors"
				fc.btnCancel.Visible = False
				fc.btnCancel.Enabled = False
				fc.btnSave.Text = "OK"
				fc.txtFileContents.Clear()
				fc.txtFileContents.ScrollBars = ScrollBars.Both
				fc.txtFileContents.Text = line.Item(0).OuterText & vbCrLf & vbCrLf
				For Each e As String In err
					fc.txtFileContents.Text += e.Trim() & vbCrLf
				Next
				fc.ShowDialog()
				My.Application.Log.WriteEntry(Date.Now() + String.Format(" Uploaded {0} to FreeREG with errors {1}", DownLoadedFile, fc.txtFileContents.Text), TraceEventType.Information)

				Dim dlg As SaveFileDialog = Nothing
				dlg = New SaveFileDialog()
				Try
					dlg.Title = "Save " & DownLoadedFile
					dlg.Filter = "Error files|*.err"
					dlg.InitialDirectory = personalPath
					dlg.AddExtension = False
					dlg.CreatePrompt = False
					dlg.OverwritePrompt = True
					dlg.RestoreDirectory = True
					dlg.FileName = Path.ChangeExtension(DownLoadedFile, "ERR")

					Dim rc As DialogResult = dlg.ShowDialog()
					If rc = DialogResult.OK Then
						Dim fs As FileStream = Nothing
						Dim sw As StreamWriter = Nothing
						Try
							fs = CType(dlg.OpenFile(), System.IO.FileStream)
							sw = New StreamWriter(fs)
							sw.WriteLine(fc.txtFileContents.Text)

						Catch io As IOException
							Dim msg As String = vbCrLf & "Message ---" & vbCrLf & io.Message & vbCrLf & "HelpLink ---" & vbCrLf & io.HelpLink & vbCrLf & "Source ---" & vbCrLf & io.Source & vbCrLf & "StackTrace ---" & vbCrLf & io.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & io.TargetSite.ToString()
							MessageBox.Show(msg, "View File IOexception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

						Catch ex As Exception
							Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
							MessageBox.Show(msg, "View File exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

						Finally
							If sw IsNot Nothing Then sw.Close()
							If fs IsNot Nothing Then fs.Close()
						End Try
						errEvent.CauseEvent(Path.ChangeExtension(fs.Name, "CSV"))
					End If

				Catch ex As Exception
					Dim msg As String = vbCrLf & "Message ---" & vbCrLf & ex.Message & vbCrLf & "HelpLink ---" & vbCrLf & ex.HelpLink & vbCrLf & "Source ---" & vbCrLf & ex.Source & vbCrLf & "StackTrace ---" & vbCrLf & ex.StackTrace & vbCrLf & "TargetSite ---" & vbCrLf & ex.TargetSite.ToString()
					MessageBox.Show(msg, "View File exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

				Finally
					If dlg IsNot Nothing Then dlg.Dispose()
				End Try

			End If

			ReloadTables()
			Me.btnUploadFile.Enabled = False
			btns.Item(1).InvokeMember("click")
			Return
		End If

		Me.btnUploadFile.Enabled = False							' Duh! What have we received?
		ReloadTables()
		wbFreeREG.Navigate(My.Settings.urlFreeREG)
	End Sub

	Private Sub dgvFileList_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFileList.RowEnter
		If fLoggedIn And Not fLoggingOut Then
			If e.RowIndex <> -1 Then
				If Me.dgvFileList.Rows(e.RowIndex).Cells("FreeREGDate").FormattedValue <> "" Then
					Me.btnUploadFile.Enabled = False
					Me.btnDownload.Enabled = True
					If Me.dgvFileList.Rows(e.RowIndex).Cells("FileDate").FormattedValue <> "" Then
						Me.btnReplace.Enabled = True
					Else
						Me.btnReplace.Enabled = False
					End If
					Me.btnRename.Enabled = True
					Me.btnDelete.Enabled = True
				Else
					Me.btnDownload.Enabled = False
					Me.btnReplace.Enabled = False
					Me.btnRename.Enabled = False
					Me.btnDelete.Enabled = False
					If Not fLoggedIn Or fLoggingOut Then
						Me.btnUploadFile.Enabled = False
					Else
						Me.btnUploadFile.Enabled = True
					End If
				End If
			End If
		End If
	End Sub

	Private Sub dgvFileList_RowLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFileList.RowLeave
		If e.RowIndex <> -1 Then
			Me.btnUploadFile.Enabled = False
			Me.btnDownload.Enabled = False
			Me.btnReplace.Enabled = False
			Me.btnRename.Enabled = False
			Me.btnDelete.Enabled = False
		End If
	End Sub

	Private Sub dgvFileList_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvFileList.CellMouseClick
		If e.Button = Windows.Forms.MouseButtons.Right And e.Clicks = 1 Then
			If Me.dgvFileList.Rows(e.RowIndex).ErrorText <> "" Then
				Dim dlg As FileDownload = Nothing
				Dim fe As FileStream = Nothing
				Dim sr As StreamReader = Nothing
				Dim pathname As String = My.Computer.FileSystem.CombinePath(personalPath, Me.dgvFileList.Rows(e.RowIndex).Cells("FileName").Value)

				dlg = New FileDownload
				dlg.Text = "Error Messages - " & Me.dgvFileList.Rows(e.RowIndex).Cells("FileName").Value
				dlg.btnCancel.Visible = False
				dlg.btnSave.Text = "OK"
				dlg.txtFileContents.ScrollBars = ScrollBars.Both
				Try
					fe = New FileStream(Path.ChangeExtension(pathname, "ERR"), FileMode.Open, FileAccess.Read, FileShare.None)
					sr = New StreamReader(fe)
					While Not sr.EndOfStream()
						Dim strError As String = sr.ReadLine()
						dlg.txtFileContents.Text += strError & vbCrLf
					End While

				Catch ex As FileNotFoundException

				Catch ex As Exception

				Finally
					If sr IsNot Nothing Then sr.Close()
					If fe IsNot Nothing Then fe.Close()

				End Try

				dlg.ShowDialog()

				dlg.Dispose()
			End If
		End If
	End Sub

	Private Sub btnLogon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogon.Click
		If FreeREG_Id <> "" And FreeREG_Password <> "" Then
			If Not fLoggedIn Then
				wbFreeREG.Navigate(My.Settings.urlFreeREG)
				cntFiles = 0
				numFiles = 0
			Else
				btnLogout.InvokeMember("click")
				fLoggingOut = True
				Me.btnUploadFile.Enabled = False
				Me.btnLogon.Text = "Logon"
				Me.txtUserid.Enabled = True
				Me.txtPassword.Enabled = True
				ReloadTables()
			End If
		Else
			MessageBox.Show("You must enter your FreeREG user name and password before you can login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
		End If
	End Sub

	Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
		Dim cntSelected As Integer = Me.dgvFileList.SelectedRows.Count
		If cntSelected > 0 Then
			Dim row As DataGridViewRow = Me.dgvFileList.SelectedRows(0)
			With row
				Dim msg As String = "Do you want to download " & .Cells("FileName").Value & "?"

				If MessageBox.Show(msg, "Download File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
					DownLoadedFile = .Cells("FileName").Value

					For Each he As HtmlElement In Me.btnFileActions
						Dim cv As String = he.GetAttribute("value")
						If cv = "View File" Then
							he.InvokeMember("click")
						End If
					Next

					Me.btnFileName.SetAttribute("value", .Cells("FileName").Value)
					Me.btnFileName.GetElementsByTagName("INPUT").Item(0).SetAttribute("value", .Cells("FileName").Value)
					Me.btnFileName.GetElementsByTagName("INPUT").Item(0).InvokeMember("click")
				End If
			End With
		End If
	End Sub

	Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplace.Click
		Dim cntSelected As Integer = Me.dgvFileList.SelectedRows.Count
		If cntSelected > 0 Then
			Dim row As DataGridViewRow = Me.dgvFileList.SelectedRows(0)
			With row
				Dim msg As String = "Do you want to replace " & .Cells("FileName").Value & "?"

				If MessageBox.Show(msg, "Replace File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
					DownLoadedFile = .Cells("FileName").Value

					For Each he As HtmlElement In Me.btnFileActions
						Dim cv As String = he.GetAttribute("value")
						If cv = "Replace" Then
							he.InvokeMember("click")
						End If
					Next

					Me.btnFileName.SetAttribute("value", .Cells("FileName").Value)
					Me.btnFileName.GetElementsByTagName("INPUT").Item(0).SetAttribute("value", .Cells("FileName").Value)
					Me.btnFileName.GetElementsByTagName("INPUT").Item(0).InvokeMember("click")
				End If
			End With
		End If
	End Sub

	Private Sub btnRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRename.Click
		Dim cntSelected As Integer = Me.dgvFileList.SelectedRows.Count
		If cntSelected > 0 Then
			Dim row As DataGridViewRow = Me.dgvFileList.SelectedRows(0)
			With row
				Dim msg As String = "Do you want to rename " & .Cells("FileName").Value & "?"

				If MessageBox.Show(msg, "Rename File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
					DownLoadedFile = .Cells("FileName").Value

					For Each he As HtmlElement In Me.btnFileActions
						Dim cv As String = he.GetAttribute("value")
						If cv = "Rename" Then
							he.InvokeMember("click")
						End If
					Next

					Me.btnFileName.SetAttribute("value", .Cells("FileName").Value)
					Me.btnFileName.GetElementsByTagName("INPUT").Item(0).SetAttribute("value", .Cells("FileName").Value)
					Me.btnFileName.GetElementsByTagName("INPUT").Item(0).InvokeMember("click")
				End If
			End With
		End If
	End Sub

	Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
		Dim cntSelected As Integer = Me.dgvFileList.SelectedRows.Count
		If cntSelected > 0 Then
			Dim row As DataGridViewRow = Me.dgvFileList.SelectedRows(0)
			With row
				Dim msg As String = "Do you want to delete " & .Cells("FileName").Value & "?"

				If MessageBox.Show(msg, "Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
					DownLoadedFile = .Cells("FileName").Value

					For Each he As HtmlElement In Me.btnFileActions
						Dim cv As String = he.GetAttribute("value")
						If cv = "Delete" Then
							he.InvokeMember("click")
						End If
					Next

					Me.btnFileName.SetAttribute("value", .Cells("FileName").Value)
					Me.btnFileName.GetElementsByTagName("INPUT").Item(0).SetAttribute("value", .Cells("FileName").Value)
					Me.btnFileName.GetElementsByTagName("INPUT").Item(0).InvokeMember("click")
				End If
			End With
		End If
	End Sub

	Private Sub btnUploadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadFile.Click
		Dim cntSelected As Integer = Me.dgvFileList.SelectedRows.Count
		If cntSelected > 0 Then
			Dim row As DataGridViewRow = Me.dgvFileList.SelectedRows(0)
			With row
				DownLoadedFile = .Cells("FileName").Value
			End With
			Me.btnUpload.InvokeMember("click")
		End If
	End Sub

	Private Sub dgvFileList_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvFileList.ColumnHeaderMouseClick
		If e.Button = Windows.Forms.MouseButtons.Left AndAlso e.Clicks = 1 Then
			If dgvFileList.Columns(e.ColumnIndex).SortMode = DataGridViewColumnSortMode.NotSortable Then
				Beep()
			End If
		End If
	End Sub

	Private Sub FreeRegBrowser_HelpRequested(ByVal sender As System.Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
		Dim cell = dgvFileList.CurrentCellAddress()
		If cell.X <> -1 AndAlso cell.Y <> -1 Then
			hlpFreeREGbrowser.SetShowHelp(sender, True)
			hlpFreeREGbrowser.SetHelpNavigator(sender, HelpNavigator.Topic)
			Dim topic As String = "FreeRegBrowser.htm"
			hlpFreeREGbrowser.SetHelpKeyword(sender, topic)
			'			Console.WriteLine(String.Format("{0}: row:{1} column:{2} {3} - {4}", sender.ToString(), cell.Y, cell.X, dgvFileList.Columns(cell.X).Name, topic))
		ElseIf cell.X = -1 AndAlso cell.Y = -1 Then
		Else
		End If
	End Sub

	Private Sub dgvFileList_HelpRequested(ByVal sender As System.Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles dgvFileList.HelpRequested
		Dim cell = dgvFileList.CurrentCellAddress()
		If cell.X <> -1 AndAlso cell.Y <> -1 Then
			Dim topic As String
			hlpFreeREGbrowser.SetShowHelp(sender, True)
			hlpFreeREGbrowser.SetHelpNavigator(sender, HelpNavigator.Topic)
			topic = String.Format("FreeRegBrowserFields.htm#{0}", dgvFileList.Columns(cell.X).Name)
			hlpFreeREGbrowser.SetHelpKeyword(sender, topic)
			'			Console.WriteLine(String.Format("{0}: row:{1} column:{2} {3} - {4}", sender.ToString(), cell.Y, cell.X, dgvFileList.Columns(cell.X).Name, topic))
		ElseIf cell.X = -1 AndAlso cell.Y = -1 Then
		Else
		End If
	End Sub

	Private Sub SplitContainer1_Panel1_HelpRequested(ByVal sender As System.Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles SplitContainer1.Panel1.HelpRequested
		For Each ctl As Control In sender.controls
			If TypeOf ctl Is Button Then
				Dim btn As Button = ctl
				Dim rect As Rectangle = btn.RectangleToScreen(btn.ClientRectangle)
				If rect.Contains(hlpevent.MousePos) Then
					'					Console.WriteLine(String.Format("{0}: MousePos:{1} Btn:{2}", sender.ToString(), hlpevent.MousePos.ToString, btn.Name))
					Help.ShowPopup(btn, hlpFreeREGbrowser.GetHelpString(btn), Control.MousePosition)
					hlpevent.Handled = True
					Exit Sub
				End If
			End If
		Next
		'		Console.WriteLine(String.Format("{0}: MousePos:{1}", sender.ToString(), hlpevent.MousePos.ToString))
	End Sub

End Class
