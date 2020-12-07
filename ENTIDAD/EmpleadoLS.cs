using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD {
    public class EmpleadoLS {
        public int idEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FullName { get { return $"{Apellidos} {Nombres}"; } }
        public string Celular { get; set; }
        public int idDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int idCargo { get; set; }
        public string NombreCargo { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public System.DateTime FechaSalida { get; set; }
        public decimal Salario { get; set; }
        public int Estatus { get; set; }

    }
}
