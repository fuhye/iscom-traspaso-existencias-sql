using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ComercialSDK.SDK
{
    public static class Movimientos
    {
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAltaMovimiento(Int32 aIdDocto, ref Int32 aMovtoId, ref AbstractDataTypes.tMovimiento aMovto);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAltaMovimientoSeriesCapas(Int32 lIdMovimiento, ref AbstractDataTypes.tSeriesCapas lSeriesCapas);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscarIdMovimiento(int lIdMovimiento);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fLeeDatoMovimiento(string aCampo, StringBuilder aValr, int aLen);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fEditarMovimiento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fGuardaMovimiento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSetDatoMovimiento(string aCampo, string aValor);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fCancelaCambiosMovimiento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSetFiltroMovimiento(int aIdDocumento);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fCancelaFiltroMovimiento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosPrimerMovimiento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosSiguienteMovimiento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosMovimientoEOF();
    }
}
