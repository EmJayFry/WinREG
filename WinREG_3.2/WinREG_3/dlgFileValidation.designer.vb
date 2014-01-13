<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgFileValidation
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgFileValidation))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.lblDescription = New System.Windows.Forms.Label
		Me.lblErrors = New System.Windows.Forms.Label
		Me.bwValidateFile = New System.ComponentModel.BackgroundWorker
		Me.pbProgress = New System.Windows.Forms.ProgressBar
		Me.hlpValidateFile = New System.Windows.Forms.HelpProvider
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 328)
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
		Me.OK_Button.Text = "Proceed"
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
		'lblDescription
		'
		Me.lblDescription.AutoSize = True
		Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDescription.Location = New System.Drawing.Point(12, 25)
		Me.lblDescription.Name = "lblDescription"
		Me.lblDescription.Size = New System.Drawing.Size(423, 224)
		Me.lblDescription.TabIndex = 1
		Me.lblDescription.Text = resources.GetString("lblDescription.Text")
		'
		'lblErrors
		'
		Me.lblErrors.AutoSize = True
		Me.lblErrors.Location = New System.Drawing.Point(177, 302)
		Me.lblErrors.Name = "lblErrors"
		Me.lblErrors.Size = New System.Drawing.Size(81, 13)
		Me.lblErrors.TabIndex = 3
		Me.lblErrors.Text = "Errors found {0}"
		'
		'bwValidateFile
		'
		Me.bwValidateFile.WorkerReportsProgress = True
		Me.bwValidateFile.WorkerSupportsCancellation = True
		'
		'pbProgress
		'
		Me.pbProgress.Location = New System.Drawing.Point(33, 262)
		Me.pbProgress.Name = "pbProgress"
		Me.pbProgress.Size = New System.Drawing.Size(369, 19)
		Me.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
		Me.pbProgress.TabIndex = 4
		'
		'hlpValidateFile
		'
		Me.hlpValidateFile.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'dlgFileValidation
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(435, 369)
		Me.Controls.Add(Me.pbProgress)
		Me.Controls.Add(Me.lblErrors)
		Me.Controls.Add(Me.lblDescription)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.HelpButton = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgFileValidation"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "File Validation"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents lblDescription As System.Windows.Forms.Label
	Friend WithEvents lblErrors As System.Windows.Forms.Label
	Friend WithEvents bwValidateFile As System.ComponentModel.BackgroundWorker
	Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
	Friend WithEvents hlpValidateFile As System.Windows.Forms.HelpProvider

End Class
