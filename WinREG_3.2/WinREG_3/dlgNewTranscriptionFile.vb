'	$Date: 2013-10-10 13:49:00 +0200 (Thu, 10 Oct 2013) $
'	$Rev: 255 $
'	$Id: dlgNewTranscriptionFile.vb 255 2013-10-10 11:49:00Z Mikefry $
'
'	WinREG/3 - Version 3.1.8
'

Imports System.Windows.Forms
Imports WinREG.LookupTables
Imports System.Globalization
Imports System.IO
Imports WinREG.MainForm

Public Class dlgNewTranscriptionFile

	Public MyTranscripts As String
	Public _File As FileHeader
	Public MyScreenLayout As ColumnLayout

	Private freeregFiles As DataSet = Nothing

	Private fileCounty As String = "   "
	Private filePlace As String = "   "
	Private fileType As String = "  "
	Private fileSuffix As String = String.Empty
	Private fbase As WinREG.FreeRegBrowser = WinREG.MainForm.FreeRegbrowser

	Private Sub dlgNewTranscriptionFile_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		freeregFiles = Nothing
	End Sub

	Private Sub dlgNewTranscriptionFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'If fbase.FreeREG_Id = String.Empty Then
		'	MessageBox.Show("Need to logon to FreeREG", "New Transcription FIle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		'Else
		Try
			Dim fname As String = Path.Combine(MyTranscripts, fbase.FreeREG_Id + ".files.xml")
			Dim fs As New FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.None)
			Dim sw As New StreamReader(fs)
			Try
				freeregFiles = New DataSet()
				freeregFiles.ReadXml(sw, XmlReadMode.ReadSchema)

			Catch ex As Exception

			Finally
				If sw IsNot Nothing Then sw.Close()
				If fs IsNot Nothing Then fs.Close()
			End Try

		Catch ex As Exception

		End Try
		'		End If

		cbCounty.SelectedIndex = -1
		cbRecordType.SelectedIndex = -1
		ttNewTranscriptionFile.Active = My.Settings.MyDisplayTooltips
		If My.Settings.MyDisplayTooltips Then
			ttNewTranscriptionFile.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
		End If
		txtFileName.Text = BuildFileName()
		labColumnLayout.Visible = False
		labColumnLayout.Enabled = False
		cbScreenLayouts.Visible = False
		cbScreenLayouts.Enabled = False
		cbCounty.SelectedItem = cbCounty.Items(cbCounty.FindString(My.Settings.Syndicate))
		txtPlaceName.Focus()
	End Sub

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		_File.Filename = BuildFileName()
		_File.ChurchName = txtChurchName.Text
		_File.PlaceName = txtPlaceName.Text
		_File.FileSource = txtSource.Text
		_File.FileComments = txtComments.Text
		_File.CreditToName = txtCreditTo.Text
		_File.CreditToAddress = txtCreditEmailAddress.Text
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub txtPlaceName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPlaceName.Validating
		If txtPlaceName.TextLength < 3 Then
			errNewTranscriptionFile.SetIconAlignment(txtPlaceName, ErrorIconAlignment.MiddleLeft)
			errNewTranscriptionFile.SetError(txtPlaceName, My.Resources.err0007)
			e.Cancel = True
		Else
		End If
	End Sub

	Private Sub txtPlaceCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPlaceCode.Validating
		If txtPlaceCode.TextLength < 3 Then
			errNewTranscriptionFile.SetIconAlignment(txtPlaceCode, ErrorIconAlignment.MiddleLeft)
			errNewTranscriptionFile.SetError(txtPlaceCode, My.Resources.err0045)
			e.Cancel = True
		Else
		End If
	End Sub

	Private Sub txtChurchName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtChurchName.Validating

	End Sub

	Private Sub txtSource_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSource.Validating
		If txtSource.Text.IndexOf("("c) >= 0 OrElse txtSource.Text.IndexOf(")"c) >= 0 Then
			errNewTranscriptionFile.SetIconAlignment(txtSource, ErrorIconAlignment.MiddleLeft)
			errNewTranscriptionFile.SetError(txtSource, My.Resources.err0042)
			e.Cancel = True
		End If
	End Sub

	Private Sub txtComments_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtComments.Validating
		If txtComments.Text.IndexOf("("c) >= 0 OrElse txtComments.Text.IndexOf(")"c) >= 0 Then
			errNewTranscriptionFile.SetIconAlignment(txtComments, ErrorIconAlignment.MiddleLeft)
			errNewTranscriptionFile.SetError(txtComments, My.Resources.err0042)
			e.Cancel = True
		End If
	End Sub

	Private Sub cbCounty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbCounty.Validating
		If cbCounty.SelectedIndex = -1 Then
			errNewTranscriptionFile.SetIconAlignment(cbCounty, ErrorIconAlignment.MiddleLeft)
			errNewTranscriptionFile.SetError(cbCounty, My.Resources.err0009)
			e.Cancel = True
		Else
		End If
	End Sub

	Private Sub cbRecordType_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbRecordType.Validating
		If cbRecordType.SelectedIndex = -1 Then
			errNewTranscriptionFile.SetIconAlignment(cbRecordType, ErrorIconAlignment.MiddleLeft)
			errNewTranscriptionFile.SetError(cbRecordType, My.Resources.err0008)
			e.Cancel = True
		Else
		End If
	End Sub

	Private Function BuildFileName() As String
		Dim x As Integer = 1
		Dim t_Filename As String

		fileSuffix = String.Empty
		If nudSuffix.Value > 0 Then fileSuffix = nudSuffix.Value.ToString()
		t_Filename = fileCounty + filePlace + fileType + fileSuffix
		While File.Exists(MyTranscripts & "\" & t_Filename & ".CSV")
			fileSuffix = Format(x, "#")
			x = x + 1
			t_Filename = fileCounty + filePlace + fileType + fileSuffix
		End While

		' We now have a list of filees from both the PC and FreeREG
		' is there any need to to this File.Exists check?
		' Can't we just see whether the file is in the list?
		If freeregFiles IsNot Nothing Then
			Dim dt As DataTable = freeregFiles.Tables("FreeRegFiles")
			Dim dr As DataRow
			dr = dt.Rows.Find(t_Filename + ".CSV")
			While dr IsNot Nothing
				fileSuffix = Format(x, "#")
				x = x + 1
				t_Filename = fileCounty + filePlace + fileType + fileSuffix
				dr = dt.Rows.Find(t_Filename + ".CSV")
			End While
		End If

		If fileSuffix = String.Empty Then nudSuffix.Value = 0 Else nudSuffix.Value = fileSuffix
		Return fileCounty + filePlace + fileType + fileSuffix + ".CSV"
	End Function

	Private Sub cbCounty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCounty.SelectedIndexChanged
		If cbCounty.SelectedIndex <> -1 Then
			Dim row As ChapmanCodesRow = cbCounty.SelectedItem().row
			fileCounty = row.Code
			_File.County = row.County
			_File.CountyCode = row.Code
		Else
			fileCounty = "   "
			_File.County = String.Empty
			_File.CountyCode = String.Empty
		End If
		txtFileName.Text = BuildFileName()
	End Sub

	Private Sub cbRecordType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRecordType.SelectedIndexChanged
		If cbRecordType.SelectedIndex <> -1 Then
			Dim row As RecordTypesRow = cbRecordType.SelectedItem().row
			fileType = row.Type
			_File.FileType = row.Description.ToUpper
		Else
			fileType = "  "
		End If
		txtFileName.Text = BuildFileName()
		labColumnLayout.Visible = False
		labColumnLayout.Enabled = False
		cbScreenLayouts.Visible = False
		cbScreenLayouts.Enabled = False

		Dim cols As List(Of ColumnLayout) = New List(Of ColumnLayout)()
		cols.Add(New ColumnLayout(ColumnLayoutType.DefaultLayout, "<Default>", String.Empty))
		cols.Add(New ColumnLayout(ColumnLayoutType.LastUsed, "<Last used>", String.Empty))

		If fileType <> "  " Then
			Try
				' Obtain the file system entries in the directory path.
				Dim directoryEntries As String() = System.IO.Directory.GetFiles(WinREG.MainForm._BaseDataDirectory + "\Screen Layouts", "*." + fileType, SearchOption.TopDirectoryOnly)
				If directoryEntries.Length > 0 Then
					For Each Str As String In directoryEntries
						Dim li As ColumnLayout = New ColumnLayout(ColumnLayoutType.File, Path.GetFileNameWithoutExtension(Str), Str)
						cols.Add(li)
					Next
				End If

			Catch exp As ArgumentNullException
				System.Console.WriteLine("Path is a null reference.")
			Catch exp As System.Security.SecurityException
				System.Console.WriteLine("The caller does not have the required permission.")
			Catch exp As ArgumentException
				System.Console.WriteLine("Path is an empty string, contains only white spaces, or contains invalid characters.")
			Catch exp As System.IO.DirectoryNotFoundException
				System.Console.WriteLine("The path encapsulated in the Directory object does not exist.")
			End Try
		End If

		labColumnLayout.Visible = True
		labColumnLayout.Enabled = True
		cbScreenLayouts.Visible = True
		cbScreenLayouts.Enabled = True
		cbScreenLayouts.DataSource = cols
		cbScreenLayouts.DisplayMember = "Name"
		If cbScreenLayouts.Items.Count > 2 Then
			cbScreenLayouts.SelectedItem = cbScreenLayouts.Items(2)
		Else
			cbScreenLayouts.SelectedItem = cbScreenLayouts.Items(0)
		End If

	End Sub

	Private Sub txtPlaceName_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlaceName.Validated
		' Parish name needs capitalisation of words, ignoring things like 'the' and 'of'
		Dim cursor As Integer = txtPlaceName.SelectionStart
		Dim sTemp As String = txtPlaceName.Text.Trim.ToLower()
		Dim ci As CultureInfo = CultureInfo.CurrentCulture
		Dim ti As TextInfo = ci.TextInfo
		txtPlaceName.Text = ti.ToTitleCase(sTemp)
		txtPlaceName.SelectionStart = cursor

		'
		'	There must be some way of "codifying" this
		'		A table of basic words, and their abbreviation(s), that can be ignored
		'			abbreviations can be extended with ',' or '.' or ' '
		'		If place starts with the 'word' + ' ' or one of the abbreviations
		'			then it is ignored. Look at next word if any.
		'		If we can't pick 3 characters, take the first 3 non-blanks.
		'
		If sTemp.ToUpper.StartsWith("ST,") Or sTemp.ToUpper.StartsWith("ST.") Or sTemp.ToUpper.StartsWith("ST ") Or sTemp.ToUpper.StartsWith("SAINT ") Then
			filePlace = SaintsPlacename(sTemp.ToUpper)
		Else
			If sTemp.ToUpper.StartsWith("CO,") Or sTemp.ToUpper.StartsWith("CO.") Or sTemp.ToUpper.StartsWith("CO ") Or sTemp.ToUpper.StartsWith("COUNTY ") Then
				filePlace = CountyPlacename(sTemp.ToUpper)
			Else
				If sTemp.ToUpper.StartsWith("N,") Or sTemp.ToUpper.StartsWith("N.") Or sTemp.ToUpper.StartsWith("N ") Or sTemp.ToUpper.StartsWith("NORTH ") Or _
				 sTemp.ToUpper.StartsWith("S,") Or sTemp.ToUpper.StartsWith("S.") Or sTemp.ToUpper.StartsWith("S ") Or sTemp.ToUpper.StartsWith("SOUTH ") Or _
				 sTemp.ToUpper.StartsWith("E,") Or sTemp.ToUpper.StartsWith("E.") Or sTemp.ToUpper.StartsWith("E ") Or sTemp.ToUpper.StartsWith("EAST ") Or _
				 sTemp.ToUpper.StartsWith("W,") Or sTemp.ToUpper.StartsWith("W.") Or sTemp.ToUpper.StartsWith("W ") Or sTemp.ToUpper.StartsWith("WEST ") Then
					filePlace = DirectionPlacename(sTemp.ToUpper)
				Else
					If sTemp.ToUpper.StartsWith("GT,") Or sTemp.ToUpper.StartsWith("GT.") Or sTemp.ToUpper.StartsWith("GT ") Or sTemp.ToUpper.StartsWith("GREAT ") Or _
					 sTemp.ToUpper.StartsWith("LT,") Or sTemp.ToUpper.StartsWith("LT.") Or sTemp.ToUpper.StartsWith("LT ") Or sTemp.ToUpper.StartsWith("LITTLE ") Then
						filePlace = DirectionPlacename(sTemp.ToUpper)
					Else
						filePlace = NormalSubstring(sTemp.ToUpper)
					End If
				End If
			End If
		End If
		txtPlaceCode.Text = filePlace
		txtFileName.Text = BuildFileName()
	End Sub

	Private Sub txtPlaceCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlaceCode.Validated
		filePlace = txtPlaceCode.Text
		txtFileName.Text = BuildFileName()
	End Sub

	Private Sub txtChurchName_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChurchName.Validated
		' Church name needs capitalisation of words, ignoring things like 'the' and 'of'
		Dim cursor As Integer = txtChurchName.SelectionStart
		Dim sTemp As String = txtChurchName.Text.Trim.ToLower()
		Dim ci As CultureInfo = CultureInfo.CurrentCulture
		Dim ti As TextInfo = ci.TextInfo
		txtChurchName.Text = ti.ToTitleCase(sTemp)
		txtChurchName.SelectionStart = cursor
	End Sub

	Private Function NormalSubstring(ByVal fullname As String) As String
		Dim str As String = "ZZZ"
		Dim charSeparators() As Char = {"."c, " "c, ","c}
		Dim words() As String

		words = fullname.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
		For Each s As String In words
			If s.Length >= 3 Then
				Return s.Substring(0, 3)
			End If
		Next

		Return str
	End Function

	Private Function SaintsPlacename(ByVal Fullname As String) As String
		Dim str As String = "SAI"
		Dim charSeparators() As Char = {"."c, " "c, ","c}
		Dim words() As String

		words = Fullname.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
		If words.Length > 1 Then
			For Each s As String In words
				If s.Length >= 3 Then
					If s <> "SAINT" Then
						Return s.Substring(0, 3)
					End If
				End If
			Next
		End If

		Return str
	End Function

	Private Function CountyPlacename(ByVal Fullname As String) As String
		Dim str As String = "COU"
		Dim charSeparators() As Char = {"."c, " "c, ","c}
		Dim words() As String

		words = Fullname.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
		If words.Length >= 2 Then
			If words(1).Length >= 3 Then
				Return words(1).Substring(0, 3)
			End If
		End If

		Return str
	End Function

	Private Function DirectionPlacename(ByVal Fullname As String) As String
		Dim str As String = Fullname.Substring(0, 3)
		Dim charSeparators() As Char = {"."c, " "c, ","c}
		Dim words() As String

		words = Fullname.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
		If words.Length >= 2 Then
			str = words(0).Substring(0, 1) & words(1).Substring(0, 2)
		End If

		Return str
	End Function

	Private Sub txtSource_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSource.KeyPress, txtComments.KeyPress
		Dim c As Char = e.KeyChar
		Dim str As String = "?!:;,.+=*-_"

		If Char.IsLetterOrDigit(c) OrElse Char.IsWhiteSpace(c) Then Exit Sub
		If str.IndexOf(c) >= 0 Then Exit Sub
		If e.KeyChar = ChrW(Keys.Back) Then Exit Sub
		Beep()
		e.Handled = True
	End Sub

	Private Sub txtSource_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSource.TextChanged
		If txtSource.Text.IndexOf("("c) >= 0 OrElse txtSource.Text.IndexOf(")"c) >= 0 Then
			errNewTranscriptionFile.SetIconAlignment(txtSource, ErrorIconAlignment.MiddleLeft)
			errNewTranscriptionFile.SetError(txtSource, My.Resources.err0042)
		End If
	End Sub

	Private Sub txtComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged
		If txtComments.Text.IndexOf("("c) >= 0 OrElse txtComments.Text.IndexOf(")"c) >= 0 Then
			errNewTranscriptionFile.SetIconAlignment(txtComments, ErrorIconAlignment.MiddleLeft)
			errNewTranscriptionFile.SetError(txtComments, My.Resources.err0042)
		End If
	End Sub

	Private Sub nudSuffix_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSuffix.ValueChanged
		fileSuffix = nudSuffix.Value.ToString()
		txtFileName.Text = BuildFileName()
	End Sub

	Private Sub cbScreenLayouts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbScreenLayouts.SelectedIndexChanged
		MyScreenLayout = cbScreenLayouts.SelectedItem()
	End Sub

	Private FirstClick As Boolean = True

	Private Sub txtPlaceCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlaceCode.Click
		If FirstClick Then
			CType(sender, TextBox).SelectAll()
			FirstClick = False
		End If
	End Sub

	Private Sub txtPlaceCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlaceCode.GotFocus
		CType(sender, TextBox).SelectAll()
	End Sub

	Private Sub txtPlaceCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlaceCode.LostFocus
		FirstClick = True
	End Sub

	Private Sub txtPlaceCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaceCode.KeyPress
		If Not Char.IsLetterOrDigit(e.KeyChar) Then
			Beep()
			e.Handled = True
		End If
	End Sub

	Private Sub txtCreditTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditTo.TextChanged

	End Sub

	Private Sub txtCreditEmailAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditEmailAddress.TextChanged

	End Sub
End Class

Public Enum ColumnLayoutType
	DefaultLayout
	LastUsed
	File
End Enum

Public Class ColumnLayout
	Dim _type As ColumnLayoutType
	Dim _name As String
	Dim _path As String

	Sub New(ByVal type As ColumnLayoutType, ByVal name As String, ByVal path As String)
		Me.Type = type
		Me.Name = name
		Me.Path = path
	End Sub

	Property Type() As ColumnLayoutType
		Get
			Return _type
		End Get
		Set(ByVal value As ColumnLayoutType)
			_type = value
		End Set
	End Property

	Property Name() As String
		Get
			Return _name
		End Get
		Set(ByVal value As String)
			_name = value
		End Set
	End Property

	Property Path() As String
		Get
			Return _path
		End Get
		Set(ByVal value As String)
			_path = value
		End Set
	End Property
End Class

