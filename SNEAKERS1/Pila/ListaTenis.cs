using SNEAKERS1.listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNEAKERS1.Pila
{
    public class ListaTenis
    {
        public Nodo Inicio;

        private DataGridView dataGridView1;

        public ListaTenis(DataGridView dataGridView)
        {
            Inicio = null;
            dataGridView1 = dataGridView;
        }

        public void AgregarAlInicio(Sneaker datosTeni)
        {
            int nuevoId = ObtenerUltimoId() + 1;

            // Crear un nuevo Sneaker con el nuevo ID
            Sneaker nuevoSneaker = new Sneaker(nuevoId, datosTeni.Marca, datosTeni.Modelo, datosTeni.Precio);

            Nodo nuevoNodo = new Nodo(nuevoSneaker);
            nuevoNodo.Siguiente = Inicio;
            Inicio = nuevoNodo;

            // Actualizar el DataGridView al agregar un nuevo Sneaker
            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
            // Limpiar el DataGridView
            dataGridView1.Rows.Clear();

            // Recorrer la lista y agregar filas al DataGridView
            Nodo actual = Inicio;
            while (actual != null)
            {
                dataGridView1.Rows.Add(actual.Sneaker.Id, actual.Sneaker.Marca, actual.Sneaker.Modelo, actual.Sneaker.Precio);
                actual = actual.Siguiente;
            }
        }

        private int ObtenerUltimoId()
        {
            Nodo ultimoNodo = Inicio;
            int ultimoId = 0;

            while (ultimoNodo != null)
            {
                if (ultimoNodo.Sneaker.Id > ultimoId)
                {
                    ultimoId = ultimoNodo.Sneaker.Id;
                }

                ultimoNodo = ultimoNodo.Siguiente;
            }

            return ultimoId;
        }

        public void MostrarLista()
        {
            Nodo actual = Inicio;
            while (actual != null)
            {
                Console.WriteLine($"Marca: {actual.Sneaker.Marca}, Modelo: {actual.Sneaker.Modelo}, Precio: {actual.Sneaker.Precio}");
                actual = actual.Siguiente;
            }
        }

        public void EliminarPrimero()
        {
            if (Inicio == null)
            {
                return;
            }

            // Establecer Inicio en el siguiente nodo
            Inicio = Inicio.Siguiente;
        }

        public void Editar(string modeloAntiguo, string nuevaMarca, string nuevoModelo, double nuevoPrecio)
        {
            Nodo actual = Inicio;

            // Buscar el nodo que contiene el Sneaker con el modelo antiguo
            while (actual != null && actual.Sneaker.Modelo != modeloAntiguo)
            {
                actual = actual.Siguiente;
            }

            // Si se encontró el nodo, actualizar los valores
            if (actual != null)
            {
                actual.Sneaker.Modelo = nuevoModelo;
                actual.Sneaker.Marca = nuevaMarca;
                actual.Sneaker.Precio = nuevoPrecio;
            }
            else
            {
                Console.WriteLine($"No se encontró un Sneaker con el modelo {modeloAntiguo} en la lista.");
            }
        }


    }
}
