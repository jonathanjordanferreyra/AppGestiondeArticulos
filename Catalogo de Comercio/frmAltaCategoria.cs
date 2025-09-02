using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo_de_Comercio
{
    public partial class frmAltaCategoria : Form
    {

        public frmAltaCategoria()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria NuevaCategoria = new Categoria();
            NuevaCategoria.Descripcion = txtCategoria.Text;
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                negocio.Agregar(NuevaCategoria);
                MessageBox.Show("Se agregó la categoría");
                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();   

        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            if (txtCategoria.Text != "")
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }
    }
}
