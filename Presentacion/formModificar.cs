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
            List<Marca> marcas = new List<Marca>
            {
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
                new Categoria{ Id = 1, Descripcion = "Celulares" },
                new Categoria{ Id = 2, Descripcion = "Televisores" },
                new Categoria{ Id = 3, Descripcion = "Media" },
                new Categoria{ Id = 4, Descripcion = "Audio" },
             };
            boxCategoria.DataSource = categorias;
            boxCategoria.DisplayMember = "Descripcion";
            boxCategoria.ValueMember = "Id";
        }

        private void formModificar_Load(object sender, EventArgs e)
        {

            
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvResultados.DataSource = listaArticulos;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvResultados.CurrentRow.DataBoundItem;

            // Actualizar datos
            seleccionado.Codigo = txtCodigo.Text;
            seleccionado.Nombre = txtNombre.Text;
            seleccionado.Descripcion = txtDescrpcion.Text;
            seleccionado.Precio = decimal.Parse(txtPrecio.Text);
            seleccionado.IdMarca = (int)boxMarca.SelectedValue;
            seleccionado.IdCategoria = (int)boxCategoria.SelectedValue;

            // Llamar al método modificar existente
            new ArticuloNegocio().modificar(seleccionado);

            // Recargar DataGridView
            dgvResultados.DataSource = new ArticuloNegocio().listar();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvResultados.CurrentRow.DataBoundItem;
                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                txtDescrpcion.Text = seleccionado.Descripcion;
                txtPrecio.Text = seleccionado.Precio.ToString();
                boxMarca.SelectedValue = seleccionado.IdMarca;
                boxCategoria.SelectedValue = seleccionado.IdCategoria;
            }
        }

        private void dgvResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvResultados.CurrentRow.DataBoundItem;
                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                txtDescrpcion.Text = seleccionado.Descripcion;
                txtPrecio.Text = seleccionado.Precio.ToString();
                boxMarca.SelectedValue = seleccionado.IdMarca;
                boxCategoria.SelectedValue = seleccionado.IdCategoria;
            }
        }
    }
}
