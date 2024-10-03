Imports System.IO
Imports MySql.Data.MySqlClient
Imports Mysqlx

Public Class Admin
    Private Sub InitializeLogo()
        Dim imagePath As String = Application.StartupPath
        Dim logoFolderPath As String = Path.Combine(imagePath, "Logo")
        Dim fullPath As String = Path.Combine(logoFolderPath, My.Settings.LogoName)
        LoadImageToPictureBox(LogoSlot, fullPath)
    End Sub

    Private Sub FetchClearance()
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_clearance.Rows.Clear()
            dgv_clearanceEdit.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_clearance"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                dgv_clearance.Rows.Add(dr("clearance_track_id"), dr("clearance_name"), dr("clearance_purpose"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
                dgv_clearanceEdit.Rows.Add(dr("clearance_track_id"), dr("clearance_name"), dr("clearance_purpose"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchCertificate()
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_certificate.Rows.Clear()
            dgv_certificateEdit.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_certificate"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                dgv_certificate.Rows.Add(dr("cert_track_id"), dr("cert_name"), dr("cert_purpose"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
                dgv_certificateEdit.Rows.Add(dr("cert_track_id"), dr("cert_name"), dr("cert_purpose"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchBusClearance()
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_bus_clearance.Rows.Clear()
            dgv_bus_clearanceEdit.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_bus_clearance"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                dgv_bus_clearance.Rows.Add(dr("bc_track_id"), dr("bc_owner_name"), dr("bc_bus_name"), dr("bc_bus_addr"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
                dgv_bus_clearanceEdit.Rows.Add(dr("bc_track_id"), dr("bc_owner_name"), dr("bc_bus_name"), dr("bc_bus_addr"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
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
        FetchClearance()
        clearance_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False)
        ToggleReports(True, False, False)
        showSettings()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        FetchCertificate()
        certificate_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False)
        ToggleReports(False, True, False)
        showSettings()
    End Sub

    Private Sub BusinessClearanceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BusinessClearanceToolStripMenuItem1.Click
        FetchBusClearance()
        bus_clearance_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False)
        ToggleReports(False, False, True)
        showSettings()
    End Sub

    Private Sub ClearanceToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ClearanceToolStripMenuItem.Click
        FetchClearance()
        bt_clearance_pnl.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(True, False, False)
        showSettings()
    End Sub

    Private Sub CertificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CertificationToolStripMenuItem.Click
        FetchCertificate()
        bt_certificate_pnl.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(False, True, False)
        showSettings()
    End Sub

    Private Sub BusinessClearanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusinessClearanceToolStripMenuItem.Click
        FetchBusClearance()
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

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_clearanceEdit.CellContentClick
        If e.ColumnIndex = dgv_clearanceEdit.Columns("actionBtn").Index AndAlso e.RowIndex >= 0 Then
            showFullDetails("SELECT * FROM bgms_clearance")
            bt_clearance_pnl.Controls.Add(actionModel)
            actionModel.Width = 410
            actionModel.Height = 430
            actionModel.Location = New Point(
               bt_clearance_pnl.Width / 2 - actionModel.Size.Width / 2,
               bt_clearance_pnl.Height / 2 - actionModel.Size.Height / 2
            )
            actionModel.Anchor = AnchorStyles.None
            actionModel.Visible = True
            actionModel.BringToFront()
        End If
    End Sub

    Private Sub showFullDetails(query As String)
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim cm As New MySqlCommand(query, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()
            Dim labels() As String

            informationBox.Clear()

            If query.Contains("bgms_clearance") Then
                labels = {"Track ID: ", "Name: ", "Age: ", "Sex: ", "Civil Status: ", "Purok: ", "Purpose: ", "Request Date: ", "Status: "}
            ElseIf query.Contains("bgms_certificate") Then
                labels = {"Track ID: ", "Name: ", "Purok: ", "Purpose: ", "Request Date: ", "Status: "}
            Else
                labels = {"Track ID: ", "Business Name: ", "Business Owner: ", "Business Address: ", "Request Date: ", "Status: "}
            End If

            While dr.Read()
                For i As Integer = 0 To dr.FieldCount - 1
                    If TypeOf dr(i) Is DateTime Then
                        Dim dateValue As DateTime = CType(dr(i), DateTime)
                        informationBox.AppendText("Request Date: " & dateValue.ToString("yyyy-MM-dd"))
                        informationBox.AppendText(Environment.NewLine)
                    Else
                        informationBox.AppendText(labels(i) & dr(i).ToString())
                        informationBox.AppendText(Environment.NewLine)
                    End If
                Next
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        actionModel.Visible = False
    End Sub

    Private Sub dgv_certificateEdit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_certificateEdit.CellContentClick
        If e.ColumnIndex = dgv_certificateEdit.Columns("actBtn").Index AndAlso e.RowIndex >= 0 Then
            showFullDetails("SELECT * FROM bgms_certificate")
            bt_certificate_pnl.Controls.Add(actionModel)
            actionModel.Width = 410
            actionModel.Height = 430
            actionModel.Location = New Point(
               bt_certificate_pnl.Width / 2 - actionModel.Size.Width / 2,
               bt_certificate_pnl.Height / 2 - actionModel.Size.Height / 2
            )
            actionModel.Anchor = AnchorStyles.None
            actionModel.Visible = True
            actionModel.BringToFront()
        End If
    End Sub

    Private Sub dgv_bus_clearanceEdit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_bus_clearanceEdit.CellContentClick
        If e.ColumnIndex = dgv_bus_clearanceEdit.Columns("actionButton").Index AndAlso e.RowIndex >= 0 Then
            showFullDetails("SELECT * FROM bgms_bus_clearance")
            bt_bus_clearance.Controls.Add(actionModel)
            actionModel.Width = 410
            actionModel.Height = 430
            actionModel.Location = New Point(
               bt_bus_clearance.Width / 2 - actionModel.Size.Width / 2,
               bt_bus_clearance.Height / 2 - actionModel.Size.Height / 2
            )
            actionModel.Anchor = AnchorStyles.None
            actionModel.Visible = True
            actionModel.BringToFront()
        End If
    End Sub
End Class