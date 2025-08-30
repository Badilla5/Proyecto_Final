<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registrar.aspx.vb" Inherits="Proyecto_Final.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row mb-3">
    <div class="col-md-4">
          <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
      <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>

        <div class="form-group mb-3">
            <label for="Nombre">Nombre </label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="LblContraseña">Contraseña</label>
            <asp:TextBox ID="TxtContraseña" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
      
        <div class="form-group mb-3">
            <label for="LblContraseña">Repetir Contraseña</label>
            <asp:TextBox  ID="txtRepetirContraseña" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-floating  mb-3">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
            <label for="MainContent_txtEmail">Email</label>
        </div>

        <div class="form-group mb-3">
    
            <asp:DropDownList ID="DdlPuestos" CssClass="form-control" runat="server">
                <asp:ListItem>Seleccionar Puesto</asp:ListItem>
                <asp:ListItem>Estudiante</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
                <asp:ListItem>Coordinador</asp:ListItem>
            </asp:DropDownList>


        <div class="form-group mb-3">
            <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>

        <div class="form-group mb-3">
            <asp:Button ID="BtnCancelar" CssClass="btn btn-primary" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
        </div>
       
               

        </div>
          </div>
           </div>



         
</asp:Content>
