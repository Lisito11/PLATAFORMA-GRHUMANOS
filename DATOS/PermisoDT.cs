using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS {
  public  class PermisoDT {
        public void Agregar(Permiso permisos) {
            using (var db = new BD_GRHUMANOSContext()) {
                db.Permisos.Add(permisos);
                db.SaveChanges();
            }
        }

        public List<PermisoLS> ListarPermisos() {
            string sql = @"select e.Nombres, e.Apellidos, d.NombreDepartamento, c.NombreCargo, p.idEmpleado, p.Desde, p.Hasta, p.idPermisos, p.Comentarios from 
                            Permisos p 
                            inner join Empleado e on p.idEmpleado = e.idEmpleado 
                            inner Join Departamento d on d.idDepartamento = e.idDepartamento
                            inner join Cargo as c on c.idCargo = e.idCargo;";
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Database.SqlQuery<PermisoLS>(sql).ToList();
            }
           
        }

        public List<PermisoLS> GetPermisosEmpleado(int id) {
            string sql = @"select e.Nombres, e.Apellidos, p.idEmpleado, p.Desde, p.Hasta, p.idPermisos, p.Comentarios from 
                           Permisos p inner join Empleado e on e.idEmpleado = p.idEmpleado where e.idEmpleado = @idepermiso ;";
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Database.SqlQuery<PermisoLS>(sql, new SqlParameter("@idepermiso", id)).ToList();
            }

        }
    }
}
