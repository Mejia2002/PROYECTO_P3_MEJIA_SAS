using ENTIDADES;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using LOGICA;

namespace PRESENTACION
{
    public partial class FormPagar : Form
    {
        private PagoSueldoLogica pagoSueldoLogica;
        public FormPagar(string identificacion, string primerNombre, string primerApellido, double salario)
        {
            pagoSueldoLogica = new PagoSueldoLogica();
            InitializeComponent();
            cboTipoPagoSueldo.Items.Add("Pago de sueldo");
            cboTipoPagoSueldo.SelectedIndex = 0;
            cboTipoPagoSueldo.DropDownStyle = ComboBoxStyle.DropDownList;

            double quincena = salario / 2;
            txtIdEmpleadoPagoSueldo.Text = identificacion;
            txtPrimerNombreEmpleadoPagoSueldo.Text = primerNombre;
            txtPrimerApellidoEmpleadoPagoSueldo.Text = primerApellido;
            txtMontoPagadoPagoSueldo.Text = quincena.ToString("N2");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposPagoSueldo())
                {
                    PagoSueldo pagoSueldo = new PagoSueldo
                    {
                        IdEmpleado = txtIdEmpleadoPagoSueldo.Text.Trim(),
                        PrimerNombreEmpleado = txtPrimerNombreEmpleadoPagoSueldo.Text.Trim(),
                        PrimerApellidoEmpleado = txtPrimerApellidoEmpleadoPagoSueldo.Text.Trim(),
                        FechaPago = txtFechaPagoPagoSueldo.Value,
                        TipoPago = cboTipoPagoSueldo.SelectedItem?.ToString(),
                        MontoPagado = Convert.ToDouble(txtMontoPagadoPagoSueldo.Text.Trim()),
                        Detalles = txtDetallesPagoSueldo.Text.Trim(),
                    };

                    using (SaveFileDialog sfd = new SaveFileDialog
                    {
                        Filter = "Archivos PDF|*.pdf",
                        FileName = $"pagoSueldo_{pagoSueldo.PrimerNombreEmpleado}_{pagoSueldo.PrimerApellidoEmpleado}_{DateTime.Now:yyyyMMddHHmmss}.pdf",
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

                                tf.DrawString("Información de la Empresa", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 30, page.Width, page.Height);
                                tf.DrawString($"- Nombre: [Mejia SAS]", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 50, page.Width, page.Height);
                                tf.DrawString($"- Dirección: [CUATRO VIENTOS CESAR]", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 70, page.Width, page.Height);
                                tf.DrawString($"- Teléfono: [018000145]", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 90, page.Width, page.Height);
                                tf.DrawString($"- Email: [mejiasas@hotmail.com]", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 130, page.Width, page.Height);
                                tf.DrawString("Información del Pago de Sueldo", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 150, page.Width, page.Height);
                                tf.DrawString($"- Fecha de Pago: {pagoSueldo.FechaPago.ToShortDateString()}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 170, page.Width, page.Height);
                                tf.DrawString($"- Tipo de Pago: {pagoSueldo.TipoPago}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 190, page.Width, page.Height);
                                tf.DrawString($"- Monto Pagado: {pagoSueldo.MontoPagado}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 210, page.Width, page.Height);
                                tf.DrawString($"- Detalles: {pagoSueldo.Detalles}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 300, page.Width, page.Height);
                                tf.DrawString("Información del Empleado", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 320, page.Width, page.Height);
                                tf.DrawString($"- Identificación: {pagoSueldo.IdEmpleado}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 340, page.Width, page.Height);
                                tf.DrawString($"- Primer nombre: {pagoSueldo.PrimerNombreEmpleado}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 360, page.Width, page.Height);
                                tf.DrawString($"- Primer apellido: {pagoSueldo.PrimerApellidoEmpleado}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 480, page.Width, page.Height);
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

        private bool ValidarCamposPagoSueldo()
        {
            string idEmpleado = txtIdEmpleadoPagoSueldo.Text.Trim();
            string primerNombreEmpleado = txtPrimerNombreEmpleadoPagoSueldo.Text.Trim();
            string primerApellidoEmpleado = txtPrimerApellidoEmpleadoPagoSueldo.Text.Trim();
            DateTime fechaPago = txtFechaPagoPagoSueldo.Value;
            string tipoPago = cboTipoPagoSueldo.SelectedItem?.ToString();
            double montoPagado;

            if (string.IsNullOrWhiteSpace(idEmpleado) ||
                string.IsNullOrWhiteSpace(primerNombreEmpleado) ||
                string.IsNullOrWhiteSpace(primerApellidoEmpleado) ||
                fechaPago == DateTime.MinValue ||
                string.IsNullOrWhiteSpace(tipoPago) ||
                !double.TryParse(txtMontoPagadoPagoSueldo.Text.Trim(), out montoPagado))
            {
                MessageBox.Show("Todos los campos obligatorios deben estar llenos y en el formato correcto.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string idEmpleado = txtIdEmpleadoPagoSueldo.Text.Trim();
            string primerNombreEmpleado = txtPrimerNombreEmpleadoPagoSueldo.Text.Trim();
            string primerApellidoEmpleado = txtPrimerApellidoEmpleadoPagoSueldo.Text.Trim();
            DateTime fechaPago = txtFechaPagoPagoSueldo.Value;
            string tipoPago = cboTipoPagoSueldo.SelectedItem?.ToString();
            if (double.TryParse(txtMontoPagadoPagoSueldo.Text.Trim(), out double montoPagado))
            {
                string detalles = txtDetallesPagoSueldo.Text.Trim();

                if (ValidarCamposPagoSueldo())
                {
                    if (fechaPago <= DateTime.Now)
                    {
                        if (pagoSueldoLogica.ExisteEmpleado(idEmpleado))
                        {
                            PagoSueldo nuevoPagoSueldo = new PagoSueldo
                            {
                                IdEmpleado = idEmpleado,
                                PrimerNombreEmpleado = primerNombreEmpleado,
                                PrimerApellidoEmpleado = primerApellidoEmpleado,
                                FechaPago = fechaPago,
                                TipoPago = tipoPago,
                                MontoPagado = montoPagado,
                                Detalles = detalles
                            };

                            DialogResult result = MessageBox.Show("¿Está seguro de guardar este pago de sueldo?", "Confirmar Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                try
                                {
                                    PagoSueldoLogica.GuardarPagoSueldo(nuevoPagoSueldo);

                                    MessageBox.Show("Pago de sueldo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error al guardar el pago de sueldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El empleado con la identificación proporcionada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La fecha de pago no puede ser en el futuro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos obligatorios deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El monto a pagar no tiene un formato válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
