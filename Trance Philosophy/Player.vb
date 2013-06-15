Imports Un4seen.Bass

Public Class Player
#Region "Settings"
    Private stream_url = "http://tfbradio.gkstreamen.nl:8028"
    Private debug As Boolean = False
#End Region
#Region "Button"
    ' This is set to True when the window is "grabbed" on the button and moved afterwards.
    Private skipClick As Boolean = False

    Private Sub LeButton_Click() Handles LeButton.Click
        ' Same story.
        If skipClick Then
            ' Reset the variable
            skipClick = False
            Exit Sub
        End If

        If Not playing Then
            stopMoveHigh = False
            If Not Play.IsBusy Then
                Play.RunWorkerAsync()
            End If
        Else
            Bass.BASS_ChannelStop(stream)
            playing = False
            stopMoveHigh = True
            stopMoveLow = False
            ShowNextAiring()
            Updatetrack.Stop()
            LiveTracks.Text = ""
            TT.SetToolTip(LiveTracks, Nothing)
        End If
        Colormove.Start()
    End Sub

    Private mouseInButton As Boolean = False

    ' Following 2 subs change the button image when the mouse enters and
    ' set mouseInButton to True or False according to the mouse position.
    ' This is used to determine if the window is "grabbed" on the button
    ' or somewhere else in the window.

    Private Sub LeButton_MouseLeave() Handles LeButton.MouseLeave
        LeButton.Image = My.Resources.play_black
        mouseInButton = False
    End Sub

    Private Sub LeButton_MouseEnter() Handles LeButton.MouseEnter
        LeButton.Image = My.Resources.play_white
        mouseInButton = True
    End Sub
#End Region
#Region "Background stuff"
    Private stream As Integer
    Private sync As SYNCPROC
    Private playing As Boolean = False
    Private Sub Play_DoWork() Handles Play.DoWork

        ' Stream
        Bass.BASS_ChannelStop(stream)
        stream = Bass.BASS_StreamCreateURL(stream_url, 2, BASSFlag.BASS_STREAM_AUTOFREE Or BASSFlag.BASS_STREAM_PRESCAN, Nothing, Nothing)
        If stream <> 0 Then
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volume / 100)
            Bass.BASS_ChannelPlay(stream, False)
            playing = True
            Play.ReportProgress(1)
            sync = New SYNCPROC(Sub(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
                                    Me.Invoke(Sub()
                                                  UpdateMeta()
                                              End Sub)
                                End Sub)
            Bass.BASS_ChannelSetSync(stream, BASSSync.BASS_SYNC_META, 0, sync, IntPtr.Zero)
            Me.Invoke(Sub()
                          UpdateMeta()
                      End Sub)

        Else
            playing = False
            Play.ReportProgress(0)
        End If
    End Sub

    Private Sub Play_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Play.ProgressChanged
        If e.ProgressPercentage = 0 Then
            MsgBox("Can't connect to the stream")
            stopMoveHigh = True
        ElseIf e.ProgressPercentage = 1 Then
            stopMoveLow = True
        End If
    End Sub
#End Region
#Region "Status + Init"

    Private Sub Player_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowNextAiring()
        Checkupdates.RunWorkerAsync()
        Volumebar.Value = volume
    End Sub

    Private Sub UpdateMeta()
        Dim tags As String = Bass.BASS_ChannelGetTagsMETA(stream)(0).Replace("StreamTitle='", Nothing).Replace("';StreamUrl='';", Nothing)
        TT.SetToolTip(Status, "Now playing: " & tags)
        If tags.ToLower.Contains("philosophy") Then
            Updatetrack.Start()
            Updatetrackworker.RunWorkerAsync()
        Else
            Updatetrack.Stop()
            LiveTracks.Text = ""
            TT.SetToolTip(LiveTracks, Nothing)
        End If
        UpdateStatus(tags)
    End Sub

    Private d As DateTime = Nothing ' Very important: the date and time of the first airing!

    Private Sub ShowNextAiring()
        ' Code below calculates the next airing date of the show.
        If d = Nothing Then
                d = New DateTime(2013, 2, 23, 16, 0, 0, DateTimeKind.Utc)
        End If

        Dim prefix As String = "Next airing: "

        Do While d.AddHours(2).Ticks < DateTime.UtcNow.Ticks
            d = d.AddDays(14)
        Loop

        If d.Ticks <= DateTime.UtcNow.Ticks And d.AddHours(2).Ticks > DateTime.UtcNow.Ticks Then
            UpdateStatus("The show's on right now! Hit play!")
            TT.SetToolTip(Status, newText)
        ElseIf DateTime.UtcNow.Ticks > d.Ticks Then ' The first episode has passed.
            UpdateStatus(prefix & d.ToLocalTime)
            TT.SetToolTip(Status, newText & ", local time")
        Else
            UpdateStatus(prefix & d.ToLocalTime)
            TT.SetToolTip(Status, newText & ", local time")
        End If
    End Sub
#End Region
#Region "Window controls"
    Private Sub Quit_Click(sender As Object, e As EventArgs) Handles Quit.Click
        If HelpText.Visible Then
            HelpText.Visible = False
            More.Visible = False
            Quit.Text = "X"
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub Min_Click(sender As Object, e As EventArgs) Handles Min.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Help_Click(sender As Object, e As EventArgs) Handles Help.Click
        HelpText.Visible = True
        More.Visible = True
        HelpText.BringToFront()
        More.BringToFront()
        Quit.BringToFront()
        Quit.Text = "<"
        If More.Text = "Back" Then
            More.Text = "Show more..."
            HelpText.Text = originalText
        End If
        MakeLinks(labels, links)
    End Sub
#End Region
#Region "Volume control"
    Private volume As Integer = 100
    Private Sub Logo_DoubleClick(sender As Object, e As EventArgs) Handles Logo.DoubleClick
        ' Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volume / 100)
        Logo.Visible = False
        Volumebar.Visible = True
        ReturnButton.Visible = True
    End Sub

    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Volumebar.Visible = False
        ReturnButton.Visible = False
        Logo.Visible = True
    End Sub

    Private Sub Volumebar_Scroll(sender As Object, e As EventArgs) Handles Volumebar.Scroll
        volume = Volumebar.Value
        Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volume / 100)
    End Sub
#End Region
#Region "About"
    Private labels As String() = {"_Tobias", "bass", "Bass.Net", "contact me", "Inspiron", "downloaded"}
    Private links As String() = {"http://tobiass.eu", "http://www.un4seen.com/bass.html", "http://bass.radio42.com", "http://me.tobiass.eu", "https://www.facebook.com/InspironTrance", "http://pirateproxy.net/search/inspiron%20trance%20philosophy/0/99/0"}
    Private originalText As String
    Private Sub More_Click() Handles More.Click
        If More.Text = "Back" Then
            More.Text = "Show more..."
            HelpText.Text = originalText
        Else
            originalText = HelpText.Text

            Dim version As String() = Split(ProductVersion, ".")
            Dim versionString As String = version(0) & "." & version(1)
            If version(2) = "0" = False Then : versionString += "." & version(2) : End If
            If version(3) = "0" = False Then
                If version(2) = "0" Then : versionString += "." & version(2) : End If
                versionString += "." & version(3)
            End If


            HelpText.Text = "This application is made by _Tobias for Inspiron" & vbNewLine & vbNewLine & _
                "This application uses bass and Bass.Net" & vbNewLine & vbNewLine & _
                "The Inspiron logo is made by Mahdi" & vbNewLine & vbNewLine & _
                "Any episode of the show can be downloaded afterwards" & vbNewLine & vbNewLine & _
                "You are using version " & versionString

            More.Text = "Back"
        End If

        MakeLinks(labels, links)
    End Sub

    Private Sub HelpText_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles HelpText.LinkClicked
        Process.Start(e.Link.LinkData)
    End Sub

    Private Sub MakeLinks(labels As String(), links As String())
        HelpText.Links.Clear()

        For i As Integer = 0 To labels.Length - 1
            If HelpText.Text.Contains(labels(i)) Then
                HelpText.Links.Add(HelpText.Text.IndexOf(labels(i)), labels(i).Length, links(i))
            End If
        Next
    End Sub
#End Region
#Region "Draggable window"
    ' When this is true, every mouse movement in the window will move it.
    Private drag As Boolean = False

    ' The following code is something I wrote a while ago for AH Radio, I have no
    ' idea how I ever made this up.
    Private mousex As Integer
    Private mousey As Integer

    Private Sub mdown() Handles Me.MouseDown, LeButton.MouseDown, Logo.MouseDown, Status.MouseDown, HelpText.MouseDown, LiveTracks.MouseDown
        ' When the mouse is pressed somewhere in the window, enable the dragging.
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub mmove() Handles Me.MouseMove, LeButton.MouseMove, Logo.MouseMove, Status.MouseMove, HelpText.MouseMove, LiveTracks.MouseMove
        If drag Then
            ' In case the window was grabbed on the button, prevent it from being clicked.
            If mouseInButton Then
                skipClick = True
            End If

            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub mup() Handles Me.MouseUp, LeButton.MouseUp, Logo.MouseUp, Status.MouseUp, HelpText.MouseUp, LiveTracks.MouseMove
        Dim rightSpace As Integer = Screen.PrimaryScreen.Bounds.Width - Me.Width - Me.Left ' This is the space left on the right
        Dim bottomSpace As Integer = Screen.PrimaryScreen.Bounds.Height - Me.Height - Me.Top ' The space left on the bottom

        If Me.Left < 0 Then
            ' If the window crossed the left screen border
            Me.Left = 0
        End If
        If Me.Top < 0 Then
            ' If the window crossed the top screen border
            Me.Top = 0
        End If
        If bottomSpace < 0 Then
            ' If the window crossed the bottom screen border
            Me.Top = Screen.PrimaryScreen.Bounds.Height - Me.Height
        End If
        If rightSpace < 0 Then
            ' If the window crossed the right screen border
            Me.Left = Screen.PrimaryScreen.Bounds.Width - Me.Width
        End If
        drag = False
    End Sub
#End Region
#Region "Fading background"
    Private direction As Boolean = True ' True = move to colorMin / False = move to colorMax
    Private colorMin As Integer = 100 ' The lowest color value
    Private colorMax As Integer = 200 ' The highest color value
    Private pause As Integer = 25 ' Interval the timer waits before switching direction
    Private pauseCount As Integer = 0 ' For internal use
    Private stopMoveHigh As Boolean = False ' When this is True, stop the timer at colorMax
    Private stopMoveLow As Boolean = False ' When this is True, stop the timer at colorMin

    Private Sub Colormove_Tick(sender As Object, e As EventArgs) Handles Colormove.Tick

        Dim r As Integer = CInt("&H" & Hex(Me.BackColor.ToArgb).Substring(2, 2))
        If r = colorMin And direction Then
            If stopMoveLow Then
                stopMoveLow = False
                Colormove.Stop()
                Exit Sub
            End If
            If pause > 0 And pauseCount < pause Then
                pauseCount += 1
            Else
                pauseCount = 0
                direction = False ' To white
                r = colorMin + 1
            End If
        ElseIf Not direction And r = colorMax Then
            If stopMoveHigh Then
                stopMoveHigh = False
                Colormove.Stop()
                Exit Sub
            End If
            If pause > 0 And pauseCount < pause Then
                pauseCount += 1
            Else
                pauseCount = 0
                direction = True ' To black
                r = colorMax - 1
            End If
        ElseIf direction Then
            r -= 1
        ElseIf Not direction Then
            r += 1
        End If
        Me.BackColor = Color.FromArgb(r, r, r)
    End Sub
#End Region
#Region "Status animation"
    Private up As Boolean = False
    Private yup As Integer = -22
    Private ydown As Integer = -3
    Private newText As String = ""
    Private Sub Statusmove_Tick(sender As Object, e As EventArgs) Handles Statusmove.Tick
        If Not up And yup < Status.Location.Y Then
            Status.Location = New Point(Status.Location.X, Status.Location.Y - 1)
        ElseIf Not up And yup = Status.Location.Y Then
            up = True
            Status.Text = newText
        ElseIf up And ydown > Status.Location.Y Then
            Status.Location = New Point(Status.Location.X, Status.Location.Y + 1)
        ElseIf up And ydown = Status.Location.Y Then
            up = False
            Statusmove.Stop()
        End If
    End Sub

    Private Sub UpdateStatus(ByVal text As String)
        If Status.Text = text Then : Exit Sub : End If
        newText = text
        If Status.Text.Length = 0 Then
            Status.Text = text
            Exit Sub
        End If
        Statusmove.Start()
    End Sub
#End Region
#Region "Updates"
    Private Sub Checkupdates_DoWork() Handles Checkupdates.DoWork
        If debug Then : Exit Sub : End If
        Using wc As New Net.WebClient
            Dim res As String
            Try
                res = wc.DownloadString("http://inspiron.tobiass.eu/last")
                If res = ProductVersion = False Then
                    If MsgBox("There's a new version available for download! Get it now?", vbYesNo, "Update available") = MsgBoxResult.Yes Then
                        Process.Start("http://inspiron.tobiass.eu")
                    End If
                End If
            Catch
            End Try

        End Using
    End Sub
#End Region
#Region "Live track listing"
    Private Sub Updatetrack_Tick() Handles Updatetrack.Tick
            If Updatetrackworker.IsBusy = False Then
                Updatetrackworker.RunWorkerAsync()
            End If
    End Sub

    Private liveresult As String

    Private Sub Updatetrackworker_DoWork() Handles Updatetrackworker.DoWork
        Using wc As New Net.WebClient
            Try
                liveresult = wc.DownloadString("http://inspiron.tobiass.eu/playing.php")
                If Updatetrack.Enabled = False Then
                    Updatetrackworker.ReportProgress(3)
                Else
                    Updatetrackworker.ReportProgress(1)
                End If
            Catch
                Updatetrackworker.ReportProgress(2)
            End Try
        End Using
    End Sub

    Private Sub Updatetrackworker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Updatetrackworker.ProgressChanged
        If e.ProgressPercentage = 1 Then
            LiveTracks.Text = liveresult
            TT.SetToolTip(LiveTracks, liveresult)
        ElseIf e.ProgressPercentage = 2 Then
            LiveTracks.Text = "There was a problem retrieving the current track."
            TT.SetToolTip(LiveTracks, Nothing)
        ElseIf e.ProgressPercentage = 3 Then
            LiveTracks.Text = ""
            TT.SetToolTip(LiveTracks, Nothing)
        End If
    End Sub
#End Region
End Class