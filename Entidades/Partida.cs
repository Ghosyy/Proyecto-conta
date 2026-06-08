using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public string NumeroPartida { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string Descripcion { get; set; }
        public string TipoPartida { get; set; }

        public List<DetallePartida> Detalles { get; set; } = new List<DetallePartida>();
    }
}
