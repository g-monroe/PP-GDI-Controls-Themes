'///////////\\\\\\\\\\\\
'|By Nettro from HF    |
'|Completed 3/28/2015  |
'|@5:43PM              |
'|Enjoy please         |
'///////////\\\\\\\\\\\\
Public Class PopUp
    Inherits Control
    Property Description As String = "This is a description no longer than 155 characters."
    Property Image As Image
    Property Type As Kind
    Enum Kind
        Comp
        Info
        Warn
        Erro
    End Enum
    Sub New()
        Me.DoubleBuffered = True
    End Sub

    Private Sub PopUp_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        '3d
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(205, 205, 205)), New Rectangle(7, 8, Me.Width - 10, 55))
        If Type = Kind.Comp Then
            'front box
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(102, 175, 82)), New Rectangle(0, 0, 60, 60))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(114, 181, 95)), New Rectangle(-1, 1, 60, 59))
            'End color
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(107, 177, 88)), New Rectangle(Me.Width - 3, 0, 3, 60))
            'box
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(61, 0, Me.Width - 65, 60))
            'lips
            e.Graphics.DrawLine(New Pen(Color.FromArgb(183, 218, 173)), New Point(60, 0), New Point(60, 59))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(183, 218, 173)), New Point(Me.Width - 4, 0), New Point(Me.Width - 4, 59))
            'text
            e.Graphics.DrawString(CheckLength(Me.Text, 25), New Font("Arial", 13, FontStyle.Regular), New SolidBrush(Color.FromArgb(110, 179, 90)), New Rectangle(75, 10, Me.Width - 85, 22))
        ElseIf Type = Kind.Erro Then
            'front box
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(213, 26, 26)), New Rectangle(0, 0, 60, 60))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(216, 43, 43)), New Rectangle(-1, 1, 60, 59))
            'End color
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(216, 41, 41)), New Rectangle(Me.Width - 3, 0, 3, 60))
            'box
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(61, 0, Me.Width - 65, 60))
            'lips
            e.Graphics.DrawLine(New Pen(Color.FromArgb(235, 149, 149)), New Point(60, 0), New Point(60, 59))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(235, 149, 149)), New Point(Me.Width - 4, 0), New Point(Me.Width - 4, 59))
            'text
            e.Graphics.DrawString(CheckLength(Me.Text, 25), New Font("Arial", 13, FontStyle.Regular), New SolidBrush(Color.FromArgb(216, 43, 43)), New Rectangle(75, 10, Me.Width - 85, 22))
        ElseIf Type = Kind.Warn Then
            'front box
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(244, 120, 23)), New Rectangle(0, 0, 60, 60))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(244, 130, 41)), New Rectangle(-1, 1, 60, 59))
            'End color
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(242, 124, 32)), New Rectangle(Me.Width - 3, 0, 3, 60))
            'box
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(61, 0, Me.Width - 65, 60))
            'lips
            e.Graphics.DrawLine(New Pen(Color.FromArgb(250, 192, 148)), New Point(60, 0), New Point(60, 59))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(250, 192, 148)), New Point(Me.Width - 4, 0), New Point(Me.Width - 4, 59))
            'text
            e.Graphics.DrawString(CheckLength(Me.Text, 25), New Font("Arial", 13, FontStyle.Regular), New SolidBrush(Color.FromArgb(245, 131, 49)), New Rectangle(75, 10, Me.Width - 85, 22))
        ElseIf Type = Kind.Info Then
            'front box
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(17, 178, 170)), New Rectangle(0, 0, 60, 60))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(35, 184, 176)), New Rectangle(-1, 1, 60, 59))
            'End color
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(25, 179, 172)), New Rectangle(Me.Width - 3, 0, 3, 60))
            'box
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(61, 0, Me.Width - 65, 60))
            'lips
            e.Graphics.DrawLine(New Pen(Color.FromArgb(145, 219, 215)), New Point(60, 0), New Point(60, 59))
            e.Graphics.DrawLine(New Pen(Color.FromArgb(145, 219, 215)), New Point(Me.Width - 4, 0), New Point(Me.Width - 4, 59))
            'text
            e.Graphics.DrawString(CheckLength(Me.Text, 25), New Font("Arial", 13, FontStyle.Regular), New SolidBrush(Color.FromArgb(54, 189, 181)), New Rectangle(75, 10, Me.Width - 85, 22))
        End If

        'Desc
        e.Graphics.DrawString(CheckLength(Description, 95), New Font("Arial", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(139, 139, 139)), New Rectangle(65, 30, Me.Width - 52, 26))
        'Image
        Try
            e.Graphics.DrawImage(Image, New Rectangle(5, 5, 50, 50))
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Function CheckLength(Text As String, Max As Integer)
        Dim i As Integer = 0
        Dim returnstr As String = ""
        Dim wentover As Integer = 0
        For Each Ch As String In Text
            i += 1
            If i <= Max Then
                returnstr += Ch
            Else
                wentover += 1
                Ch = ""
                returnstr += Ch
            End If
        Next
        If wentover > 0 Then
            Return returnstr & "..."
        Else
            Return returnstr
        End If
    End Function
End Class