Imports System.Windows.Forms

Public Class dlgEditAutoCompletionEntry

	Public strNew As String = ""

	Private Sub dlgEditAutoCompletionEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	End Sub

	Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
		If e.KeyCode = Keys.Return Then
			Me.DialogResult = Windows.Forms.DialogResult.OK
			e.Handled = True
			strNew = Me.TextBox1.Text
			Close()
		End If
	End Sub
End Class
