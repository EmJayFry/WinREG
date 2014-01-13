'	$Date: 2012-12-13 12:23:41 +0200 (Thu, 13 Dec 2012) $
'	$Rev: 188 $
'	$Id: dlgEditFileName.vb 188 2012-12-13 10:23:41Z Mikefry $
'
'	WinREG/3 - Version 3.1.8
'

Imports System.Windows.Forms

Public Class dlgEditFileName

	Private Sub dlgEditFileName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Restore window state & position
		Me.Location = My.Settings.MyEditFileNameLocation
		Me.WindowState = My.Settings.MyEditFileNameWindowState
		ttRenameFile.Active = My.Settings.MyDisplayTooltips
		If My.Settings.MyDisplayTooltips Then
			ttRenameFile.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
		End If

		Dim name As String = lblFileName.Text.Substring(0, 3) & "   " & lblFileName.Text.Substring(6)
		Dim mask As String = ""
		Dim maskChars As String = "09#L?&CAa.,:/$<>\"

		For i As Integer = 0 To name.Length() - 1
			If maskChars.Contains(name.Substring(i, 1)) Then
				mask += "\"
			End If
			mask += name.Substring(i, 1)
		Next

		cboCountyList.DataSource = MainForm.tabChapmanCodes
		cboCountyList.DisplayMember = "County"
		cboCountyList.ValueMember = "Code"
		cboCountyList.SelectedValue = lblFileName.Text.Substring(0, 3)

		mtbFileName.AsciiOnly = False
		mtbFileName.BeepOnError = True
		mtbFileName.Mask = mask.Replace("   ", ">AAA")
		Me.OK_Button.Enabled = False
	End Sub

	Private Sub dlgEditFileName_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
		My.Settings.MyEditFileNameWindowState = Me.WindowState

		If Me.WindowState = FormWindowState.Normal Then
			My.Settings.MyEditFileNameLocation = Me.Location
		Else
			My.Settings.MyEditFileNameLocation = Me.RestoreBounds.Location
		End If
		My.Settings.Save()
	End Sub

	Private Sub mtbFileName_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mtbFileName.MaskInputRejected
		ttRenameFile.ToolTipTitle = "Invalid Input"
		ttRenameFile.ToolTipIcon = ToolTipIcon.Error
		ttRenameFile.Show(My.Resources.err0033, mtbFileName, 5000)
	End Sub

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		If mtbFileName.MaskCompleted And mtbFileName.MaskFull Then
		Else
			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		End If
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub mtbFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtbFileName.TextChanged
		If mtbFileName.MaskCompleted And mtbFileName.MaskFull Then
			errRenameFile.SetError(mtbFileName, "")
			Me.OK_Button.Enabled = True
		Else
			errRenameFile.SetIconAlignment(mtbFileName, ErrorIconAlignment.MiddleLeft)
			errRenameFile.SetError(mtbFileName, My.Resources.err0033)
			Me.OK_Button.Enabled = False
		End If
	End Sub

	Private Sub mtbFileName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtbFileName.Validating

	End Sub

	Private Sub mtbFileName_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtbFileName.Validated

	End Sub

	Private Sub chkChangeCounty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChangeCounty.CheckedChanged
		cboCountyList.Enabled = chkChangeCounty.Checked
		If Not chkChangeCounty.Checked Then
			If lblFileName.Text.Substring(0, 3) <> mtbFileName.Mask.Substring(0, 3) Then
				Dim newMask As String = mtbFileName.Mask.Replace(cboCountyList.SelectedValue, lblFileName.Text.Substring(0, 3))
				Dim newText As String = mtbFileName.Text.Replace(cboCountyList.SelectedValue, lblFileName.Text.Substring(0, 3))
				mtbFileName.Mask = newMask
				mtbFileName.Text = newText
			End If
		End If
	End Sub

	Private Sub cboCountyList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCountyList.SelectedIndexChanged
		If cboCountyList.SelectedIndex <> -1 Then
			If mtbFileName.Mask <> String.Empty Then
				If lblFileName.Text.Substring(0, 3) <> cboCountyList.SelectedValue Then
					Dim newMask As String = mtbFileName.Mask.Replace(lblFileName.Text.Substring(0, 3), cboCountyList.SelectedValue)
					Dim newText As String = mtbFileName.Text.Replace(lblFileName.Text.Substring(0, 3), cboCountyList.SelectedValue)
					mtbFileName.Mask = newMask
					mtbFileName.Text = newText
				End If
			End If
		End If
	End Sub
End Class
