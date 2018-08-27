Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class LottoLight
    Class RoundedRectangle
        <DllImport("gdi32.dll")> _
        Shared Function CreateRoundRectRgn(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cx As Integer, ByVal cy As Integer) As IntPtr
        End Function
        Shared Function DrawRoundRectangle(rct As Rectangle, r As Integer, MSAA As Integer, FillColor As Color, BorderColor As Color)
            Dim b As New Bitmap(rct.Width * MSAA + MSAA, rct.Height * MSAA + MSAA)
            Dim g As Graphics = Graphics.FromImage(b)
            Dim RegH As IntPtr = CreateRoundRectRgn(rct.Left, rct.Top, (rct.Width) * MSAA, (rct.Height) * MSAA, r * MSAA, r * MSAA)
            Dim RegH1 As IntPtr = CreateRoundRectRgn(rct.Left + MSAA / 1, rct.Top + MSAA / 1, (rct.Width - 1) * MSAA, (rct.Height - 1) * MSAA, (r - 2) * MSAA, (r - 2) * MSAA)
            Dim Reg As Region = Region.FromHrgn(RegH)
            Dim Reg1 As Region = Region.FromHrgn(RegH1)

            g.InterpolationMode = InterpolationMode.HighQualityBicubic

            g.FillRegion(New SolidBrush(BorderColor), Reg)
            g.SetClip(Reg1, CombineMode.Replace)
            g.Clear(FillColor)
            Return b
        End Function
    End Class
End Class
Public Class LL_Button
    Inherits Control
    Sub New()
        Me.DoubleBuffered = True
    End Sub
    Dim mouseover As Boolean = False
    Dim mouseclick As Boolean = False
    Dim WithEvents tmr As New Timer With {.Interval = 10}
    Dim clickcount As Integer = 0
    Event MouseClicked()
    Private Sub LL_Button_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If mouseover Then
                If mouseclick = False Then
                    mouseclick = True
                    Me.Refresh()
                End If
            End If
        End If
    End Sub

    Private Sub LL_Button_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        mouseover = False
        Me.Refresh()
    End Sub

    Private Sub LL_Button_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If New Rectangle(1, 4, Me.Width - 2, Me.Height - 2).Contains(e.X, e.Y) Then
            mouseover = True
            Cursor = Cursors.Hand
            Me.Refresh()
        Else
            mouseover = False
            Cursor = Cursors.Arrow
            Me.Refresh()
        End If
    End Sub

    Private Sub LL_Button_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If mouseover Then
                RaiseEvent MouseClicked()
                mouseclick = False
            End If
        End If
    End Sub
    Private Sub LL_Button_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        If mouseover Then
            g.DrawImage(LottoLight.RoundedRectangle.DrawRoundRectangle(New Rectangle(1, 4, Me.Width - 2, Me.Height - 2), 6, 4, Color.FromArgb(39, 185, 101), Color.FromArgb(39, 185, 101)), 1, 4, Me.Width - 2, Me.Height - 2)
            g.DrawImage(LottoLight.RoundedRectangle.DrawRoundRectangle(New Rectangle(1, 1, Me.Width - 2, Me.Height - 3), 6, 4, Color.FromArgb(39, 185, 101), Color.FromArgb(39, 185, 101)), 1, 1, Me.Width - 2, Me.Height - 3)
            g.DrawString("Smart Play", New Font("Arial", 14, FontStyle.Regular), Brushes.White, New Rectangle(10, Me.Height - 38, Me.Width - 12, Me.Height - 38))
           
        Else
            g.DrawImage(LottoLight.RoundedRectangle.DrawRoundRectangle(New Rectangle(1, 4, Me.Width - 2, Me.Height - 2), 6, 4, Color.FromArgb(39, 185, 101), Color.FromArgb(39, 185, 101)), 1, 4, Me.Width - 2, Me.Height - 2)
            g.DrawImage(LottoLight.RoundedRectangle.DrawRoundRectangle(New Rectangle(1, 1, Me.Width - 2, Me.Height - 3), 6, 4, Color.FromArgb(46, 204, 113), Color.FromArgb(46, 204, 113)), 1, 1, Me.Width - 2, Me.Height - 3)
            g.DrawString("Smart Play", New Font("Arial", 14, FontStyle.Regular), Brushes.White, New Rectangle(10, Me.Height - 38, Me.Width - 12, Me.Height - 38))
        End If
        If mouseclick Then
            g.DrawImage(LottoLight.RoundedRectangle.DrawRoundRectangle(New Rectangle(1, 4, Me.Width - 2, Me.Height - 2), 6, 4, Color.FromArgb(46, 204, 113), Color.FromArgb(46, 204, 113)), 1, 4, Me.Width - 2, Me.Height - 2)
            g.DrawImage(LottoLight.RoundedRectangle.DrawRoundRectangle(New Rectangle(1, 1, Me.Width - 2, Me.Height - 5), 6, 4, Color.FromArgb(39, 185, 101), Color.FromArgb(39, 185, 101)), 1, 1, Me.Width - 2, Me.Height - 5)
            g.DrawString("Smart Play", New Font("Arial", 14, FontStyle.Regular), Brushes.White, New Rectangle(10, Me.Height - 38, Me.Width - 12, Me.Height - 38))
        End If

    End Sub


End Class
Public Class LL_BubProgbar
    Inherits Control
    Sub New()
        Me.DoubleBuffered = False
    End Sub
    Property Percent As Integer = 100
    Property ShowBubble As Boolean = True
    Property ShowLabel As Boolean = False
    Property Label As String
    Property ShowPathLine As Boolean = True
    Property BarColor As Color = Color.FromArgb(252, 165, 51)

    Private Sub LL_BubProgbar_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.HighQuality
        g.DrawImage(LottoLight.RoundedRectangle.DrawRoundRectangle(New Rectangle(1, 1, ((Me.Width - 1) - (Me.Width * Percent) / Percent), Me.Height - 2), 6, 4, BarColor, BarColor), New Rectangle(1, 1, Me.Width - 1 - ((Me.Width - 1) - (Me.Width * Percent) / Percent), Me.Height - 2))
    End Sub
End Class