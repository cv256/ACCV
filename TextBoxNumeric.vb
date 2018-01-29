Public Class TextBoxNumeric
    Inherits TextBox

    Private _MinValue As Single = Single.MinValue, _MaxValue As Single = Single.MaxValue, _Mask As String = ""

    Public Sub New()
        TextAlign = HorizontalAlignment.Right
    End Sub

    <ComponentModel.Category("A")>
    Public Property Mask() As String
        Get
            Return _Mask
        End Get
        Set(ByVal value As String)
            _Mask = value
        End Set
    End Property
    <ComponentModel.Category("A")>
    Public Property MinValue() As Single
        Get
            Return _MinValue
        End Get
        Set(ByVal value As Single)
            _MinValue = value
        End Set
    End Property
    <ComponentModel.Category("A")>
    Public Property MaxValue() As Single
        Get
            Return _MaxValue
        End Get
        Set(ByVal value As Single)
            _MaxValue = value
        End Set
    End Property

    Public Function TextSet(pValue As String, provider As IFormatProvider) As String
        Dim tmpSingle As Single, tmpError As String
        tmpError = ValidateNumber(pValue, tmpSingle, provider)
        TextSet(tmpSingle)
        Return tmpError
    End Function

    Public Sub TextSet(pValue As Single)
        MyBase.Text = pValue.ToString(Mask)
    End Sub

    Public Function TextGet(Optional ByRef pErrors As String = "") As Single
        Dim pResult As Single = 0
        Dim res As String = $"Instead of «{MyBase.Text}», write a number between {MinValue.ToString(Mask)} and {MaxValue.ToString(Mask)}" & vbCrLf
        If Not Single.TryParse(MyBase.Text, Globalization.NumberStyles.Any, provider:=Nothing, result:=pResult) _
            OrElse pResult < MinValue OrElse pResult > MaxValue Then
            pErrors &= vbCrLf & res
        End If
        Return pResult
    End Function

    Public Function Validate(Optional ByRef pResult As Single = 0) As String
        Dim res As String = $"Instead of «{MyBase.Text}», write a number between {MinValue.ToString(Mask)} and {MaxValue.ToString(Mask)}" & vbCrLf
        If Not Single.TryParse(MyBase.Text, Globalization.NumberStyles.Any, provider:=Nothing, result:=pResult) Then Return res
        If pResult < MinValue OrElse pResult > MaxValue Then Return res
        Return ""
    End Function

    Public Function ValidateNumber(pText As String, Optional ByRef pResult As Single = 0, Optional provider As IFormatProvider = Nothing) As String
        Dim res As String = $"Instead of «{pText}», write a number between {MinValue.ToString(Mask)} and {MaxValue.ToString(Mask)}" & vbCrLf
        If Not Single.TryParse(pText, Globalization.NumberStyles.Any, provider:=provider, result:=pResult) Then Return res
        If pResult < MinValue OrElse pResult > MaxValue Then Return res
        Return ""
    End Function

End Class
