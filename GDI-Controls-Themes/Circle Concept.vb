'This may be messy so if you are trying to learn from it, ... i would say don't xD!
Public Class CicleGroup
    Inherits Panel

    Dim inner As Boolean = False
    Public List As New List(Of Item)
    Property refreshh As Boolean = True
    Dim TRC1 As Integer = 20
    Public Sub New()
        BackColor = Color.Transparent
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
            ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
            ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Parent = FindForm()

    End Sub
    Public Class ItemCollection
        Inherits List(Of Item)
        Private Parent As CicleGroup
        Public Sub New(Parent As CicleGroup)
            Me.Parent = Parent
        End Sub
        Public Shadows Sub Add(Item As Item)

            MyBase.Add(Item)
        End Sub
        Public Shadows Sub AddRange(Range As List(Of Item))
            MyBase.AddRange(Range)
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
        End Sub
        Public Shadows Sub Remove(Item As Item)
            MyBase.Remove(Item)
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of Item))
            MyBase.RemoveAll(Predicate)
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
        End Sub

    End Class
    Public Class Item
        Property Text As String
        Property Fill_Color As Color = Color.FromArgb(100, 45, 45, 45)
        Property Index As Integer = 0
        Property Icon As Image = My.Resources.LightStar
        Property Iconn As Boolean = False
        Property locx As Integer = 0
        Property locy As Integer = 0
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
    Public List2 As New List(Of Point)
    Private Sub CicleGroup_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If refreshh = True Then
            Try
                _Items.Clear()
            Catch ex As Exception

            End Try
            refreshh = False
        End If
        Dim i2 As Integer = 0
        For Each itm As Item In _Items
            i2 += 1
        Next

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality


        Dim rnd As New Random
        If i2 = 0 Then
            For i As Integer = 0 To 50
                Dim item As New Item
                item.locx = rnd.Next(0, Me.Width - 23)
                item.locy = rnd.Next(0, Me.Height - 23)
                _Items.Add(Item)
            Next
        End If
        For Each itm As Item In _Items
            e.Graphics.DrawLine(Pens.Black, New Point(Me.Width / 2, Me.Height / 2), New Point(itm.locx, itm.locy))
            If Not New Rectangle(itm.locx, itm.locy, 25, 25).Contains(New Rectangle(Me.Width / 2 - 25, Me.Height / 2 - 25, 50, 50)) Then
                Dim r As Integer = rnd.Next(0, 205)
                Dim g As Integer = rnd.Next(0, 205)
                Dim b As Integer = rnd.Next(0, 205)
                'Dim pic As New PictureBox
                'pic.Location = New Point(itm.locx - 1, itm.locy - 1)
                'pic.Size = New Size(16, 16)
                'pic.Image = itm.Icon
                'pic.Name = "pic_" & itm.Text
                'pic.SizeMode = PictureBoxSizeMode.Zoom
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(r, g, b)), New Rectangle(itm.locx - 6, itm.locy - 6, 26, 26))
                e.Graphics.DrawImage(itm.Icon, New Rectangle(itm.locx - 3, itm.locy - 3, 20, 20))
                'Me.Controls.Add(pic)

                'pic.Region = New Region(RoundedRec(0, 0, pic.Width - TRC1 * 4, pic.Height - TRC1 * 4))
            End If
        Next

        e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(68, 148, 248)), New Rectangle(Me.Width / 2 - 25, Me.Height / 2 - 25, 50, 50))
        refreshh = False

        For Each itm As Item In _Items
            If New Rectangle(itm.locx, itm.locy, 25, 25).Contains(mouseX, mouseY) Then
                Cursor = Cursors.Hand
                e.Graphics.DrawString(itm.Text, Font, Brushes.Brown, New Rectangle(mouseX + 38, mouseY, 50, 50))
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(68, 148, 248)), New Rectangle(itm.locx - 26, itm.locy - 26, 66, 66))
                'Dim pic As New PictureBox
                'pic.Location = New Point(itm.locx - 23, itm.locy - 23)
                'pic.Size = New Size(60, 60)
                'pic.Image = itm.Icon
                'pic.SizeMode = PictureBoxSizeMode.Zoom
                'pic.Name = "Hover_pic" & rnd.Next(1, 999)
                'Me.Controls.Add(pic)
                'For Each pic2 As PictureBox In Me.Controls.OfType(Of PictureBox)()
                '    If pic2.Name.Contains(itm.Text) Then
                '        pic2.Visible = False
                '    End If
                'Next
                e.Graphics.DrawImage(itm.Icon, New Rectangle(itm.locx - 23, itm.locy - 23, 60, 60))
            Else
                'For Each pic As PictureBox In Me.Controls.OfType(Of PictureBox)()
                '    If pic.Name.Contains("Hover_pic") Then
                '        pic.Dispose()
                '    End If
                'Next
                Cursor = Cursors.Arrow
            End If
        Next
    End Sub
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False
    Dim x, y As Integer
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)


        '
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        isDragging = False
        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y

        If isDragging Then
            Dim screenPoint As Point = PointToScreen(e.Location)

            FindForm().Location = New Point(screenPoint.X - Me.savePoint.X, screenPoint.Y - Me.savePoint.Y)
        End If
        For Each itm In List
            If New Rectangle(itm.locx, itm.locy, 25, 25).Contains(mouseX, mouseY) Then
                inner = True

            Else
                inner = False
            End If
        Next

        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region

    Private Sub pic_load()

    End Sub
    Private Function RoundedRec(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer) As System.Drawing.Drawing2D.GraphicsPath
        ' Make and Draw a path.
        Dim graphics_path As New System.Drawing.Drawing2D.GraphicsPath
        graphics_path.AddLine(X + 10, Y, X + Width, Y) 'add the Top line to the path
        Dim TRC1 As Integer = 20 * 4
        Dim TRC2 As Integer = 4 * 4
        Dim TRC3 As Integer = 12 * 4
        Dim TRC4 As Integer = 8 * 4
        Dim TRC5 As Integer = 16 * 4
        'Top Right corner        
        Dim tr() As Point = { _
        New Point(X + Width, Y), _
        New Point((X + Width) + TRC4, Y + TRC2), _
        New Point((X + Width) + TRC5, Y + TRC3), _
        New Point((X + Width) + TRC1, Y + TRC1)}

        graphics_path.AddCurve(tr)  'Add the Top right curve to the path

        'Bottom right corner 
        Dim BRC1 As Integer = 20 * 4
        Dim BRC2 As Integer = 4 * 4
        Dim BRC3 As Integer = 12 * 4
        Dim BRC4 As Integer = 8 * 4
        Dim BRC5 As Integer = 16 * 4
        Dim br() As Point = { _
        New Point((X + Width) + BRC1, Y + Height), _
        New Point((X + Width) + BRC5, (Y + Height) + BRC4), _
        New Point((X + Width) + BRC4, (Y + Height) + BRC5), _
        New Point(X + Width, (Y + Height) + BRC1)}

        graphics_path.AddCurve(br)  'Add the Bottom right curve to the path

        'Bottom left corner
        Dim BLC1 As Integer = 20 * 4
        Dim BLC2 As Integer = 4 * 4
        Dim BLC3 As Integer = 12 * 4
        Dim BLC4 As Integer = 8 * 4
        Dim BLC5 As Integer = 16 * 4
        Dim bl() As Point = { _
        New Point(X + BLC1, (Y + Height) + BLC1), _
        New Point(X + BLC3, (Y + Height) + BLC5), _
        New Point(X + BLC2, (Y + Height) + BLC4), _
        New Point(X, Y + Height)}

        graphics_path.AddCurve(bl)  'Add the Bottom left curve to the path
        Dim TLC1 As Integer = 20 * 4
        Dim TLC2 As Integer = 4 * 4
        Dim TLC3 As Integer = 12 * 4
        'Top left corner
        Dim tl() As Point = { _
        New Point(X, Y + TLC1), _
        New Point(X + TLC2, Y + TLC3), _
        New Point(X + TLC3, Y + TLC2), _
        New Point(X + TLC1, Y)}

        graphics_path.AddCurve(tl)  'add the Top left curve to the path

        Return graphics_path

    End Function
End Class