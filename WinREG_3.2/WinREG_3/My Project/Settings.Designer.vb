﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.5472
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Name() As String
            Get
                Return CType(Me("Name"),String)
            End Get
            Set
                Me("Name") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property EmailAddress() As String
            Get
                Return CType(Me("EmailAddress"),String)
            End Get
            Set
                Me("EmailAddress") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Syndicate() As String
            Get
                Return CType(Me("Syndicate"),String)
            End Get
            Set
                Me("Syndicate") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property DataFolderName() As String
            Get
                Return CType(Me("DataFolderName"),String)
            End Get
            Set
                Me("DataFolderName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BackupFolderName() As String
            Get
                Return CType(Me("BackupFolderName"),String)
            End Get
            Set
                Me("BackupFolderName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ProductFolderName() As String
            Get
                Return CType(Me("ProductFolderName"),String)
            End Get
            Set
                Me("ProductFolderName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property Location_MainForm() As Global.System.Drawing.Point
            Get
                Return CType(Me("Location_MainForm"),Global.System.Drawing.Point)
            End Get
            Set
                Me("Location_MainForm") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property WindowState_MainForm() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("WindowState_MainForm"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("WindowState_MainForm") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("729, 452")>  _
        Public Property Size_MainForm() As Global.System.Drawing.Size
            Get
                Return CType(Me("Size_MainForm"),Global.System.Drawing.Size)
            End Get
            Set
                Me("Size_MainForm") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("WinREG3a.chm")>  _
        Public ReadOnly Property HelpFileName() As String
            Get
                Return CType(Me("HelpFileName"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property MyUCFLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("MyUCFLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("MyUCFLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property MyUCFWindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("MyUCFWindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("MyUCFWindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property MyDatePickerLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("MyDatePickerLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("MyDatePickerLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property MyDatePickerWindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("MyDatePickerWindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("MyDatePickerWindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property MyDisplayTooltips() As Boolean
            Get
                Return CType(Me("MyDisplayTooltips"),Boolean)
            End Get
            Set
                Me("MyDisplayTooltips") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ImageFolderName() As String
            Get
                Return CType(Me("ImageFolderName"),String)
            End Get
            Set
                Me("ImageFolderName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property MyImageViewerLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("MyImageViewerLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("MyImageViewerLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("523, 348")>  _
        Public Property MyImageViewerSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("MyImageViewerSize"),Global.System.Drawing.Size)
            End Get
            Set
                Me("MyImageViewerSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property MyImageViewerWindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("MyImageViewerWindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("MyImageViewerWindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("169")>  _
        Public Property MyImageViewerSplitterDistance() As Integer
            Get
                Return CType(Me("MyImageViewerSplitterDistance"),Integer)
            End Get
            Set
                Me("MyImageViewerSplitterDistance") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property MyImageViewerOnTop() As Boolean
            Get
                Return CType(Me("MyImageViewerOnTop"),Boolean)
            End Get
            Set
                Me("MyImageViewerOnTop") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("143")>  _
        Public Property MyTreeViewerSplitterDistance() As Integer
            Get
                Return CType(Me("MyTreeViewerSplitterDistance"),Integer)
            End Get
            Set
                Me("MyTreeViewerSplitterDistance") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("60")>  _
        Public Property MyColumnWidth1() As Integer
            Get
                Return CType(Me("MyColumnWidth1"),Integer)
            End Get
            Set
                Me("MyColumnWidth1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("60")>  _
        Public Property MyColumnWidth2() As Integer
            Get
                Return CType(Me("MyColumnWidth2"),Integer)
            End Get
            Set
                Me("MyColumnWidth2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("60")>  _
        Public Property MyColumnWidth3() As Integer
            Get
                Return CType(Me("MyColumnWidth3"),Integer)
            End Get
            Set
                Me("MyColumnWidth3") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property MyImageZoomFactor() As Double
            Get
                Return CType(Me("MyImageZoomFactor"),Double)
            End Get
            Set
                Me("MyImageZoomFactor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property MyBackupRestoreLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("MyBackupRestoreLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("MyBackupRestoreLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property MyBackupRestoreWindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("MyBackupRestoreWindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("MyBackupRestoreWindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property MyUserSettingsWindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("MyUserSettingsWindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("MyUserSettingsWindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("334, 385")>  _
        Public Property MyUserSettingsSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("MyUserSettingsSize"),Global.System.Drawing.Size)
            End Get
            Set
                Me("MyUserSettingsSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property MyUserSettingsLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("MyUserSettingsLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("MyUserSettingsLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property MyHelpfulHintsLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("MyHelpfulHintsLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("MyHelpfulHintsLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property MyHelpfulHintsWindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("MyHelpfulHintsWindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("MyHelpfulHintsWindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10")>  _
        Public Property TooltipsDisplayPeriod() As Decimal
            Get
                Return CType(Me("TooltipsDisplayPeriod"),Decimal)
            End Get
            Set
                Me("TooltipsDisplayPeriod") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property MyAutofillFields() As Boolean
            Get
                Return CType(Me("MyAutofillFields"),Boolean)
            End Get
            Set
                Me("MyAutofillFields") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property MyOptionsTab() As Integer
            Get
                Return CType(Me("MyOptionsTab"),Integer)
            End Get
            Set
                Me("MyOptionsTab") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property MyOptionsWindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("MyOptionsWindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("MyOptionsWindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property MyOptionsLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("MyOptionsLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("MyOptionsLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property MyMRUList() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("MyMRUList"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("MyMRUList") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("5")>  _
        Public Property MyMRUSize() As Integer
            Get
                Return CType(Me("MyMRUSize"),Integer)
            End Get
            Set
                Me("MyMRUSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property MyCommonFileDetailsLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("MyCommonFileDetailsLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("MyCommonFileDetailsLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property MyCommonFileDetailsWindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("MyCommonFileDetailsWindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("MyCommonFileDetailsWindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property MyEditFileNameLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("MyEditFileNameLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("MyEditFileNameLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property MyEditFileNameWindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("MyEditFileNameWindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("MyEditFileNameWindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property colLayoutMarriages() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("colLayoutMarriages"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("colLayoutMarriages") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property colLayoutBurials() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("colLayoutBurials"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("colLayoutBurials") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property colLayoutBaptisms() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("colLayoutBaptisms"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("colLayoutBaptisms") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property UpgradeSettings() As Boolean
            Get
                Return CType(Me("UpgradeSettings"),Boolean)
            End Get
            Set
                Me("UpgradeSettings") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("LemonChiffon")>  _
        Public Property MyCellColour() As Global.System.Drawing.Color
            Get
                Return CType(Me("MyCellColour"),Global.System.Drawing.Color)
            End Get
            Set
                Me("MyCellColour") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Wheat")>  _
        Public Property MyAlternateCellColour() As Global.System.Drawing.Color
            Get
                Return CType(Me("MyAlternateCellColour"),Global.System.Drawing.Color)
            End Get
            Set
                Me("MyAlternateCellColour") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 8.25pt")>  _
        Public Property MyCellFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("MyCellFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("MyCellFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 8.25pt")>  _
        Public ReadOnly Property DefaultCellFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("DefaultCellFont"),Global.System.Drawing.Font)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("LemonChiffon")>  _
        Public ReadOnly Property DefaultCellColour() As Global.System.Drawing.Color
            Get
                Return CType(Me("DefaultCellColour"),Global.System.Drawing.Color)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Wheat")>  _
        Public ReadOnly Property DefaultAlternateCellColour() As Global.System.Drawing.Color
            Get
                Return CType(Me("DefaultAlternateCellColour"),Global.System.Drawing.Color)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property AutoCopyDates() As Boolean
            Get
                Return CType(Me("AutoCopyDates"),Boolean)
            End Get
            Set
                Me("AutoCopyDates") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property MyLeadingZeroOnDates() As Boolean
            Get
                Return CType(Me("MyLeadingZeroOnDates"),Boolean)
            End Get
            Set
                Me("MyLeadingZeroOnDates") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property ConfirmRecordDuplication() As Boolean
            Get
                Return CType(Me("ConfirmRecordDuplication"),Boolean)
            End Get
            Set
                Me("ConfirmRecordDuplication") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property MyCreateBackups() As Boolean
            Get
                Return CType(Me("MyCreateBackups"),Boolean)
            End Get
            Set
                Me("MyCreateBackups") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property LoadFinished() As Boolean
            Get
                Return CType(Me("LoadFinished"),Boolean)
            End Get
            Set
                Me("LoadFinished") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property UseDataGrid() As Boolean
            Get
                Return CType(Me("UseDataGrid"),Boolean)
            End Get
            Set
                Me("UseDataGrid") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property ShowSplashScreen() As Boolean
            Get
                Return CType(Me("ShowSplashScreen"),Boolean)
            End Get
            Set
                Me("ShowSplashScreen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property MyUserName() As String
            Get
                Return CType(Me("MyUserName"),String)
            End Get
            Set
                Me("MyUserName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property MyUserPassword() As String
            Get
                Return CType(Me("MyUserPassword"),String)
            End Get
            Set
                Me("MyUserPassword") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.WinREG.My.MySettings
            Get
                Return Global.WinREG.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
