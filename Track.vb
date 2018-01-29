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
