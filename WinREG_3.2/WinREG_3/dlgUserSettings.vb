'	$Date: 2012-02-01 15:52:14 +0200 (Wed, 01 Feb 2012) $
'	$Rev: 147 $
'	$Id: dlgUserSettings.vb 147 2012-02-01 13:52:14Z Mikefry $
'
'	WinREG/3 - Version 3.1.8
'

Public Class dlgUserSettings
	Dim fRestoreComplete As Boolean = True

	Private Sub UserSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		My.Settings.MyUserSettingsWindowState = Me.WindowState

		If Me.WindowState = FormWindowState.Normal Then
			My.Settings.MyUserSettingsSize = Me.Size
			My.Settings.MyUserSettingsLocation = Me.Location
		Else
			My.Settings.MyUserSettingsSize = Me.RestoreBounds.Size
			My.Settings.MyUserSettingsLocation = Me.RestoreBounds.Location
		End If
		My.Settings.Save()
	End Sub

	Private Sub UserSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Restore window state & position
		Me.Size = My.Settings.MyUserSettingsSize
		Me.Location = My.Settings.MyUserSettingsLocation
		Me.WindowState = My.Settings.MyUserSettingsWindowState

		pgUserSettings.SelectedObject = My.Settings

		' Attribute for the user-scope settings.
		Dim userAttr As New System.Configuration.UserScopedSettingAttribute
		Dim attrs As New System.ComponentModel.AttributeCollection(userAttr)
		pgUserSettings.BrowsableAttributes = attrs

	End Sub

End Class