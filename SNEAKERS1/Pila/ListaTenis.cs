using SNEAKERS1.listas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SNEAKERS1.Pila
{
    public class ListaTenis
    {
        public Nodo Inicio;
        private DataGridView dataGridView1;
        private Stack<Nodo> pilaAuxiliar;

        public ListaTenis(DataGridView dataGridView)
        {
            Inicio = null;
            dataGridView1 = dataGridView;
            pilaAuxiliar = new Stack<Nodo>();
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
                Console.WriteLine($"Marca: {actual.Sneaker.Marca}, Modelo: {actual.Sneaker.Modelo}, Precio: {actual.Sneaker.Precio}");
                actual = actual.Siguiente;
            }
        }

        public void EliminarPrimero()
        {
            if (Inicio == null)
            {
                MessageBox.Show("La lista está vacía. No hay elementos para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Agregar el elemento a la pila auxiliar antes de eliminarlo
            pilaAuxiliar.Push(new Nodo(Inicio.Sneaker));

            Inicio = Inicio.Siguiente;
            ActualizarDataGridView();
            MessageBox.Show("Primer elemento eliminado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Editar(int posicionSeleccionada, string nuevaMarca, string nuevoModelo, double nuevoPrecio)
        {
            Nodo actual = ObtenerNodoEnPosicion(posicionSeleccionada);

            if (actual != null)
            {
                // Guardar el elemento actual en la pila auxiliar antes de la edición
                pilaAuxiliar.Push(new Nodo(actual.Sneaker));

                // Editar el Sneaker actual con los nuevos datos
                actual.Sneaker.Marca = nuevaMarca;
                actual.Sneaker.Modelo = nuevoModelo;
                actual.Sneaker.Precio = nuevoPrecio;

                ActualizarDataGridView();
                Console.WriteLine("Sneaker editado correctamente.");
            }
            else
            {
                MessageBox.Show($"No se encontró un Sneaker en la posición {posicionSeleccionada} en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Nodo ObtenerNodoEnPosicion(int posicion)
        {
            Nodo actual = Inicio;

            for (int i = 0; i < posicion && actual != null; i++)
            {
                actual = actual.Siguiente;
            }

            return actual;
        }


        // Restaurar el último elemento eliminado
        public void RestaurarUltimoEliminado()
        {
            if (pilaAuxiliar.Count > 0)
            {
                Nodo ultimoEliminado = pilaAuxiliar.Pop();
                ultimoEliminado.Siguiente = Inicio;
                Inicio = ultimoEliminado;
                MessageBox.Show("Último elemento eliminado restaurado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La pila auxiliar está vacía. No hay elementos para restaurar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
