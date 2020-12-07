using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS {
    public class CargoDT {
        public void Agregar(Cargo cargo) {
            using (var db = new BD_GRHUMANOSContext()) {
                db.Cargoes.Add(cargo);
                db.SaveChanges();
            }
        }

        public List<Cargo> ListarCargos() {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Cargoes.ToList();
            }
        }

        public Cargo GetCargos(int id) {
            using (var db = new BD_GRHUMANOSContext()) {
                return db.Cargoes.Find(id);
            }
        }

        public void Editar(Cargo cargo) {
            using (var db = new BD_GRHUMANOSContext()) {
                var d = db.Cargoes.Find(cargo.idCargo);
                d.NombreCargo = cargo.NombreCargo;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id) {
            using (var db = new BD_GRHUMANOSContext()) {
                var cargo = db.Cargoes.Find(id);
                db.Cargoes.Remove(cargo);
                db.SaveChanges();
            }
        }
    }
}
