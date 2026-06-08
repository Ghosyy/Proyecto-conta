using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class ProductoDAL : ConexionDB
    {
        public List<Producto> ObtenerInventario()
        {
            List<Producto> lista = new List<Producto>();

            using (var conexion = GetConnection())
            {
                conexion.Open();
                // Aquí está el cambio mágico al final de la consulta
                string query = "SELECT Sku, Descripcion, TipoItem, CostoUnitario, PrecioVenta, Existencia FROM Inventario_Productos ORDER BY Sku ASC";

                using (var comando = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    using (System.Data.SqlClient.SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                Sku = reader["Sku"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                TipoItem = reader["TipoItem"].ToString(),
                                CostoUnitario = Convert.ToDecimal(reader["CostoUnitario"]),
                                PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                Existencia = Convert.ToDecimal(reader["Existencia"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public bool InsertarProducto(string sku, string descripcion, string tipoItem, decimal costo, decimal precio, decimal existencia)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                // Apuntando a tu tabla real: Inventario_Productos
                string query = @"INSERT INTO Inventario_Productos (Sku, Descripcion, TipoItem, CostoUnitario, PrecioVenta, Existencia) 
                                 VALUES (@Sku, @Desc, @Tipo, @Costo, @Precio, @Existencia)";

                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Sku", sku);
                    cmd.Parameters.AddWithValue("@Desc", descripcion);
                    cmd.Parameters.AddWithValue("@Tipo", tipoItem);
                    cmd.Parameters.AddWithValue("@Costo", costo);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Existencia", existencia);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Método para EDITAR un producto existente
        public bool ActualizarProducto(string sku, string descripcion, string tipoItem, decimal costo, decimal precio, decimal existencia)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = @"UPDATE Inventario_Productos 
                                 SET Descripcion = @Desc, TipoItem = @Tipo, CostoUnitario = @Costo, PrecioVenta = @Precio, Existencia = @Existencia 
                                 WHERE Sku = @Sku";

                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Sku", sku);
                    cmd.Parameters.AddWithValue("@Desc", descripcion);
                    cmd.Parameters.AddWithValue("@Tipo", tipoItem);
                    cmd.Parameters.AddWithValue("@Costo", costo);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Existencia", existencia);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para ELIMINAR un producto
        public bool EliminarProducto(string sku)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = "DELETE FROM Inventario_Productos WHERE Sku = @Sku";

                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Sku", sku);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
