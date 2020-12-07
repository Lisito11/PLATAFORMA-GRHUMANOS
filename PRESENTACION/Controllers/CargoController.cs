using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRESENTACION.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        public ActionResult Index()
        {
            var cargo = CargoNG.ListarCargos();
            return View(cargo);
        }
        public ActionResult Crear() {
            return View();
        }

        public ActionResult ViewCargos() {
            var cargo = CargoNG.ListarCargos();
            return View(cargo);
        }

        [HttpPost]
        public ActionResult Crear(Cargo cargo) {
            try {
                if (cargo.NombreCargo == null) {
                    ModelState.AddModelError("", "Debe ingresar un cargo.");
                    return View(cargo);
                }

                CargoNG.Agregar(cargo);
                return RedirectToAction("ViewCargos");
            } catch {
                ModelState.AddModelError("", "Ocurrió un error al agregar un cargo");
                return View(cargo);
            }
        }
    }
}