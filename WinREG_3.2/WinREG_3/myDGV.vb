Imports System.Collections.Specialized

'	$Date: 2013-11-30 11:19:43 +0200 (Sat, 30 Nov 2013) $
'	$Rev: 275 $
'	$Id: myDGV.vb 275 2013-11-30 09:19:43Z Mikefry $
'
'	WinREG/3 - Version 3.1.16
'

Public Class myDGV
	Inherits DataGridView

	Public Structure CellContents
		Dim row As Integer
		Dim col As Integer
		Dim str As String
	End Structure

	Public Structure UndoItem
		Dim desc As String
		Dim items As System.Collections.ObjectModel.Collection(Of CellContents)
	End Structure

	Private stackUndo As Stack(Of UndoItem) = New Stack(Of UndoItem)

	Private _rowOffset As Integer
	Public Property RowOffset() As Integer
		Get
			Return _rowOffset
		End Get
		Set(ByVal value As Integer)
			_rowOffset = value
		End Set
	End Property

	Public Sub New()
		InitializeComponent()
		DoubleBuffered = True
	End Sub

	Private Sub InitializeComponent()
		CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
	End Sub

	Public Function CurrentColumnLayout() As StringCollection
		CurrentColumnLayout = New StringCollection()
		For Each column As DataGridViewColumn In Me.Columns
			CurrentColumnLayout.Add(String.Format("{0},{1},{2},{3},{4}", column.DisplayIndex.ToString("D2"), column.Width, column.Visible, column.Index, column.Name))
		Next
	End Function

	Public Sub SetColumnLayout(ByVal strCollection As StringCollection)
		Dim colsArray() As String = New String() {}
		Dim i As Integer
		Dim a() As String
		Dim index As Integer

		If strCollection IsNot Nothing Then
			ReDim colsArray(strCollection.Count)
			strCollection.CopyTo(colsArray, 0)
			Array.Sort(colsArray)
			For i = 1 To colsArray.Length - 1 Step 1
				If colsArray(i - 1) IsNot Nothing Then
					a = colsArray(i - 1).Split(","c)
					index = Integer.Parse(a(3))
					If a(4) <> "County" Then
						Me.Columns(index).DisplayIndex = Integer.Parse(a(0))
						Me.Columns(index).Width = Integer.Parse(a(1))
						Me.Columns(index).Visible = Boolean.Parse(a(2))
					Else
						Me.Columns(index).Visible = False
					End If
				End If
			Next
		End If
	End Sub

	Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
		Dim key As Keys = (keyData And Keys.KeyCode)
		If key = Keys.Enter Then
			Return ProcessRightKey(keyData)
		End If
		If key = Keys.Down Then
			Return ProcessDownKey(keyData)
		End If
		If keyData = Keys.F11 Then
			If Me.RowCount > 1 Then
				If Me.CurrentRow.Index = Me.RowCount - 1 Then
					Me.CurrentRow().Cells(Me.CurrentCell.ColumnIndex).Value = Me.Rows(Me.CurrentRow.Index - 1).Cells(Me.CurrentCell.ColumnIndex).Value
					Return True
				End If
			End If
		End If
		Return MyBase.ProcessDialogKey(keyData)
	End Function

	Public Overloads Function ProcessRightKey(ByVal keyData As Keys) As Boolean
		Dim key As Keys = (keyData And Keys.KeyCode)
		If key = Keys.Enter Then
			Dim strCollection As StringCollection = CurrentColumnLayout()
			Dim colsArray() As String = New String() {}
			Dim i As Integer
			Dim a() As String
			Dim index As Integer
			Dim bVisible As Boolean
			Dim iLastVisible As Integer = -1, iDisplay As Integer
			Dim col As String = Nothing

			If strCollection IsNot Nothing Then
				ReDim colsArray(strCollection.Count)
				strCollection.CopyTo(colsArray, 0)
				Array.Sort(colsArray)
				For i = 1 To colsArray.Length - 1 Step 1
					If colsArray(i - 1) IsNot Nothing Then
						a = colsArray(i - 1).Split(","c)
						index = Integer.Parse(a(3))
						bVisible = Boolean.Parse(a(2))
						If bVisible Then
							iDisplay = Integer.Parse(a(0))
							If iDisplay > iLastVisible Then
								iLastVisible = iDisplay
								col = a(4)
							End If
						End If
					End If
				Next
			End If

			If MyBase.CurrentCell.OwningColumn.Name = col AndAlso MyBase.CurrentCell.RowIndex = (MyBase.RowCount - 1) Then
				MyBase.FirstDisplayedScrollingColumnIndex = MyBase.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index
				MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(FirstDisplayedScrollingColumnIndex)

				MainForm.BindingNavigatorAddNewItem.PerformClick()
				Return True
			End If

			If MyBase.CurrentCell.OwningColumn.Name = col AndAlso MyBase.CurrentCell.RowIndex + 1 <> (MyBase.NewRowIndex) Then
				MyBase.FirstDisplayedScrollingColumnIndex = MyBase.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index
				MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex + 1).Cells(FirstDisplayedScrollingColumnIndex)
				Return True
			End If
			Return MyBase.ProcessRightKey(keyData)
		End If
		Return MyBase.ProcessRightKey(keyData)
	End Function

	Public Overloads Function ProcessDownKey(ByVal keyData As Keys) As Boolean
		Dim key As Keys = (keyData And Keys.KeyCode)
		If key = Keys.Down Then
			If MyBase.CurrentCell.RowIndex = (MyBase.RowCount - 1) Then
				MyBase.FirstDisplayedScrollingColumnIndex = MyBase.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index
				MyBase.CurrentCell = MyBase.Rows(MyBase.CurrentCell.RowIndex).Cells(MyBase.FirstDisplayedScrollingColumnIndex)
				MainForm.BindingNavigatorAddNewItem.PerformClick()
				Return True
			End If
		End If
		Return MyBase.ProcessDownKey(keyData)
	End Function

	'	<System.Security.Permissions.UIPermission(System.Security.Permissions.SecurityAction.LinkDemand, Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)> _
	Protected Overrides Function ProcessDataGridViewKey(ByVal e As KeyEventArgs) As Boolean
		' If user pressed Ctrl+A, bypass base class to prevent row selection 
		If e.KeyCode = Keys.A AndAlso e.Control Then
			Return True
		End If

		If e.KeyCode = Keys.Enter Then
			Return ProcessRightKey(e.KeyData)
		End If
		If e.KeyCode = Keys.Down Then
			Return ProcessDownKey(e.KeyData)
		End If

		Return MyBase.ProcessDataGridViewKey(e)
	End Function

	'	<System.Security.Permissions.UIPermission(System.Security.Permissions.SecurityAction.LinkDemand, Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)> _
	Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
		If keyData = (Keys.Control Or Keys.X) Then										' CUT
			MainForm.CutDataGridToClipboard()
			Return True
		ElseIf keyData = (Keys.Control Or Keys.C) Then									' COPY
			MainForm.CopyDataGridToClipboard()
			Return True
		ElseIf keyData = (Keys.Control Or Keys.V) Then									' PASTE
			MainForm.PasteClipboardToDataGrid()
			Return True
		ElseIf keyData = (Keys.Control Or Keys.Z) Then									' UNDO
			UnDo()
			Return True
		ElseIf keyData = (Keys.Control Or Keys.Alt Or Keys.C) Then					' DUPLICATE RECORD
			MainForm.DuplicateRecord(MyBase.CurrentRow)
			Return True
		End If
		Return MyBase.ProcessCmdKey(msg, keyData)
	End Function

	Public Overrides Function GetClipboardContent() As System.Windows.Forms.DataObject
		Return MyBase.GetClipboardContent()
	End Function

	Public Sub UnDoable(ByVal desc As String, ByVal items As System.Collections.ObjectModel.Collection(Of CellContents))
		Dim undoItem As UndoItem = New UndoItem

		undoItem.desc = desc
		undoItem.items = items
		stackUndo.Push(undoItem)
	End Sub

	Public Function CanUndo() As Boolean
		CanUndo = False
		If stackUndo.Count > 0 Then CanUndo = True
	End Function

	Public Sub UnDo()
		If stackUndo.Count > 0 Then
			Dim item As UndoItem = stackUndo.Pop()
			For Each i As CellContents In item.items
				With i
					Me.Item(.col, .row).Value() = .str
				End With
			Next
		Else
			Beep()
		End If
	End Sub

	Protected Overloads Overrides Sub OnCellMouseDown(ByVal e As DataGridViewCellMouseEventArgs)
		' If user clicked on top left headers cell, bypass base class 
		' to prevent row selection 
		If e.ColumnIndex = -1 AndAlso e.RowIndex = -1 Then
			Return
		End If

		' Otherwise, do normal processing 
		MyBase.OnCellMouseDown(e)
	End Sub

	Protected Overloads Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
		' If mouse cursor is over top left headers cell, bypass base class 
		' to prevent highlighting of cell 
		If e.Y < Me.ColumnHeadersHeight + SystemInformation.BorderSize.Width AndAlso e.X < Me.RowHeadersWidth + SystemInformation.BorderSize.Width Then
			Me.Cursor = Cursors.Arrow

			Return
		End If

		' Otherwise, do normal processing 
		MyBase.OnMouseMove(e)
	End Sub

	Protected Overrides Sub OnCellPainting(ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)

		If e.ColumnIndex = -1 Then
			' This is the TopLeftHeaderCell
			If e.RowIndex = -1 Then
				Dim newRect As New Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4)
				Dim backColorBrush As New SolidBrush(e.CellStyle.BackColor)
				Dim gridBrush As New SolidBrush(Me.GridColor)
				Dim gridLinePen As New Pen(gridBrush)

				Try

					' Erase the cell.
					e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

					' Draw the grid lines (only the right and bottom lines;
					' DataGridView takes care of the others).
					e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
					e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

					' Draw the diaglonal line - TopLeft to BottomRight
					e.Graphics.DrawLine(Pens.Blue, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

					' Draw the text content of the cell, ignoring alignment.
					If (e.Value IsNot Nothing) Then
						Dim f = e.Graphics.MeasureString(e.Value, e.CellStyle.Font, e.CellBounds.Width)
						e.Graphics.DrawString(CStr(e.Value), e.CellStyle.Font, Brushes.Blue, e.CellBounds.X + 2, e.CellBounds.Bottom - f.Height - 2, StringFormat.GenericDefault)
					Else
						Dim f = e.Graphics.MeasureString("Line", e.CellStyle.Font, e.CellBounds.Width)
						e.Graphics.DrawString("Line", e.CellStyle.Font, Brushes.Blue, e.CellBounds.X + 2, e.CellBounds.Bottom - f.Height - 2, StringFormat.GenericDefault)
					End If
					e.Handled = True

				Finally
					gridLinePen.Dispose()
					gridBrush.Dispose()
					backColorBrush.Dispose()
				End Try
			ElseIf e.RowIndex > -1 Then
				' Paint the background of the cell  
				e.PaintBackground(e.ClipBounds, False)

				' Create the text that is going to be displayed in the row header.   
				Dim rowNumStr As String = CStr(e.RowIndex + RowOffset + 1)

				' Adjust the text layout rectangle to center the text vertically   
				' within the cell and to move it slightly to the right for greater  
				' visual appearence.  
				Dim ofs As Single = Convert.ToSingle(e.CellBounds.Height - Me.FontHeight) / 2
				Dim layoutRect As RectangleF = e.CellBounds
				layoutRect.Inflate(0, -ofs)
				layoutRect.X += 5
				layoutRect.Width -= 5
				Dim centerFormat = New StringFormat()
				centerFormat.Alignment = StringAlignment.Center
				centerFormat.LineAlignment = StringAlignment.Center

				' Draw the text using the Cell's Graphics object.  
				e.Graphics.DrawString(rowNumStr, Me.Font, Brushes.Black, layoutRect, centerFormat)

				' By setting the Handled property True we signalize that this cell requires  
				' no further painting.  
				e.Handled = True
			End If
		End If

		MyBase.OnCellPainting(e)

	End Sub

End Class
