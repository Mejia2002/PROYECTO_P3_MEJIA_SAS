using ENTIDADES;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class LiquidacionDatos
    {
        public static List<ENTIDADES.Liquidacion> ObtenerTodasLasLiquidaciones()
        {
            List<ENTIDADES.Liquidacion> liquidaciones = new List<ENTIDADES.Liquidacion>();

            string query = @"SELECT * FROM Liquidacion";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ENTIDADES.Liquidacion liquidacion = new ENTIDADES.Liquidacion
                            {
                                IdPago = Convert.ToInt32(reader["id_pago"]),
                                IdEmpleado = Convert.ToString(reader["id_empleado"]),
                                PrimerNombreEmpleado = Convert.ToString(reader["primer_nombre_empleado"]),
                                PrimerApellidoEmpleado = Convert.ToString(reader["primer_apellido_empleado"]),
                                FechaPago = Convert.ToDateTime(reader["fecha_pago"]),
                                TipoPago = Convert.ToString(reader["tipo_pago"]),
                                FechaInicio = Convert.ToDateTime(reader["fecha_inicio"]),
                                FechaFin = Convert.ToDateTime(reader["fecha_fin"]),
                                DiasTrabajados = Convert.ToInt32(reader["dias_trabajados"]),
                                MontoPagado = Convert.ToDouble(reader["monto_pagado"]),
                                Detalles = Convert.ToString(reader["detalles"]),                              
                            };

                            liquidaciones.Add(liquidacion);
                        }
                    }
                }
            }

            return liquidaciones;
        }

        public static void GuardarLiquidacion(ENTIDADES.Liquidacion liquidacion)
        {
            string query = @"INSERT INTO Liquidacion (
                                id_empleado,
                                primer_nombre_empleado,
                                primer_apellido_empleado,
                                fecha_pago,
                                tipo_pago,
                                fecha_inicio,
                                fecha_fin,
                                dias_trabajados,
                                monto_pagado,
                                detalles
                            )
                            VALUES (
                                :id_empleado,
                                :primer_nombre_empleado,
                                :primer_apellido_empleado,
                                :fecha_pago,
                                :tipo_pago,
                                :fecha_inicio,
                                :fecha_fin,
                                :dias_trabajados,
                                :monto_pagado,
                                :detalles
                            )";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":id_empleado", OracleDbType.Varchar2).Value = liquidacion.IdEmpleado;
                    cmd.Parameters.Add(":primer_nombre_empleado", OracleDbType.Varchar2).Value = liquidacion.PrimerNombreEmpleado;
                    cmd.Parameters.Add(":primer_apellido_empleado", OracleDbType.Varchar2).Value = liquidacion.PrimerApellidoEmpleado;
                    cmd.Parameters.Add(":fecha_pago", OracleDbType.Date).Value = liquidacion.FechaPago;
                    cmd.Parameters.Add(":tipo_pago", OracleDbType.Varchar2).Value = liquidacion.TipoPago;
                    cmd.Parameters.Add(":fecha_inicio", OracleDbType.Date).Value = liquidacion.FechaInicio;
                    cmd.Parameters.Add(":fecha_fin", OracleDbType.Date).Value = liquidacion.FechaFin;
                    cmd.Parameters.Add(":dias_trabajados", OracleDbType.Int32).Value = liquidacion.DiasTrabajados;
                    cmd.Parameters.Add(":monto_pagado", OracleDbType.Double).Value = liquidacion.MontoPagado;
                    cmd.Parameters.Add(":detalles", OracleDbType.Varchar2).Value = liquidacion.Detalles;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarLiquidacion(int idPago)
        {
            string query = "DELETE FROM Liquidacion WHERE id_pago = :id_pago";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":id_pago", OracleDbType.Int32).Value = idPago;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static ENTIDADES.Liquidacion BuscarLiquidacion(int idPago)
        {
            string query = "SELECT * FROM Liquidacion WHERE id_pago = :id_pago";

            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":id_pago", OracleDbType.Int32).Value = idPago;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ENTIDADES.Liquidacion liquidacion = new ENTIDADES.Liquidacion
                            {
                                IdPago = Convert.ToInt32(reader["id_pago"]),
                                IdEmpleado = Convert.ToString(reader["id_empleado"]),
                                PrimerNombreEmpleado = Convert.ToString(reader["primer_nombre_empleado"]),
                                PrimerApellidoEmpleado = Convert.ToString(reader["primer_apellido_empleado"]),
                                FechaPago = Convert.ToDateTime(reader["fecha_pago"]),
                                TipoPago = Convert.ToString(reader["tipo_pago"]),
                                FechaInicio = Convert.ToDateTime(reader["fecha_inicio"]),
                                FechaFin = Convert.ToDateTime(reader["fecha_fin"]),
                                DiasTrabajados = Convert.ToInt32(reader["dias_trabajados"]),
                                MontoPagado = Convert.ToDouble(reader["monto_pagado"]),
                                Detalles = Convert.ToString(reader["detalles"]),

                            };

                            return liquidacion;
                        }
                    }
                }
            }

            return null; 
        }

        public static void ActualizarLiquidacion(Liquidacion liquidacion)
        {
            string query = "UPDATE Liquidacion " +
                            "SET " +
                            "id_empleado = :id_empleado, " +
                            "primer_nombre_empleado = :primer_nombre_empleado, " +
                            "primer_apellido_empleado = :primer_apellido_empleado, " +
                            "fecha_pago = :fecha_pago, " +
                            "tipo_pago = :tipo_pago, " +
                            "fecha_inicio = :fecha_inicio, " +
                            "fecha_fin = :fecha_fin, " +
                            "dias_trabajados = :dias_trabajados, " +
                            "monto_pagado = :monto_pagado, " +
                            "detalles = :detalles " +
                            "WHERE id_pago = :id_pago";


            using (OracleConnection connection = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":id_empleado", OracleDbType.Varchar2).Value = liquidacion.IdEmpleado;
                    cmd.Parameters.Add(":primer_nombre_empleado", OracleDbType.Varchar2).Value = liquidacion.PrimerNombreEmpleado;
                    cmd.Parameters.Add(":primer_apellido_empleado", OracleDbType.Varchar2).Value = liquidacion.PrimerApellidoEmpleado;
                    cmd.Parameters.Add(":fecha_pago", OracleDbType.Date).Value = liquidacion.FechaPago;
                    cmd.Parameters.Add(":tipo_pago", OracleDbType.Varchar2).Value = liquidacion.TipoPago;
                    cmd.Parameters.Add(":fecha_inicio", OracleDbType.Date).Value = liquidacion.FechaInicio;
                    cmd.Parameters.Add(":fecha_fin", OracleDbType.Date).Value = liquidacion.FechaFin;
                    cmd.Parameters.Add(":dias_trabajados", OracleDbType.Int32).Value = liquidacion.DiasTrabajados;
                    cmd.Parameters.Add(":monto_pagado", OracleDbType.Double).Value = liquidacion.MontoPagado;
                    cmd.Parameters.Add(":detalles", OracleDbType.Varchar2).Value = liquidacion.Detalles;
                    cmd.Parameters.Add(":id_pago", OracleDbType.Int32).Value = liquidacion.IdPago;

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
