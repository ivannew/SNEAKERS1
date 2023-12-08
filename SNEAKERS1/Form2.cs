using System;
using System.Windows.Forms;
using SNEAKERS1.listas;
using SNEAKERS1.Pila;

namespace SNEAKERS1
{
    public partial class Form2 : Form
    {
        private ListaTenis miLista;

        public Form2()
        {
            InitializeComponent();
            miLista = new ListaTenis(dataGridView1);
            ConfigurarDataGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            miLista.EliminarPrimero();
            ActualizarDataGridView();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;

            if (!double.TryParse(txtPrecio.Text, out double precio))
            {
                MessageBox.Show("Por favor, ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Sneaker nuevoSneaker = new Sneaker(modelo, marca, precio);
                miLista.AgregarAlInicio(nuevoSneaker);
                ActualizarDataGridView();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el tenis: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            miLista.RestaurarUltimoEliminado();
            ActualizarDataGridView();
        }

        private void LimpiarCampos()
        {
            txtModelo.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Marca", "Marca");
            dataGridView1.Columns.Add("Modelo", "Modelo");
            dataGridView1.Columns.Add("Precio", "Precio");
        }

        private void ActualizarDataGridView()
        {
            miLista.MostrarLista();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                // Obtener datos de los TextBox
                string nuevaMarca = txtMarca.Text;
                string nuevoModelo = txtModelo.Text;
                double nuevoPrecio;

                if (double.TryParse(txtPrecio.Text, out nuevoPrecio))
                {
                    // Llamar a la función de edición con la posición seleccionada y los nuevos datos
                    miLista.Editar(selectedIndex, nuevaMarca, nuevoModelo, nuevoPrecio);
                }
                else
                {
                    MessageBox.Show("Ingrese un valor válido para el precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
