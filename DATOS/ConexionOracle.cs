using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DATOS
{
    public class ConexionOracle
    {
        private static string connectionString = "User Id=MEJIA_SAS;Password=MEJIASAS1003252107;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)));";

        public static OracleConnection ObtenerConexion()
        {
            OracleConnection connection = new OracleConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Conexión a Oracle abierta con éxito. Puedes realizar operaciones en la base de datos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir la conexión: {ex.Message}");
            }

            return connection;
        }

        public static void CerrarConexion(OracleConnection connection)
        {
            try
            {
                connection.Close();
                Console.WriteLine("Conexión a Oracle cerrada con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cerrar la conexión: {ex.Message}");
            }
        }
    }
}
