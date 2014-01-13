Imports System.Windows.Forms
Imports System.Text

Public Class dlgEditBadRecord
	Private _bad As BadRecordsDataSet.BadRecordsRow

	Sub New(ByRef bad As BadRecordsDataSet.BadRecordsRow)
		InitializeComponent()
		_bad = bad
	End Sub

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		_bad.csv = CType(CSVParser(OriginalSourceTextBox.Text).ToArray(GetType(String)), String())
		_bad.OriginalSource = OriginalSourceTextBox.Text

		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub dlgEditBadRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		RowNumberTextBox.Text = _bad.RowNumber
		OriginalSourceTextBox.Text = _bad.OriginalSource
	End Sub

	Private Function CSVParser(ByVal strInputString As String) As ArrayList
		Dim Counter As Integer = 0, intLength
		Dim strElem As StringBuilder = New StringBuilder()
		Dim alParsedCsv As ArrayList = New ArrayList()
		intLength = strInputString.Length
		strElem = strElem.Append("")
		Dim intCurrState As Integer = 0
		Dim aActionDecider As Integer()() = New Integer(8)() {}
		'Build the state array
		aActionDecider(0) = New Integer(3) {2, 0, 1, 5}
		aActionDecider(1) = New Integer(3) {6, 0, 1, 5}
		aActionDecider(2) = New Integer(3) {4, 3, 3, 6}
		aActionDecider(3) = New Integer(3) {4, 3, 3, 6}
		aActionDecider(4) = New Integer(3) {2, 8, 6, 7}
		aActionDecider(5) = New Integer(3) {5, 5, 5, 5}
		aActionDecider(6) = New Integer(3) {6, 6, 6, 6}
		aActionDecider(7) = New Integer(3) {5, 5, 5, 5}
		aActionDecider(8) = New Integer(3) {0, 0, 0, 0}

		For intCounter As Integer = 0 To intLength - 1
			Dim ch As Char = strInputString(intCounter)
			intCurrState = aActionDecider(intCurrState)(GetInputID(ch))
			'take the necessary action depending upon the state 
			PerformAction(intCurrState, ch, strElem, alParsedCsv)
		Next

		'End of line reached, hence input ID is 3

		intCurrState = aActionDecider(intCurrState)(3)
		PerformAction(intCurrState, Chr(0), strElem, alParsedCsv)
		Return alParsedCsv
	End Function

	Private Function GetInputID(ByVal chrInput As Char) As Integer
		If chrInput = """"c Then
			Return 0
		ElseIf chrInput = ","c Then
			Return 1
		Else
			Return 2
		End If
	End Function

	Private Sub PerformAction(ByRef intCurrState As Integer, ByVal chrInputChar As Char, ByRef strElem As StringBuilder, ByRef alParsedCsv As ArrayList)
		Dim strTemp As String = Nothing
		Select Case intCurrState
			Case 0
				'Separate out value to array list
				strTemp = strElem.ToString()
				alParsedCsv.Add(strTemp)
				strElem = New StringBuilder()

			Case 1, 3, 4
				'accumulate the character
				strElem.Append(chrInputChar)

			Case 5
				'End of line reached. Separate out value to array list
				strTemp = strElem.ToString()
				alParsedCsv.Add(strTemp)

			Case 6
				'Erroneous input. Reject line.
				alParsedCsv.Clear()

			Case 7
				'wipe ending " and Separate out value to array list
				strElem.Remove(strElem.Length - 1, 1)
				strTemp = strElem.ToString()
				alParsedCsv.Add(strTemp)
				strElem = New StringBuilder()
				intCurrState = 5

			Case 8
				'wipe ending " and Separate out value to array list
				strElem.Remove(strElem.Length - 1, 1)
				strTemp = strElem.ToString()
				alParsedCsv.Add(strTemp)
				strElem = New StringBuilder()
				intCurrState = 0
		End Select
	End Sub

	Private Sub QuoteSelectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuoteSelectionToolStripMenuItem.Click
		Dim selectedText As String = OriginalSourceTextBox.SelectedText
		Dim replacementText As String = """" + selectedText + """"
		OriginalSourceTextBox.SelectedText = replacementText
		OriginalSourceTextBox.SelectionLength = 0
		OriginalSourceTextBox.SelectionStart = 0
	End Sub

	Private Sub cmsOriginalSource_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsOriginalSource.Opening
		QuoteSelectionToolStripMenuItem.Enabled = OriginalSourceTextBox.SelectionLength <> 0
	End Sub
End Class
