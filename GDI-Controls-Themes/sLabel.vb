Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class sLabel
    Inherits Control
    Private g As Graphics
#Region "Start"
    Sub New()
        ForeColor = Color.FromArgb(205, 63, 99)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
    End Sub
#End Region
#Region "Declarations"
    Private _Quality As SmoothingMode = SmoothingMode.HighQuality
    Private _bubbleColor As Color = Color.FromArgb(249, 242, 244)
    Private _bubble As Boolean = True
    Private _textAlignment As StringAlignment = StringAlignment.Near
    Private _textWrap As Boolean = True
    Private _fontFit As Boolean = False
    Private _roundedCorners As Integer = 8
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
    Property RoundedCorners() As Integer
        Get
            Return _roundedCorners
        End Get
        Set(ByVal value As Integer)
            _roundedCorners = value
        End Set
    End Property
    <Category("Appearance")>
    Property Bubble() As Boolean
        Get
            Return _bubble
        End Get
        Set(ByVal value As Boolean)
            _bubble = value
        End Set
    End Property
    <Category("Appearance")>
    Property TextWrap() As Boolean
        Get
            Return _textWrap
        End Get
        Set(ByVal value As Boolean)
            _textWrap = value
        End Set
    End Property
    <Category("Appearance")>
    Property FontFit() As Boolean
        Get
            Return _fontFit
        End Get
        Set(ByVal value As Boolean)
            _fontFit = value
        End Set
    End Property
    <Category("Appearance")>
    Property TextAlignment() As StringAlignment
        Get
            Return _textAlignment
        End Get
        Set(ByVal value As StringAlignment)
            _textAlignment = value
        End Set
    End Property
    <Category("Appearance")>
    Property BubbleColor() As Color
        Get
            Return _bubbleColor
        End Get
        Set(ByVal value As Color)
            _bubbleColor = value
        End Set
    End Property
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
    Public Function FontFitfun(GraphicRef As Graphics, GraphicString As String, OriginalFont As Font, ContainerWidth As Integer, MaxFontSize As Integer, MinFontSize As Integer,
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
#Region "Paint"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        g = e.Graphics
        g.SmoothingMode = Quality
        g.Clear(BackColor)
        If Quality = SmoothingMode.HighQuality Then
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        ElseIf Quality = SmoothingMode.HighSpeed Then
            g.InterpolationMode = InterpolationMode.Low
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        End If
        If RoundedCorners = 0 Then
            cgFillRectangle(g, BubbleColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
        Else
            cgFillPath(g, BubbleColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
        End If

        If TextWrap Then
            If FontFit Then
                cgDrawnString(g, Text, FontFitfun(g, Text, Font, Me.Width - 1, Font.Size, 6, True), ForeColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = TextAlignment, .FormatFlags = StringFormatFlags.NoWrap})
            Else
                cgDrawnString(g, Text, Font, ForeColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = TextAlignment, .FormatFlags = StringFormatFlags.NoWrap})
            End If
        Else
            If FontFit Then
                cgDrawnString(g, Text, FontFitfun(g, Text, Font, Me.Width - 1, Font.Size, 6, True), ForeColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = TextAlignment})
            Else
                cgDrawnString(g, Text, Font, ForeColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = TextAlignment})
            End If
        End If
    End Sub
#End Region
End Class
