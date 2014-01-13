<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgUserSettings
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgUserSettings))
		Me.pgUserSettings = New System.Windows.Forms.PropertyGrid
		Me.hlpUserSettings = New System.Windows.Forms.HelpProvider
		Me.ttUserSettings = New System.Windows.Forms.ToolTip(Me.components)
		Me.SuspendLayout()
		'
		'pgUserSettings
		'
		Me.pgUserSettings.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pgUserSettings.Location = New System.Drawing.Point(0, 0)
		Me.pgUserSettings.Name = "pgUserSettings"
		Me.pgUserSettings.Size = New System.Drawing.Size(318, 347)
		Me.pgUserSettings.TabIndex = 0
		Me.ttUserSettings.SetToolTip(Me.pgUserSettings, resources.GetString("pgUserSettings.ToolTip"))
		'
		'hlpUserSettings
		'
		Me.hlpUserSettings.HelpNamespace = "WinREG3a.chm"
		'
		'ttUserSettings
		'
		Me.ttUserSettings.Active = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		Me.ttUserSettings.IsBalloon = True
		'
		'dlgUserSettings
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = True
		Me.AutoSize = True
		Me.ClientSize = New System.Drawing.Size(318, 347)
		Me.Controls.Add(Me.pgUserSettings)
		Me.HelpButton = True
		Me.hlpUserSettings.SetHelpKeyword(Me, "UserSettings.html")
		Me.hlpUserSettings.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgUserSettings"
		Me.hlpUserSettings.SetShowHelp(Me, True)
		Me.Text = "User Settings"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pgUserSettings As System.Windows.Forms.PropertyGrid
	Friend WithEvents hlpUserSettings As System.Windows.Forms.HelpProvider
	Friend WithEvents ttUserSettings As System.Windows.Forms.ToolTip
End Class
