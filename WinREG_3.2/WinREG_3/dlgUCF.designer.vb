<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgUCF
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgUCF))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.btnUcfOK = New System.Windows.Forms.Button
		Me.btnUcfCancel = New System.Windows.Forms.Button
		Me.lblOutput = New System.Windows.Forms.Label
		Me.txtDataField = New System.Windows.Forms.TextBox
		Me.grpRadioButtons = New System.Windows.Forms.GroupBox
		Me.RadioButton1 = New System.Windows.Forms.RadioButton
		Me.RadioButton2 = New System.Windows.Forms.RadioButton
		Me.RadioButton3 = New System.Windows.Forms.RadioButton
		Me.RadioButton4 = New System.Windows.Forms.RadioButton
		Me.RadioButton5 = New System.Windows.Forms.RadioButton
		Me.RadioButton6 = New System.Windows.Forms.RadioButton
		Me.lbl1Either = New System.Windows.Forms.Label
		Me.txt1Either = New System.Windows.Forms.TextBox
		Me.lbl1Or = New System.Windows.Forms.Label
		Me.txt1Or = New System.Windows.Forms.TextBox
		Me.lbl2Leader = New System.Windows.Forms.Label
		Me.nud2CannotRead = New System.Windows.Forms.NumericUpDown
		Me.lbl2Chars = New System.Windows.Forms.Label
		Me.lbl3Leader = New System.Windows.Forms.Label
		Me.txt3Letter = New System.Windows.Forms.TextBox
		Me.lbl4Leader = New System.Windows.Forms.Label
		Me.nud4From = New System.Windows.Forms.NumericUpDown
		Me.lbl4Or = New System.Windows.Forms.Label
		Me.nud4To = New System.Windows.Forms.NumericUpDown
		Me.lbl4Chars = New System.Windows.Forms.Label
		Me.btnPreview = New System.Windows.Forms.Button
		Me.hlpUCF = New System.Windows.Forms.HelpProvider
		Me.ttUCF = New System.Windows.Forms.ToolTip(Me.components)
		Me.TableLayoutPanel1.SuspendLayout()
		Me.grpRadioButtons.SuspendLayout()
		CType(Me.nud2CannotRead, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.nud4From, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.nud4To, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.btnUcfOK, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.btnUcfCancel, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(351, 215)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
		Me.TableLayoutPanel1.TabIndex = 1
		Me.TableLayoutPanel1.TabStop = True
		'
		'btnUcfOK
		'
		Me.btnUcfOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnUcfOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnUcfOK.Location = New System.Drawing.Point(3, 3)
		Me.btnUcfOK.Name = "btnUcfOK"
		Me.btnUcfOK.Size = New System.Drawing.Size(67, 23)
		Me.btnUcfOK.TabIndex = 0
		Me.btnUcfOK.Text = "OK"
		'
		'btnUcfCancel
		'
		Me.btnUcfCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnUcfCancel.CausesValidation = False
		Me.btnUcfCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnUcfCancel.Location = New System.Drawing.Point(76, 3)
		Me.btnUcfCancel.Name = "btnUcfCancel"
		Me.btnUcfCancel.Size = New System.Drawing.Size(67, 23)
		Me.btnUcfCancel.TabIndex = 1
		Me.btnUcfCancel.Text = "Cancel"
		'
		'lblOutput
		'
		Me.lblOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblOutput.AutoSize = True
		Me.lblOutput.Location = New System.Drawing.Point(7, 223)
		Me.lblOutput.Name = "lblOutput"
		Me.lblOutput.Size = New System.Drawing.Size(45, 13)
		Me.lblOutput.TabIndex = 3
		Me.lblOutput.Text = "Output:"
		'
		'txtDataField
		'
		Me.txtDataField.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.txtDataField.BackColor = System.Drawing.SystemColors.HighlightText
		Me.txtDataField.CausesValidation = False
		Me.hlpUCF.SetHelpString(Me.txtDataField, "This is the data string that will be returned to the input form")
		Me.txtDataField.Location = New System.Drawing.Point(53, 217)
		Me.txtDataField.Name = "txtDataField"
		Me.hlpUCF.SetShowHelp(Me.txtDataField, True)
		Me.txtDataField.Size = New System.Drawing.Size(289, 21)
		Me.txtDataField.TabIndex = 0
		'
		'grpRadioButtons
		'
		Me.grpRadioButtons.Controls.Add(Me.RadioButton1)
		Me.grpRadioButtons.Controls.Add(Me.RadioButton2)
		Me.grpRadioButtons.Controls.Add(Me.RadioButton3)
		Me.grpRadioButtons.Controls.Add(Me.RadioButton4)
		Me.grpRadioButtons.Controls.Add(Me.RadioButton5)
		Me.grpRadioButtons.Controls.Add(Me.RadioButton6)
		Me.grpRadioButtons.Location = New System.Drawing.Point(13, 3)
		Me.grpRadioButtons.Name = "grpRadioButtons"
		Me.grpRadioButtons.Size = New System.Drawing.Size(269, 208)
		Me.grpRadioButtons.TabIndex = 3
		Me.grpRadioButtons.TabStop = False
		Me.grpRadioButtons.Text = "Please select the correct option from the list below:"
		'
		'RadioButton1
		'
		Me.RadioButton1.AutoSize = True
		Me.RadioButton1.Location = New System.Drawing.Point(6, 20)
		Me.RadioButton1.Name = "RadioButton1"
		Me.RadioButton1.Size = New System.Drawing.Size(192, 17)
		Me.RadioButton1.TabIndex = 0
		Me.RadioButton1.TabStop = True
		Me.RadioButton1.Text = "I cannot tell whether it is ""A"" or ""B"""
		Me.RadioButton1.UseVisualStyleBackColor = True
		'
		'RadioButton2
		'
		Me.RadioButton2.AutoSize = True
		Me.RadioButton2.Location = New System.Drawing.Point(6, 50)
		Me.RadioButton2.Name = "RadioButton2"
		Me.RadioButton2.Size = New System.Drawing.Size(233, 17)
		Me.RadioButton2.TabIndex = 1
		Me.RadioButton2.TabStop = True
		Me.RadioButton2.Text = "I cannot read a certain number of letters..."
		Me.RadioButton2.UseVisualStyleBackColor = True
		'
		'RadioButton3
		'
		Me.RadioButton3.AutoSize = True
		Me.RadioButton3.Location = New System.Drawing.Point(6, 80)
		Me.RadioButton3.Name = "RadioButton3"
		Me.RadioButton3.Size = New System.Drawing.Size(220, 17)
		Me.RadioButton3.TabIndex = 2
		Me.RadioButton3.TabStop = True
		Me.RadioButton3.Text = "I think I can read the letter. It may be..."
		Me.RadioButton3.UseVisualStyleBackColor = True
		'
		'RadioButton4
		'
		Me.RadioButton4.AutoSize = True
		Me.RadioButton4.Location = New System.Drawing.Point(6, 110)
		Me.RadioButton4.Name = "RadioButton4"
		Me.RadioButton4.Size = New System.Drawing.Size(213, 17)
		Me.RadioButton4.TabIndex = 3
		Me.RadioButton4.TabStop = True
		Me.RadioButton4.Text = "I can't read between x and y letters ..."
		Me.RadioButton4.UseVisualStyleBackColor = True
		'
		'RadioButton5
		'
		Me.RadioButton5.AutoSize = True
		Me.RadioButton5.Location = New System.Drawing.Point(6, 140)
		Me.RadioButton5.Name = "RadioButton5"
		Me.RadioButton5.Size = New System.Drawing.Size(242, 17)
		Me.RadioButton5.TabIndex = 4
		Me.RadioButton5.TabStop = True
		Me.RadioButton5.Text = "I don't know how many letters I cannot read."
		Me.RadioButton5.UseVisualStyleBackColor = True
		'
		'RadioButton6
		'
		Me.RadioButton6.AutoSize = True
		Me.RadioButton6.Location = New System.Drawing.Point(6, 170)
		Me.RadioButton6.Name = "RadioButton6"
		Me.RadioButton6.Size = New System.Drawing.Size(197, 17)
		Me.RadioButton6.TabIndex = 5
		Me.RadioButton6.TabStop = True
		Me.RadioButton6.Text = "I cannot tell if it is a letter or a blob."
		Me.RadioButton6.UseVisualStyleBackColor = True
		'
		'lbl1Either
		'
		Me.lbl1Either.AutoSize = True
		Me.lbl1Either.Location = New System.Drawing.Point(287, 22)
		Me.lbl1Either.Name = "lbl1Either"
		Me.lbl1Either.Size = New System.Drawing.Size(95, 13)
		Me.lbl1Either.TabIndex = 11
		Me.lbl1Either.Text = "The letter is either"
		'
		'txt1Either
		'
		Me.txt1Either.Location = New System.Drawing.Point(391, 18)
		Me.txt1Either.MaxLength = 1
		Me.txt1Either.Name = "txt1Either"
		Me.txt1Either.Size = New System.Drawing.Size(30, 21)
		Me.txt1Either.TabIndex = 4
		'
		'lbl1Or
		'
		Me.lbl1Or.AutoSize = True
		Me.lbl1Or.Location = New System.Drawing.Point(430, 22)
		Me.lbl1Or.Name = "lbl1Or"
		Me.lbl1Or.Size = New System.Drawing.Size(22, 13)
		Me.lbl1Or.TabIndex = 7
		Me.lbl1Or.Text = "OR"
		'
		'txt1Or
		'
		Me.txt1Or.Location = New System.Drawing.Point(461, 18)
		Me.txt1Or.MaxLength = 1
		Me.txt1Or.Name = "txt1Or"
		Me.txt1Or.Size = New System.Drawing.Size(30, 21)
		Me.txt1Or.TabIndex = 5
		'
		'lbl2Leader
		'
		Me.lbl2Leader.AutoSize = True
		Me.lbl2Leader.Location = New System.Drawing.Point(287, 52)
		Me.lbl2Leader.Name = "lbl2Leader"
		Me.lbl2Leader.Size = New System.Drawing.Size(72, 13)
		Me.lbl2Leader.TabIndex = 9
		Me.lbl2Leader.Text = "I cannot read"
		'
		'nud2CannotRead
		'
		Me.nud2CannotRead.Location = New System.Drawing.Point(367, 48)
		Me.nud2CannotRead.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
		Me.nud2CannotRead.Name = "nud2CannotRead"
		Me.nud2CannotRead.Size = New System.Drawing.Size(47, 21)
		Me.nud2CannotRead.TabIndex = 6
		'
		'lbl2Chars
		'
		Me.lbl2Chars.AutoSize = True
		Me.lbl2Chars.Location = New System.Drawing.Point(422, 52)
		Me.lbl2Chars.Name = "lbl2Chars"
		Me.lbl2Chars.Size = New System.Drawing.Size(58, 13)
		Me.lbl2Chars.TabIndex = 11
		Me.lbl2Chars.Text = "characters"
		'
		'lbl3Leader
		'
		Me.lbl3Leader.AutoSize = True
		Me.lbl3Leader.Location = New System.Drawing.Point(287, 82)
		Me.lbl3Leader.Name = "lbl3Leader"
		Me.lbl3Leader.Size = New System.Drawing.Size(99, 13)
		Me.lbl3Leader.TabIndex = 12
		Me.lbl3Leader.Text = "I think the letter is:"
		'
		'txt3Letter
		'
		Me.txt3Letter.Location = New System.Drawing.Point(392, 78)
		Me.txt3Letter.MaxLength = 1
		Me.txt3Letter.Name = "txt3Letter"
		Me.txt3Letter.Size = New System.Drawing.Size(30, 21)
		Me.txt3Letter.TabIndex = 7
		'
		'lbl4Leader
		'
		Me.lbl4Leader.AutoSize = True
		Me.lbl4Leader.Location = New System.Drawing.Point(287, 112)
		Me.lbl4Leader.Name = "lbl4Leader"
		Me.lbl4Leader.Size = New System.Drawing.Size(35, 13)
		Me.lbl4Leader.TabIndex = 14
		Me.lbl4Leader.Text = "Either"
		'
		'nud4From
		'
		Me.nud4From.Location = New System.Drawing.Point(326, 108)
		Me.nud4From.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
		Me.nud4From.Name = "nud4From"
		Me.nud4From.Size = New System.Drawing.Size(47, 21)
		Me.nud4From.TabIndex = 8
		'
		'lbl4Or
		'
		Me.lbl4Or.AutoSize = True
		Me.lbl4Or.Location = New System.Drawing.Point(377, 112)
		Me.lbl4Or.Name = "lbl4Or"
		Me.lbl4Or.Size = New System.Drawing.Size(22, 13)
		Me.lbl4Or.TabIndex = 16
		Me.lbl4Or.Text = "OR"
		'
		'nud4To
		'
		Me.nud4To.Location = New System.Drawing.Point(405, 109)
		Me.nud4To.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
		Me.nud4To.Name = "nud4To"
		Me.nud4To.Size = New System.Drawing.Size(47, 21)
		Me.nud4To.TabIndex = 9
		'
		'lbl4Chars
		'
		Me.lbl4Chars.AutoSize = True
		Me.lbl4Chars.Location = New System.Drawing.Point(450, 112)
		Me.lbl4Chars.Name = "lbl4Chars"
		Me.lbl4Chars.Size = New System.Drawing.Size(58, 13)
		Me.lbl4Chars.TabIndex = 18
		Me.lbl4Chars.Text = "characters"
		'
		'btnPreview
		'
		Me.hlpUCF.SetHelpString(Me.btnPreview, "Press this to see a preview of the field as it will be returned to the input form" & _
				  "")
		Me.btnPreview.Location = New System.Drawing.Point(418, 186)
		Me.btnPreview.Name = "btnPreview"
		Me.hlpUCF.SetShowHelp(Me.btnPreview, True)
		Me.btnPreview.Size = New System.Drawing.Size(75, 23)
		Me.btnPreview.TabIndex = 19
		Me.btnPreview.Text = "Preview"
		Me.btnPreview.UseVisualStyleBackColor = True
		'
		'hlpUCF
		'
		Me.hlpUCF.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'ttUCF
		'
		Me.ttUCF.Active = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		Me.ttUCF.IsBalloon = True
		'
		'dlgUCF
		'
		Me.AcceptButton = Me.btnUcfOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnUcfCancel
		Me.ClientSize = New System.Drawing.Size(509, 256)
		Me.Controls.Add(Me.btnPreview)
		Me.Controls.Add(Me.lbl4Chars)
		Me.Controls.Add(Me.nud4To)
		Me.Controls.Add(Me.lbl4Or)
		Me.Controls.Add(Me.nud4From)
		Me.Controls.Add(Me.lbl4Leader)
		Me.Controls.Add(Me.txt3Letter)
		Me.Controls.Add(Me.lbl3Leader)
		Me.Controls.Add(Me.lbl1Either)
		Me.Controls.Add(Me.txt1Either)
		Me.Controls.Add(Me.lbl1Or)
		Me.Controls.Add(Me.txt1Or)
		Me.Controls.Add(Me.lbl2Leader)
		Me.Controls.Add(Me.nud2CannotRead)
		Me.Controls.Add(Me.lbl2Chars)
		Me.Controls.Add(Me.grpRadioButtons)
		Me.Controls.Add(Me.lblOutput)
		Me.Controls.Add(Me.txtDataField)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.HelpButton = True
		Me.hlpUCF.SetHelpKeyword(Me, "UncertainCharacterFormat.html")
		Me.hlpUCF.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgUCF"
		Me.hlpUCF.SetShowHelp(Me, True)
		Me.ShowInTaskbar = False
		Me.Text = "UCF (Uncertain Character Format) Selector"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.grpRadioButtons.ResumeLayout(False)
		Me.grpRadioButtons.PerformLayout()
		CType(Me.nud2CannotRead, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.nud4From, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.nud4To, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents btnUcfOK As System.Windows.Forms.Button
	Friend WithEvents btnUcfCancel As System.Windows.Forms.Button
	Friend WithEvents lblOutput As System.Windows.Forms.Label
	Friend WithEvents txtDataField As System.Windows.Forms.TextBox
	Friend WithEvents grpRadioButtons As System.Windows.Forms.GroupBox
	Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
	Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
	Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
	Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
	Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
	Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
	Friend WithEvents lbl1Either As System.Windows.Forms.Label
	Friend WithEvents txt1Either As System.Windows.Forms.TextBox
	Friend WithEvents lbl1Or As System.Windows.Forms.Label
	Friend WithEvents txt1Or As System.Windows.Forms.TextBox
	Friend WithEvents lbl2Leader As System.Windows.Forms.Label
	Friend WithEvents nud2CannotRead As System.Windows.Forms.NumericUpDown
	Friend WithEvents lbl2Chars As System.Windows.Forms.Label
	Friend WithEvents lbl3Leader As System.Windows.Forms.Label
	Friend WithEvents txt3Letter As System.Windows.Forms.TextBox
	Friend WithEvents lbl4Leader As System.Windows.Forms.Label
	Friend WithEvents nud4From As System.Windows.Forms.NumericUpDown
	Friend WithEvents lbl4Or As System.Windows.Forms.Label
	Friend WithEvents nud4To As System.Windows.Forms.NumericUpDown
	Friend WithEvents lbl4Chars As System.Windows.Forms.Label
	Friend WithEvents btnPreview As System.Windows.Forms.Button
	Friend WithEvents hlpUCF As System.Windows.Forms.HelpProvider
	Friend WithEvents ttUCF As System.Windows.Forms.ToolTip

End Class
