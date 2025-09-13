﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class formAgregar : Form
    {
        public formAgregar()
        {
            InitializeComponent();
            List<Marca> marcas = new List<Marca>
            {
                new Marca{ Id = 1, Descripcion = "Samsung" },
                new Marca{ Id = 2, Descripcion = "Apple" },
                new Marca{ Id = 3, Descripcion = "Sony" },
                new Marca{ Id = 4, Descripcion = "Huawei" },
                new Marca{ Id = 5, Descripcion = "Motorola" },

             };

            boxMarca.DataSource = marcas;          
            boxMarca.DisplayMember = "Descripcion";     
            boxMarca.ValueMember = "Id";

            List<Categoria> categorias = new List<Categoria>
            {
                new Categoria{ Id = 1, Descripcion = "Celulares" },
                new Categoria{ Id = 2, Descripcion = "Televisores" },
                new Categoria{ Id = 3, Descripcion = "Media" },
                new Categoria{ Id = 4, Descripcion = "Audio" },
             };
            boxCategoria.DataSource = categorias;          
            boxCategoria.DisplayMember = "Descripcion";    
            boxCategoria.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
               string.IsNullOrWhiteSpace(txtNombre.Text) ||
               string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            
            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Ingrese un precio válido.");
                return;
            }
            try
            {

                Articulo nuevo = new Articulo();
                {

                    nuevo.Codigo = txtCodigo.Text.Trim();
                    nuevo.Nombre = txtNombre.Text.Trim();
                    nuevo.Descripcion = txtDescrpcion.Text.Trim();
                    nuevo.IdMarca = ((Marca)boxMarca.SelectedItem).Id;
                    nuevo.IdCategoria = ((Categoria)boxCategoria.SelectedItem).Id;
                    nuevo.Precio = precio;
                    nuevo.Imagenes = lstUrls.Items.Cast<string>()
                                                  .Select(url => new Imagen { ImagenUrl = url })
                                                  .ToList();

                }

                ArticuloNegocio negocio = new ArticuloNegocio();
                int idNuevo = negocio.agregar(nuevo);

                MessageBox.Show("Artículo agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar artículo: " + ex.Message);
            }
            finally
            {
                this.Close();
            }

        }

        private void btnAgregarUrl_Click(object sender, EventArgs e)
        {
            var url = txtUrl.Text?.Trim(); //
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Ingrese una URL válida.");
                return;
            }

            if(!lstUrls.Items.Cast<string>().Any(u => u.Equals(url, StringComparison.OrdinalIgnoreCase))) //Esto es para verificar si la url ya existe en la lista evitando mayusculas o minusculas
            {
                lstUrls.Items.Add(url);
                txtUrl.Clear();
            }
            else
            {
                MessageBox.Show("La URL ya ha sido agregada.");
            }
        }

        private void btnQuitarUrl_Click(object sender, EventArgs e)
        {
            if (lstUrls.SelectedItem != null)
            {
                lstUrls.Items.Remove(lstUrls.SelectedItem);
            }
            else
            {
                MessageBox.Show("Seleccione una URL para quitar.");
            }
        }
    }
}
