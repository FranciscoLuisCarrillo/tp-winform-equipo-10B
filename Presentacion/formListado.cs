using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Presentacion
{
    public enum TipoListado
    {
        Articulo,
        Marca,
        Categoria
    }
    public partial class formListado : Form
    {
        private TipoListado tipo;
        private List<Articulo> listaArticulos;
        private List<Marca> listaMarca;
        public formListado(TipoListado tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void formListado_Load(object sender, EventArgs e)
        {
           
            switch (tipo)
            {
                
                case TipoListado.Articulo:
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    listaArticulos = negocio.listar();
                    dgvArticulos.DataSource = listaArticulos;
                    break;

                case TipoListado.Marca:
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    listaMarca = marcaNegocio.listar();
                    dgvArticulos.DataSource = listaMarca;
                    break;

                /*
                    case TipoListado.Categoria:
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    listaCategoria = categoriaNegocio.listar();
                    dgvArticulos.DataSource = listaCategoria;
                    break;
                */
            }


        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo Seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(Seleccionado.Imagenes[0].ImagenUrl);
            pbArticulo.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void cargarImagen(string image)
        {
            try
            {
                pbArticulo.Load(image);
            }
            catch (Exception)
            {
                pbArticulo.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }
    }
}

