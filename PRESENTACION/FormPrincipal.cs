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
    public partial class FormPrincipal : Form
    {      
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnContratar_Click(object sender, EventArgs e)
        {
            FormContrato formContrato = new FormContrato();
            formContrato.ShowDialog();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FormVerEmpleados formVerEmpleados = new FormVerEmpleados();
            formVerEmpleados.ShowDialog();
        }

        private void btnNomina_Click(object sender, EventArgs e)
        {
            FormNomina formNomina = new FormNomina();
            formNomina.ShowDialog();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            string identificacion = null;
            string primerNombre = null;
            string primerApellido = null;
            FormPagoSueldo formPagoSueldo = new FormPagoSueldo(identificacion, primerNombre, primerApellido);
            formPagoSueldo.ShowDialog();
        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = DateTime.Now;
            string identificacion = null;
            string primerNombre = null;
            string primerApellido = null;
            FormVerLiquidaciones formVerLiquidaciones = new FormVerLiquidaciones(identificacion, primerNombre, primerApellido, fechaInicio);
            formVerLiquidaciones.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
