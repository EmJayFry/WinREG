<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileRename
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
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.btnOK = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.lblRequest = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.txtNewName = New System.Windows.Forms.TextBox
		Me.txtNewNameConfirm = New System.Windows.Forms.TextBox
		Me.TableLayoutPanel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.btnOK, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(256, 175)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(178, 33)
		Me.TableLayoutPanel1.TabIndex = 5
		'
		'btnOK
		'
		Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.btnOK.Location = New System.Drawing.Point(7, 5)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 23)
		Me.btnOK.TabIndex = 0
		Me.btnOK.Text = "OK"
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.btnCancel.CausesValidation = False
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(96, 5)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 1
		Me.btnCancel.Text = "Cancel"
		'
		'lblRequest
		'
		Me.lblRequest.AutoSize = True
		Me.lblRequest.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRequest.Location = New System.Drawing.Point(13, 13)
		Me.lblRequest.Name = "lblRequest"
		Me.lblRequest.Size = New System.Drawing.Size(106, 19)
		Me.lblRequest.TabIndex = 0
		Me.lblRequest.Text = "Instructions"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(14, 65)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(58, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "New name"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(14, 101)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(94, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Confirm new name"
		'
		'txtNewName
		'
		Me.txtNewName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtNewName.Location = New System.Drawing.Point(114, 62)
		Me.txtNewName.MaxLength = 120
		Me.txtNewName.Name = "txtNewName"
		Me.txtNewName.Size = New System.Drawing.Size(100, 20)
		Me.txtNewName.TabIndex = 2
		'
		'txtNewNameConfirm
		'
		Me.txtNewNameConfirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtNewNameConfirm.Location = New System.Drawing.Point(114, 98)
		Me.txtNewNameConfirm.MaxLength = 120
		Me.txtNewNameConfirm.Name = "txtNewNameConfirm"
		Me.txtNewNameConfirm.Size = New System.Drawing.Size(100, 20)
		Me.txtNewNameConfirm.TabIndex = 4
		'
		'FileRename
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(435, 209)
		Me.Controls.Add(Me.txtNewNameConfirm)
		Me.Controls.Add(Me.txtNewName)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.lblRequest)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FileRename"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "File Rename"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents btnOK As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents lblRequest As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtNewName As System.Windows.Forms.TextBox
	Friend WithEvents txtNewNameConfirm As System.Windows.Forms.TextBox

End Class
