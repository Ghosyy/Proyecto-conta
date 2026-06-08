using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class CuentaDAL : ConexionDB
    {
        public List<Cuenta> ObtenerCuentas()
        {
            List<Cuenta> lista = new List<Cuenta>();

            using (var conexion = GetConnection())
            {
                conexion.Open();

                // Hacemos el SELECT exacto a las columnas de tu imagen
                string query = "SELECT CodigoCuenta, NombreCuenta, Clasificacion, AceptaMovimientos FROM Catalogo_Cuentas";

                using (var comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cuenta
                            {
                                CodigoCuenta = reader["CodigoCuenta"].ToString(),
                                NombreCuenta = reader["NombreCuenta"].ToString(),
                                Clasificacion = reader["Clasificacion"].ToString(),
                                // SQL guarda los bit (0 o 1) como booleanos en C#
                                AceptaMovimientos = Convert.ToBoolean(reader["AceptaMovimientos"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
