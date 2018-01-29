<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormChangeMod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormChangeMod))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btSetup = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbPath = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btCalcZ = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btCalcY = New System.Windows.Forms.Button()
        Me.btCalcRotation = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tSpringRateRear = New AC_CV.TextBoxNumeric()
        Me.tSpringRateFront = New AC_CV.TextBoxNumeric()
        Me.tBumpSpringRateRear = New AC_CV.TextBoxNumeric()
        Me.tBumpSpringRateFront = New AC_CV.TextBoxNumeric()
        Me.tHubRear = New AC_CV.TextBoxNumeric()
        Me.tHubFront = New AC_CV.TextBoxNumeric()
        Me.tTotalmass = New AC_CV.TextBoxNumeric()
        Me.tWheelbase = New AC_CV.TextBoxNumeric()
        Me.tZ = New AC_CV.TextBoxNumeric()
        Me.tCGLocation = New AC_CV.TextBoxNumeric()
        Me.tArbRear = New AC_CV.TextBoxNumeric()
        Me.tArbFront = New AC_CV.TextBoxNumeric()
        Me.tRotation = New AC_CV.TextBoxNumeric()
        Me.tY = New AC_CV.TextBoxNumeric()
        Me.tBaseyRear = New AC_CV.TextBoxNumeric()
        Me.tBaseyFront = New AC_CV.TextBoxNumeric()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Front:"
        '
        'btSetup
        '
        Me.btSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSetup.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.btSetup.Location = New System.Drawing.Point(498, 416)
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
        Me.btClose.Location = New System.Drawing.Point(579, 416)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 23)
        Me.btClose.TabIndex = 15
        Me.btClose.Text = "Cancel"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Rear:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "BaseY:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(250, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(408, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "vertical meters between the center of the wheel and the center of the mass of the" &
    " car"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(62, 267)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Drawing Y:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(322, 267)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(188, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "push the car drawing down this meters"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(62, 291)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Drawing Rotation:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(322, 291)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(159, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "front down, rear up, this degrees"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(250, 388)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "...."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(62, 388)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Anti-roll bar:"
        '
        'lbPath
        '
        Me.lbPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbPath.AutoSize = True
        Me.lbPath.BackColor = System.Drawing.Color.Transparent
        Me.lbPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPath.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbPath.Location = New System.Drawing.Point(12, 421)
        Me.lbPath.Name = "lbPath"
        Me.lbPath.Size = New System.Drawing.Size(28, 13)
        Me.lbPath.TabIndex = 33
        Me.lbPath.Text = "path"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(250, 163)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(156, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "% weight distribution to the front"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(62, 163)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "% CG front :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(322, 243)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(183, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "push the car drawing front this meters"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(62, 243)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Drawing Z:"
        '
        'btCalcZ
        '
        Me.btCalcZ.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btCalcZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCalcZ.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btCalcZ.Location = New System.Drawing.Point(253, 240)
        Me.btCalcZ.Name = "btCalcZ"
        Me.btCalcZ.Size = New System.Drawing.Size(63, 20)
        Me.btCalcZ.TabIndex = 40
        Me.btCalcZ.Text = "Calculate"
        Me.btCalcZ.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.LemonChiffon
        Me.Label15.Location = New System.Drawing.Point(10, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(784, 13)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = resources.GetString("Label15.Text")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.LemonChiffon
        Me.Label16.Location = New System.Drawing.Point(10, 216)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(744, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = resources.GetString("Label16.Text")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.LemonChiffon
        Me.Label17.Location = New System.Drawing.Point(10, 320)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(752, 13)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = resources.GetString("Label17.Text")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(250, 139)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(350, 13)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "meters between the middle of the front tyre and the middle of the rear tyre"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(62, 139)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "Wheelbase :"
        '
        'btCalcY
        '
        Me.btCalcY.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btCalcY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCalcY.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btCalcY.Location = New System.Drawing.Point(253, 264)
        Me.btCalcY.Name = "btCalcY"
        Me.btCalcY.Size = New System.Drawing.Size(63, 20)
        Me.btCalcY.TabIndex = 47
        Me.btCalcY.Text = "Calculate"
        Me.btCalcY.UseVisualStyleBackColor = False
        '
        'btCalcRotation
        '
        Me.btCalcRotation.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btCalcRotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCalcRotation.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btCalcRotation.Location = New System.Drawing.Point(253, 288)
        Me.btCalcRotation.Name = "btCalcRotation"
        Me.btCalcRotation.Size = New System.Drawing.Size(63, 20)
        Me.btCalcRotation.TabIndex = 48
        Me.btCalcRotation.Text = "Calculate"
        Me.btCalcRotation.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(250, 92)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(20, 13)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "Kg"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(62, 92)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Total Mass :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(250, 116)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(247, 13)
        Me.Label22.TabIndex = 55
        Me.Label22.Text = "Kg of each wheel and suspension (unsprung mass)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(62, 116)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 13)
        Me.Label23.TabIndex = 52
        Me.Label23.Text = "Hub Mass:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(250, 364)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(19, 13)
        Me.Label24.TabIndex = 59
        Me.Label24.Text = "...."
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(13, 364)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(118, 13)
        Me.Label25.TabIndex = 56
        Me.Label25.Text = "BumpStop Spring Rate:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(250, 341)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(19, 13)
        Me.Label26.TabIndex = 63
        Me.Label26.Text = "...."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(62, 341)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(69, 13)
        Me.Label27.TabIndex = 60
        Me.Label27.Text = "Spring Rate :"
        '
        'tSpringRateRear
        '
        Me.tSpringRateRear.Location = New System.Drawing.Point(198, 338)
        Me.tSpringRateRear.Mask = ""
        Me.tSpringRateRear.MaxValue = 3.402823E+38!
        Me.tSpringRateRear.MinValue = -3.402823E+38!
        Me.tSpringRateRear.Name = "tSpringRateRear"
        Me.tSpringRateRear.Size = New System.Drawing.Size(52, 20)
        Me.tSpringRateRear.TabIndex = 62
        Me.tSpringRateRear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tSpringRateFront
        '
        Me.tSpringRateFront.Location = New System.Drawing.Point(135, 338)
        Me.tSpringRateFront.Mask = ""
        Me.tSpringRateFront.MaxValue = 999999.0!
        Me.tSpringRateFront.MinValue = -999999.0!
        Me.tSpringRateFront.Name = "tSpringRateFront"
        Me.tSpringRateFront.Size = New System.Drawing.Size(52, 20)
        Me.tSpringRateFront.TabIndex = 61
        Me.tSpringRateFront.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tBumpSpringRateRear
        '
        Me.tBumpSpringRateRear.Location = New System.Drawing.Point(198, 361)
        Me.tBumpSpringRateRear.Mask = ""
        Me.tBumpSpringRateRear.MaxValue = 3.402823E+38!
        Me.tBumpSpringRateRear.MinValue = -3.402823E+38!
        Me.tBumpSpringRateRear.Name = "tBumpSpringRateRear"
        Me.tBumpSpringRateRear.Size = New System.Drawing.Size(52, 20)
        Me.tBumpSpringRateRear.TabIndex = 58
        Me.tBumpSpringRateRear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tBumpSpringRateFront
        '
        Me.tBumpSpringRateFront.Location = New System.Drawing.Point(135, 361)
        Me.tBumpSpringRateFront.Mask = ""
        Me.tBumpSpringRateFront.MaxValue = 999999.0!
        Me.tBumpSpringRateFront.MinValue = -999999.0!
        Me.tBumpSpringRateFront.Name = "tBumpSpringRateFront"
        Me.tBumpSpringRateFront.Size = New System.Drawing.Size(52, 20)
        Me.tBumpSpringRateFront.TabIndex = 57
        Me.tBumpSpringRateFront.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tHubRear
        '
        Me.tHubRear.Location = New System.Drawing.Point(213, 113)
        Me.tHubRear.Mask = ""
        Me.tHubRear.MaxValue = 1000.0!
        Me.tHubRear.MinValue = 0!
        Me.tHubRear.Name = "tHubRear"
        Me.tHubRear.Size = New System.Drawing.Size(37, 20)
        Me.tHubRear.TabIndex = 54
        Me.tHubRear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tHubFront
        '
        Me.tHubFront.Location = New System.Drawing.Point(135, 113)
        Me.tHubFront.Mask = ""
        Me.tHubFront.MaxValue = 1000.0!
        Me.tHubFront.MinValue = 0!
        Me.tHubFront.Name = "tHubFront"
        Me.tHubFront.Size = New System.Drawing.Size(37, 20)
        Me.tHubFront.TabIndex = 53
        Me.tHubFront.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tTotalmass
        '
        Me.tTotalmass.Location = New System.Drawing.Point(174, 89)
        Me.tTotalmass.Mask = ""
        Me.tTotalmass.MaxValue = 30000.0!
        Me.tTotalmass.MinValue = 0!
        Me.tTotalmass.Name = "tTotalmass"
        Me.tTotalmass.Size = New System.Drawing.Size(37, 20)
        Me.tTotalmass.TabIndex = 50
        Me.tTotalmass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tWheelbase
        '
        Me.tWheelbase.Location = New System.Drawing.Point(174, 136)
        Me.tWheelbase.Mask = "0.00"
        Me.tWheelbase.MaxValue = 100.0!
        Me.tWheelbase.MinValue = 0!
        Me.tWheelbase.Name = "tWheelbase"
        Me.tWheelbase.Size = New System.Drawing.Size(37, 20)
        Me.tWheelbase.TabIndex = 45
        Me.tWheelbase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tZ
        '
        Me.tZ.Location = New System.Drawing.Point(174, 240)
        Me.tZ.Mask = "0.00"
        Me.tZ.MaxValue = 100.0!
        Me.tZ.MinValue = -100.0!
        Me.tZ.Name = "tZ"
        Me.tZ.Size = New System.Drawing.Size(37, 20)
        Me.tZ.TabIndex = 38
        Me.tZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tCGLocation
        '
        Me.tCGLocation.Location = New System.Drawing.Point(174, 160)
        Me.tCGLocation.Mask = "0.00"
        Me.tCGLocation.MaxValue = 100.0!
        Me.tCGLocation.MinValue = 0!
        Me.tCGLocation.Name = "tCGLocation"
        Me.tCGLocation.Size = New System.Drawing.Size(37, 20)
        Me.tCGLocation.TabIndex = 35
        Me.tCGLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tArbRear
        '
        Me.tArbRear.Location = New System.Drawing.Point(198, 385)
        Me.tArbRear.Mask = ""
        Me.tArbRear.MaxValue = 3.402823E+38!
        Me.tArbRear.MinValue = -3.402823E+38!
        Me.tArbRear.Name = "tArbRear"
        Me.tArbRear.Size = New System.Drawing.Size(52, 20)
        Me.tArbRear.TabIndex = 31
        Me.tArbRear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tArbFront
        '
        Me.tArbFront.Location = New System.Drawing.Point(135, 385)
        Me.tArbFront.Mask = ""
        Me.tArbFront.MaxValue = 999999.0!
        Me.tArbFront.MinValue = -999999.0!
        Me.tArbFront.Name = "tArbFront"
        Me.tArbFront.Size = New System.Drawing.Size(52, 20)
        Me.tArbFront.TabIndex = 30
        Me.tArbFront.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tRotation
        '
        Me.tRotation.Location = New System.Drawing.Point(174, 288)
        Me.tRotation.Mask = ""
        Me.tRotation.MaxValue = 100.0!
        Me.tRotation.MinValue = -100.0!
        Me.tRotation.Name = "tRotation"
        Me.tRotation.Size = New System.Drawing.Size(37, 20)
        Me.tRotation.TabIndex = 24
        Me.tRotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tY
        '
        Me.tY.Location = New System.Drawing.Point(174, 264)
        Me.tY.Mask = "0.00"
        Me.tY.MaxValue = 100.0!
        Me.tY.MinValue = -100.0!
        Me.tY.Name = "tY"
        Me.tY.Size = New System.Drawing.Size(37, 20)
        Me.tY.TabIndex = 23
        Me.tY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tBaseyRear
        '
        Me.tBaseyRear.Location = New System.Drawing.Point(213, 184)
        Me.tBaseyRear.Mask = "0.00"
        Me.tBaseyRear.MaxValue = 100.0!
        Me.tBaseyRear.MinValue = -100.0!
        Me.tBaseyRear.Name = "tBaseyRear"
        Me.tBaseyRear.Size = New System.Drawing.Size(37, 20)
        Me.tBaseyRear.TabIndex = 20
        Me.tBaseyRear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tBaseyFront
        '
        Me.tBaseyFront.Location = New System.Drawing.Point(135, 184)
        Me.tBaseyFront.Mask = "0.00"
        Me.tBaseyFront.MaxValue = 100.0!
        Me.tBaseyFront.MinValue = -100.0!
        Me.tBaseyFront.Name = "tBaseyFront"
        Me.tBaseyFront.Size = New System.Drawing.Size(37, 20)
        Me.tBaseyFront.TabIndex = 19
        Me.tBaseyFront.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.ForeColor = System.Drawing.Color.Navy
        Me.Label28.Location = New System.Drawing.Point(-2, 2)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(669, 45)
        Me.Label28.TabIndex = 64
        Me.Label28.Text = resources.GetString("Label28.Text")
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormChangeMod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(666, 442)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.tSpringRateRear)
        Me.Controls.Add(Me.tSpringRateFront)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.tBumpSpringRateRear)
        Me.Controls.Add(Me.tBumpSpringRateFront)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.tHubRear)
        Me.Controls.Add(Me.tHubFront)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.tTotalmass)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.btCalcRotation)
        Me.Controls.Add(Me.btCalcY)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.tWheelbase)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btCalcZ)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tZ)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tCGLocation)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lbPath)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tArbRear)
        Me.Controls.Add(Me.tArbFront)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tRotation)
        Me.Controls.Add(Me.tY)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tBaseyRear)
        Me.Controls.Add(Me.tBaseyFront)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btSetup)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "FormChangeMod"
        Me.Text = "AC CV Change MOD"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btSetup As Button
    Friend WithEvents btClose As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tBaseyFront As TextBoxNumeric
    Friend WithEvents tBaseyRear As TextBoxNumeric
    Friend WithEvents Label4 As Label
    Friend WithEvents tRotation As TextBoxNumeric
    Friend WithEvents tY As TextBoxNumeric
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tArbRear As TextBoxNumeric
    Friend WithEvents tArbFront As TextBoxNumeric
    Friend WithEvents Label10 As Label
    Friend WithEvents lbPath As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents tCGLocation As TextBoxNumeric
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents tZ As TextBoxNumeric
    Friend WithEvents Label14 As Label
    Friend WithEvents btCalcZ As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents tWheelbase As TextBoxNumeric
    Friend WithEvents Label19 As Label
    Friend WithEvents btCalcY As Button
    Friend WithEvents btCalcRotation As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents tTotalmass As TextBoxNumeric
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents tHubRear As TextBoxNumeric
    Friend WithEvents tHubFront As TextBoxNumeric
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents tBumpSpringRateRear As TextBoxNumeric
    Friend WithEvents tBumpSpringRateFront As TextBoxNumeric
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents tSpringRateRear As TextBoxNumeric
    Friend WithEvents tSpringRateFront As TextBoxNumeric
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
End Class
