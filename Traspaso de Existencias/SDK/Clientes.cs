using System.Runtime.InteropServices;
using System.Text;

namespace ComercialSDK.SDK
{
    public static class Clientes {

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fInsertaCteProv();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAltaCteProv(ref int aIdCteProv, ref AbstractDataTypes.tCteProv astCteProv);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fLlenaRegistroCteProv(AbstractDataTypes.tCteProv CteProv, int aEsAlta);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSetDatoCteProv(string Campo, string Valor);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fGuardaCteProv();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscaIdCteProv(int lIdCteProv);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscaCteProv(string lCodCteProv);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fLeeDatoCteProv(string aCampo, StringBuilder aValr, int aLen);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBorraCteProv();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fEditaCteProv();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fCancelarModificacionCteProv();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosPrimerCteProv();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosSiguienteCteProv();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosEOFCteProv();
    }
}
