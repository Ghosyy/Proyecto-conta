using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ConexionDB
    {
        // Tu cadena de conexión apuntando a tu servidor ABNER\SQLEXPRESS
        private readonly string cadenaConexion = "Server=ABNER\\SQLEXPRESS;Database=DB_PanaderiaIxtapan;Integrated Security=True;";

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
