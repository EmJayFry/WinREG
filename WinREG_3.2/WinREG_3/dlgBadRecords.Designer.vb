<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgBadRecords
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
		Dim RowNumberLabel As System.Windows.Forms.Label
		Dim OriginalSourceLabel As System.Windows.Forms.Label
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgBadRecords))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.RowNumberTextBox = New System.Windows.Forms.TextBox
		Me.OriginalSourceTextBox = New System.Windows.Forms.TextBox
		Me.ErrorMessageLabel1 = New System.Windows.Forms.Label
		Me.btnEditBadRecord = New System.Windows.Forms.Button
		Me.BadRecordsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.BadRecordsBindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
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
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		RowNumberLabel = New System.Windows.Forms.Label
		OriginalSourceLabel = New System.Windows.Forms.Label
		Me.TableLayoutPanel1.SuspendLayout()
		CType(Me.BadRecordsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.BadRecordsBindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BadRecordsBindingNavigator1.SuspendLayout()
		Me.SuspendLayout()
		'
		'RowNumberLabel
		'
		RowNumberLabel.AutoSize = True
		RowNumberLabel.Location = New System.Drawing.Point(19, 46)
		RowNumberLabel.Name = "RowNumberLabel"
		RowNumberLabel.Size = New System.Drawing.Size(72, 13)
		RowNumberLabel.TabIndex = 2
		RowNumberLabel.Text = "Row Number:"
		'
		'OriginalSourceLabel
		'
		OriginalSourceLabel.AutoSize = True
		OriginalSourceLabel.Location = New System.Drawing.Point(19, 72)
		OriginalSourceLabel.Name = "OriginalSourceLabel"
		OriginalSourceLabel.Size = New System.Drawing.Size(82, 13)
		OriginalSourceLabel.TabIndex = 4
		OriginalSourceLabel.Text = "Original Source:"
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(550, 290)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
		Me.TableLayoutPanel1.TabIndex = 0
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.OK_Button.Location = New System.Drawing.Point(76, 3)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(67, 23)
		Me.OK_Button.TabIndex = 0
		Me.OK_Button.Text = "OK"
		'
		'RowNumberTextBox
		'
		Me.RowNumberTextBox.Location = New System.Drawing.Point(107, 43)
		Me.RowNumberTextBox.Name = "RowNumberTextBox"
		Me.RowNumberTextBox.ReadOnly = True
		Me.RowNumberTextBox.Size = New System.Drawing.Size(50, 20)
		Me.RowNumberTextBox.TabIndex = 3
		'
		'OriginalSourceTextBox
		'
		Me.OriginalSourceTextBox.Location = New System.Drawing.Point(107, 69)
		Me.OriginalSourceTextBox.Name = "OriginalSourceTextBox"
		Me.OriginalSourceTextBox.ReadOnly = True
		Me.OriginalSourceTextBox.Size = New System.Drawing.Size(589, 20)
		Me.OriginalSourceTextBox.TabIndex = 5
		'
		'ErrorMessageLabel1
		'
		Me.ErrorMessageLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ErrorMessageLabel1.Location = New System.Drawing.Point(163, 41)
		Me.ErrorMessageLabel1.Name = "ErrorMessageLabel1"
		Me.ErrorMessageLabel1.Size = New System.Drawing.Size(530, 23)
		Me.ErrorMessageLabel1.TabIndex = 7
		Me.ErrorMessageLabel1.Text = "Label1"
		Me.ErrorMessageLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnEditBadRecord
		'
		Me.btnEditBadRecord.Location = New System.Drawing.Point(107, 95)
		Me.btnEditBadRecord.Name = "btnEditBadRecord"
		Me.btnEditBadRecord.Size = New System.Drawing.Size(75, 23)
		Me.btnEditBadRecord.TabIndex = 8
		Me.btnEditBadRecord.Text = "Edit record"
		Me.btnEditBadRecord.UseVisualStyleBackColor = True
		'
		'BadRecordsBindingSource
		'
		'
		'BadRecordsBindingNavigator1
		'
		Me.BadRecordsBindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem
		Me.BadRecordsBindingNavigator1.BindingSource = Me.BadRecordsBindingSource
		Me.BadRecordsBindingNavigator1.CountItem = Me.BindingNavigatorCountItem
		Me.BadRecordsBindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem
		Me.BadRecordsBindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
		Me.BadRecordsBindingNavigator1.Location = New System.Drawing.Point(0, 0)
		Me.BadRecordsBindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
		Me.BadRecordsBindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
		Me.BadRecordsBindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
		Me.BadRecordsBindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
		Me.BadRecordsBindingNavigator1.Name = "BadRecordsBindingNavigator1"
		Me.BadRecordsBindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
		Me.BadRecordsBindingNavigator1.Size = New System.Drawing.Size(708, 25)
		Me.BadRecordsBindingNavigator1.TabIndex = 9
		Me.BadRecordsBindingNavigator1.Text = "BindingNavigator1"
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
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(22, 125)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(64, 13)
		Me.Label1.TabIndex = 10
		Me.Label1.Text = "Instructions:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(43, 142)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(279, 13)
		Me.Label2.TabIndex = 11
		Me.Label2.Text = "1. Use the navigation control to select a record to change"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(43, 167)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(252, 13)
		Me.Label3.TabIndex = 12
		Me.Label3.Text = "2. Press the Edit record button to change the record"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(43, 192)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(318, 13)
		Me.Label4.TabIndex = 13
		Me.Label4.Text = "3. Repeat for each record. Not all records must be corrected here."
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(43, 217)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(255, 13)
		Me.Label5.TabIndex = 14
		Me.Label5.Text = "4. Press the OK button to return to the main program."
		'
		'dlgBadRecords
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(708, 331)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.BadRecordsBindingNavigator1)
		Me.Controls.Add(Me.btnEditBadRecord)
		Me.Controls.Add(RowNumberLabel)
		Me.Controls.Add(Me.RowNumberTextBox)
		Me.Controls.Add(OriginalSourceLabel)
		Me.Controls.Add(Me.OriginalSourceTextBox)
		Me.Controls.Add(Me.ErrorMessageLabel1)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgBadRecords"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Malformed Records"
		Me.TableLayoutPanel1.ResumeLayout(False)
		CType(Me.BadRecordsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.BadRecordsBindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.BadRecordsBindingNavigator1.ResumeLayout(False)
		Me.BadRecordsBindingNavigator1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents RowNumberTextBox As System.Windows.Forms.TextBox
	Friend WithEvents OriginalSourceTextBox As System.Windows.Forms.TextBox
	Friend WithEvents ErrorMessageLabel1 As System.Windows.Forms.Label
	Friend WithEvents btnEditBadRecord As System.Windows.Forms.Button
	Friend WithEvents BadRecordsBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents BadRecordsBindingNavigator1 As System.Windows.Forms.BindingNavigator
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
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
