using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NEGOCIO {
   public class EmpleadoNG {
        private static EmpleadoDT obj = new EmpleadoDT();


        public static void Agregar(Empleado empleado) {
            obj.Agregar(empleado);
        }

        public static List<EmpleadoLS> ListarEmpleados() {
            return obj.ListarEmpleados();
        }
        public static List<EmpleadoLS> ListarEmpleadosInactivos() {
            return obj.ListarEmpleadosInactivos();
        }
        public static Empleado GetEmpleado(int id) {
            return obj.GetEmpleado(id);
        }

        public static List<SelectListItem> GetCargos() {
            var listado = new List<SelectListItem>();
            foreach (var element in obj.GetCargos()) {
                var item = new SelectListItem {
                    Text = element.NombreCargo,
                    Value = element.idCargo.ToString()
                };

                listado.Add(item);
                

            }

            return listado;
        }

        public static List<SelectListItem> GetDepartamentos() {
            var listado = new List<SelectListItem>();
            foreach (var element in obj.GetDepartamentos()) {
                var item = new SelectListItem();
                item.Text = element.NombreDepartamento;
                item.Value = element.idDepartamento.ToString();
                listado.Add(item);
            }

            return listado;
        }

        public static void Editar(Empleado empleado) {
            obj.Editar(empleado);
        }

        public static void InactivarEmpleado(int empleado) {
            obj.InactivarEmpleado(empleado);
        }
    }
}
