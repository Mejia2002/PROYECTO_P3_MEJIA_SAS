namespace PRESENTACION
{
    partial class FormNomina
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNomina = new System.Windows.Forms.DataGridView();
            this.btnBuscarIdPago = new System.Windows.Forms.Button();
            this.btnBuscarIdentificacion = new System.Windows.Forms.Button();
            this.txtBuscarIdPago = new System.Windows.Forms.TextBox();
            this.txtBuscarIdentificacion = new System.Windows.Forms.TextBox();
            this.btnVerTodo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNomina
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvNomina.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNomina.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNomina.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNomina.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNomina.EnableHeadersVisualStyles = false;
            this.dgvNomina.Location = new System.Drawing.Point(13, 93);
            this.dgvNomina.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvNomina.Name = "dgvNomina";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNomina.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNomina.Size = new System.Drawing.Size(947, 412);
            this.dgvNomina.TabIndex = 0;
            // 
            // btnBuscarIdPago
            // 
            this.btnBuscarIdPago.BackColor = System.Drawing.Color.PowderBlue;
            this.btnBuscarIdPago.Location = new System.Drawing.Point(4, 26);
            this.btnBuscarIdPago.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscarIdPago.Name = "btnBuscarIdPago";
            this.btnBuscarIdPago.Size = new System.Drawing.Size(134, 40);
            this.btnBuscarIdPago.TabIndex = 1;
            this.btnBuscarIdPago.Text = "BUSCAR ID PAGO";
            this.btnBuscarIdPago.UseVisualStyleBackColor = false;
            this.btnBuscarIdPago.Click += new System.EventHandler(this.btnBuscarIdPago_Click);
            // 
            // btnBuscarIdentificacion
            // 
            this.btnBuscarIdentificacion.BackColor = System.Drawing.Color.PowderBlue;
            this.btnBuscarIdentificacion.Location = new System.Drawing.Point(348, 25);
            this.btnBuscarIdentificacion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscarIdentificacion.Name = "btnBuscarIdentificacion";
            this.btnBuscarIdentificacion.Size = new System.Drawing.Size(181, 40);
            this.btnBuscarIdentificacion.TabIndex = 2;
            this.btnBuscarIdentificacion.Text = "BUSCAR IDENTIFICACION";
            this.btnBuscarIdentificacion.UseVisualStyleBackColor = false;
            this.btnBuscarIdentificacion.Click += new System.EventHandler(this.btnBuscarIdentificacion_Click);
            // 
            // txtBuscarIdPago
            // 
            this.txtBuscarIdPago.Location = new System.Drawing.Point(145, 43);
            this.txtBuscarIdPago.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscarIdPago.Name = "txtBuscarIdPago";
            this.txtBuscarIdPago.Size = new System.Drawing.Size(154, 20);
            this.txtBuscarIdPago.TabIndex = 3;
            this.txtBuscarIdPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarIdPago_KeyPress);
            // 
            // txtBuscarIdentificacion
            // 
            this.txtBuscarIdentificacion.Location = new System.Drawing.Point(536, 43);
            this.txtBuscarIdentificacion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscarIdentificacion.Name = "txtBuscarIdentificacion";
            this.txtBuscarIdentificacion.Size = new System.Drawing.Size(154, 20);
            this.txtBuscarIdentificacion.TabIndex = 4;
            this.txtBuscarIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarIdentificacion_KeyPress);
            // 
            // btnVerTodo
            // 
            this.btnVerTodo.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVerTodo.Location = new System.Drawing.Point(760, 36);
            this.btnVerTodo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnVerTodo.Name = "btnVerTodo";
            this.btnVerTodo.Size = new System.Drawing.Size(130, 39);
            this.btnVerTodo.TabIndex = 5;
            this.btnVerTodo.Text = "VER TODO";
            this.btnVerTodo.UseVisualStyleBackColor = false;
            this.btnVerTodo.Click += new System.EventHandler(this.btnVerTodo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBuscarIdentificacion);
            this.groupBox1.Controls.Add(this.txtBuscarIdPago);
            this.groupBox1.Controls.Add(this.btnBuscarIdentificacion);
            this.groupBox1.Controls.Add(this.btnBuscarIdPago);
            this.groupBox1.Location = new System.Drawing.Point(30, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(716, 72);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSalir.Location = new System.Drawing.Point(829, 511);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(130, 39);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "VOLVER";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Lime;
            this.btnExportar.Location = new System.Drawing.Point(691, 511);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(130, 39);
            this.btnExportar.TabIndex = 8;
            this.btnExportar.Text = "Exportar a Excel";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // FormNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1006, 554);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVerTodo);
            this.Controls.Add(this.dgvNomina);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormNomina";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNomina;
        private System.Windows.Forms.Button btnBuscarIdPago;
        private System.Windows.Forms.Button btnBuscarIdentificacion;
        private System.Windows.Forms.TextBox txtBuscarIdPago;
        private System.Windows.Forms.TextBox txtBuscarIdentificacion;
        private System.Windows.Forms.Button btnVerTodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnExportar;
    }
}