Imports System.Drawing.Drawing2D
 'Progammed by Kevin
 'leave credit
Public Class RoundLabel
    Inherits Control
    Property mainColor As Color = Color.FromArgb(242, 108, 79)
    Property textColor As Color = Color.White
    Property resizeText As Boolean = False
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
    Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(160, 20)
    End Sub
 
    Private Sub LabelR_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.FillPath(New SolidBrush(mainColor), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), Me.Height))
        If resizeText Then
            'Font resizing by Andro72(http://goo.gl/1kS7O0)
            Dim extent As SizeF = g.MeasureString(Me.Text, Me.Font)
            Dim hRatio As Single = Me.Height / extent.Height
            Dim wRatio As Single = Me.Width / extent.Width
            Dim ratio As Single = If((hRatio < wRatio), hRatio, wRatio)
            Dim newSize As Single = Me.Font.Size * ratio
            Me.Font = New Font(Me.Font.FontFamily, newSize, Me.Font.Style)
        End If
        g.DrawString(Me.Text, Me.Font, New SolidBrush(textColor), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    End Sub
End Class