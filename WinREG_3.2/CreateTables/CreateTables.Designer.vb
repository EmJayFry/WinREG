<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCreateTables
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgCreateTables))
		Me.LookupTables = New WinREG.LookupTables
		Me.ChapmanCodesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.ChapmanCodesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
		Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
		Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
		Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
		Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.ChapmanCodesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
		CType(Me.LookupTables, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ChapmanCodesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ChapmanCodesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ChapmanCodesBindingNavigator.SuspendLayout()
		Me.SuspendLayout()
		'
		'LookupTables
		'
		Me.LookupTables.DataSetName = "LookupTables"
		Me.LookupTables.Locale = New System.Globalization.CultureInfo("")
		Me.LookupTables.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'ChapmanCodesBindingSource
		'
		Me.ChapmanCodesBindingSource.DataMember = "ChapmanCodes"
		Me.ChapmanCodesBindingSource.DataSource = Me.LookupTables
		'
		'ChapmanCodesBindingNavigator
		'
		Me.ChapmanCodesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
		Me.ChapmanCodesBindingNavigator.BindingSource = Me.ChapmanCodesBindingSource
		Me.ChapmanCodesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
		Me.ChapmanCodesBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
		Me.ChapmanCodesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ChapmanCodesBindingNavigatorSaveItem})
		Me.ChapmanCodesBindingNavigator.Location = New System.Drawing.Point(0, 0)
		Me.ChapmanCodesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
		Me.ChapmanCodesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
		Me.ChapmanCodesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
		Me.ChapmanCodesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
		Me.ChapmanCodesBindingNavigator.Name = "ChapmanCodesBindingNavigator"
		Me.ChapmanCodesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
		Me.ChapmanCodesBindingNavigator.Size = New System.Drawing.Size(341, 25)
		Me.ChapmanCodesBindingNavigator.TabIndex = 0
		Me.ChapmanCodesBindingNavigator.Text = "BindingNavigator1"
		'
		'BindingNavigatorAddNewItem
		'
		Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
		Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorAddNewItem.Text = "Add new"
		'
		'BindingNavigatorCountItem
		'
		Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
		Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
		Me.BindingNavigatorCountItem.Text = "of {0}"
		Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
		'
		'BindingNavigatorDeleteItem
		'
		Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
		Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorDeleteItem.Text = "Delete"
		'
		'BindingNavigatorMoveFirstItem
		'
		Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
		Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorMoveFirstItem.Text = "Move first"
		'
		'BindingNavigatorMovePreviousItem
		'
		Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
		Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
		'
		'BindingNavigatorSeparator
		'
		Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
		Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
		'
		'BindingNavigatorPositionItem
		'
		Me.BindingNavigatorPositionItem.AccessibleName = "Position"
		Me.BindingNavigatorPositionItem.AutoSize = False
		Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
		Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
		Me.BindingNavigatorPositionItem.Text = "0"
		Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
		'
		'BindingNavigatorSeparator1
		'
		Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
		Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'BindingNavigatorMoveNextItem
		'
		Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
		Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorMoveNextItem.Text = "Move next"
		'
		'BindingNavigatorMoveLastItem
		'
		Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
		Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorMoveLastItem.Text = "Move last"
		'
		'BindingNavigatorSeparator2
		'
		Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
		Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
		'
		'ChapmanCodesBindingNavigatorSaveItem
		'
		Me.ChapmanCodesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.ChapmanCodesBindingNavigatorSaveItem.Enabled = False
		Me.ChapmanCodesBindingNavigatorSaveItem.Image = CType(resources.GetObject("ChapmanCodesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
		Me.ChapmanCodesBindingNavigatorSaveItem.Name = "ChapmanCodesBindingNavigatorSaveItem"
		Me.ChapmanCodesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
		Me.ChapmanCodesBindingNavigatorSaveItem.Text = "Save Data"
		'
		'dlgCreateTables
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(341, 269)
		Me.Controls.Add(Me.ChapmanCodesBindingNavigator)
		Me.Name = "dlgCreateTables"
		Me.Text = "Create Lookup Tables"
		CType(Me.LookupTables, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ChapmanCodesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ChapmanCodesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ChapmanCodesBindingNavigator.ResumeLayout(False)
		Me.ChapmanCodesBindingNavigator.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents LookupTables As WinREG.LookupTables
	Friend WithEvents ChapmanCodesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents ChapmanCodesBindingNavigator As System.Windows.Forms.BindingNavigator
	Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
	Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
	Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ChapmanCodesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton

End Class
