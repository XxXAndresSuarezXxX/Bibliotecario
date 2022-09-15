Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Module Datos_Globales

    Public Conexion As New OleDbConnection
    Public Comando As New OleDb.OleDbCommand
    Public Adaptador As New OleDbDataAdapter
    Public DS As DataSet
    Public dr As OleDbDataReader

    Public CadenaDeConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Libreria.mdb"

    Public Sub MostrarDGV(Idioma As String, dgvGrilla As DataGridView)
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = Idioma

        Adaptador = New OleDbDataAdapter(Comando)
        DS = New DataSet
        Adaptador.Fill(DS)

        dgvGrilla.DataSource = DS.Tables(0)

        Conexion.Close()
    End Sub

    Public Sub Agregar(txtAutor As String, Titulo As String)
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = Titulo
        Adaptador = New OleDbDataAdapter(Comando)
        DS = New DataSet
        Adaptador.Fill(DS)

        Dim Tabla As DataTable = DS.Tables(0)
        Dim Fila As DataRow = Tabla.NewRow()
        Fila("Nombre") = txtAutor
        Tabla.Rows.Add(Fila)

        Dim Grabar As New OleDbCommandBuilder(Adaptador)
        Adaptador.Update(DS)


        MessageBox.Show("Dato Agregado")
        Conexion.Close()

    End Sub

    Public Function BuscarPorId(Tabla As String, IDColumna As String, Codigo As Integer) As String
        Dim Resultado As String = ""
        Dim Conexion As New OleDb.OleDbConnection
        Dim comando As New OleDb.OleDbCommand
        Dim DR As OleDbDataReader

        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        comando.Connection = Conexion
        comando.CommandType = CommandType.TableDirect
        comando.CommandText = Tabla

        DR = comando.ExecuteReader
        If DR.HasRows Then
            While DR.Read
                If DR(IDColumna) = Codigo Then
                    Resultado = DR("Nombre")
                    Exit While
                End If

            End While
        End If
        Conexion.Close()
        Return Resultado
    End Function

    Public Sub Actualizar(num As Integer, nombre As String, id As Integer)
        Dim SQL As String = ""
        Select Case num
            Case 1
                SQL = "update Autor set nombre = '" & nombre & "' where IdAutor = " & id
            Case 2
                SQL = "update Idioma Set nombre = '" & nombre & "' where IdIdioma = " & id
            Case 3
                SQL = "update Pais set nombre = '" & nombre & "' where IdPais = " & id
        End Select
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.Text
        Comando.CommandText = SQL
        Comando.ExecuteReader()
        Conexion.Close()
        MessageBox.Show("Datos actualizados")
    End Sub

    Public IND As Integer = 0

End Module
