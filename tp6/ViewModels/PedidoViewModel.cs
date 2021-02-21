using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tp6.Entidades;

namespace tp6.ViewModels
{
    public class PedidoViewModel
    {
        public int NumeroPedido { get; set; }
        public TipoPedido Tipo { get; set; }
        public Estado EstadoPedido { get; set; }
        [Required]
        [StringLength(140, MinimumLength = 10)]
        public string Observacion { get; set; }

        public Cliente Cliente { get; set; }

        public Cadete Cadete { get; set; }
        public List<Cliente> listaClientes { get; set; }
    }
}
