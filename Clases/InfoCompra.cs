using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class InfoCompra
    {
        public int      IdInfoCompra    { get; set; }
        public string   NombreCliente   { get; set; }
        public string   ApellidoCliente { get; set; }
        public string   Dni             { get; set; }
        public int      Estado          { get; set; }
        public DateTime FechayHora      { get; set; }
    }
}
