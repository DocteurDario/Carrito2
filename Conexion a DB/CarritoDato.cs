﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;


namespace Conexion_a_DB
{
    public class CarritoDato
    {
        public List<Carrito> listarCarrito()
        {
            List<Carrito> lista = new List<Carrito>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select IdCarrito,IdArticulo,Cantidad,PrecioUnitario from CARRITO CR,ARTICULOS A,CATEGORIAS C, MARCAS M Where CR.IdArticulo = A.Id and M.Id = A.IdMarca and C.Id = A.IdCategoria order by a.id asc";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Carrito Aux = new Carrito();

                    Aux.IdCarrito = (int)lector["IdCarrito"];
                    Aux.IdArticulo = (int)lector["IdArticulo"];
                    Aux.Cantidad = (int)lector["Cantidad"];
                    Aux.PrecioUnitario = (decimal)lector["PrecioUnitario"];

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

      
        public List<Carrito> listarCarritoConSP()
        {
            List<Carrito> ListaOrdenada = new List<Carrito>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "StoredCarritoListar";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Carrito Aux = new Carrito();

                    Aux.IdCarrito = (int)lector["IdCarrito"];
                    Aux.IdArticulo = (int)lector["IdArticulo"];
                    Aux.Cantidad = (int)lector["Cantidad"];
                    Aux.PrecioUnitario = (decimal)lector["PrecioUnitario"];


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
        public void Eliminar(Carrito carrito)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "delete from ARTICULOS where IdCarrito = @ID";
                comando.Parameters.AddWithValue("@ID", carrito.IdCarrito);
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
        */
        public void Agregar(Carrito carrito)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                
                comando.CommandText = "insert into CARRITO (IdArticulo,Cantidad, PrecioUnitario) Values ( " + carrito.IdArticulo + ",'"+carrito.Cantidad+"','"+carrito.PrecioUnitario+"')";
                
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
        /*
        public void Modificar(Carrito carrito)
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
     */
    }
}
    
