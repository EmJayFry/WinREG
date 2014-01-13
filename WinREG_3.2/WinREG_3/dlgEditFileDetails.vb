'	$Date: 2013-10-10 13:49:00 +0200 (Thu, 10 Oct 2013) $
'	$Rev: 255 $
'	$Id: dlgEditFileDetails.vb 255 2013-10-10 11:49:00Z Mikefry $
'
'	WinREG/3 - Version 3.1.10
'

Imports System.Windows.Forms

Public Class dlgEditFileDetails
	Public _place As String
	Public _church As String
	Public _source As String
	Public _comments As String
	Public _creditname As String
	Public _creditemail As String

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		If txtPlaceName.Text <> String.Empty AndAlso txtChurch.Text <> String.Empty Then
			_place = txtPlaceName.Text
			_church = txtChurch.Text
			_creditname = txtCreditTo.Text
			_creditemail = txtCreditEmailAddress.Text
			_source = txtSource.Text
			_comments = txtComments.Text
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Close()
		Else
		End If
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub dlgDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Restore window state & position
		'		Me.Size = My.Settings.MyCommonFileDetailsSize
		Me.Location = My.Settings.MyCommonFileDetailsLocation
		Me.WindowState = My.Settings.MyCommonFileDetailsWindowState
		ttAlterDetails.Active = My.Settings.MyDisplayTooltips
		If My.Settings.MyDisplayTooltips Then
			ttAlterDetails.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
		End If

		txtPlaceName.Text = _place
		txtChurch.Text = _church
		txtCreditTo.Text = _creditname
		txtCreditEmailAddress.Text = _creditemail
		txtSource.Text = _source
		txtComments.Text = _comments
		If _place = String.Empty OrElse _church = String.Empty Then OK_Button.Enabled = False
	End Sub

	Private Sub dlgDetails_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		My.Settings.MyCommonFileDetailsWindowState = Me.WindowState

		If Me.WindowState = FormWindowState.Normal Then
			'			My.Settings.MyCommonFileDetailsSize = Me.Size
			My.Settings.MyCommonFileDetailsLocation = Me.Location
		Else
			'			My.Settings.MyCommonFileDetailsSize = Me.RestoreBounds.Size
			My.Settings.MyCommonFileDetailsLocation = Me.RestoreBounds.Location
		End If
		My.Settings.Save()
	End Sub

	Private Sub ttAlterDetails_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ttAlterDetails.Popup
		If e.AssociatedControl.Name = "txtPlaceName" Then
			ttAlterDetails.ToolTipTitle = "Place Name"
		ElseIf e.AssociatedControl.Name = "txtChurch" Then
			ttAlterDetails.ToolTipTitle = "Church"
		ElseIf e.AssociatedControl.Name = "txtSource" Then
			ttAlterDetails.ToolTipTitle = "Source"
		ElseIf e.AssociatedControl.Name = "txtComments" Then
			ttAlterDetails.ToolTipTitle = "Comments"
		ElseIf e.AssociatedControl.Name = "txtCreditTo" Then
			ttAlterDetails.ToolTipTitle = "Credit to"
		ElseIf e.AssociatedControl.Name = "txtCreditEMailAddress" Then
			ttAlterDetails.ToolTipTitle = "Credit to EMail address"
		End If
	End Sub

	Private Sub txtSource_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSource.KeyPress, txtComments.KeyPress
		Dim c As Char = e.KeyChar
		Dim str As String = "?!:;,.+=*-_"
		If Char.IsLetterOrDigit(c) OrElse Char.IsWhiteSpace(c) Then Exit Sub
		If str.IndexOf(c) >= 0 Then Exit Sub
		If e.KeyChar = ChrW(Keys.Back) Then Exit Sub
		Beep()
		e.Handled = True
	End Sub

	Private Sub txtSource_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSource.Validating
		If txtSource.Text.IndexOf("("c) >= 0 OrElse txtSource.Text.IndexOf(")"c) >= 0 Then
			errAlterDetails.SetIconAlignment(txtSource, ErrorIconAlignment.MiddleLeft)
			errAlterDetails.SetError(txtSource, My.Resources.err0042)
			e.Cancel = True
		End If
	End Sub

	Private Sub txtComments_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtComments.Validating
		If txtComments.Text.IndexOf("("c) >= 0 OrElse txtComments.Text.IndexOf(")"c) >= 0 Then
			errAlterDetails.SetIconAlignment(txtComments, ErrorIconAlignment.MiddleLeft)
			errAlterDetails.SetError(txtComments, My.Resources.err0042)
			e.Cancel = True
		End If
	End Sub

	Private Sub txtSource_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSource.Validated, txtComments.Validated
		errAlterDetails.SetError(sender, "")
	End Sub

	Private Sub txtSource_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSource.TextChanged
		If txtSource.Text.IndexOf("("c) >= 0 OrElse txtSource.Text.IndexOf(")"c) >= 0 Then
			errAlterDetails.SetIconAlignment(txtSource, ErrorIconAlignment.MiddleLeft)
			errAlterDetails.SetError(txtSource, My.Resources.err0042)
		End If
	End Sub

	Private Sub txtComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged
		If txtComments.Text.IndexOf("("c) >= 0 OrElse txtComments.Text.IndexOf(")"c) >= 0 Then
			errAlterDetails.SetIconAlignment(txtComments, ErrorIconAlignment.MiddleLeft)
			errAlterDetails.SetError(txtComments, My.Resources.err0042)
		End If
	End Sub

	Private Sub txtPlaceName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlaceName.TextChanged
		If txtPlaceName.Text = String.Empty Then
			If OK_Button.Enabled Then OK_Button.Enabled = False
		Else
			If OK_Button.Enabled = False AndAlso txtChurch.Text <> String.Empty Then OK_Button.Enabled = True
		End If
	End Sub

	Private Sub txtChurch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChurch.TextChanged
		If txtChurch.Text = String.Empty Then
			If OK_Button.Enabled Then OK_Button.Enabled = False
		Else
			If OK_Button.Enabled = False AndAlso txtPlaceName.Text <> String.Empty Then OK_Button.Enabled = True
		End If
	End Sub

	Private Sub txtCreditTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditTo.TextChanged

	End Sub

	Private Sub txtCreditEmailAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditEmailAddress.TextChanged

	End Sub
End Class
