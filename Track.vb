Public Class Track
    Public Path As String = ""
    Public Config As String = ""
    Public Name As String = ""
    Public MyLike As Integer
    Public MyNotes As String = ""
    Public Length As Integer
    Public Width As String
    Public Country As String
    Public MapPath As String = ""
    'Public MapSize As Size
    Public FotoPath As String = ""
    'Public FotoSize As Size
    Public Tags As New List(Of String)
    Public Modded As Boolean

    Public Sub Init(fold As String)
        Me.Path = fold
        Dim i As Integer = fold.ToLower.LastIndexOf("\ui\")
        If i >= 0 Then
            Me.Config = fold.Substring(i + 4)
        End If
        Me.Modded = System.IO.File.Exists(fold.Substring(0, fold.ToLower.LastIndexOf("\ui")) & "\MOD.txt")
        If IsNumeric(MyIni.Value("TRACKLIKES", Me.PathConfig.ToUpper)) Then Me.MyLike = CInt(MyIni.Value("TRACKLIKES", Me.PathConfig.ToUpper))
        Me.MyNotes = MyIni.Value("TRACKNOTES", Me.PathConfig.ToUpper)
        Me.MapPath = fold & "\outline.png"
        'Me.MapSize = GetImageSize(Me.MapPath)
        If Not IO.File.Exists(Me.MapPath) Then ' Me.MapSize.Height = 0 
            Me.MapPath = fold & "\map.png"
            'Me.MapSize = GetImageSize(Me.MapPath)
        End If
        Me.FotoPath = fold & "\preview.png"
        'Me.FotoSize = GetImageSize(Me.FotoPath)
        ' read ui_track.json:
        Dim ui As String = ""
        Try
            Using sr As New System.IO.StreamReader(fold & "\ui_track.json")
                ui = sr.ReadToEnd()
            End Using
        Catch ex As Exception
        End Try
        Me.Name = GetJsonString(ui, "name").Trim(" "c)
        If String.IsNullOrEmpty(Me.Name) Then Me.Name = Me.PathConfig.Replace(".", " ")
        Me.Width = GetJsonString(ui, "width").Trim(" "c)
        Me.Country = GetJsonString(ui, "country").Trim(" "c)
        ' lenght
        Dim tmpHP As String = GetJsonString(ui, "length").Replace(",", "").Replace(".", "").Replace(" ", "").Replace("m", "")
        Dim tmpHPi As Integer
        For tmpHPi = 0 To tmpHP.Length - 1
            If Not IsNumeric(tmpHP(tmpHPi)) Then Exit For
        Next
        If tmpHPi > 0 Then Me.Length = CInt(tmpHP.Substring(0, tmpHPi))
        If tmpHP.ToUpper.Contains("K"c) AndAlso tmpHPi < 1000 Then Me.Length *= 1000
        ' tags:
        Me.Tags.Clear()
        For Each thisTrackTag As String In GetJsonString(ui, "tags").Split(","c)
            thisTrackTag = thisTrackTag.Replace("""", "").Replace(vbCr, "").Replace(vbLf, "").Replace(vbTab, "").Replace(" ", "") '.ToUpper
            'For Each tr As KeyValuePair(Of String, String) In TagTranslations
            '    thisTrackTag = thisTrackTag.Replace(tr.Key, tr.Value)
            'Next
            If String.IsNullOrEmpty(thisTrackTag) Then Continue For
            If Me.Tags.Contains(thisTrackTag) Then Continue For

            'If Not TagsClasses.ContainsKey(thisTrackTag) Then
            '    Dim thisCarTagClass As String = "Others" ' as tags que nao estiverem configuradas no INI cria seccao Others
            '    If thisTrackTag.StartsWith("#A") Then thisCarTagClass = "A" ' se a tag é #A69 poe-a na seccao A, nao é preciso configurar no INI as tags começadas por #A
            '    If Not TagNames.Contains(thisCarTagClass) Then TagNames.Add(thisCarTagClass)
            '    TagsClasses.Add(thisTrackTag, thisCarTagClass)
            'End If

            Me.Tags.Add(thisTrackTag)
        Next
    End Sub

    Public Function PathConfig() As String
        Return Track.PathBase(Path) & CStr(IIf(String.IsNullOrEmpty(Config), "", "." & Config))
    End Function

    Public Shared Function FindByPath(pPathConfig As String) As Track
        For Each c As Track In Tracks
            If c.PathConfig.ToUpper = pPathConfig.ToUpper Then Return c
        Next
        Return Nothing
    End Function

    Public Shared Function PathBase(pPath As String) As String
        Dim f As Integer = pPath.ToLower.LastIndexOf("\ui")
        If f < 0 Then f = pPath.Length
        Dim i As Integer = pPath.LastIndexOf("\", f - 1)
        Return pPath.Substring(i + 1, f - i - 1)
    End Function

    Public Function FolderBase() As String
        Return PathBase(Me.Path).Replace(ACPath & "tracks\", "")
    End Function

End Class
