using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
//using AccesoDatos;
using Acceso = AccesoDatos.Acceso;

namespace negocio
{
    public class ArticuloNegocio
        {
            public List<Articulo> listar()
            {
                List<Articulo> lista = new List<Articulo>();

                // INSTANCIA DE CLASE DE ACCESO A DATOS
                Acceso conectar = new Acceso();

                // SE MIGRO ESTA LOGICA A CLASE ACCESODATOS
                //SqlConnection conexion = new SqlConnection();
                //SqlCommand comando = new SqlCommand();
                //SqlDataReader lector;

                try
                {
                    // ESTA LOGICA SE MIGRA A CLASE ACCESODATOS
                    ///lo primero es la el servidor donde se conecta, lo segundo es la base de datos y lo tercero es la seguridad
                    //conexion.ConnectionString = "Server=TOMAS; Database=CATALOGO_P3_DB; Integrated Security=True; TrustServerCertificate=True;";
                    //comando.CommandType = System.Data.CommandType.Text;
                    //comando.CommandText = "SELECT A.Id,A.Codigo,A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio FROM ARTICULOS A, MARCAS M, CATEGORIAS C Where M.Id = A.Id And C.Id = M.Id";
                    //comando.Connection = conexion;

                    // GENERO LA CONSULTA PARA PASARLE AL CONECTOR
                    string consulta = "SELECT A.Id,A.Codigo,A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio FROM ARTICULOS A, MARCAS M, CATEGORIAS C Where M.Id = A.Id And C.Id = M.Id";
                    conectar.setearConsulta(consulta);


                    conectar.ejecutarLectura();
                    // SE MIGRO ESTA LOGICA A CLASE ACCESODATOS
                    //conexion.Open();
                    //lector = comando.ExecuteReader();

                    // SE CAMBIO LA LOGICA PARA PASAR LA CONECCION MEDIANTE LA CLASE ACCESODATOS
                    while (conectar.Lector.Read())
                    {
                        Articulo aux = new Articulo();
                        aux.Id = conectar.Lector.GetInt32(0);
                        aux.Codigo = (string)conectar.Lector["Codigo"];
                        aux.Nombre = (string)conectar.Lector["Nombre"];
                        aux.Descripcion = (string)conectar.Lector["Descripcion"];
                        aux.Marca = new Marca();
                        aux.Marca.Descripcion = (string)conectar.Lector["Marca"];
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)conectar.Lector["Categoria"];
                        aux.Precio = (decimal)conectar.Lector["Precio"];
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
                    conectar.cerrarConexion();
                }
            }

        public void agregar(Articulo nuevo)

        {
            Acceso conectar = new Acceso();
            try
            {
                // pruebas de logica agnosticas a las ventanas
                string consulta = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)";
                conectar.setearConsulta(consulta);
                // prueba de seteo
                conectar.setAtributo("@codigo", nuevo.Codigo);
                conectar.setAtributo("@nombre", nuevo.Nombre);
                conectar.setAtributo("@descripcion", nuevo.Descripcion);
                conectar.setAtributo("@idMarca", nuevo.Marca.Id);
                conectar.setAtributo("@idCategoria", nuevo.Categoria.Id);
                conectar.setAtributo("@precio", nuevo.Precio); 

                conectar.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conectar.cerrarConexion();


            }
        }


        // Elimina el dato de forma fisica en la DDBB (usar con cuidaod se pierde el registro)
        public void eliminar(int id)
        {
            Acceso conectar = new Acceso();
            try
            {
                string consulta = "DELETE FROM ARTICULOS WHERE Id = @Id";
                conectar.setearConsulta(consulta);
                conectar.setAtributo("@Id", id);
                conectar.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conectar.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo)
        {
        }
       
        }
    }

