'	$Date: 2013-10-10 10:39:47 +0200 (Thu, 10 Oct 2013) $
'	$Rev: 253 $
'	$Id: dlgRecoverFromBackup.vb 253 2013-10-10 08:39:47Z Mikefry $
'
'	WinREG/3 - Version 3.1.17
'

Imports System.Windows.Forms
Imports System.Linq
Imports System.IO

Public Class dlgRecoverFromBackup

	Public tf As TranscriptionFile = Nothing
	Public btf As TranscriptionFile = Nothing

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub dlgRecoverFromBackup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim filelist = GetFiles(My.Settings.DataFolderName, "*.csv")

		cboxTranscriptionFiles.Items.AddRange(filelist.ToArray())
		cboxTranscriptionFiles.DisplayMember = "Name"
		If cboxTranscriptionFiles.Items.Count > 0 Then
			cboxTranscriptionFiles.SelectedIndex = 0
		End If
	End Sub

	' Function to retrieve a list of files. Note that this is a copy
	' of the file information.
	Private Function GetFiles(ByVal root As String, ByVal type As String) As IEnumerable(Of FileInfo)
		Return From file In My.Computer.FileSystem.GetFiles(root, FileIO.SearchOption.SearchTopLevelOnly, type) _
		 Select New FileInfo(file)
	End Function

	Private Sub cboxTranscriptionFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxTranscriptionFiles.SelectedIndexChanged
		Dim selectedFile As FileInfo = CType(cboxTranscriptionFiles.SelectedItem, FileInfo)

		' Get the File Details and the first data record
		'
		tf = New TranscriptionFile(selectedFile)

		' Extract the File Details information, and display it
		'
		Dim source As String = tf.HdrLine4(2)
		Dim comments As String = tf.HdrLine4(3)
		Dim namePlace As String = tf.FirstDataLine(1)
		Dim nameChurch As String = tf.FirstDataLine(2)

		labFileName.Text = selectedFile.FullName
		labPlacename.Text = namePlace
		labChurchname.Text = nameChurch
		labSource.Text = source
		labComments.Text = comments
		labLastUpdated.Text = selectedFile.LastWriteTime.ToString("F")
		labLineCount.Text = tf.LineCount.ToString()

		' Compile a list of the available backup files
		'
		cboxBackupFiles.Items.Clear()
		cboxBackupFiles.Text = String.Empty
		Dim filelist = GetFiles(My.Settings.BackupFolderName, "*.csv")
		Dim queryFiles = From file In filelist _
		 Where file.Name.StartsWith(Path.GetFileNameWithoutExtension(selectedFile.FullName) + " ") _
		 Order By file.Name Descending _
		 Select file
		cboxBackupFiles.Items.AddRange(queryFiles.ToArray())
		cboxBackupFiles.DisplayMember = "Name"
		labNumBackups.Text = queryFiles.Count
		If cboxBackupFiles.Items.Count > 0 Then cboxBackupFiles.SelectedIndex = 0
		If queryFiles.Count > 0 Then
			cboxBackupFiles.Enabled = True
			labBackupLines.Visible = True
			labBackupUpdated.Visible = True
			Label9.Visible = True
			Label11.Visible = True
		Else
			cboxBackupFiles.Enabled = False
			labBackupLines.Visible = False
			labBackupUpdated.Visible = False
			Label9.Visible = False
			Label11.Visible = False
		End If
	End Sub

	Private Sub cboxBackupFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxBackupFiles.SelectedIndexChanged
		Dim selectedFile As FileInfo = CType(cboxBackupFiles.SelectedItem, FileInfo)

		' Get the File Details and the first data record of the selected Backup file
		'
		btf = New TranscriptionFile(selectedFile)

		labBackupLines.Text = btf.LineCount.ToString()
		labBackupUpdated.Text = selectedFile.LastWriteTime.ToString("F")
		If labLineCount.Text = labBackupLines.Text AndAlso labLastUpdated.Text = labBackupUpdated.Text Then
			OK_Button.Enabled = False
		Else
			OK_Button.Enabled = True
		End If
	End Sub

#Region "Class:Transcription File"
	Public Class TranscriptionFile

		Private _filename As FileInfo
		Public ReadOnly Property FileName() As FileInfo
			Get
				Return _filename
			End Get
		End Property

		Private _aline1 As String()
		Public ReadOnly Property HdrLine1() As String()
			Get
				Return _aline1
			End Get
		End Property

		Private _aline2 As String()
		Public ReadOnly Property HdrLine2() As String()
			Get
				Return _aline2
			End Get
		End Property

		Private _aline3 As String()
		Public ReadOnly Property HdrLine3() As String()
			Get
				Return _aline3
			End Get
		End Property

		Private _aline4 As String()
		Public ReadOnly Property HdrLine4() As String()
			Get
				Return _aline4
			End Get
		End Property

		Private _aline5 As String()
		Public ReadOnly Property HdrLine5() As String()
			Get
				Return _aline5
			End Get
		End Property

		Private _FirstDataLine As String()
		Public ReadOnly Property FirstDataLine() As String()
			Get
				Return _FirstDataLine
			End Get
		End Property

		Private _count As Integer
		Public ReadOnly Property LineCount()
			Get
				Return _count
			End Get
		End Property

		Public Sub New(ByVal strFileName As FileInfo)
			_filename = strFileName
			Dim hdrs As Integer = 4
			Using fs As FileStream = New FileStream(strFileName.FullName, FileMode.Open, FileAccess.Read, FileShare.None)
				Dim csv As FileIO.TextFieldParser = New FileIO.TextFieldParser(fs, WinREG.MainForm._Encoding)
				csv.TextFieldType = FileIO.FieldType.Delimited
				csv.SetDelimiters(",")
				csv.HasFieldsEnclosedInQuotes = True
				csv.TrimWhiteSpace = True

				_aline1 = csv.ReadFields()
				_aline2 = csv.ReadFields()
				_aline3 = csv.ReadFields()
				_aline4 = csv.ReadFields()
				_aline5 = csv.ReadFields()
				_FirstDataLine = _aline5
				If _aline5(0).Equals("+LDS", StringComparison.InvariantCultureIgnoreCase) Then
					_FirstDataLine = csv.ReadFields()
					hdrs = 5
				End If
			End Using
			Dim l As String() = File.ReadAllLines(strFileName.FullName)
			_count = l.Count - hdrs
		End Sub

	End Class
#End Region

End Class
