Imports System.Drawing.Drawing2D
Imports System.ComponentModel

#Region "Reqution Theme"
Public Class MainContainer
    Inherits ContainerControl

#Region "Modules & Functions"
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
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
    Sub New()
        Me.Dock = DockStyle.Fill
        Me.DoubleBuffered = True
        Padding = New Padding(1, 25, 0, 51)
    End Sub
#Region "Paint"
    Private Sub MainContainer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Color.Black)
        'Top Bar
        FillNotBottomRoundedRectangle(e.Graphics, New Rectangle(0, 0, Me.Width, 20), 28, New SolidBrush(Color.FromArgb(22, 28, 40)))

        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(22, 28, 40)), New Rectangle(14, 1, 2, 18))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(22, 28, 40)), New Rectangle(Me.Width - 15, 1, 2, 18))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(22, 28, 40)), New Rectangle(1, 14, Me.Width - 1, 10))
        e.Graphics.DrawString(FindForm.Text, Font, Brushes.White, New Rectangle(0, 5, Me.Width, 20), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        'Bottom
        FillNotTopRoundedRectangle(e.Graphics, New Rectangle(0, Me.Height - 65, Me.Width, 65), 28, New SolidBrush(Color.FromArgb(45, 57, 96)))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(45, 57, 96)), New Rectangle(14, Me.Height - 25, 2, 25))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(45, 57, 96)), New Rectangle(Me.Width - 15, Me.Height - 25, 2, 25))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(45, 57, 96)), New Rectangle(1, Me.Height - 14, Me.Width - 1, 2))
        '  e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(45, 57, 96)), New Rectangle(0, Me.Height - 120, Me.Width, 25))
        'Filler
        Dim rect = New Rectangle(1, 24, Me.Width - 1, Me.Height - 75)
        Dim gradbrush = New LinearGradientBrush(rect, Color.FromArgb(47, 57, 100), Color.FromArgb(26, 31, 45), 120.0!)
        e.Graphics.FillRectangle(gradbrush, rect)

    End Sub
#End Region
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width, 48)
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
<DefaultEvent("Scroll")> _
Class CustomScrollBar
    Inherits Control
    'Made by the awesome and great AeonHack
    Event Scroll(ByVal sender As Object)
    Public Sub FillRoundedRectangle(ByVal g As Drawing.Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub
    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then value = 1

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            If Not ShowThumb Then Return _Minimum
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            InvalidatePosition()

            RaiseEvent Scroll(Me)
        End Set
    End Property

    Property _Percent As Double
    Public ReadOnly Property Percent As Double
        Get
            If Not ShowThumb Then Return 0
            Return GetProgress()
        End Get
    End Property

    Private _SmallChange As Integer = 1
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _SmallChange = value
        End Set
    End Property

    Private _LargeChange As Integer = 10
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _LargeChange = value
        End Set
    End Property

    Private ButtonSize As Integer = 16
    Private ThumbSize As Integer = 24 ' 14 minimum

    Private TSA As Rectangle
    Private BSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle

    Private ShowThumb As Boolean
    Private ThumbDown As Boolean

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Width = 18

        B1 = New SolidBrush(Color.FromArgb(27, 132, 188))
        B2 = New SolidBrush(Color.FromArgb(33, 159, 225))

        P1 = New Pen(Color.FromArgb(235, 235, 235))
        P2 = New Pen(Color.FromArgb(165, 165, 165))
        P3 = New Pen(Color.FromArgb(155, 155, 155))
        P4 = New Pen(Color.FromArgb(140, 140, 40))
    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private P1, P2, P3, P4 As Pen
    Private B1, B2 As SolidBrush

    Dim I1 As Integer

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(Color.FromArgb(28, 32, 49))

        GP1 = DrawArrow(2, 6, False)
        GP2 = DrawArrow(3, 7, False)

        'g.FillPath(B1, GP2)
        'g.FillPath(B2, GP1)

        GP3 = DrawArrow(2, Height - 11, True)
        GP4 = DrawArrow(3, Height - 10, True)

        'g.FillPath(B1, GP4)
        'g.FillPath(B2, GP3)

        If ShowThumb Then
            '   g.FillRectangle(B1, Thumb)
            FillRoundedRectangle(g, Thumb, 8, New SolidBrush(Color.FromArgb(72, 141, 188)))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(72, 141, 188)), New Point(Thumb.X + 1, Thumb.Y + 4), New Point(Thumb.Width, Thumb.Y + 4))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(72, 141, 188)), New Point(Thumb.X + 1, Thumb.Y + Thumb.Height - 4), New Point(Thumb.Width, Thumb.Y + Thumb.Height - 4))
            'Top Y down lines
            e.Graphics.DrawLine(New Pen(Color.FromArgb(72, 141, 188)), New Point(Thumb.X + 4, Thumb.Y + 1), New Point(Thumb.X + 4, Thumb.Y + 3))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(72, 141, 188)), New Point(Thumb.X + Thumb.Width - 4, Thumb.Y + 1), New Point(Thumb.X + Thumb.Width - 4, Thumb.Y + 3))
            'Bottom Y down Lines
            e.Graphics.DrawLine(New Pen(Color.FromArgb(72, 141, 188)), New Point(Thumb.X + 4, Thumb.Y + Thumb.Height - 4), New Point(Thumb.X + 4, Thumb.Y + Thumb.Height - 1))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(72, 141, 188)), New Point(Thumb.X + Thumb.Width - 4, Thumb.Y + Thumb.Height - 4), New Point(Thumb.X + Thumb.Width - 4, Thumb.Y + Thumb.Height - 1))
            ' g.DrawRectangle(P1, Thumb)
            '  g.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2)

            Dim Y As Integer
            Dim LY As Integer = Thumb.Y + (Thumb.Height \ 2) - 3

            For I As Integer = 0 To 2
                Y = LY + (I * 3)

                ' g.DrawLine(P1, Thumb.X + 5, Y, Thumb.Right - 5, Y)
                ' g.DrawLine(P2, Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1)
            Next
        End If

        '   g.DrawRectangle(P3, 0, 0, Width - 1, Height - 1)
        '  G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3)
    End Sub

    Private Function DrawArrow(x As Integer, y As Integer, flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 4
        Dim H As Integer = 5

        If flip Then
            GP.AddLine(x + 1, y, x + W + 1, y)
            GP.AddLine(x + W, y, x + H, y + H - 1)
        Else
            GP.AddLine(x, y + H, x + W, y + H)
            GP.AddLine(x + W, y + H, x + H, y)
        End If

        GP.CloseFigure()
        Return GP
    End Function

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        TSA = New Rectangle(0, 0, Width, ButtonSize)
        BSA = New Rectangle(0, Height - ButtonSize, Width, ButtonSize)
        Shaft = New Rectangle(0, TSA.Bottom + 1, Width, Height - (ButtonSize * 2) - 1)

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Height)

        If ShowThumb Then
            'ThumbSize = Math.Max(0, 14) 'TODO: Implement this

            Thumb = New Rectangle(1, 0, Width - 8, ThumbSize)
        End If

        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.Y = CInt(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If TSA.Contains(e.Location) Then
                I1 = _Value - _SmallChange
            ElseIf BSA.Contains(e.Location) Then
                I1 = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    MyBase.OnMouseDown(e)
                    Return
                Else
                    If e.Y < Thumb.Y Then
                        I1 = _Value - _LargeChange
                    Else
                        I1 = _Value + _LargeChange
                    End If
                End If
            End If

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.Y - TSA.Height - (ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Height - ThumbSize

            I1 = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
        MyBase.OnMouseUp(e)
    End Sub

    Private Function GetProgress() As Double
        Return (_Value - _Minimum) / (_Maximum - _Minimum)
    End Function

End Class
Public Class CustomTabControl
    Inherits TabControl

    Private BC As Color = Color.FromArgb(47, 57, 100) 'Background Color
    Private SLGT As Color = Color.FromArgb(47, 57, 100) 'Selected Tab Gradient Color Top
    Private SLGB As Color = Color.FromArgb(200, 200, 200) 'Selected Tab Gradient Color Bottom
    Private SLLT As Pen = New Pen(Color.FromArgb(165, 165, 165)) 'Selected Tab Line Color Top
    Private SLLB As Pen = New Pen(Color.FromArgb(98, 98, 98)) 'Selected Tab Line Color Bottom
    Private TC As SolidBrush = New SolidBrush(Color.FromArgb(180, 180, 180)) 'Header Text Color
    Private UTC As Brush = Brushes.White 'Unselected Tab Font Color
    Private STC As Brush = New SolidBrush(Color.FromArgb(67, 129, 172)) 'Selected Tab Font Color

    Private BCB As SolidBrush = New SolidBrush(BC)
    Private BCP As Pen = New Pen(BC)
    Private TR, InTR, InR, LR, ImR As Rectangle
    Private SF As StringFormat = New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center}
    Private SFHeader As StringFormat = New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Far}
    Private ICounter As Integer = 0
    Private SLGBr As LinearGradientBrush
    Private TSB As SolidBrush
    Private TROffset As Integer = 1

    Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.Opaque Or ControlStyles.ResizeRedraw Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.Opaque, True)
        SetStyle(ControlStyles.Selectable, False)
        SizeMode = TabSizeMode.Fixed
        Alignment = TabAlignment.Left
        ItemSize = New Size(21, 180)
        DrawMode = TabDrawMode.OwnerDrawFixed
        Font = New Font("Verdana", 8)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        Dim rect = New Rectangle(1, 24, Me.Width - 1, Me.Height - 55)
        Dim gradbrush = New LinearGradientBrush(rect, Color.FromArgb(47, 57, 100), Color.FromArgb(26, 31, 45), 120.0!)
        If Not SelectedIndex = Nothing AndAlso Not SelectedIndex = -1 AndAlso Not SelectedIndex > TabPages.Count - 1 AndAlso Not TabPages(SelectedIndex).BackColor = Color.Transparent Then
            g.Clear(Color.FromArgb(47, 57, 100))
        Else
            g.Clear(Color.FromArgb(47, 57, 100))
        End If
        ICounter = 0

        LR = New Rectangle(0, 0, ItemSize.Height + 3, Height)
        gradbrush = New LinearGradientBrush(LR, Color.FromArgb(47, 57, 100), Color.FromArgb(26, 31, 45), 120.0!)
        g.FillRectangle(gradbrush, LR)
        'g.DrawRectangle(BCP, LR)

        g.SmoothingMode = SmoothingMode.AntiAlias
        For i = 0 To TabCount - 1
            TR = GetTabRect(i)
            TR = New Rectangle(TR.X, TR.Y, TR.Width - 1, TR.Height)
            If TabPages(i).Tag IsNot Nothing AndAlso TabPages(i).Tag IsNot String.Empty Then
                InR = New Rectangle(TR.X + 10, TR.Y, TR.Width - 10, TR.Height)
                g.DrawString(TabPages(i).Text.ToUpper, New Font("Myriad Pro", 10, FontStyle.Regular), TC, InR, SFHeader)
                ICounter += 1
            Else
                If i = SelectedIndex Then
                    SLGBr = New LinearGradientBrush(TR, SLGT, SLGB, 90)
                    InR = New Rectangle(TR.X + 36, TR.Y, TR.Width - 36, TR.Height)
                    InTR = New Rectangle(TR.X, TR.Y + TROffset, TR.Width, TR.Height - (2 * TROffset))

                    ' g.FillRectangle(SLGBr, InTR)
                    'g.DrawLine(SLLT, TR.X, TR.Y + TROffset, TR.X + TR.Width - 1, TR.Y + TROffset)
                    '  g.DrawLine(SLLB, TR.X, TR.Y + TR.Height - TROffset, TR.X + TR.Width - 1, TR.Y + TR.Height - TROffset)
                    g.DrawString(TabPages(i).Text, New Font("Myriad Pro", 10, FontStyle.Regular), STC, InR, SF)

                    If SelectedImageList IsNot Nothing AndAlso SelectedImageList.Images.Count > i - ICounter AndAlso SelectedImageList.Images(i - ICounter) IsNot Nothing Then
                        ImR = New Rectangle(TR.X + 13, TR.Y + ((TR.Height / 2) - 8), 16, 16)
                        g.DrawImage(SelectedImageList.Images(i - ICounter), ImR)
                    End If

                Else
                    InR = New Rectangle(TR.X + 36, TR.Y, TR.Width - 36, TR.Height)
                    g.DrawString(TabPages(i).Text, Font, UTC, InR, SF)

                    If UnselectedImageList IsNot Nothing AndAlso UnselectedImageList.Images.Count > i - ICounter AndAlso UnselectedImageList.Images(i - ICounter) IsNot Nothing Then
                        ImR = New Rectangle(TR.X + 13, TR.Y + ((TR.Height / 2) - 8), 16, 16)
                        g.DrawImage(UnselectedImageList.Images(i - ICounter), ImR)
                    End If

                End If
            End If
        Next


        g.Dispose()

    End Sub

    Private UnselectedImageList As ImageList
    Public Property ImageList_Unselected As ImageList
        Get
            Return UnselectedImageList
        End Get
        Set(value As ImageList)
            UnselectedImageList = value
            If UnselectedImageList IsNot Nothing AndAlso Not UnselectedImageList.ImageSize = New Size(16, 16) Then
                UnselectedImageList.ImageSize = New Size(16, 16)
            End If
            Invalidate()
        End Set
    End Property

    Private SelectedImageList As ImageList
    Public Property ImageList_Selected As ImageList
        Get
            Return SelectedImageList
        End Get
        Set(value As ImageList)
            SelectedImageList = value
            If SelectedImageList IsNot Nothing AndAlso Not SelectedImageList.ImageSize = New Size(16, 16) Then
                SelectedImageList.ImageSize = New Size(16, 16)
            End If
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnSelecting(e As TabControlCancelEventArgs)
        MyBase.OnSelecting(e)
        If e.TabPage IsNot Nothing AndAlso e.TabPage.Tag IsNot Nothing AndAlso e.TabPage.Tag IsNot String.Empty AndAlso Not DesignMode Then
            e.Cancel = True
        End If
    End Sub

End Class
Public Class BackgroundContainer
    Inherits Control
    Sub New()
        Me.DoubleBuffered = True
    End Sub
#Region "Paint"

#End Region

    Private Sub BackgroundContainer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim rect = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim gradbrush = New LinearGradientBrush(rect, Color.FromArgb(47, 57, 100), Color.FromArgb(26, 31, 45), 120.0!)
        e.Graphics.FillRectangle(gradbrush, rect)
    End Sub

    Private Sub BackgroundContainer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
End Class
Public Class PlayListControl
    Inherits ContainerControl
    Property Image As Image
    Event Clicked()
    Property Texxt As String = "PLAYLIST"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
           ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
           ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Parent = FindForm()
        Me.Padding = New Padding(0, 30, 0, 0)
    End Sub
#Region "Paint"
    Private Sub PlayListControl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(50, 67, 129, 172)), New Rectangle(0, 0, Me.Width, 30))
        e.Graphics.DrawImage(Image, New Rectangle(20, 4, 24, 24))
        e.Graphics.DrawString(Texxt, New Font("Myriad Pro", 10, FontStyle.Regular), Brushes.White, New Rectangle(48, 8, Me.Width, 40))
        e.Graphics.DrawString("+", New Font("Myriad Pro", 16, FontStyle.Regular), Brushes.White, New Rectangle(Me.Width - 25, 4, Me.Width, 40))
    End Sub
#End Region
#Region "ThemeDraggable"
    Dim clickedd As Boolean = False
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If New Rectangle(Me.Width - 25, 4, Me.Width, 40).Contains(mouseX, mouseY) Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RaiseEvent Clicked()
            End If
        End If
        '
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y
        If New Rectangle(2, 2, Me.Width - 4, Me.Height - 4).Contains(mouseX, mouseY) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class
Partial Public Class PlayListbox
    Inherits Control
    Public Event SelectedItem(i As Integer)
    Property OutBorderColor As Color = Color.FromArgb(229, 229, 229)
    Property InBorderColor As Color = Color.FromArgb(219, 219, 219)
    Property BoxColor As Color = Color.FromArgb(242, 242, 242)
    Property OddColor As Color = Color.FromArgb(88, 159, 214)
    Property PopOddColor As Color = Color.FromArgb(28, 32, 49)
    Private VS As CustomScrollBar
    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub HandleScroll(sender As Object)
        Invalidate()
    End Sub

    Private Sub InvalidateScroll()
        VS.Maximum = (_Items.Count * 24)
        Invalidate()
    End Sub

    Private Sub InvalidateLayout()
        VS.Location = New Point(Width - VS.Width + 2, 1)
        VS.Size = New Size(18, Height - 2)

        Invalidate()
    End Sub
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
           ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
           ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Parent = FindForm()


        VS = New CustomScrollBar
        VS.SmallChange = 24
        VS.LargeChange = 24
        AddHandler VS.Scroll, AddressOf HandleScroll
        AddHandler VS.MouseDown, AddressOf VS_MouseDown
        Controls.Add(VS)

        InvalidateLayout()
    End Sub
    Private Sub VS_MouseDown(sender As Object, e As MouseEventArgs)
        Focus()
        Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (24 * 2))))
        Dim Index As Integer = ((e.Y + Offset - 24) \ 24)
    End Sub
    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        Dim Move As Integer = -((e.Delta * SystemInformation.MouseWheelScrollLines \ 120) * (24 \ 2))

        Dim Value As Integer = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum)
        VS.Value = Value

        MyBase.OnMouseWheel(e)
    End Sub
    Public Class ItemCollection
        Inherits List(Of Item)
        Private Parent As PlayListbox
        Public Sub New(Parent As PlayListbox)
            Me.Parent = Parent

        End Sub
        Public Shadows Sub Add(Item As Item)
            MyBase.Add(Item)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub AddRange(Range As List(Of Item))
            MyBase.AddRange(Range)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Remove(Item As Item)
            MyBase.Remove(Item)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of Item))
            MyBase.RemoveAll(Predicate)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
            Parent.InvalidateScroll()
        End Sub

    End Class
    Public Class Item
        Property Text As String
        Property OddColor As Color = Color.FromArgb(37, 142, 198)
        Property PopOddColor As Color = Color.FromArgb(17, 122, 178)
        Property Index As Integer = 0
        Property locy As Integer = 0
        Property Image As Image = My.Resources.Screenshot_3
        Property Selected As Boolean = False
        Protected UniqueId As Guid
        Sub New()
            UniqueId = Guid.NewGuid()
        End Sub
        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is Item Then
                Return (DirectCast(obj, Item).UniqueId = UniqueId)
            End If
            Return False
        End Function

    End Class
    Public _Items As New ItemCollection(Me)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Items As ItemCollection
        Get
            Return _Items
        End Get
        Set(ByVal value As ItemCollection)
            _Items = value
        End Set
    End Property

    Private Sub FlatListbox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (24 * 2))))
        Dim rect2 = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim gradbrush = New LinearGradientBrush(rect2, Color.FromArgb(47, 57, 100), Color.FromArgb(26, 31, 45), 120.0!)
        ' e.Graphics.Clear(BoxColor)
        '   e.Graphics.DrawRectangle(New Pen(InBorderColor), New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
        ' e.Graphics.DrawRectangle(New Pen(OutBorderColor), New Rectangle(0, 0, Me.Width - 2, Me.Height - 2))
        e.Graphics.FillRectangle(gradbrush, rect2)
        VS.Width = 16
        VS.Height = Me.Height + 32
        VS.Location = New Point(Me.Width - 10, -16)
        Dim y As Integer = 4
        For Each Item As Item In _Items

            y = 24 * Item.Index
            If Not Item.Selected = True Then
                Item.locy = y
                Dim rect = New Rectangle(0, y - Offset, Me.Width - 4, 24)
                e.Graphics.FillRectangle(New SolidBrush(Color.Transparent), rect)
                rect = New Rectangle(0, y + 20 - Offset, Me.Width - 4, 4)
                e.Graphics.FillRectangle(New SolidBrush(Color.Transparent), rect)
                e.Graphics.DrawString(Item.Text, New Font("Myriad Pro", 9.5, FontStyle.Regular), New SolidBrush(Color.FromArgb(230, 230, 230)), 24, y + 4 - Offset)
                e.Graphics.DrawImage(Item.Image, New Rectangle(6, y + 6 - Offset, 16, 16))
            Else
                Dim rect = New Rectangle(0, y - Offset, Me.Width, 24)
                e.Graphics.FillRectangle(New SolidBrush(OddColor), rect)
                rect = New Rectangle(0, y - Offset, 3, 24)
                e.Graphics.FillRectangle(New SolidBrush(PopOddColor), rect)
                e.Graphics.DrawString(Item.Text, New Font("Myriad Pro", 9.5, FontStyle.Regular), New SolidBrush(Color.White), 24, y + 4 - Offset)
                e.Graphics.DrawImage(Item.Image, New Rectangle(6, y + 6 - Offset, 16, 16))
            End If
        Next
    End Sub
    'Example
    Public Function SelectedItemIndex()
        For Each Item As Item In _Items
            If Item.Selected = True Then
                Return Item.Index
            End If
        Next
    End Function
#Region "ThemeDraggable"
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim y As Integer = 3
        Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (24 * 2))))
        For Each Item As Item In _Items
            y = 24 * Item.Index
            Dim rect = New Rectangle(2, y - Offset, Me.Width - 4, 24)
            If Item.locy = y Then
                If rect.Contains(mouseX, mouseY) Then
                    Item.Selected = Not Item.Selected
                    RaiseEvent SelectedItem(Item.Index)
                Else
                    Item.Selected = False
                End If
            Else
                Item.Selected = False
            End If
        Next
        '

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y

        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class
Public Class Texxtbox
    Inherits Panel
#Region "Modules & Functions"
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.FillPie(b, r.X, r.Y, 1, 1, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, 1, 1, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        ' g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub

#End Region
    Friend WithEvents TB As TextBox
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub
    Sub New()
        Me.Size = New Size(200, 30)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
          ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
          ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Parent = FindForm()
        MyBase.Font = New Font("Myriad Pro", 12, FontStyle.Regular)
        TB = New Windows.Forms.TextBox
        TB.Font = New Font("Segoe UI", 15)
        TB.Text = Text
        TB.ForeColor = _TextColour
        TB.MaxLength = _MaxLength
        TB.BackColor = _BaseColour
        TB.Multiline = False
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(5, 7)
        TB.Width = Width - 7
        TB.Font = MyBase.Font
    End Sub
#Region "Paint"
    Private Sub Texxtbox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim rect = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim gradbrush = New LinearGradientBrush(rect, Color.FromArgb(44, 113, 170), Color.FromArgb(30, 107, 158), 120.0!)
        FillRoundedRectangle(e.Graphics, rect, 10, gradbrush)
        rect = New Rectangle(2, 2, Me.Width - 4, Me.Height - 4)
        gradbrush = New LinearGradientBrush(rect, Color.FromArgb(60, 121, 181), Color.FromArgb(60, 121, 181), 120.0!)
        FillRoundedRectangle(e.Graphics, rect, 10, gradbrush)
        DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(31, 79, 115)), 2, 2, Me.Width - 4, Me.Height - 4, 8)
        'textbox
        TB.Text = _Text
        TB.Font = Font
        TB.BackColor = _BaseColour
        TB.ForeColor = _TextColour
        TB.Location = New Point(5, 7)
        TB.Width = Width - 40
    End Sub
#End Region
#Region "Events - Properties"
    Private _BorderColour As Color = Color.FromArgb(163, 190, 146)
    Private _LineColour As Color = Color.FromArgb(221, 221, 221)
    Private _TextColour As Color = Color.FromArgb(12, 46, 83)
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength As Integer = 32767
    Private _ReadOnly As Boolean
    Private _BaseColour As Color = Color.FromArgb(60, 121, 181)
    Private _UseSystemPasswordChar As Boolean
    Private _Text As String = "Username"
    Public Sub SelectAll()
        TB.Focus()
        TB.SelectAll()
        Invalidate()
    End Sub
    <Category("Username")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Username")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Username")>
    Public Property LineColour As Color
        Get
            Return _LineColour
        End Get
        Set(value As Color)
            _LineColour = value
        End Set
    End Property

    <Category("Username")>
    Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
        End Set
    End Property



    <Category("Username")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property

    <Category("Username")>
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property

    <Category("Username")>
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Username")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    <Category("Username")>
    Property Textt As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property


#End Region
End Class
Public Class CustomSplitter
    Inherits Panel
    Sub New()
        Me.Size = New Size(10, 3)

    End Sub
#Region "paint"
    Private Sub CustomSplitter_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(56, 171, 215)), New Rectangle(0, 0, Me.Width, Me.Height))
    End Sub
#End Region

 
    Private Sub CustomSplitter_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Size = New Size(Me.Width, 3)
    End Sub
End Class
Public Class Checkbox
    Inherits Panel
    Event CheckClick()
    Property Checked As Boolean = False
#Region "Modules & Functions"
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.FillPie(b, r.X, r.Y, 1, 1, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, 1, 1, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        ' g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub

#End Region
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
   ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
   ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Parent = FindForm()
        Me.Size = New Size(20, 20)
    End Sub
#Region "paint"

    Private Sub Checkbox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim rect = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim gradbrush = New LinearGradientBrush(rect, Color.FromArgb(44, 113, 170), Color.FromArgb(30, 107, 158), 120.0!)
        FillRoundedRectangle(e.Graphics, rect, 2, gradbrush)
        rect = New Rectangle(2, 2, Me.Width - 4, Me.Height - 4)
        gradbrush = New LinearGradientBrush(rect, Color.FromArgb(60, 121, 181), Color.FromArgb(44, 98, 135), 120.0!)
        FillRoundedRectangle(e.Graphics, rect, 2, gradbrush)
        DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(31, 79, 115)), 2, 2, Me.Width - 4, Me.Height - 4, 1)
        If Checked = False Then

        Else
            e.Graphics.DrawString("a", New Font("Webdings", 12, FontStyle.Regular), Brushes.White, New Rectangle(0, 0, Me.Width - 4, Me.Height - 4))
        End If
    End Sub
#End Region
#Region "ThemeDraggable"
    Dim clickedd As Boolean = False
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If New Rectangle(2, 2, Me.Width - 4, Me.Height - 4).Contains(mouseX, mouseY) Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RaiseEvent CheckClick()
                Checked = Not Checked
            End If
        End If
        '
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y
        If New Rectangle(2, 2, Me.Width - 4, Me.Height - 4).Contains(mouseX, mouseY) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class
Module DesignFunctions
    Function ToBrush(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return ToBrush(Color.FromArgb(A, R, G, B))
    End Function
    Function ToBrush(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return ToBrush(Color.FromArgb(R, G, B))
    End Function
    Function ToBrush(ByVal A As Integer, ByVal C As Color) As Brush
        Return ToBrush(Color.FromArgb(A, C))
    End Function
    Function ToBrush(ByVal Pen As Pen) As Brush
        Return ToBrush(Pen.Color)
    End Function
    Function ToBrush(ByVal Color As Color) As Brush
        Return New SolidBrush(Color)
    End Function
    Function ToPen(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return ToPen(Color.FromArgb(A, R, G, B))
    End Function
    Function ToPen(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return ToPen(Color.FromArgb(R, G, B))
    End Function
    Function ToPen(ByVal A As Integer, ByVal C As Color) As Pen
        Return ToPen(Color.FromArgb(A, C))
    End Function
    Function ToPen(ByVal Color As Color) As Pen
        Return ToPen(New SolidBrush(Color))
    End Function
    Function ToPen(ByVal Brush As SolidBrush) As Pen
        Return New Pen(Brush)
    End Function

    Class CornerStyle
        Public TopLeft As Boolean
        Public TopRight As Boolean
        Public BottomLeft As Boolean
        Public BottomRight As Boolean
    End Class

    Public Function AdvRect(ByVal Rectangle As Rectangle, ByVal CornerStyle As CornerStyle, ByVal Curve As Integer) As GraphicsPath
        AdvRect = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2

        If CornerStyle.TopLeft Then
            AdvRect.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        Else
            AdvRect.AddLine(Rectangle.X, Rectangle.Y, Rectangle.X + ArcRectangleWidth, Rectangle.Y)
        End If

        If CornerStyle.TopRight Then
            AdvRect.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        Else
            AdvRect.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + ArcRectangleWidth)
        End If

        If CornerStyle.BottomRight Then
            AdvRect.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        Else
            AdvRect.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height, Rectangle.X + Rectangle.Width - ArcRectangleWidth, Rectangle.Y + Rectangle.Height)
        End If

        If CornerStyle.BottomLeft Then
            AdvRect.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        Else
            AdvRect.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y + Rectangle.Height - ArcRectangleWidth)
        End If

        AdvRect.CloseAllFigures()

        Return AdvRect
    End Function

    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        RoundRect = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        RoundRect.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        RoundRect.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        RoundRect.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        RoundRect.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        RoundRect.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, ArcRectangleWidth + Rectangle.Y))
        RoundRect.CloseAllFigures()
        Return RoundRect
    End Function

    Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        Return RoundRect(New Rectangle(X, Y, Width, Height), Curve)
    End Function

    Class PillStyle
        Public Left As Boolean
        Public Right As Boolean
    End Class

    Public Function Pill(ByVal Rectangle As Rectangle, ByVal PillStyle As PillStyle) As GraphicsPath
        Pill = New GraphicsPath()

        If PillStyle.Left Then
            Pill.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270, 180)
        Else
            Pill.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y)
        End If

        If PillStyle.Right Then
            Pill.AddArc(New Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90, 180)
        Else
            Pill.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height)
        End If

        Pill.CloseAllFigures()

        Return Pill
    End Function

    Public Function Pill(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal PillStyle As PillStyle)
        Return Pill(New Rectangle(X, Y, Width, Height), PillStyle)
    End Function

End Module
Class ThemedTrackBar
    Inherits Control
    'Base or Template used was from Tedd
#Region "Properties"
    Dim _Maximum As Integer = 10
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _Maximum = value
            If value < _Value Then _Value = value
            Invalidate()
        End Set
    End Property

    Event ValueChanged()
    Dim _Value As Integer = 0
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)

            Select Case value
                Case Is = _Value
                    Exit Property
                Case Is < 0
                    _Value = 0
                Case Is > _Maximum
                    _Value = _Maximum
                Case Else
                    _Value = value
            End Select

            Invalidate()
            RaiseEvent ValueChanged()
        End Set
    End Property
#End Region

    Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or _
                    ControlStyles.AllPaintingInWmPaint Or _
                    ControlStyles.ResizeRedraw Or _
                    ControlStyles.UserPaint Or _
                    ControlStyles.Selectable Or _
                    ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Dim CaptureM As Boolean = False
    Dim Bar As Rectangle = New Rectangle(0, 10, Width - 1, Height - 21)
    Dim Track As Size = New Size(20, 20)

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics
        Bar = New Rectangle(10, 10, Width - 21, Height - 21)
        G.Clear(Color.FromArgb(41, 54, 96))
        G.SmoothingMode = SmoothingMode.HighQuality

        'Background
        Dim BackLinear As LinearGradientBrush = New LinearGradientBrush(New Point(0, CInt((Height / 2) - 4)), New Point(0, CInt((Height / 2) + 4)), Color.FromArgb(65, 65, 65), Color.FromArgb(65, 65, 65))
        G.FillRectangle(New SolidBrush(Color.FromArgb(60, 73, 118)), New Rectangle(0, CInt((Height / 2) - 4), Width - 1, 8))
        '  G.DrawPath(ToPen(50, Color.Black), RoundRect(0, CInt((Height / 2) - 4), Width - 1, 8, 3))
        BackLinear.Dispose()
        G.FillRectangle(New SolidBrush(Color.FromArgb(87, 113, 190)), New Rectangle(0, CInt((Height / 2) - 4), Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 9, 8))

        'Fill
        '  G.FillPath(New LinearGradientBrush(New Point(1, CInt((Height / 2) - 4)), New Point(1, CInt((Height / 2) + 4)), Color.FromArgb(250, 200, 70), Color.FromArgb(250, 160, 40)), RoundRect(1, CInt((Height / 2) - 4), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 8, 3))
        ' G.DrawPath(ToPen(100, Color.White), RoundRect(2, CInt((Height / 2) - 2), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 4, 3))
        G.SetClip(RoundRect(1, CInt((Height / 2) - 4), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 8, 3))
        For i = 0 To CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2) Step 10
            'G.FillEllipse(New SolidBrush(Color.FromArgb(27, 132, 188)), New Rectangle(New Point(i, CInt((Height / 2) - 10)), New Point(i - 10, CInt((Height / 2) + 10))))
        Next
        G.SetClip(New Rectangle(0, 0, Width, Height))

        'Button
        If inner = True Then
            ' G.FillEllipse(Brushes.White, New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 3, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 3, Track.Width - 6, Track.Height - 6))
            ' G.DrawEllipse(ToPen(50, Color.Black), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 3, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 3, Track.Width - 6, Track.Height - 6))
            ' G.FillEllipse(New LinearGradientBrush(New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2)), New Point(0, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + Track.Height), Color.FromArgb(200, Color.Black), Color.FromArgb(25, Color.Black)), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 6, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 6, Track.Width - 12, Track.Height - 12))
        Else
            '  G.FillEllipse(Brushes.White, New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 3, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 3, Track.Width - 6, Track.Height - 6))
            '  G.DrawEllipse(ToPen(50, Color.Black), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2) + 3, Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2) + 3, Track.Width - 6, Track.Height - 6))
        End If
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        Me.BackColor = Color.Transparent

        MyBase.OnHandleCreated(e)
    End Sub
    Dim inner As Boolean = False
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        Dim mp = New Rectangle(New Point(e.Location.X, e.Location.Y), New Size(1, 1))
        Dim Bar As Rectangle = New Rectangle(10, 10, Width - 21, Height - 21)
        If New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), 0), New Size(Track.Width, Height)).IntersectsWith(mp) Then
            CaptureM = True
            inner = True
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        CaptureM = False
        inner = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If CaptureM Then
            Dim mp As Point = New Point(e.X, e.Y)
            Dim Bar As Rectangle = New Rectangle(10, 10, Width - 21, Height - 21)
            Value = CInt(Maximum * ((mp.X - Bar.X) / Bar.Width))
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e) : CaptureM = False
    End Sub

End Class

#End Region
#Region "Reqution Theme"
Public Class LoginContainer
    Inherits ContainerControl

    Sub New()
        Me.Dock = DockStyle.Fill
        Me.DoubleBuffered = True
    End Sub
    'Paint 
#Region "Paint"
    Private Sub LoginContainer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        'Graphics type
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        'Background
        e.Graphics.Clear(Color.FromArgb(45, 57, 96))

        'Top Gradient
        Dim rect = New Rectangle(1, 1, Me.Width, 45)
        Dim TopbarGrad = New LinearGradientBrush(rect, Color.FromArgb(66, 85, 144), Color.FromArgb(45, 57, 96), 180.0!)
        e.Graphics.FillRectangle(TopbarGrad, rect)
        rect = New Rectangle(1, 45, Me.Width, 3)
        TopbarGrad = New LinearGradientBrush(rect, Color.FromArgb(66, 85, 144), Color.FromArgb(50, 45, 57, 96), 180.0!)
        e.Graphics.FillRectangle(TopbarGrad, rect)
        'Border
        e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
    End Sub
#End Region
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width, 46)
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
Public Class ControlBox
    Inherits Panel
    Sub New()
        Me.Size = New Size(50, 15)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
           ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
           ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Parent = FindForm()
    End Sub
#Region "Paint"
    Private Sub ControlBox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        'red button
        Dim redrect = New Rectangle(2, 2, 10, 10)
        Dim redCicleGrad = New LinearGradientBrush(redrect, Color.FromArgb(50, 255, 255, 255), Color.FromArgb(219, 69, 61), 90.0!)
        e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(219, 69, 61)), redrect)
        e.Graphics.FillEllipse(redCicleGrad, redrect)
        'yellow
        Dim yelrect = New Rectangle(16, 2, 10, 10)
        Dim yelCicleGrad = New LinearGradientBrush(yelrect, Color.FromArgb(50, 255, 255, 255), Color.FromArgb(223, 158, 76), 90.0!)
        e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(223, 158, 76)), yelrect)
        e.Graphics.FillEllipse(yelCicleGrad, yelrect)
        'green
        Dim grerect = New Rectangle(30, 2, 10, 10)
        Dim greCicleGrad = New LinearGradientBrush(grerect, Color.FromArgb(50, 255, 255, 255), Color.FromArgb(102, 170, 75), 90.0!)
        e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(102, 170, 75)), grerect)
        e.Graphics.FillEllipse(greCicleGrad, grerect)
    End Sub
#End Region
#Region "ThemeDraggable"
    Dim clickedd As Boolean = False
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If New Rectangle(2, 2, 10, 10).Contains(mouseX, mouseY) Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Environment.Exit(0)
            End If
        End If
        If New Rectangle(16, 2, 10, 10).Contains(mouseX, mouseY) Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If FindForm.WindowState = FormWindowState.Maximized Then
                Else

                End If
                FindForm.WindowState = FormWindowState.Minimized
            End If
        End If
        If New Rectangle(30, 2, 10, 10).Contains(mouseX, mouseY) Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If FindForm.WindowState = FormWindowState.Maximized Then
                    FindForm.WindowState = FormWindowState.Normal
                Else
                    FindForm.WindowState = FormWindowState.Maximized
                End If
            End If
        End If
        '
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y
        If New Rectangle(2, 2, 10, 10).Contains(mouseX, mouseY) Or New Rectangle(16, 2, 10, 10).Contains(mouseX, mouseY) Or New Rectangle(30, 2, 10, 10).Contains(mouseX, mouseY) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class
Public Class LoginBox
    Inherits Panel
    Event Clicked()
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
            Controls.Add(TB2)
        End If
    End Sub
#Region "Modules & Functions"
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
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
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.FillPie(b, r.X, r.Y, 1, 1, 180, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y, 1, 1, 270, 90)
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        ' g.FillRectangle(b, CInt(r.X + d / 2), r.Y, r.Width - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y + d / 2), r.Width, CInt(r.Height - d))
        g.FillRectangle(b, CInt(r.X + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width - d), CInt(d / 2))
        g.SmoothingMode = mode
    End Sub

#End Region
    Sub New()
        Me.Size = New Size(234, 178)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
           ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
           ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Parent = FindForm()
        'Textbox 1
        MyBase.Font = New Font("Arial", 12, FontStyle.Regular)
        TB = New Windows.Forms.TextBox
        TB.BackColor = _BaseColour
        TB.Font = New Font("Segoe UI", 9)
        TB.Text = Text
        TB.BackColor = _BaseColour
        TB.ForeColor = _TextColour
        TB.MaxLength = _MaxLength
        TB.Multiline = False
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(20, 20)
        TB.Width = Width - 10
        TB.Font = MyBase.Font
        'Textbox2
        TB2 = New Windows.Forms.TextBox
        TB2.BackColor = _BaseColour
        TB2.Font = New Font("Segoe UI", 9)
        TB2.Text = Text
        TB2.BackColor = _BaseColour
        TB2.ForeColor = _TextColour
        TB2.MaxLength = _MaxLength
        TB2.Multiline = False
        TB2.ReadOnly = _ReadOnly
        TB2.UseSystemPasswordChar = _UseSystemPasswordChar
        TB2.BorderStyle = BorderStyle.None
        TB2.Location = New Point(20, 85)
        TB2.Width = Width - 10
        TB2.Font = MyBase.Font
    End Sub
#Region "paint"
    Private Sub LoginBox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim Rect = New Rectangle(0, 0, Me.Width, Me.Height - 10)
        Dim GradBrush = New LinearGradientBrush(New Rectangle(0, 0, Me.Width, Me.Height - 64), Color.FromArgb(243, 240, 243), Color.FromArgb(212, 207, 203), 90.0!)
        FillRoundedRectangle(e.Graphics, Rect, 18, GradBrush)
        '  DrawRoundRect(e.Graphics, New Pen(Color.FromArgb(240, 240, 240)), 0, 0, Me.Width, Me.Height, 18)
        If clickedd = False Then
            Rect = New Rectangle(0, Me.Height - 70, Me.Width, 70)
            GradBrush = New LinearGradientBrush(Rect, Color.FromArgb(147, 179, 201), Color.FromArgb(68, 93, 113), 90.0!)
            FillNotTopRoundedRectangle(e.Graphics, Rect, 18, GradBrush)
        Else
            Rect = New Rectangle(0, Me.Height - 70, Me.Width, 70)
            GradBrush = New LinearGradientBrush(Rect, Color.FromArgb(68, 93, 113), Color.FromArgb(48, 73, 93), 90.0!)
            FillNotTopRoundedRectangle(e.Graphics, Rect, 18, GradBrush)
        End If
        GradBrush = New LinearGradientBrush(Rect, Color.FromArgb(50, Color.Black), Color.FromArgb(147, 179, 201), 90.0!)
        Rect = New Rectangle(0, Me.Height - 64, Me.Width, 4)
        e.Graphics.FillRectangle(GradBrush, Rect)
        e.Graphics.DrawLine(New Pen(Color.FromArgb(191, 191, 191)), New Point(0, 60), New Point(Me.Width, 60))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), New Rectangle(6, 0, 5, 10))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), New Rectangle(Me.Width - 10, 0, 5, 5))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), New Rectangle(0, 5, Me.Width, 10))
        'Fix Bottom
        If clickedd = False Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(77, 103, 123)), New Rectangle(7, Me.Height - 8, 2, 7))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(77, 103, 123)), New Rectangle(Me.Width - 10, Me.Height - 8, 2, 7))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(77, 103, 123)), New Rectangle(0, Me.Height - 10, Me.Width, 2))
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(48, 73, 93)), New Rectangle(7, Me.Height - 8, 2, 7))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(48, 73, 93)), New Rectangle(Me.Width - 10, Me.Height - 8, 2, 7))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(48, 73, 93)), New Rectangle(0, Me.Height - 10, Me.Width, 2))
        End If
       
        If clickedd = False Then
            If New Rectangle(10, Me.Height - 60, Me.Width - 20, 70).Contains(mouseX, mouseY) Then
                'e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(mouseX - 7, mouseY - 7, 14, 14))
                'e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(60, Color.White)), New Rectangle(mouseX - 8, mouseY - 8, 16, 16))
                'e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(70, Color.White)), New Rectangle(mouseX - 10, mouseY - 10, 20, 20))
                'e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.White)), New Rectangle(mouseX - 3, mouseY - 3, 5, 5))
                e.Graphics.DrawString("Sign In", New Font("Arial", 18, FontStyle.Regular), New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(0, Me.Height - 65, Me.Width, 70), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                e.Graphics.DrawString("Sign In", New Font("Arial", 17, FontStyle.Regular), New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(0, Me.Height - 65, Me.Width, 70), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End If
        End If
        'Textboxs
        TB.Text = _Text
        TB.BackColor = _BaseColour
        TB.ForeColor = _TextColour
        TB.Location = New Point(20, 20)
        TB.Width = Width - 40
        TB2.Text = _Text2
        TB2.BackColor = _BaseColour2
        TB2.ForeColor = _TextColour2
        TB2.Location = New Point(20, 85)
        TB2.Width = Width - 40
        'Sign In
        e.Graphics.DrawString("Sign In", New Font("Arial", 16, FontStyle.Regular), Brushes.White, New Rectangle(0, Me.Height - 65, Me.Width, 70), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        clickedd = False
    End Sub
#End Region
#Region "Properties & Events"
    Private WithEvents TB2 As TextBox
    Private WithEvents TB As New TextBox
    Private _BaseColour As Color = Color.FromArgb(236, 233, 234)
    Private _BorderColour As Color = Color.FromArgb(163, 190, 146)
    Private _LineColour As Color = Color.FromArgb(221, 221, 221)
    Private _TextColour As Color = Color.FromArgb(149, 147, 148)
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength As Integer = 32767
    Private _ReadOnly As Boolean
    Private _UseSystemPasswordChar As Boolean
    Private _Text As String = "Username"
    Private _Text2 As String = "Password"
    Private _BaseColour2 As Color = Color.FromArgb(218, 213, 211)
    Private _BorderColour2 As Color = Color.FromArgb(163, 190, 146)
    Private _LineColour2 As Color = Color.FromArgb(221, 221, 221)
    Private _TextColour2 As Color = Color.FromArgb(149, 147, 148)
    Private _TextAlign2 As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength2 As Integer = 32767
    Private _ReadOnly2 As Boolean
    Private _UseSystemPasswordChar2 As Boolean
    Private _Multiline As Boolean
    Public Sub SelectAll()
        TB.Focus()
        TB.SelectAll()
        Invalidate()
    End Sub

    <Category("Username")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Username")>
  Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Username")>
    Public Property LineColour As Color
        Get
            Return _LineColour
        End Get
        Set(value As Color)
            _LineColour = value
        End Set
    End Property

    <Category("Username")>
     Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
        End Set
    End Property

  

    <Category("Username")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property

    <Category("Username")>
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property

    <Category("Username")>
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Username")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    <Category("Username")>
    Property Textt As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property

  
    'Password
    <Category("Password")>
    Property Text2 As String
        Get
            Return _Text2
        End Get
        Set(ByVal value As String)
            _Text = value
            If TB2 IsNot Nothing Then
                TB2.Text = value
            End If
        End Set
    End Property
    <Category("Password")>
    Public Property BaseColour2 As Color
        Get
            Return _BaseColour2
        End Get
        Set(value As Color)
            _BaseColour2 = value
        End Set
    End Property

    <Category("Password")>
    Public Property BorderColour2 As Color
        Get
            Return _BorderColour2
        End Get
        Set(value As Color)
            _BorderColour2 = value
        End Set
    End Property

    <Category("Password")>
    Public Property LineColour2 As Color
        Get
            Return _LineColour2
        End Get
        Set(value As Color)
            _LineColour2 = value
        End Set
    End Property

    <Category("Password")>
    Public Property TextColour2 As Color
        Get
            Return _TextColour2
        End Get
        Set(value As Color)
            _TextColour2 = value
        End Set
    End Property



    <Category("Password")>
    Property TextAlign2() As HorizontalAlignment
        Get
            Return _TextAlign2
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB2 IsNot Nothing Then
                TB2.TextAlign = value
            End If
        End Set
    End Property

    <Category("Password")>
    Property MaxLength2() As Integer
        Get
            Return _MaxLength2
        End Get
        Set(ByVal value As Integer)
            _MaxLength2 = value
            If TB2 IsNot Nothing Then
                TB2.MaxLength = value
            End If
        End Set
    End Property

    <Category("Password")>
    Property [ReadOnly2]() As Boolean
        Get
            Return _ReadOnly2
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly2 = value
            If TB2 IsNot Nothing Then
                TB2.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Password")>
    Property UseSystemPasswordChar2() As Boolean
        Get
            Return _UseSystemPasswordChar2
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar2 = value
            If TB2 IsNot Nothing Then
                TB2.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    <Category("Password")>
    Overrides Property Text As String
        Get
            Return _Text2
        End Get
        Set(ByVal value As String)
            _Text2 = value
            If TB2 IsNot Nothing Then
                TB2.Text = value
            End If
        End Set
    End Property

    <Category("Control")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB2 IsNot Nothing Then
                TB2.Font = value
                TB2.Location = New Point(3, 5)
                TB2.Width = Width - 6
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6
                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property


    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        _Text = TB.Text
        _Text2 = TB2.Text
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)

        TB.Location = New Point(20, 20)
        TB.Width = Width - 10
        'TB2.Location = New Point(85, 85)
        'TB2.Width = Width - 10

        MyBase.OnResize(e)
    End Sub

#End Region
#Region "ThemeDraggable"
    Dim clickedd As Boolean = False
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If New Rectangle(0, 0, Me.Width, Me.Height).Contains(mouseX, mouseY) Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RaiseEvent Clicked()
                clickedd = True
            End If
        End If
        '
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y
        If New Rectangle(0, Me.Height - 70, Me.Width, 70).Contains(mouseX, mouseY) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Arrow
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
End Class
#End Region
'All credits go to there rightful owners :P - Nettro