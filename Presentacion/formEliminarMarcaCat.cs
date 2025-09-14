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
    public partial class formEliminarMarcaCat : Form
    {
        public string tipo;
        public formEliminarMarcaCat(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void formEliminarMarcaCat_Load_1(object sender, EventArgs e)
        {
            label1.Text = "Eliminar " + tipo;
            if(tipo == "Marca")
            {
                negocio.MarcaNegocio marcaNegocio = new negocio.MarcaNegocio();
                List<dominio.Marca> listaMarca = marcaNegocio.listar();
                dgv.DataSource = listaMarca;
            }
            else
            {
                negocio.CategoriaNegocio categoriaNegocio = new negocio.CategoriaNegocio();
                List<dominio.Categoria> listaCategoria = categoriaNegocio.listar();
                dgv.DataSource = listaCategoria;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un elemento de la lista.");
                return;
            }

            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["ID"].Value);

            if (tipo == "Marca")
            {
                negocio.MarcaNegocio marcaNegocio = new negocio.MarcaNegocio();
                try
                {
                    marcaNegocio.eliminarMarcaPorID(id);
                    MessageBox.Show("Marca eliminada con éxito");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                negocio.CategoriaNegocio categoriaNegocio = new negocio.CategoriaNegocio();
                try
                {
                    categoriaNegocio.eliminarCategoriaPorID(id);
                    MessageBox.Show("Categoría eliminada con éxito");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
