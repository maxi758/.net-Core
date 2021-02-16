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
        int activo;

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
            this.Activo = 1;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int Activo { get => activo; set => activo = value; }
    }
}
