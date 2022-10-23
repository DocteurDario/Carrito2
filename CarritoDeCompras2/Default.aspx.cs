using Conexion_a_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using System.Diagnostics.PerformanceData;

namespace CarritoDeCompras2
{
    public partial class _Default : Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        public List<Carrito> ListaCarrito { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDato articulo = new ArticuloDato();
            CarritoDato carrito = new CarritoDato();
            ListaArticulo = articulo.listarConSP();
            ListaCarrito = carrito.listarCarrito();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }


        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            Carrito carrito = new Carrito();
            Articulo ArticuloCarro;
                
            ArticuloCarro = ListaArticulo.Find(x => x.IdArtículo == int.Parse(valor));
            //bool existe= ListaCarrito.Exists(x => x.IdArticulo == int.Parse(valor));
            try
            {
                if(ListaCarrito.Exists(x => x.IdArticulo == int.Parse(valor) == true))
                {
                    carrito = ListaCarrito.Find(x => x.IdArticulo == int.Parse(valor));
                    carrito.Cantidad = carrito.Cantidad+1;
                    
                    CarritoDato carritoDato = new CarritoDato();
                    carritoDato.Modificar(carrito);
                }
                else
                {                               
                    if (ArticuloCarro.IdArtículo == int.Parse(valor))
                    {
                        carrito.IdArticulo = ArticuloCarro.IdArtículo;
                        carrito.Cantidad = 1;
                        carrito.PrecioUnitario = ArticuloCarro.Precio;
                        
                        CarritoDato carritoDato = new CarritoDato();
                        carritoDato.Agregar(carrito);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}