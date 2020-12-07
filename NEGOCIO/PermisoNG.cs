using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDAD;
namespace NEGOCIO {
   public class PermisoNG {
        private static PermisoDT obj = new PermisoDT();

        public static void Agregar(Permiso permiso) {
            obj.Agregar(permiso);
        }

        public static List<PermisoLS> ListarPermisos() {
            return obj.ListarPermisos();
        }

        public static List<PermisoLS> GetPermisosEmpleado(int id) {
            return obj.GetPermisosEmpleado(id);
        }
    }
}
