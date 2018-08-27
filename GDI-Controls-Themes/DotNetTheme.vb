Public Class TestForm
    Inherits ContainerControl
    Function NoiseBrush(colors As Color()) As TextureBrush
        Dim B As New Bitmap(128, 128)
        Dim R As New Random(128)

        For X As Integer = 0 To B.Width - 1
            For Y As Integer = 0 To B.Height - 1
                B.SetPixel(X, Y, colors(R.Next(colors.Length)))
            Next
        Next

        Dim T As New TextureBrush(B)
        B.Dispose()

        Return T
    End Function
#Region "Properties"
    Public ColorBarTop As Color
    Public ColorBarBottom As Color
    Public Icon As Image
    Public IconBorder As Boolean = False
    Public HeaderTitle As String = ".NET"
    Public Title As String = ".STREAMER"
    <PropertyTab("ColorBarTop")> _
<DisplayName("ColorBarTop")> _
    Public Property ColorBT() As Color
        Get
            Return ColorBarTop
        End Get
        Set(value As Color)
            ColorBarTop = value
        End Set
    End Property
    <PropertyTab("ColorBarBottom")> _
<DisplayName("ColorBarBottom")> _
    Public Property ColorBB() As Color
        Get
            Return ColorBarBottom
        End Get
        Set(value As Color)
            ColorBarBottom = value
        End Set
    End Property
    <PropertyTab("Icon")> _
<DisplayName("Icon")> _
    Public Property Iconn() As Image
        Get
            Return Icon
        End Get
        Set(value As Image)
            Icon = value
        End Set
    End Property
    <PropertyTab("IconBorder")> _
<DisplayName("IconBorder")> _
    Public Property IconnBorder() As Boolean
        Get
            Return IconBorder
        End Get
        Set(value As Boolean)
            IconBorder = value
        End Set
    End Property
    <PropertyTab("HeaderTitle")> _
<DisplayName("HeaderTitle")> _
    Public Property Header() As String
        Get
            Return HeaderTitle
        End Get
        Set(value As String)
            HeaderTitle = value
        End Set
    End Property
    <PropertyTab("Title")> _
<DisplayName("Title")> _
    Public Property Titlee() As String
        Get
            Return Title
        End Get
        Set(value As String)
            Title = value
        End Set
    End Property
#End Region
    Sub New()
        Me.BackColor = Color.FromArgb(45, 45, 45)
        Me.DoubleBuffered = True
    End Sub
    Dim TopTexture As TextureBrush = NoiseBrush({Color.FromArgb(29, 25, 21), Color.FromArgb(31, 27, 23), Color.FromArgb(27, 23, 29)})
    Private Sub TestForm_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        'Border And Background
        Dim Rect = New Rectangle(0, 0, Me.Width, Me.Height)
        e.Graphics.FillRectangle(TopTexture, Rect)
        e.Graphics.DrawRectangle(New Pen(Color.DimGray), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
        For i As Integer = 0 To 14
            Dim x As Integer = i * 20 - 150
            Dim y As Integer = i * 20 - 120
            Dim wid As Integer = Me.Width + 20 - x * 2
            Dim hei As Integer = Me.Height + 30 - y * 2
            e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(1, 255, 255, 255)), New Rectangle(x, y, wid, hei))
        Next
        'Bar
        Dim rectsquare As New Rectangle(1, 15, 13, 55)
        Dim brush As New LinearGradientBrush(rectsquare, ColorBarTop, ColorBarBottom, 90.0!)
        e.Graphics.FillRectangle(brush, rectsquare)
        'Icon
        If Not Icon Is Nothing Then
            e.Graphics.DrawImage(Icon, New Rectangle(18, 20, 25, 25))
        End If
        'Icon Border
        If IconBorder = True Then
            e.Graphics.DrawRectangle(New Pen(Color.DimGray), New Rectangle(18, 20, 25, 25))
        End If
        'Header
        e.Graphics.DrawString(HeaderTitle, New Font("Arial", 10, FontStyle.Regular), Brushes.White, New Rectangle(45, 32, 1000, 16))
        'Title
        e.Graphics.DrawString(Title, New Font("Arial", 10, FontStyle.Regular), Brushes.White, New Rectangle(18, 52, 1000, 16))
        'Buttons
        e.Graphics.DrawString("r", New Font("Webdings", 10, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(Me.Width - 25, 10, 16, 16))
        e.Graphics.DrawString("0", New Font("Webdings", 12, FontStyle.Regular), New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(Me.Width - 45, 8, 16, 16))
        'Example
        'Dim point1 As New PointF(5, 5)
        'Dim point2 As New PointF(10, 10)
        'Dim point3 As New PointF(0, 10)
        'Dim curvePoints As PointF() = {point1, point2, point3}

        '' Define fill mode. 
        'Dim newFillMode As FillMode = FillMode.Winding
        'e.Graphics.FillPolygon(New SolidBrush(Color.White), curvePoints, newFillMode)
    End Sub
#Region "ThemeDraggable"
    Dim x, y As Integer
    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width, 15)
        If dragRect.Contains(New Point(e.X, e.Y)) Then
            isDragging = True
            savePoint = New Point(e.X, e.Y)
        End If
        Dim clickRect As New Rectangle(Me.Width - 25, 10, 16, 16)
        If clickRect.Contains(New Point(e.X, e.Y)) Then
            Environment.[Exit](0)
        End If
        Dim clickRect2 As New Rectangle(Me.Width - 45, 8, 16, 16)
        If clickRect2.Contains(New Point(e.X, e.Y)) Then
            FindForm.WindowState = FormWindowState.Minimized
        End If
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
        If New Rectangle(Width - 40, 10, 24, 24).Contains(New Point(x, y)) Then
            FindForm.Close()
        End If
        If isDragging Then
            Dim screenPoint As Point = PointToScreen(e.Location)

            FindForm().Location = New Point(screenPoint.X - Me.savePoint.X, screenPoint.Y - Me.savePoint.Y)
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
    Private Sub TestForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
End Class