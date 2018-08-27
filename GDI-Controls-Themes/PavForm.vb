Imports System.Drawing.Drawing2D
Imports Pavelite_Theme.PaveliteFormPallete
Public Class PL_FormContainer
    Inherits ContainerControl
    Sub New()
        Me.DoubleBuffered = True
        'Me.Dock = true

    End Sub
#Region "Properties"
    '{
    '[Drawing]
    '}
    Property Quality As gs = gs.AA
    Dim w As Integer = Me.Width
    Dim h As Integer = Me.Height
    '}
    '[Msic]
    '}
    '-Text
    Property fText As Font = New Font("Arial", 9, FontStyle.Bold)
    Property hText As String = "PAVELITE FORM"
    '-Icon
    Property bIcon As Boolean = False
    Property Icon As Image
    '-Buttons
    Property Buttons As Boolean = True

#End Region
#Region "Functions"
    Public Shared Function CheckIcon(b As Boolean, y As Integer, n As Integer) As Integer
        If b Then Return y : Else Return n
    End Function
    Enum gs
        AA
        HQ
        HS
    End Enum
    Public Shared Function GetSmoothMode(g As gs) As SmoothingMode
        Select Case g
            Case gs.AA
                Return SmoothingMode.AntiAlias
            Case gs.HQ
                Return SmoothingMode.HighQuality
            Case gs.HS
                Return SmoothingMode.HighSpeed
        End Select
        Return SmoothingMode.HighSpeed
    End Function
    Public Shared Function LinearGradientBrush(fc As Color, sc As Color, r As Rectangle, a As Decimal) As LinearGradientBrush
        Return New LinearGradientBrush(r, fc, sc, a)
    End Function
#End Region
    Public Sub PL_FormContainer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Using bm As New Bitmap(Me.Width, Me.Height)
            Using g As Graphics = Graphics.FromImage(bm)
                '[Begin]
                g.SmoothingMode = GetSmoothMode(Quality)
                w = Me.Width - 1
                h = Me.Height - 1
                '[Back]
                g.Clear(_BackColor)
                '[Header]
                g.FillRectangle(New LinearGradientBrush(New Rectangle(1, 1, w - 1, 50), _HeaderColor, _AltHeaderColor, 90.0!), New Rectangle(1, 1, w - 1, 50))
                '[Icon]
                If bIcon Then
                    g.FillRectangle(BackBrush, New Rectangle(6, (50 / 2) - 13, 26, 26))
                    g.DrawRectangle(BorderPen, New Rectangle(6, (50 / 2) - 13, 26, 26))
                    Try : If Not Icon Is Nothing Then : g.DrawImage(Icon, New Rectangle(7, (50 / 2) - 12, 25, 25)) : Else : End If : Catch ex As Exception : End Try
                    Icon.Dispose()
                End If
                '[Text]
                g.DrawString(hText, fText, AltTextBrush, New Rectangle((CheckIcon(bIcon, 35, 11)), 1, w - (CheckIcon(bIcon, 35, 11)), 53), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
                g.DrawString(hText, fText, TextBrush, New Rectangle((CheckIcon(bIcon, 35, 11)), 1, w - (CheckIcon(bIcon, 35, 11)), 50), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
                '[Border]
                g.DrawRectangle(BorderPen, New Rectangle(0, 0, w, h))
                '[Button]

                If Buttons Then
                    g.FillRectangle(New SolidBrush(Color.FromArgb(104, 155, 192)), New Rectangle(w - 70, (50 / 3) - 12, 27, 18))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(68, 114, 150)), New Rectangle(w - 70, (50 / 3) - 13, 26, 16))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(47, 104, 149)), New Rectangle(w - 70, (50 / 3) - 12, 26, 17))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(51, 114, 163)), New Rectangle(w - 70, (50 / 3) - 11, 26, 16))
                    g.DrawString("-", New Font("Arial", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(105, 152, 188)), New Rectangle(w - 74, (55 / 3) - 11, 26, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    g.DrawString("-", New Font("Arial", 10, FontStyle.Regular), Brushes.White, New Rectangle(w - 73, (55 / 3) - 11, 26, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                    g.FillRectangle(New LinearGradientBrush(New Rectangle(w - 53, 2, 10, 48), _HeaderColor, _AltHeaderColor, 90.0!), New Rectangle(w - 53, 2, 10, 48))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(104, 155, 192)), New Rectangle(w - 50, (50 / 3) - 12, 27, 18))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(68, 114, 150)), New Rectangle(w - 50, (50 / 3) - 13, 26, 16))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(47, 104, 149)), New Rectangle(w - 50, (50 / 3) - 12, 26, 17))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(51, 114, 163)), New Rectangle(w - 50, (50 / 3) - 11, 26, 16))
                    g.DrawString("+", New Font("Arial", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(105, 152, 188)), New Rectangle(w - 52, (55 / 3) - 11, 26, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    g.DrawString("+", New Font("Arial", 10, FontStyle.Regular), Brushes.White, New Rectangle(w - 53, (55 / 3) - 11, 26, 16), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                    g.FillRectangle(New LinearGradientBrush(New Rectangle(w - 33, 2, 10, 48), _HeaderColor, _AltHeaderColor, 90.0!), New Rectangle(w - 33, 3, 10, 47))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(104, 155, 192)), New Rectangle(w - 30, (50 / 3) - 12, 27, 18))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(68, 114, 150)), New Rectangle(w - 30, (50 / 3) - 13, 26, 16))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(47, 104, 149)), New Rectangle(w - 30, (50 / 3) - 12, 26, 17))
                    g.FillRectangle(New SolidBrush(Color.FromArgb(51, 114, 163)), New Rectangle(w - 30, (50 / 3) - 11, 26, 16))
                    g.DrawString("x", New Font("Arial", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(105, 152, 188)), New Rectangle(w - 29, (50 / 3) - 11, 26, 14), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    g.DrawString("x", New Font("Arial", 10, FontStyle.Regular), Brushes.White, New Rectangle(w - 30, (50 / 3) - 11, 26, 14), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    ' g.FillRectangle(New SolidBrush(Color.FromArgb(96, 158, 196)), New Rectangle(w - 29, (50 / 3) - 12, 24, 16))
                End If
                'g.FillEllipse(New SolidBrush(Color.FromArgb(104, 155, 192)), New Rectangle(w - 30, (50 / 3) - 12, 27, 18))
                'g.FillEllipse(New SolidBrush(Color.FromArgb(68, 114, 150)), New Rectangle(w - 30, (50 / 3) - 13, 26, 16))
                'g.FillEllipse(New SolidBrush(Color.FromArgb(47, 104, 149)), New Rectangle(w - 30, (50 / 3) - 12, 26, 17))
                'g.FillEllipse(New SolidBrush(Color.FromArgb(51, 114, 163)), New Rectangle(w - 30, (50 / 3) - 11, 26, 16))
                '   g.FillRectangle(New SolidBrush(Color.FromArgb(96, 158, 196)), New Rectangle(w - 29, (50 / 3) - 12, 24, 16))
                '[End]
                Try : e.Graphics.DrawImage(DirectCast(bm.Clone(), Bitmap), 0, 0) : Catch ex As Exception : End Try

            End Using
        End Using

    End Sub

End Class
Public NotInheritable Class PaveliteFormPallete

#Region " Properties "
    Public Shared ReadOnly Property BorderPen() As Pen
        Get
            Return _BorderPen
        End Get
    End Property
    Public Shared ReadOnly Property BackBrush() As SolidBrush
        Get
            Return _BackBrush
        End Get
    End Property
    Public Shared ReadOnly Property HeaderBrush() As SolidBrush
        Get
            Return _HeaderBrush
        End Get
    End Property
    Public Shared ReadOnly Property AltHeaderBrush() As SolidBrush
        Get
            Return _AltHeaderBrush
        End Get
    End Property
    Public Shared ReadOnly Property IconBackBrush() As SolidBrush
        Get
            Return _IconBackBrush
        End Get
    End Property
    Public Shared ReadOnly Property IconBorderBrush() As SolidBrush
        Get
            Return _IconBorderBrush
        End Get
    End Property
    Public Shared ReadOnly Property TextBrush() As SolidBrush
        Get
            Return _TextBrush
        End Get
    End Property
    Public Shared ReadOnly Property AltTextBrush() As SolidBrush
        Get
            Return _AltTextBrush
        End Get
    End Property
#End Region

#Region " Members "

    Private Shared _BorderPen As Pen
    Private Shared _BackBrush As SolidBrush
    Private Shared _HeaderBrush As SolidBrush
    Private Shared _AltHeaderBrush As SolidBrush
    Private Shared _IconBackBrush As SolidBrush
    Private Shared _IconBorderBrush As SolidBrush
    Private Shared _TextBrush As SolidBrush
    Private Shared _AltTextBrush As SolidBrush
    '<Color>
    Public Shared Property _BorderColor As Color = Color.FromArgb(212, 232, 244)
    Public Shared Property _BackColor As Color = Color.FromArgb(244, 249, 252)
    Public Shared Property _HeaderColor As Color = Color.FromArgb(113, 171, 204)
    Public Shared Property _AltHeaderColor As Color = Color.FromArgb(63, 127, 173)
    Public Shared Property _IconBackColor As Color = Color.FromArgb(244, 249, 252)
    Public Shared Property _IconBorderColor As Color = Color.FromArgb(212, 232, 244)
    Public Shared Property _TextColor As Color = Color.FromArgb(242, 246, 249)
    Public Shared Property _AltTextColor As Color = Color.FromArgb(48, 108, 157)

#End Region

#Region " Constructor "

    Shared Sub New()
        _BorderPen = New Pen(_BorderColor)
        _BackBrush = New SolidBrush(_BackColor)
        _HeaderBrush = New SolidBrush(_HeaderColor)
        _AltHeaderBrush = New SolidBrush(_AltHeaderColor)
        _IconBackBrush = New SolidBrush(_IconBackColor)
        _IconBorderBrush = New SolidBrush(_IconBorderColor)
        _TextBrush = New SolidBrush(_TextColor)
        _AltTextBrush = New SolidBrush(_AltTextColor)
    End Sub

#End Region

End Class