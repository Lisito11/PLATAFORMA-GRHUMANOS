using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENTIDAD;
using NEGOCIO;
namespace PRESENTACION.Controllers
{
    public class PermisoController : Controller
    {
        // GET: Permiso
        public ActionResult Index()
        {
            var permisos = PermisoNG.ListarPermisos();
            return View(permisos);
        }

        public ActionResult ViewPermisos() {
            var permisos = PermisoNG.ListarPermisos();
            return View(permisos);
        }

        public ActionResult ListaEmpleadosPermisos() {
            var empleado = EmpleadoNG.ListarEmpleados();
            return View(empleado);
        }

        public ActionResult ListaEmpleadosVerPermisos() {
            var empleado = PermisoNG.ListarPermisos();
            return View(empleado);
        }

        public ActionResult PermisosEmpleado(int id) {
            var empleado = PermisoNG.GetPermisosEmpleado(id);
            return View(empleado);
        }


        public ActionResult Crear(int id) {
            var empleado = EmpleadoNG.GetEmpleado(id);
            ViewBag.idEmpleado = empleado.idEmpleado;
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Permiso permiso) {
            try {
                if (permiso.Desde == null) {
                    ModelState.AddModelError("", "Debe ingresar cuando inicia el permiso");
                    return View(permiso);
                }
                if (permiso.Hasta == null) {
                    ModelState.AddModelError("", "Debe ingresar cuando termina el permiso");
                    return View(permiso);
                }
                PermisoNG.Agregar(permiso);
                return RedirectToAction("ViewPermisos");

            } catch {
                ModelState.AddModelError("", "Ocurrió un error al agregar el permiso");
                return View(permiso);

            }

        }
    }
}