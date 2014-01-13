'	$Date: 2013-10-16 18:27:32 +0200 (Wed, 16 Oct 2013) $
'	$Rev: 258 $
'	$Id: SplashScreen.vb 258 2013-10-16 16:27:32Z Mikefry $
'
'	WinREG/3 - Version 3.1.18
'

Public NotInheritable Class SplashScreen

	Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		'Set up the dialog text at runtime according to the application's assembly information.  
		My.Settings.LoadFinished = False

		'Application title
		If My.Application.Info.Title <> "" Then
			ApplicationTitle.Text = My.Application.Info.Title
		Else
			'If the application title is missing, use the application name, without the extension
			ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
		End If

		'Format the version information using the text set into the Version control at design time as the
		'  formatting string.  This allows for effective localization if desired.
		'  Build and revision information could be included by using the following code and changing the 
		'  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
		'  String.Format() in Help for more information.
		'
		'    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

		Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)

		'Copyright info
		Copyright.Text = My.Application.Info.Copyright
		My.Settings.LoadFinished = True
	End Sub

End Class
