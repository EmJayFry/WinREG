'	$Date: 2012-02-01 15:52:14 +0200 (Wed, 01 Feb 2012) $
'	$Rev: 147 $
'	$Id: dlgBackupRestore.vb 147 2012-02-01 13:52:14Z Mikefry $
'
'	WinREG/3 - Version 3.1.8
'

Imports System.IO

Public Class dlgBackupRestore
	Dim fRestoreComplete As Boolean = True

	Private Sub dlgBackupRestore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Restore window state & position
		Me.Location = My.Settings.MyBackupRestoreLocation
		Me.WindowState = My.Settings.MyBackupRestoreWindowState

		Me.tabBackupRestore.SelectedIndex = 0
		Dim fileList As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

		If lbBackupFileList.Items.Count() > 0 Then	' Clear the ListBox
			lbBackupFileList.Items.Clear()
		End If

		fileList = My.Computer.FileSystem.GetFiles(My.Settings.DataFolderName, FileIO.SearchOption.SearchTopLevelOnly, "*.csv")
		For Each foundFile As String In fileList
			lbBackupFileList.Items.Add(My.Computer.FileSystem.GetFileInfo(foundFile).Name)
		Next

		btnBackup.Enabled = False
		btnBackup.Visible = False

		If My.Settings.MyDisplayTooltips Then Me.ttBackupRestore.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
	End Sub

	Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
		btnBackup.Enabled = False
		btnBackup.Visible = False
		Close()
	End Sub

	Private Sub dlgBackupRestore_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		My.Settings.MyBackupRestoreWindowState = Me.WindowState

		If Me.WindowState = FormWindowState.Normal Then
			My.Settings.MyBackupRestoreLocation = Me.Location
		Else
			My.Settings.MyBackupRestoreLocation = Me.RestoreBounds.Location
		End If
		My.Settings.Save()
	End Sub

	Private Sub lnkBackupFilesFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkBackupFilesFolder.Click
		Try
			System.Diagnostics.Process.Start("explorer.exe", My.Settings.BackupFolderName)
			errBackupRestore.SetError(lnkBackupFilesFolder, "")
		Catch ex As Exception
			errBackupRestore.SetError(lnkBackupFilesFolder, ex.Message())
		End Try
	End Sub

	Private Sub tabBackupRestore_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tabBackupRestore.Selected
		If e.TabPageIndex = 0 Then
			Dim fileList As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

			If lbBackupFileList.Items.Count() > 0 Then	' Clear the ListBox
				lbBackupFileList.Items.Clear()
			End If

			fileList = My.Computer.FileSystem.GetFiles(My.Settings.DataFolderName, FileIO.SearchOption.SearchTopLevelOnly, "*.csv")
			For Each foundFile As String In fileList
				lbBackupFileList.Items.Add(My.Computer.FileSystem.GetFileInfo(foundFile).Name)
			Next

			btnBackup.Enabled = False
			btnBackup.Visible = False
		Else
			Dim fileList As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

			If lbRestoreFileList.Items.Count() > 0 Then	' Clear the ListBox
				lbRestoreFileList.Items.Clear()
			End If

			fileList = My.Computer.FileSystem.GetFiles(My.Settings.BackupFolderName, FileIO.SearchOption.SearchTopLevelOnly, "*.csv")
			For Each foundFile As String In fileList
				lbRestoreFileList.Items.Add(My.Computer.FileSystem.GetFileInfo(foundFile).Name)
			Next

			btnBackup.Enabled = False
			btnBackup.Visible = False
		End If

	End Sub

	Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
		Dim source, dest, msg As String

		If lbBackupFileList.SelectedIndex <> -1 Then
			For Each filename As String In lbBackupFileList.SelectedItems
				source = My.Settings.DataFolderName & "\" & filename
				dest = My.Computer.FileSystem.CombinePath(My.Settings.BackupFolderName, filename)
				Try
					File.Copy(source, dest, True)
					errBackupRestore.SetError(lbBackupFileList, "")
					msg = "File " & filename & " copied to " & My.Settings.BackupFolderName
					MessageBox.Show(msg, "File Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Catch ex As Exception
					Dim strError As String

					strError = ex.ToString()
					errBackupRestore.SetError(lbBackupFileList, strError)
				End Try
			Next
		End If
	End Sub

	Private Sub lbRestoreFileList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbRestoreFileList.SelectedIndexChanged
		btnRestore.Visible = True
		btnRestore.Enabled = True
	End Sub

	Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
		Dim source, dest, msg As String

		If lbRestoreFileList.SelectedIndex <> -1 Then
			For Each filename As String In lbRestoreFileList.SelectedItems
				source = My.Computer.FileSystem.CombinePath(My.Settings.BackupFolderName, lbRestoreFileList.SelectedItem)
				dest = My.Settings.DataFolderName & "\" & lbRestoreFileList.SelectedItem
				Try
					File.Copy(source, dest, True)
					errBackupRestore.SetError(lbRestoreFileList, "")
					msg = "File " & lbRestoreFileList.SelectedItem & " restored from " & My.Settings.BackupFolderName
					MessageBox.Show(msg, "File Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Catch ex As Exception
					Dim strError As String

					strError = ex.ToString()
					errBackupRestore.SetError(lbRestoreFileList, strError)
				End Try
			Next
		End If
	End Sub

	Private Sub lbBackupFileList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbBackupFileList.SelectedIndexChanged
		btnBackup.Visible = True
		btnBackup.Enabled = True
	End Sub

	Private Sub btnBackupAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAllFilesToBackup.Click
		For i As Integer = 0 To lbBackupFileList.Items.Count - 1
			lbBackupFileList.SetSelected(i, True)
		Next
	End Sub

	Private Sub btnRestoreAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAllFilesToRestore.Click
		For i As Integer = 0 To lbRestoreFileList.Items.Count - 1
			lbRestoreFileList.SetSelected(i, True)
		Next
	End Sub

End Class