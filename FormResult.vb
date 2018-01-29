Public Class FormResult

    Private Class Player
        Public Name As String
        Public Car As String
        Public Skin As String
        Public BestLap As Integer
        Public Sectors As New List(Of Sector)
    End Class

    Private Class Sector
        Public Name As String
        Public Lap As Integer
        Public Sector As Integer
        Public SectorTime As Integer
        Public TotalTime As Integer
    End Class

    Public Shadows Function ShowDialog() As DialogResult
        Dim ui As String = ""
        Try
            Using sr As New System.IO.StreamReader(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\out\race_out.json")
                ui = sr.ReadToEnd()
            End Using
        Catch ex As Exception
            Return DialogResult.Abort
        End Try

        Try
            ui = ui.Trim(" "c).Replace(vbCr, "").Replace(vbLf, "").Replace(vbTab, "") ' there will be just 1 session (unless they launched ACS career or something with various sessions using its menu)
            ' read Players:
            Dim Players As New List(Of Player), tmpPlayers As String = "", HumanPlayer As Player
            tmpPlayers = GetJsonString(ui, "players")
            For Each p As String In tmpPlayers.Split("{"c)
                If String.IsNullOrEmpty(p) Then Continue For
                Players.Add(New Player With {.Name = GetJsonString(p, "name"), .Car = Car.FindName(GetJsonString(p, "car")), .Skin = GetJsonString(p, "skin")})
                Players.Last.Sectors.Add(New Sector With {.Name = "START"}) ' we ADD 1 SECTOR to each player
                If Players.Last.Name = "HUMAN" Then HumanPlayer = Players.Last
            Next
            If Players.Count < 1 Then Return DialogResult.Abort

            ' read Section Times:
            Dim sessions As String = GetJsonString(ui, "sessions")
            Dim laps As String() = GetJsonString(sessions, "laps").Split("{"c) ' for each lap and for each player, so 2 laps and 4 players returns 8 items
            For Each l As String In laps ' they come ordered by Player, Lap
                If String.IsNullOrEmpty(l) Then Continue For
                Dim idxL As Integer = CInt(GetJsonString(l, "lap"))
                Dim idxS As Integer = 0, idxSmax As Integer = GetJsonString(l, "sectors").Split(","c).Count
                For Each sectorTime As String In GetJsonString(l, "sectors").Split(","c)
                    If sectorTime.Replace(" ", "") = "" Then Exit For
                    Dim sTime As Integer = CInt(sectorTime.Replace(" ", ""))
                    idxS += 1
                    Dim tmpTxt As String
                    If idxS >= idxSmax Then
                        tmpTxt = "LAP " & (idxL + 1).ToString
                    Else
                        tmpTxt = "Lap " & idxL.ToString & " +" & idxS.ToString
                    End If
                    Players(CInt(GetJsonString(l, "car"))).Sectors.Add(New Sector With {.Name = tmpTxt, .Lap = idxL, .Sector = idxS, .SectorTime = sTime})
                Next sectorTime
            Next l

            ' read Best Times:
            For Each l As String In GetJsonString(sessions, "bestLaps").Split("{"c) ' for each each player, so 4 players returns 4 items ' they come ordered by Player
                If String.IsNullOrEmpty(l) Then Continue For
                Players(CInt(GetJsonString(l, "car"))).BestLap = CInt(GetJsonString(l, "time").Replace(" ", ""))
            Next l

            If HumanPlayer IsNot Nothing AndAlso HumanPlayer.Sectors.Count < 2 Then ' race_out.json often comes with empty sessions.laps (and sessions.lapstotal and sessions.duration). In that cases I'll try to use laps.ini
                Dim lapsIni As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
                lapsIni.Load(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\out\laps.ini")
                For idxL As Integer = 0 To 999
                    If Not lapsIni.Sections.ContainsKey("LAP_" & idxL) Then Exit For
                    With lapsIni.Sections("LAP_" & idxL)
                        Dim lTime As Integer = CInt(.Keys("TIME").Value.Replace(" ", ""))
                        If HumanPlayer.BestLap = 0 OrElse HumanPlayer.BestLap > lTime Then HumanPlayer.BestLap = lTime
                        Dim idxSmax As Integer = CInt(.Keys("SPLITS").Value.Replace(" ", ""))
                        If idxSmax = 0 Then
                            HumanPlayer.Sectors.Add(New Sector With {.Name = "LAP " & (idxL + 1).ToString, .Lap = idxL + 1, .Sector = 1, .SectorTime = lTime})
                        Else
                            For idxS As Integer = 1 To idxSmax
                                If Not .Keys.ContainsKey("SPLIT_" & idxS - 1) Then Exit For
                                Dim sTime As Integer = CInt(.Keys("SPLIT_" & idxS - 1).Value.Replace(" ", ""))
                                Dim tmpTxt As String
                                If idxS >= idxSmax Then
                                    tmpTxt = "LAP " & (idxL + 1).ToString
                                Else
                                    tmpTxt = "Lap " & (idxL).ToString & " +" & (idxS).ToString
                                End If
                                HumanPlayer.Sectors.Add(New Sector With {.Name = tmpTxt, .Lap = idxL + 1, .Sector = idxS, .SectorTime = sTime})
                            Next idxS
                        End If
                    End With
                Next idxL
            End If

            ' remove players that have no Sectors:
            Players.RemoveAll(Function(p) p.Sectors.Count < 2)
            If Players.Count < 1 Then Return DialogResult.Abort

            ' calculate total times for each player/section:
            For Each p As Player In Players
                p.Sectors(0).SectorTime = Players.Min(Function(pp) pp.Sectors(1).SectorTime)
                p.Sectors(0).TotalTime = p.Sectors(0).SectorTime
                Dim bestLap As Integer = 0
                Dim tot As Integer = 0
                For n As Integer = 1 To p.Sectors.Count - 1
                    tot += p.Sectors(n).SectorTime
                    p.Sectors(n).TotalTime = tot
                Next
            Next
            ' save Human best lap and time driven
            ' Track, Car, TotalTimeDriven, BestLapTime, BestLapDate
            If HumanPlayer IsNot Nothing AndAlso HumanPlayer.Sectors.Last.TotalTime > 0 Then
                If MyHistory Is Nothing Then ' just in case we had some error loading history before, reloads history
                    MyHistory = New History
                    If Not MyHistory.Load() Then MyHistory = Nothing
                End If
                If MyHistory IsNot Nothing Then
                    With MyHistory.FindTrackCar(SelectedTrack.Name, SelectedCar.Name) ' we shouldnt use SelectedTrack.Name, SelectedCar.Name, we should use race_out.track and HumanPlayer.Car
                        If HumanPlayer.BestLap > 0 Then
                            If .BestLapTime = 0 Then
                                MsgBox($"First  time on track
{ .Track}

with car
{ .Car}

{TimeSecondsDescr(HumanPlayer.BestLap)}")
                                .BestLapTime = HumanPlayer.BestLap
                                .BestLapDate = Now
                            ElseIf HumanPlayer.BestLap < .BestLapTime Then
                                MsgBox($"new  Best Lap  on track
{ .Track}

with car
{ .Car}

{TimeSecondsDescr(HumanPlayer.BestLap)}

{TimeSecondsDescr(HumanPlayer.BestLap - .BestLapTime)}")
                                .BestLapTime = HumanPlayer.BestLap
                                .BestLapDate = Now
                            End If
                        End If
                        .TotalTimeDriven += HumanPlayer.Sectors.Last.TotalTime
                    End With
                    MyHistory.Save()
                End If
            End If

            ' sort players by TotalTime
            Players.Sort(Function(p1, p2) CInt(IIf(p1.Sectors.Count < p2.Sectors.Count, 1, IIf(p1.Sectors.Count > p2.Sectors.Count, -1, IIf(p1.Sectors.Last.TotalTime > p2.Sectors.Last.TotalTime, 1, -1)))))

            ' Chart it:
            Chart1.Series.Clear()
            Chart1.ChartAreas(0).AxisY.Enabled = DataVisualization.Charting.AxisEnabled.False
            Chart1.ChartAreas(0).AxisX.Minimum = 0
            Chart1.ChartAreas(0).AxisX.Maximum = Players.Max(Function(pp) pp.Sectors.Count - 1)
            Dim FontBold As New Font(Chart1.Font, FontStyle.Bold)
            For Each p As Player In Players
                Dim auxSerie As System.Windows.Forms.DataVisualization.Charting.Series ' MICROSOFT CHART HAS A BUG ! IF SERIES STARTS OR ENDS WITH SPACES CRASHES !
                Dim auxSerieName As String = p.Name & vbCrLf & p.Car & vbCrLf
                Dim myTotalTime As Integer = p.Sectors(p.Sectors.Count - 1).TotalTime
                Dim bestTotalTime As Integer = Players.Where(Function(pp) pp.Sectors.Count >= p.Sectors.Count).Min(Function(pp) pp.Sectors(p.Sectors.Count - 1).TotalTime)
                If p.Sectors.Count = Players.Max(Function(pp) pp.Sectors.Count) Then
                    auxSerieName &= TimeSecondsDescr(myTotalTime)
                    If Players.Count > 1 Then auxSerieName &= "  (" & TimeDiffDescr(bestTotalTime, myTotalTime) & ")"
                Else
                    auxSerieName &= "DNF (" & (p.Sectors.Count - 1).ToString & "/" & Players.Max(Function(pp) pp.Sectors.Count - 1) & " sections=" & TimeSecondsDescr(myTotalTime) & ")"
                End If
                auxSerie = Chart1.Series.Add(auxSerieName & vbCrLf)
                auxSerie.ChartType = DataVisualization.Charting.SeriesChartType.Line
                auxSerie.MarkerStyle = DataVisualization.Charting.MarkerStyle.Cross
                If p.Name = "HUMAN" Then
                    auxSerie.Font = FontBold
                    auxSerie.BorderWidth = 4
                End If
                Dim lapTime As Integer = 0
                For Each s As Sector In p.Sectors
                    If Not s.Name.StartsWith("START") Then lapTime += s.SectorTime
                    If Players.Count > 1 Then
                        Dim SectionPlayers As List(Of Player) = Players.Where(Function(pp) pp.Sectors.Exists(Function(pt) pt.Name = s.Name)).ToList
                        Dim TotalBest As Integer = SectionPlayers.Min(Function(pp) pp.Sectors.First(Function(pt) pt.Name = s.Name).TotalTime)
                        With auxSerie.Points.Add(TotalBest - s.TotalTime)
                            If Not s.Name.StartsWith("START") Then
                                If SectionPlayers.Count > 1 Then
                                    Dim SectionBest As Integer = SectionPlayers.Min(Function(pp) pp.Sectors.First(Function(pt) pt.Name = s.Name).SectorTime)
                                    .Label = TimeDiffDescr(SectionBest, s.SectorTime, "sect.")
                                Else
                                    .Label = "sect." & TimeSecondsDescr(s.SectorTime)
                                End If
                                If s.Name.StartsWith("LAP") Then
                                    .Label = TimeSecondsDescr(lapTime) & vbCrLf & .Label
                                    lapTime = 0
                                End If
                            End If
                            .XValue = auxSerie.Points.Count - 1
                            Chart1.Series(0).Points(CInt(.XValue)).AxisLabel = s.Name
                        End With
                    Else
                        Dim SectorBest As Integer = Players.Min(Function(pp) pp.Sectors.Where(Function(ps) ps.Sector = s.Sector).Min(Function(ps) ps.SectorTime))
                        With auxSerie.Points.Add(SectorBest - s.SectorTime)
                            If Not s.Name.StartsWith("START") Then
                                .Label = TimeDiffDescr(SectorBest, s.SectorTime, "sect.")
                                If s.Name.StartsWith("LAP") Then
                                    .Label = TimeSecondsDescr(lapTime) & vbCrLf & .Label
                                    lapTime = 0
                                End If
                            End If
                            .XValue = auxSerie.Points.Count - 1
                            Chart1.Series(0).Points(CInt(.XValue)).AxisLabel = s.Name
                        End With
                    End If
                Next s
            Next p
            DialogResult = DialogResult.OK
            Return MyBase.ShowDialog

        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace)
        End Try
        Return DialogResult.Abort
    End Function


    Private Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        Close()
    End Sub

End Class