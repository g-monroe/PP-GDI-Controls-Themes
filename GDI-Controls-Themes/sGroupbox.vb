Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class sGroupbox
    Inherits ContainerControl
    Private G As Graphics
#Region "Start"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.ContainerControl, True)
    End Sub
#End Region
#Region "Declarations"
    Private _Quality As SmoothingMode = SmoothingMode.AntiAlias
    '//Colors
    Private _borderColor As Color = Color.FromArgb(27, 37, 49)
    Private _containerColor As Color = Color.White
    Private _splitterColor As Color = Color.FromArgb(218, 218, 218)
    Private _splitterShadowColor As Color = Color.FromArgb(238, 238, 238)
    Private _splitterContainerColor As Color = Color.FromArgb(245, 245, 245)
    Private _headerSplitterColor As Color = Color.FromArgb(63, 71, 81)
    Private _headerSplitterShadowColor As Color = Color.FromArgb(136, 141, 147)
    Private _headerForeColor As Color = Color.White
    Private _headerColor As Color = Color.FromArgb(27, 37, 49)
    '//Integers
    Private _headerTitleSpacing As Integer = 5
    Private _headerImgSize As Integer = 24
    Private _headerHeight As Integer = 40
    Private _splitterHeight As Integer = 30
    Private _RoundedCorners As Integer = 12
    '//Strings
    Private _headerTitle As String = "Sarrow Groupbox"
    '//Objects
    Private _headerTitleFont As Font = New Font("Arial", 12, FontStyle.Regular)
    Private _headerTitleAlignment As New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    '//Bitmaps
    Private _headerImg As Image
    '//Booleans
    Private _headerIcon As Boolean = False
    Private _splitter As Boolean = False
    Private _headerShadow As Boolean = False
    Private _border As Boolean = True
#End Region
#Region "Properties"
#Region "-]Core"
    <Category("Appearance")>
    <DisplayName("Quality")>
    Public Property Quality As SmoothingMode
        Get
            Return _Quality
        End Get
        Set(value As SmoothingMode)
            _Quality = value
        End Set
    End Property
    <Category("Appearance")>
    <DisplayName("Rounded")>
    Public Property RoundedCorners As Integer
        Get
            Return _RoundedCorners
        End Get
        Set(value As Integer)
            _RoundedCorners = value
        End Set
    End Property
    <Category("Appearance")>
    <DisplayName("Border")>
    Public Property Border As Boolean
        Get
            Return _border
        End Get
        Set(value As Boolean)
            _border = value
        End Set
    End Property
#End Region
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
    <DisplayName("Back Color")>
    Public Property ContainerColor As Color
        Get
            Return _containerColor
        End Get
        Set(value As Color)
            _containerColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Splitter Color")>
    Public Property SplitterColor As Color
        Get
            Return _splitterColor
        End Get
        Set(value As Color)
            _splitterColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Splitter Shadow Color")>
    Public Property SplitterShadowColor As Color
        Get
            Return _splitterShadowColor
        End Get
        Set(value As Color)
            _splitterShadowColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Splitter back Color")>
    Public Property SplitterBackColor As Color
        Get
            Return _splitterContainerColor
        End Get
        Set(value As Color)
            _splitterContainerColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Header Splitter Color")>
    Public Property HeaderSplitterColor As Color
        Get
            Return _headerSplitterColor
        End Get
        Set(value As Color)
            _headerSplitterColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Header Splitter Shadow Color")>
    Public Property HeaderSplitterShadowColor As Color
        Get
            Return _headerSplitterShadowColor
        End Get
        Set(value As Color)
            _headerSplitterShadowColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Header Fore Color")>
    Public Property HeaderForeColor As Color
        Get
            Return _headerForeColor
        End Get
        Set(value As Color)
            _headerForeColor = value
        End Set
    End Property
    <Category("Colors")>
    <DisplayName("Header Back Color")>
    Public Property HeaderColor As Color
        Get
            Return _headerColor
        End Get
        Set(value As Color)
            _headerColor = value
        End Set
    End Property
#End Region
#Region "-]Integers"
    <Category("Header")>
    <DisplayName("Icon Size")>
    Public Property IconSize As Integer
        Get
            Return _headerImgSize
        End Get
        Set(value As Integer)
            _headerImgSize = value
        End Set
    End Property
    <Category("Header")>
    <DisplayName("Title Spacing")>
    Public Property TitleSpacing As Integer
        Get
            Return _headerTitleSpacing
        End Get
        Set(value As Integer)
            _headerTitleSpacing = value
        End Set
    End Property
    <Category("Header")>
    <DisplayName("Height")>
    Public Property HeaderHeight As Integer
        Get
            Return _headerHeight
        End Get
        Set(value As Integer)
            _headerHeight = value
        End Set
    End Property
    <Category("Splitter")>
    <DisplayName("Height")>
    Public Property SplitterHeight As Integer
        Get
            Return _splitterHeight
        End Get
        Set(value As Integer)
            _splitterHeight = value
        End Set
    End Property
#End Region
#Region "-]Bitmaps"
    <Category("Header")>
    <DisplayName("Icon")>
    Public Property Icon As Image
        Get
            Return _headerImg
        End Get
        Set(value As Image)
            _headerImg = value
        End Set
    End Property
#End Region
#Region "-]Strings"
    <Category("Header")>
    <DisplayName("Title")>
    Public Property HeaderTitle As String
        Get
            Return _headerTitle
        End Get
        Set(value As String)
            _headerTitle = value
        End Set
    End Property
#End Region
#Region "-]Objects"
    <Category("Header")>
    <DisplayName("Title Font")>
    Public Property HeaderTitleFont As Font
        Get
            Return _headerTitleFont
        End Get
        Set(value As Font)
            _headerTitleFont = value
        End Set
    End Property
    <Category("Header")>
    <DisplayName("Title Alignment")>
    Public Property HeaderTitleAlgin As StringFormat
        Get
            Return _headerTitleAlignment
        End Get
        Set(value As StringFormat)
            _headerTitleAlignment = value
        End Set
    End Property
#End Region
#Region "-]Booleans"
    <Category("Header")>
    <DisplayName("Icon Visible")>
    Public Property IconVisible As Boolean
        Get
            Return _headerIcon
        End Get
        Set(value As Boolean)
            _headerIcon = value
        End Set
    End Property
    <Category("Splitter")>
    <DisplayName("Visible")>
    Public Property SplitterVisible As Boolean
        Get
            Return _splitter
        End Get
        Set(value As Boolean)
            _splitter = value
        End Set
    End Property
    <Category("Header")>
    <DisplayName("Shadow Visible")>
    Public Property HeaderShadow As Boolean
        Get
            Return _headerShadow
        End Get
        Set(value As Boolean)
            _headerShadow = value
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
#End Region
#End Region
#Region "Paint"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        G = e.Graphics
        G.SmoothingMode = Quality
        G.Clear(BackColor)
        If Quality = SmoothingMode.HighQuality Then
            G.InterpolationMode = InterpolationMode.HighQualityBicubic
            G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        ElseIf Quality = SmoothingMode.HighSpeed Then
            G.InterpolationMode = InterpolationMode.Low
            G.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        End If
        If Not RoundedCorners = 0 Then
            cgFillPath(G, ContainerColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
            cgFillPath(G, HeaderColor, Round(New Rectangle(0, 0, Me.Width - 1, HeaderHeight), RoundedCorners + 1))
            cgFillRectangle(G, HeaderColor, New Rectangle(0, HeaderHeight - RoundedCorners, Me.Width - 1, RoundedCorners + 1))
            If HeaderShadow Then
                cgDrawLine(G, HeaderSplitterColor, New Point(0, HeaderHeight), New Point(Me.Width - 1, HeaderHeight))
                cgDrawLine(G, HeaderSplitterShadowColor, New Point(0, HeaderHeight + 1), New Point(Me.Width - 1, HeaderHeight + 1))
            End If
            Dim textspacin As Integer = TitleSpacing
            If IconVisible Then
                textspacin += (IconSize + ((HeaderHeight / 2) - (IconSize / 2)))
                cgDrawnBitmap(G, Icon, New Rectangle((HeaderHeight / 2) - (IconSize / 2), (HeaderHeight / 2) - (IconSize / 2), IconSize, IconSize))
            End If
            cgDrawnString(G, HeaderTitle, HeaderTitleFont, HeaderForeColor, New Rectangle(textspacin, (HeaderHeight / 2) - (G.MeasureString(HeaderTitle, HeaderTitleFont).Height / 2), Me.Width - (textspacin + 10), HeaderHeight), New StringFormat)
            If SplitterVisible Then
                cgFillPath(G, SplitterBackColor, NTRound(New Rectangle(0, Me.Height - (SplitterHeight + 1), Me.Width - 1, SplitterHeight), RoundedCorners))
                cgDrawLine(G, SplitterColor, New Point(0, Me.Height - (SplitterHeight)), New Point(Me.Width - 1, Me.Height - (SplitterHeight)))
                cgDrawLine(G, SplitterShadowColor, New Point(0, Me.Height - (SplitterHeight - 1)), New Point(Me.Width - 1, Me.Height - (SplitterHeight - 1)))
            End If
            If Border Then
                cgDrawnPath(G, BorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
            End If

        Else
            cgFillRectangle(G, ContainerColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
            cgFillRectangle(G, HeaderColor, New Rectangle(0, 0, Me.Width - 1, HeaderHeight))
            If HeaderShadow Then
                cgDrawLine(G, HeaderSplitterColor, New Point(0, HeaderHeight), New Point(Me.Width - 1, HeaderHeight))
                cgDrawLine(G, HeaderSplitterShadowColor, New Point(0, HeaderHeight + 1), New Point(Me.Width - 1, HeaderHeight + 1))
            End If
            Dim textspacin As Integer = TitleSpacing
            If IconVisible Then
                textspacin += (IconSize + ((HeaderHeight / 2) - (IconSize / 2)))
                cgDrawnBitmap(G, Icon, New Rectangle((HeaderHeight / 2) - (IconSize / 2), (HeaderHeight / 2) - (IconSize / 2), IconSize, IconSize))
            End If
            cgDrawnString(G, HeaderTitle, HeaderTitleFont, HeaderForeColor, New Rectangle(textspacin, (HeaderHeight / 2) - (G.MeasureString(HeaderTitle, HeaderTitleFont).Height / 2), Me.Width - (textspacin + 10), HeaderHeight), New StringFormat)
            If SplitterVisible Then
                cgFillRectangle(G, SplitterBackColor, New Rectangle(0, Me.Height - (SplitterHeight + 1), Me.Width - 1, SplitterHeight))
                cgDrawLine(G, SplitterColor, New Point(0, Me.Height - (SplitterHeight)), New Point(Me.Width - 1, Me.Height - (SplitterHeight)))
                cgDrawLine(G, SplitterShadowColor, New Point(0, Me.Height - (SplitterHeight - 1)), New Point(Me.Width - 1, Me.Height - (SplitterHeight - 1)))
            End If
            If Border Then
                cgDrawRectangle(G, BorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
            End If

        End If

    End Sub
#End Region
End Class
