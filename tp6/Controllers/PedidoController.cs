using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Entidades;
using System.IO;
using tp6.Models;

namespace tp6.Controllers
{
    public class PedidoController : Controller
    {
        static List<Pedido> listaPedidos = new List<Pedido>();
        // GET: PedidoController
        public ActionResult Index()
        {
            RepoPedidos repoPedido = new RepoPedidos();
            var listaPedidos = repoPedido.GetAll();
            return View(listaPedidos);
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoController/Create
        public ActionResult AltaPedido()
        {
            return View(new Pedido());
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPedido(Pedido nuevo)
        {

            var mensaje = " ";
            if (ModelState.IsValid)
            {
                RepoPedidos repoPedido = new RepoPedidos();
                repoPedido.AltaPedido(nuevo);
                listaPedidos.Add(nuevo);
                mensaje = "todo ok";
            }
            else
            {
                mensaje = "hubo una falla"; 
            }

            return Content(mensaje);

        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            RepoPedidos repoPedido = new RepoPedidos();
            Pedido Nuevo = new Pedido();
            Nuevo = repoPedido.GetPedido(id);
            return View(Nuevo);
        }

        // POST: PedidoController/Edit/5
        
        public ActionResult Modificar(Pedido nuevo)
        {
            if (ModelState.IsValid)
            {
                RepoPedidos repoPedido = new RepoPedidos();
                repoPedido.ModificarPedido(nuevo);
                listaPedidos.Add(nuevo);
                
            }
            else
            {
                Console.WriteLine ("hubo una falla");
            }


            return RedirectToAction("Index");
        }

        // GET: PedidoController/Delete/5
       /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: PedidoController/Delete/5
        //[HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                RepoPedidos repoPedido = new RepoPedidos();
                repoPedido.EliminarPedido(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            listaPedidos.RemoveAll(t => t.NumeroPedido == id);
            return View();
        }
    }
}
