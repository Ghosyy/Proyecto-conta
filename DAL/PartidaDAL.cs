using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;

namespace DAL
{
    public class PartidaDAL : ConexionDB
    {
        public bool InsertarPartida(Partida nuevaPartida)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                // Iniciamos la transacción segura
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Guardar el Encabezado apuntando a tus columnas reales
                        string queryPartida = "INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) OUTPUT INSERTED.IdPartida VALUES (@Numero, @Fecha, @Desc, @Tipo)";
                        int idPartidaGenerado = 0;

                        using (var cmdPartida = new SqlCommand(queryPartida, conexion, transaccion))
                        {
                            cmdPartida.Parameters.AddWithValue("@Numero", nuevaPartida.NumeroPartida);
                            cmdPartida.Parameters.AddWithValue("@Fecha", nuevaPartida.FechaTransaccion);
                            cmdPartida.Parameters.AddWithValue("@Desc", nuevaPartida.Descripcion);
                            cmdPartida.Parameters.AddWithValue("@Tipo", nuevaPartida.TipoPartida);

                            idPartidaGenerado = (int)cmdPartida.ExecuteScalar();
                        }

                        // 2. Guardar el Detalle (AQUÍ ESTÁ LA MAGIA: CargoDebe y AbonoHaber, pero con @Debe y @Haber en los values)
                        string queryDetalle = "INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (@IdPartida, @CodigoCuenta, @Debe, @Haber)";

                        foreach (var detalle in nuevaPartida.Detalles)
                        {
                            using (var cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                            {
                                cmdDetalle.Parameters.AddWithValue("@IdPartida", idPartidaGenerado);
                                cmdDetalle.Parameters.AddWithValue("@CodigoCuenta", detalle.CodigoCuenta);
                                cmdDetalle.Parameters.AddWithValue("@Debe", detalle.Debe);
                                cmdDetalle.Parameters.AddWithValue("@Haber", detalle.Haber);
                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        // Confirmar cambios
                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        // Revertir si algo falla
                        transaccion.Rollback();
                        throw;
                    }
                }
            }

        }


        public DataTable ObtenerLibroDiario()
        {
            DataTable dt = new DataTable();
            using (var conexion = GetConnection())
            {
                conexion.Open();
                // Hacemos un JOIN para unir el encabezado con el detalle
                string query = @"
                    SELECT 
                        P.NumeroPartida AS [No. Partida], 
                        CONVERT(varchar, P.FechaTransaccion, 103) AS Fecha, 
                        D.CodigoCuenta AS [Código], 
                        P.Descripcion AS Descripción, 
                        D.CargoDebe AS Debe, 
                        D.AbonoHaber AS Haber
                    FROM Partidas P
                    INNER JOIN Detalle_Partidas D ON P.IdPartida = D.IdPartida
                    ORDER BY P.FechaTransaccion, P.IdPartida, D.IdDetalle";

                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    using (var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt); // Llenamos la tabla virtual con los datos de SQL
                    }
                }
            }
            return dt;
        }

        // Método para el Estado de Resultados (Cuentas 4, 5 y 6, ignorando la partida de cierre)
        public DataTable ObtenerEstadoResultados()
        {
            DataTable dt = new DataTable();
            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = @"
                    SELECT 
                        C.CodigoCuenta AS [Código], 
                        C.NombreCuenta AS [Cuenta], 
                        -- Para ingresos (4) mostramos el Haber, para Costos (5) y Gastos (6) el Debe
                        CASE 
                            WHEN C.CodigoCuenta LIKE '4%' THEN SUM(D.AbonoHaber) - SUM(D.CargoDebe)
                            WHEN C.CodigoCuenta LIKE '5%' THEN SUM(D.CargoDebe) - SUM(D.AbonoHaber)
                            WHEN C.CodigoCuenta LIKE '6%' THEN SUM(D.CargoDebe) - SUM(D.AbonoHaber)
                        END AS [Monto Acumulado]
                    FROM Detalle_Partidas D
                    INNER JOIN Catalogo_Cuentas C ON D.CodigoCuenta = C.CodigoCuenta
                    INNER JOIN Partidas P ON D.IdPartida = P.IdPartida
                    WHERE (C.CodigoCuenta LIKE '4%' OR C.CodigoCuenta LIKE '5%' OR C.CodigoCuenta LIKE '6%') 
                    AND P.TipoPartida != 'Cierre' -- Ignoramos la partida de cierre para ver el saldo histórico real
                    GROUP BY C.CodigoCuenta, C.NombreCuenta
                    ORDER BY C.CodigoCuenta";

                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    using (var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Método para jalar el Libro Mayor (Saldos agrupados)
        public DataTable ObtenerLibroMayor()
        {
            DataTable dt = new DataTable();
            using (var conexion = GetConnection())
            {
                conexion.Open();
                // Usamos tu tabla real: Catalogo_Cuentas
                string query = @"
                    SELECT 
                        D.CodigoCuenta AS [Código de Cuenta], 
                        C.NombreCuenta AS [Nombre de la Cuenta], 
                        SUM(D.CargoDebe) AS [Total Debe], 
                        SUM(D.AbonoHaber) AS [Total Haber],
                        (SUM(D.CargoDebe) - SUM(D.AbonoHaber)) AS [Saldo Matemático]
                    FROM Detalle_Partidas D
                    INNER JOIN Catalogo_Cuentas C ON D.CodigoCuenta = C.CodigoCuenta
                    GROUP BY D.CodigoCuenta, C.NombreCuenta
                    ORDER BY D.CodigoCuenta";

                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    using (var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Método para el Balance General (Cuentas 1, 2 y 3)
        public DataTable ObtenerSaldosBalance()
        {
            DataTable dt = new DataTable();
            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = @"
                    SELECT 
                        C.CodigoCuenta, 
                        C.NombreCuenta, 
                        -- Activo (1) suma en el Debe. Pasivo (2) y Capital (3) suman en el Haber
                        CASE 
                            WHEN C.CodigoCuenta LIKE '1%' THEN SUM(D.CargoDebe) - SUM(D.AbonoHaber)
                            WHEN C.CodigoCuenta LIKE '2%' OR C.CodigoCuenta LIKE '3%' THEN SUM(D.AbonoHaber) - SUM(D.CargoDebe)
                        END AS Saldo
                    FROM Detalle_Partidas D
                    INNER JOIN Catalogo_Cuentas C ON D.CodigoCuenta = C.CodigoCuenta
                    WHERE C.CodigoCuenta LIKE '1%' OR C.CodigoCuenta LIKE '2%' OR C.CodigoCuenta LIKE '3%'
                    GROUP BY C.CodigoCuenta, C.NombreCuenta
                    HAVING (SUM(D.CargoDebe) - SUM(D.AbonoHaber)) <> 0 -- Solo jala cuentas que tengan dinero
                    ORDER BY C.CodigoCuenta";

                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    using (var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Método para editar un monto directamente desde el Libro Diario
        public bool ActualizarMontoDetalle(string numeroPartida, string codigoCuenta, decimal nuevoDebe, decimal nuevoHaber)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = @"
                    UPDATE D
                    SET D.CargoDebe = @Debe, D.AbonoHaber = @Haber
                    FROM Detalle_Partidas D
                    INNER JOIN Partidas P ON D.IdPartida = P.IdPartida
                    WHERE P.NumeroPartida = @NumPartida AND D.CodigoCuenta = @CodigoCuenta";

                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@NumPartida", numeroPartida);
                    cmd.Parameters.AddWithValue("@CodigoCuenta", codigoCuenta);
                    cmd.Parameters.AddWithValue("@Debe", nuevoDebe);
                    cmd.Parameters.AddWithValue("@Haber", nuevoHaber);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public void ObtenerSaldosCuenta(string codigoCuenta, out decimal totalDebe, out decimal totalHaber)
        {
            totalDebe = 0;
            totalHaber = 0;

            using (var conexion = GetConnection())
            {
                conexion.Open();
                // Usamos ISNULL para que, si la cuenta no tiene movimientos, devuelva 0 y no truene el sistema
                string query = "SELECT ISNULL(SUM(CargoDebe), 0) AS TotalDebe, ISNULL(SUM(AbonoHaber), 0) AS TotalHaber FROM Detalle_Partidas WHERE CodigoCuenta = @Codigo";

                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigoCuenta);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalDebe = Convert.ToDecimal(reader["TotalDebe"]);
                            totalHaber = Convert.ToDecimal(reader["TotalHaber"]);
                        }
                    }
                }
            }
        }
    }
}




