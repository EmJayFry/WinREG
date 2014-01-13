<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDateHelper
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgDateHelper))
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.OK_Button = New System.Windows.Forms.Button
		Me.txtDateReturned = New System.Windows.Forms.TextBox
		Me.lblDateReturned = New System.Windows.Forms.Label
		Me.chkDateMissing = New System.Windows.Forms.CheckBox
		Me.chkDateUnreadable = New System.Windows.Forms.CheckBox
		Me.grpDateComponents = New System.Windows.Forms.GroupBox
		Me.grpOptions = New System.Windows.Forms.GroupBox
		Me.chkYearUnreadable = New System.Windows.Forms.CheckBox
		Me.chkMonthUnreadable = New System.Windows.Forms.CheckBox
		Me.chkMonthMissing = New System.Windows.Forms.CheckBox
		Me.chkDayUnreadable = New System.Windows.Forms.CheckBox
		Me.chkDayMissing = New System.Windows.Forms.CheckBox
		Me.txtYear = New RegExTextBox
		Me.txtMonth = New RegExTextBox
		Me.txtDay = New RegExTextBox
		Me.lblYear = New System.Windows.Forms.Label
		Me.lblMonth = New System.Windows.Forms.Label
		Me.lblDay = New System.Windows.Forms.Label
		Me.dpDate = New System.Windows.Forms.DateTimePicker
		Me.errDateHelper = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.hlpDateHelper = New System.Windows.Forms.HelpProvider
		Me.ttDateHelper = New System.Windows.Forms.ToolTip(Me.components)
		Me.grpDateComponents.SuspendLayout()
		Me.grpOptions.SuspendLayout()
		CType(Me.errDateHelper, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Cancel_Button.CausesValidation = False
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(327, 158)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(49, 23)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Cancel"
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.OK_Button.Location = New System.Drawing.Point(273, 158)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(49, 23)
		Me.OK_Button.TabIndex = 0
		Me.OK_Button.Text = "OK"
		'
		'txtDateReturned
		'
		Me.txtDateReturned.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.txtDateReturned.BackColor = System.Drawing.SystemColors.Window
		Me.txtDateReturned.CausesValidation = False
		Me.txtDateReturned.Location = New System.Drawing.Point(121, 160)
		Me.txtDateReturned.Name = "txtDateReturned"
		Me.txtDateReturned.ReadOnly = True
		Me.txtDateReturned.Size = New System.Drawing.Size(100, 21)
		Me.txtDateReturned.TabIndex = 2
		'
		'lblDateReturned
		'
		Me.lblDateReturned.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblDateReturned.AutoSize = True
		Me.lblDateReturned.Location = New System.Drawing.Point(12, 163)
		Me.lblDateReturned.Name = "lblDateReturned"
		Me.lblDateReturned.Size = New System.Drawing.Size(103, 13)
		Me.lblDateReturned.TabIndex = 3
		Me.lblDateReturned.Text = "Date to be returned"
		'
		'chkDateMissing
		'
		Me.chkDateMissing.AutoSize = True
		Me.chkDateMissing.Location = New System.Drawing.Point(15, 11)
		Me.chkDateMissing.Name = "chkDateMissing"
		Me.chkDateMissing.Size = New System.Drawing.Size(96, 17)
		Me.chkDateMissing.TabIndex = 4
		Me.chkDateMissing.Text = "Date is missing"
		Me.chkDateMissing.UseVisualStyleBackColor = True
		'
		'chkDateUnreadable
		'
		Me.chkDateUnreadable.AutoSize = True
		Me.chkDateUnreadable.Location = New System.Drawing.Point(121, 11)
		Me.chkDateUnreadable.Name = "chkDateUnreadable"
		Me.chkDateUnreadable.Size = New System.Drawing.Size(116, 17)
		Me.chkDateUnreadable.TabIndex = 5
		Me.chkDateUnreadable.Text = "Date is unreadable"
		Me.chkDateUnreadable.UseVisualStyleBackColor = True
		'
		'grpDateComponents
		'
		Me.grpDateComponents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			 Or System.Windows.Forms.AnchorStyles.Left) _
			 Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.grpDateComponents.Controls.Add(Me.grpOptions)
		Me.grpDateComponents.Controls.Add(Me.txtYear)
		Me.grpDateComponents.Controls.Add(Me.txtMonth)
		Me.grpDateComponents.Controls.Add(Me.txtDay)
		Me.grpDateComponents.Controls.Add(Me.lblYear)
		Me.grpDateComponents.Controls.Add(Me.lblMonth)
		Me.grpDateComponents.Controls.Add(Me.lblDay)
		Me.grpDateComponents.Location = New System.Drawing.Point(15, 34)
		Me.grpDateComponents.Name = "grpDateComponents"
		Me.grpDateComponents.Size = New System.Drawing.Size(368, 116)
		Me.grpDateComponents.TabIndex = 6
		Me.grpDateComponents.TabStop = False
		Me.grpDateComponents.Text = "Date components"
		'
		'grpOptions
		'
		Me.grpOptions.Controls.Add(Me.chkYearUnreadable)
		Me.grpOptions.Controls.Add(Me.chkMonthUnreadable)
		Me.grpOptions.Controls.Add(Me.chkMonthMissing)
		Me.grpOptions.Controls.Add(Me.chkDayUnreadable)
		Me.grpOptions.Controls.Add(Me.chkDayMissing)
		Me.grpOptions.Location = New System.Drawing.Point(127, 13)
		Me.grpOptions.Name = "grpOptions"
		Me.grpOptions.Size = New System.Drawing.Size(226, 90)
		Me.grpOptions.TabIndex = 6
		Me.grpOptions.TabStop = False
		Me.grpOptions.Text = "Options"
		'
		'chkYearUnreadable
		'
		Me.chkYearUnreadable.AutoSize = True
		Me.chkYearUnreadable.Location = New System.Drawing.Point(6, 65)
		Me.chkYearUnreadable.Name = "chkYearUnreadable"
		Me.chkYearUnreadable.Size = New System.Drawing.Size(143, 17)
		Me.chkYearUnreadable.TabIndex = 4
		Me.chkYearUnreadable.Text = "Year missing/unreadable"
		Me.chkYearUnreadable.UseVisualStyleBackColor = True
		'
		'chkMonthUnreadable
		'
		Me.chkMonthUnreadable.AutoSize = True
		Me.chkMonthUnreadable.Location = New System.Drawing.Point(105, 40)
		Me.chkMonthUnreadable.Name = "chkMonthUnreadable"
		Me.chkMonthUnreadable.Size = New System.Drawing.Size(113, 17)
		Me.chkMonthUnreadable.TabIndex = 3
		Me.chkMonthUnreadable.Text = "Month unreadable"
		Me.chkMonthUnreadable.UseVisualStyleBackColor = True
		'
		'chkMonthMissing
		'
		Me.chkMonthMissing.AutoSize = True
		Me.chkMonthMissing.Location = New System.Drawing.Point(6, 40)
		Me.chkMonthMissing.Name = "chkMonthMissing"
		Me.chkMonthMissing.Size = New System.Drawing.Size(93, 17)
		Me.chkMonthMissing.TabIndex = 2
		Me.chkMonthMissing.Text = "Month missing"
		Me.chkMonthMissing.UseVisualStyleBackColor = True
		'
		'chkDayUnreadable
		'
		Me.chkDayUnreadable.AutoSize = True
		Me.chkDayUnreadable.Location = New System.Drawing.Point(105, 15)
		Me.chkDayUnreadable.Name = "chkDayUnreadable"
		Me.chkDayUnreadable.Size = New System.Drawing.Size(102, 17)
		Me.chkDayUnreadable.TabIndex = 1
		Me.chkDayUnreadable.Text = "Day unreadable"
		Me.chkDayUnreadable.UseVisualStyleBackColor = True
		'
		'chkDayMissing
		'
		Me.chkDayMissing.AutoSize = True
		Me.chkDayMissing.Location = New System.Drawing.Point(6, 15)
		Me.chkDayMissing.Name = "chkDayMissing"
		Me.chkDayMissing.Size = New System.Drawing.Size(82, 17)
		Me.chkDayMissing.TabIndex = 0
		Me.chkDayMissing.Text = "Day missing"
		Me.chkDayMissing.UseVisualStyleBackColor = True
		'
		'txtYear
		'
		Me.txtYear.ErrorColor = System.Drawing.Color.Red
		Me.txtYear.ErrorMessage = Nothing
		Me.txtYear.Location = New System.Drawing.Point(57, 76)
		Me.txtYear.MaxLength = 4
		Me.txtYear.Name = "txtYear"
		Me.txtYear.Size = New System.Drawing.Size(50, 21)
		Me.txtYear.TabIndex = 5
		Me.txtYear.ValidationExpression = "^(?<Year>\*|(?:_|1)(?:_|[5-9])(?:_|[0-9])(?:_|[0-9]))$"
		'
		'txtMonth
		'
		Me.txtMonth.AutoCompleteCustomSource.AddRange(New String() {"*", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"})
		Me.txtMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.txtMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
		Me.txtMonth.ErrorColor = System.Drawing.Color.Red
		Me.txtMonth.ErrorMessage = Nothing
		Me.txtMonth.Location = New System.Drawing.Point(57, 50)
		Me.txtMonth.MaxLength = 3
		Me.txtMonth.Name = "txtMonth"
		Me.txtMonth.Size = New System.Drawing.Size(50, 21)
		Me.txtMonth.TabIndex = 4
		Me.txtMonth.ValidationExpression = resources.GetString("txtMonth.ValidationExpression")
		'
		'txtDay
		'
		Me.txtDay.AutoCompleteCustomSource.AddRange(New String() {"*", "_0", "_1", "_2", "_3", "_4", "_5", "_6", "_7", "_8", "_9", "1_", "2_", "3_", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "01", "02", "03", "04", "05", "06", "07", "08", "09"})
		Me.txtDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.txtDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
		Me.txtDay.ErrorColor = System.Drawing.Color.Red
		Me.txtDay.ErrorMessage = Nothing
		Me.txtDay.Location = New System.Drawing.Point(57, 26)
		Me.txtDay.MaxLength = 2
		Me.txtDay.Name = "txtDay"
		Me.txtDay.Size = New System.Drawing.Size(50, 21)
		Me.txtDay.TabIndex = 3
		Me.txtDay.ValidationExpression = "^(?<Day>(?<Missing>\*)|(?<UnreadableCharacter>_[0-9])|(?<UnreadableCharacter>[0-3" & _
		  "]_)|(?<DayTens>0[1-9])|(?<DayTwenties>[1-2][0-9])|(?<DayThirties>3[0-1])|(?<Sing" & _
		  "leDigit>[1-9]))$"
		'
		'lblYear
		'
		Me.lblYear.AutoSize = True
		Me.lblYear.Location = New System.Drawing.Point(16, 79)
		Me.lblYear.Name = "lblYear"
		Me.lblYear.Size = New System.Drawing.Size(29, 13)
		Me.lblYear.TabIndex = 2
		Me.lblYear.Text = "Year"
		'
		'lblMonth
		'
		Me.lblMonth.AutoSize = True
		Me.lblMonth.Location = New System.Drawing.Point(16, 53)
		Me.lblMonth.Name = "lblMonth"
		Me.lblMonth.Size = New System.Drawing.Size(37, 13)
		Me.lblMonth.TabIndex = 1
		Me.lblMonth.Text = "Month"
		'
		'lblDay
		'
		Me.lblDay.AutoSize = True
		Me.lblDay.Location = New System.Drawing.Point(16, 29)
		Me.lblDay.Name = "lblDay"
		Me.lblDay.Size = New System.Drawing.Size(26, 13)
		Me.lblDay.TabIndex = 0
		Me.lblDay.Text = "Day"
		'
		'dpDate
		'
		Me.dpDate.CustomFormat = "dd MMM yyyy"
		Me.dpDate.Enabled = False
		Me.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.dpDate.Location = New System.Drawing.Point(261, 8)
		Me.dpDate.MaxDate = New Date(2010, 8, 21, 0, 0, 0, 0)
		Me.dpDate.Name = "dpDate"
		Me.dpDate.Size = New System.Drawing.Size(107, 21)
		Me.dpDate.TabIndex = 7
		Me.dpDate.Value = New Date(2010, 8, 21, 0, 0, 0, 0)
		Me.dpDate.Visible = False
		'
		'errDateHelper
		'
		Me.errDateHelper.ContainerControl = Me
		'
		'hlpDateHelper
		'
		Me.hlpDateHelper.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'ttDateHelper
		'
		Me.ttDateHelper.Active = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		Me.ttDateHelper.IsBalloon = True
		'
		'dlgDateHelper
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(386, 184)
		Me.Controls.Add(Me.dpDate)
		Me.Controls.Add(Me.grpDateComponents)
		Me.Controls.Add(Me.chkDateUnreadable)
		Me.Controls.Add(Me.chkDateMissing)
		Me.Controls.Add(Me.lblDateReturned)
		Me.Controls.Add(Me.txtDateReturned)
		Me.Controls.Add(Me.OK_Button)
		Me.Controls.Add(Me.Cancel_Button)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.HelpButton = True
		Me.hlpDateHelper.SetHelpKeyword(Me, "F4.html")
		Me.hlpDateHelper.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgDateHelper"
		Me.hlpDateHelper.SetShowHelp(Me, True)
		Me.ShowInTaskbar = False
		Me.Text = "Date Picker"
		Me.grpDateComponents.ResumeLayout(False)
		Me.grpDateComponents.PerformLayout()
		Me.grpOptions.ResumeLayout(False)
		Me.grpOptions.PerformLayout()
		CType(Me.errDateHelper, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents txtDateReturned As System.Windows.Forms.TextBox
	Friend WithEvents lblDateReturned As System.Windows.Forms.Label
	Friend WithEvents chkDateMissing As System.Windows.Forms.CheckBox
	Friend WithEvents chkDateUnreadable As System.Windows.Forms.CheckBox
	Friend WithEvents grpDateComponents As System.Windows.Forms.GroupBox
	Friend WithEvents grpOptions As System.Windows.Forms.GroupBox
	Friend WithEvents txtYear As RegExTextBox
	Friend WithEvents txtMonth As RegExTextBox
	Friend WithEvents txtDay As RegExTextBox
	Friend WithEvents lblYear As System.Windows.Forms.Label
	Friend WithEvents lblMonth As System.Windows.Forms.Label
	Friend WithEvents lblDay As System.Windows.Forms.Label
	Friend WithEvents chkYearUnreadable As System.Windows.Forms.CheckBox
	Friend WithEvents chkMonthUnreadable As System.Windows.Forms.CheckBox
	Friend WithEvents chkMonthMissing As System.Windows.Forms.CheckBox
	Friend WithEvents chkDayUnreadable As System.Windows.Forms.CheckBox
	Friend WithEvents chkDayMissing As System.Windows.Forms.CheckBox
	Friend WithEvents dpDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents errDateHelper As System.Windows.Forms.ErrorProvider
	Friend WithEvents hlpDateHelper As System.Windows.Forms.HelpProvider
	Friend WithEvents ttDateHelper As System.Windows.Forms.ToolTip

End Class
