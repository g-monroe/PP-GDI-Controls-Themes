Imports System.ComponentModel
Imports System.Drawing.Drawing2D
<DefaultEvent("ButtonClicked")>
Public Class sButton
    Inherits Control
    Private G As Graphics
#Region "Start"
    Sub New()
        Font = New Font("Microsoft Sans Serif", 11, FontStyle.Regular)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
    End Sub
#End Region
#Region "Declarations"
    Event ButtonClicked(Checked As Boolean)
    '//Core
    Private _Quality As SmoothingMode = SmoothingMode.HighQuality
    Private _roundedCorners As Integer = 8
    Private _checked As Boolean = False
    Private _checkedVisiable As Boolean = False
    Private _imgSize As Integer = 24
    Private _imgSpacing As Integer = 5
    Private _fontFit As Boolean = False

    Dim hovered As Boolean = False
    Dim clicked As Boolean = False
    Dim lwidth As Integer = 0
    Dim rwidth As Integer = 0
    '//Normal
    Private _normalBorderColor As Color = Color.FromArgb(58, 129, 186)
    Private _normalFillColor As Color = Color.FromArgb(71, 142, 199)
    Private _normalForeColor As Color = Color.White
    Private _normalDividerColor As Color = Color.FromArgb(10, 54, 102)
    Private _normalDivider As Boolean = False
    Private _normalImage As Image
    Private _normalImg As Boolean = False
    Private _normalText As String = "Button"
    Private _normalFont As Font = Font
    Private _normalToggleColor As Color = Color.FromArgb(66, 139, 202)
    Private _normalToggleBackColor As Color = Color.White
    Private _normalToggleBorderColor As Color = Color.FromArgb(177, 207, 233)
    '//Hover
    Private _hoverBorderColor As Color = Color.FromArgb(40, 94, 142)
    Private _hoverFillColor As Color = Color.FromArgb(48, 113, 169)
    Private _hoverForeColor As Color = Color.White
    Private _hoverDividerColor As Color = Color.FromArgb(10, 54, 102)
    Private _hoverDivider As Boolean = False
    Private _hoverImage As Image
    Private _hoverImg As Boolean = False
    Private _hoverText As String = "Button"
    Private _hoverFont As Font = Font
    Private _hoverToggleColor As Color = Color.FromArgb(66, 139, 202)
    Private _hoverToggleBackColor As Color = Color.White
    Private _hoverToggleBorderColor As Color = Color.FromArgb(177, 207, 233)
    '//Clicked
    Private _clickedBorderColor As Color = Color.FromArgb(53, 116, 167)
    Private _clickedFillColor As Color = Color.FromArgb(44, 96, 140)
    Private _clickedForeColor As Color = Color.White
    Private _clickedDividerColor As Color = Color.FromArgb(10, 54, 102)
    Private _clickedDivider As Boolean = False
    Private _clickedImage As Image
    Private _clickedImg As Boolean = False
    Private _clickedText As String = "Button"
    Private _clickedFont As Font = Font
    Private _clickedShadow As Boolean = True
    Private _clickedShadowColor As Color = Color.FromArgb(60, 20, 20, 20)
    Private _clickedToggleColor As Color = Color.FromArgb(66, 139, 202)
    Private _clickedToggleBackColor As Color = Color.White
    Private _clickedToggleBorderColor As Color = Color.FromArgb(177, 207, 233)
    '//Text
    Private _textAlignment As StringAlignment = StringAlignment.Center
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
    Property FontFit() As Boolean
        Get
            Return _fontFit
        End Get
        Set(ByVal value As Boolean)
            _fontFit = value
        End Set
    End Property
    <Category("Appearance")>
    Property ImageSize() As Integer
        Get
            Return _imgSize
        End Get
        Set(ByVal value As Integer)
            _imgSize = value
        End Set
    End Property
    <Category("Appearance")>
    Property ImageSpacing() As Integer
        Get
            Return _imgSpacing
        End Get
        Set(ByVal value As Integer)
            _imgSpacing = value
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
    Property TextAlignment() As StringAlignment
        Get
            Return _textAlignment
        End Get
        Set(ByVal value As StringAlignment)
            _textAlignment = value
        End Set
    End Property
    <Category("Appearance")>
    Property Checked() As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            _checked = value
        End Set
    End Property
    <Category("Appearance")>
    Property CheckedVisiable() As Boolean
        Get
            Return _checkedVisiable
        End Get
        Set(ByVal value As Boolean)
            _checkedVisiable = value
        End Set
    End Property
#Region "Normal"
    <Category("Normal")>
    <DisplayName("Toggle Color")>
    Property nToggleColor() As Color
        Get
            Return _normalToggleColor
        End Get
        Set(ByVal value As Color)
            _normalToggleColor = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Toggle Back Color")>
    Property nToggleBackColor() As Color
        Get
            Return _normalToggleBackColor
        End Get
        Set(ByVal value As Color)
            _normalToggleBackColor = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Toggle Border Color")>
    Property nToggleBorderColor() As Color
        Get
            Return _normalToggleBorderColor
        End Get
        Set(ByVal value As Color)
            _normalToggleBorderColor = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Border Color")>
    Property nBorderColor() As Color
        Get
            Return _normalBorderColor
        End Get
        Set(ByVal value As Color)
            _normalBorderColor = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Fill Color")>
    Property nFillColor() As Color
        Get
            Return _normalFillColor
        End Get
        Set(ByVal value As Color)
            _normalFillColor = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Fore Color")>
    Property nForeColor() As Color
        Get
            Return _normalForeColor
        End Get
        Set(ByVal value As Color)
            _normalForeColor = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Divider Color")>
    Property nDividerColor() As Color
        Get
            Return _normalDividerColor
        End Get
        Set(ByVal value As Color)
            _normalDividerColor = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Divider")>
    Property nDivider() As Boolean
        Get
            Return _normalDivider
        End Get
        Set(ByVal value As Boolean)
            _normalDivider = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Image Visiable")>
    Property nImageV() As Boolean
        Get
            Return _normalImg
        End Get
        Set(ByVal value As Boolean)
            _normalImg = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Image")>
    Property nImage() As Image
        Get
            Return _normalImage
        End Get
        Set(ByVal value As Image)
            _normalImage = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Font")>
    Property nFont() As Font
        Get
            Return _normalFont
        End Get
        Set(ByVal value As Font)
            _normalFont = value
        End Set
    End Property
    <Category("Normal")>
    <DisplayName("Text")>
    Property nText() As String
        Get
            Return _normalText
        End Get
        Set(ByVal value As String)
            _normalText = value
        End Set
    End Property
#End Region
#Region "Hover"
    <Category("Hover")>
    <DisplayName("Toggle Color")>
    Property hToggleColor() As Color
        Get
            Return _hoverToggleColor
        End Get
        Set(ByVal value As Color)
            _hoverToggleColor = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Toggle Back Color")>
    Property hToggleBackColor() As Color
        Get
            Return _hoverToggleBackColor
        End Get
        Set(ByVal value As Color)
            _hoverToggleBackColor = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Toggle Border Color")>
    Property hToggleBorderColor() As Color
        Get
            Return _hoverToggleBorderColor
        End Get
        Set(ByVal value As Color)
            _hoverToggleBorderColor = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Border Color")>
    Property hBorderColor() As Color
        Get
            Return _hoverBorderColor
        End Get
        Set(ByVal value As Color)
            _hoverBorderColor = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Fill Color")>
    Property hFillColor() As Color
        Get
            Return _hoverFillColor
        End Get
        Set(ByVal value As Color)
            _hoverFillColor = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Fore Color")>
    Property hForeColor() As Color
        Get
            Return _hoverForeColor
        End Get
        Set(ByVal value As Color)
            _hoverForeColor = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Divider Color")>
    Property hDividerColor() As Color
        Get
            Return _hoverDividerColor
        End Get
        Set(ByVal value As Color)
            _hoverDividerColor = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Divider")>
    Property hDivider() As Boolean
        Get
            Return _hoverDivider
        End Get
        Set(ByVal value As Boolean)
            _hoverDivider = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Image Visiable")>
    Property hImageV() As Boolean
        Get
            Return _hoverImg
        End Get
        Set(ByVal value As Boolean)
            _hoverImg = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Image")>
    Property hImage() As Image
        Get
            Return _hoverImage
        End Get
        Set(ByVal value As Image)
            _hoverImage = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Font")>
    Property hFont() As Font
        Get
            Return _hoverFont
        End Get
        Set(ByVal value As Font)
            _hoverFont = value
        End Set
    End Property
    <Category("Hover")>
    <DisplayName("Text")>
    Property hText() As String
        Get
            Return _hoverText
        End Get
        Set(ByVal value As String)
            _hoverText = value
        End Set
    End Property
#End Region
#Region "Clicked"
    <Category("Clicked")>
    <DisplayName("Shadow Color")>
    Property cShadowColor() As Color
        Get
            Return _clickedShadowColor
        End Get
        Set(ByVal value As Color)
            _clickedShadowColor = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Toggle Color")>
    Property cToggleColor() As Color
        Get
            Return _clickedToggleColor
        End Get
        Set(ByVal value As Color)
            _clickedToggleColor = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Toggle Back Color")>
    Property cToggleBackColor() As Color
        Get
            Return _clickedToggleBackColor
        End Get
        Set(ByVal value As Color)
            _clickedToggleBackColor = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Toggle Border Color")>
    Property cToggleBorderColor() As Color
        Get
            Return _clickedToggleBorderColor
        End Get
        Set(ByVal value As Color)
            _clickedToggleBorderColor = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Border Color")>
    Property cBorderColor() As Color
        Get
            Return _clickedBorderColor
        End Get
        Set(ByVal value As Color)
            _clickedBorderColor = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Fill Color")>
    Property cFillColor() As Color
        Get
            Return _clickedFillColor
        End Get
        Set(ByVal value As Color)
            _clickedFillColor = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Fore Color")>
    Property cForeColor() As Color
        Get
            Return _clickedForeColor
        End Get
        Set(ByVal value As Color)
            _clickedForeColor = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Divider Color")>
    Property cDividerColor() As Color
        Get
            Return _clickedDividerColor
        End Get
        Set(ByVal value As Color)
            _clickedDividerColor = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Shadow")>
    Property cShadow() As Boolean
        Get
            Return _clickedShadow
        End Get
        Set(ByVal value As Boolean)
            _clickedShadow = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Divider")>
    Property cDivider() As Boolean
        Get
            Return _clickedDivider
        End Get
        Set(ByVal value As Boolean)
            _clickedDivider = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Image Visiable")>
    Property cImageV() As Boolean
        Get
            Return _clickedImg
        End Get
        Set(ByVal value As Boolean)
            _clickedImg = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Image")>
    Property cImage() As Image
        Get
            Return _clickedImage
        End Get
        Set(ByVal value As Image)
            _clickedImage = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Font")>
    Property cFont() As Font
        Get
            Return _clickedFont
        End Get
        Set(ByVal value As Font)
            _clickedFont = value
        End Set
    End Property
    <Category("Clicked")>
    <DisplayName("Text")>
    Property cText() As String
        Get
            Return _clickedText
        End Get
        Set(ByVal value As String)
            _clickedText = value
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
#Region "Mouse"
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If New Rectangle(1, 1, Me.Width - 3, Me.Height - 3).Contains(e.X, e.Y) Then
            hovered = True
            Cursor = Cursors.Hand
            Me.Refresh()
        Else
            hovered = False
            Cursor = Cursors.Arrow
            Me.Refresh()
        End If
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        hovered = False
        clicked = False
        Me.Refresh()
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            clicked = True
            Me.Refresh()
        End If
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If hovered Then
                clicked = False
                Checked = Not Checked
                RaiseEvent ButtonClicked(Checked)
                Me.Refresh()
            End If
        End If
    End Sub
#End Region
#Region "Paint"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        G = e.Graphics
        G.SmoothingMode = Quality
        G.Clear(BackColor)
        lwidth = 3
        rwidth = 3
        If Quality = SmoothingMode.HighQuality Then
            G.InterpolationMode = InterpolationMode.HighQualityBicubic
            G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        ElseIf Quality = SmoothingMode.HighSpeed Then
            G.InterpolationMode = InterpolationMode.Low
            G.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        End If
        If Not RoundedCorners = 0 Then
            If Not hovered And Not clicked Then
                ForeColor = nForeColor
                cgFillPath(G, nFillColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
                If CheckedVisiable Then
                    rwidth = 24 + ImageSpacing
                    cgFillPath(G, nToggleBackColor, Round(New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16), RoundedCorners))
                    cgDrawnPath(G, nToggleBorderColor, Round(New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16), RoundedCorners))
                    If Checked Then
                        cgDrawnString(G, "✓", New Font("Arail", 10, FontStyle.Bold), nToggleColor, New Rectangle((Me.Width - ImageSpacing) - 22, (Me.Height / 2) - 7, 24, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If nDivider Then
                    If nImageV Then
                        lwidth += ImageSpacing + ImageSize
                        cgFillPath(G, nDividerColor, NRRound(New Rectangle(0, 0, lwidth, Me.Height - 1), RoundedCorners))
                        cgDrawLine(G, nBorderColor, New Point(lwidth + 1, 0), New Point(lwidth + 1, Me.Height - 1))
                        cgDrawnBitmap(G, nImage, New Rectangle(ImageSpacing, ImageSpacing, ImageSize, ImageSize))
                    End If
                End If
                cgDrawnPath(G, nBorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                If FontFit Then
                    cgDrawnString(G, nText, FontFitfun(G, nText, nFont, (Me.Width) - (lwidth + rwidth), 72, 8, True), nForeColor, New Rectangle(lwidth, 2, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                Else
                    cgDrawnString(G, nText, nFont, nForeColor, New Rectangle(lwidth, 0, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                End If
            ElseIf hovered And Not clicked Then
                ForeColor = hForeColor
                cgFillPath(G, hFillColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
                If CheckedVisiable Then
                    rwidth = 24 + ImageSpacing
                    cgFillPath(G, hToggleBackColor, Round(New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16), RoundedCorners))
                    cgDrawnPath(G, hToggleBorderColor, Round(New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16), RoundedCorners))
                    If Checked Then
                        cgDrawnString(G, "✓", New Font("Arail", 10, FontStyle.Regular), hToggleColor, New Rectangle((Me.Width - ImageSpacing) - 22, (Me.Height / 2) - 7, 24, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If hDivider Then
                    If hImageV Then
                        lwidth += ImageSpacing + ImageSize
                        cgFillPath(G, hDividerColor, NRRound(New Rectangle(0, 0, lwidth, Me.Height - 1), RoundedCorners))
                        cgDrawLine(G, hBorderColor, New Point(lwidth + 1, 0), New Point(lwidth + 1, Me.Height - 1))
                        cgDrawnBitmap(G, hImage, New Rectangle(ImageSpacing, ImageSpacing, ImageSize, ImageSize))
                    End If
                End If
                cgDrawnPath(G, hBorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                If FontFit Then
                    cgDrawnString(G, hText, FontFitfun(G, hText, hFont, (Me.Width) - (lwidth + rwidth), 72, 8, True), hForeColor, New Rectangle(lwidth, 2, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                Else
                    cgDrawnString(G, hText, hFont, hForeColor, New Rectangle(lwidth, 0, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                End If
            ElseIf hovered And clicked Then
                ForeColor = cForeColor
                cgFillPath(G, cFillColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
                If CheckedVisiable Then
                    rwidth = 24 + ImageSpacing
                    cgFillPath(G, cToggleBackColor, Round(New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16), RoundedCorners))
                    cgDrawnPath(G, cToggleBorderColor, Round(New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16), RoundedCorners))
                    If Checked Then
                        cgDrawnString(G, "✓", New Font("Arail", 10, FontStyle.Regular), cToggleColor, New Rectangle((Me.Width - ImageSpacing) - 22, (Me.Height / 2) - 7, 24, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If hDivider Then
                    If hImageV Then
                        lwidth += ImageSpacing + ImageSize
                        cgFillPath(G, cDividerColor, NRRound(New Rectangle(0, 0, lwidth, Me.Height - 1), RoundedCorners))
                        cgDrawLine(G, cBorderColor, New Point(lwidth + 1, 0), New Point(lwidth + 1, Me.Height - 1))
                        cgDrawnBitmap(G, cImage, New Rectangle(ImageSpacing, ImageSpacing, ImageSize, ImageSize))
                    End If
                End If
                cgDrawnPath(G, cBorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                If FontFit Then
                    cgDrawnString(G, cText, FontFitfun(G, hText, hFont, (Me.Width) - (lwidth + rwidth), 72, 8, True), cForeColor, New Rectangle(lwidth, 2, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                Else
                    cgDrawnString(G, cText, cFont, cForeColor, New Rectangle(lwidth, 0, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                End If
                If cShadow Then
                    Using lgb As LinearGradientBrush = New LinearGradientBrush(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), cShadowColor, Color.Transparent, 90.0!)
                        G.FillPath(lgb, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                    End Using
                End If
            End If
        Else
            If Not hovered And Not clicked Then
                ForeColor = nForeColor
                cgFillRectangle(G, nFillColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If CheckedVisiable Then
                    rwidth = 24 + ImageSpacing
                    cgFillRectangle(G, nToggleBackColor, New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16))
                    cgDrawRectangle(G, nToggleBorderColor, New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16))
                    If Checked Then
                        cgDrawnString(G, "✓", New Font("Arail", 10, FontStyle.Regular), nToggleColor, New Rectangle((Me.Width - ImageSpacing) - 22, (Me.Height / 2) - 7, 24, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If nDivider Then
                    If nImageV Then
                        lwidth += ImageSpacing + ImageSize
                        cgFillRectangle(G, nDividerColor, New Rectangle(0, 0, lwidth, Me.Height - 1))
                        cgDrawLine(G, nBorderColor, New Point(lwidth + 1, 0), New Point(lwidth + 1, Me.Height - 1))
                        cgDrawnBitmap(G, nImage, New Rectangle(ImageSpacing, ImageSpacing, ImageSize, ImageSize))
                    End If
                End If
                cgDrawRectangle(G, nBorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If FontFit Then
                    cgDrawnString(G, nText, FontFitfun(G, nText, nFont, (Me.Width) - (lwidth + rwidth), 72, 8, True), nForeColor, New Rectangle(lwidth, 2, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                Else
                    cgDrawnString(G, nText, nFont, nForeColor, New Rectangle(lwidth, 0, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                End If
            ElseIf hovered And Not clicked Then
                ForeColor = hForeColor
                cgFillRectangle(G, hFillColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If CheckedVisiable Then
                    rwidth = 24 + ImageSpacing
                    cgFillRectangle(G, hToggleBackColor, New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16))
                    cgDrawRectangle(G, hToggleBorderColor, New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16))
                    If Checked Then
                        cgDrawnString(G, "✓", New Font("Arail", 10, FontStyle.Regular), hToggleColor, New Rectangle((Me.Width - ImageSpacing) - 22, (Me.Height / 2) - 7, 24, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If hDivider Then
                    If hImageV Then
                        lwidth += ImageSpacing + ImageSize
                        cgFillRectangle(G, hDividerColor, New Rectangle(0, 0, lwidth, Me.Height - 1))
                        cgDrawLine(G, hBorderColor, New Point(lwidth + 1, 0), New Point(lwidth + 1, Me.Height - 1))
                        cgDrawnBitmap(G, hImage, New Rectangle(ImageSpacing, ImageSpacing, ImageSize, ImageSize))
                    End If
                End If
                cgDrawRectangle(G, hBorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If FontFit Then
                    cgDrawnString(G, hText, FontFitfun(G, hText, hFont, (Me.Width) - (lwidth + rwidth), 72, 8, True), hForeColor, New Rectangle(lwidth, 2, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                Else
                    cgDrawnString(G, hText, hFont, hForeColor, New Rectangle(lwidth, 0, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                End If
            ElseIf hovered And clicked Then
                ForeColor = cForeColor
                cgFillRectangle(G, cFillColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If CheckedVisiable Then
                    rwidth = 24 + ImageSpacing
                    cgFillRectangle(G, cToggleBackColor, New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16))
                    cgDrawRectangle(G, cToggleBorderColor, New Rectangle((Me.Width - ImageSpacing) - 24, (Me.Height / 2) - 8, 24, 16))
                    If Checked Then
                        cgDrawnString(G, "✓", New Font("Arail", 10, FontStyle.Regular), cToggleColor, New Rectangle((Me.Width - ImageSpacing) - 22, (Me.Height / 2) - 7, 24, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If hDivider Then
                    If hImageV Then
                        lwidth += ImageSpacing + ImageSize
                        cgFillRectangle(G, cDividerColor, New Rectangle(0, 0, lwidth, Me.Height - 1))
                        cgDrawLine(G, cBorderColor, New Point(lwidth + 1, 0), New Point(lwidth + 1, Me.Height - 1))
                        cgDrawnBitmap(G, cImage, New Rectangle(ImageSpacing, ImageSpacing, ImageSize, ImageSize))
                    End If
                End If
                cgDrawRectangle(G, cBorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If FontFit Then
                    cgDrawnString(G, cText, FontFitfun(G, hText, hFont, (Me.Width) - (lwidth + rwidth), 72, 8, True), cForeColor, New Rectangle(lwidth, 2, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                Else
                    cgDrawnString(G, cText, cFont, cForeColor, New Rectangle(lwidth, 0, (Me.Width) - (lwidth + rwidth), Me.Height - 1), New StringFormat With {.Alignment = TextAlignment, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
                End If
                If cShadow Then
                    Using lgb As LinearGradientBrush = New LinearGradientBrush(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), cShadowColor, Color.Transparent, 90.0!)
                        G.FillRectangle(lgb, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                    End Using
                End If
            End If
        End If
    End Sub
#End Region
End Class
