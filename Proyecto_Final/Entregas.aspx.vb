Public Class Entregas
    Inherits System.Web.UI.Page
    Private ReadOnly Repo As New Repository()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Public Function limpiarCampos() As Boolean
        txtDescripccion.Text = String.Empty
        txtTitulo.Text = String.Empty
        lblError.Text = String.Empty
        Return True
    End Function
    Public Function obtenerIdEstudiante() As Integer
        Dim Email As String = txtEmail.Text
        Dim EstudianteId As Integer = Repo.ObtenerIdEstudiante(Email)
        Return EstudianteId

    End Function
    Public Function validarEntrega() As Boolean
        Dim IdEstudiante = obtenerIdEstudiante()
        Dim Descripcion As String = txtDescripccion.Text
        Dim Titulo As String = txtTitulo.Text
        If String.IsNullOrEmpty(Titulo) OrElse String.IsNullOrEmpty(Descripcion) Then
            lblError.Text = "Por favor, complete todos los campos."
            lblError.Visible = True
            Return False
        End If

        Dim exito As Boolean = Repo.insertarEntrega(IdEstudiante, Descripcion, Titulo)
        If exito Then
            lblError.Text = "Entrega registrada con éxito."
            lblError.Visible = True
            Return True
        Else
            lblError.Text = "Error al registrar la entrega. Inténtelo de nuevo."
            lblError.Visible = True
            Return False
        End If
    End Function
    Protected Sub btnEntrega_Click(sender As Object, e As EventArgs)
        Dim IdEstudiante As Integer = obtenerIdEstudiante()
        If IdEstudiante <> -1 Then
            validarEntrega()
            limpiarCampos()
        Else
            lblError.Text = "El email proporcionado no está registrado."
            lblError.Visible = True
        End If
    End Sub
End Class