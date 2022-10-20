using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Carrito
    {
        public int      IdCarrito        { get; set; } 
        public int      IdArticulo       {get; set; }
        public int      Cantidad         {get; set; }    
        public decimal  PrecioUnitario   {get; set; }
    }
}
