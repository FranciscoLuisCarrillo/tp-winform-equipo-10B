using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // instancia de negocio.            
            ArticuloNegocio negocio = new ArticuloNegocio();

           
            try
            {
                // --- INICIO DE LA PRUEBA DE AGREGAR ---

                // 1.Creo Ob articulo
                Console.WriteLine("Creando nuevo artículo de prueba...");
                Articulo nuevo = new Articulo();
                nuevo.Codigo = "CONS-01";
                nuevo.Nombre = "Articulo de Prueba desde Consola";
                nuevo.Descripcion = "Este artículo fue agregado para probar la conexión y la lógica de negocio.";
                nuevo.Precio = 999.99m;

                // Creamos objetos mara Marca y Categoria
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = 3;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = 2;

                // 2. Genero nuevo articulo a la DDBB
                Console.WriteLine("Intentando agregar el artículo a la base de datos...");
                negocio.agregar(nuevo);

                // 3. Mensaje de exito
                Console.WriteLine("¡Éxito! El artículo fue agregado correctamente.");

                // --- FIN DE LA PRUEBA ---
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Ocurrió un error grave: " + ex.Message);
            }
            finally
            {
                
                Console.WriteLine("\nPrueba finalizada. Presiona cualquier tecla para salir...");
                Console.ReadKey();
            }
        }
    }
}
