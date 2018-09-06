using System.Runtime.InteropServices;
using System.Text;

namespace ComercialSDK.SDK
{
    public static class Unidades
    {
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscaUnidad(string aNombreUnidad);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscaIdUnidad(int aIdUnidad);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosPrimerUnidad();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosSiguienteUnidad();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosEOFUnidad();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fEditaUnidad();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fGuardaUnidad();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSetDatoUnidad(string Campo, string Valor);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fLeeDatoUnidad(string aCampo, StringBuilder aValor, int aLen);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAltaUnidad(ref int aIdUnidad, ref AbstractDataTypes.tUnidad astUnidad);
    }
}
