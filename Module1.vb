Module Module1
    Public Sub LoadImageToPictureBox(pictureBox As PictureBox, imagePath As String)
        Try
            pictureBox.Image = Image.FromFile(imagePath)
        Catch ex As Exception
            MsgBox("Error loading image: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub
End Module
