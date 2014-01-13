'	$Date: 2013-12-20 11:10:12 +0200 (Fri, 20 Dec 2013) $
'	$Rev: 290 $
'	$Id: WinREG2_Panel.vb 290 2013-12-20 09:10:12Z Mikefry $
'
'	WinREG/3 - Version 3.2.00
'

Imports WinREG.MessageBoxes

Public Class WinREG2_Panel

	Public _ItemActivated As Boolean = False
	Public _NewItem As Boolean = False									' Set when adding a new item to any file
	Public _ActivatedListItem As Integer
	Public _SelectedDataRow As Integer

	Public WriteOnly Property enableToolTip() As Boolean
		Set(ByVal value As Boolean)
			ttipPanel.Active = value
			If value Then ttipPanel.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000
		End Set
	End Property

	Private Sub lvData_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvData.ItemActivate, lvData.DoubleClick
		Dim selIndex As Integer
		_NewItem = False

		If Not _ItemActivated Then
			selIndex = lvData.SelectedIndices().Item(0)				' Index of the selected item
			Dim selectedListViewItem As ListViewItem = lvData.Items(selIndex)
			Dim loadorder As Integer = selectedListViewItem.SubItems(selectedListViewItem.SubItems.Count - 1).Text

			If TypeOf lvData.DataSource.DataSource Is WinREG.TranscriptionTables.BaptismsDataTable Then
				Dim dt As WinREG.TranscriptionTables.BaptismsDataTable = lvData.DataSource.DataSource
				Dim row As WinREG.TranscriptionTables.BaptismsRow = dt.Rows(loadorder)
				ShowBaptismsRow(row)
				_SelectedDataRow = loadorder
				_ActivatedListItem = selIndex
				_ItemActivated = True

			ElseIf TypeOf lvData.DataSource.DataSource Is WinREG.TranscriptionTables.BurialsDataTable Then
				Dim dt As WinREG.TranscriptionTables.BurialsDataTable = lvData.DataSource.DataSource
				Dim row As WinREG.TranscriptionTables.BurialsRow = dt.Rows(loadorder)
				ShowBurialsRow(row)
				_SelectedDataRow = loadorder
				_ActivatedListItem = selIndex
				_ItemActivated = True

			ElseIf TypeOf lvData.DataSource.DataSource Is WinREG.TranscriptionTables.MarriagesDataTable Then
				Dim dt As WinREG.TranscriptionTables.MarriagesDataTable = lvData.DataSource.DataSource
				Dim row As WinREG.TranscriptionTables.MarriagesRow = dt.Rows(loadorder)
				ShowMarriagesRow(row)
				_SelectedDataRow = loadorder
				_ActivatedListItem = selIndex
				_ItemActivated = True

			End If
		End If
	End Sub

	Private Sub lvData_ItemAdded(ByVal sender As Object, ByVal index As Integer, ByVal newrow As DataRowView) Handles lvData.ItemAdded
		Dim selectedListViewItem As ListViewItem = lvData.Items(index)
		Dim loadorder As Integer = selectedListViewItem.SubItems(selectedListViewItem.SubItems.Count - 1).Text

		If TypeOf newrow.Row Is WinREG.TranscriptionTables.BaptismsRow Then
			Dim row As WinREG.TranscriptionTables.BaptismsRow = newrow.Row
			ShowBaptismsRow(row)
			_SelectedDataRow = loadorder
			_ActivatedListItem = index
			_ItemActivated = True

		ElseIf TypeOf newrow.Row Is WinREG.TranscriptionTables.BurialsRow Then
			Dim row As WinREG.TranscriptionTables.BurialsRow = newrow.Row
			ShowBurialsRow(row)
			_SelectedDataRow = loadorder
			_ActivatedListItem = index
			_ItemActivated = True

		ElseIf TypeOf newrow.Row Is WinREG.TranscriptionTables.MarriagesRow Then
			Dim row As WinREG.TranscriptionTables.MarriagesRow = newrow.Row
			ShowMarriagesRow(row)
			_SelectedDataRow = loadorder
			_ActivatedListItem = index
			_ItemActivated = True

		End If

	End Sub

	Private Sub ShowBaptismsRow(ByVal row As WinREG.TranscriptionTables.BaptismsRow)
		txtBapRegNo.Text = row.RegNo
		txtBapRegNo.Enabled = True
		If MainForm.ldsFile Then
			labBapFiche.Visible = True
			labBapFiche.Enabled = True
			txtBapFiche.Visible = True
			txtBapFiche.Enabled = True
			txtBapFiche.Text = row.LDSFiche
			labBapImage.Visible = True
			labBapImage.Enabled = True
			txtBapImage.Visible = True
			txtBapImage.Enabled = True
			txtBapImage.Text = row.LDSImage
		Else
			labBapFiche.Visible = False
			labBapFiche.Enabled = False
			txtBapFiche.Visible = False
			txtBapFiche.Enabled = False
			labBapImage.Visible = False
			labBapImage.Enabled = False
			txtBapImage.Visible = False
			txtBapImage.Enabled = False
		End If
		txtBapBirthDate.Text = row.BirthDate
		txtBapBirthDate.Enabled = True
		txtBapBaptismDate.Text = row.BaptismDate
		txtBapBaptismDate.Enabled = True
		txtBapForenames.Text = row.Forenames
		txtBapForenames.Enabled = True

		If cbBapSex.DataSource Is Nothing Then
			cbBapSex.DataSource = MainForm.tabBapSex
			cbBapSex.ValueMember = "Code"
			cbBapSex.DisplayMember = "Description"
		End If

		cbBapSex.SelectedValue = row.Sex
		cbBapSex.Enabled = True

		txtBapFathersForenames.Text = row.FathersName
		txtBapFathersForenames.Enabled = True
		txtBapMothersForenames.Text = row.MothersName
		txtBapMothersForenames.Enabled = True
		txtBapFathersSurname.Text = row.FathersSurname
		txtBapFathersSurname.Enabled = True
		txtBapMothersSurname.Text = row.MothersSurname
		txtBapMothersSurname.Enabled = True
		txtBapAbode.Text = row.Abode
		txtBapAbode.Enabled = True
		txtBapFathersOccupation.Text = row.FathersOccupation
		txtBapFathersOccupation.Enabled = True
		txtBapNotes.Text = row.Notes
		txtBapNotes.Enabled = True

		btnBapSave.Enabled = True
		btnBapSave.Text = "Save"
		btnBapCancel.Enabled = True
		btnBapDelete.Enabled = True
		txtBapRegNo.Select()
	End Sub

	Private Sub ShowBurialsRow(ByVal row As WinREG.TranscriptionTables.BurialsRow)
		txtBurRegNo.Text = row.RegNo
		txtBurRegNo.Enabled = True
		If MainForm.ldsFile Then
			labBurFiche.Visible = True
			labBurFiche.Enabled = True
			txtBurFiche.Visible = True
			txtBurFiche.Enabled = True
			txtBurFiche.Text = row.LDSFiche
			labBurImage.Visible = True
			labBurImage.Enabled = True
			txtBurImage.Visible = True
			txtBurImage.Enabled = True
			txtBurImage.Text = row.LDSImage
		Else
			labBurFiche.Visible = False
			labBurFiche.Enabled = False
			txtBurFiche.Visible = False
			txtBurFiche.Enabled = False
			labBurImage.Visible = False
			labBurImage.Enabled = False
			txtBurImage.Visible = False
			txtBurImage.Enabled = False
		End If
		txtBurBurialDate.Text = row.BurialDate
		txtBurBurialDate.Enabled = True
		txtBurForenames.Text = row.Forenames
		txtBurForenames.Enabled = True

		If cbBurRelationship.DataSource Is Nothing Then
			cbBurRelationship.DataSource = MainForm.tabBurialRelationship
			cbBurRelationship.ValueMember = "FileValue"
			cbBurRelationship.DisplayMember = "DisplayValue"
		End If

		cbBurRelationship.SelectedValue = row.Relationship
		cbBurRelationship.Enabled = True

		txtBurMaleRelativeForename.Text = row.MaleForenames
		txtBurMaleRelativeForename.Enabled = True
		txtBurFemaleRelativeForename.Text = row.FemaleForenames
		txtBurFemaleRelativeForename.Enabled = True
		txtBurRelativeSurname.Text = row.RelativeSurname
		txtBurRelativeSurname.Enabled = True
		txtBurSurname.Text = row.Surname
		txtBurSurname.Enabled = True
		txtBurAge.Text = row.Age
		txtBurAge.Enabled = True
		txtBurAbode.Text = row.Abode
		txtBurAbode.Enabled = True
		txtBurNotes.Text = row.Notes
		txtBurNotes.Enabled = True

		btnBurSave.Enabled = True
		btnBurSave.Text = "Save"
		btnBurCancel.Enabled = True
		btnBurDelete.Enabled = True
		txtBurRegNo.Select()
	End Sub

	Private Sub ShowMarriagesRow(ByVal row As WinREG.TranscriptionTables.MarriagesRow)
		txtMarRegNo.Text = row.RegNo
		txtMarRegNo.Enabled = True
		If MainForm.ldsFile Then
			labMarFiche.Visible = True
			labMarFiche.Enabled = True
			txtMarFiche.Visible = True
			txtMarFiche.Enabled = True
			txtMarFiche.Text = row.LDSFiche
			labMarImage.Visible = True
			labMarImage.Enabled = True
			txtMarImage.Visible = True
			txtMarImage.Enabled = True
			txtMarImage.Text = row.LDSImage
		Else
			labMarFiche.Visible = False
			labMarFiche.Enabled = False
			txtMarFiche.Visible = False
			txtMarFiche.Enabled = False
			labMarImage.Visible = False
			labMarImage.Enabled = False
			txtMarImage.Visible = False
			txtMarImage.Enabled = False
		End If
		txtMarDate.Text = row.MarriageDate
		txtMarDate.Enabled = True
		txtMarGroomForenames.Text = row.GroomForenames
		txtMarGroomForenames.Enabled = True
		txtMarGroomSurname.Text = row.GroomSurname
		txtMarGroomSurname.Enabled = True
		txtMarGroomAge.Text = row.GroomAge
		txtMarGroomAge.Enabled = True
		txtMarGroomParish.Text = row.GroomParish
		txtMarGroomParish.Enabled = True

		If cbMarGroomCondition.DataSource Is Nothing Then
			cbMarGroomCondition.DataSource = MainForm.tabGroomCondition
			cbMarGroomCondition.ValueMember = "FileValue"
			cbMarGroomCondition.DisplayMember = "DisplayValue"
		End If

		cbMarGroomCondition.SelectedValue = row.GroomCondition
		cbMarGroomCondition.Enabled = True

		txtMarGroomOccupation.Text = row.GroomOccupation
		txtMarGroomOccupation.Enabled = True
		txtMarGroomAbode.Text = row.GroomAbode
		txtMarGroomAbode.Enabled = True
		txtMarBrideForenames.Text = row.BrideForenames
		txtMarBrideForenames.Enabled = True
		txtMarBrideSurname.Text = row.BrideSurname
		txtMarBrideSurname.Enabled = True
		txtMarBrideAge.Text = row.BrideAge
		txtMarBrideAge.Enabled = True
		txtMarBrideParish.Text = row.BrideParish
		txtMarBrideParish.Enabled = True

		If cbMarBrideCondition.DataSource Is Nothing Then
			cbMarBrideCondition.DataSource = MainForm.tabBrideCondition
			cbMarBrideCondition.ValueMember = "FileValue"
			cbMarBrideCondition.DisplayMember = "DisplayValue"
		End If

		cbMarBrideCondition.SelectedValue = row.BrideCondition
		cbMarBrideCondition.Enabled = True

		txtMarBrideOccupation.Text = row.BrideOccupation
		txtMarBrideOccupation.Enabled = True
		txtMarBrideAbode.Text = row.BrideAbode
		txtMarBrideAbode.Enabled = True
		txtMarGroomFatherForenames.Text = row.GroomFatherForenames
		txtMarGroomFatherForenames.Enabled = True
		txtMarGroomFatherSurname.Text = row.GroomFatherSurname
		txtMarGroomFatherSurname.Enabled = True
		txtMarGroomFatherOccupation.Text = row.GroomFatherOccupation
		txtMarGroomFatherOccupation.Enabled = True
		txtMarBrideFatherForenames.Text = row.BrideFatherForenames
		txtMarBrideFatherForenames.Enabled = True
		txtMarBrideFatherSurname.Text = row.BrideFatherSurname
		txtMarBrideFatherSurname.Enabled = True
		txtMarBrideFatherOccupation.Text = row.BrideFatherOccupation
		txtMarBrideFatherOccupation.Enabled = True
		txtMarWitness1Forenames.Text = row.Witness1Forenames
		txtMarWitness1Forenames.Enabled = True
		txtMarWitness1Surname.Text = row.Witness1Surname
		txtMarWitness1Surname.Enabled = True
		txtMarWitness2Forenames.Text = row.Witness2Forenames
		txtMarWitness2Forenames.Enabled = True
		txtMarWitness2Surname.Text = row.Witness2Surname
		txtMarWitness2Surname.Enabled = True
		txtMarNotes.Text = row.Notes
		txtMarNotes.Enabled = True

		btnMarSave.Enabled = True
		btnMarSave.Text = "Save"
		btnMarCancel.Enabled = True
		btnMarDelete.Enabled = True
		txtMarRegNo.Select()
	End Sub

	Private Sub lvData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvData.Click
		Dim selIndex As Integer
		Dim lvi As ListViewItem

		If Not _ItemActivated Then
			selIndex = lvData.SelectedIndices().Item(0)			  ' Index of the selected item
			lvi = lvData.Items(selIndex)								  ' The selected ListView item

			If TypeOf lvData.DataSource.DataSource Is WinREG.TranscriptionTables.BaptismsDataTable Then
				Dim dt As WinREG.TranscriptionTables.BaptismsDataTable = lvData.DataSource.DataSource
				Dim row As WinREG.TranscriptionTables.BaptismsRow = dt.Rows(lvi.SubItems(lvi.SubItems.Count - 1).Text)

				txtBapRegNo.Text = row.RegNo
				If MainForm.ldsFile Then
					labBapFiche.Visible = True
					txtBapFiche.Visible = True
					txtBapFiche.Text = row.LDSFiche
					labBapImage.Visible = True
					txtBapImage.Visible = True
					txtBapImage.Text = row.LDSImage
				Else
					labBapFiche.Visible = False
					labBapFiche.Enabled = False
					txtBapFiche.Visible = False
					txtBapFiche.Enabled = False
					labBapImage.Visible = False
					labBapImage.Enabled = False
					txtBapImage.Visible = False
					txtBapImage.Enabled = False
				End If
				txtBapBirthDate.Text = row.BirthDate
				txtBapBaptismDate.Text = row.BaptismDate
				txtBapForenames.Text = row.Forenames

				If cbBapSex.DataSource Is Nothing Then
					cbBapSex.DataSource = MainForm.tabBapSex
					cbBapSex.ValueMember = "Code"
					cbBapSex.DisplayMember = "Description"
				End If

				cbBapSex.SelectedValue = row.Sex

				txtBapFathersForenames.Text = row.FathersName
				txtBapMothersForenames.Text = row.MothersName
				txtBapFathersSurname.Text = row.FathersSurname
				txtBapMothersSurname.Text = row.MothersSurname
				txtBapAbode.Text = row.Abode
				txtBapFathersOccupation.Text = row.FathersOccupation
				txtBapNotes.Text = row.Notes

			ElseIf TypeOf lvData.DataSource.DataSource Is WinREG.TranscriptionTables.BurialsDataTable Then
				Dim dt As WinREG.TranscriptionTables.BurialsDataTable = lvData.DataSource.DataSource
				Dim row As WinREG.TranscriptionTables.BurialsRow = dt.Rows(lvi.SubItems(lvi.SubItems.Count - 1).Text)

				txtBurRegNo.Text = row.RegNo
				txtBurBurialDate.Text = row.BurialDate
				If MainForm.ldsFile Then
					labBurFiche.Visible = True
					txtBurFiche.Visible = True
					txtBurFiche.Text = row.LDSFiche
					labBurImage.Visible = True
					txtBurImage.Visible = True
					txtBurImage.Text = row.LDSImage
				Else
					labBurFiche.Visible = False
					labBurFiche.Enabled = False
					txtBurFiche.Visible = False
					txtBurFiche.Enabled = False
					labBurImage.Visible = False
					labBurImage.Enabled = False
					txtBurImage.Visible = False
					txtBurImage.Enabled = False
				End If
				txtBurForenames.Text = row.Forenames

				If cbBurRelationship.DataSource Is Nothing Then
					cbBurRelationship.DataSource = MainForm.tabBurialRelationship
					cbBurRelationship.ValueMember = "FileValue"
					cbBurRelationship.DisplayMember = "DisplayValue"
				End If

				cbBurRelationship.SelectedValue = row.Relationship

				txtBurMaleRelativeForename.Text = row.MaleForenames
				txtBurFemaleRelativeForename.Text = row.FemaleForenames
				txtBurRelativeSurname.Text = row.RelativeSurname
				txtBurSurname.Text = row.Surname
				txtBurAge.Text = row.Age
				txtBurAbode.Text = row.Abode
				txtBurNotes.Text = row.Notes

			ElseIf TypeOf lvData.DataSource.DataSource Is WinREG.TranscriptionTables.MarriagesDataTable Then
				Dim dt As WinREG.TranscriptionTables.MarriagesDataTable = lvData.DataSource.DataSource
				Dim row As WinREG.TranscriptionTables.MarriagesRow = dt.Rows(lvi.SubItems(lvi.SubItems.Count - 1).Text)

				txtMarRegNo.Text = row.RegNo
				txtMarDate.Text = row.MarriageDate
				If MainForm.ldsFile Then
					labMarFiche.Visible = True
					txtMarFiche.Visible = True
					txtMarFiche.Text = row.LDSFiche
					labMarImage.Visible = True
					txtMarImage.Visible = True
					txtMarImage.Text = row.LDSImage
				Else
					labMarFiche.Visible = False
					labMarFiche.Enabled = False
					txtMarFiche.Visible = False
					txtMarFiche.Enabled = False
					labMarImage.Visible = False
					labMarImage.Enabled = False
					txtMarImage.Visible = False
					txtMarImage.Enabled = False
				End If
				txtMarGroomForenames.Text = row.GroomForenames
				txtMarGroomSurname.Text = row.GroomSurname
				txtMarGroomAge.Text = row.GroomAge
				txtMarGroomParish.Text = row.GroomParish

				If cbMarGroomCondition.DataSource Is Nothing Then
					cbMarGroomCondition.DataSource = MainForm.tabGroomCondition
					cbMarGroomCondition.ValueMember = "FileValue"
					cbMarGroomCondition.DisplayMember = "DisplayValue"
				End If

				cbMarGroomCondition.SelectedValue = row.GroomCondition

				txtMarGroomOccupation.Text = row.GroomOccupation
				txtMarGroomAbode.Text = row.GroomAbode
				txtMarBrideForenames.Text = row.BrideForenames
				txtMarBrideSurname.Text = row.BrideSurname
				txtMarBrideAge.Text = row.BrideAge
				txtMarBrideParish.Text = row.BrideParish

				If cbMarBrideCondition.DataSource Is Nothing Then
					cbMarBrideCondition.DataSource = MainForm.tabBrideCondition
					cbMarBrideCondition.ValueMember = "FileValue"
					cbMarBrideCondition.DisplayMember = "DisplayValue"
				End If

				cbMarBrideCondition.SelectedValue = row.BrideCondition

				txtMarBrideOccupation.Text = row.BrideOccupation
				txtMarBrideAbode.Text = row.BrideAbode
				txtMarGroomFatherForenames.Text = row.GroomFatherForenames
				txtMarGroomFatherSurname.Text = row.GroomFatherSurname
				txtMarGroomFatherOccupation.Text = row.GroomFatherOccupation
				txtMarBrideFatherForenames.Text = row.BrideFatherForenames
				txtMarBrideFatherSurname.Text = row.BrideFatherSurname
				txtMarBrideFatherOccupation.Text = row.BrideFatherOccupation
				txtMarWitness1Forenames.Text = row.Witness1Forenames
				txtMarWitness1Surname.Text = row.Witness1Surname
				txtMarWitness2Forenames.Text = row.Witness2Forenames
				txtMarWitness2Surname.Text = row.Witness2Surname
				txtMarNotes.Text = row.Notes

			End If

		Else
			lvData.Items(_ActivatedListItem).Selected = True
		End If
	End Sub

	Private Sub lvData_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvData.ColumnClick
		Dim colHeader As ColumnHeader = lvData.Columns(e.Column)

		' It is not useful to be able to sort on certain columns
		'
		If colHeader.Name = "County" OrElse colHeader.Name = "Place" OrElse colHeader.Name = "Church" OrElse colHeader.Name = "Notes" _
		 OrElse colHeader.Name = "Relationship" OrElse colHeader.Name = "Sex" OrElse colHeader.Name = "Age" _
		 OrElse colHeader.Name = "GroomAge" OrElse colHeader.Name = "GroomCondition" OrElse colHeader.Name = "BrideAge" OrElse colHeader.Name = "BrideCondition" Then
			MessageBox.Show(String.Format(My.Resources.err0031, colHeader.Name), "Column Sort", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0031)
			Exit Sub
		End If

		lvData.ListViewItemSorter = New ListViewItemComparer(colHeader)

		MainForm.mnuFileUnsortRecords.Visible = True
		MainForm.mnuFileUnsortRecords.Enabled = True
		MainForm.BindingNavigatorUnsortFileButton.Enabled = True
	End Sub

	Public Sub ClearPanel()
		Select Case MainForm._File.FileType
			Case "BAPTISMS"
				ClearBaptismPanel()

			Case "BURIALS"
				ClearBurialPanel()

			Case "MARRIAGES"
				ClearMarriagePanel()

		End Select
	End Sub

	Private Sub btnBapCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBapCancel.Click
		ClearBaptismPanel()
	End Sub

	Private Sub btnBurCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBurCancel.Click
		ClearBurialPanel()
	End Sub

	Private Sub btnMarCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarCancel.Click
		ClearMarriagePanel()
	End Sub

	Private Sub ClearBaptismPanel()
		_ActivatedListItem = -1
		_SelectedDataRow = -1
		_ItemActivated = False

		txtBapRegNo.Enabled = False
		txtBapBirthDate.Enabled = False
		txtBapBaptismDate.Enabled = False
		txtBapForenames.Enabled = False
		cbBapSex.Enabled = False
		txtBapFathersForenames.Enabled = False
		txtBapMothersForenames.Enabled = False
		txtBapFathersSurname.Enabled = False
		txtBapMothersSurname.Enabled = False
		txtBapAbode.Enabled = False
		txtBapFathersOccupation.Enabled = False
		txtBapNotes.Enabled = False

		labBapFiche.Visible = False
		labBapFiche.Enabled = False
		txtBapFiche.Visible = False
		txtBapFiche.Enabled = False
		txtBapFiche.Text = ""
		labBapImage.Visible = False
		labBapImage.Enabled = False
		txtBapImage.Visible = False
		txtBapImage.Enabled = False
		txtBapImage.Text = ""

		txtBapRegNo.Text = ""
		txtBapBirthDate.Text = ""
		txtBapBaptismDate.Text = ""
		txtBapForenames.Text = ""
		cbBapSex.SelectedIndex = -1
		txtBapFathersForenames.Text = ""
		txtBapMothersForenames.Text = ""
		txtBapFathersSurname.Text = ""
		txtBapMothersSurname.Text = ""
		txtBapAbode.Text = ""
		txtBapFathersOccupation.Text = ""
		txtBapNotes.Text = ""

		btnBapSave.Enabled = False
		btnBapSave.Text = "Save"
		btnBapCancel.Enabled = False
		btnBapDelete.Enabled = False
	End Sub

	Private Sub ClearBurialPanel()
		_ActivatedListItem = -1
		_SelectedDataRow = -1
		_ItemActivated = False

		txtBurRegNo.Enabled = False
		txtBurBurialDate.Enabled = False
		txtBurForenames.Enabled = False
		cbBurRelationship.Enabled = False
		txtBurMaleRelativeForename.Enabled = False
		txtBurFemaleRelativeForename.Enabled = False
		txtBurRelativeSurname.Enabled = False
		txtBurSurname.Enabled = False
		txtBurAge.Enabled = False
		txtBurAbode.Enabled = False
		txtBurNotes.Enabled = False

		labBurFiche.Visible = False
		labBurFiche.Enabled = False
		txtBurFiche.Visible = False
		txtBurFiche.Enabled = False
		txtBurFiche.Text = ""
		labBurImage.Visible = False
		labBurImage.Enabled = False
		txtBurImage.Visible = False
		txtBurImage.Enabled = False
		txtBurImage.Text = ""

		txtBurRegNo.Text = ""
		txtBurBurialDate.Text = ""
		txtBurForenames.Text = ""
		cbBurRelationship.SelectedIndex = -1
		txtBurMaleRelativeForename.Text = ""
		txtBurFemaleRelativeForename.Text = ""
		txtBurRelativeSurname.Text = ""
		txtBurSurname.Text = ""
		txtBurAge.Text = ""
		txtBurAbode.Text = ""
		txtBurNotes.Text = ""

		btnBurSave.Enabled = False
		btnBurSave.Text = "Save"
		btnBurCancel.Enabled = False
		btnBurDelete.Enabled = False
	End Sub

	Private Sub ClearMarriagePanel()
		_ActivatedListItem = -1
		_SelectedDataRow = -1
		_ItemActivated = False

		txtMarRegNo.Enabled = False
		txtMarDate.Enabled = False
		txtMarGroomForenames.Enabled = False
		txtMarGroomSurname.Enabled = False
		txtMarGroomAge.Enabled = False
		txtMarGroomParish.Enabled = False
		cbMarGroomCondition.Enabled = False
		txtMarGroomOccupation.Enabled = False
		txtMarGroomAbode.Enabled = False
		txtMarBrideForenames.Enabled = False
		txtMarBrideSurname.Enabled = False
		txtMarBrideAge.Enabled = False
		txtMarBrideParish.Enabled = False
		cbMarBrideCondition.Enabled = False
		txtMarBrideOccupation.Enabled = False
		txtMarBrideAbode.Enabled = False
		txtMarGroomFatherForenames.Enabled = False
		txtMarGroomFatherSurname.Enabled = False
		txtMarGroomFatherOccupation.Enabled = False
		txtMarBrideFatherForenames.Enabled = False
		txtMarBrideFatherSurname.Enabled = False
		txtMarBrideFatherOccupation.Enabled = False
		txtMarWitness1Forenames.Enabled = False
		txtMarWitness1Surname.Enabled = False
		txtMarWitness2Forenames.Enabled = False
		txtMarWitness2Surname.Enabled = False
		txtMarNotes.Enabled = False

		labMarFiche.Visible = False
		labMarFiche.Enabled = False
		txtMarFiche.Visible = False
		txtMarFiche.Enabled = False
		txtMarFiche.Text = ""
		labMarImage.Visible = False
		labMarImage.Enabled = False
		txtMarImage.Visible = False
		txtMarImage.Enabled = False
		txtMarImage.Text = ""

		txtMarRegNo.Text = ""
		txtMarDate.Text = ""
		txtMarGroomForenames.Text = ""
		txtMarGroomSurname.Text = ""
		txtMarGroomAge.Text = ""
		txtMarGroomParish.Text = ""
		cbMarGroomCondition.SelectedIndex = -1
		txtMarGroomOccupation.Text = ""
		txtMarGroomAbode.Text = ""
		txtMarBrideForenames.Text = ""
		txtMarBrideSurname.Text = ""
		txtMarBrideAge.Text = ""
		txtMarBrideParish.Text = ""
		cbMarBrideCondition.SelectedIndex = -1
		txtMarBrideOccupation.Text = ""
		txtMarBrideAbode.Text = ""
		txtMarGroomFatherForenames.Text = ""
		txtMarGroomFatherSurname.Text = ""
		txtMarGroomFatherOccupation.Text = ""
		txtMarBrideFatherForenames.Text = ""
		txtMarBrideFatherSurname.Text = ""
		txtMarBrideFatherOccupation.Text = ""
		txtMarWitness1Forenames.Text = ""
		txtMarWitness1Surname.Text = ""
		txtMarWitness2Forenames.Text = ""
		txtMarWitness2Surname.Text = ""
		txtMarNotes.Text = ""

		btnMarSave.Enabled = False
		btnMarCancel.Enabled = False
		btnMarDelete.Enabled = False
	End Sub

	Private Sub btnBapDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBapDelete.Click
		If Not frmImageViewer Is Nothing Then
			If Not frmImageViewer.IsDisposed Then
				If frmImageViewer.Visible Then frmImageViewer.Hide()
			End If
		End If

		If MessageBox.Show(My.Resources.msgDeleteRow, "Delete Baptism Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
			Dim dt As TranscriptionTables.BaptismsDataTable = lvData.DataSource.DataSource
			dt.Rows.RemoveAt(_SelectedDataRow)
			ClearBaptismPanel()
			lblRecordCount.Text = dt.Rows.Count

			MainForm.mnuFileSaveFile.Enabled = True
			MainForm.fileChanged = True
			MainForm.BindingNavigatorSaveFileButton.Enabled = MainForm.fileOpen And MainForm.fileChanged
		End If

		If Not frmImageViewer Is Nothing Then
			If Not frmImageViewer.IsDisposed Then
				If Not frmImageViewer.Visible Then frmImageViewer.Show()
			End If
		End If

	End Sub

	Private Sub btnBurDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBurDelete.Click
		If Not frmImageViewer Is Nothing Then
			If Not frmImageViewer.IsDisposed Then
				If frmImageViewer.Visible Then frmImageViewer.Hide()
			End If
		End If

		If MessageBox.Show(My.Resources.msgDeleteRow, "Delete Burial Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
			Dim dt As TranscriptionTables.BurialsDataTable = lvData.DataSource.DataSource
			dt.Rows.RemoveAt(_SelectedDataRow)
			ClearBurialPanel()
			lblRecordCount.Text = dt.Rows.Count

			MainForm.mnuFileSaveFile.Enabled = True
			MainForm.fileChanged = True
			MainForm.BindingNavigatorSaveFileButton.Enabled = MainForm.fileOpen And MainForm.fileChanged
		End If

		If Not frmImageViewer Is Nothing Then
			If Not frmImageViewer.IsDisposed Then
				If Not frmImageViewer.Visible Then frmImageViewer.Show()
			End If
		End If

	End Sub

	Private Sub btnMarDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarDelete.Click
		If Not frmImageViewer Is Nothing Then
			If Not frmImageViewer.IsDisposed Then
				If frmImageViewer.Visible Then frmImageViewer.Hide()
			End If
		End If

		If MessageBox.Show(My.Resources.msgDeleteRow, "Delete Marriage Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
			Dim dt As TranscriptionTables.MarriagesDataTable = lvData.DataSource.DataSource
			dt.Rows.RemoveAt(_SelectedDataRow)
			ClearMarriagePanel()
			lblRecordCount.Text = dt.Rows.Count

			MainForm.mnuFileSaveFile.Enabled = True
			MainForm.fileChanged = True
			MainForm.BindingNavigatorSaveFileButton.Enabled = MainForm.fileOpen And MainForm.fileChanged
		End If

		If Not frmImageViewer Is Nothing Then
			If Not frmImageViewer.IsDisposed Then
				If Not frmImageViewer.Visible Then frmImageViewer.Show()
			End If
		End If

	End Sub

	Private Sub btnBapSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBapSave.Click
		MainForm.panelValidator.Validate()
		If Not MainForm.panelValidator.IsValid Then
			Dim rc = MessageBox.Show(My.Resources.err0062, "Save BAPTISM record", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button3, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0062)
			Select Case rc
				Case DialogResult.Abort					' Throw the changes away
					ClearBaptismPanel()
					Exit Sub

				Case DialogResult.Retry					' Go back and correct the record
					Exit Sub
			End Select
		End If

		' Update the record in the DataTable
		'
		Dim dt As TranscriptionTables.BaptismsDataTable = lvData.DataSource.DataSource
		Dim row As TranscriptionTables.BaptismsRow = dt.Rows(_SelectedDataRow)

		row.RegNo = txtMarRegNo.Text
		row.BirthDate = txtBapBirthDate.Text
		row.BaptismDate = txtBapBaptismDate.Text
		row.Forenames = txtBapForenames.Text
		row.Sex = cbBapSex.SelectedValue
		row.FathersName = txtBapFathersForenames.Text
		row.MothersName = txtBapMothersForenames.Text
		row.FathersSurname = txtBapFathersSurname.Text
		row.MothersSurname = txtBapMothersSurname.Text
		row.Abode = txtBapAbode.Text
		row.FathersOccupation = txtBapFathersOccupation.Text
		row.Notes = txtBapNotes.Text

		If MainForm.ldsFile Then
			row.LDSFiche = txtBapFiche.Text
			row.LDSImage = txtBapImage.Text
		End If

		ClearBaptismPanel()
	End Sub

	Private Sub btnBurSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBurSave.Click
		MainForm.panelValidator.Validate()
		If Not MainForm.panelValidator.IsValid Then
			Dim rc = MessageBox.Show(My.Resources.err0062, "Save BURIAL record", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button3, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0062)
			Select Case rc
				Case DialogResult.Abort					' Throw the changes away
					ClearBurialPanel()
					Exit Sub

				Case DialogResult.Retry					' Go back and correct the record
					Exit Sub
			End Select
		End If

		' Update the record in the DataTable
		'
		Dim dt As TranscriptionTables.BurialsDataTable = lvData.DataSource.DataSource
		Dim row As TranscriptionTables.BurialsRow = dt.Rows(_SelectedDataRow)

		row.RegNo = txtBurRegNo.Text
		row.BurialDate = txtBurBurialDate.Text
		row.Forenames = txtBurForenames.Text
		row.Relationship = cbBurRelationship.SelectedValue
		row.MaleForenames = txtBurMaleRelativeForename.Text
		row.FemaleForenames = txtBurFemaleRelativeForename.Text
		row.RelativeSurname = txtBurRelativeSurname.Text
		row.Surname = txtBurSurname.Text
		row.Age = txtBurAge.Text
		row.Abode = txtBurAbode.Text
		row.Notes = txtBurNotes.Text

		If MainForm.ldsFile Then
			row.LDSFiche = txtBurFiche.Text
			row.LDSImage = txtBurImage.Text
		End If

		ClearBurialPanel()
	End Sub

	Private Sub btnMarSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarSave.Click
		MainForm.panelValidator.Validate()
		If Not MainForm.panelValidator.IsValid Then
			Dim rc = MessageBox.Show(My.Resources.err0062, "Save MARRIAGE record", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button3, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0062)
			Select Case rc
				Case DialogResult.Abort					' Throw the changes away
					ClearMarriagePanel()
					Exit Sub

				Case DialogResult.Retry					' Go back and correct the record
					Exit Sub
			End Select
		End If

		' Update the record in the DataTable
		'
		Dim dt As TranscriptionTables.MarriagesDataTable = lvData.DataSource.DataSource
		Dim row As TranscriptionTables.MarriagesRow = dt.Rows(_SelectedDataRow)

		row.RegNo = txtMarRegNo.Text
		row.MarriageDate = txtMarDate.Text
		row.GroomForenames = txtMarGroomForenames.Text
		row.GroomSurname = txtMarGroomSurname.Text
		row.GroomAge = txtMarGroomAge.Text
		row.GroomParish = txtMarGroomParish.Text
		row.GroomCondition = cbMarGroomCondition.SelectedValue
		row.GroomOccupation = txtMarGroomOccupation.Text
		row.GroomAbode = txtMarGroomAbode.Text
		row.BrideForenames = txtMarBrideForenames.Text
		row.BrideSurname = txtMarBrideSurname.Text
		row.BrideAge = txtMarBrideAge.Text
		row.BrideParish = txtMarBrideParish.Text
		row.BrideCondition = cbMarBrideCondition.SelectedValue
		row.BrideOccupation = txtMarBrideOccupation.Text
		row.BrideAbode = txtMarBrideAbode.Text
		row.GroomFatherForenames = txtMarGroomFatherForenames.Text
		row.GroomFatherSurname = txtMarGroomFatherSurname.Text
		row.GroomFatherOccupation = txtMarGroomFatherOccupation.Text
		row.BrideFatherForenames = txtMarBrideFatherForenames.Text
		row.BrideFatherSurname = txtMarBrideFatherSurname.Text
		row.BrideFatherOccupation = txtMarBrideFatherOccupation.Text
		row.Witness1Forenames = txtMarWitness1Forenames.Text
		row.Witness1Surname = txtMarWitness1Surname.Text
		row.Witness2Forenames = txtMarWitness2Forenames.Text
		row.Witness2Surname = txtMarWitness2Surname.Text
		row.Notes = txtMarNotes.Text

		If MainForm.ldsFile Then
			row.LDSFiche = txtMarFiche.Text
			row.LDSImage = txtMarImage.Text
		End If

		ClearMarriagePanel()
	End Sub

	Private Sub customDateValidator_Validating(ByVal sender As System.Object, ByVal e As CustomValidation.CustomValidator.ValidatingCancelEventArgs) Handles customMarriageDateValidator.Validating, customBurialDateValidator.Validating, customBirthDateValidator.Validating, customBaptismDateValidator.Validating
		Dim validator As CustomValidation.CustomValidator = CType(sender, CustomValidation.CustomValidator)
		Dim control As TextBox = CType(validator.ControlToValidate, TextBox)
		Dim msg As String = ""
		Dim m() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}

		e.Valid = True
		validator.ErrorMessage = ""
		Select Case MainForm._File.FileType
			Case "BAPTISMS"
				If control.Parent Is grpBaptisms Then
					e.Valid = Validations.ValidateDate(control.Text, msg, m)
					validator.ErrorMessage = msg
					Console.WriteLine(String.Format("Name: {0} {1} {2}", control.Name, control.ToString, e.Valid))
				End If

			Case "BURIALS"
				If control.Parent Is grpBurials Then
					e.Valid = Validations.ValidateDate(control.Text, msg, m)
					validator.ErrorMessage = msg
					Console.WriteLine(String.Format("Name: {0} {1} {2}", control.Name, control.ToString, e.Valid))
				End If

			Case "MARRIAGES"
				If control.Parent Is grpMarriages Then
					e.Valid = Validations.ValidateDate(control.Text, msg, m)
					validator.ErrorMessage = msg
					Console.WriteLine(String.Format("Name: {0} {1} {2}", control.Name, control.ToString, e.Valid))
				End If

		End Select

	End Sub

	Private Sub customBurialAgeValidator_Validating(ByVal sender As System.Object, ByVal e As CustomValidation.CustomValidator.ValidatingCancelEventArgs) Handles customBurialAgeValidator.Validating
		Dim validator As CustomValidation.CustomValidator = CType(sender, CustomValidation.CustomValidator)
		Dim control As TextBox = CType(validator.ControlToValidate, TextBox)
		Dim msg As String = ""

		e.Valid = True
		validator.ErrorMessage = ""
		If MainForm._File.FileType = "BURIALS" Then
			e.Valid = Validations.ValidateBurialAge(control.Text, msg, True)
			validator.ErrorMessage = msg
			Console.WriteLine(String.Format("Name: {0} {1} {2}", control.Name, control.ToString, e.Valid))
		End If
	End Sub

	Private Sub customGroomAgeValidator_Validating(ByVal sender As System.Object, ByVal e As CustomValidation.CustomValidator.ValidatingCancelEventArgs) Handles customGroomAgeValidator.Validating
		Dim validator As CustomValidation.CustomValidator = CType(sender, CustomValidation.CustomValidator)
		Dim control As TextBox = CType(validator.ControlToValidate, TextBox)
		Dim msg As String = ""

		e.Valid = True
		validator.ErrorMessage = ""
		If MainForm._File.FileType = "MARRIAGES" Then
			e.Valid = Validations.ValidateGroomAge(control.Text, msg, True)
			validator.ErrorMessage = msg
			Console.WriteLine(String.Format("Name: {0} {1} {2}", control.Name, control.ToString, e.Valid))
		End If
	End Sub

	Private Sub customBrideAgeValidator_Validating(ByVal sender As System.Object, ByVal e As CustomValidation.CustomValidator.ValidatingCancelEventArgs) Handles customBrideageValidator.Validating
		Dim validator As CustomValidation.CustomValidator = CType(sender, CustomValidation.CustomValidator)
		Dim control As TextBox = CType(validator.ControlToValidate, TextBox)
		Dim msg As String = ""

		e.Valid = True
		validator.ErrorMessage = ""
		If MainForm._File.FileType = "MARRIAGES" Then
			e.Valid = Validations.ValidateBrideAge(control.Text, msg, True)
			validator.ErrorMessage = msg
			Console.WriteLine(String.Format("Name: {0} {1} {2}", control.Name, control.ToString, e.Valid))
		End If
	End Sub

	Private Sub customRegNoValidator_Validating(ByVal sender As System.Object, ByVal e As CustomValidation.CustomValidator.ValidatingCancelEventArgs) Handles customBapRegNoValidator.Validating, customMarRegNoValidator.Validating, customBurRegNoValidator.Validating
		Dim validator As CustomValidation.CustomValidator = CType(sender, CustomValidation.CustomValidator)
		Dim control As TextBox = CType(validator.ControlToValidate, TextBox)
		Dim msg As String = ""

		e.Valid = True
		Select Case MainForm._File.FileType
			Case "BAPTISMS"
				If control.Parent Is grpBaptisms Then
					e.Valid = String.IsNullOrEmpty(control.Text) OrElse IsNumeric(control.Text)
					Console.WriteLine(String.Format("Name: {0} {1} {2}", control.Name, control.ToString, e.Valid))
				End If

			Case "BURIALS"
				If control.Parent Is grpBurials Then
					e.Valid = String.IsNullOrEmpty(control.Text) OrElse IsNumeric(control.Text)
					Console.WriteLine(String.Format("Name: {0} {1} {2}", control.Name, control.ToString, e.Valid))
				End If

			Case "MARRIAGES"
				If control.Parent Is grpMarriages Then
					e.Valid = String.IsNullOrEmpty(control.Text) OrElse IsNumeric(control.Text)
					Console.WriteLine(String.Format("Name: {0} {1} {2}", control.Name, control.ToString, e.Valid))
				End If
		End Select

	End Sub

	Class ListViewItemComparer
		Implements IComparer
		Private col As ColumnHeader
		Private order As SortOrder

		Public Sub New()
			col = Nothing
			order = SortOrder.Ascending
		End Sub

		Public Sub New(ByVal column As ColumnHeader)
			col = column
			order = SortOrder.Ascending
		End Sub

		Public Sub New(ByVal column As ColumnHeader, ByVal order As SortOrder)
			col = column
			order = order
		End Sub

		Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
			Dim compareresult
			If col Is Nothing Then Return 0
			If col.Index = -1 Then Return 0
			Dim lviX As ListViewItem = CType(x, ListViewItem)
			Dim lviY As ListViewItem = CType(y, ListViewItem)
			Dim Value1 As String = lviX.SubItems(col.Index).Text
			Dim Value2 As String = lviY.SubItems(col.Index).Text

			If Value1 = String.Empty AndAlso Value2 = String.Empty Then
				compareresult = 0
			Else
				' Register numbers - 16-bit unsigned integers
				If col.Name = "RegNo" OrElse col.Name = "LoadOrder" Then
					Dim res1 As Integer, res2 As Integer
					Dim v1 = Integer.TryParse(Value1, res1)
					Dim v2 = Integer.TryParse(Value2, res2)

					If v1 AndAlso v2 Then
						If res1 < res2 Then compareresult = -1 Else If res1 = res2 Then compareresult = 0 Else compareresult = 1
					Else
						compareresult = String.Compare(Value1, Value2, True)
					End If
					Return compareresult
				End If

				' Dates need VERY VERY SPECIAL handling!
				If col.Name.Contains("Date") Then
					'	For any Date field, this gets complicated
					'
					Dim msg As String = ""
					Dim m1() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}
					Dim m2() As String = {Nothing, Nothing, Nothing, Nothing, Nothing}

					'	One of the fields blank and the other non-blank is simple
					'
					If Value1 = String.Empty AndAlso Value2 <> String.Empty Then
						compareresult = -1
					ElseIf Value1 <> String.Empty AndAlso Value2 = String.Empty Then
						compareresult = 1
					Else
						Dim d1 As DateTime, d2 As DateTime
						If DateTime.TryParse(Value1, d1) Then
							If DateTime.TryParse(Value2, d2) Then
								compareresult = DateTime.Compare(d1, d2)
							Else
								If Value1 <> String.Empty AndAlso Not Validations.ValidateDate(Value1, msg, m1) Then
									If Not WinREG.MainForm.badDates.Contains(Value1) Then
										WinREG.MainForm.badDates.Add(Value1)
									End If
								End If

								If Value2 <> String.Empty AndAlso Not Validations.ValidateDate(Value2, msg, m2) Then
									If Not WinREG.MainForm.badDates.Contains(Value2) Then
										WinREG.MainForm.badDates.Add(Value2)
									End If
								End If

								Dim date1 As String = WinREG.MainForm.ReformatDateString(m1)
								Dim date2 As String = WinREG.MainForm.ReformatDateString(m2)

								compareresult = String.Compare(date1, date2)
							End If
						Else
							If Value1 <> String.Empty AndAlso Not Validations.ValidateDate(Value1, msg, m1) Then
								If Not WinREG.MainForm.badDates.Contains(Value1) Then
									WinREG.MainForm.badDates.Add(Value1)
								End If
							End If

							If Value2 <> String.Empty AndAlso Not Validations.ValidateDate(Value2, msg, m2) Then
								If Not WinREG.MainForm.badDates.Contains(Value2) Then
									WinREG.MainForm.badDates.Add(Value2)
								End If
							End If

							Dim date1 As String = WinREG.MainForm.ReformatDateString(m1)
							Dim date2 As String = WinREG.MainForm.ReformatDateString(m2)

							compareresult = String.Compare(date1, date2)
						End If
					End If
				Else
					'	For general text strings this is easy
					'
					compareresult = String.Compare(Value1, Value2, True)
				End If
			End If

			'If sortOrder is descending, invert the compareResult sign.
			If order = Windows.Forms.SortOrder.Descending Then compareresult = -compareresult
			Return compareresult
		End Function

	End Class

End Class
