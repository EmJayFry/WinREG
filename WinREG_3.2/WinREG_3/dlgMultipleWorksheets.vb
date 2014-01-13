'	$Date: 2012-02-01 15:52:14 +0200 (Wed, 01 Feb 2012) $
'	$Rev: 147 $
'	$Id: dlgMultipleWorksheets.vb 147 2012-02-01 13:52:14Z Mikefry $
'
'	WinREG/3 - Version 3.1.8
'

Imports System.Windows.Forms

Public Class dlgMultipleWorksheets

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
