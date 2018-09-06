using System.Runtime.InteropServices;
using System.Text;

namespace ComercialSDK.SDK
{
    internal static class Conceptos
    {
        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fLeeDatoConceptoDocto(string aCampo, StringBuilder aValr, int aLen);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fBuscaConceptoDocto(string aCodConcepto);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fBuscaIdConceptoDocto(int aIdConcepto);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fPosPrimerConceptoDocto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fPosSiguienteConceptoDocto();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        internal static extern int fPosEOFConceptoDocto();
    }
}
