<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Comentarios.aspx.vb" Inherits="Proyecto_Final.Calificaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="form-d-flex align-items-center py-4 bg-body-tertiary">
     <main class="form-signin w-100 m-auto">
         <h1 class="h3 mb-3 fw-normal">Cometarios de los proyectos
         </h1>
          <asp:Label ID="LblIDproyecto" runat="server" Text=""></asp:Label>
           <div class="form-floating">
               <asp:TextBox ID="TxtIdproyecto" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Email"></asp:TextBox>
               <label for="MainContent_TxtIdproyecto">Id del proyecto  </label>
           </div>
         <div class="form-floating">
             <asp:TextBox ID="txtCalificacion" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Email"></asp:TextBox>
             <label for="MainContent_txtCalificacion">Calificacion</label>
         </div>
         <div class="form-floating">
              <asp:TextBox ID="txtComentario" runat="server" CssClass="mb-3 form-control" TextMode="SingleLine" placeholder="Titulo" Width =""></asp:TextBox>
               <label for="MainContent_txtComentario">Comentario </label>
         </div>
         <asp:Button CssClass="btn btn-primary w-100 py-2" ID="btnEntrega" runat="server" Text="Aceptar" OnClick="btnEntrega_Click" />
             <asp:Label ID="lblError" runat="server" Text="" CssClass="alert alert-danger" Visible="false"></asp:Label>
     </main>
 </div>


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ProyectoId" DataSourceID="SqlDataSource1" Width="1352px">
        <Columns>
            <asp:BoundField DataField="ProyectoId" HeaderText="ProyectoId" InsertVisible="False" ReadOnly="True" SortExpression="ProyectoId" />
            <asp:BoundField DataField="ProyectoTitulo" HeaderText="ProyectoTitulo" SortExpression="ProyectoTitulo" />
            <asp:BoundField DataField="ProyectoDescripcion" HeaderText="ProyectoDescripcion" SortExpression="ProyectoDescripcion" />
            <asp:BoundField DataField="EstudianteNombre" HeaderText="EstudianteNombre" SortExpression="EstudianteNombre" />
            <asp:BoundField DataField="ComentarioTexto" HeaderText="ComentarioTexto" SortExpression="ComentarioTexto" />
            <asp:BoundField DataField="Calificacion" HeaderText="Calificacion" SortExpression="Calificacion" />
        </Columns>
    </asp:GridView>
    


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:II-46PConnectionString1 %>" 
        SelectCommand="SELECT P.Id AS ProyectoId, P.Titulo AS ProyectoTitulo, P.Descripcion AS ProyectoDescripcion, E.Nombre AS EstudianteNombre, C.Texto AS ComentarioTexto, C.Calificacion FROM Proyectos AS P INNER JOIN Usuarios AS E ON P.IdEstudiante = E.Id LEFT OUTER JOIN Comentarios AS C ON P.Id = C.IdProyecto LEFT OUTER JOIN Usuarios AS U ON C.IdUsuario = U.Id ORDER BY P.FechaCreacion DESC, C.Fecha"></asp:SqlDataSource>
    


</asp:Content>
