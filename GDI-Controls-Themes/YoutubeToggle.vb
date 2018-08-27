Imports System.Drawing.Drawing2D
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