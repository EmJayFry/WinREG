Imports System.Windows.Forms

Public Class dlgColumnVisibility

	Public Class CheckedListBoxItem
		Private _displayindex As Integer
		Private _width As Integer
		Private _visible As Boolean
		Private _index As Integer
		Private _name As String

		Public Sub New(ByVal name As String, ByVal visible As Boolean, ByVal index As Integer, ByVal display As Integer, ByVal width As Integer)
			_name = name
			_visible = visible
			_index = index
			_displayindex = display
			_width = width
		End Sub

		Public Property Name()
			Get
				Return _name
			End Get
			Set(ByVal value)
				_name = value
			End Set
		End Property

		Public Property Visible()
			Get
				Return _visible
			End Get
			Set(ByVal value)
				_visible = value
			End Set
		End Property

		Public Property Index()
			Get
				Return _index
			End Get
			Set(ByVal value)
				_index = value
			End Set
		End Property

		Public Property DisplayIndex()
			Get
				Return _displayindex
			End Get
			Set(ByVal value)
				_displayindex = value
			End Set
		End Property

		Public Property Width()
			Get
				Return _width
			End Get
			Set(ByVal value)
				_width = value
			End Set
		End Property

		Public Overrides Function ToString() As String
			Return Name
		End Function
	End Class

	Public dgv As DataGridView

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		For Each col As CheckedListBoxItem In clbColumns.Items
			Console.WriteLine(String.Format("{0},{1},{2},{3},{4}", col.DisplayIndex, col.Width, col.Visible, col.Index, col.Name))
			dgv.Columns(col.Index).visible = col.Visible
		Next

		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub dlgColumnVisibility_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		For Each col As DataGridViewColumn In dgv.Columns
			If col.Name <> "County" AndAlso col.Name <> "LoadOrder" Then
				Dim obj = New CheckedListBoxItem(col.Name, col.Visible, col.Index, col.DisplayIndex, col.Width)
				clbColumns.Items.Add(obj, obj.Visible)
			End If
		Next
	End Sub

	Private Sub clbColumns_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbColumns.ItemCheck
		Dim col As CheckedListBoxItem = sender.items(e.Index)
		If e.NewValue = CheckState.Checked Then
			col.Visible = True
		Else
			col.Visible = False
		End If
	End Sub

	Private Sub btnEnableAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnableAll.Click

		For i = 0 To (clbColumns.Items.Count - 1)
			Dim col As CheckedListBoxItem = clbColumns.Items(i)
			If clbColumns.GetItemChecked(i) = False Then
				If col.Name <> "Place" AndAlso col.Name <> "Church" Then
					clbColumns.SetItemChecked(i, True)
					col.Visible = True
				End If
			End If
		Next

	End Sub
End Class
