<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Entregas.aspx.vb" Inherits="Proyecto_Final.Entregas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-d-flex align-items-center py-4 bg-body-tertiary">
        <main class="form-signin w-100 m-auto">
            <h1 class="h3 mb-3 fw-normal">Entrega de Proyectos</h1>

             <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>
              <div class="form-floating">
                  <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Email"></asp:TextBox>
                  <label for="MainContent_txtEmail">Email </label>
  
              </div>

            <div class="form-floating">
                  <asp:TextBox ID="txtTitulo" runat="server" CssClass="mb-3 form-control" TextMode="SingleLine" placeholder="Titulo"></asp:TextBox>
                    <label for="MainContent_txtTitulo">Titulo </label>
            </div>

            <div class="form-floating">
                 <asp:TextBox ID="txtDescripccion" runat="server" CssClass="mb-3 form-control" TextMode="SingleLine" placeholder="Titulo" Width =""></asp:TextBox>
                  <label for="MainContent_txtDescripccion">Descripccion </label>
            </div>

            <asp:Button CssClass="btn btn-primary w-100 py-2" ID="btnEntrega" runat="server" Text="Aceptar" OnClick="btnEntrega_Click" />
                <asp:Label ID="lblError" runat="server" Text="" CssClass="alert alert-danger" Visible="false"></asp:Label>

        </main>
    </div>


</asp:Content>
