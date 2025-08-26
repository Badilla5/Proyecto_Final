<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.vb" Inherits="Proyecto_Final.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Row mb-3">
        <div class="form-group mb-3">
            <label for="txtNombre">Nombre</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="lbEmail">Email</label>
            <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            
            <asp:DropDownList ID="DdlPuestos" CssClass="form-control" runat="server">
                <asp:ListItem>Seleccionar Puesto</asp:ListItem>
                <asp:ListItem>Estudiante</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
                <asp:ListItem>Coordinador</asp:ListItem>
            </asp:DropDownList>

        </div>
        <div>
            <asp:Button ID="BtnActulizar" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="BtnActulizar_Click" />
        </div>
        <div>
    <asp:Button ID="BtnCancelar" CssClass="btn btn-primary" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
</div>
        <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
    </div>

    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Width="899px">
        <Columns>

            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Rol" HeaderText="Rol" SortExpression="Rol" />
            <asp:CommandField ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
    


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46PConnectionString1 %>" ProviderName="<%$ ConnectionStrings:II-46PConnectionString1.ProviderName %>" SelectCommand="SELECT [Id], [Nombre], [Email], [Rol] FROM [Usuarios]"></asp:SqlDataSource>
    


</asp:Content>
