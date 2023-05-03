Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Form1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connStr As String = "server=localhost;user=root;database=mysql;port=3306;password=1234;"
        Using conn As New MySqlConnection(connStr)


            Using cmd As MySqlCommand = New MySqlCommand("select pass from users where uname='" + TextBox1.Text + "'")

                cmd.CommandType = CommandType.Text
                cmd.Connection = conn

                conn.Open()
                Dim usr As String = TextBox1.Text
                Dim frm2 = New Form2(usr)


                Using sdr As MySqlDataReader = cmd.ExecuteReader()
                    If sdr.Read() Then
                        Dim psk As String = sdr("pass").ToString()
                        If TextBox2.Text = psk Then

                            frm2.Show()

                        Else
                            MsgBox("fail")
                        End If
                    End If




                End Using
                conn.Close()

            End Using
        End Using

    End Sub


End Class
