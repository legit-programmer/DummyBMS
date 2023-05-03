Imports MySql.Data.MySqlClient
Imports System.Reflection.Emit

Public Class Form2
    Dim mainUser As String
    Public Sub New(ByVal user As String)
        InitializeComponent()
        mainUser = user

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connStr As String = "server=localhost;user=root;database=mysql;port=3306;password=1234;"
        Using conn As New MySqlConnection(connStr)


            Using cmd As MySqlCommand = New MySqlCommand("select * from users where uname='" + mainUser + "'")

                cmd.CommandType = CommandType.Text
                cmd.Connection = conn
                conn.Open()


                Using sdr As MySqlDataReader = cmd.ExecuteReader()
                    sdr.Read()
                    Label5.Text = sdr("acc").ToString
                    Label4.Text = sdr("name").ToString
                    Label7.Text = sdr("amt").ToString




                End Using
                conn.Close()

            End Using
        End Using


    End Sub


End Class