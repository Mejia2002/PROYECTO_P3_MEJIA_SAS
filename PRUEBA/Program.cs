using DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace PRUEBA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prueba de conexión a Oracle");

            // Intenta abrir la conexión
            OracleConnection conexion = ConexionOracle.ObtenerConexion();

            // Verifica si la conexión está abierta
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("¡Conexión establecida correctamente!");

                // Aquí puedes realizar otras operaciones en la base de datos si es necesario

                // Cierra la conexión
                ConexionOracle.CerrarConexion(conexion);
                Console.WriteLine("Conexión cerrada.");
            }

            Console.WriteLine("Presiona cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}
