Public Class Calificaciones
    Inherits System.Web.UI.Page
    Private ReadOnly Repo As New Repository()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function ObtenerIdEstudiante() As Integer
        Dim Idproyecto As String = TxtIdproyecto.Text
        Dim EstudianteId As Integer = Repo.ObtenerIdProyecto(Idproyecto)
        Return EstudianteId

    End Function

    Public Function validarComentario() As Boolean
        Dim Idusuario = ObtenerIdEstudiante()
        Dim Idproyecto As String = TxtIdproyecto.Text
        Dim Texto As String = txtComentario.Text
        Dim Calificacion As Integer = txtCalificacion.Text
        If String.IsNullOrEmpty(Calificacion) OrElse String.IsNullOrEmpty(Texto) Then
            lblError.Text = "Por favor, complete todos los campos."
            lblError.Visible = True
            Return False
        End If
        Dim exito As Boolean = Repo.Insertarcomentario(Idproyecto, Idusuario, Texto, Calificacion)
        If exito Then
            lblError.Text = "Comentario registrado con éxito."
            lblError.Visible = True
            Return True
        Else
            lblError.Text = "Error al registrar el comentario. Inténtelo de nuevo."
            lblError.Visible = True
            Return False
        End If
    End Function

    Protected Sub btnEntrega_Click(sender As Object, e As EventArgs)
        Dim EstudianteId As Int32 = ObtenerIdEstudiante()
        If EstudianteId <> -1 Then
            validarComentario()
            GridView1.DataBind()

        Else
            lblError.Text = "El Id de proyecto proporcionado no está registrado."
            lblError.Visible = True
        End If


    End Sub
End Class