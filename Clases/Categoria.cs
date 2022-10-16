using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases 
{
    public class Categoria
    {
        public int IdCategoria { get; set; }    
        public string NombreCategoria { set; get; }

        public override string ToString()
        {
            return NombreCategoria;
        }
    }
}
