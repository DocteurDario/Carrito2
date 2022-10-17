<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoDeCompras2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotrom alert-dark">
        <h1>EL DOC CARRITO DE COMPRAS👨🏽‍💻</h1>
        <p class="lead">Compra en la mejor pagina que hice hasta el momento, esperemos que mas adelante realice mejores.</p>
        <p><a href="About.aspx" class="btn btn-outline-info">Ingresa a Comprar &raquo</a></p>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--
        <%
            foreach (Clases.Articulo NroArt in ListaArticulo)
            {
        %>          
              <div class="col">
                  <div class="card">
                        <img src="<%:NroArt.Imagen %>" class="card-img-top" alt="...">
                        <div class="card-body">
                           <h5 class="card-title"><%:NroArt.Codigo%></h5>
                           <p class="card-text"><%:NroArt.Descripcion %></p>
                            <a href="MostrarDetalle.aspx?idArticulo=<%:NroArt.IdArtículo%>">Ver Detalle</a>
                        </div>
                    </div>
                </div>
        <% } %>
        --%>
        <asp:Repeater runat="server" id="repRepetidor">
            <ItemTemplate>
                <div class="col">
                  <div class="card">
                        <img src="<%#Eval(" Imagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                           <h5 class="card-title"><%#Eval("Codigo")%></h5>
                           <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="MostrarDetalle.aspx?idArticulo=<%#Eval("IdArtículo")%>">Ver Detalle</a>
                            <asp:button Text="Ejemplo" cssClass="btn btn-outline-info" runat="server" Id="btnEjemplo" CommandArgument='<%#Eval("IdArtículo") %>' CommandName="IdArticulo" OnClick="btnEjemplo_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <div class="col-md-4"></div>
</asp:Content>
