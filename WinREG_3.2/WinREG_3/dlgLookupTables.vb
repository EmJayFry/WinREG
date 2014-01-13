'	$Date: 2013-09-04 10:36:16 +0200 (Wed, 04 Sep 2013) $
'	$Rev: 228 $
'	$Id: dlgLookupTables.vb 228 2013-09-04 08:36:16Z Mikefry $
'
'	WinREG/3 - Version 3.1.17
'

Imports System.Windows.Forms
Imports WinREG.LookupTables
Imports WinREG.MessageBoxes

Public Class dlgLookupTables
	Public boolTablesChanged As Boolean = False
	Private tableloaded As Boolean = False
	Private strTableName As String

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		If bsTables.DataSource.HasErrors Then
			bsTables.DataSource.RejectChanges()
			boolTablesChanged = False
		Else
			Dim dt = bsTables.DataSource
			Dim added As Integer = 0
			Dim deleted As Integer = 0
			Dim detached As Integer = 0
			Dim unchanged As Integer = 0
			Dim modified As Integer = 0
			Dim other As Integer = 0

			For Each row In dt.Rows
				Select Case row.RowState
					Case DataRowState.Detached
						detached += 1
					Case DataRowState.Unchanged
						unchanged += 1
					Case DataRowState.Added
						added += 1
					Case DataRowState.Deleted
						deleted += 1
					Case DataRowState.Modified
						modified += 1
					Case Else
						other += 1
				End Select
			Next

			bsTables.DataSource.AcceptChanges()
			boolTablesChanged = (added + deleted + modified) > 0
		End If

		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		boolTablesChanged = False
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub dlgLookupTables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		If My.Settings.MyDisplayTooltips Then Me.ttLookupTables.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
		strTableName = bsTables.DataSource.TableName

		Dim idx As Integer = 0
		Select Case strTableName
			Case "BaptismSex"
				dgvTables.AllowUserToAddRows = False
				dgvTables.AllowUserToDeleteRows = False
				For Each row As BaptismSexRow In bsTables.DataSource.Rows
					dgvTables.Rows.Item(idx).ReadOnly = (row.Type = "Application")
					idx += 1
				Next
				BindingNavigatorAddNewItem.Enabled = False
				BindingNavigatorDeleteItem.Enabled = False
				BindingNavigatorSaveData.Enabled = False

			Case "BurialRelationship"
				dgvTables.AllowUserToAddRows = True
				dgvTables.AllowUserToDeleteRows = True
				For Each row As BurialRelationshipRow In bsTables.DataSource.Rows
					If row.RowState = DataRowState.Deleted Then
					Else
						dgvTables.Rows.Item(idx).ReadOnly = (row.Type = "Application")
						idx += 1
					End If
				Next
				BindingNavigatorAddNewItem.Enabled = True
				BindingNavigatorDeleteItem.Enabled = False
				BindingNavigatorSaveData.Enabled = False

			Case "BrideCondition"
				dgvTables.AllowUserToAddRows = True
				dgvTables.AllowUserToDeleteRows = True
				For Each row As BrideConditionRow In bsTables.DataSource.Rows
					If row.RowState = DataRowState.Deleted Then
					Else
						dgvTables.Rows.Item(idx).ReadOnly = (row.Type = "Application")
						idx += 1
					End If
				Next
				BindingNavigatorAddNewItem.Enabled = True
				BindingNavigatorDeleteItem.Enabled = False
				BindingNavigatorSaveData.Enabled = False

			Case "GroomCondition"
				dgvTables.AllowUserToAddRows = True
				dgvTables.AllowUserToDeleteRows = True
				For Each row As GroomConditionRow In bsTables.DataSource.Rows
					If row.RowState = DataRowState.Deleted Then
					Else
						dgvTables.Rows.Item(idx).ReadOnly = (row.Type = "Application")
						idx += 1
					End If
				Next
				BindingNavigatorAddNewItem.Enabled = True
				BindingNavigatorDeleteItem.Enabled = False
				BindingNavigatorSaveData.Enabled = False

			Case "RecordTypes"
				dgvTables.AllowUserToAddRows = False
				dgvTables.AllowUserToDeleteRows = False
				For Each row As RecordTypesRow In bsTables.DataSource.Rows
					dgvTables.Rows(idx).ReadOnly = True
					idx += 1
				Next
				BindingNavigatorAddNewItem.Enabled = False
				BindingNavigatorDeleteItem.Enabled = False
				BindingNavigatorSaveData.Enabled = False

			Case "ChapmanCodes"
				dgvTables.AllowUserToAddRows = False
				dgvTables.AllowUserToDeleteRows = False
				For Each row As ChapmanCodesRow In bsTables.DataSource.Rows
					dgvTables.Rows(idx).ReadOnly = True
					idx += 1
				Next
				BindingNavigatorAddNewItem.Enabled = False
				BindingNavigatorDeleteItem.Enabled = False
				BindingNavigatorSaveData.Enabled = False

		End Select

		CType(bsTables.DataSource, DataTable).AcceptChanges()
		tableloaded = True
	End Sub

	Private Sub dgvTables_DefaultValuesNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvTables.DefaultValuesNeeded
		With e.Row
			.Cells("Type").Value = "User"
			.Cells("FileValue").Value = String.Empty
			.Cells("DisplayValue").Value = String.Empty
		End With
	End Sub

	Private Sub dgvTables_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvTables.DataError
		MessageBox.Show(e.Exception.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		dgvTables.Rows(e.RowIndex).ErrorText = e.Exception.Message
		e.Cancel = True
	End Sub

	Private Sub dgvTables_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvTables.SelectionChanged
		For Each row In dgvTables.SelectedRows
			If row.Cells.Count = 3 Then
				If Not IsDBNull(row.cells("Type").value) Then
					If row.cells("Type").value = "Application" Then
						BindingNavigatorDeleteItem.Enabled = False
						dgvTables.Rows(row.index).ReadOnly = True
					Else
						BindingNavigatorDeleteItem.Enabled = True
					End If
				End If
			Else
				BindingNavigatorDeleteItem.Enabled = False
				dgvTables.Rows(row.index).ReadOnly = True
			End If
		Next
	End Sub

	Private Sub dgvTables_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTables.UserDeletingRow
		If e.Row.Cells("Type").Value = "Application" Then
			MessageBox.Show(My.Resources.msgDeletingTableRecord, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0010)
			e.Cancel = True
		End If
	End Sub

End Class
