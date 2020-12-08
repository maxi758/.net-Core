using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp6.Entidades
{
    public enum Estado
    {
        Recibido = 0, Realizandose, Entregado, Desconocido
    }
    
    public enum TipoPedido
    {
        Express,
        Delicado,
        Ecologico,
    }
    public class Pedidos
    {
        int numeroPedido;
        String Observacion;
        Cliente cliente;
        Estado estadoPedido;
        TipoPedido tipo;
        Boolean cupon;
        double costoPedido;

        public Pedidos()
        {
        }

        public Pedidos(int numeroPedido, string observacion, Cliente cliente, Estado estadoPedido, TipoPedido tipo, bool cupon, double costoPedido)
        {
            this.NumeroPedido = numeroPedido;
            Observacion1 = observacion;
            this.Cliente = cliente;
            this.EstadoPedido = estadoPedido;
            this.Tipo = tipo;
            this.Cupon = cupon;
            this.CostoPedido = costoPedido;
        }

        public int NumeroPedido { get => numeroPedido; set => numeroPedido = value; }
        public string Observacion1 { get => Observacion; set => Observacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
        public TipoPedido Tipo { get => tipo; set => tipo = value; }
        public bool Cupon { get => cupon; set => cupon = value; }
        public double CostoPedido { get => costoPedido; set => costoPedido = value; }
    }
}
