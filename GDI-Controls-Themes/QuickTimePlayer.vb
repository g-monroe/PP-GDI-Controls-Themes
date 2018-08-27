Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
<DefaultEvent("CheckedChanged")> Class YouToggle : Inherits Panel

    Public onoff As Boolean = False
    Public Event CheckedChanged(ByVal sender As Object)
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        Me.Size = New Size(44, 18)
    End Sub

    <PropertyTab("Onoff")> _
 <DisplayName("Onoff")> _
    Public Property Icons() As Boolean
        Get
            Return onoff
        End Get
        Set(value As Boolean)
            onoff = value
        End Set
    End Property
    Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim bm As New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        ' Me.Padding = New Padding(13, 39, 13, 24)
        '  Dim rect As New Rectangle(0, 0, Me.Width, (Me.Height - 35))
        ' Dim brush As New LinearGradientBrush(rect, Color.FromArgb(250, 250, 250), Color.FromArgb(206, 206, 206), 90.0!)
        'Begin
        If onoff = True Then
            Dim Path As GraphicsPath = RoundRec(0, 0, Width - 2, Height - 2, 14)
            g.SmoothingMode = SmoothingMode.HighQuality
            g.FillPath(New SolidBrush(Color.FromArgb(22, 122, 198)), Path)
            g.DrawPath(New Pen(Color.FromArgb(22, 122, 198)), Path)
            g.DrawEllipse(New Pen(Color.FromArgb(255, 255, 255)), New Rectangle(Width - 17, Me.Height - 17, 14, 14))
            g.FillEllipse(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(Width - 17, Me.Height - 17, 14, 14))
            g.DrawString("ü", New Font("Wingdings", 14), New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(0 + 7, Me.Height - 19, 14, 14), NearSF)
        Else
            Dim Path As GraphicsPath = RoundRec(0, 0, Width - 2, Height - 2, 14)
            g.SmoothingMode = SmoothingMode.HighQuality
            g.FillPath(New SolidBrush(Color.FromArgb(184, 184, 184)), Path)
            g.DrawPath(New Pen(Color.FromArgb(184, 184, 184)), Path)
            g.DrawEllipse(New Pen(Color.FromArgb(255, 255, 255)), New Rectangle(0 + 1, Me.Height - 17, 14, 14))
            g.FillEllipse(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(0 + 1, Me.Height - 17, 14, 14))
        End If
        'end
        e.Graphics.DrawImage(DirectCast(bm.Clone(), Bitmap), 0, 0)
        g.Dispose()
        bm.Dispose()
        MyBase.OnPaint(e)
    End Sub
    Dim x, y As Integer
    Private _Checked As Boolean = False
#Region " Options"

    <Category("Options")> _
    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
        End Set
    End Property

#End Region
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        Dim clickRect2 As New Rectangle(0 + 1, Me.Height - 17, 14, 14)
        If onoff = False Then
            If clickRect2.Contains(New Point(e.X, e.Y)) Then
                onoff = True
                RaiseEvent CheckedChanged(Me)
            End If
        End If
        Dim clickRect3 As New Rectangle(Width - 17, Me.Height - 17, 14, 14)
        If onoff = True Then
            If clickRect3.Contains(New Point(e.X, e.Y)) Then
                onoff = False
                RaiseEvent CheckedChanged(Me)
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
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub
#End Region
    Private Sub Theme_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
    Public Function RoundRec(ByVal X As Integer, ByVal Y As Integer, _
       ByVal Width As Integer, ByVal Height As Integer, ByVal diameter As Integer) As System.Drawing.Drawing2D.GraphicsPath

        ''the 'diameter' parameter changes the size of the rounded region

        Dim graphics_path As New System.Drawing.Drawing2D.GraphicsPath

        Dim BaseRect As New RectangleF(X, Y, Width, Height)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(diameter, diameter))

        'top left Arc
        graphics_path.AddArc(ArcRect, 180, 90)
        graphics_path.AddLine(X + CInt(diameter / 2), _
        Y, X + Width - CInt(diameter / 2), Y)

        ' top right arc
        ArcRect.X = BaseRect.Right - diameter
        graphics_path.AddArc(ArcRect, 270, 90)
        graphics_path.AddLine(X + Width, _
        Y + CInt(diameter / 2), X + Width, _
                         Y + Height - CInt(diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - diameter
        graphics_path.AddArc(ArcRect, 0, 90)
        graphics_path.AddLine(X + CInt(diameter / 2), _
        Y + Height, X + Width - CInt(diameter / 2), _
                         Y + Height)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        graphics_path.AddArc(ArcRect, 90, 90)
        graphics_path.AddLine(X, Y + CInt(diameter / 2), _
        X, Y + Height - CInt(diameter / 2))

        Return graphics_path

    End Function
End Class


<DefaultEvent("VolumeChanged2")> Class YouPLayer : Inherits Control

    Public Event VolumeChanged2(ByVal sender As Object)
    Private _Volume As Integer
    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle
    Private LastVolume As Integer
    Private pointdown As Point
    Private Speaker_Cone As Image
    Private Volume_Maximum As Image
    Private Volume_Medium As Image
    Private Volume_Mute As Image
    Private Volume_Silent As Image
    Private VolumeChangedEvent As VolumeChangedEventHandler
    Public Delegate Sub VolumeChangedEventHandler(ByVal Volume As Integer)




    Sub New()
        Me.Speaker_Cone = Me.CodeToImage("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")
        Me.Volume_Maximum = Me.CodeToImage("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")
        Me.Volume_Medium = Me.CodeToImage("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")
        Me.Volume_Silent = Me.CodeToImage("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")
        Me.Volume_Mute = Me.CodeToImage("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")
        Me.pointdown = New Point(-1, -1)
        Me.LastVolume = 100
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub
    Public Function CodeToImage(ByVal Code As String) As Image
        Return Image.FromStream(New MemoryStream(Convert.FromBase64String(Code)))
    End Function

    Public Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        Me.CreateRoundPath = New GraphicsPath(FillMode.Winding)
        Me.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0!, 90.0!)
        Me.CreateRoundPath.AddArc((r.Right - slope), r.Y, slope, slope, 270.0!, 90.0!)
        Me.CreateRoundPath.AddArc((r.Right - slope), (r.Bottom - slope), slope, slope, 0.0!, 90.0!)
        Me.CreateRoundPath.AddArc(r.X, (r.Bottom - slope), slope, slope, 90.0!, 90.0!)
        Me.CreateRoundPath.CloseFigure()
        Return Me.CreateRoundPath
    End Function

    Public Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        Me.CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return Me.CreateRound(Me.CreateRoundRectangle, slope)
    End Function

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Dim volumeChangedEvent As VolumeChangedEventHandler
        Me.pointdown = e.Location
        Dim rectangle As New Rectangle(&H2B, 10, (Me.Width - &H38), 7)
        Dim rectangle2 As Rectangle = rectangle
        If rectangle2.Contains(e.Location) Then
            Me.Volume = CInt(Math.Round(CDbl(((CDbl((e.Location.X - &H33)) / CDbl((Me.Width - &H47))) * 100))))
            volumeChangedEvent = Me.VolumeChangedEvent
            RaiseEvent VolumeChanged2(Me)
            If (Not volumeChangedEvent Is Nothing) Then
                volumeChangedEvent.Invoke(Me._Volume)
            End If
        End If
        rectangle2 = New Rectangle(10, 4, 20, 20)
        rectangle = rectangle2
        If rectangle.Contains(e.Location) Then
            If (Me._Volume <> 0) Then
                Me.LastVolume = Me._Volume
                Me._Volume = 0
                RaiseEvent VolumeChanged2(Me)
            Else
                Me._Volume = Me.LastVolume
                RaiseEvent VolumeChanged2(Me)
            End If
            volumeChangedEvent = Me.VolumeChangedEvent
            If (Not volumeChangedEvent Is Nothing) Then
                volumeChangedEvent.Invoke(Me._Volume)
            End If
            Me.Invalidate()
        End If
        MyBase.OnMouseDown(e)
    End Sub
 
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        Dim rectangle As New Rectangle(&H2B, 0, (Me.Width - &H38), 26)
        If ((e.Button = MouseButtons.Left) And rectangle.Contains(Me.pointdown)) Then
            Me.Volume = CInt(Math.Round(CDbl(((CDbl((e.Location.X - &H43)) / CDbl((Me.Width - &H47))) * 100))))
            Dim volumeChangedEvent As VolumeChangedEventHandler = Me.VolumeChangedEvent
            If (Not volumeChangedEvent Is Nothing) Then
                volumeChangedEvent.Invoke(Me._Volume)
                RaiseEvent VolumeChanged2(Me)
            End If
        End If
        MyBase.OnMouseMove(e)
    End Sub


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.Clear(Color.FromArgb(27, 28, 29))
        Dim rect As New Rectangle(10, 8, 12, 12)
        e.Graphics.DrawImage(Me.Speaker_Cone, rect)
        Dim num As Integer = Me._Volume
        If (num > 80) Then
            rect = New Rectangle(&H16, 4, 11, 20)
            e.Graphics.DrawImage(Me.Volume_Maximum, rect)
        ElseIf (num > 50) Then
            rect = New Rectangle(&H16, 4, 11, 20)
            e.Graphics.DrawImage(Me.Volume_Medium, rect)
        ElseIf (num > 0) Then
            rect = New Rectangle(&H16, 4, 11, 20)
            e.Graphics.DrawImage(Me.Volume_Silent, rect)
        Else
            rect = New Rectangle(&H17, 10, 7, 7)
            e.Graphics.DrawImage(Me.Volume_Mute, rect)
        End If
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim path2 As GraphicsPath = Me.CreateRound(&H2B, 10, (Me.Width - &H38), 7, 6)
        e.Graphics.FillPath(New SolidBrush(Color.FromArgb(30, 30, 30)), path2)
        e.Graphics.DrawPath(Pens.Black, path2)
        Dim path As GraphicsPath = Me.CreateRound(CInt(Math.Round(CDbl((43 + ((CDbl(Me._Volume) / 100) * (Me.Width - &H47)))))), 8, &H10, 11, 6)
        rect = New Rectangle(CInt(Math.Round(CDbl((43 + ((CDbl(Me._Volume) / 100) * (Me.Width - &H47)))))), 10, &H10, 7)
        Dim brush As New LinearGradientBrush(rect, Color.FromArgb(251, 83, 150), Color.FromArgb(225, 53, 126), 90.0!) 'Want Color.FromArgb(251, 83, 150), Color.FromArgb(225, 53, 126)
        e.Graphics.FillRectangle(brush, New Rectangle(43, 10, rect.X - 28, 7))
        e.Graphics.FillPath(brush, path)
        e.Graphics.DrawPath(New Pen(Color.FromArgb(100, Color.Black)), path)
        '  e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(221, 221, 221)), rect)
        'e.Graphics.FillRectangle(brush, New Rectangle(34, 10, rect.X - 28, 7))
        If VolStringOnOff = True Then
            e.Graphics.DrawString(VolString, New Font("Arial", 6, FontStyle.Regular), New SolidBrush(Color.FromArgb(255, 255, 255)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End If
               MyBase.OnPaint(e)
    End Sub
    Public VolString As String = "0"
    Public VolStringOnOff As Boolean = False
    <PropertyTab("Onoff")> _
 <DisplayName("Onoff")> _
    Public Property Onoff() As Boolean
        Get
            Return VolStringOnOff
        End Get
        Set(value As Boolean)
            VolStringOnOff = value
        End Set
    End Property
    <PropertyTab("Volumetext")> _
 <DisplayName("Volumetext")> _
    Public Property Icons() As String
        Get
            Return VolString
        End Get
        Set(value As String)
            VolString = value
        End Set
    End Property


    Public Property Volume As Integer
        Get
            Return Me._Volume
        End Get
        Set(ByVal value As Integer)
            If (value <= 100) Then
                Me._Volume = value
            Else
                Me._Volume = 100
            End If
            If (value < 0) Then
                Me._Volume = 0
            End If
            Me.Invalidate()
        End Set
    End Property











End Class
Partial Public Class ThemeContainer : Inherits Control
    Public Event DestinationChanged(ByVal sender As Object)
    Public Event PlaystateChanged(ByVal sender As Object)
    Public Event FastForward(ByVal sender As Object)
    Public Event Revious(ByVal sender As Object)
    Private _Volume As Integer
    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle
    Private LastVolume As Integer
    Private pointdown As Point
    Private Speaker_Cone As Image
    Private Volume_Maximum As Image
    Private Volume_Medium As Image
    Private Volume_Mute As Image
    Private Volume_Silent As Image
    Private VolumeChangedEvent As VolumeChangedEventHandler
    Public Delegate Sub VolumeChangedEventHandler(ByVal Volume As Integer)

    Public Maxnum As Integer = 100
    <PropertyTab("Maxnum")> _
 <DisplayName("Maxnum")> _
    Public Property Maxnumber() As Integer
        Get
            Return Maxnum
        End Get
        Set(value As Integer)
            Maxnum = value
        End Set
    End Property


    Sub New()
        Me.Speaker_Cone = Me.CodeToImage("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")
        Me.Volume_Maximum = Me.CodeToImage("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")
        Me.Volume_Medium = Me.CodeToImage("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")
        Me.Volume_Silent = Me.CodeToImage("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")
        Me.Volume_Mute = Me.CodeToImage("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")
        Me.pointdown = New Point(-1, -1)

        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub
    Public Function CodeToImage(ByVal Code As String) As Image
        Return Image.FromStream(New MemoryStream(Convert.FromBase64String(Code)))
    End Function
    Public Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        Me.CreateRoundPath = New GraphicsPath(FillMode.Winding)
        Me.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0!, 90.0!)
        Me.CreateRoundPath.AddArc((r.Right - slope), r.Y, slope, slope, 270.0!, 90.0!)
        Me.CreateRoundPath.AddArc((r.Right - slope), (r.Bottom - slope), slope, slope, 0.0!, 90.0!)
        Me.CreateRoundPath.AddArc(r.X, (r.Bottom - slope), slope, slope, 90.0!, 90.0!)
        Me.CreateRoundPath.CloseFigure()
        Return Me.CreateRoundPath
    End Function

    Public Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        Me.CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return Me.CreateRound(Me.CreateRoundRectangle, slope)
    End Function
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        ' Dim dragRect As New Rectangle(0, 0, Me.Width, 50)
        ' If dragRect.Contains(New Point(e.X, e.Y)) Then
        'isDragging = True
        '  savePoint = New Point(e.X, e.Y)
        '  End If
        '  Dim clickRect As New Rectangle(Width - 40, 10, 24, 24)
        '  If clickRect.Contains(New Point(e.X, e.Y)) Then
        'Environment.[Exit](0)
        '  End If
        Dim rect = New Rectangle(Me.Width / 2 - 40, Me.Height / 2 - 20, 40, 40)
        If rect.Contains(e.Location) Then
            PlayState2 = Not PlayState2
            RaiseEvent PlaystateChanged(Me)
            MyBase.OnMouseDown(e)
        End If
        rect = New Rectangle(Me.Width / 2 + 26, Me.Height / 2 - 15, 40, 40)
        If rect.Contains(e.Location) Then
            RaiseEvent FastForward(Me)
            MyBase.OnMouseDown(e)
        End If
        rect = New Rectangle(Me.Width / 2 - 83, Me.Height / 2 - 16, 40, 40)
        If rect.Contains(e.Location) Then
            RaiseEvent Revious(Me)
            MyBase.OnMouseDown(e)
        End If
        
        Dim volumeChangedEvent As VolumeChangedEventHandler
        Me.pointdown = e.Location
        Dim rectangle As New Rectangle(&H2B, 10, (Me.Width - &H38 - 30), 7)
        Dim rectangle2 As Rectangle = rectangle
        If rectangle2.Contains(e.Location) Then
            Me.Destination = CInt(Math.Round(CDbl(((CDbl((e.Location.X - &H33)) / CDbl((Me.Width - &H47))) * Maxnum))))
            volumeChangedEvent = Me.VolumeChangedEvent
            RaiseEvent DestinationChanged(Me)
            If (Not volumeChangedEvent Is Nothing) Then
                volumeChangedEvent.Invoke(Me._Volume)
            End If
        End If
        rectangle2 = New Rectangle(10, 4, 20, 20)
        rectangle = rectangle2
        If rectangle.Contains(e.Location) Then
            If (Me._Volume <> 0) Then
                Me.LastVolume = Me._Volume
                Me._Volume = 0
                RaiseEvent DestinationChanged(Me)
            Else
                Me._Volume = Me.LastVolume
                RaiseEvent DestinationChanged(Me)
            End If
            volumeChangedEvent = Me.VolumeChangedEvent
            If (Not volumeChangedEvent Is Nothing) Then
                volumeChangedEvent.Invoke(Me._Volume)
            End If
            Me.Invalidate()
        End If

        '
        MyBase.OnMouseDown(e)
    End Sub
    Dim x, y As integer
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        isDragging = False
        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y
        Dim rectangle As New Rectangle(&H2B, 0, (Me.Width - &H38 - 30), 26)
        If ((e.Button = MouseButtons.Left) And rectangle.Contains(Me.pointdown)) Then
            Me.Destination = CInt(Math.Round(CDbl(((CDbl((e.Location.X - &H33)) / CDbl((Me.Width - &H47))) * Maxnum))))
            Dim volumeChangedEvent As VolumeChangedEventHandler = Me.VolumeChangedEvent
            If (Not volumeChangedEvent Is Nothing) Then

            End If
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
    Protected Overridable Sub OnMouseDown2(ByVal e As MouseEventArgs)

     
    End Sub
    
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.Clear(Color.FromArgb(45, 45, 45))
        Dim rect As New Rectangle(10, 8, 12, 12)
        Me.LastVolume = Maxnum
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim path2 As GraphicsPath = Me.CreateRound(2, 2, Me.Width - 4, Me.Height - 4, 12)
        e.Graphics.FillPath(New SolidBrush(Color.FromArgb(30, 30, 30)), path2)
        e.Graphics.DrawPath(Pens.Black, path2)
        'inner grey border
        Dim path3 As GraphicsPath = Me.CreateRound(3, 3, Me.Width - 5, Me.Height - 5, 12)
        e.Graphics.FillPath(New SolidBrush(Color.FromArgb(30, 30, 30)), path2)
        e.Graphics.DrawPath(New Pen(Color.FromArgb(85, 85, 86)), path3)
        'Half Shape
        Dim rect2 = New Rectangle(4, 4, Me.Width - 7, Me.Height / 2 - 6)
        Dim brush As New LinearGradientBrush(rect2, Color.FromArgb(68, 68, 69), Color.FromArgb(42, 42, 44), 90.0!)
        Dim path4 As GraphicsPath = Me.CreateRound(4, 4, Me.Width - 7, Me.Height / 2 - 6, 12)
        e.Graphics.FillPath(brush, path4)
        Dim rect3 = New Rectangle(4, Me.Height / 2, Me.Width - 6, Me.Height / 2 - 6)
        Dim brush3 As New LinearGradientBrush(rect2, Color.FromArgb(32, 32, 34), Color.FromArgb(22, 23, 23), 90.0!)
        Dim path5 As GraphicsPath = Me.CreateRound(4, Me.Height / 2 + 6, Me.Width - 6, Me.Height / 2 - 20, 12)
        e.Graphics.FillPath(brush3, path5)
        ' e.Graphics.DrawImage(Me.Speaker_Cone, rect)
        Dim num As Integer = Me._Volume
        rect = New Rectangle(&H8, 6, 100, 20)

        e.Graphics.DrawString(VolString, New Font("Arial", 8, FontStyle.Regular), New SolidBrush(Color.FromArgb(255, 255, 255)), rect)
        rect = New Rectangle(Me.Width - &H23, 6, 100, 20)
        e.Graphics.DrawString(VolString2, New Font("Arial", 8, FontStyle.Regular), New SolidBrush(Color.FromArgb(255, 255, 255)), rect)

        'If (num > 80) Then
        '    rect = New Rectangle(&H16, 4, 11, 20)
        '    e.Graphics.DrawImage(Me.Volume_Maximum, rect)
        'ElseIf (num > 50) Then
        '    rect = New Rectangle(&H16, 4, 11, 20)
        '    e.Graphics.DrawImage(Me.Volume_Medium, rect)
        'ElseIf (num > 0) Then
        '    rect = New Rectangle(&H16, 4, 11, 20)
        '    e.Graphics.DrawImage(Me.Volume_Silent, rect)
        'Else
        '    rect = New Rectangle(&H17, 10, 7, 7)
        '    e.Graphics.DrawImage(Me.Volume_Mute, rect)
        'End If
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim path6 As GraphicsPath = Me.CreateRound(&H2B, 10, (Me.Width - &H38 - 30), 7, 6)
        'e.Graphics.FillPath(New SolidBrush(Color.FromArgb(30, 30, 30)), path2)
        e.Graphics.DrawPath(Pens.Black, path6)
        Dim path As GraphicsPath = Me.CreateRound(CInt(Math.Round(CDbl((43 + ((CDbl(Me._Volume) / Maxnum) * (Me.Width - &H67)))))), 10, &H10, 7, 6)
        rect = New Rectangle(CInt(Math.Round(CDbl((47 + ((CDbl(Me._Volume) / Maxnum) * (Me.Width - &H47)))))), 0, &H10, 26) ' 7 ' 10
        Dim brush4 As New LinearGradientBrush(rect, Color.FromArgb(251, 83, 150), Color.FromArgb(225, 53, 126), 90.0!) 'Want Color.FromArgb(251, 83, 150), Color.FromArgb(225, 53, 126
        e.Graphics.FillPath(brush4, path)
        e.Graphics.DrawPath(New Pen(Color.FromArgb(100, Color.Black)), path)
        ' e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(185, 31, 31)), New Rectangle(34, 10, rect.X - 28, 7))
        'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(221, 221, 221)), rect)
        e.Graphics.DrawString("7", New Font("Webdings", 32, FontStyle.Regular), New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(Me.Width / 2 - 90, Me.Height / 2 - 20, 40, 40))
        e.Graphics.DrawString("8", New Font("Webdings", 32, FontStyle.Regular), New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(Me.Width / 2 + 16, Me.Height / 2 - 20, 50, 40))
        If PlayState2 = True Then
            e.Graphics.DrawString(";", New Font("Webdings", 32, FontStyle.Regular), New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(Me.Width / 2 - 40, Me.Height / 2 - 20, 40, 40))
            MyBase.OnPaint(e)
        Else
            e.Graphics.DrawString("4", New Font("Webdings", 32, FontStyle.Regular), New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(Me.Width / 2 - 40, Me.Height / 2 - 20, 40, 40))
            MyBase.OnPaint(e)
        End If
    End Sub
    Public VolString As String = "00:00"
    Public VolString2 As String = "00:00"
    Public PlayState2 As Boolean = False
    <PropertyTab("PlayState")> _
 <DisplayName("PlayState")> _
    Public Property Onoff() As Boolean
        Get
            Return PlayState2
        End Get
        Set(value As Boolean)
            PlayState2 = value
        End Set
    End Property
    <PropertyTab("Volumetext")> _
 <DisplayName("Volumetext")> _
    Public Property Icons() As String
        Get
            Return VolString
        End Get
        Set(value As String)
            VolString = value
        End Set
    End Property
    <PropertyTab("Volumetext2")> _
<DisplayName("Volumetext2")> _
    Public Property Icons2() As String
        Get
            Return VolString2
        End Get
        Set(value As String)
            VolString2 = value
        End Set
    End Property

    Public Property Destination As Integer
        Get
            Return Me._Volume
        End Get
        Set(ByVal value As Integer)
            If (value <= Maxnum) Then
                Me._Volume = value
            Else
                Me._Volume = Maxnum
            End If
            If (value < 0) Then
                Me._Volume = 0
            End If
            Me.Invalidate()
        End Set
    End Property




End Class