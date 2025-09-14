using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
//using AccesoDatos;
using Acceso = AccesoDatos.Acceso;
namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            Acceso datos = new Acceso();
            try
            {
                datos.setearConsulta("Select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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
                datos.cerrarConexion();
            }

            }
    }


    public void eliminarMarcaPorID(int id)
        {
            Acceso conectar = new Acceso();
            try
            {
                // La consulta ahora es un DELETE directo sobre la tabla.
                string consulta = "DELETE FROM MARCAS WHERE Id = @id";
                conectar.setearConsulta(consulta);
                conectar.setAtributo("@id", id);
                conectar.ejecutarAccion();
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





    }
