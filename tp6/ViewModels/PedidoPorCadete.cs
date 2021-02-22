using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using tp6.Entidades;

namespace tp6.ViewModels
{  
    public class PedidoPorCadeteViewModel
    {
        public int NumeroPedido { get; set; }
        public TipoPedido Tipo { get; set; }
        public Estado EstadoPedido { get; set; }
        [Required]
        [StringLength(140)]
        public string Observacion { get; set; }

        public Cliente Cliente { get; set; }

        public int IdCadete { get; set; }
        public List<Pedido> listaPedidos { get; set; }
        
    }
}
