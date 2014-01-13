<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileDownload
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
		Me.btnSave = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.txtFileContents = New System.Windows.Forms.TextBox
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.SuspendLayout()
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(12, 3)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(75, 23)
		Me.btnSave.TabIndex = 0
		Me.btnSave.Text = "Save File"
		'
		'btnCancel
		'
		Me.btnCancel.CausesValidation = False
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(93, 3)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 1
		Me.btnCancel.Text = "Cancel"
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainer1.IsSplitterFixed = True
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnSave)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnCancel)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.txtFileContents)
		Me.SplitContainer1.Size = New System.Drawing.Size(435, 315)
		Me.SplitContainer1.SplitterDistance = 25
		Me.SplitContainer1.TabIndex = 1
		'
		'txtFileContents
		'
		Me.txtFileContents.BackColor = System.Drawing.Color.LightYellow
		Me.txtFileContents.Dock = System.Windows.Forms.DockStyle.Fill
		Me.txtFileContents.Location = New System.Drawing.Point(0, 0)
		Me.txtFileContents.Multiline = True
		Me.txtFileContents.Name = "txtFileContents"
		Me.txtFileContents.ReadOnly = True
		Me.txtFileContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtFileContents.Size = New System.Drawing.Size(435, 286)
		Me.txtFileContents.TabIndex = 3
		Me.txtFileContents.WordWrap = False
		'
		'FileDownload
		'
		Me.AcceptButton = Me.btnSave
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(435, 315)
		Me.Controls.Add(Me.SplitContainer1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FileDownload"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "File Download"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.Panel2.PerformLayout()
		Me.SplitContainer1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents txtFileContents As System.Windows.Forms.TextBox

End Class
