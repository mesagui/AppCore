using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.BD;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Controllers
{
    public class PeliculaController : Controller
    {
        public SimuladorContext context = new SimuladorContext();
        public IActionResult Index()
        {
            var peliculas = context.Peliculas.Include(a=>a.Director).ToList();
            return View(peliculas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Directores = context.Directors.ToList();
            return View(new Pelicula());
        }

        [HttpPost]
        public IActionResult Crear(Pelicula pelicula)
        {
            validarCodigoPelicula(pelicula);
            validarDatos(pelicula);
           
            if (ModelState.IsValid) {
                pelicula.Anio = DateTime.Now;
                context.Peliculas.Add(pelicula);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Directores = context.Directors.ToList();
            return View(pelicula);
        }
        public void validarDatos(Pelicula peli) {
            if (peli.Nombre=="" || peli.Nombre==null)
            {
                ModelState.AddModelError("Nombre", "El campo Nombre es obligatorio");
            }
        }
        public void validarCodigoPelicula(Pelicula peli) {
            if (peli.CodigoPelicula == "" || peli.CodigoPelicula == null)
            {
                ModelState.AddModelError("PeliculaCodigo1", "El campo Pelicula es requerido");
            }
            else{
                var obj = context.Peliculas.Where(a => a.CodigoPelicula.Equals(peli.CodigoPelicula)).FirstOrDefault();
               
                string peliobtenida = obj.CodigoPelicula;

                if (peli.CodigoPelicula == peliobtenida.ToString())
                {
                    ModelState.AddModelError("PeliculaCodigo", "El codigo de pelicula ya existe");
                }
            }
        }
    }
}