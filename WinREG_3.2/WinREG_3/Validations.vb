'	$Date: 2013-12-22 00:36:27 +0200 (Sun, 22 Dec 2013) $
'	$Rev: 298 $
'	$Id: Validations.vb 298 2013-12-21 22:36:27Z Mikefry $
'
'	WinREG/3 - Version 3.2.1
'

Imports WinREG.MessageBoxes
Imports System.Text.RegularExpressions
Imports System.Globalization

Public NotInheritable Class Validations
	Private Sub New()
	End Sub

	Public Shared Function ValidateDate(ByRef strToValidate As String, ByRef strErrMessage As String, ByRef strBits As String()) As Boolean
		Dim e As Boolean

		strErrMessage = ""

		If strToValidate = "" Then											' Empty dates are valid
			e = True
			Return True
		ElseIf strToValidate = "*" Then									' .. so is a single *
			e = True
			Return True
		End If

		' Validate the format of a Date using a Regular Expression
		'
		Dim m As Match

		Dim r1 = New freereg.regex.rgxValidateDate
		m = r1.Match(strToValidate)
		'		m = rgxValidateDate.Match(strToValidate)
		If m.Success = False Then											' Badly formed dates are rejected
			Dim r2 = New freereg.regex.rgxValidateDoubleDate
			m = r2.Match(strToValidate)
			'			m = rgxValidateDoubleDate.Match(strToValidate)
			If m.Success = False Then										' Badly formed dates are rejected
				strErrMessage = My.Resources.err0011
				e = False
				Return False
			End If
		End If

		' At this point, it would seem that the entered date is at least in an acceptable format
		'
		' What we have to do now is check that each component of the date is valid and that the
		' components are, when taken together, valid.
		'
		Dim dd As String, mmm As String, yy As String, zz As String, sep1 As String, sep2 As String, strToReplace As String
		Const delim As String = "- /."
		Dim fValidYear As Boolean = False, fValidMonth As Boolean = False, fValidDay As Boolean = False

		dd = m.Groups.Item("days").Value().Trim()
		sep1 = m.Groups.Item("sep1").Value().Trim()
		mmm = m.Groups.Item("month").Value().Trim(delim.ToCharArray())
		sep2 = m.Groups.Item("sep2").Value().Trim()
		yy = m.Groups.Item("year").Value().Trim()
		zz = m.Groups.Item("newyear").Value().Trim()
		e = True																		' At this point, the date appears to be valid

		' If separators are used, they should be consistent
		'
		If sep1 IsNot Nothing AndAlso sep2 IsNot Nothing Then
			If sep1 <> sep2 Then
				strErrMessage = My.Resources.err0039
				e = False
				Return False
			End If
		End If

		strBits(1) = dd
		strBits(2) = mmm
		strBits(3) = yy
		strBits(4) = zz

		' Validate the month component and convert it to the common Mmm format
		'
		If mmm <> "" Then
			If mmm <> "*" Then													' Month can be * in which case it's valid
				fValidMonth = True
				Dim dnum As Integer
				If Int32.TryParse(mmm, dnum) Then
					Select Case dnum
						Case 1
							mmm = "Jan"
						Case 2
							mmm = "Feb"
						Case 3
							mmm = "Mar"
						Case 4
							mmm = "Apr"
						Case 5
							mmm = "May"
						Case 6
							mmm = "Jun"
						Case 7
							mmm = "Jul"
						Case 8
							mmm = "Aug"
						Case 9
							mmm = "Sep"
						Case 10
							mmm = "Oct"
						Case 11
							mmm = "Nov"
						Case 12
							mmm = "Dec"
						Case Else
							strErrMessage = My.Resources.err0013
							e = False												' Just in case!
					End Select
				Else
					If mmm = "" Then
						strToReplace = ""
					Else
						If mmm.Length < 3 Then
							strErrMessage = My.Resources.err0014
							e = False												' Just in case!
						End If

						strToReplace = UCase(Microsoft.VisualBasic.Left(mmm, 1)) & LCase(Microsoft.VisualBasic.Mid(mmm, 2, 2))
					End If
					mmm = strToReplace
				End If
				strBits(2) = mmm
			End If
		End If
		If Not e Then Return False ' Date was invalid

		' Validate the dd component
		'
		If dd <> "*" Then														' Days can be *, in which case don't do this
			If dd <> "" Then
				If dd.Contains("_") = False Then
					If dd.EndsWith("st", StringComparison.CurrentCultureIgnoreCase) OrElse dd.EndsWith("nd", StringComparison.CurrentCultureIgnoreCase) OrElse dd.EndsWith("rd", StringComparison.CurrentCultureIgnoreCase) OrElse dd.EndsWith("th", StringComparison.CurrentCultureIgnoreCase) Then
						dd = dd.TrimEnd("s"c, "S"c, "t"c, "T"c, "n"c, "N"c, "d"c, "D"c, "r"c, "R"c, "h"c, "H"c)
						strBits(1) = dd
					End If

					Dim dnum As Integer
					If Integer.TryParse(dd, NumberStyles.Integer, Nothing, dnum) Then

						fValidDay = True
						If mmm = "Sep" And yy = "1752" And (CInt(dd) >= 3 And CInt(dd) <= 13) Then
							strErrMessage = My.Resources.err0015
							e = False												' The 'missing' 11 days from 1752 are invalid
						End If
					Else
						strErrMessage = "day should be numeric"
						e = False
					End If
				End If
			End If
		End If
		If Not e Then Return False ' Date was invalid

		' Validate the year component
		'
		If yy <> "*" Then
			If yy <> "" Then
				If yy.Contains("_") = False Then
					fValidYear = True
					Dim yyi As Integer
					If Int16.TryParse(yy, yyi) Then
						If yyi <= 1751 Then
							If zz <> "*" Then
								If zz <> "" Then
									If zz.Contains("_") = False Then
										Dim zzi As Integer
										If Int16.TryParse(zz, zzi) Then
											If mmm <> "Jan" And mmm <> "Feb" And mmm <> "Mar" And mmm <> "" And mmm <> "*" Then
												strErrMessage = My.Resources.err0016
												e = False
											Else
												If dd <> "*" And dd <> "" And dd.Contains("_") = False Then
													Dim ddd As Integer
													If Int16.TryParse(dd, ddd) Then
														If ddd >= 25 And mmm = "Mar" Then
															strErrMessage = My.Resources.err0017
															e = False
														Else
															If zzi <= 99 Then
																If (yyi Mod 100) = 99 Then	' End of century - split must be "00"
																	If zz <> "00" Then
																		strErrMessage = My.Resources.err0018
																		e = False
																	End If
																Else
																	Dim yyj As Integer = (yyi + 1) Mod 100

																	If yyj <> zzi Then
																		If zzi <> yyj Mod 10 Then
																			strErrMessage = My.Resources.err0019
																			e = False
																		End If
																	End If

																	If e Then
																		zz = yyj.ToString()
																	End If
																End If
															Else									' Split-year can't be more than 99
																strErrMessage = My.Resources.err0020
																e = False
															End If
														End If
													Else
														strErrMessage = My.Resources.err0021
														e = False
													End If
												End If
											End If
										Else
											strErrMessage = My.Resources.err0022
											e = False
										End If
									End If
								Else												' Should be a split-year in this case
									If mmm = "Jan" Or mmm = "Feb" Then
										strErrMessage = My.Resources.err0023
										e = False
									Else
										If mmm = "Mar" Then
											If Not String.IsNullOrEmpty(dd) Then
												If dd <> "*" And dd <> "" And dd.Contains("_") = False Then
													Try
														If CInt(dd) <= 24 Then
															strErrMessage = My.Resources.err0023
															e = False
														End If
													Catch ex As Exception
														strErrMessage = My.Resources.err0024
														e = False
													End Try
												End If
											End If
										End If
									End If
								End If
							Else												' Should be a split-year in this case
								If mmm = "Jan" Or mmm = "Feb" Then
									strErrMessage = My.Resources.err0023
									e = False
								Else
									If mmm = "Mar" Then
										If Not String.IsNullOrEmpty(dd) Then
											If dd <> "*" And dd <> "" And dd.Contains("_") = False Then
												Try
													If CInt(dd) <= 24 Then
														strErrMessage = My.Resources.err0023
														e = False
													End If
												Catch ex As Exception
													strErrMessage = My.Resources.err0024
													e = False
												End Try
											End If
										End If
									End If
								End If
							End If
						End If
					Else
						If zz <> "" Then									' Years after 1751 musn't have a split-year
							strErrMessage = My.Resources.err0025
							e = False
						End If
					End If
				Else
					strErrMessage = My.Resources.err0022
					e = False
				End If
			End If
		End If
		If Not e Then Return False ' Date was invalid

		If mmm = "Feb" And dd = "29" Then								' Special check for leap years
			Dim yyi As Integer = Convert.ToInt16(yy)

			If yyi < 1752 Then yyi += 1 ' The double-year is the crucial one!
			Dim century As Integer = yyi \ 100, year As Integer = yyi Mod 100

			If year <> 0 Then
				If (year Mod 4) <> 0 Then
					strErrMessage = My.Resources.err0026
					e = False
				End If
			Else
				If (century Mod 4) <> 0 Then								' Only 1600 and 2000 are leap years. 17/18/1900 are not.
					strErrMessage = My.Resources.err0027
					e = False
				End If
			End If
		End If
		If Not e Then Return False ' Date was invalid

		If My.Settings.MyLeadingZeroOnDates Then
			If dd <> "*" And dd <> "" And dd.Contains("_") = False Then
				Dim dnum As Integer = Convert.ToInt32(dd)					' Convert a numeric day to the required dd format
				strToReplace = String.Format("{0:00} {1} {2}", dnum, mmm, yy)						' Construct a correctly formatted and punctuated date string
			Else
				If dd <> "" Then
					strToReplace = String.Format("{0} {1} {2}", dd, mmm, yy)			' Construct a correctly formatted and punctuated date string
				ElseIf mmm <> "" Then
					strToReplace = String.Format("{0} {1}", mmm, yy)							' Construct a correctly formatted and punctuated date string
				Else
					strToReplace = yy											' Construct a correctly formatted and punctuated date string
				End If
			End If
		Else
			strToReplace = String.Format("{0} {1} {2}", dd, mmm, yy)					' Construct a correctly formatted and punctuated date string
		End If

		If Not zz = "" Then
			strToReplace = String.Format("{0}/{1}", strToReplace, zz)
		End If

		strBits(1) = dd
		strBits(2) = mmm
		strBits(3) = yy
		strBits(4) = zz

		strToValidate = strToReplace
		Return True
	End Function

	Public Shared Function ValidateBurialAge(ByRef strToValidate As String, ByRef strErrMessage As String, ByVal inValidation As Boolean) As Boolean
		Dim e As Boolean = False

		strErrMessage = String.Empty
		If strToValidate = String.Empty OrElse strToValidate = "*" Then Return True

		If String.Compare(strToValidate, "infant", True) = 0 OrElse String.Compare(strToValidate, "child", True) = 0 Then Return True

		Dim s As ULong
		If UInt32.TryParse(strToValidate, s) Then
			If s > 99 Then
				If Not inValidation Then
					If MessageBox.Show(My.Resources.msgOldperson, "Burial Age", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0041) = Windows.Forms.DialogResult.Yes Then
						e = True
					Else
						strErrMessage = My.Resources.err0041
						Return False
					End If
				Else
					strErrMessage = My.Resources.err0041
					Return False
				End If
			Else
				e = True
			End If
		Else
			' Now we need to look for 1 or 2 digit numbers followed by one of the age 'units'
			' There could be multiple units of y-years, m-months, w-weeks, d-days in any order
			' But there should not be any duplicate units
			'
			Dim t As String = strToValidate						' Temporary copy of the data string
			Dim ca As Char() = t.ToCharArray
			Dim i As Integer = 0
			t = ""
			For Each c As Char In ca								' replace any units with digits
				If c = "y"c Or c = "Y"c Then
					ca(i) = "0"c
				ElseIf c = "m"c Or c = "M"c Then
					ca(i) = "0"c
				ElseIf c = "w"c Or c = "W"c Then
					ca(i) = "0"c
				ElseIf c = "d"c Or c = "D"c Then
					ca(i) = "0"c
				ElseIf c = "h"c Or c = "H"c Then
					ca(i) = "0"c
				ElseIf c = "_"c Or c = "¼"c Or c = "½"c Or c = "¾"c Then
					ca(i) = "0"c
				End If

				t = t + ca(i)
				i += 1
			Next

			If UInt64.TryParse(t, s) Then
				e = True
			Else
				e = False												' otherwise, the string is invalid
				strErrMessage = My.Resources.err0004
			End If
		End If

		Return e
	End Function

	Public Shared Function ValidateBrideAge(ByRef strToValidate As String, ByRef strErrMessage As String, ByVal inValidation As Boolean) As Boolean
		Dim e As Boolean = False

		If strToValidate = "" OrElse strToValidate = "*" Then Return True
		If String.Compare(strToValidate, "minor", True) = 0 Then Return True

		If String.Compare(strToValidate, "of full age", True) = 0 OrElse String.Compare(strToValidate, "of age", True) = 0 OrElse String.Compare(strToValidate, "full age", True) = 0 OrElse String.Compare(strToValidate, "over 21", True) = 0 Then
			strToValidate = "full age"
			Return True
		End If

		If String.Compare(strToValidate, "over 21", True) = 0 Then
			strToValidate = "over 21"
			Return True
		End If

		If Regex.IsMatch(strToValidate, My.Resources.rgxMarriageAgeComplex, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase) Then
			Dim ms = Regex.Matches(strToValidate, My.Resources.rgxMarriageAgeComplex, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
			If ms.Count = 1 Then
				Dim s As Short
				If UInt16.TryParse(ms(0).Groups.Item("num1").Value, s) Then
					If s > 99 Then
						If Not inValidation Then
							If MessageBox.Show(My.Resources.msgOldperson, "Brides Age", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0008) = Windows.Forms.DialogResult.Yes Then
								e = True
							Else
								e = False
								strErrMessage = My.Resources.err0058
							End If
						Else
							e = False
							strErrMessage = My.Resources.err0058
						End If
					Else
						e = True
					End If

				Else
					e = False
					strErrMessage = My.Resources.err0005
				End If
			Else
				strErrMessage = My.Resources.err0005
				e = False
			End If
		Else
			If Regex.IsMatch(strToValidate, My.Resources.rgxMarriageAgeSimple, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase) Then
				Dim ms = Regex.Matches(strToValidate, My.Resources.rgxMarriageAgeSimple, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
				If ms.Count = 1 Then
					Dim s As Short
					If UInt16.TryParse(ms(0).Groups.Item("number").Value, s) Then
						If s > 99 Then
							If Not inValidation Then
								If MessageBox.Show(My.Resources.msgOldperson, "Brides Age", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0008) = Windows.Forms.DialogResult.Yes Then
									e = True
								Else
									e = False
									strErrMessage = My.Resources.err0058
								End If
							Else
								e = False
								strErrMessage = My.Resources.err0058
							End If
						Else
							e = True
						End If

					Else
						e = False
						strErrMessage = My.Resources.err0005
					End If
				Else
					strErrMessage = My.Resources.err0005
					e = False
				End If
			Else
				strErrMessage = My.Resources.err0005
				e = False
			End If
		End If

		Return e
	End Function

	Public Shared Function ValidateGroomAge(ByRef strToValidate As String, ByRef strErrMessage As String, ByVal inValidation As Boolean) As Boolean
		Dim e As Boolean = False

		If strToValidate = "" OrElse strToValidate = "*" Then Return True
		If String.Compare(strToValidate, "minor", True) = 0 Then Return True

		If String.Compare(strToValidate, "of full age", True) = 0 OrElse String.Compare(strToValidate, "of age", True) = 0 OrElse String.Compare(strToValidate, "full age", True) = 0 OrElse String.Compare(strToValidate, "over 21", True) = 0 Then
			strToValidate = "full age"
			Return True
		End If

		If String.Compare(strToValidate, "over 21", True) = 0 Then
			strToValidate = "over 21"
			Return True
		End If

		If Regex.IsMatch(strToValidate, My.Resources.rgxMarriageAgeComplex, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase) Then
			Dim ms = Regex.Matches(strToValidate, My.Resources.rgxMarriageAgeComplex, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
			If ms.Count = 1 Then
				Dim s As Short
				If UInt16.TryParse(ms(0).Groups.Item("num1").Value, s) Then
					If s > 99 Then
						If Not inValidation Then
							If MessageBox.Show(My.Resources.msgOldperson, "Grooms Age", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0005) = Windows.Forms.DialogResult.Yes Then
								e = True
							Else
								e = False
								strErrMessage = My.Resources.err0059
							End If
						Else
							e = False
							strErrMessage = My.Resources.err0059
						End If
					Else
						e = True
					End If

				Else
					e = False
					strErrMessage = My.Resources.err0006
				End If
			Else
				strErrMessage = My.Resources.err0006
				e = False
			End If
		Else
			If Regex.IsMatch(strToValidate, My.Resources.rgxMarriageAgeSimple, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase) Then
				Dim ms = Regex.Matches(strToValidate, My.Resources.rgxMarriageAgeSimple, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
				If ms.Count = 1 Then
					Dim s As Short
					If UInt16.TryParse(ms(0).Groups.Item("number").Value, s) Then
						If s > 99 Then
							If Not inValidation Then
								If MessageBox.Show(My.Resources.msgOldperson, "Grooms Age", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, MSG0005) = Windows.Forms.DialogResult.Yes Then
									e = True
								Else
									e = False
									strErrMessage = My.Resources.err0059
								End If
							Else
								e = False
								strErrMessage = My.Resources.err0059
							End If
						Else
							e = True
						End If

					Else
						e = False
						strErrMessage = My.Resources.err0006
					End If
				Else
					strErrMessage = My.Resources.err0006
					e = False
				End If
			Else
				strErrMessage = My.Resources.err0006
				e = False
			End If
		End If

		Return e
	End Function

End Class
