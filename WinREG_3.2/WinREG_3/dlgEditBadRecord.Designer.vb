<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEditBadRecord
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
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.RowNumberTextBox = New System.Windows.Forms.TextBox
		Me.OriginalSourceTextBox = New System.Windows.Forms.TextBox
		Me.cmsOriginalSource = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.QuoteSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		RowNumberLabel = New System.Windows.Forms.Label
		OriginalSourceLabel = New System.Windows.Forms.Label
		Me.TableLayoutPanel1.SuspendLayout()
		Me.cmsOriginalSource.SuspendLayout()
		Me.SuspendLayout()
		'
		'RowNumberLabel
		'
		RowNumberLabel.AutoSize = True
		RowNumberLabel.Location = New System.Drawing.Point(12, 18)
		RowNumberLabel.Name = "RowNumberLabel"
		RowNumberLabel.Size = New System.Drawing.Size(72, 13)
		RowNumberLabel.TabIndex = 2
		RowNumberLabel.Text = "Row Number:"
		'
		'OriginalSourceLabel
		'
		OriginalSourceLabel.AutoSize = True
		OriginalSourceLabel.Location = New System.Drawing.Point(12, 55)
		OriginalSourceLabel.Name = "OriginalSourceLabel"
		OriginalSourceLabel.Size = New System.Drawing.Size(82, 13)
		OriginalSourceLabel.TabIndex = 3
		OriginalSourceLabel.Text = "Original Source:"
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
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
		Me.OK_Button.Location = New System.Drawing.Point(3, 3)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(67, 23)
		Me.OK_Button.TabIndex = 0
		Me.OK_Button.Text = "Save"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Cancel"
		'
		'RowNumberTextBox
		'
		Me.RowNumberTextBox.Location = New System.Drawing.Point(100, 15)
		Me.RowNumberTextBox.Name = "RowNumberTextBox"
		Me.RowNumberTextBox.ReadOnly = True
		Me.RowNumberTextBox.Size = New System.Drawing.Size(50, 20)
		Me.RowNumberTextBox.TabIndex = 3
		'
		'OriginalSourceTextBox
		'
		Me.OriginalSourceTextBox.ContextMenuStrip = Me.cmsOriginalSource
		Me.OriginalSourceTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OriginalSourceTextBox.Location = New System.Drawing.Point(100, 52)
		Me.OriginalSourceTextBox.Name = "OriginalSourceTextBox"
		Me.OriginalSourceTextBox.Size = New System.Drawing.Size(589, 23)
		Me.OriginalSourceTextBox.TabIndex = 4
		'
		'cmsOriginalSource
		'
		Me.cmsOriginalSource.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuoteSelectionToolStripMenuItem})
		Me.cmsOriginalSource.Name = "cmsOriginalSource"
		Me.cmsOriginalSource.Size = New System.Drawing.Size(158, 26)
		'
		'QuoteSelectionToolStripMenuItem
		'
		Me.QuoteSelectionToolStripMenuItem.Name = "QuoteSelectionToolStripMenuItem"
		Me.QuoteSelectionToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
		Me.QuoteSelectionToolStripMenuItem.Text = "Quote selection"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 90)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(64, 13)
		Me.Label1.TabIndex = 5
		Me.Label1.Text = "Instructions:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(24, 113)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(376, 13)
		Me.Label2.TabIndex = 6
		Me.Label2.Text = "1. The orignal, raw source of the record is in the textbox. This can be changed"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.Red
		Me.Label3.Location = New System.Drawing.Point(97, 90)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(287, 13)
		Me.Label3.TabIndex = 7
		Me.Label3.Text = "YOU MUST KNOW WHAT YOU'RE DOING HERE"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(24, 138)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(313, 13)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "2. Generally, you will want to remove one or more trailing commas"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(24, 163)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(361, 13)
		Me.Label5.TabIndex = 9
		Me.Label5.Text = "3. Sometimes, you need to add quotes around a field that has a comma in it"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(24, 188)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(573, 13)
		Me.Label6.TabIndex = 10
		Me.Label6.Text = "4. Part of the record can be quoted. Select the piece of the record to be quoted " & _
			 "and then right-click. Follow the propmpt."
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(406, 113)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(120, 13)
		Me.Label7.TabIndex = 11
		Me.Label7.Text = "BE VERY CAREFUL"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(24, 213)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(192, 13)
		Me.Label8.TabIndex = 12
		Me.Label8.Text = "5. Press Save to update the raw record"
		'
		'dlgEditBadRecord
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(708, 331)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(OriginalSourceLabel)
		Me.Controls.Add(Me.OriginalSourceTextBox)
		Me.Controls.Add(RowNumberLabel)
		Me.Controls.Add(Me.RowNumberTextBox)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgEditBadRecord"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Edit Bad Record"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.cmsOriginalSource.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents RowNumberTextBox As System.Windows.Forms.TextBox
	Friend WithEvents OriginalSourceTextBox As System.Windows.Forms.TextBox
	Friend WithEvents cmsOriginalSource As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents QuoteSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
