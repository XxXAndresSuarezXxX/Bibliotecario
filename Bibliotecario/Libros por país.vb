Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Public Structure ADRegistro
    Dim IdPais As Integer
    Dim Nombre As String
    Dim Cantidad As Integer
End Structure

Public Class frmLibrosPorPais
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim I As Integer = 0
        Dim Vector(1000) As ADRegistro
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Pais"

        dr = Comando.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                Vector(I).IdPais = dr("IdPais")
                Vector(I).Nombre = dr("Nombre")
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
                    If dr("IdPais") = Vector(I).IdPais Then
                        Vector(I).Cantidad = Vector(I).Cantidad + 1
                    End If
                    I = I + 1
                End While
            End While
        End If

        I = 0
        While (I < IND)
            dgvGrilla.Rows.Add(Vector(I).IdPais, Vector(I).Nombre, Vector(I).Cantidad)
            I = I + 1
        End While




        Conexion.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim AD As New StreamWriter("Libros por Paises.csv", False, Encoding.Default)
        Dim I As Integer = 0
        Dim Autores(1000) As ADRegistro
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Pais"

        dr = Comando.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                Autores(I).IdPais = dr("IdPais")
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
                    If dr("IdPais") = Autores(I).IdPais Then
                        Autores(I).Cantidad = Autores(I).Cantidad + 1
                    End If
                    I = I + 1
                End While
            End While
        End If

        I = 0
        AD.Write("IdPais")
        AD.Write(";")
        AD.Write("Nombre")
        AD.Write(";")
        AD.WriteLine("Cantidad")

        While (I < IND)
            AD.Write(Autores(I).IdPais)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub
End Class