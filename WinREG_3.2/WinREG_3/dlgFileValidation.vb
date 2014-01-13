'	$Date: 2013-12-07 23:58:37 +0200 (Sat, 07 Dec 2013) $
'	$Rev: 282 $
'	$Id: dlgFileValidation.vb 282 2013-12-07 21:58:37Z Mikefry $
'
'	WinREG/3 - Version 3.1.17
'

Imports System.ComponentModel
Imports WinREG.LookupTables

Public Class dlgFileValidation
	Public dgv As DataGridView
	Public _File As WinREG.MainForm.FileHeader
	Public tabBaptismSex As BaptismSexDataTable
	Public tabBurialRelationships As BurialRelationshipDataTable
	Public tabMarriageGroomConditions As GroomConditionDataTable
	Public tabMarriageBrideConditions As BrideConditionDataTable

	Dim numErrors As Integer = 0

	Private Sub dlgFileValidation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Me.Text &= " - " & _File.Filename
		pbProgress.Minimum = 0
		pbProgress.Maximum = dgv.RowCount
		lblErrors.Text = String.Format("Errors found {0}", numErrors)
	End Sub

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.bwValidateFile.RunWorkerAsync()
		OK_Button.Enabled = False
		Cancel_Button.Enabled = True
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.bwValidateFile.CancelAsync()
	End Sub

	Private Sub bwValidateFile_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwValidateFile.DoWork
		' Do not access the form's BackgroundWorker reference directly.
		' Instead, use the reference provided by the sender parameter.
		Dim bw As BackgroundWorker = CType(sender, BackgroundWorker)

		' Start the time-consuming operation.
		e.Result = ValidateFile(bw, e)

	End Sub

	Private Sub bwValidateFile_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwValidateFile.RunWorkerCompleted
		If e.Cancelled Then
			' The user canceled the operation.
			MessageBox.Show("Operation was canceled", "Validate Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		ElseIf (e.Error IsNot Nothing) Then
			' There was an error during the operation.
			Dim msg As String = String.Format("An error occurred: {0}", e.Error.Message)
			MessageBox.Show(msg, "Validate Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Else
			Dim numErrors As Integer = CType(e.Result, Integer)
			' The operation completed normally.
			If numErrors > 0 Then
				If numErrors = 1 Then
					MessageBox.Show("There is " & numErrors.ToString() & " error in various records.", "Validate Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					MessageBox.Show("There are " & numErrors.ToString() & " errors in various records.", "Validate Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			Else
				MessageBox.Show("No errors were detected in this file.", "Validate Records", MessageBoxButtons.OK)
			End If

			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End If
		'Me.Close()
	End Sub

	Private Sub bwValidateFile_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwValidateFile.ProgressChanged
		pbProgress.Value = e.ProgressPercentage
		lblErrors.Text = String.Format("Errors found {0}", numErrors)
	End Sub

	Private Function ValidateFile(ByVal bw As BackgroundWorker, ByVal e As DoWorkEventArgs) As Integer
		Dim strErrMessage As String = ""
		Dim s As Integer = 0
		Dim str As String = ""
		Dim strAge As String = ""
		Dim strBits(4) As String

		For Each row As DataGridViewRow In dgv.Rows
			s += 1
			Select Case _File.FileType
				Case "BAPTISMS"
					If row.DataBoundItem.row.HasErrors Then
						numErrors += 1
					Else
						If Not IsDBNull(row.Cells("BirthDate").Value) Then
							If Not Validations.ValidateDate(row.Cells("BirthDate").Value, strErrMessage, strBits) Then
								row.Cells("BirthDate").ErrorText = strErrMessage
								numErrors += 1
							Else
								row.Cells("BirthDate").ErrorText = String.Empty
							End If
						End If

						If Not IsDBNull(row.Cells("BaptismDate").Value) Then
							If Not Validations.ValidateDate(row.Cells("BaptismDate").Value, strErrMessage, strBits) Then
								row.Cells("BaptismDate").ErrorText = strErrMessage
								numErrors += 1
							Else
								row.Cells("BaptismDate").ErrorText = String.Empty
							End If
						End If

						str = ""
						If row.Cells("Sex").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Sex").Value.ToString()) Then str = row.Cells("Sex").Value.ToString()
						If Not tabBaptismSex.Rows.Contains(str) Then
							row.Cells("Sex").ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Baptism Sex")
							numErrors += 1
						Else
							row.Cells("Sex").ErrorText = String.Empty
							row.Cells("Sex").Value = str
						End If
					End If

				Case "BURIALS"
					If row.DataBoundItem.row.HasErrors Then
						numErrors += 1
					Else
						If Not IsDBNull(row.Cells("BurialDate").Value) Then
							If Not Validations.ValidateDate(row.Cells("BurialDate").Value, strErrMessage, strBits) Then
								row.Cells("BurialDate").ErrorText = strErrMessage
								numErrors += 1
							Else
								row.Cells("BurialDate").ErrorText = String.Empty
							End If
						End If

						strAge = ""
						If Not IsDBNull(row.Cells("Age").EditedFormattedValue.ToString()) Then strAge = row.Cells("Age").EditedFormattedValue.ToString()
						strErrMessage = String.Empty
						If Not Validations.ValidateBurialAge(strAge, strErrMessage, True) Then
							' TODO: The over-100 message and condition is not really an error. Use a different warning-type icon
							row.Cells("Age").ErrorText = strErrMessage
							numErrors += 1
						Else
							row.Cells("Age").ErrorText = String.Empty
						End If

						str = ""
						If row.Cells("Relationship").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Relationship").Value.ToString()) Then str = row.Cells("Relationship").Value.ToString()
						If Not tabBurialRelationships.Rows.Contains(str) Then
							row.Cells("Relationship").ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Burial Relationship")
							numErrors += 1
						Else
							row.Cells("Relationship").ErrorText = String.Empty
							row.Cells("Relationship").Value = str
						End If
					End If

				Case "MARRIAGES"
					If row.DataBoundItem.row.HasErrors Then
						numErrors += 1
					Else
						If Not IsDBNull(row.Cells("MarriageDate").Value) Then
							If Not Validations.ValidateDate(row.Cells("MarriageDate").Value, strErrMessage, strBits) Then
								row.Cells("MarriageDate").ErrorText = strErrMessage
								numErrors += 1
							Else
								row.Cells("MarriageDate").ErrorText = String.Empty
							End If
						End If

						strAge = ""
						If Not IsDBNull(row.Cells("BrideAge").FormattedValue.ToString()) Then strAge = row.Cells("BrideAge").FormattedValue.ToString()
						strErrMessage = String.Empty
						If Not Validations.ValidateBrideAge(strAge, strErrMessage, True) Then
							row.Cells("BrideAge").ErrorText = strErrMessage
							numErrors += 1
						Else
							row.Cells("BrideAge").ErrorText = String.Empty
						End If

						str = ""
						If row.Cells("BrideCondition").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("BrideCondition").Value.ToString()) Then str = row.Cells("BrideCondition").Value.ToString()
						If Not tabMarriageBrideConditions.Rows.Contains(str) Then
							row.Cells("BrideCondition").ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Bride Conditions")
							numErrors += 1
						Else
							row.Cells("BrideCondition").ErrorText = String.Empty
							row.Cells("BrideCondition").Value = str
						End If

						strAge = ""
						If Not IsDBNull(row.Cells("GroomAge").FormattedValue.ToString()) Then strAge = row.Cells("GroomAge").FormattedValue.ToString()
						strErrMessage = String.Empty
						If Not Validations.ValidateGroomAge(strAge, strErrMessage, True) Then
							row.Cells("GroomAge").ErrorText = strErrMessage
							numErrors += 1
						Else
							row.Cells("GroomAge").ErrorText = String.Empty
						End If

						str = ""
						If row.Cells("GroomCondition").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("GroomCondition").Value.ToString()) Then str = row.Cells("GroomCondition").Value.ToString()
						If Not tabMarriageGroomConditions.Rows.Contains(str) Then
							row.Cells("GroomCondition").ErrorText = String.Format("The value '{0}' is not present in the {1} table", str, "Groom Conditions")
							numErrors += 1
						Else
							row.Cells("GroomCondition").ErrorText = String.Empty
							row.Cells("GroomCondition").Value = str
						End If
					End If

			End Select

			' If the operation was canceled by the user, 
			' set the DoWorkEventArgs.Cancel property to true.
			If bw.CancellationPending Then
				e.Cancel = True
				Exit For
			End If

			' Report progress as a percentage of the total task.
			bw.ReportProgress(s)
		Next

		Return numErrors
	End Function
End Class
