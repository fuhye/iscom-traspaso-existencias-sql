using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComercialSDK.SDK {
    internal static class Empresas {

        

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fPosSiguienteEmpresa(ref int aIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fPosPrimerEmpresa(ref int aIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);
    }
}
