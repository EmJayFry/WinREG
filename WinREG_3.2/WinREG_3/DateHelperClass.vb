'	$Date: 2012-02-01 15:52:14 +0200 (Wed, 01 Feb 2012) $
'	$Rev: 147 $
'	$Id: DateHelperClass.vb 147 2012-02-01 13:52:14Z Mikefry $
'
'	WinREG/3 - Version 3.1.8
'

Public Class DateHelperClass

	Private _FieldText As String
	Private _FieldName As String
	Private _InsertionPoint As Integer

	Public Property FieldName() As String
		Get
			Return _FieldName
		End Get
		Set(ByVal value As String)
			_FieldName = value
		End Set
	End Property

	Public Property FieldText() As String
		Get
			Return _FieldText
		End Get
		Set(ByVal value As String)
			_FieldText = value
		End Set
	End Property

	Public Property InsertionPoint() As Integer
		Get
			Return _InsertionPoint
		End Get
		Set(ByVal value As Integer)
			_InsertionPoint = value
		End Set
	End Property

End Class
