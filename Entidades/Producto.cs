using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public string TipoItem { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Existencia { get; set; }
    }
}
