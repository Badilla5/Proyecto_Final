Public Class Usuario
    Inherits Persona
    Public Property Contraseña As String
    Public Property Rol As String
    Public Property Email As String
    Public Property IdEstudiante As Integer
    Public Property IdProyecto As Integer
    Public Property titulo As String
    Public Property repetirContraseña As String
    Public Property Descripcion As String

    Public Sub New()
        ' Constructor por defecto

    End Sub
    Public Sub New(nombre As String, email As String, contraseña As String, rol As String)
        Me.Nombre = nombre
        Me.Email = email
        Me.Contraseña = contraseña
        Me.Rol = rol
    End Sub

    Public Function validarusuario() As Boolean
        Return Not String.IsNullOrEmpty(Email) AndAlso Not String.IsNullOrEmpty(Contraseña)

    End Function
    Public Function validarContraseña() As Boolean
        Return Not String.IsNullOrEmpty(Contraseña) AndAlso Contraseña.Length >= 6
    End Function

    Public Function validarNombre() As Boolean
        Return Not String.IsNullOrEmpty(Nombre) AndAlso Nombre.Length >= 3
    End Function

    Public Function dtToUsuario(dataTable As DataTable) As Usuario
        If dataTable IsNot Nothing AndAlso dataTable.Rows.Count > 0 Then
            Dim row As DataRow = dataTable.Rows(0)
            Return New Usuario() With {
                .Id = Convert.ToInt32(row("Id")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Email = Convert.ToString(row("Email")),
                .Rol = Convert.ToString(row("Rol")),
                .IdEstudiante = Convert.ToInt32(row("IdEstudiante")),
                .IdProyecto = Convert.ToInt32(row("IdProyecto")),
                .Contraseña = Convert.ToString(row("Contraseña"))
            }
        End If
        Return Nothing
    End Function
    Public Function validarEmail() As Boolean
        Dim emailPattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        Return Regex.IsMatch(Email, emailPattern)
    End Function


End Class
