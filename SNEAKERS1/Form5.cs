using SNEAKERS1.cola;
using System;
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
    public partial class Form5 : Form
    {
        Cola miCola = new Cola();
        public Form5()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Modelo", "Modelo");
            dataGridView1.Columns.Add("Precio", "Precio");
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombreNodo.Text.Length == 0 ||
        !decimal.TryParse(txtPrecioNodo.Text, out decimal precio) ||
        string.IsNullOrEmpty(txtModeloNodo.Text))
            {
                MessageBox.Show("Debes ingresar un nombre, un precio y un modelo válidos");
            }
            else
            {
                Nodo unNuevoNodo = new Nodo
                {
                    Nombre = txtNombreNodo.Text,
                    Precio = precio,
                    Modelo = txtModeloNodo.Text
                };
                miCola.Encolar(unNuevoNodo);
                MostrarCola();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (miCola.Vacia())
            {
                MessageBox.Show("La cola esta vacia");
            }
            else
            {
                miCola.Desencolar();
                MostrarCola();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                if (decimal.TryParse(txtPrecioNodo.Text, out decimal precio))
                {
                    Nodo nodoSeleccionado = miCola.ObtenerNodoEnIndice(rowIndex);
                    nodoSeleccionado.Nombre = txtNombreNodo.Text;
                    nodoSeleccionado.Modelo = txtModeloNodo.Text;
                    nodoSeleccionado.Precio = precio;
                    MostrarCola();
                }
                else
                {
                    MessageBox.Show("Ingresa un precio válido");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila para editar");
            }
        }
        private void btnDesencolar_Click(object sender, EventArgs e)
        {
            if (miCola.Vacia())
            {
                MessageBox.Show("La cola esta vacia");
            }
            else
            {
                miCola.Desencolar();
                MostrarCola();
            }
        }

        private void MostrarCola()
        {
            dataGridView1.Rows.Clear();
            MostrarNodoEnPantalla(miCola.Inicio);

            // Limpiar campos después de mostrar la cola
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreNodo.Clear();
            txtPrecioNodo.Clear();
            txtModeloNodo.Clear();
        }
        private void MostrarNodoEnPantalla(Nodo unNodo)
        {
            if (unNodo != null)
            {
                // Agrega las celdas en el mismo orden que las columnas
                dataGridView1.Rows.Add(unNodo.Id, unNodo.Nombre, unNodo.Modelo, unNodo.Precio);

                if (unNodo.Siguiente != null)
                {
                    MostrarNodoEnPantalla(unNodo.Siguiente);
                }
            }
        }
    }
}
