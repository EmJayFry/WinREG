<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgBackupRestore
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgBackupRestore))
		Me.btnClose = New System.Windows.Forms.Button
		Me.lblNote = New System.Windows.Forms.Label
		Me.lnkBackupFilesFolder = New System.Windows.Forms.LinkLabel
		Me.tabBackupRestore = New System.Windows.Forms.TabControl
		Me.tabBackup = New System.Windows.Forms.TabPage
		Me.btnSelectAllFilesToBackup = New System.Windows.Forms.Button
		Me.lblInstructions = New System.Windows.Forms.Label
		Me.lbBackupFileList = New System.Windows.Forms.ListBox
		Me.btnBackup = New System.Windows.Forms.Button
		Me.tabRestore = New System.Windows.Forms.TabPage
		Me.btnSelectAllFilesToRestore = New System.Windows.Forms.Button
		Me.lblRestorePrompt = New System.Windows.Forms.Label
		Me.lbRestoreFileList = New System.Windows.Forms.ListBox
		Me.btnRestore = New System.Windows.Forms.Button
		Me.errBackupRestore = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.hlpBackupRestore = New System.Windows.Forms.HelpProvider
		Me.ttBackupRestore = New System.Windows.Forms.ToolTip(Me.components)
		Me.tabBackupRestore.SuspendLayout()
		Me.tabBackup.SuspendLayout()
		Me.tabRestore.SuspendLayout()
		CType(Me.errBackupRestore, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'btnClose
		'
		Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnClose.CausesValidation = False
		Me.btnClose.Location = New System.Drawing.Point(395, 245)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(75, 23)
		Me.btnClose.TabIndex = 0
		Me.btnClose.Text = "Close"
		Me.btnClose.UseVisualStyleBackColor = True
		'
		'lblNote
		'
		Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblNote.AutoSize = True
		Me.lblNote.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNote.Location = New System.Drawing.Point(2, 255)
		Me.lblNote.Name = "lblNote"
		Me.lblNote.Size = New System.Drawing.Size(236, 13)
		Me.lblNote.TabIndex = 1
		Me.lblNote.Text = "PLEASE NOTE: The backup files will be saved in:"
		'
		'lnkBackupFilesFolder
		'
		Me.lnkBackupFilesFolder.AutoSize = True
		Me.lnkBackupFilesFolder.Location = New System.Drawing.Point(252, 255)
		Me.lnkBackupFilesFolder.Name = "lnkBackupFilesFolder"
		Me.lnkBackupFilesFolder.Size = New System.Drawing.Size(98, 13)
		Me.lnkBackupFilesFolder.TabIndex = 2
		Me.lnkBackupFilesFolder.TabStop = True
		Me.lnkBackupFilesFolder.Text = "Backup Files Folder"
		'
		'tabBackupRestore
		'
		Me.tabBackupRestore.Controls.Add(Me.tabBackup)
		Me.tabBackupRestore.Controls.Add(Me.tabRestore)
		Me.tabBackupRestore.Location = New System.Drawing.Point(5, 13)
		Me.tabBackupRestore.Name = "tabBackupRestore"
		Me.tabBackupRestore.SelectedIndex = 0
		Me.tabBackupRestore.Size = New System.Drawing.Size(465, 229)
		Me.tabBackupRestore.TabIndex = 3
		'
		'tabBackup
		'
		Me.tabBackup.Controls.Add(Me.btnSelectAllFilesToBackup)
		Me.tabBackup.Controls.Add(Me.lblInstructions)
		Me.tabBackup.Controls.Add(Me.lbBackupFileList)
		Me.tabBackup.Controls.Add(Me.btnBackup)
		Me.tabBackup.Location = New System.Drawing.Point(4, 22)
		Me.tabBackup.Name = "tabBackup"
		Me.tabBackup.Padding = New System.Windows.Forms.Padding(3)
		Me.tabBackup.Size = New System.Drawing.Size(457, 203)
		Me.tabBackup.TabIndex = 0
		Me.tabBackup.Text = "Backup"
		Me.tabBackup.UseVisualStyleBackColor = True
		'
		'btnSelectAllFilesToBackup
		'
		Me.btnSelectAllFilesToBackup.Location = New System.Drawing.Point(370, 26)
		Me.btnSelectAllFilesToBackup.Name = "btnSelectAllFilesToBackup"
		Me.btnSelectAllFilesToBackup.Size = New System.Drawing.Size(75, 23)
		Me.btnSelectAllFilesToBackup.TabIndex = 9
		Me.btnSelectAllFilesToBackup.Text = "Select All"
		Me.btnSelectAllFilesToBackup.UseVisualStyleBackColor = True
		'
		'lblInstructions
		'
		Me.lblInstructions.AutoSize = True
		Me.lblInstructions.Location = New System.Drawing.Point(7, 7)
		Me.lblInstructions.Name = "lblInstructions"
		Me.lblInstructions.Size = New System.Drawing.Size(308, 13)
		Me.lblInstructions.TabIndex = 5
		Me.lblInstructions.Text = "Please select the file(s) you wish to backup from the list below:"
		'
		'lbBackupFileList
		'
		Me.lbBackupFileList.FormattingEnabled = True
		Me.lbBackupFileList.Location = New System.Drawing.Point(10, 26)
		Me.lbBackupFileList.MultiColumn = True
		Me.lbBackupFileList.Name = "lbBackupFileList"
		Me.lbBackupFileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
		Me.lbBackupFileList.Size = New System.Drawing.Size(354, 160)
		Me.lbBackupFileList.TabIndex = 8
		'
		'btnBackup
		'
		Me.btnBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnBackup.Enabled = False
		Me.btnBackup.Location = New System.Drawing.Point(370, 163)
		Me.btnBackup.Name = "btnBackup"
		Me.btnBackup.Size = New System.Drawing.Size(81, 23)
		Me.btnBackup.TabIndex = 7
		Me.btnBackup.Text = "Backup"
		Me.btnBackup.UseVisualStyleBackColor = True
		'
		'tabRestore
		'
		Me.tabRestore.Controls.Add(Me.btnSelectAllFilesToRestore)
		Me.tabRestore.Controls.Add(Me.lblRestorePrompt)
		Me.tabRestore.Controls.Add(Me.lbRestoreFileList)
		Me.tabRestore.Controls.Add(Me.btnRestore)
		Me.tabRestore.Location = New System.Drawing.Point(4, 22)
		Me.tabRestore.Name = "tabRestore"
		Me.tabRestore.Padding = New System.Windows.Forms.Padding(3)
		Me.tabRestore.Size = New System.Drawing.Size(457, 203)
		Me.tabRestore.TabIndex = 1
		Me.tabRestore.Text = "Restore"
		Me.tabRestore.UseVisualStyleBackColor = True
		'
		'btnSelectAllFilesToRestore
		'
		Me.btnSelectAllFilesToRestore.Location = New System.Drawing.Point(370, 26)
		Me.btnSelectAllFilesToRestore.Name = "btnSelectAllFilesToRestore"
		Me.btnSelectAllFilesToRestore.Size = New System.Drawing.Size(75, 23)
		Me.btnSelectAllFilesToRestore.TabIndex = 10
		Me.btnSelectAllFilesToRestore.Text = "Select All"
		Me.btnSelectAllFilesToRestore.UseVisualStyleBackColor = True
		'
		'lblRestorePrompt
		'
		Me.lblRestorePrompt.AutoSize = True
		Me.lblRestorePrompt.Location = New System.Drawing.Point(7, 7)
		Me.lblRestorePrompt.Name = "lblRestorePrompt"
		Me.lblRestorePrompt.Size = New System.Drawing.Size(218, 13)
		Me.lblRestorePrompt.TabIndex = 1
		Me.lblRestorePrompt.Text = "Please select the file(s) you wish to restore:"
		'
		'lbRestoreFileList
		'
		Me.lbRestoreFileList.FormattingEnabled = True
		Me.lbRestoreFileList.Location = New System.Drawing.Point(10, 26)
		Me.lbRestoreFileList.MultiColumn = True
		Me.lbRestoreFileList.Name = "lbRestoreFileList"
		Me.lbRestoreFileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
		Me.lbRestoreFileList.Size = New System.Drawing.Size(354, 160)
		Me.lbRestoreFileList.TabIndex = 3
		'
		'btnRestore
		'
		Me.btnRestore.Enabled = False
		Me.btnRestore.Location = New System.Drawing.Point(370, 163)
		Me.btnRestore.Name = "btnRestore"
		Me.btnRestore.Size = New System.Drawing.Size(81, 23)
		Me.btnRestore.TabIndex = 4
		Me.btnRestore.Text = "Restore"
		Me.btnRestore.UseVisualStyleBackColor = True
		'
		'errBackupRestore
		'
		Me.errBackupRestore.ContainerControl = Me
		'
		'hlpBackupRestore
		'
		Me.hlpBackupRestore.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'ttBackupRestore
		'
		Me.ttBackupRestore.Active = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		Me.ttBackupRestore.AutoPopDelay = 5000
		Me.ttBackupRestore.InitialDelay = 500
		Me.ttBackupRestore.IsBalloon = True
		Me.ttBackupRestore.ReshowDelay = 100
		'
		'dlgBackupRestore
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(474, 273)
		Me.Controls.Add(Me.tabBackupRestore)
		Me.Controls.Add(Me.lblNote)
		Me.Controls.Add(Me.lnkBackupFilesFolder)
		Me.Controls.Add(Me.btnClose)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.HelpButton = True
		Me.hlpBackupRestore.SetHelpKeyword(Me, "backupRestore.html")
		Me.hlpBackupRestore.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgBackupRestore"
		Me.hlpBackupRestore.SetShowHelp(Me, True)
		Me.Text = "Backup & Restore Utility"
		Me.tabBackupRestore.ResumeLayout(False)
		Me.tabBackup.ResumeLayout(False)
		Me.tabBackup.PerformLayout()
		Me.tabRestore.ResumeLayout(False)
		Me.tabRestore.PerformLayout()
		CType(Me.errBackupRestore, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents btnClose As System.Windows.Forms.Button
	Friend WithEvents lblNote As System.Windows.Forms.Label
	Friend WithEvents lnkBackupFilesFolder As System.Windows.Forms.LinkLabel
	Friend WithEvents tabBackupRestore As System.Windows.Forms.TabControl
	Friend WithEvents tabBackup As System.Windows.Forms.TabPage
	Friend WithEvents tabRestore As System.Windows.Forms.TabPage
	Friend WithEvents lblRestorePrompt As System.Windows.Forms.Label
	Friend WithEvents lblInstructions As System.Windows.Forms.Label
	Friend WithEvents btnBackup As System.Windows.Forms.Button
	Friend WithEvents lbBackupFileList As System.Windows.Forms.ListBox
	Friend WithEvents lbRestoreFileList As System.Windows.Forms.ListBox
	Friend WithEvents btnRestore As System.Windows.Forms.Button
	Friend WithEvents errBackupRestore As System.Windows.Forms.ErrorProvider
	Friend WithEvents hlpBackupRestore As System.Windows.Forms.HelpProvider
	Friend WithEvents btnSelectAllFilesToBackup As System.Windows.Forms.Button
	Friend WithEvents btnSelectAllFilesToRestore As System.Windows.Forms.Button
	Friend WithEvents ttBackupRestore As System.Windows.Forms.ToolTip
End Class
