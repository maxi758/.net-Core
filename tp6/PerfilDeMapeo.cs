using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Entidades;
using tp6.ViewModels;

namespace tp6
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();

            CreateMap<Cliente, ClienteViewModel>().ReverseMap();

            CreateMap<Pedido, PedidoViewModel>().ReverseMap();

            CreateMap<Pedido, ModificarPedidoViewModel>().ReverseMap();

            CreateMap<Pedido, PedidoPorCadeteViewModel>().ReverseMap();
        }
    }
}
