Public Class frmModificarAutor
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        txtNombre.Text = ""
        txtNombre.Text = BuscarPorId("Autor", "IdAutor", txtAutor.Text)
        btnGuardar.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Actualizar(1, txtNombre.Text, txtAutor.Text)
        txtAutor.Text = ""
        txtNombre.Text = ""


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub txtAutor_TextChanged(sender As Object, e As EventArgs) Handles txtAutor.TextChanged
        btnBuscar.Enabled = txtAutor.Text <> ""
    End Sub

    Private Sub frmModificarAutor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
        btnGuardar.Enabled = False
    End Sub
End Class