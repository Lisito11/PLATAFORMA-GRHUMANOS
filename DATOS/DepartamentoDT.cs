using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS {
    public class DepartamentoDT {
        public void Agregar(Departamento dpto) {
            using (var db = new BD_GRHUMANOSContext()) {
                db.Departamentoes.Add(dpto);
                db.SaveChanges();
            }
        }

        public List<Departamento> ListarDepartamentos() {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Departamentoes.ToList();
            }
        }

        public Departamento GetDepartamento(int id) {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Departamentoes.Find(id);
            }
        }

        public void Editar(Departamento dpto) {
            using (var db = new BD_GRHUMANOSContext()) {
                var d = db.Departamentoes.Find(dpto.idDepartamento);
                d.NombreDepartamento = dpto.NombreDepartamento;
                d.CodigoDepartamento = dpto.CodigoDepartamento;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id) {
            using (var db = new BD_GRHUMANOSContext()) {
                var dpto = db.Departamentoes.Find(id);
                db.Departamentoes.Remove(dpto);
                db.SaveChanges();
            }
        }
    }
}
