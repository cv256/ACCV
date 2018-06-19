Public Class FormFavorites
    Private suspendDrawHTML As Boolean

    Private Structure Favorite
        Public Name As String
        Public Car As Car
        Public Track As Track
        Public OpponentsCount As Integer
    End Structure
    Private Favorites As New List(Of Favorite)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        suspendDrawHTML = True
        ' populate Favorites :
        For Each f As String In FileIO.FileSystem.GetFiles(MyIniPath, FileIO.SearchOption.SearchTopLevelOnly, "FAV *.INI")
            Dim tmpF As New Favorite With {.Name = f.Replace(MyIniPath & "\FAV ", "").Replace(".INI", "")}
            Dim tmpIni As New INIFile()
            tmpIni.Load(f)
            tmpF.Car = If(Car.Find(tmpIni.Value("LASTUSED", "CAR")), New Car)
            tmpF.Track = If(Track.FindByPath(tmpIni.Value("LASTUSED", "TRACK")), New Track)
            Integer.TryParse(tmpIni.Value("LASTUSED", "OPPONENTSCOUNT"), tmpF.OpponentsCount)
            Favorites.Add(tmpF)
        Next

        ' create criteria controls:
        Dim lastTop As Integer = 0

        Dim ck As New chk3state With {.Name = "chkModded", .Text = "MOD", .Top = lastTop, .AutoSize = True}
        Panel1.Controls.Add(ck) : lastTop = ck.Bottom
        AddHandler ck.CheckStateChanged, AddressOf FiltersChanged

        For Each tagClass As String In TagNames
            Dim tj As New List(Of String)
            For Each c As Car In Cars
                For Each t As String In c.Tags.Where(Function(f) TagsClasses(f) = tagClass)
                    If Not tj.Contains(t.ToLower) Then tj.Add(t.ToLower)
                Next
            Next
            If tj.Count > 0 Then
                Dim l As New Label With {.Text = tagClass, .Width = Panel1.Width - 30, .TextAlign = ContentAlignment.BottomCenter, .Top = lastTop} : Panel1.Controls.Add(l) : lastTop = l.Bottom
                tj.Sort()
                For Each t As String In tj
                    ck = New chk3state With {.Name = "chk" & t, .Text = t, .Top = lastTop, .AutoSize = True}
                    Panel1.Controls.Add(ck) : lastTop = ck.Bottom
                    AddHandler ck.CheckStateChanged, AddressOf FiltersChanged
                Next
            End If
        Next

        For Each c As Control In Me.Controls
            If TypeOf (c) IsNot TextBox Then Continue For
            AddHandler c.TextChanged, AddressOf FiltersChanged
        Next

        suspendDrawHTML = False
        DrawHTML()
    End Sub

    Private Sub DrawHTML()
        If suspendDrawHTML Then Return
        suspendDrawHTML = True
        delayedDrawHTML.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Dim LineHeight As Integer = 128, PreviewWidth As Integer = 150
        Dim html As String = "<html><head><title>AC CV Favorites</title>" & CSS & "</head><body [tmpOnLoad]>"
        html &= "<table border=1 style=""border-collapse:collapse;font-size:" & FontSize & "pt;"">"
        ' HEADERS:
        html &= "<thead>"
        html &= "<tr style=""background-color:darkblue;color:white;"">" &
            "<td rowspan=2><a href=""CAR"">Car</a></td>" &
            "<td rowspan=2><a href=""TRACK"">Track</a></td>" &
            "<td rowspan=2><a href=""NAME"">Description</a></td>" &
            "<td colspan=6 style=""text-align:center;"">CAR</td>" &
            "<td colspan=2 style=""text-align:center;"">TRACK</td>" &
        "</tr>"
        html &= "<tr style=""background-color:darkblue;color:white;"">" &
            "<td style=""text-align:center;""><a href=""LIKE"">LIKE</a></td>" &
            "<td style=""text-align:right;""><a href=""HP"">HP</a></td>" &
            "<td style=""text-align:right;""><a href=""KG"">Kg</a></td>" &
            "<td style=""text-align:right;""><a href=""HPTON"">HP/Ton</a></td>" &
            "<td style=""text-align:center;""><a href=""ACCEL"">0-100</a></td>" &
            "<td style=""text-align:right;""><a href=""SPEED"">Speed</a></td>" &
            "<td style=""text-align:right;""><a href=""TRACKLIKE"">LIKE</a></td>" &
            "<td style=""text-align:right;""><a href=""TRACKLEN"">KMs</a></td>" &
        "</tr>"
        html &= "</thead>"
        html &= "<tbody>"

        If Not IsNumeric(txtHPFrom.Text) Then txtHPFrom.Text = "0"
        If Not IsNumeric(txtHPTo.Text) Then txtHPTo.Text = "99999"
        Dim hpFrom As Integer = CInt(txtHPFrom.Text)
        Dim hpTo As Integer = CInt(txtHPTo.Text)

        If Not IsNumeric(txtKgFrom.Text) Then txtKgFrom.Text = "0"
        If Not IsNumeric(txtKgTo.Text) Then txtKgTo.Text = "99999"
        Dim kgFrom As Integer = CInt(txtKgFrom.Text)
        Dim kgTo As Integer = CInt(txtKgTo.Text)

        If Not IsNumeric(txtHPTonFrom.Text) Then txtHPTonFrom.Text = "0"
        If Not IsNumeric(txtHPTonTo.Text) Then txtHPTonTo.Text = "99999"
        Dim HpTonFrom As Integer = CInt(txtHPTonFrom.Text)
        Dim HpTonTo As Integer = CInt(txtHPTonTo.Text)

        If Not IsNumeric(txtAccelFrom.Text) Then txtAccelFrom.Text = "0"
        If Not IsNumeric(txtAccelTo.Text) Then txtAccelTo.Text = 99.9.ToString
        Dim AccelFrom As Decimal = CDec(txtAccelFrom.Text)
        Dim AccelTo As Decimal = CDec(txtAccelTo.Text)

        If Not IsNumeric(txtSpeedFrom.Text) Then txtSpeedFrom.Text = "0"
        If Not IsNumeric(txtSpeedTo.Text) Then txtSpeedTo.Text = "9999"
        Dim SpeedFrom As Integer = CInt(txtSpeedFrom.Text)
        Dim SpeedTo As Integer = CInt(txtSpeedTo.Text)

        If Not IsNumeric(txtLikeFrom.Text) Then txtLikeFrom.Text = "0"
        If Not IsNumeric(txtLikeTo.Text) Then txtLikeTo.Text = "10"
        Dim likeFrom As Integer = CInt(txtLikeFrom.Text)
        Dim likeTo As Integer = CInt(txtLikeTo.Text)

        If Not IsNumeric(txtTrackLikeFrom.Text) Then txtTrackLikeFrom.Text = "0"
        If Not IsNumeric(txtTrackLikeTo.Text) Then txtTrackLikeTo.Text = "10"
        Dim trackLikeFrom As Integer = CInt(txtTrackLikeFrom.Text)
        Dim trackLikeTo As Integer = CInt(txtTrackLikeTo.Text)

        If Not IsNumeric(txtLenFrom.Text) Then txtLenFrom.Text = "0"
        If Not IsNumeric(txtLenTo.Text) Then txtLenTo.Text = "9999"
        Dim lenFrom As Integer = CInt(txtLenFrom.Text)
        Dim lenTo As Integer = CInt(txtLenTo.Text)

        ' FILTER :
        Dim FavsOK As New List(Of Favorite)
        For Each f As Favorite In Favorites
            With f.Track
                If txtTrackText.TextLength > 0 Then
                    Dim tmpTxt As String = txtTrackText.Text.ToUpper
                    If .Name.ToUpper.Contains(tmpTxt) = False AndAlso .PathConfig.ToUpper.Contains(tmpTxt) = False AndAlso .MyNotes.ToUpper.Contains(tmpTxt) = False Then Continue For
                End If
                If .Length < lenFrom Then Continue For
                If lenTo <> 9999 AndAlso .Length / 1000 > lenTo Then Continue For
                If .MyLike < tracklikeFrom Then Continue For
                If .MyLike > trackLikeTo Then Continue For
            End With
            With f.Car
                If txtCarText.TextLength > 0 Then
                    Dim tmpTxt As String = txtCarText.Text.ToUpper
                    If .Name.ToUpper.Contains(tmpTxt) = False AndAlso .Brand.ToUpper.Contains(tmpTxt) = False AndAlso Car.Folder(.Path).ToUpper.Contains(tmpTxt) = False AndAlso .MyNotes.ToUpper.Contains(tmpTxt) = False Then Continue For
                End If
                If .HP < hpFrom Then Continue For
                If hpTo <> 99999 AndAlso .HP > hpTo Then Continue For
                If .Weight < kgFrom Then Continue For
                If kgTo <> 99999 AndAlso .Weight > kgTo Then Continue For
                If .HpPerTon < HpTonFrom Then Continue For
                If HpTonTo <> 99999 AndAlso .HpPerTon > HpTonTo Then Continue For
                If .Acceleration < AccelFrom Then Continue For
                If AccelTo <> 99.9 AndAlso .Acceleration > AccelTo Then Continue For
                If .TopSpeed < SpeedFrom Then Continue For
                If SpeedTo <> 9999 AndAlso .TopSpeed > SpeedTo Then Continue For
                If .MyLike < likeFrom Then Continue For
                If .MyLike > likeTo Then Continue For
                Select Case CType(Panel1.Controls("chkModded"), chk3state).CheckState
                    Case CheckState.Checked
                        If Not .Modded Then Continue For
                    Case CheckState.Unchecked
                        If .Modded Then Continue For
                End Select
                ' allows only:
                Dim Allowed As Boolean = True
                For Each t As Control In Panel1.Controls
                    If Not TypeOf (t) Is chk3state Then Continue For
                    If CType(t, chk3state).CheckState <> CheckState.Checked Then Continue For
                    If t.Name.EndsWith("Modded") Then Continue For
                    If Not .Tags.Contains(t.Name.ToUpper.Replace("CHK", "")) Then
                        Allowed = False
                        Exit For
                    End If
                Next
                ' dont allow:
                If Not Allowed Then Continue For
                For Each t As String In .Tags
                    If Panel1.Controls.ContainsKey("chk" & t) AndAlso CType(Panel1.Controls("chk" & t), chk3state).CheckState = CheckState.Unchecked Then
                        Allowed = False
                        Exit For
                    End If
                Next
                If Not Allowed Then Continue For
            End With

            FavsOK.Add(f)
        Next f

        ' HTML :
        For Each f As Favorite In FavsOK
            With f.Car
                html &= $"
                <tr style=""background-color:#000000;color:white;"">
                    <td><a href=""SELECTFAV{f.Name}""><img title=""Click to select this Favorite"" src=""{ .Path}\skins\{ .SelectedSkinPath}\preview.jpg"" style=""height:{LineHeight}px;""></a></td>
                    <td><a href=""SELECTFAV{f.Name}""><img title=""Click to select this Favorite"" src=""{f.Track.FotoPath}"" style=""height:{LineHeight}px;""></a></td>
                    <td><b>{f.Name}</b><br/><br/>{ .Name}<br/><br/>{f.Track.Name}<br/><br/>{f.OpponentsCount}  opponents<br/></td>
                    <td style=""text-align:center;"">{ .MyLike}</td>
                    <td style=""text-align:right;"">{ .HP}<br/><br/>hp</td>
                    <td style=""text-align:right;"">{ .Weight}<br/><br/>kg</td>
                    <td style=""text-align:right;"">{ .HpPerTon}<br/><br/>hp/ton</td>
                    <td style=""text-align:center;"">{ .Acceleration.ToString("0.0")}<br/><br/>s</td>
                    <td style=""text-align:right;"">{ .TopSpeed}<br/><br/>km/h</td>
                    <td style=""text-align:center;"">{f.Track.MyLike}</td>
                    <td style=""text-align:right;"">{(f.Track.Length / 1000).ToString("#.0")}</td>
                </tr>"
            End With
        Next
        html &= "</tbody></table></body></html>"
        html = html.Replace("[tmpOnLoad]", "")
        WebBrowser1.DocumentText = html
        Me.Cursor = Cursors.Default
        suspendDrawHTML = False
    End Sub

    Private Sub FiltersChanged(sender As Object, e As EventArgs)
        If Not Me.Visible Then Return
        If suspendDrawHTML Then Return
        delayedDrawHTML.Enabled = True
    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        If e.Url.LocalPath = "blank" Then Return
        e.Cancel = True
        If e.Url.LocalPath = "CAR" Then
            Favorites.Sort(Function(f, h) f.Car.Name.CompareTo(h.Car.Name))
            DrawHTML()
        ElseIf e.Url.LocalPath = "TRACK" Then
            Favorites.Sort(Function(f, h) f.Track.Name.CompareTo(h.Track.Name))
            DrawHTML()
        ElseIf e.Url.LocalPath = "TRACKLIKE" Then
            Favorites.Sort(Function(f, h) h.Track.MyLike.CompareTo(f.Track.MyLike))
            DrawHTML()
        ElseIf e.Url.LocalPath = "TRACKLEN" Then
            Favorites.Sort(Function(f, h) f.Track.Length.CompareTo(h.Track.Length))
            DrawHTML()
        ElseIf e.Url.LocalPath = "NAME" Then
            Favorites.Sort(Function(f, h) f.Name.CompareTo(h.Name))
            DrawHTML()
        ElseIf e.Url.LocalPath = "HP" Then
            Favorites.Sort(Function(f, h) f.Car.HP.CompareTo(h.Car.HP))
            DrawHTML()
        ElseIf e.Url.LocalPath = "LIKE" Then
            Favorites.Sort(Function(f, h) h.Car.MyLike.CompareTo(f.Car.MyLike))
            DrawHTML()
        ElseIf e.Url.LocalPath = "KG" Then
            Favorites.Sort(Function(f, h) f.Car.Weight.CompareTo(h.Car.Weight))
            DrawHTML()
        ElseIf e.Url.LocalPath = "HPTON" Then
            Favorites.Sort(Function(f, h) f.Car.HpPerTon.CompareTo(h.Car.HpPerTon))
            DrawHTML()
        ElseIf e.Url.LocalPath = "ACCEL" Then
            Favorites.Sort(Function(f, h) f.Car.Acceleration.CompareTo(h.Car.Acceleration))
            DrawHTML()
        ElseIf e.Url.LocalPath = "SPEED" Then
            Favorites.Sort(Function(f, h) f.Car.TopSpeed.CompareTo(h.Car.TopSpeed))
            DrawHTML()
        ElseIf e.Url.LocalPath.StartsWith("SELECTFAV") Then
            Favorite_Load(e.Url.LocalPath.Replace("SELECTFAV", ""))
            DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Favorite_Load(pName As String)
        Dim tmpPath As String = MyIniPath & "\FAV " & pName & ".INI"
        Try
            If Not FileIO.FileSystem.FileExists(tmpPath) Then
                MsgBox("A favorite set named «" & tmpPath & "» does not exist.", MsgBoxStyle.Information, "Load Favorite Set")
                Return
            End If
            Dim tmpIni As New INIFile()
            tmpIni.Load(tmpPath)
            FormMain.Scenario_Load(tmpIni)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, MsgBoxStyle.Exclamation, "Load Favorite Set")
        End Try
        Me.Close()
    End Sub

    Private Sub delayedDrawHTML_Tick(sender As Object, e As EventArgs) Handles delayedDrawHTML.Tick
        DrawHTML()
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If Not FormMain.ValidateChoices() Then Return
        Dim tmpName As String, tmpPath As String
        tmpName = InputBox("What NAME do you want to give to this set of Selected Car, Selected Track and Opponents ?", "Save Favorite Set", SelectedCar.Name & " " & SelectedTrack.Name)
        If String.IsNullOrWhiteSpace(tmpName) Then Return
        If tmpName.Length > 60 Then
            MsgBox("Name too long. Reduce " & (tmpName.Length - 60).ToString & " characters", MsgBoxStyle.Information, "Save Favorite Set")
            Return
        End If
        tmpPath = MyIniPath & "\FAV " & tmpName & ".INI"
        Try
            If FileIO.FileSystem.FileExists(tmpPath) Then
                If MsgBox("A favorite set named «" & tmpName & "» allready existis." & vbCrLf & vbCrLf & "Overwrite it ?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Return
            End If
            Dim tmpIni As New INIFile()
            tmpIni.Load(tmpPath)
            FormMain.Scenario_Save(tmpIni)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, MsgBoxStyle.Exclamation, "Save Favorite Set")
        End Try
        Me.Close()
    End Sub

    Private Sub btManage_Click(sender As Object, e As EventArgs) Handles btManage.Click
        Diagnostics.Process.Start(MyIniPath)
        Me.Close()
    End Sub

End Class
