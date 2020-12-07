using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO {
    public class CargoNG {
        private static CargoDT obj = new CargoDT();

        public static void Agregar(Cargo cargo) {
            obj.Agregar(cargo);
        }

        public static List<Cargo> ListarCargos() {
            return obj.ListarCargos();
        }

        public static Cargo GetCargo(int id) {
            return obj.GetCargos(id);
        }

        public static void Editar(Cargo cargo) {
            obj.Editar(cargo);
        }

        public static void Eliminar(int id) {
            obj.Eliminar(id);
        }
    }
}
