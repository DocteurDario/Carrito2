<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoDeCompras2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotrom alert-dark">
        <h1>EL DOC CARRITO DE COMPRAS👨🏽‍💻</h1>
        <p class="lead">Compra en la mejor pagina que hice hasta el momento, esperemos que mas adelante realice mejores.</p>
        <p><a href="About.aspx" class="btn btn-outline-info">Ingresa a Comprar &raquo</a></p>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%
            foreach (Clases.Articulo NroArt in ListaArticulo)
            {
        %>          
              <div class="col">
                  <div class="card">
                        <img src="..." class="card-img-top" alt="...">
                        <div class="card-body">
                           <h5 class="card-title"><%:NroArt.Codigo%></h5>
                           <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                        </div>
                    </div>
                </div>
        <% } %>
    </div>
    <div class="col-md-4"></div>
</asp:Content>
