using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Clases;

namespace Conexion_a_DB
{
    public class ArticuloDato
    {
        public List<Articulo> listarArticulos()
        {
            List<Articulo> lista= new List<Articulo>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select A.Id as 'IdP', A.Codigo as 'Codigo', A.Nombre as 'Nombre', A.Descripcion as 'Descripcion', M.id as 'Id', M.Descripcion as 'Marca', C.id as 'Id', C.Descripcion as 'Categoria', A.ImagenUrl as 'ImagenURL', A.Precio as 'Precio' from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Articulo Aux = new Articulo();
                        
                        Aux.IdArtículo = (int)lector["IdP"];
                        Aux.Codigo= (string)lector["Codigo"];
                        Aux.NombreArticulo = (string)lector["Nombre"];

                        if (!(lector["Descripcion"] is DBNull))
                        Aux.Descripcion = (string)lector["Descripcion"];

                        Aux.Marca = new Marca();
                        Aux.Marca.IdMarca = (int)lector["Id"];
                        Aux.Marca.NombreMarca = (string)lector["Marca"];
                        Aux.Categoria = new Categoria();
                        Aux.Categoria.IdCategoria = (int)lector["Id"];
                        Aux.Categoria.NombreCategoria = (string)lector["Categoria"];

                        // if (!(lector.IsDBNull(lector.GetOrdinal("ImagenURL")))) 
                        //Aux.Imagen = (string)lector["ImagenURL"];

                        if (!(lector["ImagenURL"] is DBNull))
                        Aux.Imagen = (string)lector["ImagenURL"];


                        Aux.Precio = (decimal)lector["Precio"];
                       
                       lista.Add(Aux);

                    }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Articulo> listarConSP()
        {
            List<Articulo> ListaOrdenada = new List<Articulo>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                //string consulta = "Select A.Id as 'Id P', A.Codigo, A.Nombre, A.Descripcion, M.id as 'Id Marca', M.Descripcion as 'Marca', C.id as 'Id Categoria', C.Descripcion as 'Categoria', A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria ";


                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                //comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = consulta;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "storedListar";


                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo Aux = new Articulo();
                    Aux.IdArtículo = (int)lector["Id P"];
                    Aux.NombreArticulo = (string)lector["Nombre"];
                    Aux.Codigo = (string)lector["Codigo"];
                    Aux.Descripcion = (string)lector["Descripcion"];
                    Aux.Marca = new Marca();
                    Aux.Marca.IdMarca = (int)lector["Id Marca"];
                    Aux.Marca.NombreMarca = (string)lector["Marca"];
                    Aux.Categoria = new Categoria();
                    Aux.Categoria.IdCategoria = (int)lector["Id Categoria"];
                    Aux.Categoria.NombreCategoria = (string)lector["Categoria"];
                    if (!(lector["ImagenURL"] is DBNull))
                    {
                        Aux.Imagen = (string)lector["ImagenURL"];
                    }
                    Aux.Precio = (decimal)lector["Precio"];

                    ListaOrdenada.Add(Aux);
                }

                return ListaOrdenada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Eliminar(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "delete from ARTICULOS where Id = @ID";
                comando.Parameters.AddWithValue("@ID", articulo.IdArtículo);
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Agregar(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) Values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @PP)";
                comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", articulo.NombreArticulo);
                comando.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                comando.Parameters.AddWithValue("@IdMarca", articulo.Marca.IdMarca);
                comando.Parameters.AddWithValue("@IdCategoria", articulo.Categoria.IdCategoria);
                comando.Parameters.AddWithValue("@ImagenUrl", articulo.Imagen);
                comando.Parameters.AddWithValue("@PP", articulo.Precio);
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }

        }

        public void Modificar(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @DD, IdMarca = @IDM, IdCategoria = @IDC, ImagenUrl = @URL, Precio = @Price where Id = @ID";
                comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", articulo.NombreArticulo);
                comando.Parameters.AddWithValue("@DD", articulo.Descripcion);
                comando.Parameters.AddWithValue("@IDM", articulo.Marca.IdMarca);
                comando.Parameters.AddWithValue("@IDC", articulo.Categoria.IdCategoria);
                comando.Parameters.AddWithValue("@URL", articulo.Imagen);
                comando.Parameters.AddWithValue("@Price", articulo.Precio);
                comando.Parameters.AddWithValue("@ID", articulo.IdArtículo);


                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }

        }

        public List<Articulo> Ordenar(string criterio)
        {
            List<Articulo> ListaOrdenada = new List<Articulo>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                string consulta = "Select A.Id as 'Id P', A.Codigo, A.Nombre, A.Descripcion, M.id as 'Id Marca', M.Descripcion as 'Marca', C.id as 'Id Categoria', C.Descripcion as 'Categoria', A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria order by ";
                switch (criterio)
                {
                    case "Código A-Z":
                        consulta += "A.Codigo asc";
                        break;

                    case "Código Z-A":
                        consulta += "A.Codigo desc";
                        break;

                    case "Mayor precio":
                        consulta += "A.Precio desc";
                        break;

                    case "Menor precio":
                        consulta += "A.Precio asc";
                        break;

                    default:
                        break;
                }

                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo Aux = new Articulo();
                    Aux.IdArtículo = (int)lector["Id P"];
                    Aux.NombreArticulo = (string)lector["Nombre"];
                    Aux.Codigo = (string)lector["Codigo"];
                    Aux.Descripcion = (string)lector["Descripcion"];
                    Aux.Marca = new Marca();
                    Aux.Marca.IdMarca = (int)lector["Id Marca"];
                    Aux.Marca.NombreMarca = (string)lector["Marca"];
                    Aux.Categoria = new Categoria();
                    Aux.Categoria.IdCategoria = (int)lector["Id Categoria"];
                    Aux.Categoria.NombreCategoria = (string)lector["Categoria"];
                    if (!(lector["ImagenURL"] is DBNull))
                    {
                        Aux.Imagen = (string)lector["ImagenURL"];
                    }
                    Aux.Precio = (decimal)lector["Precio"];

                    ListaOrdenada.Add(Aux);
                }

                return ListaOrdenada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        /*
        public void setearProcedimiento (string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }
        */
       
    }
}
