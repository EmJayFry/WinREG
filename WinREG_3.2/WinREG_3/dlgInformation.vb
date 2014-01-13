'	$Date: 2013-10-02 10:26:35 +0200 (Wed, 02 Oct 2013) $
'	$Rev: 248 $
'	$Id: dlgInformation.vb 248 2013-10-02 08:26:35Z Mikefry $
'
'	WinREG/3 - Version 3.1.17
'

Imports System.Windows.Forms
Imports Microsoft.Win32
Imports System.Text

Public Class dlgInformation

	Private Sub dlgInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim clr As String = String.Format("Current CLR Version: {0}" + vbCrLf + vbCrLf, GetVersionFromEnvironment)
		Dim installed As String = GetInstalledVersionsFromRegistry() + vbCrLf
		Dim updates As String = GetUpdateHistory() + vbCrLf

		txtInformation.Text = clr + installed + updates
		txtInformation.SelectionStart = 0
		txtInformation.SelectionLength = 0
	End Sub

	Private Function GetVersionFromEnvironment() As String
		Return Environment.Version.ToString()
	End Function

	Private Function GetInstalledVersionsFromRegistry() As String
		Dim strBuild As New StringBuilder()
		strBuild.AppendLine("Installed Versions:")

		Using ndpKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\")
			For Each versionKeyName As String In ndpKey.GetSubKeyNames()
				If versionKeyName.StartsWith("v") Then
					Dim versionKey As RegistryKey = ndpKey.OpenSubKey(versionKeyName)
					Dim name As String = DirectCast(versionKey.GetValue("Version", ""), String)
					Dim sp As String = versionKey.GetValue("SP", "").ToString()
					Dim install As String = versionKey.GetValue("Install", "").ToString()
					If install = "" Then
						'no install info, must be later
						strBuild.AppendFormat("  {0}  {1}" + vbCrLf, versionKeyName, name)
					Else
						If sp <> "" AndAlso install = "1" Then
							strBuild.AppendFormat("  {0}  {1}  SP{2}" + vbCrLf, versionKeyName, name, sp)
						End If
					End If
					If name <> "" Then Continue For

					For Each subKeyName As String In versionKey.GetSubKeyNames()
						Dim subKey As RegistryKey = versionKey.OpenSubKey(subKeyName)
						name = DirectCast(subKey.GetValue("Version", ""), String)
						If name <> "" Then
							sp = subKey.GetValue("SP", "").ToString()
						End If
						install = subKey.GetValue("Install", "").ToString()
						If install = "" Then
							'no install info, must be later
							strBuild.AppendFormat("  {0}  {1}" + vbCrLf, versionKeyName, name)
						Else
							If sp <> "" AndAlso install = "1" Then
								strBuild.AppendFormat("    {0}  {1}  SP{2}" + vbCrLf, versionKeyName, name, sp)
							ElseIf install = "1" Then
								strBuild.AppendFormat("    {0}  {1}" + vbCrLf, subKeyName, name)
							End If
						End If
					Next
				End If
			Next
		End Using

		Return strBuild.ToString
	End Function

	Private Function GetUpdateHistory() As String
		Dim strBuild As New StringBuilder()
		strBuild.appendline("Update History:")

		Using baseKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Updates")
			For Each baseKeyName As String In baseKey.GetSubKeyNames()
				If baseKeyName.Contains(".NET Framework") OrElse baseKeyName.StartsWith("KB") OrElse baseKeyName.Contains(".NETFramework") Then

					Using updateKey As RegistryKey = baseKey.OpenSubKey(baseKeyName)
						Dim name As String = CStr(updateKey.GetValue("PackageName", ""))
						strBuild.AppendFormat("  {0}  {1}" + vbCrLf, baseKeyName, name)
						For Each kbKeyName As String In updateKey.GetSubKeyNames()
							Using kbKey As RegistryKey = updateKey.OpenSubKey(kbKeyName)
								name = CStr(kbKey.GetValue("PackageName", ""))
								strBuild.AppendFormat("    {0}  {1}" + vbCrLf, kbKeyName, name)

								If kbKey.SubKeyCount > 0 Then
									For Each sbKeyName As String In updateKey.GetSubKeyNames()
										Using sbSubKey As RegistryKey = kbKey.OpenSubKey(sbKeyName)
											name = CStr(sbSubKey.GetValue("PackageName", ""))
											If name = "" Then
												name = CStr(sbSubKey.GetValue("Description", ""))
											End If
											strBuild.AppendFormat("      {0}  {1}" + vbCrLf, sbKeyName, name)
										End Using
									Next sbKeyName
								End If
							End Using
						Next kbKeyName
					End Using

				End If
			Next baseKeyName
		End Using

		Return strBuild.ToString
	End Function

End Class
