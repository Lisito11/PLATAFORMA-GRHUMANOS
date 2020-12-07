using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS {
   public class EmpleadoDT {
        public void Agregar(Empleado empleado) {
            using (var db = new BD_GRHUMANOSContext()) {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
            }
        }
        public List<EmpleadoLS> ListarEmpleados() {
            string sql = @"select e.Nombres, e.Apellidos, e.CodigoEmpleado, e.idEmpleado, e.Celular, c.NombreCargo, d.NombreDepartamento, e.FechaIngreso, e.Estatus, e.idCargo, e.idDepartamento, e.Salario from Empleado e inner join Cargo c on e.idCargo = c.idCargo inner join Departamento d on e.idDepartamento = d.idDepartamento WHERE e.Estatus = 1;";
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Database.SqlQuery<EmpleadoLS>(sql).ToList();
            }
        }

        public List<EmpleadoLS> ListarEmpleadosInactivos() {
            string sql = @"select e.Nombres, e.Apellidos, e.CodigoEmpleado, se.FechaSalida,e.idEmpleado, e.Celular, c.NombreCargo, d.NombreDepartamento, e.FechaIngreso, e.Estatus, e.idCargo, e.idDepartamento, e.Salario from Empleado e inner join Cargo c on e.idCargo = c.idCargo inner join Departamento d on e.idDepartamento = d.idDepartamento inner join SalidaEmpleado se on se.idEmpleado = e.idEmpleado WHERE e.Estatus = 0;";
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Database.SqlQuery<EmpleadoLS>(sql).ToList();
            }
        }

        public List<Departamento> GetDepartamentos() {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Departamentoes.ToList();
            }
        }
        public List<Cargo> GetCargos() {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Cargoes.ToList();
            }
        }

        public Empleado GetEmpleado(int id) {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Empleadoes.Find(id);
            }
        }

        public void Editar(Empleado empleado) {
            using (var db = new BD_GRHUMANOSContext()) {
                var e = db.Empleadoes.Find(empleado.idEmpleado);
                e.CodigoEmpleado = empleado.CodigoEmpleado;
                e.Nombres = empleado.Nombres;
                e.Apellidos = empleado.Apellidos;
                e.Celular = empleado.Celular;
                e.Departamento = empleado.Departamento;
                e.Cargo = empleado.Cargo;
                e.FechaIngreso = empleado.FechaIngreso;
                e.Salario = empleado.Salario;
                e.Estatus = empleado.Estatus;
                db.SaveChanges();
            }
        }

        public void InactivarEmpleado(int empleado) {
            using (var db = new BD_GRHUMANOSContext()) {
                var desempleado = db.Empleadoes.Find(empleado);
                desempleado.Estatus = 0;
                db.SaveChanges();
            }
        }
    }
}
