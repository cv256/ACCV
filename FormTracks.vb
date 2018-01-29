Public Class FormTracks
    Private suspendDrawHTML As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        suspendDrawHTML = True

        For Each c As Control In Me.Controls
            If TypeOf (c) IsNot TextBox Then Continue For
            AddHandler c.TextChanged, AddressOf FiltersChanged
        Next

        Dim ck As New chk3state With {.Name = "chkModded", .Text = "MOD", .Left = Label4.Left, .Top = txtLikeTo.Bottom + 5, .AutoSize = True}
        Me.Controls.Add(ck)
        AddHandler ck.CheckStateChanged, AddressOf FiltersChanged

        suspendDrawHTML = False
        DrawHTML()
    End Sub

    Private Sub DrawHTML()
        If suspendDrawHTML Then Return
        suspendDrawHTML = True
        delayedDrawHTML.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Dim PreviewWidth As Integer = 256, tmpOnLoad As String = ""
        Dim html As String = "<html><head><title>AC CV Tracks</title>" & CSS & "</head><body [tmpOnLoad]>"
        html &= "<table border=1 style=""border-collapse:collapse;font-size:" & FontSize & "pt;"">"
        html &= "<thead><tr style=""background-color:darkblue;color:white;"">"
        html &= "<td style=""text-align:center;"">Foto</td>" &
            "<td style=""text-align:center;"">Map</td>" &
            "<td>Name</td>" &
            "<td style=""text-align:center;""><a href=""LIKE"">LIKE</a></td>" &
            "<td style=""text-align:right;""><a href=""LEN"">KMs</a></td>" &
            "<td style=""text-align:center;""><a href=""BESTLAP"">Best Lap</a></td>" &
            "<td style=""text-align:center;""><a href=""WIDTH"">Width</a></td>" &
            "<td style=""text-align:center;""><a href=""TAG"">Tags</a></td>" &
            "<td style=""text-align:center;""><a href=""DRIVEN"">Driven</a></td>" &
            "<td ><a href=""COUNTRY"">Country</a></td>"
        'For Each t As String In TagNames
        '    html &= "<td style=""text-align:center;""><a href=""TAG" & t & """>" & t & "</a></td>"
        'Next
        html &= "</tr></thead><tbody>"

        If Not IsNumeric(txtLenFrom.Text) Then txtLenFrom.Text = "0"
        If Not IsNumeric(txtLenTo.Text) Then txtLenTo.Text = "9999"
        Dim lenFrom As Integer = CInt(txtLenFrom.Text)
        Dim lenTo As Integer = CInt(txtLenTo.Text)

        If Not IsNumeric(txtLikeFrom.Text) Then txtLikeFrom.Text = "0"
        If Not IsNumeric(txtLikeTo.Text) Then txtLikeTo.Text = "10"
        Dim likeFrom As Integer = CInt(txtLikeFrom.Text)
        Dim likeTo As Integer = CInt(txtLikeTo.Text)

        Dim tot As Integer = 0
        For Each t As Track In Tracks
            If txtText.TextLength > 0 Then
                Dim tmpTxt As String = txtText.Text.ToUpper
                If t.Name.ToUpper.Contains(tmpTxt) = False AndAlso t.PathConfig.ToUpper.Contains(tmpTxt) = False AndAlso t.MyNotes.ToUpper.Contains(tmpTxt) = False Then Continue For
            End If
            If t.Length < lenFrom Then Continue For
            If lenTo <> 9999 AndAlso t.Length / 1000 > lenTo Then Continue For
            If t.MyLike < likeFrom Then Continue For
            If t.MyLike > likeTo Then Continue For

            Select Case CType(Me.Controls("chkModded"), chk3state).CheckState
                Case CheckState.Checked
                    If Not t.Modded Then Continue For
                Case CheckState.Unchecked
                    If t.Modded Then Continue For
            End Select


            Dim tmpColor As String = "#000000"
            If Not IsNothing(SelectedTrack) AndAlso SelectedTrack.Equals(t) Then
                tmpColor = "#808080"
                tmpOnLoad = "onload=""document.getElementById('SELECTTRACK" & t.PathConfig & "').scrollIntoView();"""
            End If
            html &= "<tr style=""background-color:" & tmpColor & ";color:white;"">"
            ' foto:
            'Dim hFactor As Double = t.FotoSize.Height / LineHeight
            'Dim wfactor As Double = t.FotoSize.Width / PreviewWidth
            'If wfactor > hFactor Then hFactor = wfactor
            'If hFactor > 0 Then
            html &= "<td id=""SELECTTRACK" & t.PathConfig & """ style=""text-align:center;""><a href=""SELECTTRACK" & t.PathConfig & """><img alt=""Click to select this Track"" src=""" & t.FotoPath & """ style=""width:" & PreviewWidth & "px;""></a></td>" '  CInt(t.FotoSize.Width / hFactor) & "px;height:" & CInt(t.FotoSize.Height / hFactor)
            'Else
            'html &= "<td></td>"
            'End If
            ' map:
            'hFactor = t.MapSize.Height / LineHeight
            'wfactor = t.MapSize.Width / PreviewWidth
            'If wfactor > hFactor Then hFactor = wfactor
            'If hFactor > 0 Then
            html &= "<td style=""text-align:center;""><a href=""SELECTTRACK" & t.PathConfig & """><img alt=""Click to select this Track"" src=""" & t.MapPath & """ style=""width:" & PreviewWidth & "px;""></a></td>" 'CInt(t.MapSize.Width / hFactor) & "px;height:" & CInt(t.MapSize.Height / hFactor)
            'Else
            'html &= "<td></td>"
            'End If
            ' name:
            html &= "<td><b>" & t.Name & "</b>" &
                "<br/><a href=""EDITTRACK" & t.PathConfig & """><i>" & CStr(IIf(String.IsNullOrEmpty(t.MyNotes), "(click to edit your notes)", t.MyNotes)) & "</i></a></td>"
            ' like:
            html &= "<td style=""text-align:center;"">" & CStr(IIf(t.Modded, "<b>MOD</b><br/><br/>", "")) & "<a href=""EDITTRACK" & t.PathConfig & """><b>" & t.MyLike & "</b></a></td>"
            html &= "<td style=""text-align:right;"">" & (t.Length / 1000).ToString("#.0") & "</td>"
            If MyHistory.TrackBest(t.Name) IsNot Nothing Then
                html &= $"<td style=""text-align:center;""><a href=""HISTORYTRACK{t.Name}"">
                    {TimeSecondsDescr(MyHistory.TrackBest(t.Name).BestLapTime)}
                    <br/><br/>{MyHistory.TrackBest(t.Name).BestLapDate.ToShortDateString}
                    <br/>{MyHistory.TrackBest(t.Name).Car}</a></td>"
            Else
                html &= "<td></td>"
            End If
            html &= "<td style=""text-align: center;"">" & t.Width & "</td>"
            html &= "<td style=""text-align:center;"">" & String.Join("<br/>", t.Tags.ToArray) & "</td>"
            html &= "<td style=""text-align: center;"">" & If(MyHistory.TrackCars(t.Name) = 0, "", $"<a href=""HISTORYTRACK{t.Name}"">
                {CInt(MyHistory.TrackTotalTimeDriven(t.Name).TotalMinutes)}<br/>minutes
                <br/><br/>{MyHistory.TrackCars(t.Name)} cars</a>") & "</td>"
            html &= "<td >" & t.Country & "</td>"
            ' tags:
            'For Each tagClass As String In TagNames
            '    html &= "<td style=""text-align:center;"">" & c.TagsByClass(tagClass) & "</td>"
            'Next
            html &= "</tr>"
            tot += 1
        Next
        html &= "</tbody></table></body></html>"
        html = html.Replace("[tmpOnLoad]", tmpOnLoad)
        WebBrowser1.DocumentText = html
        lbTotals.Text = "( " & tot & " / " & Tracks.Count & " tracks )"
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
        If e.Url.LocalPath = "LEN" Then
            Tracks.Sort(Function(f, h) f.Length.CompareTo(h.Length))
            DrawHTML()
        ElseIf e.Url.LocalPath = "LIKE" Then
            Tracks.Sort(Function(f, h) h.MyLike.CompareTo(f.MyLike))
            DrawHTML()
        ElseIf e.Url.LocalPath = "WIDTH" Then
            Tracks.Sort(Function(f, h) f.Width.CompareTo(h.Width))
            DrawHTML()
        ElseIf e.Url.LocalPath = "BESTLAP" Then
            Tracks.Sort(Function(f, h) CInt(If(MyHistory.TrackBest(f.Name) Is Nothing, 0, MyHistory.TrackBest(f.Name).BestLapTime)).CompareTo(CInt(If(MyHistory.TrackBest(h.Name) Is Nothing, 0, MyHistory.TrackBest(h.Name).BestLapTime))))
            DrawHTML()
        ElseIf e.Url.LocalPath = "DRIVEN" Then
            Tracks.Sort(Function(f, h) MyHistory.TrackTotalTimeDriven(f.Name).CompareTo(MyHistory.TrackTotalTimeDriven(h.Name)))
            DrawHTML()
        ElseIf e.Url.LocalPath = "COUNTRY" Then
            Tracks.Sort(Function(f, h) f.Country.CompareTo(h.Country))
            DrawHTML()
        ElseIf e.Url.LocalPath.StartsWith("TAG") Then
            'Dim tmpClass As String = e.Url.LocalPath.Replace("TAG", "")
            Tracks.Sort(Function(f, h) String.Join("|", f.Tags.ToArray).CompareTo(String.Join("|", h.Tags.ToArray)))
            DrawHTML()
        ElseIf e.Url.LocalPath.StartsWith("EDITTRACK") Then
            Dim tmpTrack As Track
            tmpTrack = Track.FindByPath(e.Url.LocalPath.Replace("EDITTRACK", ""))
            Dim tmpFrm As New FormEdit
            tmpFrm.txtLikes.Value = CInt(IIf(tmpTrack.MyLike = 0, 5, tmpTrack.MyLike))
            tmpFrm.txtNotes.Text = tmpTrack.MyNotes.Replace("<br/>", vbCrLf)
            If tmpFrm.ShowDialog <> DialogResult.OK Then Return
            tmpTrack.MyLike = tmpFrm.txtLikes.Value
            tmpTrack.MyNotes = tmpFrm.txtNotes.Text.Replace(vbCrLf, "<br/>")
            MyIni.Value("TRACKLIKES", tmpTrack.PathConfig.ToUpper) = tmpTrack.MyLike.ToString
            MyIni.Value("TRACKNOTES", tmpTrack.PathConfig.ToUpper) = tmpTrack.MyNotes
            Me.Cursor = Cursors.WaitCursor
            MyIni.Save()
            Me.Cursor = Cursors.Default
            DrawHTML()
        ElseIf e.Url.LocalPath.StartsWith("SELECTTRACK") Then
            SelectedTrack = Track.FindByPath(e.Url.LocalPath.Replace("SELECTTRACK", ""))
            Me.Close()
        ElseIf e.Url.LocalPath.StartsWith("HISTORYTRACK") Then
            Dim f As New FormHistory
            f.Show(MyHistory, pTrack:=e.Url.LocalPath.Replace("HISTORYTRACK", ""), pCar:="")
        End If
    End Sub

    Private Sub delayedDrawHTML_Tick(sender As Object, e As EventArgs) Handles delayedDrawHTML.Tick
        DrawHTML()
    End Sub
End Class
