

' Bindable list view.
' 2003 - Ian Griffiths (ian@interact-sw.co.uk)
'
' This code is in the public domain, and has no warranty.


Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

''' <summary>
''' A ListView with complex data binding support.
''' </summary>
''' <remarks>
''' <p>Windows Forms provides a built-in <see cref="ListView"/> control,
''' which is essentially a wrapper of the standard Win32 list view. While
''' this is a very powerful control, it does not support complex data
''' binding. It supports simple binding, as all controls do, but simple
''' binding only binds a single row of data. The absence of complex
''' binding (i.e. the ability to bind to whole lists of data) is
''' disappointing in a class whose main purpose is to display lists of
''' things.</p>
'''
''' <p>This class derives from <see cref="ListView"/> and adds support
''' for complex binding, through its <see cref="DataSource"/> and
''' <see cref="DataMember"/> properties. These behave much like the
''' equivalent properties on the =<see cref="DataGrid"/> control.</p>
'''
''' <p>Note that the primary purpose of this control is to illustrate
''' data binding implementation techniques. It is NOT designed as an
''' industrial-strength control for use in production code. If you use
''' this in live systems, you do so at your own risk; it would almost
''' certainly be a better idea to look at the various professional
''' bindable grid controls on the market.</p>
''' </remarks>
Public Class BindableListView
	Inherits System.Windows.Forms.ListView
	''' <summary>
	''' The data source to which this control is bound.
	''' </summary>
	''' <remarks>
	''' <p>To make this control display the contents of a data source, you
	''' should set this property to refer to that data source. The source
	''' should implement either <see cref="IList"/>,
	''' <see cref="IBindingList"/>, or <see cref="IListSource"/>.</p>
	'''
	''' <p>When binding to a list container (i.e. one that implements the
	''' <see cref="IListSource"/> interface, such as <see cref="DataSet"/>)
	''' you must also set the <see cref="DataMember"/> property in order
	''' to identify which particular list you would like to display. You
	''' may also set the <see cref="DataMember"/> property even when
	''' DataSource refers to a list, since <see cref="DataMember"/> can
	''' also be used to navigate relations between lists.</p>
	''' </remarks>
	<Category("Data")> _
	<TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")> _
	Public Property DataSource() As Object
		Get
			Return m_dataSource
		End Get
		Set(ByVal value As Object)
			If m_dataSource IsNot value Then
				' Must be either a list or a list source
				If value IsNot Nothing AndAlso Not (TypeOf value Is IList) AndAlso Not (TypeOf value Is IListSource) Then
					Throw New ArgumentException("Data source must be IList or IListSource")
				End If
				m_dataSource = value
				SetDataBinding()
				OnDataSourceChanged(EventArgs.Empty)
			End If
		End Set
	End Property
	Private m_dataSource As Object

	''' <summary>
	''' Raised when the DataSource property changes.
	''' </summary>
	Public Event DataSourceChanged As EventHandler

	''' <summary>
	''' Called when the DataSource property changes
	''' </summary>
	''' <param name="e">The EventArgs that will be passed to any handlers
	''' of the DataSourceChanged event.</param>
	Protected Overridable Sub OnDataSourceChanged(ByVal e As EventArgs)
		RaiseEvent DataSourceChanged(Me, e)
	End Sub

	''' <summary>
	''' Identifies the item or relation within the data source whose
	''' contents should be shown.
	''' </summary>
	''' <remarks>
	''' <p>If the <see cref="DataSource"/> refers to a container of lists
	''' such as a <see cref="DataSet"/>, this property should be used to
	''' indicate which list should be shown.</p>
	''' 
	''' <p>Even when <see cref="DataSource"/> refers to a specific list,
	''' you can still set this property to indicate that a related table
	''' should be shown by specifying a relation name. This will cause
	''' this control to display only those rows in the child table related
	''' to the currently selected row in the parent table.</p>
	''' </remarks>
	<Category("Data")> _
	<Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", GetType(System.Drawing.Design.UITypeEditor))> _
	Public Property DataMember() As String
		Get
			Return m_DataMember
		End Get
		Set(ByVal value As String)
			If m_DataMember <> value Then
				m_DataMember = value
				SetDataBinding()
				OnDataMemberChanged(EventArgs.Empty)
			End If
		End Set
	End Property
	Private m_DataMember As String

	''' <summary>
	''' Raised when the DataMember property changes.
	'''</summary>
	Public Event DataMemberChanged As EventHandler

	''' <summary>
	''' Called when the DataMember property changes.
	''' </summary>
	''' <param name="e">The EventArgs that will be passed to any handlers
	''' of the DataMemberChanged event.</param>
	Protected Overridable Sub OnDataMemberChanged(ByVal e As EventArgs)
		RaiseEvent DataMemberChanged(Me, e)
	End Sub

	''' <summary>
	''' Handles binding context changes
	''' </summary>
	''' <param name="e">The EventArgs that will be passed to any handlers
	''' of the BindingContextChanged event.</param>
	Protected Overrides Sub OnBindingContextChanged(ByVal e As EventArgs)
		MyBase.OnBindingContextChanged(e)

		' If our binding context changes, we must rebind, since we will
		' have a new currency managers, even if we are still bound to the
		' same data source.
		SetDataBinding()
	End Sub


	''' <summary>
	''' Handles parent binding context changes
	''' </summary>
	''' <param name="e">Unused EventArgs.</param>
	Protected Overrides Sub OnParentBindingContextChanged(ByVal e As EventArgs)
		MyBase.OnParentBindingContextChanged(e)

		' BindingContext is an ambient property - by default it simply picks
		' up the parent control's context (unless something has explicitly
		' given us our own). So we must respond to changes in our parent's
		' binding context in the same way we would changes to our own
		' binding context.
		SetDataBinding()
	End Sub


	' Attaches the control to a data source.
	Private Sub SetDataBinding()
		' The BindingContext is initially null - in general we will not
		' obtain a BindingContext until we are attached to our parent
		' control. (OnParentBindingContextChanged will be called when
		' that happens, so this method will run again. This means it's
		' OK to ignore this call when we don't yet have a BindingContext.)
		If BindingContext IsNot Nothing Then

			' Obtain the CurrencyManager and (if available) IBindingList
			' for the current data source.
			Dim currencyManager As CurrencyManager = Nothing
			Dim bindingList As IBindingList = Nothing

			If DataSource IsNot Nothing Then
				currencyManager = DirectCast(BindingContext(DataSource, DataMember), CurrencyManager)
				If currencyManager IsNot Nothing Then
					bindingList = TryCast(currencyManager.List, IBindingList)
				End If
			End If

			' Now see if anything has changed since we last bound to a source.

			Dim reloadMetaData As Boolean = False
			Dim reloadItems As Boolean = False
			If currencyManager IsNot m_currencyManager Then
				' We have a new CurrencyManager. If we were previously
				' using another CurrencyManager (i.e. if this is not the
				' first time we've seen one), we'll have some event
				' handlers attached to the old one, so first we must
				' detach those.
				If m_currencyManager IsNot Nothing Then
					RemoveHandler currencyManager.MetaDataChanged, AddressOf currencyManager_MetaDataChanged
					RemoveHandler currencyManager.PositionChanged, AddressOf currencyManager_PositionChanged
					RemoveHandler currencyManager.ItemChanged, AddressOf currencyManager_ItemChanged
				End If

				' Now hook up event handlers to the new CurrencyManager.
				' This enables us to detect when the currently selected
				' row changes. It also lets us find out more major changes
				' such as binding to a different list object (this happens
				' when binding to related views - each time the currently
				' selected row in a parent changes, the child list object
				' is replaced with a new object), or even changes in the
				' set of properties.
				m_currencyManager = currencyManager
				If currencyManager IsNot Nothing Then
					reloadMetaData = True
					reloadItems = True
					AddHandler currencyManager.MetaDataChanged, AddressOf currencyManager_MetaDataChanged
					AddHandler currencyManager.PositionChanged, AddressOf currencyManager_PositionChanged
					AddHandler currencyManager.ItemChanged, AddressOf currencyManager_ItemChanged
				End If
			End If

			If bindingList IsNot m_bindingList Then
				' The IBindingList has changed. If we were previously
				' bound to an IBindingList, detach the event handler.
				If m_bindingList IsNot Nothing Then
					RemoveHandler m_bindingList.ListChanged, AddressOf bindingList_ListChanged
				End If

				' Now hook up a handler to the new IBindingList - this
				' will notify us of any changes in the list. (This is
				' more detailed than the CurrencyManager ItemChanged
				' event. However, we need both, because the only way we
				' know when the list is replaced completely is when the
				' CurrencyManager raises the ItemChanged event.)
				m_bindingList = bindingList
				If bindingList IsNot Nothing Then
					reloadItems = True
					AddHandler m_bindingList.ListChanged, AddressOf bindingList_ListChanged
				End If
			End If

			' If a change occurred that means the set of properties may
			' have changed, reload these.
			If reloadMetaData Then
				LoadColumnsFromSource()
			End If

			' If a change occurred that means the set of items to be
			' shown in the list may have changed, reload those.
			If reloadItems Then
				LoadItemsFromSource()
			End If
		End If

	End Sub
	Private m_currencyManager As CurrencyManager
	Private m_bindingList As IBindingList
	Private m_properties As PropertyDescriptorCollection


	' Reload the properties, and build column headers for them.

	Private Sub LoadColumnsFromSource()
		' Retrieve and store the PropertyDescriptors. (We always go
		' via PropertyDescriptors when binding, and not the Reflection
		' API - this allows generic data sources to decide at runtime
		' what properties to present.) For data sources that don't opt
		' to have dynamic properties, the PropertyDescriptor mechanism
		' automatically falls back to Reflection under the covers.

		m_properties = m_currencyManager.GetItemProperties()


		' Build new column headers for the ListView.

		Dim headers As ColumnHeader() = New ColumnHeader(m_properties.Count - 1) {}
		Columns.Clear()
		For column As Integer = 0 To m_properties.Count - 1
			Dim columnName As String = m_properties(column).Name

			' We set the width to be -2 in order to auto-size the column
			' to the header text. Bizarrely, this only works if we set
			' the width after adding the column. (That's we we're not
			' simply passing -2 to Add. The value passed - 0 in this case
			' - is irrelevant here.)
			Columns.Add(columnName, 0, HorizontalAlignment.Left)
			Columns(column).Name = columnName
			Columns(column).Width = -2
		Next
		' For some reason we seem to need to go back and set the
		' first column's Width to -2 (auto width) a second time.
		' It doesn't stick first time.
		'		Columns(0).Width = -2
	End Sub


	' Reload list items from the data source.

	Private Sub LoadItemsFromSource()
		' Tell the control not to bother redrawing until we're done
		' adding new items - avoids flicker and speeds things up.
		BeginUpdate()

		Try
			' We're about to rebuild the list, so get rid of the current
			' items.
			Items.Clear()

			' m_bindingList won't be set if the data source doesn't
			' implement IBindingList, so always ask the CurrencyManager
			' for the IList. (IList is all we need to retrieve the rows.)

			Dim items__1 As IList = m_currencyManager.List

			' Add items to list.
			Dim nItems As Integer = items__1.Count
			For i As Integer = 0 To nItems - 1
				Items.Add(BuildItemForRow(items__1(i)))
			Next
			Dim index As Integer = m_currencyManager.Position
			If index <> -1 Then
				SetSelectedIndex(index)
			End If
		Finally
			' In finally block just in case the data source does something
			' nasty to us - it feels like it might be bad to leave the
			' control in a state where we called BeginUpdate without a
			' corresponding EndUpdate.
			EndUpdate()
		End Try
	End Sub

	' Build a single ListViewItem for a single row from the source. (We
	' need to do this when constructing the original list, but this is
	' also called in the IBindingList.ListChanged event handler when
	' updating individual items.)

	Private Function BuildItemForRow(ByVal row As Object) As ListViewItem
		Dim itemText As String() = New String(m_properties.Count - 1) {}
		For column As Integer = 0 To itemText.Length - 1
			' Use the PropertyDescriptors to extract the property value -
			' this might be a virtual property.

			itemText(column) = m_properties(column).GetValue(row).ToString()
		Next
		Return New ListViewItem(itemText)
	End Function

	Public Event ItemAdded(ByVal sender As Object, ByVal index As Integer, ByVal newrow As DataRowView)

	' IBindingList ListChanged event handler. Deals with fine-grained
	' changes to list items.

	Private Sub bindingList_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
		Select Case e.ListChangedType
			' Well, usually fine-grained... The whole list has changed
			' utterly, so reload it.

			Case ListChangedType.Reset
				LoadItemsFromSource()
				Exit Select


				' A single item has changed, so just rebuild that.

			Case ListChangedType.ItemChanged
				Dim changedRow As Object = m_currencyManager.List(e.NewIndex)
				BeginUpdate()
				Items(e.NewIndex) = BuildItemForRow(changedRow)
				EndUpdate()
				Exit Select


				' A new item has appeared, so add that.

			Case ListChangedType.ItemAdded
				Dim newRow As Object = m_currencyManager.List(e.NewIndex)
				' We get this event twice if certain grid controls
				' are used to add a new row to a datatable: once when
				' the editing of a new row begins, and once again when
				' that editing commits. (If the user cancels the creation
				' of the new row, we never see the second creation.)
				' We detect this by seeing if this is a view on a
				' row in a DataTable, and if it is, testing to see if
				' it's a new row under creation.
				Dim drv As DataRowView = TryCast(newRow, DataRowView)
				If drv Is Nothing OrElse Not drv.IsNew Then
					' Either we're not dealing with a view on a data
					' table, or this is the commit notification. Either
					' way, this is the final notification, so we want
					' to add the new row now!
					BeginUpdate()
					If e.NewIndex <= Items.Count Then
						Items(e.NewIndex) = BuildItemForRow(newRow)
					Else
						Items.Insert(e.NewIndex, BuildItemForRow(newRow))
					End If
					EndUpdate()
				End If
				RaiseEvent ItemAdded(Me, e.NewIndex, drv)
				Exit Select


				' An item has gone away.

			Case ListChangedType.ItemDeleted
				'				If e.NewIndex < Items.Count Then
				'					Items.RemoveAt(e.NewIndex)
				'				End If
				Exit Select


				' An item has changed its index.

			Case ListChangedType.ItemMoved
				BeginUpdate()
				Dim moving As ListViewItem = Items(e.OldIndex)
				Items.Insert(e.NewIndex, moving)
				EndUpdate()
				Exit Select


				' Something has changed in the metadata. (This control is
				' too lazy to deal with this in a fine-grained fashion,
				' mostly because the author has never seen this event
				' occur... So we deal with it the simple way: reload
				' everything.)

			Case ListChangedType.PropertyDescriptorAdded, ListChangedType.PropertyDescriptorChanged, ListChangedType.PropertyDescriptorDeleted
				LoadColumnsFromSource()
				LoadItemsFromSource()
				Exit Select
		End Select
	End Sub


	' The CurrencyManager calls this if the data source looks
	' different. We just reload everything.

	Private Sub currencyManager_MetaDataChanged(ByVal sender As Object, ByVal e As EventArgs)
		LoadColumnsFromSource()
		LoadItemsFromSource()
	End Sub


	' Called by the CurrencyManager when the currently selected item
	' changes. We update the ListView selection so that we stay in sync
	' with any other controls bound to the same source.

	Private Sub currencyManager_PositionChanged(ByVal sender As Object, ByVal e As EventArgs)
		SetSelectedIndex(m_currencyManager.Position)
	End Sub


	' Change the currently-selected item. (I'm sure I'm missing a simpler
	' way of doing this... If anyone knows what it is, please let me
	' know!)

	Private Sub SetSelectedIndex(ByVal index As Integer)
		' Avoid recursion - we keep track of when we're already in the
		' middle of changing the index, in case the CurrencyManager
		' decides to call us back as a result of a change already in
		' progress. (Not sure if this will ever actually happen - the
		' OnSelectedIndexChanged method uses the m_changingIndex flag to
		' avoid modifying the CurrencyManager's Position when the change
		' in selection was caused by the CurrencyManager in the first
		' place. But it doesn't hurt to be defensive...)
		If index.ToString = 0 Then
			If Not m_changingIndex Then
				m_changingIndex = True
				SelectedItems.Clear()
				If Items.Count > index Then
					Dim item As ListViewItem = Items(index)
					item.Selected = True
					item.EnsureVisible()
				End If
				m_changingIndex = False
			End If
		End If
	End Sub
	Private m_changingIndex As Boolean


	' Called by Windows Forms when the currently selected index of the
	' control changes. This usually happens because the user clicked on
	' the control. In this case we want to notify the CurrencyManager so
	' that any other bound controls will remain in sync. This method will
	' also be called when we changed our index as a result of a
	' notification that originated from the CurrencyManager, and in that
	' case we avoid notifying the CurrencyManager back!

	Protected Overrides Sub OnSelectedIndexChanged(ByVal e As EventArgs)
		MyBase.OnSelectedIndexChanged(e)

		' Did this originate from us, or was this caused by the
		' CurrencyManager in the first place. If we're sure it was us,
		' and there is actually a selected item (this event is also raised
		' when transitioning to the 'no items selected' state), and we
		' definitely do have a CurrencyManager (i.e. we are actually bound
		' to a data source), then we notify the CurrencyManager.

		If Not m_changingIndex AndAlso SelectedIndices.Count > 0 AndAlso m_currencyManager IsNot Nothing Then
			m_currencyManager.Position = SelectedIndices(0)
		End If
	End Sub

	' Called by the CurrencyManager when stuff changes. (Yes I know
	' that's vague, but then so is the official documentation.)
	' At time of writing, the official docs imply that you don't need
	' to handle this event if your source implements IBindingList, since
	' IBindingList.ListChanged provides more details information about the
	' change. However, it's not quite as simple as that: when bound to a
	' related view, the list to which we are bound changes every time the
	' selected index of the parent changes, and to see that happen we
	' either have handle this event, or the CurrentChanged (also from the
	' CurrencyManager). So in practice you need to handle both.
	' It doesn't appear to matter whether you handle CurrentChanged or
	' ItemChanged in order to detect such changes - both are raised when
	' the underlying list changes. However, Mark Boulter sent me some
	' example code (thanks Mark!) that used this one, and he probably
	' knows something I don't about which is likely to work better...
	' So I'm doing what his code does and using this event.
	Private Sub currencyManager_ItemChanged(ByVal sender As Object, ByVal e As ItemChangedEventArgs)
		' An index of -1 seems to be the indication that lots has
		' changed. (I've not found where it says this in the
		' documentation - I got this information from a comment in Mark
		' Boulter's code.) So we always reload all items from the
		' source when this happens.
		If e.Index = -1 Then
			' ...but before we reload all items from source, we also look
			' to see if the list we're supposed to bind to has changed
			' since last time, and if it has, reattach our event handlers.

			If Not Object.ReferenceEquals(m_bindingList, m_currencyManager.List) Then
				RemoveHandler m_bindingList.ListChanged, AddressOf bindingList_ListChanged
				'				m_bindingList.ListChanged -= New ListChangedEventHandler(AddressOf bindingList_ListChanged)
				m_bindingList = TryCast(m_currencyManager.List, IBindingList)
				If m_bindingList IsNot Nothing Then
					AddHandler m_bindingList.ListChanged, AddressOf bindingList_ListChanged
					'					m_bindingList.ListChanged += New ListChangedEventHandler(AddressOf bindingList_ListChanged)
				End If
			End If
			LoadItemsFromSource()
		End If
	End Sub
End Class
