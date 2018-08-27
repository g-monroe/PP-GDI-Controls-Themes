Imports System.Drawing.Drawing2D
 
Public Class PokeButton
    Inherits Control
    Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(160, 40)
    End Sub
    Property Shadow As Boolean = False
    Property Color1 As Color = Color.FromArgb(169, 219, 156)
    Property Color2 As Color = Color.FromArgb(29, 209, 165)
    Property BorderColor As Color = Color.FromArgb(29, 209, 165)
    Property TextColor As Color = Color.White
    Property Curve As Integer = 40
    Dim mHover As Boolean = False
    Dim mClick As Boolean = False
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
            g.FillPath(New SolidBrush(Color.FromArgb(120, Color.Gray)), Round(New Rectangle(8, 8, Me.Width - 10, Me.Height - 10), Curve))
            g.FillPath(New SolidBrush(BorderColor), Round(New Rectangle(0, 0, Me.Width - 10, Me.Height - 10), Curve + 2))
            g.FillPath(gb(g, New Rectangle(1, 1, Me.Width - 12, Me.Height - 12), Color1, Color2), Round(New Rectangle(1, 1, Me.Width - 12, Me.Height - 12), Curve))
            g.DrawString(Text, New Font("Arial", 10, FontStyle.Bold), New SolidBrush(TextColor), New Rectangle(1, 1, Me.Width - 12, Me.Height - 12), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Else
            g.FillPath(New SolidBrush(BorderColor), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), Curve + 2))
            g.FillPath(gb(g, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), Color1, Color2), Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), Curve))
            g.DrawString(Text, New Font("Arial", 10, FontStyle.Bold), New SolidBrush(TextColor), New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End If
        If mHover And mClick = False Then
            g.FillPath(New SolidBrush(Color.FromArgb(60, Color.Gray)), Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), Curve))
        ElseIf mClick = True Then
            g.FillPath(New SolidBrush(Color.FromArgb(60, Color.Black)), Round(New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), Curve))
 
        End If
     
        e.Graphics.DrawImage(b.Clone, 0, 0)
        g.Dispose()
        b.Dispose()
    End Sub
 
    Private Sub PokeButton_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Shadow Then
                If New Rectangle(1, 1, Me.Width - 12, Me.Height - 12).Contains(e.X, e.Y) Then
                    mClick = True
 
                    Cursor = Cursors.Hand
                    Me.Refresh()
                End If
            Else
                If New Rectangle(1, 1, Me.Width - 3, Me.Height - 3).Contains(e.X, e.Y) Then
                    mClick = True
                    Cursor = Cursors.Hand
                    Me.Refresh()
                End If
            End If
        End If
    End Sub
 
    Private Sub PokeButton_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        mHover = False
        Me.Refresh()
    End Sub
 
    Private Sub PokeButton_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If Shadow Then
            If New Rectangle(1, 1, Me.Width - 12, Me.Height - 12).Contains(e.X, e.Y) Then
                mHover = True
                Cursor = Cursors.Hand
                Me.Refresh()
            End If
        Else
            If New Rectangle(1, 1, Me.Width - 3, Me.Height - 3).Contains(e.X, e.Y) Then
                mHover = True
                Cursor = Cursors.Hand
                Me.Refresh()
            End If
        End If
 
    End Sub
Event Clicked()
    Private Sub PokeButton_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        RaiseEvent Clicked()
        mHover = False
        mClick = False
        Me.Refresh()
    End Sub
End Class