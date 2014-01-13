'	$Date: 2013-09-07 09:38:09 +0200 (Sat, 07 Sep 2013) $
'	$Rev: 237 $
'	$Id: ContextMenuExtension.vb 237 2013-09-07 07:38:09Z Mikefry $
'
'	WinREGShellExtensions - Version 1.0.2
'

Imports System
Imports System.IO
Imports System.Runtime.InteropServices

Imports Microsoft.VisualBasic.FileIO

Imports LogicNP.EZShellExtensions
Imports System.Windows.Forms

' The following steps are only necessary if adding a new shell extension to an existing 
' ClassLibrary project via the "Add New Item.." dialog box.
' These are automatically performed when create a brand new shell extensions project is
' created using the "New Project" dialog box.

' STEP 1 
' If the project's AssemblyInfo.vb file has the AssemblyVersion 
' atrribute with a variable version as follows :
' <Assembly: AssemblyVersion("1.0.*")> 
' ...change it to a constant version as follows :
' <Assembly: AssemblyVersion("1.0.0.0")> 

' STEP 2
' This assembly must be given a strong name so that it can be installed in the GAC.
' To do so, generate a strong name key pair using the sn.exe tool that comes with the .Net SDK as follows :
' sn.exe -k keypair.kp 
' Then copy the generated keypair.kp file to the project directory and add the following attribute
' to the project's AssemblyInfo.vb file
'<Assembly: AssemblyKeyFile("..\..\keypair.kp")> 


' USING POST-BUILD STEPS 
' Use the following Post-Build Steps to speed up testing and developing of your shell extension : 
'
' "{Path To RegisterExtension.exe}" -i "$(TargetPath)"
' "{Path To RestartExplorer.exe}"
'
' The first step registers the shell extension on the system and installs the dll in the GAC after every build. 
' The second step restarts Windows Explorer so that your newly built dll gets loaded by Windows Explorer.
'
' Example : 
' "C:\Program Files\LogicNP Software\EZShellExtensions.Net\RegisterExtension.exe" -i "$(TargetPath)"
' "C:\Program Files\LogicNP Software\EZShellExtensions.Net\RestartExplorer.exe"
'
' Note: Use RegisterExtensionDotNet20.exe instead of RegisterExtension.exe if using Visual Studio 2005/.Net 2.0
'
' See the topic "Using Post-Build Steps to ease testing of shell extensions" in the 
' EZShellExtensions.Net help file for more information.

Namespace WinREGShellExtensions
	' The GuidAttribute has been applied to the extension class
	' with an automatically generated unique GUID.
	' Every different extension should have such a unique GUID

	' The TargetExtension attribute has been applied below to indicate 
	' the file types that your extension targets. 

	<Guid("A8883D86-E998-47C4-A754-FC5B8AC7894D"), ComVisible(True), TargetExtension(".csv", True)> _
	 Public Class CtxMenu

		Inherits ContextMenuExtension
		Private _FileInfo As FileInfo
		Private _file As String

		Public Sub New()
		End Sub

		'Override this method to perform initialzation specific to your contextmenu extension. 
		Protected Overrides Function OnInitialize() As Boolean

			If Me.TargetFiles.Length() > 1 Then Return False

			_FileInfo = New FileInfo(Me.TargetFiles(0))
			If String.Compare(_FileInfo.Extension, ".csv", True) <> 0 Then Return False
			_file = Me.TargetFiles(0)
			Return True

		End Function

		' Override this method to add your menu items to the context menu
		Protected Overrides Sub OnGetMenuItems(ByVal e As LogicNP.EZShellExtensions.GetMenuitemsEventArgs)
			Dim x As LogicNP.EZShellExtensions.ShellMenuItem = e.Menu.Getitem(10)

			e.Menu.AddItem("Open with Notepad", "OpenWithNotepad", "Opens the transcription file with the Notepad text editor")
			e.Menu.AddItem("Menu item 2", "menuitem2", "Menu Item 2")

		End Sub

		' Override this method to perform your own tasks when any of the 
		' menu items provided by your contextmenu extension is selected by the user.
		Protected Overrides Function OnExecuteMenuItem(ByVal e As LogicNP.EZShellExtensions.ExecuteItemEventArgs) As Boolean
			If e.MenuItem.Verb = "OpenWithNotepad" Then
				Dim systemDirectory As String = System.Environment.SystemDirectory
				Dim notepadPath As String = My.Computer.FileSystem.CombinePath(systemDirectory, "NOTEPAD.EXE")
				Dim process As New System.Diagnostics.Process
				process.Start(notepadPath, _file)
				Return True

			ElseIf e.MenuItem.Verb = "menuitem2" Then
				MessageBox.Show("Menu Item 2 Clicked for " & _file)
				Return True

			End If

			' Return TRUE if menu item is yours(check verb) and execution is successful, FALSE otherwise
			Return False
		End Function


		' Override this method to provide the dimensions for any owner drawn 
		' contextmenu items provided by your contextmenu extension.
		' 'TODO : UNCOMMENT THIS OVERRIDE IF YOU HAVE OWNER DRAWN MENU IETMS
		' -------------
		' Protected Overrides Sub OnMeasureMenuItem(ByVal e As LogicNP.EZShellExtensions.EZSMeasureItemEventArgs)
		'     'TODO : Set menu item width and height

		'     e.ItemHeight = 150
		'     e.ItemWidth = 150
		' End Sub
		' -------------

		' Override this method to draw any owner-draw menu items
		' added by the contextmenu extension.
		' 'TODO : UNCOMMENT THIS OVERRIDE IF YOU HAVE OWNER DRAWN MENU IETMS
		' -------------
		' Protected Overrides Sub OnDrawMenuItem(ByVal e As LogicNP.EZShellExtensions.EZSDrawItemEventArgs)
		'     'TODO : Write your drawing code here.
		'     e.Graphics.FillRectangle(SystemBrushes.Menu, e.Bounds)
		' End Sub
		' -------------

	End Class

End Namespace

