<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Player
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Player))
        Me.LeButton = New System.Windows.Forms.PictureBox()
        Me.Colormove = New System.Windows.Forms.Timer(Me.components)
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.Min = New System.Windows.Forms.Label()
        Me.Quit = New System.Windows.Forms.Label()
        Me.Play = New System.ComponentModel.BackgroundWorker()
        Me.Status = New System.Windows.Forms.Label()
        Me.Vistimer = New System.Windows.Forms.Timer(Me.components)
        Me.Statusupdater = New System.ComponentModel.BackgroundWorker()
        Me.StatusupdaterTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.Statusmove = New System.Windows.Forms.Timer(Me.components)
        Me.Volumebar = New System.Windows.Forms.TrackBar()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.Help = New System.Windows.Forms.Label()
        Me.HelpText = New System.Windows.Forms.LinkLabel()
        Me.More = New System.Windows.Forms.Button()
        Me.Checkupdates = New System.ComponentModel.BackgroundWorker()
        Me.Updatetrack = New System.Windows.Forms.Timer(Me.components)
        Me.LiveTracks = New System.Windows.Forms.Label()
        Me.Updatetrackworker = New System.ComponentModel.BackgroundWorker()
        CType(Me.LeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Volumebar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LeButton
        '
        Me.LeButton.BackColor = System.Drawing.Color.Transparent
        Me.LeButton.Image = Global.TrancePhilosophy.My.Resources.Resources.play_black
        Me.LeButton.Location = New System.Drawing.Point(52, 30)
        Me.LeButton.Name = "LeButton"
        Me.LeButton.Size = New System.Drawing.Size(300, 300)
        Me.LeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LeButton.TabIndex = 0
        Me.LeButton.TabStop = False
        '
        'Colormove
        '
        Me.Colormove.Interval = 10
        '
        'Logo
        '
        Me.Logo.BackColor = System.Drawing.Color.Transparent
        Me.Logo.Image = Global.TrancePhilosophy.My.Resources.Resources.logo_text
        Me.Logo.Location = New System.Drawing.Point(1, 356)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(400, 95)
        Me.Logo.TabIndex = 1
        Me.Logo.TabStop = False
        Me.TT.SetToolTip(Me.Logo, "Double-click to adjust volume")
        '
        'Min
        '
        Me.Min.BackColor = System.Drawing.Color.Black
        Me.Min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Min.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Min.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Min.ForeColor = System.Drawing.Color.White
        Me.Min.Location = New System.Drawing.Point(363, 1)
        Me.Min.Name = "Min"
        Me.Min.Size = New System.Drawing.Size(16, 15)
        Me.Min.TabIndex = 0
        Me.Min.Text = "-"
        Me.Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Quit
        '
        Me.Quit.BackColor = System.Drawing.Color.Black
        Me.Quit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Quit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Quit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Quit.ForeColor = System.Drawing.Color.White
        Me.Quit.Location = New System.Drawing.Point(382, 1)
        Me.Quit.Name = "Quit"
        Me.Quit.Size = New System.Drawing.Size(16, 15)
        Me.Quit.TabIndex = 0
        Me.Quit.Text = "X"
        Me.Quit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Play
        '
        Me.Play.WorkerReportsProgress = True
        '
        'Status
        '
        Me.Status.BackColor = System.Drawing.Color.Transparent
        Me.Status.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Status.Location = New System.Drawing.Point(20, -3)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(317, 27)
        Me.Status.TabIndex = 2
        Me.Status.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Vistimer
        '
        Me.Vistimer.Interval = 25
        '
        'Statusupdater
        '
        Me.Statusupdater.WorkerReportsProgress = True
        '
        'StatusupdaterTimer
        '
        Me.StatusupdaterTimer.Enabled = True
        Me.StatusupdaterTimer.Interval = 15000
        '
        'TT
        '
        Me.TT.AutoPopDelay = 5000
        Me.TT.InitialDelay = 100
        Me.TT.ReshowDelay = 100
        Me.TT.UseAnimation = False
        Me.TT.UseFading = False
        '
        'Statusmove
        '
        Me.Statusmove.Interval = 10
        '
        'Volumebar
        '
        Me.Volumebar.AutoSize = False
        Me.Volumebar.LargeChange = 10
        Me.Volumebar.Location = New System.Drawing.Point(103, 380)
        Me.Volumebar.Maximum = 100
        Me.Volumebar.Name = "Volumebar"
        Me.Volumebar.Size = New System.Drawing.Size(191, 26)
        Me.Volumebar.TabIndex = 3
        Me.Volumebar.TickStyle = System.Windows.Forms.TickStyle.None
        Me.Volumebar.Visible = False
        '
        'ReturnButton
        '
        Me.ReturnButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnButton.Location = New System.Drawing.Point(161, 412)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(75, 25)
        Me.ReturnButton.TabIndex = 4
        Me.ReturnButton.Text = "Return"
        Me.ReturnButton.UseVisualStyleBackColor = True
        Me.ReturnButton.Visible = False
        '
        'Help
        '
        Me.Help.BackColor = System.Drawing.Color.Black
        Me.Help.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Help.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Help.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Help.ForeColor = System.Drawing.Color.White
        Me.Help.Location = New System.Drawing.Point(344, 1)
        Me.Help.Name = "Help"
        Me.Help.Size = New System.Drawing.Size(16, 15)
        Me.Help.TabIndex = 0
        Me.Help.Text = "?"
        Me.Help.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HelpText
        '
        Me.HelpText.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.HelpText.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpText.ForeColor = System.Drawing.Color.LightGray
        Me.HelpText.LinkArea = New System.Windows.Forms.LinkArea(0, 0)
        Me.HelpText.LinkColor = System.Drawing.Color.White
        Me.HelpText.Location = New System.Drawing.Point(0, 0)
        Me.HelpText.Name = "HelpText"
        Me.HelpText.Size = New System.Drawing.Size(400, 452)
        Me.HelpText.TabIndex = 20
        Me.HelpText.Text = resources.GetString("HelpText.Text")
        Me.HelpText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.HelpText.Visible = False
        '
        'More
        '
        Me.More.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.More.Location = New System.Drawing.Point(159, 413)
        Me.More.Name = "More"
        Me.More.Size = New System.Drawing.Size(84, 23)
        Me.More.TabIndex = 22
        Me.More.Text = "Show more..."
        Me.More.UseVisualStyleBackColor = False
        Me.More.Visible = False
        '
        'Checkupdates
        '
        '
        'Updatetrack
        '
        Me.Updatetrack.Interval = 5000
        '
        'LiveTracks
        '
        Me.LiveTracks.BackColor = System.Drawing.Color.Transparent
        Me.LiveTracks.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LiveTracks.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LiveTracks.Location = New System.Drawing.Point(1, 330)
        Me.LiveTracks.Name = "LiveTracks"
        Me.LiveTracks.Size = New System.Drawing.Size(397, 27)
        Me.LiveTracks.TabIndex = 2
        Me.LiveTracks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Updatetrackworker
        '
        Me.Updatetrackworker.WorkerReportsProgress = True
        '
        'Player
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(400, 452)
        Me.Controls.Add(Me.More)
        Me.Controls.Add(Me.Quit)
        Me.Controls.Add(Me.ReturnButton)
        Me.Controls.Add(Me.Volumebar)
        Me.Controls.Add(Me.LeButton)
        Me.Controls.Add(Me.LiveTracks)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.Help)
        Me.Controls.Add(Me.Min)
        Me.Controls.Add(Me.Logo)
        Me.Controls.Add(Me.HelpText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.TrancePhilosophy.My.Resources.Resources.inspiron_s
        Me.Name = "Player"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Trance Philosophy Player"
        CType(Me.LeButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Volumebar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LeButton As System.Windows.Forms.PictureBox
    Friend WithEvents Colormove As System.Windows.Forms.Timer
    Friend WithEvents Logo As System.Windows.Forms.PictureBox
    Friend WithEvents Min As System.Windows.Forms.Label
    Friend WithEvents Quit As System.Windows.Forms.Label
    Friend WithEvents Play As System.ComponentModel.BackgroundWorker
    Friend WithEvents Status As System.Windows.Forms.Label
    Friend WithEvents Vistimer As System.Windows.Forms.Timer
    Friend WithEvents Statusupdater As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusupdaterTimer As System.Windows.Forms.Timer
    Friend WithEvents TT As System.Windows.Forms.ToolTip
    Friend WithEvents Statusmove As System.Windows.Forms.Timer
    Friend WithEvents Volumebar As System.Windows.Forms.TrackBar
    Friend WithEvents ReturnButton As System.Windows.Forms.Button
    Friend WithEvents Help As System.Windows.Forms.Label
    Friend WithEvents HelpText As System.Windows.Forms.LinkLabel
    Friend WithEvents More As System.Windows.Forms.Button
    Friend WithEvents Checkupdates As System.ComponentModel.BackgroundWorker
    Friend WithEvents Updatetrack As System.Windows.Forms.Timer
    Friend WithEvents LiveTracks As System.Windows.Forms.Label
    Friend WithEvents Updatetrackworker As System.ComponentModel.BackgroundWorker

End Class
