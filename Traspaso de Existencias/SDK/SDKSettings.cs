using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercialSDK.SDK
{
    public class SDKSettings
    {

        private static string _DateFormat = "MM/dd/yyyy";
        public static string DateFormat
        {
            get
            {
                return _DateFormat;
            }
            set
            {
                _DateFormat = value;
            }
        }

        private static Dictionary<string, string> _ClavesSAT;

        internal static Dictionary<string, string> ClavesSAT
        {
            get
            {
                if (ReferenceEquals(_ClavesSAT, null))
                    _ClavesSAT = new Dictionary<string, string>();
                return _ClavesSAT;
            }
        }

#if AdminPAQ
        public const string LIBRARY_DLL = "MGW_SDK.dll";

        public const string CONNECTION_STRING = @"Provider=vfpoledb;Data Source={0};Collating Sequence=general;";

        public static string ORG_DIR { get; set; } = "";
        public static string PAQ { get; set; } = "AdminPAQ";
        public static byte SISTEMA { get; set; } = 0;
        public static string DatabaseLocation { get; set; }
        public static string SDKLocation { get; set; } = @"C:\Program Files (x86)\Compacw\AdminPAQ";

        public static void SetLocation()
        {
            Directory.SetCurrentDirectory(SDKLocation);
        }

        #region parametros para empresas
        public const int EMPRESA_LONGITUD_RFC = 60;

        public const string EMPRESA_CAMPO_RFC = "crfcempr01";
        #endregion

        #region parametros para clientes
        public const int CLIENTE_LONGITUD_ID = 11;
        public const int CLIENTE_LONGITUD_RFC = 20;
        public const int CLIENTE_LONGITUD_RAZON_SOCIAL = 60;
        public const int CLIENTE_LONGITUD_CODIGO = 30;
        public const int CLIENTE_LONGITUD_FECHA_ALTA = 23;
        public const int CLIENTE_LONGITUD_LISTA_PRECIOS = 6;
        public const int CLIENTE_LONGITUD_ID_MONEDA = 11;
        public const int CLIENTE_LONGITUD_TIPO = 6;
        public const int CLIENTE_LONGITUD_STATUS = 6;
        public const int CLIENTE_LONGITUD_VENTA_CREDITO = 6;
        public const int CLIENTE_LONGITUD_EXCEDER_CREDITO = 6;
        public const int CLIENTE_LONGITUD_ID_ALMACEN = 11;
        public const int CLIENTE_LONGITUD_TEXTOEXTRA01 = 50;
        public const int CLIENTE_LONGITUD_EMAIL1 = 60;
        public const int CLIENTE_LONGITUD_EMAIL2 = 60;
        public const int CLIENTE_LONGITUD_EMAIL3 = 60;
        public const int CLIENTE_LONGITUD_ACTIVO = 6;
        public const int CLIENTE_LONGITUD_TEXTO_EXTRA1 = 50;
        public const int CLIENTE_LONGITUD_TEXTO_EXTRA2 = 50;
        public const int CLIENTE_LONGITUD_TEXTO_EXTRA3 = 50;
        public const int CLIENTE_LONGITUD_METODO_PAGO = 30;

        public const string CLIENTE_CAMPO_ID = "cidclien01";
        public const string CLIENTE_CAMPO_RFC = "crfc";
        public const string CLIENTE_CAMPO_RAZON_SOCIAL = "crazonso01";
        public const string CLIENTE_CAMPO_CODIGO = "ccodigoc01";
        public const string CLIENTE_CAMPO_FECHA_ALTA = "cfechaalta";
        public const string CLIENTE_CAMPO_LISTA_PRECIOS = "clistapr01";
        public const string CLIENTE_CAMPO_ID_MONEDA = "cidmoneda";
        public const string CLIENTE_CAMPO_TIPO = "ctipocli01";
        public const string CLIENTE_CAMPO_STATUS = "cestatus";
        public const string CLIENTE_CAMPO_VENTA_CREDITO = "cbanvent01";
        public const string CLIENTE_CAMPO_EXCEDER_CREDITO = "cbanexce01";
        public const string CLIENTE_CAMPO_ID_ALMACEN = "cidalmacen";
        public const string CLIENTE_CAMPO_EMAIL1 = "cemail1";
        public const string CLIENTE_CAMPO_EMAIL2 = "cemail2";
        public const string CLIENTE_CAMPO_EMAIL3 = "cemail3";
        public const string CLIENTE_CAMPO_ACTIVO = "cestatus";
        public const string CLIENTE_CAMPO_TEXTO_EXTRA1 = "ctextoex01";
        public const string CLIENTE_CAMPO_TEXTO_EXTRA2 = "ctextoex02";
        public const string CLIENTE_CAMPO_TEXTO_EXTRA3 = "ctextoex03";
        public const string CLIENTE_CAMPO_METODO_PAGO = "cmetodopag";
        public const string CLIENTE_CAMPO_USO_CFDI = "cUsoCFDI";
        #endregion

        #region parametros para almacenes
        public const int ALMACEN_LONGITUD_ID = 11;
        public const int ALMACEN_LONGITUD_FECHA_ALTA = 23;
        public const int ALMACEN_LONGITUD_NOMBRE = 60;
        public const int ALMACEN_LONGITUD_CODIGO = 30;

        public const string ALMACEN_CAMPO_ID = "cidalmacen";
        public const string ALMACEN_CAMPO_CODIGO = "ccodigoa01";
        public const string ALMACEN_CAMPO_NOMBRE = "cnombrea01";
        public const string ALMACEN_CAMPO_FECHA_ALTA = "cfechaal01";
        #endregion

        #region parametros para domicilios
        public const int DOMICILIO_LONGITUD_ID = 11;
        public const int DOMICILIO_LONGITUD_CALLE = 60;
        public const int DOMICILIO_LONGITUD_NOEXT = 30;
        public const int DOMICILIO_LONGITUD_NOINT = 30;
        public const int DOMICILIO_LONGITUD_COLONIA = 60;
        public const int DOMICILIO_LONGITUD_CODIGO_POSTAL = 6;
        public const int DOMICILIO_LONGITUD_PAIS = 60;
        public const int DOMICILIO_LONGITUD_ESTADO = 60;
        public const int DOMICILIO_LONGITUD_CIUDAD = 60;
        public const int DOMICILIO_LONGITUD_MUNICIPIO = 60;
        public const int DOMICILIO_LONGITUD_TIPO_DIRECCION = 6;
        public const int DOMICILIO_LONGITUD_TIPO_CATALOGO = 6;
        public const int DOMICILIO_LONGITUD_ID_CATALOGO = 11;

        public const string DOMICILIO_CAMPO_ID = "ciddirec01";
        public const string DOMICILIO_CAMPO_CALLE = "cnombrec01";
        public const string DOMICILIO_CAMPO_NOEXT = "cnumeroe01";
        public const string DOMICILIO_CAMPO_NOINT = "cnumeroi01";
        public const string DOMICILIO_CAMPO_COLONIA = "ccolonia";
        public const string DOMICILIO_CAMPO_CODIGO_POSTAL = "ccodigop01";
        public const string DOMICILIO_CAMPO_PAIS = "cpais";
        public const string DOMICILIO_CAMPO_ESTADO = "cestado";
        public const string DOMICILIO_CAMPO_CIUDAD = "cciudad";
        public const string DOMICILIO_CAMPO_MUNICIPIO = "cmunicipio";
        public const string DOMICILIO_CAMPO_TIPO_DIRECCION = "ctipodir01";
        public const string DOMICILIO_CAMPO_TIPO_CATALOGO = "ctipocat01";
        public const string DOMICILIO_CAMPO_ID_CATALOGO = "cidcatal01";
        #endregion

        #region parametros para productos y servicios
        public const int PRODUCTO_LONGITUD_ID = 11;
        public const int PRODUCTO_LONGITUD_CODIGO = 30;
        public const int PRODUCTO_LONGITUD_DESCRIPCION = 60;
        public const int PRODUCTO_LONGITUD_ESTADO = 6;
        public const int PRODUCTO_LONGITUD_TIPO = 6;
        public const int PRODUCTO_LONGITUD_FECHA_ALTA = 23;
        public const int PRODUCTO_LONGITUD_CONTROL = 6;
        public const int PRODUCTO_LONGITUD_NOMBRE_ALTERNATIVO = 60;
        public const int PRODUCTO_LONGITUD_METODO_COSTEO = 6;
        public const int PRODUCTO_LONGITUD_PRECIO1 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO2 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO3 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO4 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO5 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO6 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO7 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO8 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO9 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO10 = 8;
        public const int PRODUCTO_LONGITUD_UNIDAD_BASE_ID = 11;
        public const int PRODUCTO_LONGITUD_UNIDAD_NO_CONVERTIBLE_ID = 11;
        public const int PRODUCTO_LONGITUD_USA_IVA = 6;
        public const int PRODUCTO_LONGITUD_UNIDAD_XML = 6;
        public const int PRODUCTO_LONGITUD_IMPUESTO1 = 8;
        public const int PRODUCTO_LONGITUD_IMPUESTO2 = 8;
        public const int PRODUCTO_LONGITUD_IMPUESTO3 = 8;

        public const string PRODUCTO_CAMPO_ID = "cidprodu01";
        public const string PRODUCTO_CAMPO_CODIGO = "ccodigop01";
        public const string PRODUCTO_CAMPO_DESCRIPCION = "cnombrep01";
        public const string PRODUCTO_CAMPO_ESTADO = "cstatusp01";
        public const string PRODUCTO_CAMPO_TIPO = "ctipopro01";
        public const string PRODUCTO_CAMPO_FECHA_ALTA = "cfechaal01";
        public const string PRODUCTO_CAMPO_CONTROL = "ccontrol01";
        public const string PRODUCTO_CAMPO_NOMBRE_ALTERNATIVO = "cnomaltern";
        public const string PRODUCTO_CAMPO_METODO_COSTEO = "cmetodoc01";
        public const string PRODUCTO_CAMPO_PRECIO1 = "cprecio1";
        public const string PRODUCTO_CAMPO_PRECIO2 = "cprecio2";
        public const string PRODUCTO_CAMPO_PRECIO3 = "cprecio3";
        public const string PRODUCTO_CAMPO_PRECIO4 = "cprecio4";
        public const string PRODUCTO_CAMPO_PRECIO5 = "cprecio5";
        public const string PRODUCTO_CAMPO_PRECIO6 = "cprecio6";
        public const string PRODUCTO_CAMPO_PRECIO7 = "cprecio7";
        public const string PRODUCTO_CAMPO_PRECIO8 = "cprecio8";
        public const string PRODUCTO_CAMPO_PRECIO9 = "cprecio9";
        public const string PRODUCTO_CAMPO_PRECIO10 = "cprecio10";
        public const string PRODUCTO_CAMPO_UNIDAD_BASE_ID = "cidunida01";
        public const string PRODUCTO_CAMPO_UNIDAD_NO_CONVERTIBLE_ID = "cidunida02";
        public const string PRODUCTO_CAMPO_USA_IVA = "cesexento";
        public const string PRODUCTO_CAMPO_UNIDAD_XML = "cidunixml";
        public const string PRODUCTO_CAMPO_IMPUESTO1 = "cimpuesto1";
        public const string PRODUCTO_CAMPO_IMPUESTO2 = "cimpuesto2";
        public const string PRODUCTO_CAMPO_IMPUESTO3 = "cimpuesto3";
        public const string PRODUCTO_CAMPO_CLAVE_SAT = "cClaveSAT";
        #endregion

        #region parametros para conceptos
        public const int CONCEPTO_LONGITUD_ID = 11;
        public const int CONCEPTO_LONGITUD_CODIGO = 30;
        public const int CONCEPTO_LONGITUD_NOMBRE = 60;
        public const int CONCEPTO_LONGITUD_TIPO_DOCUMENTO = 11;
        public const int CONCEPTO_LONGITUD_SERIE = 11;
        public const int CONCEPTO_LONGITUD_FORMATO = 253;
        public const int CONCEPTO_LONGITUD_PREFIJO_ENTREGA = 30;

        public const string CONCEPTO_CAMPO_ID = "cidconce01";
        public const string CONCEPTO_CAMPO_CODIGO = "ccodigoc01";
        public const string CONCEPTO_CAMPO_NOMBRE = "cnombrec01";
        public const string CONCEPTO_CAMPO_TIPO_DOCUMENTO = "ciddocum01";
        public const string CONCEPTO_CAMPO_SERIE = "cseriepo01";
        public const string CONCEPTO_CAMPO_FORMATO = "cplamigcfd";
        public const string CONCEPTO_CAMPO_PREFIJO_ENTREGA = "cpreficon";
        #endregion

        #region parametros para documentos
        public const int DOCUMENTO_LONGITUD_ID = 11;
        public const int DOCUMENTO_LONGITUD_TIPO = 11;
        public const int DOCUMENTO_LONGITUD_ID_CONCEPTO = 11;
        public const int DOCUMENTO_LONGITUD_SERIE = 11;
        public const int DOCUMENTO_LONGITUD_FOLIO = 8;
        public const int DOCUMENTO_LONGITUD_FECHA = 23;
        public const int DOCUMENTO_LONGITUD_ID_CLIENTE = 11;
        public const int DOCUMENTO_LONGITUD_RAZON_SOCIAL = 60;
        public const int DOCUMENTO_LONGITUD_RFC = 20;
        public const int DOCUMENTO_LONGITUD_ID_MONEDA = 11;
        public const int DOCUMENTO_LONGITUD_TIPO_CAMBIO = 8;
        public const int DOCUMENTO_LONGITUD_REFERENCIA = 20;
        public const int DOCUMENTO_LONGITUD_CANCELADO = 6;
        public const int DOCUMENTO_LONGITUD_NETO = 8;
        public const int DOCUMENTO_LONGITUD_IMPUESTO1 = 8;
        public const int DOCUMENTO_LONGITUD_IMPUESTO2 = 8;
        public const int DOCUMENTO_LONGITUD_IMPUESTO3 = 8;
        public const int DOCUMENTO_LONGITUD_TOTAL = 8;
        public const int DOCUMENTO_LONGITUD_PORCENTAJE1 = 8;
        public const int DOCUMENTO_LONGITUD_PORCENTAJE2 = 8;
        public const int DOCUMENTO_LONGITUD_PORCENTAJE3 = 8;
        public const int DOCUMENTO_LONGITUD_LUGAR_EXPEDICION = 253;
        public const int DOCUMENTO_LONGITUD_METODO_PAGO = 100;
        public const int DOCUMENTO_LONGITUD_CONDICIONES_PAGO = 100;
        public const int DOCUMENTO_LONGITUD_CUENTA_PAGO = 20;
        public const int DOCUMENTO_LONGITUD_TEXTO_EXTRA1 = 50;
        public const int DOCUMENTO_LONGITUD_TEXTO_EXTRA2 = 50;
        public const int DOCUMENTO_LONGITUD_TEXTO_EXTRA3 = 50;
        public const int DOCUMENTO_LONGITUD_OBSERVACIONES = 255;
        public const int DOCUMENTO_LONGITUD_FECHA_EXTRA = 23;
        public const int DOCUMENTO_LONGITUD_IMPORTE_EXTRA1 = 8;
        public const int DOCUMENTO_LONGITUD_IMPORTE_EXTRA2 = 8;
        public const int DOCUMENTO_LONGITUD_IMPORTE_EXTRA3 = 8;


        public const string DOCUMENTO_CAMPO_ID = "ciddocum01";
        public const string DOCUMENTO_CAMPO_TIPO = "ciddocum02";
        public const string DOCUMENTO_CAMPO_ID_CONCEPTO = "cidconce01";
        public const string DOCUMENTO_CAMPO_SERIE = "cseriedo01";
        public const string DOCUMENTO_CAMPO_FOLIO = "cfolio";
        public const string DOCUMENTO_CAMPO_FECHA = "cfecha";
        public const string DOCUMENTO_CAMPO_ID_CLIENTE = "cidclien01";
        public const string DOCUMENTO_CAMPO_RAZON_SOCIAL = "crazonso01";
        public const string DOCUMENTO_CAMPO_RFC = "crfc";
        public const string DOCUMENTO_CAMPO_ID_MONEDA = "cidmoneda";
        public const string DOCUMENTO_CAMPO_TIPO_CAMBIO = "ctipocam01";
        public const string DOCUMENTO_CAMPO_REFERENCIA = "creferen01";
        public const string DOCUMENTO_CAMPO_CANCELADO = "ccancelado";
        public const string DOCUMENTO_CAMPO_NETO = "cneto";
        public const string DOCUMENTO_CAMPO_IMPUESTO1 = "cimpuesto1";
        public const string DOCUMENTO_CAMPO_IMPUESTO2 = "cimpuesto2";
        public const string DOCUMENTO_CAMPO_IMPUESTO3 = "cimpuesto3";
        public const string DOCUMENTO_CAMPO_TOTAL = "ctotal";
        public const string DOCUMENTO_CAMPO_PORCENTAJE1 = "cporcent01";
        public const string DOCUMENTO_CAMPO_PORCENTAJE2 = "cporcent02";
        public const string DOCUMENTO_CAMPO_PORCENTAJE3 = "cporcent03";
        public const string DOCUMENTO_CAMPO_LUGAR_EXPEDICION = "clugarexpe";
        public const string DOCUMENTO_CAMPO_METODO_PAGO = "cmetodopag";
        public const string DOCUMENTO_CAMPO_CONDICIONES_PAGO = "ccondipago";
        public const string DOCUMENTO_CAMPO_CUENTA_PAGO = "cnumctapag";
        public const string DOCUMENTO_CAMPO_TEXTO_EXTRA1 = "ctextoex01";
        public const string DOCUMENTO_CAMPO_TEXTO_EXTRA2 = "ctextoex02";
        public const string DOCUMENTO_CAMPO_TEXTO_EXTRA3 = "ctextoex03";
        public const string DOCUMENTO_CAMPO_OBSERVACIONES = "cobservaciones";
        public const string DOCUMENTO_CAMPO_FECHA_EXTRA = "cfechaex01";
        public const string DOCUMENTO_CAMPO_IMPORTE_EXTRA1 = "cimporte01";
        public const string DOCUMENTO_CAMPO_IMPORTE_EXTRA2 = "cimporte02";
        public const string DOCUMENTO_CAMPO_IMPORTE_EXTRA3 = "cimporte03";
        #endregion

        #region parametros para movimientos
        public const int MOVIMIENTO_LONGITUD_ID = 11;
        public const int MOVIMIENTO_LONGITUD_ID_DOCUMENTO = 11;
        public const int MOVIMIENTO_LONGITUD_NUMERO_MOVIMIENTO = 8;
        public const int MOVIMIENTO_LONGITUD_TIPO_DOCUMENTO = 11;
        public const int MOVIMIENTO_LONGITUD_ID_PRODUCTO = 11;
        public const int MOVIMIENTO_LONGITUD_ID_ALMACEN = 11;
        public const int MOVIMIENTO_LONGITUD_UNIDADES_BASE = 8;
        public const int MOVIMIENTO_LONGITUD_UNIDADES_NO_CONVERTIBLES = 8;
        public const int MOVIMIENTO_LONGITUD_UNIDADES_CAPTURADAS = 8;
        public const int MOVIMIENTO_LONGITUD_IDENTIFICADOR_UNIDAD = 8;
        public const int MOVIMIENTO_LONGITUD_PRECIO = 8;
        public const int MOVIMIENTO_LONGITUD_PRECIO_CAPTURADO = 8;
        public const int MOVIMIENTO_LONGITUD_NETO = 8;
        public const int MOVIMIENTO_LONGITUD_IMPUESTO1 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT01 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPUESTO2 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT02 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPUESTO3 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT03 = 8;
        public const int MOVIMIENTO_LONGITUD_DESCUENTO1 = 8;
        public const int MOVIMIENTO_LONGITUD_DESCUENTO2 = 8;
        public const int MOVIMIENTO_LONGITUD_DESCUENTO3 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT06 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT07 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT08 = 8;
        public const int MOVIMIENTO_LONGITUD_TOTAL = 8;
        public const int MOVIMIENTO_LONGITUD_REFERENCIA = 20;
        public const int MOVIMIENTO_LONGITUD_OBSERVACIONES = 255;
        public const int MOVIMIENTO_LONGITUD_IMPORTE_EXTRA1 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPORTE_EXTRA2 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPORTE_EXTRA3 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPORTE_EXTRA4 = 8;
        public const int MOVIMIENTO_LONGITUD_TEXTO_EXTRA1 = 50;
        public const int MOVIMIENTO_LONGITUD_TEXTO_EXTRA2 = 50;
        public const int MOVIMIENTO_LONGITUD_TEXTO_EXTRA3 = 50;

        public const string MOVIMIENTO_CAMPO_ID = "cidmovim01";
        public const string MOVIMIENTO_CAMPO_ID_DOCUMENTO = "ciddocum01";
        public const string MOVIMIENTO_CAMPO_NUMERO_MOVIMIENTO = "cnumerom01";
        public const string MOVIMIENTO_CAMPO_TIPO_DOCUMENTO = "ciddocum02";
        public const string MOVIMIENTO_CAMPO_ID_PRODUCTO = "cidprodu01";
        public const string MOVIMIENTO_CAMPO_ID_ALMACEN = "cidalmacen";
        public const string MOVIMIENTO_CAMPO_UNIDADES_BASE = "cunidades";
        public const string MOVIMIENTO_CAMPO_UNIDADES_NO_CONVERTIBLES = "cunidade01";
        public const string MOVIMIENTO_CAMPO_UNIDADES_CAPTURADAS = "cunidade02";
        public const string MOVIMIENTO_CAMPO_IDENTIFICADOR_UNIDAD = "cidunidad";
        public const string MOVIMIENTO_CAMPO_PRECIO = "cprecio";
        public const string MOVIMIENTO_CAMPO_PRECIO_CAPTURADO = "cprecioc01";
        public const string MOVIMIENTO_CAMPO_NETO = "cneto";
        public const string MOVIMIENTO_CAMPO_IMPUESTO1 = "cimpuesto1";
        public const string MOVIMIENTO_CAMPO_PORCENT01 = "cporcent01";
        public const string MOVIMIENTO_CAMPO_IMPUESTO2 = "cimpuesto2";
        public const string MOVIMIENTO_CAMPO_PORCENT02 = "cporcent02";
        public const string MOVIMIENTO_CAMPO_IMPUESTO3 = "cimpuesto3";
        public const string MOVIMIENTO_CAMPO_PORCENT03 = "cporcent03";
        public const string MOVIMIENTO_CAMPO_DESCUENTO1 = "cdescuen01";
        public const string MOVIMIENTO_CAMPO_DESCUENTO2 = "cdescuen02";
        public const string MOVIMIENTO_CAMPO_DESCUENTO3 = "cdescuen03";
        public const string MOVIMIENTO_CAMPO_PORCENT06 = "cporcent06";
        public const string MOVIMIENTO_CAMPO_PORCENT07 = "cporcent07";
        public const string MOVIMIENTO_CAMPO_PORCENT08 = "cporcent08";
        public const string MOVIMIENTO_CAMPO_TOTAL = "ctotal";
        public const string MOVIMIENTO_CAMPO_REFERENCIA = "creferen01";
        public const string MOVIMIENTO_CAMPO_OBSERVACIONES = "cobservamov";
        public const string MOVIMIENTO_CAMPO_IMPORTE_EXTRA1 = "cimporte01";
        public const string MOVIMIENTO_CAMPO_IMPORTE_EXTRA2 = "cimporte02";
        public const string MOVIMIENTO_CAMPO_IMPORTE_EXTRA3 = "cimporte03";
        public const string MOVIMIENTO_CAMPO_IMPORTE_EXTRA4 = "cimporte04";
        public const string MOVIMIENTO_CAMPO_TEXTO_EXTRA1 = "ctextoex01";
        public const string MOVIMIENTO_CAMPO_TEXTO_EXTRA2 = "ctextoex02";
        public const string MOVIMIENTO_CAMPO_TEXTO_EXTRA3 = "ctextoex03";
        #endregion

        #region parametros para unidades
        public const int UNIDAD_LONGITUD_ID = 11;
        public const int UNIDAD_LONGITUD_NOMBRE = 60;
        public const int UNIDAD_LONGITUD_ABREVIATURA = 3;
        public const int UNIDAD_LONGITUD_CLAVE_INTERNACIONAL = 3;

        public const string UNIDAD_CAMPO_ID = "cidunidad";
        public const string UNIDAD_CAMPO_NOMBRE = "cnombreu01";
        public const string UNIDAD_CAMPO_ABREVIATURA = "cabrevia01";
        public const string UNIDAD_CAMPO_CLAVE_INTERNACIONAL = "cclaveint";
        #endregion

        #region parametros para agentes
        public const int AGENTE_LONGITUD_ID = 11;
        public const int AGENTE_LONGITUD_CODIGO = 30;
        public const int AGENTE_LONGITUD_NOMBRE = 60;

        public const string AGENTE_CAMPO_ID = "CIDAGENTE";
        public const string AGENTE_CAMPO_CODIGO = "CCODIGOAGENTE";
        public const string AGENTE_CAMPO_NOMBRE = "CNOMBREAGENTE";
        #endregion
#else
        public const string LIBRARY_DLL = "mgwservicios.dll";

        public const string CONNECTION_STRING = @"Provider=vfpoledb;Data Source={0};Collating Sequence=general;";

        public static string ORG_DIR { get; set; } = "";
        public static string PAQ { get; set; } = "CONTPAQ I Comercial";
        public static byte SISTEMA { get; set; } = 0;
        public static string USERNAME { get; set; }
        public static string PASSWORD { get; set; }
        public static string DatabaseLocation { get; set; }
        public static string SDKLocation { get; set; } = @"C:\Program Files (x86)\Compac\COMERCIAL";

        #region parametros para empresas
        public const int EMPRESA_LONGITUD_RFC = 60;

        public const string EMPRESA_CAMPO_RFC = "crfcempresa";
        #endregion

        #region parametros para clientes
        public const int CLIENTE_LONGITUD_ID = 11;
        public const int CLIENTE_LONGITUD_RFC = 20;
        public const int CLIENTE_LONGITUD_RAZON_SOCIAL = 60;
        public const int CLIENTE_LONGITUD_CODIGO = 30;
        public const int CLIENTE_LONGITUD_FECHA_ALTA = 23;
        public const int CLIENTE_LONGITUD_LISTA_PRECIOS = 6;
        public const int CLIENTE_LONGITUD_ID_MONEDA = 11;
        public const int CLIENTE_LONGITUD_TIPO = 6;
        public const int CLIENTE_LONGITUD_STATUS = 6;
        public const int CLIENTE_LONGITUD_VENTA_CREDITO = 6;
        public const int CLIENTE_LONGITUD_EXCEDER_CREDITO = 6;
        public const int CLIENTE_LONGITUD_ID_ALMACEN = 11;
        public const int CLIENTE_LONGITUD_TEXTOEXTRA01 = 50;
        public const int CLIENTE_LONGITUD_EMAIL1 = 60;
        public const int CLIENTE_LONGITUD_EMAIL2 = 60;
        public const int CLIENTE_LONGITUD_EMAIL3 = 60;
        public const int CLIENTE_LONGITUD_ACTIVO = 6;
        public const int CLIENTE_LONGITUD_TEXTO_EXTRA1 = 50;
        public const int CLIENTE_LONGITUD_TEXTO_EXTRA2 = 50;
        public const int CLIENTE_LONGITUD_TEXTO_EXTRA3 = 50;
        public const int CLIENTE_LONGITUD_METODO_PAGO = 30;

        public const string CLIENTE_CAMPO_ID = "cidclienteproveedor";
        public const string CLIENTE_CAMPO_RFC = "crfc";
        public const string CLIENTE_CAMPO_RAZON_SOCIAL = "crazonsocial";
        public const string CLIENTE_CAMPO_CODIGO = "ccodigocliente";
        public const string CLIENTE_CAMPO_FECHA_ALTA = "cfechaalta";
        public const string CLIENTE_CAMPO_LISTA_PRECIOS = "clistapreciocliente";
        public const string CLIENTE_CAMPO_ID_MONEDA = "cidmoneda";
        public const string CLIENTE_CAMPO_TIPO = "ctipocliente";
        public const string CLIENTE_CAMPO_STATUS = "cestatus";
        public const string CLIENTE_CAMPO_VENTA_CREDITO = "cbanventacredito";
        public const string CLIENTE_CAMPO_EXCEDER_CREDITO = "cbanexcedercredito";
        public const string CLIENTE_CAMPO_ID_ALMACEN = "cidalmacen";
        public const string CLIENTE_CAMPO_TEXTOEXTRA01 = "ctextoextra1";
        public const string CLIENTE_CAMPO_EMAIL1 = "cemail1";
        public const string CLIENTE_CAMPO_EMAIL2 = "cemail2";
        public const string CLIENTE_CAMPO_EMAIL3 = "cemail3";
        public const string CLIENTE_CAMPO_ACTIVO = "cestatus";
        public const string CLIENTE_CAMPO_TEXTO_EXTRA1 = "ctextoex01";
        public const string CLIENTE_CAMPO_TEXTO_EXTRA2 = "ctextoex02";
        public const string CLIENTE_CAMPO_TEXTO_EXTRA3 = "ctextoex03";
        public const string CLIENTE_CAMPO_METODO_PAGO = "cmetodopag";

        #endregion

        #region parametros para almacenes
        public const int ALMACEN_LONGITUD_ID = 11;
        public const int ALMACEN_LONGITUD_FECHA_ALTA = 23;
        public const int ALMACEN_LONGITUD_NOMBRE = 60;
        public const int ALMACEN_LONGITUD_CODIGO = 30;

        public const string ALMACEN_CAMPO_ID = "cidalmacen";
        public const string ALMACEN_CAMPO_CODIGO = "ccodigoalmacen";
        public const string ALMACEN_CAMPO_NOMBRE = "cnombrealmacen";
        public const string ALMACEN_CAMPO_FECHA_ALTA = "cfechaaltaalmacen";
        #endregion

        #region parametros para domicilios
        public const int DOMICILIO_LONGITUD_ID = 11;
        public const int DOMICILIO_LONGITUD_CALLE = 60;
        public const int DOMICILIO_LONGITUD_NOEXT = 30;
        public const int DOMICILIO_LONGITUD_NOINT = 30;
        public const int DOMICILIO_LONGITUD_COLONIA = 60;
        public const int DOMICILIO_LONGITUD_CODIGO_POSTAL = 6;
        public const int DOMICILIO_LONGITUD_PAIS = 60;
        public const int DOMICILIO_LONGITUD_ESTADO = 60;
        public const int DOMICILIO_LONGITUD_CIUDAD = 60;
        public const int DOMICILIO_LONGITUD_MUNICIPIO = 60;
        public const int DOMICILIO_LONGITUD_TIPO_DIRECCION = 6;
        public const int DOMICILIO_LONGITUD_TIPO_CATALOGO = 6;
        public const int DOMICILIO_LONGITUD_ID_CATALOGO = 11;

        public const string DOMICILIO_CAMPO_ID = "ciddireccion";
        public const string DOMICILIO_CAMPO_CALLE = "cnombrecalle";
        public const string DOMICILIO_CAMPO_NOEXT = "cnumeroexterior";
        public const string DOMICILIO_CAMPO_NOINT = "cnumerointerior";
        public const string DOMICILIO_CAMPO_COLONIA = "ccolonia";
        public const string DOMICILIO_CAMPO_CODIGO_POSTAL = "ccodigopostal";
        public const string DOMICILIO_CAMPO_PAIS = "cpais";
        public const string DOMICILIO_CAMPO_ESTADO = "cestado";
        public const string DOMICILIO_CAMPO_CIUDAD = "cciudad";
        public const string DOMICILIO_CAMPO_MUNICIPIO = "cmunicipio";
        public const string DOMICILIO_CAMPO_TIPO_DIRECCION = "ctipodireccion";
        public const string DOMICILIO_CAMPO_TIPO_CATALOGO = "ctipocatalogo";
        public const string DOMICILIO_CAMPO_ID_CATALOGO = "cidcatalogo";
        #endregion

        #region parametros para productos y servicios
        public const int PRODUCTO_LONGITUD_ID = 11;
        public const int PRODUCTO_LONGITUD_CODIGO = 30;
        public const int PRODUCTO_LONGITUD_DESCRIPCION = 60;
        public const int PRODUCTO_LONGITUD_ESTADO = 6;
        public const int PRODUCTO_LONGITUD_TIPO = 6;
        public const int PRODUCTO_LONGITUD_FECHA_ALTA = 23;
        public const int PRODUCTO_LONGITUD_CONTROL = 6;
        public const int PRODUCTO_LONGITUD_NOMBRE_ALTERNATIVO = 60;
        public const int PRODUCTO_LONGITUD_METODO_COSTEO = 6;
        public const int PRODUCTO_LONGITUD_PRECIO1 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO2 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO3 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO4 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO5 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO6 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO7 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO8 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO9 = 8;
        public const int PRODUCTO_LONGITUD_PRECIO10 = 8;
        public const int PRODUCTO_LONGITUD_UNIDAD_BASE_ID = 11;
        public const int PRODUCTO_LONGITUD_UNIDAD_NO_CONVERTIBLE_ID = 11;
        public const int PRODUCTO_LONGITUD_USA_IVA = 6;
        public const int PRODUCTO_LONGITUD_UNIDAD_XML = 6;
        public const int PRODUCTO_LONGITUD_IMPUESTO1 = 8;
        public const int PRODUCTO_LONGITUD_IMPUESTO2 = 8;
        public const int PRODUCTO_LONGITUD_IMPUESTO3 = 8;

        public const string PRODUCTO_CAMPO_ID = "cidproducto";
        public const string PRODUCTO_CAMPO_CODIGO = "ccodigoproducto";
        public const string PRODUCTO_CAMPO_DESCRIPCION = "cnombreproducto";
        public const string PRODUCTO_CAMPO_ESTADO = "cstatusproducto";
        public const string PRODUCTO_CAMPO_TIPO = "ctipoproducto";
        public const string PRODUCTO_CAMPO_FECHA_ALTA = "cfechaaltaproducto";
        public const string PRODUCTO_CAMPO_CONTROL = "ccontrolexistencia";
        public const string PRODUCTO_CAMPO_NOMBRE_ALTERNATIVO = "cnomaltern";
        public const string PRODUCTO_CAMPO_METODO_COSTEO = "cmetodocosteo";
        public const string PRODUCTO_CAMPO_PRECIO1 = "cprecio1";
        public const string PRODUCTO_CAMPO_PRECIO2 = "cprecio2";
        public const string PRODUCTO_CAMPO_PRECIO3 = "cprecio3";
        public const string PRODUCTO_CAMPO_PRECIO4 = "cprecio4";
        public const string PRODUCTO_CAMPO_PRECIO5 = "cprecio5";
        public const string PRODUCTO_CAMPO_PRECIO6 = "cprecio6";
        public const string PRODUCTO_CAMPO_PRECIO7 = "cprecio7";
        public const string PRODUCTO_CAMPO_PRECIO8 = "cprecio8";
        public const string PRODUCTO_CAMPO_PRECIO9 = "cprecio9";
        public const string PRODUCTO_CAMPO_PRECIO10 = "cprecio10";
        public const string PRODUCTO_CAMPO_UNIDAD_BASE_ID = "cunidadbase";
        public const string PRODUCTO_CAMPO_UNIDAD_NO_CONVERTIBLE_ID = "cunidadnoconvertible";
        public const string PRODUCTO_CAMPO_USA_IVA = "cesexento";
        public const string PRODUCTO_CAMPO_UNIDAD_XML = "CIDUNIXML";
        public const string PRODUCTO_CAMPO_IMPUESTO1 = "cimpuesto1";
        public const string PRODUCTO_CAMPO_IMPUESTO2 = "cimpuesto2";
        public const string PRODUCTO_CAMPO_IMPUESTO3 = "cimpuesto3";
        #endregion

        #region parametros para conceptos
        public const int CONCEPTO_LONGITUD_ID = 11;
        public const int CONCEPTO_LONGITUD_CODIGO = 30;
        public const int CONCEPTO_LONGITUD_NOMBRE = 60;
        public const int CONCEPTO_LONGITUD_TIPO_DOCUMENTO = 11;
        public const int CONCEPTO_LONGITUD_SERIE = 11;
        public const int CONCEPTO_LONGITUD_FORMATO = 253;
        public const int CONCEPTO_LONGITUD_PREFIJO_ENTREGA = 30;

        public const string CONCEPTO_CAMPO_ID = "cidconceptodocumento";
        public const string CONCEPTO_CAMPO_CODIGO = "ccodigoconcepto";
        public const string CONCEPTO_CAMPO_NOMBRE = "cnombreconcepto";
        public const string CONCEPTO_CAMPO_TIPO_DOCUMENTO = "ciddocumentode";
        public const string CONCEPTO_CAMPO_SERIE = "cserieporomision";
        public const string CONCEPTO_CAMPO_FORMATO = "cplamigcfd";
        public const string CONCEPTO_CAMPO_PREFIJO_ENTREGA = "cpreficon";
        #endregion

        #region parametros para documentos
        public const int DOCUMENTO_LONGITUD_ID = 11;
        public const int DOCUMENTO_LONGITUD_TIPO = 11;
        public const int DOCUMENTO_LONGITUD_ID_CONCEPTO = 11;
        public const int DOCUMENTO_LONGITUD_SERIE = 11;
        public const int DOCUMENTO_LONGITUD_FOLIO = 8;
        public const int DOCUMENTO_LONGITUD_FECHA = 23;
        public const int DOCUMENTO_LONGITUD_ID_CLIENTE = 11;
        public const int DOCUMENTO_LONGITUD_RAZON_SOCIAL = 60;
        public const int DOCUMENTO_LONGITUD_RFC = 20;
        public const int DOCUMENTO_LONGITUD_ID_MONEDA = 11;
        public const int DOCUMENTO_LONGITUD_TIPO_CAMBIO = 8;
        public const int DOCUMENTO_LONGITUD_REFERENCIA = 20;
        public const int DOCUMENTO_LONGITUD_CANCELADO = 6;
        public const int DOCUMENTO_LONGITUD_NETO = 8;
        public const int DOCUMENTO_LONGITUD_IMPUESTO1 = 8;
        public const int DOCUMENTO_LONGITUD_IMPUESTO2 = 8;
        public const int DOCUMENTO_LONGITUD_IMPUESTO3 = 8;
        public const int DOCUMENTO_LONGITUD_TOTAL = 8;
        public const int DOCUMENTO_LONGITUD_PORCENTAJE1 = 8;
        public const int DOCUMENTO_LONGITUD_PORCENTAJE2 = 8;
        public const int DOCUMENTO_LONGITUD_PORCENTAJE3 = 8;
        public const int DOCUMENTO_LONGITUD_LUGAR_EXPEDICION = 253;
        public const int DOCUMENTO_LONGITUD_METODO_PAGO = 100;
        public const int DOCUMENTO_LONGITUD_CONDICIONES_PAGO = 100;
        public const int DOCUMENTO_LONGITUD_CUENTA_PAGO = 20;
        public const int DOCUMENTO_LONGITUD_TEXTO_EXTRA1 = 50;
        public const int DOCUMENTO_LONGITUD_TEXTO_EXTRA2 = 50;
        public const int DOCUMENTO_LONGITUD_TEXTO_EXTRA3 = 50;
        public const int DOCUMENTO_LONGITUD_FECHA_EXTRA = 23;
        public const int DOCUMENTO_LONGITUD_OBSERVACIONES = 253;
        public const int DOCUMENTO_LONGITUD_IMPORTE_EXTRA1 = 8;
        public const int DOCUMENTO_LONGITUD_IMPORTE_EXTRA2 = 8;
        public const int DOCUMENTO_LONGITUD_IMPORTE_EXTRA3 = 8;

        public const string DOCUMENTO_CAMPO_ID = "ciddocumento";
        public const string DOCUMENTO_CAMPO_TIPO = "ciddocumentode";
        public const string DOCUMENTO_CAMPO_ID_CONCEPTO = "cidconceptodocumento";
        public const string DOCUMENTO_CAMPO_SERIE = "cseriedocumento";
        public const string DOCUMENTO_CAMPO_FOLIO = "cfolio";
        public const string DOCUMENTO_CAMPO_FECHA = "cfecha";
        public const string DOCUMENTO_CAMPO_ID_CLIENTE = "cidclienteproveedor";
        public const string DOCUMENTO_CAMPO_RAZON_SOCIAL = "crazonsocial";
        public const string DOCUMENTO_CAMPO_RFC = "crfc";
        public const string DOCUMENTO_CAMPO_ID_MONEDA = "cidmoneda";
        public const string DOCUMENTO_CAMPO_TIPO_CAMBIO = "ctipocambio";
        public const string DOCUMENTO_CAMPO_REFERENCIA = "creferencia";
        public const string DOCUMENTO_CAMPO_CANCELADO = "ccancelado";
        public const string DOCUMENTO_CAMPO_NETO = "cneto";
        public const string DOCUMENTO_CAMPO_IMPUESTO1 = "cimpuesto1";
        public const string DOCUMENTO_CAMPO_IMPUESTO2 = "cimpuesto2";
        public const string DOCUMENTO_CAMPO_IMPUESTO3 = "cimpuesto3";
        public const string DOCUMENTO_CAMPO_TOTAL = "ctotal";
        public const string DOCUMENTO_CAMPO_PORCENTAJE1 = "cporcentajeimpuesto01";
        public const string DOCUMENTO_CAMPO_PORCENTAJE2 = "cporcentajeimpuesto02";
        public const string DOCUMENTO_CAMPO_PORCENTAJE3 = "cporcentajeimpuesto03";
        public const string DOCUMENTO_CAMPO_LUGAR_EXPEDICION = "clugarexpe";
        public const string DOCUMENTO_CAMPO_METODO_PAGO = "cmetodopag";
        public const string DOCUMENTO_CAMPO_CONDICIONES_PAGO = "ccondipago";
        public const string DOCUMENTO_CAMPO_CUENTA_PAGO = "cnumctapag";
        public const string DOCUMENTO_CAMPO_TEXTO_EXTRA1 = "ctextoextra1";
        public const string DOCUMENTO_CAMPO_TEXTO_EXTRA2 = "ctextoextra2";
        public const string DOCUMENTO_CAMPO_TEXTO_EXTRA3 = "ctextoextra3";
        public const string DOCUMENTO_CAMPO_FECHA_EXTRA = "cfechaex01";
        public const string DOCUMENTO_CAMPO_OBSERVACIONES = "cobservaciones";
        public const string DOCUMENTO_CAMPO_IMPORTE_EXTRA1 = "cimporteextra1";
        public const string DOCUMENTO_CAMPO_IMPORTE_EXTRA2 = "cimporteextra2";
        public const string DOCUMENTO_CAMPO_IMPORTE_EXTRA3 = "cimporteextra3";
        public const string DOCUMENTO_CAMPO_NUM_PARCI = "CCANTPARCI";
        #endregion

        #region parametros para movimientos
        public const int MOVIMIENTO_LONGITUD_ID = 11;
        public const int MOVIMIENTO_LONGITUD_ID_DOCUMENTO = 11;
        public const int MOVIMIENTO_LONGITUD_NUMERO_MOVIMIENTO = 8;
        public const int MOVIMIENTO_LONGITUD_TIPO_DOCUMENTO = 11;
        public const int MOVIMIENTO_LONGITUD_ID_PRODUCTO = 11;
        public const int MOVIMIENTO_LONGITUD_ID_ALMACEN = 11;
        public const int MOVIMIENTO_LONGITUD_UNIDADES_BASE = 8;
        public const int MOVIMIENTO_LONGITUD_UNIDADES_NO_CONVERTIBLES = 8;
        public const int MOVIMIENTO_LONGITUD_UNIDADES_CAPTURADAS = 8;
        public const int MOVIMIENTO_LONGITUD_IDENTIFICADOR_UNIDAD = 8;
        public const int MOVIMIENTO_LONGITUD_PRECIO = 8;
        public const int MOVIMIENTO_LONGITUD_PRECIO_CAPTURADO = 8;
        public const int MOVIMIENTO_LONGITUD_NETO = 8;
        public const int MOVIMIENTO_LONGITUD_IMPUESTO1 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT01 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPUESTO2 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT02 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPUESTO3 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT03 = 8;
        public const int MOVIMIENTO_LONGITUD_DESCUENTO1 = 8;
        public const int MOVIMIENTO_LONGITUD_DESCUENTO2 = 8;
        public const int MOVIMIENTO_LONGITUD_DESCUENTO3 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT06 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT07 = 8;
        public const int MOVIMIENTO_LONGITUD_PORCENT08 = 8;
        public const int MOVIMIENTO_LONGITUD_TOTAL = 8;
        public const int MOVIMIENTO_LONGITUD_REFERENCIA = 20;
        public const int MOVIMIENTO_LONGITUD_OBSERVACIONES = 255;
        public const int MOVIMIENTO_LONGITUD_IMPORTE_EXTRA1 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPORTE_EXTRA2 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPORTE_EXTRA3 = 8;
        public const int MOVIMIENTO_LONGITUD_IMPORTE_EXTRA4 = 8;
        public const int MOVIMIENTO_LONGITUD_TEXTO_EXTRA1 = 50;
        public const int MOVIMIENTO_LONGITUD_TEXTO_EXTRA2 = 50;
        public const int MOVIMIENTO_LONGITUD_TEXTO_EXTRA3 = 50;

        public const string MOVIMIENTO_CAMPO_ID = "cidmovimiento";
        public const string MOVIMIENTO_CAMPO_ID_DOCUMENTO = "ciddocumento";
        public const string MOVIMIENTO_CAMPO_NUMERO_MOVIMIENTO = "cnumeromovimiento";
        public const string MOVIMIENTO_CAMPO_TIPO_DOCUMENTO = "ciddocumentode";
        public const string MOVIMIENTO_CAMPO_ID_PRODUCTO = "cidproducto";
        public const string MOVIMIENTO_CAMPO_ID_ALMACEN = "cidalmacen";
        public const string MOVIMIENTO_CAMPO_UNIDADES_BASE = "cunidades";
        public const string MOVIMIENTO_CAMPO_UNIDADES_NO_CONVERTIBLES = "cunidadesnc";
        public const string MOVIMIENTO_CAMPO_UNIDADES_CAPTURADAS = "cunidadescapturadas";
        public const string MOVIMIENTO_CAMPO_IDENTIFICADOR_UNIDAD = "cidunidad";
        public const string MOVIMIENTO_CAMPO_PRECIO = "cprecio";
        public const string MOVIMIENTO_CAMPO_PRECIO_CAPTURADO = "cpreciocapturado";
        public const string MOVIMIENTO_CAMPO_NETO = "cneto";
        public const string MOVIMIENTO_CAMPO_IMPUESTO1 = "cimpuesto1";
        public const string MOVIMIENTO_CAMPO_PORCENT01 = "cporcentajeimpuesto1";
        public const string MOVIMIENTO_CAMPO_IMPUESTO2 = "cimpuesto2";
        public const string MOVIMIENTO_CAMPO_PORCENT02 = "cporcentajeimpuesto2";
        public const string MOVIMIENTO_CAMPO_IMPUESTO3 = "cimpuesto3";
        public const string MOVIMIENTO_CAMPO_PORCENT03 = "cporcentajeimpuesto3";
        public const string MOVIMIENTO_CAMPO_DESCUENTO1 = "cdescuento1";
        public const string MOVIMIENTO_CAMPO_DESCUENTO2 = "cdescuento2";
        public const string MOVIMIENTO_CAMPO_DESCUENTO3 = "cdescuento3";
        public const string MOVIMIENTO_CAMPO_TOTAL = "ctotal";
        public const string MOVIMIENTO_CAMPO_REFERENCIA = "creferencia";
        public const string MOVIMIENTO_CAMPO_OBSERVACIONES = "cobservamov";
        public const string MOVIMIENTO_CAMPO_PORCENT06 = "cporcentajedescuento1";
        public const string MOVIMIENTO_CAMPO_PORCENT07 = "cporcentajedescuento1";
        public const string MOVIMIENTO_CAMPO_PORCENT08 = "cporcentajedescuento1";
        public const string MOVIMIENTO_CAMPO_IMPORTE_EXTRA1 = "cimporteextra1";
        public const string MOVIMIENTO_CAMPO_IMPORTE_EXTRA2 = "cimporteextra2";
        public const string MOVIMIENTO_CAMPO_IMPORTE_EXTRA3 = "cimporteextra3";
        public const string MOVIMIENTO_CAMPO_IMPORTE_EXTRA4 = "cimporteextra4";
        public const string MOVIMIENTO_CAMPO_TEXTO_EXTRA1 = "ctextoextra1";
        public const string MOVIMIENTO_CAMPO_TEXTO_EXTRA2 = "ctextoextra2";
        public const string MOVIMIENTO_CAMPO_TEXTO_EXTRA3 = "ctextoextra3";
        #endregion

        #region parametros para unidades
        public const int UNIDAD_LONGITUD_ID = 11;
        public const int UNIDAD_LONGITUD_NOMBRE = 60;
        public const int UNIDAD_LONGITUD_ABREVIATURA = 3;
        public const int UNIDAD_LONGITUD_CLAVE_INTERNACIONAL = 3;

        public const string UNIDAD_CAMPO_ID = "cidunidad";
        public const string UNIDAD_CAMPO_NOMBRE = "cnombreunidad";
        public const string UNIDAD_CAMPO_ABREVIATURA = "cabreviatura";
        public const string UNIDAD_CAMPO_CLAVE_INTERNACIONAL = "cclaveint";
        #endregion

        #region parametros para agentes
        public const int AGENTE_LONGITUD_ID = 11;
        public const int AGENTE_LONGITUD_CODIGO = 30;
        public const int AGENTE_LONGITUD_NOMBRE = 60;

        public const string AGENTE_CAMPO_ID = "CIDAGENTE";
        public const string AGENTE_CAMPO_CODIGO = "CCODIGOAGENTE";
        public const string AGENTE_CAMPO_NOMBRE = "CNOMBREAGENTE";
        #endregion
#endif
    }
}
