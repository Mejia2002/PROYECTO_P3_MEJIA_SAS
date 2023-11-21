using ENTIDADES;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class PagoSueldoDatos
    {
        public static List<ENTIDADES.PagoSueldo> ObtenerTodosLosPagosSueldo()
        {
            List<ENTIDADES.PagoSueldo> pagosSueldo = new List<ENTIDADES.PagoSueldo>();

            string query = @"SELECT * FROM PagoSueldo";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ENTIDADES.PagoSueldo pagoSueldo = new ENTIDADES.PagoSueldo
                            {
                                IdPago = Convert.ToInt32(reader["id_pago"]),
                                IdEmpleado = Convert.ToString(reader["id_empleado"]),
                                PrimerNombreEmpleado = Convert.ToString(reader["primer_nombre_empleado"]),
                                PrimerApellidoEmpleado = Convert.ToString(reader["primer_apellido_empleado"]),
                                FechaPago = Convert.ToDateTime(reader["fecha_pago"]),
                                TipoPago = Convert.ToString(reader["tipo_pago"]),
                                MontoPagado = Convert.ToDouble(reader["monto_pagado"]),
                                Detalles = Convert.ToString(reader["detalles"]),
                            };

                            pagosSueldo.Add(pagoSueldo);
                        }
                    }
                }
            }

            return pagosSueldo;
        }

        public static void GuardarPagoSueldo(ENTIDADES.PagoSueldo pagoSueldo)
        {
            string query = @"INSERT INTO PagoSueldo (
                                id_empleado,
                                primer_nombre_empleado,
                                primer_apellido_empleado,
                                fecha_pago,
                                tipo_pago,
                                monto_pagado,
                                detalles
                            )
                            VALUES (
                                :id_empleado,
                                :primer_nombre_empleado,
                                :primer_apellido_empleado,
                                :fecha_pago,
                                :tipo_pago,
                                :monto_pagado,
                                :detalles
                            )";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":id_empleado", OracleDbType.Varchar2).Value = pagoSueldo.IdEmpleado;
                    cmd.Parameters.Add(":primer_nombre_empleado", OracleDbType.Varchar2).Value = pagoSueldo.PrimerNombreEmpleado;
                    cmd.Parameters.Add(":primer_apellido_empleado", OracleDbType.Varchar2).Value = pagoSueldo.PrimerApellidoEmpleado;
                    cmd.Parameters.Add(":fecha_pago", OracleDbType.Date).Value = pagoSueldo.FechaPago;
                    cmd.Parameters.Add(":tipo_pago", OracleDbType.Varchar2).Value = pagoSueldo.TipoPago;
                    cmd.Parameters.Add(":monto_pagado", OracleDbType.Double).Value = pagoSueldo.MontoPagado;
                    cmd.Parameters.Add(":detalles", OracleDbType.Varchar2).Value = pagoSueldo.Detalles;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarPagoSueldo(int idPago)
        {
            string query = "DELETE FROM PagoSueldo WHERE id_pago = :id_pago";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":id_pago", OracleDbType.Int32).Value = idPago;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static ENTIDADES.PagoSueldo BuscarPagoSueldo(int idPago)
        {
            string query = "SELECT * FROM PagoSueldo WHERE id_pago = :id_pago";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":id_pago", OracleDbType.Int32).Value = idPago;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ENTIDADES.PagoSueldo pagoSueldo = new ENTIDADES.PagoSueldo
                            {
                                IdPago = Convert.ToInt32(reader["id_pago"]),
                                IdEmpleado = Convert.ToString(reader["id_empleado"]),
                                PrimerNombreEmpleado = Convert.ToString(reader["primer_nombre_empleado"]),
                                PrimerApellidoEmpleado = Convert.ToString(reader["primer_apellido_empleado"]),
                                FechaPago = Convert.ToDateTime(reader["fecha_pago"]),
                                TipoPago = Convert.ToString(reader["tipo_pago"]),
                                MontoPagado = Convert.ToDouble(reader["monto_pagado"]),
                                Detalles = Convert.ToString(reader["detalles"]),
                            };

                            return pagoSueldo;
                        }
                    }
                }
            }

            return null;
        }

        public static void ActualizarPagoSueldo(PagoSueldo pagoSueldo)
        {
            string query = "UPDATE PagoSueldo " +
                           "SET " +
                           "id_empleado = :id_empleado, " +
                           "primer_nombre_empleado = :primer_nombre_empleado, " +
                           "primer_apellido_empleado = :primer_apellido_empleado, " +
                           "fecha_pago = :fecha_pago, " +
                           "tipo_pago = :tipo_pago, " +
                           "monto_pagado = :monto_pagado, " +
                           "detalles = :detalles " +
                           "WHERE id_pago = :id_pago";

            try
            {
                using (OracleConnection connection = ConexionOracle.ObtenerConexion())
                {
                    using (OracleCommand cmd = new OracleCommand(query, connection))
                    {
                        cmd.Parameters.Add(":id_empleado", OracleDbType.Varchar2).Value = pagoSueldo.IdEmpleado;
                        cmd.Parameters.Add(":primer_nombre_empleado", OracleDbType.Varchar2).Value = pagoSueldo.PrimerNombreEmpleado;
                        cmd.Parameters.Add(":primer_apellido_empleado", OracleDbType.Varchar2).Value = pagoSueldo.PrimerApellidoEmpleado;
                        cmd.Parameters.Add(":fecha_pago", OracleDbType.Date).Value = pagoSueldo.FechaPago;
                        cmd.Parameters.Add(":tipo_pago", OracleDbType.Varchar2).Value = pagoSueldo.TipoPago;
                        cmd.Parameters.Add(":monto_pagado", OracleDbType.Double).Value = pagoSueldo.MontoPagado;
                        cmd.Parameters.Add(":detalles", OracleDbType.Varchar2).Value = pagoSueldo.Detalles;
                        cmd.Parameters.Add(":id_pago", OracleDbType.Int32).Value = pagoSueldo.IdPago;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar pago de sueldo: {ex.Message}");
                throw;
            }
        }

    }
}
