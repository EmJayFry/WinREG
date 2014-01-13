'	$Date: 2013-09-05 11:09:11 +0200 (Thu, 05 Sep 2013) $
'	$Rev: 231 $
'	$Id: dlgBadRecords.vb 231 2013-09-05 09:09:11Z Mikefry $
'
'	WinREG/3 - Version 3.1.17
'
Imports System.Windows.Forms
Imports WinREG.BadRecordsDataSet

Public Class dlgBadRecords
	Private _OriginalTable As BadRecordsDataTable
	Private _badRecords As BadRecordsDataTable
	Private _SelectedBadRecord As BadRecordsRow
	Private _Index As Integer
	Private _updated As Boolean

	Sub New(ByRef badrecords As BadRecordsDataTable)
		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		_OriginalTable = badrecords
		_badRecords = badrecords.Copy()
		_updated = False
	End Sub

	ReadOnly Property DataHasBeenUpdated() As Boolean
		Get
			Return _updated
		End Get
	End Property

	ReadOnly Property GetUpdatedRecords() As List(Of BadRecordsRow)
		Get
			Dim results As New List(Of BadRecordsRow)
			Dim workTable As BadRecordsDataTable = _badRecords.Copy()
			For Each row In workTable
				Dim original = _OriginalTable.FindByRowNumber(row.RowNumber)
				If row.OriginalSource <> original.OriginalSource Then
					results.Add(row)
				End If
			Next

			Return results
		End Get
	End Property

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub btnEditBadRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditBadRecord.Click
		Dim workTable As BadRecordsDataTable = _badRecords.Copy()
		Dim SelectedBadRecord As BadRecordsRow = workTable.Rows(_Index)
		Dim dlg = New dlgEditBadRecord(SelectedBadRecord)
		Dim rc = dlg.ShowDialog()
		If rc = Windows.Forms.DialogResult.OK Then
			Dim OriginalBadRecord As BadRecordsRow = _badRecords.Rows(_Index)
			If OriginalBadRecord.OriginalSource <> SelectedBadRecord.OriginalSource Then
				OriginalBadRecord.OriginalSource = SelectedBadRecord.OriginalSource
				OriginalBadRecord.csv = SelectedBadRecord.csv
				OriginalBadRecord.ErrorMessage = "Record updated. Awaiting re-validation"
				OriginalSourceTextBox.Text = OriginalBadRecord.OriginalSource
				ErrorMessageLabel1.Text = OriginalBadRecord.ErrorMessage
				btnEditBadRecord.Enabled = False
				_updated = True
			End If
		End If
	End Sub

	Private Sub dlgBadRecords_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		BadRecordsBindingSource.DataSource = _badRecords
	End Sub

	Private Sub BadRecordsBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BadRecordsBindingSource.CurrentChanged
		Dim i As DataRowView = BadRecordsBindingSource.Current
		_SelectedBadRecord = i.Row
		_Index = _badRecords.Rows.IndexOf(_SelectedBadRecord)
		RowNumberTextBox.Text = _SelectedBadRecord.RowNumber.ToString()
		ErrorMessageLabel1.Text = _SelectedBadRecord.ErrorMessage
		OriginalSourceTextBox.Text = _SelectedBadRecord.OriginalSource
		btnEditBadRecord.Enabled = Not (_SelectedBadRecord.ErrorMessage = "Record updated. Awaiting re-validation")
	End Sub
End Class
