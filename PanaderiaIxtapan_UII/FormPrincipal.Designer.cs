namespace PanaderiaIxtapan_UII
{
    partial class FormPrincipal
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
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.moduloContableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarNuevaPartidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libroDiarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libroMayorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadosFinancierosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cierreMensualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularizaciónDeIVAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarCierreMensualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSku = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoItem = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAgregarInventario = new System.Windows.Forms.Button();
            this.btnEliminarInventario = new System.Windows.Forms.Button();
            this.btnEliminarInventari = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Location = new System.Drawing.Point(12, 46);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.Size = new System.Drawing.Size(528, 400);
            this.dgvCuentas.TabIndex = 0;
            this.dgvCuentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentas_CellContentClick);
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(546, 46);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(463, 400);
            this.dgvInventario.TabIndex = 1;
            this.dgvInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellClick);
            this.dgvInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moduloContableToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.cierreMensualToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1158, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // moduloContableToolStripMenuItem
            // 
            this.moduloContableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarNuevaPartidaToolStripMenuItem});
            this.moduloContableToolStripMenuItem.Name = "moduloContableToolStripMenuItem";
            this.moduloContableToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.moduloContableToolStripMenuItem.Text = "Modulo Contable";
            // 
            // registrarNuevaPartidaToolStripMenuItem
            // 
            this.registrarNuevaPartidaToolStripMenuItem.Name = "registrarNuevaPartidaToolStripMenuItem";
            this.registrarNuevaPartidaToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.registrarNuevaPartidaToolStripMenuItem.Text = "Registrar nueva partida";
            this.registrarNuevaPartidaToolStripMenuItem.Click += new System.EventHandler(this.registrarNuevaPartidaToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.libroDiarioToolStripMenuItem,
            this.libroMayorToolStripMenuItem,
            this.estadosFinancierosToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // libroDiarioToolStripMenuItem
            // 
            this.libroDiarioToolStripMenuItem.Name = "libroDiarioToolStripMenuItem";
            this.libroDiarioToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.libroDiarioToolStripMenuItem.Text = "Libro Diario";
            this.libroDiarioToolStripMenuItem.Click += new System.EventHandler(this.libroDiarioToolStripMenuItem_Click);
            // 
            // libroMayorToolStripMenuItem
            // 
            this.libroMayorToolStripMenuItem.Name = "libroMayorToolStripMenuItem";
            this.libroMayorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.libroMayorToolStripMenuItem.Text = "Libro Mayor";
            this.libroMayorToolStripMenuItem.Click += new System.EventHandler(this.libroMayorToolStripMenuItem_Click);
            // 
            // estadosFinancierosToolStripMenuItem
            // 
            this.estadosFinancierosToolStripMenuItem.Name = "estadosFinancierosToolStripMenuItem";
            this.estadosFinancierosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.estadosFinancierosToolStripMenuItem.Text = "Estados financieros";
            this.estadosFinancierosToolStripMenuItem.Click += new System.EventHandler(this.estadosFinancierosToolStripMenuItem_Click);
            // 
            // cierreMensualToolStripMenuItem
            // 
            this.cierreMensualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularizaciónDeIVAToolStripMenuItem,
            this.ejecutarCierreMensualToolStripMenuItem});
            this.cierreMensualToolStripMenuItem.Name = "cierreMensualToolStripMenuItem";
            this.cierreMensualToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.cierreMensualToolStripMenuItem.Text = "Cierre mensual";
            // 
            // regularizaciónDeIVAToolStripMenuItem
            // 
            this.regularizaciónDeIVAToolStripMenuItem.Name = "regularizaciónDeIVAToolStripMenuItem";
            this.regularizaciónDeIVAToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.regularizaciónDeIVAToolStripMenuItem.Text = "Regularización de IVA";
            this.regularizaciónDeIVAToolStripMenuItem.Click += new System.EventHandler(this.regularizaciónDeIVAToolStripMenuItem_Click);
            // 
            // ejecutarCierreMensualToolStripMenuItem
            // 
            this.ejecutarCierreMensualToolStripMenuItem.Name = "ejecutarCierreMensualToolStripMenuItem";
            this.ejecutarCierreMensualToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ejecutarCierreMensualToolStripMenuItem.Text = "Ejecutar cierre mensual";
            this.ejecutarCierreMensualToolStripMenuItem.Click += new System.EventHandler(this.ejecutarCierreMensualToolStripMenuItem_Click);
            // 
            // txtSku
            // 
            this.txtSku.Location = new System.Drawing.Point(44, 452);
            this.txtSku.Name = "txtSku";
            this.txtSku.Size = new System.Drawing.Size(100, 20);
            this.txtSku.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sku";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(81, 482);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descripcion";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(67, 518);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(100, 20);
            this.txtCosto.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 525);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Costo";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(291, 456);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Precio";
            // 
            // txtExistencia
            // 
            this.txtExistencia.Location = new System.Drawing.Point(291, 499);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(100, 20);
            this.txtExistencia.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 502);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Existencia";
            // 
            // cmbTipoItem
            // 
            this.cmbTipoItem.FormattingEnabled = true;
            this.cmbTipoItem.Items.AddRange(new object[] {
            "Insumo",
            "Producto"});
            this.cmbTipoItem.Location = new System.Drawing.Point(448, 481);
            this.cmbTipoItem.Name = "cmbTipoItem";
            this.cmbTipoItem.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoItem.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 459);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tipo";
            // 
            // btnAgregarInventario
            // 
            this.btnAgregarInventario.Location = new System.Drawing.Point(588, 459);
            this.btnAgregarInventario.Name = "btnAgregarInventario";
            this.btnAgregarInventario.Size = new System.Drawing.Size(163, 23);
            this.btnAgregarInventario.TabIndex = 15;
            this.btnAgregarInventario.Text = "Agregar al inventario";
            this.btnAgregarInventario.UseVisualStyleBackColor = true;
            this.btnAgregarInventario.Click += new System.EventHandler(this.btnAgregarInventario_Click);
            // 
            // btnEliminarInventario
            // 
            this.btnEliminarInventario.Location = new System.Drawing.Point(580, 521);
            this.btnEliminarInventario.Name = "btnEliminarInventario";
            this.btnEliminarInventario.Size = new System.Drawing.Size(184, 23);
            this.btnEliminarInventario.TabIndex = 16;
            this.btnEliminarInventario.Text = "Eliminar algo del inventario";
            this.btnEliminarInventario.UseVisualStyleBackColor = true;
            this.btnEliminarInventario.Click += new System.EventHandler(this.btnEliminarInventario_Click);
            // 
            // btnEliminarInventari
            // 
            this.btnEliminarInventari.Location = new System.Drawing.Point(580, 492);
            this.btnEliminarInventari.Name = "btnEliminarInventari";
            this.btnEliminarInventari.Size = new System.Drawing.Size(171, 23);
            this.btnEliminarInventari.TabIndex = 17;
            this.btnEliminarInventari.Text = "Editar inventario";
            this.btnEliminarInventari.UseVisualStyleBackColor = true;
            this.btnEliminarInventari.Click += new System.EventHandler(this.btnEliminarInventari_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 569);
            this.Controls.Add(this.btnEliminarInventari);
            this.Controls.Add(this.btnEliminarInventario);
            this.Controls.Add(this.btnAgregarInventario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTipoItem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtExistencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSku);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.dgvCuentas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem moduloContableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarNuevaPartidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem libroDiarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cierreMensualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularizaciónDeIVAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarCierreMensualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem libroMayorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadosFinancierosToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSku;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipoItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregarInventario;
        private System.Windows.Forms.Button btnEliminarInventario;
        private System.Windows.Forms.Button btnEliminarInventari;
    }
}