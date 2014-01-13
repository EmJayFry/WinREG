Partial Class LookupTables

	Public Function addRecordTypeRow(ByVal recordType As String, ByVal recordDesc As String) As RecordTypesRow
		Dim row As RecordTypesRow
		row = RecordTypes.NewRecordTypesRow()
		With row
			.Type = recordType
			.Description = recordDesc
		End With
		Return row
	End Function

	Public Function addChapmanCodeRow(ByVal chapmanCode As String, ByVal chapmanDesc As String) As ChapmanCodesRow
		Dim row As ChapmanCodesRow
		row = ChapmanCodes.NewChapmanCodesRow()
		With row
			.Code = chapmanCode
			.County = chapmanDesc
		End With
		Return row
	End Function

	Public Function addBaptismSexRow(ByVal type As String, ByVal fileValue As Char, ByVal displayValue As String) As BaptismSexRow
		Dim row As BaptismSexRow
		row = BaptismSex.NewBaptismSexRow()
		With row
			.Type = type
			.Code = fileValue
			.Description = displayValue
		End With
		Return row
	End Function

	Public Function addApplicationBaptismSexRow(ByVal fileValue As Char, ByVal displayValue As String) As BaptismSexRow
		Dim row As BaptismSexRow
		row = addBaptismSexRow("Application", fileValue, displayValue)
		Return row
	End Function

	Public Function addBurialRelationshipRow(ByVal type As String, ByVal fileValue As String, ByVal displayValue As String) As BurialRelationshipRow
		Dim row As BurialRelationshipRow
		row = BurialRelationship.NewBurialRelationshipRow()
		With row
			row.Type = type
			row.FileValue = fileValue
			row.DisplayValue = displayValue
		End With
		Return row
	End Function

	Public Function addApplicationBurialRelationshipRow(ByVal fileValue As Char, ByVal displayValue As String) As BurialRelationshipRow
		Dim row As BurialRelationshipRow
		row = addBurialRelationshipRow("Application", fileValue, displayValue)
		Return row
	End Function

	Public Function addGroomConditionRow(ByVal type As String, ByVal fileValue As String, ByVal displayValue As String) As GroomConditionRow
		Dim row As GroomConditionRow
		row = GroomCondition.NewGroomConditionRow()
		With row
			.Type = type
			.FileValue = fileValue
			.DisplayValue = displayValue
		End With
		Return row
	End Function

	Public Function addApplicationGroomConditionRow(ByVal fileValue As Char, ByVal displayValue As String) As GroomConditionRow
		Dim row As GroomConditionRow
		row = addGroomConditionRow("Application", fileValue, displayValue)
		Return row
	End Function

	Public Function addBrideConditionRow(ByVal type As String, ByVal fileValue As String, ByVal displayValue As String) As BrideConditionRow
		Dim row As BrideConditionRow
		row = BrideCondition.NewBrideConditionRow()
		With row
			.Type = type
			.FileValue = fileValue
			.DisplayValue = displayValue
		End With
		Return row
	End Function

	Public Function addApplicationBrideConditionRow(ByVal fileValue As Char, ByVal displayValue As String) As BrideConditionRow
		Dim row As BrideConditionRow
		row = addBrideConditionRow("Application", fileValue, displayValue)
		Return row
	End Function

End Class
