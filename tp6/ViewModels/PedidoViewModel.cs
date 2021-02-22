using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using tp6.Entidades;

namespace tp6.ViewModels
{
    public enum Estado
    {
        Recibido = 1, Realizandose, Entregado, Desconocido
    }

    public enum TipoPedido
    {
        Express = 1,
        Delicado,
        Ecologico,
    }
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
        public List<CadeteViewModel> listadoDeCadetes;
        public List<ClienteViewModel> listadoDeClientes;
    }
}
