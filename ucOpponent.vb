﻿Imports AC_CV

Public Class ucOpponent

    Private _opponentIdx As Integer
    Public Tooltip1 As ToolTip

    Public Property OpponentIdx As Integer
        Get
            Return _opponentIdx
        End Get
        Set(value As Integer)
            _opponentIdx = value
            ShowCar()
            txtLevel.Text = Opponents(_opponentIdx - 1).AILevel.ToString
        End Set
    End Property

    Private Sub ShowCar()
        Me.BackgroundImage = Nothing
        With Opponents(_opponentIdx - 1)
            If .Car Is Nothing Then
                lbCarName.Text = "click here to select a car for opponent " & _opponentIdx
                Tooltip1.SetToolTip(Me, lbCarName.Text)
            Else
                lbCarName.Text = .Car.Name
                Try
                    Using bitmapFile As System.IO.FileStream = New System.IO.FileStream(.Car.Path & "\skins\" & .Skin & "\preview.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
                        Me.BackgroundImage = New Bitmap(bitmapFile)
                    End Using
                Catch ex As Exception
                    MsgBox("Couldnt find skin «" & .Skin & "» for car «" & .Car.Name & "»" & vbCrLf & vbCrLf & "Right-click to choose another skin" & vbCrLf & "Click to choose another car", MsgBoxStyle.Information)
                End Try
                Tooltip1.SetToolTip(Me, .Car.TooltipText(.Car.SelectedSkinPath, "Opponent " & _opponentIdx))
            End If
        End With
    End Sub

    Private Sub pictCar_MouseClick(sender As Object, e As MouseEventArgs) Handles lbCarName.MouseClick, Me.MouseClick
        With Opponents(_opponentIdx - 1)
            If e.Button = MouseButtons.Left Then
                Dim tmpfrm As New FormCars
                tmpfrm.SelectedCar = .Car
                If .Car IsNot Nothing Then tmpfrm.SelectedCar.SelectedSkinPath = .Skin
                Select Case tmpfrm.ShowDialog(Me)
                    Case DialogResult.Yes ' Random
                        lbRnd_Click(Nothing, Nothing)
                    Case DialogResult.OK
                        .Car = tmpfrm.SelectedCar
                        .Skin = tmpfrm.SelectedCar.SelectedSkinPath
                        ShowCar()
                End Select
            Else
                Dim tmpfrm As New FormSkins With {.StartPosition = FormStartPosition.Manual, .Height = Me.ParentForm.Height, .Top = Me.ParentForm.Top, .Left = Me.ParentForm.Right - Me.Width}
                If tmpfrm.ShowDialog(.Car, .Skin, Me) <> DialogResult.OK Then Return
                .Skin = tmpfrm.SelectedSkin
                ShowCar()
            End If
        End With
    End Sub

    Private Sub txtLevel_TextChanged(sender As Object, e As EventArgs) Handles txtLevel.TextChanged
        If _opponentIdx = 0 Then Return
        If Not IsNumeric(txtLevel.Text) OrElse CInt(txtLevel.Text) < 0 OrElse CInt(txtLevel.Text) > 99 Then txtLevel.Text = DefaultAILevel.ToString
        Opponents(_opponentIdx - 1).AILevel = CInt(txtLevel.Text)
    End Sub

    Private Sub lbUp_Click(sender As Object, e As EventArgs) Handles lbUp.Click
        If _opponentIdx <= 1 Then Return
        Dim myOppo As Opponent
        myOppo = Opponents(_opponentIdx - 1)
        Opponents(_opponentIdx - 1) = Opponents(_opponentIdx - 2)
        Opponents(_opponentIdx - 2) = myOppo
        CType(Me.ParentForm, FormMain).SetOpponents(Me, Nothing)
    End Sub

    Private Sub lbDown_Click(sender As Object, e As EventArgs) Handles lbDown.Click
        If _opponentIdx >= OpponentCount Then Return
        Dim myOppo As Opponent
        myOppo = Opponents(_opponentIdx - 1)
        Opponents(_opponentIdx - 1) = Opponents(_opponentIdx)
        Opponents(_opponentIdx) = myOppo
        CType(Me.ParentForm, FormMain).SetOpponents(Me, Nothing)
    End Sub

    Private Sub lbRnd_Click(sender As Object, e As EventArgs) Handles lbRnd.Click
        Dim tmpCar As Car = Car.GetRandomCar()
        If tmpCar Is Nothing Then Return
        Opponents(_opponentIdx - 1).Car = tmpCar
        Opponents(_opponentIdx - 1).Skin = tmpCar.GetRandomSkin()
        ShowCar()
    End Sub

End Class
