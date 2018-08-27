Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.IO
'|||||||||||||||||||||||||||||||||||||
'||Origin Theme|||||||||||||||||||||||
'||Made by Nettro|||||||||||||||||||||
'||Date: Aug 09, 2014|||||||||||||||||
'|||||||||||||||||||||||||||||||||||||
Partial Class originForm
    Inherits UserControl
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        DoubleBuffered = True

    End Sub
    Private BottomMessage As String = "Create an account "
    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        FindForm().FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.FromArgb(45, 45, 45)
        FindForm.TransparencyKey = Color.FromArgb(45, 45, 45)

        MyBase.OnHandleCreated(e)
    End Sub
    <PropertyTab("BottomMessage")> _
    <DisplayName("BottomMessage")> _
    Public Property BM() As String
        Get
            Return BottomMessage
        End Get
        Set(value As String)
            BottomMessage = value
        End Set
    End Property
    '\/Edit Default Image here, or insert your own Image through MyProject Resources
    Private IconImage As Bitmap = My.Resources.logo_origin_transparent
    Private IconShow As Boolean = True
    Private Smooth As Boolean = True
    Private ImageLocX As Integer = 55
    Private ImageLocY As Integer = 55
    Private ImageSizeX As Integer = 143
    Private ImageSizeY As Integer = 48

    <PropertyTab("IconShow")> _
 <DisplayName("IconShow")> _
    Public Property Icons() As Boolean
        Get
            Return IconShow
        End Get
        Set(value As Boolean)
            IconShow = value
        End Set
    End Property
    <PropertyTab("IconImage")> _
    <DisplayName("IconImage")> _
    Public Property ImageIcon() As Bitmap
        Get
            Return IconImage
        End Get
        Set(value As Bitmap)
            IconImage = value
        End Set
    End Property
    <PropertyTab("ImageLocX")> _
   <DisplayName("ImageLocX")> _
    Public Property ImageLocX2() As Integer
        Get
            Return ImageLocX
        End Get
        Set(value As Integer)
            ImageLocX = value
        End Set
    End Property
    <PropertyTab("ImageLocY")> _
  <DisplayName("ImageLocY")> _
    Public Property ImageLocY2() As Integer
        Get
            Return ImageLocY
        End Get
        Set(value As Integer)
            ImageLocY = value
        End Set
    End Property
    <PropertyTab("ImageWidth")> _
  <DisplayName("ImageWidth")> _
    Public Property ImageWidth2() As Integer
        Get
            Return ImageSizeX
        End Get
        Set(value As Integer)
            ImageSizeX = value
        End Set
    End Property
    <PropertyTab("ImageHeight")> _
  <DisplayName("ImageHeight")> _
    Public Property ImageHeight2() As Integer
        Get
            Return ImageSizeY
        End Get
        Set(value As Integer)
            ImageSizeY = value
        End Set
    End Property
    <PropertyTab("Smoothing")> _
 <DisplayName("Smoothing")> _
    Public Property SmoothEdges() As Boolean
        Get
            Return Smooth
        End Get
        Set(value As Boolean)
            Smooth = value
        End Set
    End Property


    Private PT1, PT2 As PointF
    Private SZ1, SZ2 As SizeF
    Dim X, Y As Integer
    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        Dim bm As New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        Dim g2 As Graphics = Graphics.FromImage(bm)
        Me.Padding = New Padding(13, 39, 13, 24)
        Dim rect As New Rectangle(0, 0, Me.Width, (Me.Height - 35))
        Dim brush As New LinearGradientBrush(rect, Color.FromArgb(250, 250, 250), Color.FromArgb(206, 206, 206), 90.0!)
        'Begin

        'Main Form
        If Smooth = True Then
            g.SmoothingMode = SmoothingMode.HighQuality
        End If
        Dim rect2 As New Rectangle(0, 0, Me.Width, (Me.Height - 35))
        Dim Path As GraphicsPath = RoundRec(0, 0, Width, Height - 35, 24)
        g.FillPath(New LinearGradientBrush(rect2, Color.FromArgb(250, 250, 250), Color.FromArgb(206, 206, 206), 90.0!), Path)
        If IconShow = True Then
            g.DrawImage(IconImage, New Rectangle(ImageLocX, ImageLocY, ImageSizeX, ImageSizeY))
        End If
        '  g.DrawPath(New Pen(Color.Black), Path)

        ' e.Graphics.FillRectangle(brush, brush.Rectangle)

        'Blend Ends
        rect = New Rectangle(0, (Me.Height - 55), Me.Width, 55)
        brush = New LinearGradientBrush(rect, Color.FromArgb(206, 206, 206), Color.FromArgb(206, 206, 206), 90.0!)
        g.FillRectangle(brush, brush.Rectangle)
        'Seprator 1
        rect = New Rectangle(0, (Me.Height - 40), Me.Width, 40)
        brush = New LinearGradientBrush(rect, Color.FromArgb(190, 190, 190), Color.FromArgb(190, 190, 190), 90.0!)
        g.FillRectangle(brush, brush.Rectangle)
        ' White Seprator
        rect = New Rectangle(0, (Me.Height - 38), Me.Width, 38)
        brush = New LinearGradientBrush(rect, Color.FromArgb(227, 227, 227), Color.FromArgb(227, 227, 227), 90.0!)
        g.FillRectangle(brush, brush.Rectangle)
        'Seprator 2
        rect = New Rectangle(0, (Me.Height - 37), Me.Width, 37)
        brush = New LinearGradientBrush(rect, Color.FromArgb(190, 190, 190), Color.FromArgb(190, 190, 190), 90.0!)
        g.FillRectangle(brush, brush.Rectangle)
        'Bottom Part
        rect = New Rectangle(0, (Me.Height - 32), Me.Width, 32)
        brush = New LinearGradientBrush(rect, Color.FromArgb(195, 195, 195), Color.FromArgb(195, 195, 195), 90.0!)
        g.FillRectangle(brush, brush.Rectangle)
        'Button Text
        g.DrawString(BottomMessage, New Font("Arial", 8, FontStyle.Bold), New SolidBrush(Color.FromArgb(45, 45, 45)), rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        'Close Button ~ By Mava
        If New Rectangle(Width - 22, 5, 15, 15).Contains(New Point(X, Y)) Then
            g.SmoothingMode = SmoothingMode.HighQuality
            g.FillEllipse(New SolidBrush(Color.FromArgb(95, 95, 95)), New Rectangle(Width - 24, 6, 16, 16))
            g.DrawString("r", New Font("Webdings", 8), New SolidBrush(Color.FromArgb(250, 250, 250)), New Point(Width - 23, 5))
        Else
            g.SmoothingMode = SmoothingMode.HighQuality
            g.FillEllipse(New SolidBrush(Color.FromArgb(85, 85, 85)), New Rectangle(Width - 24, 6, 16, 16))
            g.DrawString("r", New Font("Webdings", 8), New SolidBrush(Color.FromArgb(250, 250, 250)), New Point(Width - 23, 5))
        End If

        'End
        e.Graphics.DrawImage(DirectCast(bm.Clone(), Bitmap), 0, 0)
        g.Dispose()
        bm.Dispose()
        MyBase.OnPaint(e)
       
    End Sub

    
    Public Function RoundRec(ByVal X As Integer, ByVal Y As Integer, _
     ByVal Width As Integer, ByVal Height As Integer, ByVal diameter As Integer) As System.Drawing.Drawing2D.GraphicsPath

        ''the 'diameter' pwwwsarameter changes the size of the rounded region

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
        Y + CInt(diameter / 2 + 30), X + Width, _
                         Y + Height - CInt(diameter / 2 + 30))

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
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width, 30)
        If dragRect.Contains(New Point(e.X, e.Y)) Then
            isDragging = True
            savePoint = New Point(e.X, e.Y)
        End If
        Dim clickRect As New Rectangle(Me.Width - 24, 10, 13, 12)
        If clickRect.Contains(New Point(e.X, e.Y)) Then
            Environment.[Exit](0)
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
        If New Rectangle(Width - 22, 5, 15, 15).Contains(New Point(X, Y)) Then
            FindForm.Close()
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
Partial Public Class NotifactionMSG
    Inherits Panel
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
    End Sub
    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
    End Sub
    Private NoteMsg As String = "An unknown error has occurred. Please restart Origin and try again."
    Private NoteFont As Font = New Font("Arial", 11, FontStyle.Bold)
    <PropertyTab("NoteFont")> _
 <DisplayName("NoteFont")> _
    Public Property NM() As Font
        Get
            Return NoteFont
        End Get
        Set(value As Font)
            NoteFont = value
        End Set
    End Property
    <PropertyTab("NoteMessage")> _
<DisplayName("NoteMessage")> _
    Public Property NF() As String
        Get
            Return NoteMsg
        End Get
        Set(value As String)
            NoteMsg = value
        End Set
    End Property
    Enum Style
        _Error
        _Notice
    End Enum

    Private _Style As Style
    Public Property AlertStyle As Style
        Get
            Return _Style
        End Get
        Set(ByVal value As Style)
            _Style = value
            Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        Dim bm As New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        Dim g2 As Graphics = Graphics.FromImage(bm)
        Me.Padding = New Padding(13, 39, 13, 24)
        Dim rect As New Rectangle(0, 0, Me.Width, (Me.Height - 35))
        Dim brush As New LinearGradientBrush(rect, Color.FromArgb(250, 250, 250), Color.FromArgb(206, 206, 206), 90.0!)
        'Begin
        If Me.Height Or Me.Width >= 30 Then

            Select Case _Style
                Case Style._Error
                    g.SmoothingMode = SmoothingMode.HighQuality
                    g.DrawRectangle(New Pen(Color.FromArgb(223, 66, 32)), New Rectangle(0, 0, Me.Width, Me.Height))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(223, 66, 32)), New Rectangle(0, 0, Me.Width, Me.Height))
                    g.DrawImage(Base64ToImage("iVBORw0KGgoAAAANSUhEUgAAACwAAAAsCAYAAAAehFoBAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIJSURBVFhH7Zg9S8RAEED9KddoYWthoxxaKAqKCoocaiFYiApaCZbaXit2thb+Af+DpVhZeNzpiaIoWIjVei8YCMfsZj8SZDGBB0eymXmEzczkBu4nayomKuGyqYTLphIum/8l3JoeUu2lEfWwXlePWzOqu7uonvZXEvjNOa6xhrVSDFe8hFuzw6rTGFPd7Xn1dLBqBWu5h3ulmLY4C7eXR3vJ50QpG7iXGFJsG6yFW1ODqrNWFyV8IBYxpVwmrIQJ/LAxISYOgZiu0lbCRT7Zfogt5dSRK8x+kxIVicueNgrzRrtUgpeTPfV5dZnwdnosrpEgh231MApThqQEOpBMD6SlNTo6jXHRoR+tMIXe5elCiHB3Z8GquWiF6U5SYBMhwkBOySWLVpiWKgU1ESpMTskli1aYOUAKauL5aPNXV6n386a4xgQ5JZcsWuFkkBGC5pEeLlUihZySSxatcDJ1CUHzSA8fYXJKLlkKF/6+u02EpWu5hAj7bokQ4aAt4fPSwdfNtbdw0EvnU9aA9vzaPBSv5RFU1nwaB6JsCfi4OBPXmAhqHNG1Zohq+AHX8dKXwsZLiGqAT4nqEwmi+wgFAhf5pInlKgvWwinstyj+SMnCG00ZonZKUhKs5R7baqDDSziFQk93oqUyByQDE1NeD35zjmussWkKNgQJ/wWVcNlUwmUTmXBN/QCoe2Fr5J6flQAAAABJRU5ErkJggg=="), New Rectangle(Me.Width / 4 - 65, Me.Height / 2 - 22, 44, 44))
                    g.DrawString(NoteMsg, NoteFont, New SolidBrush(Color.FromArgb(250, 250, 250)), New Rectangle(Me.Width / 4 - 10, Me.Height / 2 - 40, 220, 80), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case Style._Notice
                    g.SmoothingMode = SmoothingMode.HighQuality
                    g.DrawRectangle(New Pen(Color.FromArgb(38, 157, 207)), New Rectangle(0, 0, Me.Width, Me.Height))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(38, 157, 207)), New Rectangle(0, 0, Me.Width, Me.Height))
                    g.DrawImage(Base64ToImage("iVBORw0KGgoAAAANSUhEUgAAACwAAAAsCAYAAAAehFoBAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAH/SURBVFhH7ZjPKwVRFMf9NTaUtbIhLC2IDXtra2t7ayUsJA8JsbCxsLGgR7yX915Kkli8nWyvPi+3NH3nx713Jk1m6lOvmTvnfJrunHPm9fWv102ZqISLphIumv8jPLh5a4a3783EXtNMHT6auZO2mT/t9OA357jGGtaqGD44Cw9t3ZnR3YaZOWqZhbNOJljLPdyrYrrgJDyy82CmHUSjcC8xVOysZBIe2Lg147WmlPCBWMRUudJIFSbw5H5+shZi+kinCuf5ZKMQW+VMIlGY/aYS5Ynrno4V5o12qQRLF8/moN3tsXL1KtcoyOFSPWKFKUMqQRxI2gNptSaOsVpDOiikMIXe5elCiPDscStzc5HCdCcVOIkQYSCncokihWmpKmgSocLkVC5RpDBzgAqaxOL504+uMas3b3JNEuRULlGkMMOLCpqGPVyqhIWcyiWKFGbiUkHTsIePMDmVS5RchZvdr56wupZGkLDvlggRDtoSPi8dXL9/egsHvXQ+ZQ1oz8uXL/JaGkFlzadxIMqWgLW7D7kmiaDGUbrWDKUafsB1vPQlt/ESSjXAW0r1iQSl+wgFAuf5pInlIwuZhC3st1L8kfIb3mjKELVTSSlYyz0u1SAOZ2ELhZ7uREtlDmB4YeICfnOOa6zJ2hSy4C38V1TCRVMJF00lXDQlE66bb+YGhyafMUw8AAAAAElFTkSuQmCC"), New Rectangle(Me.Width / 4 - 65, Me.Height / 2 - 22, 44, 44))
                    g.DrawString(NoteMsg, NoteFont, New SolidBrush(Color.FromArgb(250, 250, 250)), New Rectangle(Me.Width / 4 - 10, Me.Height / 2 - 40, 220, 80), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End Select
        End If
        'end 
        e.Graphics.DrawImage(DirectCast(bm.Clone(), Bitmap), 0, 0)
        g.Dispose()
        bm.Dispose()
        MyBase.OnPaint(e)
    End Sub
    Public Function Base64ToImage(base64String As String) As Image
        'I did not write this Function
        ' Convert Base64 String to byte[]
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)

        ' Convert byte[] to Image
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim image__1 As Image = Image.FromStream(ms, True)
        Return image__1
    End Function
End Class