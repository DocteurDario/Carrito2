<%@ Page Title="Reclamos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CarritoDeCompras2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Algunos contactos.</h3>
    <address>
        <br />
        José C Paz, CP 1665 <br />
        <abbr title="Teléfono">Teléfono:</abbr>
        0800-Carrito
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Reclamos@DocCarrito.com">Reclamos@DocCarrito.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Informacion@DocCarrito.com">Informacion@DocCarrito.com</a>
    </address>
</asp:Content>
