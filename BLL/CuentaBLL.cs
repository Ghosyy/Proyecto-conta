using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class CuentaBLL
    {
        private CuentaDAL cuentaDal = new CuentaDAL();

        public List<Cuenta> ListarCatalogo()
        {
            return cuentaDal.ObtenerCuentas();
        }
    }
}
