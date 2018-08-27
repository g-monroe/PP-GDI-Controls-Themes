Imports System.Drawing.Drawing2D

Public Class PokeGroup
    Inherits Control
    Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(160, 40)
    End Sub
    Property Shadow As Boolean = False
    Property Color1 As Color = Color.FromArgb(255, 254, 255)
    Property Color2 As Color = Color.FromArgb(242, 254, 234)
    Property BorderColor As Color = Color.FromArgb(29, 209, 165)
    Property Curve As Integer = 10
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
    Public Function gb(e As Graphics, r As Rectangle, c1 As Color, c2 As Color) As LinearGradientBrush
        Dim g As Graphics = e
        Dim p1 As Point = r.Location
        Dim p2 As Point = New Point(r.Right, r.Bottom)
        Dim brsGradient As New System.Drawing.Drawing2D.LinearGradientBrush(p1, p2, c1, c2)
        Return brsGradient
    End Function
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim b As New Bitmap(Width, Height)
        Dim g As Graphics = Graphics.FromImage(b)
        g.Clear(BackColor)
        g.SmoothingMode = SmoothingMode.AntiAlias
        If Shadow Then
            g.FillPath(New SolidBrush(Color.FromArgb(180, Color.Gray)), Round(New Rectangle(3, 3, Me.Width - 4, Me.Height - 4), 10))
            g.FillPath(gb(g, New Rectangle(0, 0, Me.Width - 6, Me.Height - 6), Color1, Color2), Round(New Rectangle(0, 0, Me.Width - 4, Me.Height - 4), Curve))
            Me.Padding = New Padding(2, 2, Me.Width - 8, Me.Height - 8)
        Else
            g.FillPath(gb(g, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), Color1, Color2), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), Curve))
            Me.Padding = New Padding(2, 2, Me.Width - 3, Me.Height - 3)
        End If


        e.Graphics.DrawImage(b.Clone, 0, 0)
        g.Dispose()
        b.Dispose()
    End Sub
End Class