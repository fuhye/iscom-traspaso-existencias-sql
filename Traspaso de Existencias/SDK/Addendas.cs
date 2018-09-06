using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComercialSDK.SDK
{
    internal class Addendas
    {
        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fInsertaDatoAddendaDocto(int aIdAddenda, int aIdCatalogo, int aNumCampo, string aDato);

    }
}
