
Imports System.Drawing.Drawing2D

Public Class Skype_Form
    Inherits ContainerControl
    Sub New()
        Me.DoubleBuffered = True
    End Sub
    Property Border_Color As Color = Color.FromArgb(24, 51, 57)
    Property inBorder_Color As Color = Color.FromArgb(96, 174, 208)
    Property iinBorder_Color As Color = Color.FromArgb(96, 174, 208)
    Property Sky1_Color As Color = Color.FromArgb(68, 195, 251)
    Property Sky2_Color As Color = Color.FromArgb(28, 178, 248)
    Property Cloud_Color As Color = Color.FromArgb(52, 186, 249) '32, 166, 229
    Private Sub Skype_Form_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        'back
        Dim rect = New Rectangle(1, 1, Me.Width - 3, Me.Height - 3)
        Dim brushs = New LinearGradientBrush(rect, Sky1_Color, Sky2_Color, 90.0!)
        e.Graphics.FillRectangle(brushs, rect)
        'Clouds
        rect = New Rectangle(-140, Me.Height / 2 + 100, Me.Width / 3 + 250, Me.Height)
        brushs = New LinearGradientBrush(rect, Sky1_Color, Sky2_Color, 90.0!)
        e.Graphics.FillEllipse(brushs, New Rectangle(-140, Me.Height / 2 + 100, Me.Width / 3 + 250, Me.Height))
        e.Graphics.FillEllipse(brushs, New Rectangle(-20 + ((Me.Width / 3) * 1), Me.Height / 2 + 130, Me.Width / 3 + 120, Me.Height))
        rect = New Rectangle(-20 + (Me.Width / 3) * 2, Me.Height / 2 + 40, Me.Width / 3 + 250, Me.Height)
        brushs = New LinearGradientBrush(rect, Sky1_Color, Sky2_Color, 90.0!)
        e.Graphics.FillEllipse(brushs, New Rectangle(-20 + (Me.Width / 3) * 2, Me.Height / 2 + 40, Me.Width / 3 + 250, Me.Height))
        'top
        rect = New Rectangle(3, 3, Me.Width - 5, 9)
        brushs = New LinearGradientBrush(rect, Color.FromArgb(60, 255, 255, 255), Color.Transparent, 90.0!)
        e.Graphics.FillRectangle(brushs, rect)
        'bottom
        rect = New Rectangle(3, Me.Height - 10, Me.Width - 5, 8)
        brushs = New LinearGradientBrush(rect, Color.Transparent, Color.FromArgb(60, 255, 255, 255), 90.0!)
        e.Graphics.FillRectangle(brushs, rect)

        'border
        e.Graphics.DrawRectangle(New Pen(Border_Color), New Rectangle(-1, -1, Me.Width + 1, Me.Height + 1))
        e.Graphics.DrawRectangle(New Pen(inBorder_Color), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
        e.Graphics.DrawRectangle(New Pen(iinBorder_Color), New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(60, 255, 255, 255)), New Rectangle(2, 2, Me.Width - 5, Me.Height - 5))
        e.Graphics.DrawString(FindForm.Text, New Font("Arial", 12, FontStyle.Regular), Brushes.White, New Rectangle(0, 5, Me.Width, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    End Sub

    Private Sub Skype_Form_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
#Region "ThemeDraggable"
    Dim x, y As Integer
    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width - 70, 30)
        If dragRect.Contains(New Point(e.X, e.Y)) Then
            isDragging = True
            savePoint = New Point(e.X, e.Y)
        End If
        '
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If New Rectangle(Me.Width - 20, 13, 16, 16).Contains(e.X, e.Y) Then
                Environment.Exit(0)
            End If
            If New Rectangle(Me.Width - 40, 13, 16, 16).Contains(e.X, e.Y) Then
                If FindForm.WindowState = FormWindowState.Normal Then
                    FindForm.WindowState = FormWindowState.Maximized
                Else
                    FindForm.WindowState = FormWindowState.Normal
                End If
            End If
            If New Rectangle(Me.Width - 60, 13, 16, 16).Contains(e.X, e.Y) Then
                FindForm.WindowState = FormWindowState.Minimized
            End If
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

            FindForm().Location = New Point(screenPoint.X - Me.savePoint.X, screenPoint.Y - Me.savePoint.Y)
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class