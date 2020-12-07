using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRESENTACION.Controllers {
    public class NominaController : Controller {
        static Nomina nomina1;

        public ActionResult Index() {
            var nominas = NonimaNG.ListarNominas();
            return View(nominas);
        }
        public ActionResult ViewNonima() {
            var nominas = NonimaNG.ListarNominas();
            return View(nominas);
        }
        public ActionResult Validar() {
            ViewBag.AgeActual = DateTime.Now.ToString("yyyy").ToString();
            ViewBag.MesActual = DateTime.Now.ToString("M");
            ViewBag.ListadoMeses = NonimaNG.GetMeses();
            return View();
        }
        [HttpPost]
        public ActionResult Validar(Nomina nomina) {

            try {
                if (nomina.Age == null) {
                    ModelState.AddModelError("", "Debe ingresar el año de la nonima.");
                    return View(nomina);
                }

                if (nomina.Mes == null) {
                    ModelState.AddModelError("", "Debe ingresar el mes de la nomina.");
                    return View(nomina);
                }
                nomina1 = nomina;
                return RedirectToAction("Crear");
            } catch {
                ModelState.AddModelError("", "Ocurrió un error al validar la nonima");
                return View(nomina);
            }
        }

        public ActionResult Crear() {
            ViewBag.SalarioTotal = NonimaNG.GetSalarioEmpleados().ToString();
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Nomina nomina) {

            try {
                nomina1.MontoTotal = nomina.MontoTotal;
                if (nomina1.MontoTotal == null) {
                    ModelState.AddModelError("", "Debe Ingresar el monto total.");
                    return View(nomina1);
                }

                NonimaNG.Agregar(nomina1);
                return RedirectToAction("ViewNonima");

            } catch {
                ModelState.AddModelError("", "Ocurrió un error al validar la nonima");
                return View(nomina1);
            }

        }
    }
}