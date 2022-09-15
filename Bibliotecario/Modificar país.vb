Public Class frmModificarPais
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        txtNombre.Text = ""
        txtNombre.Text = BuscarPorId("Pais", "IDPais", txtCodigo.Text)
        btnGuardar.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Actualizar(3, txtNombre.Text, txtCodigo.Text)
        txtNombre.Text = ""
        txtCodigo.Text = ""
        btnGuardar.Enabled = True


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub frmModificarPais_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
        btnGuardar.Enabled = False

    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        btnBuscar.Enabled = txtCodigo.Text <> ""
    End Sub
End Class