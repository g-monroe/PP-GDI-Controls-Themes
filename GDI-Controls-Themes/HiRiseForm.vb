Imports Monocontrol_Maker.monodie
Imports System.Drawing.Drawing2D
Public Class HR_Form
    Inherits ContainerControl
    Sub New()
        Me.DoubleBuffered = True
    End Sub
#Region "properties"
    Property Border1 As Color = ColorTranslator.FromHtml("#2A3D56")
    Property Border2 As Color = ColorTranslator.FromHtml("#50708E")
    Property Header As Color = ColorTranslator.FromHtml("#3F5C76")
    Property lip1Header As Color = ColorTranslator.FromHtml("#3A5673")
    Property lip2Header As Color = ColorTranslator.FromHtml("#4E708C")
    Property lip3Header As Color = ColorTranslator.FromHtml("#517391")
    Property lip1Header2 As Color = ColorTranslator.FromHtml("#C1D7EB")
    Property lip2Header2 As Color = ColorTranslator.FromHtml("#D5E4EF")
    Property lip3Header2 As Color = ColorTranslator.FromHtml("#E0EBF5")
    Property back As Color = ColorTranslator.FromHtml("#F6FAFE")
    Property icontype As Boolean = False
#End Region
    Private Sub HR_Form_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim h As Integer = Me.Height
        Dim w As Integer = Me.Width
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.Clear(BackColor)
        Fillrr(g, New Rectangle(0, 15, w - 2, h - 17), 12, New SolidBrush(back))
        FillNotBottomrr(g, New Rectangle(0, 0, w - 2, 40), 13, New SolidBrush(Border2))
        FillNotBottomrr(g, New Rectangle(0, 3, w - 2, 38), 13, New SolidBrush(Header))
        g.DrawLine(New Pen(Header), New Point(0, 35), New Point(w - 2, 35))
        g.DrawLine(New Pen(lip3Header), New Point(0, 36), New Point(w - 2, 36))
        g.DrawLine(New Pen(lip1Header), New Point(0, 37), New Point(w - 2, 37))
        g.DrawLine(New Pen(lip1Header2), New Point(0, 38), New Point(w - 2, 38))
        g.DrawLine(New Pen(lip2Header2), New Point(0, 39), New Point(w - 2, 39))

        Dim gb As New LinearGradientBrush(New Rectangle(0, 39, w - 3, 20), Color.FromArgb(120, lip3Header2), Color.Transparent, 90.0!)
        g.FillRectangle(gb, New Rectangle(0, 39, w - 3, 19))
        DrawRoundedRectangle(g, New Rectangle(0, 0, w - 1, h - 1), New Pen(Border1, 1), 14)
        If icontype = False Then
            DrawRoundedRectangle(g, New Rectangle(7, 7, 25, 25), New Pen(ColorTranslator.FromHtml("#8EA2B4"), 2), 6)
            g.FillRectangle(Brushes.White, New Rectangle(10, 10, 18, 18))
            DrawRoundedRectangle(g, New Rectangle(9, 9, 21, 21), New Pen(ColorTranslator.FromHtml("#B6CADC"), 2), 2)
        Else
            DrawRoundedRectangle(g, New Rectangle(6, 6, 24, 25), New Pen(lip1Header, 1), 6)
            Fillrr(g, New Rectangle(4, 4, 30, 33), 4, New SolidBrush(lip3Header))
            Fillrr(g, New Rectangle(6, 6, 26, 30), 6, New SolidBrush(ColorTranslator.FromHtml("#B6CADC")))

            Fillrr(g, New Rectangle(8, 8, 22, 30), 4, New SolidBrush(back))
            DrawRoundedRectangle(g, New Rectangle(8, 8, 22, 30), New Pen(lip3Header2, 1), 4)
        End If

        g.DrawIcon(FindForm.Icon, New Rectangle(10, 10, 19, 19))
        'buttons
        FillNotToprr(g, New Rectangle(Me.Width - 50, -6, 40, 25), 16, New SolidBrush(ColorTranslator.FromHtml("#3F5C76")))
        FillNotToprr(g, New Rectangle(Me.Width - 49, -6, 38, 24), 16, New SolidBrush(ColorTranslator.FromHtml("#527491")))
        FillNotToprr(g, New Rectangle(Me.Width - 49, -7, 38, 24), 16, New SolidBrush(ColorTranslator.FromHtml("#3F5C76")))
        DrawRoundedRectangle(g, New Rectangle(Me.Width - 48, -10, 37, 27), New Pen(ColorTranslator.FromHtml("#527491")), 16)
        DrawRoundedRectangle(g, New Rectangle(Me.Width - 48, -7, 37, 23), New Pen(Border1), 16)
        DrawRoundedRectangle(g, New Rectangle(Me.Width - 50, -10, 41, 28), New Pen(Border1), 18)
        '  g.FillRectangle(gb, New Rectangle(0, h - 21, w - 3, 20))
    End Sub

    Private Sub HR_Form_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
End Class