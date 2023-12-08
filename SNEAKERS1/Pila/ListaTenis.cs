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

 
            Sneaker nuevoSneaker = new Sneaker(nuevoId, datosTeni.Marca, datosTeni.Modelo, datosTeni.Precio);

            Nodo nuevoNodo = new Nodo(nuevoSneaker);
            nuevoNodo.Siguiente = Inicio;
            Inicio = nuevoNodo;

            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
           
            dataGridView1.Rows.Clear();

        
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
                Console.WriteLine($"Id: {actual.Sneaker.Id}, Marca: {actual.Sneaker.Marca}, Modelo: {actual.Sneaker.Modelo}, Precio: {actual.Sneaker.Precio}");
                actual = actual.Siguiente;
            }
        }

        public void EliminarPrimero()
        {
            if (Inicio == null)
            {
                Console.WriteLine("La lista está vacía. No hay elementos para eliminar.");
                return;
            }

            Inicio = Inicio.Siguiente;
            Console.WriteLine("Primer elemento eliminado.");
            MostrarLista(); // Muestra la lista después de la eliminación
        }

        public void Editar(string modeloAntiguo, string nuevaMarca, string nuevoModelo, double nuevoPrecio)
        {
            Nodo actual = Inicio;

            while (actual != null && actual.Sneaker.Modelo != modeloAntiguo)
            {
                actual = actual.Siguiente;
            }

            if (actual != null)
            {
                Console.WriteLine($"Editando Sneaker: {actual.Sneaker.Id}, Modelo Antiguo: {modeloAntiguo}, Nueva Marca: {nuevaMarca}, Nuevo Modelo: {nuevoModelo}, Nuevo Precio: {nuevoPrecio}");

                actual.Sneaker.Modelo = nuevoModelo;
                actual.Sneaker.Marca = nuevaMarca;
                actual.Sneaker.Precio = nuevoPrecio;

                Console.WriteLine("Sneaker editado correctamente.");
                MostrarLista(); // Muestra la lista después de la edición
            }
            else
            {
                Console.WriteLine($"No se encontró un Sneaker con el modelo {modeloAntiguo} en la lista.");
            }
        }




    }
}
