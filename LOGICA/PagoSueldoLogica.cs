using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA
{
    public class PagoSueldoLogica
    {
        public static List<ENTIDADES.PagoSueldo> ObtenerTodosLosPagosSueldo()
        {
            try
            {
                return DATOS.PagoSueldoDatos.ObtenerTodosLosPagosSueldo();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los pagos de sueldo.", ex);
            }
        }

        public static void GuardarPagoSueldo(ENTIDADES.PagoSueldo pagoSueldo)
        {
            try
            {
                DATOS.PagoSueldoDatos.GuardarPagoSueldo(pagoSueldo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al guardar el pago de sueldo.", ex);
            }
        }
        public bool ExisteEmpleado(string idEmpleado)
        {
            return EmpleadoDatos.ExisteEmpleado(idEmpleado);
        }

        public static void EliminarPagoSueldo(int idPago)
        {
            try
            {
                DATOS.PagoSueldoDatos.EliminarPagoSueldo(idPago);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al eliminar el pago de sueldo.", ex);
            }
        }

        public static ENTIDADES.PagoSueldo BuscarPagoSueldo(int idPago)
        {
            try
            {
                return DATOS.PagoSueldoDatos.BuscarPagoSueldo(idPago);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al buscar el pago de sueldo.", ex);
            }
        }

        public void ActualizarPagoSueldo(PagoSueldo pagoSueldo)
        {
            try
            {
                DATOS.PagoSueldoDatos.ActualizarPagoSueldo(pagoSueldo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar el pago: {ex.Message}");
            }
        }
    }
}
