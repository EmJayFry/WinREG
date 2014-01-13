<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgExcelFileDetails
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
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblUsername = New System.Windows.Forms.Label
		Me.lblEmailAddress = New System.Windows.Forms.Label
		Me.btnApply = New System.Windows.Forms.Button
		Me.txtFileHeaders = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.ttExcelFileDetails = New System.Windows.Forms.ToolTip(Me.components)
		Me.TableLayoutPanel1.SuspendLayout()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 299)
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
		Me.SplitContainer1.IsSplitterFixed = True
		Me.SplitContainer1.Location = New System.Drawing.Point(-2, -1)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblUsername)
		Me.SplitContainer1.Panel1.Controls.Add(Me.lblEmailAddress)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnApply)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.txtFileHeaders)
		Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
		Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
		Me.SplitContainer1.Size = New System.Drawing.Size(436, 294)
		Me.SplitContainer1.SplitterDistance = 78
		Me.SplitContainer1.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(3, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(74, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "User details"
		'
		'lblUsername
		'
		Me.lblUsername.AutoSize = True
		Me.lblUsername.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblUsername.Location = New System.Drawing.Point(42, 17)
		Me.lblUsername.Name = "lblUsername"
		Me.lblUsername.Size = New System.Drawing.Size(0, 15)
		Me.lblUsername.TabIndex = 1
		Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblEmailAddress
		'
		Me.lblEmailAddress.AutoSize = True
		Me.lblEmailAddress.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEmailAddress.Location = New System.Drawing.Point(42, 41)
		Me.lblEmailAddress.Name = "lblEmailAddress"
		Me.lblEmailAddress.Size = New System.Drawing.Size(0, 15)
		Me.lblEmailAddress.TabIndex = 2
		Me.lblEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnApply
		'
		Me.btnApply.Enabled = False
		Me.btnApply.Location = New System.Drawing.Point(355, 52)
		Me.btnApply.Name = "btnApply"
		Me.btnApply.Size = New System.Drawing.Size(75, 23)
		Me.btnApply.TabIndex = 3
		Me.btnApply.Text = "Apply"
		Me.ttExcelFileDetails.SetToolTip(Me.btnApply, "When available, pressing this button will substitute your" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "name and email address" & _
				  " into the header lines below." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You will only be able to do this once.")
		Me.btnApply.UseVisualStyleBackColor = True
		'
		'txtFileHeaders
		'
		Me.txtFileHeaders.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFileHeaders.Location = New System.Drawing.Point(15, 20)
		Me.txtFileHeaders.Multiline = True
		Me.txtFileHeaders.Name = "txtFileHeaders"
		Me.txtFileHeaders.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
		Me.txtFileHeaders.Size = New System.Drawing.Size(407, 101)
		Me.txtFileHeaders.TabIndex = 1
		Me.txtFileHeaders.Text = "Line 1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Line 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Line 3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Line 4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Line 5"
		Me.txtFileHeaders.WordWrap = False
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(3, 4)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(111, 13)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "File header details"
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(15, 128)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(407, 62)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "This is how the header records will appear in the CSV file." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If the details are" & _
			 " incorrect, edit the header lines" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "accordingly and press the OK button"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'ttExcelFileDetails
		'
		Me.ttExcelFileDetails.IsBalloon = True
		'
		'dlgExcelFileDetails
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(435, 340)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.HelpButton = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgExcelFileDetails"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "File & User Details"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.Panel2.PerformLayout()
		Me.SplitContainer1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtFileHeaders As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
	Friend WithEvents lblUsername As System.Windows.Forms.Label
	Friend WithEvents btnApply As System.Windows.Forms.Button
	Friend WithEvents ttExcelFileDetails As System.Windows.Forms.ToolTip

End Class
