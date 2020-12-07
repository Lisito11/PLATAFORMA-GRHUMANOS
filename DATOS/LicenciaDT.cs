using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS {
   public class LicenciaDT {
        public void Agregar(Licencia licencia) {
            using (var db = new BD_GRHUMANOSContext()) {
                db.Licencias.Add(licencia);
                db.SaveChanges();
            }
        }

        public List<LicenciaLS> ListarLicencias() {
            string sql = @"select e.Nombres, e.Apellidos, v.idEmpleado, v.Comentarios, v.Desde, v.Hasta, v.idLicencias, v.Motivo from 
                            Licencias v inner join Empleado e on v.idEmpleado = e.idEmpleado;";
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Database.SqlQuery<LicenciaLS>(sql).ToList();
            }
        }
    }
}
