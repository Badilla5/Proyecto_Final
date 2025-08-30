Public Class Registrar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private ReadOnly Repo As New Repository()
    Public Function limpiarCampos() As Boolean
        TxtContraseña.Text = String.Empty
        txtEmail.Text = String.Empty
        txtNombre.Text = String.Empty
        txtRepetirContraseña.Text = String.Empty
        LblMensaje.Text = String.Empty
        Return True
    End Function

    Public Function validarRegistro() As Boolean
        Dim nombre As String = txtNombre.Text
        Dim email As String = txtEmail.Text
        Dim contraseña As String = TxtContraseña.Text
        Dim repetirContraseña As String = txtRepetirContraseña.Text
        Dim rol As String = DdlPuestos.SelectedValue
        Dim nuevoUsuario As New Usuario(nombre, email, contraseña, rol)
        If Not validarContraseñas(contraseña, repetirContraseña) Then
            Return False
        End If
        If Not validarDatos(nuevoUsuario) Then
            LblMensaje.Text = "Por favor, complete todos los campos correctamente."
            LblMensaje.Visible = True
            Return False
        End If
        Dim exito As Boolean = Repo.insertarUsuario(nombre, email, contraseña, rol)
        If exito Then
            LblMensaje.Text = "Usuario registrado con éxito."
            LblMensaje.Visible = True
            Return True
        Else
            LblMensaje.Text = "Error al registrar el usuario. Inténtelo de nuevo."
            LblMensaje.Visible = True
            Return False
        End If
    End Function

    Public Function validarContraseñas(Contraseña As String, RepetirContraseña As String) As Boolean
        If Contraseña <> RepetirContraseña Then
            LblMensaje.Text = "Las contraseñas no coinciden."
            LblMensaje.Visible = True
            Return False
        End If
        Return True
    End Function
    Private Function validarDatos(Usuario As Usuario) As Boolean
        ' Validar que los campos no estén vacíos 
        If Not Usuario.validarNombre() OrElse Not Usuario.validarContraseña() OrElse Not Usuario.validarEmail() Then
            Return False
        End If
        Return True
    End Function

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        validarRegistro()
        limpiarCampos()

    End Sub

    Protected Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        limpiarCampos()

    End Sub
End Class