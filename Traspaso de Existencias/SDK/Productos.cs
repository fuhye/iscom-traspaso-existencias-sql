using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComercialSDK.SDK
{
    public static class Productos
    {
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAltaProducto(ref int aIdProducto, ref AbstractDataTypes.tProducto aProducto);

        [DllImport(SDKSettings.LIBRARY_DLL, CharSet = CharSet.Ansi, EntryPoint = "fInsertaProducto")]
        public static extern int fInsertaProducto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSetDatoProducto(string Campo, string Valor);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fGuardaProducto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscaIdProducto(int lIdProducto);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscaProducto(string lCodProducto);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fLeeDatoProducto(string aCampo, StringBuilder aValor, int len);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBorraProducto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fEditaProducto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fCancelarModificacionProducto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosPrimerProducto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosSiguienteProducto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosEOFProducto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fRegresaExistencia(string aCodigoProducto, string aCodigoAlmacen, string aAnio, string aMes, string aDia, ref double aExistencia);
    }
}
