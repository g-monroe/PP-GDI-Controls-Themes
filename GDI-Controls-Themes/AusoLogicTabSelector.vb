'Random Controls: Ausologic Tabselector
'By Nettro ;P please enjoy
'Tip: reminder to change the index of each item
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class TabSelector
    Inherits Panel
    Property Selected As Selectt
    Event ClickedParent()
    Event ClickedStudent()
    Event ClickedTeacher()
    Dim InnerTeacher As Boolean = False
    Dim InnerStudent As Boolean = False
    Dim InnerParent As Boolean = False
    Enum Selectt
        Student
        Teacher
        parent
    End Enum
    Property SelectedItem As Integer = 0
    Sub New()
        Me.DoubleBuffered = True
    End Sub

    Private Sub Tabcon_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Dim locc As New Point
        If e.Button = Windows.Forms.MouseButtons.Left Then
            For Each itm As Item In _Items
                If itm.Index < 1 Then
                    locc.X = 12
                    locc.Y = 4
                    If New Rectangle(locc.X, locc.Y, 32, 32).Contains(e.X, e.Y) Then
                        SelectedItem = itm.Index
                        Me.Refresh()
                    End If
                Else
                    locc.X = 64 * itm.Index
                    locc.Y = 4
                    If New Rectangle(locc.X, locc.Y, 32, 32).Contains(e.X, e.Y) Then
                        SelectedItem = itm.Index
                        Me.Refresh()
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub Tabcon_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Dim locc As New Point
        For Each itm As Item In _Items
            itm.Inner = False
            If itm.Index < 1 Then
                locc.X = 12
                locc.Y = 4
                If New Rectangle(locc.X, locc.Y, 32, 32).Contains(e.X, e.Y) Then
                    Cursor = Cursors.Hand
                    itm.Inner = True
                    Me.Refresh()
                End If
            Else
                locc.X = 64 * itm.Index
                locc.Y = 4
                If New Rectangle(locc.X, locc.Y, 32, 32).Contains(e.X, e.Y) Or New Rectangle(12, 4, 32, 32).Contains(e.X, e.Y) Then
                    Cursor = Cursors.Hand
                    itm.Inner = True
                    Me.Refresh()
                Else
                    Cursor = Cursors.Arrow
                    Me.Refresh()
                End If
                If New Rectangle(locc.X, locc.Y, 32, 32).Contains(e.X, e.Y) Then
                    itm.Inner = True
                End If
            End If
        Next

    End Sub

    Private Sub Tabcon_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(0, 140, 178)), New Rectangle(0, 0, Me.Width, Me.Height))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(0, 171, 206)), New Rectangle(2, 0, Me.Width - 4, Me.Height - 3))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(0, 140, 178)), New Rectangle(3, 0, Me.Width - 6, Me.Height - 4))
        For Each itm As Item In _Items
            Dim locc As New Point
            If itm.Index < 1 Then
                locc.X = 12
                locc.Y = 4
                itm.locx = locc.X
                itm.locy = locc.Y
                e.Graphics.DrawImage(itm.Image, New Rectangle(locc.X, locc.Y, 32, 32))
                If itm.usepic = False Then
                    e.Graphics.DrawImage(itm.Image, New Rectangle(locc.X, locc.Y, 32, 32))
                Else
                    Dim pic As New PictureBox
                    If itm.refresh = False Then
                        'pic.BackColor = Color.FromArgb(0, 140, 178)
                        'pic.Size = New Size(32, 32)
                        'pic.Location = locc
                        'pic.LoadAsync(itm.URL)
                        'pic.Name = "pic_" & itm.Index
                        'pic.SizeMode = PictureBoxSizeMode.StretchImage
                        'pic.InitialImage = My.Resources.loading
                        'AddHandler pic.Paint, AddressOf pic_draw
                        'Me.Controls.Add(pic)
                        'Dim MyWebClient As New System.Net.WebClient
                        'Dim ImageInBytes() As Byte = MyWebClient.DownloadData(itm.URL)
                        'Dim ImageStream As New IO.MemoryStream(ImageInBytes)
                        'e.Graphics.DrawImage(New System.Drawing.Bitmap(ImageStream), New Rectangle(12, 4, 32, 32))
                    Else
                        For Each pic2 As PictureBox In Me.Controls.OfType(Of PictureBox)()
                            If pic2.Location = locc Then
                                pic2.Dispose()
                            End If
                        Next
                        pic.BackColor = Color.FromArgb(0, 140, 178)
                        pic.Size = New Size(32, 32)
                        pic.Location = locc
                        pic.LoadAsync(itm.URL)
                        pic.Name = "pic_" & itm.Index
                        pic.SizeMode = PictureBoxSizeMode.StretchImage
                        AddHandler pic.Paint, AddressOf pic_draw
                        Me.Controls.Add(pic)
                        itm.refresh = False
                        'Dim MyWebClient As New System.Net.WebClient
                        'Dim ImageInBytes() As Byte = MyWebClient.DownloadData(itm.URL)
                        'Dim ImageStream As New IO.MemoryStream(ImageInBytes)
                        'e.Graphics.DrawImage(New System.Drawing.Bitmap(ImageStream), New Rectangle(12, 4, 32, 32))
                    End If
                End If
                If SelectedItem = itm.Index Then
                    Dim ptsArray2 As PointF() = {New Point(6, 0), New Point(46, 0), New Point(26, 12), New Point(6, 0)}
                    e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(0, 92, 113)), ptsArray2)
                    Dim ptsArray As PointF() = {New Point(6, -1), New Point(46, -1), New Point(26, 12), New Point(6, -1)}
                    e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(240, 240, 240)), ptsArray)
                End If
                If itm.Inner = True Then
                    e.Graphics.DrawString(itm.Text, New Font("Arial", 8, FontStyle.Regular), Brushes.White, New Rectangle(locc.X - 6, locc.Y + 28, 48, 12), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                End If
            Else
                locc.X = 64 * itm.Index
                locc.Y = 4
                itm.locx = locc.X
                itm.locy = locc.Y
                If itm.usepic = False Then
                    e.Graphics.DrawImage(itm.Image, New Rectangle(locc.X, locc.Y, 32, 32))
                Else
                    Dim pic As New PictureBox
                    If itm.refresh = False Then
                        'pic.BackColor = Color.FromArgb(0, 140, 178)
                        'pic.Size = New Size(32, 32)
                        'pic.Location = locc
                        'pic.LoadAsync(itm.URL)
                        'pic.Name = "pic_" & itm.Index
                        'pic.SizeMode = PictureBoxSizeMode.StretchImage
                        'pic.InitialImage = My.Resources.loading
                        'AddHandler pic.Paint, AddressOf pic_draw
                        'Me.Controls.Add(pic)
                        'Dim MyWebClient As New System.Net.WebClient
                        'Dim ImageInBytes() As Byte = MyWebClient.DownloadData(itm.URL)
                        'Dim ImageStream As New IO.MemoryStream(ImageInBytes)
                        'e.Graphics.DrawImage(New System.Drawing.Bitmap(ImageStream), New Rectangle(locc.X, locc.Y, 32, 32))
                    Else
                        For Each pic2 As PictureBox In Me.Controls.OfType(Of PictureBox)()
                            If pic2.Location = locc Then
                                pic2.Dispose()
                            End If
                        Next
                        pic.BackColor = Color.FromArgb(0, 140, 178)
                        pic.Size = New Size(32, 32)
                        pic.Location = locc
                        pic.LoadAsync(itm.URL)
                        pic.Name = "pic_" & itm.Index
                        pic.SizeMode = PictureBoxSizeMode.StretchImage
                        AddHandler pic.Paint, AddressOf pic_draw
                        Me.Controls.Add(pic)
                        'Dim MyWebClient As New System.Net.WebClient
                        'Dim ImageInBytes() As Byte = MyWebClient.DownloadData(itm.URL)
                        'Dim ImageStream As New IO.MemoryStream(ImageInBytes)
                        'e.Graphics.DrawImage(New System.Drawing.Bitmap(ImageStream), New Rectangle(locc.X, locc.Y, 32, 32))
                        'itm.refresh = False
                    End If
                End If
                If SelectedItem = itm.Index Then
                    Dim ptsArray2 As PointF() = {New Point(locc.X - 6, 0), New Point(locc.X + 38, 0), New Point(locc.X + 16, 12), New Point(locc.X - 6, 0)}
                    e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(0, 92, 113)), ptsArray2)
                    Dim ptsArray As PointF() = {New Point(locc.X - 6, -1), New Point(locc.X + 38, -1), New Point(locc.X + 16, 12), New Point(locc.X - 6, -1)}
                    e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(240, 240, 240)), ptsArray)
                End If
                If itm.Inner = True Then
                    e.Graphics.DrawString(itm.Text, New Font("Arial", 8, FontStyle.Regular), Brushes.White, New Rectangle(locc.X - 12, locc.Y + 28, locc.X, 12), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                End If
            End If

        Next
    End Sub

#Region "Itemss"
    Public Class ItemCollection
        Inherits List(Of Item)
        Private Parent As TabSelector
        Public Sub New(Parent As TabSelector)
            Me.Parent = Parent

        End Sub
        Public Shadows Sub Add(Item As Item)
            MyBase.Add(Item)
            'Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub AddRange(Range As List(Of Item))
            MyBase.AddRange(Range)
            'Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
            'Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Remove(Item As Item)
            MyBase.Remove(Item)
            'Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
            'Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of Item))
            MyBase.RemoveAll(Predicate)
            'Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
            'Parent.InvalidateScroll()
        End Sub

    End Class
    Public Class Item
        Property Text As String
        Property Index As Integer = 0
        Property locy As Integer = 0
        Property locx As Integer = 0
        Property Image As Image
        Property Inner As Boolean = False
        Property refresh As Boolean = True
        Property usepic As Boolean = False
        Property URL As String = ""
        Property Selected As Boolean = False
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

    Private Sub pic_draw(sender As Object, e As PaintEventArgs)
        'For Each pic As PictureBox In Me.Controls.OfType(Of PictureBox)()
        '    Dim temp As String = pic.Name.Split("_").Last
        '    FindForm.Text = temp
        '    If temp = SelectedItem Then
        '        AddHandler pic.Paint, AddressOf draw1
        '        pic.Refresh()
        '    End If
        'Next
    End Sub

    Private Sub draw1(sender As Object, e As PaintEventArgs)
        'e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        'Dim ptsArray2 As PointF() = {New Point(1, 0), New Point(31, 0), New Point(16, 12), New Point(1, 0)}
        '            e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(0, 92, 113)), ptsArray2)
        'Dim ptsArray As PointF() = {New Point(1, -1), New Point(31, -1), New Point(16, 12), New Point(1, -1)}
        '            e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(240, 240, 240)), ptsArray)

    End Sub

End Class