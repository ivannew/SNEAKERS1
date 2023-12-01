using SNEAKERS1.listas;
using System;
using System.Windows.Forms;

namespace SNEAKERS1
{
    public partial class listacs : Form
    {
        private ListaEnlazada listaEnlazada = new ListaEnlazada();
        public listacs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }
        private void ActualizarDataGridView()
        {
            dataGridView1.Rows.Clear();

            // Obtener la lista actual de sneakers
            Nodo nodoActual = listaEnlazada.Primero;

            while (nodoActual != null)
            {
                Sneaker sneakerActual = nodoActual.Sneaker;

                // Agregar una nueva fila al DataGridView con los datos del sneaker
                dataGridView1.Rows.Add(sneakerActual.Id, sneakerActual.Modelo, sneakerActual.Marca, sneakerActual.Precio);

                // Mover al siguiente nodo en la lista
                nodoActual = nodoActual.Siguiente;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                // Verificar si el usuario ingresó valores válidos para el ID y los nuevos datos
                if (int.TryParse(textBox4.Text, out int idEditar) &&
                    double.TryParse(textBox2.Text, out double nuevoPrecio))
                {
                    string nuevoModelo = textBox3.Text;
                    string nuevaMarca = textBox1.Text;

                    listaEnlazada.Editar(idEditar, nuevoModelo, nuevaMarca, nuevoPrecio);
                    ActualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("Ingrese valores válidos para el ID y los nuevos datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            textBox3.Clear(); // Limpiar campo de modelo
            textBox1.Clear(); // Limpiar campo de marca
            textBox2.Clear(); // Limpiar campo de precio
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string modelo = textBox3.Text;
            string marca = textBox1.Text;

            // Verificar si el usuario ingresó un valor válido para el precio
            if (double.TryParse(textBox2.Text, out double precio))
            {
                Sneaker nuevoSneaker = new Sneaker(modelo, marca, precio);
                listaEnlazada.Insertar(nuevoSneaker);

                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para el precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimpiarCampos();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int idEliminar))
            {
                listaEnlazada.Eliminar(idEliminar);
                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para el ID a eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            listaEnlazada.OrdenarPorPrecioDescendente();
            ActualizarDataGridView();
        }

        private void listacs_Load(object sender, EventArgs e)
        {

        }
    }
}
