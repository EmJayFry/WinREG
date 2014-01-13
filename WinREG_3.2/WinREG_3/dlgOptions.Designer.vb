<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgOptions
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgOptions))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.reqDataFolder = New CustomValidation.RequiredFieldValidator
		Me.txtDataFolder = New System.Windows.Forms.TextBox
		Me.reqBackupsFolder = New CustomValidation.RequiredFieldValidator
		Me.txtBackupsFolder = New System.Windows.Forms.TextBox
		Me.ValidatorOptions = New CustomValidation.FormValidator
		Me.summaryOptions = New CustomValidation.ValidationSummary
		Me.fbdFolderBrowser = New System.Windows.Forms.FolderBrowserDialog
		Me.ttOptions = New System.Windows.Forms.ToolTip(Me.components)
		Me.cbSyndicate = New System.Windows.Forms.ComboBox
		Me.mtbMRUSize = New System.Windows.Forms.MaskedTextBox
		Me.btnRemoveAssociations = New System.Windows.Forms.Button
		Me.lbSystemInformation = New System.Windows.Forms.ListBox
		Me.tabOptions = New System.Windows.Forms.TabControl
		Me.tabMyInformationPage = New System.Windows.Forms.TabPage
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.tabDataEntry = New System.Windows.Forms.TabPage
		Me.chkEnableFiltering = New System.Windows.Forms.CheckBox
		Me.lblMRUSize = New System.Windows.Forms.Label
		Me.tabFoldersPage = New System.Windows.Forms.TabPage
		Me.txtOperation = New System.Windows.Forms.Label
		Me.lblDataFolder = New System.Windows.Forms.Label
		Me.btnBrowseDataFolder = New System.Windows.Forms.Button
		Me.lblBackupsFolder = New System.Windows.Forms.Label
		Me.btnBrowseBackupsFolder = New System.Windows.Forms.Button
		Me.lblImageFolder = New System.Windows.Forms.Label
		Me.txtImagesFolder = New System.Windows.Forms.TextBox
		Me.btnBrowseImagesFolder = New System.Windows.Forms.Button
		Me.lblFileOpen = New System.Windows.Forms.Label
		Me.tabColoursAndFonts = New System.Windows.Forms.TabPage
		Me.Label7 = New System.Windows.Forms.Label
		Me.btnCellFont = New System.Windows.Forms.Button
		Me.txtCellFont = New System.Windows.Forms.TextBox
		Me.btnRestoreDefaults = New System.Windows.Forms.Button
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.cbColourAlternate = New ColorComboBox.ColorComboBox
		Me.cbColourNormal = New ColorComboBox.ColorComboBox
		Me.tabSystemPage = New System.Windows.Forms.TabPage
		Me.cstmDataFolder = New CustomValidation.CustomValidator
		Me.cstmBackupsFolder = New CustomValidation.CustomValidator
		Me.cstmImagesFolder = New CustomValidation.CustomValidator
		Me.fdDefaultCellFont = New System.Windows.Forms.FontDialog
		Me.reqName = New CustomValidation.RequiredFieldValidator
		Me.reqEmailAddress = New CustomValidation.RequiredFieldValidator
		Me.regexEmailAddress = New CustomValidation.RegularExpressionValidator
		Me.regexName = New CustomValidation.RegularExpressionValidator
		Me.txtFreeREG_Password = New System.Windows.Forms.TextBox
		Me.txtFreeREG_Id = New System.Windows.Forms.TextBox
		Me.txtName = New CaseText.CaseText
		Me.txtEmailAddress = New CaseText.CaseText
		Me.chkShowSplashScreen = New System.Windows.Forms.CheckBox
		Me.chkUseDataGrid = New System.Windows.Forms.CheckBox
		Me.chkBackupFiles = New System.Windows.Forms.CheckBox
		Me.chkQueryDuplicate = New System.Windows.Forms.CheckBox
		Me.chkAutoCopyDates = New System.Windows.Forms.CheckBox
		Me.chkLeadingZeroOnDates = New System.Windows.Forms.CheckBox
		Me.chkEnableTooltips = New System.Windows.Forms.CheckBox
		Me.lblTooltips1 = New System.Windows.Forms.Label
		Me.nupTooltips = New System.Windows.Forms.NumericUpDown
		Me.lblTooltips2 = New System.Windows.Forms.Label
		Me.chkAutofillFields = New System.Windows.Forms.CheckBox
		Me.hlpOptions = New System.Windows.Forms.HelpProvider
		Me.TableLayoutPanel1.SuspendLayout()
		CType(Me.reqDataFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.reqBackupsFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ValidatorOptions, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tabOptions.SuspendLayout()
		Me.tabMyInformationPage.SuspendLayout()
		Me.tabDataEntry.SuspendLayout()
		Me.tabFoldersPage.SuspendLayout()
		Me.tabColoursAndFonts.SuspendLayout()
		Me.tabSystemPage.SuspendLayout()
		CType(Me.cstmDataFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cstmBackupsFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cstmImagesFolder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.reqName, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.reqEmailAddress, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.regexEmailAddress, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.regexName, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.nupTooltips, System.ComponentModel.ISupportInitialize).BeginInit()
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(324, 311)
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
		Me.Cancel_Button.CausesValidation = False
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Cancel"
		'
		'reqDataFolder
		'
		Me.reqDataFolder.ControlToValidate = Me.txtDataFolder
		Me.reqDataFolder.ErrorMessage = "You must enter a valid pathname for the folder in which your transcription files " & _
			 "will be stored"
		Me.reqDataFolder.Icon = CType(resources.GetObject("reqDataFolder.Icon"), System.Drawing.Icon)
		Me.reqDataFolder.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		Me.reqDataFolder.ValidateOnLoad = True
		'
		'txtDataFolder
		'
		Me.txtDataFolder.Location = New System.Drawing.Point(78, 26)
		Me.txtDataFolder.Name = "txtDataFolder"
		Me.txtDataFolder.Size = New System.Drawing.Size(334, 20)
		Me.txtDataFolder.TabIndex = 1
		'
		'reqBackupsFolder
		'
		Me.reqBackupsFolder.ControlToValidate = Me.txtBackupsFolder
		Me.reqBackupsFolder.ErrorMessage = "You must enter a valid pathname for the folder in which backups your transcriptio" & _
			 "n files will be kept"
		Me.reqBackupsFolder.Icon = CType(resources.GetObject("reqBackupsFolder.Icon"), System.Drawing.Icon)
		Me.reqBackupsFolder.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		Me.reqBackupsFolder.ValidateOnLoad = True
		'
		'txtBackupsFolder
		'
		Me.txtBackupsFolder.Location = New System.Drawing.Point(78, 57)
		Me.txtBackupsFolder.Name = "txtBackupsFolder"
		Me.txtBackupsFolder.Size = New System.Drawing.Size(334, 20)
		Me.txtBackupsFolder.TabIndex = 4
		'
		'ValidatorOptions
		'
		Me.summaryOptions.SetDisplayMode(Me.ValidatorOptions, CustomValidation.ValidationSummaryDisplayMode.BulletList)
		Me.summaryOptions.SetErrorCaption(Me.ValidatorOptions, "User & Program Options")
		Me.summaryOptions.SetErrorMessage(Me.ValidatorOptions, "You must correct these errors before you can continue")
		Me.ValidatorOptions.HostingForm = Me
		Me.summaryOptions.SetShowSummary(Me.ValidatorOptions, True)
		'
		'ttOptions
		'
		Me.ttOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.ttOptions.IsBalloon = True
		Me.ttOptions.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		Me.ttOptions.ToolTipTitle = "TOOLTIP TITLE"
		'
		'cbSyndicate
		'
		Me.cbSyndicate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.cbSyndicate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cbSyndicate.DisplayMember = "Code"
		Me.cbSyndicate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbSyndicate.FormattingEnabled = True
		Me.cbSyndicate.Location = New System.Drawing.Point(107, 131)
		Me.cbSyndicate.Name = "cbSyndicate"
		Me.cbSyndicate.Size = New System.Drawing.Size(185, 21)
		Me.cbSyndicate.TabIndex = 5
		Me.ttOptions.SetToolTip(Me.cbSyndicate, resources.GetString("cbSyndicate.ToolTip"))
		Me.cbSyndicate.ValueMember = "Code"
		'
		'mtbMRUSize
		'
		Me.mtbMRUSize.AllowPromptAsInput = False
		Me.mtbMRUSize.BeepOnError = True
		Me.mtbMRUSize.Culture = New System.Globalization.CultureInfo("")
		Me.mtbMRUSize.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
		Me.mtbMRUSize.HidePromptOnLeave = True
		Me.mtbMRUSize.Location = New System.Drawing.Point(193, 122)
		Me.mtbMRUSize.Mask = "00"
		Me.mtbMRUSize.Name = "mtbMRUSize"
		Me.mtbMRUSize.Size = New System.Drawing.Size(20, 20)
		Me.mtbMRUSize.TabIndex = 6
		Me.mtbMRUSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.mtbMRUSize.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
		Me.ttOptions.SetToolTip(Me.mtbMRUSize, resources.GetString("mtbMRUSize.ToolTip"))
		'
		'btnRemoveAssociations
		'
		Me.btnRemoveAssociations.AutoSize = True
		Me.btnRemoveAssociations.Enabled = False
		Me.btnRemoveAssociations.Location = New System.Drawing.Point(319, 241)
		Me.btnRemoveAssociations.Name = "btnRemoveAssociations"
		Me.btnRemoveAssociations.Size = New System.Drawing.Size(133, 23)
		Me.btnRemoveAssociations.TabIndex = 10
		Me.btnRemoveAssociations.Text = "Remove File Association"
		Me.ttOptions.SetToolTip(Me.btnRemoveAssociations, resources.GetString("btnRemoveAssociations.ToolTip"))
		Me.btnRemoveAssociations.UseVisualStyleBackColor = True
		Me.btnRemoveAssociations.Visible = False
		'
		'lbSystemInformation
		'
		Me.lbSystemInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lbSystemInformation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.lbSystemInformation.FormattingEnabled = True
		Me.lbSystemInformation.Location = New System.Drawing.Point(5, 16)
		Me.lbSystemInformation.Name = "lbSystemInformation"
		Me.lbSystemInformation.Size = New System.Drawing.Size(454, 251)
		Me.lbSystemInformation.TabIndex = 0
		Me.ttOptions.SetToolTip(Me.lbSystemInformation, "Information about your system")
		'
		'tabOptions
		'
		Me.tabOptions.Controls.Add(Me.tabMyInformationPage)
		Me.tabOptions.Controls.Add(Me.tabDataEntry)
		Me.tabOptions.Controls.Add(Me.tabFoldersPage)
		Me.tabOptions.Controls.Add(Me.tabColoursAndFonts)
		Me.tabOptions.Controls.Add(Me.tabSystemPage)
		Me.tabOptions.HotTrack = True
		Me.tabOptions.Location = New System.Drawing.Point(4, 3)
		Me.tabOptions.Multiline = True
		Me.tabOptions.Name = "tabOptions"
		Me.tabOptions.SelectedIndex = 0
		Me.hlpOptions.SetShowHelp(Me.tabOptions, True)
		Me.tabOptions.ShowToolTips = True
		Me.tabOptions.Size = New System.Drawing.Size(473, 302)
		Me.tabOptions.TabIndex = 0
		'
		'tabMyInformationPage
		'
		Me.tabMyInformationPage.Controls.Add(Me.txtFreeREG_Password)
		Me.tabMyInformationPage.Controls.Add(Me.txtFreeREG_Id)
		Me.tabMyInformationPage.Controls.Add(Me.Label9)
		Me.tabMyInformationPage.Controls.Add(Me.Label8)
		Me.tabMyInformationPage.Controls.Add(Me.Label1)
		Me.tabMyInformationPage.Controls.Add(Me.txtName)
		Me.tabMyInformationPage.Controls.Add(Me.Label2)
		Me.tabMyInformationPage.Controls.Add(Me.txtEmailAddress)
		Me.tabMyInformationPage.Controls.Add(Me.Label3)
		Me.tabMyInformationPage.Controls.Add(Me.Label4)
		Me.tabMyInformationPage.Controls.Add(Me.cbSyndicate)
		Me.tabMyInformationPage.Location = New System.Drawing.Point(4, 22)
		Me.tabMyInformationPage.Name = "tabMyInformationPage"
		Me.tabMyInformationPage.Padding = New System.Windows.Forms.Padding(3)
		Me.hlpOptions.SetShowHelp(Me.tabMyInformationPage, True)
		Me.tabMyInformationPage.Size = New System.Drawing.Size(465, 276)
		Me.tabMyInformationPage.TabIndex = 0
		Me.tabMyInformationPage.Text = "My Information"
		Me.tabMyInformationPage.UseVisualStyleBackColor = True
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(16, 208)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(53, 13)
		Me.Label9.TabIndex = 8
		Me.Label9.Text = "Password"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(16, 171)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(68, 13)
		Me.Label8.TabIndex = 6
		Me.Label8.Text = "FreeREG ID."
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(16, 60)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(35, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Name"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(16, 97)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(73, 13)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Email Address"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(16, 134)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(54, 13)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "Syndicate"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(34, 13)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(397, 26)
		Me.Label4.TabIndex = 10
		Me.Label4.Text = "The details below are required in order for you to successfully compile your reco" & _
			 "rds " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and to submit them to the FreeREG website."
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'tabDataEntry
		'
		Me.tabDataEntry.Controls.Add(Me.chkShowSplashScreen)
		Me.tabDataEntry.Controls.Add(Me.chkUseDataGrid)
		Me.tabDataEntry.Controls.Add(Me.chkEnableFiltering)
		Me.tabDataEntry.Controls.Add(Me.chkBackupFiles)
		Me.tabDataEntry.Controls.Add(Me.chkQueryDuplicate)
		Me.tabDataEntry.Controls.Add(Me.chkAutoCopyDates)
		Me.tabDataEntry.Controls.Add(Me.chkLeadingZeroOnDates)
		Me.tabDataEntry.Controls.Add(Me.chkEnableTooltips)
		Me.tabDataEntry.Controls.Add(Me.lblTooltips1)
		Me.tabDataEntry.Controls.Add(Me.nupTooltips)
		Me.tabDataEntry.Controls.Add(Me.lblTooltips2)
		Me.tabDataEntry.Controls.Add(Me.chkAutofillFields)
		Me.tabDataEntry.Controls.Add(Me.lblMRUSize)
		Me.tabDataEntry.Controls.Add(Me.mtbMRUSize)
		Me.tabDataEntry.Location = New System.Drawing.Point(4, 22)
		Me.tabDataEntry.Name = "tabDataEntry"
		Me.tabDataEntry.Padding = New System.Windows.Forms.Padding(3)
		Me.hlpOptions.SetShowHelp(Me.tabDataEntry, True)
		Me.tabDataEntry.Size = New System.Drawing.Size(465, 276)
		Me.tabDataEntry.TabIndex = 3
		Me.tabDataEntry.Text = "Data Entry"
		Me.tabDataEntry.UseVisualStyleBackColor = True
		'
		'chkEnableFiltering
		'
		Me.chkEnableFiltering.AutoSize = True
		Me.chkEnableFiltering.Location = New System.Drawing.Point(253, 100)
		Me.chkEnableFiltering.Name = "chkEnableFiltering"
		Me.chkEnableFiltering.Size = New System.Drawing.Size(136, 17)
		Me.chkEnableFiltering.TabIndex = 11
		Me.chkEnableFiltering.Text = "Enable Column Filtering"
		Me.chkEnableFiltering.UseVisualStyleBackColor = True
		Me.chkEnableFiltering.Visible = False
		'
		'lblMRUSize
		'
		Me.lblMRUSize.AutoSize = True
		Me.lblMRUSize.Location = New System.Drawing.Point(27, 125)
		Me.lblMRUSize.Name = "lblMRUSize"
		Me.lblMRUSize.Size = New System.Drawing.Size(160, 13)
		Me.lblMRUSize.TabIndex = 5
		Me.lblMRUSize.Text = "Number of entries in MRU file list"
		'
		'tabFoldersPage
		'
		Me.tabFoldersPage.Controls.Add(Me.txtOperation)
		Me.tabFoldersPage.Controls.Add(Me.lblDataFolder)
		Me.tabFoldersPage.Controls.Add(Me.txtDataFolder)
		Me.tabFoldersPage.Controls.Add(Me.btnBrowseDataFolder)
		Me.tabFoldersPage.Controls.Add(Me.lblBackupsFolder)
		Me.tabFoldersPage.Controls.Add(Me.txtBackupsFolder)
		Me.tabFoldersPage.Controls.Add(Me.btnBrowseBackupsFolder)
		Me.tabFoldersPage.Controls.Add(Me.lblImageFolder)
		Me.tabFoldersPage.Controls.Add(Me.txtImagesFolder)
		Me.tabFoldersPage.Controls.Add(Me.btnBrowseImagesFolder)
		Me.tabFoldersPage.Controls.Add(Me.lblFileOpen)
		Me.tabFoldersPage.Controls.Add(Me.btnRemoveAssociations)
		Me.tabFoldersPage.Location = New System.Drawing.Point(4, 22)
		Me.tabFoldersPage.Name = "tabFoldersPage"
		Me.tabFoldersPage.Padding = New System.Windows.Forms.Padding(3)
		Me.hlpOptions.SetShowHelp(Me.tabFoldersPage, True)
		Me.tabFoldersPage.Size = New System.Drawing.Size(465, 276)
		Me.tabFoldersPage.TabIndex = 1
		Me.tabFoldersPage.Text = "Folders"
		Me.tabFoldersPage.UseVisualStyleBackColor = True
		'
		'txtOperation
		'
		Me.txtOperation.Location = New System.Drawing.Point(27, 205)
		Me.txtOperation.Name = "txtOperation"
		Me.txtOperation.Size = New System.Drawing.Size(417, 19)
		Me.txtOperation.TabIndex = 11
		Me.txtOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblDataFolder
		'
		Me.lblDataFolder.AutoSize = True
		Me.lblDataFolder.Location = New System.Drawing.Point(23, 29)
		Me.lblDataFolder.Name = "lblDataFolder"
		Me.lblDataFolder.Size = New System.Drawing.Size(30, 13)
		Me.lblDataFolder.TabIndex = 0
		Me.lblDataFolder.Text = "Data"
		'
		'btnBrowseDataFolder
		'
		Me.btnBrowseDataFolder.AutoSize = True
		Me.btnBrowseDataFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.btnBrowseDataFolder.Location = New System.Drawing.Point(418, 24)
		Me.btnBrowseDataFolder.Name = "btnBrowseDataFolder"
		Me.btnBrowseDataFolder.Size = New System.Drawing.Size(26, 23)
		Me.btnBrowseDataFolder.TabIndex = 2
		Me.btnBrowseDataFolder.Text = "..."
		Me.btnBrowseDataFolder.UseVisualStyleBackColor = True
		'
		'lblBackupsFolder
		'
		Me.lblBackupsFolder.AutoSize = True
		Me.lblBackupsFolder.Location = New System.Drawing.Point(23, 60)
		Me.lblBackupsFolder.Name = "lblBackupsFolder"
		Me.lblBackupsFolder.Size = New System.Drawing.Size(49, 13)
		Me.lblBackupsFolder.TabIndex = 3
		Me.lblBackupsFolder.Text = "Backups"
		'
		'btnBrowseBackupsFolder
		'
		Me.btnBrowseBackupsFolder.AutoSize = True
		Me.btnBrowseBackupsFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.btnBrowseBackupsFolder.Location = New System.Drawing.Point(418, 55)
		Me.btnBrowseBackupsFolder.Name = "btnBrowseBackupsFolder"
		Me.btnBrowseBackupsFolder.Size = New System.Drawing.Size(26, 23)
		Me.btnBrowseBackupsFolder.TabIndex = 5
		Me.btnBrowseBackupsFolder.Text = "..."
		Me.btnBrowseBackupsFolder.UseVisualStyleBackColor = True
		'
		'lblImageFolder
		'
		Me.lblImageFolder.AutoSize = True
		Me.lblImageFolder.Location = New System.Drawing.Point(23, 91)
		Me.lblImageFolder.Name = "lblImageFolder"
		Me.lblImageFolder.Size = New System.Drawing.Size(41, 13)
		Me.lblImageFolder.TabIndex = 6
		Me.lblImageFolder.Text = "Images"
		'
		'txtImagesFolder
		'
		Me.txtImagesFolder.Location = New System.Drawing.Point(78, 88)
		Me.txtImagesFolder.Name = "txtImagesFolder"
		Me.txtImagesFolder.Size = New System.Drawing.Size(334, 20)
		Me.txtImagesFolder.TabIndex = 7
		'
		'btnBrowseImagesFolder
		'
		Me.btnBrowseImagesFolder.AutoSize = True
		Me.btnBrowseImagesFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.btnBrowseImagesFolder.Location = New System.Drawing.Point(418, 84)
		Me.btnBrowseImagesFolder.Name = "btnBrowseImagesFolder"
		Me.btnBrowseImagesFolder.Size = New System.Drawing.Size(26, 23)
		Me.btnBrowseImagesFolder.TabIndex = 8
		Me.btnBrowseImagesFolder.Text = "..."
		Me.btnBrowseImagesFolder.UseVisualStyleBackColor = True
		'
		'lblFileOpen
		'
		Me.lblFileOpen.AutoSize = True
		Me.lblFileOpen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFileOpen.Location = New System.Drawing.Point(40, 129)
		Me.lblFileOpen.Name = "lblFileOpen"
		Me.lblFileOpen.Size = New System.Drawing.Size(384, 52)
		Me.lblFileOpen.TabIndex = 9
		Me.lblFileOpen.Text = "The folder fields have been disabled because to alter" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "their contents whilst a fi" & _
			 "le is open could cause problems." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Close the file first, if you want to alter a" & _
			 "ny of the folder pathnames."
		Me.lblFileOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.lblFileOpen.Visible = False
		'
		'tabColoursAndFonts
		'
		Me.tabColoursAndFonts.Controls.Add(Me.Label7)
		Me.tabColoursAndFonts.Controls.Add(Me.btnCellFont)
		Me.tabColoursAndFonts.Controls.Add(Me.txtCellFont)
		Me.tabColoursAndFonts.Controls.Add(Me.btnRestoreDefaults)
		Me.tabColoursAndFonts.Controls.Add(Me.Label6)
		Me.tabColoursAndFonts.Controls.Add(Me.Label5)
		Me.tabColoursAndFonts.Controls.Add(Me.cbColourAlternate)
		Me.tabColoursAndFonts.Controls.Add(Me.cbColourNormal)
		Me.tabColoursAndFonts.Location = New System.Drawing.Point(4, 22)
		Me.tabColoursAndFonts.Name = "tabColoursAndFonts"
		Me.tabColoursAndFonts.Padding = New System.Windows.Forms.Padding(3)
		Me.hlpOptions.SetShowHelp(Me.tabColoursAndFonts, True)
		Me.tabColoursAndFonts.Size = New System.Drawing.Size(465, 276)
		Me.tabColoursAndFonts.TabIndex = 5
		Me.tabColoursAndFonts.Text = "Colours & Fonts"
		Me.tabColoursAndFonts.UseVisualStyleBackColor = True
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(203, 122)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(28, 13)
		Me.Label7.TabIndex = 7
		Me.Label7.Text = "Font"
		'
		'btnCellFont
		'
		Me.btnCellFont.AutoSize = True
		Me.btnCellFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.btnCellFont.Location = New System.Drawing.Point(424, 120)
		Me.btnCellFont.Name = "btnCellFont"
		Me.btnCellFont.Size = New System.Drawing.Size(26, 23)
		Me.btnCellFont.TabIndex = 6
		Me.btnCellFont.Text = "..."
		Me.btnCellFont.UseVisualStyleBackColor = True
		'
		'txtCellFont
		'
		Me.txtCellFont.Location = New System.Drawing.Point(268, 122)
		Me.txtCellFont.Name = "txtCellFont"
		Me.txtCellFont.Size = New System.Drawing.Size(150, 20)
		Me.txtCellFont.TabIndex = 5
		'
		'btnRestoreDefaults
		'
		Me.btnRestoreDefaults.Location = New System.Drawing.Point(268, 156)
		Me.btnRestoreDefaults.Name = "btnRestoreDefaults"
		Me.btnRestoreDefaults.Size = New System.Drawing.Size(150, 23)
		Me.btnRestoreDefaults.TabIndex = 4
		Me.btnRestoreDefaults.Text = "Restore Defaults"
		Me.btnRestoreDefaults.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(129, 90)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(102, 13)
		Me.Label6.TabIndex = 3
		Me.Label6.Text = "Alternate Cell Colour"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(137, 55)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(94, 13)
		Me.Label5.TabIndex = 2
		Me.Label5.Text = "Default Cell Colour"
		'
		'cbColourAlternate
		'
		Me.cbColourAlternate.FormattingEnabled = True
		Me.cbColourAlternate.Items.AddRange(New Object() {System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.DimGray, System.Drawing.Color.Gray, System.Drawing.Color.DarkGray, System.Drawing.Color.Silver, System.Drawing.Color.LightGray, System.Drawing.Color.Gainsboro, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Maroon, System.Drawing.Color.DarkRed, System.Drawing.Color.Red, System.Drawing.Color.Brown, System.Drawing.Color.Firebrick, System.Drawing.Color.IndianRed, System.Drawing.Color.Snow, System.Drawing.Color.LightCoral, System.Drawing.Color.RosyBrown, System.Drawing.Color.MistyRose, System.Drawing.Color.Salmon, System.Drawing.Color.Tomato, System.Drawing.Color.DarkSalmon, System.Drawing.Color.Coral, System.Drawing.Color.OrangeRed, System.Drawing.Color.LightSalmon, System.Drawing.Color.Sienna, System.Drawing.Color.SeaShell, System.Drawing.Color.Chocolate, System.Drawing.Color.SaddleBrown, System.Drawing.Color.SandyBrown, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Linen, System.Drawing.Color.Bisque, System.Drawing.Color.DarkOrange, System.Drawing.Color.BurlyWood, System.Drawing.Color.Tan, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.NavajoWhite, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.PapayaWhip, System.Drawing.Color.Moccasin, System.Drawing.Color.Orange, System.Drawing.Color.Wheat, System.Drawing.Color.OldLace, System.Drawing.Color.FloralWhite, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.Goldenrod, System.Drawing.Color.Cornsilk, System.Drawing.Color.Gold, System.Drawing.Color.Khaki, System.Drawing.Color.LemonChiffon, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.DarkKhaki, System.Drawing.Color.Beige, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Olive, System.Drawing.Color.Yellow, System.Drawing.Color.LightYellow, System.Drawing.Color.Ivory, System.Drawing.Color.OliveDrab, System.Drawing.Color.YellowGreen, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.GreenYellow, System.Drawing.Color.Chartreuse, System.Drawing.Color.LawnGreen, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.LightGreen, System.Drawing.Color.ForestGreen, System.Drawing.Color.LimeGreen, System.Drawing.Color.PaleGreen, System.Drawing.Color.DarkGreen, System.Drawing.Color.Green, System.Drawing.Color.Lime, System.Drawing.Color.Honeydew, System.Drawing.Color.SeaGreen, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.SpringGreen, System.Drawing.Color.MintCream, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.Aquamarine, System.Drawing.Color.Turquoise, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.Teal, System.Drawing.Color.DarkCyan, System.Drawing.Color.Cyan, System.Drawing.Color.Aqua, System.Drawing.Color.LightCyan, System.Drawing.Color.Azure, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.CadetBlue, System.Drawing.Color.PowderBlue, System.Drawing.Color.LightBlue, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.SkyBlue, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.SteelBlue, System.Drawing.Color.AliceBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.MidnightBlue, System.Drawing.Color.Lavender, System.Drawing.Color.Navy, System.Drawing.Color.DarkBlue, System.Drawing.Color.MediumBlue, System.Drawing.Color.Blue, System.Drawing.Color.GhostWhite, System.Drawing.Color.SlateBlue, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumPurple, System.Drawing.Color.BlueViolet, System.Drawing.Color.Indigo, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkViolet, System.Drawing.Color.MediumOrchid, System.Drawing.Color.Thistle, System.Drawing.Color.Plum, System.Drawing.Color.Violet, System.Drawing.Color.Purple, System.Drawing.Color.DarkMagenta, System.Drawing.Color.Fuchsia, System.Drawing.Color.Magenta, System.Drawing.Color.Orchid, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.DeepPink, System.Drawing.Color.HotPink, System.Drawing.Color.LavenderBlush, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.Crimson, System.Drawing.Color.Pink, System.Drawing.Color.LightPink, System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.DimGray, System.Drawing.Color.Gray, System.Drawing.Color.DarkGray, System.Drawing.Color.Silver, System.Drawing.Color.LightGray, System.Drawing.Color.Gainsboro, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Maroon, System.Drawing.Color.DarkRed, System.Drawing.Color.Red, System.Drawing.Color.Brown, System.Drawing.Color.Firebrick, System.Drawing.Color.IndianRed, System.Drawing.Color.Snow, System.Drawing.Color.LightCoral, System.Drawing.Color.RosyBrown, System.Drawing.Color.MistyRose, System.Drawing.Color.Salmon, System.Drawing.Color.Tomato, System.Drawing.Color.DarkSalmon, System.Drawing.Color.Coral, System.Drawing.Color.OrangeRed, System.Drawing.Color.LightSalmon, System.Drawing.Color.Sienna, System.Drawing.Color.SeaShell, System.Drawing.Color.Chocolate, System.Drawing.Color.SaddleBrown, System.Drawing.Color.SandyBrown, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Linen, System.Drawing.Color.Bisque, System.Drawing.Color.DarkOrange, System.Drawing.Color.BurlyWood, System.Drawing.Color.Tan, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.NavajoWhite, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.PapayaWhip, System.Drawing.Color.Moccasin, System.Drawing.Color.Orange, System.Drawing.Color.Wheat, System.Drawing.Color.OldLace, System.Drawing.Color.FloralWhite, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.Goldenrod, System.Drawing.Color.Cornsilk, System.Drawing.Color.Gold, System.Drawing.Color.Khaki, System.Drawing.Color.LemonChiffon, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.DarkKhaki, System.Drawing.Color.Beige, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Olive, System.Drawing.Color.Yellow, System.Drawing.Color.LightYellow, System.Drawing.Color.Ivory, System.Drawing.Color.OliveDrab, System.Drawing.Color.YellowGreen, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.GreenYellow, System.Drawing.Color.Chartreuse, System.Drawing.Color.LawnGreen, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.LightGreen, System.Drawing.Color.ForestGreen, System.Drawing.Color.LimeGreen, System.Drawing.Color.PaleGreen, System.Drawing.Color.DarkGreen, System.Drawing.Color.Green, System.Drawing.Color.Lime, System.Drawing.Color.Honeydew, System.Drawing.Color.SeaGreen, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.SpringGreen, System.Drawing.Color.MintCream, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.Aquamarine, System.Drawing.Color.Turquoise, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.Teal, System.Drawing.Color.DarkCyan, System.Drawing.Color.Cyan, System.Drawing.Color.Aqua, System.Drawing.Color.LightCyan, System.Drawing.Color.Azure, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.CadetBlue, System.Drawing.Color.PowderBlue, System.Drawing.Color.LightBlue, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.SkyBlue, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.SteelBlue, System.Drawing.Color.AliceBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.MidnightBlue, System.Drawing.Color.Lavender, System.Drawing.Color.Navy, System.Drawing.Color.DarkBlue, System.Drawing.Color.MediumBlue, System.Drawing.Color.Blue, System.Drawing.Color.GhostWhite, System.Drawing.Color.SlateBlue, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumPurple, System.Drawing.Color.BlueViolet, System.Drawing.Color.Indigo, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkViolet, System.Drawing.Color.MediumOrchid, System.Drawing.Color.Thistle, System.Drawing.Color.Plum, System.Drawing.Color.Violet, System.Drawing.Color.Purple, System.Drawing.Color.DarkMagenta, System.Drawing.Color.Fuchsia, System.Drawing.Color.Magenta, System.Drawing.Color.Orchid, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.DeepPink, System.Drawing.Color.HotPink, System.Drawing.Color.LavenderBlush, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.Crimson, System.Drawing.Color.Pink, System.Drawing.Color.LightPink, System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.DimGray, System.Drawing.Color.Gray, System.Drawing.Color.DarkGray, System.Drawing.Color.Silver, System.Drawing.Color.LightGray, System.Drawing.Color.Gainsboro, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Maroon, System.Drawing.Color.DarkRed, System.Drawing.Color.Red, System.Drawing.Color.Brown, System.Drawing.Color.Firebrick, System.Drawing.Color.IndianRed, System.Drawing.Color.Snow, System.Drawing.Color.LightCoral, System.Drawing.Color.RosyBrown, System.Drawing.Color.MistyRose, System.Drawing.Color.Salmon, System.Drawing.Color.Tomato, System.Drawing.Color.DarkSalmon, System.Drawing.Color.Coral, System.Drawing.Color.OrangeRed, System.Drawing.Color.LightSalmon, System.Drawing.Color.Sienna, System.Drawing.Color.SeaShell, System.Drawing.Color.Chocolate, System.Drawing.Color.SaddleBrown, System.Drawing.Color.SandyBrown, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Linen, System.Drawing.Color.Bisque, System.Drawing.Color.DarkOrange, System.Drawing.Color.BurlyWood, System.Drawing.Color.Tan, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.NavajoWhite, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.PapayaWhip, System.Drawing.Color.Moccasin, System.Drawing.Color.Orange, System.Drawing.Color.Wheat, System.Drawing.Color.OldLace, System.Drawing.Color.FloralWhite, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.Goldenrod, System.Drawing.Color.Cornsilk, System.Drawing.Color.Gold, System.Drawing.Color.Khaki, System.Drawing.Color.LemonChiffon, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.DarkKhaki, System.Drawing.Color.Beige, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Olive, System.Drawing.Color.Yellow, System.Drawing.Color.LightYellow, System.Drawing.Color.Ivory, System.Drawing.Color.OliveDrab, System.Drawing.Color.YellowGreen, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.GreenYellow, System.Drawing.Color.Chartreuse, System.Drawing.Color.LawnGreen, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.LightGreen, System.Drawing.Color.ForestGreen, System.Drawing.Color.LimeGreen, System.Drawing.Color.PaleGreen, System.Drawing.Color.DarkGreen, System.Drawing.Color.Green, System.Drawing.Color.Lime, System.Drawing.Color.Honeydew, System.Drawing.Color.SeaGreen, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.SpringGreen, System.Drawing.Color.MintCream, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.Aquamarine, System.Drawing.Color.Turquoise, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.Teal, System.Drawing.Color.DarkCyan, System.Drawing.Color.Cyan, System.Drawing.Color.Aqua, System.Drawing.Color.LightCyan, System.Drawing.Color.Azure, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.CadetBlue, System.Drawing.Color.PowderBlue, System.Drawing.Color.LightBlue, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.SkyBlue, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.SteelBlue, System.Drawing.Color.AliceBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.MidnightBlue, System.Drawing.Color.Lavender, System.Drawing.Color.Navy, System.Drawing.Color.DarkBlue, System.Drawing.Color.MediumBlue, System.Drawing.Color.Blue, System.Drawing.Color.GhostWhite, System.Drawing.Color.SlateBlue, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumPurple, System.Drawing.Color.BlueViolet, System.Drawing.Color.Indigo, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkViolet, System.Drawing.Color.MediumOrchid, System.Drawing.Color.Thistle, System.Drawing.Color.Plum, System.Drawing.Color.Violet, System.Drawing.Color.Purple, System.Drawing.Color.DarkMagenta, System.Drawing.Color.Fuchsia, System.Drawing.Color.Magenta, System.Drawing.Color.Orchid, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.DeepPink, System.Drawing.Color.HotPink, System.Drawing.Color.LavenderBlush, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.Crimson, System.Drawing.Color.Pink, System.Drawing.Color.LightPink})
		Me.cbColourAlternate.Location = New System.Drawing.Point(268, 87)
		Me.cbColourAlternate.Name = "cbColourAlternate"
		Me.cbColourAlternate.Size = New System.Drawing.Size(150, 21)
		Me.cbColourAlternate.TabIndex = 1
		'
		'cbColourNormal
		'
		Me.cbColourNormal.FormattingEnabled = True
		Me.cbColourNormal.Items.AddRange(New Object() {System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.DimGray, System.Drawing.Color.Gray, System.Drawing.Color.DarkGray, System.Drawing.Color.Silver, System.Drawing.Color.LightGray, System.Drawing.Color.Gainsboro, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Maroon, System.Drawing.Color.DarkRed, System.Drawing.Color.Red, System.Drawing.Color.Brown, System.Drawing.Color.Firebrick, System.Drawing.Color.IndianRed, System.Drawing.Color.Snow, System.Drawing.Color.LightCoral, System.Drawing.Color.RosyBrown, System.Drawing.Color.MistyRose, System.Drawing.Color.Salmon, System.Drawing.Color.Tomato, System.Drawing.Color.DarkSalmon, System.Drawing.Color.Coral, System.Drawing.Color.OrangeRed, System.Drawing.Color.LightSalmon, System.Drawing.Color.Sienna, System.Drawing.Color.SeaShell, System.Drawing.Color.Chocolate, System.Drawing.Color.SaddleBrown, System.Drawing.Color.SandyBrown, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Linen, System.Drawing.Color.Bisque, System.Drawing.Color.DarkOrange, System.Drawing.Color.BurlyWood, System.Drawing.Color.Tan, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.NavajoWhite, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.PapayaWhip, System.Drawing.Color.Moccasin, System.Drawing.Color.Orange, System.Drawing.Color.Wheat, System.Drawing.Color.OldLace, System.Drawing.Color.FloralWhite, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.Goldenrod, System.Drawing.Color.Cornsilk, System.Drawing.Color.Gold, System.Drawing.Color.Khaki, System.Drawing.Color.LemonChiffon, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.DarkKhaki, System.Drawing.Color.Beige, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Olive, System.Drawing.Color.Yellow, System.Drawing.Color.LightYellow, System.Drawing.Color.Ivory, System.Drawing.Color.OliveDrab, System.Drawing.Color.YellowGreen, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.GreenYellow, System.Drawing.Color.Chartreuse, System.Drawing.Color.LawnGreen, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.LightGreen, System.Drawing.Color.ForestGreen, System.Drawing.Color.LimeGreen, System.Drawing.Color.PaleGreen, System.Drawing.Color.DarkGreen, System.Drawing.Color.Green, System.Drawing.Color.Lime, System.Drawing.Color.Honeydew, System.Drawing.Color.SeaGreen, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.SpringGreen, System.Drawing.Color.MintCream, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.Aquamarine, System.Drawing.Color.Turquoise, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.Teal, System.Drawing.Color.DarkCyan, System.Drawing.Color.Cyan, System.Drawing.Color.Aqua, System.Drawing.Color.LightCyan, System.Drawing.Color.Azure, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.CadetBlue, System.Drawing.Color.PowderBlue, System.Drawing.Color.LightBlue, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.SkyBlue, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.SteelBlue, System.Drawing.Color.AliceBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.MidnightBlue, System.Drawing.Color.Lavender, System.Drawing.Color.Navy, System.Drawing.Color.DarkBlue, System.Drawing.Color.MediumBlue, System.Drawing.Color.Blue, System.Drawing.Color.GhostWhite, System.Drawing.Color.SlateBlue, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumPurple, System.Drawing.Color.BlueViolet, System.Drawing.Color.Indigo, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkViolet, System.Drawing.Color.MediumOrchid, System.Drawing.Color.Thistle, System.Drawing.Color.Plum, System.Drawing.Color.Violet, System.Drawing.Color.Purple, System.Drawing.Color.DarkMagenta, System.Drawing.Color.Fuchsia, System.Drawing.Color.Magenta, System.Drawing.Color.Orchid, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.DeepPink, System.Drawing.Color.HotPink, System.Drawing.Color.LavenderBlush, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.Crimson, System.Drawing.Color.Pink, System.Drawing.Color.LightPink, System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.DimGray, System.Drawing.Color.Gray, System.Drawing.Color.DarkGray, System.Drawing.Color.Silver, System.Drawing.Color.LightGray, System.Drawing.Color.Gainsboro, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Maroon, System.Drawing.Color.DarkRed, System.Drawing.Color.Red, System.Drawing.Color.Brown, System.Drawing.Color.Firebrick, System.Drawing.Color.IndianRed, System.Drawing.Color.Snow, System.Drawing.Color.LightCoral, System.Drawing.Color.RosyBrown, System.Drawing.Color.MistyRose, System.Drawing.Color.Salmon, System.Drawing.Color.Tomato, System.Drawing.Color.DarkSalmon, System.Drawing.Color.Coral, System.Drawing.Color.OrangeRed, System.Drawing.Color.LightSalmon, System.Drawing.Color.Sienna, System.Drawing.Color.SeaShell, System.Drawing.Color.Chocolate, System.Drawing.Color.SaddleBrown, System.Drawing.Color.SandyBrown, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Linen, System.Drawing.Color.Bisque, System.Drawing.Color.DarkOrange, System.Drawing.Color.BurlyWood, System.Drawing.Color.Tan, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.NavajoWhite, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.PapayaWhip, System.Drawing.Color.Moccasin, System.Drawing.Color.Orange, System.Drawing.Color.Wheat, System.Drawing.Color.OldLace, System.Drawing.Color.FloralWhite, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.Goldenrod, System.Drawing.Color.Cornsilk, System.Drawing.Color.Gold, System.Drawing.Color.Khaki, System.Drawing.Color.LemonChiffon, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.DarkKhaki, System.Drawing.Color.Beige, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Olive, System.Drawing.Color.Yellow, System.Drawing.Color.LightYellow, System.Drawing.Color.Ivory, System.Drawing.Color.OliveDrab, System.Drawing.Color.YellowGreen, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.GreenYellow, System.Drawing.Color.Chartreuse, System.Drawing.Color.LawnGreen, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.LightGreen, System.Drawing.Color.ForestGreen, System.Drawing.Color.LimeGreen, System.Drawing.Color.PaleGreen, System.Drawing.Color.DarkGreen, System.Drawing.Color.Green, System.Drawing.Color.Lime, System.Drawing.Color.Honeydew, System.Drawing.Color.SeaGreen, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.SpringGreen, System.Drawing.Color.MintCream, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.Aquamarine, System.Drawing.Color.Turquoise, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.Teal, System.Drawing.Color.DarkCyan, System.Drawing.Color.Cyan, System.Drawing.Color.Aqua, System.Drawing.Color.LightCyan, System.Drawing.Color.Azure, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.CadetBlue, System.Drawing.Color.PowderBlue, System.Drawing.Color.LightBlue, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.SkyBlue, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.SteelBlue, System.Drawing.Color.AliceBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.MidnightBlue, System.Drawing.Color.Lavender, System.Drawing.Color.Navy, System.Drawing.Color.DarkBlue, System.Drawing.Color.MediumBlue, System.Drawing.Color.Blue, System.Drawing.Color.GhostWhite, System.Drawing.Color.SlateBlue, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumPurple, System.Drawing.Color.BlueViolet, System.Drawing.Color.Indigo, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkViolet, System.Drawing.Color.MediumOrchid, System.Drawing.Color.Thistle, System.Drawing.Color.Plum, System.Drawing.Color.Violet, System.Drawing.Color.Purple, System.Drawing.Color.DarkMagenta, System.Drawing.Color.Fuchsia, System.Drawing.Color.Magenta, System.Drawing.Color.Orchid, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.DeepPink, System.Drawing.Color.HotPink, System.Drawing.Color.LavenderBlush, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.Crimson, System.Drawing.Color.Pink, System.Drawing.Color.LightPink, System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.DimGray, System.Drawing.Color.Gray, System.Drawing.Color.DarkGray, System.Drawing.Color.Silver, System.Drawing.Color.LightGray, System.Drawing.Color.Gainsboro, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Maroon, System.Drawing.Color.DarkRed, System.Drawing.Color.Red, System.Drawing.Color.Brown, System.Drawing.Color.Firebrick, System.Drawing.Color.IndianRed, System.Drawing.Color.Snow, System.Drawing.Color.LightCoral, System.Drawing.Color.RosyBrown, System.Drawing.Color.MistyRose, System.Drawing.Color.Salmon, System.Drawing.Color.Tomato, System.Drawing.Color.DarkSalmon, System.Drawing.Color.Coral, System.Drawing.Color.OrangeRed, System.Drawing.Color.LightSalmon, System.Drawing.Color.Sienna, System.Drawing.Color.SeaShell, System.Drawing.Color.Chocolate, System.Drawing.Color.SaddleBrown, System.Drawing.Color.SandyBrown, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Linen, System.Drawing.Color.Bisque, System.Drawing.Color.DarkOrange, System.Drawing.Color.BurlyWood, System.Drawing.Color.Tan, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.NavajoWhite, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.PapayaWhip, System.Drawing.Color.Moccasin, System.Drawing.Color.Orange, System.Drawing.Color.Wheat, System.Drawing.Color.OldLace, System.Drawing.Color.FloralWhite, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.Goldenrod, System.Drawing.Color.Cornsilk, System.Drawing.Color.Gold, System.Drawing.Color.Khaki, System.Drawing.Color.LemonChiffon, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.DarkKhaki, System.Drawing.Color.Beige, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Olive, System.Drawing.Color.Yellow, System.Drawing.Color.LightYellow, System.Drawing.Color.Ivory, System.Drawing.Color.OliveDrab, System.Drawing.Color.YellowGreen, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.GreenYellow, System.Drawing.Color.Chartreuse, System.Drawing.Color.LawnGreen, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.LightGreen, System.Drawing.Color.ForestGreen, System.Drawing.Color.LimeGreen, System.Drawing.Color.PaleGreen, System.Drawing.Color.DarkGreen, System.Drawing.Color.Green, System.Drawing.Color.Lime, System.Drawing.Color.Honeydew, System.Drawing.Color.SeaGreen, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.SpringGreen, System.Drawing.Color.MintCream, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.Aquamarine, System.Drawing.Color.Turquoise, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.Teal, System.Drawing.Color.DarkCyan, System.Drawing.Color.Cyan, System.Drawing.Color.Aqua, System.Drawing.Color.LightCyan, System.Drawing.Color.Azure, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.CadetBlue, System.Drawing.Color.PowderBlue, System.Drawing.Color.LightBlue, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.SkyBlue, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.SteelBlue, System.Drawing.Color.AliceBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.MidnightBlue, System.Drawing.Color.Lavender, System.Drawing.Color.Navy, System.Drawing.Color.DarkBlue, System.Drawing.Color.MediumBlue, System.Drawing.Color.Blue, System.Drawing.Color.GhostWhite, System.Drawing.Color.SlateBlue, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumPurple, System.Drawing.Color.BlueViolet, System.Drawing.Color.Indigo, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkViolet, System.Drawing.Color.MediumOrchid, System.Drawing.Color.Thistle, System.Drawing.Color.Plum, System.Drawing.Color.Violet, System.Drawing.Color.Purple, System.Drawing.Color.DarkMagenta, System.Drawing.Color.Fuchsia, System.Drawing.Color.Magenta, System.Drawing.Color.Orchid, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.DeepPink, System.Drawing.Color.HotPink, System.Drawing.Color.LavenderBlush, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.Crimson, System.Drawing.Color.Pink, System.Drawing.Color.LightPink})
		Me.cbColourNormal.Location = New System.Drawing.Point(268, 52)
		Me.cbColourNormal.Name = "cbColourNormal"
		Me.cbColourNormal.Size = New System.Drawing.Size(150, 21)
		Me.cbColourNormal.TabIndex = 0
		'
		'tabSystemPage
		'
		Me.tabSystemPage.Controls.Add(Me.lbSystemInformation)
		Me.tabSystemPage.Location = New System.Drawing.Point(4, 22)
		Me.tabSystemPage.Name = "tabSystemPage"
		Me.tabSystemPage.Size = New System.Drawing.Size(465, 276)
		Me.tabSystemPage.TabIndex = 4
		Me.tabSystemPage.Text = "System Information"
		Me.tabSystemPage.UseVisualStyleBackColor = True
		'
		'cstmDataFolder
		'
		Me.cstmDataFolder.ControlToValidate = Me.txtDataFolder
		Me.cstmDataFolder.ErrorMessage = "Path does not exist"
		Me.cstmDataFolder.Icon = CType(resources.GetObject("cstmDataFolder.Icon"), System.Drawing.Icon)
		Me.cstmDataFolder.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		'
		'cstmBackupsFolder
		'
		Me.cstmBackupsFolder.ControlToValidate = Me.txtBackupsFolder
		Me.cstmBackupsFolder.ErrorMessage = "Path does not exist"
		Me.cstmBackupsFolder.Icon = CType(resources.GetObject("cstmBackupsFolder.Icon"), System.Drawing.Icon)
		Me.cstmBackupsFolder.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		'
		'cstmImagesFolder
		'
		Me.cstmImagesFolder.ControlToValidate = Me.txtImagesFolder
		Me.cstmImagesFolder.ErrorMessage = "Path does not exist"
		Me.cstmImagesFolder.Icon = CType(resources.GetObject("cstmImagesFolder.Icon"), System.Drawing.Icon)
		Me.cstmImagesFolder.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		'
		'fdDefaultCellFont
		'
		Me.fdDefaultCellFont.FontMustExist = True
		Me.fdDefaultCellFont.ShowHelp = True
		'
		'reqName
		'
		Me.reqName.ControlToValidate = Me.txtName
		Me.reqName.ErrorMessage = "You must enter your name"
		Me.reqName.Icon = CType(resources.GetObject("reqName.Icon"), System.Drawing.Icon)
		Me.reqName.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		Me.reqName.ValidateOnLoad = True
		'
		'reqEmailAddress
		'
		Me.reqEmailAddress.ControlToValidate = Me.txtEmailAddress
		Me.reqEmailAddress.ErrorMessage = "An email address must be entered"
		Me.reqEmailAddress.Icon = CType(resources.GetObject("reqEmailAddress.Icon"), System.Drawing.Icon)
		Me.reqEmailAddress.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		Me.reqEmailAddress.ValidateOnLoad = True
		'
		'regexEmailAddress
		'
		Me.regexEmailAddress.ControlToValidate = Me.txtEmailAddress
		Me.regexEmailAddress.ErrorMessage = "The email address that has been entered is invalid"
		Me.regexEmailAddress.Icon = CType(resources.GetObject("regexEmailAddress.Icon"), System.Drawing.Icon)
		Me.regexEmailAddress.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		Me.regexEmailAddress.ValidateOnLoad = True
		Me.regexEmailAddress.ValidationExpression = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3} \.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" & _
			 ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)"
		'
		'regexName
		'
		Me.regexName.ControlToValidate = Me.txtName
		Me.regexName.ErrorMessage = "Your name can only contain letters and spaces"
		Me.regexName.Icon = CType(resources.GetObject("regexName.Icon"), System.Drawing.Icon)
		Me.regexName.IconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
		Me.regexName.ValidateOnLoad = True
		Me.regexName.ValidationExpression = "^[a-zA-Z\s-]+$"
		'
		'txtFreeREG_Password
		'
		Me.txtFreeREG_Password.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WinREG.My.MySettings.Default, "MyUserPassword", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.txtFreeREG_Password.Location = New System.Drawing.Point(107, 205)
		Me.txtFreeREG_Password.Name = "txtFreeREG_Password"
		Me.txtFreeREG_Password.Size = New System.Drawing.Size(100, 20)
		Me.txtFreeREG_Password.TabIndex = 12
		Me.txtFreeREG_Password.Text = Global.WinREG.My.MySettings.Default.MyUserPassword
		Me.ttOptions.SetToolTip(Me.txtFreeREG_Password, resources.GetString("txtFreeREG_Password.ToolTip"))
		'
		'txtFreeREG_Id
		'
		Me.txtFreeREG_Id.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WinREG.My.MySettings.Default, "MyUserName", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.txtFreeREG_Id.Location = New System.Drawing.Point(107, 168)
		Me.txtFreeREG_Id.Name = "txtFreeREG_Id"
		Me.txtFreeREG_Id.Size = New System.Drawing.Size(100, 20)
		Me.txtFreeREG_Id.TabIndex = 11
		Me.txtFreeREG_Id.Text = Global.WinREG.My.MySettings.Default.MyUserName
		Me.ttOptions.SetToolTip(Me.txtFreeREG_Id, resources.GetString("txtFreeREG_Id.ToolTip"))
		'
		'txtName
		'
		Me.txtName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WinREG.My.MySettings.Default, "Name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.txtName.Location = New System.Drawing.Point(107, 57)
		Me.txtName.Name = "txtName"
		Me.txtName.Size = New System.Drawing.Size(185, 20)
		Me.txtName.TabIndex = 1
		Me.txtName.Text = Global.WinREG.My.MySettings.Default.Name
		Me.txtName.TextCase = CaseText.CaseText.CaseType.ChristianNames
		Me.ttOptions.SetToolTip(Me.txtName, resources.GetString("txtName.ToolTip"))
		'
		'txtEmailAddress
		'
		Me.txtEmailAddress.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WinREG.My.MySettings.Default, "EmailAddress", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.txtEmailAddress.Location = New System.Drawing.Point(107, 94)
		Me.txtEmailAddress.Name = "txtEmailAddress"
		Me.txtEmailAddress.Size = New System.Drawing.Size(185, 20)
		Me.txtEmailAddress.TabIndex = 3
		Me.txtEmailAddress.Text = Global.WinREG.My.MySettings.Default.EmailAddress
		Me.txtEmailAddress.TextCase = CaseText.CaseText.CaseType.Normal
		Me.ttOptions.SetToolTip(Me.txtEmailAddress, resources.GetString("txtEmailAddress.ToolTip"))
		'
		'chkShowSplashScreen
		'
		Me.chkShowSplashScreen.AutoSize = True
		Me.chkShowSplashScreen.Checked = Global.WinREG.My.MySettings.Default.ShowSplashScreen
		Me.chkShowSplashScreen.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkShowSplashScreen.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.WinREG.My.MySettings.Default, "ShowSplashScreen", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.chkShowSplashScreen.Location = New System.Drawing.Point(253, 148)
		Me.chkShowSplashScreen.Name = "chkShowSplashScreen"
		Me.chkShowSplashScreen.Size = New System.Drawing.Size(172, 17)
		Me.chkShowSplashScreen.TabIndex = 13
		Me.chkShowSplashScreen.Text = "Show Splash Screen at startup"
		Me.chkShowSplashScreen.UseVisualStyleBackColor = True
		Me.chkShowSplashScreen.Visible = False
		'
		'chkUseDataGrid
		'
		Me.chkUseDataGrid.AutoSize = True
		Me.chkUseDataGrid.Checked = Global.WinREG.My.MySettings.Default.UseDataGrid
		Me.chkUseDataGrid.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkUseDataGrid.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.WinREG.My.MySettings.Default, "UseDataGrid", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.chkUseDataGrid.Location = New System.Drawing.Point(253, 124)
		Me.chkUseDataGrid.Name = "chkUseDataGrid"
		Me.chkUseDataGrid.Size = New System.Drawing.Size(73, 17)
		Me.chkUseDataGrid.TabIndex = 12
		Me.chkUseDataGrid.Text = "Use Grid?"
		Me.chkUseDataGrid.UseVisualStyleBackColor = True
		'
		'chkBackupFiles
		'
		Me.chkBackupFiles.AutoSize = True
		Me.chkBackupFiles.Checked = Global.WinREG.My.MySettings.Default.MyCreateBackups
		Me.chkBackupFiles.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkBackupFiles.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.WinREG.My.MySettings.Default, "MyCreateBackups", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.chkBackupFiles.Location = New System.Drawing.Point(30, 100)
		Me.chkBackupFiles.Name = "chkBackupFiles"
		Me.chkBackupFiles.Size = New System.Drawing.Size(200, 17)
		Me.chkBackupFiles.TabIndex = 10
		Me.chkBackupFiles.Text = "Create backups of transcription files?"
		Me.chkBackupFiles.UseVisualStyleBackColor = True
		'
		'chkQueryDuplicate
		'
		Me.chkQueryDuplicate.AutoSize = True
		Me.chkQueryDuplicate.Checked = Global.WinREG.My.MySettings.Default.ConfirmRecordDuplication
		Me.chkQueryDuplicate.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkQueryDuplicate.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.WinREG.My.MySettings.Default, "ConfirmRecordDuplication", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.chkQueryDuplicate.Location = New System.Drawing.Point(253, 50)
		Me.chkQueryDuplicate.Name = "chkQueryDuplicate"
		Me.chkQueryDuplicate.Size = New System.Drawing.Size(165, 17)
		Me.chkQueryDuplicate.TabIndex = 9
		Me.chkQueryDuplicate.Text = "Confirm duplication of records"
		Me.ttOptions.SetToolTip(Me.chkQueryDuplicate, "Turn this option on if, when creating a new" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "record from an existing one, you wan" & _
				  "t the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "program to notify you of the action. This can" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "help prevent the inadveren" & _
				  "t duplication of records.")
		Me.chkQueryDuplicate.UseVisualStyleBackColor = True
		'
		'chkAutoCopyDates
		'
		Me.chkAutoCopyDates.AutoSize = True
		Me.chkAutoCopyDates.Checked = Global.WinREG.My.MySettings.Default.AutoCopyDates
		Me.chkAutoCopyDates.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkAutoCopyDates.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.WinREG.My.MySettings.Default, "AutoCopyDates", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.chkAutoCopyDates.Location = New System.Drawing.Point(253, 75)
		Me.chkAutoCopyDates.Name = "chkAutoCopyDates"
		Me.chkAutoCopyDates.Size = New System.Drawing.Size(165, 17)
		Me.chkAutoCopyDates.TabIndex = 8
		Me.chkAutoCopyDates.Text = "Enable AutoCopying of Dates"
		Me.ttOptions.SetToolTip(Me.chkAutoCopyDates, resources.GetString("chkAutoCopyDates.ToolTip"))
		Me.chkAutoCopyDates.UseVisualStyleBackColor = True
		'
		'chkLeadingZeroOnDates
		'
		Me.chkLeadingZeroOnDates.AutoSize = True
		Me.chkLeadingZeroOnDates.Checked = Global.WinREG.My.MySettings.Default.MyLeadingZeroOnDates
		Me.chkLeadingZeroOnDates.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkLeadingZeroOnDates.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.WinREG.My.MySettings.Default, "MyLeadingZeroOnDates", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.chkLeadingZeroOnDates.Location = New System.Drawing.Point(30, 75)
		Me.chkLeadingZeroOnDates.Name = "chkLeadingZeroOnDates"
		Me.chkLeadingZeroOnDates.Size = New System.Drawing.Size(169, 17)
		Me.chkLeadingZeroOnDates.TabIndex = 7
		Me.chkLeadingZeroOnDates.Text = "Format dates with leading zero"
		Me.ttOptions.SetToolTip(Me.chkLeadingZeroOnDates, resources.GetString("chkLeadingZeroOnDates.ToolTip"))
		Me.chkLeadingZeroOnDates.UseVisualStyleBackColor = True
		'
		'chkEnableTooltips
		'
		Me.chkEnableTooltips.AutoSize = True
		Me.chkEnableTooltips.Checked = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		Me.chkEnableTooltips.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.WinREG.My.MySettings.Default, "MyDisplayTooltips", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.chkEnableTooltips.Location = New System.Drawing.Point(30, 25)
		Me.chkEnableTooltips.Name = "chkEnableTooltips"
		Me.chkEnableTooltips.Size = New System.Drawing.Size(160, 17)
		Me.chkEnableTooltips.TabIndex = 0
		Me.chkEnableTooltips.Text = "Enable the display of tooltips"
		Me.ttOptions.SetToolTip(Me.chkEnableTooltips, resources.GetString("chkEnableTooltips.ToolTip"))
		Me.chkEnableTooltips.UseVisualStyleBackColor = True
		'
		'lblTooltips1
		'
		Me.lblTooltips1.AutoSize = True
		Me.lblTooltips1.DataBindings.Add(New System.Windows.Forms.Binding("Visible", Global.WinREG.My.MySettings.Default, "MyDisplayTooltips", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.lblTooltips1.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Global.WinREG.My.MySettings.Default, "MyDisplayTooltips", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.lblTooltips1.Enabled = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		Me.lblTooltips1.Location = New System.Drawing.Point(250, 26)
		Me.lblTooltips1.Name = "lblTooltips1"
		Me.lblTooltips1.Size = New System.Drawing.Size(63, 13)
		Me.lblTooltips1.TabIndex = 1
		Me.lblTooltips1.Text = "Display time"
		Me.lblTooltips1.Visible = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		'
		'nupTooltips
		'
		Me.nupTooltips.DataBindings.Add(New System.Windows.Forms.Binding("Visible", Global.WinREG.My.MySettings.Default, "MyDisplayTooltips", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.nupTooltips.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Global.WinREG.My.MySettings.Default, "MyDisplayTooltips", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.nupTooltips.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.WinREG.My.MySettings.Default, "TooltipsDisplayPeriod", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.nupTooltips.Enabled = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		Me.nupTooltips.Location = New System.Drawing.Point(316, 24)
		Me.nupTooltips.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
		Me.nupTooltips.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
		Me.nupTooltips.Name = "nupTooltips"
		Me.nupTooltips.ReadOnly = True
		Me.nupTooltips.Size = New System.Drawing.Size(61, 20)
		Me.nupTooltips.TabIndex = 2
		Me.nupTooltips.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.ttOptions.SetToolTip(Me.nupTooltips, resources.GetString("nupTooltips.ToolTip"))
		Me.nupTooltips.Value = Global.WinREG.My.MySettings.Default.TooltipsDisplayPeriod
		Me.nupTooltips.Visible = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		'
		'lblTooltips2
		'
		Me.lblTooltips2.AutoSize = True
		Me.lblTooltips2.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Global.WinREG.My.MySettings.Default, "MyDisplayTooltips", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.lblTooltips2.DataBindings.Add(New System.Windows.Forms.Binding("Visible", Global.WinREG.My.MySettings.Default, "MyDisplayTooltips", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.lblTooltips2.Enabled = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		Me.lblTooltips2.Location = New System.Drawing.Point(389, 26)
		Me.lblTooltips2.Name = "lblTooltips2"
		Me.lblTooltips2.Size = New System.Drawing.Size(47, 13)
		Me.lblTooltips2.TabIndex = 3
		Me.lblTooltips2.Text = "seconds"
		Me.lblTooltips2.Visible = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		'
		'chkAutofillFields
		'
		Me.chkAutofillFields.AutoSize = True
		Me.chkAutofillFields.Checked = Global.WinREG.My.MySettings.Default.MyAutofillFields
		Me.chkAutofillFields.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkAutofillFields.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.WinREG.My.MySettings.Default, "MyAutofillFields", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.chkAutofillFields.Location = New System.Drawing.Point(30, 50)
		Me.chkAutofillFields.Name = "chkAutofillFields"
		Me.chkAutofillFields.Size = New System.Drawing.Size(135, 17)
		Me.chkAutofillFields.TabIndex = 4
		Me.chkAutofillFields.Text = "Enable Autocompletion"
		Me.ttOptions.SetToolTip(Me.chkAutofillFields, resources.GetString("chkAutofillFields.ToolTip"))
		Me.chkAutofillFields.UseVisualStyleBackColor = True
		'
		'hlpOptions
		'
		Me.hlpOptions.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'dlgOptions
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(482, 352)
		Me.Controls.Add(Me.tabOptions)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.HelpButton = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgOptions"
		Me.hlpOptions.SetShowHelp(Me, True)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "User & Program Options"
		Me.TableLayoutPanel1.ResumeLayout(False)
		CType(Me.reqDataFolder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.reqBackupsFolder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ValidatorOptions, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tabOptions.ResumeLayout(False)
		Me.tabMyInformationPage.ResumeLayout(False)
		Me.tabMyInformationPage.PerformLayout()
		Me.tabDataEntry.ResumeLayout(False)
		Me.tabDataEntry.PerformLayout()
		Me.tabFoldersPage.ResumeLayout(False)
		Me.tabFoldersPage.PerformLayout()
		Me.tabColoursAndFonts.ResumeLayout(False)
		Me.tabColoursAndFonts.PerformLayout()
		Me.tabSystemPage.ResumeLayout(False)
		CType(Me.cstmDataFolder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cstmBackupsFolder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cstmImagesFolder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.reqName, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.reqEmailAddress, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.regexEmailAddress, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.regexName, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.nupTooltips, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents tabOptions As System.Windows.Forms.TabControl
	Friend WithEvents tabMyInformationPage As System.Windows.Forms.TabPage
	Friend WithEvents tabFoldersPage As System.Windows.Forms.TabPage
	Friend WithEvents cbSyndicate As System.Windows.Forms.ComboBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents reqName As CustomValidation.RequiredFieldValidator
	Friend WithEvents reqEmailAddress As CustomValidation.RequiredFieldValidator
	Friend WithEvents regexEmailAddress As CustomValidation.RegularExpressionValidator
	Friend WithEvents txtName As CaseText.CaseText
	Friend WithEvents btnBrowseBackupsFolder As System.Windows.Forms.Button
	Friend WithEvents btnBrowseDataFolder As System.Windows.Forms.Button
	Friend WithEvents txtDataFolder As System.Windows.Forms.TextBox
	Friend WithEvents txtBackupsFolder As System.Windows.Forms.TextBox
	Friend WithEvents lblBackupsFolder As System.Windows.Forms.Label
	Friend WithEvents lblDataFolder As System.Windows.Forms.Label
	Friend WithEvents reqDataFolder As CustomValidation.RequiredFieldValidator
	Friend WithEvents reqBackupsFolder As CustomValidation.RequiredFieldValidator
	Friend WithEvents ValidatorOptions As CustomValidation.FormValidator
	Friend WithEvents summaryOptions As CustomValidation.ValidationSummary
	Friend WithEvents fbdFolderBrowser As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents ttOptions As System.Windows.Forms.ToolTip
	Friend WithEvents txtImagesFolder As System.Windows.Forms.TextBox
	Friend WithEvents lblImageFolder As System.Windows.Forms.Label
	Friend WithEvents btnBrowseImagesFolder As System.Windows.Forms.Button
	Friend WithEvents tabDataEntry As System.Windows.Forms.TabPage
	Friend WithEvents txtEmailAddress As CaseText.CaseText
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents chkEnableTooltips As System.Windows.Forms.CheckBox
	Friend WithEvents nupTooltips As System.Windows.Forms.NumericUpDown
	Friend WithEvents lblTooltips2 As System.Windows.Forms.Label
	Friend WithEvents lblTooltips1 As System.Windows.Forms.Label
	Friend WithEvents chkAutofillFields As System.Windows.Forms.CheckBox
	Friend WithEvents hlpOptions As System.Windows.Forms.HelpProvider
	Friend WithEvents mtbMRUSize As System.Windows.Forms.MaskedTextBox
	Friend WithEvents lblMRUSize As System.Windows.Forms.Label
	Friend WithEvents cstmDataFolder As CustomValidation.CustomValidator
	Friend WithEvents cstmBackupsFolder As CustomValidation.CustomValidator
	Friend WithEvents cstmImagesFolder As CustomValidation.CustomValidator
	Friend WithEvents lblFileOpen As System.Windows.Forms.Label
	Friend WithEvents tabSystemPage As System.Windows.Forms.TabPage
	Friend WithEvents lbSystemInformation As System.Windows.Forms.ListBox
	Friend WithEvents btnRemoveAssociations As System.Windows.Forms.Button
	Friend WithEvents chkLeadingZeroOnDates As System.Windows.Forms.CheckBox
	Friend WithEvents tabColoursAndFonts As System.Windows.Forms.TabPage
	Friend WithEvents cbColourNormal As ColorComboBox.ColorComboBox
	Friend WithEvents cbColourAlternate As ColorComboBox.ColorComboBox
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents btnRestoreDefaults As System.Windows.Forms.Button
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents btnCellFont As System.Windows.Forms.Button
	Friend WithEvents txtCellFont As System.Windows.Forms.TextBox
	Friend WithEvents fdDefaultCellFont As System.Windows.Forms.FontDialog
	Friend WithEvents chkAutoCopyDates As System.Windows.Forms.CheckBox
	Friend WithEvents chkQueryDuplicate As System.Windows.Forms.CheckBox
	Friend WithEvents regexName As CustomValidation.RegularExpressionValidator
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents txtFreeREG_Password As System.Windows.Forms.TextBox
	Friend WithEvents txtFreeREG_Id As System.Windows.Forms.TextBox
	Friend WithEvents txtOperation As System.Windows.Forms.Label
	Friend WithEvents chkBackupFiles As System.Windows.Forms.CheckBox
	Friend WithEvents chkEnableFiltering As System.Windows.Forms.CheckBox
	Friend WithEvents chkUseDataGrid As System.Windows.Forms.CheckBox
	Friend WithEvents chkShowSplashScreen As System.Windows.Forms.CheckBox

End Class
