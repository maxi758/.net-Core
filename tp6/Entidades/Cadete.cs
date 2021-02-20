using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp6.Entidades
{
    public enum Vehiculo
    {
        bicicleta, auto, moto
    }
    public class Cadete : Persona
    {
        List<Pedido> listaPedidos;
    }
}
