Imports System.Drawing.Drawing2D
Public Class MainContainer
    Inherits ContainerControl
#Region "Modules & Functions"
    Public Property StyleType As Kind = Kind.Normal
    Enum Kind
        Normal
        Windows
        SmallView
    End Enum
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
#End Region
    Enum TypeIcon
        UseFormIcon
        CustomImage
        NoIcon
    End Enum
    Property ShowNotes As Boolean = False
    Property NoteNum As String = "0"
    Property IconDisplayType As TypeIcon
    Property Image As Image

    Sub New()

        Me.DoubleBuffered = True
        Me.Dock = DockStyle.Fill
        Me.Padding = New Padding(1, 66, 1, 1)
    End Sub
    Private Sub MainContainer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        'Background
    e.Graphics.Clear(Color.FromArgb(18, 18, 18))
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        If StyleType = Kind.Normal Then
            'Header
      e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(18, 18, 18)), New Rectangle(0, 0, Me.Width - 1, 60))
            Dim nrect = New Rectangle(0, 61, Me.Width - 1, 5)
      Dim brushs = New LinearGradientBrush(nrect, Color.FromArgb(50, Color.Black), Color.FromArgb(18, 18, 18), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brushs, nrect)
            '//////////////
            'Buttons//////

            'Minimize 
            If Minihover = True Then
        e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(74, 75, 78)), New Rectangle(Me.Width - 38, 8, 12, 12))
        e.Graphics.DrawString("0", New Font("Webdings", 7.1, FontStyle.Regular), New SolidBrush(Color.FromArgb(44, 45, 49)), New Rectangle(Me.Width - 38, 5, 12, 12))
            Else
        e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(64, 65, 68)), New Rectangle(Me.Width - 38, 8, 12, 12))
        e.Graphics.DrawString("0", New Font("Webdings", 7.1, FontStyle.Regular), New SolidBrush(Color.FromArgb(44, 45, 49)), New Rectangle(Me.Width - 38, 5, 12, 12))
            End If
            'Maxmize
      'If Maxhover = True Then
      '    e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(74, 75, 78)), New Rectangle(Me.Width - 40, 8, 12, 12)) '47, 48, 52
      '    e.Graphics.DrawString("+", New Font("Arial", 9.5, FontStyle.Regular), New SolidBrush(Color.FromArgb(44, 45, 49)), New Rectangle(Me.Width - 39.5, 6, 12, 12))
      'Else
      '    e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(64, 65, 68)), New Rectangle(Me.Width - 40, 8, 12, 12)) '47, 48, 52
      '    e.Graphics.DrawString("+", New Font("Arial", 9.5, FontStyle.Regular), New SolidBrush(Color.FromArgb(44, 45, 49)), New Rectangle(Me.Width - 39.5, 6, 12, 12))
      'End If
            If Exithover = True Then
                'Close
        e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(74, 75, 78)), New Rectangle(Me.Width - 22, 8, 12, 12))
                e.Graphics.DrawString("r", New Font("Webdings", 7.1, FontStyle.Regular), New SolidBrush(Color.FromArgb(44, 45, 49)), New Rectangle(Me.Width - 22, 9, 12, 12))
            Else
                'Close
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(64, 65, 68)), New Rectangle(Me.Width - 22, 8, 12, 12))
                e.Graphics.DrawString("r", New Font("Webdings", 7.1, FontStyle.Regular), New SolidBrush(Color.FromArgb(44, 45, 49)), New Rectangle(Me.Width - 22, 9, 12, 12))
            End If

            '/////////////
            'ShadowText
            e.Graphics.DrawString(ParentForm.Text, New Font("Arial", 11.5, FontStyle.Regular), New SolidBrush(Color.FromArgb(22, 24, 28)), New Rectangle(0, 5, Me.Width - 1, 20), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            'Text
            e.Graphics.DrawString(ParentForm.Text, New Font("Arial", 11.5, FontStyle.Regular), Brushes.White, New Rectangle(0, 6, Me.Width - 1, 20), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            'icon
            Select Case IconDisplayType
                Case TypeIcon.CustomImage
                    e.Graphics.DrawImage(Image, New Rectangle(5, 4, 24, 24))
                Case TypeIcon.UseFormIcon
                    e.Graphics.DrawImage(ParentForm.Icon.ToBitmap, New Rectangle(2, -5, 28, 28))
                Case TypeIcon.NoIcon
                    If Not NoteNum = "0" Then
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(251, 83, 150)), New Rectangle(2, 4, 20, 6))
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(231, 63, 130)), New Rectangle(2, 8, 20, 2))
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(251, 83, 150)), New Rectangle(2, 14, 20, 6))
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(231, 63, 130)), New Rectangle(2, 18, 20, 2))
                    Else
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(163, 163, 163)), New Rectangle(2, 4, 20, 6))
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(183, 183, 183)), New Rectangle(2, 8, 20, 2))
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(163, 163, 163)), New Rectangle(2, 14, 20, 6))
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(183, 183, 183)), New Rectangle(2, 18, 20, 2))
                    End If

            End Select
            Me.Padding = New Padding(1, 66, 1, 1)
        ElseIf StyleType = Kind.Windows Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(22, 23, 27)), New Rectangle(0, 0, Me.Width - 1, 33))
            Dim nrect = New Rectangle(0, 28, Me.Width - 1, 5)
            Dim brushs = New LinearGradientBrush(nrect, Color.FromArgb(50, Color.Black), Color.FromArgb(22, 24, 28), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brushs, nrect)
            Me.Padding = New Padding(1, 33, 1, 1)
        ElseIf StyleType = Kind.SmallView Then
            Me.Padding = New Padding(1, 1, 1, 1)
        End If
    End Sub
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False
    Private Minihover As Boolean = False
    Private Maxhover As Boolean = False
    Private Exithover As Boolean = False
    Public Event Clickedd()
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width - 58, 61)
        If dragRect.Contains(New Point(e.X, e.Y)) Then
            isDragging = True
            savePoint = New Point(e.X, e.Y)
        End If
        If New Rectangle(5, 4, 36, 24).Contains(e.X, e.Y) Then
            RaiseEvent Clickedd()
        End If
        Dim clickRect As New Rectangle(Me.Width - 22, 8, 12, 12)
        If clickRect.Contains(New Point(e.X, e.Y)) Then
            Environment.[Exit](0)
        End If
    If New Rectangle(Me.Width - 38, 8, 12, 12).Contains(New Point(mouseX, mouseY)) Then
      FindForm.WindowState = FormWindowState.Minimized
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
        If New Rectangle(Me.Width - 40, 8, 12, 12).Contains(New Point(mouseX, mouseY)) Then
            Maxhover = True
        Else
            Maxhover = False
        End If
        If New Rectangle(Me.Width - 58, 8, 12, 12).Contains(New Point(mouseX, mouseY)) Then
            Minihover = True
        Else
            Minihover = False
        End If
        If New Rectangle(Me.Width - 22, 8, 12, 12).Contains(e.X, e.Y) Then
            Exithover = True
        Else
            Exithover = False
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class