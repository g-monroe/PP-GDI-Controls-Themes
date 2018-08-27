Imports System.ComponentModel
Imports System.Drawing.Drawing2D
'[--------------------]
'[|by Nettro from HF |]
'[|Hope you enjoy ;) |]
'[|Feb 08, 2015      |]
'[--------------------]
Public Class PlisticBlueContainer
    Inherits ContainerControl
    Sub New()
        Me.DoubleBuffered = True
        Me.Dock = DockStyle.Fill
    End Sub
    <Category("Main Colors")>
    Property Fill_Color As Color = Color.FromArgb(25, 38, 69)
    <Category("Main Colors")>
    Property header_Color As Color = Color.FromArgb(20, 30, 55)
    <Category("Main Colors")>
    Property icon_color As Color = Color.FromArgb(16, 24, 44)
    <Category("Main Colors")>
    Property Bottom_Color As Color = Color.FromArgb(20, 30, 55)
    <Category("Main Colors")>
    Property Lip_Color As Color = Color.FromArgb(15, 23, 41)
    <Category("Form Text")>
    Property Texxt_Color As Color = Color.FromArgb(245, 245, 25)
    <Category("Form Text")>
    Property Fonnt As Font = New Font("Arial", 16, FontStyle.Regular)
    <Category("Form Text")>
    Property Texxt As String = " - Sign In"
    <Category("Header Text")>
    Property Header_Fonnt As Font = New Font("Arial", 16, FontStyle.Bold)
    <Category("Header Text")>
    Property Header_Texxt As String = "PB"
    <Category("Header Text")>
    Property Header_Texxt_Color As Color = Color.FromArgb(0, 174, 85)
    <Category("Bottom Text")>
    Property Bottom_Fonnt As Font = New Font("Arial", 11, FontStyle.Regular)
    <Category("Bottom Text")>
    Property Bottom_Texxt As String = "   Don't have an account?"
    <Category("Bottom Text")>
    Property Bottom_Texxt_Color As Color = Color.FromArgb(166, 172, 192)
    Private Sub PlisticBlueContainer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.FillRectangle(New SolidBrush(Fill_Color), New Rectangle(0, 0, Me.Width, Me.Height))
        e.Graphics.FillRectangle(New SolidBrush(header_Color), New Rectangle(0, 0, Me.Width - 52, 50))
        e.Graphics.FillRectangle(New SolidBrush(icon_color), New Rectangle(Me.Width - 52, 0, 52, 50))
        e.Graphics.FillRectangle(New SolidBrush(Bottom_Color), New Rectangle(0, Me.Height - 57, Me.Width, 50))
        e.Graphics.FillRectangle(New SolidBrush(Lip_Color), New Rectangle(0, Me.Height - 7, Me.Width, 7))
        Dim Textsz As SizeF = e.Graphics.MeasureString(Texxt, Fonnt)
        e.Graphics.DrawString(Header_Texxt, Header_Fonnt, New SolidBrush(Header_Texxt_Color), New Rectangle(0, 0, (Me.Width - 52) - Textsz.Width, 50), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Dim Headersz As SizeF = e.Graphics.MeasureString(Header_Texxt, Header_Fonnt)
        e.Graphics.DrawString(Texxt, Fonnt, New SolidBrush(Texxt_Color), New Rectangle(0, 0, (Me.Width - 52) + Headersz.Width, 50), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        e.Graphics.DrawString(Bottom_Texxt, Bottom_Fonnt, New SolidBrush(Bottom_Texxt_Color), New Rectangle(0, Me.Height - 57, Me.Width, 50), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
        e.Graphics.DrawImage(FindForm.Icon.ToBitmap, New Rectangle(Me.Width - 48, 4, 46, 46))
    End Sub
#Region "ThemeDraggable"
    Dim x, y As Integer
    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width, 50)
        If dragRect.Contains(New Point(e.X, e.Y)) Then
            isDragging = True
            savePoint = New Point(e.X, e.Y)
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
End Class
Public Class PlisticBlueButton
    Inherits Control
    Sub New()
        Me.DoubleBuffered = True
    End Sub
#Region "Functions"
    Public Sub FixRoundRectClicked(g As Graphics)
        'Fix Top
        'Line right 
        g.DrawLine(New Pen(Main_Color), New Point(Me.Width - 7, 2), New Point(Me.Width - 7, 7))
        'Line left
        g.DrawLine(New Pen(Main_Color), New Point(7, 2), New Point(7, 7))
        'Long Line
        g.DrawLine(New Pen(Main_Color), New Point(2, 7), New Point(Me.Width - 2, 7))
        'Fix Bottom
        'Line Bottom Right 
        ' g.DrawLine(New Pen(Under_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 4))
        'Line Bottom Left
        ' g.DrawLine(New Pen(Under_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 4))
        'Line right
        g.DrawLine(New Pen(Main_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 6))
        'Line left
        g.DrawLine(New Pen(Main_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 6))
        'Long Line
        g.DrawLine(New Pen(Main_Color), New Point(2, Me.Height - 7), New Point(Me.Width - 2, Me.Height - 7))
    End Sub
    Public Sub FixRoundRect(g As Graphics)
        'Fix Top
        'Line right 
        g.DrawLine(New Pen(Main_Color), New Point(Me.Width - 7, 2), New Point(Me.Width - 7, 7))
        'Line left
        g.DrawLine(New Pen(Main_Color), New Point(7, 2), New Point(7, 7))
        'Long Line
        g.DrawLine(New Pen(Main_Color), New Point(2, 7), New Point(Me.Width - 2, 7))
        'Fix Bottom
        'Line Bottom Right 
        g.DrawLine(New Pen(Under_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 4))
        'Line Bottom Left
        g.DrawLine(New Pen(Under_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 4))
        'Line right
        g.DrawLine(New Pen(Main_Color), New Point(Me.Width - 7, Me.Height - 6), New Point(Me.Width - 7, Me.Height - 11))
        'Line left
        g.DrawLine(New Pen(Main_Color), New Point(7, Me.Height - 6), New Point(7, Me.Height - 11))
        'Long Line
        g.DrawLine(New Pen(Main_Color), New Point(2, Me.Height - 11), New Point(Me.Width - 2, Me.Height - 11))
    End Sub
    Public Sub DrawRoundRect(g As Graphics, p As Pen, x As Single, y As Single, width As Single, height As Single, _
      radius As Single)
        Dim gp As New GraphicsPath()

        gp.AddLine(x + radius, y, x + width - (radius * 2), y)
        ' Line
        gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90)
        ' Corner
        gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2))
        ' Line
        gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90)
        ' Corner
        gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height)
        ' Line
        gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90)
        ' Corner
        gp.AddLine(x, y + height - (radius * 2), x, y + radius)
        ' Line
        gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
        ' Corner
        gp.CloseFigure()

        g.DrawPath(p, gp)
        gp.Dispose()
    End Sub
    Public Sub FillRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
    Public Sub FillNotTopRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
        g.FillPie(b, r.X, r.Y, 1, 1, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, 1, 1, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        ' g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
    Public Sub FillNotBottomRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        'g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        '  g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        ' g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        '   g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
#End Region
#Region "Properties"
    <Category("Colors")>
    Property Main_Color As Color = Color.FromArgb(166, 172, 192)
    <Category("Colors")>
    Property Under_Color As Color = Color.FromArgb(112, 116, 130)
    <Category("Colors")>
    Property Text_Color As Color = Color.FromArgb(22, 34, 59)
    <Category("Colors")>
    Property Back_color As Color = Color.FromArgb(22, 34, 59)
    <Category("Text")>
    Property Texxt As String = "Sign up"
    <Category("Text")>
    Property fonnt As Font = New Font("Arial", 11, FontStyle.Regular)
    Dim inner As Boolean = True
    Event Clicked()
    Dim Cliccked As Boolean = False
#End Region

  

    Private Sub PlisticBlueButton_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.Clear(Back_color)
        If Cliccked = False Then
            FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 2, Me.Height - 2), 12, New SolidBrush(Under_Color))
            FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 2, Me.Height - 6), 12, New SolidBrush(Main_Color))
            FixRoundRect(e.Graphics)
            e.Graphics.DrawString(Texxt, fonnt, New SolidBrush(Text_Color), New Rectangle(1, 1, Me.Width - 2, Me.Height - 6), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Else
            FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 2, Me.Height - 2), 12, New SolidBrush(Main_Color))
            FixRoundRectClicked(e.Graphics)
            FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 2, Me.Height - 2), 12, New SolidBrush(Color.FromArgb(90, 45, 45, 45)))
            e.Graphics.DrawString(Texxt, fonnt, New SolidBrush(Text_Color), New Rectangle(1, 1, Me.Width - 2, Me.Height - 2), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

        End If

    End Sub
#Region "Mouse"
    Dim tmr As New Timer
    Private Sub PlisticBlueButton_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If New Rectangle(1, 1, Me.Width - 2, Me.Height - 6).Contains(e.X, e.Y) Then
                RaiseEvent Clicked()
                Cliccked = True
                Me.Refresh()
                tmr.Interval = 200
                AddHandler tmr.Tick, AddressOf tmr_tick
                tmr.Start()
            End If
        End If
    End Sub

    Private Sub PlisticBlueButton_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If New Rectangle(1, 1, Me.Width - 2, Me.Height - 6).Contains(e.X, e.Y) Then
            Cursor = Cursors.Hand
            inner = True
        Else
            Cursor = Cursors.Arrow
            inner = False
        End If
    End Sub
#End Region

    Private Sub tmr_tick(sender As Object, e As EventArgs)
        Cliccked = False
        Me.Refresh()
        tmr.Stop()
    End Sub

End Class
Public Class PlisticBlue_Seperator
    Inherits Control
    <Category("Colors")>
    Property Main_Color As Color = Color.FromArgb(96, 105, 131)
    <Category("Colors")>
    Property Back_color As Color = Color.FromArgb(25, 38, 69)
    <Category("Colors")>
    Property Side_Color As Color = Color.FromArgb(0, 174, 85)
    <Category("Misc")>
    Property SubtractSep As Integer = 40
    Sub New()
        Me.DoubleBuffered = True
        Me.Height = 6
        Me.Width = 100
    End Sub

    Private Sub PlisticBlue_Spe_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Back_color)
        e.Graphics.DrawLine(New Pen(Side_Color), New Point(3, Me.Height / 2), New Point(Me.Width - 4, Me.Height / 2))
        e.Graphics.DrawLine(New Pen(Main_Color), New Point(SubtractSep - 1, Me.Height / 2), New Point(Me.Width - SubtractSep, Me.Height / 2))
    End Sub
End Class
Public Class PlisticBlue_GroupBox
    Inherits Panel
    Sub New()
        Me.DoubleBuffered = True
        Me.Padding = New Padding(5, 5, 5, 5)
    End Sub
    Property Main_color As Color = Color.FromArgb(19, 28, 52)
    Property back_color As Color = Color.FromArgb(25, 38, 69)
#Region "Functions"
    Public Sub FixRoundRectClicked(g As Graphics)
        'Fix Top
        'Line right 
        g.DrawLine(New Pen(Main_Color), New Point(Me.Width - 7, 2), New Point(Me.Width - 7, 7))
        'Line left
        g.DrawLine(New Pen(Main_Color), New Point(7, 2), New Point(7, 7))
        'Long Line
        g.DrawLine(New Pen(Main_Color), New Point(2, 7), New Point(Me.Width - 2, 7))
        'Fix Bottom
        'Line Bottom Right 
        ' g.DrawLine(New Pen(Under_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 4))
        'Line Bottom Left
        ' g.DrawLine(New Pen(Under_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 4))
        'Line right
        g.DrawLine(New Pen(Main_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 6))
        'Line left
        g.DrawLine(New Pen(Main_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 6))
        'Long Line
        g.DrawLine(New Pen(Main_Color), New Point(2, Me.Height - 7), New Point(Me.Width - 2, Me.Height - 7))
    End Sub
    Public Sub FixRoundRect(g As Graphics)
        'Fix Top
        'Line right 
        g.DrawLine(New Pen(Main_Color), New Point(Me.Width - 7, 2), New Point(Me.Width - 7, 7))
        'Line left
        g.DrawLine(New Pen(Main_Color), New Point(7, 2), New Point(7, 7))
        'Long Line
        g.DrawLine(New Pen(Main_Color), New Point(2, 7), New Point(Me.Width - 2, 7))
        'Fix Bottom
        'Line Bottom Right 
        ' g.DrawLine(New Pen(Under_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 4))
        'Line Bottom Left
        'g.DrawLine(New Pen(Under_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 4))
        'Line right
        g.DrawLine(New Pen(Main_Color), New Point(Me.Width - 7, Me.Height - 6), New Point(Me.Width - 7, Me.Height - 11))
        'Line left
        g.DrawLine(New Pen(Main_Color), New Point(7, Me.Height - 6), New Point(7, Me.Height - 11))
        'Long Line
        g.DrawLine(New Pen(Main_Color), New Point(2, Me.Height - 11), New Point(Me.Width - 2, Me.Height - 11))
    End Sub
    Public Sub DrawRoundRect(g As Graphics, p As Pen, x As Single, y As Single, width As Single, height As Single, _
      radius As Single)
        Dim gp As New GraphicsPath()

        gp.AddLine(x + radius, y, x + width - (radius * 2), y)
        ' Line
        gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90)
        ' Corner
        gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2))
        ' Line
        gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90)
        ' Corner
        gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height)
        ' Line
        gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90)
        ' Corner
        gp.AddLine(x, y + height - (radius * 2), x, y + radius)
        ' Line
        gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
        ' Corner
        gp.CloseFigure()

        g.DrawPath(p, gp)
        gp.Dispose()
    End Sub
    Public Sub FillRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
    Public Sub FillNotTopRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
        g.FillPie(b, r.X, r.Y, 1, 1, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, 1, 1, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        ' g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
    Public Sub FillNotBottomRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        'g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        '  g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        ' g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        '   g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
#End Region

    Private Sub PlisticBlue_GroupBox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(back_color)
        FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 2, Me.Height - 2), 12, New SolidBrush(Main_color))
        FixRoundRectClicked(e.Graphics)
    End Sub
End Class
Public Class FluidButton
    Inherits Control
    Event Lefted_Clicked()
    <Category("Animation")>
    Property Animation As Boolean = False
    <Category("Animation")>
    Property CountMax As Integer = 120
    <Category("Animation")>
    Property Clicked As Boolean = False
    <Category("Animation")>
    Property CurrCount As Integer = 0
    <Category("Animation")>
    Property Shad As Integer = 20
    <Category("Animation")>
    Property StartShad As Integer = 20
    <Category("Animation")>
    Property SGD As Boolean = False
    <Category("Animation")>
    Property Momentum As Integer = 1
    <Category("Animation")>
    Property Speed As Integer = 20
    <Category("Animation")>
    Property Texxt As String = "Button"
    <Category("Animation")>
    Property StartSize As Size = New Size(30, 30)
    <Category("Animation")>
    Property MouseLoc As Point
    <Category("Animation")>
    Property PostSize As Size = New Size(30, 30)
    <Category("Color")>
    Property Main_color As Color = Color.FromArgb(166, 172, 192)
    <Category("Color")>
    Property Text_color As Color = Color.FromArgb(166, 172, 192)
    <Category("Color")>
    Property Back_color As Color = Color.FromArgb(25, 38, 69)
    Property Fonnt As Font = New Font("Arial", 11, FontStyle.Regular)
    Dim tmr As New Timer
#Region "Mouse Events"
    Private Sub FluidEngine_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If New Rectangle(2, 2, Me.Width - 2, Me.Height - 2).Contains(e.X, e.Y) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
    End Sub
    Private Sub FluidEngine_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        'Reset
        For Each tim As Timer In Me.Controls.OfType(Of Timer)()
            tim.Dispose()
        Next
        tmr = New Timer
        PostSize = StartSize
        CurrCount = 0
        Shad = StartShad
        'Prepare
        tmr.Interval = Speed
        AddHandler tmr.Tick, AddressOf tmr_Tick
        If Animation = True Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RaiseEvent Lefted_Clicked()
                Clicked = True
                MouseLoc = New Point(e.X, e.Y)
                tmr.Start()

            End If
        End If
    End Sub
#End Region
    Sub New()
        Me.DoubleBuffered = True
    End Sub



    Private Sub FluidEngine_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Back_color)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        ' e.Graphics.DrawRectangle(Pens.Black, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
        e.Graphics.DrawString(Text, Fonnt, New SolidBrush(Text_color), New Rectangle(0, 0, Me.Width, Me.Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        If Clicked = True Then
            e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(Shad, Main_color)), New Rectangle(New Point(MouseLoc.X - (StartSize.Width + CurrCount) / 2, MouseLoc.Y - (StartSize.Height + CurrCount) / 2), New Point(StartSize.Width + CurrCount, StartSize.Height + CurrCount)))
        End If

    End Sub
#Region "Animation Timer"
    Private Sub tmr_Tick(sender As Object, e As EventArgs)
        If CurrCount = CountMax Then
            tmr.Stop()
            Clicked = False
            Me.Refresh()
        Else
            If SGD = True Then
                If Not Shad = 255 Then
                    Shad += Momentum
                End If
            Else
                If Not Shad = 0 Then
                    Shad -= Momentum
                End If
            End If

            CurrCount += Momentum
            Me.Refresh()
        End If
    End Sub
#End Region

End Class
Public Class PlisticBlue_Checkbox
    Inherits Control
    Sub New()
        Me.DoubleBuffered = True
        Me.Width = 100
        Me.Height = 60
    End Sub
    <Category("Color")>
    Property Border_color As Color = Color.FromArgb(166, 172, 192)
    <Category("Color")>
    Property Check_color As Color = Color.FromArgb(25, 38, 69)
    <Category("Color")>
    Property Checked_color As Color = Color.FromArgb(166, 172, 192)
    <Category("Color")>
    Property Text_color As Color = Color.FromArgb(166, 172, 192)
    <Category("Color")>
    Property Back_color As Color = Color.FromArgb(25, 38, 69)
    Property Fonnt As Font = New Font("Arial", 11, FontStyle.Regular)
#Region "Functions"
    Public Sub FixRoundRectClicked(g As Graphics, rect As Rectangle)
        'Fix Top
        'Line right 
        g.DrawLine(New Pen(Checked_color), New Point(rect.Width - 7, 2), New Point(rect.Width - 7, 7))
        'Line left
        g.DrawLine(New Pen(Checked_color), New Point(7, 2), New Point(7, 7))
        'Long Line
        g.DrawLine(New Pen(Checked_color), New Point(2, 7), New Point(rect.Width - 2, 7))
        'Fix Bottom
        'Line Bottom Right 
        ' g.DrawLine(New Pen(Under_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 4))
        'Line Bottom Left
        ' g.DrawLine(New Pen(Under_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 4))
        'Line right
        g.DrawLine(New Pen(Checked_color), New Point(rect.Width - 7, rect.Height - 2), New Point(rect.Width - 7, rect.Height - 6))
        'Line left
        g.DrawLine(New Pen(Checked_color), New Point(7, rect.Height - 2), New Point(7, rect.Height - 6))
        'Long Line
        g.DrawLine(New Pen(Checked_color), New Point(2, rect.Height - 7), New Point(rect.Width - 2, rect.Height - 7))
    End Sub
    Public Sub FixRoundRect(g As Graphics)
        'Fix Top
        'Line right 
        g.DrawLine(New Pen(Checked_color), New Point(Me.Width - 7, 2), New Point(Me.Width - 7, 7))
        'Line left
        g.DrawLine(New Pen(Checked_color), New Point(7, 2), New Point(7, 7))
        'Long Line
        g.DrawLine(New Pen(Checked_color), New Point(2, 7), New Point(Me.Width - 2, 7))
        'Fix Bottom
        'Line Bottom Right 
        ' g.DrawLine(New Pen(Under_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 4))
        'Line Bottom Left
        'g.DrawLine(New Pen(Under_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 4))
        'Line right
        g.DrawLine(New Pen(Checked_color), New Point(Me.Width - 7, Me.Height - 6), New Point(Me.Width - 7, Me.Height - 11))
        'Line left
        g.DrawLine(New Pen(Checked_color), New Point(7, Me.Height - 6), New Point(7, Me.Height - 11))
        'Long Line
        g.DrawLine(New Pen(Checked_color), New Point(2, Me.Height - 11), New Point(Me.Width - 2, Me.Height - 11))
    End Sub
    Public Sub DrawRoundRect(g As Graphics, p As Pen, x As Single, y As Single, width As Single, height As Single, _
      radius As Single)
        Dim gp As New GraphicsPath()

        gp.AddLine(x + radius, y, x + width - (radius * 2), y)
        ' Line
        gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90)
        ' Corner
        gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2))
        ' Line
        gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90)
        ' Corner
        gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height)
        ' Line
        gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90)
        ' Corner
        gp.AddLine(x, y + height - (radius * 2), x, y + radius)
        ' Line
        gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
        ' Corner
        gp.CloseFigure()

        g.DrawPath(p, gp)
        gp.Dispose()
    End Sub
    Public Sub FillRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
    Public Sub FillNotTopRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
        g.FillPie(b, r.X, r.Y, 1, 1, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, 1, 1, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        ' g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
    Public Sub FillNotBottomRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        'g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        '  g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        ' g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        '   g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
#End Region
    Property Checked As Boolean = False
    Event CheckedChanged()
    Private Sub PlisticBlue_Checkbox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Back_color)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        If Checked = False Then
            DrawRoundRect(e.Graphics, New Pen(Border_color), 1, 1, 20, 20, 2)
        Else
            DrawRoundRect(e.Graphics, New Pen(Border_color), 1, 1, 20, 20, 2)
            FillRoundedRectangle(e.Graphics, New Rectangle(0, 0, 21, 22), 2, New SolidBrush(Checked_color))
            FixRoundRectClicked(e.Graphics, New Rectangle(0, 0, 21, 22))
            e.Graphics.DrawString("a", New Font("Webdings", 16, FontStyle.Regular), New SolidBrush(Check_color), New Rectangle(2, 0, 20, 20), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End If
        e.Graphics.DrawString(Text, Fonnt, New SolidBrush(Text_color), New Rectangle(24, 1, Me.Width - 23, Me.Height - 2), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    End Sub
#Region "Mouse"
    Private Sub PlisticBlue_Checkbox_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If New Rectangle(1, 1, 20, 20).Contains(e.X, e.Y) Then
                Checked = Not Checked
                RaiseEvent CheckedChanged()
                Me.Refresh()
            End If
        End If
    End Sub

    Private Sub PlisticBlue_Checkbox_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If New Rectangle(1, 1, 20, 20).Contains(e.X, e.Y) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
    End Sub
#End Region
End Class
Public Class PlisticBlue_TabSelector
    Inherits Control
    Property UnSelected_Circle_Color As Color = Color.FromArgb(52, 65, 94)
    Property Selected_Circle_Color As Color = Color.FromArgb(166, 172, 192)
    Property Selected_inCircle_Color As Color = Color.FromArgb(25, 38, 69)
    Property unSelected_inCircle_Color As Color = Color.FromArgb(52, 65, 94)
    Property Selected_line_Color As Color = Color.FromArgb(166, 172, 192)
    Property UnSelected_line_Color As Color = Color.FromArgb(52, 65, 94)
    Property back_Color As Color = Color.FromArgb(25, 38, 69)
    Enum Selct
        Step1
        Step2
        Step3
    End Enum
    Property Selected As Selct
    Sub New()
        Me.DoubleBuffered = True
        Me.Width = 100
        Me.Height = 20
    End Sub


    Private Sub PlisticBlue_TabSelector_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(back_Color)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Select Case Selected

            Case Selct.Step1
                e.Graphics.FillRectangle(New SolidBrush(UnSelected_line_Color), New Rectangle(4, Me.Height / 2 - 2, Me.Width / 2 - 9, 4))
                e.Graphics.FillEllipse(New SolidBrush(Selected_Circle_Color), New Rectangle(0, 0, 18, 18))
                e.Graphics.FillEllipse(New SolidBrush(Selected_inCircle_Color), New Rectangle(4, 4, 10, 10))
                e.Graphics.FillRectangle(New SolidBrush(UnSelected_line_Color), New Rectangle(Me.Width / 2 + 2, Me.Height / 2 - 2, Me.Width / 2 - 9, 4))
                e.Graphics.FillEllipse(New SolidBrush(UnSelected_Circle_Color), New Rectangle(Me.Width / 2 - 9, 0, 18, 18))
                e.Graphics.FillEllipse(New SolidBrush(unSelected_inCircle_Color), New Rectangle(Me.Width / 2 - 5, 4, 10, 10))
                e.Graphics.FillEllipse(New SolidBrush(UnSelected_Circle_Color), New Rectangle(Me.Width - 19, 0, 18, 18))
                e.Graphics.FillEllipse(New SolidBrush(unSelected_inCircle_Color), New Rectangle(Me.Width - 15, 4, 10, 10))
            Case Selct.Step2
                e.Graphics.FillRectangle(New SolidBrush(Selected_line_Color), New Rectangle(4, Me.Height / 2 - 2, Me.Width / 2 - 9, 4))
                e.Graphics.FillEllipse(New SolidBrush(Selected_Circle_Color), New Rectangle(0, 0, 18, 18))
                e.Graphics.FillEllipse(New SolidBrush(Selected_inCircle_Color), New Rectangle(4, 4, 10, 10))
                e.Graphics.FillRectangle(New SolidBrush(UnSelected_line_Color), New Rectangle(Me.Width / 2 + 2, Me.Height / 2 - 2, Me.Width / 2 - 9, 4))
                e.Graphics.FillEllipse(New SolidBrush(Selected_Circle_Color), New Rectangle(Me.Width / 2 - 9, 0, 18, 18))
                e.Graphics.FillEllipse(New SolidBrush(Selected_inCircle_Color), New Rectangle(Me.Width / 2 - 5, 4, 10, 10))
                e.Graphics.FillEllipse(New SolidBrush(UnSelected_Circle_Color), New Rectangle(Me.Width - 19, 0, 18, 18))
                e.Graphics.FillEllipse(New SolidBrush(unSelected_inCircle_Color), New Rectangle(Me.Width - 15, 4, 10, 10))
            Case Selct.Step3
                e.Graphics.FillRectangle(New SolidBrush(Selected_line_Color), New Rectangle(4, Me.Height / 2 - 2, Me.Width / 2 - 9, 4))
                e.Graphics.FillEllipse(New SolidBrush(Selected_Circle_Color), New Rectangle(0, 0, 18, 18))
                e.Graphics.FillEllipse(New SolidBrush(Selected_inCircle_Color), New Rectangle(4, 4, 10, 10))
                e.Graphics.FillRectangle(New SolidBrush(Selected_line_Color), New Rectangle(Me.Width / 2 + 2, Me.Height / 2 - 2, Me.Width / 2 - 9, 4))
                e.Graphics.FillEllipse(New SolidBrush(Selected_Circle_Color), New Rectangle(Me.Width / 2 - 9, 0, 18, 18))
                e.Graphics.FillEllipse(New SolidBrush(Selected_inCircle_Color), New Rectangle(Me.Width / 2 - 5, 4, 10, 10))
                e.Graphics.FillEllipse(New SolidBrush(Selected_Circle_Color), New Rectangle(Me.Width - 19, 0, 18, 18))
                e.Graphics.FillEllipse(New SolidBrush(Selected_inCircle_Color), New Rectangle(Me.Width - 15, 4, 10, 10))
        End Select
    End Sub
    Event SelectedChange(Selectted As Selct)
    Property Lock As Boolean = False
#Region "Mouse"

    Private Sub PlisticBlue_TabSelector_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Not Lock = True Then
                    If New Rectangle(0, 0, 18, 18).Contains(e.X, e.Y) Then
                        RaiseEvent SelectedChange(Selct.Step1)
                        Selected = Selct.Step1
                        Me.Refresh()
                    End If
                    If New Rectangle(Me.Width / 2 - 9, 0, 18, 18).Contains(e.X, e.Y) Then
                        RaiseEvent SelectedChange(Selct.Step2)
                        Selected = Selct.Step2
                        Me.Refresh()
                    End If
                    If New Rectangle(Me.Width - 19, 0, 18, 18).Contains(e.X, e.Y) Then
                        RaiseEvent SelectedChange(Selct.Step3)
                        Selected = Selct.Step3
                        Me.Refresh()
                    End If
            End If
        End If
    End Sub

    Private Sub PlisticBlue_TabSelector_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If New Rectangle(Me.Width - 19, 0, 18, 18).Contains(e.X, e.Y) Or New Rectangle(Me.Width / 2 - 9, 0, 18, 18).Contains(e.X, e.Y) Or New Rectangle(0, 0, 18, 18).Contains(e.X, e.Y) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
    End Sub
#End Region
End Class
Public Class PlisticBlue_Textbox
    Inherits Control
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub
    Sub New()
        Me.DoubleBuffered = True
        Me.Width = 150
        Me.Height = 40
        'TB
        MyBase.Font = Text_Font
        TB = New Windows.Forms.TextBox
        TB.BackColor = Text_Back_Color
        TB.Font = New Font("Segoe UI", 9)
        TB.Text = Text
        TB.BackColor = Textbox_Back_Color
        TB.ForeColor = Text_Color
        TB.MaxLength = MaxLeng
        TB.Multiline = False
        TB.ReadOnly = ReadOnlyy
        TB.UseSystemPasswordChar = UseChar
        TB.BorderStyle = BorderStyle.None
        If Icon = True Then
            TB.Location = New Point(40, Me.Height / 2 - TB.Height / 2)
            TB.Size = New Size(Me.Width - 44, TB.Height)
        Else
            TB.Location = New Point(10, Me.Height / 2 - TB.Height / 2)
            TB.Size = New Size(Me.Width - 14, TB.Height)
        End If
        TB.Font = MyBase.Font
    End Sub
#Region "Properties"
    Public WithEvents TB As New TextBox
    Property Icon As Boolean = False
    Property Image As Image
    Private Text_Color As Color = Color.FromArgb(166, 172, 192)
    Private Text_Font As Font = New Font("Arial", 11, FontStyle.Regular)
    Private back_Color As Color = Color.FromArgb(25, 38, 69)
    Private Text_Back_Color As Color = Color.FromArgb(15, 23, 41)
    Private UseChar As Boolean = False
    Property Lock As Boolean = False
    Private Textbox_Back_Color As Color = Color.FromArgb(15, 23, 41)
    Private MaxLeng As Integer = 255
    Private ReadOnlyy As Boolean = False
    Private TextAlignn As HorizontalAlignment = HorizontalAlignment.Left
    Private Multilinee As Boolean
    Public Sub SelectAll()
        TB.Focus()
        TB.SelectAll()
        Invalidate()
    End Sub

    <Category("Textbox")>
    Public Property BaseColour As Color
        Get
            Return Textbox_Back_Color
        End Get
        Set(value As Color)
            Textbox_Back_Color = value
        End Set
    End Property

    <Category("Textbox")>
    Public Property TextColour As Color
        Get
            Return Text_Color
        End Get
        Set(value As Color)
            Text_Color = value
        End Set
    End Property



    <Category("Textbox")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return TextAlignn
        End Get
        Set(ByVal value As HorizontalAlignment)
            TextAlignn = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property

    <Category("Textbox")>
    Property MaxLength() As Integer
        Get
            Return MaxLeng
        End Get
        Set(ByVal value As Integer)
            MaxLeng = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property

    <Category("Textbox")>
    Property [ReadOnly]() As Boolean
        Get
            Return ReadOnlyy
        End Get
        Set(ByVal value As Boolean)
            ReadOnlyy = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Textbox")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return UseChar
        End Get
        Set(ByVal value As Boolean)
            UseChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    <Category("Textbox")>
    Property Textt As String
        Get
            Return Text
        End Get
        Set(ByVal value As String)
            Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property

#End Region
#Region "Functions"
    Public Sub FixRoundRectClicked(g As Graphics)
        'Fix Top
        'Line right 
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(Me.Width - 7, 2), New Point(Me.Width - 7, 7))
        'Line left
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(7, 2), New Point(7, 7))
        'Long Line
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(2, 7), New Point(Me.Width - 2, 7))
        'Fix Bottom
        'Line Bottom Right 
        ' g.DrawLine(New Pen(Under_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 4))
        'Line Bottom Left
        ' g.DrawLine(New Pen(Under_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 4))
        'Line right
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 6))
        'Line left
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 6))
        'Long Line
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(2, Me.Height - 7), New Point(Me.Width - 2, Me.Height - 7))
    End Sub
    Public Sub FixRoundRect(g As Graphics)
        'Fix Top
        'Line right 
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(Me.Width - 7, 2), New Point(Me.Width - 7, 7))
        'Line left
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(7, 2), New Point(7, 7))
        'Long Line
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(2, 7), New Point(Me.Width - 2, 7))
        'Fix Bottom
        'Line Bottom Right 
        ' g.DrawLine(New Pen(Under_Color), New Point(7, Me.Height - 2), New Point(7, Me.Height - 4))
        'Line Bottom Left
        'g.DrawLine(New Pen(Under_Color), New Point(Me.Width - 7, Me.Height - 2), New Point(Me.Width - 7, Me.Height - 4))
        'Line right
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(Me.Width - 7, Me.Height - 6), New Point(Me.Width - 7, Me.Height - 11))
        'Line left
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(7, Me.Height - 6), New Point(7, Me.Height - 11))
        'Long Line
        g.DrawLine(New Pen(Textbox_Back_Color), New Point(2, Me.Height - 11), New Point(Me.Width - 2, Me.Height - 11))
    End Sub
    Public Sub DrawRoundRect(g As Graphics, p As Pen, x As Single, y As Single, width As Single, height As Single, _
      radius As Single)
        Dim gp As New GraphicsPath()

        gp.AddLine(x + radius, y, x + width - (radius * 2), y)
        ' Line
        gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90)
        ' Corner
        gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2))
        ' Line
        gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90)
        ' Corner
        gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height)
        ' Line
        gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90)
        ' Corner
        gp.AddLine(x, y + height - (radius * 2), x, y + radius)
        ' Line
        gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
        ' Corner
        gp.CloseFigure()

        g.DrawPath(p, gp)
        gp.Dispose()
    End Sub
    Public Sub FillRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
    Public Sub FillNotTopRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
        g.FillPie(b, r.X, r.Y, 1, 1, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, 1, 1, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        ' g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
    Public Sub FillNotBottomRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        'g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        '  g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        ' g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        '   g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
#End Region

    Private Sub PlisticBlue_Textbox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(back_Color)
        FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 2, Me.Height - 2), 12, New SolidBrush(Textbox_Back_Color))
        FixRoundRectClicked(e.Graphics)
        TB.BackColor = Textbox_Back_Color
        TB.ForeColor = Text_Color
        If Icon = True Then
            e.Graphics.DrawImage(Image, New Rectangle(6, 6, 32, 32))
        End If
        If Lock = True Then
            TB.ReadOnly = True
            ReadOnlyy = True
            TB.Refresh()
            '  FixRoundRectClicked(e.Graphics)
        Else
            TB.ReadOnly = False
            ReadOnlyy = False
            TB.Refresh()
        End If
    End Sub

    Private Sub PlisticBlue_Textbox_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Icon = True Then
            TB.Location = New Point(40, Me.Height / 2 - TB.Height / 2)
            TB.Size = New Size(Me.Width - 44, TB.Height)
        Else
            TB.Location = New Point(10, Me.Height / 2 - TB.Height / 2)
            TB.Size = New Size(Me.Width - 14, TB.Height)
        End If
    End Sub
    Event TextChangedd(text As String)
    Private Sub TB_TextChanged(sender As Object, e As EventArgs) Handles TB.TextChanged
        Text = TB.Text
        Textt = TB.Text
        RaiseEvent TextChangedd(Text)
    End Sub
End Class