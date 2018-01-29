Public Class FormHistory
    Private H As History, Track As String, Car As String
    Public Shadows Sub Show(pH As History, pTrack As String, pCar As String)
        H = pH : Track = pTrack.ToUpper : Car = pCar.ToUpper
        Me.Text &= " - " & If(pCar > "", pCar, pTrack)
        ListView1.Columns.Add(If(pCar > "", "Track", "Car"))
        ListView1.Columns.Add("Best Lap")
        ListView1.Columns.Add("Best Lap Date")
        ListView1.Columns.Add("Total Time Driven")
        Fill(1)
        Me.Top = 0
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height - 70
        MyBase.Show()
        ListView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize)
        ListView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        ListView1.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        H.OrderBy(Function(f) f.BestLapTime)
        Fill(e.Column)
    End Sub

    Private Sub Fill(pOrder As Integer)
        ListView1.Items.Clear()
        Dim myH As List(Of HistoryItem)
        If Car > "" Then
            Select Case pOrder
                Case 1
                    myH = H.Where(Function(f) f.Car = Car).OrderBy(Function(h) If(h.BestLapTime > 0, h.BestLapTime, Integer.MaxValue)).ToList()
                Case 2
                    myH = H.Where(Function(f) f.Car = Car).OrderBy(Function(h) h.BestLapDate).ToList()
                Case 3
                    myH = H.Where(Function(f) f.Car = Car).OrderBy(Function(h) -h.TotalTimeDriven).ToList()
                Case Else
                    myH = H.Where(Function(f) f.Car = Car).OrderBy(Function(h) h.Track).ToList()
            End Select
        Else
            Select Case pOrder
                Case 1
                    myH = H.Where(Function(f) f.Track = Track).OrderBy(Function(h) If(h.BestLapTime > 0, h.BestLapTime, Integer.MaxValue)).ToList()
                Case 2
                    myH = H.Where(Function(f) f.Track = Track).OrderBy(Function(h) h.BestLapDate).ToList()
                Case 3
                    myH = H.Where(Function(f) f.Track = Track).OrderBy(Function(h) -h.TotalTimeDriven).ToList()
                Case Else
                    myH = H.Where(Function(f) f.Track = Track).OrderBy(Function(h) h.Car).ToList()
            End Select
        End If
        For Each hi As HistoryItem In myH
            With ListView1.Items.Add(If(Car > "", hi.Track, hi.Car))
                .SubItems.Add(TimeSecondsDescr(hi.BestLapTime))
                .SubItems.Add(hi.BestLapDate.ToString("yyyy-MM-dd hh:mm"))
                .SubItems.Add(CInt(New TimeSpan(0, 0, 0, 0, milliseconds:=hi.TotalTimeDriven).TotalMinutes) & "'")
            End With
        Next

    End Sub

End Class