using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp6.Entidades
{
    public class Persona
    {
        static int aux = 0;
        int id;
        String nombre;
        String direccion;
        String telefono;

        public Persona()
        {
            this.id = aux++;
        }

        public Persona( string nombre, string direccion, string telefono)
        {
            this.id = aux++;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public int Id { get => id;  }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
