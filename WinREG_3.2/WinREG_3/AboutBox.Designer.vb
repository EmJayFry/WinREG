﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox
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

	Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
	Friend WithEvents LabelProductName As System.Windows.Forms.Label
	Friend WithEvents LabelVersion As System.Windows.Forms.Label
	Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
	Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
	Friend WithEvents OKButton As System.Windows.Forms.Button
	Friend WithEvents LabelCopyright As System.Windows.Forms.Label

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox))
		Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
		Me.LogoPictureBox = New System.Windows.Forms.PictureBox
		Me.LabelProductName = New System.Windows.Forms.Label
		Me.LabelVersion = New System.Windows.Forms.Label
		Me.LabelCopyright = New System.Windows.Forms.Label
		Me.LabelCompanyName = New System.Windows.Forms.Label
		Me.TextBoxDescription = New System.Windows.Forms.TextBox
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OKButton = New System.Windows.Forms.Button
		Me.btnInformation = New System.Windows.Forms.Button
		Me.TableLayoutPanel.SuspendLayout()
		CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'TableLayoutPanel
		'
		Me.TableLayoutPanel.ColumnCount = 3
		Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
		Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
		Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
		Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
		Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 1, 0)
		Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 1, 1)
		Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 2)
		Me.TableLayoutPanel.Controls.Add(Me.LabelCompanyName, 1, 3)
		Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 4)
		Me.TableLayoutPanel.Controls.Add(Me.TableLayoutPanel1, 1, 5)
		Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TableLayoutPanel.Location = New System.Drawing.Point(9, 9)
		Me.TableLayoutPanel.Name = "TableLayoutPanel"
		Me.TableLayoutPanel.RowCount = 6
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
		Me.TableLayoutPanel.Size = New System.Drawing.Size(396, 246)
		Me.TableLayoutPanel.TabIndex = 0
		'
		'LogoPictureBox
		'
		Me.LogoPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LogoPictureBox.Image = Global.WinREG.My.Resources.Resources.CleyNextTheSeaChurch
		Me.LogoPictureBox.Location = New System.Drawing.Point(3, 3)
		Me.LogoPictureBox.Name = "LogoPictureBox"
		Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
		Me.LogoPictureBox.Size = New System.Drawing.Size(125, 240)
		Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.LogoPictureBox.TabIndex = 0
		Me.LogoPictureBox.TabStop = False
		'
		'LabelProductName
		'
		Me.TableLayoutPanel.SetColumnSpan(Me.LabelProductName, 2)
		Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LabelProductName.Font = New System.Drawing.Font("Sliver", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelProductName.Location = New System.Drawing.Point(137, 0)
		Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 17)
		Me.LabelProductName.Name = "LabelProductName"
		Me.LabelProductName.Size = New System.Drawing.Size(256, 17)
		Me.LabelProductName.TabIndex = 0
		Me.LabelProductName.Text = "Product Name"
		Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'LabelVersion
		'
		Me.TableLayoutPanel.SetColumnSpan(Me.LabelVersion, 2)
		Me.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LabelVersion.Location = New System.Drawing.Point(137, 24)
		Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 17)
		Me.LabelVersion.Name = "LabelVersion"
		Me.LabelVersion.Size = New System.Drawing.Size(256, 17)
		Me.LabelVersion.TabIndex = 0
		Me.LabelVersion.Text = "Version {0}.{1:00}.{2:00}"
		Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'LabelCopyright
		'
		Me.TableLayoutPanel.SetColumnSpan(Me.LabelCopyright, 2)
		Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LabelCopyright.Location = New System.Drawing.Point(137, 48)
		Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
		Me.LabelCopyright.Name = "LabelCopyright"
		Me.LabelCopyright.Size = New System.Drawing.Size(256, 17)
		Me.LabelCopyright.TabIndex = 0
		Me.LabelCopyright.Text = "Copyright"
		Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'LabelCompanyName
		'
		Me.TableLayoutPanel.SetColumnSpan(Me.LabelCompanyName, 2)
		Me.LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LabelCompanyName.Location = New System.Drawing.Point(137, 72)
		Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelCompanyName.MaximumSize = New System.Drawing.Size(0, 17)
		Me.LabelCompanyName.Name = "LabelCompanyName"
		Me.LabelCompanyName.Size = New System.Drawing.Size(256, 17)
		Me.LabelCompanyName.TabIndex = 0
		Me.LabelCompanyName.Text = "Company Name"
		Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'TextBoxDescription
		'
		Me.TableLayoutPanel.SetColumnSpan(Me.TextBoxDescription, 2)
		Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TextBoxDescription.Location = New System.Drawing.Point(137, 99)
		Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
		Me.TextBoxDescription.Multiline = True
		Me.TextBoxDescription.Name = "TextBoxDescription"
		Me.TextBoxDescription.ReadOnly = True
		Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.TextBoxDescription.Size = New System.Drawing.Size(256, 112)
		Me.TextBoxDescription.TabIndex = 0
		Me.TextBoxDescription.TabStop = False
		Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
		Me.TextBoxDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel.SetColumnSpan(Me.TableLayoutPanel1, 2)
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.OKButton, 1, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.btnInformation, 0, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(134, 217)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(259, 26)
		Me.TableLayoutPanel1.TabIndex = 1
		'
		'OKButton
		'
		Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.OKButton.Location = New System.Drawing.Point(132, 3)
		Me.OKButton.Name = "OKButton"
		Me.OKButton.Size = New System.Drawing.Size(75, 20)
		Me.OKButton.TabIndex = 0
		Me.OKButton.Text = "&OK"
		'
		'btnInformation
		'
		Me.btnInformation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnInformation.Location = New System.Drawing.Point(51, 3)
		Me.btnInformation.Name = "btnInformation"
		Me.btnInformation.Size = New System.Drawing.Size(75, 20)
		Me.btnInformation.TabIndex = 1
		Me.btnInformation.Text = "Information"
		Me.btnInformation.UseVisualStyleBackColor = True
		'
		'AboutBox
		'
		Me.AcceptButton = Me.OKButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(414, 264)
		Me.Controls.Add(Me.TableLayoutPanel)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "AboutBox"
		Me.Padding = New System.Windows.Forms.Padding(9)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "About WinREG/3"
		Me.TableLayoutPanel.ResumeLayout(False)
		Me.TableLayoutPanel.PerformLayout()
		CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents btnInformation As System.Windows.Forms.Button

End Class
