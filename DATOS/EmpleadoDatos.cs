using ENTIDADES;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class EmpleadoDatos
    {
        public static void AgregarEmpleado(Empleado empleado)
        {
            string query = $"INSERT INTO Empleados VALUES ('{empleado.Identificacion}', " +
                           $"'{empleado.PrimerNombre}', '{empleado.SegundoNombre}', " +
                           $"'{empleado.PrimerApellido}', '{empleado.SegundoApellido}', " +
                           $"'{empleado.Telefono}', '{empleado.Correo}', " +
                           $"TO_DATE('{empleado.FechaInicio.ToString("yyyy-MM-dd")}', 'YYYY-MM-DD'), " +
                           $"'{empleado.TipoContrato}', '{empleado.Cargo}', {empleado.Salario})";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static bool ExisteEmpleado(string identificacion)
        {
            string query = $"SELECT COUNT(*) FROM Empleados WHERE identificacion = '{identificacion}'";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }


        public static Empleado BuscarEmpleadoPorIdentificacion(string identificacion)
        {
            string query = $"SELECT * FROM Empleados WHERE identificacion = '{identificacion}'";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Empleado
                            {
                                Identificacion = reader["identificacion"].ToString(),
                                PrimerNombre = reader["primer_nombre"].ToString(),
                                SegundoNombre = reader["segundo_nombre"].ToString(),
                                PrimerApellido = reader["primer_apellido"].ToString(),
                                SegundoApellido = reader["segundo_apellido"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                Correo = reader["correo"].ToString(),
                                FechaInicio = Convert.ToDateTime(reader["fechaInicio"]),
                                TipoContrato = reader["tipoContrato"].ToString(),
                                Cargo = reader["cargo"].ToString(),
                                Salario = Convert.ToDouble(reader["salario"])
                            };
                        }
                    }
                }
            }

            return null; 
        }
        

        public static void ActualizarEmpleado(Empleado empleado)
        {
            string query = $"UPDATE Empleados SET " +
                           $"primer_nombre = '{empleado.PrimerNombre}', " +
                           $"segundo_nombre = '{empleado.SegundoNombre}', " +
                           $"primer_apellido = '{empleado.PrimerApellido}', " +
                           $"segundo_apellido = '{empleado.SegundoApellido}', " +
                           $"telefono = '{empleado.Telefono}', " +
                           $"correo = '{empleado.Correo}', " +
                           $"fechaInicio = TO_DATE('{empleado.FechaInicio.ToString("yyyy-MM-dd")}', 'YYYY-MM-DD'), " +
                           $"tipoContrato = '{empleado.TipoContrato}', " +
                           $"cargo = '{empleado.Cargo}', " +
                           $"salario = {empleado.Salario} " +
                           $"WHERE identificacion = '{empleado.Identificacion}'";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<ENTIDADES.Empleado> ObtenerTodosLosEmpleados()
        {
            List<ENTIDADES.Empleado> listaEmpleados = new List<ENTIDADES.Empleado>();

            string query = "SELECT * FROM Empleados";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ENTIDADES.Empleado empleado = new ENTIDADES.Empleado
                            {
                                Identificacion = reader["identificacion"].ToString(),
                                PrimerNombre = reader["primer_nombre"].ToString(),
                                SegundoNombre = reader["segundo_nombre"].ToString(),
                                PrimerApellido = reader["primer_apellido"].ToString(),
                                SegundoApellido = reader["segundo_apellido"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                Correo = reader["correo"].ToString(),
                                FechaInicio = Convert.ToDateTime(reader["fechaInicio"]),
                                TipoContrato = reader["tipoContrato"].ToString(),
                                Cargo = reader["cargo"].ToString(),
                                Salario = Convert.ToDouble(reader["salario"])
                            };

                            listaEmpleados.Add(empleado);
                        }
                    }
                }
            }

            return listaEmpleados;
        }
        public static double ObtenerSalario(string identificacion)
        {
            double salario = 0.0;

            string query = "SELECT salario FROM Empleados WHERE identificacion = :identificacion";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":identificacion", OracleDbType.Varchar2).Value = identificacion;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            salario = Convert.ToDouble(reader["salario"]);
                        }
                    }
                }
            }

            return salario;
        }

        public static void EliminarEmpleado(string identificacion)
        {
            string query = $"DELETE FROM Empleados WHERE identificacion = '{identificacion}'";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
