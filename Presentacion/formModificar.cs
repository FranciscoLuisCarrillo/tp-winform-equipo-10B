using dominio;
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
    public partial class formModificar : Form
    {
        private List<Articulo> listaArticulos;  
        public formModificar()
        {
            InitializeComponent();
        }

        private void formModificar_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvResultados.DataSource = listaArticulos;
        }
    }
}
