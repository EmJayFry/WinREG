Public Class JulianDate

	Public Shared Function isJulianDate(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer) As Boolean
		' All dates prior to 1752 are in the Julian calendar
		If year < 1752 Then
			Return True
			' All dates after 1752 are in the Gregorian calendar
		ElseIf year > 1752 Then
			Return False
		Else
			' If 1752, check before September 3 (Julian) or after September 13 (Gregorian)
			If month < 9 Then
				Return True
			ElseIf month > 9 Then
				Return False
			Else
				If day < 3 Then
					Return True
				ElseIf day > 13 Then
					Return False
				Else
					' Any date in the range 3 Sep 1752 to 13 Sep 1752 is invalid 
					Throw New ArgumentOutOfRangeException("This date is not valid as it does not exist in either the Julian or the Gregorian calendars.")
				End If
			End If
		End If
	End Function

	Private Shared Function DateToJD(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal hour As Integer, ByVal minute As Integer, ByVal second As Integer, ByVal millisecond As Integer) As Double
		' Determine correct calendar based on date
		Dim JulianCalendar As Boolean = isJulianDate(year, month, day)

		Dim M As Integer = If(month > 2, month, month + 12)
		Dim Y As Integer = If(month > 2, year, year - 1)
		Dim D As Double = day + hour / 24.0 + minute / 1440.0 + (second + millisecond * 1000) / 86400.0
		Dim B As Integer = If(JulianCalendar, 0, 2 - Y / 100 + Y / 100 / 4)

		Return CInt(365.25 * (Y + 4716)) + CInt(30.6001 * (M + 1)) + D + B - 1524.5
	End Function

	Public Shared Function JD(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal hour As Integer, ByVal minute As Integer, ByVal second As Integer, ByVal millisecond As Integer) As Double
		Return DateToJD(year, month, day, hour, minute, second, millisecond)
	End Function

	Public Shared Function JD(ByVal [date] As DateTime) As Double
		Return DateToJD([date].Year, [date].Month, [date].Day, [date].Hour, [date].Minute, [date].Second, [date].Millisecond)
	End Function

End Class
