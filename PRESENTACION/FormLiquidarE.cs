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
    public partial class FormLiquidarE : Form
    {
        private LiquidacionLogica liquidacionLogica;
        public FormLiquidarE(string identificacion, string primerNombre, string primerApellido, DateTime fechaInicio, DateTime fechaFin)
        {
            InitializeComponent();
            liquidacionLogica = new LiquidacionLogica();
            cboTipoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoPago.Items.Add("Liquidación");
            cboTipoPago.SelectedIndex = 0;
            txtIdEmpleado.Text = identificacion;
            txtPrimerNombreEmpleado.Text = primerNombre;
            txtPrimerApellidoEmpleado.Text = primerApellido;
            txtFechaInicioL.Value = fechaInicio;
            txtFechaFin.Value = fechaFin;

            Liquidacion liquidacionCalculo = new Liquidacion
            {
                FechaInicio = fechaInicio,
                FechaFin = fechaFin
            };
            LiquidacionLogica.CalcularDiasYMontos(liquidacionCalculo);

            txtDiasTrabajados.Text = liquidacionCalculo.DiasTrabajados.ToString();
            txtTotalPagar.Text = liquidacionCalculo.MontoPagado.ToString("C");

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                string textoMonto = txtTotalPagar.Text.Trim().Replace("$", "").Replace(",", "");
                double montoPagado;
                double.TryParse(textoMonto, out montoPagado);
                if (ValidarCampos())
                {
                    Liquidacion liquidacion = new Liquidacion
                    {
                        IdEmpleado = txtIdEmpleado.Text.Trim(),
                        PrimerNombreEmpleado = txtPrimerNombreEmpleado.Text.Trim(),
                        PrimerApellidoEmpleado = txtPrimerApellidoEmpleado.Text.Trim(),
                        FechaPago = txtFechaPago.Value,
                        TipoPago = cboTipoPago.SelectedItem?.ToString(),
                        FechaInicio = txtFechaInicioL.Value,
                        FechaFin = txtFechaFin.Value,
                        DiasTrabajados = Convert.ToInt32(txtDiasTrabajados.Text.Trim()),
                        MontoPagado = montoPagado,
                        Detalles = txtDetalles.Text.Trim(),

                    };

                    using (SaveFileDialog sfd = new SaveFileDialog
                    {
                        Filter = "Archivos PDF|*.pdf",
                        FileName = $"liquidacion_{liquidacion.PrimerNombreEmpleado}_{liquidacion.PrimerApellidoEmpleado}_{DateTime.Now:yyyyMMddHHmmss}.pdf",
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
                                tf.DrawString("Información de la Liquidación", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 30, page.Width, page.Height);
                                tf.DrawString($"- Fecha de Pago: {liquidacion.FechaPago.ToShortDateString()}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 50, page.Width, page.Height);
                                tf.DrawString($"- Tipo de Pago: {liquidacion.TipoPago}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 70, page.Width, page.Height);
                                tf.DrawString($"- Fecha de Inicio: {liquidacion.FechaInicio.ToShortDateString()}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 90, page.Width, page.Height);
                                tf.DrawString($"- Fecha de Fin: {liquidacion.FechaFin.ToShortDateString()}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 110, page.Width, page.Height);
                                tf.DrawString($"- Días Trabajados: {liquidacion.DiasTrabajados}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 130, page.Width, page.Height);
                                tf.DrawString($"- Monto Pagado: {liquidacion.MontoPagado}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 150, page.Width, page.Height);
                                tf.DrawString($"- Detalles: {liquidacion.Detalles}", font, XBrushes.Black, rect, XStringFormats.TopLeft);


                                rect = new XRect(10, 220, page.Width, page.Height);
                                tf.DrawString("Información del Empleado", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 240, page.Width, page.Height);
                                tf.DrawString($"- Identificación: {liquidacion.IdEmpleado}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 260, page.Width, page.Height);
                                tf.DrawString($"- Primer nombre: {liquidacion.PrimerNombreEmpleado}", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                                rect = new XRect(10, 280, page.Width, page.Height);
                                tf.DrawString($"- Primer apellido: {liquidacion.PrimerApellidoEmpleado}", font, XBrushes.Black, rect, XStringFormats.TopLeft);


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

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtIdEmpleado.Text) ||
                string.IsNullOrWhiteSpace(txtPrimerNombreEmpleado.Text) ||
                string.IsNullOrWhiteSpace(txtPrimerApellidoEmpleado.Text) ||
                string.IsNullOrWhiteSpace(txtFechaPago.Text) ||
                cboTipoPago.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtFechaInicioL.Text) ||
                string.IsNullOrWhiteSpace(txtFechaFin.Text) ||
                string.IsNullOrWhiteSpace(txtDiasTrabajados.Text) ||
                string.IsNullOrWhiteSpace(txtTotalPagar.Text))

            {
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string idEmpleado = txtIdEmpleado.Text.Trim();
            string primerNombreEmpleado = txtPrimerNombreEmpleado.Text.Trim();
            string primerApellidoEmpleado = txtPrimerApellidoEmpleado.Text.Trim();
            DateTime fechaPago = txtFechaPago.Value;
            DateTime fechaInicio = txtFechaInicioL.Value;
            DateTime fechaFin = txtFechaFin.Value;
            string tipoPago = cboTipoPago.SelectedItem?.ToString();
            string detalles = txtDetalles.Text.Trim();

            if (!string.IsNullOrEmpty(idEmpleado) &&
                !string.IsNullOrEmpty(primerNombreEmpleado) &&
                !string.IsNullOrEmpty(primerApellidoEmpleado) &&
                fechaPago != DateTime.MinValue &&
                fechaInicio != DateTime.MinValue &&
                fechaFin != DateTime.MinValue &&
                !string.IsNullOrEmpty(tipoPago))
            {
                if (fechaInicio <= fechaFin)
                {
                    Empleado empleadoExistente = EmpleadoLogica.BuscarEmpleadoPorIdentificacion(idEmpleado);

                    if (empleadoExistente != null)
                    {
                        Liquidacion nuevaLiquidacion = new Liquidacion
                        {
                            IdEmpleado = idEmpleado,
                            PrimerNombreEmpleado = primerNombreEmpleado,
                            PrimerApellidoEmpleado = primerApellidoEmpleado,
                            FechaPago = fechaPago,
                            FechaInicio = fechaInicio,
                            FechaFin = fechaFin,
                            TipoPago = tipoPago,
                            Detalles = detalles
                        };

                        DialogResult result = MessageBox.Show("¿Está seguro de guardar esta liquidación?", "Confirmar Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                LiquidacionLogica.GuardarLiquidacion(nuevaLiquidacion);

                                MessageBox.Show("Liquidación guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al guardar la liquidación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("La fecha de inicio debe ser menor o igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos obligatorios deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = txtFechaInicioL.Value;
            DateTime fechaFin = txtFechaFin.Value;

            if (fechaInicio <= fechaFin)
            {
                string idEmpleado = txtIdEmpleado.Text.Trim();

                if (!string.IsNullOrEmpty(idEmpleado))
                {
                    Empleado empleadoExistente = EmpleadoLogica.BuscarEmpleadoPorIdentificacion(idEmpleado);

                    if (empleadoExistente != null)
                    {
                        if (empleadoExistente.Salario > 0)
                        {
                            Liquidacion liquidacionCalculo = new Liquidacion
                            {
                                IdEmpleado = idEmpleado,
                                FechaInicio = fechaInicio,
                                FechaFin = fechaFin
                            };
                            LiquidacionLogica.CalcularDiasYMontos(liquidacionCalculo);

                            txtDiasTrabajados.Text = liquidacionCalculo.DiasTrabajados.ToString();
                            txtTotalPagar.Text = liquidacionCalculo.MontoPagado.ToString("C");
                        }
                        else
                        {
                            MessageBox.Show("El empleado no tiene un salario registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El empleado con la identificación proporcionada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese una identificación válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La fecha de inicio debe ser menor o igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
