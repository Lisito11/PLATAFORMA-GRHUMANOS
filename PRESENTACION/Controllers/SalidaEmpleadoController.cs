using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRESENTACION.Controllers {
    public class SalidaEmpleadoController : Controller {
        // GET: SalidaEmpleado
        public ActionResult Index() {
            var iempleados = SalidaEmpleadoNG.ListarEmpleadosInactivos();
            return View(iempleados);
        }
        public ActionResult ViewSalidaEmpleado() {
            var iempleados = SalidaEmpleadoNG.ListarEmpleadosInactivos();
            return View(iempleados);
        }
        public ActionResult ListaEmpleadosInactivar() {
            var empleado = EmpleadoNG.ListarEmpleados();
            return View(empleado);
        }

        public ActionResult Crear(int id) {
            ViewBag.fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
            var empleado = EmpleadoNG.GetEmpleado(id);
            ViewBag.idEmpleado = empleado.idEmpleado;
            ViewBag.ListadoSalidas = SalidaEmpleadoNG.ListarSalidas();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(SalidaEmpleado sempleado, Empleado empleado) {
            try {

                if (sempleado.idEmpleado == null) {
                    ModelState.AddModelError("", "Debe ingresar el id del empleado.");
                    return View(sempleado);
                }

                if (sempleado.TipoSalida == null) {
                    ModelState.AddModelError("", "Debe ingresar el tipo de salida del empleado");
                    return View(sempleado);
                }

                if (sempleado.Motivo == null) {
                    ModelState.AddModelError("", "Debe ingresar el motivo de salida del empleado");
                    return View(sempleado);
                }

                if (sempleado.FechaSalida == null) {
                    ModelState.AddModelError("", "Debe ingresar la fecha de salida del empleado");
                    return View(sempleado);
                }


                EmpleadoNG.InactivarEmpleado(sempleado.idEmpleado);
                SalidaEmpleadoNG.Agregar(sempleado);
                return RedirectToAction("ViewSalidaEmpleado");
            } catch {
                ModelState.AddModelError("", "Ocurrió un error al agregar el empleado");
                return View(sempleado);
            }


        }
    }
}