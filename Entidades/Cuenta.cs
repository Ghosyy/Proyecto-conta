using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuenta
    {
        public string CodigoCuenta { get; set; }
        public string NombreCuenta { get; set; }
        public string Clasificacion { get; set; }
        public bool AceptaMovimientos { get; set; }
    }
}
