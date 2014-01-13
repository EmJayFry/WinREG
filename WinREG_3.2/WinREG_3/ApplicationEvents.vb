'	$Date: 2013-12-10 12:49:27 +0200 (Tue, 10 Dec 2013) $
'	$Rev: 284 $
'	$Id: ApplicationEvents.vb 284 2013-12-10 10:49:27Z Mikefry $
'
'	WinREG/3 - Version 3.2.1
'

Imports System.Threading
Imports System.Globalization
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.IO

Imports WinREG.MainForm
Imports Microsoft.WindowsAPICodePack.ApplicationServices
Imports System.Text

Namespace My

	' The following events are available for MyApplication:
	' 
	' Startup: Raised when the application starts, before the startup form is created.
	' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
	' UnhandledException: Raised if the application encounters an unhandled exception.
	' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
	' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
	Partial Friend Class MyApplication

		Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shutdown

			If fileOpen Then
				If fileChanged Then
					MessageBox.Show("Program is shutting down and there is still an open file, with changes that haven't been saved", "Application Shutdown", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				End If
			End If

			My.Application.Log.WriteEntry(Date.Now() + " WinREG/3 " + AppVersion() + " Shutdown" + vbCrLf, TraceEventType.Information)
		End Sub

		Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
			'If My.Application.CommandLineArgs.Count > 0 Then
			'	If String.Compare(My.Application.CommandLineArgs(0), "/nosplash", True) <> 0 Then
			'		If Not Me.SplashScreen Is Nothing Then
			'			While My.Settings.LoadFinished = False
			'				System.Threading.Thread.Sleep(100)
			'			End While
			'			My.Settings.LoadFinished = False
			'		End If
			'	End If
			'End If

			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture
			Try

				My.Application.Log.DefaultFileLogWriter.LogFileCreationSchedule = Logging.LogFileCreationScheduleOption.Daily
				My.Application.Log.DefaultFileLogWriter.Location = Logging.LogFileLocation.Custom
				If String.IsNullOrEmpty(My.Settings.DataFolderName) Then
					My.Application.Log.DefaultFileLogWriter.CustomLocation = String.Format("{0}\{1}\{2}", My.Computer.FileSystem.SpecialDirectories.MyDocuments, My.Application.Info.CompanyName, My.Application.Info.ProductName)
				Else
					My.Application.Log.DefaultFileLogWriter.CustomLocation = My.Settings.DataFolderName
				End If

				If System.IO.File.Exists(My.Application.Log.DefaultFileLogWriter.FullLogFileName) Then
					Dim fi = New System.IO.FileInfo(My.Application.Log.DefaultFileLogWriter.FullLogFileName)
					If fi.IsReadOnly() Then
						fi.IsReadOnly = False
					End If
				Else
				End If

				My.Application.Log.DefaultFileLogWriter.AutoFlush = True
				My.Application.Log.WriteEntry(Date.Now() + " WinREG/3 " + AppVersion() + " Started", TraceEventType.Information)

			Catch ex As Exception
				MessageBox.Show(ex.Message, "Application Startup", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				End
			End Try

			'			Dim x As Integer = 10
			'			Dim y As Integer = 0
			'			Dim z As Integer = x / y

		End Sub

		Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean
			If File.Exists("error.jpg") Then File.Delete("error.jpg")

			If Environment.OSVersion.Version.Major >= 6 Then
				WinREG.MainForm.RegisterForRecovery()
				WinREG.MainForm.RegisterForRestart()
			End If

			Me.MinimumSplashScreenDisplayTime = 5000
			Return MyBase.OnInitialize(commandLineArgs)
		End Function

		Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

			'If Me.SplashScreen IsNot Nothing Then
			'	If Me.SplashScreen.Visible Then
			'		Me.SplashScreen.Close()
			'	End If
			'End If

			If fileOpen Then
				If fileChanged Then
					MessageBox.Show("Program is crashing unexpectedly and there is still an open file, with changes that haven't been saved", "Application Shutdown", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				End If
			End If

			If MessageBox.Show(My.Resources.msgUnexpectedError, "Unhandled Exception", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
				Try
					Dim myMailMessage As New MailMessage("fredbonzo@iafrica.com", "mikefry@iafrica.com") With {.Priority = MailPriority.Normal, .Subject = "Unhandled Application Error"}

					Dim mediaType As String = "text/html"
					Dim bodyText As String = CreateExceptionText(e.Exception)
					Dim HTMLContent As AlternateView = AlternateView.CreateAlternateViewFromString(bodyText, Nothing, mediaType)
					myMailMessage.AlternateViews.Add(HTMLContent)

					TakeScreenShot()
					If File.Exists("error.jpg") Then
						Dim screenshot As New Attachment("error.jpg", MediaTypeNames.Image.Jpeg)
						Dim fname As String = String.Format("Exception {0} {1}.jpg", Date.Now.ToString, WinREG.MainForm._User.Username)
						screenshot.ContentDisposition.FileName = fname
						myMailMessage.Attachments.Add(screenshot)
					Else
						Dim fname As String = String.Format("Exception {0} {1}.jpg", Date.Now.ToString, WinREG.MainForm._User.Username)
					End If

					Dim smtpServer = New SmtpClient("smtp.iafrica.com")
					smtpServer.Send(myMailMessage)

					myMailMessage.Dispose()
					MessageBox.Show("Message sent", "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Critical, "Sending email " + Date.Now())
					MessageBox.Show("Exception sending message to developers", "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				End Try
			Else
				Dim s As New StringBuilder()
				s.AppendFormat("{0} {1}", e.Exception.Message, e.Exception.StackTrace)
				MessageBox.Show(s.ToString(), "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
			End If

			My.Application.Log.WriteEntry(String.Format("{0} StackTrace:{1}", Date.Now(), e.Exception.StackTrace), TraceEventType.Critical)
			My.Application.Log.WriteException(e.Exception, TraceEventType.Critical, "Application shut down at " + Date.Now())
		End Sub

		Private Sub TakeScreenShot()
			If My.Application.MainForm IsNot Nothing Then
				Dim bounds As Rectangle = My.Application.MainForm.Bounds
				Using b As New Bitmap(bounds.Width, bounds.Height)
					Using g = Graphics.FromImage(b)
						g.CopyFromScreen(My.Application.MainForm.Location, Point.Empty, bounds.Size)
					End Using
					b.Save("error.jpg", Imaging.ImageFormat.Jpeg)
				End Using
			Else
				Dim bounds As Rectangle = Screen.PrimaryScreen.Bounds
				Using b As New Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb)
					Using g = Graphics.FromImage(b)
						g.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
					End Using
					b.Save("error.jpg", Imaging.ImageFormat.Jpeg)
				End Using
			End If
		End Sub

		Private Function AppVersion() As String
			Return String.Format("Version {0}.{1:00}.{2:00}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
		End Function

		Private Function CreateExceptionText(ByVal ex As Exception) As String
			Return <p>
						 <pre>
*****************************************************************
* An Error has occurred in <%= My.Application.Info.AssemblyName %>
							 <%= String.Format(" [Version {0}.{1:00}.{2}]", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build) %>
* <%= String.Format("{0} ({1}) {2}", My.Computer.Info.OSFullName(), My.Computer.Info.OSPlatform(), My.Computer.Info.OSVersion()) %>
*****************************************************************
<%= FormatException(ex) %>
						 </pre>
					 </p>.ToString
		End Function

		'						 <img src='cid:SCREENSHOT'/>

		Private Function FormatException(ByVal ex As Exception) As String
			If ex Is Nothing Then
				Return ""
			Else
				Return <pre><%= ex.ToString() %>
-----------------------------------------------------------------
<%= FormatException(ex.InnerException) %>
						 </pre>.Value
			End If
		End Function

	End Class

End Namespace

