'	$Date: 2013-05-17 11:29:04 +0200 (Fri, 17 May 2013) $
'	$Rev: 206 $
'	$Id: PropertySheetExtension.vb 206 2013-05-17 09:29:04Z Mikefry $
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

	' The TargetExtension attribute has been applied below to indicate 
	' the file types that your extension targets. 

	<Guid("45F3ABA2-2219-46EB-A46D-F526E579D8CD"), ComVisible(True), TargetExtension(".csv", True)> _
	 Public Class PropSheet
		Inherits PropertySheetExtension

#Region " Windows Form Designer generated code "

		Public Sub New()
			MyBase.New()

			'This call is required by the Windows Form Designer.
			Application.EnableVisualStyles()
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call

		End Sub

		'UserControl1 overrides dispose to clean up the component list.
		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not (components Is Nothing) Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents txtFilename As System.Windows.Forms.TextBox
		Friend WithEvents txtCounty As System.Windows.Forms.TextBox
		Friend WithEvents txtPlacename As System.Windows.Forms.TextBox
		Friend WithEvents txtChurchname As System.Windows.Forms.TextBox
		Friend WithEvents txtSource As System.Windows.Forms.TextBox
		Friend WithEvents txtComments As System.Windows.Forms.TextBox
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents txtFileSize As System.Windows.Forms.TextBox
		Friend WithEvents txtRecCount As System.Windows.Forms.TextBox

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.Label1 = New System.Windows.Forms.Label
			Me.Label2 = New System.Windows.Forms.Label
			Me.Label3 = New System.Windows.Forms.Label
			Me.Label4 = New System.Windows.Forms.Label
			Me.Label5 = New System.Windows.Forms.Label
			Me.Label6 = New System.Windows.Forms.Label
			Me.txtFilename = New System.Windows.Forms.TextBox
			Me.txtCounty = New System.Windows.Forms.TextBox
			Me.txtPlacename = New System.Windows.Forms.TextBox
			Me.txtChurchname = New System.Windows.Forms.TextBox
			Me.txtSource = New System.Windows.Forms.TextBox
			Me.txtComments = New System.Windows.Forms.TextBox
			Me.Label7 = New System.Windows.Forms.Label
			Me.Label8 = New System.Windows.Forms.Label
			Me.txtFileSize = New System.Windows.Forms.TextBox
			Me.txtRecCount = New System.Windows.Forms.TextBox
			Me.SuspendLayout()
			'
			'Label1
			'
			Me.Label1.AutoSize = True
			Me.Label1.Location = New System.Drawing.Point(28, 35)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(52, 13)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Filename:"
			'
			'Label2
			'
			Me.Label2.AutoSize = True
			Me.Label2.Location = New System.Drawing.Point(28, 57)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(43, 13)
			Me.Label2.TabIndex = 1
			Me.Label2.Text = "County:"
			'
			'Label3
			'
			Me.Label3.AutoSize = True
			Me.Label3.Location = New System.Drawing.Point(28, 79)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(63, 13)
			Me.Label3.TabIndex = 2
			Me.Label3.Text = "Placename:"
			'
			'Label4
			'
			Me.Label4.AutoSize = True
			Me.Label4.Location = New System.Drawing.Point(28, 101)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(73, 13)
			Me.Label4.TabIndex = 3
			Me.Label4.Text = "Church name:"
			'
			'Label5
			'
			Me.Label5.AutoSize = True
			Me.Label5.Location = New System.Drawing.Point(28, 123)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(44, 13)
			Me.Label5.TabIndex = 4
			Me.Label5.Text = "Source:"
			'
			'Label6
			'
			Me.Label6.AutoSize = True
			Me.Label6.Location = New System.Drawing.Point(28, 145)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(59, 13)
			Me.Label6.TabIndex = 5
			Me.Label6.Text = "Comments:"
			'
			'txtFilename
			'
			Me.txtFilename.BackColor = System.Drawing.SystemColors.Window
			Me.txtFilename.Location = New System.Drawing.Point(107, 32)
			Me.txtFilename.Name = "txtFilename"
			Me.txtFilename.ReadOnly = True
			Me.txtFilename.Size = New System.Drawing.Size(214, 20)
			Me.txtFilename.TabIndex = 6
			'
			'txtCounty
			'
			Me.txtCounty.BackColor = System.Drawing.SystemColors.Window
			Me.txtCounty.Location = New System.Drawing.Point(107, 54)
			Me.txtCounty.Name = "txtCounty"
			Me.txtCounty.ReadOnly = True
			Me.txtCounty.Size = New System.Drawing.Size(214, 20)
			Me.txtCounty.TabIndex = 7
			'
			'txtPlacename
			'
			Me.txtPlacename.BackColor = System.Drawing.SystemColors.Window
			Me.txtPlacename.Location = New System.Drawing.Point(107, 76)
			Me.txtPlacename.Name = "txtPlacename"
			Me.txtPlacename.ReadOnly = True
			Me.txtPlacename.Size = New System.Drawing.Size(214, 20)
			Me.txtPlacename.TabIndex = 8
			'
			'txtChurchname
			'
			Me.txtChurchname.BackColor = System.Drawing.SystemColors.Window
			Me.txtChurchname.Location = New System.Drawing.Point(107, 98)
			Me.txtChurchname.Name = "txtChurchname"
			Me.txtChurchname.ReadOnly = True
			Me.txtChurchname.Size = New System.Drawing.Size(214, 20)
			Me.txtChurchname.TabIndex = 9
			'
			'txtSource
			'
			Me.txtSource.BackColor = System.Drawing.SystemColors.Window
			Me.txtSource.Location = New System.Drawing.Point(107, 120)
			Me.txtSource.Name = "txtSource"
			Me.txtSource.ReadOnly = True
			Me.txtSource.Size = New System.Drawing.Size(214, 20)
			Me.txtSource.TabIndex = 10
			'
			'txtComments
			'
			Me.txtComments.BackColor = System.Drawing.SystemColors.Window
			Me.txtComments.Location = New System.Drawing.Point(107, 142)
			Me.txtComments.Name = "txtComments"
			Me.txtComments.ReadOnly = True
			Me.txtComments.Size = New System.Drawing.Size(214, 20)
			Me.txtComments.TabIndex = 11
			'
			'Label7
			'
			Me.Label7.AutoSize = True
			Me.Label7.Location = New System.Drawing.Point(28, 199)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New System.Drawing.Size(47, 13)
			Me.Label7.TabIndex = 12
			Me.Label7.Text = "File size:"
			'
			'Label8
			'
			Me.Label8.AutoSize = True
			Me.Label8.Location = New System.Drawing.Point(166, 199)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New System.Drawing.Size(75, 13)
			Me.Label8.TabIndex = 13
			Me.Label8.Text = "Record count:"
			'
			'txtFileSize
			'
			Me.txtFileSize.BackColor = System.Drawing.SystemColors.Window
			Me.txtFileSize.Location = New System.Drawing.Point(81, 196)
			Me.txtFileSize.Name = "txtFileSize"
			Me.txtFileSize.ReadOnly = True
			Me.txtFileSize.Size = New System.Drawing.Size(57, 20)
			Me.txtFileSize.TabIndex = 14
			Me.txtFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			'
			'txtRecCount
			'
			Me.txtRecCount.BackColor = System.Drawing.SystemColors.Window
			Me.txtRecCount.Location = New System.Drawing.Point(247, 196)
			Me.txtRecCount.Name = "txtRecCount"
			Me.txtRecCount.ReadOnly = True
			Me.txtRecCount.Size = New System.Drawing.Size(51, 20)
			Me.txtRecCount.TabIndex = 15
			Me.txtRecCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			'
			'PropertySheetExtension1
			'
			Me.Controls.Add(Me.txtRecCount)
			Me.Controls.Add(Me.txtFileSize)
			Me.Controls.Add(Me.Label8)
			Me.Controls.Add(Me.Label7)
			Me.Controls.Add(Me.txtComments)
			Me.Controls.Add(Me.txtSource)
			Me.Controls.Add(Me.txtChurchname)
			Me.Controls.Add(Me.txtPlacename)
			Me.Controls.Add(Me.txtCounty)
			Me.Controls.Add(Me.txtFilename)
			Me.Controls.Add(Me.Label6)
			Me.Controls.Add(Me.Label5)
			Me.Controls.Add(Me.Label4)
			Me.Controls.Add(Me.Label3)
			Me.Controls.Add(Me.Label2)
			Me.Controls.Add(Me.Label1)
			Me.Name = "PropertySheetExtension1"
			Me.Text = "FreeREG Transcription FIle"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

#End Region

		Private _FileInfo As FileInfo
		Private _Csv As TextFieldParser
		Private _h1 As String(), _h2 As String(), _h3 As String(), _h4 As String(), _d1 As String()
		Private _RecCount As Integer = 0

		' Override this method to perform initialization tasks specific 
		' to your property sheet extension.

		Protected Overrides Function OnInitialize() As Boolean
			Dim r As Boolean = True

			If Me.TargetFiles.Length() > 1 Then Return False

			_FileInfo = New FileInfo(Me.TargetFiles(0))
			If String.Compare(_FileInfo.Extension, ".csv", True) <> 0 Then Return False

			Try
				_Csv = New TextFieldParser(Me.TargetFiles(0))
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

		Private Sub PropertySheetExtension1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

			Me.txtFilename.Text = _FileInfo.Name
			If _h2.Length >= 4 Then Me.txtCounty.Text = _h2(3)
			Me.txtPlacename.Text = _d1(1)
			Me.txtChurchname.Text = _d1(2)
			If _h4.Length >= 3 Then Me.txtSource.Text = _h4(2)
			If _h4.Length >= 4 Then Me.txtComments.Text = _h4(3)
			Me.txtFileSize.Text = _FileInfo.Length()
			Me.txtRecCount.Text = _RecCount

		End Sub
	End Class

End Namespace

