Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Org.BouncyCastle.Tsp


Public Class Admin
    Dim documentType As String
    Private Sub InitializeLogo()
        Dim imagePath As String = Application.StartupPath
        Dim logoFolderPath As String = Path.Combine(imagePath, "Logo")
        Dim fullPath As String = Path.Combine(logoFolderPath, My.Settings.LogoName)
        LoadImageToPictureBox(LogoSlot, fullPath)
    End Sub

    Private Sub CheckPriv()
        Console.WriteLine(My.Settings.access_level)
        If My.Settings.access_level = "Barangay Secretary" Then
            txtbox_amountPaid.Enabled = False
            FinancialReportToolStripMenuItem.Visible = False
        End If

        If My.Settings.access_level <> "Barangay Captain" Then
            um_btn.Visible = False
            MetroButton11.Visible = False
            MetroButton3.Visible = False
        End If

        If My.Settings.access_level = "Unknown Developer" Then
            um_btn.Visible = True
            MetroButton11.Visible = True
            MetroButton3.Visible = True
        End If
    End Sub

    Private Sub FetchClearance()
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_clearance.Rows.Clear()
            dgv_clearanceEdit.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_clearance WHERE archived= 0"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                If dr("status").Equals("Granted") Or dr("status").Equals("Denied") Then
                    If IsDBNull(dr("date_issued")) Then
                        dgv_clearance.Rows.Add(dr("clearance_track_id"), dr("clearance_name"), dr("clearance_age"), dr("clearance_sex"), dr("clearance_cs"), dr("clearance_purpose"), dr("clearance_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), "N/A", dr("status"))
                    Else
                        dgv_clearance.Rows.Add(dr("clearance_track_id"), dr("clearance_name"), dr("clearance_age"), dr("clearance_sex"), dr("clearance_cs"), dr("clearance_purpose"), dr("clearance_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), Convert.ToDateTime(dr("date_issued")).ToString("MM-dd-yyyy"), dr("status"))
                    End If
                ElseIf dr("status").Equals("Pending") Then
                    dgv_clearanceEdit.Rows.Add(dr("clearance_track_id"), dr("clearance_name"), dr("clearance_age"), dr("clearance_sex"), dr("clearance_cs"), dr("clearance_purpose"), dr("clearance_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
                End If
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchSpecifiClearance(keyword As String)
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_clearance.Rows.Clear()
            dgv_clearanceEdit.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_clearance WHERE archived= 0 AND clearance_name LIKE '%" & keyword & "%' OR clearance_track_id LIKE '%" & keyword & "%'"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                If dr("status").Equals("Granted") Or dr("status").Equals("Denied") Then
                    If IsDBNull(dr("date_issued")) Then
                        dgv_clearance.Rows.Add(dr("clearance_track_id"), dr("clearance_name"), dr("clearance_age"), dr("clearance_sex"), dr("clearance_cs"), dr("clearance_purpose"), dr("clearance_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), "N/A", dr("status"))
                    Else
                        dgv_clearance.Rows.Add(dr("clearance_track_id"), dr("clearance_name"), dr("clearance_age"), dr("clearance_sex"), dr("clearance_cs"), dr("clearance_purpose"), dr("clearance_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), Convert.ToDateTime(dr("date_issued")).ToString("MM-dd-yyyy"), dr("status"))
                    End If
                ElseIf dr("status").Equals("Pending") Then
                    dgv_clearanceEdit.Rows.Add(dr("clearance_track_id"), dr("clearance_name"), dr("clearance_age"), dr("clearance_sex"), dr("clearance_cs"), dr("clearance_purpose"), dr("clearance_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
                End If
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

            Dim sqlQuery As String = "SELECT * FROM bgms_certificate WHERE archived = 0"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                If dr("status").Equals("Granted") Or dr("status").Equals("Denied") Then
                    If IsDBNull(dr("date_issued")) Then
                        dgv_certificate.Rows.Add(dr("cert_track_id"), dr("cert_name"), dr("cert_purpose"), dr("cert_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), "N/A", dr("status"))
                    Else
                        dgv_certificate.Rows.Add(dr("cert_track_id"), dr("cert_name"), dr("cert_purpose"), dr("cert_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), Convert.ToDateTime(dr("date_issued")).ToString("MM-dd-yyyy"), dr("status"))
                    End If
                ElseIf dr("status").Equals("Pending") Then
                    dgv_certificateEdit.Rows.Add(dr("cert_track_id"), dr("cert_name"), dr("cert_purpose"), dr("cert_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
                End If
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchSpecificCertificate(keyword As String)
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_certificate.Rows.Clear()
            dgv_certificateEdit.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_certificate WHERE archived = 0 AND cert_name LIKE '%" & keyword & "%' OR cert_track_id LIKE '%" & keyword & "%'"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                If dr("status").Equals("Granted") Or dr("status").Equals("Denied") Then
                    If IsDBNull(dr("date_issued")) Then
                        dgv_certificate.Rows.Add(dr("cert_track_id"), dr("cert_name"), dr("cert_purpose"), dr("cert_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), "N/A", dr("status"))
                    Else
                        dgv_certificate.Rows.Add(dr("cert_track_id"), dr("cert_name"), dr("cert_purpose"), dr("cert_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), Convert.ToDateTime(dr("date_issued")).ToString("MM-dd-yyyy"), dr("status"))
                    End If
                ElseIf dr("status").Equals("Pending") Then
                    dgv_certificateEdit.Rows.Add(dr("cert_track_id"), dr("cert_name"), dr("cert_purpose"), dr("cert_purok"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
                End If
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Public Sub FetchConfig()
        Dim command As MySqlCommand = Nothing
        Dim reader As MySqlDataReader = Nothing

        Try
            Dim query As String = "SELECT * FROM bgms_config WHERE config_type = @value"
            command = New MySqlCommand(query, cn)
            command.Parameters.AddWithValue("@value", "name")
            reader = command.ExecuteReader()
            If reader.HasRows Then
                Dim counter As Integer = 0
                While reader.Read()
                    Dim result As String = reader("config_content").ToString()
                    Select Case counter
                        Case 0
                            txtbox_brgyName.Text = result
                        Case 1
                            txtBox_muni.Text = result
                        Case 2
                            txtBox_prov.Text = result
                    End Select
                    counter += 1
                End While
            Else
                MsgBox("No data found.", vbOK + vbCritical, "Missing Data")
            End If
        Catch ex As MySqlException
            MsgBox("MySQL error: " & ex.Message, vbOK + vbCritical, "Database Error")
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbOK + vbCritical, "System Error")
        Finally
            ' Close the reader
            If reader IsNot Nothing Then
                reader.Close()
            End If

            ' Dispose of the command
            If command IsNot Nothing Then
                command.Dispose()
            End If
        End Try
    End Sub

    Private Sub FetchBusClearance()
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_bus_clearance.Rows.Clear()
            dgv_bus_clearanceEdit.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_bus_clearance WHERE archived = 0"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                If dr("status").Equals("Granted") Or dr("status").Equals("Denied") Then
                    If IsDBNull(dr("date_issued")) Then
                        dgv_bus_clearance.Rows.Add(dr("bc_track_id"), dr("bc_owner_name"), dr("bc_bus_name"), dr("bc_bus_addr"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), "N/A", dr("status"))
                    Else
                        dgv_bus_clearance.Rows.Add(dr("bc_track_id"), dr("bc_owner_name"), dr("bc_bus_name"), dr("bc_bus_addr"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), Convert.ToDateTime(dr("date_issued")).ToString("MM-dd-yyyy"), dr("status"))
                    End If
                ElseIf dr("status").Equals("Pending") Then
                    dgv_bus_clearanceEdit.Rows.Add(dr("bc_track_id"), dr("bc_owner_name"), dr("bc_bus_name"), dr("bc_bus_addr"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
                End If

            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchSpecificBusClearance(keyword As String)
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_bus_clearance.Rows.Clear()
            dgv_bus_clearanceEdit.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_bus_clearance WHERE archived = 0 AND bc_owner_name LIKE '%" & keyword & "%' OR bc_bus_name LIKE '%" & keyword & "%' OR bc_track_id LIKE '%" & keyword & "%'"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                If dr("status").Equals("Granted") Or dr("status").Equals("Denied") Then
                    If IsDBNull(dr("date_issued")) Then
                        dgv_bus_clearance.Rows.Add(dr("bc_track_id"), dr("bc_owner_name"), dr("bc_bus_name"), dr("bc_bus_addr"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), "N/A", dr("status"))
                    Else
                        dgv_bus_clearance.Rows.Add(dr("bc_track_id"), dr("bc_owner_name"), dr("bc_bus_name"), dr("bc_bus_addr"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), Convert.ToDateTime(dr("date_issued")).ToString("MM-dd-yyyy"), dr("status"))
                    End If
                ElseIf dr("status").Equals("Pending") Then
                    dgv_bus_clearanceEdit.Rows.Add(dr("bc_track_id"), dr("bc_owner_name"), dr("bc_bus_name"), dr("bc_bus_addr"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
                End If

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

    Private Sub ToggleBT(Optional state1 As Boolean = False, Optional state2 As Boolean = False, Optional state3 As Boolean = False, Optional state4 As Boolean = False, Optional state5 As Boolean = False, Optional state6 As Boolean = False, Optional state7 As Boolean = False, Optional state8 As Boolean = False)
        bt_clearance_pnl.Visible = state1
        bt_certificate_pnl.Visible = state2
        bt_bus_clearance.Visible = state3
        blotter_pnl.Visible = state4
        summonPnl.Visible = state5
        pnl_financial.Visible = state6
        pnl_archive.Visible = state7
        um_pnl.Visible = state8
        summon_info.Visible = False
        blotter_info.Visible = False
    End Sub

    Private Sub brgyTrans_btn_Click(sender As Object, e As EventArgs) Handles brgyTrans_btn.Click
        Me.Bt_Menu.Show(Me.brgyTrans_btn, Me.brgyTrans_btn.PointToClient(Cursor.Position))
    End Sub

    Private Sub brgyMngmnt_btn_Click(sender As Object, e As EventArgs) Handles brgyMngmnt_btn.Click
        Me.Bm_Menu.Show(Me.brgyMngmnt_btn, Me.brgyMngmnt_btn.PointToClient(Cursor.Position))
    End Sub

    Private Sub MetroButton10_Click(sender As Object, e As EventArgs) Handles reports_btn.Click
        Me.Settings_Menu.Show(Me.reports_btn, Me.reports_btn.PointToClient(Cursor.Position))
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        clearance_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False)
        ToggleReports(True, False, False)
        FetchClearance()
        showSettings()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        certificate_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False)
        ToggleReports(False, True, False)
        FetchCertificate()
        showSettings()
    End Sub

    Private Sub BusinessClearanceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BusinessClearanceToolStripMenuItem1.Click
        bus_clearance_pnl.Dock = DockStyle.Fill
        ToggleBT(False, False, False)
        ToggleReports(False, False, True)
        FetchBusClearance()
        showSettings()
    End Sub

    Private Sub ClearanceToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ClearanceToolStripMenuItem.Click
        documentType = "clearance"
        bt_clearance_pnl.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(True, False, False)
        FetchClearance()
        showSettings()
    End Sub

    Private Sub CertificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CertificationToolStripMenuItem.Click
        documentType = "certificate"
        bt_certificate_pnl.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(False, True, False)
        FetchCertificate()
        showSettings()
    End Sub

    Private Sub BusinessClearanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusinessClearanceToolStripMenuItem.Click
        documentType = "business_clearance"
        bt_bus_clearance.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(False, False, True)
        FetchBusClearance()
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
        FetchConfig()
        FetchAccount()
        CheckPriv()
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
        MetroButton12.Visible = False
        MetroButton13.Visible = False
        Dim id As String = GenerateID()
        TextBox13.Text = id
        TextBox14.Text = DateTime.Now.ToString("MM/dd/yyyy")
        TextBox14.ReadOnly = True
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
            Dim clickedRow As DataGridViewRow = dgv_clearanceEdit.Rows(e.RowIndex)
            Dim firstCellValue As Object = clickedRow.Cells(0).Value
            showFullDetails("SELECT * FROM bgms_clearance WHERE clearance_track_id = '" & firstCellValue & "'")
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
                labels = {"Track ID: ", "Name: ", "Age: ", "Sex: ", "Civil Status: ", "Purok: ", "Purpose: ", "Request Date: ", "Date Issued: ", "Status: "}
            ElseIf query.Contains("bgms_certificate") Then
                labels = {"Track ID: ", "Name: ", "Purok: ", "Purpose: ", "Request Date: ", "Date Issued: ", "Status: "}
            Else
                labels = {"Track ID: ", "Business Name: ", "Business Owner: ", "Business Address: ", "Request Date: ", "Date Issued: ", "Status: "}
            End If

            While dr.Read()
                For i As Integer = 1 To dr.FieldCount - 3
                    txtbox_trackid.Text = dr(0).ToString()
                    If TypeOf dr(i) Is DateTime Then
                        Dim dateValue As DateTime = CType(dr(i), DateTime)
                        If dr.GetName(i).Equals("request_date") Then
                            informationBox.AppendText("Request Date: " & dateValue.ToString("yyyy-MM-dd"))
                        ElseIf dr.GetName(i).Equals("date_issued") Then
                            informationBox.AppendText("Date Issued: " & dateValue.ToString("yyyy-MM-dd"))
                        End If

                        informationBox.AppendText(Environment.NewLine)
                        informationBox.AppendText(Environment.NewLine)
                    Else
                        informationBox.AppendText(labels(i) & dr(i).ToString())
                        informationBox.AppendText(Environment.NewLine)
                        informationBox.AppendText(Environment.NewLine)
                    End If

                    If dr("status") <> "Pending" Then
                        MetroButton6.Enabled = False
                        MetroButton4.Enabled = False
                    Else
                        MetroButton6.Enabled = True
                        MetroButton4.Enabled = True
                    End If

                    If String.IsNullOrEmpty(txtbox_amountPaid.Text) Then
                        MetroButton6.Enabled = False
                    Else
                        MetroButton6.Enabled = True
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
            Dim clickedRow As DataGridViewRow = dgv_certificateEdit.Rows(e.RowIndex)
            Dim firstCellValue As Object = clickedRow.Cells(0).Value
            showFullDetails("SELECT * FROM bgms_certificate WHERE cert_track_id = '" & firstCellValue & "'")
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
            Dim clickedRow As DataGridViewRow = dgv_bus_clearanceEdit.Rows(e.RowIndex)
            Dim firstCellValue As Object = clickedRow.Cells(0).Value
            showFullDetails("SELECT * FROM bgms_bus_clearance WHERE bc_track_id = '" & firstCellValue & "'")
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

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim cmd As New MySqlCommand()
            cmd.Connection = cn

            If documentType.Equals("clearance") Then
                cmd.CommandText = "UPDATE bgms_clearance SET date_issued=@date, status = @status WHERE, amount=@amount clearance_track_id = @document_id"
            ElseIf documentType.Equals("certificate") Then
                cmd.CommandText = "UPDATE bgms_certificate SET date_issued=@date, status = @status, amount=@amount  WHERE cert_track_id = @document_id"
            Else
                cmd.CommandText = "UPDATE bgms_bus_clearance SET date_issued=@date, status = @status, amount=@amount  WHERE bc_track_id = @document_id"
            End If

            cmd.Parameters.AddWithValue("@status", "Granted")
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@document_id", txtbox_trackid.Text)
            cmd.Parameters.AddWithValue("@amount", txtbox_amountPaid.Text)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MsgBox("Document status updated successfully.", vbInformation, "Success")
            Else
                MsgBox("No document found with the specified ID.", vbExclamation, "No Update")
            End If

        Catch ex As Exception
            MsgBox("Failed to update document status", vbCritical, "Failure")
            cn.Close()
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            actionModel.Visible = False
            txtbox_amountPaid.Clear()

            If documentType.Equals("clearance") Then
                FetchClearance()
            ElseIf documentType.Equals("certificate") Then
                FetchCertificate()
            Else
                FetchBusClearance()
            End If
        End Try
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim cmd As New MySqlCommand()
            cmd.Connection = cn

            Console.WriteLine(documentType)

            If documentType.Equals("clearance") Then
                cmd.CommandText = "UPDATE bgms_clearance SET status = @status WHERE clearance_track_id = @document_id"
            ElseIf documentType.Equals("certificate") Then
                cmd.CommandText = "UPDATE bgms_certificate SET status = @status WHERE cert_track_id = @document_id"
            Else
                cmd.CommandText = "UPDATE bgms_bus_clearance SET status = @status WHERE bc_track_id = @document_id"
            End If

            cmd.Parameters.AddWithValue("@status", "Denied")
            Console.WriteLine(cmd.CommandText)
            cmd.Parameters.AddWithValue("@document_id", txtbox_trackid.Text)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MsgBox("Document status updated successfully.", vbInformation, "Success")
            Else
                MsgBox("No document found with the specified ID.", vbExclamation, "No Update")
            End If

        Catch ex As Exception
            MsgBox("Failed to update document status", vbCritical, "Failure")
            cn.Close()
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            actionModel.Visible = False
            txtbox_amountPaid.Clear()

            If documentType.Equals("clearance") Then
                FetchClearance()
            ElseIf documentType.Equals("certificate") Then
                FetchCertificate()
            Else
                FetchBusClearance()
            End If
        End Try
    End Sub

    Private Sub MetroButton5_Click_1(sender As Object, e As EventArgs) Handles MetroButton5.Click
        Dim answer = MsgBox("Are you sure you want to archive this record?", vbQuestion + vbYesNo, "Archive")
        If answer = vbYes Then
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                Dim cmd As New MySqlCommand()
                cmd.Connection = cn

                Console.WriteLine(documentType)

                If documentType.Equals("clearance") Then
                    cmd.CommandText = "UPDATE bgms_clearance SET archived = @status WHERE clearance_track_id = @document_id"
                ElseIf documentType.Equals("certificate") Then
                    cmd.CommandText = "UPDATE bgms_certificate SET archived = @status WHERE cert_track_id = @document_id"
                Else
                    cmd.CommandText = "UPDATE bgms_bus_clearance SET archived = @status WHERE bc_track_id = @document_id"
                End If

                cmd.Parameters.AddWithValue("@status", 1)
                Console.WriteLine(cmd.CommandText)
                cmd.Parameters.AddWithValue("@document_id", txtbox_trackid.Text)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MsgBox("Document archived successfully.", vbInformation, "Success")
                Else
                    MsgBox("No document found with the specified ID.", vbExclamation, "No Update")
                End If

            Catch ex As Exception
                MsgBox("Failed to update document status", vbCritical, "Failure")
                cn.Close()
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                actionModel.Visible = False
                txtbox_amountPaid.Clear()

                If documentType.Equals("clearance") Then
                    FetchClearance()
                ElseIf documentType.Equals("certificate") Then
                    FetchCertificate()
                Else
                    FetchBusClearance()
                End If
            End Try
        End If
    End Sub

    Private Sub exit_btn_Click_1(sender As Object, e As EventArgs) Handles um_btn.Click
        FetchAccount()
        um_pnl.Dock = DockStyle.Fill
        um_pnl.BringToFront()
        ToggleBT(False, False, False, state8:=True)
    End Sub

    Private Sub txtbox_amountPaid_TextChanged(sender As Object, e As EventArgs) Handles txtbox_amountPaid.TextChanged
        Dim cursorPosition As Integer = txtbox_amountPaid.SelectionStart

        If String.IsNullOrEmpty(txtbox_amountPaid.Text) Then
            MetroButton6.Enabled = False
        Else
            MetroButton6.Enabled = True
        End If

        Dim newText As String = String.Concat(txtbox_amountPaid.Text.Where(Function(c) Char.IsDigit(c) OrElse c = "."c))

        If newText.Count(Function(c) c = "."c) > 1 Then
            newText = newText.Remove(newText.LastIndexOf("."c))
        End If

        Dim decimalIndex As Integer = newText.IndexOf("."c)
        If decimalIndex <> -1 AndAlso newText.Length - decimalIndex > 3 Then
            newText = newText.Substring(0, decimalIndex + 3)
        End If

        If txtbox_amountPaid.Text <> newText Then
            txtbox_amountPaid.Text = newText
            txtbox_amountPaid.SelectionStart = Math.Min(cursorPosition, txtbox_amountPaid.Text.Length)
        End If
    End Sub

    Private Sub FinancialReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinancialReportToolStripMenuItem.Click
        ToggleBT(False, False, False, False, False, True)
        pnl_financial.Dock = DockStyle.Fill
        pnl_financial.BringToFront()
        FetchFinancialRep()
    End Sub

    Private Sub FetchFinancialRep()
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_financial.Rows.Clear()

            Dim sqlQuery As String = "
        SELECT 
            clearance_name AS name, 
            'Barangay Clearance' AS document_type,
            clearance_track_id AS tracking_code,
            request_date,
            date_issued,
            amount
        FROM 
            bgms_clearance 

        UNION ALL 

        SELECT 
            cert_name AS name, 
            'Barangay Certificate' AS document_type,
            cert_track_id AS tracking_code,
            request_date, 
            date_issued,
            amount
        FROM 
            bgms_certificate 

        UNION ALL 

        SELECT 
            bc_owner_name AS name,
            'Business Clearance' AS document_type,
            bc_track_id AS tracking_code,
            request_date, 
            date_issued,
            amount
        FROM 
            bgms_bus_clearance;"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()
            Dim totalAmount As Decimal = 0

            While dr.Read()
                Try
                    dgv_financial.Rows.Add(dr("tracking_code"), dr("name"), dr("document_type"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), Convert.ToDateTime(dr("date_issued")).ToString("MM-dd-yyyy"), dr("amount"))
                    Dim amount = Convert.ToDecimal(dr("amount"))
                    totalAmount += amount
                Catch ex As System.InvalidCastException
                    dgv_financial.Rows.Add(dr("tracking_code"), dr("name"), dr("document_type"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), "N/A", dr("amount"))
                End Try
            End While

            dgv_financial.Rows.Add("", "Total", "", "", "", totalAmount)

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchArchive()
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_archive.Rows.Clear()

            Dim sqlQuery As String = "
        SELECT 
            clearance_name AS name, 
            'Barangay Clearance' AS document_type,
            clearance_track_id AS tracking_code,
            request_date
        FROM 
            bgms_clearance WHERE archived = 1

        UNION ALL 

        SELECT 
            cert_name AS name, 
            'Barangay Certificate' AS document_type,
            cert_track_id AS tracking_code,
            request_date
        FROM 
            bgms_certificate WHERE archived = 1

        UNION ALL 

        SELECT 
            bc_owner_name AS name,
            'Business Clearance' AS document_type,
            bc_track_id AS tracking_code,
            request_date
        FROM 
            bgms_bus_clearance WHERE archived = 1;"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                dgv_archive.Rows.Add(dr("tracking_code"), dr("name"), dr("document_type"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchSpecificArchive(query As String)
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_archive.Rows.Clear()

            Dim sqlQuery As String = "
        SELECT 
            clearance_name AS name, 
            'Barangay Clearance' AS document_type,
            clearance_track_id AS tracking_code,
            request_date
        FROM 
            bgms_clearance WHERE archived = 1 AND clearance_track_id LIKE '%" & query & "%' OR clearance_name LIKE '%" & query & "%'

        UNION ALL 

        SELECT 
            cert_name AS name, 
            'Barangay Certificate' AS document_type,
            cert_track_id AS tracking_code,
            request_date
        FROM 
            bgms_certificate WHERE archived = 1 AND cert_track_id LIKE '%" & query & "%' OR cert_name LIKE '%" & query & "%'

        UNION ALL 

        SELECT 
            bc_owner_name AS name,
            'Business Clearance' AS document_type,
            bc_track_id AS tracking_code,
            request_date
        FROM 
            bgms_bus_clearance WHERE archived = 1 AND bc_track_id LIKE '%" & query & "%' OR bc_bus_name LIKE '%" & query & "%' OR bc_owner_name LIKE '%" & query & "%';"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                dgv_archive.Rows.Add(dr("tracking_code"), dr("name"), dr("document_type"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        FetchArchive()
        pnl_archive.Dock = DockStyle.Fill
        ToggleBT(False, False, False, state7:=True)
    End Sub

    Private Sub UpdateArchive(query As String, query2 As String)
        Try
            Dim count As Integer = 0
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            Dim cm As New MySqlCommand(query, cn)
            count = Convert.ToInt32(cm.ExecuteScalar())
            If count > 0 Then
                Dim cmd As New MySqlCommand(query2, cn)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MsgBox("Document Updated successfully.", vbInformation, "Success")
                    FetchArchive()
                End If
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub dgv_archive_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_archive.CellContentClick
        If e.ColumnIndex = dgv_archive.Columns("actButton").Index AndAlso e.RowIndex >= 0 Then
            Dim clickedRow As DataGridViewRow = dgv_archive.Rows(e.RowIndex)
            Dim firstCellValue As Object = clickedRow.Cells(0).Value
            Dim query = MsgBox("Do you want to unarchive this file?", vbQuestion + vbYesNo, "Archive")
            If query = vbYes Then
                UpdateArchive("SELECT COUNT(*) FROM bgms_clearance", "UPDATE bgms_clearance SET archived = 0 WHERE clearance_track_id = '" & firstCellValue & "'")
                UpdateArchive("SELECT COUNT(*) FROM bgms_certificate", "UPDATE bgms_certificate SET archived = 0 WHERE cert_track_id = '" & firstCellValue & "'")
                UpdateArchive("SELECT COUNT(*) FROM bgms_bus_clearance", "UPDATE bgms_bus_clearance SET archived = 0 WHERE bc_track_id = '" & firstCellValue & "'")
            End If
        End If
    End Sub

    Private captainName As String

    Private Sub FetchAccount()
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            um_dgv.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_account"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            Dim rowCount As Integer = 1

            While dr.Read()
                If dr("acc_position").ToString = "Barangay Captain" Then
                    captainName = dr("acc_name").ToString()
                End If
                um_dgv.Rows.Add(rowCount.ToString(), dr("acc_name").ToString(), dr("acc_username").ToString(), dr("acc_position").ToString(), dr("acc_role").ToString(), dr("acc_status").ToString())
                rowCount += 1
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub um_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles um_dgv.CellContentClick
        If e.ColumnIndex = um_dgv.Columns("um_action").Index AndAlso e.RowIndex >= 0 Then
            Dim clickedRow As DataGridViewRow = um_dgv.Rows(e.RowIndex)
            Dim firstCellValue As Object = clickedRow.Cells(2).Value
            Dim currentStatus As Object = clickedRow.Cells(5).Value
            Dim pos As Object = clickedRow.Cells(4).Value
            If currentStatus = "Active" And pos <> "Super Admin" Then
                Dim deactivate_confirmation = MsgBox("Do you want to deactivate this account?", vbYesNo + vbExclamation, "Deactivating Account")
                If deactivate_confirmation = vbYes Then
                    Try
                        If cn.State = ConnectionState.Closed Then
                            cn.Open()
                        End If

                        Dim deactivateString As String = "UPDATE bgms_account SET acc_status='Inactive' WHERE acc_username = @username"
                        Dim cmd As New MySqlCommand(deactivateString, cn)
                        cmd.Parameters.AddWithValue("@username", firstCellValue)
                        cmd.ExecuteNonQuery()
                        MsgBox("Account deactivated successfully.", vbInformation, "Success")
                        FetchAccount()
                    Catch ex As Exception
                        MsgBox("Failed to deactivate account: " & ex.Message, vbCritical, "Failure")
                    Finally
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If
                    End Try
                End If
            ElseIf currentStatus = "Inactive" And pos <> "Super Admin" Then
                Dim activate_confirmation = MsgBox("Do you want to reactivate this account?", vbYesNo + vbExclamation, "Reactivating Account")
                If activate_confirmation = vbYes Then
                    Try
                        If cn.State = ConnectionState.Closed Then
                            cn.Open()
                        End If

                        Dim activateString As String = "UPDATE bgms_account SET acc_status='Active' WHERE acc_username = @username"
                        Dim cmd As New MySqlCommand(activateString, cn)
                        cmd.Parameters.AddWithValue("@username", firstCellValue)
                        cmd.ExecuteNonQuery()
                        MsgBox("Account reactivated successfully.", vbInformation, "Success")
                        FetchAccount()
                    Catch ex As Exception
                        MsgBox("Failed to activate account: " & ex.Message, vbCritical, "Failure")
                    Finally
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If
                    End Try
                End If
            Else
                MsgBox("This account cannot be modified.", vbInformation, "Notice")
            End If
        End If
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        actionModal.Visible = False
    End Sub

    Private Sub addUsr_btn_Click(sender As Object, e As EventArgs) Handles addUsr_btn.Click
        um_pnl.Controls.Add(actionModal)
        actionModal.Width = 410
        actionModal.Height = 430
        actionModal.Location = New Point(
            um_pnl.Width / 2 - actionModal.Size.Width / 2,
            um_pnl.Height / 2 - actionModal.Size.Height / 2
        )
        actionModal.Anchor = AnchorStyles.None
        actionModal.Visible = True
        actionModal.BringToFront()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cn.Open()

        If txtbox_pass.Text = txtbox_cpass.Text Then
            Dim userInsertCommand As New MySqlCommand("INSERT INTO bgms_account (`acc_name`, `acc_username`, `acc_password`, `acc_position`, `acc_role`,`acc_status`) VALUES (@ac, @au, @ap, @acp,@ar, @as)", cn)
            userInsertCommand.Parameters.Add("@ac", MySqlDbType.VarChar).Value = txtbox_name.Text
            userInsertCommand.Parameters.Add("@au", MySqlDbType.VarChar).Value = txtbox_uname.Text
            userInsertCommand.Parameters.Add("@ap", MySqlDbType.VarChar).Value = ComputeSHA256Hash(txtbox_pass.Text)
            userInsertCommand.Parameters.Add("@acp", MySqlDbType.VarChar).Value = cb_pos.Text
            userInsertCommand.Parameters.Add("@ar", MySqlDbType.VarChar).Value = cb_role.Text
            userInsertCommand.Parameters.Add("@as", MySqlDbType.VarChar).Value = "Active"

            Try
                If userInsertCommand.ExecuteNonQuery() = 1 Then
                    MsgBox("Account inserted successfully", vbInformation, "Success")
                Else
                    MsgBox("Error inserting data", vbCritical, "Failure")
                End If
            Catch ex As Exception
                MsgBox("Error inserting data: " & ex.Message, vbCritical, "Failure")
            Finally
                cn.Close()
                actionModal.Visible = False
                FetchAccount()
                ClearText()
            End Try
        Else
            MsgBox("Password do not match.", vbExclamation, "Warning")
        End If
    End Sub

    Private Sub ClearText()
        txtbox_name.Clear()
        txtbox_uname.Clear()
        txtbox_pass.Clear()
        txtbox_cpass.Clear()
        cb_pos.ResetText()
        cb_role.ResetText()
    End Sub

    Private Sub MetroButton9_Click(sender As Object, e As EventArgs) Handles MetroButton9.Click
        Me.Hide()
        Me.Close()
        Dim loginForm As New Login()
        loginForm.ShowDialog()


    End Sub

    Private Function GetSaveFilePath() As String
        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Word Documents (*.docx)|*.docx"
            saveFileDialog.Title = "Save Word Document"
            saveFileDialog.DefaultExt = "docx"
            saveFileDialog.AddExtension = True

            ' Show the dialog and get the selected file path
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Return saveFileDialog.FileName ' Return the selected file path
            End If
        End Using
        Return String.Empty ' Return empty if the user cancels
    End Function

    Function GetDaySuffix(ByVal day As Integer) As String
        If day >= 11 AndAlso day <= 13 Then
            Return "th"
        End If

        Select Case day Mod 10
            Case 1
                Return "st"
            Case 2
                Return "nd"
            Case 3
                Return "rd"
            Case Else
                Return "th"
        End Select
    End Function

    Public Sub CreateWordDocument(name As String, title As String, address As String, date_ As String, brgy As String, muni As String, prov As String)
        Dim wordApp As Word.Application = Nothing
        Dim doc As Word.Document = Nothing

        Dim parts() As String = date_.Split("-"c)
        Dim month As String = parts(0)
        Dim day As String = parts(1)
        Dim year As String = parts(2)

        Dim dayInt As Integer = Convert.ToInt32(day)
        Dim suffix As String = GetDaySuffix(dayInt)

        Try
            ' Initialize Word application
            wordApp = New Word.Application()
            wordApp.Visible = False

            ' Define file paths
            Dim busfilePath As String = Application.StartupPath
            Dim busPath As String = Path.Combine(busfilePath, "Docs/busClearance.docx")
            Dim logoPath As String = My.Settings.LogoName

            ' Validate file paths
            If Not File.Exists(busPath) Then Throw New FileNotFoundException($"Template file not found: {busPath}")
            If Not File.Exists(logoPath) Then Throw New FileNotFoundException($"Logo file not found: {logoPath}")

            ' Open the Word template
            doc = wordApp.Documents.Open(busPath)
            doc.Saved = True ' Prevent auto-saving

            ' Replace text placeholders
            ReplaceTextPlaceholder(doc, "{Name}", name)
            ReplaceTextPlaceholder(doc, "{Title}", title)
            ReplaceTextPlaceholder(doc, "{Address}", address)
            ReplaceTextPlaceholder(doc, "{Day}", day + suffix)
            ReplaceTextPlaceholder(doc, "{Month}", MonthName(month))
            ReplaceTextPlaceholder(doc, "{Year}", year)
            ReplaceTextPlaceholder(doc, "{Barangay}", brgy)
            ReplaceTextPlaceholder(doc, "{Municipality}", muni)
            ReplaceTextPlaceholder(doc, "{Province}", prov)
            ReplaceTextPlaceholder(doc, "{Captain}", captainName)
            'ReplaceTextPlaceholder(doc, "signed", "-Originally Signed-")

            ' Replace image placeholder
            ReplaceImagePlaceholder(doc, "{imagePlaceholder}", logoPath)

            ' Open SaveFileDialog to let user choose save location
            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "Word Documents (*.docx)|*.docx|All Files (*.*)|*.*"
                saveDialog.Title = "Save Document As"
                saveDialog.DefaultExt = "docx"
                saveDialog.AddExtension = True

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    doc.SaveAs2(saveDialog.FileName)
                    MessageBox.Show($"Document saved successfully at {saveDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Save operation was canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using

        Catch ex As FileNotFoundException
            ' Handle file not found exceptions
            MessageBox.Show($"File error: {ex.Message}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            ' Handle any other exceptions
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' Ensure resources are properly cleaned up
            If doc IsNot Nothing Then
                doc.Close(SaveChanges:=False)
                Marshal.ReleaseComObject(doc)
            End If
            If wordApp IsNot Nothing Then
                wordApp.Quit()
                Marshal.ReleaseComObject(wordApp)
            End If
        End Try
    End Sub

    Public Sub CreateClearanceDocument(name As String, age As String, sex As String, status As String, reason As String, purok As String, brgy As String, muni As String, prov As String, date_ As String)
        Dim wordApp As Word.Application = Nothing
        Dim doc As Word.Document = Nothing

        Dim parts() As String = date_.Split("-"c)
        Dim month As String = parts(0)
        Dim day As String = parts(1)
        Dim year As String = parts(2)

        Dim year_ As Integer = Convert.ToInt32(parts(2))

        year_ += 1

        Dim updatedYear As String = year_.ToString()

        Dim dayInt As Integer = Convert.ToInt32(day)
        Dim suffix As String = GetDaySuffix(dayInt)

        Try
            ' Initialize Word application
            wordApp = New Word.Application()
            wordApp.Visible = False

            ' Define file paths
            Dim busfilePath As String = Application.StartupPath
            Dim busPath As String = Path.Combine(busfilePath, "Docs/brgyClearance.docx")
            Dim logoPath As String = My.Settings.LogoName

            ' Validate file paths
            If Not File.Exists(busPath) Then Throw New FileNotFoundException($"Template file not found: {busPath}")
            If Not File.Exists(logoPath) Then Throw New FileNotFoundException($"Logo file not found: {logoPath}")

            ' Open the Word template
            doc = wordApp.Documents.Open(busPath)
            doc.Saved = True ' Prevent auto-saving

            ' Replace text placeholders
            ReplaceTextPlaceholder(doc, "{Name}", name)
            ReplaceTextPlaceholder(doc, "{Age}", age)
            ReplaceTextPlaceholder(doc, "{Sex}", sex)
            ReplaceTextPlaceholder(doc, "{Day}", day + suffix)
            ReplaceTextPlaceholder(doc, "{Month}", MonthName(month))
            ReplaceTextPlaceholder(doc, "{Year}", year)
            ReplaceTextPlaceholder(doc, "{Nationality}", "Filipino")
            ReplaceTextPlaceholder(doc, "{Status}", status)
            ReplaceTextPlaceholder(doc, "{Purok}", purok)
            ReplaceTextPlaceholder(doc, "{Barangay}", brgy)
            ReplaceTextPlaceholder(doc, "{Municipality}", muni)
            ReplaceTextPlaceholder(doc, "{Province}", prov)
            ReplaceTextPlaceholder(doc, "{Reason}", reason)
            ReplaceTextPlaceholder(doc, "{Captain}", captainName)
            ReplaceTextPlaceholder(doc, "{Validity}", "December 31, " & updatedYear)
            'ReplaceTextPlaceholder(doc, "signed", "-Originally Signed-")

            ' Replace image placeholder
            ReplaceImagePlaceholder(doc, "{imagePlaceholder}", logoPath)

            ' Open SaveFileDialog to let user choose save location
            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "Word Documents (*.docx)|*.docx|All Files (*.*)|*.*"
                saveDialog.Title = "Save Document As"
                saveDialog.DefaultExt = "docx"
                saveDialog.AddExtension = True

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    doc.SaveAs2(saveDialog.FileName)
                    MessageBox.Show($"Document saved successfully at {saveDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Save operation was canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using

        Catch ex As FileNotFoundException
            ' Handle file not found exceptions
            MessageBox.Show($"File error: {ex.Message}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            ' Handle any other exceptions
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' Ensure resources are properly cleaned up
            If doc IsNot Nothing Then
                doc.Close(SaveChanges:=False)
                Marshal.ReleaseComObject(doc)
            End If
            If wordApp IsNot Nothing Then
                wordApp.Quit()
                Marshal.ReleaseComObject(wordApp)
            End If
        End Try
    End Sub

    Public Sub CreateCertificateDocument(name As String, purok As String, date_ As String, brgy As String, muni As String, prov As String, reason As String)
        Dim wordApp As Word.Application = Nothing
        Dim doc As Word.Document = Nothing

        Dim parts() As String = date_.Split("-"c)
        Dim month As String = parts(0)
        Dim day As String = parts(1)
        Dim year As String = parts(2)

        Dim dayInt As Integer = Convert.ToInt32(day)
        Dim suffix As String = GetDaySuffix(dayInt)

        Try
            ' Initialize Word application
            wordApp = New Word.Application()
            wordApp.Visible = False

            ' Define file paths
            Dim busfilePath As String = Application.StartupPath
            Dim busPath As String = Path.Combine(busfilePath, "Docs/indigency.docx")
            Dim logoPath As String = My.Settings.LogoName

            ' Validate file paths
            If Not File.Exists(busPath) Then Throw New FileNotFoundException($"Template file not found: {busPath}")
            If Not File.Exists(logoPath) Then Throw New FileNotFoundException($"Logo file not found: {logoPath}")

            ' Open the Word template
            doc = wordApp.Documents.Open(busPath)
            doc.Saved = True ' Prevent auto-saving

            ' Replace text placeholders
            ReplaceTextPlaceholder(doc, "{Name}", name)
            ReplaceTextPlaceholder(doc, "{Purok}", purok)
            ReplaceTextPlaceholder(doc, "{Reason}", reason)
            ReplaceTextPlaceholder(doc, "{Day}", day + suffix)
            ReplaceTextPlaceholder(doc, "{Month}", MonthName(month))
            ReplaceTextPlaceholder(doc, "{Year}", year)
            ReplaceTextPlaceholder(doc, "{Barangay}", brgy)
            ReplaceTextPlaceholder(doc, "{Municipality}", muni)
            ReplaceTextPlaceholder(doc, "{Province}", prov)
            ReplaceTextPlaceholder(doc, "{Captain}", captainName)
            'ReplaceTextPlaceholder(doc, "signed", "-Originally Signed-")

            ' Replace image placeholder
            ReplaceImagePlaceholder(doc, "{imagePlaceholder}", logoPath)

            ' Open SaveFileDialog to let user choose save location
            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "Word Documents (*.docx)|*.docx|All Files (*.*)|*.*"
                saveDialog.Title = "Save Document As"
                saveDialog.DefaultExt = "docx"
                saveDialog.AddExtension = True

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    doc.SaveAs2(saveDialog.FileName)
                    MessageBox.Show($"Document saved successfully at {saveDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Save operation was canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using

        Catch ex As FileNotFoundException
            ' Handle file not found exceptions
            MessageBox.Show($"File error: {ex.Message}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            ' Handle any other exceptions
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' Ensure resources are properly cleaned up
            If doc IsNot Nothing Then
                doc.Close(SaveChanges:=False)
                Marshal.ReleaseComObject(doc)
            End If
            If wordApp IsNot Nothing Then
                wordApp.Quit()
                Marshal.ReleaseComObject(wordApp)
            End If
        End Try
    End Sub


    Private Sub ReplaceTextPlaceholder(doc As Word.Document, placeholder As String, replacement As String)
        ' Loop through the content to find and replace the text placeholder
        Dim range As Word.Range = doc.Content
        range.Find.Text = placeholder
        range.Find.Replacement.Text = replacement
        range.Find.Execute(Replace:=Word.WdReplace.wdReplaceAll)
    End Sub

    Private Sub ReplaceImagePlaceholder(doc As Word.Document, placeholder As String, imagePath As String)
        Dim range As Word.Range = doc.Content
        With range.Find
            .Text = placeholder
            .Execute()
        End With

        ' If the placeholder is found, replace it with the image
        If range.Find.Found Then
            range.Delete() ' Remove the placeholder text
            Dim shape As Word.Shape = doc.Shapes.AddPicture(FileName:=imagePath,
                                                         LinkToFile:=False,
                                                         SaveWithDocument:=True,
                                                         Anchor:=range)

            ' Set the image wrapping style to "Behind Text"
            shape.WrapFormat.Type = Word.WdWrapType.wdWrapBehind

            ' Set custom size (e.g., 1.37 inches width and proportional height)
            Dim widthInInches As Double = 1.37
            Dim widthInPoints As Double = widthInInches * 72
            ' Dim originalAspectRatio As Double = shape.Width / shape.Height

            shape.Width = widthInPoints
            shape.Height = widthInPoints
        End If
    End Sub


    Private Sub dgv_bus_clearance_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_bus_clearance.CellContentClick
        If e.ColumnIndex = dgv_bus_clearance.Columns("bc_action").Index AndAlso e.RowIndex >= 0 Then
            Dim clickedRow As DataGridViewRow = dgv_bus_clearance.Rows(e.RowIndex)
            Dim clearanceQuery = MsgBox("Do you want to print this document?", vbYesNo + vbQuestion, "Print Document")
            If clearanceQuery = vbYes Then
                CreateWordDocument(clickedRow.Cells(1).Value, clickedRow.Cells(2).Value, clickedRow.Cells(3).Value, clickedRow.Cells(5).Value, txtbox_brgyName.Text, txtBox_muni.Text, txtBox_prov.Text)
            End If
        End If
    End Sub

    Private Sub dgv_brgy_clearance_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_clearance.CellContentClick
        If e.ColumnIndex = dgv_clearance.Columns("clearance_action").Index AndAlso e.RowIndex >= 0 Then
            Dim clickedRow As DataGridViewRow = dgv_clearance.Rows(e.RowIndex)
            Dim clearanceQuery = MsgBox("Do you want to print this document?", vbYesNo + vbQuestion, "Print Document")
            If clearanceQuery = vbYes Then
                CreateClearanceDocument(clickedRow.Cells(1).Value, clickedRow.Cells(2).Value, clickedRow.Cells(3).Value, clickedRow.Cells(4).Value, clickedRow.Cells(5).Value, clickedRow.Cells(6).Value, txtbox_brgyName.Text, txtBox_muni.Text, txtBox_prov.Text, clickedRow.Cells(7).Value)
            End If
        End If
    End Sub
    Private Sub dgv_certificate_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_certificate.CellContentClick
        If e.ColumnIndex = dgv_certificate.Columns("cert_action").Index AndAlso e.RowIndex >= 0 Then
            Dim clickedRow As DataGridViewRow = dgv_certificate.Rows(e.RowIndex)
            Dim clearanceQuery = MsgBox("Do you want to print this document?", vbYesNo + vbQuestion, "Print Document")
            If clearanceQuery = vbYes Then
                CreateCertificateDocument(clickedRow.Cells(1).Value, clickedRow.Cells(3).Value, clickedRow.Cells(5).Value, txtbox_brgyName.Text, txtBox_muni.Text, txtBox_prov.Text, clickedRow.Cells(2).Value)
            End If
        End If
    End Sub

    Private Sub OrdinanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdinanceToolStripMenuItem.Click
        ToggleBT()
        Dim filePath As String = Application.StartupPath
        summonPnl.Dock = DockStyle.Fill
        summonPnl.Visible = True
        summonPnl.BringToFront()
        dgv_folder.Visible = True
        MetroButton12.Visible = True
        MetroButton13.Visible = False
        FetchFiles(filePath & "\Ordinance")
    End Sub

    Private Sub ResolutionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResolutionToolStripMenuItem.Click
        ToggleBT()
        Dim filePath As String = Application.StartupPath
        summonPnl.Dock = DockStyle.Fill
        summonPnl.Visible = True
        summonPnl.BringToFront()
        dgv_folder.Visible = True
        MetroButton12.Visible = False
        MetroButton13.Visible = True
        FetchFiles(filePath & "\Resolution")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim key As String = TextBox1.Text
        FetchSpecifiClearance(key)
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim key As String = TextBox4.Text
        FetchSpecifiClearance(key)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim key As String = TextBox2.Text
        FetchSpecificCertificate(key)
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim key As String = TextBox5.Text
        FetchSpecificCertificate(key)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim key As String = TextBox3.Text
        FetchSpecificBusClearance(key)
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Dim key As String = TextBox6.Text
        FetchSpecificBusClearance(key)
    End Sub

    Private Sub MetroButton12_Click(sender As Object, e As EventArgs) Handles MetroButton12.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
        openFileDialog.Title = "Select a PDF File"

        Dim filePath As String = Application.StartupPath

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim destinationPath As String = Path.Combine(filePath & "\Ordinance", Path.GetFileName(openFileDialog.FileName))
            Try
                If Not Directory.Exists(filePath & "\Ordinance") Then
                    Directory.CreateDirectory(filePath & "\Ordinance")
                End If

                ' Copy the file to the destination
                File.Copy(openFileDialog.FileName, destinationPath, True)
                MessageBox.Show("File uploaded successfully to: " & destinationPath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FetchFiles(filePath & "\Ordinance")
            Catch ex As Exception
                MessageBox.Show("Error uploading file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub MetroButton13_Click(sender As Object, e As EventArgs) Handles MetroButton13.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
        openFileDialog.Title = "Select a PDF File"

        Dim filePath As String = Application.StartupPath

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim destinationPath As String = Path.Combine(filePath & "\Resolution", Path.GetFileName(openFileDialog.FileName))
            Try
                If Not Directory.Exists(filePath & "\Resolution") Then
                    Directory.CreateDirectory(filePath & "\Resolution")
                End If

                ' Copy the file to the destination
                File.Copy(openFileDialog.FileName, destinationPath, True)
                MessageBox.Show("File uploaded successfully to: " & destinationPath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FetchFiles(filePath & "\Resolution")
            Catch ex As Exception
                MessageBox.Show("Error uploading file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Add_Complainant_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView7.Rows.Add(TextBox8.Text, RichTextBox1.Text)
        TextBox8.Clear()
        RichTextBox1.Clear()
    End Sub

    Private Sub Add_Respondent_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView8.Rows.Add(TextBox9.Text, RichTextBox2.Text)
        TextBox9.Clear()
        RichTextBox2.Clear()
    End Sub

    Private Sub Add_Summon(sender As Object, e As EventArgs) Handles Button3.Click
        If cn.State <> ConnectionState.Open Then
            cn.Open()
        End If

        Dim query As String = "INSERT INTO bgms_summon_person (`sp_name`, `sp_address`, `sp_type`, `summon_no`) VALUES (@spn, @spa, @spt, @smno)"
        Dim summon_query As String = "INSERT INTO bgms_summon (`summon_id`, `summon_reason`, `summon_hearing_date`, `summon_hearing_time`, `summon_publish_date`) VALUES (@si, @sr, @shd, @sht, @shp)"
        Dim complianantInsertCommand As MySqlCommand = Nothing
        Dim defendantInsertCommand As MySqlCommand = Nothing
        Dim summonInsertCommand As MySqlCommand = Nothing
        Dim lastInsertedId As Integer = 0

        Try
            ' Insert into bgms_blotter table
            summonInsertCommand = New MySqlCommand(summon_query, cn)
            summonInsertCommand.Parameters.AddWithValue("@si", TextBox13.Text())
            summonInsertCommand.Parameters.AddWithValue("@sr", RichTextBox3.Text())
            summonInsertCommand.Parameters.AddWithValue("@shd", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
            summonInsertCommand.Parameters.AddWithValue("@sht", DateTimePicker2.Value.ToString("HH:mm"))
            summonInsertCommand.Parameters.AddWithValue("@shp", Date.ParseExact(TextBox14.Text(), "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"))
            summonInsertCommand.ExecuteNonQuery()

            ' Insert into bgms_blotter_person table for each row in DataGridView
            For Each row As DataGridViewRow In DataGridView7.Rows
                If Not row.IsNewRow Then
                    complianantInsertCommand = New MySqlCommand(query, cn)
                    complianantInsertCommand.Parameters.AddWithValue("@spn", row.Cells(0).Value)
                    complianantInsertCommand.Parameters.AddWithValue("@spa", row.Cells(1).Value)
                    complianantInsertCommand.Parameters.AddWithValue("@spt", "Complainant")
                    complianantInsertCommand.Parameters.AddWithValue("@smno", TextBox13.Text()) ' Use the last inserted ID for the foreign key

                    ' Execute the command
                    complianantInsertCommand.ExecuteNonQuery()

                    ' Dispose of the command to free resources
                    complianantInsertCommand.Dispose()
                End If
            Next

            ' Insert into bgms_blotter_person table for each row in DataGridView
            For Each row As DataGridViewRow In DataGridView8.Rows
                If Not row.IsNewRow Then
                    defendantInsertCommand = New MySqlCommand(query, cn)
                    defendantInsertCommand.Parameters.AddWithValue("@spn", row.Cells(0).Value)
                    defendantInsertCommand.Parameters.AddWithValue("@spa", row.Cells(1).Value)
                    defendantInsertCommand.Parameters.AddWithValue("@spt", "Defendant")
                    defendantInsertCommand.Parameters.AddWithValue("@smno", TextBox13.Text()) ' Use the last inserted ID for the foreign key

                    ' Execute the command
                    defendantInsertCommand.ExecuteNonQuery()

                    ' Dispose of the command to free resources
                    defendantInsertCommand.Dispose()
                End If
            Next

            MsgBox("Data successfully inserted into the database.", vbInformation, "Success")

        Catch ex As Exception
            MsgBox($"Error: {ex.Message}", vbCritical, "Error")

        Finally
            ' Clean up resources
            If summonInsertCommand IsNot Nothing Then
                summonInsertCommand.Dispose()
            End If
            If complianantInsertCommand IsNot Nothing Then
                complianantInsertCommand.Dispose()
            End If
            If defendantInsertCommand IsNot Nothing Then
                defendantInsertCommand.Dispose()
            End If
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            TextBox13.Text = GenerateID()
            TextBox14.Text = DateTime.Now.ToString("MM/dd/yyyy")
            TextBox8.Clear()
            RichTextBox1.Clear()
            DataGridView7.Rows.Clear()
            TextBox9.Clear()
            RichTextBox2.Clear()
            DataGridView8.Rows.Clear()
            RichTextBox3.Clear()
        End Try
    End Sub

    Private Sub BlotterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BlotterToolStripMenuItem1.Click
        ToggleBT()
        blotter_info.Visible = True
        blotter_info.Dock = DockStyle.Fill
        FetchBlotter()
    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged
        FetchSpecificArchive(TextBox16.Text())
    End Sub

    Private Sub SummonToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SummonToolStripMenuItem1.Click
        ToggleBT()
        summon_info.Visible = True
        summon_info.Dock = DockStyle.Fill
        FetchSummon()
    End Sub

    Private Sub FetchBlotter()
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_blotter.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_blotter WHERE status = 'active'"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                dgv_blotter.Rows.Add(dr("blotter_no"), dr("blotter_date"), dr("blotter_time"), dr("blotter_address"))
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchSpecificBlotter(query As String)
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_blotter.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_blotter a JOIN bgms_blotter_person WHERE a.status = 'active' AND blotter_no LIKE '%" & query & "%' OR bp_name LIKE '%" & query & "%'"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                Dim exists As Boolean = False

                For Each row As DataGridViewRow In dgv_blotter.Rows
                    If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = dr("blotter_no").ToString() Then
                        exists = True
                        Exit For
                    End If
                Next

                If Not exists Then
                    dgv_blotter.Rows.Add(dr("blotter_no"), dr("blotter_date"), dr("blotter_time"), dr("blotter_address"))
                End If
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        FetchSpecificBlotter(TextBox11.Text())
    End Sub

    Private Sub FetchSummon()
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_summon.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_summon WHERE status = 'active'"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                dgv_summon.Rows.Add(dr("summon_id"), dr("summon_reason"), Convert.ToDateTime(dr("summon_hearing_date")).ToString("MM-dd-yyyy"), dr("summon_hearing_time"), Convert.ToDateTime(dr("summon_publish_date")).ToString("MM-dd-yyyy"))
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchSpecificSummon(query As String)
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            dgv_summon.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_summon a JOIN bgms_summon_person b ON a.summon_id = b.summon_no WHERE a.status = 'active' AND summon_id LIKE '%" & query & "%' OR sp_type LIKE '%" & query & "%'"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()

                Dim exists As Boolean = False

                For Each row As DataGridViewRow In dgv_summon.Rows
                    If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = dr("summon_id").ToString() Then
                        exists = True
                        Exit For
                    End If
                Next

                If Not exists Then
                    dgv_summon.Rows.Add(dr("summon_id"), dr("summon_reason"), Convert.ToDateTime(dr("summon_hearing_date")).ToString("MM-dd-yyyy"), dr("summon_hearing_time"), Convert.ToDateTime(dr("summon_publish_date")).ToString("MM-dd-yyyy"))
                End If
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub txtbox_summon_search_TextChanged(sender As Object, e As EventArgs) Handles txtbox_summon_search.TextChanged
        FetchSpecificSummon(txtbox_summon_search.Text())
    End Sub

    Private Sub FetchBlotterInfo(id As String)
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            lbl_blotter_id.Text = id

            RichTextBox4.Clear()
            DataGridView1.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_blotter_person a JOIN bgms_blotter b ON a.bp_no = b.blotter_no WHERE bp_no = '" & id & "'"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                RichTextBox4.Text = dr("blotter_statement")
                DataGridView1.Rows.Add(dr("bp_name"), dr("bp_cn"), dr("bp_age"), dr("bp_classification"), dr("bp_address"))
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub FetchSummonInfo(id As String)
        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            lbl_summon_id.Text = id

            DataGridView2.Rows.Clear()

            Dim sqlQuery As String = "SELECT * FROM bgms_summon_person a JOIN bgms_summon b ON a.summon_no = b.summon_id WHERE summon_no = '" & id & "'"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                DataGridView2.Rows.Add(dr("sp_name"), dr("sp_address"), dr("sp_type"))
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub dgv_blotter_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_blotter.CellContentClick
        If e.ColumnIndex = dgv_blotter.Columns("blotterAction").Index AndAlso e.RowIndex >= 0 Then
            Dim clickedRow As DataGridViewRow = dgv_blotter.Rows(e.RowIndex)
            Dim firstCellValue As Object = clickedRow.Cells(0).Value
            FetchBlotterInfo(firstCellValue)
            blotter_info.Controls.Add(blotter_popup)
            blotter_popup.Width = 550
            blotter_popup.Height = 430
            blotter_popup.Location = New Point(
               blotter_info.Width / 2 - blotter_popup.Size.Width / 2,
               blotter_info.Height / 2 - blotter_popup.Size.Height / 2
            )
            blotter_popup.Anchor = AnchorStyles.None
            blotter_popup.Visible = True
            blotter_popup.BringToFront()
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        blotter_popup.Visible = False
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        summon_popup.Visible = False
    End Sub

    Private Sub dgv_summon_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_summon.CellContentClick
        If e.ColumnIndex = dgv_summon.Columns("summonAction").Index AndAlso e.RowIndex >= 0 Then
            Dim clickedRow As DataGridViewRow = dgv_summon.Rows(e.RowIndex)
            Dim firstCellValue As Object = clickedRow.Cells(0).Value
            FetchSummonInfo(firstCellValue)
            summon_info.Controls.Add(summon_popup)
            summon_popup.Width = 550
            summon_popup.Height = 430
            summon_popup.Location = New Point(
               summon_info.Width / 2 - summon_popup.Size.Width / 2,
               summon_info.Height / 2 - summon_popup.Size.Height / 2
            )
            summon_popup.Anchor = AnchorStyles.None
            summon_popup.Visible = True
            summon_popup.BringToFront()
        End If
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Dim query As DialogResult = MsgBox("Are you sure you want to delete this record?", vbQuestion + vbYesNo, "Confirmation")
        If query = DialogResult.Yes Then
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                Dim deactivateString As String = "UPDATE bgms_summon SET status = 'inactive' WHERE summon_id = @id"
                Dim cmd As New MySqlCommand(deactivateString, cn)
                cmd.Parameters.AddWithValue("@id", lbl_summon_id.Text())
                cmd.ExecuteNonQuery()
                MsgBox("Record deleted successfully.", vbInformation, "Success")
                summon_popup.Visible = False
                FetchSummon()
            Catch ex As Exception
                MsgBox("Failed to  delete record: " & ex.Message, vbCritical, "Failure")
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Dim query As DialogResult = MsgBox("Are you sure you want to delete this record?", vbQuestion + vbYesNo, "Confirmation")
        If query = DialogResult.Yes Then
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                Dim deactivateString As String = "UPDATE bgms_blotter SET status = 'inactive' WHERE blotter_no = @id"
                Dim cmd As New MySqlCommand(deactivateString, cn)
                cmd.Parameters.AddWithValue("@id", lbl_blotter_id.Text())
                cmd.ExecuteNonQuery()
                MsgBox("Record deleted successfully.", vbInformation, "Success")
                blotter_popup.Visible = False
                FetchBlotter()
            Catch ex As Exception
                MsgBox("Failed to  delete record: " & ex.Message, vbCritical, "Failure")
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub FetchFiles(folderPath As String)
        If Not Directory.Exists(folderPath) Then
            MessageBox.Show("Folder does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        dgv_folder.Rows.Clear()

        Dim files As String() = Directory.GetFiles(folderPath)

        For Each filePath As String In files
            Dim fileInfo As New FileInfo(filePath)
            dgv_folder.Rows.Add(fileInfo.Name, fileInfo.DirectoryName, fileInfo.LastWriteTime)
        Next
    End Sub

    Private selectedFile As String

    Private Sub dgv_folder_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_folder.CellContentClick
        If e.ColumnIndex = dgv_folder.Columns("fileAction").Index AndAlso e.RowIndex >= 0 Then
            Dim clickedRow As DataGridViewRow = dgv_folder.Rows(e.RowIndex)
            Dim firstCellValue As Object = clickedRow.Cells(0).Value
            Dim filePath As String = Application.StartupPath
            Dim pdfDoc1 As String = filePath & "\Ordinance\" & firstCellValue.ToString()
            Dim pdfDoc2 As String = filePath & "\Resolution\" & firstCellValue.ToString()
            If File.Exists(pdfDoc1) Then
                Me.PdfDocumentViewer1.LoadFromFile(pdfDoc1)
                selectedFile = pdfDoc1
            ElseIf File.Exists(pdfDoc2) Then
                Me.PdfDocumentViewer1.LoadFromFile(pdfDoc2)
                selectedFile = pdfDoc2
            End If
            summonPnl.Controls.Add(file_popup)
            file_popup.Width = 1000
            file_popup.Height = 500
            file_popup.Location = New Point(
               summonPnl.Width / 2 - file_popup.Size.Width / 2,
               summonPnl.Height / 2 - file_popup.Size.Height / 2
            )
            file_popup.Anchor = AnchorStyles.None
            file_popup.Visible = True
            file_popup.BringToFront()
        End If
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        file_popup.Visible = False
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Dim query As DialogResult = MsgBox("Are you sure you want to delete this file?", vbYesNo + vbQuestion, "File Deletion")
        If query = vbYes Then
            Try
                file_popup.Visible = False
                ' Check if the file exists
                Dim filePath As String = Application.StartupPath
                If File.Exists(selectedFile) Then
                    ' Delete the file
                    File.Delete(selectedFile)
                    MessageBox.Show("File deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If selectedFile.Contains("\Ordinance") Then
                        FetchFiles(filePath & "\Ordinance")
                    Else
                        FetchFiles(filePath & "\Resolution")
                    End If
                Else
                    MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                ' Handle any errors during deletion
                MessageBox.Show("An error occurred while deleting the file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class