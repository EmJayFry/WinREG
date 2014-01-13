Imports System.Windows.Forms

Public Class dlgEditAutoCompletionList

	Public acs As AutoCompleteStringCollection = Nothing

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

	Private Sub dlgEditAutoCompletionList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		cbList.BeginUpdate()
		For Each strAuto As String In acs
			cbList.Items.Add(strAuto)
		Next
		cbList.EndUpdate()
	End Sub

	Private Sub dlgEditAutoCompletionList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
		If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
			acs.Clear()
			For Each strnew As String In cbList.Items
				acs.Add(strnew)
			Next
		End If
	End Sub

	Private Sub bfnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		If cbList.Text <> "" Then cbList.Items.Add(cbList.Text)
	End Sub

	Private Sub cbList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbList.SelectedIndexChanged
		btnRemove.Enabled = cbList.SelectedIndex <> -1
		btnChange.Enabled = cbList.SelectedIndex <> -1
	End Sub

	Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
		If cbList.SelectedIndex <> -1 Then
			Dim txt = cbList.SelectedItem
			Dim area As String = ""
			If Me.Text = "Abodes Autocompletion List" Then
				area = "Abodes or Parishes"
			Else
				area = "Occupations"
			End If
			If MessageBox.Show(String.Format(My.Resources.msgClearTableEntries, txt, area), "Remove AutoCompletion Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
				For Each row In WinREG.MainForm.mainDGV.Rows
					Select Case Me.Text
						Case "Abodes Autocompletion List"
							Select Case WinREG.MainForm._File.FileType
								Case "BAPTISMS"
									If row.Cells("Abode").Value = txt Then
										row.Cells("Abode").Value = ""
									End If

								Case "BURIALS"
									If row.Cells("Abode").Value = txt Then
										row.Cells("Abode").Value = ""
									End If

								Case "MARRIAGES"
									If row.Cells("GroomParish").Value = txt Then
										row.Cells("GroomParish").Value = ""
									End If
									If row.Cells("GroomAbode").Value = txt Then
										row.Cells("GroomAbode").Value = ""
									End If
									If row.Cells("BrideParish").Value = txt Then
										row.Cells("BrideParish").Value = ""
									End If
									If row.Cells("BrideAbode").Value = txt Then
										row.Cells("BrideAbode").Value = ""
									End If

							End Select

						Case "Occupations Autocompletion List"
							Select Case WinREG.MainForm._File.FileType
								Case "BAPTISMS"
									If row.Cells("FathersOccupation").Value = txt Then
										row.Cells("FathersOccupation").Value = ""
									End If

								Case "BURIALS"

								Case "MARRIAGES"
									If row.Cells("GroomOccupation").Value = txt Then
										row.Cells("GroomOccupation").Value = ""
									End If
									If row.Cells("BrideOccupation").Value = txt Then
										row.Cells("BrideOccupation").Value = ""
									End If
									If row.Cells("GroomFatherOccupation").Value = txt Then
										row.Cells("GroomFatherOccupation").Value = ""
									End If
									If row.Cells("BrideFatherOccupation").Value = txt Then
										row.Cells("BrideFatherOccupation").Value = ""
									End If

							End Select

					End Select
				Next
			End If

			cbList.Items.RemoveAt(cbList.SelectedIndex)
			btnAdd.Enabled = False
			btnRemove.Enabled = False
			btnChange.Enabled = False
			cbList.Text = ""
		End If
	End Sub

	Private Sub cbList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbList.TextChanged
		If cbList.Text <> "" Then
			If cbList.Items.Contains(cbList.Text) Then
				btnAdd.Enabled = False
				btnRemove.Enabled = True
				btnChange.Enabled = True
				cbList.SelectedItem = cbList.Text
			Else
				btnAdd.Enabled = True
				btnRemove.Enabled = False
				btnChange.Enabled = False
			End If
		Else
			btnAdd.Enabled = False
			btnRemove.Enabled = False
			btnChange.Enabled = False
		End If
	End Sub

	Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
		If cbList.SelectedIndex <> -1 Then
			Dim txt = cbList.SelectedItem
			Dim dlg As New dlgEditAutoCompletionEntry
			dlg.Label1.Text = "Current value: " + txt
			dlg.TextBox1.Text = txt
			Dim rc = dlg.ShowDialog()
			If rc = Windows.Forms.DialogResult.OK AndAlso dlg.TextBox1.Text <> "" AndAlso txt <> dlg.TextBox1.Text Then
				cbList.Items(cbList.SelectedIndex) = dlg.strNew

				If MessageBox.Show(String.Format(My.Resources.msgUpdateTableEntries, txt, dlg.strNew), "Change AutoCompletion Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
					For Each row In WinREG.MainForm.mainDGV.Rows
						Select Case Me.Text
							Case "Abodes Autocompletion List"
								Select Case WinREG.MainForm._File.FileType
									Case "BAPTISMS"
										If row.Cells("Abode").Value = txt Then
											row.Cells("Abode").Value = dlg.strNew
										End If

									Case "BURIALS"
										If row.Cells("Abode").Value = txt Then
											row.Cells("Abode").Value = dlg.strNew
										End If

									Case "MARRIAGES"
										If row.Cells("GroomParish").Value = txt Then
											row.Cells("GroomParish").Value = dlg.strNew
										End If
										If row.Cells("GroomAbode").Value = txt Then
											row.Cells("GroomAbode").Value = dlg.strNew
										End If
										If row.Cells("BrideParish").Value = txt Then
											row.Cells("BrideParish").Value = dlg.strNew
										End If
										If row.Cells("BrideAbode").Value = txt Then
											row.Cells("BrideAbode").Value = dlg.strNew
										End If

								End Select

							Case "Occupations Autocompletion List"
								Select Case WinREG.MainForm._File.FileType
									Case "BAPTISMS"
										If row.Cells("FathersOccupation").Value = txt Then
											row.Cells("FathersOccupation").Value = dlg.strNew
										End If

									Case "BURIALS"

									Case "MARRIAGES"
										If row.Cells("GroomOccupation").Value = txt Then
											row.Cells("GroomOccupation").Value = dlg.strNew
										End If
										If row.Cells("BrideOccupation").Value = txt Then
											row.Cells("BrideOccupation").Value = dlg.strNew
										End If
										If row.Cells("GroomFatherOccupation").Value = txt Then
											row.Cells("GroomFatherOccupation").Value = dlg.strNew
										End If
										If row.Cells("BrideFatherOccupation").Value = txt Then
											row.Cells("BrideFatherOccupation").Value = dlg.strNew
										End If

								End Select

						End Select
					Next
				End If
			End If

			btnAdd.Enabled = False
			btnRemove.Enabled = False
			btnChange.Enabled = False
			cbList.SelectedIndex = -1
			cbList.Text = ""
		End If
	End Sub
End Class
