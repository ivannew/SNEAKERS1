using SNEAKERS1.arreglos;
using SNEAKERS1.listas;
using System;
using System.Windows.Forms;

namespace SNEAKERS1
{
    public partial class Form3 : Form
    {
        private ArregloTenis miArreglo;

        public Form3()
        {
            InitializeComponent();
            miArreglo = new ArregloTenis(100, dataGridView1);
            ConfigurarDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;

            if (!double.TryParse(txtPrecio.Text, out double precio))
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
                return;
            }

            try
            {
                Sneaker nuevoSneaker = new Sneaker(modelo, marca, precio);
                miArreglo.Agregar(nuevoSneaker);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el tenis: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            miArreglo.EliminarUltimo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                Sneaker sneakerSeleccionado = miArreglo.ObtenerSneaker(selectedIndex);

                if (sneakerSeleccionado != null)
                {
                    txtMarca.Text = sneakerSeleccionado.Marca;
                    txtModelo.Text = sneakerSeleccionado.Modelo;
                    txtPrecio.Text = sneakerSeleccionado.Precio.ToString();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                if (!double.TryParse(txtPrecio.Text, out double nuevoPrecio))
                {
                    MessageBox.Show("Por favor, ingrese un precio válido.");
                    return;
                }

                miArreglo.Editar(selectedIndex, txtMarca.Text, txtModelo.Text, nuevoPrecio);

                // Llamar al método para guardar los cambios
                miArreglo.GuardarCambios();

                LimpiarTextBox();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarTextBox()
        {
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }

        private void ActualizarDataGridView()
        {
            miArreglo.ActualizarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false; // Evitar la fila adicional al final
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Marca", "Marca");
            dataGridView1.Columns.Add("Modelo", "Modelo");
            dataGridView1.Columns.Add("Precio", "Precio");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
