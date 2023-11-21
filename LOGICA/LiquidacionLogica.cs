using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA
{
    public class LiquidacionLogica
    {
       

        public static void GuardarLiquidacion(ENTIDADES.Liquidacion liquidacion)
        {
            try
            {
                DATOS.LiquidacionDatos.GuardarLiquidacion(liquidacion);
                Console.WriteLine("Liquidación guardada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar liquidación: {ex.Message}");
            }
        }

        public static List<ENTIDADES.Liquidacion> ObtenerTodasLasLiquidaciones()
        {
            try
            {
                return DATOS.LiquidacionDatos.ObtenerTodasLasLiquidaciones();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener liquidaciones: {ex.Message}");
                return new List<ENTIDADES.Liquidacion>();
            }
        }
        public bool ExisteEmpleado(string idEmpleado)
        {
            return EmpleadoDatos.ExisteEmpleado(idEmpleado);
        }
        public static ENTIDADES.Liquidacion BuscarLiquidacion(int idPago)
        {
            try
            {
                return DATOS.LiquidacionDatos.BuscarLiquidacion(idPago);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar liquidación: {ex.Message}");
                return null;
            }
        }


        public void ActualizarLiquidacion(Liquidacion liquidacion)
        {
            try
            {
                DATOS.LiquidacionDatos.ActualizarLiquidacion(liquidacion);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar liquidación: {ex.Message}");
            }
        }


        public static void EliminarLiquidacion(int idPago)
        {
            try
            {
                DATOS.LiquidacionDatos.EliminarLiquidacion(idPago);
                Console.WriteLine("Liquidación eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar liquidación: {ex.Message}");
            }
        }
        
        public static void CalcularDiasYMontos(ENTIDADES.Liquidacion liquidacion)
        {
            liquidacion.DiasTrabajados = CalcularDiasTrabajados(liquidacion.FechaInicio, liquidacion.FechaFin);
            liquidacion.MontoPagado = CalcularMontoPagado(liquidacion.IdEmpleado, liquidacion.DiasTrabajados);
        }

        private static int CalcularDiasTrabajados(DateTime fechaInicio, DateTime fechaFin)
        {
            int diasTrabajados = (int)(fechaFin - fechaInicio).TotalDays + 1;
            return diasTrabajados < 0 ? 0 : diasTrabajados;
        }

        private static double CalcularMontoPagado(string idEmpleado, int diasTrabajados)
        {
            double salario = EmpleadoDatos.ObtenerSalario(idEmpleado);
            double montoPagado = (diasTrabajados*8066);

            return montoPagado;
        }
    }
}
