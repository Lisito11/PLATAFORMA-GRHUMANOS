using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO {
   public class LicenciaNG {
        private static LicenciaDT obj  = new LicenciaDT();

        public static void Agregar(Licencia licencia) {
            obj.Agregar(licencia);
        }

        public static List<LicenciaLS> ListarLicencias() {
            return obj.ListarLicencias();
        }
    }
}
