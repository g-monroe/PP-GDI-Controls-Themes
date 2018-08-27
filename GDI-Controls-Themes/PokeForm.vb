Imports System.Drawing.Drawing2D
Public Class FormContainer
    Inherits Panel
    Public WithEvents tmr As New Timer With {.Interval = 40, .Enabled = True}
    Public avatar As Image
    Property pLoc_x As Integer = 0
    Sub New()
        Me.DoubleBuffered = True
    End Sub
    Private Sub tmr_Tick(sender As Object, e As EventArgs) Handles tmr.Tick
        If Not pLoc_x = -(1570) Then
            pLoc_x -= 1
        Else
            pLoc_x = 0
        End If
       
        Me.Refresh()
    End Sub
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
#Region "ThemeDraggable"
    Dim x, y As Integer
    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width, 30)
        If dragRect.Contains(New Point(e.X, e.Y)) Then
            Me.Cursor = Cursors.Hand
            isDragging = True
            savePoint = New Point(e.X, e.Y)

        End If

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
            Me.Cursor = Cursors.Hand
            FindForm().Location = New Point(screenPoint.X - Me.savePoint.X, screenPoint.Y - Me.savePoint.Y)
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
    Public Shared Function CropToCircle(srcImage As Image, backGround As Color) As Image
        Dim dstImage As Image = New Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat)
        Dim g As Graphics = Graphics.FromImage(dstImage)
        Using br As Brush = New SolidBrush(backGround)
            g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height)
        End Using
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, dstImage.Width, dstImage.Height)
        g.SetClip(path)
        g.DrawImage(srcImage, 0, 0)

        Return dstImage
    End Function
    Public Function gb(e As Graphics, r As Rectangle, c1 As Color, c2 As Color) As LinearGradientBrush
        Dim g As Graphics = e
        Dim p1 As Point = r.Location
        Dim p2 As Point = New Point(r.Right, r.Bottom)
        Dim brsGradient As New System.Drawing.Drawing2D.LinearGradientBrush(p1, p2, c1, c2)
        Return brsGradient
    End Function
    Function CheckStr(str As String, max As Integer) As String
        Dim strmax As Integer
        Try
            strmax = str.Count
        Catch ex As Exception
            strmax = 1
        End Try

        Dim newstr As String = ""
        If strmax > max Then
            Dim countt As Integer = 0
            For Each Charr As Char In str
                countt += 1
                If countt <= max Then
                    newstr += Charr
                ElseIf countt <= max + 3 Then
                    newstr += "."
                End If
            Next
        Else
            newstr = str
        End If
        Return newstr
    End Function
    Private Sub FormContainer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawImage(My.Resources.bg, New Rectangle(0, 0, Me.Width, Me.Height))
        g.DrawImage(My.Resources.Clouds, New Rectangle(pLoc_x, 0, 1920, 350))
        g.DrawRectangle(New Pen(Color.FromArgb(133, 173, 245)), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
        g.DrawRectangle(New Pen(Color.FromArgb(106, 146, 242)), New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))

        g.SmoothingMode = SmoothingMode.HighQuality

    End Sub
End Class