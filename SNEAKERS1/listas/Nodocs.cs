using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNEAKERS1.listas
{
    public class Nodo
    {
        public Datos Datos { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Datos datos)
        {
            Datos = datos;
            Siguiente = null;
        }
    }

}
