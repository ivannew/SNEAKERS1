using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNEAKERS1.cola
{
    class Cola
    {

        Nodo _inicio;

        public void Encolar(Nodo unNodo)
        {
            if (_inicio == null)
            {
                _inicio = unNodo;
            }
            else
            {
                Nodo aux = BuscarUltimo(_inicio);
                aux.Siguiente = unNodo;
            }
        }


        private Nodo BuscarUltimo(Nodo unNodo)
        {
            if (unNodo.Siguiente == null)
            {
                return unNodo;
            }
            else
            {
                return BuscarUltimo(unNodo.Siguiente);
            }
        }

        public void Desencolar()
        {
            _inicio = _inicio.Siguiente;

        }

        public Nodo Inicio
        {
            get
            {
                return _inicio;
            }
        }

        public Nodo ObtenerNodoEnIndice(int indice)
        {
            Nodo actual = _inicio;
            for (int i = 0; i < indice; i++)
            {
                if (actual == null)
                    return null;
                actual = actual.Siguiente;
            }
            return actual;
        }

        public bool Vacia()
        {
            return (_inicio == null);
        }
    }
}
