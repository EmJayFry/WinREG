<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRecoverFromBackup
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
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.cboxTranscriptionFiles = New System.Windows.Forms.ComboBox
		Me.labFileName = New System.Windows.Forms.Label
		Me.labPlacename = New System.Windows.Forms.Label
		Me.labChurchname = New System.Windows.Forms.Label
		Me.labSource = New System.Windows.Forms.Label
		Me.labComments = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.cboxBackupFiles = New System.Windows.Forms.ComboBox
		Me.Label5 = New System.Windows.Forms.Label
		Me.labNumBackups = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.labLastUpdated = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.labLineCount = New System.Windows.Forms.Label
		Me.labBackupLines = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.labBackupUpdated = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(342, 274)
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
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Cancel"
		'
		'cboxTranscriptionFiles
		'
		Me.cboxTranscriptionFiles.FormattingEnabled = True
		Me.cboxTranscriptionFiles.Location = New System.Drawing.Point(13, 13)
		Me.cboxTranscriptionFiles.Name = "cboxTranscriptionFiles"
		Me.cboxTranscriptionFiles.Size = New System.Drawing.Size(162, 21)
		Me.cboxTranscriptionFiles.TabIndex = 1
		'
		'labFileName
		'
		Me.labFileName.AutoSize = True
		Me.labFileName.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labFileName.Location = New System.Drawing.Point(13, 41)
		Me.labFileName.Name = "labFileName"
		Me.labFileName.Size = New System.Drawing.Size(49, 13)
		Me.labFileName.TabIndex = 2
		Me.labFileName.Text = "filename"
		'
		'labPlacename
		'
		Me.labPlacename.AutoSize = True
		Me.labPlacename.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labPlacename.Location = New System.Drawing.Point(72, 63)
		Me.labPlacename.Name = "labPlacename"
		Me.labPlacename.Size = New System.Drawing.Size(38, 13)
		Me.labPlacename.TabIndex = 3
		Me.labPlacename.Text = "place"
		Me.labPlacename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'labChurchname
		'
		Me.labChurchname.AutoSize = True
		Me.labChurchname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labChurchname.Location = New System.Drawing.Point(72, 80)
		Me.labChurchname.Name = "labChurchname"
		Me.labChurchname.Size = New System.Drawing.Size(46, 13)
		Me.labChurchname.TabIndex = 4
		Me.labChurchname.Text = "church"
		Me.labChurchname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'labSource
		'
		Me.labSource.AutoSize = True
		Me.labSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labSource.Location = New System.Drawing.Point(72, 97)
		Me.labSource.Name = "labSource"
		Me.labSource.Size = New System.Drawing.Size(45, 13)
		Me.labSource.TabIndex = 5
		Me.labSource.Text = "source"
		Me.labSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'labComments
		'
		Me.labComments.AutoSize = True
		Me.labComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labComments.Location = New System.Drawing.Point(72, 114)
		Me.labComments.Name = "labComments"
		Me.labComments.Size = New System.Drawing.Size(63, 13)
		Me.labComments.TabIndex = 6
		Me.labComments.Text = "comments"
		Me.labComments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(35, 63)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(37, 13)
		Me.Label1.TabIndex = 7
		Me.Label1.Text = "Place:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(28, 80)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(44, 13)
		Me.Label2.TabIndex = 8
		Me.Label2.Text = "Church:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(28, 97)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(44, 13)
		Me.Label3.TabIndex = 9
		Me.Label3.Text = "Source:"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(13, 114)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(59, 13)
		Me.Label4.TabIndex = 10
		Me.Label4.Text = "Comments:"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'cboxBackupFiles
		'
		Me.cboxBackupFiles.FormattingEnabled = True
		Me.cboxBackupFiles.Location = New System.Drawing.Point(16, 176)
		Me.cboxBackupFiles.Name = "cboxBackupFiles"
		Me.cboxBackupFiles.Size = New System.Drawing.Size(239, 21)
		Me.cboxBackupFiles.TabIndex = 11
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(13, 148)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(59, 13)
		Me.Label5.TabIndex = 12
		Me.Label5.Text = "#Backups:"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'labNumBackups
		'
		Me.labNumBackups.AutoSize = True
		Me.labNumBackups.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labNumBackups.Location = New System.Drawing.Point(72, 148)
		Me.labNumBackups.Name = "labNumBackups"
		Me.labNumBackups.Size = New System.Drawing.Size(48, 13)
		Me.labNumBackups.TabIndex = 13
		Me.labNumBackups.Text = "number"
		Me.labNumBackups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(135, 131)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(72, 13)
		Me.Label6.TabIndex = 14
		Me.Label6.Text = "Last updated:"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'labLastUpdated
		'
		Me.labLastUpdated.AutoSize = True
		Me.labLastUpdated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labLastUpdated.Location = New System.Drawing.Point(202, 131)
		Me.labLastUpdated.Name = "labLastUpdated"
		Me.labLastUpdated.Size = New System.Drawing.Size(53, 13)
		Me.labLastUpdated.TabIndex = 15
		Me.labLastUpdated.Text = "updated"
		Me.labLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(15, 131)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(57, 13)
		Me.Label7.TabIndex = 16
		Me.Label7.Text = "#Records:"
		'
		'labLineCount
		'
		Me.labLineCount.AutoSize = True
		Me.labLineCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labLineCount.Location = New System.Drawing.Point(72, 131)
		Me.labLineCount.Name = "labLineCount"
		Me.labLineCount.Size = New System.Drawing.Size(33, 13)
		Me.labLineCount.TabIndex = 17
		Me.labLineCount.Text = "lines"
		'
		'labBackupLines
		'
		Me.labBackupLines.AutoSize = True
		Me.labBackupLines.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labBackupLines.Location = New System.Drawing.Point(72, 213)
		Me.labBackupLines.Name = "labBackupLines"
		Me.labBackupLines.Size = New System.Drawing.Size(33, 13)
		Me.labBackupLines.TabIndex = 21
		Me.labBackupLines.Text = "lines"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(15, 213)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(57, 13)
		Me.Label9.TabIndex = 20
		Me.Label9.Text = "#Records:"
		'
		'labBackupUpdated
		'
		Me.labBackupUpdated.AutoSize = True
		Me.labBackupUpdated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labBackupUpdated.Location = New System.Drawing.Point(202, 213)
		Me.labBackupUpdated.Name = "labBackupUpdated"
		Me.labBackupUpdated.Size = New System.Drawing.Size(53, 13)
		Me.labBackupUpdated.TabIndex = 19
		Me.labBackupUpdated.Text = "updated"
		Me.labBackupUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Location = New System.Drawing.Point(135, 213)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(72, 13)
		Me.Label11.TabIndex = 18
		Me.Label11.Text = "Last updated:"
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'dlgRecoverFromBackup
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(500, 315)
		Me.Controls.Add(Me.labBackupLines)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.labBackupUpdated)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.labLineCount)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.labLastUpdated)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.labNumBackups)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.cboxBackupFiles)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.labComments)
		Me.Controls.Add(Me.labSource)
		Me.Controls.Add(Me.labChurchname)
		Me.Controls.Add(Me.labPlacename)
		Me.Controls.Add(Me.labFileName)
		Me.Controls.Add(Me.cboxTranscriptionFiles)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgRecoverFromBackup"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Recover Transcription File from Backup"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents cboxTranscriptionFiles As System.Windows.Forms.ComboBox
	Friend WithEvents labFileName As System.Windows.Forms.Label
	Friend WithEvents labPlacename As System.Windows.Forms.Label
	Friend WithEvents labChurchname As System.Windows.Forms.Label
	Friend WithEvents labSource As System.Windows.Forms.Label
	Friend WithEvents labComments As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents cboxBackupFiles As System.Windows.Forms.ComboBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents labNumBackups As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents labLastUpdated As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents labLineCount As System.Windows.Forms.Label
	Friend WithEvents labBackupLines As System.Windows.Forms.Label
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents labBackupUpdated As System.Windows.Forms.Label
	Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
