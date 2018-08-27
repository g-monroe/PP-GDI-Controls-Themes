
Imports System.Drawing.Drawing2D
Imports System.IO

Public Class Shelf_itemm
    Inherits PictureBox
#Region "Property"
    Property Kind As Type
    Property HD As Boolean = True
    Enum Type
        New_Release
        Popular
        Coming_Soon
        Custom
    End Enum
    Property MouseEntered As Boolean = False
    Property Custom_Border_Color As Color = Color.FromArgb(123, 123, 123)
    Property Custom_Inner_Border_Color As Color = Color.FromArgb(190, 190, 190)
    Property Custom_Lines_Color As Color = Color.FromArgb(106, 106, 106)
    Property Custom_Border_Line_Color As Color = Color.FromArgb(106, 106, 106)
    Property Custom_Top_Back_Gradient_Color As Color = Color.FromArgb(190, 190, 190)
    Property Custom_Bottom_Back_Gradient_Color As Color = Color.FromArgb(162, 162, 162)
    Property Custom_Folds_Color As Color = Color.FromArgb(120, 120, 120)

    Property Anime_Url As String = "http://example.com"
    Property Anime_Show_Name As String = "Anime Show Name-Sama"
    Property Anime_back_Color As Color = Color.FromArgb(160, 0, 0, 0)
    Property Anime_Show_Name_Font As Font = New Font("Arial", 9, FontStyle.Regular)
    Property Anime_Show_Name_Text_Color As Color = Color.White
    Property Anime_Thumbnail As String = "https://static.hummingbird.me/anime/poster_images/000/010/716/large/0fd8df1b586e60a0b1591cd8555c072f1431933759_full.jpg?1433453828"

    Property Custom_First_Text As String = "Custom"
    Property Custom_Second_Text As String = "Release"
    Property Custom_First_Text_Color As Color = Color.White
    Property Custom_Second_Text_Color As Color = Color.White
    Property Custom_First_Text_Font As Font = New Font("Impact", 10, FontStyle.Regular)
    Property Custom_Second_Text_Font As Font = New Font("Impact", 9, FontStyle.Regular)
    Property Custom_First_Text_Point As Point = New Point(-51, -42)
    Property Custom_First_ShadowText_Point As Point = New Point(-21, -19)
    Property Custom_First_Text_Size As Size = New Size(55, 48)
    Property Custom_Second_Text_Point As Point = New Point(-97, -74)
    Property Custom_Second_ShadowText_Point As Point = New Point(-72, -49)
    Property Custom_Second_Text_Size As Size = New Size(55, 48)
#End Region
#Region "Imported Functions"
    Private Sub DrawVertText(ByVal What As String, g2 As Graphics, ByVal Within As Rectangle, ByVal How As Font, ByVal Colore As Brush, ByVal rotateint As Integer)

        Dim strSize As SizeF = g2.MeasureString(What, How)


        g2.TranslateTransform(CSng(Within.Width / 2), CSng(Within.Height / 2))

        g2.RotateTransform(rotateint)


        g2.DrawString(What, How, Colore, Within)
        ' g2.Dispose()
    End Sub
#End Region
    Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(175, 250)
        Me.Padding = New Padding(4, 4, 4, 4)
        Me.ImageLocation = Anime_Thumbnail
        Me.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
    Function CheckTex(Str As String, Max As Integer)
        Dim newstr As String = ""
        Dim i As Integer = 0
        Dim mi As Integer = 0
        For Each Chr As String In Str
            If i >= Max Then
                mi += 1
                If mi <= 3 Then
                    newstr += "."
                Else
                End If
            Else
                newstr += Chr
            End If
            i += 1
        Next
        Return newstr
    End Function
    Public draggintext As Boolean = False
    Public DragTextint As Integer = 65
    Public FirstDownint As Integer = 0
    Public DragTextWidth As Integer = 1000
    Private Sub Shelf_itemm_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If New Rectangle(65, 2, Me.Width - 77, 30).Contains(e.X, e.Y) Then
                draggintext = True
                Cursor = Cursors.VSplit
                FirstDownint = e.X
            End If
        End If

    End Sub



    Private Sub Shelf_itemm_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        MouseEntered = False
        Me.Padding = New Padding(4, 4, 4, 4)
        Me.Refresh()
    End Sub

    Private Sub Shelf_itemm_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If New Rectangle(4, 4, Me.Width - 8, Me.Height - 8).Contains(e.X, e.Y) Then
            MouseEntered = True
            Me.Padding = New Padding(0, 0, 0, 0)
            Me.Refresh()

        End If
        If New Rectangle(65, 2, Me.Width - 77, 30).Contains(e.X, e.Y) Then
            If draggintext = True Then


                If e.X < FirstDownint Then
                    DragTextint -= 2
                Else
                    DragTextint += 1
                End If
                If Not DragTextint > (-DragTextWidth) Then
                    DragTextint = 65
                End If
            End If
        Else
            draggintext = False
            Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub Shelf_itemm_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If New Rectangle(65, 2, Me.Width - 77, 30).Contains(e.X, e.Y) Then
                draggintext = False
                Cursor = Cursors.Arrow
            End If
        End If
    End Sub

    Private Sub Shelf_itemm_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        If MouseEntered = False Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(10, Me.Height - 4, Me.Width - 6, 3))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(Me.Width - 3, 8, 3, Me.Height - 12))
            e.Graphics.FillRectangle(New SolidBrush(Anime_back_Color), New Rectangle(4, 4, Me.Width - 7, 30))
            e.Graphics.DrawString(CheckTex(Anime_Show_Name, 25), Anime_Show_Name_Font, New SolidBrush(Anime_Show_Name_Text_Color), New Rectangle(65, 5, Me.Width - 77, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

            If Kind = Type.New_Release Then
                'Border
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(222, 70, 109)), New Rectangle(4, 4, Me.Width - 8, Me.Height - 8))
                'Folds
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(222, 70, 109)), New Rectangle(67, 0, 4, 4))
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(222, 70, 109)), New Rectangle(0, 66, 4, 4))
                'backs
                Dim points() As Point = {New Point(-1, -1), New Point(70, -1), New Point(-1, 70), New Point(0, -1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(234, 36, 127)), points)
                Dim points2() As Point = {New Point(1, 1), New Point(69, 1), New Point(1, 69), New Point(1, 1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(243, 142, 189)), points2)
                'Gradientback
                Dim curvePoints As PointF() = {New Point(2, 2), New Point(68, 2), New Point(2, 68), New Point(2, 2)}
                Dim rect As New Rectangle(2, 2, 68, 68)
                Dim brushed = New LinearGradientBrush(rect, Color.FromArgb(245, 116, 183), Color.FromArgb(226, 83, 127), 39.0!)
                e.Graphics.FillPolygon(brushed, curvePoints)
                'Lines
                Dim linees As _
                     New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(247, 85, 169), Color.Transparent)
                e.Graphics.FillPolygon(linees, curvePoints)
                '//////Text
                DrawVertText("New", e.Graphics, New Rectangle(-21, -22, 55, 48), New Font("Impact", 12, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 316)
                DrawVertText("New", e.Graphics, New Rectangle(-47, -44, 55, 48), New Font("Impact", 12, FontStyle.Regular), Brushes.White, 0)
                DrawVertText("Release", e.Graphics, New Rectangle(-83, -52, 55, 48), New Font("Impact", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 0)
                DrawVertText("Release", e.Graphics, New Rectangle(-108, -75, 55, 48), New Font("Impact", 10, FontStyle.Regular), Brushes.White, 0)

            ElseIf Kind = Type.Popular Then
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(255, 63, 63)), New Rectangle(4, 4, Me.Width - 8, Me.Height - 8))
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 63, 63)), New Rectangle(67, 0, 4, 4))
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 63, 63)), New Rectangle(0, 66, 4, 4))

                Dim points() As Point = {New Point(-1, -1), New Point(70, -1), New Point(-1, 70), New Point(0, -1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(255, 62, 62)), points)
                Dim points2() As Point = {New Point(1, 1), New Point(69, 1), New Point(1, 69), New Point(1, 1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(255, 163, 163)), points2)
                'Dim myHatchBrush As _
                '    New HatchBrush(HatchStyle.Vertical, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush, points2)
                'Dim myHatchBrush2 As _
                '   New HatchBrush(HatchStyle.Horizontal, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush2, points2)
                Dim curvePoints As PointF() = {New Point(2, 2), New Point(68, 2), New Point(2, 68), New Point(2, 2)}
                Dim rect As New Rectangle(2, 2, 68, 68)
                Dim brushed = New LinearGradientBrush(rect, Color.FromArgb(255, 123, 123), Color.FromArgb(255, 23, 23), 39.0!)
                e.Graphics.FillPolygon(brushed, curvePoints)
                Dim linees As _
                     New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(255, 45, 45), Color.Transparent)
                e.Graphics.FillPolygon(linees, curvePoints)
                'e.graphics.DrawString("New", New Font("Impact", 12, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(3, 3, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                'e.graphics.DrawString("New", New Font("Impact", 12, FontStyle.Regular), Brushes.White, New Rectangle(2, 2, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                DrawVertText("Popular", e.Graphics, New Rectangle(-34, -15, 65, 48), New Font("Impact", 12, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 316)
                DrawVertText("Popular", e.Graphics, New Rectangle(-64, -37, 65, 48), New Font("Impact", 12, FontStyle.Regular), Brushes.White, 0)
                ' e.graphics.DrawString("RELEASE", New Font("Impact", 8, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(1, 18, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                ' e.graphics.DrawString("RELEASE", New Font("Impact", 8, FontStyle.Regular), New SolidBrush(Color.White), New Rectangle(0, 17, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
            ElseIf Kind = Type.Coming_Soon Then
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(37, 138, 255)), New Rectangle(4, 4, Me.Width - 8, Me.Height - 8))
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(37, 138, 255)), New Rectangle(67, 0, 4, 4))
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(37, 138, 255)), New Rectangle(0, 66, 4, 4))

                Dim points() As Point = {New Point(-1, -1), New Point(70, -1), New Point(-1, 70), New Point(0, -1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(20, 130, 255)), points)
                Dim points2() As Point = {New Point(1, 1), New Point(69, 1), New Point(1, 69), New Point(1, 1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(150, 199, 255)), points2)
                'Dim myHatchBrush As _
                '    New HatchBrush(HatchStyle.Vertical, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush, points2)
                'Dim myHatchBrush2 As _
                '   New HatchBrush(HatchStyle.Horizontal, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush2, points2)
                Dim curvePoints As PointF() = {New Point(2, 2), New Point(68, 2), New Point(2, 68), New Point(2, 2)}
                Dim rect As New Rectangle(2, 2, 68, 68)
                Dim brushed = New LinearGradientBrush(rect, Color.FromArgb(105, 175, 255), Color.FromArgb(45, 138, 255), 39.0!)
                e.Graphics.FillPolygon(brushed, curvePoints)
                Dim linees As _
                     New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(15, 127, 254), Color.Transparent)
                e.Graphics.FillPolygon(linees, curvePoints)
                'e.graphics.DrawString("New", New Font("Impact", 12, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(3, 3, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                'e.graphics.DrawString("New", New Font("Impact", 12, FontStyle.Regular), Brushes.White, New Rectangle(2, 2, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                DrawVertText("Upcoming", e.Graphics, New Rectangle(-33, -20, 75, 58), New Font("Impact", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(120, 0, 0, 0)), 316)
                DrawVertText("Upcoming", e.Graphics, New Rectangle(-77, -50, 85, 58), New Font("Impact", 10, FontStyle.Regular), Brushes.White, 0)
                ' e.graphics.DrawString("RELEASE", New Font("Impact", 8, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(1, 18, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                ' e.graphics.DrawString("RELEASE", New Font("Impact", 8, FontStyle.Regular), New SolidBrush(Color.White), New Rectangle(0, 17, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
            ElseIf Kind = Type.Custom Then
                e.Graphics.DrawRectangle(New Pen(Custom_Border_Line_Color), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                e.Graphics.FillRectangle(New SolidBrush(Custom_Folds_Color), New Rectangle(67, 0, 4, 4))
                e.Graphics.FillRectangle(New SolidBrush(Custom_Folds_Color), New Rectangle(0, 66, 4, 4))

                Dim points() As Point = {New Point(-1, -1), New Point(70, -1), New Point(-1, 70), New Point(0, -1)}
                e.Graphics.FillPolygon(New SolidBrush(Custom_Border_Color), points)
                Dim points2() As Point = {New Point(1, 1), New Point(69, 1), New Point(1, 69), New Point(1, 1)}
                e.Graphics.FillPolygon(New SolidBrush(Custom_Inner_Border_Color), points2)
                'Dim myHatchBrush As _
                '    New HatchBrush(HatchStyle.Vertical, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush, points2)
                'Dim myHatchBrush2 As _
                '   New HatchBrush(HatchStyle.Horizontal, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush2, points2)
                Dim curvePoints As PointF() = {New Point(2, 2), New Point(68, 2), New Point(2, 68), New Point(2, 2)}
                Dim rect As New Rectangle(2, 2, 68, 68)
                Dim brushed = New LinearGradientBrush(rect, Custom_Top_Back_Gradient_Color, Custom_Bottom_Back_Gradient_Color, 39.0!)
                e.Graphics.FillPolygon(brushed, curvePoints)
                Dim linees As _
                     New HatchBrush(HatchStyle.LightDownwardDiagonal, Custom_Lines_Color, Color.Transparent)
                e.Graphics.FillPolygon(linees, curvePoints)
                DrawVertText(Custom_First_Text, e.Graphics, New Rectangle(Custom_First_ShadowText_Point, Custom_First_Text_Size), Custom_First_Text_Font, New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 316)
                DrawVertText(Custom_First_Text, e.Graphics, New Rectangle(Custom_First_Text_Point, Custom_First_Text_Size), Custom_First_Text_Font, New SolidBrush(Custom_First_Text_Color), 0)
                DrawVertText(Custom_Second_Text, e.Graphics, New Rectangle(Custom_Second_ShadowText_Point, Custom_Second_Text_Size), Custom_Second_Text_Font, New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 0)
                DrawVertText(Custom_Second_Text, e.Graphics, New Rectangle(Custom_Second_Text_Point, Custom_Second_Text_Size), Custom_Second_Text_Font, New SolidBrush(Custom_Second_Text_Color), 0)
            End If

        Else
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            e.Graphics.FillRectangle(New SolidBrush(Anime_back_Color), New Rectangle(1, 1, Me.Width - 2, 30))
            If draggintext = False Then
                e.Graphics.DrawString(CheckTex(Anime_Show_Name, 25), Anime_Show_Name_Font, New SolidBrush(Anime_Show_Name_Text_Color), New Rectangle(65, 2, Me.Width - 77, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            Else
                Dim sz As SizeF = e.Graphics.MeasureString(Anime_Show_Name, Anime_Show_Name_Font)
                DragTextWidth = sz.Width + 5
                e.Graphics.DrawString(Anime_Show_Name, Anime_Show_Name_Font, New SolidBrush(Anime_Show_Name_Text_Color), New Rectangle(DragTextint, 2, sz.Width, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End If
            'Te
            e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(120, 0, 0, 0)), New Rectangle(Me.Width / 2 - 32, Me.Height - 40, 64, 64))
            e.Graphics.FillEllipse(New SolidBrush(Color.FromArgb(255, 255, 255, 255)), New Rectangle(Me.Width / 2 - 28, Me.Height - 36, 56, 56))
            Dim bytes As Byte() = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAYAAACM/rhtAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAKRJREFUeNpi/P//P8NgBkwMgxyMOnDUgaMOHHXgqANHHTjqwAEGoNYMMgYCeyA+CZIiAm8HYhWaugeLA58T6TgY3ohk/l4S9aLjvejuwRbFEiR6WhGJ/YvCAMTQz0LlFOM5mospBBSnQVo7cDQNjqZBaqTBpyQ66hEt0yC2msSDhNrkEhBr0bKqYxwdWRh14KgDRx046sBRB446cNSBQ9qBAAEGAPhFqjdpHPl0AAAAAElFTkSuQmCC")

            Dim img As Image
            Using ms As New MemoryStream(bytes)
                img = Image.FromStream(ms)
            End Using
            e.Graphics.DrawImage(img, New Rectangle(Me.Width / 2 - 16, Me.Height - 30, 32, 38))
            img.Dispose()
            If Kind = Type.New_Release Then
                'Border
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(222, 70, 109)), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                'Folds
                'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(222, 70, 109)), New Rectangle(67, 0, 4, 4))
                'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(222, 70, 109)), New Rectangle(0, 66, 4, 4))
                'backs
                Dim points() As Point = {New Point(-1, -1), New Point(70, -1), New Point(-1, 70), New Point(0, -1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(234, 36, 127)), points)
                Dim points2() As Point = {New Point(1, 1), New Point(69, 1), New Point(1, 69), New Point(1, 1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(243, 142, 189)), points2)
                'Gradientback
                Dim curvePoints As PointF() = {New Point(2, 2), New Point(68, 2), New Point(2, 68), New Point(2, 2)}
                Dim rect As New Rectangle(2, 2, 68, 68)
                Dim brushed = New LinearGradientBrush(rect, Color.FromArgb(245, 116, 183), Color.FromArgb(226, 83, 127), 39.0!)
                e.Graphics.FillPolygon(brushed, curvePoints)
                'Lines
                Dim linees As _
                     New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(247, 85, 169), Color.Transparent)
                e.Graphics.FillPolygon(linees, curvePoints)
                '//////Text
                DrawVertText("New", e.Graphics, New Rectangle(-21, -22, 55, 48), New Font("Impact", 12, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 316)
                DrawVertText("New", e.Graphics, New Rectangle(-47, -44, 55, 48), New Font("Impact", 12, FontStyle.Regular), Brushes.White, 0)
                DrawVertText("Release", e.Graphics, New Rectangle(-83, -52, 55, 48), New Font("Impact", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 0)
                DrawVertText("Release", e.Graphics, New Rectangle(-108, -75, 55, 48), New Font("Impact", 10, FontStyle.Regular), Brushes.White, 0)

            ElseIf Kind = Type.Popular Then
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(255, 63, 63)), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 63, 63)), New Rectangle(67, 0, 4, 4))
                'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 63, 63)), New Rectangle(0, 66, 4, 4))

                Dim points() As Point = {New Point(-1, -1), New Point(70, -1), New Point(-1, 70), New Point(0, -1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(255, 62, 62)), points)
                Dim points2() As Point = {New Point(1, 1), New Point(69, 1), New Point(1, 69), New Point(1, 1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(255, 163, 163)), points2)
                'Dim myHatchBrush As _
                '    New HatchBrush(HatchStyle.Vertical, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush, points2)
                'Dim myHatchBrush2 As _
                '   New HatchBrush(HatchStyle.Horizontal, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush2, points2)
                Dim curvePoints As PointF() = {New Point(2, 2), New Point(68, 2), New Point(2, 68), New Point(2, 2)}
                Dim rect As New Rectangle(2, 2, 68, 68)
                Dim brushed = New LinearGradientBrush(rect, Color.FromArgb(255, 123, 123), Color.FromArgb(255, 23, 23), 39.0!)
                e.Graphics.FillPolygon(brushed, curvePoints)
                Dim linees As _
                     New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(255, 45, 45), Color.Transparent)
                e.Graphics.FillPolygon(linees, curvePoints)
                'e.graphics.DrawString("New", New Font("Impact", 12, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(3, 3, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                'e.graphics.DrawString("New", New Font("Impact", 12, FontStyle.Regular), Brushes.White, New Rectangle(2, 2, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                DrawVertText("Popular", e.Graphics, New Rectangle(-34, -15, 65, 48), New Font("Impact", 12, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 316)
                DrawVertText("Popular", e.Graphics, New Rectangle(-64, -37, 65, 48), New Font("Impact", 12, FontStyle.Regular), Brushes.White, 0)
                ' e.graphics.DrawString("RELEASE", New Font("Impact", 8, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(1, 18, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                ' e.graphics.DrawString("RELEASE", New Font("Impact", 8, FontStyle.Regular), New SolidBrush(Color.White), New Rectangle(0, 17, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
            ElseIf Kind = Type.Coming_Soon Then
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(37, 138, 255)), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(37, 138, 255)), New Rectangle(67, 0, 4, 4))
                'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(37, 138, 255)), New Rectangle(0, 66, 4, 4))

                Dim points() As Point = {New Point(-1, -1), New Point(70, -1), New Point(-1, 70), New Point(0, -1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(20, 130, 255)), points)
                Dim points2() As Point = {New Point(1, 1), New Point(69, 1), New Point(1, 69), New Point(1, 1)}
                e.Graphics.FillPolygon(New SolidBrush(Color.FromArgb(150, 199, 255)), points2)
                'Dim myHatchBrush As _
                '    New HatchBrush(HatchStyle.Vertical, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush, points2)
                'Dim myHatchBrush2 As _
                '   New HatchBrush(HatchStyle.Horizontal, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush2, points2)
                Dim curvePoints As PointF() = {New Point(2, 2), New Point(68, 2), New Point(2, 68), New Point(2, 2)}
                Dim rect As New Rectangle(2, 2, 68, 68)
                Dim brushed = New LinearGradientBrush(rect, Color.FromArgb(105, 175, 255), Color.FromArgb(45, 138, 255), 39.0!)
                e.Graphics.FillPolygon(brushed, curvePoints)
                Dim linees As _
                     New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(15, 127, 254), Color.Transparent)
                e.Graphics.FillPolygon(linees, curvePoints)
                'e.graphics.DrawString("New", New Font("Impact", 12, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(3, 3, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                'e.graphics.DrawString("New", New Font("Impact", 12, FontStyle.Regular), Brushes.White, New Rectangle(2, 2, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                DrawVertText("Upcoming", e.Graphics, New Rectangle(-33, -20, 75, 58), New Font("Impact", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(120, 0, 0, 0)), 316)
                DrawVertText("Upcoming", e.Graphics, New Rectangle(-77, -50, 85, 58), New Font("Impact", 10, FontStyle.Regular), Brushes.White, 0)
                ' e.graphics.DrawString("RELEASE", New Font("Impact", 8, FontStyle.Regular), New SolidBrush(Color.FromArgb(80, 0, 0, 0)), New Rectangle(1, 18, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
                ' e.graphics.DrawString("RELEASE", New Font("Impact", 8, FontStyle.Regular), New SolidBrush(Color.White), New Rectangle(0, 17, 45, 30), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
            ElseIf Kind = Type.Custom Then
                e.Graphics.DrawRectangle(New Pen(Custom_Border_Line_Color), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(37, 138, 255)), New Rectangle(67, 0, 4, 4))
                'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(37, 138, 255)), New Rectangle(0, 66, 4, 4))

                Dim points() As Point = {New Point(-1, -1), New Point(70, -1), New Point(-1, 70), New Point(0, -1)}
                e.Graphics.FillPolygon(New SolidBrush(Custom_Border_Color), points)
                Dim points2() As Point = {New Point(1, 1), New Point(69, 1), New Point(1, 69), New Point(1, 1)}
                e.Graphics.FillPolygon(New SolidBrush(Custom_Inner_Border_Color), points2)
                'Dim myHatchBrush As _
                '    New HatchBrush(HatchStyle.Vertical, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush, points2)
                'Dim myHatchBrush2 As _
                '   New HatchBrush(HatchStyle.Horizontal, Color.FromArgb(243, 104, 183), Color.Transparent)
                'e.graphics.FillPolygon(myHatchBrush2, points2)
                Dim curvePoints As PointF() = {New Point(2, 2), New Point(68, 2), New Point(2, 68), New Point(2, 2)}
                Dim rect As New Rectangle(2, 2, 68, 68)
                Dim brushed = New LinearGradientBrush(rect, Custom_Top_Back_Gradient_Color, Custom_Bottom_Back_Gradient_Color, 39.0!)
                e.Graphics.FillPolygon(brushed, curvePoints)
                Dim linees As _
                     New HatchBrush(HatchStyle.LightDownwardDiagonal, Custom_Lines_Color, Color.Transparent)
                e.Graphics.FillPolygon(linees, curvePoints)
                e.Graphics.FillPolygon(linees, curvePoints)
                DrawVertText(Custom_First_Text, e.Graphics, New Rectangle(Custom_First_ShadowText_Point, Custom_First_Text_Size), Custom_First_Text_Font, New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 316)
                DrawVertText(Custom_First_Text, e.Graphics, New Rectangle(Custom_First_Text_Point, Custom_First_Text_Size), Custom_First_Text_Font, New SolidBrush(Custom_First_Text_Color), 0)
                DrawVertText(Custom_Second_Text, e.Graphics, New Rectangle(Custom_Second_ShadowText_Point, Custom_Second_Text_Size), Custom_Second_Text_Font, New SolidBrush(Color.FromArgb(80, 0, 0, 0)), 0)
                DrawVertText(Custom_Second_Text, e.Graphics, New Rectangle(Custom_Second_Text_Point, Custom_Second_Text_Size), Custom_Second_Text_Font, New SolidBrush(Custom_Second_Text_Color), 0)
            End If
        End If


    End Sub
End Class