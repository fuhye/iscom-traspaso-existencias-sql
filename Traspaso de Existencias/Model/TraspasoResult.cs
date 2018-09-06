using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traspaso_de_Existencias.Model
{
    internal class TraspasoResult
    {
        public List<string> Errors { get; set; }
        public TimeSpan TimeToRead { get; set; }
        public TimeSpan TimeToImport { get; set; }
        public TimeSpan TimeToVerify { get; set; }
        public List<TraspasoVerification> Verification { get; set; }

        public TraspasoResult()
        {
            Errors = new List<string>();
            Verification = new List<TraspasoVerification>();
            TimeToVerify = new TimeSpan();
        }
    }
}
