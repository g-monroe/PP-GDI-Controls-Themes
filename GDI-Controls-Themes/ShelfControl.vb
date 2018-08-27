Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class GridView
    Inherits Panel

    Property ItemWidth As Integer = 141
    Property ItemHeight As Integer = 201
    Property Row As Integer = 8
    Property Column As Integer = 1000
    Property Spacing As Integer = 20
    Property FRefresh As Boolean = True
    Event Clicked(URL As String)
    
    Sub New()
        Me.DoubleBuffered = True
    End Sub
 
    Dim pic As New Pict
    Private Sub GridView_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If FRefresh = True Then
            For i3 As Integer = 0 To Row
                For Each pic As Pict In Me.Controls.OfType(Of Pict)()
                    pic.Dispose()
                Next
            Next
            Dim NewLoc As New Point
            Dim i As Integer = 0
            For CurrCol As Integer = 0 To Column
                For CurrRow As Integer = 0 To Row
                    i += 1
                    For Each itm As Item In Items
                        If itm.OrderNumber = i Then
                            NewLoc.X = CurrRow * (ItemWidth + Spacing)
                            NewLoc.Y = CurrCol * (ItemHeight + Spacing)
                            itm.Locate = NewLoc
                            pic = New Pict
                            pic.ItemHeight = ItemHeight
                            pic.ItemWidth = ItemWidth
                            pic.Show_Name = itm.Text
                            pic.Name = itm.OrderNumber.ToString
                            pic.Location = NewLoc
                            pic.Parent = FindForm.Parent
                            pic.Size = New Size(ItemWidth, ItemHeight)
                            pic.SizeMode = PictureBoxSizeMode.StretchImage
                            AddHandler pic.MouseMove, AddressOf pic_MM
                            AddHandler pic.MouseM, AddressOf pic_MC
                            pic.LoadAsync(itm.URL_LINK)
                            Me.Controls.Add(pic)
                        End If
                    Next
                Next
            Next
            FRefresh = False
        End If
    End Sub

    Private Sub pic_MM(sender As Object, e As MouseEventArgs)
        If New Rectangle(ItemWidth / 2 - 30, ItemHeight / 2 - 30, 60, 60).Contains(e.X, e.Y) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
    End Sub
    Private Sub pic_MC(Mouselocation As Point, pic As String, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            For Each itm As Item In Items
                If pic = itm.OrderNumber Then
                    RaiseEvent Clicked(itm.ShowLink)
                End If
            Next
        End If
    End Sub
#Region "Item Collection"
    Public Class ItemCollection
        Inherits List(Of Item)
        Public Parent As GridView
        Public Sub New(Parent As GridView)
            Me.Parent = Parent
        End Sub
        Public Shadows Sub Add(Item As Item)
            MyBase.Add(Item)
            ' Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub AddRange(Range As List(Of Item))
            MyBase.AddRange(Range)
            ' Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
            ' Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Remove(Item As Item)
            MyBase.Remove(Item)
            ' Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
            'Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of Item))
            MyBase.RemoveAll(Predicate)
            '  Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
            '  Parent.InvalidateScroll()
        End Sub

    End Class
    Public Class Item
        Property Text As String
        Property OrderNumber As Integer
        Property MouseEntered As Boolean = False
        Public Type As String = "None"
        Property PictureLink As Boolean = False
        Property URL_LINK As String = "http://i.imgur.com/blkrqBo.gif"
        Property ShowLink As String = "None"
        Property Locate As Point = New Point(0, 0)
        Protected UniqueId As Guid
        Sub New()
            UniqueId = Guid.NewGuid()
        End Sub
        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is Item Then
                Return (DirectCast(obj, Item).UniqueId = UniqueId)
            End If
            Return False
        End Function

    End Class
    Public _Items As New ItemCollection(Me)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Items As ItemCollection
        Get
            Return _Items
        End Get
        Set(ByVal value As ItemCollection)
            _Items = value
        End Set
    End Property
#End Region
#Region "Custom Picturebox"
    Public Class Pict
        Inherits PictureBox
        Property MouseLoc As Point
        Property ItemWidth As Integer = 151
        Property Show_Name As String
        Property inner = False
        Property ItemHeight As Integer = 201
        Event MouseM(Mouselocation As Point, pic As String, e As MouseEventArgs)

        Private Sub Pict_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
            If e.Button = Windows.Forms.MouseButtons.Left Then

                If New Rectangle(ItemWidth / 2 - 30, ItemHeight / 2 - 30, 60, 60).Contains(e.X, e.Y) Then
                    RaiseEvent MouseM(MouseLoc, Me.Name, e)
                End If
            End If
        End Sub

        Private Sub Pict_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
            inner = True
            Me.Refresh()
        End Sub

        Private Sub Pict_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
            inner = False
            Me.Refresh()
        End Sub
        Private Sub Pict_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            MouseLoc = e.Location
        End Sub

        Private Sub Pict_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(0, 0, ItemWidth - 2, ItemHeight - 2))
            If inner = True Then
                e.Graphics.DrawEllipse(Pens.Black, New Rectangle(ItemWidth / 2 - 30, ItemHeight / 2 - 30, 60, 60))
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(150, Color.Black)), New Rectangle(ItemWidth / 2 - 30, ItemHeight / 2 - 30, 60, 60))
                e.Graphics.DrawString("4", New Font("Webdings", 46, FontStyle.Regular), Brushes.White, New Rectangle(ItemWidth / 2 - 26, ItemHeight / 2 - 27, 60, 60), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(120, 0, 0, 0)), New Rectangle(0, ItemHeight - 50, ItemWidth, 50))
                e.Graphics.DrawString(Show_Name, New Font("Arial", 11, FontStyle.Regular), Brushes.White, New Rectangle(0, ItemHeight - 50, ItemWidth, 50), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End If
        End Sub
    End Class
#End Region
End Class