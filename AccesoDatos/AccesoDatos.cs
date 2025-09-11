using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Acceso
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public Acceso()
        {

            // CONEXION FRANCISCO
            conexion = new SqlConnection("server=.; database=CATALOGO_P3_DB; integrated security=true;");
            comando = new SqlCommand();
            // CONEXION TOMAS
            //conexion = new SqlConnection("server=TOMAS;  Database=CATALOGO_P3_DB; Integrated Security=True; TrustServerCertificate=True;");
            //comando = new SqlCommand();
            //CONEXION JOAQUIN
            //conexion = new SqlConnection("server=JOAQUIN; database=CATALOGO_P3_DB; integrated security=true; TrustServerCertificate=True;");
            //comando = new SqlCommand();

        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }


        // MEtodo para pasar parametros a la consulta y generar pruebas
        public void setAtributo(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        } 

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

    }
}
