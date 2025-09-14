using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso = AccesoDatos.Acceso;

namespace negocio
{
    public class CategoriaNegocio
    {

        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            Acceso datos = new Acceso();
            try
            {
                datos.setearConsulta("Select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
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

        public void agregarCategoria(Categoria nueva)
        {
            Acceso conectar = new Acceso();
            try
            {
                string consulta = "INSERT INTO CATEGORIAS (Descripcion) VALUES (@descripcion)";
                conectar.setearConsulta(consulta);
                conectar.setAtributo("@descripcion", nueva.Descripcion);
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

        public void eliminarCategoriaPorID(int id)
        {
            Acceso conectar = new Acceso();
            try
            {
                string consulta = "DELETE FROM CATEGORIAS WHERE Id = @id";
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

        public void eliminarCategoriaPorNombre(string nombreCategoria)
        {
            Acceso conectar = new Acceso();
            try
            {

                string consulta = "DELETE FROM CATEGORIAS WHERE UPPER(Descripcion) = @nombre";
                conectar.setearConsulta(consulta);
                // Convertimos el parámetro a mayúsculas para que coincida con la lógica de la consulta.
                conectar.setAtributo("@nombre", nombreCategoria.ToUpper());
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
        public void modificarCategoria(Categoria categoria)
        {
            Acceso conectar = new Acceso();
            try
            {
                string consulta = "UPDATE CATEGORIAS SET Descripcion = @descripcion WHERE Id = @id";
                conectar.setearConsulta(consulta);
                conectar.setAtributo("@descripcion", categoria.Descripcion);
                conectar.setAtributo("@id", categoria.Id);
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
}
