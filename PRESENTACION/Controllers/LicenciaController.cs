using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENTIDAD;
using NEGOCIO;
namespace PRESENTACION.Controllers
{
    public class LicenciaController : Controller {
        // GET: Licencia
        public ActionResult Index() {
            var licencias = LicenciaNG.ListarLicencias();
            return View(licencias);
        }


        public ActionResult ListaEmpleadosLicencias() {
            var empleado = EmpleadoNG.ListarEmpleados();
            return View(empleado);
        }



        public ActionResult Crear(int id) {
            var empleado = EmpleadoNG.GetEmpleado(id);
            ViewBag.idEmpleado = empleado.idEmpleado;
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Licencia licencia) {
            try {
                if (licencia.Desde == null) {
                    ModelState.AddModelError("", "Debe ingresar cuando inicia la licencia");
                    return View(licencia);
                }
                if (licencia.Hasta == null) {
                    ModelState.AddModelError("", "Debe ingresar cuando termina la licencia");
                    return View(licencia);
                }
                if (licencia.Motivo == null) {
                    ModelState.AddModelError("", "Debe ingresar el motivo de la licencia");
                    return View(licencia);
                }
                LicenciaNG.Agregar(licencia);
                return RedirectToAction("Index");

            } catch {
                ModelState.AddModelError("", "Ocurrió un error al agregar la licencia");
                return View(licencia);

            }
        }
    }
}