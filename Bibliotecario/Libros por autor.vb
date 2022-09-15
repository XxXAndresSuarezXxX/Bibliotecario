Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Public Class frmLibrosPorAutor
    Public Structure ADRegistro
        Dim IdAutor As Integer
        Dim Nombre As String
        Dim Cantidad As Integer
    End Structure



    Private Sub frmLibrosPorAutor_Load(sender As Object, e As EventArgs) Handles MyBase.Load




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim I As Integer = 0
        Dim Autores(1000) As ADRegistro
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Autor"

        dr = Comando.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                Autores(I).IdAutor = dr("IdAutor")
                Autores(I).Nombre = dr("Nombre")
                I = I + 1
            End While
            IND = I
        End If
        Conexion.Close()

        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Libro"
        dr = Comando.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                I = 0
                While (I <= IND)
                    If dr("IdAutor") = Autores(I).IdAutor Then
                        Autores(I).Cantidad = Autores(I).Cantidad + 1
                    End If
                    I = I + 1
                End While
            End While
        End If

        I = 0
        While (I < IND)
            dgvGrilla.Rows.Add(Autores(I).IdAutor, Autores(I).Nombre, Autores(I).Cantidad)
            I = I + 1
        End While




        Conexion.Close()

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim AD As New StreamWriter("Libros por Autores.csv", False, Encoding.Default)
        Dim I As Integer = 0
        Dim Autores(1000) As ADRegistro
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Autor"

        dr = Comando.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                Autores(I).IdAutor = dr("IdAutor")
                Autores(I).Nombre = dr("Nombre")
                I = I + 1
            End While
            IND = I
        End If
        Conexion.Close()

        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Libro"
        dr = Comando.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                I = 0
                While (I <= IND)
                    If dr("IdAutor") = Autores(I).IdAutor Then
                        Autores(I).Cantidad = Autores(I).Cantidad + 1
                    End If
                    I = I + 1
                End While
            End While
        End If

        I = 0
        AD.Write("IDAutor")
        AD.Write(";")
        AD.Write("Nombre")
        AD.Write(";")
        AD.WriteLine("Cantidad")

        While (I < IND)
            AD.Write(Autores(I).IdAutor)
            AD.Write(";")
            AD.Write(Autores(I).Nombre)
            AD.Write(";")
            AD.WriteLine(Autores(I).Cantidad)
            I = I + 1
        End While


        AD.Close()


        Conexion.Close()

        MessageBox.Show("Datos Exportados")
    End Sub
End Class