using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDAD;
namespace NEGOCIO {
   public class VacacionesNG {
        private static VacacionesDT obj = new VacacionesDT();

        public static void Agregar(Vacacione vacaciones) {
            obj.Agregar(vacaciones);
        }

        public static List<VacacionesLS> ListarVacaciones() {
            return obj.ListarVacaciones();
        }
    }
}
