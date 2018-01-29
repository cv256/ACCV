Public Class FormSkins

    Private _car As Car
    Public SelectedSkin As String



    Public Shadows Function ShowDialog(pCar As Car, pSelectedSkin As String, pOwner As IWin32Window) As DialogResult
        If pCar Is Nothing Then Return DialogResult.Abort
        _car = pCar
        SelectedSkin = pSelectedSkin
        Dim lastBottom As Integer = 0
        For Each s As String In _car.Skins
            Dim p As New Panel With {.Top = lastBottom + 2, .Width = 256, .Height = 144, .Cursor = Cursors.Hand, .BackgroundImageLayout = ImageLayout.Zoom, .Tag = s}
            ToolTip1.SetToolTip(p, s & vbCrLf & "Left-click: Use this skin" & vbCrLf & "Right-click: Showroom this skin")
            Using bitmapFile As System.IO.FileStream = New System.IO.FileStream(_car.Path & "\skins\" & s & "\preview.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
                p.BackgroundImage = New Bitmap(bitmapFile)
            End Using
            Me.Controls.Add(p)
            AddHandler p.MouseClick, AddressOf pictCar_Click
            lastBottom = p.Bottom
        Next
        If lastBottom + 60 < Me.Height Then Me.Height = lastBottom + 60

        MyBase.ShowDialog(pOwner)

        For i As Integer = 1 To Me.Controls.Count ' fucking disposes:
            If CType(Me.Controls(Me.Controls.Count - 1), Panel).BackgroundImage IsNot Nothing Then CType(Me.Controls(Me.Controls.Count - 1), Panel).BackgroundImage.Dispose()
            CType(Me.Controls(Me.Controls.Count - 1), Panel).BackgroundImage = Nothing
            Me.Controls(Me.Controls.Count - 1).Dispose()
        Next

        Return Me.DialogResult
    End Function


    Private Sub FormSkins_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Close()
    End Sub

    Private Sub pictCar_Click(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim tmpSkin As String = CStr(CType(sender, Control).Tag)
            Try
                Dim Ini As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
                Ini.Load(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\cfg\showroom_start.ini")
                Ini.Value("SHOWROOM", "CAR") = Car.Folder(_car.Path)
                Ini.Value("SHOWROOM", "SKIN") = tmpSkin
                ' start showroom:
                Ini.Save()
                FileIO.FileSystem.CurrentDirectory = ACPath
                Me.WindowState = FormWindowState.Minimized
                Shell(ACPath & "acShowroom.exe", AppWinStyle.MaximizedFocus, Wait:=True)
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace)
            End Try
            Me.WindowState = FormWindowState.Maximized
            Me.Activate()
            DialogResult = DialogResult.Cancel
        Else
            SelectedSkin = CStr(CType(sender, Control).Tag)
            DialogResult = DialogResult.OK
        End If
        Close()
    End Sub

End Class