Public Class DarkLog_Container
    Inherits ContainerControl
    Property Text_ As String = "User Login"
    Property Text_Color As Color = Color.White
    Sub New()
        Me.DoubleBuffered = True
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub DarkLog_Container_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        'Back
        e.Graphics.Clear(Color.Black)
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(33, 31, 33)), New Rectangle(2, 2, Me.Width - 4, Me.Height - 5))
        'header
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(24, 22, 24)), New Rectangle(2, 2, Me.Width - 4, 50))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(15, 13, 15)), New Point(2, 51), New Point(Me.Width - 4, 51))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(42, 40, 41)), New Point(2, 52), New Point(Me.Width - 4, 52))
        Dim rect = New Rectangle(2, 2, Me.Width - 4, 23)
        Dim LGB = New LinearGradientBrush(rect, Color.FromArgb(40, 165, 165, 165), Color.FromArgb(24, 22, 24), 90.0!)
        e.Graphics.FillRectangle(LGB, rect)
        'Shadow Text
        e.Graphics.DrawString(Text_, New Font("Arial", 10, FontStyle.Regular), New SolidBrush(Color.Black), New Rectangle(2, 3, Me.Width - 4, 50), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
        'Text
        e.Graphics.DrawString(Text_, New Font("Arial", 10, FontStyle.Regular), New SolidBrush(Text_Color), New Rectangle(2, 2, Me.Width - 4, 50), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
        'Border
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(60, 200, 200, 200)), New Rectangle(1, 1, Me.Width - 3, Me.Height - 4))
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