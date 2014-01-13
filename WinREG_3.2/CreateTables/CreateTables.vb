'	$Date: 2012-12-20 18:49:16 +0200 (Thu, 20 Dec 2012) $
'	$Rev: 191 $
'	$Id: CreateTables.vb 191 2012-12-20 16:49:16Z Mikefry $
'
'	CreateTables - Version 1.0.0
'

Imports System.IO
Imports System.Globalization
Imports System.Text

Public Class dlgCreateTables
	Dim tabLookUps As New WinREG.LookupTables()
	Dim tabBapSex As DataTable = tabLookUps.BaptismSex
	Dim tabBurialRelationship As DataTable = tabLookUps.BurialRelationship
	Dim tabGroomCondition As DataTable = tabLookUps.GroomCondition
	Dim tabBrideCondition As DataTable = tabLookUps.BrideCondition
	Dim tabRecordTypes As DataTable = tabLookUps.RecordTypes
	Dim tabChapmanCodes As DataTable = tabLookUps.ChapmanCodes

	Dim tabTranscripts As New WinREG.TranscriptionTables()
	Dim tabBaptisms As DataTable = tabTranscripts.Baptisms
	Dim tabBurials As DataTable = tabTranscripts.Burials
	Dim tabMarriages As DataTable = tabTranscripts.Marriages

	Public _Culture As CultureInfo = CultureInfo.InvariantCulture
	Public _Encoding As Encoding = Encoding.GetEncoding("iso-8859-1")

	Private Sub dlgCreateTables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim MyTablesPath As String = My.Application.Info.DirectoryPath + "\"
		Dim MyTablesFile As String = "winreg.tables"
		Dim MyTranscriptsFile As String = "winreg.transcripts"

		If File.Exists(MyTablesPath & MyTablesFile) Then
			Dim fs As FileStream = Nothing
			Dim stmReader As StreamReader = Nothing

			Try
				fs = New FileStream(MyTablesPath & MyTablesFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
				stmReader = New StreamReader(fs, _Encoding)
				tabLookUps.ReadXml(stmReader, Data.XmlReadMode.Auto)

			Catch ex As Exception
				Dim extra As String = ""
				If Not (ex.Data Is Nothing) Then
					extra = vbCrLf & "Extra information" & vbCrLf
					Dim de As DictionaryEntry
					For Each de In ex.Data
						extra += de.Key & ":" & de.Value & vbCrLf
					Next de
				End If
				Dim msgText As String = " LoadTables " & ex.Message & ex.StackTrace & extra
				My.Application.Log.WriteEntry(My.Computer.Clock.GmtTime.ToString & msgText, TraceEventType.Error)

			Finally
				If Not (stmReader Is Nothing) Then stmReader.Close()
				If Not (fs Is Nothing) Then fs.Close()
			End Try
		Else
			If tabRecordTypes.Rows.Count = 0 Then
				tabRecordTypes.Rows.Add(tabLookUps.addRecordTypeRow("BA", "Baptisms"))
				tabRecordTypes.Rows.Add(tabLookUps.addRecordTypeRow("BU", "Burials"))
				tabRecordTypes.Rows.Add(tabLookUps.addRecordTypeRow("MA", "Marriages"))
			End If

			If tabBapSex.Rows.Count = 0 Then
				tabBapSex.Rows.Add(tabLookUps.addApplicationBaptismSexRow(String.Empty, String.Empty))
				tabBapSex.Rows.Add(tabLookUps.addApplicationBaptismSexRow("-", "Unknown"))
				tabBapSex.Rows.Add(tabLookUps.addApplicationBaptismSexRow("M", "Male"))
				tabBapSex.Rows.Add(tabLookUps.addApplicationBaptismSexRow("F", "Female"))
			End If

			If tabChapmanCodes.Rows.Count = 0 Then
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CHI", "Channel Isles"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ENG", "England"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("IOM", "Isle of Man"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("IRL", "Ireland"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SCT", "Scotland"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WLS", "Wales"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ALL", "All countries"))

				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ALD", "Alderney"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("GSY", "Guernsey"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("JSY", "Jersey"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SRK", "Sark"))

				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("BDF", "Bedfordshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("BRK", "Berkshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("BKM", "Buckinghamshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CAM", "Cambridgeshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CHS", "Cheshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CON", "Cornwall"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CUL", "Cumberland"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DBY", "Derbyshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DEV", "Devonshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DOR", "Dorset"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DUR", "Durham"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ESS", "Essex"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("GLS", "Gloucestershire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("HAM", "Hampshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("HEF", "Herefordshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("HRT", "Hertfordshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("HUN", "Huntingdonshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("IOW", "Isle of Wight"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("KEN", "Kent"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LAN", "Lancashire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LEI", "Leicestershire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LIN", "Lincolnshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LND", "London"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MDX", "Middlesex"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("NFK", "Norfolk"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("NTH", "Northamptonshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("NBL", "Northumberland"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("NTT", "Nottinghamshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("OXF", "Oxfordshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("RUT", "Rutland"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SAL", "Shropshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SOM", "Somerset"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("STS", "Staffordshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SFK", "Suffolk"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SRY", "Surrey"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SSX", "Sussex"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WAR", "Warwickshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WES", "Westmorland"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WIL", "Wiltshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WOR", "Worcestershire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("YKS", "Yorkshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ERY", "East Riding Yorkshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("NRY", "North Riding Yorkshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WRY", "West Riding Yorkshire"))

				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ABD", "Aberdeenshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ANS", "Angus"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ARL", "Argyllshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("AYR", "Ayrshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("BAN", "Banffshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("BEW", "Berwickshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("BUT", "Bute"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CAI", "Caithness"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CLK", "Clackmannanshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DFS", "Dumfriesshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DNB", "Dunbartonshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ELN", "East Lothian"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("FIF", "Fifeshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("INV", "Inverness-shire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("KCD", "Kincardineshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("KRS", "Kinross-shire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("KKD", "Kircudbrightshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LKS", "Lanarkshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MLN", "Midlothian"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MOR", "Moray"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("NAI", "Nairnshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("OKI", "Orkney"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("PEE", "Peeblesshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("PER", "Perthshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("RFW", "Renfrewshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ROC", "Ross & Cromarty"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ROX", "Roxburghshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SEL", "Selkirkshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SHI", "Shetland"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("STI", "Stirlingshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SUT", "Sutherland"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WLN", "West Lothian"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WIG", "Wigtownshire"))

				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("BOR", "Borders"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CEN", "Central"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DGY", "Dumfries & Galloway"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("GMP", "Grampian"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("HLD", "Highland"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LTN", "Lothian"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("STD", "Strathclyde"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("TAY", "Tayside"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WIS", "Western Isles"))

				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("AGY", "Anglesey"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("BRE", "Brecknockshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CAE", "Caernarfonshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CGN", "Cardiganshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CMN", "Carmarthenshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DEN", "Denbighshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("FLN", "Flintshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("GLA", "Glamorgan"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MER", "Merionethshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MON", "Monmouthshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MGY", "Montgomeryshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("PEM", "Pembrokeshire"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("RAD", "Radnorshire"))

				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CWD", "Clywd"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DFD", "Dyfed"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("GNT", "Gwent"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("GWN", "Gwynedd"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MGM", "Mid Glamorgan"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("POW", "Powys"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SGM", "South Glamorgan"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WGM", "West Glamorgan"))

				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ANT", "Antrim"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ARM", "Armagh"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CAR", "Carlow"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CAV", "Cavan"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("CLA", "Clare"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("COR", "Cork"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DON", "Donegal"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DOW", "Down"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("DUB", "Dublin"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("FER", "Fermanagh"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("GAL", "Galway"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("KER", "Kerry"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("KID", "Kildare"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("KIK", "Kilkenny"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LET", "Leitrim"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LEX", "Leix"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LIM", "Limerick"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LDY", "Londonderry"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LOG", "Longford"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("LOU", "Louth"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MAY", "Mayo"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MEA", "Meath"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("MOG", "Monaghan"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("OFF", "Offaly"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("ROS", "Roscommon"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("SLI", "Sligo"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("TIP", "Tipperary"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("TYR", "Tyrone"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WAT", "Waterford"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WEM", "Westmeath"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WEX", "Wexford"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("WIC", "Wicklow"))

				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("OVB", "Overseas (British Subject)"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("OVF", "Overseas (Foreign)"))
				tabChapmanCodes.Rows.Add(tabLookUps.addChapmanCodeRow("UNK", "Unknown"))
			End If

			If tabBurialRelationship.Rows.Count = 0 Then
				tabBurialRelationship.Rows.Add(tabLookUps.addApplicationBurialRelationshipRow(String.Empty, String.Empty))
				tabBurialRelationship.Rows.Add(tabLookUps.addApplicationBurialRelationshipRow("son of", "son of"))
				tabBurialRelationship.Rows.Add(tabLookUps.addApplicationBurialRelationshipRow("dau of", "dau of"))
				tabBurialRelationship.Rows.Add(tabLookUps.addApplicationBurialRelationshipRow("wife of", "wife of"))
				tabBurialRelationship.Rows.Add(tabLookUps.addApplicationBurialRelationshipRow("husband of", "husband of"))
				tabBurialRelationship.Rows.Add(tabLookUps.addApplicationBurialRelationshipRow("widow of", "widow of"))
				tabBurialRelationship.Rows.Add(tabLookUps.addApplicationBurialRelationshipRow("relict of", "relict of"))
			End If

			If tabGroomCondition.Rows.Count = 0 Then
				tabGroomCondition.Rows.Add(tabLookUps.addApplicationGroomConditionRow(String.Empty, String.Empty))
				tabGroomCondition.Rows.Add(tabLookUps.addApplicationGroomConditionRow("bachelor", "bachelor"))
				tabGroomCondition.Rows.Add(tabLookUps.addApplicationGroomConditionRow("widower", "widower"))
				tabGroomCondition.Rows.Add(tabLookUps.addApplicationGroomConditionRow("single", "single man"))
				tabGroomCondition.Rows.Add(tabLookUps.addApplicationGroomConditionRow("virgin", "virgin"))
				tabGroomCondition.Rows.Add(tabLookUps.addApplicationGroomConditionRow("annulled", "previous marriage annulled"))
				tabGroomCondition.Rows.Add(tabLookUps.addApplicationGroomConditionRow("divorced", "divorced man"))
				tabGroomCondition.Rows.Add(tabLookUps.addApplicationGroomConditionRow("dissolved", "previous marriage dissolved"))
				tabGroomCondition.Rows.Add(tabLookUps.addApplicationGroomConditionRow("minor", "minor"))
			End If

			If tabBrideCondition.Rows.Count = 0 Then
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow(String.Empty, String.Empty))
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow("spinster", "spinster"))
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow("widow", "widow"))
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow("single", "single woman"))
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow("maiden", "maiden"))
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow("virgin", "virgin"))
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow("minor", "minor"))
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow("divorcee", "divorcee"))
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow("annulled", "previous marriage annulled"))
				tabBrideCondition.Rows.Add(tabLookUps.addApplicationBrideConditionRow("dissolved", "previous marriage dissolved"))
			End If

			Dim fs As FileStream = Nothing
			Dim stmWriter As StreamWriter = Nothing
			Try
				fs = New FileStream(MyTablesPath & MyTablesFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None)
				stmWriter = New StreamWriter(fs, _Encoding)
				tabLookUps.AcceptChanges()
				tabLookUps.WriteXml(stmWriter, Data.XmlWriteMode.WriteSchema)

			Catch ex As Exception
				Dim extra As String = ""
				If Not (ex.Data Is Nothing) Then
					extra = vbCrLf & "Extra information" & vbCrLf
					Dim de As DictionaryEntry
					For Each de In ex.Data
						extra += de.Key & ":" & de.Value & vbCrLf
					Next de
				End If
				Dim msgText As String = " SaveTables " & ex.Message & ex.StackTrace & extra
				My.Application.Log.WriteEntry(My.Computer.Clock.GmtTime.ToString & msgText, TraceEventType.Error)

			Finally
				If Not (stmWriter Is Nothing) Then stmWriter.Close()
				If Not (fs Is Nothing) Then fs.Close()
			End Try
		End If

		If File.Exists(MyTablesPath & MyTranscriptsFile) Then
		Else
			Dim fs As FileStream = Nothing
			Dim stmWriter As StreamWriter = Nothing
			Try
				fs = New FileStream(MyTablesPath & MyTranscriptsFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None)
				stmWriter = New StreamWriter(fs, _Encoding)
				tabTranscripts.AcceptChanges()
				tabTranscripts.WriteXml(stmWriter, Data.XmlWriteMode.WriteSchema)

			Catch ex As Exception
				Dim extra As String = ""
				If Not (ex.Data Is Nothing) Then
					extra = vbCrLf & "Extra information" & vbCrLf
					Dim de As DictionaryEntry
					For Each de In ex.Data
						extra += de.Key & ":" & de.Value & vbCrLf
					Next de
				End If
				Dim msgText As String = " SaveTables " & ex.Message & ex.StackTrace & extra
				My.Application.Log.WriteEntry(My.Computer.Clock.GmtTime.ToString & msgText, TraceEventType.Error)

			Finally
				If Not (stmWriter Is Nothing) Then stmWriter.Close()
				If Not (fs Is Nothing) Then fs.Close()
			End Try
		End If

	End Sub
End Class
