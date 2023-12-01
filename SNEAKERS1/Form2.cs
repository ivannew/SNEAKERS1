using SNEAKERS1.listas;
using SNEAKERS1.Pila;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNEAKERS1
{
    public partial class Form2 : Form
    {
        private ListaTenis miLista;
        public Form2()
        {
            InitializeComponent();

            // Inicializa miLista en el constructor
            miLista = new ListaTenis(dataGridView1);

            // Inicializar el DataGridView
            ConfigurarDataGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (miLista.Inicio != null)
            {
                // Eliminar el primer elemento
                miLista.EliminarPrimero();

                // Actualizar el DataGridView
                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("La lista está vacía. No hay elementos para eliminar.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;

            // Validar y convertir el precio
            if (!double.TryParse(txtPrecio.Text, out double precio))
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
                return;
            }

            try
            {
                // Crear un nuevo Sneaker sin especificar el ID
                Sneaker nuevoSneaker = new Sneaker(modelo, marca, precio);

                // Agregar el Sneaker a la lista
                miLista.AgregarAlInicio(nuevoSneaker);

                // Actualizar el DataGridView
                ActualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el tenis: {ex.Message}");
            }
        }

        private void ActualizarDataGridView()
        {
            // Limpiar el DataGridView
            dataGridView1.Rows.Clear();

            // Recorrer la lista y agregar filas al DataGridView
            Nodo actual = miLista.Inicio;
            while (actual != null)
            {
                dataGridView1.Rows.Add(actual.Sneaker.Id, actual.Sneaker.Marca, actual.Sneaker.Modelo, actual.Sneaker.Precio);
                actual = actual.Siguiente;
            }
        }

        private void ConfigurarDataGridView()
        {
            // Agregar las columnas al DataGridView
            dataGridView1.Columns.Add("Id", "Id");  // Agrega esta línea para la columna de ID
            dataGridView1.Columns.Add("Marca", "Marca");
            dataGridView1.Columns.Add("Modelo", "Modelo");
            dataGridView1.Columns.Add("Precio", "Precio");
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                // Obtener el Sneaker correspondiente a la fila seleccionada en tu lista enlazada
                Nodo actual = miLista.Inicio;
                for (int i = 0; i < selectedIndex && actual != null; i++)
                {
                    actual = actual.Siguiente;
                }

                // Verificar que actual no sea nulo
                if (actual != null)
                {
                    // Obtener los valores editados de los TextBox
                    string nuevoModelo = txtModelo.Text;
                    string nuevaMarca = txtMarca.Text;
                    double nuevoPrecio;

                    // Verificar si el precio ingresado es un valor válido
                    if (double.TryParse(txtPrecio.Text, out nuevoPrecio))
                    {
                        // Actualizar el Sneaker con los valores editados
                        actual.Sneaker.Modelo = nuevoModelo;
                        actual.Sneaker.Marca = nuevaMarca;
                        actual.Sneaker.Precio = nuevoPrecio;

                        // Actualizar el DataGridView
                        ActualizarDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un valor válido para el precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
