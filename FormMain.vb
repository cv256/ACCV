Public Class FormMain
    Private Initialized As Boolean
    Private TarmacTemplates As INIFile
    'Private pnlFav As Panel

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Init() Then
            Dim tmpFrm As New FormSetup
            tmpFrm.ShowDialog(Me)
        End If

        For Each f As String In FileIO.FileSystem.GetDirectories(ACPath & "\content\weather")
            cbWeather.Items.Add(FileIO.FileSystem.GetName(f))
        Next

        TarmacTemplates = New INIFile
        TarmacTemplates.Encoding = System.Text.Encoding.ASCII
        TarmacTemplates.Load(ACPath & "cfg\templates\tracks.ini")
        For Each f As KeyValuePair(Of String, Section) In TarmacTemplates.Sections
            cbTarmac.Items.Add(FileIO.FileSystem.GetName(f.Key))
        Next

        Initialized = True
        Scenario_Load(MyIni)
    End Sub




    Private Sub ShowCar()
        If pictCar.BackgroundImage IsNot Nothing Then pictCar.BackgroundImage.Dispose()
        pictCar.BackgroundImage = Nothing
        If SelectedCar Is Nothing Then
            lbCarName.Text = "Car Name"
            ToolTip1.SetToolTip(pictCar, "Click here to select a car for driving")
        Else
            lbCarName.Text = SelectedCar.Name
            Try
                Using bitmapFile As System.IO.FileStream = New System.IO.FileStream(SelectedCar.Path & "\skins\" & SelectedCar.SelectedSkinPath & "\preview.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
                    pictCar.BackgroundImage = New Bitmap(bitmapFile)
                End Using
            Catch ex As Exception
            End Try
            MyIni.Value("PREFEREDSKINS", Car.Folder(SelectedCar.Path).ToUpper) = SelectedCar.SelectedSkinPath
            ToolTip1.SetToolTip(pictCar, SelectedCar.TooltipText(SelectedCar.SelectedSkinPath, "Driving"))
        End If
    End Sub

    Private Sub ShowTrack()
        If pictTrack.BackgroundImage IsNot Nothing Then pictTrack.BackgroundImage.Dispose()
        If pictMap.BackgroundImage IsNot Nothing Then pictMap.BackgroundImage.Dispose()
        pictTrack.BackgroundImage = Nothing
        pictMap.BackgroundImage = Nothing
        Dim cbGhostOld As String = ""
        If cbGhost.SelectedItem IsNot Nothing Then cbGhostOld = CType(cbGhost.SelectedItem, KeyValuePair(Of String, String)).Value
        cbGhost.Items.Clear()
        cbGhost.Items.Add(New KeyValuePair(Of String, String)("(none)", ""))
        If SelectedTrack Is Nothing Then
            lbTrack.Text = "Track Name"
        Else
            lbTrack.Text = SelectedTrack.Name
            Try
                Using bitmapFile As System.IO.FileStream = New System.IO.FileStream(SelectedTrack.FotoPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
                    pictTrack.BackgroundImage = New Bitmap(bitmapFile)
                End Using
            Catch ex As Exception
            End Try
            Try
                Using bitmapFile As System.IO.FileStream = New System.IO.FileStream(SelectedTrack.MapPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
                    pictMap.BackgroundImage = New Bitmap(bitmapFile)
                End Using
            Catch ex As Exception
            End Try
            ' fill cbGhost:
            Dim tmpPath As String = FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\GhostCar\" & SelectedTrack.FolderBase
            If System.IO.Directory.Exists(tmpPath) Then
                For Each f As String In System.IO.Directory.EnumerateFiles(tmpPath, "*" & SelectedTrack.Config & ".ghost")
                    cbGhost.Items.Add(New KeyValuePair(Of String, String)(f.Replace(tmpPath & "\GHOST_CAR_", "").Replace(".ghost", ""), f))
                    If f = cbGhostOld Then cbGhost.SelectedIndex = cbGhost.Items.Count - 1
                Next
            End If
        End If

    End Sub

    Public Sub SetOpponents(sender As Object, e As EventArgs) Handles txtOpponents.TextChanged
        If Not Initialized Then Return
        If Not IsNumeric(txtOpponents.Text) OrElse CInt(txtOpponents.Text) < 0 OrElse CInt(txtOpponents.Text) > 30 Then
            txtOpponents.Text = "3"
            Return
        End If
        For i As Integer = 1 To pnlOpponents.Controls.Count ' fucking disposes:
            If pnlOpponents.Controls(pnlOpponents.Controls.Count - 1).BackgroundImage IsNot Nothing Then pnlOpponents.Controls(pnlOpponents.Controls.Count - 1).BackgroundImage.Dispose()
            pnlOpponents.Controls(pnlOpponents.Controls.Count - 1).BackgroundImage = Nothing
            pnlOpponents.Controls(pnlOpponents.Controls.Count - 1).Dispose()
        Next
        pnlOpponents.Controls.Clear()
        OpponentCount = CInt(txtOpponents.Text)
        Dim lastBottom As Integer = 0
        For idx As Integer = 1 To OpponentCount
            Dim tmpSkin As String = ""
            If SelectedCar IsNot Nothing Then tmpSkin = SelectedCar.SelectedSkinPath
            If Opponents.Count < idx Then Opponents.Add(New Opponent With {.AILevel = DefaultAILevel, .Car = SelectedCar, .Skin = tmpSkin})
            Dim tmpUcOpponent As New ucOpponent With {.Tooltip1 = ToolTip1, .OpponentIdx = idx, .Top = lastBottom}
            pnlOpponents.Controls.Add(tmpUcOpponent)
            lastBottom += tmpUcOpponent.Height
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close() ' cont use End because it wont trigger event FormClosing !
    End Sub

    Public Function ValidateChoices() As Boolean
        If SelectedCar Is Nothing Then
            MsgBox("One must selected a Car and a Track before he can start playing")
            pictCar_MouseClick(Nothing, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0))
            Return False
        End If
        If SelectedTrack Is Nothing Then
            MsgBox("One must selected a Car and a Track before he can start playing")
            pictTrack_Click(Nothing, Nothing)
            Return False
        End If
        Return True
    End Function

    Private Sub bt_Click(sender As Object, e As EventArgs) Handles btStart.Click
        If Not ValidateChoices() Then Return
        Try
            Dim Ini As New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            Ini.Load(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\cfg\camera_manager.ini")
            Ini.Value("SHAKE", "GFORCEZ") = MoveZ.ToString("0.0").Replace(",", ".")
            Ini.Value("SHAKE", "GFORCEY") = MoveY.ToString("0.0").Replace(",", ".")
            Ini.Value("SHAKE", "GFORCEX") = MoveX.ToString("0.0").Replace(",", ".")
            Ini.Value("SHAKE", "SHAKEMULT") = Shake.ToString("0.0").Replace(",", ".")
            Ini.Save()

            Ini = New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            Ini.Load(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\cfg\audio.ini")
            Ini.Value("SKIDS", "ENTRY_POINT") = Skids.ToString()
            Ini.Save()

            Ini = New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            Ini.Load(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\cfg\gameplay.ini")
            Ini.Value("PYTHON", "ENABLE_PYTHON") = CStr(IIf(chkPython.Checked, "1", "0"))
            Ini.Save()

            Ini = New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            Ini.Load(ACPath & "\system\cfg\assetto_corsa.ini")
            Ini.Value("AC_APPS", "ENABLE_DEV_APPS") = CStr(IIf(chkExtraApps.Checked, "1", "0"))
            Ini.Save()

            Ini = New INIFile With {.Encoding = System.Text.Encoding.ASCII}
            Ini.Load(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\cfg\Race.ini") ' [RACE]   TRACK=mugello   MODEL=bmw_e39m5   CARS=1   AI_LEVEL=98   SKIN=black_red   RACE_LAPS=5
            RaceINI_CarsClear(Ini)
            Ini.Value("REPLAY", "ACTIVE") = "0"
            Ini.Value("RACE", "MODEL") = Car.Folder(SelectedCar.Path)
            Ini.Value("RACE", "RACE_LAPS") = txtLaps.Text
            Ini.Value("RACE", "CARS") = CStr(IIf(tbRace.Equals(TabControl1.SelectedTab), 1 + OpponentCount, 1))
            Ini.Value("RACE", "AI_LEVEL") = DefaultAILevel.ToString
            Ini.Value("RACE", "TRACK") = Track.PathBase(SelectedTrack.Path)
            Ini.Value("RACE", "CONFIG_TRACK") = SelectedTrack.Config
            Ini.Value("RACE", "PENALTIES") = CStr(IIf(chkPenalties.Checked, "1", "0"))
            Ini.Value("GHOST_CAR", "RECORDING") = CStr(IIf(chkSaveGhost.Checked, "1", "0"))
            Ini.Value("GHOST_CAR", "PLAYING") = "0"
            Ini.Value("GHOST_CAR", "FILE") = ""
            If cbGhost.SelectedItem IsNot Nothing Then
                Dim tmpGhost As String = CType(cbGhost.SelectedItem, KeyValuePair(Of String, String)).Value
                If Not String.IsNullOrEmpty(tmpGhost) Then
                    Ini.Value("GHOST_CAR", "PLAYING") = "1"
                    Ini.Value("GHOST_CAR", "FILE") = tmpGhost
                    Ini.Value("GHOST_CAR", "SECONDS_ADVANTAGE") = "1"
                End If
            End If

            Ini.Value("LAP_INVALIDATOR", "ALLOWED_TYRES_OUT") = CStr(IIf(chkTyresOut.Checked, "0", "-1"))
            If Not cbWeather.SelectedItem Is Nothing Then Ini.Value("WEATHER", "NAME") = cbWeather.SelectedItem.ToString
            If Not cbTarmac.SelectedItem Is Nothing Then
                Ini.Value("DYNAMIC_TRACK", "SESSION_START") = TarmacTemplates.Value(cbTarmac.SelectedItem.ToString, "SESSION_START")
                Ini.Value("DYNAMIC_TRACK", "SESSION_TRANSFER") = TarmacTemplates.Value(cbTarmac.SelectedItem.ToString, "SESSION_TRANSFER")
                Ini.Value("DYNAMIC_TRACK", "RANDOMNESS") = TarmacTemplates.Value(cbTarmac.SelectedItem.ToString, "RANDOMNESS")
                Ini.Value("DYNAMIC_TRACK", "LAP_GAIN") = TarmacTemplates.Value(cbTarmac.SelectedItem.ToString, "LAP_GAIN")
            End If
            RaceINI_Car(Ini, 0, SelectedCar, SelectedCar.SelectedSkinPath, DefaultAILevel)
            If tbPractice.Equals(TabControl1.SelectedTab) Then
                Ini.Value("SESSION_0", "NAME") = "Practice"
                Ini.Value("SESSION_0", "TYPE") = "1"
                Ini.Value("SESSION_0", "SPAWN_SET") = "PIT"
            ElseIf tbHot.Equals(TabControl1.SelectedTab) Then
                Ini.Value("SESSION_0", "NAME") = "Hotlap"
                Ini.Value("SESSION_0", "TYPE") = "4"
                Ini.Value("SESSION_0", "SPAWN_SET") = "HOTLAP_START"
            ElseIf tbTime.Equals(TabControl1.SelectedTab) Then
                Ini.Value("SESSION_0", "NAME") = "Time Attack"
                Ini.Value("SESSION_0", "TYPE") = "5"
                Ini.Value("SESSION_0", "SPAWN_SET") = "START"
            ElseIf tbDrift.Equals(TabControl1.SelectedTab) Then
                Ini.Value("SESSION_0", "NAME") = "Drift Session"
                Ini.Value("SESSION_0", "TYPE") = "6"
                Ini.Value("SESSION_0", "SPAWN_SET") = "PIT"
            ElseIf tbRace.Equals(TabControl1.SelectedTab) Then
                Ini.Value("SESSION_0", "NAME") = "Quick Race"
                Ini.Value("SESSION_0", "TYPE") = "3"
                Ini.Value("SESSION_0", "SPAWN_SET") = "START"
                Ini.Value("SESSION_0", "LAPS") = txtLaps.Text
                ' oponent cars
                For oIdx As Integer = 1 To OpponentCount
                    Dim o As Opponent = Opponents(oIdx - 1)
                    RaceINI_Car(Ini, oIdx, o.Car, o.Skin, o.AILevel)
                Next
            End If
            Ini.Save()

            ' start game:
            If System.IO.File.Exists(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\out\race_out.json") Then System.IO.File.Delete(FileIO.SpecialDirectories.MyDocuments & "\Assetto Corsa\out\race_out.json")
            FileIO.FileSystem.CurrentDirectory = ACPath
            Me.WindowState = FormWindowState.Minimized
            Shell(ACPath & "acs.exe", AppWinStyle.MaximizedFocus, Wait:=True)

            ShowResults()

        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace)
        End Try
        Me.WindowState = FormWindowState.Maximized
        Me.Activate()
    End Sub

    Private Sub ShowResults()
        Dim tmpFrm As New FormResult
        tmpFrm.Owner = Me
        tmpFrm.ShowDialog()
    End Sub

    Public Sub RaceINI_Car(pIni As INIFile, oIdx As Integer, pCar As Car, pSkin As String, pAILevel As Integer)
        pIni.Value("CAR_" & oIdx.ToString, "MODEL") = Car.Folder(pCar.Path)
        pIni.Value("CAR_" & oIdx.ToString, "MODEL_CONFIG") = ""
        pIni.Value("CAR_" & oIdx.ToString, "SETUP") = ""
        pIni.Value("CAR_" & oIdx.ToString, "AI_LEVEL") = pAILevel.ToString
        pIni.Value("CAR_" & oIdx.ToString, "SKIN") = pSkin
        pIni.Value("CAR_" & oIdx.ToString, "DRIVER_NAME") = CStr(IIf(oIdx = 0, "HUMAN", "Ai" & oIdx.ToString & " " & pAILevel.ToString & "%"))
        pIni.Value("CAR_" & oIdx.ToString, "NATIONALITY") = "null"
    End Sub


    Public Sub RaceINI_CarsClear(pIni As INIFile)
        For oIdx As Integer = 1 To 99
            If Not pIni.Sections.ContainsKey("CAR_" & oIdx.ToString) Then Continue For
            pIni.Sections.Remove("CAR_" & oIdx.ToString)
        Next
    End Sub


    Private Sub txtLaps_TextChanged(sender As Object, e As EventArgs) Handles txtLaps.TextChanged
        If Not IsNumeric(txtLaps.Text) Then txtLaps.Text = "3"
    End Sub


    Private Sub pictCar_MouseClick(sender As Object, e As MouseEventArgs) Handles pictCar.MouseClick
        If e.Button = MouseButtons.Left Then
            Dim tmpfrm As New FormCars
            tmpfrm.SelectedCar = SelectedCar
            Select Case tmpfrm.ShowDialog(Me)
                Case DialogResult.Yes ' Random
                    Dim tmpCar As Car = Car.GetRandomCar()
                    If tmpCar IsNot Nothing Then
                        SelectedCar = tmpCar
                        SelectedCar.SelectedSkinPath = tmpCar.GetRandomSkin()
                    End If
                Case DialogResult.OK
                    SelectedCar = tmpfrm.SelectedCar
            End Select
        Else
            Dim tmpfrm As New FormSkins With {.StartPosition = FormStartPosition.Manual, .Height = Me.Height, .Top = Me.Top, .Left = Me.Left + e.X}
            If tmpfrm.ShowDialog(SelectedCar, SelectedCar.SelectedSkinPath, Me) <> DialogResult.OK Then Return
            SelectedCar.SelectedSkinPath = tmpfrm.SelectedSkin
        End If
        ShowCar()
    End Sub

    Private Sub pictTrack_Click(sender As Object, e As EventArgs) Handles pictTrack.Click
        Dim tmpfrm As New FormTracks
        tmpfrm.ShowDialog(Me)
        ShowTrack()
    End Sub

    Private Sub btSetup_Click(sender As Object, e As EventArgs) Handles btSetup.Click
        Dim tmpfrm As New FormSetup
        FormSetup.ShowDialog(Me)
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Scenario_Save(MyIni)
    End Sub

    Public Sub Scenario_Load(pIni As INIFile)
        SelectedCar = Car.Find(pIni.Value("LASTUSED", "CAR"))
        SelectedTrack = Track.FindByPath(pIni.Value("LASTUSED", "TRACK"))
        txtLaps.Text = pIni.Value("LASTUSED", "LAPS")
        chkPenalties.Checked = pIni.Value("LASTUSED", "PENALTIES") = "1"
        chkTyresOut.Checked = pIni.Value("LASTUSED", "TYRESOUT") = "1"
        chkExtraApps.Checked = pIni.Value("LASTUSED", "EXTRAAPPS") = "1"
        chkPython.Checked = pIni.Value("LASTUSED", "PYTHON") = "1"
        cbWeather.SelectedIndex = cbWeather.FindString(pIni.Value("LASTUSED", "WEATHER"))
        cbTarmac.SelectedIndex = cbTarmac.FindString(pIni.Value("LASTUSED", "TARMAC"))
        Opponents.Clear()
        For idx As Integer = 1 To 99
            If String.IsNullOrEmpty(pIni.Value("LASTOPPONENTS", "CAR" & idx)) Then Exit For
            Opponents.Add(New Opponent With {.Car = Car.Find(pIni.Value("LASTOPPONENTS", "CAR" & idx)) _
                          , .AILevel = CInt(pIni.Value("LASTOPPONENTS", "AILEVEL" & idx)) _
                          , .Skin = pIni.Value("LASTOPPONENTS", "SKIN" & idx)})
        Next
        Initialized = False ' to avoid firing SetOpponents
        txtOpponents.Text = pIni.Value("LASTUSED", "OPPONENTSCOUNT") ' this sometimes fires SetOpponents
        Initialized = True
        SetOpponents(Nothing, Nothing)
        ShowCar()
        ShowTrack()
    End Sub
    Public Sub Scenario_Save(pIni As INIFile)
        If Not SelectedCar Is Nothing Then pIni.Value("LASTUSED", "CAR") = Car.Folder(SelectedCar.Path)
        If Not SelectedTrack Is Nothing Then pIni.Value("LASTUSED", "TRACK") = SelectedTrack.PathConfig
        pIni.Value("LASTUSED", "OPPONENTSCOUNT") = OpponentCount.ToString
        pIni.Value("LASTUSED", "LAPS") = CInt(txtLaps.Text).ToString
        pIni.Value("LASTUSED", "PENALTIES") = CStr(IIf(chkPenalties.Checked, "1", "0"))
        pIni.Value("LASTUSED", "TYRESOUT") = CStr(IIf(chkTyresOut.Checked, "1", "0"))
        pIni.Value("LASTUSED", "EXTRAAPPS") = CStr(IIf(chkExtraApps.Checked, "1", "0"))
        pIni.Value("LASTUSED", "PYTHON") = CStr(IIf(chkPython.Checked, "1", "0"))
        If Not cbWeather.SelectedItem Is Nothing Then pIni.Value("LASTUSED", "WEATHER") = cbWeather.SelectedItem.ToString
        If Not cbTarmac.SelectedItem Is Nothing Then pIni.Value("LASTUSED", "TARMAC") = cbTarmac.SelectedItem.ToString
        Dim idx As Integer = 0
        For Each o As Opponent In Opponents
            idx += 1
            If o.Car IsNot Nothing Then pIni.Value("LASTOPPONENTS", "CAR" & idx) = Car.Folder(o.Car.Path)
            pIni.Value("LASTOPPONENTS", "AILEVEL" & idx) = o.AILevel.ToString
            pIni.Value("LASTOPPONENTS", "SKIN" & idx) = o.Skin
        Next
        pIni.Save()
    End Sub

    Private Sub btFav_Click(sender As Object, e As EventArgs) Handles btFav.Click
        Dim tmpFrm As New FormFavorites
        tmpFrm.ShowDialog(Me)
    End Sub

    Private Sub btReplays_Click(sender As Object, e As EventArgs) Handles btReplays.Click
        Dim tmpFrm As New FormReplays
        tmpFrm.ShowDialog(Me)
    End Sub

    Private Sub btStart_MouseUp(sender As Object, e As MouseEventArgs) Handles btStart.MouseUp
        If e.Button <> MouseButtons.Right Then Exit Sub
        ShowResults()
    End Sub


End Class

' \ASSETTO CORSA\CFG\RACE.INI :
'
'[RACE]
'TRACK = magione
'CONFIG_TRACK =
'MODEL = lotus_elise_sc
'MODEL_CONFIG =
'CARS = 1
'AI_LEVEL = 98
'FIXED_SETUP = 0
'PENALTIES = 0

'[GHOST_CAR]
'RECORDING = 1
'PLAYING = 1
'SECONDS_ADVANTAGE = 0
'LOAD = 1
'FILE =

'[REPLAY]
'FILENAME =
'ACTIVE = 0

'[LIGHTING]
'SUN_ANGLE = -48
'TIME_MULT = 1
'CLOUD_SPEED = 0.2

'[GROOVE]
'VIRTUAL_LAPS = 10
'MAX_LAPS = 30
'STARTING_LAPS = 0

'[DYNAMIC_TRACK]
'SESSION_START = 100 ; % level Of grip at session start
'SESSION_TRANSFER = 50 ;  how much Of the grip gained In one session transfers To the session after it
'RANDOMNESS = 0   ; level Of randomness added To the start grip
'LAP_GAIN = 1   ; how many laps are needed To add 1% grip

'[REMOTE]
'ACTIVE = 0
'SERVER_IP =
'SERVER_PORT =
'NAME =
'TEAM =
'GUID =
'REQUESTED_CAR =
'PASSWORD =

'[LAP_INVALIDATOR]
'ALLOWED_TYRES_OUT = -1

'[TEMPERATURE]
'AMBIENT = 26
'ROAD = 32

'[WEATHER]
'NAME = 4_mid_clear


'[SESSION_0]
'NAME = Practice
'TYPE=1
'DURATION_MINUTES = 0
'SPAWN_SET = PIT

'[SESSION_0]
'NAME = Hotlap
'TYPE=4
'DURATION_MINUTES = 0
'SPAWN_SET = HOTLAP_START

'[SESSION_0]
'NAME = Time Attack
'TYPE=5
'DURATION_MINUTES = 0
'SPAWN_SET = START

'[SESSION_0]
'NAME = Drift Session
'TYPE=6
'SPAWN_SET = PIT

'[SESSION_0]
'STARTING_POSITION = 2
'NAME = Quick Race
'TYPE=3
'LAPS = 3
'DURATION_MINUTES = 0
'SPAWN_SET = START


'[CAR_0]
'MODEL = -
'MODEL_CONFIG =
'SKIN = Racing_Green_Stripe
'DRIVER_NAME =
'NATIONALITY = ITA			; ISO Country code
'AI_LEVEL = 96
'SETUP =

'[CAR_1]
'MODEL = mazda_miata
'MODEL_CONFIG =
'SETUP = akinadownhill
'AI_LEVEL = 100
'SKIN = laguna_blue
'DRIVER_NAME = Eddie Gomez
'NATIONALITY = USA ; ISO Country code

'[CAR_2]
'MODEL = landrover_defender4x4
'MODEL_CONFIG =
'SETUP = akinadownhill
'AI_LEVEL = 100
'SKIN = 01
'DRIVER_NAME = Martin Fleming
'NATIONALITY = null

'[CAR_3]
'MODEL = landrover_defender4x4
'MODEL_CONFIG =
'SETUP = akinadownhill
'AI_LEVEL = 100
'SKIN = 02
'DRIVER_NAME = Heriberto Herbert
'NATIONALITY = null


