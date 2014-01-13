'	$Date: 2011-06-08 16:47:04 +0200 (Wed, 08 Jun 2011) $
'	$Rev: 144 $
'	$Id: FileRename.vb 144 2011-06-08 14:47:04Z Mikefry $
'
'	FreeRegBrowser - Version 1.0.3
'

Imports System.Windows.Forms

Public Class FileRename

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub FileRename_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
		If Me.DialogResult = Windows.Forms.DialogResult.OK Then
			e.Cancel = True
			If Me.txtNewName.Text = "" Or Me.txtNewNameConfirm.Text = "" Then Return
			If Not (Me.txtNewName.Text.EndsWith(".CSV") And Me.txtNewNameConfirm.Text.EndsWith(".CSV")) Then Return
			If Me.txtNewName.Text <> Me.txtNewNameConfirm.Text Then Return
			e.Cancel = False
		End If
	End Sub
End Class
