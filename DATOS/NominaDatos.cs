using ENTIDADES;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class NominaDatos
    {
        public static Nomina BuscarNominaPorIdentificacion(string idEmpleado)
        {
            string query = $"SELECT * FROM Nomina WHERE id_empleado = '{idEmpleado}'";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Nomina
                            {
                                IdPago = Convert.ToInt32(reader["id_pago"]),
                                IdEmpleado = reader["id_empleado"].ToString(),
                                PrimerNombreEmpleado = reader["primer_nombre_empleado"].ToString(),
                                PrimerApellidoEmpleado = reader["primer_apellido_empleado"].ToString(),
                                FechaPago = Convert.ToDateTime(reader["fecha_pago"]),
                                TipoPago = reader["tipo_pago"].ToString(),
                                MontoPagado = Convert.ToDouble(reader["monto_pagado"]),
                                Detalles = reader["detalles"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public static Nomina BuscarNominaPorId(int idPago)
        {
            string query = $"SELECT * FROM Nomina WHERE id_pago = {idPago}";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Nomina
                            {
                                IdPago = Convert.ToInt32(reader["id_pago"]),
                                IdEmpleado = reader["id_empleado"].ToString(),
                                PrimerNombreEmpleado = reader["primer_nombre_empleado"].ToString(),
                                PrimerApellidoEmpleado = reader["primer_apellido_empleado"].ToString(),
                                FechaPago = Convert.ToDateTime(reader["fecha_pago"]),
                                TipoPago = reader["tipo_pago"].ToString(),
                                MontoPagado = Convert.ToDouble(reader["monto_pagado"]),
                                Detalles = reader["detalles"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public static List<Nomina> ObtenerTodaNomina()
        {
            List<Nomina> listaNomina = new List<Nomina>();

            string query = "SELECT * FROM Nomina";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Nomina nomina = new Nomina
                            {
                                IdPago = Convert.ToInt32(reader["id_pago"]),
                                IdEmpleado = reader["id_empleado"].ToString(),
                                PrimerNombreEmpleado = reader["primer_nombre_empleado"].ToString(),
                                PrimerApellidoEmpleado = reader["primer_apellido_empleado"].ToString(),
                                FechaPago = Convert.ToDateTime(reader["fecha_pago"]),
                                TipoPago = reader["tipo_pago"].ToString(),
                                MontoPagado = Convert.ToDouble(reader["monto_pagado"]),
                                Detalles = reader["detalles"].ToString(),
                                IdPagoAsociado = Convert.ToInt32(reader["id_pago_asociado"])
                            };

                            listaNomina.Add(nomina);
                        }
                    }
                }
            }

            return listaNomina;
        }
    }

}
