<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFavorites
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHPFrom = New System.Windows.Forms.TextBox()
        Me.txtHPTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKgTo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKgFrom = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHPTonTo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHPTonFrom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSpeedTo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSpeedFrom = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAccelTo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAccelFrom = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtLikeTo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtLikeFrom = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCarText = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTrackText = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.delayedDrawHTML = New System.Windows.Forms.Timer(Me.components)
        Me.txtTrackLikeTo = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtTrackLikeFrom = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtLenTo = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtLenFrom = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btManage = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(174, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1182, 705)
        Me.WebBrowser1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Power >"
        '
        'txtHPFrom
        '
        Me.txtHPFrom.Location = New System.Drawing.Point(55, 178)
        Me.txtHPFrom.Name = "txtHPFrom"
        Me.txtHPFrom.Size = New System.Drawing.Size(30, 20)
        Me.txtHPFrom.TabIndex = 2
        Me.txtHPFrom.Text = "0"
        Me.txtHPFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHPTo
        '
        Me.txtHPTo.Location = New System.Drawing.Point(104, 178)
        Me.txtHPTo.Name = "txtHPTo"
        Me.txtHPTo.Size = New System.Drawing.Size(38, 20)
        Me.txtHPTo.TabIndex = 4
        Me.txtHPTo.Text = "?"
        Me.txtHPTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(88, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "<"
        '
        'txtKgTo
        '
        Me.txtKgTo.Location = New System.Drawing.Point(104, 201)
        Me.txtKgTo.Name = "txtKgTo"
        Me.txtKgTo.Size = New System.Drawing.Size(38, 20)
        Me.txtKgTo.TabIndex = 8
        Me.txtKgTo.Text = "?"
        Me.txtKgTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(88, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "<"
        '
        'txtKgFrom
        '
        Me.txtKgFrom.Location = New System.Drawing.Point(55, 201)
        Me.txtKgFrom.Name = "txtKgFrom"
        Me.txtKgFrom.Size = New System.Drawing.Size(30, 20)
        Me.txtKgFrom.TabIndex = 6
        Me.txtKgFrom.Text = "0"
        Me.txtKgFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Weight >"
        '
        'txtHPTonTo
        '
        Me.txtHPTonTo.Location = New System.Drawing.Point(104, 224)
        Me.txtHPTonTo.Name = "txtHPTonTo"
        Me.txtHPTonTo.Size = New System.Drawing.Size(38, 20)
        Me.txtHPTonTo.TabIndex = 12
        Me.txtHPTonTo.Text = "?"
        Me.txtHPTonTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(88, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "<"
        '
        'txtHPTonFrom
        '
        Me.txtHPTonFrom.Location = New System.Drawing.Point(55, 224)
        Me.txtHPTonFrom.Name = "txtHPTonFrom"
        Me.txtHPTonFrom.Size = New System.Drawing.Size(30, 20)
        Me.txtHPTonFrom.TabIndex = 10
        Me.txtHPTonFrom.Text = "0"
        Me.txtHPTonFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 227)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "HP/Ton >"
        '
        'txtSpeedTo
        '
        Me.txtSpeedTo.Location = New System.Drawing.Point(104, 270)
        Me.txtSpeedTo.Name = "txtSpeedTo"
        Me.txtSpeedTo.Size = New System.Drawing.Size(38, 20)
        Me.txtSpeedTo.TabIndex = 20
        Me.txtSpeedTo.Text = "?"
        Me.txtSpeedTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(88, 273)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "<"
        '
        'txtSpeedFrom
        '
        Me.txtSpeedFrom.Location = New System.Drawing.Point(55, 270)
        Me.txtSpeedFrom.Name = "txtSpeedFrom"
        Me.txtSpeedFrom.Size = New System.Drawing.Size(30, 20)
        Me.txtSpeedFrom.TabIndex = 18
        Me.txtSpeedFrom.Text = "0"
        Me.txtSpeedFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 273)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Speed >"
        '
        'txtAccelTo
        '
        Me.txtAccelTo.Location = New System.Drawing.Point(104, 247)
        Me.txtAccelTo.Name = "txtAccelTo"
        Me.txtAccelTo.Size = New System.Drawing.Size(38, 20)
        Me.txtAccelTo.TabIndex = 16
        Me.txtAccelTo.Text = "?"
        Me.txtAccelTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(88, 250)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "<"
        '
        'txtAccelFrom
        '
        Me.txtAccelFrom.Location = New System.Drawing.Point(55, 247)
        Me.txtAccelFrom.Name = "txtAccelFrom"
        Me.txtAccelFrom.Size = New System.Drawing.Size(30, 20)
        Me.txtAccelFrom.TabIndex = 14
        Me.txtAccelFrom.Text = "0"
        Me.txtAccelFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 250)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "0-100 >"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(146, 273)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Km/h"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(146, 250)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "s"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(146, 204)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 13)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Kg"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(146, 181)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "HP"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(3, 316)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(167, 388)
        Me.Panel1.TabIndex = 26
        '
        'txtLikeTo
        '
        Me.txtLikeTo.Location = New System.Drawing.Point(104, 292)
        Me.txtLikeTo.Name = "txtLikeTo"
        Me.txtLikeTo.Size = New System.Drawing.Size(22, 20)
        Me.txtLikeTo.TabIndex = 30
        Me.txtLikeTo.Text = "10"
        Me.txtLikeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(88, 295)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "<"
        '
        'txtLikeFrom
        '
        Me.txtLikeFrom.Location = New System.Drawing.Point(63, 292)
        Me.txtLikeFrom.Name = "txtLikeFrom"
        Me.txtLikeFrom.Size = New System.Drawing.Size(22, 20)
        Me.txtLikeFrom.TabIndex = 28
        Me.txtLikeFrom.Text = "0"
        Me.txtLikeFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 295)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Like >"
        '
        'txtCarText
        '
        Me.txtCarText.Location = New System.Drawing.Point(55, 155)
        Me.txtCarText.MaxLength = 30
        Me.txtCarText.Name = "txtCarText"
        Me.txtCarText.Size = New System.Drawing.Size(113, 20)
        Me.txtCarText.TabIndex = 32
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 158)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Text:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 139)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(135, 13)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Filter Favorites by Car:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 46)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(149, 13)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "Filter Favorites by Track:"
        '
        'txtTrackText
        '
        Me.txtTrackText.Location = New System.Drawing.Point(55, 63)
        Me.txtTrackText.MaxLength = 30
        Me.txtTrackText.Name = "txtTrackText"
        Me.txtTrackText.Size = New System.Drawing.Size(113, 20)
        Me.txtTrackText.TabIndex = 38
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Text:"
        '
        'delayedDrawHTML
        '
        Me.delayedDrawHTML.Interval = 600
        '
        'txtTrackLikeTo
        '
        Me.txtTrackLikeTo.Location = New System.Drawing.Point(112, 109)
        Me.txtTrackLikeTo.Name = "txtTrackLikeTo"
        Me.txtTrackLikeTo.Size = New System.Drawing.Size(22, 20)
        Me.txtTrackLikeTo.TabIndex = 48
        Me.txtTrackLikeTo.Text = "10"
        Me.txtTrackLikeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(96, 112)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(13, 13)
        Me.Label21.TabIndex = 47
        Me.Label21.Text = "<"
        '
        'txtTrackLikeFrom
        '
        Me.txtTrackLikeFrom.Location = New System.Drawing.Point(73, 109)
        Me.txtTrackLikeFrom.Name = "txtTrackLikeFrom"
        Me.txtTrackLikeFrom.Size = New System.Drawing.Size(22, 20)
        Me.txtTrackLikeFrom.TabIndex = 46
        Me.txtTrackLikeFrom.Text = "0"
        Me.txtTrackLikeFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 112)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(36, 13)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Like >"
        '
        'txtLenTo
        '
        Me.txtLenTo.Location = New System.Drawing.Point(112, 86)
        Me.txtLenTo.Name = "txtLenTo"
        Me.txtLenTo.Size = New System.Drawing.Size(43, 20)
        Me.txtLenTo.TabIndex = 44
        Me.txtLenTo.Text = "9999"
        Me.txtLenTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(96, 89)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(13, 13)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "<"
        '
        'txtLenFrom
        '
        Me.txtLenFrom.Location = New System.Drawing.Point(55, 86)
        Me.txtLenFrom.Name = "txtLenFrom"
        Me.txtLenFrom.Size = New System.Drawing.Size(40, 20)
        Me.txtLenFrom.TabIndex = 42
        Me.txtLenFrom.Text = "0"
        Me.txtLenFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 89)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 13)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "KMs >"
        '
        'btSave
        '
        Me.btSave.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btSave.ForeColor = System.Drawing.Color.DarkRed
        Me.btSave.Location = New System.Drawing.Point(26, 0)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(124, 21)
        Me.btSave.TabIndex = 49
        Me.btSave.Text = "Save Current Set"
        Me.btSave.UseVisualStyleBackColor = False
        '
        'btManage
        '
        Me.btManage.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btManage.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btManage.Location = New System.Drawing.Point(26, 19)
        Me.btManage.Name = "btManage"
        Me.btManage.Size = New System.Drawing.Size(124, 21)
        Me.btManage.TabIndex = 50
        Me.btManage.Text = "Manage Favoritizeds"
        Me.btManage.UseVisualStyleBackColor = False
        '
        'FormFavorites
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1356, 705)
        Me.Controls.Add(Me.btManage)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.txtTrackLikeTo)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtTrackLikeFrom)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtLenTo)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtLenFrom)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtTrackText)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtCarText)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtLikeTo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtLikeFrom)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSpeedTo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSpeedFrom)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAccelTo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtAccelFrom)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtHPTonTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtHPTonFrom)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtKgTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtKgFrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtHPTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHPFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Label11)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "FormFavorites"
        Me.Text = "AC CV Favorites"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Label1 As Label
    Friend WithEvents txtHPFrom As TextBox
    Friend WithEvents txtHPTo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtKgTo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtKgFrom As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtHPTonTo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtHPTonFrom As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSpeedTo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSpeedFrom As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAccelTo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAccelFrom As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtLikeTo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtLikeFrom As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCarText As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtTrackText As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents delayedDrawHTML As Timer
    Friend WithEvents txtTrackLikeTo As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtTrackLikeFrom As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtLenTo As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtLenFrom As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents btSave As Button
    Friend WithEvents btManage As Button
End Class
