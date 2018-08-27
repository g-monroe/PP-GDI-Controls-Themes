Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class sNotification
    Inherits Control
    Private g As Graphics 'Graphics for Control.
#Region "Start"
    Sub New()
        Me.Size = New Size(120, 40)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
    End Sub
#End Region
#Region "Declarations"
#Region "-]Core"
    Private _Quality As SmoothingMode = SmoothingMode.AntiAlias
    Private _Type As Types = Types.Custom
    Private _RoundedCorners As Integer = 8
    Private CloseHover As Boolean = False
    Enum Types
        Custom = 0
        Success = 1
        Info = 2
        Error_ = 3
        Warning = 4
        Coffee = 5
    End Enum
#End Region
#Region "-]Colors"
#Region "-|-]Custom Note"
    Private _customBorderColor As Color = Color.FromArgb(229, 225, 229)
    Private _customFillColor As Color = Color.FromArgb(255, 255, 255)
    Private _customHeaderColor As Color = Color.FromArgb(81, 83, 85)
    Private _customTextColor As Color = Color.FromArgb(80, 80, 80)
    Private _customDividerColor As Color = Color.FromArgb(235, 235, 235)
    Private _customCloseColor As Color = Color.FromArgb(204, 204, 204)
    Private _customCloseHoverColor As Color = Color.FromArgb(104, 104, 104)
    Private _customShadowBorderColor As Color = Color.FromArgb(231, 234, 236)
#End Region
#Region "-|-]Success Note"
    Private _successBorderColor As Color = Color.FromArgb(111, 161, 56)
    Private _successFillColor As Color = Color.FromArgb(118, 171, 60)
    Private _successHeaderColor As Color = Color.White
    Private _successTextColor As Color = Color.White
    Private _successDividerColor As Color = Color.FromArgb(111, 161, 56)
    Private _successCloseColor As Color = Color.FromArgb(145, 187, 99)
    Private _successCloseHoverColor As Color = Color.FromArgb(105, 147, 69)
    Private _successShadowBorderColor As Color = Color.FromArgb(145, 187, 99)
#End Region
#Region "-|-]Info Note"
    Private _infoBorderColor As Color = Color.FromArgb(66, 176, 219)
    Private _infoFillColor As Color = Color.FromArgb(79, 181, 221)
    Private _infoHeaderColor As Color = Color.White
    Private _infoTextColor As Color = Color.White
    Private _infoDividerColor As Color = Color.FromArgb(66, 176, 219)
    Private _infoCloseColor As Color = Color.FromArgb(114, 195, 227)
    Private _infoCloseHoverColor As Color = Color.FromArgb(74, 155, 187)
    Private _infoShadowBorderColor As Color = Color.FromArgb(114, 195, 227)
#End Region
#Region "-|-]Error Note"
    Private _errorBorderColor As Color = Color.FromArgb(239, 64, 67)
    Private _errorFillColor As Color = Color.FromArgb(240, 78, 81)
    Private _errorHeaderColor As Color = Color.White
    Private _errorTextColor As Color = Color.White
    Private _errorDividerColor As Color = Color.FromArgb(239, 64, 67)
    Private _errorCloseColor As Color = Color.FromArgb(243, 113, 115)
    Private _errorCloseHoverColor As Color = Color.White
    Private _errorShadowBorderColor As Color = Color.FromArgb(243, 113, 115)
#End Region
#Region "-|-]Warning Note"
    Private _warningBorderColor As Color = Color.FromArgb(231, 149, 0)
    Private _warningFillColor As Color = Color.FromArgb(246, 159, 0)
    Private _warningHeaderColor As Color = Color.White
    Private _warningTextColor As Color = Color.White
    Private _warningDividerColor As Color = Color.FromArgb(231, 149, 0)
    Private _warningCloseColor As Color = Color.FromArgb(247, 178, 51)
    Private _warningCloseHoverColor As Color = Color.White
    Private _warningShadowBorderColor As Color = Color.FromArgb(247, 178, 51)
#End Region
#Region "-|-]Coffee Note"
    Private _coffeeBorderColor As Color = Color.FromArgb(35, 40, 57)
    Private _coffeeFillColor As Color = Color.FromArgb(41, 47, 67)
    Private _coffeeHeaderColor As Color = Color.White
    Private _coffeeTextColor As Color = Color.White
    Private _coffeeDividerColor As Color = Color.FromArgb(35, 40, 57)
    Private _coffeeCloseColor As Color = Color.FromArgb(83, 88, 104)
    Private _coffeeCloseHoverColor As Color = Color.White
    Private _coffeeShadowBorderColor As Color = Color.FromArgb(83, 88, 104)
#End Region
#End Region
#Region "-]Strings"
#Region "-|-]Custom Note"
    Private _customHeader As String = "Default!"
    Private _customText As String = "This is a custom Notecation!"
#End Region
#Region "-|-]Success Note"
    Private _successHeader As String = "Success!"
    Private _successText As String = "This is a custom Notecation!"
#End Region
#Region "-|-]Info Note"
    Private _infoHeader As String = "Info!"
    Private _infoText As String = "This is a custom Notecation!"
#End Region
#Region "-|-]Error Note"
    Private _errorHeader As String = "Error!"
    Private _errorText As String = "This is a custom Notecation!"
#End Region
#Region "-|-]Warning Note"
    Private _warningHeader As String = "Warning!"
    Private _warningText As String = "This is a custom Notecation!"
#End Region
#Region "-|-]Coffee Note"
    Private _coffeeHeader As String = "Coffee!"
    Private _coffeeText As String = "This is a custom Notecation!"
#End Region
#End Region
#Region "-]Fonts"
#Region "-|-]Custom Note"
    Private _customHeaderFont As Font = New Font("Arial", 12, FontStyle.Bold)
    Private _customTextFont As Font = New Font("Arial", 12, FontStyle.Regular)
#End Region
#Region "-|-]Success Note"
    Private _successHeaderFont As Font = New Font("Arial", 12, FontStyle.Bold)
    Private _successTextFont As Font = New Font("Arial", 12, FontStyle.Regular)
#End Region
#Region "-|-]Info Note"
    Private _infoHeaderFont As Font = New Font("Arial", 12, FontStyle.Bold)
    Private _infoTextFont As Font = New Font("Arial", 12, FontStyle.Regular)
#End Region
#Region "-|-]Error Note"
    Private _errorHeaderFont As Font = New Font("Arial", 12, FontStyle.Bold)
    Private _errorTextFont As Font = New Font("Arial", 12, FontStyle.Regular)
#End Region
#Region "-|-]Warning Note"
    Private _warningHeaderFont As Font = New Font("Arial", 12, FontStyle.Bold)
    Private _warningTextFont As Font = New Font("Arial", 12, FontStyle.Regular)
#End Region
#Region "-|-]Coffee Note"
    Private _coffeeHeaderFont As Font = New Font("Arial", 12, FontStyle.Bold)
    Private _coffeeTextFont As Font = New Font("Arial", 12, FontStyle.Regular)
#End Region
#End Region
#Region "-]Booleans"
#Region "-|-]Custom Note"
    Private _customClose As Boolean = False
    Private _customIconVisible As Boolean = False
    Private _customDividerVisible As Boolean = False
#End Region
#Region "-|-]Success Note"
    Private _successClose As Boolean = False
    Private _successIconVisible As Boolean = False
    Private _successDividerVisible As Boolean = False
#End Region
#Region "-|-]Info Note"
    Private _infoClose As Boolean = False
    Private _infoIconVisible As Boolean = False
    Private _infoDividerVisible As Boolean = False
#End Region
#Region "-|-]Error Note"
    Private _errorClose As Boolean = False
    Private _errorIconVisible As Boolean = False
    Private _errorDividerVisible As Boolean = False
#End Region
#Region "-|-]Warning Note"
    Private _warningClose As Boolean = False
    Private _warningIconVisible As Boolean = False
    Private _warningDividerVisible As Boolean = False
#End Region
#Region "-|-]Coffee Note"
    Private _coffeeClose As Boolean = False
    Private _coffeeIconVisible As Boolean = False
    Private _coffeeDividerVisible As Boolean = False
#End Region
#End Region
#Region "-]Bitmaps"
#Region "-|-]Custom Note"
    Private _customIcon As Image
#End Region
#Region "-|-]Success Note"
    Private _successIcon As Image
#End Region
#Region "-|-]Info Note"
    Private _infoIcon As Image
#End Region
#Region "-|-]Error Note"
    Private _errorIcon As Image
#End Region
#Region "-|-]Warning Note"
    Private _warningIcon As Image
#End Region
#Region "-|-]Coffee Note"
    Private _coffeeIcon As Image
#End Region
#End Region
#Region "-]Integers"
#Region "-|-]Custom Note"
    Private _customIconSize As Integer = 36
    Private _customIconSpacing As Integer = 5
#End Region
#Region "-|-]Success Note"
    Private _successIconSize As Integer = 36
    Private _successIconSpacing As Integer = 5
#End Region
#Region "-|-]Info Note"
    Private _infoIconSize As Integer = 36
    Private _infoIconSpacing As Integer = 5
#End Region
#Region "-|-]Error Note"
    Private _errorIconSize As Integer = 36
    Private _errorIconSpacing As Integer = 5
#End Region
#Region "-|-]Warning Note"
    Private _warningIconSize As Integer = 36
    Private _warningIconSpacing As Integer = 5
#End Region
#Region "-|-]Coffee Note"
    Private _coffeeIconSize As Integer = 36
    Private _coffeeIconSpacing As Integer = 5
#End Region
#End Region
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
    <DisplayName("Type")>
    Public Property Type As Types
        Get
            Return _Type
        End Get
        Set(value As Types)
            _Type = value
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
#End Region
#Region "-]Colors"
#Region "-|-]Custom Note"
    <Category("Custom Note")>
    <DisplayName("Border Color")>
    Public Property customBorderColor As Color
        Get
            Return _customBorderColor
        End Get
        Set(value As Color)
            _customBorderColor = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Shadow Border Color")>
    Public Property customShadowBorderColor As Color
        Get
            Return _customShadowBorderColor
        End Get
        Set(value As Color)
            _customShadowBorderColor = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Close Hover Color")>
    Public Property customCloseHoverColor As Color
        Get
            Return _customCloseHoverColor
        End Get
        Set(value As Color)
            _customCloseHoverColor = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Fill Color")>
    Public Property customFillColor As Color
        Get
            Return _customFillColor
        End Get
        Set(value As Color)
            _customFillColor = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Header Color")>
    Public Property customHeaderColor As Color
        Get
            Return _customHeaderColor
        End Get
        Set(value As Color)
            _customHeaderColor = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Text Color")>
    Public Property customTextColor As Color
        Get
            Return _customTextColor
        End Get
        Set(value As Color)
            _customTextColor = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Divider Color")>
    Public Property customDividerColor As Color
        Get
            Return _customDividerColor
        End Get
        Set(value As Color)
            _customDividerColor = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Close Color")>
    Public Property customCloseColor As Color
        Get
            Return _customCloseColor
        End Get
        Set(value As Color)
            _customCloseColor = value
        End Set
    End Property
#End Region
#Region "-|-]Success Note"
    <Category("Success Note")>
    <DisplayName("Border Color")>
    Public Property successBorderColor As Color
        Get
            Return _successBorderColor
        End Get
        Set(value As Color)
            _successBorderColor = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Shadow Border Color")>
    Public Property successShadowBorderColor As Color
        Get
            Return _successShadowBorderColor
        End Get
        Set(value As Color)
            _successShadowBorderColor = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Close Hover Color")>
    Public Property successCloseHoverColor As Color
        Get
            Return _successCloseHoverColor
        End Get
        Set(value As Color)
            _successCloseHoverColor = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Fill Color")>
    Public Property successFillColor As Color
        Get
            Return _successFillColor
        End Get
        Set(value As Color)
            _successFillColor = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Header Color")>
    Public Property successHeaderColor As Color
        Get
            Return _successHeaderColor
        End Get
        Set(value As Color)
            _successHeaderColor = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Text Color")>
    Public Property successTextColor As Color
        Get
            Return _successTextColor
        End Get
        Set(value As Color)
            _successTextColor = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Divider Color")>
    Public Property successDividerColor As Color
        Get
            Return _successDividerColor
        End Get
        Set(value As Color)
            _successDividerColor = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Close Color")>
    Public Property successCloseColor As Color
        Get
            Return _successCloseColor
        End Get
        Set(value As Color)
            _successCloseColor = value
        End Set
    End Property
#End Region
#Region "-|-]Info Note"
    <Category("Info Note")>
    <DisplayName("Border Color")>
    Public Property infoBorderColor As Color
        Get
            Return _infoBorderColor
        End Get
        Set(value As Color)
            _infoBorderColor = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Shadow Border Color")>
    Public Property infoShadowBorderColor As Color
        Get
            Return _infoShadowBorderColor
        End Get
        Set(value As Color)
            _infoShadowBorderColor = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Close Hover Color")>
    Public Property infoCloseHoverColor As Color
        Get
            Return _infoCloseHoverColor
        End Get
        Set(value As Color)
            _infoCloseHoverColor = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Fill Color")>
    Public Property infoFillColor As Color
        Get
            Return _infoFillColor
        End Get
        Set(value As Color)
            _infoFillColor = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Header Color")>
    Public Property infoHeaderColor As Color
        Get
            Return _infoHeaderColor
        End Get
        Set(value As Color)
            _infoHeaderColor = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Text Color")>
    Public Property infoTextColor As Color
        Get
            Return _infoTextColor
        End Get
        Set(value As Color)
            _infoTextColor = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Divider Color")>
    Public Property infoDividerColor As Color
        Get
            Return _infoDividerColor
        End Get
        Set(value As Color)
            _infoDividerColor = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Close Color")>
    Public Property infoCloseColor As Color
        Get
            Return _infoCloseColor
        End Get
        Set(value As Color)
            _infoCloseColor = value
        End Set
    End Property
#End Region
#Region "-|-]Error Note"
    <Category("Error Note")>
    <DisplayName("Border Color")>
    Public Property errorBorderColor As Color
        Get
            Return _errorBorderColor
        End Get
        Set(value As Color)
            _errorBorderColor = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Shadow Border Color")>
    Public Property errorShadowBorderColor As Color
        Get
            Return _errorShadowBorderColor
        End Get
        Set(value As Color)
            _errorShadowBorderColor = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Close Hover Color")>
    Public Property errorCloseHoverColor As Color
        Get
            Return _errorCloseHoverColor
        End Get
        Set(value As Color)
            _errorCloseHoverColor = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Fill Color")>
    Public Property errorFillColor As Color
        Get
            Return _errorFillColor
        End Get
        Set(value As Color)
            _errorFillColor = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Header Color")>
    Public Property errorHeaderColor As Color
        Get
            Return _errorHeaderColor
        End Get
        Set(value As Color)
            _errorHeaderColor = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Text Color")>
    Public Property errorTextColor As Color
        Get
            Return _errorTextColor
        End Get
        Set(value As Color)
            _errorTextColor = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Divider Color")>
    Public Property errorDividerColor As Color
        Get
            Return _errorDividerColor
        End Get
        Set(value As Color)
            _errorDividerColor = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Close Color")>
    Public Property errorCloseColor As Color
        Get
            Return _errorCloseColor
        End Get
        Set(value As Color)
            _errorCloseColor = value
        End Set
    End Property
#End Region
#Region "-|-]Warning Note"
    <Category("Warning Note")>
    <DisplayName("Border Color")>
    Public Property warningBorderColor As Color
        Get
            Return _warningBorderColor
        End Get
        Set(value As Color)
            _warningBorderColor = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Shadow Border Color")>
    Public Property warningShadowBorderColor As Color
        Get
            Return _warningShadowBorderColor
        End Get
        Set(value As Color)
            _warningShadowBorderColor = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Close Hover Color")>
    Public Property warningCloseHoverColor As Color
        Get
            Return _warningCloseHoverColor
        End Get
        Set(value As Color)
            _warningCloseHoverColor = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Fill Color")>
    Public Property warningFillColor As Color
        Get
            Return _warningFillColor
        End Get
        Set(value As Color)
            _warningFillColor = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Header Color")>
    Public Property warningHeaderColor As Color
        Get
            Return _warningHeaderColor
        End Get
        Set(value As Color)
            _warningHeaderColor = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Text Color")>
    Public Property warningTextColor As Color
        Get
            Return _warningTextColor
        End Get
        Set(value As Color)
            _warningTextColor = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Divider Color")>
    Public Property warningDividerColor As Color
        Get
            Return _warningDividerColor
        End Get
        Set(value As Color)
            _warningDividerColor = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Close Color")>
    Public Property warningCloseColor As Color
        Get
            Return _warningCloseColor
        End Get
        Set(value As Color)
            _warningCloseColor = value
        End Set
    End Property
#End Region
#Region "-|-]Coffee Note"
    <Category("Coffee Note")>
    <DisplayName("Border Color")>
    Public Property coffeeBorderColor As Color
        Get
            Return _coffeeBorderColor
        End Get
        Set(value As Color)
            _coffeeBorderColor = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Shadow Border Color")>
    Public Property coffeeShadowBorderColor As Color
        Get
            Return _coffeeShadowBorderColor
        End Get
        Set(value As Color)
            _coffeeShadowBorderColor = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Close Hover Color")>
    Public Property coffeeCloseHoverColor As Color
        Get
            Return _coffeeCloseHoverColor
        End Get
        Set(value As Color)
            _coffeeCloseHoverColor = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Fill Color")>
    Public Property coffeeFillColor As Color
        Get
            Return _coffeeFillColor
        End Get
        Set(value As Color)
            _coffeeFillColor = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Header Color")>
    Public Property coffeeHeaderColor As Color
        Get
            Return _coffeeHeaderColor
        End Get
        Set(value As Color)
            _coffeeHeaderColor = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Text Color")>
    Public Property coffeeTextColor As Color
        Get
            Return _coffeeTextColor
        End Get
        Set(value As Color)
            _coffeeTextColor = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Divider Color")>
    Public Property coffeeDividerColor As Color
        Get
            Return _coffeeDividerColor
        End Get
        Set(value As Color)
            _coffeeDividerColor = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Close Color")>
    Public Property coffeeCloseColor As Color
        Get
            Return _coffeeCloseColor
        End Get
        Set(value As Color)
            _coffeeCloseColor = value
        End Set
    End Property
#End Region
#End Region
#Region "-]String"
#Region "-|-]Custom Note"
    <Category("Custom Note")>
    <DisplayName("Header Text")>
    Public Property customHeader As String
        Get
            Return _customHeader
        End Get
        Set(value As String)
            _customHeader = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Caption")>
    Public Property customText As String
        Get
            Return _customText
        End Get
        Set(value As String)
            _customText = value
        End Set
    End Property
#End Region
#Region "-|-]Success Note"
    <Category("Success Note")>
    <DisplayName("Header Text")>
    Public Property successHeader As String
        Get
            Return _successHeader
        End Get
        Set(value As String)
            _successHeader = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Caption")>
    Public Property successText As String
        Get
            Return _successText
        End Get
        Set(value As String)
            _successText = value
        End Set
    End Property
#End Region
#Region "-|-]Info Note"
    <Category("Info Note")>
    <DisplayName("Header Text")>
    Public Property infoHeader As String
        Get
            Return _infoHeader
        End Get
        Set(value As String)
            _infoHeader = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Caption")>
    Public Property infoText As String
        Get
            Return _infoText
        End Get
        Set(value As String)
            _infoText = value
        End Set
    End Property
#End Region
#Region "-|-]Error Note"
    <Category("Error Note")>
    <DisplayName("Header Text")>
    Public Property errorHeader As String
        Get
            Return _errorHeader
        End Get
        Set(value As String)
            _errorHeader = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Caption")>
    Public Property errorText As String
        Get
            Return _errorText
        End Get
        Set(value As String)
            _errorText = value
        End Set
    End Property
#End Region
#Region "-|-]Warning Note"
    <Category("Warning Note")>
    <DisplayName("Header Text")>
    Public Property warningHeader As String
        Get
            Return _warningHeader
        End Get
        Set(value As String)
            _warningHeader = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Caption")>
    Public Property warningText As String
        Get
            Return _warningText
        End Get
        Set(value As String)
            _warningText = value
        End Set
    End Property
#End Region
#Region "-|-]Coffee Note"
    <Category("Coffee Note")>
    <DisplayName("Header Text")>
    Public Property coffeeHeader As String
        Get
            Return _coffeeHeader
        End Get
        Set(value As String)
            _coffeeHeader = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Caption")>
    Public Property coffeeText As String
        Get
            Return _coffeeText
        End Get
        Set(value As String)
            _coffeeText = value
        End Set
    End Property
#End Region
#End Region
#Region "-]Fonts"
#Region "-|-]Custom Note"
    <Category("Custom Note")>
    <DisplayName("Header Font")>
    Public Property customHeaderFont As Font
        Get
            Return _customHeaderFont
        End Get
        Set(value As Font)
            _customHeaderFont = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Text Font")>
    Public Property customTextFont As Font
        Get
            Return _customTextFont
        End Get
        Set(value As Font)
            _customTextFont = value
        End Set
    End Property
#End Region
#Region "-|-]Success Note"
    <Category("Success Note")>
    <DisplayName("Header Font")>
    Public Property successHeaderFont As Font
        Get
            Return _successHeaderFont
        End Get
        Set(value As Font)
            _successHeaderFont = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Text Font")>
    Public Property successTextFont As Font
        Get
            Return _successTextFont
        End Get
        Set(value As Font)
            _successTextFont = value
        End Set
    End Property
#End Region
#Region "-|-]Info Note"
    <Category("Info Note")>
    <DisplayName("Header Font")>
    Public Property infoHeaderFont As Font
        Get
            Return _infoHeaderFont
        End Get
        Set(value As Font)
            _infoHeaderFont = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Text Font")>
    Public Property infoTextFont As Font
        Get
            Return _infoTextFont
        End Get
        Set(value As Font)
            _infoTextFont = value
        End Set
    End Property
#End Region
#Region "-|-]Error Note"
    <Category("Error Note")>
    <DisplayName("Header Font")>
    Public Property errorHeaderFont As Font
        Get
            Return _errorHeaderFont
        End Get
        Set(value As Font)
            _errorHeaderFont = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Text Font")>
    Public Property errorTextFont As Font
        Get
            Return _errorTextFont
        End Get
        Set(value As Font)
            _errorTextFont = value
        End Set
    End Property
#End Region
#Region "-|-]Warning Note"
    <Category("Warning Note")>
    <DisplayName("Header Font")>
    Public Property warningHeaderFont As Font
        Get
            Return _warningHeaderFont
        End Get
        Set(value As Font)
            _warningHeaderFont = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Text Font")>
    Public Property warningTextFont As Font
        Get
            Return _warningTextFont
        End Get
        Set(value As Font)
            _warningTextFont = value
        End Set
    End Property
#End Region
#Region "-|-]Coffee Note"
    <Category("Coffee Note")>
    <DisplayName("Header Font")>
    Public Property coffeeHeaderFont As Font
        Get
            Return _coffeeHeaderFont
        End Get
        Set(value As Font)
            _coffeeHeaderFont = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Text Font")>
    Public Property coffeeTextFont As Font
        Get
            Return _coffeeTextFont
        End Get
        Set(value As Font)
            _coffeeTextFont = value
        End Set
    End Property
#End Region
#End Region
#Region "-]Booleans"
#Region "-|-]Custom Note"
    <Category("Custom Note")>
    <DisplayName("Close")>
    Public Property customClose As Boolean
        Get
            Return _customClose
        End Get
        Set(value As Boolean)
            _customClose = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Icon Visible")>
    Public Property customIconVisible As Boolean
        Get
            Return _customIconVisible
        End Get
        Set(value As Boolean)
            _customIconVisible = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Icon Divider")>
    Public Property customDividerVisible As Boolean
        Get
            Return _customDividerVisible
        End Get
        Set(value As Boolean)
            _customDividerVisible = value
        End Set
    End Property
#End Region
#Region "-|-]Success Note"
    <Category("Success Note")>
    <DisplayName("Close")>
    Public Property successClose As Boolean
        Get
            Return _successClose
        End Get
        Set(value As Boolean)
            _successClose = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Icon Visible")>
    Public Property successIconVisible As Boolean
        Get
            Return _successIconVisible
        End Get
        Set(value As Boolean)
            _successIconVisible = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Icon Divider")>
    Public Property successDividerVisible As Boolean
        Get
            Return _successDividerVisible
        End Get
        Set(value As Boolean)
            _successDividerVisible = value
        End Set
    End Property
#End Region
#Region "-|-]Info Note"
    <Category("Info Note")>
    <DisplayName("Close")>
    Public Property infoClose As Boolean
        Get
            Return _infoClose
        End Get
        Set(value As Boolean)
            _infoClose = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Icon Visible")>
    Public Property infoIconVisible As Boolean
        Get
            Return _infoIconVisible
        End Get
        Set(value As Boolean)
            _infoIconVisible = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Icon Divider")>
    Public Property infoDividerVisible As Boolean
        Get
            Return _infoDividerVisible
        End Get
        Set(value As Boolean)
            _infoDividerVisible = value
        End Set
    End Property
#End Region
#Region "-|-]Error Note"
    <Category("Error Note")>
    <DisplayName("Close")>
    Public Property errorClose As Boolean
        Get
            Return _errorClose
        End Get
        Set(value As Boolean)
            _errorClose = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Icon Visible")>
    Public Property errorIconVisible As Boolean
        Get
            Return _errorIconVisible
        End Get
        Set(value As Boolean)
            _errorIconVisible = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Icon Divider")>
    Public Property errorDividerVisible As Boolean
        Get
            Return _errorDividerVisible
        End Get
        Set(value As Boolean)
            _errorDividerVisible = value
        End Set
    End Property
#End Region
#Region "-|-]Warning Note"
    <Category("Warning Note")>
    <DisplayName("Close")>
    Public Property warningClose As Boolean
        Get
            Return _warningClose
        End Get
        Set(value As Boolean)
            _warningClose = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Icon Visible")>
    Public Property warningIconVisible As Boolean
        Get
            Return _warningIconVisible
        End Get
        Set(value As Boolean)
            _warningIconVisible = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Icon Divider")>
    Public Property warningDividerVisible As Boolean
        Get
            Return _warningDividerVisible
        End Get
        Set(value As Boolean)
            _warningDividerVisible = value
        End Set
    End Property
#End Region
#Region "-|-]Coffee Note"
    <Category("Coffee Note")>
    <DisplayName("Close")>
    Public Property coffeeClose As Boolean
        Get
            Return _coffeeClose
        End Get
        Set(value As Boolean)
            _coffeeClose = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Icon Visible")>
    Public Property coffeeIconVisible As Boolean
        Get
            Return _coffeeIconVisible
        End Get
        Set(value As Boolean)
            _coffeeIconVisible = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Icon Divider")>
    Public Property coffeeDividerVisible As Boolean
        Get
            Return _coffeeDividerVisible
        End Get
        Set(value As Boolean)
            _coffeeDividerVisible = value
        End Set
    End Property
#End Region
#End Region
#Region "-]Bitmaps"
#Region "-|-]Custom Note"
    <Category("Custom Note")>
    <DisplayName("Icon")>
    Public Property customIcon As Image
        Get
            Return _customIcon
        End Get
        Set(value As Image)
            _customIcon = value
        End Set
    End Property
#End Region
#Region "-|-]Success Note"
    <Category("Success Note")>
    <DisplayName("Icon")>
    Public Property successIcon As Image
        Get
            Return _successIcon
        End Get
        Set(value As Image)
            _successIcon = value
        End Set
    End Property
#End Region
#Region "-|-]Info Note"
    <Category("Info Note")>
    <DisplayName("Icon")>
    Public Property infoIcon As Image
        Get
            Return _infoIcon
        End Get
        Set(value As Image)
            _infoIcon = value
        End Set
    End Property
#End Region
#Region "-|-]Error Note"
    <Category("Error Note")>
    <DisplayName("Icon")>
    Public Property errorIcon As Image
        Get
            Return _errorIcon
        End Get
        Set(value As Image)
            _errorIcon = value
        End Set
    End Property
#End Region
#Region "-|-]Warning Note"
    <Category("Warning Note")>
    <DisplayName("Icon")>
    Public Property warningIcon As Image
        Get
            Return _warningIcon
        End Get
        Set(value As Image)
            _warningIcon = value
        End Set
    End Property
#End Region
#Region "-|-]Coffee Note"
    <Category("Coffee Note")>
    <DisplayName("Icon")>
    Public Property coffeeIcon As Image
        Get
            Return _coffeeIcon
        End Get
        Set(value As Image)
            _coffeeIcon = value
        End Set
    End Property
#End Region
#End Region
#Region "-]Integers"
#Region "-|-]Custom Note"
    <Category("Custom Note")>
    <DisplayName("Icon Size")>
    Public Property customIconSize As Integer
        Get
            Return _customIconSize
        End Get
        Set(value As Integer)
            _customIconSize = value
        End Set
    End Property
    <Category("Custom Note")>
    <DisplayName("Icon Spacing")>
    Public Property customIconSpacing As Integer
        Get
            Return _customIconSpacing
        End Get
        Set(value As Integer)
            _customIconSpacing = value
        End Set
    End Property
#End Region
#Region "-|-]Success Note"
    <Category("Success Note")>
    <DisplayName("Icon Size")>
    Public Property successIconSize As Integer
        Get
            Return _successIconSize
        End Get
        Set(value As Integer)
            _successIconSize = value
        End Set
    End Property
    <Category("Success Note")>
    <DisplayName("Icon Spacing")>
    Public Property successIconSpacing As Integer
        Get
            Return _successIconSpacing
        End Get
        Set(value As Integer)
            _successIconSpacing = value
        End Set
    End Property
#End Region
#Region "-|-]Info Note"
    <Category("Info Note")>
    <DisplayName("Icon Size")>
    Public Property infoIconSize As Integer
        Get
            Return _infoIconSize
        End Get
        Set(value As Integer)
            _infoIconSize = value
        End Set
    End Property
    <Category("Info Note")>
    <DisplayName("Icon Spacing")>
    Public Property infoIconSpacing As Integer
        Get
            Return _infoIconSpacing
        End Get
        Set(value As Integer)
            _infoIconSpacing = value
        End Set
    End Property
#End Region
#Region "-|-]Error Note"
    <Category("Error Note")>
    <DisplayName("Icon Size")>
    Public Property errorIconSize As Integer
        Get
            Return _errorIconSize
        End Get
        Set(value As Integer)
            _errorIconSize = value
        End Set
    End Property
    <Category("Error Note")>
    <DisplayName("Icon Spacing")>
    Public Property errorIconSpacing As Integer
        Get
            Return _errorIconSpacing
        End Get
        Set(value As Integer)
            _errorIconSpacing = value
        End Set
    End Property
#End Region
#Region "-|-]Warning Note"
    <Category("Warning Note")>
    <DisplayName("Icon Size")>
    Public Property warningIconSize As Integer
        Get
            Return _warningIconSize
        End Get
        Set(value As Integer)
            _warningIconSize = value
        End Set
    End Property
    <Category("Warning Note")>
    <DisplayName("Icon Spacing")>
    Public Property warningIconSpacing As Integer
        Get
            Return _warningIconSpacing
        End Get
        Set(value As Integer)
            _warningIconSpacing = value
        End Set
    End Property
#End Region
#Region "-|-]Coffee Note"
    <Category("Coffee Note")>
    <DisplayName("Icon Size")>
    Public Property coffeeIconSize As Integer
        Get
            Return _coffeeIconSize
        End Get
        Set(value As Integer)
            _coffeeIconSize = value
        End Set
    End Property
    <Category("Coffee Note")>
    <DisplayName("Icon Spacing")>
    Public Property coffeeIconSpacing As Integer
        Get
            Return _coffeeIconSpacing
        End Get
        Set(value As Integer)
            _coffeeIconSpacing = value
        End Set
    End Property
#End Region
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

    Public Shared Function Round(x As Integer, y As Integer, height As Integer, width As Integer, slope As Integer) As GraphicsPath
        Return Round(New Rectangle(x, y, height, width), slope)
    End Function
#End Region
#End Region
#End Region
#Region "Mouse Events"
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15).Contains(e.X, e.Y) Then
            CloseHover = True
            Cursor = Cursors.Hand
            Me.Refresh()
        Else
            CloseHover = False
            Cursor = Cursors.Arrow
            Me.Refresh()
        End If
    End Sub
    Event Close()
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15).Contains(e.X, e.Y) Then
                RaiseEvent Close()
            End If
        End If
    End Sub
#End Region
#Region "Paint"
    Private Sub sNotification_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        g = e.Graphics
        g.SmoothingMode = SmoothingMode.HighQuality
        'Set the Style of the notifaction
        If Quality = SmoothingMode.HighQuality Then
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        ElseIf Quality = SmoothingMode.HighSpeed Then
            g.InterpolationMode = InterpolationMode.Low
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        End If
        Dim IconWidth As Integer = 0
        If Not RoundedCorners = 0 Then
            If Type = Types.Custom Then
                cgFillPath(g, customFillColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
                If customIconVisible Then
                    If customDividerVisible Then
                        cgFillPath(g, customDividerColor, NRRound(New Rectangle(0, 0, (customIconSpacing * 2) + customIconSize, Me.Height - 1), RoundedCorners))
                        cgDrawnPath(g, customShadowBorderColor, NRRound(New Rectangle(1, 1, (customIconSpacing * 2) + customIconSize - 2, Me.Height - 4), RoundedCorners))
                        IconWidth += (customIconSpacing * 2) + 1 + customIconSize
                        cgDrawLine(g, customBorderColor, New Point((customIconSpacing * 2) + 1 + customIconSize, 0), New Point((customIconSpacing * 2) + 1 + customIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, customIcon, New Rectangle(customIconSpacing, customIconSpacing, customIconSize, customIconSize))
                    Me.Height = (customIconSpacing * 2) + customIconSize
                End If
                cgDrawnPath(g, customShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundedCorners))
                cgDrawnPath(g, customBorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                cgDrawnString(g, customHeader, customHeaderFont, customHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(customHeader, customHeaderFont).Height / 2), g.MeasureString(customHeader, customHeaderFont).Width, g.MeasureString(customHeader, customHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, customText, customTextFont, customTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(customHeader, customHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(customText, customTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(customText, customTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If customClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), customCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), customCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If

                End If
            ElseIf Type = Types.Success Then
                cgFillPath(g, successFillColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
                If successIconVisible Then
                    If successDividerVisible Then
                        cgFillPath(g, successDividerColor, NRRound(New Rectangle(0, 0, (successIconSpacing * 2) + successIconSize, Me.Height - 1), RoundedCorners))
                        cgDrawnPath(g, successShadowBorderColor, NRRound(New Rectangle(1, 1, (successIconSpacing * 2) + successIconSize - 2, Me.Height - 4), RoundedCorners))
                        IconWidth += (successIconSpacing * 2) + 1 + successIconSize
                        cgDrawLine(g, successBorderColor, New Point((successIconSpacing * 2) + 1 + successIconSize, 0), New Point((successIconSpacing * 2) + 1 + successIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, successIcon, New Rectangle(successIconSpacing, successIconSpacing, successIconSize, successIconSize))
                    Me.Height = (successIconSpacing * 2) + successIconSize
                End If
                cgDrawnPath(g, successShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundedCorners))
                cgDrawnPath(g, successBorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                cgDrawnString(g, successHeader, successHeaderFont, successHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(successHeader, successHeaderFont).Height / 2), g.MeasureString(successHeader, successHeaderFont).Width, g.MeasureString(successHeader, successHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, successText, successTextFont, successTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(successHeader, successHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(successText, successTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(successText, successTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If successClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), successCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), successCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            ElseIf Type = Types.Info Then
                cgFillPath(g, infoFillColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
                If infoIconVisible Then
                    If infoDividerVisible Then
                        cgFillPath(g, infoDividerColor, NRRound(New Rectangle(0, 0, (infoIconSpacing * 2) + infoIconSize, Me.Height - 1), RoundedCorners))
                        cgDrawnPath(g, infoShadowBorderColor, NRRound(New Rectangle(1, 1, (infoIconSpacing * 2) + infoIconSize - 2, Me.Height - 4), RoundedCorners))
                        IconWidth += (infoIconSpacing * 2) + 1 + infoIconSize
                        cgDrawLine(g, infoBorderColor, New Point((infoIconSpacing * 2) + 1 + infoIconSize, 0), New Point((infoIconSpacing * 2) + 1 + infoIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, infoIcon, New Rectangle(infoIconSpacing, infoIconSpacing, infoIconSize, infoIconSize))
                    Me.Height = (infoIconSpacing * 2) + infoIconSize
                End If
                cgDrawnPath(g, infoShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundedCorners))
                cgDrawnPath(g, infoBorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                cgDrawnString(g, infoHeader, infoHeaderFont, infoHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(infoHeader, infoHeaderFont).Height / 2), g.MeasureString(infoHeader, infoHeaderFont).Width + 3, g.MeasureString(infoHeader, infoHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, infoText, infoTextFont, infoTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(infoHeader, infoHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(infoText, infoTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(infoText, infoTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If infoClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), infoCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), infoCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            ElseIf Type = Types.Error_ Then
                cgFillPath(g, errorFillColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
                If errorIconVisible Then
                    If errorDividerVisible Then
                        cgFillPath(g, errorDividerColor, NRRound(New Rectangle(0, 0, (errorIconSpacing * 2) + errorIconSize, Me.Height - 1), RoundedCorners))
                        cgDrawnPath(g, errorShadowBorderColor, NRRound(New Rectangle(1, 1, (errorIconSpacing * 2) + errorIconSize - 2, Me.Height - 4), RoundedCorners))
                        IconWidth += (errorIconSpacing * 2) + 1 + errorIconSize
                        cgDrawLine(g, errorBorderColor, New Point((errorIconSpacing * 2) + 1 + errorIconSize, 0), New Point((errorIconSpacing * 2) + 1 + errorIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, errorIcon, New Rectangle(errorIconSpacing, errorIconSpacing, errorIconSize, errorIconSize))
                    Me.Height = (errorIconSpacing * 2) + errorIconSize
                End If
                cgDrawnPath(g, errorShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundedCorners))
                cgDrawnPath(g, errorBorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                cgDrawnString(g, errorHeader, errorHeaderFont, errorHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(errorHeader, errorHeaderFont).Height / 2), g.MeasureString(errorHeader, errorHeaderFont).Width + 3, g.MeasureString(errorHeader, errorHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, errorText, errorTextFont, errorTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(errorHeader, errorHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(errorText, errorTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(errorText, errorTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If errorClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), errorCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), errorCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            ElseIf Type = Types.Warning Then
                cgFillPath(g, warningFillColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
                If warningIconVisible Then
                    If warningDividerVisible Then
                        cgFillPath(g, warningDividerColor, NRRound(New Rectangle(0, 0, (warningIconSpacing * 2) + warningIconSize, Me.Height - 1), RoundedCorners))
                        cgDrawnPath(g, warningShadowBorderColor, NRRound(New Rectangle(1, 1, (warningIconSpacing * 2) + warningIconSize - 2, Me.Height - 4), RoundedCorners))
                        IconWidth += (warningIconSpacing * 2) + 1 + warningIconSize
                        cgDrawLine(g, warningBorderColor, New Point((warningIconSpacing * 2) + 1 + warningIconSize, 0), New Point((warningIconSpacing * 2) + 1 + warningIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, warningIcon, New Rectangle(warningIconSpacing, warningIconSpacing, warningIconSize, warningIconSize))
                    Me.Height = (warningIconSpacing * 2) + warningIconSize
                End If
                cgDrawnPath(g, warningShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundedCorners))
                cgDrawnPath(g, warningBorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                cgDrawnString(g, warningHeader, warningHeaderFont, warningHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(warningHeader, warningHeaderFont).Height / 2), g.MeasureString(warningHeader, warningHeaderFont).Width + 3, g.MeasureString(warningHeader, warningHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, warningText, warningTextFont, warningTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(warningHeader, warningHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(warningText, warningTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(warningText, warningTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If warningClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), warningCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), warningCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            ElseIf Type = Types.Coffee Then
                cgFillPath(g, coffeeFillColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners + 1))
                If coffeeIconVisible Then
                    If coffeeDividerVisible Then
                        cgFillPath(g, coffeeDividerColor, NRRound(New Rectangle(0, 0, (coffeeIconSpacing * 2) + coffeeIconSize, Me.Height - 1), RoundedCorners))
                        cgDrawnPath(g, coffeeShadowBorderColor, NRRound(New Rectangle(1, 1, (coffeeIconSpacing * 2) + coffeeIconSize - 2, Me.Height - 4), RoundedCorners))
                        IconWidth += (coffeeIconSpacing * 2) + 1 + coffeeIconSize
                        cgDrawLine(g, coffeeBorderColor, New Point((coffeeIconSpacing * 2) + 1 + coffeeIconSize, 0), New Point((coffeeIconSpacing * 2) + 1 + coffeeIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, coffeeIcon, New Rectangle(coffeeIconSpacing, coffeeIconSpacing, coffeeIconSize, coffeeIconSize))
                    Me.Height = (coffeeIconSpacing * 2) + coffeeIconSize
                End If
                cgDrawnPath(g, coffeeShadowBorderColor, Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), RoundedCorners))
                cgDrawnPath(g, coffeeBorderColor, Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), RoundedCorners))
                cgDrawnString(g, coffeeHeader, coffeeHeaderFont, coffeeHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(coffeeHeader, coffeeHeaderFont).Height / 2), g.MeasureString(coffeeHeader, coffeeHeaderFont).Width + 3, g.MeasureString(coffeeHeader, coffeeHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, coffeeText, coffeeTextFont, coffeeTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(coffeeHeader, coffeeHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(coffeeText, coffeeTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(coffeeText, coffeeTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If coffeeClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), coffeeCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), coffeeCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            End If
        Else 'Rectangles
            If Type = Types.Custom Then
                cgFillRectangle(g, customFillColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If customIconVisible Then
                    If customDividerVisible Then
                        cgFillRectangle(g, customDividerColor, New Rectangle(0, 0, (customIconSpacing * 2) + customIconSize, Me.Height - 1))
                        'cgDrawRectangle(g, customShadowBorderColor, New Rectangle(1, 1, (customIconSpacing * 2) + customIconSize - 2, Me.Height - 4))
                        IconWidth += (customIconSpacing * 2) + 1 + customIconSize
                        cgDrawLine(g, customBorderColor, New Point((customIconSpacing * 2) + 1 + customIconSize, 0), New Point((customIconSpacing * 2) + 1 + customIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, customIcon, New Rectangle(customIconSpacing, customIconSpacing, customIconSize, customIconSize))
                    Me.Height = (customIconSpacing * 2) + customIconSize
                End If
                cgDrawRectangle(g, customShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 2))
                cgDrawRectangle(g, customBorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                cgDrawnString(g, customHeader, customHeaderFont, customHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(customHeader, customHeaderFont).Height / 2), g.MeasureString(customHeader, customHeaderFont).Width, g.MeasureString(customHeader, customHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, customText, customTextFont, customTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(customHeader, customHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(customText, customTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(customText, customTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If customClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), customCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), customCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If

                End If
            ElseIf Type = Types.Success Then
                cgFillRectangle(g, successFillColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If successIconVisible Then
                    If successDividerVisible Then
                        cgFillRectangle(g, successDividerColor, New Rectangle(0, 0, (successIconSpacing * 2) + successIconSize, Me.Height - 1))
                        'cgDrawRectangle(g, successShadowBorderColor, New Rectangle(1, 1, (successIconSpacing * 2) + successIconSize - 2, Me.Height - 4))
                        IconWidth += (successIconSpacing * 2) + 1 + successIconSize
                        cgDrawLine(g, successBorderColor, New Point((successIconSpacing * 2) + 1 + successIconSize, 0), New Point((successIconSpacing * 2) + 1 + successIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, successIcon, New Rectangle(successIconSpacing, successIconSpacing, successIconSize, successIconSize))
                    Me.Height = (successIconSpacing * 2) + successIconSize
                End If
                cgDrawRectangle(g, successShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                cgDrawRectangle(g, successBorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                cgDrawnString(g, successHeader, successHeaderFont, successHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(successHeader, successHeaderFont).Height / 2), g.MeasureString(successHeader, successHeaderFont).Width, g.MeasureString(successHeader, successHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, successText, successTextFont, successTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(successHeader, successHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(successText, successTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(successText, successTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If successClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), successCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), successCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            ElseIf Type = Types.Info Then
                cgFillRectangle(g, infoFillColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If infoIconVisible Then
                    If infoDividerVisible Then
                        cgFillRectangle(g, infoDividerColor, New Rectangle(0, 0, (infoIconSpacing * 2) + infoIconSize, Me.Height - 1))
                        'cgDrawRectangle(g, infoShadowBorderColor, New Rectangle(1, 1, (infoIconSpacing * 2) + infoIconSize - 2, Me.Height - 4))
                        IconWidth += (infoIconSpacing * 2) + 1 + infoIconSize
                        cgDrawLine(g, infoBorderColor, New Point((infoIconSpacing * 2) + 1 + infoIconSize, 0), New Point((infoIconSpacing * 2) + 1 + infoIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, infoIcon, New Rectangle(infoIconSpacing, infoIconSpacing, infoIconSize, infoIconSize))
                    Me.Height = (infoIconSpacing * 2) + infoIconSize
                End If
                cgDrawRectangle(g, infoShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                cgDrawRectangle(g, infoBorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                cgDrawnString(g, infoHeader, infoHeaderFont, infoHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(infoHeader, infoHeaderFont).Height / 2), g.MeasureString(infoHeader, infoHeaderFont).Width, g.MeasureString(infoHeader, infoHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, infoText, infoTextFont, infoTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(infoHeader, infoHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(infoText, infoTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(infoText, infoTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If infoClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), infoCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), infoCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            ElseIf Type = Types.Error_ Then
                cgFillRectangle(g, errorFillColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If errorIconVisible Then
                    If errorDividerVisible Then
                        cgFillRectangle(g, errorDividerColor, New Rectangle(0, 0, (errorIconSpacing * 2) + errorIconSize, Me.Height - 1))
                        'cgDrawRectangle(g, errorShadowBorderColor, New Rectangle(1, 1, (errorIconSpacing * 2) + errorIconSize - 2, Me.Height - 4))
                        IconWidth += (errorIconSpacing * 2) + 1 + errorIconSize
                        cgDrawLine(g, errorBorderColor, New Point((errorIconSpacing * 2) + 1 + errorIconSize, 0), New Point((errorIconSpacing * 2) + 1 + errorIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, errorIcon, New Rectangle(errorIconSpacing, errorIconSpacing, errorIconSize, errorIconSize))
                    Me.Height = (errorIconSpacing * 2) + errorIconSize
                End If
                cgDrawRectangle(g, errorShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                cgDrawRectangle(g, errorBorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                cgDrawnString(g, errorHeader, errorHeaderFont, errorHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(errorHeader, errorHeaderFont).Height / 2), g.MeasureString(errorHeader, errorHeaderFont).Width + 3, g.MeasureString(errorHeader, errorHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, errorText, errorTextFont, errorTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(errorHeader, errorHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(errorText, errorTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(errorText, errorTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If errorClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), errorCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), errorCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            ElseIf Type = Types.Warning Then
                cgFillRectangle(g, warningFillColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If warningIconVisible Then
                    If warningDividerVisible Then
                        cgFillRectangle(g, warningDividerColor, New Rectangle(0, 0, (warningIconSpacing * 2) + warningIconSize, Me.Height - 1))
                        'cgDrawRectangle(g, warningShadowBorderColor, New Rectangle(1, 1, (warningIconSpacing * 2) + warningIconSize - 2, Me.Height - 4))
                        IconWidth += (warningIconSpacing * 2) + 1 + warningIconSize
                        cgDrawLine(g, warningBorderColor, New Point((warningIconSpacing * 2) + 1 + warningIconSize, 0), New Point((warningIconSpacing * 2) + 1 + warningIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, warningIcon, New Rectangle(warningIconSpacing, warningIconSpacing, warningIconSize, warningIconSize))
                    Me.Height = (warningIconSpacing * 2) + warningIconSize
                End If
                cgDrawRectangle(g, warningShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                cgDrawRectangle(g, warningBorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                cgDrawnString(g, warningHeader, warningHeaderFont, warningHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(warningHeader, warningHeaderFont).Height / 2), g.MeasureString(warningHeader, warningHeaderFont).Width + 3, g.MeasureString(warningHeader, warningHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, warningText, warningTextFont, warningTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(warningHeader, warningHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(warningText, warningTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(warningText, warningTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If warningClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), warningCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), warningCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            ElseIf Type = Types.Coffee Then
                cgFillRectangle(g, coffeeFillColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If coffeeIconVisible Then
                    If coffeeDividerVisible Then
                        cgFillRectangle(g, coffeeDividerColor, New Rectangle(0, 0, (coffeeIconSpacing * 2) + coffeeIconSize, Me.Height - 1))
                        'cgDrawRectangle(g, coffeeShadowBorderColor, New Rectangle(1, 1, (coffeeIconSpacing * 2) + coffeeIconSize - 2, Me.Height - 4))
                        IconWidth += (coffeeIconSpacing * 2) + 1 + coffeeIconSize
                        cgDrawLine(g, coffeeBorderColor, New Point((coffeeIconSpacing * 2) + 1 + coffeeIconSize, 0), New Point((coffeeIconSpacing * 2) + 1 + coffeeIconSize, Me.Height - 1))
                    End If
                    cgDrawnBitmap(g, coffeeIcon, New Rectangle(coffeeIconSpacing, coffeeIconSpacing, coffeeIconSize, coffeeIconSize))
                    Me.Height = (coffeeIconSpacing * 2) + coffeeIconSize
                End If
                cgDrawRectangle(g, coffeeShadowBorderColor, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
                cgDrawRectangle(g, coffeeBorderColor, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                cgDrawnString(g, coffeeHeader, coffeeHeaderFont, coffeeHeaderColor, New Rectangle(IconWidth + 5, (Me.Height / 2) - (g.MeasureString(coffeeHeader, coffeeHeaderFont).Height / 2), g.MeasureString(coffeeHeader, coffeeHeaderFont).Width + 3, g.MeasureString(coffeeHeader, coffeeHeaderFont).Height), New StringFormat With {.Alignment = StringAlignment.Near})
                cgDrawnString(g, coffeeText, coffeeTextFont, coffeeTextColor, New Rectangle(IconWidth + 1 + g.MeasureString(coffeeHeader, coffeeHeaderFont).Width, (Me.Height / 2) - (g.MeasureString(coffeeText, coffeeTextFont).Height / 2), Me.Width - (IconWidth + 20), g.MeasureString(coffeeText, coffeeTextFont).Height + 5), New StringFormat With {.Alignment = StringAlignment.Near})
                If coffeeClose Then
                    If CloseHover = False Then
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), coffeeCloseColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    Else
                        cgDrawnString(g, "x", New Font("Arial", 12, FontStyle.Bold), coffeeCloseHoverColor, New Rectangle(Me.Width - 20, (Me.Height / 2) - 10, 15, 15), New StringFormat With {.Alignment = StringAlignment.Near})
                    End If
                End If
            End If
        End If

    End Sub
#End Region
End Class