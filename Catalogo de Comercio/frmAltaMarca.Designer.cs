namespace Catalogo_de_Comercio
{
    partial class frmAltaMarca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.BackColor = System.Drawing.Color.Silver;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMarca.Location = new System.Drawing.Point(147, 93);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(130, 25);
            this.lblMarca.TabIndex = 4;
            this.lblMarca.Text = "Nueva Marca:";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(100, 172);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(225, 22);
            this.txtMarca.TabIndex = 0;
            this.txtMarca.TextChanged += new System.EventHandler(this.txtMarca_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnAgregar.Location = new System.Drawing.Point(100, 251);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(109, 37);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancelar.Location = new System.Drawing.Point(216, 251);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 37);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAltaMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(427, 406);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblMarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(445, 453);
            this.MinimumSize = new System.Drawing.Size(445, 453);
            this.Name = "frmAltaMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Nueva Marca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
    }
}