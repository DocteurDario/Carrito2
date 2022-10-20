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
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDato articulo = new ArticuloDato();
            ListaArticulo = articulo.listarConSP();

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
                       

            try
            {
                if (ArticuloCarro.IdArtículo == int.Parse(valor))
                {
                    carrito.IdArticulo = int.Parse(valor);
                    carrito.Cantidad = 1;
                    carrito.PrecioUnitario = ArticuloCarro.Precio;

                    CarritoDato carritoDato = new CarritoDato();
                    carritoDato.Agregar(carrito);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}