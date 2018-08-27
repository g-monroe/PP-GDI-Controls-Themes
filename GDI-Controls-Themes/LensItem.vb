Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.ComponentModel

Public Class Lens
    Inherits Control
#Region "Properties & Events"
    Property idleMainColor As Color = Color.FromArgb(60, 77, 99)
    Property idleOrbColor As Color = Color.FromArgb(40, 54, 73)
    Property hoverMainColor As Color = Color.FromArgb(231, 178, 79)
    Property selectedMainColor As Color = Color.FromArgb(217, 71, 71)
    Event StatusChanged(Type As Kind)
    Property Selected As Boolean = False
    Event SelectedChanged(Selected As Boolean)
    Property bckColor As Color = Color.FromArgb(50, 67, 91)
    Property img As String = "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"
    Property TextFont As Font = New Font("Arial", 11, FontStyle.Regular)
    Property TextColor As Color = Color.FromArgb(255, 255, 255)
    Property Slope As Integer = 24
    Property Type As Kind = Kind.Idle
    Enum Kind
        Idle
        Hover
        Selected
    End Enum
#End Region

    Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(150, 200)
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
    Public Function Base64ToImage(base64String As String) As Image
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim image__1 As Image = Image.FromStream(ms, True)
        Return image__1
    End Function
#Region "Mouse Events"
    Private Sub Lens_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If New Rectangle(0, 0, Me.Width - 1, Me.Height - 1).Contains(e.X, e.Y) Then
                Selected = Not Selected
                If Selected = True Then
                    Type = Kind.Selected
                Else
                    Type = Kind.Hover
                End If
                RaiseEvent SelectedChanged(Selected)
                Me.Refresh()
            End If
        End If
    End Sub
    Private Sub Lens_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        Cursor = Cursors.Arrow
        If Not Type = Kind.Selected Then
            Type = Kind.Idle
            RaiseEvent StatusChanged(Type)
            Me.Refresh()
        End If
    End Sub

    Private Sub Lens_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Cursor = Cursors.Hand
        If Not Type = Kind.Selected And New Rectangle(0, 0, Me.Width - 1, Me.Height - 1).Contains(e.X, e.Y) Then
            Type = Kind.Hover
            RaiseEvent StatusChanged(Type)
            Me.Refresh()
        End If
    End Sub
#End Region

    Private Sub Lens_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.FillPath(New SolidBrush(bckColor), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), Slope))
        If Type = Kind.Idle Then
            g.FillEllipse(New SolidBrush(idleOrbColor), New Rectangle(Me.Width - 20, 12, 10, 10))
            g.FillPath(New SolidBrush(idleMainColor), NTRound(New Rectangle(0, Me.Height - (Me.Height / 5), Me.Width - 1, Me.Height / 5), Slope))
            g.DrawString(Text, TextFont, New SolidBrush(TextColor), New Rectangle(5, Me.Height - (Me.Height / 5), Me.Width - 6, Me.Height / 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        ElseIf Type = Kind.Hover Then
            g.FillEllipse(New SolidBrush(hoverMainColor), New Rectangle(Me.Width - 20, 12, 10, 10))
            g.FillPath(New SolidBrush(hoverMainColor), NTRound(New Rectangle(0, Me.Height - (Me.Height / 5), Me.Width - 1, Me.Height / 5), Slope))
            g.DrawString(Text, TextFont, New SolidBrush(TextColor), New Rectangle(5, Me.Height - (Me.Height / 5), Me.Width - 6, Me.Height / 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        ElseIf Type = Kind.Selected Then
            g.FillEllipse(New SolidBrush(selectedMainColor), New Rectangle(Me.Width - 20, 12, 10, 10))
            g.DrawPath(New Pen(selectedMainColor), Round(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), Slope))
            g.FillPath(New SolidBrush(selectedMainColor), NTRound(New Rectangle(0, Me.Height - (Me.Height / 5), Me.Width - 1, Me.Height / 5), Slope))
            g.DrawString(Text, TextFont, New SolidBrush(TextColor), New Rectangle(5, Me.Height - (Me.Height / 5), Me.Width - 6, Me.Height / 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End If
        Try : g.DrawImage(Base64ToImage(img), New Rectangle(5, Me.Height / 5, Me.Width - 11, Me.Height / 2)) : Catch ex As Exception : End Try
    End Sub
End Class