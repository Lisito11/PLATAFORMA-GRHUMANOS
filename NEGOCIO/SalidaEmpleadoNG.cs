using ENTIDAD;
using DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NEGOCIO {
   public class SalidaEmpleadoNG {
        private static SalidaEmpleadoDT obj = new SalidaEmpleadoDT();

        public static void Agregar(SalidaEmpleado salidaEmpleado) {
            obj.Agregar(salidaEmpleado);
        }


        public static List<SalidaEmpleadoLS> ListarEmpleadosInactivos() {
            return obj.ListarEmpleadosInactivos();
        }

        public static List<SelectListItem> ListarSalidas() {
            Dictionary<string, string> tiposalidas = new Dictionary<string, string>() { { "Renuncia", "Renuncia" },
            { "Despido", "Despido" },{ "Desahucio", "Desahucio" }};

            var listado = new List<SelectListItem>();
            foreach (var element in tiposalidas) {
                var item = new SelectListItem {
                    Text = element.Key,
                    Value = element.Value
                };

                listado.Add(item);


            }

            return listado;
        }
    }
}
