Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Public Class frmLibrosDeAutor
    Private Sub frmLibrosDeAutor_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Autor"

        Adaptador = New OleDbDataAdapter(Comando)
        DS = New DataSet
        Adaptador.Fill(DS)
        cmbPais.DataSource = DS.Tables(0)
        cmbPais.ValueMember = "IdAutor"
        cmbPais.DisplayMember = "Nombre"

        Conexion.Close()


    End Sub

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Libro"

        dr = Comando.ExecuteReader
        dgvGrilla.Rows.Clear()
        Dim Cantidad As Integer = 0
        Dim Diferentes As Integer = 0

        If dr.HasRows Then
            While dr.Read
                If dr("IdPais") = cmbPais.SelectedValue Then
                    dgvGrilla.Rows.Add(dr("Titulo"), dr("Cantidad"), dr("Precio"))
                    Cantidad = Cantidad + dr("Cantidad")
                    Diferentes = Diferentes + 1
                End If

            End While
        End If


        lblCantidad.Text = Cantidad
        lblDiferentes.Text = Diferentes
        Conexion.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        Dim AD As New StreamWriter("Libros de un Autor.csv", False, Encoding.Default)
        Dim Cantidad As Integer = 0
        Dim Diferentes As Integer = 0
        AD.WriteLine("Titulo;Cantidad;Precio")
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Libro"
        dr = Comando.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                If dr("IdAutor") = cmbPais.SelectedValue Then
                    AD.Write(dr("Titulo"))
                    AD.Write(";")
                    AD.Write(dr("Cantidad"))
                    AD.Write(";")
                    AD.WriteLine(dr("Precio"))
                    Diferentes = Diferentes + 1
                    Cantidad = Cantidad + dr("Cantidad")
                End If


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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()


    End Sub
End Class