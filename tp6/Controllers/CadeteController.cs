using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Entidades;
using System.IO;

namespace tp6.Controllers
{
    public class CadeteController : Controller
    {
        static List<Cadete> listaCadetes = new List<Cadete>();
        // GET: CadeteController
        public ActionResult Index()
        {
            return View(listaCadetes);
        }

        // GET: CadeteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadeteController/Create
        public ActionResult AltaCadete()
        {
            return View(new Cadete());
        }

        // POST: CadeteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearCadete(Cadete nuevo)
        {
            try
            {
                string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
                command.CommandText = "Insert into cadete(nombre, direccion, telefono) values(@nombre,@direccion, @telefono) ";
                command.Parameters.AddWithValue("@nombre", nuevo.Nombre);
                command.Parameters.AddWithValue("@direccion", nuevo.Direccion);
                command.Parameters.AddWithValue("@telefono", nuevo.Telefono);
                command.ExecuteNonQuery();
                conexion.Close();
                var mensaje = " ";
                if (ModelState.IsValid)
                {
                    listaCadetes.Add(nuevo);
                    mensaje = "todo ok";
                }
                else
                {
                    mensaje = "hubo una falla";
                }

                return Content(mensaje);
            }
            catch (Exception)
            {
                return Content("Error");
                throw;
            }
            
        }

        // GET: CadeteController/Edit/5
        public ActionResult Edit(int id)
        {
            Cadete Nuevo = Helper.BuscarPorId(listaCadetes, id);
            return View(Nuevo);
        }

        // POST: CadeteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(Cadete Nuevo)
        {
            /*try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
            Cadete Modificado = Helper.BuscarPorId(listaCadetes, Nuevo.Id);


            Modificado.Nombre = Nuevo.Nombre;
            Modificado.Direccion = Nuevo.Direccion;
            Modificado.Telefono = Nuevo.Telefono;


            return RedirectToAction("Index");
        }

        // GET: CadeteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadeteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            /*try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
            listaCadetes.RemoveAll(t => t.Id == id);
            return View();
        }
    }
}
