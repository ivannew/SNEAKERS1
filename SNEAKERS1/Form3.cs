using SNEAKERS1.arreglos;
using SNEAKERS1.listas;
using System;
using System.IO;
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
            LimpiarTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            miArreglo.EliminarUltimo();
        }

        // ... (otros métodos y propiedades)

        private int indiceEditando = -1; // Agrega esta variable

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                if (indiceEditando == -1)
                {
                    // Si no estamos editando, mostramos los datos en los TextBox
                    Sneaker sneakerSeleccionado = miArreglo.ObtenerSneaker(selectedIndex);

                    if (sneakerSeleccionado != null)
                    {
                        txtMarca.Text = sneakerSeleccionado.Marca;
                        txtModelo.Text = sneakerSeleccionado.Modelo;
                        txtPrecio.Text = sneakerSeleccionado.Precio.ToString();

                        // Almacenamos el índice de la fila que estamos editando
                        indiceEditando = selectedIndex;
                    }
                }
                else
                {
                    // Si estamos editando, guardamos los cambios
                    string marca = txtMarca.Text;
                    string modelo = txtModelo.Text;

                    if (double.TryParse(txtPrecio.Text, out double precio))
                    {
                        // Llamamos al método de la clase ArregloTenis para editar y guardar cambios
                        miArreglo.EditarSneaker(indiceEditando, marca, modelo, precio);

                        // Limpiamos los TextBox y restablecemos el índice de edición
                        LimpiarTextBox();
                        indiceEditando = -1;
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                // Obtiene el Sneaker seleccionado
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                Sneaker sneakerSeleccionado = miArreglo.ObtenerSneaker(selectedIndex);

                if (sneakerSeleccionado != null)
                {
                    // Actualizar los valores del Sneaker con los TextBox
                    sneakerSeleccionado.Marca = txtMarca.Text;
                    sneakerSeleccionado.Modelo = txtModelo.Text;

                    // Intentar convertir el precio
                    if (double.TryParse(txtPrecio.Text, out double nuevoPrecio))
                    {
                        // Actualizar el precio solo si la conversión es exitosa
                        sneakerSeleccionado.Precio = nuevoPrecio;

                        // Actualizar el DataGridView
                        miArreglo.ActualizarDataGridView();

                        // Limpiar los TextBox
                        LimpiarTextBox();

                        // Guardar los cambios
                        miArreglo.GuardarCambios();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Marca", "Marca");
            dataGridView1.Columns.Add("Modelo", "Modelo");
            dataGridView1.Columns.Add("Precio", "Precio");
        }
    }
}
