using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNEAKERS1.listas
{

        public class Sneaker
        {
            public int Id { get; set; }
            public string Modelo { get; set; }
            public string Marca { get; set; }
            public double Precio { get; set; }

            public Sneaker(int id, string modelo, string marca, double precio)
            {
                Id = id;
                Modelo = modelo;
                Marca = marca;
                Precio = precio;
            }
            public Sneaker(string modelo, string marca, double precio)
            {
                Modelo = modelo;
                Marca = marca;
                Precio = precio;
            }
        }
    
}
