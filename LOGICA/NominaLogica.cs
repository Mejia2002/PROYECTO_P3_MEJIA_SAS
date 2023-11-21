using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA
{
    public class NominaLogica
    {
        public static Nomina BuscarNominaPorId(int idPago)
        {
            try
            {
                return NominaDatos.BuscarNominaPorId(idPago);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar nómina por ID: {ex.Message}");
                return null;
            }
        }

        public static List<Nomina> ObtenerTodaNomina()
        {
            try
            {
                return NominaDatos.ObtenerTodaNomina();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener toda la nómina: {ex.Message}");
                return new List<Nomina>();
            }
        }

        public static Nomina BuscarNominaPorIdentificacion(string idEmpleado)
        {
            try
            {

                return NominaDatos.BuscarNominaPorIdentificacion(idEmpleado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar nómina por ID de empleado: {ex.Message}");
                return null;
            }
        }
    }
}

