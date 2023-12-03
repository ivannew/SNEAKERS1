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

          
            miLista = new ListaTenis(dataGridView1);

           
            ConfigurarDataGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (miLista.Inicio != null)
            {
                miLista.EliminarPrimero();

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

            if (!double.TryParse(txtPrecio.Text, out double precio))
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
                return;
            }

            try
            {
        
                Sneaker nuevoSneaker = new Sneaker(modelo, marca, precio);

         
                miLista.AgregarAlInicio(nuevoSneaker);

                ActualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el tenis: {ex.Message}");
            }
        }

        private void ActualizarDataGridView()
        {
            dataGridView1.Rows.Clear();

          
            Nodo actual = miLista.Inicio;
            while (actual != null)
            {
                dataGridView1.Rows.Add(actual.Sneaker.Id, actual.Sneaker.Marca, actual.Sneaker.Modelo, actual.Sneaker.Precio);
                actual = actual.Siguiente;
            }
        }

        private void ConfigurarDataGridView()
        {
            
            dataGridView1.Columns.Add("Id", "Id");  
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
             
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                Nodo actual = miLista.Inicio;
                for (int i = 0; i < selectedIndex && actual != null; i++)
                {
                    actual = actual.Siguiente;
                }

              
                if (actual != null)
                {
                   
                    string nuevoModelo = txtModelo.Text;
                    string nuevaMarca = txtMarca.Text;
                    double nuevoPrecio;

                  
                    if (double.TryParse(txtPrecio.Text, out nuevoPrecio))
                    {
                      
                        actual.Sneaker.Modelo = nuevoModelo;
                        actual.Sneaker.Marca = nuevaMarca;
                        actual.Sneaker.Precio = nuevoPrecio;

                      
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
