Imports System.Windows.Data

Public Class ScaleToPercentConverter
	Implements IValueConverter

	Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
		' Round to an integer value whilst converting.
		Return CType(CType(CType(value * 100.0, Double), Integer), Double)
	End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
		Return CType(value / 100.0, Double)
	End Function
End Class
