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
    public partial class formModificarMarcaCat : Form
    {
        public string tipo;
        public formModificarMarcaCat(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }
        private void formModificarMarcaCat_Load(object sender, EventArgs e)
        {
            label8.Text = "Modificar " + tipo;
            if (tipo == "Marca")
            {
                negocio.MarcaNegocio marcaNegocio = new negocio.MarcaNegocio();
                List<dominio.Marca> listaMarca = marcaNegocio.listar();
                dgvResultados.DataSource = listaMarca;
            }
            else
            {
                negocio.CategoriaNegocio categoriaNegocio = new negocio.CategoriaNegocio();
                List<dominio.Categoria> listaCategoria = categoriaNegocio.listar();
                dgvResultados.DataSource = listaCategoria;
            }
        }
    }
}
