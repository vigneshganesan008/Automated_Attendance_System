﻿Imports MySql.Data.MySqlClient
Public Class TeacherAttendance
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim conn As MySqlConnection
        conn = New MySqlConnection()
        conn.ConnectionString = "server=127.0.0.1;userid=root;password=;database=vb;Convert Zero Datetime=True"
        Try

            conn.Open()
        Catch myerror As MySqlException
            MessageBox.Show("Error Connecting to Database: " & myerror.Message)

        End Try

        Dim myAdapter As New MySqlDataAdapter
        Dim myCommand As New MySqlCommand()
        myCommand.Connection = conn
        myCommand.CommandText = "SELECT * FROM atten WHERE date='" & DateTimePicker1.Text & "' "

        myAdapter.SelectCommand = myCommand

        Dim dt As New DataTable()
        dt.Load(myCommand.ExecuteReader())
        DataGridView1.DataSource = dt

        conn.Close()
    End Sub

    Private Sub TeacherAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.MaxDate = Date.Now
    End Sub
End Class