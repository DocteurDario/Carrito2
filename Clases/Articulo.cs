using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Articulo
    {   

        public int IdArtículo { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [DisplayName("Nombre")]
        public string NombreArticulo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }    
        public string Imagen { get; set; }  
        public decimal Precio { get; set; }   
    }   
}
