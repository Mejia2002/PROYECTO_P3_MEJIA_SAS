using ENTIDADES;
using LOGICA;
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

namespace PRESENTACION
{
    public partial class FormPagoSueldo : Form
    {
        private PagoSueldoLogica pagoSueldoLogica;
        public FormPagoSueldo(string identificacion, string primerNombre, string primerApellido)
        {
            InitializeComponent();
            CargarDatos();
            pagoSueldoLogica = new PagoSueldoLogica();
            cboTipoPagoSueldo.Items.Add("Pago de sueldo");
            cboTipoPagoSueldo.SelectedIndex = 0;
            cboTipoPagoSueldo.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvPagosSueldo.CellDoubleClick += dgvPagosSueldo_CellDoubleClick;

            txtIdEmpleadoPagoSueldo.Text = identificacion;
            txtPrimerNombreEmpleadoPagoSueldo.Text = primerNombre;
            txtPrimerApellidoEmpleadoPagoSueldo.Text = primerApellido;


        }
        private void dgvPagosSueldo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0)
    {
        DataGridViewRow filaSeleccionada = dgvPagosSueldo.Rows[e.RowIndex];
        txtIdEmpleadoPagoSueldo.Text = filaSeleccionada.Cells["IdEmpleado"].Value.ToString();
        txtPrimerNombreEmpleadoPagoSueldo.Text = filaSeleccionada.Cells["PrimerNombreEmpleado"].Value.ToString();
        txtPrimerApellidoEmpleadoPagoSueldo.Text = filaSeleccionada.Cells["PrimerApellidoEmpleado"].Value.ToString();
        txtFechaPagoPagoSueldo.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaPago"].Value);
        cboTipoPagoSueldo.SelectedItem = filaSeleccionada.Cells["TipoPago"].Value.ToString();
        txtMontoPagadoPagoSueldo.Text = filaSeleccionada.Cells["MontoPagado"].Value.ToString();
        txtDetallesPagoSueldo.Text = filaSeleccionada.Cells["Detalles"].Value.ToString();
    }
}

        private void CargarDatos()
        {
            List<PagoSueldo> pagosSueldo = PagoSueldoLogica.ObtenerTodosLosPagosSueldo();
            foreach (var pagoSueldo in pagosSueldo)
            {
                pagoSueldo.PrimerApellidoEmpleado = pagoSueldo.PrimerApellidoEmpleado?.ToUpper();
                pagoSueldo.PrimerNombreEmpleado = pagoSueldo.PrimerNombreEmpleado?.ToUpper();
                pagoSueldo.TipoPago = pagoSueldo.TipoPago?.ToUpper();                
            }

            dgvPagosSueldo.DataSource = pagosSueldo;
            dgvPagosSueldo.Columns["IdPago"].HeaderText = "ID Pago";
            dgvPagosSueldo.Columns["IdEmpleado"].HeaderText = "Identificacion";
            dgvPagosSueldo.Columns["PrimerNombreEmpleado"].HeaderText = "Primer Nombre";
            dgvPagosSueldo.Columns["PrimerApellidoEmpleado"].HeaderText = "Primer Apellido";
            dgvPagosSueldo.Columns["FechaPago"].HeaderText = "Fecha de Pago";
            dgvPagosSueldo.Columns["TipoPago"].HeaderText = "Tipo de Pago";
            dgvPagosSueldo.Columns["MontoPagado"].HeaderText = "Monto Pagado";
            dgvPagosSueldo.Columns["Detalles"].HeaderText = "Detalles";

        }
        private void LimpiarFormularioPagoSueldo()
        {
            txtIdEmpleadoPagoSueldo.Text = string.Empty;
            txtPrimerNombreEmpleadoPagoSueldo.Text = string.Empty;
            txtPrimerApellidoEmpleadoPagoSueldo.Text = string.Empty;
            txtFechaPagoPagoSueldo.Value = DateTime.Now;
            cboTipoPagoSueldo.SelectedIndex = -1;
            txtMontoPagadoPagoSueldo.Text = string.Empty;
            txtDetallesPagoSueldo.Text = string.Empty;
            txtBuscarIdPago.Text = string.Empty;

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
                                    CargarDatos();
                                    LimpiarFormularioPagoSueldo();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPagosSueldo.SelectedRows.Count > 0)
            {
                int idPago = Convert.ToInt32(dgvPagosSueldo.SelectedRows[0].Cells["IdPago"].Value);

                DialogResult result = MessageBox.Show("¿Está seguro de eliminar este pago de sueldo?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        PagoSueldoLogica.EliminarPagoSueldo(idPago);

                        MessageBox.Show("Pago de sueldo eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el pago de sueldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pago de sueldo para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string idEmpleado = txtBuscarIdPago.Text.Trim();

            if (!string.IsNullOrEmpty(idEmpleado))
            {
                try
                {
                    PagoSueldo pagoSueldo = PagoSueldoLogica.BuscarPagoSueldo(Convert.ToInt32(idEmpleado));

                    if (pagoSueldo != null)
                    {
                        dgvPagosSueldo.DataSource = null;
                        List<PagoSueldo> pagosSueldoEncontrados = new List<PagoSueldo> { pagoSueldo };
                        dgvPagosSueldo.DataSource = pagosSueldoEncontrados;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún pago de sueldo para ese empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar pago de sueldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una identificación de empleado para realizar la búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            CargarDatos();
            LimpiarFormularioPagoSueldo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPagosSueldo.SelectedRows.Count > 0)
                {
                    int idPago = Convert.ToInt32(dgvPagosSueldo.SelectedRows[0].Cells["IdPago"].Value);
                    string idEmpleado = txtIdEmpleadoPagoSueldo.Text.Trim();
                    string primerNombreEmpleado = txtPrimerNombreEmpleadoPagoSueldo.Text.Trim();
                    string primerApellidoEmpleado = txtPrimerApellidoEmpleadoPagoSueldo.Text.Trim();
                    DateTime fechaPago = txtFechaPagoPagoSueldo.Value;
                    string tipoPago = cboTipoPagoSueldo.SelectedItem?.ToString();

                    if (!double.TryParse(txtMontoPagadoPagoSueldo.Text.Trim(), out double montoPagado))
                    {
                        MessageBox.Show("El monto pagado no tiene el formato correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string detalles = txtDetallesPagoSueldo.Text.Trim();

                    if (pagoSueldoLogica.ExisteEmpleado(idEmpleado))
                    {
                        PagoSueldo pagoSueldoModificado = new PagoSueldo
                        {
                            IdPago = idPago,
                            IdEmpleado = idEmpleado,
                            PrimerNombreEmpleado = primerNombreEmpleado,
                            PrimerApellidoEmpleado = primerApellidoEmpleado,
                            FechaPago = fechaPago,
                            TipoPago = tipoPago,
                            MontoPagado = montoPagado,
                            Detalles = detalles
                        };

                        pagoSueldoLogica.ActualizarPagoSueldo(pagoSueldoModificado);
                        CargarDatos();

                        MessageBox.Show("Pago de sueldo modificado correctamente.");
                        LimpiarFormularioPagoSueldo();
                    }
                    else
                    {
                        MessageBox.Show("El empleado no existe. No se puede continuar con la modificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fila antes de intentar modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el pago de sueldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdEmpleadoPagoSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMontoPagadoPagoSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrimerNombreEmpleadoPagoSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrimerApellidoEmpleadoPagoSueldo_KeyPress(object sender, KeyPressEventArgs e)
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


