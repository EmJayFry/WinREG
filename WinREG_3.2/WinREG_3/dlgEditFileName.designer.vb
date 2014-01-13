<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEditFileName
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEditFileName))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.lblDefaultFileName = New System.Windows.Forms.Label
		Me.lblFileName = New System.Windows.Forms.Label
		Me.lblNewFileName = New System.Windows.Forms.Label
		Me.mtbFileName = New System.Windows.Forms.MaskedTextBox
		Me.ttRenameFile = New System.Windows.Forms.ToolTip(Me.components)
		Me.hlpRenameFile = New System.Windows.Forms.HelpProvider
		Me.errRenameFile = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.chkChangeCounty = New System.Windows.Forms.CheckBox
		Me.cboCountyList = New System.Windows.Forms.ComboBox
		Me.TableLayoutPanel1.SuspendLayout()
		CType(Me.errRenameFile, System.ComponentModel.ISupportInitialize).BeginInit()
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(144, 76)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
		Me.TableLayoutPanel1.TabIndex = 1
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
		'lblDefaultFileName
		'
		Me.lblDefaultFileName.AutoSize = True
		Me.lblDefaultFileName.Location = New System.Drawing.Point(13, 13)
		Me.lblDefaultFileName.Name = "lblDefaultFileName"
		Me.lblDefaultFileName.Size = New System.Drawing.Size(92, 13)
		Me.lblDefaultFileName.TabIndex = 2
		Me.lblDefaultFileName.Text = "Default File name:"
		'
		'lblFileName
		'
		Me.lblFileName.AutoSize = True
		Me.lblFileName.Location = New System.Drawing.Point(150, 13)
		Me.lblFileName.Name = "lblFileName"
		Me.lblFileName.Size = New System.Drawing.Size(39, 13)
		Me.lblFileName.TabIndex = 3
		Me.lblFileName.Text = "Label2"
		'
		'lblNewFileName
		'
		Me.lblNewFileName.AutoSize = True
		Me.lblNewFileName.Location = New System.Drawing.Point(13, 44)
		Me.lblNewFileName.Name = "lblNewFileName"
		Me.lblNewFileName.Size = New System.Drawing.Size(82, 13)
		Me.lblNewFileName.TabIndex = 4
		Me.lblNewFileName.Text = "New File Name:"
		'
		'mtbFileName
		'
		Me.mtbFileName.AsciiOnly = True
		Me.mtbFileName.BeepOnError = True
		Me.mtbFileName.Culture = New System.Globalization.CultureInfo("")
		Me.mtbFileName.Location = New System.Drawing.Point(153, 41)
		Me.mtbFileName.Name = "mtbFileName"
		Me.mtbFileName.RejectInputOnFirstFailure = True
		Me.mtbFileName.Size = New System.Drawing.Size(100, 20)
		Me.mtbFileName.TabIndex = 0
		Me.ttRenameFile.SetToolTip(Me.mtbFileName, resources.GetString("mtbFileName.ToolTip"))
		'
		'ttRenameFile
		'
		Me.ttRenameFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.ttRenameFile.IsBalloon = True
		Me.ttRenameFile.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		Me.ttRenameFile.ToolTipTitle = "New File Name"
		'
		'hlpRenameFile
		'
		Me.hlpRenameFile.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'errRenameFile
		'
		Me.errRenameFile.ContainerControl = Me
		'
		'chkChangeCounty
		'
		Me.chkChangeCounty.AutoSize = True
		Me.chkChangeCounty.Location = New System.Drawing.Point(280, 12)
		Me.chkChangeCounty.Name = "chkChangeCounty"
		Me.chkChangeCounty.Size = New System.Drawing.Size(99, 17)
		Me.chkChangeCounty.TabIndex = 5
		Me.chkChangeCounty.Text = "Change County"
		Me.chkChangeCounty.UseVisualStyleBackColor = True
		'
		'cboCountyList
		'
		Me.cboCountyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboCountyList.Enabled = False
		Me.cboCountyList.FormattingEnabled = True
		Me.cboCountyList.Location = New System.Drawing.Point(280, 40)
		Me.cboCountyList.Name = "cboCountyList"
		Me.cboCountyList.Size = New System.Drawing.Size(121, 21)
		Me.cboCountyList.TabIndex = 6
		'
		'dlgEditFileName
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(435, 117)
		Me.Controls.Add(Me.cboCountyList)
		Me.Controls.Add(Me.chkChangeCounty)
		Me.Controls.Add(Me.mtbFileName)
		Me.Controls.Add(Me.lblNewFileName)
		Me.Controls.Add(Me.lblFileName)
		Me.Controls.Add(Me.lblDefaultFileName)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.HelpButton = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgEditFileName"
		Me.ShowInTaskbar = False
		Me.Text = "Edit File Name"
		Me.TableLayoutPanel1.ResumeLayout(False)
		CType(Me.errRenameFile, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents lblDefaultFileName As System.Windows.Forms.Label
	Friend WithEvents lblFileName As System.Windows.Forms.Label
	Friend WithEvents lblNewFileName As System.Windows.Forms.Label
	Friend WithEvents mtbFileName As System.Windows.Forms.MaskedTextBox
	Friend WithEvents ttRenameFile As System.Windows.Forms.ToolTip
	Friend WithEvents hlpRenameFile As System.Windows.Forms.HelpProvider
	Friend WithEvents errRenameFile As System.Windows.Forms.ErrorProvider
	Friend WithEvents chkChangeCounty As System.Windows.Forms.CheckBox
	Friend WithEvents cboCountyList As System.Windows.Forms.ComboBox

End Class
