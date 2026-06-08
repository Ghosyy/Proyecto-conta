using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class UsuarioDAL : ConexionDB
    {
        public Usuario Login(string username, string password)
        {
            Usuario user = null;

            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = "SELECT IdUsuario, NombreCompleto, Username, Rol FROM Usuarios WHERE Username = @user AND PasswordTexto = @pass AND Activo = 1";

                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@user", username);
                    comando.Parameters.AddWithValue("@pass", password);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                Username = reader["Username"].ToString(),
                                Rol = reader["Rol"].ToString(),
                                Activo = true
                            };
                        }
                    }
                }
            }
            return user;
        }
    }
}   