Imports System.IO

Class Window1

	Private _imgList As DirectoryImageList
	Private _path As String = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)

	Public Sub New()
		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		ResetList()
	End Sub

	Private Sub ResetList()
		_imgList = New DirectoryImageList(_path)
		Me.ListBox1.DataContext = _imgList.Images
	End Sub

	Private Sub FolderOpenMenuItem_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
		SetPath()
	End Sub

	Private Sub SetPath()
		Dim dlg As Forms.FolderBrowserDialog = New Forms.FolderBrowserDialog()
		dlg.ShowDialog()
		_path = dlg.SelectedPath
		ResetList()
	End Sub

	Public Class DirectoryImageList

		Public Sub New(ByVal path As String)
			_path = path
			_images = New List(Of BitmapSource)
			LoadImages()
		End Sub

		Private _images As List(Of BitmapSource)
		Public Property Images() As List(Of BitmapSource)
			Get
				Return _images
			End Get
			Set(ByVal value As List(Of BitmapSource))
				_images = value
			End Set
		End Property

		Private _path As String
		Public Property Path() As String
			Get
				Return _path
			End Get
			Set(ByVal value As String)
				_path = value
			End Set
		End Property

		Private Sub LoadImages()
			_images.Clear()
			Dim img As BitmapImage

			For Each file As String In Directory.GetFiles(_path)
				Try
					img = New BitmapImage(New Uri(file))
					_images.Add(img)

				Catch ex As Exception

				End Try
			Next
		End Sub

	End Class

	Private Sub ListBox1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs)
		Image1.Source = CType(CType(sender, ListBox).SelectedItem, BitmapSource)
	End Sub

End Class
