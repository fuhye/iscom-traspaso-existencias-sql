using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ComercialSDK.SDK {
    public static class AbstractDataTypes {
        /// <summary>
        /// Clase con las constantes con la longitud de cada campo
        /// </summary>
        public class FieldLongConstants {
            public const int kLongId = 11;
            public const int kLongCodigo = 31;
            public const int kLongNombre = 61;
            public const int kLongNombreProducto = 256;
            public const int kLongFecha = 24;
            public const int kLongAbreviatura = 4;
            public const int kLongCodValorCblasif = 4;
            public const int kLongTextoExtra = 51;
            public const int kLongNumSerie = 12;
            public const int kLongReferencia = 21;
            public const int kLongSeries = 31;
            public const int kLongDescripcion = 61;
            public const int kLongNumeroExtInt = 7;
            public const int kLongCodigoPostal = 7;
            public const int kLongTelefono = 16;
            public const int kLongEmailWeb = 51;
            public const int kLongRFC = 21;
            public const int kLongCURP = 21;
            public const int kLongDesCorta = 21;
            public const int kLongDenComercial = 51;
            public const int kLongRepLegal = 51;
            public const int kLongNumeroExpandido = 31;
            public const int kLongLugarExpedicion = 401;
            public const int klongUUID = 36;
        }

        /// <summary>
        /// Estructura tDocumento, sirve para dar de alta un documento utilizando funciones de alto nivel
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tDocumento {
            public double aFolio;
            public Int32 aNumMoneda;
            public double aTipoCambio;
            public double aImporte;
            public double aDescuentoDoc1;
            public double aDescuentoDoc2;
            public int aSistemaOrigen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String aCodConcepto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongNumSerie)]
            public String aSerie;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String aFecha;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String aCodigoCteProv;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String aCodigoAgente;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongReferencia)]
            public String aReferencia;
            public Int32 aAfecta;
            public double aGasto1;
            public double aGasto2;
            public double aGasto3;
        }

        /// <summary>
        /// Estructura tllaveDocto, sirve para afectar un documento utilizando funciones de alto nivel
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tLlaveDocto {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String aCodConcepto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongNumSerie)]
            public String aSerie;
            public double aFolio;
        }

        /// <summary>
        /// Estructura tMovimiento, sirve para dar de alta un movimiento utilizando instrucciones de alto nivel
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tMovimiento {
            public Int32 aConsecutivo;
            public double aUnidades;
            public double aPrecio;
            public double aCosto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String aCodProdSer;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String aCodAlmacen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongReferencia)]
            public String aReferencia;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String aCodClasificacion;
        }

        /// <summary>
        /// Estructura tCteProv, sirve para dar de alta un producto utilizando instrucciones de alto nivel
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tCteProv {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String cCodigoCliente;//[ kLongCodigo + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongNombre)]
            public String cRazonSocial;//[ kLongNombre + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String cFechaAlta;//[ kLongFecha + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongRFC)]
            public String cRFC;//[ kLongRFC + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCURP)]
            public String cCURP;//[ kLongCURP + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDenComercial)]
            public String cDenComercial;//[ kLongDenComercial + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongRepLegal)]
            public String cRepLegal;//[ kLongRepLegal + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongNombre)]
            public String cNombreMoneda;//[ kLongNombre + 1 ];
            public int cListaPreciosCliente;
            public double cDescuentoMovto;
            public int cBanVentaCredito; // 0 = No se permite venta a crédito, 1 = Se permite venta a crédito
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionCliente1;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionCliente2;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionCliente3;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionCliente4;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionCliente5;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionCliente6;//[ kLongCodValorClasif + 1 ];
            public int cTipoCliente; // 1 - Cliente, 2 - Cliente/Proveedor, 3 - Proveedor
            public int cEstatus; // 0. Inactivo, 1. Activo
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String cFechaBaja;//[ kLongFecha + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String cFechaUltimaRevision;//[ kLongFecha + 1 ];
            public double cLimiteCreditoCliente;
            public int cDiasCreditoCliente;
            public int cBanExcederCredito; // 0 = No se permite exceder crédito, 1 = Se permite exceder el crédito
            public double cDescuentoProntoPago;
            public int cDiasProntoPago;
            public double cInteresMoratorio;
            public int cDiaPago;
            public int cDiasRevision;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDesCorta)]
            public String cMensajeria;//[ kLongDesCorta + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String cCuentaMensajeria;//[ kLongDescripcion + 1 ];
            public int cDiasEmbarqueCliente;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String cCodigoAlmacen;//[ kLongCodigo + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String cCodigoAgenteVenta;//[ kLongCodigo + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String cCodigoAgenteCobro;//[ kLongCodigo + 1 ];
            public int cRestriccionAgente;
            public double cImpuesto1;
            public double cImpuesto2;
            public double cImpuesto3;
            public double cRetencionCliente1;
            public double cRetencionCliente2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionProveedor1;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionProveedor2;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionProveedor3;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionProveedor4;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionProveedor5;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacionProveedor6;//[ kLongCodValorClasif + 1 ];
            public double cLimiteCreditoProveedor;
            public int cDiasCreditoProveedor;
            public int cTiempoEntrega;
            public int cDiasEmbarqueProveedor;
            public double cImpuestoProveedor1;
            public double cImpuestoProveedor2;
            public double cImpuestoProveedor3;
            public double cRetencionProveedor1;
            public double cRetencionProveedor2;
            public int cBanInteresMoratorio; // 0 = No se le calculan intereses moratorios al cliente, 1 = Si se le calculan intereses moratorios al cliente.
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTextoExtra)]
            public String cTextoExtra1;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTextoExtra)]
            public String cTextoExtra2;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTextoExtra)]
            public String cTextoExtra3;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTextoExtra)]
            public String cFechaExtra;//[ kLongFecha + 1 ];
            public double cImporteExtra1;
            public double cImporteExtra2;
            public double cImporteExtra3;
            public double cImporteExtra4;

        }

        /// <summary>
        /// Estructura tDireccion, sirve para dar de alta un domicilio para cliente o documento
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tDireccion
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String aCodCteProv;
            public int cTipoCatalogo;
            public int aTipoDireccion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String cNombreCalle;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongNumeroExpandido)]
            public String cNumeroExterior;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongNumeroExpandido)]
            public String cNumeroInterior;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String cColonia;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigoPostal)]
            public String cCodigoPostal;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTelefono)]
            public String cTelefono1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTelefono)]
            public String cTelefono2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTelefono)]
            public String cTelefono3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTelefono)]
            public String cTelefono4;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongEmailWeb)]
            public String cEmail;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongEmailWeb)]
            public String cDireccionWeb;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String cCiudad;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String cEstado;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String cPais;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String cTextoExtra;
        }

        /// <summary>
        /// Estructura tProducto, sirve para dar de alta un producto utilizando instrucciones de alto nivel
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tProducto {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String cCodigoProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongNombre)]
            public String cNombreProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongNombreProducto)]
            public String cDescripcionProducto;
            public int cTipoProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String cFechaAltaProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String cFechaBaja;
            public int cStatusProducto;
            public int cControlExistencia;
            public int cMetodoCosteo;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String cCodigoUnidadBase;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String cCodigoUnidadNoConvertible;
            public double cPrecio1;
            public double cPrecio2;
            public double cPrecio3;
            public double cPrecio4;
            public double cPrecio5;
            public double cPrecio6;
            public double cPrecio7;
            public double cPrecio8;
            public double cPrecio9;
            public double cPrecio10;
            public double cImpuesto1;
            public double cImpuesto2;
            public double cImpuesto3;
            public double cRetencion1;
            public double cRetencion2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongAbreviatura)]
            public String cNombreCaracteristica1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongAbreviatura)]
            public String cNombreCaracteristica2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongAbreviatura)]
            public String cNombreCaracteristica3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacion1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacion2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacion3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacion4;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacion5;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodValorCblasif)]
            public String cCodigoValorClasificacion6;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTextoExtra)]
            public String cTextoExtra1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTextoExtra)]
            public String cTextoExtra2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongTextoExtra)]
            public String cTextoExtra3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String cFechaExtra;
            public double cImporteExtra1;
            public double cImporteExtra2;
            public double cImporteExtra3;
            public double cImporteExtra4;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tUnidad
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongNombre)]
            public String cNombreUnidad;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongAbreviatura)]
            public String cAbreviatura;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongAbreviatura)]
            public String cDespliegue;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tSeriesCapas
        {
            public double aUnidades;

            public double aTipoCambio;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongCodigo)]
            public String aSeries;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String aPedimento;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String aAgencia;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String aFechaPedimento;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongDescripcion)]
            public String aNumeroLote;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String aFechaFabricacion;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FieldLongConstants.kLongFecha)]
            public String aFechaCaducidad;
        }
    }
}
