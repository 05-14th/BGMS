Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Module Module1
    Public cn As New MySqlConnection
    Public Sub LoadImageToPictureBox(pictureBox As PictureBox, imagePath As String)
        Try
            pictureBox.Image = Image.FromFile(imagePath)
        Catch ex As Exception
            MsgBox("Error loading image: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Public Sub ConnectToDB()
        Try
            With cn
                .ConnectionString = $"Server='{My.Settings.server}'; Uid='{My.Settings.username}'; Pwd='{My.Settings.password}';Database='{My.Settings.db_name}';Port='{My.Settings.port}'"
                .Open()
            End With
            cn.Close()
        Catch ex As Exception
            'MsgBox($"{ex.Message}", vbOKOnly, "Connection Error")
        Finally
            cn.Close()
        End Try
    End Sub

    Public Function ComputeSHA256Hash(input As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
            Dim builder As New StringBuilder()
            For Each b As Byte In hashBytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function
End Module
