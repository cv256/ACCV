Public Class FormEdit

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub btSetup_Click(sender As Object, e As EventArgs) Handles btSetup.Click
        If txtNotes.Text.Contains("["c) OrElse txtNotes.Text.Contains("]"c) OrElse txtNotes.Text.Contains(";"c) Then
            MsgBox("Dont use characters  [  ]  ;", MsgBoxStyle.Information)
            Return
        End If
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub
End Class