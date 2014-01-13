'	$Date: 2011-06-08 16:47:04 +0200 (Wed, 08 Jun 2011) $
'	$Rev: 144 $
'	$Id: FileDownload.vb 144 2011-06-08 14:47:04Z Mikefry $
'
'	FreeRegBrowser - Version 1.0.3
'

Imports System.Windows.Forms

Public Class FileDownload

	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub
End Class
