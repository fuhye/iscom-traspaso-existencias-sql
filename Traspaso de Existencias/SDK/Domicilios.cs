using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComercialSDK.SDK
{
    public class Domicilios
    {
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscaDireccionCteProv(string aCodCteProv, int aTipoDireccion);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscaDireccionEmpresa();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscaDireccionDocumento(int aIdDocumento, int aTipoDireccion);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAltaDireccion(ref int aIdDireccion, ref AbstractDataTypes.tDireccion astDireccion);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fLeeDatoDireccion(string aCampo, StringBuilder aValr, int aLen);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fEditaDireccion();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSetDatoDireccion(string aCampo, string aValr);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fGuardaDireccion();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fCancelarModificacionDireccion();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fInsertaDireccion();
    }
}
