using System;
using ENTIDAD;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS {
    public class SalidaEmpleadoDT {
        public void Agregar(SalidaEmpleado salidaEmpleado) {
            using (var db = new BD_GRHUMANOSContext()) {
                db.SalidaEmpleadoes.Add(salidaEmpleado);
                db.SaveChanges();
            }
        }

        public List<SalidaEmpleadoLS> ListarEmpleadosInactivos() {
            string sql = @"select e.Nombres, e.Apellidos, se.idEmpleado, se.FechaSalida, se.idSalidaEmpleado, se.Motivo, se.TipoSalida from SalidaEmpleado se inner join Empleado e on e.idEmpleado = se.idEmpleado;";
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Database.SqlQuery<SalidaEmpleadoLS>(sql).ToList();
            }
            
        }

    }
}
