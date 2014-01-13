<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageViewer
	Inherits System.Windows.Forms.Form

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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageViewer))
		Me.mnuImageViewer = New System.Windows.Forms.MenuStrip
		Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileBrowse = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuImage = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuImageFlipVertical = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuImageFlipHorizontal = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuImageRotateLeft = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuImageRotateRight = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuImageZoomIn = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuImageZoomOut = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuImageFitToScreen = New System.Windows.Forms.ToolStripMenuItem
		Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.KeepViewerOnTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.imglImageViewer = New System.Windows.Forms.ImageList(Me.components)
		Me.Button1 = New System.Windows.Forms.Button
		Me.errImageViewer = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.ttImageViewer = New System.Windows.Forms.ToolTip(Me.components)
		Me.btnPreviousImage = New System.Windows.Forms.Button
		Me.trkbarZoomer = New System.Windows.Forms.TrackBar
		Me.btnNextImage = New System.Windows.Forms.Button
		Me.splitImageViewer = New System.Windows.Forms.SplitContainer
		Me.splitTreeViewer = New System.Windows.Forms.SplitContainer
		Me.tvTreeNodes = New System.Windows.Forms.TreeView
		Me.lvTreeNode = New System.Windows.Forms.ListView
		Me.Filename = New System.Windows.Forms.ColumnHeader
		Me.Type = New System.Windows.Forms.ColumnHeader
		Me.LastAccessed = New System.Windows.Forms.ColumnHeader
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.pnlPhoto = New System.Windows.Forms.Panel
		Me.picPhoto = New System.Windows.Forms.PictureBox
		Me.hlpImageViewer = New System.Windows.Forms.HelpProvider
		Me.mnuImageViewer.SuspendLayout()
		CType(Me.errImageViewer, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.trkbarZoomer, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.splitImageViewer.Panel1.SuspendLayout()
		Me.splitImageViewer.Panel2.SuspendLayout()
		Me.splitImageViewer.SuspendLayout()
		Me.splitTreeViewer.Panel1.SuspendLayout()
		Me.splitTreeViewer.Panel2.SuspendLayout()
		Me.splitTreeViewer.SuspendLayout()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.pnlPhoto.SuspendLayout()
		CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'mnuImageViewer
		'
		Me.mnuImageViewer.AutoSize = False
		Me.mnuImageViewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuImage, Me.OptionsToolStripMenuItem})
		Me.mnuImageViewer.Location = New System.Drawing.Point(0, 0)
		Me.mnuImageViewer.Name = "mnuImageViewer"
		Me.mnuImageViewer.Size = New System.Drawing.Size(507, 24)
		Me.mnuImageViewer.TabIndex = 0
		Me.mnuImageViewer.Text = "MenuStrip1"
		'
		'mnuFile
		'
		Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileBrowse, Me.mnuFileExit})
		Me.mnuFile.Name = "mnuFile"
		Me.mnuFile.Size = New System.Drawing.Size(37, 20)
		Me.mnuFile.Text = "&File"
		'
		'mnuFileBrowse
		'
		Me.mnuFileBrowse.Name = "mnuFileBrowse"
		Me.mnuFileBrowse.Size = New System.Drawing.Size(121, 22)
		Me.mnuFileBrowse.Text = "&Browse..."
		'
		'mnuFileExit
		'
		Me.mnuFileExit.Name = "mnuFileExit"
		Me.mnuFileExit.Size = New System.Drawing.Size(121, 22)
		Me.mnuFileExit.Text = "E&xit"
		'
		'mnuImage
		'
		Me.mnuImage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImageFlipVertical, Me.mnuImageFlipHorizontal, Me.ToolStripSeparator1, Me.mnuImageRotateLeft, Me.mnuImageRotateRight, Me.ToolStripSeparator2, Me.mnuImageZoomIn, Me.mnuImageZoomOut, Me.ToolStripSeparator3, Me.mnuImageFitToScreen})
		Me.mnuImage.Enabled = False
		Me.mnuImage.Name = "mnuImage"
		Me.mnuImage.Size = New System.Drawing.Size(52, 20)
		Me.mnuImage.Text = "&Image"
		'
		'mnuImageFlipVertical
		'
		Me.mnuImageFlipVertical.Name = "mnuImageFlipVertical"
		Me.mnuImageFlipVertical.Size = New System.Drawing.Size(151, 22)
		Me.mnuImageFlipVertical.Text = "Flip Vertical"
		'
		'mnuImageFlipHorizontal
		'
		Me.mnuImageFlipHorizontal.Name = "mnuImageFlipHorizontal"
		Me.mnuImageFlipHorizontal.Size = New System.Drawing.Size(151, 22)
		Me.mnuImageFlipHorizontal.Text = "Flip Horizontal"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(148, 6)
		'
		'mnuImageRotateLeft
		'
		Me.mnuImageRotateLeft.Name = "mnuImageRotateLeft"
		Me.mnuImageRotateLeft.Size = New System.Drawing.Size(151, 22)
		Me.mnuImageRotateLeft.Text = "Rotate Left"
		'
		'mnuImageRotateRight
		'
		Me.mnuImageRotateRight.Name = "mnuImageRotateRight"
		Me.mnuImageRotateRight.Size = New System.Drawing.Size(151, 22)
		Me.mnuImageRotateRight.Text = "Rotate Right"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(148, 6)
		'
		'mnuImageZoomIn
		'
		Me.mnuImageZoomIn.Name = "mnuImageZoomIn"
		Me.mnuImageZoomIn.Size = New System.Drawing.Size(151, 22)
		Me.mnuImageZoomIn.Text = "Zoom In"
		'
		'mnuImageZoomOut
		'
		Me.mnuImageZoomOut.Name = "mnuImageZoomOut"
		Me.mnuImageZoomOut.Size = New System.Drawing.Size(151, 22)
		Me.mnuImageZoomOut.Text = "Zoom Out"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(148, 6)
		'
		'mnuImageFitToScreen
		'
		Me.mnuImageFitToScreen.Name = "mnuImageFitToScreen"
		Me.mnuImageFitToScreen.Size = New System.Drawing.Size(151, 22)
		Me.mnuImageFitToScreen.Text = "Fit to Screen"
		'
		'OptionsToolStripMenuItem
		'
		Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KeepViewerOnTopToolStripMenuItem})
		Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
		Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
		Me.OptionsToolStripMenuItem.Text = "Options"
		'
		'KeepViewerOnTopToolStripMenuItem
		'
		Me.KeepViewerOnTopToolStripMenuItem.CheckOnClick = True
		Me.KeepViewerOnTopToolStripMenuItem.Name = "KeepViewerOnTopToolStripMenuItem"
		Me.KeepViewerOnTopToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
		Me.KeepViewerOnTopToolStripMenuItem.Text = "Keep Viewer On Top"
		'
		'imglImageViewer
		'
		Me.imglImageViewer.ImageStream = CType(resources.GetObject("imglImageViewer.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imglImageViewer.TransparentColor = System.Drawing.Color.Transparent
		Me.imglImageViewer.Images.SetKeyName(0, "folder.ico")
		Me.imglImageViewer.Images.SetKeyName(1, "file.ico")
		Me.imglImageViewer.Images.SetKeyName(2, "txt.ico")
		Me.imglImageViewer.Images.SetKeyName(3, "bmp.ico")
		Me.imglImageViewer.Images.SetKeyName(4, "gif.ico")
		Me.imglImageViewer.Images.SetKeyName(5, "jpg.ico")
		Me.imglImageViewer.Images.SetKeyName(6, "pdf.ico")
		Me.imglImageViewer.Images.SetKeyName(7, "png.ico")
		Me.imglImageViewer.Images.SetKeyName(8, "tiff.ico")
		'
		'Button1
		'
		Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
		Me.Button1.Location = New System.Drawing.Point(402, 226)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(15, 23)
		Me.Button1.TabIndex = 4
		Me.Button1.UseVisualStyleBackColor = True
		'
		'errImageViewer
		'
		Me.errImageViewer.ContainerControl = Me
		'
		'ttImageViewer
		'
		Me.ttImageViewer.Active = Global.WinREG.My.MySettings.Default.MyDisplayTooltips
		Me.ttImageViewer.IsBalloon = True
		'
		'btnPreviousImage
		'
		Me.btnPreviousImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.btnPreviousImage.BackColor = System.Drawing.SystemColors.Control
		Me.btnPreviousImage.Dock = System.Windows.Forms.DockStyle.Fill
		Me.btnPreviousImage.Image = CType(resources.GetObject("btnPreviousImage.Image"), System.Drawing.Image)
		Me.btnPreviousImage.Location = New System.Drawing.Point(0, 262)
		Me.btnPreviousImage.Margin = New System.Windows.Forms.Padding(0)
		Me.btnPreviousImage.Name = "btnPreviousImage"
		Me.btnPreviousImage.Size = New System.Drawing.Size(24, 24)
		Me.btnPreviousImage.TabIndex = 5
		Me.ttImageViewer.SetToolTip(Me.btnPreviousImage, "Previous image")
		Me.btnPreviousImage.UseVisualStyleBackColor = False
		'
		'trkbarZoomer
		'
		Me.trkbarZoomer.BackColor = System.Drawing.SystemColors.Control
		Me.trkbarZoomer.Dock = System.Windows.Forms.DockStyle.Fill
		Me.trkbarZoomer.LargeChange = 10
		Me.trkbarZoomer.Location = New System.Drawing.Point(24, 262)
		Me.trkbarZoomer.Margin = New System.Windows.Forms.Padding(0)
		Me.trkbarZoomer.Maximum = 100
		Me.trkbarZoomer.Name = "trkbarZoomer"
		Me.trkbarZoomer.Size = New System.Drawing.Size(286, 24)
		Me.trkbarZoomer.SmallChange = 2
		Me.trkbarZoomer.TabIndex = 3
		Me.trkbarZoomer.TickFrequency = 5
		Me.trkbarZoomer.TickStyle = System.Windows.Forms.TickStyle.None
		Me.ttImageViewer.SetToolTip(Me.trkbarZoomer, "Zoom control")
		'
		'btnNextImage
		'
		Me.btnNextImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.btnNextImage.BackColor = System.Drawing.SystemColors.Control
		Me.btnNextImage.Dock = System.Windows.Forms.DockStyle.Fill
		Me.btnNextImage.Image = CType(resources.GetObject("btnNextImage.Image"), System.Drawing.Image)
		Me.btnNextImage.Location = New System.Drawing.Point(310, 262)
		Me.btnNextImage.Margin = New System.Windows.Forms.Padding(0)
		Me.btnNextImage.Name = "btnNextImage"
		Me.btnNextImage.Size = New System.Drawing.Size(24, 24)
		Me.btnNextImage.TabIndex = 6
		Me.ttImageViewer.SetToolTip(Me.btnNextImage, "Next image")
		Me.btnNextImage.UseVisualStyleBackColor = False
		'
		'splitImageViewer
		'
		Me.splitImageViewer.DataBindings.Add(New System.Windows.Forms.Binding("SplitterDistance", Global.WinREG.My.MySettings.Default, "MyImageViewerSplitterDistance", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.splitImageViewer.Dock = System.Windows.Forms.DockStyle.Fill
		Me.splitImageViewer.Location = New System.Drawing.Point(0, 24)
		Me.splitImageViewer.Name = "splitImageViewer"
		'
		'splitImageViewer.Panel1
		'
		Me.splitImageViewer.Panel1.Controls.Add(Me.splitTreeViewer)
		'
		'splitImageViewer.Panel2
		'
		Me.splitImageViewer.Panel2.Controls.Add(Me.TableLayoutPanel1)
		Me.splitImageViewer.Size = New System.Drawing.Size(507, 286)
		Me.splitImageViewer.SplitterDistance = 169
		Me.splitImageViewer.TabIndex = 1
		'
		'splitTreeViewer
		'
		Me.splitTreeViewer.DataBindings.Add(New System.Windows.Forms.Binding("SplitterDistance", Global.WinREG.My.MySettings.Default, "MyTreeViewerSplitterDistance", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
		Me.splitTreeViewer.Dock = System.Windows.Forms.DockStyle.Fill
		Me.splitTreeViewer.Location = New System.Drawing.Point(0, 0)
		Me.splitTreeViewer.Name = "splitTreeViewer"
		Me.splitTreeViewer.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'splitTreeViewer.Panel1
		'
		Me.splitTreeViewer.Panel1.Controls.Add(Me.tvTreeNodes)
		'
		'splitTreeViewer.Panel2
		'
		Me.splitTreeViewer.Panel2.Controls.Add(Me.lvTreeNode)
		Me.splitTreeViewer.Size = New System.Drawing.Size(169, 286)
		Me.splitTreeViewer.SplitterDistance = 143
		Me.splitTreeViewer.TabIndex = 1
		'
		'tvTreeNodes
		'
		Me.tvTreeNodes.BackColor = System.Drawing.Color.White
		Me.tvTreeNodes.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tvTreeNodes.FullRowSelect = True
		Me.tvTreeNodes.HideSelection = False
		Me.tvTreeNodes.ImageIndex = 0
		Me.tvTreeNodes.ImageList = Me.imglImageViewer
		Me.tvTreeNodes.Location = New System.Drawing.Point(0, 0)
		Me.tvTreeNodes.Name = "tvTreeNodes"
		Me.tvTreeNodes.SelectedImageIndex = 0
		Me.tvTreeNodes.Size = New System.Drawing.Size(169, 143)
		Me.tvTreeNodes.TabIndex = 0
		'
		'lvTreeNode
		'
		Me.lvTreeNode.BackColor = System.Drawing.Color.White
		Me.lvTreeNode.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Filename, Me.Type, Me.LastAccessed})
		Me.lvTreeNode.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lvTreeNode.HideSelection = False
		Me.lvTreeNode.LargeImageList = Me.imglImageViewer
		Me.lvTreeNode.Location = New System.Drawing.Point(0, 0)
		Me.lvTreeNode.MultiSelect = False
		Me.lvTreeNode.Name = "lvTreeNode"
		Me.lvTreeNode.ShowGroups = False
		Me.lvTreeNode.Size = New System.Drawing.Size(169, 139)
		Me.lvTreeNode.SmallImageList = Me.imglImageViewer
		Me.lvTreeNode.Sorting = System.Windows.Forms.SortOrder.Ascending
		Me.lvTreeNode.TabIndex = 0
		Me.lvTreeNode.UseCompatibleStateImageBehavior = False
		Me.lvTreeNode.View = System.Windows.Forms.View.Details
		'
		'Filename
		'
		Me.Filename.Text = "File name"
		'
		'Type
		'
		Me.Type.Text = "Type"
		'
		'LastAccessed
		'
		Me.LastAccessed.Text = "Last accessed"
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.AutoSize = True
		Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control
		Me.TableLayoutPanel1.ColumnCount = 3
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.pnlPhoto, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.btnPreviousImage, 0, 1)
		Me.TableLayoutPanel1.Controls.Add(Me.trkbarZoomer, 1, 1)
		Me.TableLayoutPanel1.Controls.Add(Me.btnNextImage, 2, 1)
		Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
		Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 2
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(334, 286)
		Me.TableLayoutPanel1.TabIndex = 1
		'
		'pnlPhoto
		'
		Me.pnlPhoto.AutoScroll = True
		Me.pnlPhoto.BackColor = System.Drawing.SystemColors.Control
		Me.TableLayoutPanel1.SetColumnSpan(Me.pnlPhoto, 3)
		Me.pnlPhoto.Controls.Add(Me.picPhoto)
		Me.pnlPhoto.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPhoto.Location = New System.Drawing.Point(0, 0)
		Me.pnlPhoto.Margin = New System.Windows.Forms.Padding(0)
		Me.pnlPhoto.Name = "pnlPhoto"
		Me.pnlPhoto.Size = New System.Drawing.Size(334, 262)
		Me.pnlPhoto.TabIndex = 7
		'
		'picPhoto
		'
		Me.picPhoto.BackColor = System.Drawing.SystemColors.Control
		Me.picPhoto.Location = New System.Drawing.Point(0, 0)
		Me.picPhoto.Margin = New System.Windows.Forms.Padding(0)
		Me.picPhoto.Name = "picPhoto"
		Me.picPhoto.Size = New System.Drawing.Size(100, 50)
		Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.picPhoto.TabIndex = 3
		Me.picPhoto.TabStop = False
		Me.picPhoto.WaitOnLoad = True
		'
		'hlpImageViewer
		'
		Me.hlpImageViewer.HelpNamespace = Global.WinREG.My.MySettings.Default.HelpFileName
		'
		'frmImageViewer
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(507, 310)
		Me.Controls.Add(Me.splitImageViewer)
		Me.Controls.Add(Me.mnuImageViewer)
		Me.HelpButton = True
		Me.hlpImageViewer.SetHelpKeyword(Me, "ImageViewer.html")
		Me.hlpImageViewer.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MainMenuStrip = Me.mnuImageViewer
		Me.Name = "frmImageViewer"
		Me.hlpImageViewer.SetShowHelp(Me, True)
		Me.Text = "Image Viewer"
		Me.mnuImageViewer.ResumeLayout(False)
		Me.mnuImageViewer.PerformLayout()
		CType(Me.errImageViewer, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.trkbarZoomer, System.ComponentModel.ISupportInitialize).EndInit()
		Me.splitImageViewer.Panel1.ResumeLayout(False)
		Me.splitImageViewer.Panel2.ResumeLayout(False)
		Me.splitImageViewer.Panel2.PerformLayout()
		Me.splitImageViewer.ResumeLayout(False)
		Me.splitTreeViewer.Panel1.ResumeLayout(False)
		Me.splitTreeViewer.Panel2.ResumeLayout(False)
		Me.splitTreeViewer.ResumeLayout(False)
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.TableLayoutPanel1.PerformLayout()
		Me.pnlPhoto.ResumeLayout(False)
		CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents mnuImageViewer As System.Windows.Forms.MenuStrip
	Friend WithEvents splitImageViewer As System.Windows.Forms.SplitContainer
	Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileBrowse As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuImage As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuImageFlipVertical As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuImageFlipHorizontal As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuImageRotateLeft As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuImageRotateRight As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuImageZoomIn As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuImageZoomOut As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuImageFitToScreen As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents errImageViewer As System.Windows.Forms.ErrorProvider
	Friend WithEvents hlpImageViewer As System.Windows.Forms.HelpProvider
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents trkbarZoomer As System.Windows.Forms.TrackBar
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents btnPreviousImage As System.Windows.Forms.Button
	Friend WithEvents ttImageViewer As System.Windows.Forms.ToolTip
	Friend WithEvents imglImageViewer As System.Windows.Forms.ImageList
	Friend WithEvents tvTreeNodes As System.Windows.Forms.TreeView
	Friend WithEvents splitTreeViewer As System.Windows.Forms.SplitContainer
	Friend WithEvents lvTreeNode As System.Windows.Forms.ListView
	Friend WithEvents Filename As System.Windows.Forms.ColumnHeader
	Friend WithEvents Type As System.Windows.Forms.ColumnHeader
	Friend WithEvents LastAccessed As System.Windows.Forms.ColumnHeader
	Friend WithEvents btnNextImage As System.Windows.Forms.Button
	Friend WithEvents picPhoto As System.Windows.Forms.PictureBox
	Friend WithEvents pnlPhoto As System.Windows.Forms.Panel
	Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents KeepViewerOnTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
