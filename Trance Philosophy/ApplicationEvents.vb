Imports Un4seen.Bass

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub app_Startup() Handles Me.Startup
            If Computer.Network.IsAvailable = False And False Then
                MsgBox("This application requires an internet connection to run.", MsgBoxStyle.Critical, "Network connection unavailable")
                End
            End If
            BassNet.Registration("tobiaqs@yahoo.nl", "2X182428163435")

            Try
                Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Player.Handle, Nothing)
            Catch ex As Exception
                MsgBox("The application can't start due a problem with the BASS library.")
                End
            End Try
        End Sub

        Private Sub app_NetworkAvailabilityChanged() Handles Me.NetworkAvailabilityChanged
            If Computer.Network.IsAvailable = False Then
                MsgBox("This application requires an internet connection to run.", MsgBoxStyle.Critical, "Network connection unavailable")
                End
            End If
        End Sub

        Private Sub app_StartupNextInstance() Handles Me.StartupNextInstance
            Player.BringToFront()
        End Sub
    End Class


End Namespace

