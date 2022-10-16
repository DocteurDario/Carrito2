using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Clases;

namespace Conexion_a_DB
{
    public class CategoriaDato
    {
        public List<Categoria> ListaDeCategorias()
        {
            List<Categoria> listaCategoria = new List<Categoria>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server = .\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Id, Descripcion as 'Categorias' from CATEGORIAS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Categoria Aux = new Categoria();
                    Aux.IdCategoria = (int)lector["Id"];
                    Aux.NombreCategoria= (string)lector["Categorias"];

                    listaCategoria.Add(Aux);

                }

                return listaCategoria;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            
        }
    }
}
