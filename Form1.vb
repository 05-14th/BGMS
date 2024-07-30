Public Class Form1
    Private Sub CenterPanel()
        ConfigPnl.Location = New Point(
            LobbyPnl.Width / 2 - ConfigPnl.Size.Width / 2,
            LobbyPnl.Height / 2 - ConfigPnl.Size.Height / 2
        )
        ConfigPnl.Anchor = AnchorStyles.None
    End Sub

    Private Sub ToggleBtnPnl()
        If btnPnl.Visible Then
            btnPnl.Visible = False
        Else
            btnPnl.Visible = True
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles DocumentsBtn.Click
        ToggleBtnPnl()
        ConfigPnl.Visible = False
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click

    End Sub

    Private Sub MetroPanel1_Paint(sender As Object, e As PaintEventArgs) Handles LobbyPnl.Paint

    End Sub

    Private Sub MetroPanel2_Paint(sender As Object, e As PaintEventArgs) Handles ConfigPnl.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub saveConfBtn_Click(sender As Object, e As EventArgs) Handles saveConfBtn.Click

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click

    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click

    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click

    End Sub

    Private Sub configBtn_Click(sender As Object, e As EventArgs) Handles configBtn.Click
        CenterPanel()
        btnPnl.Visible = False
        If ConfigPnl.Visible Then
            ConfigPnl.Visible = False
        Else
            ConfigPnl.Visible = True
        End If
    End Sub

    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs) Handles MetroTextBox1.Click

    End Sub

    Private Sub MetroTextBox3_Click(sender As Object, e As EventArgs) Handles MetroTextBox3.Click

    End Sub
End Class
