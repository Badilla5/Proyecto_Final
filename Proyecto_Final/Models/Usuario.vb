Public Class Usuario
    Inherits Persona
    Public Property Contraseña As String
    Public Property Rol As String
    Public Property Email As String

    Public Sub New()
    End Sub

    Public Function obtenernobrecompleto() As String
        Return Nombre & " " & Apellido
    End Function

    Public Function validarusuario() As Boolean
        Return Not String.IsNullOrEmpty(Email) AndAlso Not String.IsNullOrEmpty(Contraseña)

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
