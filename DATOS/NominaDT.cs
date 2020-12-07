using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
namespace DATOS {
    public class NominaDT {
        public void Agregar(Nomina nomina) {
            using (var db = new BD_GRHUMANOSContext()) {
                db.Nominas.Add(nomina);
                db.SaveChanges();
            }
        }

        public List<Nomina> ListarNominas() {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Nominas.ToList();
            }
        }

        public Nomina GetNomina(int id) {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Nominas.Find(id);
            }
        }

        public List<Empleado> GetSalarioEmpleados() {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Empleadoes.SqlQuery("SELECT * FROM dbo.Empleado WHERE Estatus = 1").ToList();
            }
        }



        public void Editar(Nomina nomina) {
            using (var db = new BD_GRHUMANOSContext()) {
                var d = db.Nominas.Find(nomina.idNomina);
                d.Age = nomina.Age;
                d.Mes = nomina.Mes;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id) {
            using (var db = new BD_GRHUMANOSContext()) {
                var nomina = db.Nominas.Find(id);
                db.Nominas.Remove(nomina);
                db.SaveChanges();
            }
        }
    } 
}
