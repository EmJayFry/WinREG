Public Class ErrorFileCreated
	' Declare an event for this class.
	Public Event ErrorFileCreated(ByVal strFileName As String)

	' Define a method that raises an event.
	Public Sub CauseEvent(ByVal strFileName As String)
		RaiseEvent ErrorFileCreated(strFileName)
	End Sub
End Class
