using SNEAKERS1.listas;
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
    public partial class listacs : Form
    {
        private Nodo cabeza;
        private int contadorId;

        public listacs()
        {
            InitializeComponent();
            InicializarDatos();
            CargarDatosEnDataGridView();

            // Asociar el evento de clic al botón Guardar
          button1.Click += btnGuardar_Click;
        }

        private void InicializarDatos()
        {
            cabeza = null;
            contadorId = 1;
        }

        private void CargarDatosEnDataGridView()
        {
            dataGridView1.Rows.Clear();

            Nodo actual = cabeza;

            while (actual != null)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1, actual.Datos.Id, actual.Datos.Marca, actual.Datos.Modelo, actual.Datos.Precio);
                dataGridView1.Rows.Add(fila);

                actual = actual.Siguiente;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener datos desde los TextBox
            string marca = textBox1.Text;
            string modelo = textBox2.Text;
            decimal precio;

            // Validar y convertir el precio
            if (!decimal.TryParse(textBox3.Text, out precio))
            {
                MessageBox.Show("Por favor, ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un nuevo nodo con los datos ingresados
            Datos nuevosDatos = new Datos
            {
                Id = contadorId,
                Marca = marca,
                Modelo = modelo,
                Precio = precio
            };

            Nodo nuevoNodo = new Nodo(nuevosDatos);

            // Agregar el nuevo nodo a la lista enlazada
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo ultimo = cabeza;
                while (ultimo.Siguiente != null)
                {
                    ultimo = ultimo.Siguiente;
                }

                ultimo.Siguiente = nuevoNodo;
            }

            // Incrementar el contador de ID
            contadorId++;

            // Actualizar el DataGridView
            CargarDatosEnDataGridView();
        }

        // Resto del código...
    }
}