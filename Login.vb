Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Login
    Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd")
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

    Private Sub LoadDocuments()
        Try
            DataGridView1.Rows.Clear()
            cn.Open()

            Dim sqlQuery As String = "
        SELECT 
            clearance_name AS name, 
            'Barangay Clearance' AS document_type,
            clearance_track_id AS tracking_code,
            request_date,
            date_issued,
            status
        FROM 
            bgms_clearance 

        UNION ALL 

        SELECT 
            cert_name AS name, 
            'Barangay Certificate' AS document_type,
            cert_track_id AS tracking_code,
            request_date, 
            date_issued,
            status 
        FROM 
            bgms_certificate 

        UNION ALL 

        SELECT 
            bc_owner_name AS name,
            'Business Clearance' AS document_type,
            bc_track_id AS tracking_code,
            request_date, 
            date_issued,
            status
        FROM 
            bgms_bus_clearance;"

            Dim cm As New MySqlCommand(sqlQuery, cn)
            Dim dr As MySqlDataReader = cm.ExecuteReader()

            While dr.Read()
                Try
                    DataGridView1.Rows.Add(dr("name"), dr("document_type"), dr("tracking_code"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), Convert.ToDateTime(dr("date_issued")).ToString("MM-dd-yyyy"), dr("status"))
                Catch ex As System.InvalidCastException
                    DataGridView1.Rows.Add(dr("name"), dr("document_type"), dr("tracking_code"), Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"), "N/A", dr("status"))
                End Try
            End While

            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Failed to fetch data: " & ex.Message, vbCritical, "Failure")
            cn.Close()
        End Try
    End Sub

    Private Sub ClearTextBox()
        txtbox_busName.Clear()
        txtbox_ownerName.Clear()
        txtbox_busAd.Clear()
        txtbox_clearanceName.Clear()
        txtbox_clearanceAge.Clear()
        cb_clearanceSex.SelectedIndex = -1
        cb_clearanceCS.SelectedIndex = -1
        cb_clearancePurok.SelectedIndex = -1
        txtbox_clearancePurp.Clear()
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
        LoadDocuments()
        ToggleUI(False, False, True, False, False, False, False)
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles Cert_btn.Click
        txtbox_certTI.Text = GenerateID()
        ClearTextBox()
        ToggleUI(True, False, False, False, True, False, False)
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles brgyClearance_btn.Click
        txtbox_trackID.Text = GenerateID()
        ClearTextBox()
        ToggleUI(True, False, False, False, False, False, True)
    End Sub

    Private Sub configBtn_Click(sender As Object, e As EventArgs) Handles configBtn.Click
        ToggleUI(False, True, False, False, False, False, False)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConfig()
        ConnectToDB()
        login_pword_txtbox.UseSystemPasswordChar = True
    End Sub

    Private Sub Clearance_btn_Click(sender As Object, e As EventArgs) Handles Clearance_btn.Click
        txtbox_clearance.Text = GenerateID()
        ClearTextBox()
        ToggleUI(True, False, False, False, False, True, False)
    End Sub

    Private Sub MetroButton1_Click_1(sender As Object, e As EventArgs) Handles login_btn.Click
        Dim command As New MySqlCommand("SELECT COUNT(*) FROM bgms_account WHERE acc_username = @username AND acc_password = @password AND acc_status = 'Active'", cn)
        command.Parameters.AddWithValue("@username", login_uname_txtbox.Text())
        command.Parameters.AddWithValue("@password", ComputeSHA256Hash(login_pword_txtbox.Text()))
        Try
            cn.Open()
            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

            If count > 0 Then
                Me.Hide()
                Dim adminForm As New Admin()
                adminForm.ShowDialog(Me)
                Me.Close()
            Else
                MsgBox("Invalid username or password.", vbInformation, "Incorrect")
            End If
            cn.Close()
        Catch ex As MySqlException
            MsgBox("Database error: " & ex.Message, vbCritical, "Failure")
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Failure")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub pass_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles pass_checkbox.CheckedChanged
        login_pword_txtbox.UseSystemPasswordChar = Not pass_checkbox.Checked
    End Sub

    Private Sub btn_submitBus_Click(sender As Object, e As EventArgs) Handles btn_submitBus.Click
        cn.Open()

        Dim bcInsertCommand As New MySqlCommand("INSERT INTO bgms_bus_clearance (`bc_track_id`, `bc_bus_name`, `bc_owner_name`, `bc_bus_addr`, `request_date`, `status`) VALUES (@bti, @bbn, @bon, @bba,@rd, @stat)", cn)
        bcInsertCommand.Parameters.Add("@bti", MySqlDbType.VarChar).Value = txtbox_trackID.Text
        bcInsertCommand.Parameters.Add("@bbn", MySqlDbType.VarChar).Value = txtbox_busName.Text
        bcInsertCommand.Parameters.Add("@bon", MySqlDbType.VarChar).Value = txtbox_ownerName.Text
        bcInsertCommand.Parameters.Add("@bba", MySqlDbType.VarChar).Value = txtbox_busAd.Text
        bcInsertCommand.Parameters.Add("@rd", MySqlDbType.VarChar).Value = currentDate
        bcInsertCommand.Parameters.Add("@stat", MySqlDbType.VarChar).Value = "Pending"

        Try
            If bcInsertCommand.ExecuteNonQuery() = 1 Then
                MsgBox("Data inserted successfully", vbInformation, "Success")
            Else
                MsgBox("Error inserting data", vbCritical, "Failure")
            End If
        Catch ex As Exception
            MsgBox("Error inserting data: " & ex.Message, vbCritical, "Failure")
        Finally
            cn.Close()
            ClearTextBox()
            GenerateID()
        End Try
    End Sub

    Private Sub MetroButton8_Click(sender As Object, e As EventArgs) Handles MetroButton8.Click
        cn.Open()

        Dim clearanceInsertCommand As New MySqlCommand("INSERT INTO bgms_clearance (`clearance_track_id`, `clearance_name`, `clearance_age` ,`clearance_sex`, `clearance_cs`, `clearance_purok`, `clearance_purpose`, `request_date`, `status`) VALUES (@cti, @cn, @ca, @cs, @css ,@cp, @cpp, @rq, @stat)", cn)
        clearanceInsertCommand.Parameters.Add("@cti", MySqlDbType.VarChar).Value = txtbox_clearance.Text
        clearanceInsertCommand.Parameters.Add("@cn", MySqlDbType.VarChar).Value = txtbox_clearanceName.Text
        clearanceInsertCommand.Parameters.Add("@ca", MySqlDbType.VarChar).Value = txtbox_clearanceAge.Text
        clearanceInsertCommand.Parameters.Add("@cs", MySqlDbType.VarChar).Value = cb_clearanceSex.Text
        clearanceInsertCommand.Parameters.Add("@css", MySqlDbType.VarChar).Value = cb_clearanceCS.Text
        clearanceInsertCommand.Parameters.Add("@cp", MySqlDbType.VarChar).Value = cb_clearancePurok.Text
        clearanceInsertCommand.Parameters.Add("@cpp", MySqlDbType.VarChar).Value = txtbox_clearancePurp.Text
        clearanceInsertCommand.Parameters.Add("@rq", MySqlDbType.VarChar).Value = currentDate
        clearanceInsertCommand.Parameters.Add("@stat", MySqlDbType.VarChar).Value = "Pending"

        Try
            If clearanceInsertCommand.ExecuteNonQuery() = 1 Then
                MsgBox("Data inserted successfully", vbInformation, "Success")
            Else
                MsgBox("Error inserting data", vbCritical, "Failure")
            End If
        Catch ex As Exception
            MsgBox("Error inserting data: " & ex.Message, vbCritical, "Failure")
        Finally
            cn.Close()
            ClearTextBox()
            GenerateID()
        End Try
    End Sub

    Private Sub MetroButton2_Click_1(sender As Object, e As EventArgs) Handles MetroButton2.Click
        cn.Open()

        Dim clearanceInsertCommand As New MySqlCommand("INSERT INTO bgms_certificate (`cert_track_id`, `cert_name`, `cert_purok`, `cert_purpose`, `request_date`, `status`) VALUES (@cti, @cn ,@cp, @cpp, @rq, @stat)", cn)
        clearanceInsertCommand.Parameters.Add("@cti", MySqlDbType.VarChar).Value = txtbox_certTI.Text
        clearanceInsertCommand.Parameters.Add("@cn", MySqlDbType.VarChar).Value = txtbox_certName.Text
        clearanceInsertCommand.Parameters.Add("@cp", MySqlDbType.VarChar).Value = txtbox_certPurok.Text
        clearanceInsertCommand.Parameters.Add("@cpp", MySqlDbType.VarChar).Value = txtbox_certPurpose.Text
        clearanceInsertCommand.Parameters.Add("@rq", MySqlDbType.VarChar).Value = currentDate
        clearanceInsertCommand.Parameters.Add("@stat", MySqlDbType.VarChar).Value = "Pending"

        Try
            If clearanceInsertCommand.ExecuteNonQuery() = 1 Then
                MsgBox("Data inserted successfully", vbInformation, "Success")
            Else
                MsgBox("Error inserting data", vbCritical, "Failure")
            End If
        Catch ex As Exception
            MsgBox("Error inserting data: " & ex.Message, vbCritical, "Failure")
        Finally
            cn.Close()
            ClearTextBox()
            GenerateID()
        End Try
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Clipboard.SetText(txtbox_certTI.Text)
        MsgBox("Track ID copied to clipboard", vbInformation, "Notice")
    End Sub

    Private Sub MetroButton5_Click_1(sender As Object, e As EventArgs) Handles MetroButton5.Click
        Clipboard.SetText(txtbox_trackID.Text)
        MsgBox("Track ID copied to clipboard", vbInformation, "Notice")
    End Sub

    Private Sub MetroButton4_Click_1(sender As Object, e As EventArgs) Handles MetroButton4.Click
        Clipboard.SetText(txtbox_clearance.Text)
        MsgBox("Track ID copied to clipboard", vbInformation, "Notice")
    End Sub

    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs) Handles MetroTextBox1.TextChanged
        cn.Open()
        Dim searchTerm As String = MetroTextBox1.Text
        Dim query As String = "
            SELECT clearance_name AS name, 'Barangay Clearance' AS document_type, clearance_track_id AS tracking_code, request_date, date_issued, status
            FROM bgms_clearance
            WHERE clearance_track_id LIKE @searchTerm OR clearance_name LIKE @searchTerm

            UNION ALL 

            SELECT cert_name AS name, 'Barangay Certificate' AS document_type, cert_track_id AS tracking_code, request_date, date_issued, status
            FROM bgms_certificate
            WHERE cert_track_id LIKE @searchTerm OR cert_name LIKE @searchTerm

            UNION ALL 

            SELECT bc_owner_name AS name, 'Business Clearance' AS document_type, bc_track_id AS tracking_code, request_date, date_issued, status
            FROM bgms_bus_clearance
            WHERE bc_track_id LIKE @searchTerm OR bc_owner_name LIKE @searchTerm
        "

        Dim command As New MySqlCommand(query, cn)
        command.Parameters.AddWithValue("@searchTerm", "%" & searchTerm & "%")
        Dim dr As MySqlDataReader = command.ExecuteReader()

        DataGridView1.Rows.Clear()

        While dr.Read()
            Dim requestDate As String = If(dr("request_date") Is DBNull.Value, "N/A", Convert.ToDateTime(dr("request_date")).ToString("MM-dd-yyyy"))
            Dim dateIssued As String = If(dr("date_issued") Is DBNull.Value, "N/A", Convert.ToDateTime(dr("date_issued")).ToString("MM-dd-yyyy"))

            DataGridView1.Rows.Add(dr("name"), dr("document_type"), dr("tracking_code"), requestDate, dateIssued, dr("status"))
        End While


        dr.Close()
        command.Dispose()
        cn.Close()
    End Sub

End Class
