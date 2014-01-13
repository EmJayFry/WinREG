<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEditAutoCompletionList
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEditAutoCompletionList))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.btnAdd = New System.Windows.Forms.Button
		Me.btnRemove = New System.Windows.Forms.Button
		Me.cbList = New System.Windows.Forms.ComboBox
		Me.btnChange = New System.Windows.Forms.Button
		Me.TableLayoutPanel1.SuspendLayout()
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
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
		'btnAdd
		'
		Me.btnAdd.Enabled = False
		Me.btnAdd.Location = New System.Drawing.Point(342, 32)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(75, 23)
		Me.btnAdd.TabIndex = 2
		Me.btnAdd.Text = "Add"
		Me.btnAdd.UseVisualStyleBackColor = True
		'
		'btnRemove
		'
		Me.btnRemove.Enabled = False
		Me.btnRemove.Location = New System.Drawing.Point(342, 72)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.Size = New System.Drawing.Size(75, 23)
		Me.btnRemove.TabIndex = 3
		Me.btnRemove.Text = "Remove"
		Me.btnRemove.UseVisualStyleBackColor = True
		'
		'cbList
		'
		Me.cbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
		Me.cbList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cbList.FormattingEnabled = True
		Me.cbList.Location = New System.Drawing.Point(13, 13)
		Me.cbList.Name = "cbList"
		Me.cbList.Size = New System.Drawing.Size(290, 241)
		Me.cbList.Sorted = True
		Me.cbList.TabIndex = 4
		'
		'btnChange
		'
		Me.btnChange.Enabled = False
		Me.btnChange.Location = New System.Drawing.Point(342, 112)
		Me.btnChange.Name = "btnChange"
		Me.btnChange.Size = New System.Drawing.Size(75, 23)
		Me.btnChange.TabIndex = 5
		Me.btnChange.Text = "Change"
		Me.btnChange.UseVisualStyleBackColor = True
		'
		'dlgEditAutoCompletionList
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(435, 315)
		Me.Controls.Add(Me.btnChange)
		Me.Controls.Add(Me.cbList)
		Me.Controls.Add(Me.btnRemove)
		Me.Controls.Add(Me.btnAdd)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.HelpButton = True
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgEditAutoCompletionList"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Autocompletion Editor"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents btnAdd As System.Windows.Forms.Button
	Friend WithEvents btnRemove As System.Windows.Forms.Button
	Friend WithEvents cbList As System.Windows.Forms.ComboBox
	Friend WithEvents btnChange As System.Windows.Forms.Button

End Class
