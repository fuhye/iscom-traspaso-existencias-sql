using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traspaso_de_Existencias.Model
{
    class TraspasoVerification
    {
        public string Product { get; set; }
        public string Warehouse { get; set; }
        public double QuantitySource { get; set; }
        public double QuantityDestiny { get; set; }
        public bool Match
        {
            get
            {
                return QuantityDestiny == QuantitySource;
            }
        }
    }
}
