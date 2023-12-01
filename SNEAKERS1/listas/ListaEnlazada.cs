using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNEAKERS1.listas
{
    public class ListaEnlazada
    {
        private int ultimoId = 0;

        public Nodo Primero { get; set; }

        public ListaEnlazada()
        {
            Primero = null;
        }

        public void Insertar(Sneaker sneaker)
        {
            sneaker.Id = ++ultimoId;
            Nodo nuevoNodo = new Nodo(sneaker);

            // Si la lista está vacía, el nuevo nodo será el primero y el último
            if (Primero == null)
            {
                Primero = nuevoNodo;
            }
            else
            {
                // Encontrar el último nodo y enlazarlo con el nuevo nodo
                Nodo ultimoNodo = ObtenerUltimoNodo();
                ultimoNodo.Siguiente = nuevoNodo;
            }
        }
        private Nodo ObtenerUltimoNodo()
        {
            Nodo ultimoNodo = Primero;
            while (ultimoNodo.Siguiente != null)
            {
                ultimoNodo = ultimoNodo.Siguiente;
            }
            return ultimoNodo;
        }

        public void Eliminar(int id)
        {
            Nodo nodoActual = Primero;
            Nodo nodoAnterior = null;

            // Buscar el nodo que contiene el sneaker con el ID especificado
            while (nodoActual != null && nodoActual.Sneaker.Id != id)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Siguiente;
            }

            // Si se encontró el nodo, eliminarlo
            if (nodoActual != null)
            {
                // Si el nodo a eliminar es el primero
                if (nodoAnterior == null)
                {
                    Primero = nodoActual.Siguiente;
                }
                else
                {
                    nodoAnterior.Siguiente = nodoActual.Siguiente;
                }
            }
        }
        public void Editar(int id, string nuevoModelo, string nuevaMarca, double nuevoPrecio)
        {
            Nodo nodoActual = Primero;

            // Buscar el nodo que contiene el sneaker con el ID especificado
            while (nodoActual != null && nodoActual.Sneaker.Id != id)
            {
                nodoActual = nodoActual.Siguiente;
            }

            // Si se encontró el nodo, actualizar los datos del sneaker
            if (nodoActual != null)
            {
                nodoActual.Sneaker.Modelo = nuevoModelo;
                nodoActual.Sneaker.Marca = nuevaMarca;
                nodoActual.Sneaker.Precio = nuevoPrecio;
            }
        }
        public void OrdenarPorPrecioDescendente()
        {
            bool intercambio;
            Nodo actual;
            Nodo siguiente = null;

            do
            {
                intercambio = false;
                actual = Primero;

                while (actual != null && actual.Siguiente != siguiente)
                {
                    Nodo siguienteNodo = actual.Siguiente;
                    if (actual.Sneaker.Precio < siguienteNodo.Sneaker.Precio)
                    {
                        // Intercambiar los nodos si el precio es menor
                        Sneaker temp = actual.Sneaker;
                        actual.Sneaker = siguienteNodo.Sneaker;
                        siguienteNodo.Sneaker = temp;

                        intercambio = true;
                    }

                    actual = actual.Siguiente;
                }
                siguiente = actual;

            } while (intercambio);
        }
    }
}
