Public Class FormReplays


    Public Shadows Function ShowDialog(pOwner As IWin32Window) As DialogResult
        Dim tmpB As Integer = 10
        For Each f As String In FileIO.FileSystem.GetFiles(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\replay", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            ' create Label to Open:
            Dim tmpL As New Label With {.Text = FileIO.FileSystem.GetName(f), .AutoSize = True, .Top = tmpB, .Cursor = Cursors.Hand, .ForeColor = Color.Blue}
            Me.Controls.Add(tmpL)
            AddHandler tmpL.Click, AddressOf Fav_Load
            AddHandler tmpL.MouseEnter, AddressOf pnlFav_MouseEnter
            AddHandler tmpL.MouseLeave, AddressOf pnlFav_MouseLeave
            tmpB = tmpL.Bottom + 10
        Next
        ' create Label to Manage:
        Dim tmpL2 As New Label With {.Text = "Manage Replays", .AutoSize = True, .Top = tmpB, .Cursor = Cursors.Hand, .ForeColor = Color.Orange}
        AddHandler tmpL2.Click, AddressOf Fav_Manage
        AddHandler tmpL2.MouseEnter, AddressOf pnlFav_MouseEnter
        AddHandler tmpL2.MouseLeave, AddressOf pnlFav_MouseLeave
        Me.Controls.Add(tmpL2)
        tmpB = tmpL2.Bottom + 10
        'set height and top:
        Me.Left = FormMain.btFav.Left
        Me.Top = FormMain.btFav.Bottom - Me.Height
        MyBase.ShowDialog(pOwner)
        Return Me.DialogResult
    End Function



    Private Sub Fav_Load(sender As Object, e As EventArgs)
        Try
            Dim Ini As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            Ini.Load(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\cfg\Race.ini")
            Ini.Value("REPLAY", "ACTIVE") = "1"
            Ini.Value("REPLAY", "FILENAME") = CType(sender, Label).Text
            ' start game:
            Ini.Save()
            FileIO.FileSystem.CurrentDirectory = ACPath
            Me.WindowState = FormWindowState.Minimized
            Shell(ACPath & "acs.exe", AppWinStyle.MaximizedFocus, Wait:=True)
            Me.WindowState = FormWindowState.Maximized
            Me.Activate()
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, MsgBoxStyle.Exclamation, "Load Replay")
        End Try
        Me.Close()
    End Sub

    Private Sub Fav_Manage(sender As Object, e As EventArgs)
        Diagnostics.Process.Start(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\replay")
        Me.Close()
    End Sub


    Private Sub pnlFav_MouseEnter(sender As Object, e As EventArgs)
        With CType(sender, Label)
            .Font = New Font(.Font, FontStyle.Bold)
        End With
    End Sub
    Private Sub pnlFav_MouseLeave(sender As Object, e As EventArgs)
        If TypeOf sender Is Label Then
            With CType(sender, Label)
                .Font = New Font(.Font, FontStyle.Regular)
            End With
        End If
    End Sub

    Private Sub FormSkins_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Close()
    End Sub

End Class