using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo_de_Comercio
{
    public partial class frmAltaMarca : Form
    {
        public frmAltaMarca()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Marca nuevaMarca = new Marca();
            nuevaMarca.Descripcion = txtMarca.Text;
            MarcaNegocio negocioMarca = new MarcaNegocio();
            try
            {
                negocioMarca.Agregar(nuevaMarca);
                MessageBox.Show("Se agregó la marca");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            if (txtMarca.Text != "")
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
