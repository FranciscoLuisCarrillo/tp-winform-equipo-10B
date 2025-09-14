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
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListado formListado = new formListado(TipoListado.Articulo);
            formListado.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            formListadoMarcaCat formListado = new formListadoMarcaCat("Marca");
            formListado.ShowDialog();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formListadoMarcaCat formListado = new formListadoMarcaCat("Categoria");
            formListado.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAgregar formAgregar = new formAgregar();
            formAgregar.ShowDialog();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBuscar formBuscar = new formBuscar();
            formBuscar.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEliminar formEliminar = new formEliminar();
            formEliminar.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formModificar formModificar = new formModificar();
            formModificar.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            formAgregarMarcaCat formAgregarMarcaCategoria = new formAgregarMarcaCat();
            formAgregarMarcaCategoria.tipo = "Marca";
            formAgregarMarcaCategoria.ShowDialog();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formAgregarMarcaCat formAgregarMarcaCategoria = new formAgregarMarcaCat();
            formAgregarMarcaCategoria.tipo = "Categoria";
            formAgregarMarcaCategoria.ShowDialog();
        }
    }
}
