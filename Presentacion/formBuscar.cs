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
    public partial class formBuscar : Form
    {
        public formBuscar()
        {
            InitializeComponent();
            List<Marca> marcas = new List<Marca>
            {
                new Marca {Id = 0, Descripcion = "" },
                new Marca{ Id = 1, Descripcion = "Samsung" },
                new Marca{ Id = 2, Descripcion = "Apple" },
                new Marca{ Id = 3, Descripcion = "Sony" },
                new Marca{ Id = 3, Descripcion = "Huawei" },
                new Marca{ Id = 3, Descripcion = "Motorola" },

             };

            boxMarca.DataSource = marcas;
            boxMarca.DisplayMember = "Descripcion";
            boxMarca.ValueMember = "Id";

            List<Categoria> categorias = new List<Categoria>
            { 
                new Categoria { Id = 0, Descripcion = "" },
                new Categoria{ Id = 1, Descripcion = "Celulares" },
                new Categoria{ Id = 2, Descripcion = "Televisores" },
                new Categoria{ Id = 3, Descripcion = "Media" },
                new Categoria{ Id = 4, Descripcion = "Audio" },
             };
            boxCategoria.DataSource = categorias;
            boxCategoria.DisplayMember = "Descripcion";
            boxCategoria.ValueMember = "Id";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            int? idMarca = null;
            int? idCategoria = null;
            decimal? precioMax = null;

            if (decimal.TryParse(txtPrecio.Text, out decimal precio))
                precioMax = precio;
            if(boxMarca.SelectedIndex > 0)
                idMarca = (int)boxMarca.SelectedValue;
            if (boxCategoria.SelectedIndex > 0)
                idCategoria = (int)boxCategoria.SelectedValue;

            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> resultados = negocio.Buscar(nombre, idMarca, idCategoria, precioMax);

            dgvResultados.DataSource = null; 
            dgvResultados.DataSource = resultados;
        }
    }
}
