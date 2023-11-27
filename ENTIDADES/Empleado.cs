using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Empleado
    {
        public Empleado()
        {
        }

        public Empleado(string identificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string telefono, string correo, DateTime fechaInicio, DateTime fechaFin, string estado, string tipoContrato, string cargo, double salario)
        {
            Identificacion = identificacion;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Telefono = telefono;
            Correo = correo;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Estado = estado;
            TipoContrato = tipoContrato;
            Cargo = cargo;
            Salario = salario;
        }

        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get;set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado {  get; set; }
        public string TipoContrato { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }

        public override string ToString()
        {
            return $"{Identificacion};{PrimerNombre};{SegundoNombre};{PrimerApellido};{SegundoApellido};{Telefono};{Correo};{FechaInicio.ToString("yyyy-MM-dd")};{TipoContrato};{FechaFin.ToString("yyyy-MM-dd")};{Estado};{Cargo};{Salario}";
        }
        public void DesactivarEmpleado()
        {
            Estado = "Inactivo";
            FechaInicio = DateTime.MinValue;
            FechaFin = DateTime.MinValue;
            TipoContrato = string.Empty;
            Cargo = string.Empty;
            Salario = 0.0;
        }

    }
}
