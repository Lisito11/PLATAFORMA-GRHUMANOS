using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO {
    public class Meses {
        public Dictionary<string, int> meses = new Dictionary<string, int>() { { "Enero", 1 },
            { "Febrero", 2 }, {"Marzo",3 }, {"Abril",4 }, {"Mayo",5 }, {"Junio", 6},{"Julio",7 },
            { "Agosto",8 },{"Septiembre", 9 },{"Octubre",10 }, {"Noviembre",11 }, {"Diciembre",12 } };
        
        public static Dictionary<int, string> numMeses = new Dictionary<int, string>() { { 1,"Enero" },
            { 2 , "Febrero" }, {3,"Marzo" }, {4,"Abril" }, {5,"Mayo" }, {6,"Junio" },{7,"Julio" },
            { 8,"Agosto" },{9,"Septiembre" },{10,"Octubre" }, {11,"Noviembre" }, {12,"Diciembre" } };
        public Meses() { 
        }
        public Dictionary<string, int> MesesDic() {
            return meses;
        }

        public static string NameMes(int num) => numMeses[num];

    }
}
