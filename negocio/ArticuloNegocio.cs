using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticuloNegocio
        {
            public List<Articulo> listar()
            {
                List<Articulo> lista = new List<Articulo>();
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                try
                {               ///lo primero es la el servidor donde se conecta, lo segundo es la base de datos y lo tercero es la seguridad
                    conexion.ConnectionString = "Server=TOMAS; Database=CATALOGO_P3_DB; Integrated Security=True; TrustServerCertificate=True;";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "SELECT A.Id,A.Codigo,A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio FROM ARTICULOS A, MARCAS M, CATEGORIAS C Where M.Id = A.Id And C.Id = M.Id";
                    comando.Connection = conexion;

                    conexion.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Articulo aux = new Articulo();
                        aux.Id = lector.GetInt32(0);
                        aux.Codigo = (string)lector["Codigo"];
                        aux.Nombre = (string)lector["Nombre"];
                        aux.Descripcion = (string)lector["Descripcion"];
                        aux.Marca = new Marca();
                        aux.Marca.Descripcion = (string)lector["Marca"];
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)lector["Categoria"];
                        aux.Precio = (decimal)lector["Precio"];
                        lista.Add(aux);
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
            
            public void agregar(Articulo nuevo)
        {

        }
        public void modificar(Articulo articulo)
        {
        }
       
        }
    }

