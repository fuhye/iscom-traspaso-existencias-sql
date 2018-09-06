using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traspaso_de_Existencias.Model
{
    internal class TraspasoParameters
    {
        public Company Source { get; set; }
        public Company DestinationDb { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<Product> Products { get; set; }
    }
}
