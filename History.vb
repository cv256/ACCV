Imports AC_CV

Public Class History
    Inherits List(Of HistoryItem)

    Public Function Load() As Boolean
        Me.Clear()
        Try
            Dim tmp As String = ""
            If FileIO.FileSystem.FileExists(MyIniPath & "\History.tab") Then
                Using sr As New System.IO.StreamReader(MyIniPath & "\History.tab")
                    tmp = sr.ReadToEnd()
                End Using
            End If
            For Each a As String In tmp.Split(CChar(vbLf))
                If String.IsNullOrEmpty(a) Then Continue For
                Dim b() As String = a.Split(CChar(vbTab))
                If CInt(b(2)) = 0 Then Continue For
                Me.Add(New HistoryItem With {.Track = b(0).ToUpper, .Car = b(1).ToUpper, .TotalTimeDriven = CInt(b(2)), .BestLapTime = CInt(b(3)), .BestLapDate = CDate(b(4))})
            Next
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace)
            Return False
        End Try
        Return True
    End Function

    Public Function Save() As Boolean
        Try
            Using sr As New System.IO.StreamWriter(MyIniPath & "\History.tab", append:=False)
                For Each h As HistoryItem In Me
                    sr.Write(h.Track.ToUpper & vbTab & h.Car.ToUpper & vbTab & h.TotalTimeDriven & vbTab & h.BestLapTime & vbTab & h.BestLapDate & vbLf)
                Next
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace)
            Return False
        End Try
        Return True
    End Function

    Public Function FindTrackCar(pTrack As String, pCar As String) As HistoryItem
        Dim res As HistoryItem = Me.FirstOrDefault(Function(h) h.Track = pTrack.ToUpper AndAlso h.Car = pCar.ToUpper)
        If res Is Nothing Then
            res = New HistoryItem() With {.Track = pTrack.ToUpper, .Car = pCar.ToUpper}
            Me.Add(res)
        End If
        Return res
    End Function

    Public Function TrackBest(pTrack As String) As HistoryItem
        Return Me.Where(Function(h) h.Track = pTrack.ToUpper AndAlso h.BestLapTime > 0).OrderBy(Function(h) h.BestLapTime).FirstOrDefault
    End Function

    Public Function TrackCars(pTrack As String) As Integer
        Return Me.Where(Function(h) h.Track = pTrack.ToUpper AndAlso h.BestLapTime > 0).Select(Function(f) f.Car).Distinct().Count
    End Function

    Public Function CarTracks(pcar As String) As Integer
        Return Me.Where(Function(h) h.Car = pcar.ToUpper AndAlso h.BestLapTime > 0).Select(Function(f) f.Track).Distinct().Count
    End Function

    Public Function CarTotalTimeDriven(pCar As String) As TimeSpan
        Return New TimeSpan(0, 0, 0, 0, milliseconds:=Me.Where(Function(h) h.Car = pCar.ToUpper).Sum(Function(h) h.TotalTimeDriven))
    End Function

    Public Function TrackTotalTimeDriven(pTrack As String) As TimeSpan
        Return New TimeSpan(0, 0, 0, 0, milliseconds:=Me.Where(Function(h) h.Track = pTrack.ToUpper).Sum(Function(h) h.TotalTimeDriven))
    End Function

End Class



Public Class HistoryItem
    Public Track As String
    Public Car As String
    Public TotalTimeDriven As Integer
    Public BestLapTime As Integer
    Public BestLapDate As DateTime
End Class
