Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class sCheckbox
    Inherits Control
    Private g As Graphics
#Region "Start"
    Sub New()
        ForeColor = Color.FromArgb(64, 64, 64)
        Font = New Font("Microsoft Sans Serif", 11, FontStyle.Regular)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
    End Sub
#End Region
#Region "Declarations"
    Private _Quality As SmoothingMode = SmoothingMode.AntiAlias
    Private _borderColor As Color = Color.FromArgb(173, 177, 181)
    Private _borderOuterShadowColor As Color = Color.FromArgb(233, 236, 239)
    Private _borderInnerShadowColor As Color = Color.FromArgb(240, 242, 244)
    Private _checkedColor As Color = Color.FromArgb(69, 69, 69)
    Private _boxColor As Color = BackColor
    Private _dborderColor As Color = Color.FromArgb(233, 236, 239)
    Private _dborderOuterShadowColor As Color = BackColor
    Private _dborderInnerShadowColor As Color = BackColor
    Private _dcheckedColor As Color = Color.FromArgb(163, 163, 163)
    Private _dboxColor As Color = BackColor
    Private _dforeColor As Color = Color.FromArgb(109, 101, 109)
    Private _roundedCorners As Integer = 8
    Private _boxed As Boolean = True
    Private _checkboxsize As Integer = 26

    Private _checked As Boolean = False
    Private _disabled As Boolean = False
#End Region
#Region "Properties"
    <Category("Appearance")>
    Property Quality() As SmoothingMode
        Get
            Return _Quality
        End Get
        Set(ByVal value As SmoothingMode)
            _Quality = value
        End Set
    End Property
    <Category("Appearance")>
    Property Boxed() As Boolean
        Get
            Return _boxed
        End Get
        Set(ByVal value As Boolean)
            _boxed = value
        End Set
    End Property
    <Category("Appearance")>
    Property RoundedCorners() As Integer
        Get
            Return _roundedCorners
        End Get
        Set(ByVal value As Integer)
            _roundedCorners = value
        End Set
    End Property
#Region "-]Colors"
    <Category("Colors")>
    <DisplayName("Border Color")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Outer Color")>
    Public Property OuterColor As Color
        Get
            Return _borderOuterShadowColor
        End Get
        Set(value As Color)
            _borderOuterShadowColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Inner Color")>
    Public Property InnerColor As Color
        Get
            Return _borderInnerShadowColor
        End Get
        Set(value As Color)
            _borderInnerShadowColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Box Color")>
    Public Property BoxColor As Color
        Get
            Return _boxColor
        End Get
        Set(value As Color)
            _boxColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Checked Color")>
    Public Property CheckedColor As Color
        Get
            Return _checkedColor
        End Get
        Set(value As Color)
            _checkedColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Disabled Checked Color")>
    Public Property dCheckedColor As Color
        Get
            Return _dcheckedColor
        End Get
        Set(value As Color)
            _dcheckedColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Disabled Border Color")>
    Public Property dborderColor As Color
        Get
            Return _dborderColor
        End Get
        Set(value As Color)
            _dborderColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Disabled Box Color")>
    Public Property dBoxColor As Color
        Get
            Return _dboxColor
        End Get
        Set(value As Color)
            _dboxColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Disabled Outer Color")>
    Public Property dOuterColor As Color
        Get
            Return _dborderOuterShadowColor
        End Get
        Set(value As Color)
            _dborderOuterShadowColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Disabled Inner Color")>
    Public Property dInnerColor As Color
        Get
            Return _dborderInnerShadowColor
        End Get
        Set(value As Color)
            _dborderInnerShadowColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Disabled Fore Color")>
    Public Property dForeColor As Color
        Get
            Return _dforeColor
        End Get
        Set(value As Color)
            _dforeColor = value
        End Set
    End Property
#End Region
#Region "-]Integers"
    <Category("Appearance")>
    <DisplayName("Checkbox Size")>
    Public Property CheckboxSize As Integer
        Get
            Return _checkboxsize
        End Get
        Set(value As Integer)
            _checkboxsize = value
        End Set
    End Property
#End Region
#Region "-]Booleans"
    <Category("Data")>
    <DisplayName("Checked")>
    Public Property Checked As Boolean
        Get
            Return _checked
        End Get
        Set(value As Boolean)
            _checked = value
        End Set
    End Property
    <Category("Data")>
    <DisplayName("Disabled")>
    Public Property Disabled As Boolean
        Get
            Return _disabled
        End Get
        Set(value As Boolean)
            _disabled = value
        End Set
    End Property
#End Region
#End Region
#Region "Clean Graphics"
#Region "-] Fill"
    Private Sub cgFillRectangle(g As Graphics, BrushColor As Color, Rect As Rectangle)
        Using Brush As New SolidBrush(BrushColor)
            g.FillRectangle(Brush, Rect)
        End Using
    End Sub
    Private Sub cgFillEllipse(g As Graphics, BrushColor As Color, Rect As Rectangle)
        Using Brush As New SolidBrush(BrushColor)
            g.FillEllipse(Brush, Rect)
        End Using
    End Sub
    Public Sub cgFillGradientBrush(g As Graphics, Rect As Rectangle, Color1 As Color, Color2 As Color, Angle As Single)
        Using GradientBrush As LinearGradientBrush = New LinearGradientBrush(Rect, Color1, Color2, Angle)
            g.FillRectangle(GradientBrush, Rect)
        End Using
    End Sub
    Public Sub cgFillPath(g As Graphics, BrushColor As Color, Path As GraphicsPath)
        Using Brush As New SolidBrush(BrushColor)
            g.FillPath(Brush, Path)
        End Using
    End Sub

#End Region
#Region "-] Draw"
    Private Sub cgDrawRectangle(g As Graphics, PenColor As Color, Rect As Rectangle)
        Using Pen As New Pen(PenColor)
            g.DrawRectangle(Pen, Rect)
        End Using
    End Sub
    Public Sub cgDrawLine(g As Graphics, Color As Color, StartPoint As Point, EndPoint As Point)
        Using Pen As New Pen(Color)
            g.DrawLine(Pen, StartPoint, EndPoint)
        End Using
    End Sub
    Public Sub cgDrawnString(g As Graphics, Str As String, Font As Font, Color As Color, Rect As Rectangle, strFormat As StringFormat)
        If Not Str = String.Empty Then
            Using Brush As New SolidBrush(Color)
                g.DrawString(Str, Font, Brush, Rect, strFormat)
            End Using
        End If
    End Sub
    Public Sub cgDrawnBitmap(g As Graphics, Bitmap As Image, Rect As Rectangle)
        If Not Bitmap Is Nothing Then
            Using Image As New Bitmap(Bitmap)
                g.DrawImage(Image, Rect)
            End Using
        End If
    End Sub
    Public Sub cgDrawnPath(g As Graphics, Color As Color, Path As GraphicsPath)
        Using Pen As New Pen(Color)
            g.DrawPath(Pen, Path)
        End Using
    End Sub
#End Region
#Region "-]Core"
#Region "Round Rectangle"
    Public Shared Function NTRound(rectangle As Rectangle, slope As Integer) As GraphicsPath
        Dim path = New GraphicsPath(FillMode.Winding)
        path.AddArc(rectangle.X - slope, rectangle.Y, slope, slope, 180.0F, 90.0F)
        path.AddArc(rectangle.Right, rectangle.Y, slope, slope, 270.0F, 90.0F)
        path.AddArc(rectangle.Right - slope, rectangle.Bottom - slope, slope, slope, 0.0F, 90.0F)
        path.AddArc(rectangle.X, rectangle.Bottom - slope, slope, slope, 90.0F, 90.0F)
        path.CloseFigure()
        Return path
    End Function
    Public Shared Function NRRound(rectangle As Rectangle, slope As Integer) As GraphicsPath
        Dim path = New GraphicsPath(FillMode.Winding)
        path.AddArc(rectangle.X, rectangle.Y, slope, slope, 180.0F, 90.0F)
        path.AddArc(rectangle.Right, rectangle.Y, 1, slope, 270.0F, 90.0F)

        path.AddArc(rectangle.Right, rectangle.Bottom, 1, slope, 0.0F, 90.0F)
        'Bottom Left
        path.AddArc(rectangle.X, rectangle.Bottom - slope, slope, slope, 90.0F, 90.0F)
        path.CloseFigure()
        Return path
    End Function
    Public Shared Function NLRound(rectangle As Rectangle, slope As Integer) As GraphicsPath
        Dim path = New GraphicsPath(FillMode.Winding)
        path.AddArc(rectangle.X, rectangle.Y, 1, slope, 180.0F, 90.0F)
        path.AddArc(rectangle.Right - slope, rectangle.Y, slope, slope, 270.0F, 90.0F)
        path.AddArc(rectangle.Right - slope, rectangle.Bottom - slope, slope, slope, 0.0F, 90.0F)

        path.AddArc(rectangle.X, rectangle.Bottom, 1, slope, 90.0F, 90.0F)
        path.CloseFigure()
        Return path
    End Function
    Public Shared Function NTRound(x As Integer, y As Integer, height As Integer, width As Integer, slope As Integer) As GraphicsPath
        Return Round(New Rectangle(x, y, height, width), slope)
    End Function

    Public Shared Function Round(rectangle As Rectangle, slope As Integer) As GraphicsPath
        Dim path = New GraphicsPath(FillMode.Winding)
        path.AddArc(rectangle.X, rectangle.Y, slope, slope, 180.0F, 90.0F)
        path.AddArc(rectangle.Right - slope, rectangle.Y, slope, slope, 270.0F, 90.0F)
        path.AddArc(rectangle.Right - slope, rectangle.Bottom - slope, slope, slope, 0.0F, 90.0F)
        path.AddArc(rectangle.X, rectangle.Bottom - slope, slope, slope, 90.0F, 90.0F)
        path.CloseFigure()
        Return path
    End Function
    Public Shared Function NBRound(rectangle As Rectangle, slope As Integer) As GraphicsPath
        Dim path = New GraphicsPath(FillMode.Winding)
        path.AddArc(rectangle.X, rectangle.Y, slope, slope, 180.0F, 90.0F)
        path.AddArc(rectangle.Right - slope, rectangle.Y, slope, slope, 270.0F, 90.0F)
        path.AddArc(rectangle.Right - slope, rectangle.Bottom, slope, slope, 0.0F, 90.0F)
        path.AddArc(rectangle.X, rectangle.Bottom + slope, slope, slope, 90.0F, 90.0F)
        path.CloseFigure()
        Return path
    End Function
    Public Shared Function Round(x As Integer, y As Integer, height As Integer, width As Integer, slope As Integer) As GraphicsPath
        Return Round(New Rectangle(x, y, height, width), slope)
    End Function
#End Region
#Region "FontFit"
    Public Function FontFit(GraphicRef As Graphics, GraphicString As String, OriginalFont As Font, ContainerWidth As Integer, MaxFontSize As Integer, MinFontSize As Integer,
    SmallestOnFail As Boolean) As Font
        Dim testFont As Font = Nothing
        ' We utilize MeasureString which we get via a control instance           
        For AdjustedSize As Integer = MaxFontSize To MinFontSize Step -1
            testFont = New Font(OriginalFont.Name, AdjustedSize, OriginalFont.Style)

            ' Test the string with the new size
            Dim AdjustedSizeNew As SizeF = GraphicRef.MeasureString(GraphicString, testFont)

            If ContainerWidth > Convert.ToInt32(AdjustedSizeNew.Width) Then
                ' Good font, return it
                Return testFont
            End If
        Next

        ' If you get here there was no fontsize that worked
        ' return MinimumSize or Original?
        If SmallestOnFail Then
            Return testFont
        Else
            Return OriginalFont
        End If
    End Function
#End Region
#End Region
#End Region
#Region "Mouse"
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If Not Disabled Then
            If New Rectangle(3, 3, CheckboxSize - 7, CheckboxSize - 7).Contains(e.X, e.Y) Then
                Cursor = Cursors.Hand
            Else
                Cursor = Cursors.Arrow
            End If
        Else
            Cursor = Cursors.Arrow
        End If
    End Sub
    Event CheckedChanged(checked As Boolean)
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If New Rectangle(3, 3, CheckboxSize - 7, CheckboxSize - 7).Contains(e.X, e.Y) Then
                Checked = Not Checked
                RaiseEvent CheckedChanged(Checked)
                Me.Refresh()
            End If
        End If
    End Sub
#End Region
#Region "Paint"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        g = e.Graphics
        g.SmoothingMode = _Quality
        If Quality = SmoothingMode.HighQuality Then
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        ElseIf Quality = SmoothingMode.HighSpeed Then
            g.InterpolationMode = InterpolationMode.Low
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        End If
        Me.Height = CheckboxSize
        If CheckboxSize > 9 Then
            If RoundedCorners = 0 Then
                If Not Disabled Then
                    cgDrawRectangle(g, OuterColor, New Rectangle(0, 0, CheckboxSize - 1, CheckboxSize - 1))
                    cgDrawRectangle(g, BorderColor, New Rectangle(1, 1, CheckboxSize - 3, CheckboxSize - 3))
                    cgDrawRectangle(g, InnerColor, New Rectangle(2, 2, CheckboxSize - 5, CheckboxSize - 5))
                    cgFillRectangle(g, BoxColor, New Rectangle(3, 3, CheckboxSize - 7, CheckboxSize - 7)) 'top mid New Point((CheckboxSize / 2), CheckboxSize - 12)
                    If Checked Then
                        If CheckboxSize > 25 Then
                            If Boxed Then
                                cgFillRectangle(g, CheckedColor, New Rectangle(4, 4, CheckboxSize - 9, CheckboxSize - 9))
                            Else
                                Dim points As PointF() = {New Point(CheckboxSize - 8, 5), New Point(CheckboxSize - 6, 8), New Point((CheckboxSize / 2), CheckboxSize - 6), New Point(5, (CheckboxSize / 2) + 2), New Point(8, (CheckboxSize / 2)), New Point((CheckboxSize / 2) - 1, CheckboxSize - 10), New Point(CheckboxSize - 8, 5)}
                                Using brushc As New SolidBrush(CheckedColor)
                                    g.FillPolygon(brushc, points)
                                End Using
                            End If
                        Else
                            cgFillRectangle(g, CheckedColor, New Rectangle(4, 4, CheckboxSize - 9, CheckboxSize - 9))
                        End If
                    End If
                    cgDrawnString(g, Text, Font, ForeColor, New Rectangle(CheckboxSize + 3, 0, Me.Width - CheckboxSize, Me.Height), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                Else
                    cgDrawRectangle(g, dOuterColor, New Rectangle(0, 0, CheckboxSize - 1, CheckboxSize - 1))
                    cgDrawRectangle(g, dborderColor, New Rectangle(1, 1, CheckboxSize - 3, CheckboxSize - 3))
                    cgDrawRectangle(g, dInnerColor, New Rectangle(2, 2, CheckboxSize - 5, CheckboxSize - 5))
                    cgFillRectangle(g, dBoxColor, New Rectangle(3, 3, CheckboxSize - 7, CheckboxSize - 7))
                    If Checked Then
                        If CheckboxSize > 25 Then
                            If Boxed Then
                                cgFillRectangle(g, dCheckedColor, New Rectangle(4, 4, CheckboxSize - 9, CheckboxSize - 9))
                            Else
                                Dim points As PointF() = {New Point(CheckboxSize - 8, 5), New Point(CheckboxSize - 6, 8), New Point((CheckboxSize / 2), CheckboxSize - 6), New Point(5, (CheckboxSize / 2) + 2), New Point(8, (CheckboxSize / 2)), New Point((CheckboxSize / 2) - 1, CheckboxSize - 10), New Point(CheckboxSize - 8, 5)}
                                Using brushc As New SolidBrush(dCheckedColor)
                                    g.FillPolygon(brushc, points)
                                End Using
                            End If
                        Else
                            cgFillRectangle(g, dCheckedColor, New Rectangle(4, 4, CheckboxSize - 9, CheckboxSize - 9))
                        End If
                    End If
                    cgDrawnString(g, Text, Font, dForeColor, New Rectangle(CheckboxSize + 3, 0, Me.Width - CheckboxSize, Me.Height), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                End If
            Else
                If Not Disabled Then
                    cgDrawnPath(g, OuterColor, Round(New Rectangle(0, 0, CheckboxSize - 1, CheckboxSize - 1), RoundedCorners))
                    cgDrawnPath(g, BorderColor, Round(New Rectangle(1, 1, CheckboxSize - 3, CheckboxSize - 3), RoundedCorners))
                    cgDrawnPath(g, InnerColor, Round(New Rectangle(2, 2, CheckboxSize - 5, CheckboxSize - 5), RoundedCorners))
                    cgFillPath(g, BoxColor, Round(New Rectangle(3, 3, CheckboxSize - 7, CheckboxSize - 7), RoundedCorners))
                    If Checked Then
                        If CheckboxSize > 25 Then
                            If Boxed Then
                                cgFillPath(g, CheckedColor, Round(New Rectangle(4, 4, CheckboxSize - 9, CheckboxSize - 9), RoundedCorners))
                            Else
                                Dim points As PointF() = {New Point(CheckboxSize - 8, 5), New Point(CheckboxSize - 6, 8), New Point((CheckboxSize / 2), CheckboxSize - 6), New Point(5, (CheckboxSize / 2) + 2), New Point(8, (CheckboxSize / 2)), New Point((CheckboxSize / 2) - 1, CheckboxSize - 10), New Point(CheckboxSize - 8, 5)}
                                Using brushc As New SolidBrush(CheckedColor)
                                    g.FillPolygon(brushc, points)
                                End Using
                            End If
                        Else
                            cgFillPath(g, CheckedColor, Round(New Rectangle(4, 4, CheckboxSize - 9, CheckboxSize - 9), RoundedCorners))
                        End If
                    End If
                    cgDrawnString(g, Text, Font, ForeColor, New Rectangle(CheckboxSize + 3, 0, Me.Width - CheckboxSize, Me.Height), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                Else
                    cgDrawnPath(g, dOuterColor, Round(New Rectangle(0, 0, CheckboxSize - 1, CheckboxSize - 1), RoundedCorners))
                    cgDrawnPath(g, dborderColor, Round(New Rectangle(1, 1, CheckboxSize - 3, CheckboxSize - 3), RoundedCorners))
                    cgDrawnPath(g, dInnerColor, Round(New Rectangle(2, 2, CheckboxSize - 5, CheckboxSize - 5), RoundedCorners))
                    cgFillPath(g, dBoxColor, Round(New Rectangle(3, 3, CheckboxSize - 7, CheckboxSize - 7), RoundedCorners))
                    If Checked Then
                        If CheckboxSize > 25 Then
                            If Boxed Then
                                cgFillPath(g, dCheckedColor, Round(New Rectangle(4, 4, CheckboxSize - 9, CheckboxSize - 9), RoundedCorners))
                            Else
                                Dim points As PointF() = {New Point(CheckboxSize - 8, 5), New Point(CheckboxSize - 6, 8), New Point((CheckboxSize / 2), CheckboxSize - 6), New Point(5, (CheckboxSize / 2) + 2), New Point(8, (CheckboxSize / 2)), New Point((CheckboxSize / 2) - 1, CheckboxSize - 10), New Point(CheckboxSize - 8, 5)}
                                Using brushc As New SolidBrush(dCheckedColor)
                                    g.FillPolygon(brushc, points)
                                End Using
                            End If
                        Else
                            cgFillPath(g, dCheckedColor, Round(New Rectangle(4, 4, CheckboxSize - 9, CheckboxSize - 9), RoundedCorners))
                        End If
                    End If
                    cgDrawnString(g, Text, Font, dForeColor, New Rectangle(CheckboxSize + 3, 0, Me.Width - CheckboxSize, Me.Height), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                End If
            End If
        Else
            cgDrawnString(g, "Checkbox Size is too small! To help provent errors you can't go smaller than 10!", Font, ForeColor, New Rectangle(0, 0, Me.Width, Me.Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End If
    End Sub
#End Region
End Class
