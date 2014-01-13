Imports System.Windows.Forms
Imports System.Globalization
Imports System.Threading

Public Class CaseText
	Inherits TextBox

	Public Enum CaseType
		Normal
		Title
		Upper
		Lower
		Sentence
		ChristianNames
	End Enum

	Private mCaseType As CaseType = CaseType.Normal

	Public Sub New()
		InitializeComponent()
		Me.Text = String.Empty
		Me.Multiline = False
		Me.Height = 20
	End Sub

	Private Sub InitializeComponent()
		Me.SuspendLayout()
		AddHandler Me.TextChanged, AddressOf Me.CaseText_TextChanged
		Me.ResumeLayout(False)
	End Sub

	Public Property TextCase() As CaseType
		Get
			Return mCaseType
		End Get
		Set(ByVal value As CaseType)
			mCaseType = value
			UpdateTextCase()
		End Set
	End Property

	'Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
	'	MyBase.OnKeyDown(e)
	'End Sub

	'Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
	'	MyBase.OnKeyPress(e)
	'End Sub

	Private Sub CaseText_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		UpdateTextCase()
	End Sub

	Private Sub UpdateTextCase()
		Dim sControlText As String = Me.Text
		Dim cursorPosition As Integer = Me.SelectionStart

		Select Case Me.TextCase
			Case CaseType.Normal

			Case CaseType.Lower
				Me.Text = Me.Text.ToLower()

			Case CaseType.Upper
				Me.Text = Me.Text.ToUpper()

			Case CaseType.Title
				Dim ci As CultureInfo = Thread.CurrentThread.CurrentCulture
				Dim ti As TextInfo = ci.TextInfo
				Me.Text = ti.ToTitleCase(sControlText)

			Case CaseType.Sentence
				Me.Text = ToSentenceCase(sControlText)

			Case CaseType.ChristianNames
				Me.Text = ChristianNamesCase(sControlText)

		End Select

		Me.SelectionStart = cursorPosition
	End Sub

	Private Function ToSentenceCase(ByVal text As String) As String
		Dim temporary As String = text
		Dim result As String = ""

		While (temporary.Length > 0)
			Dim splitTemporary() As String = splitAtFirstSentence(temporary)

			temporary = splitTemporary(1)
			If (splitTemporary(0).Length > 0) Then
				result += capitaliseSentence(splitTemporary(0))
			Else
				result += capitaliseSentence(splitTemporary(1))
				temporary = ""
			End If
		End While
		Return result
	End Function

	Private Function capitaliseSentence(ByVal sentence As String) As String

		Dim result As String = ""

		While (sentence(0) = " "c)
			sentence = sentence.Remove(0, 1)
			result += " "
			If (sentence.Length = 0) Then Exit While
		End While

		Dim trimmed = sentence.TrimStart()

		If (trimmed.Length > 0) Then
			If trimmed.Substring(0, 1) = "[" Then
				Dim i = trimmed.IndexOf("]"c)
				If i > -1 Then
					result += trimmed.Substring(0, i + 1).ToUpper()
					If (i + 1) < trimmed.Length Then
						result += trimmed.Substring(i + 1, trimmed.Length - 1 - i)
					End If
				End If
			Else
				result += trimmed.Substring(0, 1).ToUpper()
				result += trimmed.Substring(1, trimmed.Length - 1)
			End If
		End If
		Return result
	End Function

	Private Function splitAtFirstSentence(ByVal text As String) As String()

		Dim lastChar As Integer = text.IndexOfAny(New Char() {"."c, ":"c, vbLf, vbCr, "!"c, "?"c}) + 1

		If (lastChar = 1) Then lastChar = 0

		Return New String() {text.Substring(0, lastChar), text.Substring(lastChar, text.Length - lastChar)}
	End Function

	Private Function ChristianNamesCase(ByVal names As String) As String
		Dim result As String = ""
		Dim chars() As Char
		Dim fNextUpper As Boolean = True, fUCF = False
		Dim i As Integer = 0

		If (names IsNot String.Empty) Then
			chars = names.ToCharArray()
			For i = 0 To chars.Length() - 1 Step 1
				If (fNextUpper) Then
					If chars(i) = "["c Then
						fUCF = True
						result += chars(i).ToString()
					Else
						If chars(i) = "]"c Then
							fUCF = False
							result += chars(i).ToString()
							fNextUpper = False
						Else
							If fUCF Then
								result += chars(i).ToString().ToUpper()
							Else
								result += chars(i).ToString().ToUpper()
								fNextUpper = False
							End If
						End If
					End If
				Else
					result += chars(i).ToString().ToLower()
					If (chars(i) = " "c) Then
						fNextUpper = True
					End If
				End If
			Next
		End If

		Return result
	End Function

End Class
