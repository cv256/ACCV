Public Class FormSetup
    Private Sub FormSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbInfo.Text = My.Application.Info.DirectoryPath & "\"
        lbVersion.Text = "v " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        lnkINI.Text = MyIniPath
        txtACFolder.Text = ACPath
        txtFontSize.Text = FontSize.ToString
        tZ.Value = CInt(MoveZ)
        tY.Value = CInt(MoveY)
        tX.Value = CInt(MoveX)
        tS.Value = CInt(Shake * 3)
        Dim Ini As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
        Ini.Load(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\cfg\audio.ini")
        tSkids.Value = Skids
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Close()
    End Sub

    Private Sub btSetup_Click(sender As Object, e As EventArgs) Handles btSetup.Click
        MyIni.Value("SETUP", "ACFOLDER") = txtACFolder.Text.Replace("""", "").Trim("\"c)
        MyIni.Value("SETUP", "FONTSIZE") = txtFontSize.Text
        MyIni.Value("SETUP", "MOVEZ") = tZ.Value.ToString
        MyIni.Value("SETUP", "MOVEY") = tY.Value.ToString
        MyIni.Value("SETUP", "MOVEX") = tX.Value.ToString
        MyIni.Value("SETUP", "SHAKE") = (tS.Value / 3).ToString
        MyIni.Value("SETUP", "SKIDS") = tSkids.Value.ToString
        Me.Cursor = Cursors.WaitCursor
        MyIni.Save()
        If Not Init() Then
            Me.Cursor = Cursors.Default
            Return
        End If
        Me.Cursor = Cursors.Default
        Close()
    End Sub

    Private Sub lnkINI_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkINI.LinkClicked
        Diagnostics.Process.Start(MyIniPath & "\Settings.ini")
    End Sub

    Private Sub txtFontSize_TextChanged(sender As Object, e As EventArgs) Handles txtFontSize.TextChanged
        With CType(sender, TextBox)
            If Not IsNumeric(.Text) Then .Text = ""
        End With
    End Sub

End Class