using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class ProductoBLL
    {
        private ProductoDAL productoDal = new ProductoDAL();

        public List<Producto> ListarInventario()
        {
            return productoDal.ObtenerInventario();
        }

        public bool InsertarProducto(string sku, string descripcion, string tipoItem, decimal costo, decimal precio, decimal existencia)
        {
            if (string.IsNullOrWhiteSpace(sku) || string.IsNullOrWhiteSpace(descripcion))
            {
                throw new Exception("El SKU y la Descripción son obligatorios.");
            }

            return productoDal.InsertarProducto(sku, descripcion, tipoItem, costo, precio, existencia);
        }

        public bool ActualizarProducto(string sku, string descripcion, string tipoItem, decimal costo, decimal precio, decimal existencia)
        {
            if (string.IsNullOrWhiteSpace(sku)) throw new Exception("Seleccione un producto para editar.");
            return productoDal.ActualizarProducto(sku, descripcion, tipoItem, costo, precio, existencia);
        }

        public bool EliminarProducto(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku)) throw new Exception("Seleccione un producto para eliminar.");
            return productoDal.EliminarProducto(sku);
        }


    }


}
