Public Class Form1
    Private Sub CenterPanel()
        ConfigPnl.Location = New Point(
            LobbyPnl.Width / 2 - ConfigPnl.Size.Width / 2,
            LobbyPnl.Height / 2 - ConfigPnl.Size.Height / 2
        )
        ConfigPnl.Anchor = AnchorStyles.None

        requestPnl.Location = New Point(
           LobbyPnl.Width / 2 - requestPnl.Size.Width / 2,
           LobbyPnl.Height / 2 - requestPnl.Size.Height / 2
       )
        requestPnl.Anchor = AnchorStyles.None

        loginPnl.Location = New Point(
           LobbyPnl.Width / 2 - loginPnl.Size.Width / 2,
           LobbyPnl.Height / 2 - loginPnl.Size.Height / 2
       )
        loginPnl.Anchor = AnchorStyles.None
    End Sub

    Private Sub ToggleUI(state1 As Boolean, state2 As Boolean, state3 As Boolean, state4 As Boolean)
        CenterPanel()
        btnPnl.Visible = state1
        ConfigPnl.Visible = state2
        requestPnl.Visible = state3
        loginPnl.Visible = state4
    End Sub

    Private Sub ToggleBtnPnl()
        If btnPnl.Visible Then
            btnPnl.Visible = False
        Else
            btnPnl.Visible = True
        End If
    End Sub

    Private Sub LoadConfig()
        server_txtbox.Text = My.Settings.server
        port_txtbox.Text = My.Settings.port
        uname_txtbox.Text = My.Settings.username
        pword_txtbox.Text = My.Settings.password
        dbname_txtbox.Text = My.Settings.db_name
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles DocumentsBtn.Click
        ToggleBtnPnl()
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        ToggleUI(False, False, False, True)
    End Sub

    Private Sub MetroPanel1_Paint(sender As Object, e As PaintEventArgs) Handles LobbyPnl.Paint

    End Sub

    Private Sub MetroPanel2_Paint(sender As Object, e As PaintEventArgs) Handles ConfigPnl.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub saveConfBtn_Click(sender As Object, e As EventArgs) Handles saveConfBtn.Click
        My.Settings.server = server_txtbox.Text
        My.Settings.port = port_txtbox.Text
        My.Settings.username = uname_txtbox.Text
        My.Settings.password = pword_txtbox.Text
        My.Settings.db_name = dbname_txtbox.Text
        My.Settings.Save()
        MsgBox("Configuration had been saved.", vbInformation, "Successful")
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles trackReqBtn.Click
        ToggleUI(False, False, True, False)
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click

    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click

    End Sub

    Private Sub configBtn_Click(sender As Object, e As EventArgs) Handles configBtn.Click
        ToggleUI(False, True, False, False)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConfig()
    End Sub
End Class
