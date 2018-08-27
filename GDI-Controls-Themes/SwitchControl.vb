Imports System.Drawing.Drawing2D

Public Class Switch
    Inherits Control
    Property Color1 As Color = Color.FromArgb(84, 197, 175)
    Property Color2 As Color = Color.FromArgb(65, 154, 137)
    Property Color3 As Color = Color.FromArgb(20, 69, 53)
    Property Color4 As Color = Color.FromArgb(10, 26, 23)
    Property Color5 As Color = Color.White
    Property Toggled As Boolean = False
    Property StyleType As _Style = _Style.Classic
    Sub New()
        Me.DoubleBuffered = True
    End Sub
    Enum _Style
        Classic
        RoundedClassic
        Rounded
        NightRounded
    End Enum
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
    Event ToggledChange(toggle As Boolean)
    Private Sub Switch_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Select Case StyleType
                Case _Style.Classic
                    Me.Size = New Size(70, 30)
                    If Toggled Then
                        If New Rectangle(Me.Width - 34, 7, 40, 20).Contains(e.X, e.Y) Then
                            Toggled = Not Toggled
                            RaiseEvent ToggledChange(Toggled)
                        End If
                    Else
                        If New Rectangle(8, 6, 40, 20).Contains(e.X, e.Y) Then
                            Toggled = Not Toggled
                            RaiseEvent ToggledChange(Toggled)
                        End If
                    End If
                Case _Style.RoundedClassic
                    If Toggled Then
                        If New Rectangle(5, 4, 32, 31).Contains(e.X, e.Y) Then
                            Toggled = Not Toggled
                            RaiseEvent ToggledChange(Toggled)

                        End If
                    Else
                        If New Rectangle(Me.Width - 37, 4, 32, 31).Contains(e.X, e.Y) Then
                            Toggled = Not Toggled
                            RaiseEvent ToggledChange(Toggled)
                        End If
                    End If
                Case _Style.Rounded
                    If Toggled Then
                        If New Rectangle(Me.Width - 37, 4, 32, 31).Contains(e.X, e.Y) Then
                            Toggled = Not Toggled
                            RaiseEvent ToggledChange(Toggled)

                        End If
                    Else
                        If New Rectangle(5, 4, 32, 31).Contains(e.X, e.Y) Then
                            Toggled = Not Toggled
                            RaiseEvent ToggledChange(Toggled)
                        End If
                    End If
                Case _Style.NightRounded
                    If Toggled Then
                        If New Rectangle(5, 4, 32, 31).Contains(e.X, e.Y) Then
                            Toggled = Not Toggled
                            RaiseEvent ToggledChange(Toggled)

                        End If
                    Else
                        If New Rectangle(Me.Width - 37, 4, 32, 31).Contains(e.X, e.Y) Then
                            Toggled = Not Toggled
                            RaiseEvent ToggledChange(Toggled)
                        End If
                    End If
            End Select
            Me.Refresh()
        End If
    End Sub

    Private Sub Switch_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Select Case StyleType
            Case _Style.Classic
                Me.Size = New Size(70, 30)
                If Toggled Then
                    If New Rectangle(Me.Width - 34, 7, 40, 20).Contains(e.X, e.Y) Then
                        Cursor = Cursors.Hand
                    Else
                        Cursor = Cursors.Arrow
                    End If
                Else
                    If New Rectangle(8, 6, 40, 20).Contains(e.X, e.Y) Then
                        Cursor = Cursors.Hand
                    Else
                        Cursor = Cursors.Arrow
                    End If
                End If
            Case _Style.RoundedClassic
                If Toggled Then
                    If New Rectangle(5, 4, 32, 31).Contains(e.X, e.Y) Then
                        Cursor = Cursors.Hand
                    Else
                        Cursor = Cursors.Arrow
                    End If
                Else
                    If New Rectangle(Me.Width - 37, 4, 32, 31).Contains(e.X, e.Y) Then
                        Cursor = Cursors.Hand
                    Else
                        Cursor = Cursors.Arrow
                    End If
                End If
            Case _Style.Rounded
                If Toggled Then
                    If New Rectangle(Me.Width - 37, 4, 32, 31).Contains(e.X, e.Y) Then
                        Cursor = Cursors.Hand
                    Else
                        Cursor = Cursors.Arrow
                    End If
                Else
                    If New Rectangle(5, 4, 32, 31).Contains(e.X, e.Y) Then
                        Cursor = Cursors.Hand
                    Else
                        Cursor = Cursors.Arrow
                    End If
                End If
            Case _Style.NightRounded
                If Toggled Then
                    If New Rectangle(5, 4, 32, 31).Contains(e.X, e.Y) Then
                        Cursor = Cursors.Hand
                    Else
                        Cursor = Cursors.Arrow
                    End If
                Else
                    If New Rectangle(Me.Width - 37, 4, 32, 31).Contains(e.X, e.Y) Then
                        Cursor = Cursors.Hand
                    Else
                        Cursor = Cursors.Arrow
                    End If
                End If
        End Select
    End Sub
    Private Sub Switch_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.HighQuality
        Select Case StyleType
            Case _Style.Classic
                Me.Size = New Size(70, 30)
                If Toggled Then
                    g.FillPath(New SolidBrush(Color1), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 20))
                    g.FillPath(New SolidBrush(Color5), Round(New Rectangle(4, 4, 30, 20), 20))
                    g.DrawString("OFF", New Font("Arial", 10, FontStyle.Bold), New SolidBrush(Color5), New Rectangle(Me.Width - 34, 7, 40, 20))
                Else
                    g.FillPath(New SolidBrush(Color2), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 20))
                    g.FillPath(New SolidBrush(Color5), Round(New Rectangle(Me.Width - 34, 4, 30, 20), 20))
                    g.DrawString("ON", New Font("Arial", 10, FontStyle.Bold), New SolidBrush(Color5), New Rectangle(8, 6, 40, 20))
                End If
            Case _Style.RoundedClassic
                Me.Size = New Size(75, 40)
                If Toggled Then
                    g.FillPath(New SolidBrush(Color1), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 40))
                    g.FillEllipse(New SolidBrush(Color5), New Rectangle(5, 4, 32, 31))
                    g.DrawString("NO", New Font("Arial", 10, FontStyle.Bold), New SolidBrush(Color5), New Rectangle(Me.Width - 34, 12, 40, 20))
                Else
                    g.FillPath(New SolidBrush(Color2), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 40))
                    g.FillEllipse(New SolidBrush(Color5), New Rectangle(Me.Width - 37, 4, 32, 31))
                    g.DrawString("YES", New Font("Arial", 9, FontStyle.Bold), New SolidBrush(Color5), New Rectangle(8, 12, 40, 20))
                End If
            Case _Style.Rounded
                Me.Size = New Size(75, 40)
                If Toggled Then
                    g.FillPath(New SolidBrush(Color1), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 40))
                    g.FillEllipse(New SolidBrush(Color5), New Rectangle(Me.Width - 37, 4, 32, 31))
                    g.DrawLine(New Pen((Color4), 2), New Point(17, 14), New Point(30, 27))
                    g.DrawLine(New Pen((Color4), 2), New Point(17, 27), New Point(30, 14))
                Else
                    g.FillPath(New SolidBrush(Color2), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 40))
                    g.FillEllipse(New SolidBrush(Color5), New Rectangle(5, 4, 32, 31))
                    g.DrawLine(New Pen((Color4), 3), New Point(Me.Width - 13, 12), New Point(Me.Width - 25, 27))
                    g.DrawLine(New Pen((Color4), 3), New Point(Me.Width - 25, 27), New Point(Me.Width - 30, 20))
                End If
            Case _Style.NightRounded
                If Toggled Then
                    g.FillPath(New SolidBrush(Color3), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 40))
                    g.FillEllipse(New SolidBrush(Color1), New Rectangle(5, 4, 32, 31))
                    g.DrawLine(New Pen((Color5), 2), New Point(Me.Width - 17, 14), New Point(Me.Width - 30, 27))
                    g.DrawLine(New Pen((Color5), 2), New Point(Me.Width - 17, 27), New Point(Me.Width - 30, 14))
                Else
                    g.FillPath(New SolidBrush(Color1), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 40))
                    g.FillEllipse(New SolidBrush(Color2), New Rectangle(Me.Width - 37, 4, 32, 31))
                    g.DrawLine(New Pen((Color4), 3), New Point(30, 10), New Point(18, 27))
                    g.DrawLine(New Pen((Color4), 3), New Point(18, 27), New Point(13, 20))
                End If
        End Select
    End Sub
End Class