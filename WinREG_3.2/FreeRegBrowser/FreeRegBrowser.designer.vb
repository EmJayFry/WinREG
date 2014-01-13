<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FreeRegBrowser
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FreeRegBrowser))
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
		Me.btnUploadFile = New System.Windows.Forms.Button
		Me.btnViewErrors = New System.Windows.Forms.Button
		Me.btnDelete = New System.Windows.Forms.Button
		Me.btnReplace = New System.Windows.Forms.Button
		Me.btnRename = New System.Windows.Forms.Button
		Me.btnDownload = New System.Windows.Forms.Button
		Me.btnLogon = New System.Windows.Forms.Button
		Me.txtPassword = New System.Windows.Forms.TextBox
		Me.txtUserid = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
		Me.dgvFileList = New System.Windows.Forms.DataGridView
		Me.ssFreeREGbrowser = New System.Windows.Forms.StatusStrip
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me.wbFreeREG = New System.Windows.Forms.WebBrowser
		Me.hlpFreeREGbrowser = New System.Windows.Forms.HelpProvider
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.SplitContainer2.Panel1.SuspendLayout()
		Me.SplitContainer2.Panel2.SuspendLayout()
		Me.SplitContainer2.SuspendLayout()
		CType(Me.dgvFileList, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ssFreeREGbrowser.SuspendLayout()
		Me.SuspendLayout()
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnUploadFile)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnViewErrors)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnDelete)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnReplace)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnRename)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnDownload)
		Me.SplitContainer1.Panel1.Controls.Add(Me.btnLogon)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtPassword)
		Me.SplitContainer1.Panel1.Controls.Add(Me.txtUserid)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
		Me.hlpFreeREGbrowser.SetShowHelp(Me.SplitContainer1.Panel1, True)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
		Me.hlpFreeREGbrowser.SetShowHelp(Me.SplitContainer1, True)
		Me.SplitContainer1.Size = New System.Drawing.Size(893, 587)
		Me.SplitContainer1.SplitterDistance = 39
		Me.SplitContainer1.SplitterWidth = 1
		Me.SplitContainer1.TabIndex = 0
		'
		'btnUploadFile
		'
		Me.btnUploadFile.Enabled = False
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.btnUploadFile, "")
		Me.hlpFreeREGbrowser.SetHelpString(Me.btnUploadFile, resources.GetString("btnUploadFile.HelpString"))
		Me.btnUploadFile.Location = New System.Drawing.Point(399, 10)
		Me.btnUploadFile.Name = "btnUploadFile"
		Me.hlpFreeREGbrowser.SetShowHelp(Me.btnUploadFile, True)
		Me.btnUploadFile.Size = New System.Drawing.Size(75, 23)
		Me.btnUploadFile.TabIndex = 4
		Me.btnUploadFile.Text = "Upload"
		Me.btnUploadFile.UseVisualStyleBackColor = True
		'
		'btnViewErrors
		'
		Me.btnViewErrors.Enabled = False
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.btnViewErrors, "")
		Me.hlpFreeREGbrowser.SetHelpString(Me.btnViewErrors, resources.GetString("btnViewErrors.HelpString"))
		Me.btnViewErrors.Location = New System.Drawing.Point(480, 10)
		Me.btnViewErrors.Name = "btnViewErrors"
		Me.hlpFreeREGbrowser.SetShowHelp(Me.btnViewErrors, True)
		Me.btnViewErrors.Size = New System.Drawing.Size(75, 23)
		Me.btnViewErrors.TabIndex = 5
		Me.btnViewErrors.Text = "View Errors"
		Me.btnViewErrors.UseVisualStyleBackColor = True
		Me.btnViewErrors.Visible = False
		'
		'btnDelete
		'
		Me.btnDelete.Enabled = False
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.btnDelete, "")
		Me.hlpFreeREGbrowser.SetHelpString(Me.btnDelete, resources.GetString("btnDelete.HelpString"))
		Me.btnDelete.Location = New System.Drawing.Point(723, 10)
		Me.btnDelete.Name = "btnDelete"
		Me.hlpFreeREGbrowser.SetShowHelp(Me.btnDelete, True)
		Me.btnDelete.Size = New System.Drawing.Size(75, 23)
		Me.btnDelete.TabIndex = 8
		Me.btnDelete.Text = "Delete"
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'btnReplace
		'
		Me.btnReplace.Enabled = False
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.btnReplace, "")
		Me.hlpFreeREGbrowser.SetHelpString(Me.btnReplace, resources.GetString("btnReplace.HelpString"))
		Me.btnReplace.Location = New System.Drawing.Point(561, 10)
		Me.btnReplace.Name = "btnReplace"
		Me.hlpFreeREGbrowser.SetShowHelp(Me.btnReplace, True)
		Me.btnReplace.Size = New System.Drawing.Size(75, 23)
		Me.btnReplace.TabIndex = 6
		Me.btnReplace.Text = "Replace"
		Me.btnReplace.UseVisualStyleBackColor = True
		'
		'btnRename
		'
		Me.btnRename.Enabled = False
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.btnRename, "")
		Me.hlpFreeREGbrowser.SetHelpString(Me.btnRename, resources.GetString("btnRename.HelpString"))
		Me.btnRename.Location = New System.Drawing.Point(642, 10)
		Me.btnRename.Name = "btnRename"
		Me.hlpFreeREGbrowser.SetShowHelp(Me.btnRename, True)
		Me.btnRename.Size = New System.Drawing.Size(75, 23)
		Me.btnRename.TabIndex = 7
		Me.btnRename.Text = "Rename"
		Me.btnRename.UseVisualStyleBackColor = True
		'
		'btnDownload
		'
		Me.btnDownload.Enabled = False
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.btnDownload, "")
		Me.hlpFreeREGbrowser.SetHelpString(Me.btnDownload, resources.GetString("btnDownload.HelpString"))
		Me.btnDownload.Location = New System.Drawing.Point(804, 10)
		Me.btnDownload.Name = "btnDownload"
		Me.hlpFreeREGbrowser.SetShowHelp(Me.btnDownload, True)
		Me.btnDownload.Size = New System.Drawing.Size(75, 23)
		Me.btnDownload.TabIndex = 9
		Me.btnDownload.Text = "Download"
		Me.btnDownload.UseVisualStyleBackColor = True
		'
		'btnLogon
		'
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.btnLogon, "")
		Me.hlpFreeREGbrowser.SetHelpString(Me.btnLogon, resources.GetString("btnLogon.HelpString"))
		Me.btnLogon.Location = New System.Drawing.Point(318, 10)
		Me.btnLogon.Name = "btnLogon"
		Me.hlpFreeREGbrowser.SetShowHelp(Me.btnLogon, True)
		Me.btnLogon.Size = New System.Drawing.Size(75, 23)
		Me.btnLogon.TabIndex = 3
		Me.btnLogon.Text = "Logon"
		Me.btnLogon.UseVisualStyleBackColor = True
		'
		'txtPassword
		'
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.txtPassword, "")
		Me.hlpFreeREGbrowser.SetHelpString(Me.txtPassword, "Enter the password for logging on to the FreeREG web site. As you enter the data," & _
				  " the program will (contrary to the above image) keep what you enter secret.")
		Me.txtPassword.Location = New System.Drawing.Point(200, 13)
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.hlpFreeREGbrowser.SetShowHelp(Me.txtPassword, True)
		Me.txtPassword.Size = New System.Drawing.Size(100, 20)
		Me.txtPassword.TabIndex = 2
		'
		'txtUserid
		'
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.txtUserid, "")
		Me.hlpFreeREGbrowser.SetHelpString(Me.txtUserid, "Enter your User Id. that you use for accessing the FreeREG web site.")
		Me.txtUserid.Location = New System.Drawing.Point(41, 13)
		Me.txtUserid.Name = "txtUserid"
		Me.hlpFreeREGbrowser.SetShowHelp(Me.txtUserid, True)
		Me.txtUserid.Size = New System.Drawing.Size(86, 20)
		Me.txtUserid.TabIndex = 1
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(133, 16)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(56, 13)
		Me.Label3.TabIndex = 12
		Me.Label3.Text = "Password:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(3, 16)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(41, 13)
		Me.Label2.TabIndex = 11
		Me.Label2.Text = "UserId:"
		'
		'SplitContainer2
		'
		Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
		Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer2.Name = "SplitContainer2"
		Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer2.Panel1
		'
		Me.SplitContainer2.Panel1.Controls.Add(Me.dgvFileList)
		'
		'SplitContainer2.Panel2
		'
		Me.SplitContainer2.Panel2.Controls.Add(Me.ssFreeREGbrowser)
		Me.SplitContainer2.Size = New System.Drawing.Size(893, 547)
		Me.SplitContainer2.SplitterDistance = 521
		Me.SplitContainer2.SplitterWidth = 1
		Me.SplitContainer2.TabIndex = 1
		'
		'dgvFileList
		'
		Me.dgvFileList.AllowUserToAddRows = False
		Me.dgvFileList.AllowUserToDeleteRows = False
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
		Me.dgvFileList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvFileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvFileList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
		Me.dgvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvFileList.DefaultCellStyle = DataGridViewCellStyle2
		Me.dgvFileList.Dock = System.Windows.Forms.DockStyle.Fill
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me.dgvFileList, "FreeRegBrowser.htm")
		Me.hlpFreeREGbrowser.SetHelpNavigator(Me.dgvFileList, System.Windows.Forms.HelpNavigator.Topic)
		Me.dgvFileList.Location = New System.Drawing.Point(0, 0)
		Me.dgvFileList.MultiSelect = False
		Me.dgvFileList.Name = "dgvFileList"
		Me.dgvFileList.ReadOnly = True
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvFileList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
		Me.dgvFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.hlpFreeREGbrowser.SetShowHelp(Me.dgvFileList, True)
		Me.dgvFileList.Size = New System.Drawing.Size(893, 521)
		Me.dgvFileList.TabIndex = 10
		'
		'ssFreeREGbrowser
		'
		Me.ssFreeREGbrowser.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ssFreeREGbrowser.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
		Me.ssFreeREGbrowser.Location = New System.Drawing.Point(0, 0)
		Me.ssFreeREGbrowser.Name = "ssFreeREGbrowser"
		Me.ssFreeREGbrowser.Size = New System.Drawing.Size(893, 25)
		Me.ssFreeREGbrowser.TabIndex = 13
		Me.ssFreeREGbrowser.Text = "ssFreeREGbrowser"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 20)
		'
		'wbFreeREG
		'
		Me.wbFreeREG.Dock = System.Windows.Forms.DockStyle.Fill
		Me.wbFreeREG.Location = New System.Drawing.Point(0, 0)
		Me.wbFreeREG.Name = "wbFreeREG"
		Me.wbFreeREG.Size = New System.Drawing.Size(893, 587)
		Me.wbFreeREG.TabIndex = 0
		Me.wbFreeREG.Visible = False
		'
		'hlpFreeREGbrowser
		'
		Me.hlpFreeREGbrowser.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'FreeRegBrowser
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(893, 587)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.wbFreeREG)
		Me.HelpButton = True
		Me.hlpFreeREGbrowser.SetHelpKeyword(Me, "FreeRegBrowser.htm")
		Me.hlpFreeREGbrowser.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FreeRegBrowser"
		Me.hlpFreeREGbrowser.SetShowHelp(Me, True)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "FreeREG Server Gateway"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		Me.SplitContainer2.Panel1.ResumeLayout(False)
		Me.SplitContainer2.Panel2.ResumeLayout(False)
		Me.SplitContainer2.Panel2.PerformLayout()
		Me.SplitContainer2.ResumeLayout(False)
		CType(Me.dgvFileList, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ssFreeREGbrowser.ResumeLayout(False)
		Me.ssFreeREGbrowser.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents txtPassword As System.Windows.Forms.TextBox
	Friend WithEvents txtUserid As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents btnLogon As System.Windows.Forms.Button
	Friend WithEvents wbFreeREG As System.Windows.Forms.WebBrowser
	Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
	Friend WithEvents ssFreeREGbrowser As System.Windows.Forms.StatusStrip
	Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents dgvFileList As System.Windows.Forms.DataGridView
	Friend WithEvents btnDownload As System.Windows.Forms.Button
	Friend WithEvents btnReplace As System.Windows.Forms.Button
	Friend WithEvents btnDelete As System.Windows.Forms.Button
	Friend WithEvents btnRename As System.Windows.Forms.Button
	Friend WithEvents btnViewErrors As System.Windows.Forms.Button
	Friend WithEvents btnUploadFile As System.Windows.Forms.Button
	Friend WithEvents hlpFreeREGbrowser As System.Windows.Forms.HelpProvider

End Class
