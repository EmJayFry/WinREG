<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
	Inherits System.Windows.Forms.Form
	'	Inherits DevExpress.XtraEditors.XtraForm

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Me.ctxStripGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.miCut = New System.Windows.Forms.ToolStripMenuItem
		Me.miCopy = New System.Windows.Forms.ToolStripMenuItem
		Me.miPaste = New System.Windows.Forms.ToolStripMenuItem
		Me.miDelete = New System.Windows.Forms.ToolStripMenuItem
		Me.popColumnsVisibility = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.ofdTranscript = New System.Windows.Forms.OpenFileDialog
		Me.msMain = New System.Windows.Forms.MenuStrip
		Me.tsFile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileNewDataFile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileOpenDataFile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileMRUList = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileMRUClearList = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
		Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuFileImportExcel = New System.Windows.Forms.ToolStripMenuItem
		Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
		Me.mnuFileCloseFile = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuFileSaveFile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileSaveFileAs = New System.Windows.Forms.ToolStripMenuItem
		Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuFilePrint = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFilePrintPreview = New System.Windows.Forms.ToolStripMenuItem
		Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuFileEditFileDetails = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileRenameFile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileValidateFileData = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileUnsortRecords = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileShowLDSColumns = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem
		Me.tsRecord = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRecordAddNewRecord = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRecordDeleteRecord = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRecordDuplicateRecord = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRecordInsertRecord = New System.Windows.Forms.ToolStripMenuItem
		Me.tsTools = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuToolsUseDataGrid = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuToolsImageViewer = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuToolsFreeREGServerGateway = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuToolsRecoverBackup = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuToolsDocumentTeplates = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuToolsBackupRestore = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuToolsFiltering = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuToolsRebuildLookUpTables = New System.Windows.Forms.ToolStripMenuItem
		Me.tsEdit = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEditUndo = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEditRedo = New System.Windows.Forms.ToolStripMenuItem
		Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuEditCut = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEditCopy = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuEditPaste = New System.Windows.Forms.ToolStripMenuItem
		Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuEditSelectAll = New System.Windows.Forms.ToolStripMenuItem
		Me.tsSettings = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsOptions = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsOptionsUserProgramOptions = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuSettingsOptionsBaptismSexTable = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsOptionsBurialRelationshipsTable = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsOptionsBrideMarriageStates = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsOptionsGroomMarriageStates = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsOptionsRecordTypesTable = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsOptionsChapmanCodesTable = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsColumnVisibility = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsUserSettings = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuSettingsSelectLayout = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsSaveLayout = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSettingsAutocompletion = New System.Windows.Forms.ToolStripMenuItem
		Me.tsMyTools = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuMyToolsCreateLookupTables = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuMyToolsCrashProgram = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuMyToolsException = New System.Windows.Forms.ToolStripMenuItem
		Me.tsHelp = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpContents = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpIndex = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpSearch = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpHowToUseTheHelpViewer = New System.Windows.Forms.ToolStripMenuItem
		Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuHelpTheWinREGBlog = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpVisitFreeREG = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpTranscriberInformation = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpEmailBugReport = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuHelpSetProgramDefaults = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuHelpVisitFreeREGForum = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuHelpConfigureUpdates = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpCheckForUpdates = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpSeparator3 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuHelpViewLogFile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpChangeHistory = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem
		Me.ttMain = New System.Windows.Forms.ToolTip(Me.components)
		Me.bwUpdater = New System.ComponentModel.BackgroundWorker
		Me.ofdExcel = New System.Windows.Forms.OpenFileDialog
		Me.tickDisplay = New System.Windows.Forms.Timer(Me.components)
		Me.sfdTranscript = New System.Windows.Forms.SaveFileDialog
		Me.bwCheckFile = New System.ComponentModel.BackgroundWorker
		Me.hlpMain = New System.Windows.Forms.HelpProvider
		Me.ssMain = New System.Windows.Forms.StatusStrip
		Me.lblFfilterStatus = New System.Windows.Forms.ToolStripStatusLabel
		Me.lblShowAll = New System.Windows.Forms.ToolStripStatusLabel
		Me.lblInformation = New System.Windows.Forms.ToolStripStatusLabel
		Me.lblDate = New System.Windows.Forms.ToolStripStatusLabel
		Me.lblUCF = New System.Windows.Forms.ToolStripStatusLabel
		Me.bnDGV = New System.Windows.Forms.BindingNavigator(Me.components)
		Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
		Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
		Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
		Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorDuplicateRecord = New System.Windows.Forms.ToolStripButton
		Me.toolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator
		Me.BindingNavigatorSaveFileButton = New System.Windows.Forms.ToolStripButton
		Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator
		Me.BindingNavigatorCutButton = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorCopyButton = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorPasteButton = New System.Windows.Forms.ToolStripButton
		Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator
		Me.BindingNavigatorViewErrorsButton = New System.Windows.Forms.ToolStripButton
		Me.BindingNavigatorUnsortFileButton = New System.Windows.Forms.ToolStripButton
		Me.mainDGV = New WinREG.myDGV
		Me.sfdColumnLayout = New System.Windows.Forms.SaveFileDialog
		Me.ofdColumnLayout = New System.Windows.Forms.OpenFileDialog
		Me.tscMain = New System.Windows.Forms.ToolStripContainer
		Me.tsFilters = New System.Windows.Forms.ToolStrip
		Me.lblFiltersText = New System.Windows.Forms.ToolStripLabel
		Me.cbFilterColumns = New System.Windows.Forms.ToolStripComboBox
		Me.cbFilterOperators = New System.Windows.Forms.ToolStripComboBox
		Me.cbFilterValues = New System.Windows.Forms.ToolStripComboBox
		Me.txtFilterString = New System.Windows.Forms.ToolStripTextBox
		Me.panelWinREG2 = New WinREG.WinREG2_Panel
		Me.mainWelcomeText = New System.Windows.Forms.TextBox
		Me.tickRecovery = New System.Windows.Forms.Timer(Me.components)
		Me.fswTranscripts = New System.IO.FileSystemWatcher
		Me.panelValidator = New CustomValidation.ContainerValidator
		Me.ctxStripGrid.SuspendLayout()
		Me.msMain.SuspendLayout()
		Me.ssMain.SuspendLayout()
		CType(Me.bnDGV, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.bnDGV.SuspendLayout()
		CType(Me.mainDGV, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tscMain.BottomToolStripPanel.SuspendLayout()
		Me.tscMain.ContentPanel.SuspendLayout()
		Me.tscMain.TopToolStripPanel.SuspendLayout()
		Me.tscMain.SuspendLayout()
		Me.tsFilters.SuspendLayout()
		CType(Me.fswTranscripts, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ctxStripGrid
		'
		Me.ctxStripGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miCut, Me.miCopy, Me.miPaste, Me.miDelete})
		Me.ctxStripGrid.Name = "ctxStripGrid"
		Me.ctxStripGrid.Size = New System.Drawing.Size(108, 92)
		'
		'miCut
		'
		Me.miCut.Name = "miCut"
		Me.miCut.Size = New System.Drawing.Size(107, 22)
		Me.miCut.Text = "Cut"
		'
		'miCopy
		'
		Me.miCopy.Name = "miCopy"
		Me.miCopy.Size = New System.Drawing.Size(107, 22)
		Me.miCopy.Text = "Copy"
		'
		'miPaste
		'
		Me.miPaste.Name = "miPaste"
		Me.miPaste.Size = New System.Drawing.Size(107, 22)
		Me.miPaste.Text = "Paste"
		'
		'miDelete
		'
		Me.miDelete.Name = "miDelete"
		Me.miDelete.Size = New System.Drawing.Size(107, 22)
		Me.miDelete.Text = "Delete"
		'
		'popColumnsVisibility
		'
		Me.popColumnsVisibility.Name = "popColumnsVisibility"
		Me.popColumnsVisibility.ShowCheckMargin = True
		Me.popColumnsVisibility.ShowImageMargin = False
		Me.popColumnsVisibility.Size = New System.Drawing.Size(61, 4)
		'
		'ofdTranscript
		'
		Me.ofdTranscript.DefaultExt = "csv"
		Me.ofdTranscript.Filter = "Transcript files (*.csv)|*.csv"
		Me.ofdTranscript.SupportMultiDottedExtensions = True
		Me.ofdTranscript.Title = "Open FreeREG Transcription File"
		'
		'msMain
		'
		Me.msMain.Dock = System.Windows.Forms.DockStyle.None
		Me.hlpMain.SetHelpKeyword(Me.msMain, "menustrip.htm")
		Me.hlpMain.SetHelpNavigator(Me.msMain, System.Windows.Forms.HelpNavigator.Topic)
		Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsFile, Me.tsRecord, Me.tsTools, Me.tsEdit, Me.tsSettings, Me.tsMyTools, Me.tsHelp})
		Me.msMain.Location = New System.Drawing.Point(0, 0)
		Me.msMain.Name = "msMain"
		Me.hlpMain.SetShowHelp(Me.msMain, True)
		Me.msMain.Size = New System.Drawing.Size(733, 24)
		Me.msMain.TabIndex = 1
		Me.msMain.Text = "MenuStrip"
		'
		'tsFile
		'
		Me.tsFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileNewDataFile, Me.mnuFileOpenDataFile, Me.mnuFileMRUList, Me.mnuFileImportExcel, Me.toolStripSeparator, Me.mnuFileCloseFile, Me.ToolStripSeparator1, Me.mnuFileSaveFile, Me.mnuFileSaveFileAs, Me.toolStripSeparator3, Me.mnuFilePrint, Me.mnuFilePrintPreview, Me.toolStripSeparator4, Me.mnuFileEditFileDetails, Me.mnuFileRenameFile, Me.mnuFileValidateFileData, Me.mnuFileUnsortRecords, Me.mnuFileShowLDSColumns, Me.ToolStripSeparator14, Me.mnuFileExit})
		Me.tsFile.Name = "tsFile"
		Me.tsFile.Size = New System.Drawing.Size(37, 20)
		Me.tsFile.Text = "&File"
		'
		'mnuFileNewDataFile
		'
		Me.mnuFileNewDataFile.Image = CType(resources.GetObject("mnuFileNewDataFile.Image"), System.Drawing.Image)
		Me.mnuFileNewDataFile.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.mnuFileNewDataFile.Name = "mnuFileNewDataFile"
		Me.mnuFileNewDataFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
		Me.mnuFileNewDataFile.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileNewDataFile.Text = "&New Data File"
		Me.mnuFileNewDataFile.ToolTipText = "Create a new transcription file"
		'
		'mnuFileOpenDataFile
		'
		Me.mnuFileOpenDataFile.Image = CType(resources.GetObject("mnuFileOpenDataFile.Image"), System.Drawing.Image)
		Me.mnuFileOpenDataFile.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.mnuFileOpenDataFile.Name = "mnuFileOpenDataFile"
		Me.mnuFileOpenDataFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
		Me.mnuFileOpenDataFile.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileOpenDataFile.Text = "&Open"
		Me.mnuFileOpenDataFile.ToolTipText = "Open an existing transcripition file"
		'
		'mnuFileMRUList
		'
		Me.mnuFileMRUList.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileMRUClearList, Me.ToolStripSeparator10, Me.ToolStripSeparator15})
		Me.mnuFileMRUList.Enabled = False
		Me.mnuFileMRUList.Name = "mnuFileMRUList"
		Me.mnuFileMRUList.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileMRUList.Text = "Recent Items"
		Me.mnuFileMRUList.Visible = False
		'
		'mnuFileMRUClearList
		'
		Me.mnuFileMRUClearList.Name = "mnuFileMRUClearList"
		Me.mnuFileMRUClearList.Size = New System.Drawing.Size(193, 22)
		Me.mnuFileMRUClearList.Text = "Clear Recent Items List"
		Me.mnuFileMRUClearList.ToolTipText = "Clear the list of recently-used files"
		'
		'ToolStripSeparator10
		'
		Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
		Me.ToolStripSeparator10.Size = New System.Drawing.Size(190, 6)
		Me.ToolStripSeparator10.Visible = False
		'
		'ToolStripSeparator15
		'
		Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
		Me.ToolStripSeparator15.Size = New System.Drawing.Size(190, 6)
		Me.ToolStripSeparator15.Visible = False
		'
		'mnuFileImportExcel
		'
		Me.mnuFileImportExcel.Name = "mnuFileImportExcel"
		Me.mnuFileImportExcel.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileImportExcel.Text = "Import Spreadsheet File"
		Me.mnuFileImportExcel.ToolTipText = "Import a spreadsheet file"
		'
		'toolStripSeparator
		'
		Me.toolStripSeparator.Name = "toolStripSeparator"
		Me.toolStripSeparator.Size = New System.Drawing.Size(195, 6)
		'
		'mnuFileCloseFile
		'
		Me.mnuFileCloseFile.Name = "mnuFileCloseFile"
		Me.mnuFileCloseFile.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileCloseFile.Text = "&Close"
		Me.mnuFileCloseFile.ToolTipText = "Close the current file"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(195, 6)
		'
		'mnuFileSaveFile
		'
		Me.mnuFileSaveFile.Image = CType(resources.GetObject("mnuFileSaveFile.Image"), System.Drawing.Image)
		Me.mnuFileSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.mnuFileSaveFile.Name = "mnuFileSaveFile"
		Me.mnuFileSaveFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
		Me.mnuFileSaveFile.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileSaveFile.Text = "&Save"
		Me.mnuFileSaveFile.ToolTipText = "Save the current contents of the transcription file and keep it open"
		'
		'mnuFileSaveFileAs
		'
		Me.mnuFileSaveFileAs.Name = "mnuFileSaveFileAs"
		Me.mnuFileSaveFileAs.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileSaveFileAs.Text = "Save &As"
		'
		'toolStripSeparator3
		'
		Me.toolStripSeparator3.Name = "toolStripSeparator3"
		Me.toolStripSeparator3.Size = New System.Drawing.Size(195, 6)
		Me.toolStripSeparator3.Visible = False
		'
		'mnuFilePrint
		'
		Me.mnuFilePrint.Enabled = False
		Me.mnuFilePrint.Image = CType(resources.GetObject("mnuFilePrint.Image"), System.Drawing.Image)
		Me.mnuFilePrint.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.mnuFilePrint.Name = "mnuFilePrint"
		Me.mnuFilePrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
		Me.mnuFilePrint.Size = New System.Drawing.Size(198, 22)
		Me.mnuFilePrint.Text = "&Print"
		Me.mnuFilePrint.Visible = False
		'
		'mnuFilePrintPreview
		'
		Me.mnuFilePrintPreview.Enabled = False
		Me.mnuFilePrintPreview.Image = CType(resources.GetObject("mnuFilePrintPreview.Image"), System.Drawing.Image)
		Me.mnuFilePrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.mnuFilePrintPreview.Name = "mnuFilePrintPreview"
		Me.mnuFilePrintPreview.Size = New System.Drawing.Size(198, 22)
		Me.mnuFilePrintPreview.Text = "Print Pre&view"
		Me.mnuFilePrintPreview.Visible = False
		'
		'toolStripSeparator4
		'
		Me.toolStripSeparator4.Name = "toolStripSeparator4"
		Me.toolStripSeparator4.Size = New System.Drawing.Size(195, 6)
		'
		'mnuFileEditFileDetails
		'
		Me.mnuFileEditFileDetails.Name = "mnuFileEditFileDetails"
		Me.mnuFileEditFileDetails.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileEditFileDetails.Text = "File &Details"
		Me.mnuFileEditFileDetails.ToolTipText = "Show the file details"
		'
		'mnuFileRenameFile
		'
		Me.mnuFileRenameFile.Name = "mnuFileRenameFile"
		Me.mnuFileRenameFile.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileRenameFile.Text = "&Rename File"
		Me.mnuFileRenameFile.ToolTipText = "Rename a transcription file"
		'
		'mnuFileValidateFileData
		'
		Me.mnuFileValidateFileData.Name = "mnuFileValidateFileData"
		Me.mnuFileValidateFileData.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileValidateFileData.Text = "&Validate File"
		Me.mnuFileValidateFileData.ToolTipText = "Validate the contents of a transcription file"
		'
		'mnuFileUnsortRecords
		'
		Me.mnuFileUnsortRecords.Enabled = False
		Me.mnuFileUnsortRecords.Image = Global.WinREG.My.Resources.Resources.cancel
		Me.mnuFileUnsortRecords.Name = "mnuFileUnsortRecords"
		Me.mnuFileUnsortRecords.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileUnsortRecords.Text = "Unsort records"
		Me.mnuFileUnsortRecords.ToolTipText = "Reset order of records to the load-orderf"
		Me.mnuFileUnsortRecords.Visible = False
		'
		'mnuFileShowLDSColumns
		'
		Me.mnuFileShowLDSColumns.Enabled = False
		Me.mnuFileShowLDSColumns.Name = "mnuFileShowLDSColumns"
		Me.mnuFileShowLDSColumns.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileShowLDSColumns.Text = "Show LDS columns"
		Me.mnuFileShowLDSColumns.ToolTipText = "Show/Hide the columns related to the Fiche and Image"
		Me.mnuFileShowLDSColumns.Visible = False
		'
		'ToolStripSeparator14
		'
		Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
		Me.ToolStripSeparator14.Size = New System.Drawing.Size(195, 6)
		'
		'mnuFileExit
		'
		Me.mnuFileExit.Name = "mnuFileExit"
		Me.mnuFileExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
		Me.mnuFileExit.Size = New System.Drawing.Size(198, 22)
		Me.mnuFileExit.Text = "E&xit"
		Me.mnuFileExit.ToolTipText = "Exit from the program"
		'
		'tsRecord
		'
		Me.tsRecord.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRecordAddNewRecord, Me.mnuRecordDeleteRecord, Me.mnuRecordDuplicateRecord, Me.mnuRecordInsertRecord})
		Me.tsRecord.Name = "tsRecord"
		Me.tsRecord.Size = New System.Drawing.Size(56, 20)
		Me.tsRecord.Text = "&Record"
		Me.tsRecord.Visible = False
		'
		'mnuRecordAddNewRecord
		'
		Me.mnuRecordAddNewRecord.Name = "mnuRecordAddNewRecord"
		Me.mnuRecordAddNewRecord.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
		Me.mnuRecordAddNewRecord.Size = New System.Drawing.Size(229, 22)
		Me.mnuRecordAddNewRecord.Text = "Add New Record"
		'
		'mnuRecordDeleteRecord
		'
		Me.mnuRecordDeleteRecord.Name = "mnuRecordDeleteRecord"
		Me.mnuRecordDeleteRecord.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
		Me.mnuRecordDeleteRecord.Size = New System.Drawing.Size(229, 22)
		Me.mnuRecordDeleteRecord.Text = "Delete Record"
		'
		'mnuRecordDuplicateRecord
		'
		Me.mnuRecordDuplicateRecord.Enabled = False
		Me.mnuRecordDuplicateRecord.Name = "mnuRecordDuplicateRecord"
		Me.mnuRecordDuplicateRecord.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
						Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
		Me.mnuRecordDuplicateRecord.Size = New System.Drawing.Size(229, 22)
		Me.mnuRecordDuplicateRecord.Text = "Duplicate Record"
		'
		'mnuRecordInsertRecord
		'
		Me.mnuRecordInsertRecord.Name = "mnuRecordInsertRecord"
		Me.mnuRecordInsertRecord.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
		Me.mnuRecordInsertRecord.Size = New System.Drawing.Size(229, 22)
		Me.mnuRecordInsertRecord.Text = "Insert Record"
		'
		'tsTools
		'
		Me.tsTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsUseDataGrid, Me.ToolStripSeparator20, Me.mnuToolsImageViewer, Me.mnuToolsFreeREGServerGateway, Me.ToolStripSeparator9, Me.mnuToolsRecoverBackup, Me.ToolStripSeparator11, Me.mnuToolsDocumentTeplates, Me.mnuToolsBackupRestore, Me.mnuToolsFiltering, Me.ToolStripSeparator21, Me.mnuToolsRebuildLookUpTables})
		Me.tsTools.Name = "tsTools"
		Me.tsTools.Size = New System.Drawing.Size(48, 20)
		Me.tsTools.Text = "&Tools"
		'
		'mnuToolsUseDataGrid
		'
		Me.mnuToolsUseDataGrid.CheckOnClick = True
		Me.mnuToolsUseDataGrid.Name = "mnuToolsUseDataGrid"
		Me.mnuToolsUseDataGrid.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
						Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
		Me.mnuToolsUseDataGrid.Size = New System.Drawing.Size(240, 22)
		Me.mnuToolsUseDataGrid.Text = "Use DataGrid"
		Me.mnuToolsUseDataGrid.ToolTipText = "Switch between the WinREG/2 and WinReg/3 operation"
		'
		'ToolStripSeparator20
		'
		Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
		Me.ToolStripSeparator20.Size = New System.Drawing.Size(237, 6)
		'
		'mnuToolsImageViewer
		'
		Me.mnuToolsImageViewer.CheckOnClick = True
		Me.mnuToolsImageViewer.Name = "mnuToolsImageViewer"
		Me.mnuToolsImageViewer.Size = New System.Drawing.Size(240, 22)
		Me.mnuToolsImageViewer.Text = "Image Viewer"
		Me.mnuToolsImageViewer.ToolTipText = "Open the Image Viewer"
		'
		'mnuToolsFreeREGServerGateway
		'
		Me.mnuToolsFreeREGServerGateway.Name = "mnuToolsFreeREGServerGateway"
		Me.mnuToolsFreeREGServerGateway.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
		Me.mnuToolsFreeREGServerGateway.Size = New System.Drawing.Size(240, 22)
		Me.mnuToolsFreeREGServerGateway.Text = "FreeREG Server Gateway"
		Me.mnuToolsFreeREGServerGateway.ToolTipText = "Open the FreeREG Server Gateway"
		'
		'ToolStripSeparator9
		'
		Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
		Me.ToolStripSeparator9.Size = New System.Drawing.Size(237, 6)
		'
		'mnuToolsRecoverBackup
		'
		Me.mnuToolsRecoverBackup.Enabled = False
		Me.mnuToolsRecoverBackup.Name = "mnuToolsRecoverBackup"
		Me.mnuToolsRecoverBackup.Size = New System.Drawing.Size(240, 22)
		Me.mnuToolsRecoverBackup.Text = "Recover File from Backup"
		'
		'ToolStripSeparator11
		'
		Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
		Me.ToolStripSeparator11.Size = New System.Drawing.Size(237, 6)
		'
		'mnuToolsDocumentTeplates
		'
		Me.mnuToolsDocumentTeplates.Name = "mnuToolsDocumentTeplates"
		Me.mnuToolsDocumentTeplates.Size = New System.Drawing.Size(240, 22)
		Me.mnuToolsDocumentTeplates.Text = "Document Templates..."
		'
		'mnuToolsBackupRestore
		'
		Me.mnuToolsBackupRestore.Name = "mnuToolsBackupRestore"
		Me.mnuToolsBackupRestore.Size = New System.Drawing.Size(240, 22)
		Me.mnuToolsBackupRestore.Text = "Backup"
		Me.mnuToolsBackupRestore.ToolTipText = "Backup and restore transcripiton files"
		'
		'mnuToolsFiltering
		'
		Me.mnuToolsFiltering.CheckOnClick = True
		Me.mnuToolsFiltering.Name = "mnuToolsFiltering"
		Me.mnuToolsFiltering.Size = New System.Drawing.Size(240, 22)
		Me.mnuToolsFiltering.Text = "Filtering"
		Me.mnuToolsFiltering.Visible = False
		'
		'ToolStripSeparator21
		'
		Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
		Me.ToolStripSeparator21.Size = New System.Drawing.Size(237, 6)
		Me.ToolStripSeparator21.Visible = False
		'
		'mnuToolsRebuildLookUpTables
		'
		Me.mnuToolsRebuildLookUpTables.Enabled = False
		Me.mnuToolsRebuildLookUpTables.Name = "mnuToolsRebuildLookUpTables"
		Me.mnuToolsRebuildLookUpTables.Size = New System.Drawing.Size(240, 22)
		Me.mnuToolsRebuildLookUpTables.Text = "Rebuild LookUp Tables"
		Me.mnuToolsRebuildLookUpTables.Visible = False
		'
		'tsEdit
		'
		Me.tsEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditUndo, Me.mnuEditRedo, Me.toolStripSeparator5, Me.mnuEditCut, Me.mnuEditCopy, Me.mnuEditPaste, Me.toolStripSeparator6, Me.mnuEditSelectAll})
		Me.tsEdit.Name = "tsEdit"
		Me.tsEdit.Size = New System.Drawing.Size(39, 20)
		Me.tsEdit.Text = "&Edit"
		Me.tsEdit.Visible = False
		'
		'mnuEditUndo
		'
		Me.mnuEditUndo.Enabled = False
		Me.mnuEditUndo.Name = "mnuEditUndo"
		Me.mnuEditUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
		Me.mnuEditUndo.Size = New System.Drawing.Size(144, 22)
		Me.mnuEditUndo.Text = "&Undo"
		'
		'mnuEditRedo
		'
		Me.mnuEditRedo.Enabled = False
		Me.mnuEditRedo.Name = "mnuEditRedo"
		Me.mnuEditRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
		Me.mnuEditRedo.Size = New System.Drawing.Size(144, 22)
		Me.mnuEditRedo.Text = "&Redo"
		Me.mnuEditRedo.Visible = False
		'
		'toolStripSeparator5
		'
		Me.toolStripSeparator5.Name = "toolStripSeparator5"
		Me.toolStripSeparator5.Size = New System.Drawing.Size(141, 6)
		'
		'mnuEditCut
		'
		Me.mnuEditCut.Image = CType(resources.GetObject("mnuEditCut.Image"), System.Drawing.Image)
		Me.mnuEditCut.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.mnuEditCut.Name = "mnuEditCut"
		Me.mnuEditCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
		Me.mnuEditCut.Size = New System.Drawing.Size(144, 22)
		Me.mnuEditCut.Text = "Cut"
		Me.mnuEditCut.ToolTipText = "Cut text and place in the clipboard"
		'
		'mnuEditCopy
		'
		Me.mnuEditCopy.Image = CType(resources.GetObject("mnuEditCopy.Image"), System.Drawing.Image)
		Me.mnuEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.mnuEditCopy.Name = "mnuEditCopy"
		Me.mnuEditCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
		Me.mnuEditCopy.Size = New System.Drawing.Size(144, 22)
		Me.mnuEditCopy.Text = "Copy"
		Me.mnuEditCopy.ToolTipText = "Copy text to the clipboard"
		'
		'mnuEditPaste
		'
		Me.mnuEditPaste.Image = CType(resources.GetObject("mnuEditPaste.Image"), System.Drawing.Image)
		Me.mnuEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.mnuEditPaste.Name = "mnuEditPaste"
		Me.mnuEditPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
		Me.mnuEditPaste.Size = New System.Drawing.Size(144, 22)
		Me.mnuEditPaste.Text = "Paste"
		Me.mnuEditPaste.ToolTipText = "Paste clipboard text into field"
		'
		'toolStripSeparator6
		'
		Me.toolStripSeparator6.Name = "toolStripSeparator6"
		Me.toolStripSeparator6.Size = New System.Drawing.Size(141, 6)
		Me.toolStripSeparator6.Visible = False
		'
		'mnuEditSelectAll
		'
		Me.mnuEditSelectAll.Enabled = False
		Me.mnuEditSelectAll.Name = "mnuEditSelectAll"
		Me.mnuEditSelectAll.Size = New System.Drawing.Size(144, 22)
		Me.mnuEditSelectAll.Text = "Select &All"
		'
		'tsSettings
		'
		Me.tsSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettingsOptions, Me.mnuSettingsColumnVisibility, Me.mnuSettingsUserSettings, Me.ToolStripSeparator8, Me.mnuSettingsSelectLayout, Me.mnuSettingsSaveLayout, Me.mnuSettingsAutocompletion})
		Me.tsSettings.Name = "tsSettings"
		Me.tsSettings.Size = New System.Drawing.Size(61, 20)
		Me.tsSettings.Text = "&Settings"
		'
		'mnuSettingsOptions
		'
		Me.mnuSettingsOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettingsOptionsUserProgramOptions, Me.ToolStripSeparator2, Me.mnuSettingsOptionsBaptismSexTable, Me.mnuSettingsOptionsBurialRelationshipsTable, Me.mnuSettingsOptionsBrideMarriageStates, Me.mnuSettingsOptionsGroomMarriageStates, Me.mnuSettingsOptionsRecordTypesTable, Me.mnuSettingsOptionsChapmanCodesTable})
		Me.mnuSettingsOptions.Name = "mnuSettingsOptions"
		Me.mnuSettingsOptions.Size = New System.Drawing.Size(190, 22)
		Me.mnuSettingsOptions.Text = "&Options"
		'
		'mnuSettingsOptionsUserProgramOptions
		'
		Me.mnuSettingsOptionsUserProgramOptions.Name = "mnuSettingsOptionsUserProgramOptions"
		Me.mnuSettingsOptionsUserProgramOptions.Size = New System.Drawing.Size(214, 22)
		Me.mnuSettingsOptionsUserProgramOptions.Text = "User and Program Options"
		Me.mnuSettingsOptionsUserProgramOptions.ToolTipText = "Show the User & Program Options dialog"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(211, 6)
		'
		'mnuSettingsOptionsBaptismSexTable
		'
		Me.mnuSettingsOptionsBaptismSexTable.Name = "mnuSettingsOptionsBaptismSexTable"
		Me.mnuSettingsOptionsBaptismSexTable.Size = New System.Drawing.Size(214, 22)
		Me.mnuSettingsOptionsBaptismSexTable.Text = "Baptism Sex Table"
		Me.mnuSettingsOptionsBaptismSexTable.ToolTipText = "Show the contents of the Baptism Sex table"
		'
		'mnuSettingsOptionsBurialRelationshipsTable
		'
		Me.mnuSettingsOptionsBurialRelationshipsTable.Name = "mnuSettingsOptionsBurialRelationshipsTable"
		Me.mnuSettingsOptionsBurialRelationshipsTable.Size = New System.Drawing.Size(214, 22)
		Me.mnuSettingsOptionsBurialRelationshipsTable.Text = "Burial Relationships Table"
		Me.mnuSettingsOptionsBurialRelationshipsTable.ToolTipText = "Show the contents of the Burial Relationships table"
		'
		'mnuSettingsOptionsBrideMarriageStates
		'
		Me.mnuSettingsOptionsBrideMarriageStates.Name = "mnuSettingsOptionsBrideMarriageStates"
		Me.mnuSettingsOptionsBrideMarriageStates.Size = New System.Drawing.Size(214, 22)
		Me.mnuSettingsOptionsBrideMarriageStates.Text = "Bride Marriage States"
		Me.mnuSettingsOptionsBrideMarriageStates.ToolTipText = "Show the contents of the Marriage Conditions Table for a Bride"
		'
		'mnuSettingsOptionsGroomMarriageStates
		'
		Me.mnuSettingsOptionsGroomMarriageStates.Name = "mnuSettingsOptionsGroomMarriageStates"
		Me.mnuSettingsOptionsGroomMarriageStates.Size = New System.Drawing.Size(214, 22)
		Me.mnuSettingsOptionsGroomMarriageStates.Text = "Groom Marriage States"
		Me.mnuSettingsOptionsGroomMarriageStates.ToolTipText = "Show the contents of the Marriage Conditions Table for a Groom"
		'
		'mnuSettingsOptionsRecordTypesTable
		'
		Me.mnuSettingsOptionsRecordTypesTable.Name = "mnuSettingsOptionsRecordTypesTable"
		Me.mnuSettingsOptionsRecordTypesTable.Size = New System.Drawing.Size(214, 22)
		Me.mnuSettingsOptionsRecordTypesTable.Text = "Record Types Table"
		Me.mnuSettingsOptionsRecordTypesTable.ToolTipText = "Show the contents of the Record Types Table"
		'
		'mnuSettingsOptionsChapmanCodesTable
		'
		Me.mnuSettingsOptionsChapmanCodesTable.Name = "mnuSettingsOptionsChapmanCodesTable"
		Me.mnuSettingsOptionsChapmanCodesTable.Size = New System.Drawing.Size(214, 22)
		Me.mnuSettingsOptionsChapmanCodesTable.Text = "Chapman Codes Table"
		Me.mnuSettingsOptionsChapmanCodesTable.ToolTipText = "Show the contents of the Chapman Codes Table"
		'
		'mnuSettingsColumnVisibility
		'
		Me.mnuSettingsColumnVisibility.Enabled = False
		Me.mnuSettingsColumnVisibility.Name = "mnuSettingsColumnVisibility"
		Me.mnuSettingsColumnVisibility.Size = New System.Drawing.Size(190, 22)
		Me.mnuSettingsColumnVisibility.Text = "Column Visibility"
		Me.mnuSettingsColumnVisibility.Visible = False
		'
		'mnuSettingsUserSettings
		'
		Me.mnuSettingsUserSettings.Enabled = False
		Me.mnuSettingsUserSettings.Name = "mnuSettingsUserSettings"
		Me.mnuSettingsUserSettings.Size = New System.Drawing.Size(190, 22)
		Me.mnuSettingsUserSettings.Text = "User Settings"
		Me.mnuSettingsUserSettings.Visible = False
		'
		'ToolStripSeparator8
		'
		Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
		Me.ToolStripSeparator8.Size = New System.Drawing.Size(187, 6)
		Me.ToolStripSeparator8.Visible = False
		'
		'mnuSettingsSelectLayout
		'
		Me.mnuSettingsSelectLayout.Enabled = False
		Me.mnuSettingsSelectLayout.Name = "mnuSettingsSelectLayout"
		Me.mnuSettingsSelectLayout.Size = New System.Drawing.Size(190, 22)
		Me.mnuSettingsSelectLayout.Text = "Select Column Layout"
		Me.mnuSettingsSelectLayout.Visible = False
		'
		'mnuSettingsSaveLayout
		'
		Me.mnuSettingsSaveLayout.Enabled = False
		Me.mnuSettingsSaveLayout.Name = "mnuSettingsSaveLayout"
		Me.mnuSettingsSaveLayout.Size = New System.Drawing.Size(190, 22)
		Me.mnuSettingsSaveLayout.Text = "Save Column Layout"
		Me.mnuSettingsSaveLayout.Visible = False
		'
		'mnuSettingsAutocompletion
		'
		Me.mnuSettingsAutocompletion.Enabled = False
		Me.mnuSettingsAutocompletion.Name = "mnuSettingsAutocompletion"
		Me.mnuSettingsAutocompletion.Size = New System.Drawing.Size(190, 22)
		Me.mnuSettingsAutocompletion.Text = "Autocompletion"
		Me.mnuSettingsAutocompletion.Visible = False
		'
		'tsMyTools
		'
		Me.tsMyTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMyToolsCreateLookupTables, Me.mnuMyToolsCrashProgram, Me.mnuMyToolsException})
		Me.tsMyTools.Enabled = False
		Me.tsMyTools.Name = "tsMyTools"
		Me.tsMyTools.Size = New System.Drawing.Size(65, 20)
		Me.tsMyTools.Text = "MyTools"
		Me.tsMyTools.Visible = False
		'
		'mnuMyToolsCreateLookupTables
		'
		Me.mnuMyToolsCreateLookupTables.Enabled = False
		Me.mnuMyToolsCreateLookupTables.Name = "mnuMyToolsCreateLookupTables"
		Me.mnuMyToolsCreateLookupTables.Size = New System.Drawing.Size(182, 22)
		Me.mnuMyToolsCreateLookupTables.Text = "Create lookup tables"
		'
		'mnuMyToolsCrashProgram
		'
		Me.mnuMyToolsCrashProgram.Enabled = False
		Me.mnuMyToolsCrashProgram.Name = "mnuMyToolsCrashProgram"
		Me.mnuMyToolsCrashProgram.Size = New System.Drawing.Size(182, 22)
		Me.mnuMyToolsCrashProgram.Text = "Crash!"
		'
		'mnuMyToolsException
		'
		Me.mnuMyToolsException.Enabled = False
		Me.mnuMyToolsException.Name = "mnuMyToolsException"
		Me.mnuMyToolsException.Size = New System.Drawing.Size(182, 22)
		Me.mnuMyToolsException.Text = "Exception"
		'
		'tsHelp
		'
		Me.tsHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpContents, Me.mnuHelpIndex, Me.mnuHelpSearch, Me.mnuHelpHowToUseTheHelpViewer, Me.toolStripSeparator7, Me.mnuHelpTheWinREGBlog, Me.mnuHelpVisitFreeREG, Me.mnuHelpTranscriberInformation, Me.mnuHelpEmailBugReport, Me.ToolStripSeparator12, Me.mnuHelpSetProgramDefaults, Me.ToolStripSeparator19, Me.mnuHelpVisitFreeREGForum, Me.ToolStripSeparator13, Me.mnuHelpConfigureUpdates, Me.mnuHelpCheckForUpdates, Me.mnuHelpSeparator3, Me.mnuHelpViewLogFile, Me.mnuHelpChangeHistory, Me.mnuHelpAbout})
		Me.tsHelp.Name = "tsHelp"
		Me.tsHelp.Size = New System.Drawing.Size(44, 20)
		Me.tsHelp.Text = "&Help"
		'
		'mnuHelpContents
		'
		Me.mnuHelpContents.Image = CType(resources.GetObject("mnuHelpContents.Image"), System.Drawing.Image)
		Me.mnuHelpContents.Name = "mnuHelpContents"
		Me.mnuHelpContents.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpContents.Text = "&Contents"
		Me.mnuHelpContents.ToolTipText = "Show the Help Contents page"
		'
		'mnuHelpIndex
		'
		Me.mnuHelpIndex.Image = CType(resources.GetObject("mnuHelpIndex.Image"), System.Drawing.Image)
		Me.mnuHelpIndex.Name = "mnuHelpIndex"
		Me.mnuHelpIndex.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpIndex.Text = "&Index"
		Me.mnuHelpIndex.ToolTipText = "Show the Help Index page"
		'
		'mnuHelpSearch
		'
		Me.mnuHelpSearch.Image = CType(resources.GetObject("mnuHelpSearch.Image"), System.Drawing.Image)
		Me.mnuHelpSearch.Name = "mnuHelpSearch"
		Me.mnuHelpSearch.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpSearch.Text = "&Search"
		Me.mnuHelpSearch.ToolTipText = "Show the Help Search page"
		'
		'mnuHelpHowToUseTheHelpViewer
		'
		Me.mnuHelpHowToUseTheHelpViewer.Name = "mnuHelpHowToUseTheHelpViewer"
		Me.mnuHelpHowToUseTheHelpViewer.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpHowToUseTheHelpViewer.Text = "How To Use The Help Viewer"
		Me.mnuHelpHowToUseTheHelpViewer.Visible = False
		'
		'toolStripSeparator7
		'
		Me.toolStripSeparator7.Name = "toolStripSeparator7"
		Me.toolStripSeparator7.Size = New System.Drawing.Size(224, 6)
		'
		'mnuHelpTheWinREGBlog
		'
		Me.mnuHelpTheWinREGBlog.Name = "mnuHelpTheWinREGBlog"
		Me.mnuHelpTheWinREGBlog.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpTheWinREGBlog.Text = "The WinREG Blog"
		'
		'mnuHelpVisitFreeREG
		'
		Me.mnuHelpVisitFreeREG.Image = CType(resources.GetObject("mnuHelpVisitFreeREG.Image"), System.Drawing.Image)
		Me.mnuHelpVisitFreeREG.Name = "mnuHelpVisitFreeREG"
		Me.mnuHelpVisitFreeREG.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpVisitFreeREG.Text = "Visit www.FreeREG.org.uk"
		'
		'mnuHelpTranscriberInformation
		'
		Me.mnuHelpTranscriberInformation.Image = CType(resources.GetObject("mnuHelpTranscriberInformation.Image"), System.Drawing.Image)
		Me.mnuHelpTranscriberInformation.Name = "mnuHelpTranscriberInformation"
		Me.mnuHelpTranscriberInformation.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpTranscriberInformation.Text = "Information for Transcribers"
		'
		'mnuHelpEmailBugReport
		'
		Me.mnuHelpEmailBugReport.Image = CType(resources.GetObject("mnuHelpEmailBugReport.Image"), System.Drawing.Image)
		Me.mnuHelpEmailBugReport.Name = "mnuHelpEmailBugReport"
		Me.mnuHelpEmailBugReport.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpEmailBugReport.Text = "Email a Bug Report"
		'
		'ToolStripSeparator12
		'
		Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
		Me.ToolStripSeparator12.Size = New System.Drawing.Size(224, 6)
		'
		'mnuHelpSetProgramDefaults
		'
		Me.mnuHelpSetProgramDefaults.Name = "mnuHelpSetProgramDefaults"
		Me.mnuHelpSetProgramDefaults.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpSetProgramDefaults.Text = "Set Program Defaults"
		'
		'ToolStripSeparator19
		'
		Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
		Me.ToolStripSeparator19.Size = New System.Drawing.Size(224, 6)
		'
		'mnuHelpVisitFreeREGForum
		'
		Me.mnuHelpVisitFreeREGForum.Image = CType(resources.GetObject("mnuHelpVisitFreeREGForum.Image"), System.Drawing.Image)
		Me.mnuHelpVisitFreeREGForum.Name = "mnuHelpVisitFreeREGForum"
		Me.mnuHelpVisitFreeREGForum.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpVisitFreeREGForum.Text = "Visit the FreeREG Forum"
		'
		'ToolStripSeparator13
		'
		Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
		Me.ToolStripSeparator13.Size = New System.Drawing.Size(224, 6)
		'
		'mnuHelpConfigureUpdates
		'
		Me.mnuHelpConfigureUpdates.Enabled = False
		Me.mnuHelpConfigureUpdates.Name = "mnuHelpConfigureUpdates"
		Me.mnuHelpConfigureUpdates.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpConfigureUpdates.Text = "Configure updates"
		Me.mnuHelpConfigureUpdates.Visible = False
		'
		'mnuHelpCheckForUpdates
		'
		Me.mnuHelpCheckForUpdates.Enabled = False
		Me.mnuHelpCheckForUpdates.Name = "mnuHelpCheckForUpdates"
		Me.mnuHelpCheckForUpdates.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpCheckForUpdates.Text = "Check for updates"
		Me.mnuHelpCheckForUpdates.Visible = False
		'
		'mnuHelpSeparator3
		'
		Me.mnuHelpSeparator3.Name = "mnuHelpSeparator3"
		Me.mnuHelpSeparator3.Size = New System.Drawing.Size(224, 6)
		Me.mnuHelpSeparator3.Visible = False
		'
		'mnuHelpViewLogFile
		'
		Me.mnuHelpViewLogFile.Name = "mnuHelpViewLogFile"
		Me.mnuHelpViewLogFile.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpViewLogFile.Text = "View log file"
		Me.mnuHelpViewLogFile.ToolTipText = "View the contents of the WinREG/3 Log File"
		'
		'mnuHelpChangeHistory
		'
		Me.mnuHelpChangeHistory.Enabled = False
		Me.mnuHelpChangeHistory.Name = "mnuHelpChangeHistory"
		Me.mnuHelpChangeHistory.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpChangeHistory.Text = "Change History"
		Me.mnuHelpChangeHistory.Visible = False
		'
		'mnuHelpAbout
		'
		Me.mnuHelpAbout.Image = CType(resources.GetObject("mnuHelpAbout.Image"), System.Drawing.Image)
		Me.mnuHelpAbout.Name = "mnuHelpAbout"
		Me.mnuHelpAbout.Size = New System.Drawing.Size(227, 22)
		Me.mnuHelpAbout.Text = "&About..."
		'
		'ttMain
		'
		Me.ttMain.Active = False
		Me.ttMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.ttMain.IsBalloon = True
		Me.ttMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		Me.ttMain.ToolTipTitle = "Tooltip Title"
		'
		'bwUpdater
		'
		Me.bwUpdater.WorkerSupportsCancellation = True
		'
		'ofdExcel
		'
		Me.ofdExcel.DefaultExt = "xls"
		Me.ofdExcel.Filter = "Microsoft Excel 97-2003 Worksheets (*.xls)|*.xls|Microsoft Excel Worksheets (*.xl" & _
			 "sx)|*.xlsx"
		Me.ofdExcel.Title = "Import Excel File"
		'
		'tickDisplay
		'
		Me.tickDisplay.Interval = 5000
		'
		'sfdTranscript
		'
		Me.sfdTranscript.CreatePrompt = True
		'
		'bwCheckFile
		'
		Me.bwCheckFile.WorkerSupportsCancellation = True
		'
		'hlpMain
		'
		Me.hlpMain.HelpNamespace = "WinREG3a.chm"
		'
		'ssMain
		'
		Me.ssMain.Dock = System.Windows.Forms.DockStyle.None
		Me.hlpMain.SetHelpKeyword(Me.ssMain, "statusstrip.htm")
		Me.hlpMain.SetHelpNavigator(Me.ssMain, System.Windows.Forms.HelpNavigator.Topic)
		Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblFfilterStatus, Me.lblShowAll, Me.lblInformation, Me.lblDate, Me.lblUCF})
		Me.ssMain.Location = New System.Drawing.Point(0, 25)
		Me.ssMain.Name = "ssMain"
		Me.hlpMain.SetShowHelp(Me.ssMain, True)
		Me.ssMain.ShowItemToolTips = True
		Me.ssMain.Size = New System.Drawing.Size(733, 22)
		Me.ssMain.TabIndex = 2
		Me.ssMain.Text = "ssMain"
		'
		'lblFfilterStatus
		'
		Me.lblFfilterStatus.Name = "lblFfilterStatus"
		Me.lblFfilterStatus.Size = New System.Drawing.Size(0, 19)
		Me.lblFfilterStatus.Visible = False
		'
		'lblShowAll
		'
		Me.lblShowAll.IsLink = True
		Me.lblShowAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
		Me.lblShowAll.Name = "lblShowAll"
		Me.lblShowAll.Size = New System.Drawing.Size(53, 19)
		Me.lblShowAll.Text = "Show &All"
		Me.lblShowAll.ToolTipText = "Click here to remove all filtering and diplay all the records" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in the file." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
		Me.lblShowAll.Visible = False
		'
		'lblInformation
		'
		Me.lblInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.lblInformation.Name = "lblInformation"
		Me.lblInformation.Size = New System.Drawing.Size(718, 17)
		Me.lblInformation.Spring = True
		Me.lblInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblDate
		'
		Me.lblDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
						Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
						Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me.lblDate.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
		Me.lblDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.lblDate.IsLink = True
		Me.lblDate.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
		Me.lblDate.Name = "lblDate"
		Me.lblDate.Size = New System.Drawing.Size(59, 19)
		Me.lblDate.Text = "F4=Date"
		Me.lblDate.ToolTipText = "You are presently in a date field. To assist you enter a correctly formatted" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dat" & _
			 "e, press the F4 key."
		Me.lblDate.Visible = False
		'
		'lblUCF
		'
		Me.lblUCF.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
						Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
						Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me.lblUCF.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
		Me.lblUCF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.lblUCF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.lblUCF.IsLink = True
		Me.lblUCF.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
		Me.lblUCF.Name = "lblUCF"
		Me.lblUCF.Size = New System.Drawing.Size(54, 19)
		Me.lblUCF.Text = "F5=UCF"
		Me.lblUCF.ToolTipText = "You are currently in a field where it is not always possible to enter" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the exact " & _
			 "character string. To assist you in entering one or more" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "unknown characters, pre" & _
			 "ss the F5 key to use the UCF helper."
		Me.lblUCF.Visible = False
		'
		'bnDGV
		'
		Me.bnDGV.AddNewItem = Nothing
		Me.bnDGV.CountItem = Me.BindingNavigatorCountItem
		Me.bnDGV.DeleteItem = Nothing
		Me.bnDGV.Dock = System.Windows.Forms.DockStyle.None
		Me.bnDGV.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.hlpMain.SetHelpKeyword(Me.bnDGV, "bindingnavigator.htm")
		Me.hlpMain.SetHelpNavigator(Me.bnDGV, System.Windows.Forms.HelpNavigator.Topic)
		Me.bnDGV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.BindingNavigatorDuplicateRecord, Me.toolStripSeparator16, Me.BindingNavigatorSaveFileButton, Me.ToolStripSeparator17, Me.BindingNavigatorCutButton, Me.BindingNavigatorCopyButton, Me.BindingNavigatorPasteButton, Me.ToolStripSeparator18, Me.BindingNavigatorViewErrorsButton, Me.BindingNavigatorUnsortFileButton})
		Me.bnDGV.Location = New System.Drawing.Point(3, 24)
		Me.bnDGV.MoveFirstItem = Nothing
		Me.bnDGV.MoveLastItem = Nothing
		Me.bnDGV.MoveNextItem = Nothing
		Me.bnDGV.MovePreviousItem = Nothing
		Me.bnDGV.Name = "bnDGV"
		Me.bnDGV.PositionItem = Me.BindingNavigatorPositionItem
		Me.hlpMain.SetShowHelp(Me.bnDGV, True)
		Me.bnDGV.Size = New System.Drawing.Size(419, 25)
		Me.bnDGV.TabIndex = 2
		Me.bnDGV.Text = "bnDGV"
		'
		'BindingNavigatorCountItem
		'
		Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
		Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
		Me.BindingNavigatorCountItem.Text = "of {0}"
		Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
		'
		'BindingNavigatorMoveFirstItem
		'
		Me.BindingNavigatorMoveFirstItem.AutoToolTip = False
		Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorMoveFirstItem.Enabled = False
		Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
		Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorMoveFirstItem.Text = "Move first"
		Me.BindingNavigatorMoveFirstItem.ToolTipText = "Move first"
		'
		'BindingNavigatorMovePreviousItem
		'
		Me.BindingNavigatorMovePreviousItem.AutoToolTip = False
		Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorMovePreviousItem.Enabled = False
		Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
		Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
		Me.BindingNavigatorMovePreviousItem.ToolTipText = "Move previous"
		'
		'BindingNavigatorSeparator
		'
		Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
		Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
		'
		'BindingNavigatorPositionItem
		'
		Me.BindingNavigatorPositionItem.AccessibleName = "Position"
		Me.BindingNavigatorPositionItem.AutoSize = False
		Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
		Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
		Me.BindingNavigatorPositionItem.Text = "0"
		Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
		'
		'BindingNavigatorSeparator1
		'
		Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
		Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'BindingNavigatorMoveNextItem
		'
		Me.BindingNavigatorMoveNextItem.AutoToolTip = False
		Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorMoveNextItem.Enabled = False
		Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
		Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorMoveNextItem.Text = "Move next"
		Me.BindingNavigatorMoveNextItem.ToolTipText = "Move next"
		'
		'BindingNavigatorMoveLastItem
		'
		Me.BindingNavigatorMoveLastItem.AutoToolTip = False
		Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorMoveLastItem.Enabled = False
		Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
		Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorMoveLastItem.Text = "Move last"
		Me.BindingNavigatorMoveLastItem.ToolTipText = "Move last"
		'
		'BindingNavigatorSeparator2
		'
		Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
		Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
		'
		'BindingNavigatorAddNewItem
		'
		Me.BindingNavigatorAddNewItem.AutoToolTip = False
		Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorAddNewItem.Enabled = False
		Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
		Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorAddNewItem.Text = "Add new"
		Me.BindingNavigatorAddNewItem.ToolTipText = "Add a new record"
		'
		'BindingNavigatorDeleteItem
		'
		Me.BindingNavigatorDeleteItem.AutoToolTip = False
		Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorDeleteItem.Enabled = False
		Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
		Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
		Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
		Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorDeleteItem.Text = "Delete"
		Me.BindingNavigatorDeleteItem.ToolTipText = "Delete a record"
		'
		'BindingNavigatorDuplicateRecord
		'
		Me.BindingNavigatorDuplicateRecord.AutoToolTip = False
		Me.BindingNavigatorDuplicateRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorDuplicateRecord.Enabled = False
		Me.BindingNavigatorDuplicateRecord.Image = Global.WinREG.My.Resources.Resources.duplicate
		Me.BindingNavigatorDuplicateRecord.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.BindingNavigatorDuplicateRecord.Name = "BindingNavigatorDuplicateRecord"
		Me.BindingNavigatorDuplicateRecord.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorDuplicateRecord.Text = "Duplicate Record"
		Me.BindingNavigatorDuplicateRecord.ToolTipText = "Duplicate current record"
		'
		'toolStripSeparator16
		'
		Me.toolStripSeparator16.Name = "toolStripSeparator16"
		Me.toolStripSeparator16.Size = New System.Drawing.Size(6, 25)
		Me.toolStripSeparator16.Visible = False
		'
		'BindingNavigatorSaveFileButton
		'
		Me.BindingNavigatorSaveFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorSaveFileButton.Enabled = False
		Me.BindingNavigatorSaveFileButton.Image = Global.WinREG.My.Resources.Resources.save
		Me.BindingNavigatorSaveFileButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.BindingNavigatorSaveFileButton.Name = "BindingNavigatorSaveFileButton"
		Me.BindingNavigatorSaveFileButton.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorSaveFileButton.Text = "BindingNavigatorSaveFileButton"
		Me.BindingNavigatorSaveFileButton.ToolTipText = "Save the changed file"
		'
		'ToolStripSeparator17
		'
		Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
		Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
		'
		'BindingNavigatorCutButton
		'
		Me.BindingNavigatorCutButton.AutoToolTip = False
		Me.BindingNavigatorCutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorCutButton.Enabled = False
		Me.BindingNavigatorCutButton.Image = CType(resources.GetObject("BindingNavigatorCutButton.Image"), System.Drawing.Image)
		Me.BindingNavigatorCutButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.BindingNavigatorCutButton.Name = "BindingNavigatorCutButton"
		Me.BindingNavigatorCutButton.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorCutButton.Text = "Cut"
		Me.BindingNavigatorCutButton.ToolTipText = "Cut text and place in the clipboard"
		'
		'BindingNavigatorCopyButton
		'
		Me.BindingNavigatorCopyButton.AutoToolTip = False
		Me.BindingNavigatorCopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorCopyButton.Enabled = False
		Me.BindingNavigatorCopyButton.Image = CType(resources.GetObject("BindingNavigatorCopyButton.Image"), System.Drawing.Image)
		Me.BindingNavigatorCopyButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.BindingNavigatorCopyButton.Name = "BindingNavigatorCopyButton"
		Me.BindingNavigatorCopyButton.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorCopyButton.Text = "Copy"
		Me.BindingNavigatorCopyButton.ToolTipText = "Copy text to the clipboard"
		'
		'BindingNavigatorPasteButton
		'
		Me.BindingNavigatorPasteButton.AutoToolTip = False
		Me.BindingNavigatorPasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorPasteButton.Enabled = False
		Me.BindingNavigatorPasteButton.Image = CType(resources.GetObject("BindingNavigatorPasteButton.Image"), System.Drawing.Image)
		Me.BindingNavigatorPasteButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.BindingNavigatorPasteButton.Name = "BindingNavigatorPasteButton"
		Me.BindingNavigatorPasteButton.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorPasteButton.Text = "Paste"
		Me.BindingNavigatorPasteButton.ToolTipText = "Paste clipboard text into field"
		'
		'ToolStripSeparator18
		'
		Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
		Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 25)
		'
		'BindingNavigatorViewErrorsButton
		'
		Me.BindingNavigatorViewErrorsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorViewErrorsButton.Enabled = False
		Me.BindingNavigatorViewErrorsButton.Image = Global.WinREG.My.Resources.Resources.Exclamation
		Me.BindingNavigatorViewErrorsButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.BindingNavigatorViewErrorsButton.Name = "BindingNavigatorViewErrorsButton"
		Me.BindingNavigatorViewErrorsButton.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorViewErrorsButton.Text = "View FreeREG Errors"
		'
		'BindingNavigatorUnsortFileButton
		'
		Me.BindingNavigatorUnsortFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.BindingNavigatorUnsortFileButton.Enabled = False
		Me.BindingNavigatorUnsortFileButton.Image = Global.WinREG.My.Resources.Resources.cancel
		Me.BindingNavigatorUnsortFileButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.BindingNavigatorUnsortFileButton.Name = "BindingNavigatorUnsortFileButton"
		Me.BindingNavigatorUnsortFileButton.Size = New System.Drawing.Size(23, 22)
		Me.BindingNavigatorUnsortFileButton.Text = "Unsort File"
		'
		'mainDGV
		'
		Me.mainDGV.AllowUserToAddRows = False
		Me.mainDGV.AllowUserToDeleteRows = False
		Me.mainDGV.AllowUserToOrderColumns = True
		Me.mainDGV.AllowUserToResizeRows = False
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.Wheat
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
		Me.mainDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.mainDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
		Me.mainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.mainDGV.ContextMenuStrip = Me.ctxStripGrid
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightYellow
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
		DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.mainDGV.DefaultCellStyle = DataGridViewCellStyle2
		Me.mainDGV.Dock = System.Windows.Forms.DockStyle.Fill
		Me.hlpMain.SetHelpKeyword(Me.mainDGV, "datagrid.htm")
		Me.hlpMain.SetHelpNavigator(Me.mainDGV, System.Windows.Forms.HelpNavigator.Topic)
		Me.mainDGV.Location = New System.Drawing.Point(0, 0)
		Me.mainDGV.Name = "mainDGV"
		Me.mainDGV.RowHeadersWidth = 50
		Me.mainDGV.RowOffset = 0
		Me.mainDGV.RowTemplate.Height = 20
		Me.mainDGV.ShowCellToolTips = False
		Me.hlpMain.SetShowHelp(Me.mainDGV, True)
		Me.mainDGV.Size = New System.Drawing.Size(733, 459)
		Me.mainDGV.TabIndex = 3
		Me.mainDGV.Visible = False
		'
		'sfdColumnLayout
		'
		Me.sfdColumnLayout.RestoreDirectory = True
		Me.sfdColumnLayout.ShowHelp = True
		Me.sfdColumnLayout.SupportMultiDottedExtensions = True
		Me.sfdColumnLayout.Title = "Save Column Layout"
		'
		'ofdColumnLayout
		'
		Me.ofdColumnLayout.RestoreDirectory = True
		Me.ofdColumnLayout.ShowHelp = True
		Me.ofdColumnLayout.SupportMultiDottedExtensions = True
		Me.ofdColumnLayout.Title = "Load Column Layout"
		'
		'tscMain
		'
		'
		'tscMain.BottomToolStripPanel
		'
		Me.tscMain.BottomToolStripPanel.Controls.Add(Me.tsFilters)
		Me.tscMain.BottomToolStripPanel.Controls.Add(Me.ssMain)
		'
		'tscMain.ContentPanel
		'
		Me.tscMain.ContentPanel.Controls.Add(Me.mainDGV)
		Me.tscMain.ContentPanel.Controls.Add(Me.panelWinREG2)
		Me.tscMain.ContentPanel.Controls.Add(Me.mainWelcomeText)
		Me.tscMain.ContentPanel.Size = New System.Drawing.Size(733, 459)
		Me.tscMain.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tscMain.Location = New System.Drawing.Point(0, 0)
		Me.tscMain.Name = "tscMain"
		Me.tscMain.Size = New System.Drawing.Size(733, 555)
		Me.tscMain.TabIndex = 0
		Me.tscMain.Text = "ToolStripContainer1"
		'
		'tscMain.TopToolStripPanel
		'
		Me.tscMain.TopToolStripPanel.Controls.Add(Me.msMain)
		Me.tscMain.TopToolStripPanel.Controls.Add(Me.bnDGV)
		'
		'tsFilters
		'
		Me.tsFilters.Dock = System.Windows.Forms.DockStyle.None
		Me.tsFilters.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.tsFilters.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblFiltersText, Me.cbFilterColumns, Me.cbFilterOperators, Me.cbFilterValues, Me.txtFilterString})
		Me.tsFilters.Location = New System.Drawing.Point(3, 0)
		Me.tsFilters.Name = "tsFilters"
		Me.tsFilters.Size = New System.Drawing.Size(677, 25)
		Me.tsFilters.TabIndex = 3
		'
		'lblFiltersText
		'
		Me.lblFiltersText.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblFiltersText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.lblFiltersText.Name = "lblFiltersText"
		Me.lblFiltersText.Size = New System.Drawing.Size(53, 22)
		Me.lblFiltersText.Text = "Filtering"
		'
		'cbFilterColumns
		'
		Me.cbFilterColumns.BackColor = System.Drawing.SystemColors.ControlLight
		Me.cbFilterColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbFilterColumns.Items.AddRange(New Object() {"Four hundred", "One", "Three", "Two"})
		Me.cbFilterColumns.Name = "cbFilterColumns"
		Me.cbFilterColumns.Size = New System.Drawing.Size(121, 25)
		'
		'cbFilterOperators
		'
		Me.cbFilterOperators.BackColor = System.Drawing.SystemColors.ControlLight
		Me.cbFilterOperators.Name = "cbFilterOperators"
		Me.cbFilterOperators.Size = New System.Drawing.Size(121, 25)
		'
		'cbFilterValues
		'
		Me.cbFilterValues.BackColor = System.Drawing.SystemColors.ControlLight
		Me.cbFilterValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbFilterValues.Name = "cbFilterValues"
		Me.cbFilterValues.Size = New System.Drawing.Size(121, 25)
		Me.cbFilterValues.Sorted = True
		'
		'txtFilterString
		'
		Me.txtFilterString.BackColor = System.Drawing.SystemColors.ControlLight
		Me.txtFilterString.Name = "txtFilterString"
		Me.txtFilterString.ReadOnly = True
		Me.txtFilterString.Size = New System.Drawing.Size(250, 25)
		'
		'panelWinREG2
		'
		Me.panelWinREG2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.panelWinREG2.Location = New System.Drawing.Point(0, 0)
		Me.panelWinREG2.Margin = New System.Windows.Forms.Padding(0)
		Me.panelWinREG2.Name = "panelWinREG2"
		Me.panelWinREG2.Size = New System.Drawing.Size(733, 459)
		Me.panelWinREG2.TabIndex = 5
		Me.panelWinREG2.Visible = False
		'
		'mainWelcomeText
		'
		Me.mainWelcomeText.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.mainWelcomeText.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.mainWelcomeText.Dock = System.Windows.Forms.DockStyle.Fill
		Me.mainWelcomeText.Font = New System.Drawing.Font("Gabriola", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.mainWelcomeText.Location = New System.Drawing.Point(0, 0)
		Me.mainWelcomeText.Multiline = True
		Me.mainWelcomeText.Name = "mainWelcomeText"
		Me.mainWelcomeText.ReadOnly = True
		Me.mainWelcomeText.Size = New System.Drawing.Size(733, 459)
		Me.mainWelcomeText.TabIndex = 4
		Me.mainWelcomeText.TabStop = False
		Me.mainWelcomeText.Text = "Welcome to WinREG/3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To get started, you either need to open an existing file o" & _
			 "r begin a new one." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Both options are to be found under the File menu item."
		Me.mainWelcomeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'tickRecovery
		'
		Me.tickRecovery.Interval = 1000
		'
		'fswTranscripts
		'
		Me.fswTranscripts.EnableRaisingEvents = True
		Me.fswTranscripts.SynchronizingObject = Me
		'
		'panelValidator
		'
		Me.panelValidator.ContainerToValidate = Me.tscMain.ContentPanel
		Me.panelValidator.HostingForm = Me
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(733, 555)
		Me.Controls.Add(Me.tscMain)
		Me.hlpMain.SetHelpKeyword(Me, "Welcome.htm")
		Me.hlpMain.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MainMenuStrip = Me.msMain
		Me.Name = "MainForm"
		Me.hlpMain.SetShowHelp(Me, True)
		Me.Text = "WinREG 3.2"
		Me.ctxStripGrid.ResumeLayout(False)
		Me.msMain.ResumeLayout(False)
		Me.msMain.PerformLayout()
		Me.ssMain.ResumeLayout(False)
		Me.ssMain.PerformLayout()
		CType(Me.bnDGV, System.ComponentModel.ISupportInitialize).EndInit()
		Me.bnDGV.ResumeLayout(False)
		Me.bnDGV.PerformLayout()
		CType(Me.mainDGV, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tscMain.BottomToolStripPanel.ResumeLayout(False)
		Me.tscMain.BottomToolStripPanel.PerformLayout()
		Me.tscMain.ContentPanel.ResumeLayout(False)
		Me.tscMain.ContentPanel.PerformLayout()
		Me.tscMain.TopToolStripPanel.ResumeLayout(False)
		Me.tscMain.TopToolStripPanel.PerformLayout()
		Me.tscMain.ResumeLayout(False)
		Me.tscMain.PerformLayout()
		Me.tsFilters.ResumeLayout(False)
		Me.tsFilters.PerformLayout()
		CType(Me.fswTranscripts, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents ofdTranscript As System.Windows.Forms.OpenFileDialog
	Friend WithEvents popColumnsVisibility As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents msMain As System.Windows.Forms.MenuStrip
	Friend WithEvents tsFile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileNewDataFile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileOpenDataFile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuFileSaveFile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileSaveFileAs As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuFilePrint As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFilePrintPreview As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsEdit As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuEditUndo As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuEditRedo As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuEditCut As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuEditCopy As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuEditPaste As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuEditSelectAll As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsTools As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsHelp As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelpContents As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelpIndex As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelpSearch As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileCloseFile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuHelpViewLogFile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents hlpMain As System.Windows.Forms.HelpProvider
	Friend WithEvents mnuToolsImageViewer As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuToolsFreeREGServerGateway As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuHelpConfigureUpdates As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelpCheckForUpdates As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelpSeparator3 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents tsRecord As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsSettings As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileRenameFile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileEditFileDetails As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileValidateFileData As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuRecordAddNewRecord As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuRecordDeleteRecord As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsSelectLayout As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsOptions As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsOptionsUserProgramOptions As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuSettingsOptionsBaptismSexTable As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsOptionsBurialRelationshipsTable As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsOptionsBrideMarriageStates As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsOptionsGroomMarriageStates As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsOptionsRecordTypesTable As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsOptionsChapmanCodesTable As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuToolsDocumentTeplates As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuToolsBackupRestore As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsUserSettings As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelpVisitFreeREG As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelpTranscriberInformation As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelpEmailBugReport As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuHelpVisitFreeREGForum As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuFileMRUList As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileMRUClearList As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents bwUpdater As System.ComponentModel.BackgroundWorker
	Friend WithEvents mnuFileShowLDSColumns As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsMyTools As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuMyToolsCreateLookupTables As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileImportExcel As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ofdExcel As System.Windows.Forms.OpenFileDialog
	Friend WithEvents tickDisplay As System.Windows.Forms.Timer
	Friend WithEvents mnuFileUnsortRecords As System.Windows.Forms.ToolStripMenuItem
	Private WithEvents ttMain As System.Windows.Forms.ToolTip
	Friend WithEvents mnuHelpSetProgramDefaults As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuHelpChangeHistory As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuRecordDuplicateRecord As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ctxStripGrid As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents miCut As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miCopy As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miPaste As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miDelete As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelpTheWinREGBlog As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents sfdTranscript As System.Windows.Forms.SaveFileDialog
	Friend WithEvents mnuSettingsColumnVisibility As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsAutocompletion As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents bwCheckFile As System.ComponentModel.BackgroundWorker
	Friend WithEvents mnuHelpHowToUseTheHelpViewer As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuSettingsSaveLayout As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents sfdColumnLayout As System.Windows.Forms.SaveFileDialog
	Friend WithEvents ofdColumnLayout As System.Windows.Forms.OpenFileDialog
	Friend WithEvents mnuMyToolsCrashProgram As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents tscMain As System.Windows.Forms.ToolStripContainer
	Friend WithEvents ssMain As System.Windows.Forms.StatusStrip
	Friend WithEvents lblInformation As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents lblDate As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents lblUCF As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents bnDGV As System.Windows.Forms.BindingNavigator
	Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
	Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
	Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorDuplicateRecord As System.Windows.Forms.ToolStripButton
	Friend WithEvents toolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorSaveFileButton As System.Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorCutButton As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorCopyButton As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorPasteButton As System.Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorViewErrorsButton As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorUnsortFileButton As System.Windows.Forms.ToolStripButton
	Friend WithEvents mainDGV As WinREG.myDGV
	Friend WithEvents mainWelcomeText As System.Windows.Forms.TextBox
	Friend WithEvents mnuToolsFiltering As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsFilters As System.Windows.Forms.ToolStrip
	Friend WithEvents lblFiltersText As System.Windows.Forms.ToolStripLabel
	Friend WithEvents cbFilterColumns As System.Windows.Forms.ToolStripComboBox
	Friend WithEvents txtFilterString As System.Windows.Forms.ToolStripTextBox
	Friend WithEvents cbFilterValues As System.Windows.Forms.ToolStripComboBox
	Friend WithEvents cbFilterOperators As System.Windows.Forms.ToolStripComboBox
	Friend WithEvents lblFfilterStatus As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents lblShowAll As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents mnuRecordInsertRecord As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents tickRecovery As System.Windows.Forms.Timer
	Friend WithEvents mnuMyToolsException As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents fswTranscripts As System.IO.FileSystemWatcher
	Friend WithEvents mnuToolsRecoverBackup As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents panelWinREG2 As WinREG.WinREG2_Panel
	Friend WithEvents mnuToolsUseDataGrid As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents panelValidator As CustomValidation.ContainerValidator
	Friend WithEvents mnuToolsRebuildLookUpTables As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator

End Class
