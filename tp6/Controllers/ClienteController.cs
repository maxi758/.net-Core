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
using tp6.ViewModels;
using AutoMapper;

namespace tp6.Controllers
{
    public class ClienteController : Controller
    {
       // static List<ClienteViewModel> listaClientes = new List<ClienteViewModel>();
        private readonly IMapper _mapper;
        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            RepoCliente repoCliente = new RepoCliente();
            var listaClientes = repoCliente.GetAll();
            List<ClienteViewModel> ListClienteVM = _mapper.Map<List<ClienteViewModel>>(listaClientes);
            
            return View(ListClienteVM);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult AltaCliente()
        {
            return View(new ClienteViewModel());
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearCliente(ClienteViewModel nuevo)
        {
            Cliente ClienteDTO = _mapper.Map<Cliente>(nuevo);

            var mensaje = " ";
            if (ModelState.IsValid)
            {
                RepoCliente repoCliente = new RepoCliente();
                repoCliente.AltaCliente(ClienteDTO);
                //listaClientes.Add(nuevo);
                mensaje = "todo ok";
                
            }
            else
            {
                mensaje = "hubo una falla"; 
            }

            return Content(mensaje);

        }

        // GET: ClienteController/Edit/5
        public ActionResult EditCliente(int id)
        {
            RepoCliente repoCliente = new RepoCliente();
            ClienteViewModel Nuevo = _mapper.Map<ClienteViewModel>(repoCliente.GetCliente(id));
            
            return View(Nuevo);
        }

        // POST: ClienteController/Edit/5
        
        public ActionResult Modificar(ClienteViewModel nuevo)
        {
            Cliente ClienteDTO = _mapper.Map<Cliente>(nuevo);
            if (ModelState.IsValid)
            {
                RepoCliente repoCliente = new RepoCliente();
                repoCliente.ModificarCliente(ClienteDTO);
                //listaClientes.Add(nuevo);
                
            }
            else
            {
                Console.WriteLine ("hubo una falla");
            }


            return RedirectToAction("Index");
        }

        // GET: ClienteController/Delete/5
       /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: ClienteController/Delete/5
       
       // [ValidateAntiForgeryToken]
        public ActionResult DeleteCliente(int id)
        {
            RepoCliente repoCliente = new RepoCliente();
            ClienteViewModel Nuevo = _mapper.Map<ClienteViewModel>(repoCliente.GetCliente(id));
            return View(Nuevo);
        }

        [HttpPost]
        public ActionResult Borrar(int id)
        {
            try
            {
                RepoCliente repoCliente = new RepoCliente();
                repoCliente.EliminarCliente(id);
              
            }
            catch
            {
                throw;
            }
            // listaClientes.RemoveAll(t => t.Id == id);
            return RedirectToAction("Index");
        }
    }
}
