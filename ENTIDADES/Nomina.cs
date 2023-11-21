using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Nomina
    {
        public Nomina()
        {
        }

        public Nomina(int idPago, string idEmpleado, string primerNombreEmpleado, string primerApellidoEmpleado, DateTime fechaPago, string tipoPago, double montoPagado, string detalles, int idPagoAsociado)
        {
            IdPago = idPago;
            IdEmpleado = idEmpleado;
            PrimerNombreEmpleado = primerNombreEmpleado;
            PrimerApellidoEmpleado = primerApellidoEmpleado;
            FechaPago = fechaPago;
            TipoPago = tipoPago;
            MontoPagado = montoPagado;
            Detalles = detalles;
            IdPagoAsociado = idPagoAsociado;
        }

        public int IdPago { get; set; }
        public string IdEmpleado { get; set; }
        public string PrimerNombreEmpleado { get; set; }
        public string PrimerApellidoEmpleado { get; set; }
        public DateTime FechaPago { get; set; }
        public string TipoPago { get; set; }
        public double MontoPagado { get; set; }
        public string Detalles { get; set; }
        public int IdPagoAsociado { get; set; }
        public override string ToString()
        {
            return $"{IdPago};{IdEmpleado};{PrimerNombreEmpleado};{PrimerApellidoEmpleado};{FechaPago.ToString("yyyy-MM-dd")};{TipoPago};{MontoPagado};{Detalles};{IdPagoAsociado}";
        }
    }
}
