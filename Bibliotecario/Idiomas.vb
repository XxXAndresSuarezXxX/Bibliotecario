Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class frmIdiomas
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        MostrarDGV("Idioma", dgvGrilla)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim AD As New StreamWriter("Listado de Idioma.csv", False, Encoding.Default)
        Dim Cantidad As Integer = 0
        Dim Diferentes As Integer = 0
        AD.WriteLine("IdIdioma;Nombre")
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Idioma"
        dr = Comando.ExecuteReader
        If dr.HasRows Then
            While dr.Read

                AD.Write(dr("IdIdioma"))
                AD.Write(";")
                AD.WriteLine(dr("Nombre"))

            End While

        End If
        AD.Close()

        Conexion.Close()
        MessageBox.Show("Datos exportados en CSV")
    End Sub
End Class