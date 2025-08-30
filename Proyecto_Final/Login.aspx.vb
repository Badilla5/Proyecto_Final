Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Public Function validarusuario(usuario As Usuario) As Boolean
        usuario.Email = txtEmail.Text
        usuario.Contraseña = txtPass.Text
        If usuario.validarusuario() AndAlso usuario.validarEmail() Then
            Dim repo As New Repository()
            Dim idusuario As Integer = repo.obtenerusuario(usuario.Email, usuario.Contraseña)
            If idusuario <> -1 Then
                Session("idusuario") = idusuario
                Session("email") = usuario.Email
                Dim rol As String = validarrol(usuario.Email)
                Session("rol") = rol
                If rol = "Estudiante" Then
                    Response.Redirect("Entregas.aspx")
                ElseIf rol = "Profesor" Then
                    Response.Redirect("Comentarios.aspx")
                Else
                    Response.Redirect("Admin.aspx")
                End If
                Return True
            Else
                LblMensaje.Text = "Usuario o contraseña incorrectos."
                Return False
            End If
        Else
            LblMensaje.Text = "Por favor, ingrese un email y contraseña válidos."
            Return False
        End If



    End Function

    Public Function validarrol(email As String) As String

        Dim repo As New Repository()
        Dim rol As String = repo.obtenerRolUsuario(email)
        Return rol
    End Function
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim usuario As New Usuario()
        validarusuario(usuario)

    End Sub
End Class