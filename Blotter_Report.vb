Imports System.Management
Imports MySql.Data.MySqlClient
Imports Mysqlx

Public Class Blotter_Report

    Private id As String = GenerateID()
    Private Sub UserView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtbox_no.Text = id
    End Sub

    Private Sub MetroPanel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles btn_publish.Click
        If cn.State <> ConnectionState.Open Then
            cn.Open()
        End If

        Dim query As String = "INSERT INTO bgms_blotter_person (`bp_name`, `bp_cn`, `bp_age`, `bp_classification`, `bp_address`, `bp_no`) VALUES (@bn, @bc, @ba, @bcl, @bad, @bno)"
        Dim blotter_query As String = "INSERT INTO bgms_blotter (`blotter_no`, `blotter_date`, `blotter_time`, `blotter_statement`, `blotter_address`) VALUES (@bn, @bd, @bt, @bs, @ba)"
        Dim userInsertCommand As MySqlCommand = Nothing
        Dim blotterInsertCommand As MySqlCommand = Nothing
        Dim lastInsertedId As Integer = 0

        Try
            ' Insert into bgms_blotter table
            blotterInsertCommand = New MySqlCommand(blotter_query, cn)
            blotterInsertCommand.Parameters.AddWithValue("@bn", id)
            blotterInsertCommand.Parameters.AddWithValue("@bd", blotter_date.Value.ToString("yyyy-MM-dd"))
            blotterInsertCommand.Parameters.AddWithValue("@bt", dt_time.Value.ToString("HH:mm"))
            blotterInsertCommand.Parameters.AddWithValue("@bs", blotter_complaint.Text)
            blotterInsertCommand.Parameters.AddWithValue("@ba", blotter_address.Text)
            blotterInsertCommand.ExecuteNonQuery()

            ' Insert into bgms_blotter_person table for each row in DataGridView
            For Each row As DataGridViewRow In dgv_person.Rows
                If Not row.IsNewRow Then
                    userInsertCommand = New MySqlCommand(query, cn)
                    userInsertCommand.Parameters.AddWithValue("@bn", row.Cells(0).Value)
                    userInsertCommand.Parameters.AddWithValue("@bc", row.Cells(3).Value)
                    userInsertCommand.Parameters.AddWithValue("@ba", row.Cells(2).Value)
                    userInsertCommand.Parameters.AddWithValue("@bcl", row.Cells(4).Value)
                    userInsertCommand.Parameters.AddWithValue("@bad", row.Cells(1).Value)
                    userInsertCommand.Parameters.AddWithValue("@bno", id) ' Use the last inserted ID for the foreign key

                    ' Execute the command
                    userInsertCommand.ExecuteNonQuery()

                    ' Dispose of the command to free resources
                    userInsertCommand.Dispose()
                End If
            Next

            MsgBox("Data successfully inserted into the database.", vbInformation, "Success")

        Catch ex As Exception
            MsgBox($"Error: {ex.Message}", vbCritical, "Error")

        Finally
            ' Clean up resources
            If blotterInsertCommand IsNot Nothing Then
                blotterInsertCommand.Dispose()
            End If
            If userInsertCommand IsNot Nothing Then
                userInsertCommand.Dispose()
            End If
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
            Me.Dispose(True)
        End Try
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        dgv_person.Rows.Add(txtbox_name.Text, txtbox_address.Text, txtbox_age.Text, txtbox_contact.Text, cb_classification.SelectedItem.ToString)
        txtbox_name.Clear()
        txtbox_address.Clear()
        txtbox_age.Clear()
        txtbox_contact.Clear()
        cb_classification.SelectedIndex = -1
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Dispose(True)
    End Sub
End Class
