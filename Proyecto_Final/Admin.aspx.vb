Public Class Admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub BtnActulizar_Click(sender As Object, e As EventArgs)
        Dim selectedRow As GridViewRow = GridView1.SelectedRow
        If selectedRow IsNot Nothing Then
            Dim id As Integer = Convert.ToInt32(selectedRow.Cells(0).Text)
            Dim nombre As String = txtNombre.Text
            Dim email As String = TxtEmail.Text
            Dim rol As String = DdlPuestos.SelectedValue
            Dim repo As New Repository()
            Dim exito As Boolean = repo.actualizarUsuario(id, nombre, email, rol)
            If exito Then
                LblMensaje.Text = "Usuario actualizado con éxito."
                GridView1.DataBind() ' Refrescar el GridView para mostrar los cambios
            Else
                LblMensaje.Text = "Error al actualizar el usuario. Inténtelo de nuevo."
            End If
        Else
            LblMensaje.Text = "Por favor, seleccione un usuario para actualizar."
        End If


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim selectedRow As GridViewRow = GridView1.SelectedRow
        If selectedRow IsNot Nothing Then
            Dim id As String = selectedRow.Cells(0).Text
            Dim nombre As String = selectedRow.Cells(1).Text
            Dim email As String = selectedRow.Cells(2).Text
            Dim rol As String = selectedRow.Cells(3).Text
            txtNombre.Text = nombre
            TxtEmail.Text = email
            DdlPuestos.SelectedValue = rol

        End If

    End Sub

    Protected Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        txtNombre.Text = String.Empty
        TxtEmail.Text = String.Empty
        DdlPuestos.SelectedIndex = 0


    End Sub
End Class