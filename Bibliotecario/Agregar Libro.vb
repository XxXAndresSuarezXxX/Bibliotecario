Imports System.Data.OleDb
Imports System.Text
Imports System.IO
Public Class frmAgregarLibro
    Private Sub frmAgregarLibro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAgregar.Enabled = False
    End Sub

    Private Sub txtAutor_TextChanged(sender As Object, e As EventArgs) Handles txtTitulo.TextChanged
        btnAgregar.Enabled = txtTitulo.Text <> "" And txtIdAutor.Text <> "" And txtAño.Text <> "" And txtIdPais.Text <> "" And txtIdIdioma.Text <> "" And txtCantidad.Text <> "" And txtPrecio.Text <> ""
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Conexion.ConnectionString = CadenaDeConexion
        Conexion.Open()
        Comando.Connection = Conexion
        Comando.CommandType = CommandType.TableDirect
        Comando.CommandText = "Libro"
        Adaptador = New OleDbDataAdapter(Comando)
        DS = New DataSet
        Adaptador.Fill(DS)

        Dim Tabla As DataTable = DS.Tables(0)
        Dim Fila As DataRow = Tabla.NewRow()
        Fila("Titulo") = txtTitulo.Text
        Fila("IdAutor") = txtIdAutor.Text
        Fila("Año") = txtAño.Text
        Fila("IdPais") = txtIdPais.Text
        Fila("IdIdioma") = txtIdIdioma.Text
        Fila("Cantidad") = txtCantidad.Text
        Fila("Precio") = txtPrecio.Text

        Tabla.Rows.Add(Fila)

        Dim Grabar As New OleDbCommandBuilder(Adaptador)
        Adaptador.Update(DS)


        MessageBox.Show("Dato Agregado")
        Conexion.Close()


    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtIdPais.TextChanged
        btnAgregar.Enabled = txtTitulo.Text <> "" And txtIdAutor.Text <> "" And txtAño.Text <> "" And txtIdPais.Text <> "" And txtIdIdioma.Text <> "" And txtCantidad.Text <> "" And txtPrecio.Text <> ""
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        btnAgregar.Enabled = txtTitulo.Text <> "" And txtIdAutor.Text <> "" And txtAño.Text <> "" And txtIdPais.Text <> "" And txtIdIdioma.Text <> "" And txtCantidad.Text <> "" And txtPrecio.Text <> ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub txtIdAutor_TextChanged(sender As Object, e As EventArgs) Handles txtIdAutor.TextChanged
        btnAgregar.Enabled = txtTitulo.Text <> "" And txtIdAutor.Text <> "" And txtAño.Text <> "" And txtIdPais.Text <> "" And txtIdIdioma.Text <> "" And txtCantidad.Text <> "" And txtPrecio.Text <> ""
    End Sub

    Private Sub txtAño_TextChanged(sender As Object, e As EventArgs) Handles txtAño.TextChanged
        btnAgregar.Enabled = txtTitulo.Text <> "" And txtIdAutor.Text <> "" And txtAño.Text <> "" And txtIdPais.Text <> "" And txtIdIdioma.Text <> "" And txtCantidad.Text <> "" And txtPrecio.Text <> ""
    End Sub

    Private Sub txtIdIdioma_TextChanged(sender As Object, e As EventArgs) Handles txtIdIdioma.TextChanged
        btnAgregar.Enabled = txtTitulo.Text <> "" And txtIdAutor.Text <> "" And txtAño.Text <> "" And txtIdPais.Text <> "" And txtIdIdioma.Text <> "" And txtCantidad.Text <> "" And txtPrecio.Text <> ""
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        btnAgregar.Enabled = txtTitulo.Text <> "" And txtIdAutor.Text <> "" And txtAño.Text <> "" And txtIdPais.Text <> "" And txtIdIdioma.Text <> "" And txtCantidad.Text <> "" And txtPrecio.Text <> ""
    End Sub
End Class