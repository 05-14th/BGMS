Imports System.IO

Public Class Login
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

        brgyCertPnl.Location = New Point(
           LobbyPnl.Width / 2 - brgyCertPnl.Size.Width / 2,
           LobbyPnl.Height / 2 - brgyCertPnl.Size.Height / 2
       )
        brgyCertPnl.Anchor = AnchorStyles.None

        ClearancePnl.Location = New Point(
           LobbyPnl.Width / 2 - ClearancePnl.Size.Width / 2,
           LobbyPnl.Height / 2 - ClearancePnl.Size.Height / 2
       )
        ClearancePnl.Anchor = AnchorStyles.None

        busClearancePnl.Location = New Point(
         LobbyPnl.Width / 2 - busClearancePnl.Size.Width / 2,
         LobbyPnl.Height / 2 - busClearancePnl.Size.Height / 2
     )
        busClearancePnl.Anchor = AnchorStyles.None
    End Sub

    Private Sub ToggleUI(state1 As Boolean, state2 As Boolean, state3 As Boolean, state4 As Boolean, state5 As Boolean, state6 As Boolean, state7 As Boolean)
        CenterPanel()
        btnPnl.Visible = state1
        ConfigPnl.Visible = state2
        requestPnl.Visible = state3
        loginPnl.Visible = state4
        brgyCertPnl.Visible = state5
        ClearancePnl.Visible = state6
        busClearancePnl.Visible = state7
    End Sub

    Private Sub ToggleBtnPnl()
        If btnPnl.Visible Then
            btnPnl.Visible = False
        Else
            btnPnl.Visible = True
        End If
    End Sub

    Private Sub InitializeLogo()
        Dim imagePath As String = Application.StartupPath
        Dim logoFolderPath As String = Path.Combine(imagePath, "Logo")
        Dim fullPath As String = Path.Combine(logoFolderPath, My.Settings.LogoName)
        LoadImageToPictureBox(PictureBox1, fullPath)
    End Sub

    Private Sub LoadConfig()
        server_txtbox.Text = My.Settings.server
        port_txtbox.Text = My.Settings.port
        uname_txtbox.Text = My.Settings.username
        pword_txtbox.Text = My.Settings.password
        dbname_txtbox.Text = My.Settings.db_name
        InitializeLogo()
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles DocumentsBtn.Click
        ToggleBtnPnl()
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        ToggleUI(False, False, False, True, False, False, False)
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
        ToggleUI(False, False, True, False, False, False, False)
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles Cert_btn.Click
        ToggleUI(True, False, False, False, True, False, False)
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles brgyClearance_btn.Click
        ToggleUI(True, False, False, False, False, False, True)
    End Sub

    Private Sub configBtn_Click(sender As Object, e As EventArgs) Handles configBtn.Click
        ToggleUI(False, True, False, False, False, False, False)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConfig()
    End Sub

    Private Sub Clearance_btn_Click(sender As Object, e As EventArgs) Handles Clearance_btn.Click
        ToggleUI(True, False, False, False, False, True, False)
    End Sub

    Private Sub MetroButton1_Click_1(sender As Object, e As EventArgs) Handles login_btn.Click
        Me.Hide()
        Admin.ShowDialog()
        Me.Close()
    End Sub

    Private Sub pass_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles pass_checkbox.CheckedChanged
        login_pword_txtbox.UseSystemPasswordChar = Not pass_checkbox.Checked
    End Sub


End Class
