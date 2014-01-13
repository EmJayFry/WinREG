'	$Date: 2013-10-02 09:26:11 +0200 (Wed, 02 Oct 2013) $
'	$Rev: 246 $
'	$Id: AboutBox.vb 246 2013-10-02 07:26:11Z Mikefry $
'
'	WinREG/3 - Version 3.1.17
'

Public NotInheritable Class AboutBox

	Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Set the title of the form.
		Dim ApplicationTitle As String
		If My.Application.Info.Title <> "" Then
			ApplicationTitle = My.Application.Info.Title
		Else
			ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
		End If
		Me.Text = String.Format("About {0}", ApplicationTitle)

		' Initialize all of the text displayed on the About Box.
		Me.LabelProductName.Text = My.Application.Info.ProductName
		Me.LabelVersion.Text = String.Format(LabelVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
		Me.LabelCopyright.Text = My.Application.Info.Copyright
		Me.LabelCompanyName.Text = My.Application.Info.CompanyName
		Me.TextBoxDescription.Text = My.Application.Info.Description
	End Sub

	Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
		Me.Close()
	End Sub

	Private Sub btnInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformation.Click
		Using dlg As New dlgInformation
			dlg.ShowDialog()
		End Using
	End Sub
End Class
