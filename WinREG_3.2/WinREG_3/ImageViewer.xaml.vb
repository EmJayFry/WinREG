Imports System.Windows
Imports System.IO
Imports System.Windows.Media.Imaging
Imports System.Windows.Controls
Imports System.Linq
Imports System.Windows.Input
Imports ZoomAndPan
Imports System.Windows.Data
Imports System.Windows.Media

Public Enum MouseHandlingMode
	None
	DraggingRectangles
	Panning
	Zooming
	DragZooming
End Enum

Class ImageViewer

	Private _fileList As IEnumerable(Of System.IO.FileInfo)
	Private _path As String = My.Settings.ImageFolderName

	''' <summary>
	''' Specifies the current state of the mouse handling logic.
	''' </summary>
	Private mouseHandlingMode As MouseHandlingMode = mouseHandlingMode.None

	''' <summary>
	''' The point that was clicked relative to the ZoomAndPanControl.
	''' </summary>
	Private origZoomAndPanControlMouseDownPoint As Point

	''' <summary>
	''' The point that was clicked relative to the content that is contained within the ZoomAndPanControl.
	''' </summary>
	Private origContentMouseDownPoint As Point

	''' <summary>
	''' Records which mouse button clicked during mouse dragging.
	''' </summary>
	Private mouseButtonDown As MouseButton

	''' <summary>
	''' Saves the previous zoom rectangle, pressing the backspace key jumps back to this zoom rectangle.
	''' </summary>
	Private prevZoomRect As Rect

	''' <summary>
	''' Save the previous content scale, pressing the backspace key jumps back to this scale.
	''' </summary>
	Private prevZoomScale As Double

	''' <summary>
	''' Set to 'true' when the previous zoom rect is saved.
	''' </summary>
	Private prevZoomRectSet As Boolean = False

	Public Sub New()
		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		For Each drive As DriveInfo In DriveInfo.GetDrives()
			If drive.IsReady Then
				Dim item As New TreeViewItem()
				item.Tag = drive
				item.Header = drive.ToString()
				item.Items.Add("*")
				TreeView1.Items.Add(item)
			End If
		Next

		LoadList()
	End Sub

	Private Sub LoadList()
		_fileList = GetFiles(_path)

		Dim queryGroupByExt = From file In _fileList _
		 Where file.Extension.ToLower() = ".jpg" Or file.Extension.ToLower() = ".png" Or file.Extension.ToLower() = ".bmp" Or file.Extension.ToLower() = ".gif" _
		 Or file.Extension.ToLower() = ".ico" Or file.Extension.ToLower() = ".tiff" _
		 Select file

		FileListView.ItemsSource = queryGroupByExt.ToList()
		If FileListView.Items.Count > 0 Then FileListView.SelectedIndex = 0
	End Sub

	Private Sub FolderOpenMenuItem_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
		SetPath()
	End Sub

	Private Sub SetPath()
		Dim dlg As Forms.FolderBrowserDialog = New Forms.FolderBrowserDialog()
		If dlg.ShowDialog() = Forms.DialogResult.OK Then
			_path = dlg.SelectedPath
			LoadList()
		End If
	End Sub

	Private Function GetFiles(ByVal root As String) As IEnumerable(Of System.IO.FileInfo)
		Return From file In _
		 My.Computer.FileSystem.GetFiles(root, FileIO.SearchOption.SearchTopLevelOnly, "*.*") _
		 Select New System.IO.FileInfo(file)
	End Function

	Private Sub ListView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs)
		For Each fInfo As FileInfo In e.AddedItems
			Dim bmpImage As New BitmapImage()
			bmpImage.BeginInit()
			bmpImage.UriSource = New Uri(fInfo.FullName)
			bmpImage.EndInit()
			TheImage.Source = bmpImage
			Me.Title = String.Format("Image Viewer - {0}", _path)
			TextBlock1.Text = fInfo.Name
		Next
	End Sub

	Private Sub TreeView1_Expanded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
		Dim item As TreeViewItem = CType(e.OriginalSource, TreeViewItem)
		If item.Items.Count = 1 AndAlso TypeOf item.Items(0) Is String AndAlso item.Items(0) = "*" Then
			item.Items.Clear()
			Dim dir As DirectoryInfo
			If TypeOf item.Tag Is DriveInfo Then
				Dim drive As DriveInfo = CType(item.Tag, DriveInfo)
				dir = drive.RootDirectory
			Else
				dir = CType(item.Tag, DirectoryInfo)
			End If
			Try
				For Each subDir As DirectoryInfo In dir.GetDirectories()
					If (subDir.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
					Else
						Dim newItem As New TreeViewItem()
						newItem.Tag = subDir
						newItem.Header = subDir.ToString()
						newItem.Items.Add("*")
						item.Items.Add(newItem)
					End If
				Next
			Catch
				' An exception could be thrown in this code if you don't
				' have sufficient security permissions for a file or directory.
				' You can catch and then ignore this exception.
			End Try
		End If
	End Sub

	Private Sub TreeView1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
		Dim item As TreeViewItem = CType(sender, TreeView).SelectedItem()
		If TypeOf item.Tag Is DirectoryInfo Then
			Dim finfo As DirectoryInfo = CType(item.Tag, DirectoryInfo)
			_path = finfo.FullName
			LoadList()
		ElseIf TypeOf item.Tag Is DriveInfo Then
			Dim dinfo As DriveInfo = CType(item.Tag, DriveInfo)
			_path = dinfo.Name
			LoadList()
		End If
	End Sub

	Private Sub btnPreviousImage_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
		If FileListView.SelectedIndex <> -1 Then
			If FileListView.SelectedIndex = 0 Then
				FileListView.SelectedIndex = FileListView.Items.Count - 1
			Else
				FileListView.SelectedIndex -= 1
			End If
			FileListView.ScrollIntoView(FileListView.SelectedItem)
		End If
	End Sub

	Private Sub btnNextImage_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
		If FileListView.SelectedIndex <> -1 Then
			If (FileListView.SelectedIndex + 1) = FileListView.Items.Count Then
				FileListView.SelectedIndex = 0
			Else
				FileListView.SelectedIndex += 1
			End If
			FileListView.ScrollIntoView(FileListView.SelectedItem)
		End If
	End Sub

	Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
		Dim helpTextWindow As HelpTextWindow = New HelpTextWindow()
		helpTextWindow.Left = Me.Left + Me.Width + 5
		helpTextWindow.Top = Me.Top
		helpTextWindow.Owner = Me
		helpTextWindow.Show()
	End Sub

	Private Sub Window_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs)
		Dim size As System.Drawing.Size = New System.Drawing.Size(Me.Width, Me.Height)
		My.Settings.MyImageViewerSize = size
		Dim location As System.Drawing.Point = New System.Drawing.Point(Me.Left, Me.Top)
		My.Settings.MyImageViewerLocation = location
		My.Settings.MyImageViewerWindowState = Me.WindowState

		My.Settings.MyColumnWidth1 = FileViewGrid.Columns(0).ActualWidth
		My.Settings.MyColumnWidth2 = FileViewGrid.Columns(1).ActualWidth
		My.Settings.MyColumnWidth3 = FileViewGrid.Columns(2).ActualWidth
		'		My.Settings.MyImageViewerSplitterDistance = GridSplitter1.ActualWidth

		My.Settings.Save()
		WinREG.MainForm.winImageViewer = Nothing
	End Sub

	''' <summary>
	''' The 'ZoomIn' command (bound to the plus key) was executed.
	''' </summary>
	Private Sub ZoomIn_Executed(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
		ZoomIn(New Point(zoomAndPanControl.ContentZoomFocusX, zoomAndPanControl.ContentZoomFocusY))
	End Sub

	''' <summary>
	''' The 'ZoomOut' command (bound to the minus key) was executed.
	''' </summary>
	Private Sub ZoomOut_Executed(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
		ZoomOut(New Point(zoomAndPanControl.ContentZoomFocusX, zoomAndPanControl.ContentZoomFocusY))
	End Sub

	''' <summary>
	''' The 'JumpBackToPrevZoom' command was executed.
	''' </summary>
	Private Sub JumpBackToPrevZoom_Executed(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
		JumpBackToPrevZoom()
	End Sub

	''' <summary>
	''' Determines whether the 'JumpBackToPrevZoom' command can be executed.
	''' </summary>
	Private Sub JumpBackToPrevZoom_CanExecuted(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
		e.CanExecute = prevZoomRectSet
	End Sub

	''' <summary>
	''' The 'Fill' command was executed.
	''' </summary>
	Private Sub Fill_Executed(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
		SavePrevZoomRect()

		zoomAndPanControl.AnimatedScaleToFit()
	End Sub

	''' <summary>
	''' The 'OneHundredPercent' command was executed.
	''' </summary>
	Private Sub OneHundredPercent_Executed(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
		SavePrevZoomRect()

		zoomAndPanControl.AnimatedZoomTo(1.0)
	End Sub

	''' <summary>
	''' Jump back to the previous zoom level.
	''' </summary>
	Private Sub JumpBackToPrevZoom()
		zoomAndPanControl.AnimatedZoomTo(prevZoomScale, prevZoomRect)

		ClearPrevZoomRect()
	End Sub

	''' <summary>
	''' Zoom the viewport out, centering on the specified point (in content coordinates).
	''' </summary>
	Private Sub ZoomOut(ByVal contentZoomCenter As Point)
		zoomAndPanControl.ZoomAboutPoint(zoomAndPanControl.ContentScale - 0.1, contentZoomCenter)
	End Sub

	''' <summary>
	''' Zoom the viewport in, centering on the specified point (in content coordinates).
	''' </summary>
	Private Sub ZoomIn(ByVal contentZoomCenter As Point)
		zoomAndPanControl.ZoomAboutPoint(zoomAndPanControl.ContentScale + 0.1, contentZoomCenter)
	End Sub

	'
	' Record the previous zoom level, so that we can jump back to it when the backspace key is pressed.
	'
	Private Sub SavePrevZoomRect()
		prevZoomRect = New Rect(zoomAndPanControl.ContentOffsetX, zoomAndPanControl.ContentOffsetY, zoomAndPanControl.ContentViewportWidth, zoomAndPanControl.ContentViewportHeight)
		prevZoomScale = zoomAndPanControl.ContentScale
		prevZoomRectSet = True
	End Sub

	''' <summary>
	''' Clear the memory of the previous zoom level.
	''' </summary>
	Private Sub ClearPrevZoomRect()
		prevZoomRectSet = False
	End Sub

	''' <summary>
	''' Event raised on mouse down in the ZoomAndPanControl.
	''' </summary>
	Private Sub zoomAndPanControl_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
		Content.Focus()
		Keyboard.Focus(Content)

		mouseButtonDown = e.ChangedButton
		origZoomAndPanControlMouseDownPoint = e.GetPosition(zoomAndPanControl)
		origContentMouseDownPoint = e.GetPosition(Content)

		If (Keyboard.Modifiers And ModifierKeys.Shift) <> 0 AndAlso (e.ChangedButton = MouseButton.Left OrElse e.ChangedButton = MouseButton.Right) Then
			' Shift + left- or right-down initiates zooming mode.
			mouseHandlingMode = mouseHandlingMode.Zooming
		ElseIf mouseButtonDown = MouseButton.Left Then
			' Just a plain old left-down initiates panning mode.
			mouseHandlingMode = mouseHandlingMode.Panning
		End If

		If mouseHandlingMode <> mouseHandlingMode.None Then
			' Capture the mouse so that we eventually receive the mouse up event.
			zoomAndPanControl.CaptureMouse()
			e.Handled = True
		End If
	End Sub

	''' <summary>
	''' Event raised on mouse up in the ZoomAndPanControl.
	''' </summary>
	Private Sub zoomAndPanControl_MouseUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
		If mouseHandlingMode <> mouseHandlingMode.None Then
			If mouseHandlingMode = mouseHandlingMode.Zooming Then
				If mouseButtonDown = MouseButton.Left Then
					' Shift + left-click zooms in on the content.
					ZoomIn(origContentMouseDownPoint)
				ElseIf mouseButtonDown = MouseButton.Right Then
					' Shift + left-click zooms out from the content.
					ZoomOut(origContentMouseDownPoint)
				End If
			ElseIf mouseHandlingMode = mouseHandlingMode.DragZooming Then
				' When drag-zooming has finished we zoom in on the rectangle that was highlighted by the user.
				ApplyDragZoomRect()
			End If

			zoomAndPanControl.ReleaseMouseCapture()
			mouseHandlingMode = mouseHandlingMode.None
			e.Handled = True
		End If
	End Sub

	''' <summary>
	''' Event raised on mouse move in the ZoomAndPanControl.
	''' </summary>
	Private Sub zoomAndPanControl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
		If mouseHandlingMode = mouseHandlingMode.Panning Then
			'
			' The user is left-dragging the mouse.
			' Pan the viewport by the appropriate amount.
			'
			Dim curContentMousePoint As Point = e.GetPosition(Content)
			Dim dragOffset As Vector = curContentMousePoint - origContentMouseDownPoint

			zoomAndPanControl.ContentOffsetX -= dragOffset.X
			zoomAndPanControl.ContentOffsetY -= dragOffset.Y

			e.Handled = True
		ElseIf mouseHandlingMode = mouseHandlingMode.Zooming Then
			Dim curZoomAndPanControlMousePoint As Point = e.GetPosition(zoomAndPanControl)
			Dim dragOffset As Vector = curZoomAndPanControlMousePoint - origZoomAndPanControlMouseDownPoint
			Dim dragThreshold As Double = 10
			If mouseButtonDown = MouseButton.Left AndAlso (Math.Abs(dragOffset.X) > dragThreshold OrElse Math.Abs(dragOffset.Y) > dragThreshold) Then
				'
				' When Shift + left-down zooming mode and the user drags beyond the drag threshold,
				' initiate drag zooming mode where the user can drag out a rectangle to select the area
				' to zoom in on.
				'
				mouseHandlingMode = mouseHandlingMode.DragZooming
				Dim curContentMousePoint As Point = e.GetPosition(Content)
				InitDragZoomRect(origContentMouseDownPoint, curContentMousePoint)
			End If

			e.Handled = True
		ElseIf mouseHandlingMode = mouseHandlingMode.DragZooming Then
			'
			' When in drag zooming mode continously update the position of the rectangle
			' that the user is dragging out.
			'
			Dim curContentMousePoint As Point = e.GetPosition(Content)
			SetDragZoomRect(origContentMouseDownPoint, curContentMousePoint)

			e.Handled = True
		End If
	End Sub

	''' <summary>
	''' Event raised by rotating the mouse wheel
	''' </summary>
	Private Sub zoomAndPanControl_MouseWheel(ByVal sender As Object, ByVal e As MouseWheelEventArgs)
		e.Handled = True

		If e.Delta > 0 Then
			Dim curContentMousePoint As Point = e.GetPosition(Content)
			ZoomIn(curContentMousePoint)
		ElseIf e.Delta < 0 Then
			Dim curContentMousePoint As Point = e.GetPosition(Content)
			ZoomOut(curContentMousePoint)
		End If
	End Sub


	''' <summary>
	''' Event raised when the user has double clicked in the zoom and pan control.
	''' </summary>
	Private Sub zoomAndPanControl_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
		If (Keyboard.Modifiers And ModifierKeys.Shift) = 0 Then
			Dim doubleClickPoint As Point = e.GetPosition(Content)
			zoomAndPanControl.AnimatedSnapTo(doubleClickPoint)
		End If
	End Sub


	''' <summary>
	''' Initialise the rectangle that the use is dragging out.
	''' </summary>
	Private Sub InitDragZoomRect(ByVal pt1 As Point, ByVal pt2 As Point)
		SetDragZoomRect(pt1, pt2)

		dragZoomCanvas.Visibility = Visibility.Visible
		dragZoomBorder.Opacity = 0.5
	End Sub

	''' <summary>
	''' Update the position and size of the rectangle that user is dragging out.
	''' </summary>
	Private Sub SetDragZoomRect(ByVal pt1 As Point, ByVal pt2 As Point)
		Dim x As Double, y As Double, width As Double, height As Double

		'
		' Deterine x,y,width and height of the rect inverting the points if necessary.
		' 

		If pt2.X < pt1.X Then
			x = pt2.X
			width = pt1.X - pt2.X
		Else
			x = pt1.X
			width = pt2.X - pt1.X
		End If

		If pt2.Y < pt1.Y Then
			y = pt2.Y
			height = pt1.Y - pt2.Y
		Else
			y = pt1.Y
			height = pt2.Y - pt1.Y
		End If

		'
		' Update the coordinates of the rectangle that is being dragged out by the user.
		' The we offset and rescale to convert from content coordinates.
		'
		Canvas.SetLeft(dragZoomBorder, x)
		Canvas.SetTop(dragZoomBorder, y)
		dragZoomBorder.Width = width
		dragZoomBorder.Height = height
	End Sub

	''' <summary>
	''' When the user has finished dragging out the rectangle the zoom operation is applied.
	''' </summary>
	Private Sub ApplyDragZoomRect()
		'
		' Record the previous zoom level, so that we can jump back to it when the backspace key is pressed.
		'
		SavePrevZoomRect()

		'
		' Retreive the rectangle that the user draggged out and zoom in on it.
		'
		Dim contentX As Double = Canvas.GetLeft(dragZoomBorder)
		Dim contentY As Double = Canvas.GetTop(dragZoomBorder)
		Dim contentWidth As Double = dragZoomBorder.Width
		Dim contentHeight As Double = dragZoomBorder.Height
		zoomAndPanControl.AnimatedZoomTo(New Rect(contentX, contentY, contentWidth, contentHeight))

		FadeOutDragZoomRect()
	End Sub

	'
	' Fade out the drag zoom rectangle.
	'
	Private Sub FadeOutDragZoomRect()
		AnimationHelper.StartAnimation(dragZoomBorder, Border.OpacityProperty, 0.0, 0.1, AddressOf eh)
	End Sub

	Private Sub eh(ByVal sender As Object, ByVal e As EventArgs)
		dragZoomCanvas.Visibility = Visibility.Collapsed
	End Sub

	Private Sub Rotate_Executed(ByVal sender As System.Object, ByVal e As System.Windows.Input.ExecutedRoutedEventArgs)

		'///////////////// Create a BitmapSource that Rotates the image //////////////////////
		' Use the BitmapImage created above as the source for a new BitmapSource object
		' that will be scaled to a different size. Create a new BitmapSource by   
		' scaling the original one.                                               
		' Note: New BitmapSource does not cache. It is always pulled when required.
		' Create the new BitmapSource that will be used to scale the size of the source.
		Dim myRotatedBitmapSource As New TransformedBitmap()
		myRotatedBitmapSource.BeginInit()
		myRotatedBitmapSource.Source = TheImage.Source
		myRotatedBitmapSource.Transform = New RotateTransform(90)
		myRotatedBitmapSource.EndInit()
		TheImage.Source = myRotatedBitmapSource

	End Sub

End Class

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
<ValueConversion(GetType(String), GetType(String))> _
 Public Class FlattenFileName
	Implements IValueConverter

	Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
		Dim components = CType(value, String).Split("."c)
		Dim str = String.Join("."c, components, 0, components.Length - 1)
		Return str
	End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
		Throw New NotSupportedException
	End Function
End Class

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
<ValueConversion(GetType(String), GetType(String))> _
Public Class TrimExtension
	Implements IValueConverter

	Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
		Return CType(value, String).TrimStart("."c)
	End Function

	Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
		Throw New NotSupportedException
	End Function
End Class