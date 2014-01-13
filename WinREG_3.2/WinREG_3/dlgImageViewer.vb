'	$Date: 2012-11-23 12:59:32 +0200 (Fri, 23 Nov 2012) $
'	$Rev: 179 $
'	$Id: dlgImageViewer.vb 179 2012-11-23 10:59:32Z Mikefry $
'
'	WinREG/3 - Version 3.1.14
'

Imports System.IO
Imports System.Drawing

Public Class frmImageViewer

	' Constants to define the size and spacing of our thumbnails
	Const iTNWidth As Integer = 120
	Const iTNHeight As Integer = 80
	Const iHPadding As Integer = 5
	Const iVPadding As Integer = 5

	' Sets the initial zoom factor to 100%
	Dim dZoomFactor As Double = 1
	' Specifies that the zoom factor will be changed in increments of 10%
	Dim dZoomIncrements As Double = 0.1

	Dim iCount = 0
	Dim iSelectedIndex As Integer = -1
	Dim iInitialSplitterSize As Integer = My.Settings.MyImageViewerSplitterDistance

	Private Sub frmImageViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		If My.Settings.ImageFolderName = "" Then
			My.Settings.ImageFolderName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
		End If
		If My.Settings.MyDisplayTooltips Then Me.ttImageViewer.AutoPopDelay = My.Settings.TooltipsDisplayPeriod * 1000

		Try
			' Restore window state & position
			Me.Size = My.Settings.MyImageViewerSize
			Me.Location = My.Settings.MyImageViewerLocation
			Me.WindowState = My.Settings.MyImageViewerWindowState
			Me.TopMost = My.Settings.MyImageViewerOnTop
			Me.dZoomFactor = My.Settings.MyImageZoomFactor

			KeepViewerOnTopToolStripMenuItem.Checked = My.Settings.MyImageViewerOnTop

		Catch ex As Exception
			My.Application.Log.WriteEntry(Now() + " Exception <" + ex.Message + ">", TraceEventType.Error)
			My.Application.Log.WriteEntry(Now() + " Exception <" + ex.StackTrace + ">", TraceEventType.Error)
			My.Application.Log.WriteEntry(Now() + " Exception <" + ex.Source + ">", TraceEventType.Error)

			Dim msgText As String = ex.Message & ex.StackTrace

			MessageBox.Show(msgText, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

			splitImageViewer.Panel1MinSize = 10
			splitImageViewer.Panel2MinSize = 10
			splitImageViewer.SplitterDistance = My.Settings.MyImageViewerSplitterDistance
			splitTreeViewer.Panel1MinSize = 10
			splitTreeViewer.Panel2MinSize = 10
			splitTreeViewer.SplitterDistance = My.Settings.MyTreeViewerSplitterDistance
		End Try

		lvTreeNode.Columns(0).Width = My.Settings.MyColumnWidth1
		lvTreeNode.Columns(1).Width = My.Settings.MyColumnWidth2
		lvTreeNode.Columns(2).Width = My.Settings.MyColumnWidth3
		splitImageViewer.SplitterDistance = iInitialSplitterSize

		PopulateTreeView(My.Settings.ImageFolderName)

	End Sub

	Private Sub frmImageViewer_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

	End Sub

	Private Sub frmImageViewer_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

		My.Settings.MyImageViewerWindowState = Me.WindowState

		If Me.WindowState = FormWindowState.Normal Then
			My.Settings.MyImageViewerSize = Me.Size
			My.Settings.MyImageViewerLocation = Me.Location
		Else
			My.Settings.MyImageViewerSize = Me.RestoreBounds.Size
			My.Settings.MyImageViewerLocation = Me.RestoreBounds.Location
		End If
		'		My.Settings.MyImageViewerSplitterDistance = iInitialSplitterSize
		My.Settings.MyImageViewerOnTop = Me.TopMost

		My.Settings.MyImageZoomFactor = Me.dZoomFactor
		My.Settings.MyColumnWidth1 = lvTreeNode.Columns(0).Width
		My.Settings.MyColumnWidth2 = lvTreeNode.Columns(1).Width
		My.Settings.MyColumnWidth3 = lvTreeNode.Columns(2).Width
		'		My.Settings.MyImageViewerSplitterDistance = iInitialSplitterSize
		My.Settings.Save()
	End Sub

	Private Sub PopulateTreeView(ByVal nodestr As String)
		Dim rootNode As TreeNode
		Try
			Dim info As New DirectoryInfo(nodestr)
			If info.Exists Then
				rootNode = New TreeNode(info.Name)
				rootNode.Tag = info
				GetDirectories(info.GetDirectories(), rootNode)
				tvTreeNodes.Nodes.Add(rootNode)
			End If

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Critical, "PopulateTreeView")

		End Try

	End Sub

	Private Sub GetDirectories(ByVal subDirs() As DirectoryInfo, ByVal nodeToAddTo As TreeNode)

		Dim aNode As TreeNode
		Dim subSubDirs() As DirectoryInfo
		Dim subDir As DirectoryInfo
		For Each subDir In subDirs
			aNode = New TreeNode(subDir.Name, 0, 0)
			aNode.Tag = subDir
			aNode.ImageKey = "folder"
			Try
				subSubDirs = subDir.GetDirectories()
				If subSubDirs.Length <> 0 Then
					GetDirectories(subSubDirs, aNode)
				End If
				nodeToAddTo.Nodes.Add(aNode)
			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Critical, "GetDirectories")

			End Try
		Next subDir

	End Sub

	Private Sub mnuFileBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileBrowse.Click
		Dim dlg As FolderBrowserDialog

		' Create a new instance of the folder browser dialog
		dlg = New FolderBrowserDialog
		dlg.SelectedPath = My.Settings.ImageFolderName
		dlg.ShowNewFolderButton = False

		' Show the Dialog and check that the user pressed OK to close it - not cancel
		If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
			Me.Cursor = Cursors.WaitCursor		' Set the Forms cursor to an hourglass
			PopulateTreeView(dlg.SelectedPath)
			Me.Cursor = Cursors.Arrow				' Return the Forms cursor to an arrow
			My.Settings.ImageFolderName = dlg.SelectedPath
		End If

		' Dispose of the dialog
		dlg.Dispose()
	End Sub

	Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
		Me.Close()
	End Sub

	Private Sub tvTreeNodes_MouseClick(ByVal sender As System.Object, ByVal e As TreeNodeMouseClickEventArgs) Handles tvTreeNodes.NodeMouseClick
		Dim newSelected As TreeNode = e.Node
		lvTreeNode.Items.Clear()
		Dim nodeDirInfo As DirectoryInfo = CType(newSelected.Tag, DirectoryInfo)
		Dim subItems() As ListViewItem.ListViewSubItem
		Dim item As ListViewItem = Nothing

		Dim dir As DirectoryInfo
		For Each dir In nodeDirInfo.GetDirectories()
			item = New ListViewItem(dir.Name, 0)
			subItems = New ListViewItem.ListViewSubItem() {New ListViewItem.ListViewSubItem(item, "Directory"), New ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString()), New ListViewItem.ListViewSubItem(item, dir.FullName())}
			item.SubItems.AddRange(subItems)
			lvTreeNode.Items.Add(item)
		Next dir

		Dim file As FileInfo
		For Each file In nodeDirInfo.GetFiles("*.jpg")
			item = New ListViewItem(file.Name, 5)
			subItems = New ListViewItem.ListViewSubItem() {New ListViewItem.ListViewSubItem(item, "JPEG File"), New ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString()), New ListViewItem.ListViewSubItem(item, file.FullName())}
			item.SubItems.AddRange(subItems)
			lvTreeNode.Items.Add(item)
		Next file

		For Each file In nodeDirInfo.GetFiles("*.tif*")
			item = New ListViewItem(file.Name, 5)
			subItems = New ListViewItem.ListViewSubItem() {New ListViewItem.ListViewSubItem(item, "TIFF File"), New ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString()), New ListViewItem.ListViewSubItem(item, file.FullName())}
			item.SubItems.AddRange(subItems)
			lvTreeNode.Items.Add(item)
		Next file

	End Sub

	Private Sub lvTreeNode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTreeNode.SelectedIndexChanged

		Dim breakfast As ListView.SelectedListViewItemCollection = lvTreeNode.SelectedItems
		Dim item As ListViewItem

		For Each item In breakfast
			If item.SubItems(1).Text = "JPEG File" Or item.SubItems(1).Text = "TIFF File" Then
				If picPhoto.Image IsNot Nothing Then
					picPhoto.Image.Dispose()
					picPhoto.Image = Nothing
					mnuImage.Enabled = False
				End If
				Try
					picPhoto.Image = Image.FromFile(item.SubItems(3).Text, False)
					mnuImage.Enabled = True
					Me.Text = "Image Viewer - " & item.Text
					FitPhotoToPanel()
					ReDrawPhoto(0, 0)
					iSelectedIndex = item.Index
					iCount = lvTreeNode.Items.Count

				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Critical, "lvTreeNode_SelectedIndexChanged")

				End Try
			End If
		Next

	End Sub

	Private Sub btnPreviousImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviousImage.Click
		If iSelectedIndex <> -1 Then
			iSelectedIndex -= 1
			If iSelectedIndex = -1 Then
				iSelectedIndex = iCount - 1
			End If

			Dim item As ListViewItem = lvTreeNode.Items(iSelectedIndex)
			If item.SubItems(1).Text = "JPEG File" Or item.SubItems(1).Text = "TIFF File" Then
				If picPhoto.Image IsNot Nothing Then
					picPhoto.Image.Dispose()
					picPhoto.Image = Nothing
					mnuImage.Enabled = False
				End If
				Try
					picPhoto.Image = Image.FromFile(item.SubItems(3).Text)
					mnuImage.Enabled = True
					Me.Text = "Image Viewer - " & item.Text
					FitPhotoToPanel()
					ReDrawPhoto(0, 0)
					iSelectedIndex = item.Index
					iCount = lvTreeNode.Items.Count
					lvTreeNode.Items(iSelectedIndex).Selected = True

				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Critical, "btnPreviousImage_Click")

				End Try
			End If
		End If

	End Sub

	Private Sub btnNextImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextImage.Click
		If iSelectedIndex <> -1 Then
			iSelectedIndex += 1
			If iSelectedIndex = iCount Then
				iSelectedIndex = 0
			End If

			Dim item As ListViewItem = lvTreeNode.Items(iSelectedIndex)
			If item.SubItems(1).Text = "JPEG File" Or item.SubItems(1).Text = "TIFF File" Then
				If picPhoto.Image IsNot Nothing Then
					picPhoto.Image.Dispose()
					picPhoto.Image = Nothing
					mnuImage.Enabled = False
				End If
				Try
					picPhoto.Image = Image.FromFile(item.SubItems(3).Text)
					mnuImage.Enabled = True
					Me.Text = "Image Viewer - " & item.Text
					FitPhotoToPanel()
					ReDrawPhoto(0, 0)
					iSelectedIndex = item.Index
					iCount = lvTreeNode.Items.Count
					lvTreeNode.Items(iSelectedIndex).Selected = True

				Catch ex As Exception
					My.Application.Log.WriteException(ex, TraceEventType.Critical, "btnNextImage_Click")

				End Try
			End If
		End If

	End Sub

	Private Sub ReDrawPhoto(ByVal xPos As Integer, ByVal yPos As Integer)
		Dim dPicStaticXPos, dPicStaticYPos As Double
		Dim dPanelStaticXPos, dPanelStaticYPos As Double
		Dim iNewXPos, iNewYPos As Integer

		Try
			If picPhoto.Image IsNot Nothing Then
				' Get the position on the picture in pixels of
				' the coordinates specified in the function, we will use this to
				' ensure these coordinates stay in the same position each time we redraw the photo
				dPicStaticXPos = xPos / (picPhoto.Width / picPhoto.Image.Width)
				dPicStaticYPos = yPos / (picPhoto.Height / picPhoto.Image.Height)
				dPanelStaticXPos = xPos + pnlPhoto.AutoScrollPosition.X
				dPanelStaticYPos = yPos + pnlPhoto.AutoScrollPosition.Y

				' Set the new image height and width using the zoom factor
				picPhoto.Height = CInt(picPhoto.Image.Height * dZoomFactor)
				picPhoto.Width = CInt(picPhoto.Image.Width * dZoomFactor)
				picPhoto.Refresh()

				' Set the AutoScrollPosition so that the point clicked on is in the same position on the screen after zooming
				iNewXPos = CInt((dPicStaticXPos * dZoomFactor) - dPanelStaticXPos)
				iNewYPos = CInt((dPicStaticYPos * dZoomFactor) - dPanelStaticYPos)
				pnlPhoto.AutoScrollPosition = New System.Drawing.Point(iNewXPos, iNewYPos)
			End If

		Catch ex As Exception
			My.Application.Log.WriteException(ex, TraceEventType.Critical, "ReDrawPhoto")

		End Try
	End Sub

	Private Sub FitPhotoToPanel()
		' Assumes that the Panel is approximately square
		' Calculates the maximum zoom factor that can be used and still
		' fit the image on the panel used to contain it
		'If picPhoto.Image IsNot Nothing Then
		'	If picPhoto.Image.Height > picPhoto.Image.Width Then
		'		dZoomFactor = (pnlPhoto.Height - 5) / picPhoto.Image.Height
		'	Else
		'		dZoomFactor = (pnlPhoto.Width - 5) / picPhoto.Image.Width
		'	End If
		'End If
	End Sub

	Private Sub picPhoto_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picPhoto.MouseWheel
		If e.Delta > 0 Then
			dZoomFactor *= (e.Delta / 120) * (1 + dZoomIncrements)
		ElseIf e.Delta < 0 Then
			dZoomFactor *= (e.Delta / -120) * (1 - dZoomIncrements)
		End If
		ReDrawPhoto(e.X, e.Y)
	End Sub

	Private Sub ImageZoomIn(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageZoomIn.Click
		' Increases the zoom factor and redraws the image
		' Passes the coordinates of the middle of the screen into the ReDrawPhoto function so
		' that the centre of the image at present remains in the centre of the screen.
		dZoomFactor *= 1 + dZoomIncrements
		ReDrawPhoto(CInt(pnlPhoto.Width / 2) - pnlPhoto.AutoScrollPosition.X, CInt(pnlPhoto.Height / 2) - pnlPhoto.AutoScrollPosition.Y)
	End Sub

	Private Sub ImageZoomOut(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageZoomOut.Click
		dZoomFactor *= 1 - dZoomIncrements
		ReDrawPhoto(CInt(pnlPhoto.Width / 2) - pnlPhoto.AutoScrollPosition.X, CInt(pnlPhoto.Height / 2) - pnlPhoto.AutoScrollPosition.Y)
	End Sub

	Private Sub ImageFitToScreen(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageFitToScreen.Click
		FitPhotoToPanel()
		ReDrawPhoto(0, 0)
	End Sub

	Private Sub ImageFlipVertical(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageFlipVertical.Click
		If picPhoto.Image IsNot Nothing Then
			picPhoto.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
			ReDrawPhoto(CInt(pnlPhoto.Width / 2), CInt(pnlPhoto.Height / 2))
		End If
	End Sub

	Private Sub ImageFlipHorizontal(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageFlipHorizontal.Click
		If picPhoto.Image IsNot Nothing Then
			picPhoto.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
			ReDrawPhoto(CInt(pnlPhoto.Width / 2), CInt(pnlPhoto.Height / 2))
		End If
	End Sub

	Private Sub ImageRotateLeft(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageRotateLeft.Click
		If picPhoto.Image IsNot Nothing Then
			picPhoto.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
			ReDrawPhoto(CInt(pnlPhoto.Width / 2), CInt(pnlPhoto.Height / 2))
		End If
	End Sub

	Private Sub ImageRotateRight(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageRotateRight.Click
		If picPhoto.Image IsNot Nothing Then
			picPhoto.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
			ReDrawPhoto(CInt(pnlPhoto.Width / 2), CInt(pnlPhoto.Height / 2))
		End If
	End Sub

	Private Sub trkbarZoomer_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkbarZoomer.Scroll
		dZoomFactor = (trkbarZoomer.Value) / 100 + dZoomIncrements
		ReDrawPhoto(CInt(pnlPhoto.Width / 2) - pnlPhoto.AutoScrollPosition.X, CInt(pnlPhoto.Height / 2) - pnlPhoto.AutoScrollPosition.Y)
	End Sub

	Private Sub lvTreeNode_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvTreeNode.ColumnClick
		With lvTreeNode
			If .Sorting = SortOrder.Ascending Then
				.Sorting = SortOrder.Descending
			ElseIf .Sorting = SortOrder.Descending Then
				.Sorting = SortOrder.None
			Else
				.Sorting = SortOrder.Ascending
			End If
		End With
	End Sub

	Private Sub KeepViewerOnTopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeepViewerOnTopToolStripMenuItem.Click
		Me.TopMost = KeepViewerOnTopToolStripMenuItem.Checked()
	End Sub

	Private Sub splitImageViewer_SplitterMoving(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterCancelEventArgs) Handles splitImageViewer.SplitterMoving
		Cursor.Current = Cursors.VSplit
	End Sub

	Private Sub splitImageViewer_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splitImageViewer.SplitterMoved
		Cursor.Current = Cursors.Default
		My.Settings.MyImageViewerSplitterDistance = splitImageViewer.SplitterDistance
	End Sub

	Private Sub splitTreeViewer_SplitterMoving(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterCancelEventArgs) Handles splitTreeViewer.SplitterMoving
		Cursor.Current = Cursors.HSplit
	End Sub

	Private Sub splitTreeViewer_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splitTreeViewer.SplitterMoved
		Cursor.Current = Cursors.Default
		My.Settings.MyTreeViewerSplitterDistance = splitTreeViewer.SplitterDistance
	End Sub

End Class
