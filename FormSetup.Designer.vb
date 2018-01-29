<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSetup))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtACFolder = New System.Windows.Forms.TextBox()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.lbVersion = New System.Windows.Forms.Label()
        Me.btSetup = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.txtFontSize = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lnkINI = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tZ = New System.Windows.Forms.TrackBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tY = New System.Windows.Forms.TrackBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tX = New System.Windows.Forms.TrackBar()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tS = New System.Windows.Forms.TrackBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tSkids = New System.Windows.Forms.TrackBar()
        CType(Me.tZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tSkids, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Assetto Corsa Folder:"
        '
        'txtACFolder
        '
        Me.txtACFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtACFolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtACFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtACFolder.Location = New System.Drawing.Point(153, 10)
        Me.txtACFolder.Name = "txtACFolder"
        Me.txtACFolder.Size = New System.Drawing.Size(789, 20)
        Me.txtACFolder.TabIndex = 1
        '
        'lbInfo
        '
        Me.lbInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbInfo.ForeColor = System.Drawing.Color.Aqua
        Me.lbInfo.Location = New System.Drawing.Point(12, 527)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(851, 13)
        Me.lbInfo.TabIndex = 2
        Me.lbInfo.Text = "info"
        '
        'lbVersion
        '
        Me.lbVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbVersion.ForeColor = System.Drawing.Color.Aqua
        Me.lbVersion.Location = New System.Drawing.Point(840, 527)
        Me.lbVersion.Name = "lbVersion"
        Me.lbVersion.Size = New System.Drawing.Size(102, 13)
        Me.lbVersion.TabIndex = 3
        Me.lbVersion.Text = "version"
        Me.lbVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btSetup
        '
        Me.btSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSetup.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.btSetup.Location = New System.Drawing.Point(786, 499)
        Me.btSetup.Name = "btSetup"
        Me.btSetup.Size = New System.Drawing.Size(75, 23)
        Me.btSetup.TabIndex = 16
        Me.btSetup.Text = "Save"
        Me.btSetup.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btClose.ForeColor = System.Drawing.Color.DarkRed
        Me.btClose.Location = New System.Drawing.Point(867, 499)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 23)
        Me.btClose.TabIndex = 15
        Me.btClose.Text = "Cancel"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'txtFontSize
        '
        Me.txtFontSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtFontSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtFontSize.Location = New System.Drawing.Point(153, 40)
        Me.txtFontSize.MaxLength = 2
        Me.txtFontSize.Name = "txtFontSize"
        Me.txtFontSize.Size = New System.Drawing.Size(35, 20)
        Me.txtFontSize.TabIndex = 18
        Me.txtFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Font Size for lists on AC CV:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(194, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "pt"
        '
        'lnkINI
        '
        Me.lnkINI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkINI.AutoSize = True
        Me.lnkINI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkINI.ForeColor = System.Drawing.Color.Black
        Me.lnkINI.Location = New System.Drawing.Point(120, 468)
        Me.lnkINI.Name = "lnkINI"
        Me.lnkINI.Size = New System.Drawing.Size(83, 16)
        Me.lnkINI.TabIndex = 20
        Me.lnkINI.TabStop = True
        Me.lnkINI.Text = "LinkLabel1"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 470)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "AC CV Configuration:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.ForeColor = System.Drawing.Color.Aqua
        Me.Label5.Location = New System.Drawing.Point(10, 487)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(768, 33)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'tZ
        '
        Me.tZ.LargeChange = 1
        Me.tZ.Location = New System.Drawing.Point(144, 92)
        Me.tZ.Maximum = 35
        Me.tZ.Name = "tZ"
        Me.tZ.Size = New System.Drawing.Size(256, 45)
        Me.tZ.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "on Accelerate/Brake:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(28, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "on Bumps/Holes:"
        '
        'tY
        '
        Me.tY.LargeChange = 1
        Me.tY.Location = New System.Drawing.Point(144, 130)
        Me.tY.Maximum = 35
        Me.tY.Name = "tY"
        Me.tY.Size = New System.Drawing.Size(256, 45)
        Me.tY.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(28, 171)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "on Turning:"
        '
        'tX
        '
        Me.tX.LargeChange = 1
        Me.tX.Location = New System.Drawing.Point(144, 168)
        Me.tX.Maximum = 35
        Me.tX.Name = "tX"
        Me.tX.Size = New System.Drawing.Size(256, 45)
        Me.tX.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Move driver's head:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "shivering on Speed:"
        '
        'tS
        '
        Me.tS.LargeChange = 1
        Me.tS.Location = New System.Drawing.Point(144, 207)
        Me.tS.Maximum = 30
        Me.tS.Name = "tS"
        Me.tS.Size = New System.Drawing.Size(256, 45)
        Me.tS.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label8.Location = New System.Drawing.Point(451, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(488, 354)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Any donation would... wow... make my day..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "not specifically for the money, bu" &
    "t because" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "that would be really nice and correct" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and would motivate me to do mo" &
    "re" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "cv256@hotmail.com" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ":-)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(28, 251)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 13)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Skid sound entry point"
        '
        'tSkids
        '
        Me.tSkids.LargeChange = 1
        Me.tSkids.Location = New System.Drawing.Point(144, 247)
        Me.tSkids.Maximum = 200
        Me.tSkids.Minimum = 2
        Me.tSkids.Name = "tSkids"
        Me.tSkids.Size = New System.Drawing.Size(256, 45)
        Me.tSkids.TabIndex = 37
        Me.tSkids.TickFrequency = 5
        Me.tSkids.Value = 2
        '
        'FormSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(954, 547)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tSkids)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tS)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tX)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tY)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tZ)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lnkINI)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFontSize)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btSetup)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.lbVersion)
        Me.Controls.Add(Me.lbInfo)
        Me.Controls.Add(Me.txtACFolder)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "FormSetup"
        Me.Text = "AC CV Configure"
        CType(Me.tZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tSkids, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtACFolder As TextBox
    Friend WithEvents lbInfo As Label
    Friend WithEvents lbVersion As Label
    Friend WithEvents btSetup As Button
    Friend WithEvents btClose As Button
    Friend WithEvents txtFontSize As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lnkINI As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tZ As TrackBar
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tY As TrackBar
    Friend WithEvents Label11 As Label
    Friend WithEvents tX As TrackBar
    Friend WithEvents Label12 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tS As TrackBar
    Friend WithEvents Label8 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents tSkids As TrackBar
End Class
