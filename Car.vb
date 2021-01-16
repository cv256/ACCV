Public Class Car
    Public Path As String = ""
    Public Brand As String = ""
    Public Name As String = ""
    Public MyLike As Integer
    Public MyNotes As String = ""
    Public HP As Integer
    Public Weight As Integer
    Public TopSpeed As Integer
    Public Acceleration As Decimal
    Public LastDate As Date
    Public Tags As New List(Of String)
    'Public BrandSize As Size
    Public SelectedSkinPath As String
    'Public SelectedSkinSize As Size
    Public Skins As New List(Of String)
    Public Modded As Boolean, ACD As Boolean, CoGFront As String = "", CoGRear As String = ""

    Public Sub Init(carPath As String)
        Me.Path = carPath
        Integer.TryParse(MyIni.Value("LIKES", Car.Folder(Me.Path).ToUpper), Me.MyLike)
        Me.MyNotes = MyIni.Value("NOTES", Car.Folder(Me.Path).ToUpper)
        Me.LastDate = System.IO.Directory.GetLastWriteTimeUtc(carPath)
        'Me.BrandSize = GetImageSize(carPath & "\ui\badge.png")
        Me.Modded = System.IO.Directory.Exists(carPath & "\data")
        Me.ACD = System.IO.File.Exists(carPath & "\data.acd")
        ' skins:
        Me.Skins.Clear()
        Try
            For Each pathSkin As String In System.IO.Directory.EnumerateDirectories(carPath & "\skins\")
                Dim foldSkin As String = pathSkin.ToLower.Replace(carPath.ToLower & "\skins\", "")
                If String.IsNullOrEmpty(Me.SelectedSkinPath) OrElse foldSkin = MyIni.Value("PREFEREDSKINS", Car.Folder(Me.Path).ToUpper) Then ' Me.SelectedSkinSize.Height <= 0 
                    Me.SelectedSkinPath = foldSkin ' Car skin preview.jpg 1024 x 576 racio 1,77777777777778
                    'Me.SelectedSkinSize = GetImageSize(pathSkin & "\preview.jpg")
                End If
                Me.Skins.Add(foldSkin)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' read ui_car.json:
        Dim ui As String = ""
        Try
            Using sr As New System.IO.StreamReader(carPath & "\ui\ui_car.json")
                ui = sr.ReadToEnd()
            End Using
        Catch ex As Exception
        End Try
        Me.Name = GetJsonString(ui, "name")
        Me.Brand = GetJsonString(ui, "brand")
        ' HP
        Dim tmpHP As String = GetJsonString(ui, "bhp").Replace("+", "").Replace(" ", "")
        Dim tmpHPi As Integer
        For tmpHPi = 0 To tmpHP.Length - 1
            If Not IsNumeric(tmpHP(tmpHPi)) Then Exit For
        Next
        If tmpHPi > 0 Then Me.HP = CInt(tmpHP.Substring(0, tmpHPi))
        ' weight
        tmpHP = GetJsonString(ui, "weight").ToUpper.Replace("+", "").Replace(" ", "")
        For tmpHPi = 0 To tmpHP.Length - 1
            If Not IsNumeric(tmpHP(tmpHPi)) Then Exit For
        Next
        If tmpHPi > 0 Then Me.Weight = CInt(tmpHP.Substring(0, tmpHPi))
        ' Accel
        tmpHP = GetJsonString(ui, "acceleration").ToUpper.Replace("+", "").Replace(" ", "").Replace(", ", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator).Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
        For tmpHPi = 0 To tmpHP.Length - 1
            If Not IsNumeric(tmpHP(tmpHPi)) AndAlso tmpHP(tmpHPi) <> System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator Then Exit For
        Next
        If tmpHPi > 0 Then Me.Acceleration = CDec(tmpHP.Substring(0, tmpHPi))
        ' Speed
        tmpHP = GetJsonString(ui, "topspeed").ToUpper.Replace("+", "").Replace(" ", "")
        For tmpHPi = 0 To tmpHP.Length - 1
            If Not IsNumeric(tmpHP(tmpHPi)) Then Exit For
        Next
        If tmpHPi > 0 Then Me.TopSpeed = CInt(tmpHP.Substring(0, tmpHPi))
        ' tags:
        Me.Tags.Clear()
        For Each thisCarTag As String In GetJsonString(ui, "tags").Split(","c)
            thisCarTag = thisCarTag.Replace("""", "").Replace(vbCr, "").Replace(vbLf, "").Replace(vbTab, "").Replace(" ", "").ToUpper
            If thisCarTag.StartsWith("#A") Then thisCarTag = "#A" & Strings.Right(("00" & thisCarTag.Replace("#A", "")), 2)
            For Each tr As KeyValuePair(Of String, String) In TagTranslations
                thisCarTag = thisCarTag.Replace(tr.Key, tr.Value)
            Next
            If String.IsNullOrEmpty(thisCarTag) Then Continue For
            If Me.Tags.Contains(thisCarTag) Then Continue For

            If Not TagsClasses.ContainsKey(thisCarTag) Then Continue For
            'If Not TagsClasses.ContainsKey(thisCarTag) Then
            '    Dim thisCarTagClass As String = "Others" ' as tags que nao estiverem configuradas no INI cria seccao Others
            '    If thisCarTag.StartsWith("#A") Then thisCarTagClass = "A" ' se a tag é #A69 poe-a na seccao A, nao é preciso configurar no INI as tags começadas por #A
            '    If Not TagNames.Contains(thisCarTagClass) Then TagNames.Add(thisCarTagClass)
            '    TagsClasses.Add(thisCarTag, thisCarTagClass)
            'End If
            Me.Tags.Add(thisCarTag)
        Next
        ' Data:
        If Me.Modded AndAlso System.IO.File.Exists(carPath & "\data\suspensions.ini") Then
            ' suspension.ini :
            Try
                Dim tmpIni As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
                tmpIni.Load(carPath & "\data\suspensions.ini")
                Dim tmpSng As Single
                If Single.TryParse(tmpIni.Value("FRONT", "BASEY"), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, tmpSng) Then Me.CoGFront = (-tmpSng).ToString("0.00")
                If Single.TryParse(tmpIni.Value("REAR", "BASEY"), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, tmpSng) Then Me.CoGRear = (-tmpSng).ToString("0.00")
            Catch ex As Exception
            End Try
            ' car.ini :
            Try
                Dim tmpIni As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
                tmpIni.Load(carPath & "\data\car.ini")
                Dim tmpSng As Single
                If Single.TryParse(tmpIni.Value("BASIC", "TOTALMASS"), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, tmpSng) Then Me.Weight = CInt(tmpSng)
            Catch ex As Exception
            End Try
            ' drivetrain.ini :
            Try
                Dim tmpIni As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
                tmpIni.Load(carPath & "\data\drivetrain.ini")
                Dim tmpStr As String = tmpIni.Value("TRACTION", "TYPE")
                If tmpStr > "" Then
                    tmpStr = tmpStr.Trim.ToUpper
                    Me.Tags.RemoveAll(Function(s) TagsClasses.ContainsKey(s) AndAlso TagsClasses(s) = "TRACTION")
                    Me.Tags.Add(tmpStr)
                    If Not TagsClasses.ContainsKey(tmpStr) Then TagsClasses.Add(tmpStr, "TRACTION")
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub


    Public Function HpPerTon() As Integer
        If Weight < 10 Then Return 0
        Return CInt(HP / Weight * 1000)
    End Function

    Public Function TagsByClass(pClass As String, pSeparator As String) As String
        Dim res As String = ""
        For Each t As String In Tags.Where(Function(f) TagsClasses(f) = pClass)
            res &= t.ToLower & pSeparator
        Next
        Return res
    End Function

    Public Function TooltipText(pSkin As String, pDescr As String) As String
        Dim tmpTT As String = ""
        If SelectedCar Is Nothing Then
            tmpTT = "No car selected for " & pDescr
        Else
            tmpTT = pDescr _
                & vbCrLf & "Car  «" & Folder(Me.Path) & "»" & "     Skin  «" & pSkin & "»" _
                & vbCrLf & vbCrLf & Me.HP.ToString & " HP     " & Me.Weight.ToString & " Kg     " & Me.HpPerTon.ToString & " HP/Ton     " & Me.Acceleration.ToString & " s     " & Me.TopSpeed.ToString & " Km/h" _
                & vbCrLf & vbCrLf & Me.TagsByClass("TRACTION", "  ").ToUpper & "     " & Me.TagsByClass("GEARS", "  ").ToUpper & "     CoG=" & Me.CoGFront & "/" & Me.CoGRear _
                & vbCrLf & vbCrLf & "Like: " & Me.MyLike & "     " & Me.MyNotes
        End If
        Return tmpTT & vbCrLf & vbCrLf & "Left-Click to select/manage cars" & vbCrLf & "Right-Click to select car skins"
    End Function


    Public Shared Function Find(pFolder As String) As Car
        For Each c As Car In Cars
            If c.Path.EndsWith("\" & pFolder) Then Return c
        Next
        Return Nothing
    End Function

    Public Shared Function FindName(pFolder As String) As String
        For Each c As Car In Cars
            If c.Path.EndsWith("\" & pFolder) Then Return c.Name
        Next
        Return pFolder
    End Function

    Public Shared Function Folder(pPath As String) As String
        If pPath Is Nothing Then Return ""
        Dim i As Integer = pPath.ToLower.Replace("\preview.jpg", "").LastIndexOf("\")
        Return pPath.Substring(i + 1)
    End Function

    Public Shared Function GetRandomCar() As Car
        If FilteredCars Is Nothing OrElse FilteredCars.Count = 0 Then
            MsgBox("For selecting a random car, your filtering must return at least one car")
            Return Nothing
        End If
        Dim res As Car
        Dim r As Integer = New Random(Now.Millisecond).Next(FilteredCars.Count)
        res = FilteredCars(r)
        Return res
    End Function

    Public Function GetRandomSkin() As String
        If Skins Is Nothing OrElse Skins.Count = 0 Then Return ""
        Dim r As Integer = New Random(Now.Millisecond).Next(Skins.Count)
        Return Skins(r)
    End Function

    Public Function OpenACD() As Boolean
        Dim tmpCmd As String = """" & QuickBMSPath & "quickbms.exe""  """ & QuickBMSPath & "assetto_corsa_acd.bms""  """ & Me.Path & "\data.acd""   """ & Me.Path & "\data"""
        If MsgBox("OK to run this ?" & vbCrLf & vbCrLf & tmpCmd, MsgBoxStyle.Question Or MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then Return False
        Try
            Shell(tmpCmd, AppWinStyle.NormalFocus, Wait:=True)
        Catch ex As Exception

        End Try
        Me.Init(Me.Path)
        Return True
    End Function

    Public Sub ExploreFolder()
        Shell($"Explorer.exe ""{Me.Path}""", AppWinStyle.NormalFocus)
    End Sub

End Class
