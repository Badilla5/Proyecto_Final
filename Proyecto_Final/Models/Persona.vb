Public Class Persona
    Public Property Id As Integer
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Edad As Integer

    Public Sub New()
    End Sub

    Public Function obtenernobrecompleto() As String
        Return Nombre & " " & Apellido
    End Function
    Public Function validarpersona() As Boolean
        Return Not String.IsNullOrEmpty(Nombre) AndAlso Not String.IsNullOrEmpty(Apellido) AndAlso Edad > 0
    End Function
    Public Function dtToPersona(dataTable As DataTable) As Persona
        If dataTable IsNot Nothing AndAlso dataTable.Rows.Count > 0 Then
            Dim row As DataRow = dataTable.Rows(0)
            Return New Persona() With {
                .Id = Convert.ToInt32(row("Id")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad"))
            }
        End If
        Return Nothing
    End Function





End Class
