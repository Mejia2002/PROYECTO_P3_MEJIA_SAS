using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace LOGICA
{
    public class EmpleadoLogica
    {
        public static void AgregarEmpleado(Empleado empleado)
        {
            try
            {
                DATOS.EmpleadoDatos.AgregarEmpleado(empleado);
                Console.WriteLine("Empleado agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar empleado: {ex.Message}");
            }
        }
        public static List<Empleado> ObtenerTodosLosEmpleados()
        {
            try
            {
                return DATOS.EmpleadoDatos.ObtenerTodosLosEmpleados();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleados: {ex.Message}");
                return new List<Empleado>();
            }
        }
        

        public static Empleado BuscarEmpleadoPorIdentificacion(string identificacion)
        {
            try
            {
                return DATOS.EmpleadoDatos.BuscarEmpleadoPorIdentificacion(identificacion);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar empleado: {ex.Message}");
                return null;
            }
        }

        public static void ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                DATOS.EmpleadoDatos.ActualizarEmpleado(empleado);
                Console.WriteLine("Empleado actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar empleado: {ex.Message}");
            }
        }

        public static void EliminarEmpleado(string identificacion)
        {
            try
            {
                DATOS.EmpleadoDatos.EliminarEmpleado(identificacion);
                Console.WriteLine("Empleado eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar empleado: {ex.Message}");
            }
        }

    }
}
