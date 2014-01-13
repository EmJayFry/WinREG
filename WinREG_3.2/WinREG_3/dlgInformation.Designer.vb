<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgInformation
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
		Me.txtInformation = New System.Windows.Forms.TextBox
		Me.SuspendLayout()
		'
		'txtInformation
		'
		Me.txtInformation.Dock = System.Windows.Forms.DockStyle.Fill
		Me.txtInformation.Location = New System.Drawing.Point(0, 0)
		Me.txtInformation.Multiline = True
		Me.txtInformation.Name = "txtInformation"
		Me.txtInformation.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.txtInformation.Size = New System.Drawing.Size(435, 315)
		Me.txtInformation.TabIndex = 0
		Me.txtInformation.WordWrap = False
		'
		'dlgInformation
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(435, 315)
		Me.Controls.Add(Me.txtInformation)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgInformation"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = ".NET Information"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtInformation As System.Windows.Forms.TextBox

End Class
