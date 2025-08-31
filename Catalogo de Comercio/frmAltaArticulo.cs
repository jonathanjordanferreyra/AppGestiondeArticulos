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
        private Articulo articulo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        //Creo un nuevo constructor
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modifique su Artículo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validarCampos()
        {
            int cont = 0;
            if(txtCodigo.Text == "")
            {
                lblast3.Visible = true;
                txtCodigo.BackColor = Color.Red;
                cont = 1;
            }
            else
            {
                lblast3.Visible = false;
                txtCodigo.BackColor = Color.White;
            }
            if (txtNombre.Text == "")
            {
                lblast4.Visible = true;
                txtNombre.BackColor = Color.Red;
                cont = 1;
            }
            else
            {
                lblast4.Visible = false;
                txtNombre.BackColor = Color.White;
            }
            if (txtDescripcion.Text == "")
            {
                lblast5.Visible = true;
                txtDescripcion.BackColor = Color.Red;
                cont = 1;
            }
            else
            {
                lblast5.Visible = false;
                txtDescripcion.BackColor = Color.White;
            }
            //valido que se ingrese un decimal con TryParse que devuelve true si no hay letras.
            decimal precio;
            if (decimal.TryParse(txtPrecio.Text, out precio))
            {
                txtPrecio.BackColor = Color.White;
                lblast8.Visible = false;
            }
            else
            {
                txtPrecio.BackColor = Color.Red;
                lblast8.Visible = true;
                MessageBox.Show("Formato incorrecto en el precio, solo números.", "Precio incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(cont == 1)
            {
                MessageBox.Show("Complete los campos obligatorios (Marcados en rojo)", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cont = 0;
                return false;
            }
            else
            {
                return true;
            }

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            
            try
            {
                if (articulo == null)
                {
                    articulo = new Articulo();
                }
                bool bandera = validarCampos();
                if (bandera) 
                {
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.ImagenUrl = txtImagenUrl.Text;
                    articulo.Marca = (Marca)cmbMarca.SelectedItem;
                    articulo.Categoria = (Categoria)cmbCategoria.SelectedItem;
                    decimal precio;
                    //si da true es porque es decimal y puedo convertirlo.
                    if (decimal.TryParse(txtPrecio.Text, out precio))
                    {
                        articulo.Precio = decimal.Parse(txtPrecio.Text);
                    }
                    //Aca debo llamar al metodo para agregarlo desde ArtNegocio o el metodo modificar, para eso valido que quiere hacer el usuario:
                    if (articulo.Id != 0)
                    {
                        articuloNegocio.Modificar(articulo);
                        MessageBox.Show("Sé modificó el artículo");
                    }
                    else
                    {
                        articuloNegocio.Agregar(articulo);
                        MessageBox.Show("Se agregó el artículo");
                    }

                    Close();
                }

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
                //precargar pokemon si se clickeo modificar
                if (articulo != null)
                {
                    txtNombre.Text = articulo.Nombre;
                    txtCodigo.Text = articulo.Codigo;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagenUrl.Text = articulo.ImagenUrl;
                    txtPrecio.Text = articulo.Precio.ToString();
                    cargarImagen(articulo.ImagenUrl);
                    cmbCategoria.SelectedValue = articulo.Categoria.Id;
                    cmbMarca.SelectedValue = articulo.Marca.Id;
                }
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
            catch (Exception)
            {
                pbxArticulo.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
               
            }
        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
           cargarImagen(txtImagenUrl.Text);
        }
    }
}
