Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports CaseText

Public Class CaseTextColumn
	Inherits DataGridViewColumn

	Public Sub New()
		MyBase.New(New CaseTextCell())
	End Sub

	Public Overrides Property CellTemplate() As DataGridViewCell
		Get
			Return MyBase.CellTemplate
		End Get
		Set(ByVal value As DataGridViewCell)
			' Ensure that the cell used for the template is a CaseTextCell.
			If (value IsNot Nothing) AndAlso Not value.GetType().IsAssignableFrom(GetType(CaseTextCell)) Then
				Throw New InvalidCastException("Must be a CaseTextCell")
			End If
			MyBase.CellTemplate = value
		End Set
	End Property

End Class

Public Class CaseTextCell
	Inherits DataGridViewTextBoxCell

	Public Sub New()
		' Use the short date format.
		Me.Style.Format = "d"
	End Sub

	Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)

		' Set the value of the editing control to the current cell value.
		MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

		Dim ctl As CaseTextEditingControl = CType(DataGridView.EditingControl, CaseTextEditingControl)
		Try
			ctl.Text = CType(initialFormattedValue, String)

		Catch ex As System.ArgumentOutOfRangeException
			ctl.Text = ""

		Catch ex As System.InvalidCastException
			ctl.Text = ""

		End Try
	End Sub

	Public Overrides ReadOnly Property EditType() As Type
		Get
			' Return the type of the editing contol that CaseTextCell uses.
			Return GetType(CaseTextEditingControl)
		End Get
	End Property

	Public Overrides ReadOnly Property ValueType() As Type
		Get
			' Return the type of the value that CaseTextCell contains.
			Return GetType(String)
		End Get
	End Property

	Public Overrides ReadOnly Property DefaultNewRowValue() As Object
		Get
			' Use the current date and time as the default value.
			Return String.Empty
		End Get
	End Property

	'Protected Overrides Function GetClipboardContent(ByVal rowIndex As Integer, ByVal firstCell As Boolean, ByVal lastCell As Boolean, ByVal inFirstRow As Boolean, ByVal inLastRow As Boolean, ByVal format As String) As Object
	'	Return MyBase.GetClipboardContent(rowIndex, firstCell, lastCell, inFirstRow, inLastRow, format)
	'End Function

End Class

Public Class CaseTextEditingControl
	Inherits CaseText
	Implements IDataGridViewEditingControl

	Private dataGridViewControl As DataGridView
	Private valueIsChanged As Boolean = False
	Private rowIndexNum As Integer

	Public Sub New()
		Me.TextCase = CaseText.CaseType.Normal
	End Sub

	Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue

		Get
			Return Me.Text
		End Get

		Set(ByVal value As Object)
			If TypeOf value Is String Then
				Me.Text = value
			End If
		End Set

	End Property

	Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
		Return Me.Text()
	End Function

	Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
		Me.Font = dataGridViewCellStyle.Font
		Me.ForeColor = dataGridViewCellStyle.ForeColor
		Me.BackColor = dataGridViewCellStyle.BackColor
	End Sub

	Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
		Get
			Return rowIndexNum
		End Get
		Set(ByVal value As Integer)
			rowIndexNum = value
		End Set
	End Property

	Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
		' Let the CaseText handle the keys listed.
		If dataGridViewWantsInputKey Then
			Select Case key And Keys.KeyCode
				Case Keys.OemPeriod, Keys.Home, Keys.End, Keys.Left, Keys.Right, Keys.Delete
					Return True

				Case Keys.Space
					Return True

				Case Else
					Return False
			End Select
		End If
		Return Not dataGridViewWantsInputKey
	End Function

	Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
		If selectAll Then
			Me.SelectAll()
		Else
			Me.SelectionStart = Me.TextLength
			Me.SelectionLength = 0
		End If
	End Sub

	Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
		Get
			Return False
		End Get
	End Property

	Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
		Get
			Return dataGridViewControl
		End Get
		Set(ByVal value As DataGridView)
			dataGridViewControl = value
		End Set
	End Property

	Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
		Get
			Return valueIsChanged
		End Get
		Set(ByVal value As Boolean)
			valueIsChanged = value
		End Set
	End Property

	Public ReadOnly Property EditingControlCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
		Get
			Return MyBase.Cursor
		End Get
	End Property

	'Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
	'	MyBase.OnKeyDown(e)
	'End Sub

	'Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
	'	MyBase.OnKeyPress(e)
	'End Sub

	Protected Overrides Sub OnTextChanged(ByVal eventargs As EventArgs)
		' Notify the DataGridView that the contents of the cell have changed.
		'If column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, True) > column.Width Then
		'	column.Width = column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, True)
		'End If

		Dim column As DataGridViewColumn = Me.dataGridViewControl.Columns(Me.dataGridViewControl.CurrentCellAddress.X)
		Dim bx = column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader, False)
		If bx > column.Width Then
			column.Width = bx
		End If

		valueIsChanged = True
		Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
		MyBase.OnTextChanged(eventargs)
	End Sub

	Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
		If keyData = (Keys.Control Or Keys.X) Then											' CUT
			Beep()
		ElseIf keyData = (Keys.Control Or Keys.C) Then										' COPY
			Beep()
		ElseIf keyData = (Keys.Control Or Keys.V) Then										' PASTE
			Beep()
		End If
		Return MyBase.ProcessCmdKey(msg, keyData)
	End Function
End Class
