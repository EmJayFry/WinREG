'	$Date: 2012-02-01 15:52:14 +0200 (Wed, 01 Feb 2012) $
'	$Rev: 147 $
'	$Id: dlgDateHelper.vb 147 2012-02-01 13:52:14Z Mikefry $
'
'	WinREG/3 - Version 3.1.8
'

Imports System.Windows.Forms
Imports System.Globalization
Imports System.Threading
Imports System.Text.RegularExpressions

Public Class dlgDateHelper
	Dim fRestoreComplete As Boolean = False

	Public _Date As DateHelperClass = New DateHelperClass

	Private dateEnteredWith As Date
	Private txtEnteredwith As String
	Private boolDay = False
	Private boolMonth = False
	Private boolYear = False

	Private Sub dlgDateHelper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		' Restore window state & position
		'		Me.Size = My.Settings.MyDatePickerSize
		Me.Location = My.Settings.MyDatePickerLocation
		Me.WindowState = My.Settings.MyDatePickerWindowState

		ttDateHelper.Active = My.Settings.MyDisplayTooltips
		If My.Settings.MyDisplayTooltips Then Me.ttDateHelper.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
		dpDate.Enabled = False
		dpDate.MaxDate = DateTime.Today
		txtEnteredwith = _Date.FieldText

		If txtEnteredwith = "" Then
			chkDateMissing.CheckState = CheckState.Unchecked
			chkDateUnreadable.CheckState = CheckState.Unchecked
			chkDayMissing.CheckState = CheckState.Unchecked
			chkDayUnreadable.CheckState = CheckState.Unchecked
			chkMonthMissing.CheckState = CheckState.Unchecked
			chkMonthUnreadable.CheckState = CheckState.Unchecked
			chkYearUnreadable.CheckState = CheckState.Unchecked

			txtDay.Text = ""
			txtDay.Enabled = True
			txtMonth.Text = ""
			txtMonth.Enabled = True
			txtYear.Text = ""
			txtYear.Enabled = True
			txtDateReturned.Text = ""
			txtDateReturned.Enabled = True
			Return
		End If

		If txtEnteredwith = "*" Then
			chkDateUnreadable.CheckState = CheckState.Checked
			Return
		End If

		Dim m As Match
		Dim r1 As New freereg.regex.rgxValidateDate
		'		Dim r As Regex = New Regex(My.Settings.rgxValidateDate, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
		m = r1.Match(txtEnteredwith)									' Check the validity of the date
		'		m = WinREG.MainForm.rgxValidateDate.Match(txtEnteredwith)				  ' Check the validity of the date

		If m.Success = True Then										' Badly formed dates are rejected as Unreadable (*)
			txtDay.Text = m.Groups.Item("days").Value().Trim()
			If txtDay.Text <> "" Then
				chkDayMissing.CheckState = CheckState.Unchecked
				If txtDay.Text = "*" Then chkDayUnreadable.CheckState = CheckState.Checked
			End If

			txtMonth.Text = m.Groups.Item("month").Value().Trim()
			If txtMonth.Text <> "" Then
				chkMonthMissing.CheckState = CheckState.Unchecked
				If txtMonth.Text = "*" Then chkMonthUnreadable.CheckState = CheckState.Checked
			End If

			txtYear.Text = m.Groups.Item("year").Value().Trim()
			If txtYear.Text = "*" Then chkYearUnreadable.CheckState = CheckState.Checked

			If txtYear.Text >= 1753 Then
				Dim dt As Date
				If DateTime.TryParse(txtEnteredwith, dt) Then
					dpDate.Value = dt
					dpDate.Visible = True
					dpDate.Enabled = True
				End If
			End If

			SetDateFlags()
			SetDoubleDating()
		Else
			Dim r2 As New freereg.regex.rgxValidateDoubleDate
			m = r2.Match(txtEnteredwith)									' Check the validity of the date
			'			m = WinREG.MainForm.rgxValidateDoubleDate.Match(txtEnteredwith)				 ' Check the validity of the date
			If m.Success = True Then
				txtDay.Text = m.Groups.Item("days").Value().Trim()
				If txtDay.Text <> "" Then
					chkDayMissing.CheckState = CheckState.Unchecked
					If txtDay.Text = "*" Then chkDayUnreadable.CheckState = CheckState.Checked
				End If

				txtMonth.Text = m.Groups.Item("month").Value().Trim()
				If txtMonth.Text <> "" Then
					chkMonthMissing.CheckState = CheckState.Unchecked
					If txtMonth.Text = "*" Then chkMonthUnreadable.CheckState = CheckState.Checked
				End If

				txtYear.Text = m.Groups.Item("year").Value().Trim()
				If txtYear.Text = "*" Then chkYearUnreadable.CheckState = CheckState.Checked

				If txtYear.Text >= 1753 Then
					Dim dt As Date
					If DateTime.TryParse(txtEnteredwith, dt) Then
						dpDate.Value = dt
						dpDate.Visible = True
						dpDate.Enabled = True
					End If
				End If

				SetDateFlags()
				SetDoubleDating()
			Else
				'
				'	Date is invalid, but... can we make some sort of sense of what's been entered
				'	before we declare it unreadable.
				'
				'	How many components does it have: split the date up by spaces and slashes
				'
				Dim el() As String = txtEnteredwith.Split(New [Char]() {" "c, "/"c})

				If el.Length = 3 Then
					txtDay.Text = el(0)
					txtMonth.Text = el(1)
					txtYear.Text = el(2)
				ElseIf el.Length = 4 Then
					txtDay.Text = el(0)
					txtMonth.Text = el(1)
					txtYear.Text = el(2) & "/" & el(3)
				Else
					chkDateUnreadable.CheckState = CheckState.Checked
				End If

			End If
		End If

	End Sub

	Private Sub dlgDateHelper_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		My.Settings.MyDatePickerWindowState = Me.WindowState

		If Me.WindowState = FormWindowState.Normal Then
			'			My.Settings.MyDatePickerSize = Me.Size
			My.Settings.MyDatePickerLocation = Me.Location
		Else
			'			My.Settings.MyDatePickerSize = Me.RestoreBounds.Size
			My.Settings.MyDatePickerLocation = Me.RestoreBounds.Location
		End If
		My.Settings.Save()
	End Sub

	Private Sub chkDateMissing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateMissing.CheckedChanged
		If chkDateMissing.CheckState = CheckState.Checked Then
			grpDateComponents.Enabled = False
			chkDateUnreadable.Enabled = False
			txtDay.Text = ""
			txtMonth.Text = ""
			txtYear.Text = ""
			txtDateReturned.Text = ""
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		grpDateComponents.Enabled = True
		chkDateUnreadable.Enabled = True

		If txtEnteredwith = "" Then
			txtDay.Text = ""
			txtMonth.Text = ""
			txtYear.Text = ""
			txtDateReturned.Text = ""
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		Dim m As Match
		Dim r As New freereg.regex.rgxValidateDate
		'		Dim r As Regex = New Regex(My.Settings.rgxValidateDate, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
		m = r.Match(txtEnteredwith)									' Check the validity of the date
		'		m = WinREG.MainForm.rgxValidateDate.Match(txtEnteredwith)					' Check the validity of the date

		If m.Success = False Then										' Badly formed dates are rejected as Unreadable (*)
			chkDateUnreadable.CheckState = CheckState.Checked
		Else
			txtDay.Text = m.Groups.Item("days").Value().Trim()
			If txtDay.Text = "" Then
				txtDay.Enabled = False
			Else
				If txtDay.Text = "*" Then
					txtDay.Text = ""
				End If
			End If

			txtMonth.Text = m.Groups.Item("month").Value().Trim()
			If txtMonth.Text = "" Then
				txtMonth.Enabled = False
			Else
				If txtMonth.Text = "*" Then
					txtMonth.Text = ""
				End If
			End If

			txtYear.Text = m.Groups.Item("year").Value().Trim()
			If txtYear.Text = "" Or txtYear.Text = "*" Then
				chkYearUnreadable.CheckState = CheckState.Checked
			Else
				chkYearUnreadable.CheckState = CheckState.Unchecked
			End If

			SetDateFlags()
			SetDoubleDating()

		End If


	End Sub

	Private Sub chkDateUnreadable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateUnreadable.CheckedChanged
		If chkDateUnreadable.CheckState = CheckState.Checked Then
			chkDateMissing.Enabled = False
			grpDateComponents.Enabled = False
			txtDay.Text = ""
			txtMonth.Text = ""
			txtYear.Text = ""
			txtDateReturned.Text = "*"
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		chkDateMissing.Enabled = True
		grpDateComponents.Enabled = True

		If txtEnteredwith = "" Then
			txtDay.Text = ""
			txtMonth.Text = ""
			txtYear.Text = ""
			txtDateReturned.Text = ""
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		Dim m As Match
		'		Dim r As Regex = New Regex(My.Settings.rgxValidateDate, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
		Dim r As New freereg.regex.rgxValidateDate
		m = r.Match(txtEnteredwith)									' Check the validity of the date
		'		m = WinREG.MainForm.rgxValidateDate.Match(txtEnteredwith)					' Check the validity of the date

		If m.Success = False Then										' Badly formed dates are rejected as Unreadable (*)
			chkDateUnreadable.CheckState = CheckState.Checked
		Else
			txtDay.Text = m.Groups.Item("days").Value().Trim()
			If txtDay.Text = "" Then
				txtDay.Enabled = False
			Else
				If txtDay.Text = "*" Then
					txtDay.Text = ""
				End If
			End If

			txtMonth.Text = m.Groups.Item("month").Value().Trim()
			If txtMonth.Text = "" Then
				txtMonth.Enabled = False
			Else
				If txtMonth.Text = "*" Then
					txtMonth.Text = ""
				End If
			End If

			txtYear.Text = m.Groups.Item("year").Value().Trim()
			If txtYear.Text = "" Or txtYear.Text = "*" Then
				chkYearUnreadable.CheckState = CheckState.Checked
			Else
				chkYearUnreadable.CheckState = CheckState.Unchecked
			End If

			SetDateFlags()
			SetDoubleDating()

		End If

	End Sub

	Private Sub chkDayMissing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDayMissing.CheckedChanged
		If chkDayMissing.CheckState = CheckState.Checked Then
			chkDayUnreadable.CheckState = CheckState.Unchecked
			chkDayUnreadable.Enabled = False
			txtDay.Enabled = False
			txtDay.Text = ""
			SetDateFlags()
			SetDoubleDating()
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		chkDayUnreadable.CheckState = CheckState.Unchecked
		chkDayUnreadable.Enabled = True
		txtDay.Enabled = True

		If txtEnteredwith = "" Then
			txtDay.Text = ""
			txtMonth.Text = ""
			txtYear.Text = ""
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		Dim m As Match
		'		Dim r As Regex = New Regex(My.Settings.rgxValidateDate, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
		Dim r As New freereg.regex.rgxValidateDate
		m = r.Match(txtEnteredwith)									' Check the validity of the date
		'		m = WinREG.MainForm.rgxValidateDate.Match(txtEnteredwith)					' Check the validity of the date

		If m.Success = False Then										' Badly formed dates are rejected as Unreadable (*)
			chkDateUnreadable.CheckState = CheckState.Checked
		Else
			txtDay.Text = m.Groups.Item("days").Value().Trim()
			If txtDay.Text = "" Then
			Else
				If txtDay.Text = "*" Then
					txtDay.Text = ""
				End If
			End If

			txtMonth.Text = m.Groups.Item("month").Value().Trim()
			If txtMonth.Text = "" Then
			Else
				If txtMonth.Text = "*" Then
					txtMonth.Text = ""
				End If
			End If

			txtYear.Text = m.Groups.Item("year").Value().Trim()
			If txtYear.Text = "" Or txtYear.Text = "*" Then
				chkYearUnreadable.CheckState = CheckState.Checked
			Else
				chkYearUnreadable.CheckState = CheckState.Unchecked
			End If

			SetDateFlags()
			SetDoubleDating()

		End If

	End Sub

	Private Sub chkDayUnreadable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDayUnreadable.CheckedChanged
		If chkDayUnreadable.CheckState = CheckState.Checked Then
			chkDayMissing.CheckState = CheckState.Unchecked
			chkDayMissing.Enabled = False
			txtDay.Text = "*"
			txtDateReturned.Text = Trim(txtDay.Text + " " + txtMonth.Text + " " + txtYear.Text)
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		chkDayMissing.CheckState = CheckState.Unchecked
		chkDayMissing.Enabled = True
		txtDay.Enabled = True

		If txtEnteredwith = "" Then
			txtDay.Text = ""
			txtMonth.Text = ""
			txtYear.Text = ""
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		Dim m As Match
		'		Dim r As Regex = New Regex(My.Settings.rgxValidateDate, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
		Dim r As New freereg.regex.rgxValidateDate
		m = r.Match(txtEnteredwith)									' Check the validity of the date
		'		m = WinREG.MainForm.rgxValidateDate.Match(txtEnteredwith)					' Check the validity of the date

		If m.Success = False Then										' Badly formed dates are rejected as Unreadable (*)
			chkDateUnreadable.CheckState = CheckState.Checked
		Else
			txtDay.Text = m.Groups.Item("days").Value().Trim()
			If txtDay.Text = "" Then
			Else
				If txtDay.Text = "*" Then
					txtDay.Text = ""
				End If
			End If

			txtMonth.Text = m.Groups.Item("month").Value().Trim()
			If txtMonth.Text = "" Then
			Else
				If txtDay.Text = "*" Then
					txtDay.Text = ""
				End If
			End If

			txtYear.Text = m.Groups.Item("year").Value().Trim()
			If txtYear.Text = "" Or txtYear.Text = "*" Then
				chkYearUnreadable.CheckState = CheckState.Checked
			Else
				chkYearUnreadable.CheckState = CheckState.Unchecked
			End If

			SetDateFlags()
			SetDoubleDating()

		End If

	End Sub

	Private Sub chkMonthMissing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMonthMissing.CheckedChanged
		If chkMonthMissing.CheckState = CheckState.Checked Then
			chkMonthUnreadable.CheckState = CheckState.Unchecked
			chkMonthUnreadable.Enabled = False
			txtMonth.Enabled = False
			If Not txtDay.Text = "" Then
				txtMonth.Text = "*"
			Else
				txtMonth.Text = ""
			End If
			txtDateReturned.Text = Trim(txtDay.Text + " " + txtMonth.Text + " " + txtYear.Text)
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		chkMonthUnreadable.CheckState = CheckState.Unchecked
		chkMonthUnreadable.Enabled = True
		txtMonth.Enabled = True

		If txtEnteredwith = "" Then
			txtDay.Text = ""
			txtMonth.Text = ""
			txtYear.Text = ""
			txtDateReturned.Text = ""
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		Dim m As Match
		'		Dim r As Regex = New Regex(My.Settings.rgxValidateDate, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
		Dim r As New freereg.regex.rgxValidateDate
		m = r.Match(txtEnteredwith)									' Check the validity of the date
		'		m = WinREG.MainForm.rgxValidateDate.Match(txtEnteredwith)					' Check the validity of the date

		If m.Success = False Then										' Badly formed dates are rejected as Unreadable (*)
			chkDateUnreadable.CheckState = CheckState.Checked
		Else
			txtDay.Text = m.Groups.Item("days").Value().Trim()
			If txtDay.Text = "" Then
			Else
				If txtDay.Text = "*" Then
					txtDay.Text = ""
				End If
			End If

			txtMonth.Text = m.Groups.Item("month").Value().Trim()
			If txtMonth.Text = "" Then
			Else
				If txtMonth.Text = "*" Then
					txtMonth.Text = ""
				End If
			End If

			txtYear.Text = m.Groups.Item("year").Value().Trim()
			If txtYear.Text = "" Or txtYear.Text = "*" Then
				chkYearUnreadable.CheckState = CheckState.Checked
			Else
				chkYearUnreadable.CheckState = CheckState.Unchecked
			End If

			SetDateFlags()
			SetDoubleDating()

		End If

	End Sub

	Private Sub chkMonthUnreadable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMonthUnreadable.CheckedChanged
		If chkMonthUnreadable.CheckState = CheckState.Checked Then
			chkMonthMissing.CheckState = CheckState.Unchecked
			chkMonthMissing.Enabled = False
			txtMonth.Text = "*"
			txtDateReturned.Text = Trim(txtDay.Text + " " + txtMonth.Text + " " + txtYear.Text)
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		chkMonthMissing.CheckState = CheckState.Unchecked
		chkMonthMissing.Enabled = True

		If txtEnteredwith = "" Then
			txtDay.Text = ""
			txtMonth.Text = ""
			txtYear.Text = ""
			txtDateReturned.Text = ""
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		Dim m As Match
		'		Dim r As Regex = New Regex(My.Settings.rgxValidateDate, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
		Dim r As New freereg.regex.rgxValidateDate
		m = r.Match(txtEnteredwith)									' Check the validity of the date
		'		m = WinREG.MainForm.rgxValidateDate.Match(txtEnteredwith)					' Check the validity of the date

		If m.Success = False Then										' Badly formed dates are rejected as Unreadable (*)
			chkDateUnreadable.CheckState = CheckState.Checked
		Else
			txtDay.Text = m.Groups.Item("days").Value().Trim()
			If txtDay.Text = "" Then
			Else
				If txtDay.Text = "*" Then
					txtDay.Text = ""
				End If
			End If

			txtMonth.Text = m.Groups.Item("month").Value().Trim()
			If txtMonth.Text = "" Then
			Else
				If txtMonth.Text = "*" Then
					txtMonth.Text = ""
				End If
			End If

			txtYear.Text = m.Groups.Item("year").Value().Trim()
			If txtYear.Text = "" Or txtYear.Text = "*" Then
				chkYearUnreadable.CheckState = CheckState.Checked
			Else
				chkYearUnreadable.CheckState = CheckState.Unchecked
			End If

			SetDateFlags()
			SetDoubleDating()

		End If

	End Sub

	Private Sub chkYearUnreadable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYearUnreadable.CheckedChanged
		If chkYearUnreadable.CheckState = CheckState.Checked Then
			txtYear.Text = "*"
			txtDateReturned.Text = Trim(txtDay.Text + " " + txtMonth.Text + " " + txtYear.Text)
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		If txtEnteredwith = "" Then
			txtDay.Text = ""
			txtMonth.Text = ""
			txtYear.Text = ""
			txtDateReturned.Text = ""
			txtEnteredwith = txtDateReturned.Text
			Return
		End If

		Dim m As Match
		'		Dim r As Regex = New Regex(My.Settings.rgxValidateDate, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
		Dim r As New freereg.regex.rgxValidateDate
		m = r.Match(txtEnteredwith)									' Check the validity of the date
		'		m = WinREG.MainForm.rgxValidateDate.Match(txtEnteredwith)					' Check the validity of the date

		If m.Success = False Then										' Badly formed dates are rejected as Unreadable (*)
			chkDateUnreadable.CheckState = CheckState.Checked
		Else
			txtDay.Text = m.Groups.Item("days").Value().Trim()
			If txtDay.Text = "" Then
			Else
				If txtDay.Text = "*" Then
					txtDay.Text = ""
				End If
			End If

			txtMonth.Text = m.Groups.Item("month").Value().Trim()
			If txtMonth.Text = "" Then
			Else
				If txtMonth.Text = "*" Then
					txtMonth.Text = ""
				End If
			End If

			txtYear.Text = m.Groups.Item("year").Value().Trim()
			If txtYear.Text = "" Or txtYear.Text = "*" Then
				chkYearUnreadable.CheckState = CheckState.Checked
			Else
				chkYearUnreadable.CheckState = CheckState.Unchecked
			End If

			SetDateFlags()
			SetDoubleDating()

		End If

	End Sub

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		_Date.FieldText = Trim(txtDateReturned.Text)
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub txtDay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDay.Validating
		If Me.txtDay.IsValid Or txtDay.Text = "" Then
			errDateHelper.SetError(Me.txtDay, "")
		Else
			errDateHelper.SetError(Me.txtDay, "Day number is invalid")
		End If
	End Sub

	Private Sub txtDay_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDay.Validated
		If boolMonth = True And boolYear = True Then
		Else
			boolDay = False
		End If

		SetDateFlags()
		SetDoubleDating()

	End Sub

	Private Sub txtMonth_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMonth.Validating
		If Me.txtMonth.IsValid Or txtMonth.Text = "" Then
			errDateHelper.SetError(Me.txtMonth, "")
		Else
			errDateHelper.SetError(Me.txtMonth, "Month abbreviation is invalid")
		End If
	End Sub

	Private Sub txtMonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonth.Validated
		Dim ci As CultureInfo = Thread.CurrentThread.CurrentCulture
		Dim ti As TextInfo = ci.TextInfo
		txtMonth.Text = ti.ToTitleCase(txtMonth.Text)

		If txtMonth.Text = "Jan" Or txtMonth.Text = "Feb" Or txtMonth.Text = "Mar" Then
			boolMonth = True
		Else
			boolMonth = False
		End If

		SetDateFlags()
		SetDoubleDating()

	End Sub

	Private Sub txtYear_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtYear.Validating
		If Me.txtYear.IsValid Then
			errDateHelper.SetError(Me.txtYear, "")
		Else
			errDateHelper.SetError(Me.txtYear, "Year number is invalid")
		End If
	End Sub

	Private Sub txtYear_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYear.Validated
		Try
			If CInt(txtYear.Text) <= 1751 Then
				boolYear = True
			Else
				boolYear = False
			End If

		Catch ex As Exception
			boolYear = False
		End Try

		SetDateFlags()
		SetDoubleDating()

	End Sub

	Private Sub SetDateFlags()
		Try
			If CInt(txtYear.Text) <= 1751 Then
				boolYear = True
				If txtMonth.Text = "Jan" Or txtMonth.Text = "jan" Then
					boolMonth = True
					Try
						If CInt(txtDay.Text) <= 31 Then
							boolDay = True
						Else
							boolDay = False
						End If

					Catch ex As Exception
						boolDay = True
					End Try
				Else
					If txtMonth.Text = "Feb" Or txtMonth.Text = "feb" Then
						boolMonth = True
						Try
							If CInt(txtDay.Text) <= 29 Then
								boolDay = True
							Else
								boolDay = False
							End If

						Catch ex As Exception
							boolDay = True
						End Try
					Else
						If txtMonth.Text = "Mar" Or txtMonth.Text = "mar" Then
							boolMonth = True
							Try
								If CInt(txtDay.Text) <= 24 Then
									boolDay = True
								Else
									boolDay = False
								End If

							Catch ex As Exception
								boolDay = True
							End Try
						Else
							boolMonth = False
						End If
					End If
				End If
			Else
				boolYear = False
			End If

		Catch ex As Exception
			boolYear = False
		End Try

	End Sub

	Private Sub SetDoubleDating()
		If boolDay And boolMonth And boolYear Then
			Dim i As Integer = CInt(txtYear.Text) Mod 100
			If i = 99 Then
				txtDateReturned.Text = Trim(txtDay.Text + " " + txtMonth.Text + " " + txtYear.Text + "/00")
			Else
				i = i Mod 10
				If i = 9 Then
					i = CInt(txtYear.Text) Mod 100
				End If
				txtDateReturned.Text = Trim(txtDay.Text + " " + txtMonth.Text + " " + txtYear.Text + "/" + CStr(i + 1))
			End If
		Else
			txtDateReturned.Text = Trim(txtDay.Text + " " + txtMonth.Text + " " + txtYear.Text)
		End If

		txtEnteredwith = txtDateReturned.Text
	End Sub

	Private Sub dpDate_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpDate.CloseUp
		Dim dt = dpDate.Value

		txtDateReturned.Text = Format(dt, "dd MMM yyyy")

		txtDay.Text = dt.Day
		txtMonth.Text = Format(dt, "MMM")
		txtYear.Text = dt.Year
		SetDateFlags()
		SetDoubleDating()
	End Sub

End Class
