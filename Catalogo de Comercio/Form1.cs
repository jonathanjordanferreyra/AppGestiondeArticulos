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

            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                CargarImagen(seleccionado.ImagenUrl);
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
                pbxArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/2560px-Placeholder_view_vector.svg.png");
            }
            catch (System.Net.WebException)
            {
                //Aca me da error de web 403, creo que no es un problema con mi codigo, si no con la URL de la base de datos.
                MessageBox.Show("No se pudo cargar la imagen (Error 403 Servidor remoto), se muestra una por defecto...");
                pbxArticulo.Load("https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.ToString()));  
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio cargar = new ArticuloNegocio();
            frmAltaArticulo Alta = new frmAltaArticulo();
            Alta.ShowDialog();
            dgvArticulos.DataSource = cargar.Listar();
        }
    }
}
