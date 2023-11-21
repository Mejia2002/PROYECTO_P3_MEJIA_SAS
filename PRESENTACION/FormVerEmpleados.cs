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

namespace PRESENTACION
{
    public partial class FormVerEmpleados : Form
    {
        private EmpleadoLogica empleadoLogica;
        private object valorOriginalCelda;
        public FormVerEmpleados()
        {
            InitializeComponent();
            empleadoLogica = new EmpleadoLogica();
            CargarDatos();
            dgvEmpleados.ReadOnly = false;
            dgvEmpleados.CellDoubleClick += DgvEmpleados_CellDoubleClick;
        }
        private void CargarDatos()
        {
            List<Empleado> empleados = EmpleadoLogica.ObtenerTodosLosEmpleados();
            foreach (var empleado in empleados)
            {
                empleado.PrimerNombre = empleado.PrimerNombre?.ToUpper();
                empleado.SegundoNombre = empleado.SegundoNombre?.ToUpper();
                empleado.PrimerApellido = empleado.PrimerApellido?.ToUpper();
                empleado.SegundoApellido = empleado.SegundoApellido?.ToUpper();
                empleado.Correo = empleado.Correo?.ToUpper();
                empleado.TipoContrato = empleado.TipoContrato?.ToUpper();
                empleado.Cargo = empleado.Cargo?.ToUpper();
            }
            dgvEmpleados.DataSource = empleados;
            dgvEmpleados.Columns["Identificacion"].HeaderText = "Identificación";
            dgvEmpleados.Columns["PrimerNombre"].HeaderText = "Primer Nombre";
            dgvEmpleados.Columns["SegundoNombre"].HeaderText = "Segundo Nombre";
            dgvEmpleados.Columns["PrimerApellido"].HeaderText = "Primer Apellido";
            dgvEmpleados.Columns["SegundoApellido"].HeaderText = "Segundo Apellido";
            dgvEmpleados.Columns["Telefono"].HeaderText = "Teléfono";
            dgvEmpleados.Columns["Correo"].HeaderText = "Correo";
            dgvEmpleados.Columns["FechaInicio"].HeaderText = "Fecha de Inicio";
            dgvEmpleados.Columns["TipoContrato"].HeaderText = "Tipo de Contrato";
            dgvEmpleados.Columns["Cargo"].HeaderText = "Cargo";
            dgvEmpleados.Columns["Salario"].HeaderText = "Salario";
        }
        private void DgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0)
            {
                valorOriginalCelda = dgvEmpleados.Rows[rowIndex].Cells[e.ColumnIndex].Value;
                dgvEmpleados.BeginEdit(true);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvEmpleados.SelectedCells[0].RowIndex;

            if (rowIndex >= 0)
            {
                Empleado empleado = (Empleado)dgvEmpleados.Rows[rowIndex].DataBoundItem;

                try
                {
                    EmpleadoLogica.ActualizarEmpleado(empleado);
                    MessageBox.Show("Emplado actualizado");
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                string identificacion = dgvEmpleados.SelectedRows[0].Cells["Identificacion"].Value.ToString();
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar este empleado?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        EmpleadoLogica.EliminarEmpleado(identificacion);
                        Console.WriteLine("Empleado eliminado exitosamente.");
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string identificacion = txtBuscarId.Text.Trim();

            if (!string.IsNullOrEmpty(identificacion))
            {
                try
                {
                    Empleado empleado = EmpleadoLogica.BuscarEmpleadoPorIdentificacion(identificacion);

                    if (empleado != null)
                    {
                        dgvEmpleados.DataSource = null;
                        List<Empleado> empleadosEncontrados = new List<Empleado> { empleado };
                        dgvEmpleados.DataSource = empleadosEncontrados;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún empleado con esa identificación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una identificación para realizar la búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarId.Text = string.Empty;
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            txtBuscarId.Text = string.Empty;
            CargarDatos();

        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvEmpleados.SelectedRows[0];

                string identificacion = filaSeleccionada.Cells["Identificacion"].Value.ToString();
                string primerNombre = filaSeleccionada.Cells["PrimerNombre"].Value.ToString();
                string primerApellido = filaSeleccionada.Cells["PrimerApellido"].Value.ToString();
                DateTime fechaInicio = Convert.ToDateTime(filaSeleccionada.Cells["FechaInicio"].Value);
                FormVerLiquidaciones formLiquidaciones = new FormVerLiquidaciones(identificacion, primerNombre, primerApellido, fechaInicio);
                formLiquidaciones.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado para liquidar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvEmpleados.SelectedRows[0];


                string identificacion = filaSeleccionada.Cells["Identificacion"].Value.ToString();
                string primerNombre = filaSeleccionada.Cells["PrimerNombre"].Value.ToString();
                string primerApellido = filaSeleccionada.Cells["PrimerApellido"].Value.ToString();

                FormPagoSueldo formPagoSueldo = new FormPagoSueldo(identificacion, primerNombre, primerApellido);
                formPagoSueldo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado para realizar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
