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
    public partial class FormVerLiquidaciones : Form
    {
        private LiquidacionLogica liquidacionLogica;
        public FormVerLiquidaciones(string identificacion, string primerNombre, string primerApellido, DateTime fechaInicio)
        {
            InitializeComponent();
            liquidacionLogica = new LiquidacionLogica();
            ConfigurarDataGridView();
            CargarDatos();
            dgvLiquidaciones.ReadOnly = false;
            cboTipoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoPago.Items.Add("Liquidación");
            cboTipoPago.SelectedIndex = -1;
            dgvLiquidaciones.CellDoubleClick += dgvLiquidaciones_CellDoubleClick;

            txtIdEmpleado.Text = identificacion;
            txtPrimerNombreEmpleado.Text = primerNombre;
            txtPrimerApellidoEmpleado.Text = primerApellido;
            txtFechaInicioL.Value = fechaInicio;

        }
        private void ConfigurarDataGridView()
        {
            dgvLiquidaciones.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        private void CargarDatos()
        {
            List<Liquidacion> liquidaciones = LiquidacionLogica.ObtenerTodasLasLiquidaciones();
            foreach (var liquidacion in liquidaciones)
            {
                liquidacion.PrimerNombreEmpleado = liquidacion.PrimerNombreEmpleado?.ToUpper();
                liquidacion.PrimerApellidoEmpleado = liquidacion.PrimerApellidoEmpleado?.ToUpper();
                liquidacion.TipoPago = liquidacion.TipoPago?.ToUpper();
            }
            dgvLiquidaciones.DataSource = liquidaciones;
            dgvLiquidaciones.Columns["IdPago"].HeaderText = "ID Pago";
            dgvLiquidaciones.Columns["IdEmpleado"].HeaderText = "Ientificacion";
            dgvLiquidaciones.Columns["PrimerNombreEmpleado"].HeaderText = "Primer Nombre";
            dgvLiquidaciones.Columns["PrimerApellidoEmpleado"].HeaderText = "Primer Apellido";
            dgvLiquidaciones.Columns["FechaPago"].HeaderText = "Fecha de Pago";
            dgvLiquidaciones.Columns["TipoPago"].HeaderText = "Tipo de Pago";
            dgvLiquidaciones.Columns["FechaInicio"].HeaderText = "Fecha de Inicio";
            dgvLiquidaciones.Columns["FechaFin"].HeaderText = "Fecha de Fin";
            dgvLiquidaciones.Columns["DiasTrabajados"].HeaderText = "Días Trabajados";
            dgvLiquidaciones.Columns["MontoPagado"].HeaderText = "Monto Pagado";
            dgvLiquidaciones.Columns["MontoPagado"].DefaultCellStyle.Format = "N0";
            dgvLiquidaciones.Columns["Detalles"].HeaderText = "Detalles";
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
                                CargarDatos();
                                LimpiarFormulario();
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
        
        private void LimpiarFormulario()
        {
            txtIdEmpleado.Text = string.Empty;
            txtPrimerNombreEmpleado.Text = string.Empty;
            txtPrimerApellidoEmpleado.Text = string.Empty;
            txtFechaPago.Value = DateTime.Now;
            txtFechaInicioL.Value = DateTime.Now;
            txtFechaFin.Value = DateTime.Now;
            cboTipoPago.SelectedIndex = -1;
            txtDiasTrabajados.Text = string.Empty;
            txtTotalPagar.Text = string.Empty;
            txtDetalles.Text = string.Empty;
            txtBuscarId.Text = string.Empty;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string idEmpleado = txtBuscarId.Text.Trim();

            if (!string.IsNullOrEmpty(idEmpleado))
            {
                try
                {
                    Liquidacion liquidacion = LiquidacionLogica.BuscarLiquidacion(Convert.ToInt32(idEmpleado));

                    if (liquidacion != null)
                    {
                        dgvLiquidaciones.DataSource = null;
                        List<Liquidacion> liquidacionesEncontradas = new List<Liquidacion> { liquidacion };
                        dgvLiquidaciones.DataSource = liquidacionesEncontradas;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ninguna liquidación con ese ID de pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar liquidación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID de pago para realizar la búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLiquidaciones.SelectedRows.Count > 0)
            {
                int idPago = Convert.ToInt32(dgvLiquidaciones.SelectedRows[0].Cells["IdPago"].Value);
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar esta liquidación?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        LiquidacionLogica.EliminarLiquidacion(idPago);
                        Console.WriteLine("Liquidación eliminada exitosamente.");
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la liquidación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una liquidación para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvLiquidaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvLiquidaciones.Rows[e.RowIndex];
                txtIdEmpleado.Text = filaSeleccionada.Cells["IdEmpleado"].Value.ToString();
                txtPrimerNombreEmpleado.Text = filaSeleccionada.Cells["PrimerNombreEmpleado"].Value.ToString();
                txtPrimerApellidoEmpleado.Text = filaSeleccionada.Cells["PrimerApellidoEmpleado"].Value.ToString();
                txtFechaPago.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaPago"].Value);
                txtFechaInicioL.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaInicio"].Value);
                txtFechaFin.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaFin"].Value);
                cboTipoPago.SelectedItem = filaSeleccionada.Cells["TipoPago"].Value.ToString();
                txtDiasTrabajados.Text = filaSeleccionada.Cells["DiasTrabajados"].Value.ToString();
                txtTotalPagar.Text = filaSeleccionada.Cells["MontoPagado"].Value.ToString();
                txtDetalles.Text = filaSeleccionada.Cells["Detalles"].Value.ToString();
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            CargarDatos();
            LimpiarFormulario();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLiquidaciones.SelectedRows.Count > 0)
                {
                    int idPago = Convert.ToInt32(dgvLiquidaciones.SelectedRows[0].Cells["IdPago"].Value);
                    string idEmpleado = txtIdEmpleado.Text.Trim();
                    string primerNombreEmpleado = txtPrimerNombreEmpleado.Text.Trim();
                    string primerApellidoEmpleado = txtPrimerApellidoEmpleado.Text.Trim();
                    DateTime fechaPago = txtFechaPago.Value;
                    string tipoPago = cboTipoPago.SelectedItem?.ToString();
                    DateTime fechaInicio = txtFechaInicioL.Value;
                    DateTime fechaFin = txtFechaFin.Value;
                    int diasTrabajados = Convert.ToInt32(txtDiasTrabajados.Text.Trim());
                    string textoMonto = txtTotalPagar.Text.Trim().Replace("$", "").Replace(",", "");

                    double montoPagado;
                    if (double.TryParse(textoMonto, out montoPagado))
                    {
                        string detalles = txtDetalles.Text.Trim();

                        if (liquidacionLogica.ExisteEmpleado(idEmpleado))
                        {
                            Liquidacion liquidacionModificada = new Liquidacion
                            {
                                IdPago = idPago,
                                IdEmpleado = idEmpleado,
                                PrimerNombreEmpleado = primerNombreEmpleado,
                                PrimerApellidoEmpleado = primerApellidoEmpleado,
                                FechaPago = fechaPago,
                                TipoPago = tipoPago,
                                FechaInicio = fechaInicio,
                                FechaFin = fechaFin,
                                DiasTrabajados = diasTrabajados,
                                MontoPagado = montoPagado,
                                Detalles = detalles
                            };

                            liquidacionLogica.ActualizarLiquidacion(liquidacionModificada);
                            CargarDatos();

                            MessageBox.Show("Liquidación modificada correctamente.");
                            LimpiarFormulario();
                        }
                        else
                        {
                            MessageBox.Show("El empleado no existe. No se puede continuar con la modificación.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El monto ingresado no es válido. Por favor, ingresa un valor numérico.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fila antes de intentar modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la liquidación: {ex.Message}");
            }
        }


        private void txtSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnDescargarPDF_Click(object sender, EventArgs e)
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


        private void txtIdEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiasTrabajados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrimerNombreEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrimerApellidoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
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
