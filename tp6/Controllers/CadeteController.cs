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

namespace tp6.Controllers
{
    public class CadeteController : Controller
    {
        //static List<Cadete> listaCadetes = new List<Cadete>();
       
        private readonly IMapper _mapper;

        public CadeteController(IMapper mapper)
        {
            _mapper = mapper;
        }
         // GET: CadeteController
        public ActionResult Index()
        {
            RepoCadetes repoCadete = new RepoCadetes();
            var listaCadetes = repoCadete.GetAll();
            List<CadeteViewModel> CadeteVM = _mapper.Map<List<CadeteViewModel>>(listaCadetes);
            return View(CadeteVM);
        }

        // GET: CadeteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadeteController/Create
        public ActionResult AltaCadete()
        {
            return View(new CadeteViewModel());
        }

        // POST: CadeteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearCadete(CadeteViewModel nuevo)
        {
            Cadete CadeteDTO = _mapper.Map<Cadete>(nuevo);
            var mensaje = " ";
            if (ModelState.IsValid)
            {
                RepoCadetes repoCadete = new RepoCadetes();
                repoCadete.AltaCadete(CadeteDTO);
                //listaCadetes.Add(nuevo);
                mensaje = "todo ok";
            }
            else
            {
                mensaje = "hubo una falla"; 
            }

            return Content(mensaje);

        }

        // GET: CadeteController/Edit/5
        public ActionResult Edit(int id)
        {
            RepoCadetes repoCadete = new RepoCadetes();
            CadeteViewModel Nuevo = _mapper.Map<CadeteViewModel>(repoCadete.GetCadete(id));
            
            return View(Nuevo);
        }

        // POST: CadeteController/Edit/5
        
        public ActionResult Modificar(CadeteViewModel nuevo)
        {
            Cadete CadeteDTO = _mapper.Map<Cadete>(nuevo);
            if (ModelState.IsValid)
            {
                RepoCadetes repoCadete = new RepoCadetes();
                repoCadete.ModificarCadete(CadeteDTO);
                //listaCadetes.Add(nuevo);
                
            }
            else
            {
                Console.WriteLine ("hubo una falla");
            }


            return RedirectToAction("Index");
        }

        // GET: CadeteController/Delete/5
       /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: CadeteController/Delete/5
        //[HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                RepoCadetes repoCadete = new RepoCadetes();
                repoCadete.EliminarUsuario(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            //listaCadetes.RemoveAll(t => t.Id == id);
            return View();
        }
    }
}
