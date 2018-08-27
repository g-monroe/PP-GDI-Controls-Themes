Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class Sarrow_Tabselector
    Inherits ContainerControl
    Private G As Graphics
#Region "Start"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or
        ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
    End Sub
#End Region
#Region "Properties"
    '<Control Properties>
#Region "-] Control"
    Private _Quality As SmoothingMode = SmoothingMode.AntiAlias
    <Category("Appearance")>
    <DisplayName("Quality")>
    Property Quality() As SmoothingMode
        Get
            Return _Quality
        End Get
        Set(ByVal value As SmoothingMode)
            _Quality = value
        End Set
    End Property
#End Region
    '</Control Properties>
    '<Company Properties>
#Region "-] Company"
    Private _CompanyVisible As Boolean = True
    <Category("Company")>
    <DisplayName("Company Visible")>
    Property CompanyVisible() As Boolean
        Get
            Return _CompanyVisible
        End Get
        Set(ByVal value As Boolean)
            _CompanyVisible = value
        End Set
    End Property
    Private _CompanyName As String = "Silver Arrow"
    <Category("Company")>
    <DisplayName("Company Name")>
    Property Company_Name As String
        Get
            Return _CompanyName
        End Get
        Set(ByVal value As String)
            _CompanyName = value
        End Set
    End Property
    Private _CompanySubtitle As String = "Communications Expert"
    <Category("Company")>
    <DisplayName("Company Subtitle")>
    Property CompanySubtitle As String
        Get
            Return _CompanySubtitle
        End Get
        Set(ByVal value As String)
            _CompanySubtitle = value
        End Set
    End Property
    Private _CompanyLink As String = "View Site"
    <Category("Company")>
    <DisplayName("Company Link Text")>
    Property CompanyLink As String
        Get
            Return _CompanyLink
        End Get
        Set(ByVal value As String)
            _CompanyLink = value
        End Set
    End Property
    Private _CompanyDoc As String = "See Documentation"
    <Category("Company")>
    <DisplayName("Company Doc Text")>
    Property CompanyDoc As String
        Get
            Return _CompanyDoc
        End Get
        Set(ByVal value As String)
            _CompanyDoc = value
        End Set
    End Property
    Private _CompanyDocAlignRight As Boolean = False
    <Category("Company")>
    <DisplayName("Company Doc AlignRight")>
    Property CompanyDocAlignRight As Boolean
        Get
            Return _CompanyDocAlignRight
        End Get
        Set(ByVal value As Boolean)
            _CompanyDocAlignRight = value
        End Set
    End Property
#End Region
#Region "-] Company Colors"
    Private _CompanyBackColor As Color = Color.FromArgb(17, 20, 22)
    <Category("Colors -> (Company)")>
    <DisplayName("BackColor")>
    Property CompanyBackColor() As Color
        Get
            Return _CompanyBackColor
        End Get
        Set(ByVal value As Color)
            _CompanyBackColor = value
        End Set
    End Property
    Private _CompanyBorderColor As Color = Color.FromArgb(20, 23, 26)
    <Category("Colors -> (Company)")>
    <DisplayName("Border Color")>
    Property CompanyBorderColor() As Color
        Get
            Return _CompanyBorderColor
        End Get
        Set(ByVal value As Color)
            _CompanyBorderColor = value
        End Set
    End Property
    Private _CompanyNameColor As Color = Color.FromArgb(245, 245, 245)
    <Category("Colors -> (Company)")>
    <DisplayName("Name Color")>
    Property CompanyNameColor() As Color
        Get
            Return _CompanyNameColor
        End Get
        Set(ByVal value As Color)
            _CompanyNameColor = value
        End Set
    End Property
    Private _CompanySubtitleColor As Color = Color.FromArgb(157, 159, 160)
    <Category("Colors -> (Company)")>
    <DisplayName("Subtitle Color")>
    Property CompanySubtitleColor() As Color
        Get
            Return _CompanySubtitleColor
        End Get
        Set(ByVal value As Color)
            _CompanySubtitleColor = value
        End Set
    End Property
    Private _CompanyLinkColor As Color = Color.FromArgb(74, 76, 78)
    <Category("Colors -> (Company)")>
    <DisplayName("Link Color")>
    Property CompanyLinkColor() As Color
        Get
            Return _CompanyLinkColor
        End Get
        Set(ByVal value As Color)
            _CompanyLinkColor = value
        End Set
    End Property
    Private _CompanyDocColor As Color = Color.FromArgb(74, 76, 78)
    <Category("Colors -> (Company)")>
    <DisplayName("Documention Color")>
    Property CompanyDocColor() As Color
        Get
            Return _CompanyDocColor
        End Get
        Set(ByVal value As Color)
            _CompanyDocColor = value
        End Set
    End Property
    Private _CompanyLinkActiveColor As Color = Color.FromArgb(245, 245, 245)
    <Category("Colors -> (Company)")>
    <DisplayName("Link Active Color")>
    Property CompanyLinkActiveColor() As Color
        Get
            Return _CompanyLinkActiveColor
        End Get
        Set(ByVal value As Color)
            _CompanyLinkActiveColor = value
        End Set
    End Property
    Private _CompanyDocActiveColor As Color = Color.FromArgb(245, 245, 245)
    <Category("Colors -> (Company)")>
    <DisplayName("Documention Active Color")>
    Property CompanyDocActiveColor() As Color
        Get
            Return _CompanyDocActiveColor
        End Get
        Set(ByVal value As Color)
            _CompanyDocActiveColor = value
        End Set
    End Property
#End Region
#Region "-] Company Fonts"
    Private _CompanyNameFont As Font = New Font("Franklin Gothic", 13, FontStyle.Bold)
    <Category("Fonts -> (Company)")>
    <DisplayName("Name Font")>
    Property CompanyNameFont() As Font
        Get
            Return _CompanyNameFont
        End Get
        Set(ByVal value As Font)
            _CompanyNameFont = value
        End Set
    End Property
    Private _CompanySubtitleFont As Font = New Font("Arial", 10, FontStyle.Regular)
    <Category("Fonts -> (Company)")>
    <DisplayName("Subtitle Font")>
    Property CompanySubtitleFont() As Font
        Get
            Return _CompanySubtitleFont
        End Get
        Set(ByVal value As Font)
            _CompanySubtitleFont = value
        End Set
    End Property
    Private _CompanyLinkFont As Font = New Font("Arial", 9, FontStyle.Regular)
    <Category("Fonts -> (Company)")>
    <DisplayName("Link Font")>
    Property CompanyLinkFont() As Font
        Get
            Return _CompanyLinkFont
        End Get
        Set(ByVal value As Font)
            _CompanyLinkFont = value
        End Set
    End Property
    Private _CompanyDocFont As Font = New Font("Arial", 9, FontStyle.Regular)
    <Category("Fonts -> (Company)")>
    <DisplayName("Documention Font")>
    Property CompanyDocFont() As Font
        Get
            Return _CompanyDocFont
        End Get
        Set(ByVal value As Font)
            _CompanyDocFont = value
        End Set
    End Property
#End Region
#Region "-] Company Logo"
    Private _CompanyLogo As Image
    <Category("Logo -> (Company)")>
    <DisplayName("Logo")>
    Property CompanyLogo As Image
        Get
            Return _CompanyLogo
        End Get
        Set(ByVal value As Image)
            _CompanyLogo = value
        End Set
    End Property
    Private _CompanyLogoVisible As Boolean = True
    <Category("Logo -> (Company)")>
    <DisplayName("Logo Visible")>
    Property CompanyLogoVisible() As Boolean
        Get
            Return _CompanyLogoVisible
        End Get
        Set(ByVal value As Boolean)
            _CompanyLogoVisible = value
        End Set
    End Property
    Private _CompanyLogoGap As Integer = 3
    <Category("Logo -> (Company)")>
    <DisplayName("Logo Gap")>
    Property CompanyLogoGap() As Integer
        Get
            Return _CompanyLogoGap
        End Get
        Set(ByVal value As Integer)
            _CompanyLogoGap = value
        End Set
    End Property
    Enum CompanyLogoAligns
        Stretch
        Fit
        AlignCenter
        AlignLeft
        AlignRight
        Custom
    End Enum
    Private _CompanyLogoAlign As CompanyLogoAligns = CompanyLogoAligns.AlignLeft
    <Category("Logo -> (Company)")>
    <DisplayName("Logo SizeMode")>
    Property CompanyLogoAlign() As CompanyLogoAligns
        Get
            Return _CompanyLogoAlign
        End Get
        Set(ByVal value As CompanyLogoAligns)
            _CompanyLogoAlign = value
        End Set
    End Property
    Private _LogoLocation As Point = New Point(10, 30)
    <Category("Logo -> (Company)")>
    <DisplayName("Logo Location(SizeMode.Custom)")>
    Property LogoLocation() As Point
        Get
            Return _LogoLocation
        End Get
        Set(ByVal value As Point)
            _LogoLocation = value
        End Set
    End Property
    Private _LogoSize As Size = New Size(92, 92)
    <Category("Logo -> (Company)")>
    <DisplayName("Logo Size(SizeMode.Custom)")>
    Property LogoSize() As Size
        Get
            Return _LogoSize
        End Get
        Set(ByVal value As Size)
            _LogoSize = value
        End Set
    End Property
#End Region
    '</Company Properties>
    '<Main Properties>
#Region "-] Main Colors"
    Private _MainBackColor As Color = Color.FromArgb(26, 30, 34)
    <Category("Colors -> (Main)")>
    <DisplayName("BackColor")>
    Property MainBackColor() As Color
        Get
            Return _MainBackColor
        End Get
        Set(ByVal value As Color)
            _MainBackColor = value
        End Set
    End Property
    Private _MainBorderColor As Color = Color.FromArgb(25, 28, 32)
    <Category("Colors -> (Main)")>
    <DisplayName("Border Color")>
    Property MainBorderColor() As Color
        Get
            Return _MainBorderColor
        End Get
        Set(ByVal value As Color)
            _MainBorderColor = value
        End Set
    End Property
#End Region
#Region "-] Tab Settings"
    <Category("Tab Settings")>
    <DisplayName("Tabcontrol")>
    Property Tabcontrol() As PlainTabcontrol

    Private _UpdateTabs As Boolean = False
    <Category("Tab Settings")>
    <DisplayName("Update Tabs")>
    Property UpdateTabs() As Boolean
        Get
            Return _UpdateTabs
        End Get
        Set(ByVal value As Boolean)
            _UpdateTabs = value
        End Set
    End Property
    Private _TabHeight As Integer = 42
    <Category("Tab Settings")>
    <DisplayName("Tab Height")>
    Property TabHeight() As Integer
        Get
            Return _TabHeight
        End Get
        Set(ByVal value As Integer)
            _TabHeight = value
        End Set
    End Property
    Private _TabLabelHeight As Integer = 22
    <Category("Tab Settings")>
    <DisplayName("Tab Label Height")>
    Property TabLabelHeight() As Integer
        Get
            Return _TabLabelHeight
        End Get
        Set(ByVal value As Integer)
            _TabLabelHeight = value
        End Set
    End Property
    'Tabs
    Public _Tabs As New TabCollection(Me)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Category("Tab Settings")>
    <DisplayName("Tabs")>
    Public Property Tabs As TabCollection
        Get
            Return _Tabs
        End Get
        Set(ByVal value As TabCollection)
            _Tabs = value
        End Set
    End Property
    'Tabs Label
    Public _TabLabels As New TablabelCollection(Me)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Category("Tab Settings")>
    <DisplayName("Tab Labels")>
    Public Property Tablabels As TablabelCollection
        Get
            Return _TabLabels
        End Get
        Set(ByVal value As TablabelCollection)
            _TabLabels = value
        End Set
    End Property
#End Region
    '</Main Properties>
#End Region
    '////
    '<c> Core Functions that make the control lighter.</c>
    '\\\\
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
        Using Image As New Bitmap(Bitmap)
            g.DrawImage(Image, Rect)
        End Using
    End Sub
#End Region
#Region "Core"
    Public Sub CleanDrawnString(g As Graphics, Str As String, Font As Font, Color As Color, Rect As Rectangle, Addi As Integer)
        Using Brush As New SolidBrush(Color)
            If Not Str = String.Empty Then
                g.DrawString(Str, Font, Brush, Rect)
                CompanyStringHieght += Addi
            End If
        End Using
    End Sub
    Public Sub CleanDrawnTabString(g As Graphics, Str As String, Font As Font, Color As Color, Rect As Rectangle, Addi As Integer, stringformat As StringFormat)
        Using Brush As New SolidBrush(Color)
            If Not Str = String.Empty Then
                g.DrawString(Str, Font, Brush, Rect, stringformat)
                TabSelectionHeight += Addi
            End If
        End Using
    End Sub
#End Region
#End Region
    '////
    '<c> Any functions/Subs that are used to help make it 
    'easier to use, draw, etc.</c>
    '\\\\
#Region "TabSelector Helper"
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
    Public Function GetCompanyHeight(g As Graphics) As Integer
        Dim CompanyHeight As Integer = 0
        If CompanyVisible Then
            If CompanyLogoVisible Then
                If Not CompanyLogo Is Nothing Then
                    CompanyHeight += LogoSize.Height
                    CompanyHeight += LogoLocation.Y
                    CompanyHeight += 5
                Else
                    CompanyHeight += 10
                End If
            End If
            CompanyHeight += CompanyLogoGap
            If Not Company_Name = String.Empty Then
                CompanyHeight += g.MeasureString(Company_Name, CompanyNameFont).Height + 5
            End If
            If Not CompanySubtitle = String.Empty Then
                CompanyHeight += g.MeasureString(CompanySubtitle, CompanySubtitleFont).Height + 8
            End If
            If Not CompanyLink = String.Empty Then
                LinkSize = g.MeasureString(CompanyLink, CompanyLinkFont)
                docSize = g.MeasureString(CompanyDoc, CompanyDocFont)
                CompanyHeight += LinkSize.Height + 6
            End If
            Return CompanyHeight
        Else
            Return 0
        End If
    End Function
    Public Sub GetTabs(Tabcontrol As PlainTabcontrol)
        If Tabs.Count <= 0 Then
            Dim i As Integer = 0
            For Each Tab As TabPage In Tabcontrol.TabPages
                Dim _tab As New Tab With {.Text = Tab.Text, .Index = i}
                If i = Tabcontrol.SelectedIndex Then
                    _tab.Selected = True
                End If
                Tabs.Add(_tab)
                i += 1
            Next
        Else
            Dim i As Integer = 0
            For Each Tab As TabPage In Tabcontrol.TabPages
                If i > Tabs.Count - 1 Then
                    Dim _tab As New Tab With {.Text = Tab.Text, .Index = i}
                    If i = Tabcontrol.SelectedIndex Then
                        _tab.Selected = True
                    End If

                    Tabs.Add(_tab)
                End If
                i += 1
            Next
        End If
    End Sub
#End Region
    '////
    '<c> Class Declared Events and Functions that can be 
    'used inside the control. </c>
    '\\\\
#Region "Events & Declarations"
    Dim CompanyHeight As Integer = 0
    Dim CompanyLogoHeight As Integer = 0
    Dim CompanyStringHieght As Integer = 0
    Dim TabSelectionHeight As Integer = 0
    Dim timedata As Integer = 0
    Dim docSize As SizeF = New Size(0, 0)
    Dim LinkSize As SizeF = New Size(0, 0)
    Event LinkClicked()
    Event DocumentClicked()
    Event TabChanged(Index As Integer, TabName As String)
    Event TabNoteClicked(Data As String)
#End Region
    '////
    '<c> Mouse Events, Functions, etc</c>
    '\\\\
#Region "Mouse Input"
#Region "Mouse Declarations"
    Dim linkHover As Boolean = False
    Dim linkClick As Boolean = False
    Dim docHover As Boolean = False
    Dim docClick As Boolean = False
    Dim NoteHover As Boolean = False
    Dim NoteClick As Boolean = False
    Dim TabHover As Boolean = False
    Dim NoteTabIndex As Integer = 0
#End Region
#Region "Mouse Functions"
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        Dim fRefresh As Boolean = False
        If Not CompanyDoc = String.Empty And (Me.Width - ((LogoLocation.X + 10) + LinkSize.Width) > docSize.Width) Then
            If New Rectangle(LogoLocation.X, CompanyStringHieght, LinkSize.Width + 2, LinkSize.Height).Contains(e.X, e.Y) Then
                linkHover = True
                fRefresh = True 'If we need to refresh we do it at the end!
            ElseIf linkHover Then
                linkHover = False
                fRefresh = True 'If we need to refresh we do it at the end!
            End If
        End If
        If Not CompanyDocAlignRight Then
            If Not CompanyDoc = String.Empty And (Me.Width - ((LogoLocation.X + 10) + LinkSize.Width) > docSize.Width) Then
                If New Rectangle(((LogoLocation.X + 14) + LinkSize.Width), CompanyStringHieght, docSize.Width, docSize.Height).Contains(e.X, e.Y) Then
                    docHover = True
                    fRefresh = True
                ElseIf docHover Then
                    docHover = False
                    fRefresh = True 'If we need to refresh we do it at the end!
                End If
            End If
        Else
            If Not CompanyDoc = String.Empty And (Me.Width - ((LogoLocation.X + 10) + LinkSize.Width) > docSize.Width) Then
                If New Rectangle(Me.Width - ((LogoLocation.X + 2) + docSize.Width), CompanyStringHieght, docSize.Width, docSize.Height).Contains(e.X, e.Y) Then
                    docHover = True
                    fRefresh = True 'If we need to refresh we do it at the end!
                ElseIf docHover Then
                    docHover = False
                    fRefresh = True 'If we need to refresh we do it at the end!
                End If
            End If
        End If
        If New Rectangle(0, CompanyHeight, Me.Width, TabSelectionHeight).Contains(e.X, e.Y) Then
            For Each Tab As Tab In Tabs
                If Tab.Button = True And Tab.NoteVisible = True And Not Tab.ButtonData = String.Empty Then
                    Dim NoteRect As Rectangle = New Rectangle((Me.Width - (Tab.NoteWidth)), Tab.Location.Y + (TabHeight / 4), Tab.NoteWidth - 10, TabHeight / 2)
                    If NoteRect.Contains(e.X, e.Y) Then
                        NoteHover = True
                        NoteTabIndex = Tab.Index
                        TabHover = False
                    Else
                        NoteHover = False
                        If New Rectangle(Tab.Location.X, Tab.Location.Y, Me.Width, TabHeight).Contains(e.X, e.Y) Then
                            If Tab.Selected = False Then
                                Tab.Hover = True
                                TabHover = True
                                fRefresh = True 'If we need to refresh we do it at the end!
                            Else
                                TabHover = False
                            End If
                        Else
                            Tab.Hover = False
                            If Not New Rectangle(0, CompanyHeight, Me.Width, TabSelectionHeight).Contains(e.X, e.Y) Then
                                TabHover = False
                            End If
                        End If
                    End If
                Else
                    '-]If There is no Button/Note
                    If New Rectangle(Tab.Location.X, Tab.Location.Y, Me.Width, TabHeight).Contains(e.X, e.Y) Then
                        If Tab.Selected = False Then
                            Tab.Hover = True
                            TabHover = True
                            fRefresh = True 'If we need to refresh we do it at the end!

                        ElseIf Tab.Selected Then
                            TabHover = False
                        End If
                    Else
                        Tab.Hover = False
                        If Not New Rectangle(0, CompanyHeight, Me.Width, TabSelectionHeight).Contains(e.X, e.Y) Then
                            TabHover = False
                        End If
                    End If
                End If
            Next
        Else
            For Each Tab As Tab In Tabs
                Tab.Hover = False
            Next
            TabHover = False

            fRefresh = True
        End If
        If fRefresh Then
            Me.Refresh()
            fRefresh = False
        End If
        If linkHover Or linkClick Or docClick Or docHover Or TabHover Or NoteHover Then
            Me.Cursor = Cursors.Hand
        Else
            Me.Cursor = Cursors.Arrow
        End If
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        TabHover = False
        For Each Tab As Tab In Tabs
            Tab.Hover = False
        Next
        Me.Refresh()
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If linkHover Then
                linkClick = True
                Me.Refresh()
            End If
            If docHover Then
                docClick = True
                Me.Refresh()
            End If
            If NoteHover Then
                NoteClick = True
                Me.Refresh()
            End If
            If TabHover Then
                For Each Tab As Tab In Tabs

                    If Tab.Hover And Not Tab.Selected Then
                        TabHover = False
                        RaiseEvent TabChanged(Tab.Index, Tab.Text)
                        Tabcontrol.SelectedIndex = Tab.Index
                        If Tabcontrol.SelectedIndex = Tab.Index Then
                            Tab.Selected = True
                        End If
                    ElseIf Not Tab.Hover And Tab.Selected Then
                        Tab.Selected = False
                    End If
                Next
                Me.Refresh()
            End If
            'Just in Case if you click a Label or anything else
            If Tabcontrol IsNot Nothing Then
                For Each TabPage As TabPage In Tabcontrol.TabPages
                    For Each Tab As Tab In Tabs
                        If Tab.Index = Tabcontrol.SelectedIndex Then
                            Tab.Selected = True
                            Exit For
                        Else
                            Tab.Selected = False
                        End If
                    Next
                    Exit For
                Next
            End If
        End If
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If linkHover And linkClick Then
            linkClick = False
            RaiseEvent LinkClicked()
            Me.Refresh()
        End If
        If docHover And docClick Then
            docClick = False
            RaiseEvent DocumentClicked()
            Me.Refresh()
        End If
        If NoteHover And NoteClick Then
            For Each Tab As Tab In Tabs
                If Tab.Index = NoteTabIndex Then
                    RaiseEvent TabNoteClicked(Tab.ButtonData)
                    Exit For
                End If
            Next
        End If
    End Sub
#End Region
#End Region
    '////
    '<c>Drawing, Painting, Filling, etc.</c>
    '\\\\
#Region "Paint/Draw"
#Region "-] Company"
    Public Sub DrawCompanyLogo(g As Graphics)
        If CompanyVisible Then
            CompanyHeight = GetCompanyHeight(g)
            CompanyLogoHeight = 0
            '--]Draw back & border of the Company Box.
            cgFillRectangle(g, CompanyBackColor, New Rectangle(0, -1, Me.Width, CompanyHeight + 1))
            cgDrawLine(g, CompanyBorderColor, New Point(0, CompanyHeight), New Point(Me.Width, CompanyHeight))
            cgDrawLine(g, MainBorderColor, New Point(0, CompanyHeight + 1), New Point(Me.Width, CompanyHeight + 1))
            '--]Check if there is a logo, so we don't waste time, trying to draw something that isn't there.
            If CompanyLogoVisible Then
                If Not CompanyLogo Is Nothing Then
                    Select Case CompanyLogoAlign
                        Case CompanyLogoAligns.AlignCenter
                            CompanyLogoHeight += 0 + LogoSize.Height + LogoLocation.Y
                            cgDrawnBitmap(g, CompanyLogo, New Rectangle((Me.Width / 2) - (LogoSize.Width / 2), LogoLocation.Y, LogoSize.Width, LogoSize.Height))
                        Case CompanyLogoAligns.AlignLeft
                            CompanyLogoHeight += 0 + LogoSize.Height + LogoLocation.Y
                            cgDrawnBitmap(g, CompanyLogo, New Rectangle(LogoLocation, LogoSize))
                        Case CompanyLogoAligns.AlignRight
                            CompanyLogoHeight += 0 + LogoSize.Height + LogoLocation.Y
                            cgDrawnBitmap(g, CompanyLogo, New Rectangle(Me.Width - (LogoSize.Width + 3), LogoLocation.Y, LogoSize.Width, LogoSize.Height))
                    End Select
                Else
                    CompanyLogoHeight += 15
                End If
            End If

            '--]Draw Company Strings Required and Properties that are set. Each String we will check if there it's Empty or not so we don't waste time drawing it if there isn't anything there
            CompanyStringHieght = CompanyLogoHeight + CompanyLogoGap
            CleanDrawnString(g, Company_Name, CompanyNameFont, CompanyNameColor, New Rectangle(LogoLocation.X, CompanyStringHieght, Me.Width - (LogoLocation.X + 3), g.MeasureString(Company_Name, CompanyNameFont).Height), g.MeasureString(Company_Name, CompanyNameFont).Height)
            CleanDrawnString(g, CompanySubtitle, CompanySubtitleFont, CompanySubtitleColor, New Rectangle(LogoLocation.X, CompanyStringHieght, Me.Width - (LogoLocation.X + 3), g.MeasureString(CompanySubtitle, CompanySubtitleFont).Height), g.MeasureString(CompanySubtitle, CompanySubtitleFont).Height + 12)
            '-] Draw Link, And Documention Click, Hover, or normal Status
            If linkClick = False Then
                CleanDrawnString(g, CompanyLink, CompanyLinkFont, CompanyLinkColor, New Rectangle(LogoLocation.X, CompanyStringHieght, Me.Width - (LogoLocation.X + 3), LinkSize.Height), 0)
            Else
                CleanDrawnString(g, CompanyLink, CompanyLinkFont, CompanyLinkActiveColor, New Rectangle(LogoLocation.X, CompanyStringHieght, Me.Width - (LogoLocation.X + 3), LinkSize.Height), 0)
            End If
            If (Me.Width - ((LogoLocation.X + 10) + LinkSize.Width) > docSize.Width) Then
                If docClick = False Then
                    If CompanyDocAlignRight Then
                        CleanDrawnString(g, CompanyDoc, CompanyDocFont, CompanyDocColor, New Rectangle(Me.Width - ((LogoLocation.X) + docSize.Width), CompanyStringHieght, Me.Width - ((LogoLocation.X + 10) + LinkSize.Width), LinkSize.Height), 0)
                    Else
                        CleanDrawnString(g, CompanyDoc, CompanyDocFont, CompanyDocColor, New Rectangle(((LogoLocation.X + 10) + LinkSize.Width), CompanyStringHieght, Me.Width - ((LogoLocation.X + 10) + LinkSize.Width), LinkSize.Height), 0)
                    End If
                Else
                    If CompanyDocAlignRight Then
                        CleanDrawnString(g, CompanyDoc, CompanyDocFont, CompanyDocActiveColor, New Rectangle(Me.Width - ((LogoLocation.X) + docSize.Width), CompanyStringHieght, Me.Width - ((LogoLocation.X + 10) + LinkSize.Width), LinkSize.Height), 0)
                    Else
                        CleanDrawnString(g, CompanyDoc, CompanyDocFont, CompanyDocActiveColor, New Rectangle(((LogoLocation.X + 10) + LinkSize.Width), CompanyStringHieght, Me.Width - ((LogoLocation.X + 10) + LinkSize.Width), LinkSize.Height), 0)
                    End If
                End If
            End If
            cgFillGradientBrush(g, New Rectangle((Me.Width - (Me.Width / 6)), 0, (Me.Width / 6), CompanyHeight), Color.Transparent, CompanyBackColor, 0.0!)
            '-] Link & Doc Clickable/Hover
            If linkHover And linkClick = False Then
                cgDrawLine(g, CompanyLinkColor, New Point(LogoLocation.X + 2, CompanyStringHieght + LinkSize.Height + 1), New Point(LogoLocation.X + LinkSize.Width - 2, CompanyStringHieght + LinkSize.Height + 1))
            End If
            If docHover And docClick = False Then
                If CompanyDocAlignRight Then
                    cgDrawLine(g, CompanyDocColor, New Point(Me.Width - (LogoLocation.X + docSize.Width), CompanyStringHieght + docSize.Height + 1), New Point(Me.Width - (LogoLocation.X), CompanyStringHieght + LinkSize.Height + 1))
                Else
                    cgDrawLine(g, CompanyDocColor, New Point(LogoLocation.X + 12 + LinkSize.Width, CompanyStringHieght + docSize.Height + 1), New Point(LogoLocation.X + docSize.Width + LinkSize.Width + 9, CompanyStringHieght + LinkSize.Height + 1))
                End If

            End If
        End If
    End Sub
#End Region
#Region "-] Intialize"
    Private Sub InitializeGraphics(g As Graphics)
        g.SmoothingMode = Quality
        If Quality = SmoothingMode.HighQuality Then
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        ElseIf Quality = SmoothingMode.HighSpeed Then
            g.InterpolationMode = InterpolationMode.Low
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        End If
        If UpdateTabs Then
            Try
                GetTabs(_Tabcontrol)
            Catch ex As Exception
            End Try
            UpdateTabs = False
        End If
    End Sub
#End Region
#Region "-] Tabs"
    Private Sub DrawTabs(g As Graphics)
        TabSelectionHeight = CompanyHeight + 10
        Dim tablabeltrack As Integer = 0
        If UpdateTabs Then
            GetTabs(Tabcontrol)
            UpdateTabs = False
        End If
        For Each Tab As Tab In Tabs
            If Not Tab.TabLabel Then
                CleanDrawnTab(g, Tab)
            End If
        Next
        For Each TabLabel As TabLabel In Tablabels

            For Each Tab As Tab In Tabs
                If Tab.TabLabel Then
                    If Tab.TabLabelIndex = TabLabel.Index And TabLabel.Index = tablabeltrack Then
                        CleanDrawnTabString(g, TabLabel.Text, TabLabel.Font, TabLabel.FontColor, New Rectangle(LogoLocation.X, TabSelectionHeight, (Me.Width - (g.MeasureString(TabLabel.Text, TabLabel.Font).Width + LogoLocation.X)), TabLabelHeight), TabLabelHeight, New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
                        tablabeltrack += 1
                    End If
                    If Tab.TabLabelIndex = TabLabel.Index Then
                        CleanDrawnTab(g, Tab)
                    End If
                End If
            Next
        Next
    End Sub
    Public Sub CleanDrawnTab(g As Graphics, Tab As Tab)
        Dim DrawOver As Integer = 0
        Tab.Location = New Point(0, TabSelectionHeight)
        If Tab.Hover And Tab.Selected = False Then
            '-]Just Hover
            cgFillRectangle(g, Tab.HoverColor, New Rectangle(0, TabSelectionHeight, Me.Width, TabHeight))
            If Not Tab.Icon Is Nothing Then
                cgDrawnBitmap(g, Tab.Icon, New Rectangle(LogoLocation.X, TabSelectionHeight, TabHeight, TabHeight))
                DrawOver += TabHeight + 3
            End If
            cgDrawnString(g, Tab.Text, Tab.Font, Tab.FontColor, New Rectangle(DrawOver + LogoLocation.X, TabSelectionHeight + 2, Me.Width - g.MeasureString(Tab.NoteText, Tab.NoteFont).Width + 15, TabHeight), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
            If Tab.NoteVisible Then
                Tab.NoteWidth = g.MeasureString(Tab.NoteText, Tab.NoteFont).Width + 20
                cgFillPath(g, Tab.NoteColor, Round(New Rectangle((Me.Width - (Tab.NoteWidth)), TabSelectionHeight + (TabHeight / 4), Tab.NoteWidth - 10, TabHeight / 2), 5))
                cgDrawnString(g, Tab.NoteText, Tab.NoteFont, Tab.NoteFontColor, New Rectangle((Me.Width - (Tab.NoteWidth)), TabSelectionHeight + (TabHeight / 4), Tab.NoteWidth - 10, TabHeight / 2), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End If
        ElseIf Tab.Selected Then
            '-]Just Selected
            '-- Back Color
            cgFillRectangle(g, Tab.SelectedColor, New Rectangle(0, TabSelectionHeight, Me.Width, TabHeight))
            '-- Bar Color
            cgFillRectangle(g, Tab.BarColor, New Rectangle(0, TabSelectionHeight, 3, TabHeight))
            '-- Icon
            If Not Tab.SelectedIcon Is Nothing Then
                cgDrawnBitmap(g, Tab.SelectedIcon, New Rectangle(LogoLocation.X, TabSelectionHeight, TabHeight, TabHeight))
                DrawOver += TabHeight + 3
            End If
            '-- Text
            cgDrawnString(g, Tab.Text, Tab.SelectedFont, Tab.SelectedFontColor, New Rectangle(DrawOver + LogoLocation.X, TabSelectionHeight + 2, Me.Width - g.MeasureString(Tab.NoteText, Tab.NoteFont).Width + 15, TabHeight), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
            '-- Note
            If Tab.NoteVisible Then
                'Set NoteWidth so we can get the width later on.
                Tab.NoteWidth = g.MeasureString(Tab.NoteText, Tab.NoteSelectedFont).Width + 20
                Dim NoteRect As Rectangle = New Rectangle((Me.Width - (Tab.NoteWidth)), TabSelectionHeight + (TabHeight / 4), Tab.NoteWidth - 10, TabHeight / 2)
                '-- Draw Note Bubble
                cgFillPath(g, Tab.NoteSelectedColor, Round(NoteRect, 5))
                '--Draw Note String
                cgDrawnString(g, Tab.NoteText, Tab.NoteSelectedFont, Tab.NoteSelectedFontColor, New Rectangle(NoteRect.X, NoteRect.Y, NoteRect.Width, NoteRect.Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End If
        ElseIf Tab.Selected = False Then
            '-]Just Not Selected and Not Hovered
            If Not Tab.Icon Is Nothing Then
                cgDrawnBitmap(g, Tab.Icon, New Rectangle(LogoLocation.X, TabSelectionHeight, TabHeight, TabHeight))
                DrawOver += TabHeight + 3
            End If
            cgDrawnString(g, Tab.Text, Tab.Font, Tab.FontColor, New Rectangle(DrawOver + LogoLocation.X, TabSelectionHeight + 2, Me.Width - g.MeasureString(Tab.NoteText, Tab.NoteFont).Width + 15, TabHeight), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap})
            If Tab.NoteVisible Then
                Tab.NoteWidth = g.MeasureString(Tab.NoteText, Tab.NoteFont).Width + 20
                Dim NoteRect As Rectangle = New Rectangle((Me.Width - (Tab.NoteWidth)), TabSelectionHeight + (TabHeight / 4), Tab.NoteWidth - 10, TabHeight / 2)

                cgFillPath(g, Tab.NoteColor, Round(NoteRect, 5))

                cgDrawnString(g, Tab.NoteText, Tab.NoteFont, Tab.NoteFontColor, New Rectangle(NoteRect.X, NoteRect.Y, NoteRect.Width, NoteRect.Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

            End If
        End If


        TabSelectionHeight += TabHeight
    End Sub
#End Region
#Region "Core Function"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        '<Initalize>
        G = e.Graphics
        InitializeGraphics(G)
        G.Clear(MainBackColor) '<-Note: Clearing MainBackColor Instead of BackColor

        '<Draw Company Logo>
        DrawCompanyLogo(G)
        '<Draw Tabs>
        DrawTabs(G)
    End Sub
#End Region
#End Region
    '////
    '<c>This is the properties for the tabs & tablabels.</c>
    '\\\\
#Region "Tab Collection"
#Region "TabLabel"
    Public Class TablabelCollection
        Inherits List(Of TabLabel)
        Private Parent As Sarrow_Tabselector
        Public Sub New(Parent As Sarrow_Tabselector)
            Me.Parent = Parent
        End Sub
        Public Shadows Sub Add(TabLabel As TabLabel)
            TabLabel.Index = Parent._TabLabels.Count
            MyBase.Add(TabLabel)
        End Sub
        Public Shadows Sub AddRange(Range As List(Of TabLabel))
            MyBase.AddRange(Range)
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
        End Sub
        Public Shadows Sub Remove(TabLabel As TabLabel)
            MyBase.Remove(TabLabel)
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of TabLabel))
            MyBase.RemoveAll(Predicate)
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
        End Sub
    End Class
    Public Class TabLabel
        Property Text As String = "POST TYPES"
        Property Index As Integer = 0
        Property FontColor As Color = Color.FromArgb(139, 141, 143)
        Property Font As Font = New Font("Arial", 8, FontStyle.Bold)
        Protected UniqueId As Guid
        Sub New()
            UniqueId = Guid.NewGuid()
        End Sub
        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is TabLabel Then
                Return (DirectCast(obj, TabLabel).UniqueId = UniqueId)
            End If
            Return False
        End Function

    End Class
#End Region
#Region "Tab Items"
    Public Class TabCollection
        Inherits List(Of Tab)
        Private Parent As Sarrow_Tabselector
        Public Sub New(Parent As Sarrow_Tabselector)
            Me.Parent = Parent
        End Sub
        Public Shadows Sub Add(Tab As Tab)
            MyBase.Add(Tab)
        End Sub
        Public Shadows Sub AddRange(Range As List(Of Tab))
            MyBase.AddRange(Range)
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
        End Sub
        Public Shadows Sub Remove(Item As Tab)
            MyBase.Remove(Item)
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of Tab))
            MyBase.RemoveAll(Predicate)
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
        End Sub
    End Class
    Public Class Tab
        <Category("Data")>
        <DisplayName("Selected")>
        Property Selected As Boolean = False
        <Category("Data")>
        <DisplayName("Mouse Over")>
        Property Hover As Boolean = False
        <Category("Data")>
        <DisplayName("Tab Index")>
        Property Index As Integer = 0
        <Category("Data")>
        <DisplayName("Location(Don't Touch)")>
        Property Location As Point = New Point(0, 0)
        <Category("Data")>
        <DisplayName("Button Data")>
        Property ButtonData As String = "ex:ADD=41223-PORT"

        <Category("TabLabel")>
        <DisplayName("Tab Label Index")>
        Property TabLabelIndex As Integer = 0
        <Category("TabLabel")>
        <DisplayName("Tab Label")>
        Property TabLabel As Boolean = False

        <Category("Colors")>
        <DisplayName("Bar Color")>
        Property BarColor As Color = Color.FromArgb(71, 147, 255)
        <Category("Colors")>
        <DisplayName("Hover Color")>
        Property HoverColor As Color = Color.FromArgb(17, 20, 22)
        <Category("Colors")>
        <DisplayName("Selected Color")>
        Property SelectedColor As Color = Color.FromArgb(17, 20, 22)
        <Category("Colors")>
        <DisplayName("Selected Font Color")>
        Property SelectedFontColor As Color = Color.FromArgb(245, 245, 245)
        <Category("Colors")>
        <DisplayName("Font Color")>
        Property FontColor As Color = Color.FromArgb(245, 245, 245)


        <Category("Customize")>
        <DisplayName("Text")>
        Property Text As String = "New Tab"
        <Category("Customize")>
        <DisplayName("Tab Icon")>
        Property Icon As Image
        <Category("Customize")>
        <DisplayName("Tab Icon Active")>
        Property SelectedIcon As Image
        <Category("Customize")>
        <DisplayName("Font")>
        Property Font As Font = New Font("Arial", 12, FontStyle.Regular)
        <Category("Customize")>
        <DisplayName("Font")>
        Property SelectedFont As Font = New Font("Arial", 12, FontStyle.Bold)

        <Category("Note Settings")>
        <DisplayName("Button -> Clickable")>
        Property Button As Boolean = False
        <Category("Note Settings")>
        <DisplayName("Note Text")>
        Property NoteText As String = "3"
        <Category("Note Settings")>
        <DisplayName("Note Width(Don't Touch)")>
        Property NoteWidth As Integer = 10
        <Category("Note Settings")>
        <DisplayName("Visible")>
        Property NoteVisible As Boolean = False
        <Category("Note Settings")>
        <DisplayName("Note Color")>
        Property NoteColor As Color = Color.FromArgb(255, 71, 71)
        <Category("Note Settings")>
        <DisplayName("Note Font Color")>
        Property NoteFontColor As Color = Color.FromArgb(245, 245, 245)
        <Category("Note Settings")>
        <DisplayName("Note Font")>
        Property NoteFont As Font = New Font("Arial", 9, FontStyle.Regular)
        <Category("Note Settings")>
        <DisplayName("Note Selected Color")>
        Property NoteSelectedColor As Color = Color.FromArgb(255, 71, 71)
        <Category("Note Settings")>
        <DisplayName("Note Selected Font Color")>
        Property NoteSelectedFontColor As Color = Color.FromArgb(245, 245, 245)
        <Category("Note Settings")>
        <DisplayName("Note Selected Font ")>
        Property NoteSelectedFont As Font = New Font("Arial", 9, FontStyle.Regular)

        Protected UniqueId As Guid
        Sub New()
            UniqueId = Guid.NewGuid()
        End Sub
        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is Tab Then
                Return (DirectCast(obj, Tab).UniqueId = UniqueId)
            End If
            Return False
        End Function

    End Class
#End Region
#End Region
End Class
#Region "No-Tab Tabcontrol"
Public Class PlainTabcontrol
    Inherits TabControl
    Property _BackColor As Color = Color.White
    Sub New()
        Appearance = TabAppearance.FlatButtons
        ItemSize = New Size(0, 1)
        SizeMode = TabSizeMode.Fixed

    End Sub
    Private Const TCM_ADJUSTRECT As Integer = &H1328
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = TCM_ADJUSTRECT AndAlso Not DesignMode Then
            Return
        End If
        MyBase.WndProc(m)
    End Sub
End Class
#End Region