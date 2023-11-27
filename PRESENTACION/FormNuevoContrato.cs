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
    public partial class FormNuevoContrato : Form
    {
        private Empleado empleadoExistente;
        private EmpleadoLogica empleadoLogica;
        public FormNuevoContrato(string identificacion, string primerNombre, string primerApellido)
        {
            InitializeComponent();
            cboCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoContrato.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarComboBox();
            txtIdentificacion.Text = identificacion;
            txtPrimerNombre.Text = primerNombre;
            txtPrimerApellido.Text = primerApellido;
            empleadoExistente = EmpleadoLogica.BuscarEmpleadoPorIdentificacion(identificacion);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidarCampos()
        {
            if (txtFechaInicio.Value > txtFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de finalización.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtSalario.Text) || !double.TryParse(txtSalario.Text, out _))
            {
                MessageBox.Show("Ingrese un salario válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cboTipoContrato.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de contrato.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboCargo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cargo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void CargarComboBox()
        {
            cboCargo.Items.AddRange(new string[] { "Siso", "Obrero", "Guadañador", "Conductor" });
            cboTipoContrato.Items.AddRange(new string[] { "Indefinido", "Proyecto" });
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                DateTime fechaInicio = txtFechaInicio.Value;
                DateTime fechaFin = txtFechaFin.Value;
                string tipoContrato = cboTipoContrato.SelectedItem.ToString();
                string cargo = cboCargo.SelectedItem.ToString();
                double salario = Convert.ToDouble(txtSalario.Text);
                
                empleadoExistente.FechaInicio = fechaInicio;
                empleadoExistente.FechaFin = fechaFin;
                empleadoExistente.TipoContrato = tipoContrato;
                empleadoExistente.Cargo = cargo;
                empleadoExistente.Salario = salario;

                if (empleadoExistente.Estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                {
                    empleadoExistente.Estado = "Activo";
                }
                EmpleadoLogica.ActualizarEmpleado(empleadoExistente);

                MessageBox.Show("Contrato realizado con exito. Estado actualizado a Activo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos(); 
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarCampos()
        {
            txtIdentificacion.Text = string.Empty;
            txtPrimerNombre.Text = string.Empty;
            txtPrimerApellido.Text = string.Empty;
            txtFechaInicio.Value = DateTime.Today;
            txtFechaFin.Value = DateTime.Today;
            cboTipoContrato.SelectedIndex = 0;
            cboCargo.SelectedIndex = 0;
            txtSalario.Text = string.Empty;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }

}
