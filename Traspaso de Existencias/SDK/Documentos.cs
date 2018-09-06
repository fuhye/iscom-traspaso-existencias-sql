using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ComercialSDK.SDK
{
    public static class Documentos
    {
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAltaDocumento(ref int aIdDocto, ref AbstractDataTypes.tDocumento aDocto);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAltaDocumentoCargoAbono(ref AbstractDataTypes.tDocumento aDocto);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSiguienteFolio(string aCodigoConcepto, string aNumSerie, ref double aFolio);
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscarIdDocumento(Int32 aIdDocumento);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fCancelaDocumento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fLeeDatoDocumento(string aCampo, StringBuilder aValor, int len);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSetDatoDocumento(string aCampo, string aValor);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fCancelarModificacionDocumento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBorraDocumento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fEditarDocumento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fGuardaDocumento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fDocumentoUUID(string aCodConcepto, string aSerie, double aFolio, StringBuilder atPtrCFDIUUID);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAfectaDocto_Param(string aCodConcepto, string aSerie, double aFolio, int aAfecta);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fEmitirDocumento(string aCodConcepto, string aSerie, double aFolio, string aPassword, string aArchivoAdicional);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosPrimerDocumento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fPosSiguienteDocumento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fEntregEnDiscoXML(string aCodConcepto, string aSerie, double aFolio, int aFormato, string aFormatoAmig);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fInsertarDocumento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fLeeDatoCFDI(StringBuilder aValor, int aDato);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fObtieneDatosCFDI(string atPtrPassword);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSetFiltroDocumento(string aFechaInicio, string aFechaFin, string aCodigoConcepto, string aCodigoCteProv);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fCancelaFiltroDocumento();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fBuscarDocumento(string aCodConcepto, string aSerie, string aFolio);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fInicializaLicenseInfo(byte aSistema); //0 = AdminPAQ, 1 = CONTPAQ i FACTURA ELECTRÓNICA

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fCancelaUUID(string aUUID, string aidCodConcepto, string aPass);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fDesbloqueaDocumento();
    }
}
