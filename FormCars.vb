Public Class FormCars
    Private suspendDrawHTML As Boolean

    Public SelectedCar As Car

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        suspendDrawHTML = True
        'DialogResult = DialogResult.No

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
        Dim PreviewWidth As Integer = 150, tmpOnLoad As String = "" ', BrandWidth As Integer = 60
        Dim html As String = "<html><head><title>AC CV Cars</title>" & CSS & "</head><body [tmpOnLoad]>"
        html &= "<table border=1 style=""border-collapse:collapse;font-size:" & FontSize & "pt;"">"
        ' HEADERS:
        html &= "  <thead><tr style=""background-color:darkblue;color:white;"">"
        html &= "<td><a href=""BRAND"">Brand</a></td>" &
            "<td>Preview</td>" &
            "<td>Name</td>" &
            "<td style=""text-align:center;""><a href=""LIKE"">LIKE</a></td>" &
            "<td style=""text-align:right;""><a href=""HP"">HP</a></td>" &
            "<td style=""text-align:right;""><a href=""KG"">Kg</a></td>" &
            "<td style=""text-align:right;""><a href=""HPTON"">HP/Ton</a></td>" &
            "<td style=""text-align:center;""><a href=""ACCEL"">0-100</a></td>" &
            "<td style=""text-align:right;""><a href=""SPEED"">Speed</a></td>" &
            "<td style=""text-align:right;""><a href=""DRIVEN"">Driven</a></td>" &
            "<td style=""text-align:right;""><a href=""COG"">CoG F/R</a></td>"
        For Each t As String In TagNames
            html &= "<td style=""text-align:center;""><a href=""TAG" & t & """>" & t & "</a></td>"
        Next
        html &= "</tr></thead><tbody>"

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

        ' FILTER :
        FilteredCars = New List(Of Car)
        For Each c As Car In Cars
            With c
                If txtText.TextLength > 0 Then
                    Dim tmpTxt As String = txtText.Text.ToUpper
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

                FilteredCars.Add(c)
            End With
        Next c
        lbTotals.Text = "( " & FilteredCars.Count & " / " & Cars.Count & " cars )"

        ' HTML :
        Dim tmpImg As String ' "" = Auto thumbnails
        If FilteredCars.Count > 55 AndAlso Not ckShowThumbnails.Checked Then tmpImg = "SELECT" ' No thumbnails
        For Each c As Car In FilteredCars
            With c
                Dim tmpColor As String = "#000000"
                If c.Equals(SelectedCar) Then
                    tmpColor = "#808080"
                    tmpOnLoad = "onload=""document.getElementById('EDITCAR" & Car.Folder(.Path) & "').scrollIntoView();"""
                Else
                    For nO As Integer = 0 To Opponents.Count - 1
                        If c.Equals(Opponents(nO).Car) Then
                            tmpColor = "#202020"
                            Exit For
                        End If
                    Next
                End If
                html &= "<tr style=""background-color:" & tmpColor & ";color:white;"">" &
        "<td id=""EDITCAR" & Car.Folder(.Path) & """>" & .Brand & "</td>" &
        "<td><a href=""SELECTCAR" & Car.Folder(.Path) & """>" & If(tmpImg Is Nothing, "<img title=""Click to select this Car"" src=""" & .Path & "\skins\" & .SelectedSkinPath & "\preview.jpg" & """ style=""width:" & PreviewWidth & "px;"">", tmpImg) & "</a></td>" &
        "<td><b>" & .Name & "</b>" &
        "<br/><a href=""EDITCAR" & Car.Folder(.Path) & """ title=""Click to edit your notes & likes"">" & CStr(IIf(String.IsNullOrEmpty(.MyNotes), "(click to edit your notes)", .MyNotes)) & "</a></td>" &
        "<td style=""text-align:center;""><a href=""EDITCAR" & Car.Folder(.Path) & """ title=""Click to edit your notes & likes""><b>" & .MyLike & "</b></a>" &
            CStr(IIf(.Modded, "<br/><br/><a href=""CHANGEMOD" & Car.Folder(.Path) & """ title=""Click to CHANGE this MOD"">MOD</a>", "")) &
            "<br/><br/><a href=""SELECTSKIN" & Car.Folder(.Path) & """ title=""Click to select skin"">" & .Skins.Count & " skins</a></td>" &
        "<td style=""text-align:right;"">" & .HP & "<br/><br/>hp</td>" &
        "<td style=""text-align:right;"">" & .Weight & "<br/><br/>kg</td>" &
        "<td style=""text-align:right;"">" & .HpPerTon & "<br/><br/>hp/ton</td>" &
        "<td style=""text-align:center;"">" & .Acceleration.ToString("0.0") & "<br/><br/>s</td>" &
        "<td style=""text-align:right;"">" & .TopSpeed & "<br/><br/>km/h</td>" &
        "<td style=""text-align:right;"">" & If(MyHistory.CarTracks(.Name) = 0, "", $"<a href=""HISTORYCAR{ .Name}"">{CInt(MyHistory.CarTotalTimeDriven(.Name).TotalMinutes)}<br/>minutes<br/><br/>{MyHistory.CarTracks(.Name)} tracks</a>") & "</td>" &
        $"<td style=""text-align:right;"">{ .CoGFront}<br/>{ .CoGRear}</td>"
                ' tags:
                For Each tagClass As String In TagNames
                    html &= "<td style=""text-align:center;"">" & .TagsByClass(tagClass, "<br/>") & "</td>"
                Next
                html &= "</tr>"
            End With
        Next
        html &= "</tbody></table></body></html>"
        html = html.Replace("[tmpOnLoad]", tmpOnLoad)
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
        If e.Url.LocalPath = "HP" Then
            Cars.Sort(Function(f, h) f.HP.CompareTo(h.HP))
            DrawHTML()
        ElseIf e.Url.LocalPath = "LIKE" Then
            Cars.Sort(Function(f, h) h.MyLike.CompareTo(f.MyLike))
            DrawHTML()
        ElseIf e.Url.LocalPath = "BRAND" Then
            Cars.Sort(Function(f, h) f.Brand.CompareTo(h.Brand))
            DrawHTML()
        ElseIf e.Url.LocalPath = "KG" Then
            Cars.Sort(Function(f, h) f.Weight.CompareTo(h.Weight))
            DrawHTML()
        ElseIf e.Url.LocalPath = "HPTON" Then
            Cars.Sort(Function(f, h) f.HpPerTon.CompareTo(h.HpPerTon))
            DrawHTML()
        ElseIf e.Url.LocalPath = "ACCEL" Then
            Cars.Sort(Function(f, h) f.Acceleration.CompareTo(h.Acceleration))
            DrawHTML()
        ElseIf e.Url.LocalPath = "SPEED" Then
            Cars.Sort(Function(f, h) f.TopSpeed.CompareTo(h.TopSpeed))
            DrawHTML()
        ElseIf e.Url.LocalPath = "DRIVEN" Then
            Cars.Sort(Function(f, h) MyHistory.CarTotalTimeDriven(f.Name).CompareTo(MyHistory.CarTotalTimeDriven(h.Name)))
            DrawHTML()
        ElseIf e.Url.LocalPath = "COG" Then
            Cars.Sort(Function(f, h) f.CoGFront.CompareTo(h.CoGFront))
            DrawHTML()
        ElseIf e.Url.LocalPath.StartsWith("TAG") Then
            Dim tmpClass As String = e.Url.LocalPath.Replace("TAG", "")
            Cars.Sort(Function(f, h) f.TagsByClass(tmpClass, "").CompareTo(h.TagsByClass(tmpClass, "")))
            DrawHTML()
        ElseIf e.Url.LocalPath.StartsWith("CHANGEMOD") Then
            SelectedCar = Car.Find(e.Url.LocalPath.Replace("CHANGEMOD", ""))
            Dim tmpFrm As New FormChangeMod
            tmpFrm.Init(SelectedCar)
            If tmpFrm.ShowDialog <> DialogResult.OK Then Return

        ElseIf e.Url.LocalPath.StartsWith("EDITCAR") Then
            SelectedCar = Car.Find(e.Url.LocalPath.Replace("EDITCAR", ""))
            Dim tmpFrm As New FormEdit
            tmpFrm.txtLikes.Value = CInt(IIf(SelectedCar.MyLike = 0, 5, SelectedCar.MyLike))
            tmpFrm.txtNotes.Text = SelectedCar.MyNotes.Replace("<br/>", vbCrLf)
            If tmpFrm.ShowDialog <> DialogResult.OK Then Return
            SelectedCar.MyLike = tmpFrm.txtLikes.Value
            SelectedCar.MyNotes = tmpFrm.txtNotes.Text.Replace(vbCrLf, "<br/>")
            MyIni.Value("LIKES", Car.Folder(SelectedCar.Path).ToUpper) = SelectedCar.MyLike.ToString
            MyIni.Value("NOTES", Car.Folder(SelectedCar.Path).ToUpper) = SelectedCar.MyNotes
            Me.Cursor = Cursors.WaitCursor
            MyIni.Save()
            Me.Cursor = Cursors.Default
            DrawHTML()
        ElseIf e.Url.LocalPath.StartsWith("SELECTSKIN") Then
            SelectedCar = Car.Find(e.Url.LocalPath.Replace("SELECTSKIN", ""))
            Dim tmpfrm As New FormSkins With {.StartPosition = FormStartPosition.Manual, .Height = Me.Height, .Top = Me.Top, .Left = Me.Left + 400}
            If tmpfrm.ShowDialog(SelectedCar, SelectedCar.SelectedSkinPath, Me) <> DialogResult.OK Then Return
            SelectedCar.SelectedSkinPath = tmpfrm.SelectedSkin
            DrawHTML()
        ElseIf e.Url.LocalPath.StartsWith("SELECTCAR") Then
            Me.SelectedCar = Car.Find(e.Url.LocalPath.Replace("SELECTCAR", ""))
            DialogResult = DialogResult.OK
            Me.Close()
        ElseIf e.Url.LocalPath.StartsWith("HISTORYCAR") Then
            Dim f As New FormHistory
            f.Show(MyHistory, pTrack:="", pCar:=e.Url.LocalPath.Replace("HISTORYCAR", ""))
        End If
    End Sub

    Private Sub ckShowThumbnails_CheckedChanged(sender As Object, e As EventArgs) Handles ckShowThumbnails.CheckedChanged
        DrawHTML()
    End Sub

    Private Sub delayedDrawHTML_Tick(sender As Object, e As EventArgs) Handles delayedDrawHTML.Tick
        DrawHTML()
    End Sub

    Private Sub btRnd_Click(sender As Object, e As EventArgs) Handles btRnd.Click
        If FilteredCars.Count < 1 Then
            MsgBox("For selecting a random car, your filtering must return at least one car")
            Return
        End If
        DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

End Class
