using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComercialSDK.SDK {
    public static class General {

#if admin
        /// <summary>
        /// Funcion que inicializa el SDK de CONTPAQ
        /// </summary>
        /// <returns></returns>
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fInicializaSDK();
#else
        /// <summary>
        /// Funcion que inicializa el SDK de CONTPAQ
        /// </summary>
        /// <returns></returns>
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fInicializaSDK();

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern void fInicioSesionSDK(string aUsuario, string aContrasenia);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fSetNombrePAQ(string aSistema);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aUsuario"></param>
        /// <param name="aContrasenia"></param>
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern void fInicioSesionSDKCONTPAQi(string aUsuario, string aContrasenia);
#endif
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fTimbraXML(string aRutaXML, string aCodConcepto, StringBuilder aUUID, string aRutaDDa, string aRutaResultado, string aPass, string aRutaFormato);

        /// <summary>
        /// Funcion que termina el SDK de CONTPAQ
        /// </summary>
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern void fTerminaSDK();

        /// <summary>
        /// Funcion que recupera el error generado en la ultima operacion
        /// </summary>
        /// <param name="NumeroError">Codigo del error</param>
        /// <param name="Mensaje">Mensaje del error</param>
        /// <param name="Longitud">Longitud del mensaje de error</param>
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern void fError(int NumeroError, StringBuilder Mensaje, int Longitud);

        /// <summary>
        /// Funcion que abre el directorio de la empresa
        /// </summary>
        /// <param name="Directorio">Ruta al directorio de la empresa</param>
        /// <returns></returns>
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fAbreEmpresa(string Directorio);

        /// <summary>
        /// Funcion que cierra el directorio de la empresa activa
        /// </summary>
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern void fCierraEmpresa();

        /// <summary>
        /// Inicializa la informacion de la licencia del sistema
        /// </summary>
        /// <param name="aSistema">Identificador del sistema a utilizar 0 = AdminPAQ, 1 = Factura Electronica</param>
        /// <returns></returns>
        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fInicializaLicenseInfo(int aSistema);

        [DllImport(SDKSettings.LIBRARY_DLL)]
        public static extern int fLeeDatoParametros(string aCampo, StringBuilder aValr, int aLen);

        /// <summary>
        /// Prepara la cadena para almacenar en el sistema
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="longitud"></param>
        /// <returns></returns>
        public static string PrepararCadena(string cadena, int longitud) {
            return cadena.PadRight(longitud - 1) + '\0';
        }

        /// <summary>
        /// Agrega al log el codigo de error
        /// </summary>
        /// <param name="Codigo">Codigo del Error a registrar</param>
        public static void RegistraErrorLog(int Codigo) {
            StringBuilder str = new StringBuilder(350);
            General.fError(Codigo, str, 350);
        }

        /// <summary>
        /// Funcion que asigna la cadena a la estructura del modelo
        /// </summary>
        /// <param name="placeholder">byte[], Campo de la estructura donde depositar los bytes</param>
        /// <param name="cadena">string, Cadena la cual se guardara</param>
        /// <param name="longitud">int, La longitud del campo</param>
        public static void StringReady42Struct(ref byte[] placeholder, string cadena, int longitud) {
            UTF8Encoding E = new UTF8Encoding();
            placeholder = new byte[longitud];
            cadena = PrepararCadena(cadena, longitud);
            E.GetBytes(cadena, 0, longitud - 1, placeholder, 0);
        }
    }
}
