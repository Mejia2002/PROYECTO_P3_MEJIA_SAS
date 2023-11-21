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

        public Empleado(string identificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string telefono, string correo, DateTime fechaInicio, string tipoContrato, string cargo, double salario)
        {
            Identificacion = identificacion;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Telefono = telefono;
            Correo = correo;
            FechaInicio = fechaInicio;
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
        public string TipoContrato { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }

        public override string ToString()
        {
            return $"{Identificacion};{PrimerNombre};{SegundoNombre};{PrimerApellido};{SegundoApellido};{Telefono};{Correo};{FechaInicio.ToString("yyyy-MM-dd")};{TipoContrato};{Cargo};{Salario}";
        }

    }
}
