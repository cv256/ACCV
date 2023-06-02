Public Class FormChangeMod
    Dim car As Car

    Dim tmpDrawingZ As Single, tmpDrawingY As Single

    'Private Sub Button2_Click(sender As Object, e As EventArgs)
    '    Shell(ACPath & $"\sdk\dev\ksSusEditor\knSusEditor.exe ""{lbPath.Text}""", AppWinStyle.MaximizedFocus)
    'End Sub


    'Private Const FirstStep As String = "First set  CG_LOCATION=0.5  and all  Spring_Rates=999999  and visually set   DrawingY and DrawingZ  until the picture of the car looks horizontaly correct, but tires are apart from the car as if they were suspended, like when you lift up the car for changing the tires. Save this values of  DrawingY and DrawingZ  you will need them for some calculations, they are the default offsets."

    Private Sub lbPath_Click(sender As Object, e As EventArgs) Handles lbPath.Click
        Shell($"Explorer.exe ""{lbPath.Text}""", AppWinStyle.NormalFocus)
    End Sub

    Public Sub Init(pCar As Car)
        car = pCar
        With car
            Me.Text &= "   " & .Name
            lbPath.Text = .Path
            Dim errors As String = ""

            Dim tmpIni As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            tmpIni.Load(.Path & "\data\suspensions.ini")
            Dim hubFront As Single, hubRear As Single
            Dim baseyFront As Single, baseyRear As Single
            Dim arbFront As Single, arbRear As Single
            Dim cgLocation As Single, wheelbase As Single
            Dim springRateFront As Single, springRateRear As Single, bumpSpringRateFront As Single, bumpSpringRateRear As Single
            errors &= tWheelbase.ValidateNumber(tmpIni.Value("BASIC", "WHEELBASE"), wheelbase, Globalization.CultureInfo.InvariantCulture)
            errors &= tCGLocation.ValidateNumber(tmpIni.Value("BASIC", "CG_LOCATION"), cgLocation, Globalization.CultureInfo.InvariantCulture)
            errors &= tBaseyFront.ValidateNumber(tmpIni.Value("FRONT", "BASEY"), baseyFront, Globalization.CultureInfo.InvariantCulture)
            errors &= tBaseyRear.ValidateNumber(tmpIni.Value("REAR", "BASEY"), baseyRear, Globalization.CultureInfo.InvariantCulture)
            errors &= tHubFront.ValidateNumber(tmpIni.Value("FRONT", "HUB_MASS"), hubFront, Globalization.CultureInfo.InvariantCulture)
            errors &= tHubRear.ValidateNumber(tmpIni.Value("REAR", "HUB_MASS"), hubRear, Globalization.CultureInfo.InvariantCulture)
            errors &= tArbFront.ValidateNumber(tmpIni.Value("ARB", "FRONT"), arbFront, Globalization.CultureInfo.InvariantCulture)
            errors &= tArbRear.ValidateNumber(tmpIni.Value("ARB", "REAR"), arbRear, Globalization.CultureInfo.InvariantCulture)
            errors &= tSpringRateFront.ValidateNumber(tmpIni.Value("FRONT", "SPRING_RATE"), springRateFront, Globalization.CultureInfo.InvariantCulture)
            errors &= tSpringRateRear.ValidateNumber(tmpIni.Value("REAR", "SPRING_RATE"), springRateRear, Globalization.CultureInfo.InvariantCulture)
            errors &= tBumpSpringRateFront.ValidateNumber(tmpIni.Value("FRONT", "BUMP_STOP_RATE"), bumpSpringRateFront, Globalization.CultureInfo.InvariantCulture)
            errors &= tBumpSpringRateRear.ValidateNumber(tmpIni.Value("REAR", "BUMP_STOP_RATE"), bumpSpringRateRear, Globalization.CultureInfo.InvariantCulture)

            tmpIni = New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            tmpIni.Load(.Path & "\data\car.ini")
            Dim totalmass As Single, y As Single, z As Single, rotation As Single
            Dim tmp As String = tmpIni.Value("BASIC", "GRAPHICS_OFFSET")
            Dim tmpArr As String() = tmp.Split(","c) ' (x,y,z)
            errors &= tY.ValidateNumber(tmpArr(1), y, Globalization.CultureInfo.InvariantCulture)
            errors &= tZ.ValidateNumber(tmpArr(2), z, Globalization.CultureInfo.InvariantCulture)
            errors &= tRotation.ValidateNumber(tmpIni.Value("BASIC", "GRAPHICS_PITCH_ROTATION"), rotation, Globalization.CultureInfo.InvariantCulture)
            errors &= tTotalmass.ValidateNumber(tmpIni.Value("BASIC", "TOTALMASS"), totalmass, Globalization.CultureInfo.InvariantCulture)
            errors &= GetSingle(tmpIni.Value("BASIC", "TMPDRAWINGZ"), -50, 50, tmpDrawingZ, Globalization.CultureInfo.InvariantCulture)
            errors &= GetSingle(tmpIni.Value("BASIC", "TMPDRAWINGY"), -50, 50, tmpDrawingY, Globalization.CultureInfo.InvariantCulture)

            tTotalmass.TextSet(totalmass)
            tWheelbase.TextSet(wheelbase)
            tCGLocation.TextSet(cgLocation)
            tBaseyFront.TextSet(baseyFront)
            tBaseyRear.TextSet(baseyRear)
            tHubFront.TextSet(hubFront)
            tHubRear.TextSet(hubRear)
            tArbFront.TextSet(arbFront)
            tArbRear.TextSet(arbRear)
            tSpringRateFront.TextSet(springRateFront)
            tSpringRateRear.TextSet(springRateRear)
            tBumpSpringRateFront.TextSet(bumpSpringRateFront)
            tBumpSpringRateRear.TextSet(bumpSpringRateRear)
            tY.TextSet(y)
            tZ.TextSet(z)
            tRotation.TextSet(rotation)

            If Not String.IsNullOrEmpty(errors) Then MsgBox(errors)
        End With
    End Sub

    Private Sub btCalcZ_Click(sender As Object, e As EventArgs) Handles btCalcZ.Click
        Dim errors As String = ""
        Dim wheelbase As Single = tWheelbase.TextGet(errors)
        Dim cgLocation As Single = tCGLocation.TextGet(errors)
        If Not String.IsNullOrEmpty(errors) Then
            MsgBox(errors)
            Return
        End If
        Dim txtDrawingZ As String = InputBox("Where is the Z zero of the drawing, the correct value of DrawingZ when CGFront=50%, the offset relatively to the center of the distance between the wheels ?", DefaultResponse:=Me.tmpDrawingZ.ToString)
        errors &= GetSingle(txtDrawingZ, -50, 50, tmpDrawingZ)
        If Not String.IsNullOrEmpty(errors) Then
            MsgBox(errors)
            Return
        End If
        tZ.Text = (wheelbase / 2 - wheelbase * cgLocation + tmpDrawingZ).ToString("0.00")
    End Sub

    Private Sub btCalcY_Click(sender As Object, e As EventArgs) Handles btCalcY.Click
        Dim errors As String = ""
        Dim cgLocation As Single = tCGLocation.TextGet(errors)
        Dim baseyFront As Single = tBaseyFront.TextGet(errors)
        Dim baseyRear As Single = tBaseyRear.TextGet(errors)
        If Not String.IsNullOrEmpty(errors) Then
            MsgBox(errors)
            Return
        End If
        Dim txtDrawingY As String = InputBox("Where is the Y zero of the drawing, the correct value of DrawingY when BaseY=0 (both front and rear) ?", DefaultResponse:=Me.tmpDrawingY.ToString)
        errors &= GetSingle(txtDrawingY, -50, 50, tmpDrawingY)
        If Not String.IsNullOrEmpty(errors) Then
            MsgBox(errors)
            Return
        End If
        tY.Text = (baseyFront * cgLocation + baseyRear * (1 - cgLocation) + tmpDrawingY).ToString("0.00")
    End Sub

    Private Sub btCalcRotation_Click(sender As Object, e As EventArgs) Handles btCalcRotation.Click
        Dim errors As String = ""
        Dim wheelbase As Single = tWheelbase.TextGet(errors)
        Dim baseyFront As Single = tBaseyFront.TextGet(errors)
        Dim baseyRear As Single = tBaseyRear.TextGet(errors)
        If Not String.IsNullOrEmpty(errors) Then
            MsgBox(errors)
            Return
        End If
        tRotation.Text = (Math.Asin((baseyRear - baseyFront) / wheelbase) / Math.PI * 180).ToString("0.00")
    End Sub

    Private Sub btSetup_Click(sender As Object, e As EventArgs) Handles btSetup.Click
        With car
            Dim errors As String = ""
            Dim hubFront As Single = tHubFront.TextGet(errors)
            Dim hubRear As Single = tHubRear.TextGet(errors)
            Dim wheelbase As Single = tWheelbase.TextGet(errors)
            Dim cgLocation As Single = tCGLocation.TextGet(errors)
            Dim baseyFront As Single = tBaseyFront.TextGet(errors)
            Dim baseyRear As Single = tBaseyRear.TextGet(errors)
            Dim arbFront As Single = tArbFront.TextGet(errors)
            Dim arbRear As Single = tArbRear.TextGet(errors)
            Dim SpringRateFront As Single = tSpringRateFront.TextGet(errors)
            Dim SpringRateRear As Single = tSpringRateRear.TextGet(errors)
            Dim BumpSpringRateFront As Single = tBumpSpringRateFront.TextGet(errors)
            Dim BumpSpringRateRear As Single = tBumpSpringRateRear.TextGet(errors)
            Dim y As Single = tY.TextGet(errors)
            Dim z As Single = tZ.TextGet(errors)
            Dim rotation As Single = tRotation.TextGet(errors)
            Dim totalmass As Single = tTotalmass.TextGet(errors)
            If Not String.IsNullOrEmpty(errors) Then
                MsgBox(errors)
                Return
            End If

            Dim tmpIni As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            tmpIni.Load(.Path & "\data\suspensions.ini")
            tmpIni.Value("BASIC", "WHEELBASE") = wheelbase.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("BASIC", "CG_LOCATION") = cgLocation.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("FRONT", "BASEY") = baseyFront.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("REAR", "BASEY") = baseyRear.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("ARB", "FRONT") = arbFront.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("ARB", "REAR") = arbRear.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("FRONT", "SPRING_RATE") = SpringRateFront.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("REAR", "SPRING_RATE") = SpringRateRear.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("FRONT", "BUMP_STOP_RATE") = BumpSpringRateFront.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("REAR", "BUMP_STOP_RATE") = BumpSpringRateRear.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("FRONT", "HUB_MASS") = hubFront.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("REAR", "HUB_MASS") = hubRear.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Save()

            tmpIni = New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            tmpIni.Load(.Path & "\data\car.ini")
            Dim tmp As String = tmpIni.Value("BASIC", "GRAPHICS_OFFSET")
            Dim tmpArr As String() = tmp.Split(","c) ' (x,y,z)
            tmpIni.Value("BASIC", "GRAPHICS_OFFSET") = tmpArr(0) & "," & y.ToString(Globalization.CultureInfo.InvariantCulture) & "," & z.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("BASIC", "GRAPHICS_PITCH_ROTATION") = rotation.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("BASIC", "TOTALMASS") = totalmass.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("BASIC", "TMPDRAWINGZ") = tmpDrawingZ.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Value("BASIC", "TMPDRAWINGY") = tmpDrawingY.ToString(Globalization.CultureInfo.InvariantCulture)
            tmpIni.Save()

        End With
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub calculate_lRotation(sender As Object, e As EventArgs) Handles tWheelbase.TextChanged, tBaseyFront.TextChanged, tBaseyRear.TextChanged
        Dim tmpWheelbase As Single = tWheelbase.TextGet() ' Wheelbase distance in meters
        If tmpWheelbase = 0 Then
            lRotation.Text = "---"
            Return
        End If

        Dim tmpIni As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
        tmpIni.Load(car.Path & "\data\suspensions.ini")

        ' BASEY=-0.090 ; Distance of CG from the center of the wheel in meters. Front Wheel Radius+BASEY=front CoG
        ' we're here assuming the front and rear Tyre's Radius are the same

        ' Push Rod length in meters. positive raises ride height, negative lowers ride height:
        Dim rodFront As Single, rodRear As Single
        'Single.TryParse(tmpIni.Value("FRONT", "ROD_LENGTH"), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, rodFront)
        'Single.TryParse(tmpIni.Value("REAR", "ROD_LENGTH"), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, rodRear)

        '' Motion Ratio:
        'Dim motionRatioFront As Single = 1
        'Select Case tmpIni.Value("FRONT", "TYPE").ToUpper
        '    Case "DWB"
        ' WHERE DO I GET THE SPRING COORDINATES ??
        'End Select
        'rodFront *= CSng(motionRatioFront ^ 2)


        ' Calculate:
        lRotation.Text = (Math.Atan(((tBaseyRear.TextGet() - rodRear) - (tBaseyFront.TextGet() - rodFront)) / tmpWheelbase) * 180 / Math.PI).ToString("0.00")
        ' Actual CG height =(FWR+FBasey)+(RWR+Rbasey))/CG_LOCATION%
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

End Class