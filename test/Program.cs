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


            /*
            // instancia de negocio.            
            ArticuloNegocio negocio = new ArticuloNegocio();

           
            try
            {
                
                Console.WriteLine("Creando nuevo artículo de prueba...");
                Articulo nuevo = new Articulo();
                nuevo.Codigo = "CONS-01";
                nuevo.Nombre = "Articulo de Prueba desde Consola";
                nuevo.Descripcion = "Este artículo fue agregado para probar la conexión y la lógica de negocio.";
                nuevo.Precio = 999.99m;

        
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = 3;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = 2;

                
                Console.WriteLine("Intentando agregar el artículo a la base de datos...");
                negocio.agregar(nuevo);

               
                Console.WriteLine("artículo agregado correctamente.");

             
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
            */




            //MarcaNegocio negocio = new MarcaNegocio();
            /*
            try
            {
                Console.WriteLine("Agregando una nueva marca...");
                Marca nueva = new Marca();
                nueva.Descripcion = "Nvidia"; // Nombre de la nueva marca

                negocio.agregar(nueva);

                Console.WriteLine("¡Marca agregada exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.ToString());
            }

            Console.ReadKey();
        }
            */


            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                
                Console.WriteLine("prueba de delete");
                Marca testDelete = new Marca();
                testDelete.Descripcion = "delete";
                negocio.agregar(testDelete);
                Console.WriteLine("Marca agregada.");

                string nombreDelete = "delete";
                Console.WriteLine("prueba delete: " + nombreDelete);

                negocio.eliminarMarcaPorNombre(nombreDelete);

                Console.WriteLine("funciona");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.ToString());
            }

            Console.ReadKey();
        }



    }
 }


