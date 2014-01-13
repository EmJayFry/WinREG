<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEditFileDetails
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEditFileDetails))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.txtChurch = New CaseText.CaseText
		Me.lblSource = New System.Windows.Forms.Label
		Me.txtSource = New CaseText.CaseText
		Me.lblComments = New System.Windows.Forms.Label
		Me.txtComments = New CaseText.CaseText
		Me.lblChurch = New System.Windows.Forms.Label
		Me.errAlterDetails = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.hlpAlterDetails = New System.Windows.Forms.HelpProvider
		Me.lblPlaceName = New System.Windows.Forms.Label
		Me.txtPlaceName = New CaseText.CaseText
		Me.ttAlterDetails = New System.Windows.Forms.ToolTip(Me.components)
		Me.lblCreditName = New System.Windows.Forms.Label
		Me.lblCreditEmailAddress = New System.Windows.Forms.Label
		Me.txtCreditTo = New System.Windows.Forms.TextBox
		Me.txtCreditEmailAddress = New System.Windows.Forms.TextBox
		Me.regexEmailAddress = New CustomValidation.RegularExpressionValidator
		Me.regexName = New CustomValidation.RegularExpressionValidator
		Me.TableLayoutPanel1.SuspendLayout()
		CType(Me.errAlterDetails, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.regexEmailAddress, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.regexName, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.33333!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.66667!))
		Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(235, 161)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(150, 34)
		Me.TableLayoutPanel1.TabIndex = 4
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.OK_Button.Location = New System.Drawing.Point(3, 5)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(67, 23)
		Me.OK_Button.TabIndex = 5
		Me.OK_Button.Text = "OK"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Cancel_Button.CausesValidation = False
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(78, 5)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
		Me.Cancel_Button.TabIndex = 6
		Me.Cancel_Button.Text = "Cancel"
		'
		'txtChurch
		'
		Me.txtChurch.Location = New System.Drawing.Point(80, 33)
		Me.txtChurch.Name = "txtChurch"
		Me.txtChurch.Size = New System.Drawing.Size(300, 21)
		Me.txtChurch.TabIndex = 1
		Me.txtChurch.TextCase = CaseText.CaseText.CaseType.Title
		Me.ttAlterDetails.SetToolTip(Me.txtChurch, resources.GetString("txtChurch.ToolTip"))
		'
		'lblSource
		'
		Me.lblSource.AutoSize = True
		Me.lblSource.Location = New System.Drawing.Point(33, 105)
		Me.lblSource.Name = "lblSource"
		Me.lblSource.Size = New System.Drawing.Size(40, 13)
		Me.lblSource.TabIndex = 3
		Me.lblSource.Text = "Source"
		Me.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'txtSource
		'
		Me.txtSource.Location = New System.Drawing.Point(80, 102)
		Me.txtSource.Name = "txtSource"
		Me.txtSource.Size = New System.Drawing.Size(300, 21)
		Me.txtSource.TabIndex = 2
		Me.txtSource.TextCase = CaseText.CaseText.CaseType.Normal
		Me.ttAlterDetails.SetToolTip(Me.txtSource, "This field should identify the source information" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the transcript.")
		'
		'lblComments
		'
		Me.lblComments.AutoSize = True
		Me.lblComments.Location = New System.Drawing.Point(16, 128)
		Me.lblComments.Name = "lblComments"
		Me.lblComments.Size = New System.Drawing.Size(57, 13)
		Me.lblComments.TabIndex = 5
		Me.lblComments.Text = "Comments"
		Me.lblComments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'txtComments
		'
		Me.txtComments.Location = New System.Drawing.Point(80, 125)
		Me.txtComments.Name = "txtComments"
		Me.txtComments.Size = New System.Drawing.Size(300, 21)
		Me.txtComments.TabIndex = 3
		Me.txtComments.TextCase = CaseText.CaseText.CaseType.Normal
		Me.ttAlterDetails.SetToolTip(Me.txtComments, "This field is optional and is provided so that the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "transcriber can supply extra " & _
				  "information about where" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the data in the transcript was obtained from.")
		'
		'lblChurch
		'
		Me.lblChurch.AutoSize = True
		Me.lblChurch.Location = New System.Drawing.Point(32, 36)
		Me.lblChurch.Name = "lblChurch"
		Me.lblChurch.Size = New System.Drawing.Size(41, 13)
		Me.lblChurch.TabIndex = 1
		Me.lblChurch.Text = "Church"
		Me.lblChurch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'errAlterDetails
		'
		Me.errAlterDetails.ContainerControl = Me
		'
		'hlpAlterDetails
		'
		Me.hlpAlterDetails.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'lblPlaceName
		'
		Me.lblPlaceName.AutoSize = True
		Me.lblPlaceName.Location = New System.Drawing.Point(12, 13)
		Me.lblPlaceName.Name = "lblPlaceName"
		Me.lblPlaceName.Size = New System.Drawing.Size(61, 13)
		Me.lblPlaceName.TabIndex = 7
		Me.lblPlaceName.Text = "Place name"
		'
		'txtPlaceName
		'
		Me.txtPlaceName.Location = New System.Drawing.Point(80, 10)
		Me.txtPlaceName.Name = "txtPlaceName"
		Me.txtPlaceName.Size = New System.Drawing.Size(300, 21)
		Me.txtPlaceName.TabIndex = 0
		Me.txtPlaceName.TextCase = CaseText.CaseText.CaseType.Title
		Me.ttAlterDetails.SetToolTip(Me.txtPlaceName, resources.GetString("txtPlaceName.ToolTip"))
		'
		'ttAlterDetails
		'
		Me.ttAlterDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.ttAlterDetails.IsBalloon = True
		Me.ttAlterDetails.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		'
		'lblCreditName
		'
		Me.lblCreditName.AutoSize = True
		Me.lblCreditName.Location = New System.Drawing.Point(24, 59)
		Me.lblCreditName.Name = "lblCreditName"
		Me.lblCreditName.Size = New System.Drawing.Size(49, 13)
		Me.lblCreditName.TabIndex = 8
		Me.lblCreditName.Text = "Credit to"
		'
		'lblCreditEmailAddress
		'
		Me.lblCreditEmailAddress.AutoSize = True
		Me.lblCreditEmailAddress.Location = New System.Drawing.Point(0, 82)
		Me.lblCreditEmailAddress.Name = "lblCreditEmailAddress"
		Me.lblCreditEmailAddress.Size = New System.Drawing.Size(73, 13)
		Me.lblCreditEmailAddress.TabIndex = 9
		Me.lblCreditEmailAddress.Text = "EMail Address"
		'
		'txtCreditTo
		'
		Me.txtCreditTo.Location = New System.Drawing.Point(80, 56)
		Me.txtCreditTo.Name = "txtCreditTo"
		Me.txtCreditTo.Size = New System.Drawing.Size(300, 21)
		Me.txtCreditTo.TabIndex = 10
		'
		'txtCreditEmailAddress
		'
		Me.txtCreditEmailAddress.Location = New System.Drawing.Point(80, 79)
		Me.txtCreditEmailAddress.Name = "txtCreditEmailAddress"
		Me.txtCreditEmailAddress.Size = New System.Drawing.Size(300, 21)
		Me.txtCreditEmailAddress.TabIndex = 11
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
		'dlgEditFileDetails
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(394, 197)
		Me.Controls.Add(Me.txtCreditEmailAddress)
		Me.Controls.Add(Me.txtCreditTo)
		Me.Controls.Add(Me.lblCreditEmailAddress)
		Me.Controls.Add(Me.lblCreditName)
		Me.Controls.Add(Me.txtPlaceName)
		Me.Controls.Add(Me.lblPlaceName)
		Me.Controls.Add(Me.lblChurch)
		Me.Controls.Add(Me.txtChurch)
		Me.Controls.Add(Me.lblSource)
		Me.Controls.Add(Me.txtSource)
		Me.Controls.Add(Me.lblComments)
		Me.Controls.Add(Me.txtComments)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.HelpButton = True
		Me.hlpAlterDetails.SetHelpKeyword(Me, "FileDetails.html")
		Me.hlpAlterDetails.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgEditFileDetails"
		Me.hlpAlterDetails.SetShowHelp(Me, True)
		Me.ShowInTaskbar = False
		Me.Text = "Common File Details"
		Me.TableLayoutPanel1.ResumeLayout(False)
		CType(Me.errAlterDetails, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.regexEmailAddress, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.regexName, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents txtChurch As CaseText.CaseText
	Friend WithEvents lblSource As System.Windows.Forms.Label
	Friend WithEvents txtSource As CaseText.CaseText
	Friend WithEvents lblComments As System.Windows.Forms.Label
	Friend WithEvents txtComments As CaseText.CaseText
	Friend WithEvents lblChurch As System.Windows.Forms.Label
	Friend WithEvents errAlterDetails As System.Windows.Forms.ErrorProvider
	Friend WithEvents hlpAlterDetails As System.Windows.Forms.HelpProvider
	Friend WithEvents txtPlaceName As CaseText.CaseText
	Friend WithEvents lblPlaceName As System.Windows.Forms.Label
	Friend WithEvents ttAlterDetails As System.Windows.Forms.ToolTip
	Friend WithEvents lblCreditEmailAddress As System.Windows.Forms.Label
	Friend WithEvents lblCreditName As System.Windows.Forms.Label
	Friend WithEvents txtCreditEmailAddress As System.Windows.Forms.TextBox
	Friend WithEvents txtCreditTo As System.Windows.Forms.TextBox
	Friend WithEvents regexEmailAddress As CustomValidation.RegularExpressionValidator
	Friend WithEvents regexName As CustomValidation.RegularExpressionValidator

End Class
