using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp6.Entidades
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
    public class Pedido
    {
        static int aux = 0;
        int numeroPedido;
        String observacion;
        Cliente cliente;
        Cadete cadete;
        Estado estadoPedido;
        TipoPedido tipo;
        Boolean cupon;
        double costoPedido;

        public Pedido()
        {
            this.NumeroPedido = aux++;
        }

        public Pedido(string observacion, Cliente cliente, Cadete cadete, Estado estadoPedido, TipoPedido tipo, bool cupon, double costoPedido)
        {
            this.NumeroPedido = aux++;
            this.Observacion = observacion;
            this.Cliente = cliente;
            this.EstadoPedido = estadoPedido;
            this.Tipo = tipo;
            this.Cupon = cupon;
            this.CostoPedido = costoPedido;
        }

        public int NumeroPedido { get => numeroPedido; set => numeroPedido = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
        public TipoPedido Tipo { get => tipo; set => tipo = value; }
        public bool Cupon { get => cupon; set => cupon = value; }
        public double CostoPedido { get => costoPedido; set => costoPedido = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }
    }
}
