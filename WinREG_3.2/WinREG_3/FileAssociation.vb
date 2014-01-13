'	$Date: 2012-02-01 15:52:14 +0200 (Wed, 01 Feb 2012) $
'	$Rev: 147 $
'	$Id: FileAssociation.vb 147 2012-02-01 13:52:14Z Mikefry $
'
'	WinREG/3 - Version 3.1.8
'

Imports Microsoft.Win32

Public Class FileAssociation

	Public Sub SetFileType(ByVal extension As String, ByVal FileType As String)
		Dim rk As RegistryKey = Registry.ClassesRoot
		Dim ext As RegistryKey = rk.CreateSubKey(extension)
		ext.SetValue("", FileType)
	End Sub

	Public Sub SetFileDescription(ByVal FileType As String, ByVal Description As String)
		Dim rk As RegistryKey = Registry.ClassesRoot
		Dim ext As RegistryKey = rk.CreateSubKey(FileType)
		ext.SetValue("", Description)
	End Sub

	Public Sub AddAction(ByVal FileType As String, ByVal Verb As String, ByVal ActionDescription As String)
		Dim rk As RegistryKey = Registry.ClassesRoot
		Dim ext As RegistryKey = rk.OpenSubKey(FileType, True).CreateSubKey("shell").CreateSubKey(Verb)
		ext.SetValue("", ActionDescription)
	End Sub

	Public Sub SetExtensionCommandLine(ByVal Command As String, ByVal FileType As String, ByVal CommandLine As String)
		SetExtensionCommandLine(Command, FileType, CommandLine, "")
	End Sub

	Public Sub SetExtensionCommandLine(ByVal Command As String, ByVal FileType As String, ByVal CommandLine As String, ByVal Name As String)
		Dim rk As RegistryKey = Registry.ClassesRoot
		Dim ext As RegistryKey = rk.OpenSubKey(FileType, True).OpenSubKey("shell", True).OpenSubKey(Command, True).CreateSubKey("command")
		ext.SetValue("", CommandLine)
	End Sub

	Public Sub SetDefaultAction(ByVal FileType As String, ByVal Verb As String)
		Dim rk As RegistryKey = Registry.ClassesRoot
		Dim ext As RegistryKey = rk.OpenSubKey(FileType, True).OpenSubKey("shell", True)
		ext.SetValue("", Verb)
	End Sub

	Public Sub SetDefaultIcon(ByVal FileType As String, ByVal icon As String)
		Dim rk As RegistryKey = Registry.ClassesRoot
		Dim ext As RegistryKey = rk.OpenSubKey(FileType, True).CreateSubKey("DefaultIcon")
		ext.SetValue("", icon)
	End Sub

End Class
