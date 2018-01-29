Public Class chk3state
    Inherits Label

    Public Event CheckStateChanged(sender As Object, e As EventArgs)

    Private _CheckState As CheckState = CheckState.Indeterminate

    Public Shadows Property Text As String
        Get
            Return MyBase.Text.TrimStart(" "c)
        End Get
        Set(value As String)
            MyBase.Text = Space(7) & value
        End Set
    End Property

    Private Sub _3state_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If _CheckState = CheckState.Unchecked Then
            e.Graphics.FillRectangle(Brushes.Orange, 0, 0, 11, 11)
            e.Graphics.FillRectangle(Brushes.Green, 11, 0, 11, 11)
            e.Graphics.DrawLine(Pens.Black, 0, 0, 10, 10)
            e.Graphics.DrawLine(Pens.Black, 10, 0, 0, 10)
        ElseIf _CheckState = CheckState.Checked Then
            e.Graphics.FillRectangle(Brushes.Red, 0, 0, 11, 11)
            e.Graphics.FillRectangle(Brushes.GreenYellow, 11, 0, 11, 11)
            e.Graphics.DrawLine(Pens.Black, 11, 0, 16, 10)
            e.Graphics.DrawLine(Pens.Black, 16, 10, 20, 0)
        Else
            e.Graphics.FillRectangle(Brushes.Red, 0, 0, 11, 11)
            e.Graphics.FillRectangle(Brushes.Green, 11, 0, 11, 11)
        End If
    End Sub

    Private Sub _3state_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If e.X < 11 Then
            If _CheckState = CheckState.Unchecked Then CheckState = CheckState.Indeterminate Else CheckState = CheckState.Unchecked
        ElseIf e.X < 22 Then
            If _CheckState = CheckState.Checked Then CheckState = CheckState.Indeterminate Else CheckState = CheckState.Checked
        End If
    End Sub

    Public Shadows Property CheckState As CheckState
        Get
            Return _CheckState
        End Get
        Set(value As CheckState)
            _CheckState = value
            Me.Refresh()
            RaiseEvent CheckStateChanged(Me, Nothing)
        End Set
    End Property

End Class
