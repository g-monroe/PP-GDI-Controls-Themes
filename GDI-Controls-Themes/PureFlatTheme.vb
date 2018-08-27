Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.ComponentModel

<DefaultEvent("CheckedChanged")> Class Toggle : Inherits Panel
    Property FillColor As Color = Color.FromArgb(27, 132, 188)
    Public onoff As Boolean = False
    Public Event CheckedChanged(ByVal sender As Object)
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        Me.Size = New Size(44, 18)
    End Sub

    <PropertyTab("Onoff")> _
 <DisplayName("Onoff")> _
    Public Property Icons() As Boolean
        Get
            Return onoff
        End Get
        Set(value As Boolean)
            onoff = value
        End Set
    End Property
    Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim bm As New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        ' Me.Padding = New Padding(13, 39, 13, 24)
        '  Dim rect As New Rectangle(0, 0, Me.Width, (Me.Height - 35))
        ' Dim brush As New LinearGradientBrush(rect, Color.FromArgb(250, 250, 250), Color.FromArgb(206, 206, 206), 90.0!)
        'Begin
        If onoff = True Then
            Dim Path As GraphicsPath = RoundRec(0, 0, Width - 2, Height - 2, 14)
            g.SmoothingMode = SmoothingMode.HighQuality
            g.FillPath(New SolidBrush(FillColor), Path)
            g.DrawPath(New Pen(FillColor), Path) '22, 122, 198
            g.DrawEllipse(New Pen(Color.FromArgb(255, 255, 255)), New Rectangle(Width - 17, Me.Height - 17, 14, 14))
            g.FillEllipse(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(Width - 17, Me.Height - 17, 14, 14))
            g.DrawString("ü", New Font("Wingdings", 14), New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(0 + 7, Me.Height - 19, 14, 14), NearSF)
        Else
            Dim Path As GraphicsPath = RoundRec(0, 0, Width - 2, Height - 2, 14)
            g.SmoothingMode = SmoothingMode.HighQuality
            g.FillPath(New SolidBrush(Color.FromArgb(184, 184, 184)), Path)
            g.DrawPath(New Pen(Color.FromArgb(184, 184, 184)), Path)
            g.DrawEllipse(New Pen(Color.FromArgb(255, 255, 255)), New Rectangle(0 + 1, Me.Height - 17, 14, 14))
            g.FillEllipse(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(0 + 1, Me.Height - 17, 14, 14))
        End If
        'end
        e.Graphics.DrawImage(DirectCast(bm.Clone(), Bitmap), 0, 0)
        g.Dispose()
        bm.Dispose()
        MyBase.OnPaint(e)
    End Sub
    Dim x, y As Integer
    Private _Checked As Boolean = False
#Region " Options"

    <Category("Options")> _
    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
        End Set
    End Property

#End Region
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        Dim clickRect2 As New Rectangle(0 + 1, Me.Height - 17, 14, 14)
        If onoff = False Then
            If clickRect2.Contains(New Point(e.X, e.Y)) Then
                onoff = True
                RaiseEvent CheckedChanged(Me)
            End If
        End If
        Dim clickRect3 As New Rectangle(Width - 17, Me.Height - 17, 14, 14)
        If onoff = True Then
            If clickRect3.Contains(New Point(e.X, e.Y)) Then
                onoff = False
                RaiseEvent CheckedChanged(Me)
            End If
        End If
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
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub
#End Region
    Private Sub Theme_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
    Public Function RoundRec(ByVal X As Integer, ByVal Y As Integer, _
       ByVal Width As Integer, ByVal Height As Integer, ByVal diameter As Integer) As System.Drawing.Drawing2D.GraphicsPath

        ''the 'diameter' parameter changes the size of the rounded region

        Dim graphics_path As New System.Drawing.Drawing2D.GraphicsPath

        Dim BaseRect As New RectangleF(X, Y, Width, Height)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(diameter, diameter))

        'top left Arc
        graphics_path.AddArc(ArcRect, 180, 90)
        graphics_path.AddLine(X + CInt(diameter / 2), _
        Y, X + Width - CInt(diameter / 2), Y)

        ' top right arc
        ArcRect.X = BaseRect.Right - diameter
        graphics_path.AddArc(ArcRect, 270, 90)
        graphics_path.AddLine(X + Width, _
        Y + CInt(diameter / 2), X + Width, _
                         Y + Height - CInt(diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - diameter
        graphics_path.AddArc(ArcRect, 0, 90)
        graphics_path.AddLine(X + CInt(diameter / 2), _
        Y + Height, X + Width - CInt(diameter / 2), _
                         Y + Height)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        graphics_path.AddArc(ArcRect, 90, 90)
        graphics_path.AddLine(X, Y + CInt(diameter / 2), _
        X, Y + Height - CInt(diameter / 2))

        Return graphics_path

    End Function

End Class

Partial Public Class ContainerTheme
    Inherits Panel
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        Me.Padding = New Padding(1, 55, 1, 1)
    End Sub
    Dim x, y As Integer
    Public Enum Type
        Teacher = 0
        Student = 1
        Application = 2
    End Enum
    Public _Type As Type = Type.Student
    Public Property Tyype As Type
        Get
            Return _Type
        End Get
        Set(ByVal value As Type)
            _Type = value
            Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim bm As New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        ' Dim rect As New Rectangle(0, 0, Me.Width, (Me.Height - 35))
        ' Dim brush As New LinearGradientBrush(rect, Color.FromArgb(250, 250, 250), Color.FromArgb(206, 206, 206), 90.0!)
        'Begin
        'Form
        g.DrawRectangle(New Pen(Color.FromArgb(242, 242, 242)), 0, 0, Me.Width, Me.Height)
        g.FillRectangle(New SolidBrush(Color.FromArgb(242, 242, 242)), 0, 0, Me.Width, Me.Height)
        'Splitter
        g.DrawRectangle(New Pen(Color.FromArgb(229, 229, 229)), 0, 0, Me.Width, 51)
        g.FillRectangle(New SolidBrush(Color.FromArgb(229, 229, 229)), 0, 0, Me.Width, 51)
        'Top
        Dim rect = New Rectangle(0, 0, Me.Width, 50)
        g.DrawRectangle(New Pen(Color.FromArgb(255, 255, 255)), 0, 0, Me.Width, 50)
        g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), 0, 0, Me.Width, 50)
        'String
        g.DrawString(FindForm.Text, New Font("Arial", 12.5, FontStyle.Regular), New SolidBrush(Color.FromArgb(130, 130, 130)), 14, 17)
        g.DrawString(_Type.ToString, New Font("Arial", 12.5, FontStyle.Bold), New SolidBrush(Color.FromArgb(45, 114, 160)), 93, 17)
        'Buttons
        '//Close button
        If New Rectangle(Width - 40, 10, 24, 24).Contains(New Point(mouseX, mouseY)) Then
            g.SmoothingMode = SmoothingMode.HighQuality
            g.FillRectangle(New SolidBrush(Color.FromArgb(237, 237, 237)), New Rectangle(Width - 40, 10, 24, 24))
            g.DrawString("r", New Font("Webdings", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 40, 10))
        Else
            g.SmoothingMode = SmoothingMode.HighQuality
            ' g.FillRectangle(New SolidBrush(Color.FromArgb(237, 237, 237)), New Rectangle(Width - 40, 10, 24, 24))
            g.DrawString("r", New Font("Webdings", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 40, 10))
        End If
        '//Minimize Button
        If New Rectangle(Width - 100, 10, 24, 24).Contains(New Point(mouseX, mouseY)) Then
            g.SmoothingMode = SmoothingMode.HighQuality
            g.FillRectangle(New SolidBrush(Color.FromArgb(237, 237, 237)), New Rectangle(Width - 100, 10, 24, 24))
            g.DrawString("0", New Font("Webdings", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 100, 10))
        Else
            g.SmoothingMode = SmoothingMode.HighQuality
            ' g.FillRectangle(New SolidBrush(Color.FromArgb(237, 237, 237)), New Rectangle(Width - 40, 10, 24, 24))
            g.DrawString("0", New Font("Webdings", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 100, 10))
        End If
        '//Fullscreen
        If New Rectangle(Width - 70, 10, 24, 24).Contains(New Point(mouseX, mouseY)) Then
            g.SmoothingMode = SmoothingMode.HighQuality
            g.FillRectangle(New SolidBrush(Color.FromArgb(237, 237, 237)), New Rectangle(Width - 70, 10, 24, 24))
            If FindForm.WindowState = FormWindowState.Maximized Then
                g.DrawString("2", New Font("Webdings", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 70, 10))
            Else
                g.DrawString("1", New Font("Webdings", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 70, 10))
            End If
        Else
            g.SmoothingMode = SmoothingMode.HighQuality
            ' g.FillRectangle(New SolidBrush(Color.FromArgb(237, 237, 237)), New Rectangle(Width - 40, 10, 24, 24))
            If FindForm.WindowState = FormWindowState.Maximized Then
                g.DrawString("2", New Font("Webdings", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 70, 10))
            Else
                g.DrawString("1", New Font("Webdings", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 70, 10))
            End If
        End If
        'End
        e.Graphics.DrawImage(DirectCast(bm.Clone(), Bitmap), 0, 0)
        g.Dispose()
        bm.Dispose()
        MyBase.OnPaint(e)

    End Sub
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width - 103, 50)
        If dragRect.Contains(New Point(e.X, e.Y)) Then
            isDragging = True
            savePoint = New Point(e.X, e.Y)
        End If
        Dim clickRect As New Rectangle(Width - 40, 10, 24, 24)
        If clickRect.Contains(New Point(e.X, e.Y)) Then
            Environment.[Exit](0)
        End If
        If New Rectangle(Width - 70, 10, 24, 24).Contains(New Point(mouseX, mouseY)) Then
            If FindForm.WindowState = FormWindowState.Maximized Then
                FindForm.WindowState = FormWindowState.Normal
            Else
                FindForm.WindowState = FormWindowState.Maximized
            End If
        End If
        If New Rectangle(Width - 100, 10, 24, 24).Contains(New Point(mouseX, mouseY)) Then
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
        If isDragging Then
            Dim screenPoint As Point = PointToScreen(e.Location)

            FindForm().Location = New Point(screenPoint.X - Me.savePoint.X, screenPoint.Y - Me.savePoint.Y)
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
    Public Function Base64ToImage(base64String As String) As Image
        'I did not write this Function
        ' Convert Base64 String to byte[]
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)

        ' Convert byte[] to Image
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim image__1 As Image = Image.FromStream(ms, True)
        Return image__1
    End Function
End Class
Partial Public Class FlatButton
    Inherits Panel
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
    End Sub
    Public Event Clicked()
    Public MainColor As Color = Color.FromArgb(33, 159, 225)
    Public PopColor As Color = Color.FromArgb(16, 110, 159)
    Public HoverColor As Color = Color.FromArgb(27, 132, 188)
    Public TextColor As Color = Color.FromArgb(255, 255, 255)
    Public TextFont As Font = New Font("Arial", 11, FontStyle.Regular)
    <PropertyTab("Main Color")> _
 <DisplayName("Main Color")> _
    Public Property MC() As Color
        Get
            Return MainColor
        End Get
        Set(value As Color)
            MainColor = value
        End Set
    End Property
    <PropertyTab("Pop Color")> _
<DisplayName("Pop Color")> _
    Public Property PC() As Color
        Get
            Return PopColor
        End Get
        Set(value As Color)
            PopColor = value
        End Set
    End Property
    <PropertyTab("Hover Color")> _
<DisplayName("Hover Color")> _
    Public Property HC() As Color
        Get
            Return HoverColor
        End Get
        Set(value As Color)
            HoverColor = value
        End Set
    End Property
    <PropertyTab("Text Color")> _
<DisplayName("Text Color")> _
    Public Property TC() As Color
        Get
            Return TextColor
        End Get
        Set(value As Color)
            TextColor = value
        End Set
    End Property
    <PropertyTab("Text Font")> _
<DisplayName("Text Font")> _
    Public Property TF() As Font
        Get
            Return TextFont
        End Get
        Set(value As Font)
            TextFont = value
        End Set
    End Property
    Dim X, Y As Integer

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim bm As New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        ' Dim rect As New Rectangle(0, 0, Me.Width, (Me.Height - 35))
        ' Dim brush As New LinearGradientBrush(rect, Color.FromArgb(250, 250, 250), Color.FromArgb(206, 206, 206), 90.0!)
        'Begin
        'Main part
        If Clickedd = True Then
            g.DrawRectangle(New Pen(PopColor), 0, 0, Me.Width, Me.Height - 7)
            g.FillRectangle(New SolidBrush(PopColor), 0, 0, Me.Width, Me.Height - 7)
        Else
            If Inner = True Then
                g.DrawRectangle(New Pen(HoverColor), 0, 0, Me.Width, Me.Height - 7)
                g.FillRectangle(New SolidBrush(HoverColor), 0, 0, Me.Width, Me.Height - 7)
            Else
                g.DrawRectangle(New Pen(MainColor), 0, 0, Me.Width, Me.Height - 7)
                g.FillRectangle(New SolidBrush(MainColor), 0, 0, Me.Width, Me.Height - 7)
            End If
        End If
        'Bottom part
        g.DrawRectangle(New Pen(PopColor), 0, Me.Height - 7, Me.Width, Me.Height - 7)
        g.FillRectangle(New SolidBrush(PopColor), 0, Me.Height - 7, Me.Width, Me.Height - Me.Height + 7)
        'Text
        Dim rect = New Rectangle(0, 0, Me.Width, Me.Height - 7)
        g.DrawString("Read More", TextFont, New SolidBrush(TextColor), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        'End
        Clickedd = False
        e.Graphics.DrawImage(DirectCast(bm.Clone(), Bitmap), 0, 0)
        g.Dispose()
        bm.Dispose()
        MyBase.OnPaint(e)
    End Sub
#Region "ThemeDraggable"
    Public Clickedd As Boolean = False

    Public Inner As Boolean = False
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        Dim clickRect As New Rectangle(0, 0, Me.Width, Me.Height)
        If clickRect.Contains(New Point(e.X, e.Y)) Then
            Clickedd = True
            RaiseEvent Clicked()
        End If
        '

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        Dim clickRect As New Rectangle(2, 2, Me.Width - 2, Me.Height - 2)
        If clickRect.Contains(New Point(e.X, e.Y)) Then
            Inner = True
        Else
            Inner = False
        End If
        mouseX = e.X
        mouseY = e.Y

        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class
<DefaultEvent("Scroll")> _
Class NSVScrollBar
    Inherits Control
    'Made by the awesome and great AeonHack
    Event Scroll(ByVal sender As Object)

    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then value = 1

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            If Not ShowThumb Then Return _Minimum
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            InvalidatePosition()

            RaiseEvent Scroll(Me)
        End Set
    End Property

    Property _Percent As Double
    Public ReadOnly Property Percent As Double
        Get
            If Not ShowThumb Then Return 0
            Return GetProgress()
        End Get
    End Property

    Private _SmallChange As Integer = 1
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _SmallChange = value
        End Set
    End Property

    Private _LargeChange As Integer = 10
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _LargeChange = value
        End Set
    End Property

    Private ButtonSize As Integer = 16
    Private ThumbSize As Integer = 24 ' 14 minimum

    Private TSA As Rectangle
    Private BSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle

    Private ShowThumb As Boolean
    Private ThumbDown As Boolean

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Width = 18

        B1 = New SolidBrush(Color.FromArgb(27, 132, 188))
        B2 = New SolidBrush(Color.FromArgb(33, 159, 225))

        P1 = New Pen(Color.FromArgb(235, 235, 235))
        P2 = New Pen(Color.FromArgb(165, 165, 165))
        P3 = New Pen(Color.FromArgb(155, 155, 155))
        P4 = New Pen(Color.FromArgb(140, 140, 40))
    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private P1, P2, P3, P4 As Pen
    Private B1, B2 As SolidBrush

    Dim I1 As Integer

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        Dim bm As New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        G = e.Graphics
        G.Clear(Color.FromArgb(242, 242, 242))

        GP1 = DrawArrow(3, 6, False)
        GP2 = DrawArrow(4, 7, False)

        G.FillPath(B1, GP2)
        G.FillPath(B2, GP1)

        GP3 = DrawArrow(3, Height - 11, True)
        GP4 = DrawArrow(4, Height - 10, True)

        G.FillPath(B1, GP4)
        G.FillPath(B2, GP3)

        If ShowThumb Then
            G.FillRectangle(B1, Thumb)
            G.DrawRectangle(P1, Thumb)
            G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2)

            Dim Y As Integer
            Dim LY As Integer = Thumb.Y + (Thumb.Height \ 2) - 3

            For I As Integer = 0 To 2
                Y = LY + (I * 3)

                G.DrawLine(P1, Thumb.X + 5, Y, Thumb.Right - 5, Y)
                G.DrawLine(P2, Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1)
            Next
        End If

        G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1)
        '  G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3)
    End Sub

    Private Function DrawArrow(x As Integer, y As Integer, flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 9
        Dim H As Integer = 5

        If flip Then
            GP.AddLine(x + 1, y, x + W + 1, y)
            GP.AddLine(x + W, y, x + H, y + H - 1)
        Else
            GP.AddLine(x, y + H, x + W, y + H)
            GP.AddLine(x + W, y + H, x + H, y)
        End If

        GP.CloseFigure()
        Return GP
    End Function

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        TSA = New Rectangle(0, 0, Width, ButtonSize)
        BSA = New Rectangle(0, Height - ButtonSize, Width, ButtonSize)
        Shaft = New Rectangle(0, TSA.Bottom + 1, Width, Height - (ButtonSize * 2) - 1)

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Height)

        If ShowThumb Then
            'ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = New Rectangle(1, 0, Width - 3, ThumbSize)
        End If

        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.Y = CInt(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If TSA.Contains(e.Location) Then
                I1 = _Value - _SmallChange
            ElseIf BSA.Contains(e.Location) Then
                I1 = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    MyBase.OnMouseDown(e)
                    Return
                Else
                    If e.Y < Thumb.Y Then
                        I1 = _Value - _LargeChange
                    Else
                        I1 = _Value + _LargeChange
                    End If
                End If
            End If

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.Y - TSA.Height - (ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Height - ThumbSize

            I1 = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
        MyBase.OnMouseUp(e)
    End Sub

    Private Function GetProgress() As Double
        Return (_Value - _Minimum) / (_Maximum - _Minimum)
    End Function

End Class

Partial Public Class FlatGroupBox
    Inherits Panel
    Property Downsize As Size = New Size(386, 146)
    Property UporDown As Boolean = True
    Property OutBorderColor As Color = Color.FromArgb(229, 229, 229)
    Property InBorderColor As Color = Color.FromArgb(219, 219, 219)
    Property HeaderColor As Color = Color.FromArgb(255, 255, 255)
    Property BoxColor As Color = Color.FromArgb(242, 242, 242)
    Property OddColor As Color = Color.FromArgb(27, 132, 188)
    Property PopOddColor As Color = Color.FromArgb(17, 122, 178)
    Property _text As String = "Box"
    Sub New()
        Me.Padding = New Padding(2, 37, 2, 2)
    End Sub
    Private Sub FlatGroupBox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(BoxColor)
        e.Graphics.DrawRectangle(New Pen(InBorderColor), New Rectangle(0, 35, Me.Width - 2, Me.Height - 36))
        e.Graphics.DrawRectangle(New Pen(OutBorderColor), New Rectangle(0, 36, Me.Width - 3, Me.Height - 37))
        e.Graphics.FillRectangle(New SolidBrush(HeaderColor), New Rectangle(0, 0, Me.Width, 35))
        If UporDown = True Then
            e.Graphics.FillRectangle(New SolidBrush(OddColor), New Rectangle(Me.Width - 27, 22, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(PopOddColor), New Rectangle(Me.Width - 27, 26, 20, 2))
            e.Graphics.FillRectangle(New SolidBrush(OddColor), New Rectangle(Me.Width - 27, 14, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(PopOddColor), New Rectangle(Me.Width - 27, 18, 20, 2))
            e.Graphics.FillRectangle(New SolidBrush(OddColor), New Rectangle(Me.Width - 27, 6, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(PopOddColor), New Rectangle(Me.Width - 27, 10, 20, 2))
            Me.Size = Downsize
        Else
            e.Graphics.FillRectangle(New SolidBrush(InBorderColor), New Rectangle(Me.Width - 27, 22, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(OutBorderColor), New Rectangle(Me.Width - 27, 26, 20, 2))
            e.Graphics.FillRectangle(New SolidBrush(InBorderColor), New Rectangle(Me.Width - 27, 14, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(OutBorderColor), New Rectangle(Me.Width - 27, 18, 20, 2))
            e.Graphics.FillRectangle(New SolidBrush(InBorderColor), New Rectangle(Me.Width - 27, 6, 20, 6))
            e.Graphics.FillRectangle(New SolidBrush(OutBorderColor), New Rectangle(Me.Width - 27, 10, 20, 2))
            Me.Size = New Size(Me.Width, 36)
        End If
        e.Graphics.DrawString(_text, New Font("Arial", 12.5, FontStyle.Regular), New SolidBrush(Color.FromArgb(130, 130, 130)), 5, 8)
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        Dim clickRect As New Rectangle(Me.Width - 27, 10, 20, 20)
        If clickRect.Contains(New Point(e.X, e.Y)) Then
            UporDown = Not UporDown
            Me.Refresh()
        End If
        '

        MyBase.OnMouseDown(e)
    End Sub
End Class
Partial Public Class FlatListbox
    Inherits Panel
    Public Event SelectedItem(i As Integer)
    Property OutBorderColor As Color = Color.FromArgb(229, 229, 229)
    Property InBorderColor As Color = Color.FromArgb(219, 219, 219)
    Property BoxColor As Color = Color.FromArgb(242, 242, 242)
    Property OddColor As Color = Color.FromArgb(27, 132, 188)
    Property PopOddColor As Color = Color.FromArgb(17, 122, 178)
    Private VS As NSVScrollBar
    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub HandleScroll(sender As Object)
        Invalidate()
    End Sub

    Private Sub InvalidateScroll()
        VS.Maximum = (_Items.Count * 24)
        Invalidate()
    End Sub

    Private Sub InvalidateLayout()
        VS.Location = New Point(Width - VS.Width + 2, 1)
        VS.Size = New Size(18, Height - 2)

        Invalidate()
    End Sub
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)



        VS = New NSVScrollBar
        VS.SmallChange = 24
        VS.LargeChange = 24

        AddHandler VS.Scroll, AddressOf HandleScroll
        AddHandler VS.MouseDown, AddressOf VS_MouseDown
        Controls.Add(VS)

        InvalidateLayout()
    End Sub
    Private Sub VS_MouseDown(sender As Object, e As MouseEventArgs)
        Focus()
        Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (24 * 2))))
        Dim Index As Integer = ((e.Y + Offset - 24) \ 24)
    End Sub
    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        Dim Move As Integer = -((e.Delta * SystemInformation.MouseWheelScrollLines \ 120) * (24 \ 2))

        Dim Value As Integer = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum)
        VS.Value = Value

        MyBase.OnMouseWheel(e)
    End Sub
    Public Class ItemCollection
        Inherits List(Of Item)
        Private Parent As FlatListbox
        Public Sub New(Parent As FlatListbox)
            Me.Parent = Parent

        End Sub
        Public Shadows Sub Add(Item As Item)
            MyBase.Add(Item)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub AddRange(Range As List(Of Item))
            MyBase.AddRange(Range)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Remove(Item As Item)
            MyBase.Remove(Item)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of Item))
            MyBase.RemoveAll(Predicate)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
            Parent.InvalidateScroll()
        End Sub

    End Class
    Public Class Item
        Property Text As String
        Property OddColor As Color = Color.FromArgb(37, 142, 198)
        Property PopOddColor As Color = Color.FromArgb(17, 122, 178)
        Property Index As Integer = 0
        Property locy As Integer = 0
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

    Private Sub FlatListbox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (24 * 2))))
        e.Graphics.Clear(BoxColor)
        e.Graphics.DrawRectangle(New Pen(InBorderColor), New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
        e.Graphics.DrawRectangle(New Pen(OutBorderColor), New Rectangle(0, 0, Me.Width - 2, Me.Height - 2))

        Dim y As Integer = 4
        For Each Item As Item In _Items

            y = 24 * Item.Index
            If Not Item.Selected = True Then
                Item.locy = y
                Dim rect = New Rectangle(2, y - Offset, Me.Width - 4, 24)
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), rect)
                rect = New Rectangle(2, y + 20 - Offset, Me.Width - 4, 4)
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(232, 232, 232)), rect)
                e.Graphics.DrawString(Item.Text, New Font("Arial", 9.5, FontStyle.Regular), New SolidBrush(Color.FromArgb(130, 130, 130)), 2, y + 4 - Offset)
            Else
                Dim rect = New Rectangle(2, y - Offset, Me.Width - 4, 24)
                e.Graphics.FillRectangle(New SolidBrush(OddColor), rect)
                rect = New Rectangle(2, y + 20 - Offset, Me.Width - 4, 4)
                e.Graphics.FillRectangle(New SolidBrush(PopOddColor), rect)
                e.Graphics.DrawString(Item.Text, New Font("Arial", 9.5, FontStyle.Regular), New SolidBrush(Color.White), 2, y + 4 - Offset)
            End If
        Next
    End Sub
    'Example
    Public Function SelectedItemIndex()
        For Each Item As Item In _Items
            If Item.Selected = True Then
                Return Item.Index
            End If
        Next
    End Function
#Region "ThemeDraggable"
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim y As Integer = 3
        Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (24 * 2))))
        For Each Item As Item In _Items
            y = 24 * Item.Index
            Dim rect = New Rectangle(2, y - Offset, Me.Width - 4, 24)
            If Item.locy = y Then
                If rect.Contains(mouseX, mouseY) Then
                    Item.Selected = Not Item.Selected
                    RaiseEvent SelectedItem(Item.Index)
                Else
                    Item.Selected = False
                End If
            Else
                Item.Selected = False
            End If
        Next
        '

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y

        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class
Module DesignFunctions
    Function ToBrush(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return ToBrush(Color.FromArgb(A, R, G, B))
    End Function
    Function ToBrush(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return ToBrush(Color.FromArgb(R, G, B))
    End Function
    Function ToBrush(ByVal A As Integer, ByVal C As Color) As Brush
        Return ToBrush(Color.FromArgb(A, C))
    End Function
    Function ToBrush(ByVal Pen As Pen) As Brush
        Return ToBrush(Pen.Color)
    End Function
    Function ToBrush(ByVal Color As Color) As Brush
        Return New SolidBrush(Color)
    End Function
    Function ToPen(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return ToPen(Color.FromArgb(A, R, G, B))
    End Function
    Function ToPen(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return ToPen(Color.FromArgb(R, G, B))
    End Function
    Function ToPen(ByVal A As Integer, ByVal C As Color) As Pen
        Return ToPen(Color.FromArgb(A, C))
    End Function
    Function ToPen(ByVal Color As Color) As Pen
        Return ToPen(New SolidBrush(Color))
    End Function
    Function ToPen(ByVal Brush As SolidBrush) As Pen
        Return New Pen(Brush)
    End Function

    Class CornerStyle
        Public TopLeft As Boolean
        Public TopRight As Boolean
        Public BottomLeft As Boolean
        Public BottomRight As Boolean
    End Class

    Public Function AdvRect(ByVal Rectangle As Rectangle, ByVal CornerStyle As CornerStyle, ByVal Curve As Integer) As GraphicsPath
        AdvRect = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2

        If CornerStyle.TopLeft Then
            AdvRect.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        Else
            AdvRect.AddLine(Rectangle.X, Rectangle.Y, Rectangle.X + ArcRectangleWidth, Rectangle.Y)
        End If

        If CornerStyle.TopRight Then
            AdvRect.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        Else
            AdvRect.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + ArcRectangleWidth)
        End If

        If CornerStyle.BottomRight Then
            AdvRect.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        Else
            AdvRect.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height, Rectangle.X + Rectangle.Width - ArcRectangleWidth, Rectangle.Y + Rectangle.Height)
        End If

        If CornerStyle.BottomLeft Then
            AdvRect.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        Else
            AdvRect.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y + Rectangle.Height - ArcRectangleWidth)
        End If

        AdvRect.CloseAllFigures()

        Return AdvRect
    End Function

    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        RoundRect = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        RoundRect.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        RoundRect.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        RoundRect.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        RoundRect.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        RoundRect.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, ArcRectangleWidth + Rectangle.Y))
        RoundRect.CloseAllFigures()
        Return RoundRect
    End Function

    Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        Return RoundRect(New Rectangle(X, Y, Width, Height), Curve)
    End Function

    Class PillStyle
        Public Left As Boolean
        Public Right As Boolean
    End Class

    Public Function Pill(ByVal Rectangle As Rectangle, ByVal PillStyle As PillStyle) As GraphicsPath
        Pill = New GraphicsPath()

        If PillStyle.Left Then
            Pill.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270, 180)
        Else
            Pill.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y)
        End If

        If PillStyle.Right Then
            Pill.AddArc(New Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90, 180)
        Else
            Pill.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height)
        End If

        Pill.CloseAllFigures()

        Return Pill
    End Function

    Public Function Pill(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal PillStyle As PillStyle)
        Return Pill(New Rectangle(X, Y, Width, Height), PillStyle)
    End Function

End Module
Class ThemedTrackBar
    Inherits Control
    'Base or Template used was from Tedd 
#Region "Properties"
    Dim _Maximum As Integer = 10
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _Maximum = value
            If value < _Value Then _Value = value
            Invalidate()
        End Set
    End Property

    Event ValueChanged()
    Dim _Value As Integer = 0
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)

            Select Case value
                Case Is = _Value
                    Exit Property
                Case Is < 0
                    _Value = 0
                Case Is > _Maximum
                    _Value = _Maximum
                Case Else
                    _Value = value
            End Select

            Invalidate()
            RaiseEvent ValueChanged()
        End Set
    End Property
#End Region

    Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or _
                    ControlStyles.AllPaintingInWmPaint Or _
                    ControlStyles.ResizeRedraw Or _
                    ControlStyles.UserPaint Or _
                    ControlStyles.Selectable Or _
                    ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Dim CaptureM As Boolean = False
    Dim Bar As Rectangle = New Rectangle(0, 10, Width - 1, Height - 21)
    Dim Track As Size = New Size(20, 20)

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics
        Bar = New Rectangle(10, 10, Width - 21, Height - 21)
        G.Clear(Parent.FindForm.BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        'Background
        Dim BackLinear As LinearGradientBrush = New LinearGradientBrush(New Point(0, CInt((Height / 2) - 4)), New Point(0, CInt((Height / 2) + 4)), Color.FromArgb(65, 65, 65), Color.FromArgb(65, 65, 65))
        G.FillPath(BackLinear, RoundRect(0, CInt((Height / 2) - 4), Width - 1, 8, 3))
        '  G.DrawPath(ToPen(50, Color.Black), RoundRect(0, CInt((Height / 2) - 4), Width - 1, 8, 3))
        BackLinear.Dispose()
        G.FillPath(New SolidBrush(Color.FromArgb(27, 132, 188)), RoundRect(0, CInt((Height / 2) - 4), Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 9, 8, 3))

        'Fill
        '  G.FillPath(New LinearGradientBrush(New Point(1, CInt((Height / 2) - 4)), New Point(1, CInt((Height / 2) + 4)), Color.FromArgb(250, 200, 70), Color.FromArgb(250, 160, 40)), RoundRect(1, CInt((Height / 2) - 4), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 8, 3))
        ' G.DrawPath(ToPen(100, Color.White), RoundRect(2, CInt((Height / 2) - 2), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 4, 3))
        G.SetClip(RoundRect(1, CInt((Height / 2) - 4), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 8, 3))
        For i = 0 To CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2) Step 10
            'G.FillEllipse(New SolidBrush(Color.FromArgb(27, 132, 188)), New Rectangle(New Point(i, CInt((Height / 2) - 10)), New Point(i - 10, CInt((Height / 2) + 10))))
        Next
        G.SetClip(New Rectangle(0, 0, Width, Height))

        'Button
        If inner = True Then
            G.FillEllipse(Brushes.White, New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 3, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 3, Track.Width - 6, Track.Height - 6))
            G.DrawEllipse(ToPen(50, Color.Black), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 3, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 3, Track.Width - 6, Track.Height - 6))
            G.FillEllipse(New LinearGradientBrush(New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2)), New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + Track.Height), Color.FromArgb(200, Color.Black), Color.FromArgb(25, Color.Black)), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 6, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 6, Track.Width - 12, Track.Height - 12))
        Else
            G.FillEllipse(Brushes.White, New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 3, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 3, Track.Width - 6, Track.Height - 6))
            G.DrawEllipse(ToPen(50, Color.Black), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 3, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 3, Track.Width - 6, Track.Height - 6))
        End If
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        Me.BackColor = Color.Transparent

        MyBase.OnHandleCreated(e)
    End Sub
    Dim inner As Boolean = False
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        Dim mp = New Rectangle(New Point(e.Location.X, e.Location.Y), New Size(1, 1))
        Dim Bar As Rectangle = New Rectangle(10, 10, Width - 21, Height - 21)
        If New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), 0), New Size(Track.Width, Height)).IntersectsWith(mp) Then
            CaptureM = True
            inner = True
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        CaptureM = False
        inner = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If CaptureM Then
            Dim mp As Point = New Point(e.X, e.Y)
            Dim Bar As Rectangle = New Rectangle(10, 10, Width - 21, Height - 21)
            Value = CInt(Maximum * ((mp.X - Bar.X) / Bar.Width))
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e) : CaptureM = False
    End Sub

End Class