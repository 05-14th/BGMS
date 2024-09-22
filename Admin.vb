Imports System.IO

Public Class Admin
    Private Sub InitializeLogo()
        Dim imagePath As String = Application.StartupPath
        Dim logoFolderPath As String = Path.Combine(imagePath, "Logo")
        Dim fullPath As String = Path.Combine(logoFolderPath, My.Settings.LogoName)
        LoadImageToPictureBox(LogoSlot, fullPath)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles upload_btn.Click

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim image As Image = Image.FromFile(openFileDialog.FileName)
            SaveImageToLogoFolder(image, Path.GetFileName(openFileDialog.FileName))
            My.Settings.LogoName = openFileDialog.FileName
            My.Settings.Save()
            MsgBox("Image saved successfully!", vbInformation + vbOK, "Successful")
            LogoSlot.Image = Image.FromFile(openFileDialog.FileName)
        End If
    End Sub

    Private Sub showSettings(Optional state As Boolean = False)
        settings_pnl.Visible = state
    End Sub

    Private Sub SaveImageToLogoFolder(image As Image, fileName As String)
        Dim projectPath As String = Application.StartupPath
        Dim logoFolderPath As String = Path.Combine(projectPath, "Logo")
        If Not Directory.Exists(logoFolderPath) Then
            Directory.CreateDirectory(logoFolderPath)
        End If

        Dim fullPath As String = Path.Combine(logoFolderPath, fileName)
        image.Save(fullPath)
    End Sub

    Private Sub ToggleReports(state1 As Boolean, state2 As Boolean, state3 As Boolean)
        clearance_pnl.Visible = state1
        certificate_pnl.Visible = state2
        bus_clearance_pnl.Visible = state3
    End Sub

    Private Sub ToggleBT(state1 As Boolean, state2 As Boolean, state3 As Boolean, Optional state4 As Boolean = False, Optional state5 As Boolean = False)
        bt_clearance_pnl.Visible = state1
        bt_certificate_pnl.Visible = state2
        bt_bus_clearance.Visible = state3
        blotter_pnl.Visible = state4
        summonPnl.Visible = state5
    End Sub

    Private Sub brgyTrans_btn_Click(sender As Object, e As EventArgs) Handles brgyTrans_btn.Click
        Me.Bt_Menu.Show(Me.brgyTrans_btn, Me.brgyTrans_btn.PointToClient(Cursor.Position))
    End Sub

    Private Sub brgyMngmnt_btn_Click(sender As Object, e As EventArgs) Handles brgyMngmnt_btn.Click
        Me.Bm_Menu.Show(Me.brgyMngmnt_btn, Me.brgyMngmnt_btn.PointToClient(Cursor.Position))
    End Sub

    Private Sub exit_btn_Click(sender As Object, e As EventArgs) Handles exit_btn.Click
        Me.Close()
    End Sub

    Private Sub MetroButton10_Click(sender As Object, e As EventArgs) Handles reports_btn.Click
        Me.Settings_Menu.Show(Me.reports_btn, Me.reports_btn.PointToClient(Cursor.Position))
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        clearance_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False)
        ToggleReports(True, False, False)
        showSettings()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        certificate_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False)
        ToggleReports(False, True, False)
        showSettings()
    End Sub

    Private Sub BusinessClearanceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BusinessClearanceToolStripMenuItem1.Click
        bus_clearance_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False)
        ToggleReports(False, False, True)
        showSettings()
    End Sub

    Private Sub ClearanceToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ClearanceToolStripMenuItem.Click
        bt_clearance_pnl.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(True, False, False)
        showSettings()
    End Sub

    Private Sub CertificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CertificationToolStripMenuItem.Click
        bt_certificate_pnl.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(False, True, False)
        showSettings()
    End Sub

    Private Sub BusinessClearanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusinessClearanceToolStripMenuItem.Click
        bt_bus_clearance.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(False, False, True)
        showSettings()
    End Sub

    Private Sub MetroButton11_Click(sender As Object, e As EventArgs) Handles MetroButton11.Click
        settings_pnl.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(False, False, False)
        showSettings(True)
    End Sub

    Private Sub BlotterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlotterToolStripMenuItem.Click
        blotter_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False, True)
        Dim blotter_report As New Blotter_Report()
        blotter_report.Dock = DockStyle.Fill
        blotter_pnl.Controls.Add(blotter_report)
        showSettings()
    End Sub

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeLogo()
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles removeLogo.Click
        Dim removeImage As DialogResult = MsgBox("Are you sure you want to remove logo?", vbQuestion + vbYesNo, "Confirmation")
        If removeImage = DialogResult.Yes Then
            MsgBox("Logo had been removed.", vbOK + vbInformation, "Success")
            LogoSlot.Image = Nothing
            My.Settings.LogoName = ""
            My.Settings.Save()
        End If
    End Sub

    Private Sub SummonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummonToolStripMenuItem.Click
        summonPnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False, False, True)
        summonPnl.Controls.Add(summon_pnl)
        summon_pnl.Location = New Point(
            summonPnl.Width / 2 - summon_pnl.Size.Width / 2,
            summonPnl.Height / 2 - summon_pnl.Size.Height / 2
        )
        summon_pnl.Anchor = AnchorStyles.None
        summon_pnl.Visible = True
        Panel5.Dock = DockStyle.Fill
        Panel8.Dock = DockStyle.Fill
    End Sub


End Class