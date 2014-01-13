<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgNewTranscriptionFile
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgNewTranscriptionFile))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.lblCounty = New System.Windows.Forms.Label
		Me.lblPlacename = New System.Windows.Forms.Label
		Me.lblChurchName = New System.Windows.Forms.Label
		Me.lblRecordType = New System.Windows.Forms.Label
		Me.errNewTranscriptionFile = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.lblSource = New System.Windows.Forms.Label
		Me.lblComments = New System.Windows.Forms.Label
		Me.frmNewTranscriptionFile = New CustomValidation.FormValidator
		Me.cbRecordType = New System.Windows.Forms.ComboBox
		Me.cbCounty = New System.Windows.Forms.ComboBox
		Me.lblFileName = New System.Windows.Forms.Label
		Me.txtFileName = New System.Windows.Forms.TextBox
		Me.ttNewTranscriptionFile = New System.Windows.Forms.ToolTip(Me.components)
		Me.nudSuffix = New System.Windows.Forms.NumericUpDown
		Me.Label1 = New System.Windows.Forms.Label
		Me.cbScreenLayouts = New System.Windows.Forms.ComboBox
		Me.labColumnLayout = New System.Windows.Forms.Label
		Me.txtPlaceCode = New System.Windows.Forms.TextBox
		Me.reqPlaceCode = New CustomValidation.RequiredFieldValidator
		Me.hlpNewTranscriptionFile = New System.Windows.Forms.HelpProvider
		Me.txtCreditEmailAddress = New System.Windows.Forms.TextBox
		Me.txtCreditTo = New System.Windows.Forms.TextBox
		Me.lblCreditEmailAddress = New System.Windows.Forms.Label
		Me.lblCreditName = New System.Windows.Forms.Label
		Me.txtPlaceName = New CaseText.CaseText
		Me.txtChurchName = New CaseText.CaseText
		Me.txtSource = New CaseText.CaseText
		Me.txtComments = New CaseText.CaseText
		Me.reqPlaceName = New CustomValidation.RequiredFieldValidator
		Me.reqChurchName = New CustomValidation.RequiredFieldValidator
		Me.regexEmailAddress = New CustomValidation.RegularExpressionValidator
		Me.regexName = New CustomValidation.RegularExpressionValidator
		Me.TableLayoutPanel1.SuspendLayout()
		CType(Me.errNewTranscriptionFile, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.frmNewTranscriptionFile, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.nudSuffix, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.reqPlaceCode, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.reqPlaceName, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.reqChurchName, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.regexEmailAddress, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.regexName, System.ComponentModel.ISupportInitialize).BeginInit()
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(253, 274)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
		Me.TableLayoutPanel1.TabIndex = 23
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.OK_Button.Location = New System.Drawing.Point(3, 3)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(67, 23)
		Me.OK_Button.TabIndex = 19
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
		Me.Cancel_Button.TabIndex = 20
		Me.Cancel_Button.Text = "Cancel"
		'
		'lblCounty
		'
		Me.lblCounty.AutoSize = True
		Me.lblCounty.Location = New System.Drawing.Point(41, 9)
		Me.lblCounty.Name = "lblCounty"
		Me.lblCounty.Size = New System.Drawing.Size(40, 13)
		Me.lblCounty.TabIndex = 0
		Me.lblCounty.Text = "County"
		'
		'lblPlacename
		'
		Me.lblPlacename.AutoSize = True
		Me.lblPlacename.Location = New System.Drawing.Point(18, 36)
		Me.lblPlacename.Name = "lblPlacename"
		Me.lblPlacename.Size = New System.Drawing.Size(63, 13)
		Me.lblPlacename.TabIndex = 2
		Me.lblPlacename.Text = "Place name"
		'
		'lblChurchName
		'
		Me.lblChurchName.AutoSize = True
		Me.lblChurchName.Location = New System.Drawing.Point(11, 60)
		Me.lblChurchName.Name = "lblChurchName"
		Me.lblChurchName.Size = New System.Drawing.Size(70, 13)
		Me.lblChurchName.TabIndex = 5
		Me.lblChurchName.Text = "Church name"
		'
		'lblRecordType
		'
		Me.lblRecordType.AutoSize = True
		Me.lblRecordType.Location = New System.Drawing.Point(5, 85)
		Me.lblRecordType.Name = "lblRecordType"
		Me.lblRecordType.Size = New System.Drawing.Size(76, 13)
		Me.lblRecordType.TabIndex = 7
		Me.lblRecordType.Text = "Type of record"
		'
		'errNewTranscriptionFile
		'
		Me.errNewTranscriptionFile.ContainerControl = Me
		'
		'lblSource
		'
		Me.lblSource.AutoSize = True
		Me.lblSource.Location = New System.Drawing.Point(40, 111)
		Me.lblSource.Name = "lblSource"
		Me.lblSource.Size = New System.Drawing.Size(41, 13)
		Me.lblSource.TabIndex = 11
		Me.lblSource.Text = "Source"
		'
		'lblComments
		'
		Me.lblComments.AutoSize = True
		Me.lblComments.Location = New System.Drawing.Point(25, 136)
		Me.lblComments.Name = "lblComments"
		Me.lblComments.Size = New System.Drawing.Size(56, 13)
		Me.lblComments.TabIndex = 13
		Me.lblComments.Text = "Comments"
		'
		'frmNewTranscriptionFile
		'
		Me.frmNewTranscriptionFile.HostingForm = Me
		'
		'cbRecordType
		'
		Me.cbRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbRecordType.FormattingEnabled = True
		Me.cbRecordType.Location = New System.Drawing.Point(89, 82)
		Me.cbRecordType.Name = "cbRecordType"
		Me.cbRecordType.Size = New System.Drawing.Size(121, 21)
		Me.cbRecordType.TabIndex = 8
		'
		'cbCounty
		'
		Me.cbCounty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cbCounty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cbCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbCounty.FormattingEnabled = True
		Me.cbCounty.Location = New System.Drawing.Point(89, 6)
		Me.cbCounty.Name = "cbCounty"
		Me.cbCounty.Size = New System.Drawing.Size(121, 21)
		Me.cbCounty.TabIndex = 1
		'
		'lblFileName
		'
		Me.lblFileName.AutoSize = True
		Me.lblFileName.Location = New System.Drawing.Point(27, 162)
		Me.lblFileName.Name = "lblFileName"
		Me.lblFileName.Size = New System.Drawing.Size(54, 13)
		Me.lblFileName.TabIndex = 15
		Me.lblFileName.Text = "File Name"
		'
		'txtFileName
		'
		Me.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtFileName.CausesValidation = False
		Me.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtFileName.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFileName.Location = New System.Drawing.Point(89, 158)
		Me.txtFileName.MaxLength = 14
		Me.txtFileName.Name = "txtFileName"
		Me.txtFileName.ReadOnly = True
		Me.txtFileName.Size = New System.Drawing.Size(146, 19)
		Me.txtFileName.TabIndex = 16
		Me.txtFileName.TabStop = False
		'
		'ttNewTranscriptionFile
		'
		Me.ttNewTranscriptionFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.ttNewTranscriptionFile.IsBalloon = True
		Me.ttNewTranscriptionFile.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		'
		'nudSuffix
		'
		Me.nudSuffix.Location = New System.Drawing.Point(299, 85)
		Me.nudSuffix.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
		Me.nudSuffix.Name = "nudSuffix"
		Me.nudSuffix.Size = New System.Drawing.Size(41, 20)
		Me.nudSuffix.TabIndex = 10
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(260, 87)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(33, 13)
		Me.Label1.TabIndex = 9
		Me.Label1.Text = "Suffix"
		'
		'cbScreenLayouts
		'
		Me.cbScreenLayouts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbScreenLayouts.Enabled = False
		Me.cbScreenLayouts.FormattingEnabled = True
		Me.cbScreenLayouts.Location = New System.Drawing.Point(89, 182)
		Me.cbScreenLayouts.Name = "cbScreenLayouts"
		Me.cbScreenLayouts.Size = New System.Drawing.Size(280, 21)
		Me.cbScreenLayouts.TabIndex = 18
		Me.cbScreenLayouts.Visible = False
		'
		'labColumnLayout
		'
		Me.labColumnLayout.AutoSize = True
		Me.labColumnLayout.Enabled = False
		Me.labColumnLayout.Location = New System.Drawing.Point(4, 185)
		Me.labColumnLayout.Name = "labColumnLayout"
		Me.labColumnLayout.Size = New System.Drawing.Size(77, 13)
		Me.labColumnLayout.TabIndex = 17
		Me.labColumnLayout.Text = "Column Layout"
		Me.labColumnLayout.Visible = False
		'
		'txtPlaceCode
		'
		Me.txtPlaceCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtPlaceCode.Location = New System.Drawing.Point(347, 33)
		Me.txtPlaceCode.MaxLength = 3
		Me.txtPlaceCode.Name = "txtPlaceCode"
		Me.txtPlaceCode.Size = New System.Drawing.Size(41, 20)
		Me.txtPlaceCode.TabIndex = 4
		'
		'reqPlaceCode
		'
		Me.reqPlaceCode.ControlToValidate = Me.txtPlaceCode
		Me.reqPlaceCode.ErrorMessage = "The Place Code is a required field"
		Me.reqPlaceCode.Icon = CType(resources.GetObject("reqPlaceCode.Icon"), System.Drawing.Icon)
		Me.reqPlaceCode.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		'
		'hlpNewTranscriptionFile
		'
		Me.hlpNewTranscriptionFile.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'txtCreditEmailAddress
		'
		Me.txtCreditEmailAddress.Location = New System.Drawing.Point(87, 233)
		Me.txtCreditEmailAddress.Name = "txtCreditEmailAddress"
		Me.txtCreditEmailAddress.Size = New System.Drawing.Size(300, 20)
		Me.txtCreditEmailAddress.TabIndex = 22
		'
		'txtCreditTo
		'
		Me.txtCreditTo.Location = New System.Drawing.Point(89, 208)
		Me.txtCreditTo.Name = "txtCreditTo"
		Me.txtCreditTo.Size = New System.Drawing.Size(300, 20)
		Me.txtCreditTo.TabIndex = 20
		'
		'lblCreditEmailAddress
		'
		Me.lblCreditEmailAddress.AutoSize = True
		Me.lblCreditEmailAddress.Location = New System.Drawing.Point(7, 236)
		Me.lblCreditEmailAddress.Name = "lblCreditEmailAddress"
		Me.lblCreditEmailAddress.Size = New System.Drawing.Size(74, 13)
		Me.lblCreditEmailAddress.TabIndex = 21
		Me.lblCreditEmailAddress.Text = "EMail Address"
		'
		'lblCreditName
		'
		Me.lblCreditName.AutoSize = True
		Me.lblCreditName.Location = New System.Drawing.Point(35, 211)
		Me.lblCreditName.Name = "lblCreditName"
		Me.lblCreditName.Size = New System.Drawing.Size(46, 13)
		Me.lblCreditName.TabIndex = 19
		Me.lblCreditName.Text = "Credit to"
		'
		'txtPlaceName
		'
		Me.txtPlaceName.Location = New System.Drawing.Point(89, 32)
		Me.txtPlaceName.MaxLength = 127
		Me.txtPlaceName.Name = "txtPlaceName"
		Me.txtPlaceName.Size = New System.Drawing.Size(251, 20)
		Me.txtPlaceName.TabIndex = 3
		Me.txtPlaceName.TextCase = CaseText.CaseText.CaseType.Title
		'
		'txtChurchName
		'
		Me.txtChurchName.Location = New System.Drawing.Point(89, 57)
		Me.txtChurchName.Name = "txtChurchName"
		Me.txtChurchName.Size = New System.Drawing.Size(251, 20)
		Me.txtChurchName.TabIndex = 6
		Me.txtChurchName.TextCase = CaseText.CaseText.CaseType.Title
		'
		'txtSource
		'
		Me.txtSource.Location = New System.Drawing.Point(89, 108)
		Me.txtSource.Name = "txtSource"
		Me.txtSource.Size = New System.Drawing.Size(299, 20)
		Me.txtSource.TabIndex = 12
		Me.txtSource.TextCase = CaseText.CaseText.CaseType.Sentence
		'
		'txtComments
		'
		Me.txtComments.Location = New System.Drawing.Point(89, 133)
		Me.txtComments.Name = "txtComments"
		Me.txtComments.Size = New System.Drawing.Size(299, 20)
		Me.txtComments.TabIndex = 14
		Me.txtComments.TextCase = CaseText.CaseText.CaseType.Sentence
		'
		'reqPlaceName
		'
		Me.reqPlaceName.ControlToValidate = Me.txtPlaceName
		Me.reqPlaceName.ErrorMessage = "The Place Name is a required field."
		Me.reqPlaceName.Icon = CType(resources.GetObject("reqPlaceName.Icon"), System.Drawing.Icon)
		Me.reqPlaceName.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		'
		'reqChurchName
		'
		Me.reqChurchName.ControlToValidate = Me.txtChurchName
		Me.reqChurchName.ErrorMessage = "The name of the Church is a required field."
		Me.reqChurchName.Icon = CType(resources.GetObject("reqChurchName.Icon"), System.Drawing.Icon)
		Me.reqChurchName.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		'
		'regexEmailAddress
		'
		Me.regexEmailAddress.ControlToValidate = Me.txtCreditEmailAddress
		Me.regexEmailAddress.ErrorMessage = "The email address that has been entered is invalid"
		Me.regexEmailAddress.Icon = CType(resources.GetObject("regexEmailAddress.Icon"), System.Drawing.Icon)
		Me.regexEmailAddress.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		Me.regexEmailAddress.ValidateOnLoad = True
		Me.regexEmailAddress.ValidationExpression = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3} \.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" & _
			 ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)"
		'
		'regexName
		'
		Me.regexName.ControlToValidate = Me.txtCreditTo
		Me.regexName.ErrorMessage = "The name of the person being credited can only contain letters and spaces"
		Me.regexName.Icon = CType(resources.GetObject("regexName.Icon"), System.Drawing.Icon)
		Me.regexName.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		Me.regexName.ValidateOnLoad = True
		Me.regexName.ValidationExpression = "^[a-zA-Z\s-]+$"
		'
		'dlgNewTranscriptionFile
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(411, 315)
		Me.Controls.Add(Me.txtCreditEmailAddress)
		Me.Controls.Add(Me.txtCreditTo)
		Me.Controls.Add(Me.lblCreditEmailAddress)
		Me.Controls.Add(Me.lblCreditName)
		Me.Controls.Add(Me.labColumnLayout)
		Me.Controls.Add(Me.cbScreenLayouts)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.nudSuffix)
		Me.Controls.Add(Me.lblCounty)
		Me.Controls.Add(Me.cbCounty)
		Me.Controls.Add(Me.lblPlacename)
		Me.Controls.Add(Me.txtPlaceName)
		Me.Controls.Add(Me.txtPlaceCode)
		Me.Controls.Add(Me.lblChurchName)
		Me.Controls.Add(Me.txtChurchName)
		Me.Controls.Add(Me.lblRecordType)
		Me.Controls.Add(Me.cbRecordType)
		Me.Controls.Add(Me.lblSource)
		Me.Controls.Add(Me.txtSource)
		Me.Controls.Add(Me.lblComments)
		Me.Controls.Add(Me.txtComments)
		Me.Controls.Add(Me.lblFileName)
		Me.Controls.Add(Me.txtFileName)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.HelpButton = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgNewTranscriptionFile"
		Me.hlpNewTranscriptionFile.SetShowHelp(Me, True)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Create a New Transcription File"
		Me.TableLayoutPanel1.ResumeLayout(False)
		CType(Me.errNewTranscriptionFile, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.frmNewTranscriptionFile, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.nudSuffix, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.reqPlaceCode, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.reqPlaceName, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.reqChurchName, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.regexEmailAddress, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.regexName, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents lblCounty As System.Windows.Forms.Label
	Friend WithEvents lblPlacename As System.Windows.Forms.Label
	Friend WithEvents lblChurchName As System.Windows.Forms.Label
	Friend WithEvents lblRecordType As System.Windows.Forms.Label
	Friend WithEvents errNewTranscriptionFile As System.Windows.Forms.ErrorProvider
	Friend WithEvents lblComments As System.Windows.Forms.Label
	Friend WithEvents lblSource As System.Windows.Forms.Label
	Friend WithEvents txtComments As CaseText.CaseText
	Friend WithEvents txtSource As CaseText.CaseText
	Friend WithEvents txtChurchName As CaseText.CaseText
	Friend WithEvents txtPlaceName As CaseText.CaseText
	Friend WithEvents reqPlaceName As CustomValidation.RequiredFieldValidator
	Friend WithEvents reqChurchName As CustomValidation.RequiredFieldValidator
	Friend WithEvents frmNewTranscriptionFile As CustomValidation.FormValidator
	Friend WithEvents cbRecordType As System.Windows.Forms.ComboBox
	Friend WithEvents cbCounty As System.Windows.Forms.ComboBox
	Friend WithEvents txtFileName As System.Windows.Forms.TextBox
	Friend WithEvents lblFileName As System.Windows.Forms.Label
	Friend WithEvents ttNewTranscriptionFile As System.Windows.Forms.ToolTip
	Friend WithEvents hlpNewTranscriptionFile As System.Windows.Forms.HelpProvider
	Friend WithEvents txtPlaceCode As System.Windows.Forms.TextBox
	Friend WithEvents reqPlaceCode As CustomValidation.RequiredFieldValidator
	Friend WithEvents nudSuffix As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents cbScreenLayouts As System.Windows.Forms.ComboBox
	Friend WithEvents labColumnLayout As System.Windows.Forms.Label
	Friend WithEvents txtCreditEmailAddress As System.Windows.Forms.TextBox
	Friend WithEvents txtCreditTo As System.Windows.Forms.TextBox
	Friend WithEvents lblCreditEmailAddress As System.Windows.Forms.Label
	Friend WithEvents lblCreditName As System.Windows.Forms.Label
	Friend WithEvents regexEmailAddress As CustomValidation.RegularExpressionValidator
	Friend WithEvents regexName As CustomValidation.RegularExpressionValidator

End Class
