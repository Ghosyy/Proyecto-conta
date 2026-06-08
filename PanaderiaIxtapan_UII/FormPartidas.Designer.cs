namespace PanaderiaIxtapan_UII
{
    partial class FormPartidas
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
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.cmbCuentas = new System.Windows.Forms.ComboBox();
            this.txtDebe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHaber = new System.Windows.Forms.TextBox();
            this.btnAgregarFila = new System.Windows.Forms.Button();
            this.dgvDetallePartida = new System.Windows.Forms.DataGridView();
            this.lblTotalDebe = new System.Windows.Forms.Label();
            this.lblTotalHaber = new System.Windows.Forms.Label();
            this.btnGuardarPartida = new System.Windows.Forms.Button();
            this.txtNumeroPartida = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoPartida = new System.Windows.Forms.ComboBox();
            this.cmbTipoFactura = new System.Windows.Forms.ComboBox();
            this.txtTotalFactura = new System.Windows.Forms.TextBox();
            this.btnGenerarIVA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePartida)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(12, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(234, 12);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(288, 20);
            this.txtConcepto.TabIndex = 1;
            // 
            // cmbCuentas
            // 
            this.cmbCuentas.FormattingEnabled = true;
            this.cmbCuentas.Location = new System.Drawing.Point(538, 11);
            this.cmbCuentas.Name = "cmbCuentas";
            this.cmbCuentas.Size = new System.Drawing.Size(202, 21);
            this.cmbCuentas.TabIndex = 2;
            // 
            // txtDebe
            // 
            this.txtDebe.Location = new System.Drawing.Point(234, 69);
            this.txtDebe.Name = "txtDebe";
            this.txtDebe.Size = new System.Drawing.Size(135, 20);
            this.txtDebe.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Debe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Haber";
            // 
            // txtHaber
            // 
            this.txtHaber.Location = new System.Drawing.Point(391, 68);
            this.txtHaber.Name = "txtHaber";
            this.txtHaber.Size = new System.Drawing.Size(131, 20);
            this.txtHaber.TabIndex = 6;
            // 
            // btnAgregarFila
            // 
            this.btnAgregarFila.Location = new System.Drawing.Point(538, 66);
            this.btnAgregarFila.Name = "btnAgregarFila";
            this.btnAgregarFila.Size = new System.Drawing.Size(115, 23);
            this.btnAgregarFila.TabIndex = 7;
            this.btnAgregarFila.Text = "Agregar movimiento";
            this.btnAgregarFila.UseVisualStyleBackColor = true;
            this.btnAgregarFila.Click += new System.EventHandler(this.btnAgregarFila_Click);
            // 
            // dgvDetallePartida
            // 
            this.dgvDetallePartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePartida.Location = new System.Drawing.Point(12, 126);
            this.dgvDetallePartida.Name = "dgvDetallePartida";
            this.dgvDetallePartida.Size = new System.Drawing.Size(510, 361);
            this.dgvDetallePartida.TabIndex = 8;
            // 
            // lblTotalDebe
            // 
            this.lblTotalDebe.AutoSize = true;
            this.lblTotalDebe.Location = new System.Drawing.Point(25, 519);
            this.lblTotalDebe.Name = "lblTotalDebe";
            this.lblTotalDebe.Size = new System.Drawing.Size(87, 13);
            this.lblTotalDebe.TabIndex = 9;
            this.lblTotalDebe.Text = "Total Debe: 0.00";
            // 
            // lblTotalHaber
            // 
            this.lblTotalHaber.AutoSize = true;
            this.lblTotalHaber.Location = new System.Drawing.Point(136, 519);
            this.lblTotalHaber.Name = "lblTotalHaber";
            this.lblTotalHaber.Size = new System.Drawing.Size(90, 13);
            this.lblTotalHaber.TabIndex = 10;
            this.lblTotalHaber.Text = "Total Haber: 0.00";
            // 
            // btnGuardarPartida
            // 
            this.btnGuardarPartida.Location = new System.Drawing.Point(269, 514);
            this.btnGuardarPartida.Name = "btnGuardarPartida";
            this.btnGuardarPartida.Size = new System.Drawing.Size(142, 23);
            this.btnGuardarPartida.TabIndex = 11;
            this.btnGuardarPartida.Text = "Guardar partida completa";
            this.btnGuardarPartida.UseVisualStyleBackColor = true;
            this.btnGuardarPartida.Click += new System.EventHandler(this.btnGuardarPartida_Click);
            // 
            // txtNumeroPartida
            // 
            this.txtNumeroPartida.Location = new System.Drawing.Point(12, 69);
            this.txtNumeroPartida.Name = "txtNumeroPartida";
            this.txtNumeroPartida.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroPartida.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "N. Partida";
            // 
            // cmbTipoPartida
            // 
            this.cmbTipoPartida.FormattingEnabled = true;
            this.cmbTipoPartida.Items.AddRange(new object[] {
            "Diario",
            "Egreso",
            "Ingreso"});
            this.cmbTipoPartida.Location = new System.Drawing.Point(118, 69);
            this.cmbTipoPartida.Name = "cmbTipoPartida";
            this.cmbTipoPartida.Size = new System.Drawing.Size(94, 21);
            this.cmbTipoPartida.TabIndex = 14;
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.FormattingEnabled = true;
            this.cmbTipoFactura.Items.AddRange(new object[] {
            "Compra",
            "Venta"});
            this.cmbTipoFactura.Location = new System.Drawing.Point(538, 162);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoFactura.TabIndex = 15;
            // 
            // txtTotalFactura
            // 
            this.txtTotalFactura.Location = new System.Drawing.Point(553, 202);
            this.txtTotalFactura.Name = "txtTotalFactura";
            this.txtTotalFactura.Size = new System.Drawing.Size(100, 20);
            this.txtTotalFactura.TabIndex = 16;
            // 
            // btnGenerarIVA
            // 
            this.btnGenerarIVA.Location = new System.Drawing.Point(565, 237);
            this.btnGenerarIVA.Name = "btnGenerarIVA";
            this.btnGenerarIVA.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarIVA.TabIndex = 17;
            this.btnGenerarIVA.Text = "button1";
            this.btnGenerarIVA.UseVisualStyleBackColor = true;
            this.btnGenerarIVA.Click += new System.EventHandler(this.btnGenerarIVA_Click);
            // 
            // FormPartidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.btnGenerarIVA);
            this.Controls.Add(this.txtTotalFactura);
            this.Controls.Add(this.cmbTipoFactura);
            this.Controls.Add(this.cmbTipoPartida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumeroPartida);
            this.Controls.Add(this.btnGuardarPartida);
            this.Controls.Add(this.lblTotalHaber);
            this.Controls.Add(this.lblTotalDebe);
            this.Controls.Add(this.dgvDetallePartida);
            this.Controls.Add(this.btnAgregarFila);
            this.Controls.Add(this.txtHaber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDebe);
            this.Controls.Add(this.cmbCuentas);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.dtpFecha);
            this.Name = "FormPartidas";
            this.Text = "FormPartidas";
            this.Load += new System.EventHandler(this.FormPartidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePartida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.ComboBox cmbCuentas;
        private System.Windows.Forms.TextBox txtDebe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHaber;
        private System.Windows.Forms.Button btnAgregarFila;
        private System.Windows.Forms.DataGridView dgvDetallePartida;
        private System.Windows.Forms.Label lblTotalDebe;
        private System.Windows.Forms.Label lblTotalHaber;
        private System.Windows.Forms.Button btnGuardarPartida;
        private System.Windows.Forms.TextBox txtNumeroPartida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoPartida;
        private System.Windows.Forms.ComboBox cmbTipoFactura;
        private System.Windows.Forms.TextBox txtTotalFactura;
        private System.Windows.Forms.Button btnGenerarIVA;
    }
}