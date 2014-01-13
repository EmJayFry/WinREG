Imports System.Windows.Data

Public Class GetFileSystemInformationConverter
	Implements IValueConverter

	Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert

		Try
			If TypeOf value Is IO.DriveInfo Then
				Dim d = DirectCast(value, IO.DriveInfo)
				If d.IsReady Then
					Dim di As New IO.DirectoryInfo(d.RootDirectory.Name)
					Return di.GetDirectories
				Else
					Return Nothing
				End If

			ElseIf TypeOf value Is IO.DirectoryInfo Then
				Dim di = DirectCast(value, IO.DirectoryInfo)
				If (di.Attributes And IO.FileAttributes.Hidden) = IO.FileAttributes.Hidden Then
					Return Nothing
				Else
					Return di.GetDirectories
				End If

			Else
				Return Nothing

			End If
		Catch ex As Exception
			Return Nothing

		End Try
	End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
		Throw New NotSupportedException
	End Function
End Class
