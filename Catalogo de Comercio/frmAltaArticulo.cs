using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Catalogo_de_Comercio
{
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            
            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.Marca = (Marca)cmbMarca.SelectedItem;
                nuevo.Categoria = (Categoria)cmbCategoria.SelectedItem;
                //Aca debo llamar al metodo para agregarlo desde ArtNegocio:
                articuloNegocio.Agregar(nuevo);
                MessageBox.Show("Se agregó el artículo");
                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            //En el load cargo las marcas y categorias del combo box
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                cmbCategoria.DataSource = categoriaNegocio.listar();
                cmbCategoria.DisplayMember = "Descripcion"; //lo que ve el usuario
                cmbCategoria.ValueMember = "Id";

                cmbMarca.DataSource = marcaNegocio.listar();
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "Id";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/2560px-Placeholder_view_vector.svg.png");
               
            }
        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
           cargarImagen(txtImagenUrl.Text);
        }
    }
}
