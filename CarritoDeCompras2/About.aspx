<%@ Page Title="Mercado DOC" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CarritoDeCompras2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3> Carrito de Compras</h3>
    <p>Productos Disponibles</p>
    <asp:GridView ID="dgvArticulos" runat="server" CssClass="Table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="IdArtículo" />
            <asp:BoundField HeaderText="Nombre" DataField="Codigo" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.NombreMarca" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.NombreCategoria" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
        </Columns>
    </asp:GridView>

</asp:Content>
