using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENTIDAD;
using NEGOCIO;
namespace PRESENTACION.Controllers {
    public class VacacionesController : Controller {
        // GET: Vacaciones
        public ActionResult Index() {
            var vacaciones = VacacionesNG.ListarVacaciones();
            return View(vacaciones);
        }
        public ActionResult ListaEmpleadosVacaciones() {
            var empleado = EmpleadoNG.ListarEmpleados();
            return View(empleado);
        }

        public ActionResult Crear(int id) {
            var empleado = EmpleadoNG.GetEmpleado(id);
            ViewBag.idEmpleado = empleado.idEmpleado;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Vacacione vacaciones) {
            try {
                if (vacaciones.Desde == null) {
                    ModelState.AddModelError("", "Debe ingresar cuando inician las vacaciones");
                    return View(vacaciones);
                }
                if (vacaciones.Hasta == null) {
                    ModelState.AddModelError("", "Debe ingresar cuando terminan las vacaciones");
                    return View(vacaciones);
                }
                if (vacaciones.Age == null) {
                    ModelState.AddModelError("", "Debe ingresar el año de la licencia");
                    return View(vacaciones);
                }

                VacacionesNG.Agregar(vacaciones);
                return RedirectToAction("Index");

            } catch {
                ModelState.AddModelError("", "Ocurrió un error al agregar las vacaciones");
                return View(vacaciones);

            }
        }

    }
}