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
using AutoMapper;
using tp6.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace tp6.Controllers
{
    public class PedidoController : Controller
    {
        //static List<Pedido> listaPedidos = new List<Pedido>();
        private readonly IMapper _mapper;

        public PedidoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: PedidoController
        public IActionResult Index()
        {
            RepoPedidos repoPedido = new RepoPedidos();
            var listaPedidos = repoPedido.GetAll();
            List<PedidoViewModel> PedidoVM = _mapper.Map<List<PedidoViewModel>>(listaPedidos);
            return View(PedidoVM);
        }

        // GET: PedidoController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoController/Create
        public IActionResult AltaPedido()
        {
            var repoCliente = new RepoCliente();
            var repoCadete = new RepoCadetes();
         
            var PedidoViewModel = new PedidoViewModel
            {
                
                listadoDeCadetes = _mapper.Map<List<CadeteViewModel>>(repoCadete.GetAll()),
                listadoDeClientes = _mapper.Map<List<ClienteViewModel>>(repoCliente.GetAll())
            };

            return View(PedidoViewModel);
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearPedido(PedidoViewModel nuevo)
        {
            try
            {
                Pedido PedidoDTO = new Pedido();
                PedidoDTO = _mapper.Map<Pedido>(nuevo);            
                RepoPedidos repoPedido = new RepoPedidos();
                repoPedido.AltaPedido(PedidoDTO);
                //listaPedidos.Add(nuevo);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }                        
           
            return Redirect("../Home/Index");
        }

        // GET: PedidoController/Edit/5
        public IActionResult Edit(int id)
        {
            RepoPedidos repoPedido = new RepoPedidos();
            Pedido Nuevo = new Pedido();
            Nuevo = repoPedido.GetPedido(id);
            return View(Nuevo);
        }

        // POST: PedidoController/Edit/5
        
        public IActionResult Modificar(Pedido nuevo)
        {
            if (ModelState.IsValid)
            {
                RepoPedidos repoPedido = new RepoPedidos();
                repoPedido.ModificarPedido(nuevo);
                //listaPedidos.Add(nuevo);
                
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
        public IActionResult Delete(int id)
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
            //listaPedidos.RemoveAll(t => t.NumeroPedido == id);
            return View();
        }
    }
}
