using ENTIDAD;
using NEGOCIO;
using System;
using System.Web.Mvc;

namespace PRESENTACION.Controllers {
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            var empleado = EmpleadoNG.ListarEmpleados();
            return View(empleado);
        }

        public ActionResult EmpleadosInactivos() {
            var empleado = EmpleadoNG.ListarEmpleadosInactivos();
            return View(empleado);
        }

        public ActionResult ViewEmpleados() {
            var empleado = EmpleadoNG.ListarEmpleados();
            return View(empleado);
        }


        public ActionResult Crear() {
            ViewBag.fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
            // Listas de cargos
            ViewBag.ListadoCargos = EmpleadoNG.GetCargos();
            // Listas de departamentos
            ViewBag.ListadoDepartamentos = EmpleadoNG.GetDepartamentos();
            return View();

        }
        [HttpPost]
        public ActionResult Crear(Empleado empleado) {
            try {
                if (empleado.idDepartamento == null) {
                    ModelState.AddModelError("", "Debe ingresar el departamento del empleado.");
                    return View(empleado);
                }
                if (empleado.idCargo == null) {
                    ModelState.AddModelError("", "Debe ingresar el cargo del empleado.");
                    return View(empleado);
                }

                if (empleado.CodigoEmpleado == null) {
                    ModelState.AddModelError("", "Debe ingresar el codigo del empleado.");
                    return View(empleado);
                }

                if (empleado.Nombres == null) {
                    ModelState.AddModelError("", "Debe ingresar los nombres del empleado");
                    return View(empleado);
                }

                if (empleado.Apellidos == null) {
                    ModelState.AddModelError("", "Debe ingresar los apellidos del empleado");
                    return View(empleado);
                }

                if (empleado.FechaIngreso == null) {
                    ModelState.AddModelError("", "Debe ingresar la fecha de ingreso del empleado");
                    return View(empleado);
                }
                if (empleado.Salario == null) {
                    ModelState.AddModelError("", "Debe ingresar el salario del empleado");
                    return View(empleado);
                }
                empleado.Estatus = 1;
                EmpleadoNG.Agregar(empleado);
                return RedirectToAction("ViewEmpleados");
            } catch {
                ModelState.AddModelError("", "Ocurrió un error al agregar el empleado");
                return View(empleado);
            }
        }       
    }
}