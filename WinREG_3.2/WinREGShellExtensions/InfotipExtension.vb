'	$Date: 2013-05-17 11:29:04 +0200 (Fri, 17 May 2013) $
'	$Rev: 206 $
'	$Id: InfotipExtension.vb 206 2013-05-17 09:29:04Z Mikefry $
'
'	WinREGShellExtensions - Version 1.0.2
'

Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Imports Microsoft.VisualBasic.FileIO

Imports LogicNP.EZShellExtensions

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
	'
	' The TargetExtension attribute has been applied below to indicate 
	' the file types that your extension targets. 

	<Guid("D28389D2-0918-4E6F-B0C0-6BAEE3D36445"), ComVisible(True), TargetExtension(".csv", True)> _
	Public Class InfoTip
		Inherits InfoTipExtension

		Private _FileInfo As FileInfo
		Private _Csv As TextFieldParser
		Private _h1 As String(), _h2 As String(), _h3 As String(), _h4 As String(), _d1 As String()
		Private _RecCount As Integer = 0

		Public Sub New()
			MessageBox.Show("HELLO!", "Infotip")
		End Sub

		Protected Overrides Function OnInitialize() As Boolean
			Dim r As Boolean = True

			_FileInfo = New FileInfo(Me.TargetFile)
			If String.Compare(_FileInfo.Extension, ".csv", True) <> 0 Then
				Return False
			End If

			Try
				_Csv = New TextFieldParser(Me.TargetFile)
				_Csv.TextFieldType = FieldType.Delimited
				_Csv.SetDelimiters(",")
				_Csv.HasFieldsEnclosedInQuotes = True
				_Csv.TrimWhiteSpace = True

				_h1 = _Csv.ReadFields()
				If String.Compare(_h1(0), "+INFO", True) <> 0 Then
					r = False
				Else
					_h2 = _Csv.ReadFields()
					_h3 = _Csv.ReadFields()
					_h4 = _Csv.ReadFields()

					Dim currentRow As String()
					While Not _Csv.EndOfData
						currentRow = _Csv.ReadFields()
						If currentRow(0) <> "+LDS" And currentRow(0) <> "+WINREG" Then
							_RecCount += 1
							If _RecCount = 1 Then _d1 = currentRow
						End If
					End While
				End If

			Catch ex As Exception
				r = False
			End Try
			_Csv.Close()

			Return r
		End Function

		Protected Overrides Function OnGetInfoTip() As String
			Dim str As String = ""

			str += "Filename: <" + _FileInfo.Name + ">" + vbCrLf
			If _h2.Length >= 4 Then str += "County: <" + _h2(3) + ">" + vbCrLf
			If _d1.Length >= 2 Then str += "Placename: <" + _d1(1) + ">" + vbCrLf
			If _d1.Length >= 3 Then str += "Church: <" + _d1(2) + ">" + vbCrLf
			If _h4.Length >= 3 Then str += "Source: <" + _h4(2) + ">" + vbCrLf
			If _h4.Length >= 4 Then str += "Comments: <" + _h4(3) + ">" + vbCrLf
			str += "Record count: <" + _RecCount.ToString + ">" + vbCrLf

			Return str
		End Function

	End Class

End Namespace
