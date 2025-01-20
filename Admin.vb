Imports System.IO
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Microsoft.Office.Interop


Public Class Admin
    Dim documentType As String
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

    Private Sub ToggleBT(state1 As Boolean, state2 As Boolean, state3 As Boolean, Optional state4 As Boolean = False, Optional state5 As Boolean = False, Optional state6 As Boolean = False, Optional state7 As Boolean = False, Optional state8 As Boolean = False)
        bt_clearance_pnl.Visible = state1
        bt_certificate_pnl.Visible = state2
        bt_bus_clearance.Visible = state3
        blotter_pnl.Visible = state4
        summonPnl.Visible = state5
        pnl_financial.Visible = state6
        pnl_archive.Visible = state7
        um_pnl.Visible = state8
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
        documentType = "clearance"
        FetchClearance()
        bt_clearance_pnl.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(True, False, False)
        showSettings()
    End Sub

    Private Sub CertificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CertificationToolStripMenuItem.Click
        documentType = "certificate"
        FetchCertificate()
        bt_certificate_pnl.Dock = DockStyle.Fill
        ToggleReports(False, False, False)
        ToggleBT(False, True, False)
        showSettings()
    End Sub

    Private Sub BusinessClearanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusinessClearanceToolStripMenuItem.Click
        documentType = "business_clearance"
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
        FetchConfig()
        FetchAccount()
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
        summonPnl.Dock = DockStyle.Fill
        summonPnl.Visible = True
        summonPnl.BringToFront()
        Dim pdfDoc As String = My.Settings.OrdinanceFile
        If File.Exists(pdfDoc) Then
            Me.PdfDocumentViewer1.LoadFromFile(pdfDoc)
        End If
    End Sub

    Private Sub ResolutionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResolutionToolStripMenuItem.Click
        summonPnl.Dock = DockStyle.Fill
        summonPnl.Visible = True
        summonPnl.BringToFront()
        Dim pdfDoc As String = My.Settings.ResolutionFile
        If File.Exists(pdfDoc) Then
            Me.PdfDocumentViewer1.LoadFromFile(pdfDoc)
        End If
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
End Class