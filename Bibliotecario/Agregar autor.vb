Imports System.Data.OleDb
Imports System.Text
Imports System.IO

Public Class frmAgregarAutor
    Private Sub frmAgregarAutor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAgregar.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar(txtAutor.Text, "Autor")

    End Sub

    Private Sub txtAutor_TextChanged(sender As Object, e As EventArgs) Handles txtAutor.TextChanged
        btnAgregar.Enabled = txtAutor.Text <> ""
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub
End Class