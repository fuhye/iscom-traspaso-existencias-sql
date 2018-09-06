using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Traspaso_de_Existencias.Error
{
    internal class TraspasoExistenciasException : Exception
    {
        public TraspasoExistenciasException()
        {
        }

        public TraspasoExistenciasException(string message) : base(message)
        {
        }

        public TraspasoExistenciasException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TraspasoExistenciasException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
