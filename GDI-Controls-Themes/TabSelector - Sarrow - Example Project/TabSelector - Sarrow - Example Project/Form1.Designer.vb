<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TabLabel1 As TabSelector___Sarrow___Example_Project.Sarrow_Tabselector.TabLabel = New TabSelector___Sarrow___Example_Project.Sarrow_Tabselector.TabLabel()
        Dim Tab1 As TabSelector___Sarrow___Example_Project.Sarrow_Tabselector.Tab = New TabSelector___Sarrow___Example_Project.Sarrow_Tabselector.Tab()
        Dim Tab2 As TabSelector___Sarrow___Example_Project.Sarrow_Tabselector.Tab = New TabSelector___Sarrow___Example_Project.Sarrow_Tabselector.Tab()
        Me.PlainTabcontrol1 = New TabSelector___Sarrow___Example_Project.PlainTabcontrol()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Sarrow_Tabselector1 = New TabSelector___Sarrow___Example_Project.Sarrow_Tabselector()
        Me.PlainTabcontrol1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlainTabcontrol1
        '
        Me.PlainTabcontrol1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.PlainTabcontrol1.Controls.Add(Me.TabPage1)
        Me.PlainTabcontrol1.Controls.Add(Me.TabPage2)
        Me.PlainTabcontrol1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlainTabcontrol1.ItemSize = New System.Drawing.Size(0, 1)
        Me.PlainTabcontrol1.Location = New System.Drawing.Point(231, 0)
        Me.PlainTabcontrol1.Name = "PlainTabcontrol1"
        Me.PlainTabcontrol1.SelectedIndex = 0
        Me.PlainTabcontrol1.Size = New System.Drawing.Size(507, 527)
        Me.PlainTabcontrol1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.PlainTabcontrol1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(499, 518)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(159, 154)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 5)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(499, 518)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Sarrow_Tabselector1
        '
        Me.Sarrow_Tabselector1.Company_Name = "Silver Arrow"
        Me.Sarrow_Tabselector1.CompanyBackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Sarrow_Tabselector1.CompanyBorderColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.Sarrow_Tabselector1.CompanyDoc = "See Documentation"
        Me.Sarrow_Tabselector1.CompanyDocActiveColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Sarrow_Tabselector1.CompanyDocColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.Sarrow_Tabselector1.CompanyDocFont = New System.Drawing.Font("Arial", 9.0!)
        Me.Sarrow_Tabselector1.CompanyLink = "View Site"
        Me.Sarrow_Tabselector1.CompanyLinkActiveColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Sarrow_Tabselector1.CompanyLinkColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.Sarrow_Tabselector1.CompanyLinkFont = New System.Drawing.Font("Arial", 9.0!)
        Me.Sarrow_Tabselector1.CompanyLogo = Nothing
        Me.Sarrow_Tabselector1.CompanyLogoAlign = TabSelector___Sarrow___Example_Project.Sarrow_Tabselector.CompanyLogoAligns.AlignLeft
        Me.Sarrow_Tabselector1.CompanyLogoGap = 3
        Me.Sarrow_Tabselector1.CompanyLogoVisible = True
        Me.Sarrow_Tabselector1.CompanyNameColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Sarrow_Tabselector1.CompanyNameFont = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Sarrow_Tabselector1.CompanySubtitle = "Communications Expert"
        Me.Sarrow_Tabselector1.CompanySubtitleColor = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Sarrow_Tabselector1.CompanySubtitleFont = New System.Drawing.Font("Arial", 10.0!)
        Me.Sarrow_Tabselector1.CompanyVisible = True
        Me.Sarrow_Tabselector1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Sarrow_Tabselector1.Location = New System.Drawing.Point(0, 0)
        Me.Sarrow_Tabselector1.LogoLocation = New System.Drawing.Point(10, 30)
        Me.Sarrow_Tabselector1.LogoSize = New System.Drawing.Size(92, 92)
        Me.Sarrow_Tabselector1.MainBackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Sarrow_Tabselector1.MainBorderColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Sarrow_Tabselector1.Name = "Sarrow_Tabselector1"
        Me.Sarrow_Tabselector1.Quality = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Me.Sarrow_Tabselector1.Size = New System.Drawing.Size(231, 527)
        Me.Sarrow_Tabselector1.Tabcontrol = Me.PlainTabcontrol1
        Me.Sarrow_Tabselector1.TabHeight = 36
        Me.Sarrow_Tabselector1.TabIndex = 0
        Me.Sarrow_Tabselector1.TabLabelHeight = 22
        TabLabel1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        TabLabel1.FontColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(143, Byte), Integer))
        TabLabel1.Index = 0
        TabLabel1.Text = "DASHBOARD"
        Me.Sarrow_Tabselector1.Tablabels.Add(TabLabel1)
        Tab1.BarColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(255, Byte), Integer))
        Tab1.Button = True
        Tab1.ButtonData = "UID=3452"
        Tab1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Tab1.FontColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Tab1.Hover = False
        Tab1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(22, Byte), Integer))
        Tab1.Icon = Nothing
        Tab1.Index = 0
        Tab1.Location = New System.Drawing.Point(0, 154)
        Tab1.NoteColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Tab1.NoteFont = New System.Drawing.Font("Arial", 9.0!)
        Tab1.NoteFontColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Tab1.NoteSelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Tab1.NoteSelectedFont = New System.Drawing.Font("Arial", 9.0!)
        Tab1.NoteSelectedFontColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Tab1.NoteText = "+ADD"
        Tab1.NoteVisible = True
        Tab1.NoteWidth = 57
        Tab1.Selected = True
        Tab1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(22, Byte), Integer))
        Tab1.SelectedFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Tab1.SelectedFontColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Tab1.SelectedIcon = Nothing
        Tab1.TabLabel = True
        Tab1.TabLabelIndex = 0
        Tab1.Text = "USERS"
        Tab2.BarColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(255, Byte), Integer))
        Tab2.Button = False
        Tab2.ButtonData = "ex:ADD=41223-PORT"
        Tab2.Font = New System.Drawing.Font("Arial", 12.0!)
        Tab2.FontColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Tab2.Hover = False
        Tab2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(22, Byte), Integer))
        Tab2.Icon = Nothing
        Tab2.Index = 1
        Tab2.Location = New System.Drawing.Point(0, 96)
        Tab2.NoteColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Tab2.NoteFont = New System.Drawing.Font("Arial", 9.0!)
        Tab2.NoteFontColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Tab2.NoteSelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Tab2.NoteSelectedFont = New System.Drawing.Font("Arial", 9.0!)
        Tab2.NoteSelectedFontColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Tab2.NoteText = "3"
        Tab2.NoteVisible = False
        Tab2.NoteWidth = 10
        Tab2.Selected = False
        Tab2.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(22, Byte), Integer))
        Tab2.SelectedFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Tab2.SelectedFontColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Tab2.SelectedIcon = Nothing
        Tab2.TabLabel = False
        Tab2.TabLabelIndex = 0
        Tab2.Text = "TabPage2"
        Me.Sarrow_Tabselector1.Tabs.Add(Tab1)
        Me.Sarrow_Tabselector1.Tabs.Add(Tab2)
        Me.Sarrow_Tabselector1.Text = "Sarrow_Tabselector1"
        Me.Sarrow_Tabselector1.UpdateTabs = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 527)
        Me.Controls.Add(Me.PlainTabcontrol1)
        Me.Controls.Add(Me.Sarrow_Tabselector1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.PlainTabcontrol1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Sarrow_Tabselector1 As Sarrow_Tabselector
    Friend WithEvents PlainTabcontrol1 As PlainTabcontrol
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents TabPage2 As TabPage
End Class
