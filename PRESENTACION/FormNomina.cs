using ENTIDADES;
using LOGICA;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTACION
{
    public partial class FormNomina : Form
    {
        public FormNomina()
        {
            InitializeComponent();
            CargarDatosNomina();       
        }
        private void CargarDatosNomina()
        {
            List<Nomina> nominas = NominaLogica.ObtenerTodaNomina();

            foreach (var nomina in nominas)
            {
                nomina.PrimerApellidoEmpleado = nomina.PrimerApellidoEmpleado?.ToUpper();
                nomina.PrimerNombreEmpleado = nomina.PrimerNombreEmpleado?.ToUpper();
                nomina.TipoPago = nomina.TipoPago?.ToUpper();
            }

            dgvNomina.DataSource = nominas;
            dgvNomina.Columns["IdPago"].HeaderText = "ID Pago";
            dgvNomina.Columns["IdEmpleado"].HeaderText = "ID Empleado";
            dgvNomina.Columns["PrimerNombreEmpleado"].HeaderText = "Primer Nombre Empleado";
            dgvNomina.Columns["PrimerApellidoEmpleado"].HeaderText = "Primer Apellido Empleado";
            dgvNomina.Columns["FechaPago"].HeaderText = "Fecha de Pago";
            dgvNomina.Columns["TipoPago"].HeaderText = "Tipo de Pago";
            dgvNomina.Columns["MontoPagado"].HeaderText = "Monto Pagado";
            dgvNomina.Columns["Detalles"].HeaderText = "Detalles";
        }
        private void CargarDatosEnDgvNomina(List<Nomina> nominas)
        {
            dgvNomina.DataSource = nominas;
        }

        private void btnBuscarIdPago_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscarIdPago.Text, out int idPago))
            {
                Nomina nomina = NominaLogica.BuscarNominaPorId(idPago);

                if (nomina != null)
                {
                    CargarDatosEnDgvNomina(new List<Nomina> { nomina });
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna nómina con ese IdPago.");
                    txtBuscarIdentificacion.Text = string.Empty;
                    txtBuscarIdPago.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para IdPago.");
            }
        }

        private void btnBuscarIdentificacion_Click(object sender, EventArgs e)
        {
            string idEmpleado = txtBuscarIdentificacion.Text;

            if (!string.IsNullOrEmpty(idEmpleado))
            {
                Nomina nomina = NominaLogica.BuscarNominaPorIdentificacion(idEmpleado);

                if (nomina != null)
                {
                    List<Nomina> nominas = new List<Nomina> { nomina };
                    CargarDatosEnDgvNomina(nominas);
                }
                else
                {
                    MessageBox.Show("No se encontraron nóminas para la identificación proporcionada.");
                    txtBuscarIdentificacion.Text = string.Empty;
                    txtBuscarIdPago.Text = string.Empty;

                }
            }
            else
            {
                MessageBox.Show("Ingrese una identificación válida para buscar.");
            }
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            CargarDatosNomina();
            txtBuscarIdentificacion.Text = string.Empty;
            txtBuscarIdPago.Text = string.Empty;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNomina.Rows.Count > 0)
                {
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            FileInfo fi = new FileInfo(sfd.FileName);
                            using (ExcelPackage package = new ExcelPackage(fi))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Nomina");
                                for (int i = 1; i <= dgvNomina.Columns.Count; i++)
                                {
                                    worksheet.Cells[1, i].Value = dgvNomina.Columns[i - 1].HeaderText;
                                    worksheet.Cells[1, i].Style.Font.Bold = true;
                                    worksheet.Cells[1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    worksheet.Cells[1, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                                    worksheet.Cells[1, i].Style.Font.Color.SetColor(Color.White);
                                }
                                for (int i = 0; i < dgvNomina.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dgvNomina.Columns.Count; j++)
                                    {
                                        worksheet.Cells[i + 2, j + 1].Value = dgvNomina.Rows[i].Cells[j].Value.ToString();
                                    }
                                }

                                package.Save();
                            }

                            MessageBox.Show("Datos exportados a Excel con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarIdPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuscarIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    
}
