'Random Controls: Ausologic Button
'by Nettro ;P

Imports System.Drawing.Drawing2D
Public Class AusogicButton
    Inherits Panel
    Property Display_Image As Boolean = False
    Property Texxt As String = "HELP"
    Property Type As Typ
    Enum Typ
        Green
        White
        Orange
    End Enum
    Property Img As Image
    Sub New()
        Me.DoubleBuffered = True
    End Sub
#Region "Functions"
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
    Private Sub Buttonn_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        If Type = Typ.Green Then
            If Clicked = True Then
                FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), 4, New SolidBrush(Color.FromArgb(144, 207, 105)))
                DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(67, 154, 45)), 1, 1, Me.Width - 3, Me.Height - 3, 4)
                Dim rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                Dim brushs = New LinearGradientBrush(rect, Color.FromArgb(70, 158, 47), Color.FromArgb(94, 191, 65), 90.0!)
                e.Graphics.FillRectangle(brushs, rect)
                rect = New Rectangle(4, 3, Me.Width - 9, Me.Height - 9)
                e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(17, 137, 39)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, 255, 255)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                If Display_Image = True Then
                    e.Graphics.DrawImage(Img, New Rectangle(8, 8, 32, 32))
                End If

            Else

                If MouseHoverr = False Then
                    FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), 4, New SolidBrush(Color.FromArgb(144, 207, 105)))
                    DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(67, 154, 45)), 1, 1, Me.Width - 3, Me.Height - 3, 4)
                    Dim rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    Dim brushs = New LinearGradientBrush(rect, Color.FromArgb(94, 191, 65), Color.FromArgb(70, 158, 47), 90.0!)
                    e.Graphics.FillRectangle(brushs, rect)
                    rect = New Rectangle(4, 3, Me.Width - 9, Me.Height - 9)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(17, 137, 39)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, 255, 255)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    If Display_Image = True Then
                        e.Graphics.DrawImage(Img, New Rectangle(8, 8, 32, 32))
                    End If

                Else
                    FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), 4, New SolidBrush(Color.FromArgb(144, 207, 105)))
                    DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(67, 154, 45)), 1, 1, Me.Width - 3, Me.Height - 3, 4)
                    Dim rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    Dim brushs = New LinearGradientBrush(rect, Color.FromArgb(105, 218, 71), Color.FromArgb(68, 181, 47), 90.0!)
                    e.Graphics.FillRectangle(brushs, rect)
                    rect = New Rectangle(4, 3, Me.Width - 9, Me.Height - 9)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(17, 137, 39)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, 255, 255)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    If Display_Image = True Then
                        e.Graphics.DrawImage(Img, New Rectangle(8, 8, 32, 32))
                    End If

                End If

            End If
        ElseIf Type = Typ.Orange Then
            If Clicked = True Then
                FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), 4, New SolidBrush(Color.FromArgb(255, 201, 66)))
                DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(237, 126, 0)), 1, 1, Me.Width - 3, Me.Height - 3, 4)
                Dim rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                Dim brushs = New LinearGradientBrush(rect, Color.FromArgb(255, 137, 0), Color.FromArgb(255, 182, 0), 90.0!)
                e.Graphics.FillRectangle(brushs, rect)
                rect = New Rectangle(4, 3, Me.Width - 9, Me.Height - 9)
                e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(219, 137, 10)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, 255, 255)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                If Display_Image = True Then
                    e.Graphics.DrawImage(Img, New Rectangle(8, 8, 32, 32))
                End If

            Else

                If MouseHoverr = False Then
                    FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), 4, New SolidBrush(Color.FromArgb(255, 201, 66)))
                    DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(237, 126, 0)), 1, 1, Me.Width - 3, Me.Height - 3, 4)
                    Dim rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    Dim brushs = New LinearGradientBrush(rect, Color.FromArgb(255, 182, 0), Color.FromArgb(255, 137, 0), 90.0!)
                    e.Graphics.FillRectangle(brushs, rect)
                    rect = New Rectangle(4, 3, Me.Width - 9, Me.Height - 9)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(219, 137, 10)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, 255, 255)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    If Display_Image = True Then
                        e.Graphics.DrawImage(Img, New Rectangle(8, 8, 32, 32))
                    End If

                Else
                    FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), 4, New SolidBrush(Color.FromArgb(255, 201, 66)))
                    DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(237, 126, 0)), 1, 1, Me.Width - 3, Me.Height - 3, 4)
                    Dim rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    Dim brushs = New LinearGradientBrush(rect, Color.FromArgb(255, 202, 0), Color.FromArgb(255, 167, 0), 90.0!)
                    e.Graphics.FillRectangle(brushs, rect)
                    rect = New Rectangle(4, 3, Me.Width - 9, Me.Height - 9)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(219, 137, 10)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, 255, 255)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    If Display_Image = True Then
                        e.Graphics.DrawImage(Img, New Rectangle(8, 8, 32, 32))
                    End If

                End If

            End If
        ElseIf Type = Typ.White Then
            If Clicked = True Then
                Dim rect = New Rectangle(1, 1, Me.Width - 3, Me.Height - 3)
                Dim brushs = New LinearGradientBrush(rect, Color.FromArgb(70, 159, 155, 149), Color.FromArgb(249, 249, 249), 90.0!)
                FillRoundedRectangle(e.Graphics, rect, 4, brushs)
                DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(190, 185, 179)), 1, 1, Me.Width - 3, Me.Height - 3, 4)
                e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Regular), New SolidBrush(Color.FromArgb(76, 76, 73)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                If Display_Image = True Then
                    e.Graphics.DrawImage(Img, New Rectangle(8, 8, 32, 32))
                End If

            Else

                If MouseHoverr = False Then
                    FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), 4, New SolidBrush(Color.FromArgb(249, 249, 249)))
                    DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(190, 185, 179)), 1, 1, Me.Width - 3, Me.Height - 3, 4)
                    Dim rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    Dim brushs = New LinearGradientBrush(rect, Color.FromArgb(250, 250, 249), Color.FromArgb(231, 229, 226), 90.0!)
                    e.Graphics.FillRectangle(brushs, rect)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Regular), New SolidBrush(Color.FromArgb(76, 76, 73)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    If Display_Image = True Then
                        e.Graphics.DrawImage(Img, New Rectangle(8, 8, 32, 32))
                    End If

                Else
                    FillRoundedRectangle(e.Graphics, New Rectangle(1, 1, Me.Width - 3, Me.Height - 3), 4, New SolidBrush(Color.FromArgb(249, 249, 249)))
                    DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(190, 185, 179)), 1, 1, Me.Width - 3, Me.Height - 3, 4)
                    Dim rect = New Rectangle(4, 4, Me.Width - 9, Me.Height - 9)
                    Dim brushs = New LinearGradientBrush(rect, Color.FromArgb(250, 250, 249), Color.FromArgb(241, 239, 236), 90.0!)
                    e.Graphics.FillRectangle(brushs, rect)
                    e.Graphics.DrawString(Texxt, New Font("Arial", 14, FontStyle.Regular), New SolidBrush(Color.FromArgb(76, 76, 73)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    If Display_Image = True Then
                        e.Graphics.DrawImage(Img, New Rectangle(8, 8, 32, 32))
                    End If

                End If

            End If
        End If
        Clicked = False
    End Sub
#Region "ThemeDraggable"
    Property Clicked As Boolean = False
    Event Clickedd()

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If New Rectangle(1, 1, Me.Width - 3, Me.Height - 3).Contains(e.X, e.Y) Then
            Clicked = True
            RaiseEvent Clickedd()
            Me.Refresh()
        End If
        '
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Property MouseHoverr As Boolean = False
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y
        If New Rectangle(2, 2, Me.Width - 4, Me.Height - 4).Contains(e.X, e.Y) Then
            MouseHoverr = True
        Else
            MouseHoverr = False
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class