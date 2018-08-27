Public Class CC_Form
  Inherits Control
  Property OddColor As Color = Color.FromArgb(251, 161, 161)
  Property EvenColor As Color = Color.FromArgb(252, 174, 174)
  Property Fence_Width As Integer = 32
  Property header_Height As Integer = 80
  Property Ribbon_Side_Color As Color = Color.FromArgb(57, 229, 189)
  Property Ribbon_Color As Color = Color.FromArgb(35, 207, 167)
  Property Bubble_Color As Color = Color.FromArgb(251, 161, 161)
  Property Border_Color1 As Color = Color.FromArgb(160, 236, 217)
  Property Border_Color2 As Color = Color.FromArgb(35, 207, 167)
  Property Border_Color3 As Color = Color.FromArgb(57, 229, 189)
  Property Bottom_B_Color1 As Color = Color.FromArgb(230, 201, 255)
  Property Bottom_B_Color2 As Color = Color.FromArgb(135, 92, 173)
  Property Bottom_B_Color3 As Color = Color.FromArgb(205, 171, 234)
  Property Top_Fence_Color As Color = Color.FromArgb(183, 239, 251)
  Property Rounded_Corners As Boolean = True
  Property Max_Tog As Boolean = False
  Property Min_Tog As Boolean = False
  Property Close_Tog As Boolean = False
  Sub New()
    Me.BackColor = Color.White
    Me.DoubleBuffered = True
    Me.Dock = DockStyle.Fill
  End Sub
  <Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
  Private Shared Function CreateRoundRectRgn(nLeftRect As Integer, nTopRect As Integer, nRightRect As Integer, nBottomRect As Integer, nWidthEllipse As Integer, nHeightEllipse As Integer) As IntPtr
  End Function
  Private Sub CC_Form_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    If Rounded_Corners = True Then
      Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Me.Width + 1, Me.Height + 1, 11, 11))
    End If
    e.Graphics.Clear(BackColor)
    e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
    Dim mx_f_i As Integer = Math.Ceiling(Me.Width / Fence_Width)
    For i As Integer = 0 To mx_f_i
      If i Mod 2 <> 0 Then
        Dim FencePs As Point() = {New Point(Fence_Width * i, header_Height), New Point(((Fence_Width * i) - Fence_Width / 2), header_Height - 20), New Point((Fence_Width * i) - Fence_Width, header_Height), New Point((Fence_Width * i) - Fence_Width, Me.Height), New Point(Fence_Width * i, Me.Height), New Point(Fence_Width * i, header_Height)}
        e.Graphics.FillPolygon(New SolidBrush(OddColor), FencePs)
      Else
        Dim FencePs As Point() = {New Point(Fence_Width * i, header_Height), New Point(((Fence_Width * i) - Fence_Width / 2), header_Height - 20), New Point((Fence_Width * i) - Fence_Width, header_Height), New Point((Fence_Width * i) - Fence_Width, Me.Height), New Point(Fence_Width * i, Me.Height), New Point(Fence_Width * i, header_Height)}
        e.Graphics.FillPolygon(New SolidBrush(EvenColor), FencePs)
      End If
    Next
    'Bubble 
    e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(60, Color.Black)), New Rectangle(Me.Width / 2 - 40, 8, 80, 80))
    e.Graphics.FillEllipse(New SolidBrush(Bubble_Color), New Rectangle(Me.Width / 2 - 40, 5, 80, 80))
    e.Graphics.DrawImage(FindForm.Icon.ToBitmap, New Rectangle(Me.Width / 2 - 12, 12, 24, 24))
    Dim fmtxsz As SizeF = e.Graphics.MeasureString(FindForm.Text, FindForm.Font)
    Dim rib_rt As Point() = {New Point(Me.Width / 2 - (fmtxsz.Width + 8) / 2, 40), New Point(Me.Width / 2 - (fmtxsz.Width + 18) / 2, 40), New Point(Me.Width / 2 - (fmtxsz.Width + 13) / 2, 40 + fmtxsz.Height / 2), New Point(Me.Width / 2 - (fmtxsz.Width + 18) / 2, 40 + fmtxsz.Height), New Point(Me.Width / 2 - (fmtxsz.Width + 8) / 2, 40 + fmtxsz.Height), New Point(Me.Width / 2 - (fmtxsz.Width + 8) / 2, 40)}
    Dim rib_lt As Point() = {New Point(Me.Width / 2 + (fmtxsz.Width + 10) / 2, 40), New Point(Me.Width / 2 + (fmtxsz.Width + 20) / 2, 40), New Point(Me.Width / 2 + (fmtxsz.Width + 15) / 2, 40 + fmtxsz.Height / 2), New Point(Me.Width / 2 + (fmtxsz.Width + 20) / 2, 40 + fmtxsz.Height), New Point(Me.Width / 2 + (fmtxsz.Width + 10) / 2, 40 + fmtxsz.Height), New Point(Me.Width / 2 + (fmtxsz.Width + 10) / 2, 40)}
    e.Graphics.FillPolygon(New SolidBrush(Ribbon_Side_Color), rib_rt)
    e.Graphics.FillPolygon(New SolidBrush(Ribbon_Side_Color), rib_lt)
    e.Graphics.FillRectangle(New SolidBrush(Ribbon_Color), New Rectangle(Me.Width / 2 - (fmtxsz.Width + 8) / 2, 40, fmtxsz.Width + 8, fmtxsz.Height + 2))
    e.Graphics.DrawString(FindForm.Text, FindForm.Font, Brushes.White, New Rectangle(Me.Width / 2 - (fmtxsz.Width + 8) / 2, 40, fmtxsz.Width + 8, fmtxsz.Height + 2), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    'Border
    e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(140, Color.White)), New Rectangle(0, header_Height + 54, Me.Width, Me.Height - (header_Height + 104)))
    e.Graphics.FillRectangle(New SolidBrush(Border_Color1), New Rectangle(0, header_Height + 20, Me.Width, 18))

    e.Graphics.FillRectangle(New SolidBrush(Border_Color3), New Rectangle(0, header_Height + 54, Me.Width, 6))
    e.Graphics.FillRectangle(New SolidBrush(Border_Color2), New Rectangle(0, header_Height + 26, Me.Width, 30))
    'Bttom
    e.Graphics.FillRectangle(New SolidBrush(Bottom_B_Color1), New Rectangle(0, Me.Height - (header_Height) + 20, Me.Width, 18))

    e.Graphics.FillRectangle(New SolidBrush(Bottom_B_Color3), New Rectangle(0, Me.Height - (header_Height) + 54, Me.Width, 6))
    e.Graphics.FillRectangle(New SolidBrush(Bottom_B_Color2), New Rectangle(0, Me.Height - (header_Height) + 26, Me.Width, 30))
    'Fence Top
    Dim FenceTP As Point() = {New Point(Me.Width, 10), New Point(Me.Width - 70, 10), New Point(Me.Width - 76, 22), New Point(Me.Width - 70, 34), New Point(Me.Width, 34), New Point(Me.Width, 10)}
    e.Graphics.FillPolygon(New SolidBrush(Top_Fence_Color), FenceTP)
    'Buttons
    If Close_Tog = False Then
      e.Graphics.FillEllipse(Brushes.LightGray, New Rectangle(Me.Width - 20, 13, 16, 16))
      e.Graphics.FillEllipse(Brushes.White, New Rectangle(Me.Width - 20, 12, 16, 16))
      e.Graphics.DrawString("x", New Font("Arial", 10, FontStyle.Bold), Brushes.DarkGray, New Rectangle(Me.Width - 20, 11, 16, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    Else
      e.Graphics.FillEllipse(Brushes.LightGray, New Rectangle(Me.Width - 20, 13, 16, 16))
      e.Graphics.FillEllipse(Brushes.White, New Rectangle(Me.Width - 20, 12, 16, 16))
      e.Graphics.DrawString("x", New Font("Arial", 10, FontStyle.Bold), Brushes.DarkGray, New Rectangle(Me.Width - 20, 11, 16, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
      e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(80, Color.Black)), New Rectangle(Me.Width - 20, 12, 16, 17))
    End If
   
    If Max_Tog = False Then
      e.Graphics.FillEllipse(Brushes.LightGray, New Rectangle(Me.Width - 40, 13, 16, 16))
      e.Graphics.FillEllipse(Brushes.White, New Rectangle(Me.Width - 40, 12, 16, 16))
      e.Graphics.DrawString("+", New Font("Arial", 11, FontStyle.Bold), Brushes.DarkGray, New Rectangle(Me.Width - 40, 13, 16, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    Else
      e.Graphics.FillEllipse(Brushes.LightGray, New Rectangle(Me.Width - 40, 13, 16, 16))
      e.Graphics.FillEllipse(Brushes.White, New Rectangle(Me.Width - 40, 12, 16, 16))
      e.Graphics.DrawString("+", New Font("Arial", 11, FontStyle.Bold), Brushes.DarkGray, New Rectangle(Me.Width - 40, 13, 16, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
      e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(80, Color.Black)), New Rectangle(Me.Width - 40, 12, 16, 17))
    End If
   
    If Min_Tog = False Then
      e.Graphics.FillEllipse(Brushes.LightGray, New Rectangle(Me.Width - 60, 13, 16, 16))
      e.Graphics.FillEllipse(Brushes.White, New Rectangle(Me.Width - 60, 12, 16, 16))
      e.Graphics.DrawString("-", New Font("Arial", 11, FontStyle.Bold), Brushes.DarkGray, New Rectangle(Me.Width - 59, 13, 16, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    Else
      e.Graphics.FillEllipse(Brushes.LightGray, New Rectangle(Me.Width - 60, 13, 16, 16))
      e.Graphics.FillEllipse(Brushes.White, New Rectangle(Me.Width - 60, 12, 16, 16))
      e.Graphics.DrawString("-", New Font("Arial", 11, FontStyle.Bold), Brushes.DarkGray, New Rectangle(Me.Width - 59, 13, 16, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
      e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(80, Color.Black)), New Rectangle(Me.Width - 60, 12, 16, 17))
    End If
   
  End Sub
#Region "ThemeDraggable"
  Dim x, y As Integer
  Private savePoint As New Point(0, 0)
  Private isDragging As Boolean = False

  Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
    Dim dragRect As New Rectangle(0, 0, Me.Width - 70, header_Height)
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
    If New Rectangle(Me.Width - 20, 13, 16, 16).Contains(e.X, e.Y) Then
      Close_Tog = True
      Cursor = Cursors.Hand
    Else
      Close_Tog = False
      Cursor = Cursors.Arrow
    End If
    If New Rectangle(Me.Width - 40, 13, 16, 16).Contains(e.X, e.Y) Then
      Max_Tog = True
      Cursor = Cursors.Hand
    Else
      Max_Tog = False
      Cursor = Cursors.Arrow
    End If
    If New Rectangle(Me.Width - 60, 13, 16, 16).Contains(e.X, e.Y) Then
      Min_Tog = True
      Cursor = Cursors.Hand
    Else
      Min_Tog = False
      Cursor = Cursors.Arrow
    End If
    If isDragging Then
      Dim screenPoint As Point = PointToScreen(e.Location)

      FindForm().Location = New Point(screenPoint.X - Me.savePoint.X, screenPoint.Y - Me.savePoint.Y)
    End If
    MyBase.OnMouseMove(e)
    Invalidate()
  End Sub

#End Region
End Class