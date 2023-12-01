using SNEAKERS1.listas;
using System;
using System.IO;
using System.Windows.Forms;

namespace SNEAKERS1.arreglos
{
    public class ArregloTenis
    {
        private Sneaker[] tenisArray;
        private int capacidad;
        private int contador;
        private DataGridView dataGridView1; // Agrega esta variable

        public ArregloTenis(int capacidadInicial, DataGridView dataGridView)
        {
            capacidad = capacidadInicial;
            tenisArray = new Sneaker[capacidad];
            contador = 0;
            dataGridView1 = dataGridView;
        }

        public void Agregar(Sneaker datosTeni)
        {
            if (contador < capacidad)
            {
                int nuevoId = ObtenerUltimoId() + 1;
                Sneaker nuevoSneaker = new Sneaker(nuevoId, datosTeni.Modelo, datosTeni.Marca, datosTeni.Precio);
                tenisArray[contador] = nuevoSneaker;
                contador++;

                // Actualizar el DataGridView después de agregar un Sneaker
                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("La capacidad del arreglo ha sido alcanzada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ActualizarDataGridView()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < contador; i++)
            {
                // Asegúrate de usar tenisArray[i].Id, tenisArray[i].Marca, etc.
                dataGridView1.Rows.Add(tenisArray[i].Id, tenisArray[i].Marca, tenisArray[i].Modelo, tenisArray[i].Precio);
            }
        }


        private int ObtenerUltimoId()
        {
            int ultimoId = 0;
            for (int i = 0; i < contador; i++)
            {
                if (tenisArray[i].Id > ultimoId)
                {
                    ultimoId = tenisArray[i].Id;
                }
            }
            return ultimoId;
        }

        public void EliminarUltimo()
        {
            if (contador > 0)
            {
                contador--;
                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("El arreglo está vacío. No hay elementos para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Editar(int indice, string nuevaMarca, string nuevoModelo, double nuevoPrecio)
        {
            if (indice >= 0 && indice < contador)
            {
                tenisArray[indice].Marca = nuevaMarca;
                tenisArray[indice].Modelo = nuevoModelo;
                tenisArray[indice].Precio = nuevoPrecio;

                // Llamar al método para guardar los cambios
                GuardarCambios();

                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("Índice no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Sneaker ObtenerSneaker(int indice)
        {
            if (indice >= 0 && indice < contador)
            {
                return tenisArray[indice];
            }
            return null;
        }
        public void GuardarCambios()
        {
            // Este es un ejemplo básico que guarda el contenido del arreglo en un archivo CSV
            // Puedes personalizar esto según el método que estés utilizando para almacenar tus datos.

            try
            {
                using (StreamWriter writer = new StreamWriter("sneakers.csv"))
                {
                    for (int i = 0; i < contador; i++)
                    {
                        // Escribe cada Sneaker en una línea del archivo CSV
                        writer.WriteLine($"{tenisArray[i].Id},{tenisArray[i].Marca},{tenisArray[i].Modelo},{tenisArray[i].Precio}");
                    }
                }

                MessageBox.Show("Cambios guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
