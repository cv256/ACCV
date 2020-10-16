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
    Public Modded As Boolean, CoGFront As String = "", CoGRear As String = ""

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

End Class
