using System.Runtime.InteropServices;
using System.Text;

namespace ComercialSDK.SDK
{
    internal static class Almacenes
    {
        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fBuscaAlmacen(string lCodCteProv);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fBuscaIdAlmacen(int aIdAlmacen);

       [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fLeeDatoAlmacen(string aCampo, StringBuilder aValr, int aLen);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fInsertaAlmacen();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fEditaAlmacen();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fGuardaAlmacen();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fCancelarModificacionAlmacen();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fSetDatoAlmacen(string aCampo, string aValor);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fPosPrimerAlmacen();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fPosSiguienteAlmacen();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fPosEOFAlmacen();
    }
}
