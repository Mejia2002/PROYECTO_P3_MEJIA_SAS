using ENTIDADES;
using LOGICA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;

namespace PRESENTACION
{
    public partial class FormContrato : Form
    {
        public FormContrato()
        {
            InitializeComponent();
            cboCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoContrato.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarComboBox();
        }

        private void btnGuargar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Empleado empleado = new Empleado
                {
                    Identificacion = txtIdentificacion.Text,
                    PrimerNombre = txtPrimerNombre.Text,
                    SegundoNombre = txtSegundoNombre.Text,
                    PrimerApellido = txtPrimerApellido.Text,
                    SegundoApellido = txtSegundoApellido.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    FechaInicio = txtFecha.Value,
                    Cargo = cboCargo.SelectedItem.ToString(),
                    TipoContrato = cboTipoContrato.SelectedItem.ToString(),
                    Salario = Convert.ToDouble(txtSalario.Text)
                };

                EmpleadoLogica.AgregarEmpleado(empleado);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarComboBox()
        {
            cboCargo.Items.AddRange(new string[] { "Siso", "Obrero", "Guadañador", "Conductor" });
            cboTipoContrato.Items.Add("Indefinido");
        }



        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtIdentificacion.Text) &&
                   !string.IsNullOrWhiteSpace(txtPrimerNombre.Text) &&
                   !string.IsNullOrWhiteSpace(txtPrimerApellido.Text) &&
                   !string.IsNullOrWhiteSpace(txtSalario.Text);
        }

        private void LimpiarCampos()
        {
            txtIdentificacion.Clear();
            txtPrimerNombre.Clear();
            txtSegundoNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtFecha.Value = DateTime.Now;
            cboCargo.SelectedIndex = -1;
            cboTipoContrato.SelectedIndex = -1;
            txtSalario.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    Empleado empleado = new Empleado
                    {
                        Identificacion = txtIdentificacion.Text,
                        PrimerNombre = txtPrimerNombre.Text,
                        SegundoNombre = txtSegundoNombre.Text,
                        PrimerApellido = txtPrimerApellido.Text,
                        SegundoApellido = txtSegundoApellido.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        FechaInicio = txtFecha.Value,
                        Cargo = cboCargo.SelectedItem.ToString(),
                        TipoContrato = cboTipoContrato.SelectedItem.ToString(),
                        Salario = Convert.ToDouble(txtSalario.Text)
                    };

                    using (SaveFileDialog sfd = new SaveFileDialog
                    {
                        Filter = "Archivos PDF|*.pdf",
                        FileName = $"contrato_{empleado.PrimerNombre}_{empleado.PrimerApellido}_{DateTime.Now:yyyyMMddHHmmss}.pdf",
                        ValidateNames = true
                    })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string rutaPDF = sfd.FileName;

                            using (PdfDocument pdf = new PdfDocument())
                            {
                                PdfPage page = pdf.AddPage();
                                XGraphics gfx = XGraphics.FromPdfPage(page);
                                XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
                                XRect rect = new XRect(10, 10, page.Width, page.Height);
                                XTextFormatter tf = new XTextFormatter(gfx);
                                tf.DrawString("Información del Contrato", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 30, page.Width, page.Height);
                                tf.DrawString($"- Empresa: Mejía SAS", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 50, page.Width, page.Height);
                                tf.DrawString($"- Actividad de la Empresa: Mantenimiento Vial", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 70, page.Width, page.Height);
                                tf.DrawString($"- Horario de Trabajo: Lunes a Viernes de 6:30 am a 4:00 pm (con almuerzo de 12:00 pm a 2:00 pm), Sábados hasta las 12:00 pm.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 110, page.Width, page.Height);
                                tf.DrawString($"- Forma de Pago de la Liquidación: La liquidación se paga mediante la fórmula (Sueldo * Días Trabajados) / 360.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 150, page.Width, page.Height);
                                tf.DrawString($"- La liquidacion se pagara cada 6 meses.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 170, page.Width, page.Height);
                                tf.DrawString($"- El pago del sueldo es quincenaL.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 190, page.Width, page.Height);
                                tf.DrawString($"- Derecho a Afiliación: El empleado tiene derecho a ser afiliado", font, XBrushes.Black, rect, XStringFormats.TopLeft);


                                rect = new XRect(10, 220, page.Width, page.Height);
                                tf.DrawString("Información del Empleado", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 240, page.Width, page.Height);
                                tf.DrawString($"Identificación: {empleado.Identificacion}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 260, page.Width, page.Height);
                                tf.DrawString($"Nombre: {empleado.PrimerNombre} {empleado.SegundoNombre} {empleado.PrimerApellido} {empleado.SegundoApellido}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 280, page.Width, page.Height);
                                tf.DrawString($"Teléfono: {empleado.Telefono}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 300, page.Width, page.Height);
                                tf.DrawString($"Correo: {empleado.Correo}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 320, page.Width, page.Height);
                                tf.DrawString($"Fecha de Inicio: {empleado.FechaInicio.ToShortDateString()}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 340, page.Width, page.Height);
                                tf.DrawString($"Cargo: {empleado.Cargo}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 360, page.Width, page.Height);
                                tf.DrawString($"Tipo de Contrato: {empleado.TipoContrato}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 380, page.Width, page.Height);
                                tf.DrawString($"Salario: {empleado.Salario}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 450, page.Width, page.Height);
                                tf.DrawString("Firma del Empleado: _________________________", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                pdf.Save(rutaPDF);
                            }

                            MessageBox.Show($"PDF generado y guardado como {rutaPDF}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }

}






