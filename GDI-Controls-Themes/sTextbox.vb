Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
'<Credit to Earn(1997450) for the Base/Structure of this Class>
Public Class sTextbox
    Inherits Control
    Private G As Graphics
#Region "Start"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        T = New TextBox
        T.Font = New Font("Segoe UI", 12)
        T.Text = Text
        T.BackColor = Color.White
        T.ForeColor = Color.Gray
        T.MaxLength = L
        T.Multiline = ML
        T.ReadOnly = R
        T.UseSystemPasswordChar = Pw
        T.BorderStyle = BorderStyle.None
        T.Cursor = Cursors.IBeam
        If ML Then
            T.Height = Height - 1
        Else
            Height = T.Height + 1
        End If
        AddHandler T.TextChanged, AddressOf OnBasetxtChanged
        AddHandler T.KeyDown, AddressOf OnBaseKeyDown
        Font = New Font("Segoe UI", 12)
    End Sub
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(T) Then
            Controls.Add(T)
        End If
    End Sub
#End Region
#Region "Declarations"
    Private H As Integer = 52
    Private D As Boolean = False
    Private P As Point
    Private A As Alignment = Alignment.Left
    Private S As MouseState = MouseState.None
    Private WithEvents T As TextBox
    Private L As Integer = 32767
    Private R As Boolean
    Private Pw As Boolean
    Private ML As Boolean

    Event TypeChange(Data As String, Type As _Type)

    Private regularBackColor As Color = Color.White
    Private regularColor As Color = Color.FromArgb(173, 175, 175)
    Private _regularFontColor As Color = Color.FromArgb(82, 77, 94)
    Private errorColor As Color = Color.FromArgb(240, 94, 97)
    Private errorBackColor As Color = Color.White
    Private _errorFontColor As Color = Color.FromArgb(82, 77, 94)
    Private warningColor As Color = Color.FromArgb(248, 185, 70)
    Private warningBackColor As Color = Color.White
    Private _warningFontColor As Color = Color.FromArgb(82, 77, 94)
    Private acceptColor As Color = Color.FromArgb(146, 188, 100)
    Private acceptBackColor As Color = Color.White
    Private _AcceptFontColor As Color = Color.FromArgb(82, 77, 94)
    Private _customColor As Color = Color.FromArgb(45, 51, 73)
    Private _customBackColor As Color = Color.White
    Private _customFontColor As Color = Color.FromArgb(82, 77, 94)
    Private _shadowBorderColor As Color = Color.FromArgb(205, 205, 215)

    Private _shadowBorder As Boolean = False
    Private _ldividerVisible As Boolean = False
    Private _rdividerVisible As Boolean = False

    Private lbtntxtcolor As Color = Color.FromArgb(82, 77, 94)
    Private rbtntxtcolor As Color = Color.FromArgb(82, 77, 94)
    Private txtboxtxtColor As Color = Color.FromArgb(174, 175, 175)
    Private txtboxBackColor As Color = Color.White

    Private _lbtnBackColor As Color = Color.White
    Private _rbtnBackColor As Color = Color.White
    Private _rHoverbtnBackColor As Color = Color.FromArgb(60, Color.Gray)
    Private _lHoverbtnBackColor As Color = Color.FromArgb(60, Color.Gray)

    Private Kind As _Type = _Type.Regular
    Private ErrorTrig As TriggerType = TriggerType.Disable
    Private errorStr As String = "0"
    Private WarningTrig As TriggerType = TriggerType.Disable
    Private warningStr As String = "0"
    Private AcceptTrig As TriggerType = TriggerType.Disable
    Private AcceptStr As String = "Example"
    Private CustomTrig As TriggerType = TriggerType.Disable
    Private CustomStr As String = "@gmail.com"


    Dim lbtnhover As Boolean = False
    Dim rbtnhover As Boolean = False
    Dim lbtnclick As Boolean = False
    Dim rbtnclick As Boolean = False
    Private _lbtnClickable As Boolean = False
    Private _rbtnClickable As Boolean = False

    Private lbtn As Boolean = False
    Private rbtn As Boolean = False
    Private _lbtntxt As String = "$"
    Private _lbtnFont As Font = New Font("Arial", 10, FontStyle.Bold)
    Private _rbtntxt As String = ".00"
    Private _rbtnFont As Font = New Font("Arial", 10, FontStyle.Bold)
    Private _lbtnimg As Image
    Private _lbtnimgbool As Boolean
    Private _lbtnimgsize As Integer = 24
    Private _rbtnimg As Image
    Private _rbtnimgbool As Boolean
    Private _rbtnimgsize As Integer = 24
    Dim lbtnwidth As Integer
    Dim rbtnwidth As Integer
#End Region
#Region "Properties"
#Region " Enums "
    Enum MouseState
        None = 0
        Over = 1
        Down = 2
    End Enum
    Enum TriggerType
        OverInt = 0
        UnderInt = 1
        ContainStr = 2
        notContainStr = 3
        Ints = 4
        NoInts = 6
        Disable = 8
    End Enum
    Enum _Type
        Regular
        _Error
        Warning
        Accepted
        Custom
    End Enum
    Enum Alignment
        Left = 0
        Centre = 1
        Right = 2
    End Enum

    Enum State
        Enabled = 0
        Disabled = 1
    End Enum
#End Region
#Region "-]TextBox Properties"

#Region " Appearance "

    <Category("Appearance")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return A
        End Get
        Set(ByVal value As HorizontalAlignment)
            A = value
            If T IsNot Nothing Then
                T.TextAlign = value
            End If
        End Set
    End Property

    <Category("Appearance")>
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If T IsNot Nothing Then
                T.Text = value
            End If
        End Set
    End Property
    <Category("Appearance")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If T IsNot Nothing Then
                T.Font = value
                '   T.Location = New Point(3, 5)
                T.Width = Width - 6

                If Not ML Then
                    Height = T.Height + 11
                End If
            End If
        End Set
    End Property

#End Region
#Region " Behaviour "

    <Category("Behavior")>
    Property MaxLength() As Integer
        Get
            Return L
        End Get
        Set(ByVal value As Integer)
            L = value
            If T IsNot Nothing Then
                T.MaxLength = value
            End If
        End Set
    End Property

    <Category("Behavior")>
    Property [ReadOnly]() As Boolean
        Get
            Return R
        End Get
        Set(ByVal value As Boolean)
            R = value
            If T IsNot Nothing Then
                T.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Behavior")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return Pw
        End Get
        Set(ByVal value As Boolean)
            Pw = value
            If T IsNot Nothing Then
                T.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    <Category("Behavior")>
    Property Multiline() As Boolean
        Get
            Return ML
        End Get
        Set(ByVal value As Boolean)
            ML = value
            If T IsNot Nothing Then
                T.Multiline = value

                If value Then
                    T.Height = Height - 11
                Else
                    Height = T.Height + 11
                End If

            End If
        End Set
    End Property


#End Region
#End Region
#Region "Colors"
#Region "-]Type Colors"
    <Category("Colors")>
    Property ShadowBorderColor() As Color
        Get
            Return _shadowBorderColor
        End Get
        Set(ByVal value As Color)
            _shadowBorderColor = value
        End Set
    End Property
    <Category("Colors")>
    Property ShadowBorder() As Boolean
        Get
            Return _shadowBorder
        End Get
        Set(ByVal value As Boolean)
            _shadowBorder = value
        End Set
    End Property
    <Category("Colors")>
    Property _Error() As Color
        Get
            Return errorColor
        End Get
        Set(ByVal value As Color)
            errorColor = value
        End Set
    End Property
    <Category("Colors")>
    Property ErrorBack() As Color
        Get
            Return errorBackColor
        End Get
        Set(ByVal value As Color)
            errorBackColor = value
        End Set
    End Property
    <Category("Colors")>
    Property ErrorFontColor() As Color
        Get
            Return _errorFontColor
        End Get
        Set(ByVal value As Color)
            _errorFontColor = value
        End Set
    End Property
    <Category("Colors")>
    Property Warning() As Color
        Get
            Return warningColor
        End Get
        Set(ByVal value As Color)
            warningColor = value
        End Set
    End Property
    <Category("Colors")>
    Property WarningFontColor() As Color
        Get
            Return _warningFontColor
        End Get
        Set(ByVal value As Color)
            _warningFontColor = value
        End Set
    End Property
    <Category("Colors")>
    Property WarningBack() As Color
        Get
            Return warningBackColor
        End Get
        Set(ByVal value As Color)
            warningBackColor = value
        End Set
    End Property
    <Category("Colors")>
    Property Accept() As Color
        Get
            Return acceptColor
        End Get
        Set(ByVal value As Color)
            acceptColor = value
        End Set
    End Property
    <Category("Colors")>
    Property AcceptBack() As Color
        Get
            Return acceptBackColor
        End Get
        Set(ByVal value As Color)
            acceptBackColor = value
        End Set
    End Property
    <Category("Colors")>
    Property AcceptFontColor() As Color
        Get
            Return _AcceptFontColor
        End Get
        Set(ByVal value As Color)
            _AcceptFontColor = value
        End Set
    End Property
    <Category("Colors")>
    Property Regular() As Color
        Get
            Return regularColor
        End Get
        Set(ByVal value As Color)
            regularColor = value
        End Set
    End Property
    <Category("Colors")>
    Property Regularback() As Color
        Get
            Return regularBackColor
        End Get
        Set(ByVal value As Color)
            regularBackColor = value
        End Set
    End Property
    <Category("Colors")>
    Property CustomFontColor() As Color
        Get
            Return _customFontColor
        End Get
        Set(ByVal value As Color)
            _customFontColor = value
        End Set
    End Property
    <Category("Colors")>
    Property CustomBackColor() As Color
        Get
            Return _customBackColor
        End Get
        Set(ByVal value As Color)
            _customBackColor = value
        End Set
    End Property
    <Category("Colors")>
    Property CustomColor() As Color
        Get
            Return _customColor
        End Get
        Set(ByVal value As Color)
            _customColor = value
        End Set
    End Property
    <Category("Colors")>
    Property LeftButtonText() As Color
        Get
            Return lbtntxtcolor
        End Get
        Set(ByVal value As Color)
            lbtntxtcolor = value
        End Set
    End Property
    <Category("Colors")>
    Property RightButtonText() As Color
        Get
            Return rbtntxtcolor
        End Get
        Set(ByVal value As Color)
            rbtntxtcolor = value
        End Set
    End Property
    <Category("Colors")>
    Property TextColor() As Color
        Get
            Return txtboxtxtColor
        End Get
        Set(ByVal value As Color)
            txtboxtxtColor = value
            If T IsNot Nothing Then
                T.ForeColor = txtboxtxtColor
            End If
        End Set
    End Property
    <Category("Colors")>
    Property TextBackColor() As Color
        Get
            Return txtboxBackColor
        End Get
        Set(ByVal value As Color)
            txtboxBackColor = value
            If T IsNot Nothing Then
                T.BackColor = txtboxBackColor
            End If
        End Set
    End Property
#End Region
#End Region
#Region "Buttons"
#Region "-] Left"
    <Category("Left Button")>
    <DisplayName("Visible")>
    Property LeftButton() As Boolean
        Get
            Return lbtn
        End Get
        Set(ByVal value As Boolean)
            lbtn = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("Clickable")>
    Property LeftButtonClickable() As Boolean
        Get
            Return _lbtnClickable
        End Get
        Set(ByVal value As Boolean)
            _lbtnClickable = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("Divider Visible")>
    Property LeftDivider() As Boolean
        Get
            Return _ldividerVisible
        End Get
        Set(ByVal value As Boolean)
            _ldividerVisible = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("Font")>
    Property LeftButtonFont() As Font
        Get
            Return _lbtnFont
        End Get
        Set(ByVal value As Font)
            _lbtnFont = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("Image Size")>
    Property LeftButtonSize() As Integer
        Get
            Return _lbtnimgsize
        End Get
        Set(ByVal value As Integer)
            _lbtnimgsize = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("Image")>
    Property LeftButtonImage() As Image
        Get
            Return _lbtnimg
        End Get
        Set(ByVal value As Image)
            _lbtnimg = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("Image Visible")>
    Property LeftButtonImageToggled() As Boolean
        Get
            Return _lbtnimgbool
        End Get
        Set(ByVal value As Boolean)
            _lbtnimgbool = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("Text")>
    Property lButtonText() As String
        Get
            Return _lbtntxt
        End Get
        Set(ByVal value As String)
            _lbtntxt = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("Text Color")>
    Property lButtonTextColor() As Color
        Get
            Return lbtntxtcolor
        End Get
        Set(ByVal value As Color)
            lbtntxtcolor = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("BackColor")>
    Property lButtonBackColor() As Color
        Get
            Return _lbtnBackColor
        End Get
        Set(ByVal value As Color)
            _lbtnBackColor = value
        End Set
    End Property
    <Category("Left Button")>
    <DisplayName("Hover Color")>
    Property lHoverButtonBackColor() As Color
        Get
            Return _lHoverbtnBackColor
        End Get
        Set(ByVal value As Color)
            _lHoverbtnBackColor = value
        End Set
    End Property
#End Region
#Region "-]Right"
    <Category("Right Button")>
    <DisplayName("Image Size")>
    Property RightButtonSize() As Integer
        Get
            Return _rbtnimgsize
        End Get
        Set(ByVal value As Integer)
            _rbtnimgsize = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Clickable")>
    Property RightButtonClickable() As Boolean
        Get
            Return _rbtnClickable
        End Get
        Set(ByVal value As Boolean)
            _rbtnClickable = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Divider Visible")>
    Property RightDivider() As Boolean
        Get
            Return _rdividerVisible
        End Get
        Set(ByVal value As Boolean)
            _rdividerVisible = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Image")>
    Property RightButtonImage() As Image
        Get
            Return _rbtnimg
        End Get
        Set(ByVal value As Image)
            _rbtnimg = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Font")>
    Property RightButtonFont() As Font
        Get
            Return _rbtnFont
        End Get
        Set(ByVal value As Font)
            _rbtnFont = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Image Visible")>
    Property RightButtonImageToggled() As Boolean
        Get
            Return _rbtnimgbool
        End Get
        Set(ByVal value As Boolean)
            _rbtnimgbool = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Visible")>
    Property RightButton() As Boolean
        Get
            Return rbtn
        End Get
        Set(ByVal value As Boolean)
            rbtn = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Text")>
    Property rButtonText() As String
        Get
            Return _rbtntxt
        End Get
        Set(ByVal value As String)
            _rbtntxt = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Text Color")>
    Property rButtonTextColor() As Color
        Get
            Return rbtntxtcolor
        End Get
        Set(ByVal value As Color)
            rbtntxtcolor = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Back Color")>
    Property rButtonBackColor() As Color
        Get
            Return _rbtnBackColor
        End Get
        Set(ByVal value As Color)
            _rbtnBackColor = value
        End Set
    End Property
    <Category("Right Button")>
    <DisplayName("Hover Color")>
    Property rHoverButtonBackColor() As Color
        Get
            Return _rHoverbtnBackColor
        End Get
        Set(ByVal value As Color)
            _rHoverbtnBackColor = value
        End Set
    End Property
#End Region

#End Region
#Region "Type Triggers"
    <Category("Triggers")>
    Property ErrorTrigger() As TriggerType
        Get
            Return ErrorTrig
        End Get
        Set(ByVal value As TriggerType)
            ErrorTrig = value
        End Set
    End Property
    <Category("Triggers")>
    <DisplayName("ErrorTrig Detail")>
    Property ErrorTriggerDetail() As String
        Get
            Return errorStr
        End Get
        Set(ByVal value As String)
            errorStr = value
        End Set
    End Property
    <Category("Triggers")>
    Property WarningTrigger() As TriggerType
        Get
            Return WarningTrig
        End Get
        Set(ByVal value As TriggerType)
            WarningTrig = value
        End Set
    End Property
    <Category("Triggers")>
    <DisplayName("WarningTrig Detail")>
    Property WarningTriggerDetail() As String
        Get
            Return warningStr
        End Get
        Set(ByVal value As String)
            warningStr = value
        End Set
    End Property
    <Category("Triggers")>
    Property AcceptTrigger() As TriggerType
        Get
            Return AcceptTrig
        End Get
        Set(ByVal value As TriggerType)
            AcceptTrig = value
        End Set
    End Property
    <Category("Triggers")>
    <DisplayName("AcceptTrig Detail")>
    Property AcceptTriggerDetail() As String
        Get
            Return AcceptStr
        End Get
        Set(ByVal value As String)
            AcceptStr = value
        End Set
    End Property
    <Category("Triggers")>
    Property CustomTrigger() As TriggerType
        Get
            Return CustomTrig
        End Get
        Set(ByVal value As TriggerType)
            CustomTrig = value
        End Set
    End Property
    <Category("Triggers")>
    <DisplayName("CustomTrig Detail")>
    Property CustomTriggerDetail() As String
        Get
            Return CustomStr
        End Get
        Set(ByVal value As String)
            CustomStr = value
        End Set
    End Property
    <Category("Triggers")>
    Property Type() As _Type
        Get
            Return Kind
        End Get
        Set(ByVal value As _Type)
            Kind = value
        End Set
    End Property

#End Region
#Region "Misc"
    Private RoundCorner As Integer = 8
    <Category("Appearance")>
    Property RoundCorners() As Integer
        Get
            Return RoundCorner
        End Get
        Set(ByVal value As Integer)
            RoundCorner = value
        End Set
    End Property
    Private _Quality As SmoothingMode = SmoothingMode.HighQuality
    <Category("Appearance")>
    Property Quality() As SmoothingMode
        Get
            Return _Quality
        End Get
        Set(ByVal value As SmoothingMode)
            _Quality = value
        End Set
    End Property
#End Region
#End Region
#Region "Textbox Helper"
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

    Public Shared Function Round(x As Integer, y As Integer, height As Integer, width As Integer, slope As Integer) As GraphicsPath
        Return Round(New Rectangle(x, y, height, width), slope)
    End Function
#End Region
#Region "Painting/Drawing"
    Public Sub Drawbtns(type As _Type)
        If Not RoundCorner = 0 Then
            If type = _Type.Regular Then
#Region "Regular Draw btns"
                Dim i As Integer = 0
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If ShadowBorder Then
                        cgDrawnPath(G, ShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundCorners - 1))
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, rButtonText, RightButtonFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 0, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If ShadowBorder Then
                    cgDrawnPath(G, ShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundCorners - 1))
                End If
                If lbtn Then
                    If LeftDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(lbtnwidth + 1, 0), New Point(lbtnwidth + 1, Me.Height - 1))
                        End If
                        cgDrawLine(G, regularColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If RightDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(Me.Width - (rbtnwidth + 1), 1), New Point(Me.Width - (rbtnwidth + 1), Me.Height - 2))
                        End If
                        cgDrawLine(G, regularColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            ElseIf type = _Type._Error Then
#Region "Error Draw btns"
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, rButtonText, _rbtnFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 2, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If ShadowBorder Then
                    cgDrawnPath(G, ShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundCorners - 1))
                End If
                If lbtn Then
                    If LeftDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(lbtnwidth + 1, 0), New Point(lbtnwidth + 1, Me.Height - 1))
                        End If
                        cgDrawLine(G, errorColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If RightDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(Me.Width - (rbtnwidth + 1), 1), New Point(Me.Width - (rbtnwidth + 1), Me.Height - 2))
                        End If
                        cgDrawLine(G, errorColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            ElseIf type = _Type.Accepted Then
#Region "Accept Draw btns"
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, rButtonText, RightButtonFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 2, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If ShadowBorder Then
                    cgDrawnPath(G, ShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundCorners - 1))
                End If
                If lbtn Then
                    If LeftDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(lbtnwidth + 1, 0), New Point(lbtnwidth + 1, Me.Height - 1))
                        End If
                        cgDrawLine(G, acceptColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If RightDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(Me.Width - (rbtnwidth + 1), 1), New Point(Me.Width - (rbtnwidth + 1), Me.Height - 2))
                        End If
                        cgDrawLine(G, acceptColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            ElseIf type = _Type.Warning Then
#Region "Warning Draw btns"
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, rButtonText, RightButtonFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 0, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If ShadowBorder Then
                    cgDrawnPath(G, ShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundCorners - 1))
                End If
                If lbtn Then
                    If LeftDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(lbtnwidth + 1, 0), New Point(lbtnwidth + 1, Me.Height - 1))
                        End If
                        cgDrawLine(G, warningColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If RightDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(Me.Width - (rbtnwidth + 1), 1), New Point(Me.Width - (rbtnwidth + 1), Me.Height - 2))
                        End If
                        cgDrawLine(G, warningColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            ElseIf type = _Type.Custom Then
#Region "Custom Draw btns"
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillPath(G, lButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If lbtnhover And Not lbtnclick Then
                            cgFillPath(G, lHoverButtonBackColor, NRRound(New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillPath(G, rButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        If rbtnhover And Not rbtnclick Then
                            cgFillPath(G, rHoverButtonBackColor, NLRound(New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1), RoundCorners))
                        End If
                        cgDrawnString(G, rButtonText, RightButtonFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 0, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                End If
                If ShadowBorder Then
                    cgDrawnPath(G, ShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundCorners - 1))
                End If
                If lbtn Then
                    If LeftDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(lbtnwidth + 1, 0), New Point(lbtnwidth + 1, Me.Height - 1))
                        End If
                        cgDrawLine(G, CustomColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If RightDivider Then
                        If ShadowBorder Then
                            cgDrawLine(G, ShadowBorderColor, New Point(Me.Width - (rbtnwidth + 1), 1), New Point(Me.Width - (rbtnwidth + 1), Me.Height - 2))
                        End If
                        cgDrawLine(G, CustomColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            End If
        Else
            If type = _Type.Regular Then
#Region "Regular Draw btns"
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If LeftDivider Then
                        cgDrawLine(G, regularColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, rButtonText, RightButtonFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 0, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If RightDivider Then
                        cgDrawLine(G, regularColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            ElseIf type = _Type._Error Then
#Region "Error Draw btns"
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If LeftDivider Then
                        cgDrawLine(G, errorColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, rButtonText, _rbtnFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 2, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If RightDivider Then
                        cgDrawLine(G, errorColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            ElseIf type = _Type.Accepted Then
#Region "Accept Draw btns"
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If LeftDivider Then
                        cgDrawLine(G, acceptColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, rButtonText, RightButtonFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 2, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If RightDivider Then
                        cgDrawLine(G, acceptColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            ElseIf type = _Type.Warning Then
#Region "Warning Draw btns"
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If LeftDivider Then
                        cgDrawLine(G, warningColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, rButtonText, RightButtonFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 0, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If RightDivider Then
                        cgDrawLine(G, warningColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            ElseIf type = _Type.Custom Then
#Region "Custom Draw btns"
                If lbtn Then
                    If _lbtnimgbool Then
                        lbtnwidth += _lbtnimgsize + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _lbtnimg, New Rectangle(5, (Me.Height / 2) - (_lbtnimgsize / 2), _lbtnimgsize, _lbtnimgsize))
                    Else
                        lbtnwidth += G.MeasureString(lButtonText, LeftButtonFont).Width + 10
                        cgFillRectangle(G, lButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        If lbtnhover And Not lbtnclick Then
                            cgFillRectangle(G, lHoverButtonBackColor, New Rectangle(0, 0, lbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, lButtonText, LeftButtonFont, lbtntxtcolor, New Rectangle(2, 0, lbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If LeftDivider Then
                        cgDrawLine(G, CustomColor, New Point(lbtnwidth, 0), New Point(lbtnwidth, Me.Height - 1))
                    End If
                End If
                If rbtn Then
                    If _rbtnimgbool Then
                        rbtnwidth += _rbtnimgsize + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnBitmap(G, _rbtnimg, New Rectangle(Me.Width - (rbtnwidth - 5), (Me.Height / 2) - (_rbtnimgsize / 2), _rbtnimgsize, _rbtnimgsize))
                    Else
                        rbtnwidth += G.MeasureString(rButtonText, RightButtonFont).Width + 10
                        cgFillRectangle(G, rButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        If rbtnhover And Not rbtnclick Then
                            cgFillRectangle(G, rHoverButtonBackColor, New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth - 1, Me.Height - 1))
                        End If
                        cgDrawnString(G, rButtonText, RightButtonFont, rbtntxtcolor, New Rectangle(Me.Width - (rbtnwidth - 2), 0, rbtnwidth - 3, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    End If
                    If RightDivider Then
                        cgDrawLine(G, CustomColor, New Point(Me.Width - rbtnwidth, 0), New Point(Me.Width - rbtnwidth, Me.Height - 1))
                    End If
                End If
#End Region
            End If
        End If
    End Sub
#End Region
#Region "Functions/Subs"
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        T.Location = New Point(7 + lbtnwidth, 5)
        T.Width = Width - (14 + lbtnwidth)

        If ML Then
            T.Height = Height - 11
        Else
            Height = T.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub
    Private Sub OnBasetxtChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = T.Text
    End Sub
    Private Sub T_txtChanged(sender As Object, e As EventArgs) Handles T.TextChanged
        Type = CheckTriggers()
        RaiseEvent TypeChange(T.Text, Type)
        Me.Refresh()
    End Sub
    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            T.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            T.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub
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
#End Region
#Region "Trigger Events"
    Private Function CheckTriggers() As _Type
        'Specific Naming Triggers
        If Not ErrorTrigger = TriggerType.Disable Then
            Select Case ErrorTrigger
                Case TriggerType.ContainStr
                    If T.Text.Contains(errorStr) Then
                        Return _Type._Error
                    End If
                Case TriggerType.notContainStr
                    If Not T.Text.Contains(errorStr) Then
                        Return _Type._Error
                    End If
            End Select
        End If
        If Not WarningTrigger = TriggerType.Disable Then
            Select Case WarningTrigger
                Case TriggerType.ContainStr
                    If T.Text.Contains(warningStr) Then
                        Return _Type.Warning
                    End If
                Case TriggerType.notContainStr
                    If Not T.Text.Contains(warningStr) Then
                        Return _Type.Warning
                    End If
            End Select
        End If
        If Not AcceptTrigger = TriggerType.Disable Then
            Select Case AcceptTrigger
                Case TriggerType.ContainStr
                    If T.Text.Contains(AcceptStr) Then
                        Return _Type.Accepted
                    End If
                Case TriggerType.notContainStr
                    If Not T.Text.Contains(AcceptStr) Then
                        Return _Type.Accepted
                    End If
            End Select
        End If
        If Not CustomTrigger = TriggerType.Disable Then
            Select Case CustomTrigger
                Case TriggerType.ContainStr
                    If T.Text.Contains(CustomStr) Then
                        Return _Type.Custom
                    End If
                Case TriggerType.notContainStr
                    If Not T.Text.Contains(CustomStr) Then
                        Return _Type.Custom
                    End If
            End Select
        End If
        'Move on To the Length Test Trigger
        If Not ErrorTrigger = TriggerType.Disable Then
            Select Case ErrorTrigger
                Case TriggerType.OverInt
                    If T.Text.Length > Convert.ToInt32(errorStr) Then
                        Return _Type._Error
                    End If
                Case TriggerType.UnderInt
                    If T.Text.Length < Convert.ToInt32(errorStr) Then
                        Return _Type._Error
                    End If
                Case TriggerType.Ints
                    If Regex.IsMatch(T.Text, "^[0-9 ]+$") Then
                        Return _Type._Error
                    End If
                Case TriggerType.NoInts
                    If Not Regex.IsMatch(T.Text, "^[0-9 ]+$") Then
                        Return _Type._Error
                    End If
            End Select
        End If
        If Not WarningTrigger = TriggerType.Disable Then
            Select Case WarningTrigger
                Case TriggerType.OverInt
                    If T.Text.Length > Convert.ToInt32(warningStr) Then
                        Return _Type.Warning
                    End If
                Case TriggerType.UnderInt
                    If T.Text.Length < Convert.ToInt32(warningStr) Then
                        Return _Type.Warning
                    End If
                Case TriggerType.Ints
                    If Regex.IsMatch(T.Text, "^[0-9 ]+$") Then
                        Return _Type.Warning
                    End If
                Case TriggerType.NoInts
                    If Not Regex.IsMatch(T.Text, "^[0-9 ]+$") Then
                        Return _Type.Warning
                    End If
            End Select
        End If
        If Not AcceptTrigger = TriggerType.Disable Then
            Select Case AcceptTrigger
                Case TriggerType.OverInt
                    If T.Text.Length > Convert.ToInt32(AcceptStr) Then
                        Return _Type.Accepted
                    End If
                Case TriggerType.UnderInt
                    If T.Text.Length < Convert.ToInt32(AcceptStr) Then
                        Return _Type.Accepted
                    End If
                Case TriggerType.Ints
                    If Regex.IsMatch(T.Text, "^[0-9 ]+$") Then
                        Return _Type.Accepted
                    End If
                Case TriggerType.NoInts
                    If Not Regex.IsMatch(T.Text, "^[0-9 ]+$") Then
                        Return _Type.Accepted
                    End If
            End Select
        End If
        If Not CustomTrigger = TriggerType.Disable Then
            Select Case CustomTrigger
                Case TriggerType.OverInt
                    If T.Text.Length > Convert.ToInt32(CustomStr) Then
                        Return _Type.Custom
                    End If
                Case TriggerType.UnderInt
                    If T.Text.Length < Convert.ToInt32(CustomStr) Then
                        Return _Type.Custom
                    End If
                Case TriggerType.Ints
                    If Regex.IsMatch(T.Text, "^[0-9 ]+$") Then
                        Return _Type.Custom
                    End If
                Case TriggerType.NoInts
                    If Not Regex.IsMatch(T.Text, "^[0-9 ]+$") Then
                        Return _Type.Custom
                    End If
            End Select
        End If
        Return _Type.Regular
    End Function
#End Region
#Region "Mouse Input"
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If LeftButtonClickable Then
            If lbtn Then
                If New Rectangle(0, 0, lbtnwidth, Me.Height - 1).Contains(e.X, e.Y) Then
                    lbtnhover = True
                    Me.Refresh()
                Else
                    lbtnhover = False
                    Me.Refresh()
                End If
            End If
        End If
        If RightButtonClickable Then
            If rbtn Then
                If New Rectangle(Me.Width - (rbtnwidth), 0, rbtnwidth, Me.Height - 1).Contains(e.X, e.Y) Then
                    rbtnhover = True
                    Me.Refresh()
                Else
                    rbtnhover = False
                    Me.Refresh()
                End If
            End If
        End If
        If lbtnhover Or rbtnhover Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        lbtnhover = False
        rbtnhover = False
        Cursor = Cursors.Arrow
        Me.Refresh()
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If lbtnclick = False And lbtnhover Then
                lbtnclick = True
                Me.Refresh()
            End If
            If rbtnclick = False And rbtnhover Then
                rbtnclick = True
                Me.Refresh()
            End If
        End If
    End Sub
    Event LeftbtnClicked(Type As _Type, data As String)
    Event RightbtnClicked(Type As _Type, data As String)
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If rbtnclick Then
                RaiseEvent RightbtnClicked(Kind, T.Text)
                rbtnclick = False
            End If
            If lbtnclick Then
                RaiseEvent LeftbtnClicked(Kind, T.Text)
                lbtnclick = False
            End If
            rbtnclick = False
        End If
    End Sub
#End Region
#Region " Paint "
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        G = e.Graphics
        G.SmoothingMode = Quality
        lbtnwidth = 0
        rbtnwidth = 0
        If Quality = SmoothingMode.HighQuality Then
            G.InterpolationMode = InterpolationMode.HighQualityBicubic
            G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        ElseIf Quality = SmoothingMode.HighSpeed Then
            G.InterpolationMode = InterpolationMode.Low
            G.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        End If
        If Not RoundCorner = 0 Then
            If Type = _Type.Regular Then
                TextColor = regularColor
                cgFillPath(G, regularBackColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners + 1))
                Drawbtns(_Type.Regular)
                cgDrawnPath(G, regularColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners))
            ElseIf Type = _Type.Accepted Then
                TextColor = AcceptFontColor
                cgFillPath(G, acceptBackColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners + 1))
                Drawbtns(_Type.Accepted)
                cgDrawnPath(G, acceptColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners))
            ElseIf Type = _Type.Warning Then
                TextColor = WarningFontColor
                cgFillPath(G, warningBackColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners + 1))
                Drawbtns(_Type.Warning)
                cgDrawnPath(G, warningColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners))
            ElseIf Type = _Type._Error Then
                TextColor = ErrorFontColor
                cgFillPath(G, errorBackColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners + 1))
                Drawbtns(_Type._Error)
                cgDrawnPath(G, errorColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners))
            ElseIf Type = _Type.Custom Then
                TextColor = CustomFontColor
                cgFillPath(G, CustomBackColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners + 1))
                Drawbtns(_Type.Custom)
                cgDrawnPath(G, CustomColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundCorners))
            End If
        Else
            If Type = _Type.Regular Then
                TextColor = regularColor
                cgFillRectangle(G, regularBackColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                Drawbtns(_Type.Regular)
                cgDrawRectangle(G, regularColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If ShadowBorder Then
                    cgDrawRectangle(G, ShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                End If
            ElseIf Type = _Type.Accepted Then
                TextColor = AcceptFontColor
                cgFillRectangle(G, acceptBackColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                Drawbtns(_Type.Accepted)
                cgDrawRectangle(G, acceptColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If ShadowBorder Then
                    cgDrawRectangle(G, ShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                End If
            ElseIf Type = _Type.Warning Then
                TextColor = WarningFontColor
                cgFillRectangle(G, warningBackColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                Drawbtns(_Type.Warning)
                cgDrawRectangle(G, warningColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If ShadowBorder Then
                    cgDrawRectangle(G, ShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                End If
            ElseIf Type = _Type._Error Then
                TextColor = ErrorFontColor
                cgFillRectangle(G, errorBackColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                Drawbtns(_Type._Error)
                cgDrawRectangle(G, errorColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If ShadowBorder Then
                    cgDrawRectangle(G, ShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                End If
            ElseIf Type = _Type.Custom Then
                TextColor = CustomFontColor
                cgFillRectangle(G, CustomBackColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                Drawbtns(_Type.Custom)
                cgDrawRectangle(G, CustomColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If ShadowBorder Then
                    cgDrawRectangle(G, ShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                End If
            End If
        End If
        T.Location = New Point(7 + lbtnwidth, 5)
        T.Width = Width - (12 + lbtnwidth + rbtnwidth)
    End Sub
#End Region
End Class
