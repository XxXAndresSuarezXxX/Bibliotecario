Imports System.Data.OleDb
Imports System.Text
Imports System.IO
Public Class frmAgregarIdioma
    Private Sub frmAgregarIdioma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAgregar.Enabled = False
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar(txtAutor.Text, "Idioma")

    End Sub

    Private Sub txtAutor_TextChanged(sender As Object, e As EventArgs) Handles txtAutor.TextChanged
        btnAgregar.Enabled = txtAutor.Text <> ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub
End Class