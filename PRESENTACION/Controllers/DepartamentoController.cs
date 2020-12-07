using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRESENTACION.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            var dptos = DepartamentoNG.ListarDepartamentos();
            return View(dptos);
        }

        public ActionResult Crear() {
            return View();
        }
        public ActionResult ViewDepartamentos() {
            var dptos = DepartamentoNG.ListarDepartamentos();
            return View(dptos);
        }
        [HttpPost]
        public ActionResult Crear(Departamento departamento) {
            try {
                if (departamento.NombreDepartamento == null) {
                    ModelState.AddModelError("", "Debe ingresar un nombre de departamento.");
                    return View(departamento);
                }

                if (departamento.CodigoDepartamento == null) {
                    ModelState.AddModelError("", "Debe ingresar el codigo del departamento.");
                    return View(departamento);
                }

                DepartamentoNG.Agregar(departamento);
                return RedirectToAction("ViewDepartamentos");
            } catch {
                ModelState.AddModelError("", "Ocurrió un error al agregar un departamento");
                return View(departamento);
            }
        }
    }
}