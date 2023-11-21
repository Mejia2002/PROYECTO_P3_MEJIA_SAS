namespace PRESENTACION
{
    partial class FormPagoSueldo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDescargarPdf = new System.Windows.Forms.Button();
            this.cboTipoPagoSueldo = new System.Windows.Forms.ComboBox();
            this.txtFechaPagoPagoSueldo = new System.Windows.Forms.DateTimePicker();
            this.txtDetallesPagoSueldo = new System.Windows.Forms.TextBox();
            this.txtMontoPagadoPagoSueldo = new System.Windows.Forms.TextBox();
            this.txtPrimerApellidoEmpleadoPagoSueldo = new System.Windows.Forms.TextBox();
            this.txtPrimerNombreEmpleadoPagoSueldo = new System.Windows.Forms.TextBox();
            this.txtIdEmpleadoPagoSueldo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPagosSueldo = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnVerTodo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtBuscarIdPago = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosSueldo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDescargarPdf);
            this.groupBox1.Controls.Add(this.cboTipoPagoSueldo);
            this.groupBox1.Controls.Add(this.txtFechaPagoPagoSueldo);
            this.groupBox1.Controls.Add(this.txtDetallesPagoSueldo);
            this.groupBox1.Controls.Add(this.txtMontoPagadoPagoSueldo);
            this.groupBox1.Controls.Add(this.txtPrimerApellidoEmpleadoPagoSueldo);
            this.groupBox1.Controls.Add(this.txtPrimerNombreEmpleadoPagoSueldo);
            this.groupBox1.Controls.Add(this.txtIdEmpleadoPagoSueldo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(392, 368);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DE PAGO";
            // 
            // btnDescargarPdf
            // 
            this.btnDescargarPdf.BackColor = System.Drawing.Color.Red;
            this.btnDescargarPdf.Location = new System.Drawing.Point(227, 322);
            this.btnDescargarPdf.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDescargarPdf.Name = "btnDescargarPdf";
            this.btnDescargarPdf.Size = new System.Drawing.Size(125, 35);
            this.btnDescargarPdf.TabIndex = 3;
            this.btnDescargarPdf.Text = "DESCARGAR PDF";
            this.btnDescargarPdf.UseVisualStyleBackColor = false;
            this.btnDescargarPdf.Click += new System.EventHandler(this.btnDescargarPdf_Click);
            // 
            // cboTipoPagoSueldo
            // 
            this.cboTipoPagoSueldo.FormattingEnabled = true;
            this.cboTipoPagoSueldo.Location = new System.Drawing.Point(184, 216);
            this.cboTipoPagoSueldo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboTipoPagoSueldo.Name = "cboTipoPagoSueldo";
            this.cboTipoPagoSueldo.Size = new System.Drawing.Size(166, 21);
            this.cboTipoPagoSueldo.TabIndex = 13;
            // 
            // txtFechaPagoPagoSueldo
            // 
            this.txtFechaPagoPagoSueldo.Location = new System.Drawing.Point(184, 180);
            this.txtFechaPagoPagoSueldo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFechaPagoPagoSueldo.Name = "txtFechaPagoPagoSueldo";
            this.txtFechaPagoPagoSueldo.Size = new System.Drawing.Size(167, 20);
            this.txtFechaPagoPagoSueldo.TabIndex = 12;
            // 
            // txtDetallesPagoSueldo
            // 
            this.txtDetallesPagoSueldo.Location = new System.Drawing.Point(184, 291);
            this.txtDetallesPagoSueldo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDetallesPagoSueldo.Name = "txtDetallesPagoSueldo";
            this.txtDetallesPagoSueldo.Size = new System.Drawing.Size(168, 20);
            this.txtDetallesPagoSueldo.TabIndex = 11;
            // 
            // txtMontoPagadoPagoSueldo
            // 
            this.txtMontoPagadoPagoSueldo.Location = new System.Drawing.Point(184, 251);
            this.txtMontoPagadoPagoSueldo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMontoPagadoPagoSueldo.Name = "txtMontoPagadoPagoSueldo";
            this.txtMontoPagadoPagoSueldo.Size = new System.Drawing.Size(168, 20);
            this.txtMontoPagadoPagoSueldo.TabIndex = 10;
            this.txtMontoPagadoPagoSueldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoPagadoPagoSueldo_KeyPress);
            // 
            // txtPrimerApellidoEmpleadoPagoSueldo
            // 
            this.txtPrimerApellidoEmpleadoPagoSueldo.Location = new System.Drawing.Point(184, 143);
            this.txtPrimerApellidoEmpleadoPagoSueldo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrimerApellidoEmpleadoPagoSueldo.Name = "txtPrimerApellidoEmpleadoPagoSueldo";
            this.txtPrimerApellidoEmpleadoPagoSueldo.Size = new System.Drawing.Size(168, 20);
            this.txtPrimerApellidoEmpleadoPagoSueldo.TabIndex = 9;
            this.txtPrimerApellidoEmpleadoPagoSueldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrimerApellidoEmpleadoPagoSueldo_KeyPress);
            // 
            // txtPrimerNombreEmpleadoPagoSueldo
            // 
            this.txtPrimerNombreEmpleadoPagoSueldo.Location = new System.Drawing.Point(184, 106);
            this.txtPrimerNombreEmpleadoPagoSueldo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrimerNombreEmpleadoPagoSueldo.Name = "txtPrimerNombreEmpleadoPagoSueldo";
            this.txtPrimerNombreEmpleadoPagoSueldo.Size = new System.Drawing.Size(168, 20);
            this.txtPrimerNombreEmpleadoPagoSueldo.TabIndex = 8;
            this.txtPrimerNombreEmpleadoPagoSueldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrimerNombreEmpleadoPagoSueldo_KeyPress);
            // 
            // txtIdEmpleadoPagoSueldo
            // 
            this.txtIdEmpleadoPagoSueldo.Location = new System.Drawing.Point(184, 66);
            this.txtIdEmpleadoPagoSueldo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdEmpleadoPagoSueldo.Name = "txtIdEmpleadoPagoSueldo";
            this.txtIdEmpleadoPagoSueldo.Size = new System.Drawing.Size(168, 20);
            this.txtIdEmpleadoPagoSueldo.TabIndex = 7;
            this.txtIdEmpleadoPagoSueldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdEmpleadoPagoSueldo_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 291);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "DETALLES:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 254);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "VALOR A PAGAR:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 217);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "TIPO DE PAGO :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "FECHA DE PAGO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "PRIMER APELLIDO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "PRIMER NOMBRE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IDENTIFICACION:";
            // 
            // dgvPagosSueldo
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPagosSueldo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPagosSueldo.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPagosSueldo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPagosSueldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPagosSueldo.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPagosSueldo.EnableHeadersVisualStyles = false;
            this.dgvPagosSueldo.Location = new System.Drawing.Point(461, 114);
            this.dgvPagosSueldo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPagosSueldo.Name = "dgvPagosSueldo";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPagosSueldo.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPagosSueldo.Size = new System.Drawing.Size(768, 330);
            this.dgvPagosSueldo.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnModificar);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Location = new System.Drawing.Point(27, 435);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(391, 82);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnLimpiar.Location = new System.Drawing.Point(246, 31);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(106, 35);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnModificar.Location = new System.Drawing.Point(133, 31);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(106, 35);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnGuardar.Location = new System.Drawing.Point(20, 31);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(106, 35);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnBuscar.Location = new System.Drawing.Point(574, 450);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 35);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnVerTodo
            // 
            this.btnVerTodo.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVerTodo.Location = new System.Drawing.Point(461, 450);
            this.btnVerTodo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnVerTodo.Name = "btnVerTodo";
            this.btnVerTodo.Size = new System.Drawing.Size(106, 35);
            this.btnVerTodo.TabIndex = 4;
            this.btnVerTodo.Text = "VER TODO";
            this.btnVerTodo.UseVisualStyleBackColor = false;
            this.btnVerTodo.Click += new System.EventHandler(this.btnVerTodo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(1123, 449);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(106, 35);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(1123, 487);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(106, 35);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "VOLVER";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtBuscarIdPago
            // 
            this.txtBuscarIdPago.Location = new System.Drawing.Point(687, 460);
            this.txtBuscarIdPago.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscarIdPago.Name = "txtBuscarIdPago";
            this.txtBuscarIdPago.Size = new System.Drawing.Size(128, 20);
            this.txtBuscarIdPago.TabIndex = 7;
            // 
            // FormPagoSueldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1252, 536);
            this.Controls.Add(this.txtBuscarIdPago);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnVerTodo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvPagosSueldo);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormPagoSueldo";
            this.Text = "PAGAR SUELDO";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosSueldo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPagosSueldo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnVerTodo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTipoPagoSueldo;
        private System.Windows.Forms.DateTimePicker txtFechaPagoPagoSueldo;
        private System.Windows.Forms.TextBox txtDetallesPagoSueldo;
        private System.Windows.Forms.TextBox txtMontoPagadoPagoSueldo;
        private System.Windows.Forms.TextBox txtPrimerApellidoEmpleadoPagoSueldo;
        private System.Windows.Forms.TextBox txtPrimerNombreEmpleadoPagoSueldo;
        private System.Windows.Forms.TextBox txtIdEmpleadoPagoSueldo;
        private System.Windows.Forms.TextBox txtBuscarIdPago;
        private System.Windows.Forms.Button btnDescargarPdf;
    }
}