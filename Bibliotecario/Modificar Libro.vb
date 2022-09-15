Imports System.Data.OleDb
Imports System.Text
Imports System.IO

Public Class frmModificarLibro
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        Dim Conexion As New OleDb.OleDbConnection
        Dim comando As New OleDb.OleDbCommand
        Dim DR As OleDbDataReader

        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        comando.Connection = Conexion
        comando.CommandType = CommandType.TableDirect
        comando.CommandText = "Libro"

        DR = comando.ExecuteReader
        If DR.HasRows Then
            While DR.Read
                If DR("IDLibro") = txtIdLibro.Text Then
                    Button2.Enabled = True
                    txtTitulo.Text = DR("Titulo")
                    txtIdAutor.Text = DR("IdAutor")
                    txtAño.Text = DR("Año")
                    txtIdPais.Text = DR("IdPais")
                    txtIdIdioma.Text = DR("IdIdioma")
                    txtCantidad.Text = DR("Cantidad")
                    txtPrecio.Text = DR("Precio")
                    Exit While


                End If

            End While
        End If
        If Button2.Enabled = False Then
            MessageBox.Show("Ese Codigo no se encuentra en la base de datos")
        End If
        Conexion.Close()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SQL As String = ""

        SQL = "update Libro set Titulo = '" & txtTitulo.Text & "' where IdLibro = " & txtIdLibro.Text
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.Text
        Comando.CommandText = SQL
        Comando.ExecuteReader()
        Conexion.Close()



        SQL = "update Libro set IdAutor = '" & txtIdAutor.Text & "' where IdLibro = " & txtIdLibro.Text
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.Text
        Comando.CommandText = SQL
        Comando.ExecuteReader()
        Conexion.Close()

        SQL = "update Libro set Año = '" & txtAño.Text & "' where IdLibro = " & txtIdLibro.Text
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.Text
        Comando.CommandText = SQL
        Comando.ExecuteReader()
        Conexion.Close()

        SQL = "update Libro set IdPais = '" & txtIdPais.Text & "' where IdLibro = " & txtIdLibro.Text
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.Text
        Comando.CommandText = SQL
        Comando.ExecuteReader()
        Conexion.Close()

        SQL = "update Libro set IdIdioma = '" & txtIdIdioma.Text & "' where IdLibro = " & txtIdLibro.Text
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.Text
        Comando.CommandText = SQL
        Comando.ExecuteReader()
        Conexion.Close()

        SQL = "update Libro set Cantidad = '" & txtCantidad.Text & "' where IdLibro = " & txtIdLibro.Text
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.Text
        Comando.CommandText = SQL
        Comando.ExecuteReader()
        Conexion.Close()

        SQL = "update Libro set Precio = '" & txtPrecio.Text & "' where IdLibro = " & txtIdLibro.Text
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.Text
        Comando.CommandText = SQL
        Comando.ExecuteReader()
        Conexion.Close()



        MessageBox.Show("Datos Modificados")
        txtIdLibro.Text = ""
        txtTitulo.Text = ""
        txtIdAutor.Text = ""
        txtAño.Text = ""
        txtIdPais.Text = ""
        txtIdIdioma.Text = ""
        txtCantidad.Text = ""
        txtPrecio.Text = ""

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtIdPais.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub txtIdLibro_TextChanged(sender As Object, e As EventArgs) Handles txtIdLibro.TextChanged
        Button1.Enabled = txtIdLibro.Text <> ""

    End Sub

    Private Sub frmModificarLibro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Button2.Enabled = False

    End Sub

    Private Sub txtIdAutor_TextChanged(sender As Object, e As EventArgs) Handles txtIdAutor.TextChanged

    End Sub
End Class