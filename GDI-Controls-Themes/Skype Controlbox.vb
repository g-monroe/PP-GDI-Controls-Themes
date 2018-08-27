Imports System.Drawing.Drawing2D
 
Public Class Skype_ControlBox
    Inherits Control
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
            ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
            ControlStyles.SupportsTransparentBackColor, True)
        'Setting Flickering off
        DoubleBuffered = True
        'backcolor transparent
        BackColor = Color.Transparent
        'This is important finds the "Form/Control" that it needs to be parent of
        Parent = FindForm()
    End Sub
 
    Property Close_Visible As Boolean = True
    Property Close_Color As Color = Color.FromArgb(255, 74, 54)
    Property Minimize_Visible As Boolean = True
    Property Minimize_Color As Color = Color.FromArgb(255, 182, 83)
    Property Maxmize_Visible As Boolean = True
    Property Maxmize_Color As Color = Color.FromArgb(195, 255, 172)
    Property Left_To_Right As Boolean = True
 
    Private Sub Skype_ControlBox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        If Left_To_Right = True Then
            Dim i As Integer = 2
            If Close_Visible = True Then
 
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(60, 255, 255, 255)), New Rectangle(i, 2, 12, 14))
                Dim brush = New LinearGradientBrush(New Rectangle(i, 1, 12, 13), Color.FromArgb(230, 0, 0, 0), Color.FromArgb(60, 0, 0, 0), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i - 1, 1, 14, 13))
                e.Graphics.FillEllipse(New SolidBrush(Close_Color), New Rectangle(i, 2, 12, 12))
                brush = New LinearGradientBrush(New Rectangle(i + 1, 3, 10, 4), Color.FromArgb(190, 255, 255, 255), Color.FromArgb(30, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 1, 3, 10, 3))
                brush = New LinearGradientBrush(New Rectangle(i + 2, 10, 18, 4), Color.FromArgb(0, 255, 255, 255), Color.FromArgb(120, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 2, 10, 8, 4))
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(10, 23, 23, 23)), New Rectangle(i + 3, 5, 6, 6))
                i += 20
            End If
            If Maxmize_Visible = True Then
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(60, 255, 255, 255)), New Rectangle(i, 2, 12, 14))
                Dim brush = New LinearGradientBrush(New Rectangle(i, 1, 12, 13), Color.FromArgb(230, 0, 0, 0), Color.FromArgb(60, 0, 0, 0), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i - 1, 1, 14, 13))
                e.Graphics.FillEllipse(New SolidBrush(Maxmize_Color), New Rectangle(i, 2, 12, 12))
                brush = New LinearGradientBrush(New Rectangle(i + 1, 3, 10, 4), Color.FromArgb(190, 255, 255, 255), Color.FromArgb(30, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 1, 3, 10, 3))
                brush = New LinearGradientBrush(New Rectangle(i + 2, 10, 18, 4), Color.FromArgb(0, 255, 255, 255), Color.FromArgb(120, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 2, 10, 8, 4))
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(10, 23, 23, 23)), New Rectangle(i + 3, 5, 6, 6))
                i += 20
            End If
            If Minimize_Visible = True Then
 
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(60, 255, 255, 255)), New Rectangle(i, 2, 12, 14))
                Dim brush = New LinearGradientBrush(New Rectangle(i, 1, 12, 13), Color.FromArgb(230, 0, 0, 0), Color.FromArgb(60, 0, 0, 0), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i - 1, 1, 14, 13))
                e.Graphics.FillEllipse(New SolidBrush(Minimize_Color), New Rectangle(i, 2, 12, 12))
                brush = New LinearGradientBrush(New Rectangle(i + 1, 3, 10, 4), Color.FromArgb(190, 255, 255, 255), Color.FromArgb(30, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 1, 3, 10, 3))
                brush = New LinearGradientBrush(New Rectangle(i + 2, 10, 18, 4), Color.FromArgb(0, 255, 255, 255), Color.FromArgb(120, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 2, 10, 8, 4))
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(10, 23, 23, 23)), New Rectangle(i + 3, 5, 6, 6))
                i += 20
            End If
        Else
            Dim i As Integer = 2
            If Minimize_Visible = True Then
 
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(60, 255, 255, 255)), New Rectangle(i, 2, 12, 14))
                Dim brush = New LinearGradientBrush(New Rectangle(i, 1, 12, 13), Color.FromArgb(230, 0, 0, 0), Color.FromArgb(60, 0, 0, 0), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i - 1, 1, 14, 13))
                e.Graphics.FillEllipse(New SolidBrush(Minimize_Color), New Rectangle(i, 2, 12, 12))
                brush = New LinearGradientBrush(New Rectangle(i + 1, 3, 10, 4), Color.FromArgb(190, 255, 255, 255), Color.FromArgb(30, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 1, 3, 10, 3))
                brush = New LinearGradientBrush(New Rectangle(i + 2, 10, 18, 4), Color.FromArgb(0, 255, 255, 255), Color.FromArgb(120, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 2, 10, 8, 4))
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(10, 23, 23, 23)), New Rectangle(i + 3, 5, 6, 6))
                i += 20
            End If
            If Maxmize_Visible = True Then
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(60, 255, 255, 255)), New Rectangle(i, 2, 12, 14))
                Dim brush = New LinearGradientBrush(New Rectangle(i, 1, 12, 13), Color.FromArgb(230, 0, 0, 0), Color.FromArgb(60, 0, 0, 0), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i - 1, 1, 14, 13))
                e.Graphics.FillEllipse(New SolidBrush(Maxmize_Color), New Rectangle(i, 2, 12, 12))
                brush = New LinearGradientBrush(New Rectangle(i + 1, 3, 10, 4), Color.FromArgb(190, 255, 255, 255), Color.FromArgb(30, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 1, 3, 10, 3))
                brush = New LinearGradientBrush(New Rectangle(i + 2, 10, 18, 4), Color.FromArgb(0, 255, 255, 255), Color.FromArgb(120, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 2, 10, 8, 4))
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(10, 23, 23, 23)), New Rectangle(i + 3, 5, 6, 6))
                i += 20
            End If
            If Close_Visible = True Then
 
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(60, 255, 255, 255)), New Rectangle(i, 2, 12, 14))
                Dim brush = New LinearGradientBrush(New Rectangle(i, 1, 12, 13), Color.FromArgb(230, 0, 0, 0), Color.FromArgb(60, 0, 0, 0), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i - 1, 1, 14, 13))
                e.Graphics.FillEllipse(New SolidBrush(Close_Color), New Rectangle(i, 2, 12, 12))
                brush = New LinearGradientBrush(New Rectangle(i + 1, 3, 10, 4), Color.FromArgb(190, 255, 255, 255), Color.FromArgb(30, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 1, 3, 10, 3))
                brush = New LinearGradientBrush(New Rectangle(i + 2, 10, 18, 4), Color.FromArgb(0, 255, 255, 255), Color.FromArgb(120, 255, 255, 255), 90.0!)
                e.Graphics.FillEllipse(brush, New Rectangle(i + 2, 10, 8, 4))
                e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(10, 23, 23, 23)), New Rectangle(i + 3, 5, 6, 6))
                i += 20
            End If
        End If
    End Sub
 
    Private Sub Skype_ControlBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            If Left_To_Right = True Then
                Dim i As Integer = 2
                If Close_Visible = True Then
                    If New Rectangle(i, 2, 12, 14).Contains(e.X, e.Y) Then
                        Environment.Exit(0)
                    End If
                    i += 20
                End If
                If Maxmize_Visible = True Then
                    If New Rectangle(i, 2, 12, 14).Contains(e.X, e.Y) Then
                        If FindForm.WindowState = FormWindowState.Normal Then
                            FindForm.WindowState = FormWindowState.Maximized
                        Else
                            FindForm.WindowState = FormWindowState.Normal
                        End If
                    End If
                    i += 20
                End If
                If Minimize_Visible = True Then
                    If New Rectangle(i, 2, 12, 14).Contains(e.X, e.Y) Then
                        FindForm.WindowState = FormWindowState.Minimized
                    End If
                    i += 20
                End If
            Else
                Dim i As Integer = 2
                If Minimize_Visible = True Then
                    If New Rectangle(i, 2, 12, 14).Contains(e.X, e.Y) Then
                        FindForm.WindowState = FormWindowState.Minimized
                    End If
                    i += 20
                End If
                If Maxmize_Visible = True Then
                    If New Rectangle(i, 2, 12, 14).Contains(e.X, e.Y) Then
                        If FindForm.WindowState = FormWindowState.Normal Then
                            FindForm.WindowState = FormWindowState.Maximized
                        Else
                            FindForm.WindowState = FormWindowState.Normal
                        End If
                    End If
                    i += 20
                End If
                If Close_Visible = True Then
                    If New Rectangle(i, 2, 12, 14).Contains(e.X, e.Y) Then
                        Environment.Exit(0)
                    End If
                    i += 20
                End If
            End If
        End If
    End Sub
 
End Class