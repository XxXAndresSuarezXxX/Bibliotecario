Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Public Class frmLibros
    Private Sub Libros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        MostrarDGV("Libro", dgvGrilla)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim AD As New StreamWriter("Listado de Libros.csv", False, Encoding.Default)
        Dim Cantidad As Integer = 0
        Dim Diferentes As Integer = 0
        AD.WriteLine("IdLibro;Titulo;IdAutor;Año;IdPais;IdIdioma;Cantidad;Precio")
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Libro"
        dr = Comando.ExecuteReader
        If dr.HasRows Then
            While dr.Read

                AD.Write(dr("IdLibro"))
                AD.Write(";")
                AD.Write(dr("Titulo"))
                AD.Write(";")
                AD.Write(dr("IdAutor"))
                AD.Write(";")
                AD.Write(dr("Año"))
                AD.Write(";")
                AD.Write(dr("IdPais"))
                AD.Write(";")
                AD.Write(dr("IdIdioma"))
                AD.Write(";")
                AD.Write(dr("Cantidad"))
                AD.Write(";")
                AD.WriteLine(dr("Precio"))
                Diferentes = Diferentes + 1
                Cantidad = Cantidad + dr("Cantidad")



            End While

            AD.WriteLine("")
            AD.Write(";")
            AD.Write("Cantidad de stock")
            AD.Write(";")
            AD.WriteLine(Cantidad)
            AD.Write(";")
            AD.Write("Cantidad de Libros")
            AD.Write(";")
            AD.Write(Diferentes)
        End If
        AD.Close()

        Conexion.Close()
        MessageBox.Show("Datos exportados en CSV")
    End Sub

End Class