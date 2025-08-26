Imports System.Data.SqlClient

Public Class Repository
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("Login").ConnectionString
    Public Function actualizarUsuario(id As Integer, nombre As String, email As String, rol As String) As Boolean
        Dim query As String = "UPDATE Usuarios SET Nombre = @Nombre, Email = @Email, Rol = @Rol WHERE Id = @Id"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Id", id)
                cmd.Parameters.AddWithValue("@Nombre", nombre)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.Parameters.AddWithValue("@Rol", rol)
                Try
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                Catch ex As Exception
                    ' Manejo de errores (puedes registrar el error si es necesario)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Function obtenerusuario(email As String, contraseña As String) As Integer
        Dim query As String = "SELECT Id, Rol FROM Usuarios WHERE Email = @Email"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.Parameters.AddWithValue("@Contraseña", contraseña)
                Try
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return Convert.ToInt32(result)
                    Else
                        Return -1 ' Usuario no encontrado
                    End If
                Catch ex As Exception
                    ' Manejo de errores (puedes registrar el error si es necesario)
                    Return -1
                End Try
            End Using
        End Using
    End Function
    Public Function insertarEntrega(IdEstudiante As Integer, Descripcion As String, Titulo As String) As Boolean
        Dim query As String = "INSERT INTO Proyectos (IdEstudiante, Descripcion, Titulo) VALUES (@IdEstudiante, @Descripcion, @Titulo)"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@IdEstudiante", IdEstudiante)
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
                cmd.Parameters.AddWithValue("@Titulo", Titulo)

                Try
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                Catch ex As Exception
                    ' Manejo de errores (puedes registrar el error si es necesario)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Function obtenerRolUsuario(email As String) As String
        Dim query As String = "SELECT Rol FROM Usuarios WHERE Email = @Email"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", email)
                Try
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return Convert.ToString(result)
                    Else
                        Return String.Empty ' Usuario no encontrado
                    End If
                Catch ex As Exception
                    ' Manejo de errores (puedes registrar el error si es necesario)
                    Return String.Empty

                End Try
            End Using
        End Using
    End Function

    Public Function obtenerUsuarioPorEmail(email As String) As DataTable
        Dim query As String = "SELECT * FROM Usuarios WHERE Email = @Email"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", email)
                Try
                    conn.Open()
                    Using adapter As New SqlDataAdapter(cmd)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        Return dataTable
                    End Using
                Catch ex As Exception
                    ' Manejo de errores (puedes registrar el error si es necesario)
                    Return Nothing
                End Try
            End Using
        End Using
    End Function

    Public Function ObtenerIdEstudiante(email As String) As Integer
        Dim query As String = "SELECT Id FROM Usuarios WHERE Email = @Email"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", email)
                Try
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return Convert.ToInt32(result)
                    Else
                        Return -1 ' Usuario no encontrado
                    End If
                Catch ex As Exception
                    ' Manejo de errores (puedes registrar el error si es necesario)
                    Return -1
                End Try
            End Using
        End Using
    End Function

End Class
