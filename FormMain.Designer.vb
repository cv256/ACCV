<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.components = New System.ComponentModel.Container()
        Me.pictCar = New System.Windows.Forms.Panel()
        Me.btStart = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLaps = New System.Windows.Forms.TextBox()
        Me.btSetup = New System.Windows.Forms.Button()
        Me.pictTrack = New System.Windows.Forms.Panel()
        Me.lbTrack = New System.Windows.Forms.Label()
        Me.pictMap = New System.Windows.Forms.Panel()
        Me.cbGhost = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbCarName = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlOpponents = New System.Windows.Forms.Panel()
        Me.txtOpponents = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkExtraApps = New System.Windows.Forms.CheckBox()
        Me.chkPython = New System.Windows.Forms.CheckBox()
        Me.chkPenalties = New System.Windows.Forms.CheckBox()
        Me.chkTyresOut = New System.Windows.Forms.CheckBox()
        Me.btFav = New System.Windows.Forms.Button()
        Me.btReplays = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbWeather = New System.Windows.Forms.ComboBox()
        Me.cbTarmac = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkSaveGhost = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbPractice = New System.Windows.Forms.TabPage()
        Me.tbHot = New System.Windows.Forms.TabPage()
        Me.tbTime = New System.Windows.Forms.TabPage()
        Me.tbDrift = New System.Windows.Forms.TabPage()
        Me.tbRace = New System.Windows.Forms.TabPage()
        Me.lbRnd = New System.Windows.Forms.Label()
        Me.pictCar.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbTime.SuspendLayout()
        Me.tbRace.SuspendLayout()
        Me.SuspendLayout()
        '
        'pictCar
        '
        Me.pictCar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pictCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictCar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictCar.Controls.Add(Me.lbRnd)
        Me.pictCar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pictCar.Location = New System.Drawing.Point(0, 0)
        Me.pictCar.Name = "pictCar"
        Me.pictCar.Size = New System.Drawing.Size(618, 347)
        Me.pictCar.TabIndex = 0
        '
        'btStart
        '
        Me.btStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStart.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btStart.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btStart.Location = New System.Drawing.Point(847, 661)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(75, 23)
        Me.btStart.TabIndex = 1
        Me.btStart.Text = "START"
        Me.btStart.UseVisualStyleBackColor = False
        '
        'btClose
        '
        Me.btClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btClose.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btClose.ForeColor = System.Drawing.Color.DarkRed
        Me.btClose.Location = New System.Drawing.Point(928, 661)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 23)
        Me.btClose.TabIndex = 4
        Me.btClose.Text = "End"
        Me.btClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(10, 630)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Laps:"
        '
        'txtLaps
        '
        Me.txtLaps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtLaps.Location = New System.Drawing.Point(47, 627)
        Me.txtLaps.Name = "txtLaps"
        Me.txtLaps.Size = New System.Drawing.Size(25, 20)
        Me.txtLaps.TabIndex = 8
        Me.txtLaps.Text = "3"
        Me.txtLaps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btSetup
        '
        Me.btSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btSetup.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btSetup.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.btSetup.Location = New System.Drawing.Point(12, 661)
        Me.btSetup.Name = "btSetup"
        Me.btSetup.Size = New System.Drawing.Size(75, 23)
        Me.btSetup.TabIndex = 14
        Me.btSetup.Text = "Configure"
        Me.btSetup.UseVisualStyleBackColor = False
        '
        'pictTrack
        '
        Me.pictTrack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pictTrack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictTrack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictTrack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pictTrack.Location = New System.Drawing.Point(0, 370)
        Me.pictTrack.Name = "pictTrack"
        Me.pictTrack.Size = New System.Drawing.Size(356, 251)
        Me.pictTrack.TabIndex = 16
        '
        'lbTrack
        '
        Me.lbTrack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTrack.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lbTrack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTrack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbTrack.Location = New System.Drawing.Point(0, 356)
        Me.lbTrack.Name = "lbTrack"
        Me.lbTrack.Size = New System.Drawing.Size(618, 14)
        Me.lbTrack.TabIndex = 17
        Me.lbTrack.Text = "Track Name"
        Me.lbTrack.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pictMap
        '
        Me.pictMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pictMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictMap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pictMap.Location = New System.Drawing.Point(362, 370)
        Me.pictMap.Name = "pictMap"
        Me.pictMap.Size = New System.Drawing.Size(256, 251)
        Me.pictMap.TabIndex = 18
        '
        'cbGhost
        '
        Me.cbGhost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbGhost.DisplayMember = "Key"
        Me.cbGhost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGhost.FormattingEnabled = True
        Me.cbGhost.Location = New System.Drawing.Point(72, 5)
        Me.cbGhost.Name = "cbGhost"
        Me.cbGhost.Size = New System.Drawing.Size(296, 21)
        Me.cbGhost.Sorted = True
        Me.cbGhost.TabIndex = 32
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(0, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Show Ghost:"
        '
        'lbCarName
        '
        Me.lbCarName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbCarName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lbCarName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCarName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbCarName.Location = New System.Drawing.Point(0, -1)
        Me.lbCarName.Name = "lbCarName"
        Me.lbCarName.Size = New System.Drawing.Size(618, 14)
        Me.lbCarName.TabIndex = 5
        Me.lbCarName.Text = "Car Brand"
        Me.lbCarName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Opponents:"
        '
        'pnlOpponents
        '
        Me.pnlOpponents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlOpponents.AutoScroll = True
        Me.pnlOpponents.Location = New System.Drawing.Point(0, 24)
        Me.pnlOpponents.Name = "pnlOpponents"
        Me.pnlOpponents.Size = New System.Drawing.Size(374, 571)
        Me.pnlOpponents.TabIndex = 20
        '
        'txtOpponents
        '
        Me.txtOpponents.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOpponents.Location = New System.Drawing.Point(82, 2)
        Me.txtOpponents.MaxLength = 2
        Me.txtOpponents.Name = "txtOpponents"
        Me.txtOpponents.Size = New System.Drawing.Size(27, 20)
        Me.txtOpponents.TabIndex = 21
        Me.txtOpponents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 9000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'chkExtraApps
        '
        Me.chkExtraApps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkExtraApps.AutoSize = True
        Me.chkExtraApps.Location = New System.Drawing.Point(865, 630)
        Me.chkExtraApps.Name = "chkExtraApps"
        Me.chkExtraApps.Size = New System.Drawing.Size(77, 17)
        Me.chkExtraApps.TabIndex = 30
        Me.chkExtraApps.Text = "Extra Apps"
        Me.ToolTip1.SetToolTip(Me.chkExtraApps, "this enables extra Kunos applications, the list that appear on the right side dur" &
        "ing the game. They lower the performance of the game.")
        Me.chkExtraApps.UseVisualStyleBackColor = True
        '
        'chkPython
        '
        Me.chkPython.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPython.AutoSize = True
        Me.chkPython.Location = New System.Drawing.Point(948, 630)
        Me.chkPython.Name = "chkPython"
        Me.chkPython.Size = New System.Drawing.Size(59, 17)
        Me.chkPython.TabIndex = 34
        Me.chkPython.Text = "Python"
        Me.ToolTip1.SetToolTip(Me.chkPython, "this enables extra users (Python) applications, the list that appear on the right" &
        " side during the game. They lower the performance of the game.")
        Me.chkPython.UseVisualStyleBackColor = True
        '
        'chkPenalties
        '
        Me.chkPenalties.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPenalties.AutoSize = True
        Me.chkPenalties.Location = New System.Drawing.Point(657, 630)
        Me.chkPenalties.Name = "chkPenalties"
        Me.chkPenalties.Size = New System.Drawing.Size(69, 17)
        Me.chkPenalties.TabIndex = 22
        Me.chkPenalties.Text = "Penalties"
        Me.chkPenalties.UseVisualStyleBackColor = True
        '
        'chkTyresOut
        '
        Me.chkTyresOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTyresOut.AutoSize = True
        Me.chkTyresOut.Location = New System.Drawing.Point(733, 630)
        Me.chkTyresOut.Name = "chkTyresOut"
        Me.chkTyresOut.Size = New System.Drawing.Size(126, 17)
        Me.chkTyresOut.TabIndex = 23
        Me.chkTyresOut.Text = "Dont Allow Tyres Out"
        Me.chkTyresOut.UseVisualStyleBackColor = True
        '
        'btFav
        '
        Me.btFav.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFav.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btFav.ForeColor = System.Drawing.Color.DarkGreen
        Me.btFav.Location = New System.Drawing.Point(595, 661)
        Me.btFav.Name = "btFav"
        Me.btFav.Size = New System.Drawing.Size(75, 23)
        Me.btFav.TabIndex = 24
        Me.btFav.Text = "Favoritize"
        Me.btFav.UseVisualStyleBackColor = False
        '
        'btReplays
        '
        Me.btReplays.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btReplays.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btReplays.ForeColor = System.Drawing.Color.DarkGreen
        Me.btReplays.Location = New System.Drawing.Point(676, 661)
        Me.btReplays.Name = "btReplays"
        Me.btReplays.Size = New System.Drawing.Size(75, 23)
        Me.btReplays.TabIndex = 25
        Me.btReplays.Text = "Replays"
        Me.btReplays.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(91, 630)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Weather:"
        '
        'cbWeather
        '
        Me.cbWeather.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbWeather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWeather.FormattingEnabled = True
        Me.cbWeather.Location = New System.Drawing.Point(148, 627)
        Me.cbWeather.Name = "cbWeather"
        Me.cbWeather.Size = New System.Drawing.Size(105, 21)
        Me.cbWeather.Sorted = True
        Me.cbWeather.TabIndex = 27
        '
        'cbTarmac
        '
        Me.cbTarmac.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbTarmac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTarmac.FormattingEnabled = True
        Me.cbTarmac.Location = New System.Drawing.Point(322, 627)
        Me.cbTarmac.Name = "cbTarmac"
        Me.cbTarmac.Size = New System.Drawing.Size(93, 21)
        Me.cbTarmac.Sorted = True
        Me.cbTarmac.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(272, 630)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Tarmac:"
        '
        'chkSaveGhost
        '
        Me.chkSaveGhost.AutoSize = True
        Me.chkSaveGhost.Location = New System.Drawing.Point(72, 32)
        Me.chkSaveGhost.Name = "chkSaveGhost"
        Me.chkSaveGhost.Size = New System.Drawing.Size(82, 17)
        Me.chkSaveGhost.TabIndex = 31
        Me.chkSaveGhost.Text = "Save Ghost"
        Me.chkSaveGhost.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tbPractice)
        Me.TabControl1.Controls.Add(Me.tbHot)
        Me.TabControl1.Controls.Add(Me.tbTime)
        Me.TabControl1.Controls.Add(Me.tbDrift)
        Me.TabControl1.Controls.Add(Me.tbRace)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(76, 18)
        Me.TabControl1.Location = New System.Drawing.Point(620, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(383, 621)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 33
        '
        'tbPractice
        '
        Me.tbPractice.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tbPractice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPractice.ForeColor = System.Drawing.Color.Transparent
        Me.tbPractice.Location = New System.Drawing.Point(4, 22)
        Me.tbPractice.Name = "tbPractice"
        Me.tbPractice.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPractice.Size = New System.Drawing.Size(375, 595)
        Me.tbPractice.TabIndex = 0
        Me.tbPractice.Text = "Practice"
        '
        'tbHot
        '
        Me.tbHot.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tbHot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbHot.Location = New System.Drawing.Point(4, 22)
        Me.tbHot.Name = "tbHot"
        Me.tbHot.Padding = New System.Windows.Forms.Padding(3)
        Me.tbHot.Size = New System.Drawing.Size(375, 595)
        Me.tbHot.TabIndex = 1
        Me.tbHot.Text = "HotLap"
        '
        'tbTime
        '
        Me.tbTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tbTime.Controls.Add(Me.cbGhost)
        Me.tbTime.Controls.Add(Me.chkSaveGhost)
        Me.tbTime.Controls.Add(Me.Label5)
        Me.tbTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTime.Location = New System.Drawing.Point(4, 22)
        Me.tbTime.Name = "tbTime"
        Me.tbTime.Size = New System.Drawing.Size(375, 595)
        Me.tbTime.TabIndex = 2
        Me.tbTime.Text = "TimeAttack"
        '
        'tbDrift
        '
        Me.tbDrift.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tbDrift.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDrift.Location = New System.Drawing.Point(4, 22)
        Me.tbDrift.Name = "tbDrift"
        Me.tbDrift.Size = New System.Drawing.Size(375, 595)
        Me.tbDrift.TabIndex = 3
        Me.tbDrift.Text = "Drift"
        '
        'tbRace
        '
        Me.tbRace.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.tbRace.Controls.Add(Me.txtOpponents)
        Me.tbRace.Controls.Add(Me.Label4)
        Me.tbRace.Controls.Add(Me.pnlOpponents)
        Me.tbRace.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRace.Location = New System.Drawing.Point(4, 22)
        Me.tbRace.Name = "tbRace"
        Me.tbRace.Size = New System.Drawing.Size(375, 595)
        Me.tbRace.TabIndex = 4
        Me.tbRace.Text = "Race"
        '
        'lbRnd
        '
        Me.lbRnd.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lbRnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRnd.ForeColor = System.Drawing.Color.Navy
        Me.lbRnd.Location = New System.Drawing.Point(11, 20)
        Me.lbRnd.Name = "lbRnd"
        Me.lbRnd.Size = New System.Drawing.Size(30, 18)
        Me.lbRnd.TabIndex = 19
        Me.lbRnd.Text = "Rnd"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1004, 687)
        Me.Controls.Add(Me.chkPython)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.chkExtraApps)
        Me.Controls.Add(Me.cbTarmac)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbWeather)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btReplays)
        Me.Controls.Add(Me.btFav)
        Me.Controls.Add(Me.chkTyresOut)
        Me.Controls.Add(Me.chkPenalties)
        Me.Controls.Add(Me.pictMap)
        Me.Controls.Add(Me.lbTrack)
        Me.Controls.Add(Me.pictTrack)
        Me.Controls.Add(Me.btSetup)
        Me.Controls.Add(Me.txtLaps)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbCarName)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btStart)
        Me.Controls.Add(Me.pictCar)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "FormMain"
        Me.Text = "AC CV"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pictCar.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tbTime.ResumeLayout(False)
        Me.tbTime.PerformLayout()
        Me.tbRace.ResumeLayout(False)
        Me.tbRace.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictCar As Panel
    Friend WithEvents btStart As Button
    Friend WithEvents btClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLaps As TextBox
    Friend WithEvents btSetup As Button
    Friend WithEvents pictTrack As Panel
    Friend WithEvents lbTrack As Label
    Friend WithEvents pictMap As Panel
    Friend WithEvents lbCarName As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlOpponents As Panel
    Friend WithEvents txtOpponents As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents chkPenalties As CheckBox
    Friend WithEvents chkTyresOut As CheckBox
    Friend WithEvents btFav As Button
    Friend WithEvents btReplays As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cbWeather As ComboBox
    Friend WithEvents cbTarmac As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkExtraApps As CheckBox
    Friend WithEvents cbGhost As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chkSaveGhost As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbPractice As TabPage
    Friend WithEvents tbHot As TabPage
    Friend WithEvents tbTime As TabPage
    Friend WithEvents tbDrift As TabPage
    Friend WithEvents tbRace As TabPage
    Friend WithEvents chkPython As CheckBox
    Friend WithEvents lbRnd As Label
End Class
