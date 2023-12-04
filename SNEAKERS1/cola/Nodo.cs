using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNEAKERS1.cola
{
    class Nodo
    {
        public static int _idCounter = 0;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Modelo { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo()
        {
            Id = ++_idCounter;
        }

    }
}
