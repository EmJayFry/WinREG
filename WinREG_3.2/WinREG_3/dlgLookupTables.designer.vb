<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgLookupTables
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgLookupTables))
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.bnTables = New System.Windows.Forms.BindingNavigator(Me.components)
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
		Me.BindingNavigatorSaveData = New System.Windows.Forms.ToolStripButton
		Me.dgvTables = New System.Windows.Forms.DataGridView
		Me.bsTables = New System.Windows.Forms.BindingSource(Me.components)
		Me.ttLookupTables = New System.Windows.Forms.ToolTip(Me.components)
		Me.hlpLookupTables = New System.Windows.Forms.HelpProvider
		Me.TableLayoutPanel1.SuspendLayout()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		CType(Me.bnTables, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.bnTables.SuspendLayout()
		CType(Me.dgvTables, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.bsTables, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 273)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
		Me.TableLayoutPanel1.TabIndex = 0
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.OK_Button.Location = New System.Drawing.Point(3, 3)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(67, 23)
		Me.OK_Button.TabIndex = 0
		Me.OK_Button.Text = "OK"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Cancel_Button.CausesValidation = False
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Cancel"
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainer1.IsSplitterFixed = True
		Me.SplitContainer1.Location = New System.Drawing.Point(-1, -1)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.bnTables)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.dgvTables)
		Me.SplitContainer1.Size = New System.Drawing.Size(435, 268)
		Me.SplitContainer1.SplitterDistance = 25
		Me.SplitContainer1.TabIndex = 1
		'
		'bnTables
		'
		Me.bnTables.AddNewItem = Me.BindingNavigatorAddNewItem
		Me.bnTables.CountItem = Me.BindingNavigatorCountItem
		Me.bnTables.DeleteItem = Me.BindingNavigatorDeleteItem
		Me.bnTables.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.BindingNavigatorSaveData})
		Me.bnTables.Location = New System.Drawing.Point(0, 0)
		Me.bnTables.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
		Me.bnTables.MoveLastItem = Me.BindingNavigatorMoveLastItem
		Me.bnTables.MoveNextItem = Me.BindingNavigatorMoveNextItem
		Me.bnTables.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
		Me.bnTables.Name = "bnTables"
		Me.bnTables.PositionItem = Me.BindingNavigatorPositionItem
		Me.bnTables.Size = New System.Drawing.Size(435, 25)
		Me.bnTables.TabIndex = 0
		Me.bnTables.Text = "BindingNavigator1"
		'
		'BindingNavigatorAddNewItem
		'
		Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
		Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorAddNewItem.Text = "Add new"
		Me.BindingNavigatorAddNewItem.Visible = False
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
		Me.BindingNavigatorDeleteItem.Visible = False
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
		'BindingNavigatorSaveData
		'
		Me.BindingNavigatorSaveData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorSaveData.Image = CType(resources.GetObject("BindingNavigatorSaveData.Image"), System.Drawing.Image)
		Me.BindingNavigatorSaveData.Name = "BindingNavigatorSaveData"
		Me.BindingNavigatorSaveData.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorSaveData.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorSaveData.Text = "Save"
		Me.BindingNavigatorSaveData.ToolTipText = "Save pending data changes"
		Me.BindingNavigatorSaveData.Visible = False
		'
		'dgvTables
		'
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
		Me.dgvTables.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvTables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
		Me.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvTables.DefaultCellStyle = DataGridViewCellStyle2
		Me.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvTables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
		Me.dgvTables.Location = New System.Drawing.Point(0, 0)
		Me.dgvTables.MultiSelect = False
		Me.dgvTables.Name = "dgvTables"
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvTables.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
		Me.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.hlpLookupTables.SetShowHelp(Me.dgvTables, True)
		Me.dgvTables.Size = New System.Drawing.Size(435, 239)
		Me.dgvTables.TabIndex = 0
		'
		'bsTables
		'
		'
		'ttLookupTables
		'
		Me.ttLookupTables.Active = False
		Me.ttLookupTables.IsBalloon = True
		'
		'hlpLookupTables
		'
		Me.hlpLookupTables.HelpNamespace = "WinREG3a.chm"
		'
		'dlgLookupTables
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(435, 314)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.HelpButton = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgLookupTables"
		Me.hlpLookupTables.SetShowHelp(Me, True)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Lookup Tables Dialog"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		CType(Me.bnTables, System.ComponentModel.ISupportInitialize).EndInit()
		Me.bnTables.ResumeLayout(False)
		Me.bnTables.PerformLayout()
		CType(Me.dgvTables, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.bsTables, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents dgvTables As System.Windows.Forms.DataGridView
	Friend WithEvents bsTables As System.Windows.Forms.BindingSource
	Friend WithEvents bnTables As System.Windows.Forms.BindingNavigator
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
	Friend WithEvents ttLookupTables As System.Windows.Forms.ToolTip
	Friend WithEvents BindingNavigatorSaveData As System.Windows.Forms.ToolStripButton
	Friend WithEvents hlpLookupTables As System.Windows.Forms.HelpProvider

End Class
