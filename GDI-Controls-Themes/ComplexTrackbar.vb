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
Class AresioTrackBar
    Inherits Panel
   
#Region "Properties"
    Dim _Maximum As Integer = 10
    Public Property inner As Boolean = False
    Public Property At As String = "00:00"
    Public Property Endd As String = "00:00"
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
    Event ClickedForward()
    Event ValueChanged()
    Public _Value As Integer = 0
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
        DoubleBuffered = True
        BackColor = Color.Transparent
        Parent = FindForm()
    End Sub

    Dim CaptureM As Boolean = False
    Dim Bar As Rectangle = New Rectangle(0, 10, Width - 1, Height - 21)
    Dim Track As Size = New Size(20, 20)

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics
        Bar = New Rectangle(10, 10, Width - 21, Height - 21)
        '    G.Clear(Parent.FindForm.BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        'Background
        Dim BackLinear As LinearGradientBrush = New LinearGradientBrush(New Rectangle(0, CInt((Height / 2) - 4 + 9), Width - 1, 8), Color.FromArgb(50, Color.Black), Color.Transparent, 90.0!)
        G.FillPath(BackLinear, RoundRect(0, CInt((Height / 2) - 4 + 9), Width - 1, 8, 3))
        G.DrawPath(ToPen(50, Color.Black), RoundRect(0, CInt((Height / 2) - 4 + 9), Width - 1, 8, 3))
        BackLinear.Dispose()


        'Fill
        G.FillPath(New LinearGradientBrush(New Point(1, CInt((Height / 2) - 4)), New Point(1, CInt((Height / 2) + 9)), Color.FromArgb(251, 83, 150), Color.FromArgb(25, 25, 25)), RoundRect(1, CInt((Height / 2) - 4 + 9), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 8, 3))
        '  G.DrawPath(ToPen(100, Color.White), RoundRect(2, CInt((Height / 2) - 2), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 4, 3))
        G.SetClip(RoundRect(1, CInt((Height / 2) - 4 + 9), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 8, 3))
        For i = 0 To CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2) Step 10
            G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(20, Color.Black)), 4), New Point(i, CInt((Height / 2) - 10)), New Point(i - 10, CInt((Height / 2) + 10)))
        Next
        G.SetClip(New Rectangle(0, 0, Width, Height))

        'Button

        'G.FillEllipse(Brushes.White, Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2), Track.Width, Track.Height)
        'G.DrawEllipse(ToPen(50, Color.Black), Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2), Track.Width, Track.Height)
        'G.FillEllipse(New LinearGradientBrush(New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2)), New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + Track.Height), Color.FromArgb(200, Color.Black), Color.FromArgb(100, Color.Black)), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 6, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 6, Track.Width - 12, Track.Height - 12))
        If inner = True Then
            G.FillEllipse(Brushes.White, Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 9, Track.Width, Track.Height)
            G.DrawEllipse(ToPen(50, Color.Black), Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 9, Track.Width, Track.Height)
            G.FillEllipse(New LinearGradientBrush(New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2)), New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + Track.Height), Color.FromArgb(200, Color.Black), Color.FromArgb(100, Color.Black)), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 6, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 15, Track.Width - 12, Track.Height - 12))
            Dim poiints As PointF() = {New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 9), New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 10, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 19), New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 20, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 9)}
            G.FillPolygon(Brushes.White, poiints)
            e.Graphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) - 22, 0), New Size(65, 16)))
            e.Graphics.DrawRectangle(New Pen(Color.DimGray), New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) - 22, 0), New Size(65, 17)))
            e.Graphics.DrawString(At & "|" & Endd, New Font("Arial", 8, FontStyle.Regular), New SolidBrush(Color.FromArgb(25, 25, 25)), New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) - 22, 0), New Size(65, 16)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Else
            G.FillEllipse(Brushes.White, Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 9, Track.Width, Track.Height)
            G.DrawEllipse(ToPen(50, Color.Black), Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 9, Track.Width, Track.Height)
            G.FillEllipse(New LinearGradientBrush(New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2)), New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + Track.Height), Color.FromArgb(200, Color.Black), Color.FromArgb(100, Color.Black)), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 6, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 15, Track.Width - 12, Track.Height - 12))
        End If
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        Me.BackColor = Color.Transparent

        MyBase.OnHandleCreated(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        Dim mp = New Rectangle(New Point(e.Location.X, e.Location.Y), New Size(20, 20))
        Dim Bar As Rectangle = New Rectangle(10, 10, Width - 21, Height - 21)
        If New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), 19), New Size(Track.Width, Height)).Contains(e.Location) Then
            CaptureM = True
            inner = Not inner
        End If
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim mousepos = Math.Min(Math.Max(e.X, 0), Me.ClientSize.Width)
            Dim value = CInt(0 + (Me.Maximum - 0) * mousepos / Me.ClientSize.Width)
            '' Disable animation, if possible
            If value > Me.Value And value < Me.Maximum Then
                Me.Value = value + 1
                Me.Value = value
            Else
                Me.Value = value
            End If

        End If
        RaiseEvent ClickedForward()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        CaptureM = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If CaptureM Then
            Dim mp As Point = New Point(e.X, e.Y)
            Dim Bar As Rectangle = New Rectangle(10, 10, Width - 21, Height - 21)
            Value = CInt(Maximum * ((mp.X - Bar.X) / Bar.Width))
            RaiseEvent ClickedForward()
        End If
        'Dim mp2 = New Rectangle(New Point(e.Location.X, e.Location.Y), New Size(1, 1))
        'Dim Bar2 As Rectangle = New Rectangle(10, 10, Width - 21, Height - 21)
        'If New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 9), New Size(Track.Width, Height)).Contains(e.Location) Then
        '    inner = True
        'Else
        '    inner = False
        'End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e) : CaptureM = False
    End Sub

End Class