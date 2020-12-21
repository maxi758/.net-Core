using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp6.Entidades
{
    public class Cadeteria
    {
        string nombre;
        List<Cadete> listaCadetes;

        public Cadeteria()
        {
        }

        public Cadeteria(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre { get => nombre; set => nombre = value; }
    }
}
