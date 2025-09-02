namespace Catalogo_de_Comercio
{
    partial class frmAltaCategoria
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnAgregar.Location = new System.Drawing.Point(103, 255);
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
            this.btnCancelar.Location = new System.Drawing.Point(216, 255);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 37);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(103, 175);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(222, 22);
            this.txtCategoria.TabIndex = 0;
            this.txtCategoria.TextChanged += new System.EventHandler(this.txtCategoria_TextChanged);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.BackColor = System.Drawing.Color.Silver;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCategoria.Location = new System.Drawing.Point(133, 90);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(159, 25);
            this.lblCategoria.TabIndex = 3;
            this.lblCategoria.Text = "Nueva Categoría:";
            // 
            // frmAltaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(427, 406);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(445, 453);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(445, 453);
            this.Name = "frmAltaCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Categoría";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lblCategoria;
    }
}