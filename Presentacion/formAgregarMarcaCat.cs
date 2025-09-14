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
    public partial class formAgregarMarcaCat : Form
    {
        public String tipo;
        public formAgregarMarcaCat()
        {
            InitializeComponent();
        }

        private void formAgregarMarcaCat_Load(object sender, EventArgs e)
        {
            this.Text = "Agregar " + tipo;
            label1.Text = "Agregar " + tipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tipo == "Marca")
            {
                negocio.MarcaNegocio marcaNegocio = new negocio.MarcaNegocio();
                dominio.Marca nueva = new dominio.Marca();
                nueva.Descripcion = txtDescrpcion.Text;
                try
                {
                    marcaNegocio.agregarMarca(nueva);
                    MessageBox.Show("Marca agregada con exito");
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
                dominio.Categoria nueva = new dominio.Categoria();
                nueva.Descripcion = txtDescrpcion.Text;
                try
                {
                    categoriaNegocio.agregarCategoria(nueva);
                    MessageBox.Show("Categoria agregada con exito");
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
