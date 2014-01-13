Imports System.Windows.Forms
Imports System.Globalization
Imports System.Threading

Public Class CaseCombo
	Inherits ComboBox

	Public Enum CaseType
		Normal
		Title
		Upper
		Lower
	End Enum

	Private mCaseType As CaseType = CaseType.Normal

	Public Sub New()
		InitializeComponent()
		Me.Text = String.Empty
	End Sub

	Public Sub InitializeComponent()
		Me.SuspendLayout()
		Me.ResumeLayout(False)
	End Sub

	Public Property TextCase() As CaseType
		Get
			Return mCaseType
		End Get
		Set(ByVal value As CaseType)
			mCaseType = value
		End Set
	End Property

	Public Sub UpdateListTextCase()

		Select Case Me.TextCase
			Case CaseType.Lower
				For i As Integer = 0 To Me.Items.Count - 1 Step 1
					Dim sTempLc As String = Me.Items(i).ToString().ToLower()
					Me.Items(i) = sTempLc
				Next

			Case CaseType.Normal

			Case CaseType.Title
				For i As Integer = 0 To Me.Items.Count - 1 Step 1
					Dim sTempTc As String = Me.Items(i).ToString()
					Dim ci As CultureInfo = Thread.CurrentThread.CurrentCulture
					Dim ti As TextInfo = ci.TextInfo
					Me.Items(i) = ti.ToTitleCase(sTempTc)
				Next

			Case CaseType.Upper
				For i As Integer = 0 To Me.Items.Count - 1 Step 1
					Dim sTempLc As String = Me.Items(i).ToString().ToUpper()
					Me.Items(i) = sTempLc
				Next

		End Select

	End Sub

End Class
