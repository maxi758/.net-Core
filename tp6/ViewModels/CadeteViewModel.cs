using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Entidades;

namespace tp6.ViewModels
{
    public class CadeteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Activo { get; set; }
        public List<Pedido> ListaPedidos {get; set;}
    }
}
