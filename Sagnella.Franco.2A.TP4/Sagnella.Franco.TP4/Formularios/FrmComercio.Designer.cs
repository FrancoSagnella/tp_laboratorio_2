namespace Formularios
{
    partial class FrmComercio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grillaInventario = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblAgregar = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCrearCarrito = new System.Windows.Forms.Button();
            this.btnAgregarCarrito = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.imgPublicidad = new System.Windows.Forms.PictureBox();
            this.lblCarrito = new System.Windows.Forms.Label();
            this.lblPublicidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPublicidad)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaInventario
            // 
            this.grillaInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaInventario.Location = new System.Drawing.Point(336, 12);
            this.grillaInventario.Name = "grillaInventario";
            this.grillaInventario.Size = new System.Drawing.Size(510, 335);
            this.grillaInventario.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 307);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(88, 42);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar productos";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblAgregar
            // 
            this.lblAgregar.AutoSize = true;
            this.lblAgregar.Location = new System.Drawing.Point(24, 291);
            this.lblAgregar.Name = "lblAgregar";
            this.lblAgregar.Size = new System.Drawing.Size(101, 13);
            this.lblAgregar.TabIndex = 2;
            this.lblAgregar.Text = "Gestionar inventario";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(118, 307);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(88, 40);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar productos";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(223, 304);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 43);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar productos";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCrearCarrito
            // 
            this.btnCrearCarrito.Location = new System.Drawing.Point(12, 29);
            this.btnCrearCarrito.Name = "btnCrearCarrito";
            this.btnCrearCarrito.Size = new System.Drawing.Size(298, 22);
            this.btnCrearCarrito.TabIndex = 5;
            this.btnCrearCarrito.Text = "Crear carrito de compra";
            this.btnCrearCarrito.UseVisualStyleBackColor = true;
            this.btnCrearCarrito.Click += new System.EventHandler(this.btnCrearCarrito_Click);
            // 
            // btnAgregarCarrito
            // 
            this.btnAgregarCarrito.Location = new System.Drawing.Point(12, 57);
            this.btnAgregarCarrito.Name = "btnAgregarCarrito";
            this.btnAgregarCarrito.Size = new System.Drawing.Size(298, 26);
            this.btnAgregarCarrito.TabIndex = 6;
            this.btnAgregarCarrito.Text = "Agregar producto al carrito";
            this.btnAgregarCarrito.UseVisualStyleBackColor = true;
            this.btnAgregarCarrito.Click += new System.EventHandler(this.btnAgregarCarrito_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(13, 111);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(297, 23);
            this.btnHistorial.TabIndex = 8;
            this.btnHistorial.Text = "Ver historial de ventas";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // imgPublicidad
            // 
            this.imgPublicidad.Location = new System.Drawing.Point(68, 164);
            this.imgPublicidad.Name = "imgPublicidad";
            this.imgPublicidad.Size = new System.Drawing.Size(191, 124);
            this.imgPublicidad.TabIndex = 9;
            this.imgPublicidad.TabStop = false;
            // 
            // lblCarrito
            // 
            this.lblCarrito.AutoSize = true;
            this.lblCarrito.Location = new System.Drawing.Point(24, 9);
            this.lblCarrito.Name = "lblCarrito";
            this.lblCarrito.Size = new System.Drawing.Size(138, 13);
            this.lblCarrito.TabIndex = 10;
            this.lblCarrito.Text = "Gestionar Carrito de compra";
            // 
            // lblPublicidad
            // 
            this.lblPublicidad.AutoSize = true;
            this.lblPublicidad.Location = new System.Drawing.Point(133, 148);
            this.lblPublicidad.Name = "lblPublicidad";
            this.lblPublicidad.Size = new System.Drawing.Size(56, 13);
            this.lblPublicidad.TabIndex = 11;
            this.lblPublicidad.Text = "Publicidad";
            // 
            // FrmComercio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 361);
            this.Controls.Add(this.lblPublicidad);
            this.Controls.Add(this.lblCarrito);
            this.Controls.Add(this.imgPublicidad);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnAgregarCarrito);
            this.Controls.Add(this.btnCrearCarrito);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lblAgregar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grillaInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmComercio";
            this.Text = "Formulario Comercio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmComercio_FormClosing);
            this.Load += new System.EventHandler(this.FrmComercio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPublicidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaInventario;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCrearCarrito;
        private System.Windows.Forms.Button btnAgregarCarrito;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.PictureBox imgPublicidad;
        private System.Windows.Forms.Label lblCarrito;
        private System.Windows.Forms.Label lblPublicidad;
    }
}

