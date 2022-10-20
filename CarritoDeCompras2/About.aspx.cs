using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexion_a_DB;

namespace CarritoDeCompras2
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarritoDato Carrito=new CarritoDato();
            dgvArticulos.DataSource = Carrito.listarCarritoConSP(); 
            dgvArticulos.DataBind();
        }
    }
}