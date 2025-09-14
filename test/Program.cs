using System;
using System.Collections.Generic;
using System.Linq;
using negocio;
using dominio;

namespace PruebaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una instancia de tu capa de negocio.
            CategoriaNegocio negocio = new CategoriaNegocio();

            // Nombre único para nuestra categoría de prueba.
            string nombreCategoriaPrueba = "Categoria Test Final";

            try
            {
                // --- 1. PRUEBA DE 'agregarCategoria' ---
                Console.WriteLine("--- INICIANDO PRUEBA DE AGREGAR ---");
                Console.WriteLine($"Agregando nueva categoría: '{nombreCategoriaPrueba}'...");

                Categoria nueva = new Categoria();
                nueva.Descripcion = nombreCategoriaPrueba;

                // Llamamos a tu método 'agregarCategoria'
                negocio.agregarCategoria(nueva);

                Console.WriteLine("¡Categoría agregada exitosamente!");


                // --- 2. VERIFICACIÓN USANDO 'listar' ---
                Console.WriteLine("\n--- VERIFICANDO QUE LA CATEGORÍA EXISTA ---");
                List<Categoria> listaActual = negocio.listar();
                Console.WriteLine("Lista actual de categorías:");
                foreach (var item in listaActual)
                {
                    Console.WriteLine($"- {item.Descripcion}");
                }

                // Buscamos la categoría recién agregada en la lista.
                Categoria encontrada = listaActual.FirstOrDefault(cat => cat.Descripcion == nombreCategoriaPrueba);
                if (encontrada != null)
                {
                    Console.WriteLine("\nVERIFICACIÓN CORRECTA: La categoría de prueba fue encontrada en la lista.");
                }
                else
                {
                    Console.WriteLine("\nERROR DE VERIFICACIÓN: No se encontró la categoría de prueba.");
                }


                // --- 3. PRUEBA DE 'eliminarCategoriaPorNombre' (Case-Insensitive) ---
                Console.WriteLine("\n--- INICIANDO PRUEBA DE ELIMINAR POR NOMBRE ---");
                string nombreParaEliminar = "categoria test final"; // En minúsculas a propósito.
                Console.WriteLine($"Eliminando categoría por nombre: '{nombreParaEliminar}'...");

                // Llamamos a tu método 'eliminarCategoriaPorNombre'
                negocio.eliminarCategoriaPorNombre(nombreParaEliminar);

                Console.WriteLine("¡Categoría eliminada exitosamente por nombre!");


                // --- 4. VERIFICACIÓN DE LA ELIMINACIÓN ---
                Console.WriteLine("\n--- VERIFICANDO QUE LA CATEGORÍA YA NO EXISTA ---");
                listaActual = negocio.listar(); // Volvemos a pedir la lista actualizada.
                Console.WriteLine("Lista final de categorías:");
                foreach (var item in listaActual)
                {
                    Console.WriteLine($"- {item.Descripcion}");
                }

                if (!listaActual.Any(cat => cat.Descripcion == nombreCategoriaPrueba))
                {
                    Console.WriteLine("\nVERIFICACIÓN CORRECTA: La categoría de prueba fue eliminada correctamente.");
                }
                else
                {
                    Console.WriteLine("\nERROR DE VERIFICACIÓN: La categoría de prueba todavía existe.");
                }


                // --- 5. PRUEBA OPCIONAL PARA 'eliminarCategoriaPorID' ---
                // Para probar esta función, puedes agregar otra categoría y luego borrarla por su ID.
                /*
                Console.WriteLine("\n--- PRUEBA OPCIONAL DE ELIMINAR POR ID ---");
                Categoria paraBorrarPorId = new Categoria { Descripcion = "Borrar Por ID" };
                negocio.agregarCategoria(paraBorrarPorId);
                Console.WriteLine("Categoría 'Borrar Por ID' agregada...");
                
                // Vuelves a listar para encontrar su ID
                int idParaBorrar = negocio.listar().FirstOrDefault(c => c.Descripcion == "Borrar Por ID").Id;
                Console.WriteLine($"Intentando eliminar categoría con ID: {idParaBorrar}");

                // Llamamos a tu método 'eliminarCategoriaPorID'
                negocio.eliminarCategoriaPorID(idParaBorrar);
                Console.WriteLine($"Categoría con ID {idParaBorrar} eliminada.");
                */

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcurrió un error grave durante la prueba: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nPrueba finalizada. Presiona cualquier tecla para salir...");
                Console.ReadKey();
            }
        }
    }
}