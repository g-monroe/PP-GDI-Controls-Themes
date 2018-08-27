'Random Controls: CrunchyRollItem
'By Nettro ;P
' Tip: you must use the refresh boolean to show or change the image <- this feature was to stop the lag -> if you know vb.net and gdi you can easily change it so it "downloads" the image instead of using a picturebox.
Imports System.ComponentModel
Imports System.IO

Public Class CrunchyRollItems
    Inherits Panel
    Public picturebx As New PictureBox
    Public Property useonlineimage As Boolean = False
    Public Property Image As Image
    Public Property URLImage As String
    Property refresh2 As Boolean = False
    Sub New()
        Me.Size = New Size(150, 135)

    End Sub
    Property Texxt As String = "Baku Baku - Episode 10"
    Private Sub CrunchyRollItems_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(227, 227, 227)), New Rectangle(1, 1, Me.Width - 3, Me.Height - 3)) '227, 227, 227
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(2, 2, Me.Width - 4, Me.Height - 4))
        e.Graphics.DrawLine(New Pen(Color.FromArgb(206, 206, 206)), New Point(2, Me.Height - 3), New Point(Me.Width - 4, Me.Height - 3))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(234, 234, 234)), New Rectangle(10, Me.Height / 2 + 16, Me.Width - 20, 4))
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(234, 234, 234)), New Rectangle(10, 10, Me.Width - 20, Me.Height / 2 + 10 - 10))
        picturebx.SizeMode = PictureBoxSizeMode.StretchImage
        picturebx.Location = New Point(11, 11)
        picturebx.Size = New Size(Me.Width - 22, Me.Height / 2 + 10 - 11)
        If refresh2 = False Then
            For Each pic As PictureBox In Me.Controls.OfType(Of PictureBox)()
                pic.Dispose()
            Next
            If useonlineimage = False Then
                picturebx.Image = Image
            Else
                picturebx.LoadAsync(URLImage)
            End If
            Controls.Add(picturebx)
            refresh2 = True
        End If
        e.Graphics.DrawString(Texxt, New Font("arial", 9, FontStyle.Regular), New SolidBrush(Color.DarkGray), New Rectangle(8, Me.Height / 2 + 20, Me.Width - 15, Me.Height / 2 - 10), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
    End Sub
End Class