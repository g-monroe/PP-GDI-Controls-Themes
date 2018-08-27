'Random Controls: Note
'By Nettro ;P
Imports System.Drawing.Drawing2D

Public Class Note
    Inherits Panel
    Sub New()
        Me.DoubleBuffered = True
    End Sub
#Region "Functions"
#Region "Modules & Functions"
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
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
#End Region
    Property Back_color As Color = Color.White
    Property Border_color As Color = Color.FromArgb(124, 186, 75)
    Property IcoSize As Size = New Size(54, 54)
    Property IcoLocation As Point = New Point(12, 8)
    Property Fill_color As Color = Color.FromArgb(138, 193, 92)
    Property Border_color2 As Color = Color.FromArgb(199, 254, 161)
    Property Text_color As Color = Color.FromArgb(233, 233, 233)
    Property Link_color As Color = Color.FromArgb(104, 154, 57)
    Dim Link_hover As Boolean = False
    Dim Link2_hover As Boolean = False
    Event Link1_Clicked()
    Event Link2_Clicked()
    Event Closed_Clicked()
    Property IconType As IcoType = IcoType.Text
    Property Image As Image
    Enum IcoType
        Image
        Text
    End Enum
    Property Link_text As String = "Link to facebook."
    Property Link2_text As String = "Sign out or Login in."
    Property header_text As String = "25:00x"
    Property para_text As String = "This is a note and you are looking at it right now because you like it."
    Property In_Circle_Text As String = "None"

    Private Sub Note_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If New Rectangle(Me.Width - 28, 20, 20, 20).Contains(e.X, e.Y) Then
                RaiseEvent Closed_Clicked()
            End If
            If New Rectangle(28, Me.Height - 25, 80, 12).Contains(e.X, e.Y) Then
                RaiseEvent Link1_Clicked()
            End If
            If New Rectangle(Me.Width - 105, Me.Height - 25, 90, 12).Contains(e.X, e.Y) Then
                RaiseEvent Link2_Clicked()
            End If
        End If
    End Sub

    Private Sub Note_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If New Rectangle(Me.Width - 105, Me.Height - 25, 90, 12).Contains(e.X, e.Y) Then
            Link2_hover = True
            Me.Refresh()
        Else
            Link2_hover = False
        End If
        If New Rectangle(28, Me.Height - 25, 80, 12).Contains(e.X, e.Y) Then
            Link_hover = True
            Me.Refresh()
        Else
            Link_hover = False
        End If
        If New Rectangle(Me.Width - 28, 20, 20, 20).Contains(e.X, e.Y) Or New Rectangle(Me.Width - 105, Me.Height - 25, 90, 12).Contains(e.X, e.Y) Or New Rectangle(28, Me.Height - 25, 80, 12).Contains(e.X, e.Y) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
    End Sub
    Private Sub Note_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Back_color)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        FillRoundedRectangle(e.Graphics, New Rectangle(18, 18, Me.Width - 26, Me.Height - 26), 8, New SolidBrush(Border_color))
        FillRoundedRectangle(e.Graphics, New Rectangle(20, 20, Me.Width - 30, Me.Height - 30), 8, New SolidBrush(Fill_color))
        '   DrawRoundRect(e.Graphics, New Pen(Border_color), 20, 20, Me.Width - 30, Me.Height - 30, 6)
        Dim rect = New Rectangle(5, 5, 65, 65)
        Dim brushs = New LinearGradientBrush(rect, Border_color, Border_color2, 90.0!)
        e.Graphics.FillEllipse(brushs, rect)
        e.Graphics.FillEllipse(New SolidBrush(Fill_color), New Rectangle(8, 8, 60, 60))
        If IconType = IcoType.Text Then
            e.Graphics.DrawString(In_Circle_Text, New Font("Arial", 10.5, FontStyle.Regular), New SolidBrush(Text_color), New Rectangle(8, 16, 58, 40), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Else
            e.Graphics.DrawImage(Image, New Rectangle(IcoLocation, IcoSize))
        End If
        e.Graphics.DrawString("x", New Font("Arial", 10.5, FontStyle.Regular), New SolidBrush(Text_color), New Rectangle(Me.Width - 28, 20, 20, 20), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        e.Graphics.DrawString(header_text, New Font("Arial", 16.5, FontStyle.Regular), New SolidBrush(Text_color), New Rectangle(75, 32, 80, 35), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        e.Graphics.DrawString(para_text, New Font("Arial", 8.5, FontStyle.Regular), New SolidBrush(Text_color), New Rectangle(75, 60, Me.Width - 86, Me.Height - 84), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        If Link_hover = False Then
            e.Graphics.DrawString(Link_text, New Font("Arial", 7.5, FontStyle.Regular), New SolidBrush(Link_color), New Rectangle(28, Me.Height - 25, 80, 12), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        Else
            e.Graphics.DrawString(Link_text, New Font("Arial", 7.5, FontStyle.Underline), New SolidBrush(Link_color), New Rectangle(28, Me.Height - 25, 80, 12), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        End If
        If Link2_hover = False Then
            e.Graphics.DrawString(Link2_text, New Font("Arial", 7.5, FontStyle.Regular), New SolidBrush(Link_color), New Rectangle(Me.Width - 105, Me.Height - 25, 90, 12), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        Else
            e.Graphics.DrawString(Link2_text, New Font("Arial", 7.5, FontStyle.Underline), New SolidBrush(Link_color), New Rectangle(Me.Width - 105, Me.Height - 25, 90, 12), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        End If
    End Sub

End Class