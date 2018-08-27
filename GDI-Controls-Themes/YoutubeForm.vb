Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Public Class FormContainer
    Inherits Panel
    Property Logo As Image
    Sub New()
        Me.Dock = DockStyle.Fill
        Me.DoubleBuffered = True
        Me.Padding = New Padding(2, 30, 2, 2)
        SetStyle(139270, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)

        Font = New Font("Verdana", 8S)

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

    Private Sub FormContainer_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        resizeleft = False
        resizeright = False
        resizebot = False
    End Sub

    Private Sub FormContainer_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If New Rectangle(Me.Width - 45, -20, 40, 38).Contains(e.X, e.Y) Then
                Close = True
                Max = False
                Min = False
                Main.Close()

                Me.Cursor = Cursors.Arrow
                Me.Refresh()
            ElseIf New Rectangle(Me.Width - 75, -20, 30, 38).Contains(e.X, e.Y) Then
                'If Max = True Then
                '    Main.WindowState = FormWindowState.Normal
                '    Max = False
                'Else
                '    Main.WindowState = FormWindowState.Maximized
                '    Max = True
                'End If
                Main.WindowState = FormWindowState.Minimized
                Close = False
                MinHover = False
                Min = False
                Me.Cursor = Cursors.Arrow
                Me.Refresh()
            ElseIf New Rectangle(Me.Width - 105, -20, 30, 38).Contains(e.X, e.Y) Then
                Max = False
                Close = False
                Min = True
                'Main.WindowState = FormWindowState.Minimized
                Me.Cursor = Cursors.Arrow
                Me.Refresh()
            ElseIf Not New Rectangle(Me.Width - 45, -20, 40, 38).Contains(e.X, e.Y) And Not New Rectangle(Me.Width - 105, -20, 30, 38).Contains(e.X, e.Y) And Not New Rectangle(Me.Width - 75, -20, 30, 38).Contains(e.X, e.Y) And New Rectangle(2, 1, Me.Width - 4, 49).Contains(e.X, e.Y) Then
                moving = True
                movelocclick = e.Location
                Me.Cursor = Cursors.Arrow
                Me.Refresh()
                'ElseIf New Rectangle(Me.Width - 8, 1, 6, Me.Height - 1).Contains(e.X, e.Y) Then
                '    resizeright = True
                '    Cursor = Cursors.PanEast
                'ElseIf New Rectangle(0, 1, 3, Me.Height - 1).Contains(e.X, e.Y) Then
                '    resizeleft = True
                '    resizeright = False
                '    Cursor = Cursors.PanWest
            End If
      
        End If
    End Sub
    Dim moving As Boolean = False
    Dim movelocclick As Point
    Dim resizeleft As Boolean = False
    Dim resizetop As Boolean = False
    Dim resizeright As Boolean = False
    Dim resizebot As Boolean = False
    Dim CloseHover As Boolean = False
    Dim Close As Boolean = False
    Dim MaxHover As Boolean = False
    Dim Max As Boolean = False
    Dim MinHover As Boolean = False
    Dim Min As Boolean = False
    Dim Shadow As Boolean = False
    Private Sub FormContainer_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If New Rectangle(Me.Width - 45, -20, 40, 38).Contains(e.X, e.Y) Then
            CloseHover = True
            MaxHover = False
            MinHover = False
            Me.Cursor = Cursors.Hand
            Me.Refresh()
        ElseIf New Rectangle(Me.Width - 75, -20, 30, 38).Contains(e.X, e.Y) Then
            MaxHover = False
            CloseHover = False
            MinHover = True
            Me.Cursor = Cursors.Hand
            Me.Refresh()
        ElseIf New Rectangle(Me.Width - 105, -20, 30, 38).Contains(e.X, e.Y) Then
            MaxHover = False
            CloseHover = False
            MinHover = False
            Me.Cursor = Cursors.Hand
            Me.Refresh()
        ElseIf Not New Rectangle(Me.Width - 45, -20, 40, 38).Contains(e.X, e.Y) Or Not New Rectangle(Me.Width - 105, -20, 30, 38).Contains(e.X, e.Y) Or Not New Rectangle(Me.Width - 75, -20, 30, 38).Contains(e.X, e.Y) And New Rectangle(2, 1, Me.Width - 4, 49).Contains(e.X, e.Y) Then
            CloseHover = False
            MaxHover = False
            MinHover = False
            Me.Cursor = Cursors.Arrow
            Me.Refresh()
        End If
        If moving = True Then
            Parent.Location = MousePosition - CType(movelocclick, Size)
        End If

        If resizeright Then
            Cursor = Cursors.PanEast
            If Parent.Width > 140 Or Parent.Width = 139 Then
                Parent.Width = (MousePosition.X - Parent.Location.X)
                'Parent.Location = MousePosition - CType(New Point(Parent.Location.X - 1, Parent.Location.Y), Size)

            End If
        End If
        If resizeleft Then
            Cursor = Cursors.PanWest
            Parent.Location = New Point(MousePosition.X, Parent.Location.Y)
            Parent.Width = (MousePosition.X + Parent.Location.X)
        End If
    End Sub
    Private Declare Function GetCursorPos Lib "user32" (lpPoint As Point) As Point


    Private Sub FormContainer_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        moving = False
        resizeleft = False
    End Sub


    Private Sub FormContainer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.Clear(Color.FromArgb(255, 84, 84, 84))
        'g.DrawRectangle(New Pen(Color.FromArgb(255, 50, 50, 50)), New Rectangle(1, 1, Me.Width - 3, Me.Height - 3))
        'g.DrawRectangle(New Pen(Color.FromArgb(255, 81, 81, 81)), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
        g.FillRectangle(New SolidBrush(Color.FromArgb(255, 51, 51, 51)), New Rectangle(0, 0, Me.Width - 1, 29)) 'New Rectangle(2, 1, Me.Width - 4, 29)
        g.DrawLine(New Pen(Color.FromArgb(255, 70, 70, 70)), New Point(1, 29), New Point(Me.Width - 3, 29))
        g.DrawLine(New Pen(Color.FromArgb(255, 34, 34, 34)), New Point(1, 30), New Point(Me.Width - 3, 30))
        Dim lgbShadow = New LinearGradientBrush(New Rectangle(1, 31, Me.Width - 3, 10), Color.FromArgb(120, Color.Black), Color.Transparent, 90.0!)
        g.FillRectangle(lgbShadow, New Rectangle(1, 30, Me.Width - 3, 10))
        'Try : g.DrawImage(Logo, New Rectangle(5, 2, 24, 24)) : Catch ex As Exception : End Try
        g.FillPath(New SolidBrush(Color.FromArgb(146, 50, 42)), Round(New Rectangle(30, 3, 53, 21), 10))
        g.DrawString("You  Stream", New Font("Arial", 9, FontStyle.Bold), New SolidBrush(Color.FromArgb(248, 248, 248)), New Rectangle(5, 6, Me.Width / 3, 35), New StringFormat With {.LineAlignment = StringAlignment.Near, .Alignment = StringAlignment.Near})

        'No Hover/Click Min
        If MinHover = True Then
            lgbShadow = New LinearGradientBrush(New Rectangle(Me.Width - 75, -20, 40, 38), Color.FromArgb(255, 51, 51, 51), Color.FromArgb(151, 151, 71), 270.0!) '205, 151, 71, 71
        Else
            lgbShadow = New LinearGradientBrush(New Rectangle(Me.Width - 75, -20, 40, 38), Color.FromArgb(255, 51, 51, 51), Color.FromArgb(205, 71, 71, 71), 270.0!) '205, 151, 71, 71
        End If
        g.FillPath(lgbShadow, Round(New Rectangle(Me.Width - 75, -20, 40, 38), 10))
        g.DrawPath(New Pen(Color.FromArgb(255, 81, 81, 81)), Round(New Rectangle(Me.Width - 75, -19, 40, 38), 10))
        g.DrawPath(New Pen(Color.FromArgb(255, 31, 31, 31)), Round(New Rectangle(Me.Width - 75, -20, 40, 38), 10))
        'g.FillRectangle(New SolidBrush(Color.FromArgb(34, 34, 34)), New Rectangle(Me.Width - 65, 10, 12, 3))
        g.SmoothingMode = SmoothingMode.HighSpeed
        g.FillRectangle(New SolidBrush(Color.FromArgb(79, 79, 79)), New Rectangle(Me.Width - 65, 10, 12, 2))
        g.SmoothingMode = SmoothingMode.AntiAlias
        ''No Hover/Click Max
        'If MaxHover = True Then
        '    lgbShadow = New LinearGradientBrush(New Rectangle(Me.Width - 75, -20, 40, 38), Color.FromArgb(255, 51, 51, 51), Color.FromArgb(155, 71, 151, 71), 270.0!) '155, 71, 151, 71
        'Else
        '    lgbShadow = New LinearGradientBrush(New Rectangle(Me.Width - 75, -20, 40, 38), Color.FromArgb(255, 51, 51, 51), Color.FromArgb(205, 71, 71, 71), 270.0!) '155, 71, 151, 71
        'End If
        'g.FillPath(lgbShadow, Round(New Rectangle(Me.Width - 75, -20, 40, 38), 10))
        'g.DrawPath(New Pen(Color.FromArgb(255, 81, 81, 81)), Round(New Rectangle(Me.Width - 75, -19, 40, 38), 10))
        'g.DrawPath(New Pen(Color.FromArgb(255, 31, 31, 31)), Round(New Rectangle(Me.Width - 75, -20, 40, 38), 10))
        'If Max = True Then
        '    'icon\/Shadow(34)
        '    g.DrawRectangle(New Pen(Color.FromArgb(34, 34, 34)), New Rectangle(Me.Width - 64, 6, 14, 10))
        '    g.DrawRectangle(New Pen(Color.FromArgb(78, 78, 78)), New Rectangle(Me.Width - 63, 7, 12, 8))
        '    g.FillRectangle(New SolidBrush(Color.FromArgb(34, 34, 34)), New Rectangle(Me.Width - 63, 7, 12, 3))
        '    g.FillRectangle(New SolidBrush(Color.FromArgb(78, 78, 78)), New Rectangle(Me.Width - 63, 7, 12, 2))
        '    'icon\/Shadow(34)
        '    g.DrawRectangle(New Pen(Color.FromArgb(34, 34, 34)), New Rectangle(Me.Width - 67, 4, 14, 10))
        '    g.DrawRectangle(New Pen(Color.FromArgb(78, 78, 78)), New Rectangle(Me.Width - 66, 5, 12, 8))
        '    g.FillRectangle(New SolidBrush(Color.FromArgb(34, 34, 34)), New Rectangle(Me.Width - 66, 5, 12, 3))
        '    g.FillRectangle(New SolidBrush(Color.FromArgb(78, 78, 78)), New Rectangle(Me.Width - 66, 5, 12, 2))
        'Else
        '    'icon\/Shadow(34)
        '    g.DrawRectangle(New Pen(Color.FromArgb(34, 34, 34)), New Rectangle(Me.Width - 67, 4, 14, 10))
        '    g.DrawRectangle(New Pen(Color.FromArgb(78, 78, 78)), New Rectangle(Me.Width - 66, 5, 12, 8))
        '    g.FillRectangle(New SolidBrush(Color.FromArgb(34, 34, 34)), New Rectangle(Me.Width - 66, 5, 12, 3))
        '    g.FillRectangle(New SolidBrush(Color.FromArgb(78, 78, 78)), New Rectangle(Me.Width - 66, 5, 12, 2))
        'End If
      

        'No Hover/Click (Close Button
        If CloseHover = True Then
            lgbShadow = New LinearGradientBrush(New Rectangle(Me.Width - 45, -20, 40, 38), Color.FromArgb(255, 51, 51, 51), Color.FromArgb(205, 151, 71, 71), 270.0!) '205, 151, 71, 71
        Else
            lgbShadow = New LinearGradientBrush(New Rectangle(Me.Width - 45, -20, 40, 38), Color.FromArgb(255, 51, 51, 51), Color.FromArgb(205, 71, 71, 71), 270.0!) '205, 151, 71, 71
        End If
        g.FillPath(lgbShadow, Round(New Rectangle(Me.Width - 45, -20, 40, 38), 10))
        g.DrawPath(New Pen(Color.FromArgb(255, 81, 81, 81)), Round(New Rectangle(Me.Width - 45, -19, 40, 38), 10))
        g.DrawPath(New Pen(Color.FromArgb(255, 31, 31, 31)), Round(New Rectangle(Me.Width - 45, -20, 40, 38), 10))
        'icon \/Shadow(34)
        'g.DrawLine(New Pen(Color.FromArgb(34, 34, 34)), New Point(Me.Width - 21, 5), New Point(Me.Width - 27, 12))
        'g.DrawLine(New Pen(Color.FromArgb(34, 34, 34)), New Point(Me.Width - 29, 5), New Point(Me.Width - 19, 12))

        g.DrawLine(New Pen(Color.FromArgb(89, 89, 89)), New Point(Me.Width - 20, 5), New Point(Me.Width - 28, 12))
        g.DrawLine(New Pen(Color.FromArgb(89, 89, 89)), New Point(Me.Width - 28, 5), New Point(Me.Width - 20, 12))

    End Sub

End Class