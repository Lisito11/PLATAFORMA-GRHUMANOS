using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NEGOCIO {
    public class NonimaNG {
        private static NominaDT obj = new NominaDT();
        public static void Agregar(Nomina nomina) {
            obj.Agregar(nomina);
        }

        public static List<Nomina> ListarNominas() {
            return obj.ListarNominas();
        }

        public static Nomina GetNomina(int id) {
            return obj.GetNomina(id);
        }

        public static string GetSalarioEmpleados() {
            decimal salarioTotal = 0;
            foreach (var salario in obj.GetSalarioEmpleados()) {
                salarioTotal += salario.Salario;
            }
            return salarioTotal.ToString();

        }

        public static List<SelectListItem> GetMeses() {
            Meses meses = new Meses();
            var listado = new List<SelectListItem>();
            foreach (var mes in meses.MesesDic()) {
                var item = new SelectListItem {
                    Text = mes.Key,
                    Value = mes.Value.ToString()
                };
                listado.Add(item);
            }

            return listado;
        }

        public static void Editar(Nomina nomina) {
            obj.Editar(nomina);
        }

        public static void Eliminar(int id) {
            obj.Eliminar(id);
        }

    }
}
