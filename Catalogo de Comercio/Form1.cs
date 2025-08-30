using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Catalogo_de_Comercio
{
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.Listar();
            dgvArticulos.DataSource = listaArticulo;
            pbxArticulo.Load(listaArticulo[0].ImagenUrl);

            OcultarColumnas();
            cboCampo.Items.Add("Código");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");

            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoría");

        }
        private void OcultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow != null) 
                { 
                    Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    CargarImagen(seleccionado.ImagenUrl);
                    txtCodigo.Text = seleccionado.Codigo;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtNombre.Text = seleccionado.Nombre;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void CargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (FileNotFoundException)
            {
                pbxArticulo.Load("https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png");
            }
            catch (System.Net.WebException)
            {
                //Aca me da error de web 403, creo que no es un problema con mi codigo, si no con la URL de la base de datos.
               // MessageBox.Show("No se pudo cargar la imagen (Error 403 Servidor remoto), se muestra una por defecto...");
                pbxArticulo.Load("https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.ToString()));  
            }

        }
        //metodo para recargar la grilla
        private void CargarGrilla()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.Listar();
                OcultarColumnas();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo Alta = new frmAltaArticulo();
            Alta.ShowDialog();
            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para modificar");
                return;
            }
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAltaArticulo Modificar = new frmAltaArticulo(seleccionado);
            Modificar.ShowDialog();
            CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                if (seleccionado == null) 
                {
                    MessageBox.Show("Debe seleccionar un Artículo para eliminar","Eliminar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar DEFINITIVAMENTE el Articulo?", "Eliminado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                       negocio.Eliminar(seleccionado.Id);
                       CargarGrilla();
                    }
                    
                }
                    
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            if (txtFiltroRapido.Text != "")
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()) || x.Codigo.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            OcultarColumnas();

        }

        //metodos para cargar el combo box criterio.
        private void cargarCriterioString()
        {
            cboCriterio.Items.Clear();
            cboCriterio.Items.Add("Empieza con");
            cboCriterio.Items.Add("Termina con");
            cboCriterio.Items.Add("Contiene");
            cboCriterio.SelectedItem = "Empieza con";
        }
        private void cargarCriterioCategoria()
        {
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            cboCriterio.DataSource = negocioCategoria.listar();
            cboCriterio.DisplayMember = "Descripcion";
            cboCriterio.ValueMember = "Id";
        }
        private void cargarCriterioMarca()
        {
            MarcaNegocio negocioMarca = new MarcaNegocio();
            cboCriterio.DataSource = negocioMarca.listar();
            cboCriterio.DisplayMember = "Descripcion";
            cboCriterio.ValueMember = "Id";
        }
        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboCriterio.DataSource = null;

                string opcion = cboCampo.SelectedItem.ToString();
                if (opcion == "Código" || opcion == "Nombre" || opcion == "Descripción")
                {
                    txtFiltroAvanzado.Enabled = true;

                    cargarCriterioString();
                }
                else if (opcion == "Categoría")
                {
                    cargarCriterioCategoria();
                    txtFiltroAvanzado.Enabled = false;
                }
                else
                {
                    cargarCriterioMarca();
                    txtFiltroAvanzado.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar los criterios " + ex.Message);
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (cboCampo != null || cboCriterio != null)
                {
                    string campo = cboCampo.SelectedItem.ToString();
                    string criterio = cboCriterio.SelectedItem.ToString();
                    string filtro = txtFiltroAvanzado.Text;
                    dgvArticulos.DataSource = null;
                    dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
                    OcultarColumnas();
                }
                else
                {
                    MessageBox.Show("Ingrese un campo y un criterio para buscar.", "Complete los campos",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
