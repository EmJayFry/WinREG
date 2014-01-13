'	$Date: 2012-11-21 11:55:10 +0200 (Wed, 21 Nov 2012) $
'	$Rev: 177 $
'	$Id: dlgExcelFileDetails.vb 177 2012-11-21 09:55:10Z Mikefry $
'
'	WinREG/3 - Version 3.1.10
'

Imports System.Windows.Forms
Imports WinREG.MainForm

Public Class dlgExcelFileDetails

	Dim f As Boolean = False

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		If f Then
			WinREG.MainForm._File.EmailAddress = My.Settings.EmailAddress
			WinREG.MainForm._File.Username = My.Settings.Name
		End If
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub dlgExcelFileDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		lblUsername.Text = My.Settings.Name
		lblEmailAddress.Text = My.Settings.EmailAddress
		txtFileHeaders.Text = CompileHeaders(WinREG.MainForm._File.Username, WinREG.MainForm._File.EmailAddress, WinREG.MainForm._Encoding.CodePage)

		If WinREG.MainForm._File.EmailAddress <> My.Settings.EmailAddress OrElse WinREG.MainForm._File.Username <> My.Settings.Name Then
			btnApply.Enabled = True
		End If
	End Sub

	Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
		txtFileHeaders.Text = CompileHeaders(My.Settings.Name, My.Settings.EmailAddress, WinREG.MainForm._Encoding.CodePage)
		btnApply.Enabled = False
		f = True
	End Sub

	Private Function CompileHeaders(ByVal name As String, ByVal email As String, ByVal codepage As Integer) As String
		Dim Line1, Line2, Line3, Line4 As String
		Dim cp As String = ","
		If codepage = 437 Then cp = ",cp437"
		If codepage = 850 Then cp = ",cp850"
		Dim fv As String = String.Format(",{0}.{1:00}.{2:00}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)

		Line1 = "+INFO," & WinREG.MainForm.QuoteString(email) & "," & WinREG.MainForm.QuoteString(WinREG.MainForm._File.Password) & ",SEQUENCED," & WinREG.MainForm.QuoteString(WinREG.MainForm._File.FileType) & cp & fv
		Line2 = "#,CCC," & WinREG.MainForm.QuoteString(name) & "," & WinREG.MainForm.QuoteString(WinREG.MainForm._File.CountyCode) & "," & WinREG.MainForm.QuoteString(WinREG.MainForm._File.Filename) & "," & WinREG.MainForm._File.DateLastUpdated
		Line3 = "#,CREDIT," & WinREG.MainForm.QuoteString(WinREG.MainForm._File.CreditToName) & "," & WinREG.MainForm.QuoteString(WinREG.MainForm._File.CreditToAddress)
		Line4 = "#," & WinREG.MainForm._File.DateCreated & "," & WinREG.MainForm.QuoteString(WinREG.MainForm._File.FileSource) & "," & WinREG.MainForm.QuoteString(WinREG.MainForm._File.FileComments)
		CompileHeaders = Line1 + vbCrLf + Line2 + vbCrLf + Line3 + vbCrLf + Line4 + vbCrLf
		If WinREG.MainForm.ldsFile Then
			CompileHeaders += "+LDS"
		End If
	End Function

End Class
