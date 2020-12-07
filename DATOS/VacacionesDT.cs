using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
namespace DATOS {
  public class VacacionesDT {
        public void Agregar(Vacacione vacaciones) {
            using (var db = new BD_GRHUMANOSContext()) {
                db.Vacaciones.Add(vacaciones);
                db.SaveChanges();
            }
        }

        public List<VacacionesLS> ListarVacaciones() {
            string sql = @"select e.Nombres, e.Apellidos, v.idEmpleado, v.Comentarios, v.Desde, v.Hasta, v.idVacaciones from 
                           Vacaciones v inner join Empleado e on v.idEmpleado = e.idEmpleado;";
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Database.SqlQuery<VacacionesLS>(sql).ToList();
            }
        }
    }
}
