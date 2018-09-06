using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComercialSDK.SDK
{
    internal class Agentes
    {
        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fBuscaIdAgente(int lIdCteProv);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fBuscaAgente(string lCodCteProv);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fLeeDatoAgente(string aCampo, StringBuilder aValr, int aLen);
    }
}
