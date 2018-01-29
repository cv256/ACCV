Module Module1

    Public MyIniPath As String
    Public MyIni As INIFile
    Public MyHistory As History
    Public ACPath As String = "C:\Assetto Corsa"
    Public FontSize As Integer = 9
    Public DefaultAILevel As Integer = 90
    Public Cars As New List(Of Car)
    Public TagNames As New List(Of String)
    Public TagsClasses As New Dictionary(Of String, String)
    Public TagTranslations As New Dictionary(Of String, String)
    Public MoveZ As Decimal = 20
    Public MoveY As Decimal = 10
    Public MoveX As Decimal = 4
    Public Shake As Decimal = 1
    Public Skids As Integer = 8

    Public SelectedCar As Car = Nothing
    Public Tracks As New List(Of Track)
    Public SelectedTrack As Track = Nothing
    Public Opponents As New List(Of Opponent)
    Public OpponentCount As Integer = 3
    Public CSS As String = "<style>body {background-color:black;color:white;font-family:arial,helvetica,sans-serif;} a {color:yellow;text-decoration:none;} a:hover {text-decoration: underline;}</style>"
    ''' <summary>
    ''' returns True if ok, False if needs Setup
    ''' </summary>
    ''' <returns></returns>
    Public Function Init() As Boolean

        If String.IsNullOrEmpty(MyIniPath) Then
            If My.Application.CommandLineArgs.Count > 0 Then MyIniPath = My.Application.CommandLineArgs(0)
            MyIniPath = FileIO.SpecialDirectories.MyDocuments & "\AC CV"
        End If
        If Not FileIO.FileSystem.DirectoryExists(MyIniPath) Then
            FileIO.FileSystem.CreateDirectory(MyIniPath)
        End If
        MyIni = New INIFile
        MyIni.Load(MyIniPath & "\Settings.ini")

        If MyHistory Is Nothing Then
            MyHistory = New History
            If Not MyHistory.Load() Then MyHistory = Nothing
        End If

        If MyIni.Value("SETUP", "ACFOLDER") = "" Then MyIni.Value("SETUP", "ACFOLDER") = ACPath.ToString
        ACPath = MyIni.Value("SETUP", "ACFOLDER") & "\"

        If MyIni.Value("SETUP", "FONTSIZE") = "" Then MyIni.Value("SETUP", "FONTSIZE") = FontSize.ToString
        FontSize = CInt(MyIni.Value("SETUP", "FONTSIZE"))

        If MyIni.Value("SETUP", "AILEVEL") = "" Then MyIni.Value("SETUP", "AILEVEL") = DefaultAILevel.ToString
        DefaultAILevel = CInt(MyIni.Value("SETUP", "AILEVEL"))

        If MyIni.Value("SETUP", "MOVEZ") = "" Then MyIni.Value("SETUP", "MOVEZ") = MoveZ.ToString
        MoveZ = CDec(MyIni.Value("SETUP", "MOVEZ"))

        If MyIni.Value("SETUP", "MOVEY") = "" Then MyIni.Value("SETUP", "MOVEY") = MoveY.ToString
        MoveY = CDec(MyIni.Value("SETUP", "MOVEY"))

        If MyIni.Value("SETUP", "MOVEX") = "" Then MyIni.Value("SETUP", "MOVEX") = MoveX.ToString
        MoveX = CDec(MyIni.Value("SETUP", "MOVEX"))

        If MyIni.Value("SETUP", "SHAKE") = "" Then MyIni.Value("SETUP", "SHAKE") = Shake.ToString
        Shake = CDec(MyIni.Value("SETUP", "SHAKE"))

        If MyIni.Value("SETUP", "SKIDS") = "" Then MyIni.Value("SETUP", "SKIDS") = Skids.ToString
        Skids = CInt(MyIni.Value("SETUP", "SKIDS"))

        If Not System.IO.File.Exists(ACPath & "acs.exe") Then
            MsgBox("Couldn't find «" & ACPath & "acs.exe" & "»")
            Return False
        End If

        InitCars()
        InitTracks()

        Return True
    End Function

    Public Function FileMsg(pFilePath As String) As String
        Return System.IO.Path.GetFileName(pFilePath) & "    Size:" & New System.IO.FileInfo(pFilePath).Length & "    Modified:" & System.IO.File.GetLastWriteTime(pFilePath)
    End Function

    Public Sub InitCars()
        SelectedCar = Nothing
        Cars.Clear()
        TagTranslations.Clear()
        TagsClasses.Clear()
        TagNames.Clear()

        'TagNames.Add("A") ' #A

        For Each k As String In MyIni.Section("TAGNAMES").Keys.Keys
            TagNames.Add(k)
        Next

        For Each k As Key In MyIni.Section("TAGS").Keys.Values
            If Not TagNames.Contains(k.Value) Then
                MsgBox(String.Format("Section «TAGS» key «{0}» points to inexisting TAGNAME «{1}»", k.Name, k.Value))
                Continue For
            End If
            TagsClasses.Add(k.Name, k.Value)
        Next

        For Each k As Key In MyIni.Section("TAGTRANSLATIONS").Keys.Values
            TagTranslations.Add(k.Name, k.Value.Replace("IGNORE", ""))
        Next

        InitCars(ACPath & "content\cars")
        InitCars(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\content\cars")
        Cars.Sort(Function(f, h) CInt(IIf(f.Brand & f.Name > h.Brand & h.Name, 1, -1)))
    End Sub


    Public Sub InitCars(pPath As String)

        For Each carPath As String In System.IO.Directory.EnumerateDirectories(pPath)

            'For Each fBak As String In System.IO.Directory.GetFiles(carPath, "*.bak")
            '    'Dim a As String = "", aCount As Integer = 0, aOK As String
            '    'For Each fOk As String In System.IO.Directory.GetFiles(carPath, System.IO.Path.GetFileNameWithoutExtension(fBak) & ".*")
            '    '    If fOk = fBak Then Continue For
            '    '    aCount += 1 : aOK = fOk
            '    '    a &= FileMsg(fOk) & vbCrLf
            '    'Next
            '    'If aCount > 1 Then
            '    '    MsgBox("Há Bak mas ha varios Originais" & vbCrLf & vbCrLf & FileMsg(fBak) & vbCrLf & vbCrLf & a)
            '    'ElseIf aCount = 1 Then
            '    System.IO.File.Move(fBak.Replace(".bak", ""), fBak.Replace(".bak", "") & ".awesome") ' .kn5 -> .kn5awesome
            '    System.IO.File.Move(fBak, fBak.Replace(".bak", "")) ' .kn5.bak -> kn5
            '    'End If
            'Next
            'For Each fBak As String In System.IO.Directory.GetFiles(carPath & "\sfx", "*.bak")
            '    System.IO.File.Move(fBak.Replace(".bak", ""), fBak.Replace(".bak", "") & ".awesome") ' .kn5 -> .kn5awesome
            '    System.IO.File.Move(fBak, fBak.Replace(".bak", "")) ' .kn5.bak -> kn5
            'Next

            Dim tmpCar As New Car
            Cars.Add(tmpCar)
            tmpCar.Path = carPath
            Integer.TryParse(MyIni.Value("LIKES", Car.Folder(tmpCar.Path).ToUpper), tmpCar.MyLike)
            tmpCar.MyNotes = MyIni.Value("NOTES", Car.Folder(tmpCar.Path).ToUpper)
            'tmpCar.BrandSize = GetImageSize(carPath & "\ui\badge.png")
            tmpCar.Modded = System.IO.Directory.Exists(carPath & "\data")
            If tmpCar.Modded AndAlso System.IO.File.Exists(carPath & "\data\suspensions.ini") Then
                Dim tmpIni As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
                tmpIni.Load(carPath & "\data\suspensions.ini")
                Dim tmpSng As Single
                Single.TryParse(tmpIni.Value("FRONT", "BASEY"), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, tmpSng)
                tmpCar.CoGFront = (-tmpSng).ToString("0.00")
                Single.TryParse(tmpIni.Value("REAR", "BASEY"), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, tmpSng)
                tmpCar.CoGRear = (-tmpSng).ToString("0.00")
            End If
            ' skins:
            Try
                For Each pathSkin As String In System.IO.Directory.EnumerateDirectories(carPath & "\skins\")
                    Dim foldSkin As String = pathSkin.ToLower.Replace(carPath.ToLower & "\skins\", "")
                    If String.IsNullOrEmpty(tmpCar.SelectedSkinPath) OrElse foldSkin = MyIni.Value("PREFEREDSKINS", Car.Folder(tmpCar.Path).ToUpper) Then ' tmpCar.SelectedSkinSize.Height <= 0 
                        tmpCar.SelectedSkinPath = foldSkin ' Car skin preview.jpg 1024 x 576 racio 1,77777777777778
                        'tmpCar.SelectedSkinSize = GetImageSize(pathSkin & "\preview.jpg")
                    End If
                    tmpCar.Skins.Add(foldSkin)
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
            tmpCar.Name = GetJsonString(ui, "name")
            tmpCar.Brand = GetJsonString(ui, "brand")
            ' HP
            Dim tmpHP As String = GetJsonString(ui, "bhp").Replace("+", "").Replace(" ", "")
            Dim tmpHPi As Integer
            For tmpHPi = 0 To tmpHP.Length - 1
                If Not IsNumeric(tmpHP(tmpHPi)) Then Exit For
            Next
            If tmpHPi > 0 Then tmpCar.HP = CInt(tmpHP.Substring(0, tmpHPi))
            ' weight
            tmpHP = GetJsonString(ui, "weight").ToUpper.Replace("+", "").Replace(" ", "")
            For tmpHPi = 0 To tmpHP.Length - 1
                If Not IsNumeric(tmpHP(tmpHPi)) Then Exit For
            Next
            If tmpHPi > 0 Then tmpCar.Weight = CInt(tmpHP.Substring(0, tmpHPi))
            ' Accel
            tmpHP = GetJsonString(ui, "acceleration").ToUpper.Replace("+", "").Replace(" ", "").Replace(", ", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator).Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
            For tmpHPi = 0 To tmpHP.Length - 1
                If Not IsNumeric(tmpHP(tmpHPi)) AndAlso tmpHP(tmpHPi) <> System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator Then Exit For
            Next
            If tmpHPi > 0 Then tmpCar.Acceleration = CDec(tmpHP.Substring(0, tmpHPi))
            ' Speed
            tmpHP = GetJsonString(ui, "topspeed").ToUpper.Replace("+", "").Replace(" ", "")
            For tmpHPi = 0 To tmpHP.Length - 1
                If Not IsNumeric(tmpHP(tmpHPi)) Then Exit For
            Next
            If tmpHPi > 0 Then tmpCar.TopSpeed = CInt(tmpHP.Substring(0, tmpHPi))
            ' tags:
            For Each thisCarTag As String In GetJsonString(ui, "tags").Split(","c)
                thisCarTag = thisCarTag.Replace("""", "").Replace(vbCr, "").Replace(vbLf, "").Replace(vbTab, "").Replace(" ", "").ToUpper
                If thisCarTag.StartsWith("#A") Then thisCarTag = "#A" & Strings.Right(("00" & thisCarTag.Replace("#A", "")), 2)
                For Each tr As KeyValuePair(Of String, String) In TagTranslations
                    thisCarTag = thisCarTag.Replace(tr.Key, tr.Value)
                Next
                If String.IsNullOrEmpty(thisCarTag) Then Continue For
                If tmpCar.Tags.Contains(thisCarTag) Then Continue For

                If Not TagsClasses.ContainsKey(thisCarTag) Then Continue For
                'If Not TagsClasses.ContainsKey(thisCarTag) Then
                '    Dim thisCarTagClass As String = "Others" ' as tags que nao estiverem configuradas no INI cria seccao Others
                '    If thisCarTag.StartsWith("#A") Then thisCarTagClass = "A" ' se a tag é #A69 poe-a na seccao A, nao é preciso configurar no INI as tags começadas por #A
                '    If Not TagNames.Contains(thisCarTagClass) Then TagNames.Add(thisCarTagClass)
                '    TagsClasses.Add(thisCarTag, thisCarTagClass)
                'End If

                tmpCar.Tags.Add(thisCarTag)

            Next
        Next
    End Sub


    Public Sub InitTracks()
        SelectedTrack = Nothing
        Tracks.Clear()
        InitTracks(ACPath & "content\tracks")
        InitTracks(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\content\tracks")
        Tracks.Sort(Function(f, h) CInt(IIf(f.Name > h.Name, 1, -1)))
    End Sub

    Public Sub InitTracks(pPath As String)
        'MsgBox("InitTracks Starting")
        For Each fold0 As String In System.IO.Directory.EnumerateDirectories(pPath)
            InitTrack(fold0 & "\ui")
            Try
                For Each fold As String In System.IO.Directory.EnumerateDirectories(fold0 & "\ui")
                    InitTrack(fold)
                Next fold
            Catch ex As Exception

            End Try
        Next fold0
        'MsgBox("InitTracks Ending, got " & Tracks.Count & " tracks")
    End Sub

    Private Sub InitTrack(fold As String)
        If Not System.IO.File.Exists(fold & "\ui_track.json") Then
            'MsgBox("InitTrack:  «" & fold & "» doesnt contain file «ui_track.json», cant add this track")
            Return
        Else
            'MsgBox("InitTrack: «" & fold & "» contain's file «ui_track.json», good...")
        End If
        Dim tmpTrack As New Track
        Tracks.Add(tmpTrack)
        tmpTrack.Path = fold
        Dim i As Integer = fold.ToLower.LastIndexOf("\ui\")
        If i >= 0 Then
            tmpTrack.Config = fold.Substring(i + 4)
        End If
        tmpTrack.Modded = System.IO.File.Exists(fold.Substring(0, fold.ToLower.LastIndexOf("\ui")) & "\MOD.txt")
        If IsNumeric(MyIni.Value("TRACKLIKES", tmpTrack.PathConfig.ToUpper)) Then tmpTrack.MyLike = CInt(MyIni.Value("TRACKLIKES", tmpTrack.PathConfig.ToUpper))
        tmpTrack.MyNotes = MyIni.Value("TRACKNOTES", tmpTrack.PathConfig.ToUpper)
        tmpTrack.MapPath = fold & "\outline.png"
        'tmpTrack.MapSize = GetImageSize(tmpTrack.MapPath)
        If Not IO.File.Exists(tmpTrack.MapPath) Then ' tmpTrack.MapSize.Height = 0 
            tmpTrack.MapPath = fold & "\map.png"
            'tmpTrack.MapSize = GetImageSize(tmpTrack.MapPath)
        End If
        tmpTrack.FotoPath = fold & "\preview.png"
        'tmpTrack.FotoSize = GetImageSize(tmpTrack.FotoPath)
        ' read ui_track.json:
        Dim ui As String = ""
        Try
            Using sr As New System.IO.StreamReader(fold & "\ui_track.json")
                ui = sr.ReadToEnd()
            End Using
        Catch ex As Exception
        End Try
        tmpTrack.Name = GetJsonString(ui, "name").Trim(" "c)
        If String.IsNullOrEmpty(tmpTrack.Name) Then tmpTrack.Name = tmpTrack.PathConfig.Replace(".", " ")
        tmpTrack.Width = GetJsonString(ui, "width").Trim(" "c)
        tmpTrack.Country = GetJsonString(ui, "country").Trim(" "c)
        ' lenght
        Dim tmpHP As String = GetJsonString(ui, "length").Replace(",", "").Replace(".", "").Replace(" ", "").Replace("m", "")
        Dim tmpHPi As Integer
        For tmpHPi = 0 To tmpHP.Length - 1
            If Not IsNumeric(tmpHP(tmpHPi)) Then Exit For
        Next
        If tmpHPi > 0 Then tmpTrack.Length = CInt(tmpHP.Substring(0, tmpHPi))
        If tmpHP.ToUpper.Contains("K"c) AndAlso tmpHPi < 1000 Then tmpTrack.Length *= 1000
        ' tags:
        For Each thisTrackTag As String In GetJsonString(ui, "tags").Split(","c)
            thisTrackTag = thisTrackTag.Replace("""", "").Replace(vbCr, "").Replace(vbLf, "").Replace(vbTab, "").Replace(" ", "") '.ToUpper
            'For Each tr As KeyValuePair(Of String, String) In TagTranslations
            '    thisTrackTag = thisTrackTag.Replace(tr.Key, tr.Value)
            'Next
            If String.IsNullOrEmpty(thisTrackTag) Then Continue For
            If tmpTrack.Tags.Contains(thisTrackTag) Then Continue For

            'If Not TagsClasses.ContainsKey(thisTrackTag) Then
            '    Dim thisCarTagClass As String = "Others" ' as tags que nao estiverem configuradas no INI cria seccao Others
            '    If thisTrackTag.StartsWith("#A") Then thisCarTagClass = "A" ' se a tag é #A69 poe-a na seccao A, nao é preciso configurar no INI as tags começadas por #A
            '    If Not TagNames.Contains(thisCarTagClass) Then TagNames.Add(thisCarTagClass)
            '    TagsClasses.Add(thisTrackTag, thisCarTagClass)
            'End If

            tmpTrack.Tags.Add(thisTrackTag)
        Next
    End Sub

    Private Function GetImageSize(pPath As String) As Size
        Dim res As New Size
        Try
            Dim tmpImg As New Bitmap(Image.FromFile(pPath))
            res.Width = tmpImg.Width
            res.Height = tmpImg.Height
            tmpImg.Dispose()
            tmpImg = Nothing
        Catch ex As Exception
        End Try
        Return res
    End Function

    Public Function GetJsonString(pJson As String, pToken As String) As String
        Dim res As String = ""
        Dim p As Integer = pJson.IndexOf("""" & pToken & """:")
        If p < 0 Then p = pJson.IndexOf("""" & pToken & """ :")
        If p >= 0 Then
            Dim i As Integer, e As Integer
            p = pJson.IndexOf(":", p + 1) + 1
            For i = p To pJson.Length - 1
                If pJson(i) = """" Then
                    e = JsonFindNext(pJson, """"c, i + 1)
                    Exit For
                ElseIf pJson(i) = "[" Then
                    e = JsonFindNext(pJson, "]"c, i)
                    Exit For
                ElseIf pJson(i) = "," OrElse pJson(i) = "}" Then
                    e = i
                    i = p
                    Exit For
                End If
            Next
            res = pJson.Substring((i + 1), e - (i + 1))
        End If
        Return res
    End Function

    Private Function JsonFindNext(pJson As String, pSep As Char, pStart As Integer) As Integer
        Dim Aspas As Boolean = False, Bracks As Integer = 0
        For n As Integer = pStart To pJson.Length - 1
            If pJson(n) = """" Then
                If pJson(n) = pSep Then Return n
                Aspas = Not Aspas
                Continue For
            End If
            If Aspas Then Continue For

            If pJson(n) = "[" Then
                Bracks += 1
            ElseIf pJson(n) = "]" Then
                Bracks -= 1
            End If
            If Bracks > 0 Then Continue For

            If pJson(n) = pSep Then
                Return n
            End If
        Next
        Return -1
    End Function

    Public Function GetSingle(pText As String, pMin As Single, pMax As Single, ByRef pResult As Single, Optional provider As IFormatProvider = Nothing) As String
        Dim res As String = $"Instead of «{pText}», write a number between {pMin} and {pMax}" & vbCrLf
        If Not Single.TryParse(pText, Globalization.NumberStyles.Any, provider, pResult) Then Return res
        If pResult < pMin OrElse pResult > pMax Then Return res
        Return ""
    End Function


    Public Function TimeSecondsDescr(pMiliseconds As Integer) As String
        Return CInt(Math.Floor(pMiliseconds / 1000 / 60)).ToString("00") & "'" & (CInt(Math.Floor(pMiliseconds / 1000)) Mod 60).ToString("00") & "." & CInt(Math.Floor(pMiliseconds Mod 1000 / 100)).ToString("0")
    End Function


    Public Function TimeDiffDescr(pBestTime As Integer, pMyTime As Integer, Optional pDescr As String = "") As String
        If pBestTime - pMyTime > 0 Then
            Return "-" & TimeSecondsDescr(pBestTime - pMyTime)
        ElseIf pBestTime - pMyTime < 0 Then
            Return "+" & TimeSecondsDescr(pMyTime - pBestTime)
        End If
        Return pDescr & "best"
    End Function

End Module
