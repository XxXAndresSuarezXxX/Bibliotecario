Imports System.Data.OleDb
Imports System.Text
Imports System.IO

Public Class frmModificarIdioma
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        btnBuscar.Enabled = txtIdioma.Text <> ""
        btnGuardar.Enabled = True
        Dim ConexionIdioma As New OleDb.OleDbConnection
        Dim comandoIdioma As New OleDb.OleDbCommand
        Dim DRIdioma As OleDbDataReader

        ConexionIdioma.ConnectionString = CadenaDeConexion
        ConexionIdioma.Open()
        comandoIdioma.Connection = ConexionIdioma
        comandoIdioma.CommandType = CommandType.TableDirect
        comandoIdioma.CommandText = "Idioma"

        DRIdioma = comandoIdioma.ExecuteReader
        If DRIdioma.HasRows Then
            While DRIdioma.Read
                If DRIdioma("IDIdioma") = txtIdioma.Text Then
                    txtNombreIdioma.Text = DRIdioma("Nombre")
                    Exit While
                End If

            End While
        End If
        ConexionIdioma.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim SQL As String = ""
        SQL = "update idioma set nombre = '" & txtNombreIdioma.Text & "' where IdIdioma = " & txtIdioma.Text
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.Text
        Comando.CommandText = SQL
        Comando.ExecuteReader()
        Conexion.Close()
        txtIdioma.Text = ""
        txtNombreIdioma.Text = ""
        MessageBox.Show("Datos guardados")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub frmModificarIdioma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
        btnGuardar.Enabled = False

    End Sub

    Private Sub txtIdioma_TextChanged(sender As Object, e As EventArgs) Handles txtIdioma.TextChanged
        btnBuscar.Enabled = txtIdioma.Text <> ""
        btnGuardar.Enabled = True


    End Sub
End Class