<%@ Page Title="Mercado DOC" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CarritoDeCompras2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3> Carrito de Compras</h3>
    <p>Productos </p>
    <asp:GridView ID="dgvArticulos" runat="server"  CssClass="Table table-dark table-bordered" AutoGenerateColumns="false">
        <Columns>           
            
            <asp:BoundField HeaderText="Codigo" DataField="IdCarrito" />
            <asp:BoundField HeaderText="Nombre" DataField="IdArticulo" />
            <asp:CommandField ShowSelectButton="true" SelectText="(-)" HeaderText="Menos"/>
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:CommandField ShowSelectButton="true" SelectText="(+)" />
            <asp:BoundField HeaderText="Total"  />
           
             
           
        </Columns>
        
    </asp:GridView>


</asp:Content>
