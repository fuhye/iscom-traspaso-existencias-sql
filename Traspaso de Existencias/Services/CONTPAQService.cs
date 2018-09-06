using ComercialSDK.SDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Traspaso_de_Existencias.Error;
using Traspaso_de_Existencias.Model;
using Traspaso_de_Existencias.Properties;
using static ComercialSDK.SDK.AbstractDataTypes;

namespace Traspaso_de_Existencias.Services
{
    internal class CONTPAQService
    {
        private static CONTPAQService _Instance;
        private int _Error;
        private SQLService SQLService;

        public static CONTPAQService Instance
        {
            get
            {
                if (ReferenceEquals(_Instance, null))
                {
                    _Instance = new CONTPAQService();
                }
                return _Instance;
            }
        }

        private CONTPAQService()
        {
            SQLService = SQLService.Instance;
        }

        [HandleProcessCorruptedStateExceptions]
        public void Login(Company source)
        {
            Directory.SetCurrentDirectory(Settings.Default.SDKDirectory);
            General.fInicioSesionSDK(Settings.Default.UsuarioComercial, Settings.Default.PasswordComercial);
            _Error = General.fSetNombrePAQ("CONTPAQ I Comercial");
            if (Settings.Default.HasContabilidad)
            {
                General.fInicioSesionSDKCONTPAQi(Settings.Default.UsuarioContabilidad, Settings.Default.PasswordContabilidad);
            }
            if(_Error == 0)
            {
                _Error = General.fAbreEmpresa(source.DataPath.Trim());
            }
        }

        internal TimeSpan Verify(TraspasoParameters parameters, List<TraspasoVerification> verificationList)
        {
            Stopwatch sw = new Stopwatch();
            TraspasoVerification verify;

            sw.Start();
            verificationList.Clear();
            Login(parameters.Source);
            foreach (Warehouse w in parameters.Warehouses)
            {
                foreach (Product p in parameters.Products)
                {
                    verify = new TraspasoVerification();
                    verify.Product = p.Name;
                    verify.Warehouse = w.Name;
                    verify.QuantitySource = p.GetExistence(w);
                    verificationList.Add(verify);
                }
            }
            LogOut();

            Login(parameters.DestinationDb);
            foreach (Warehouse w in parameters.Warehouses)
            {
                foreach (Product p in parameters.Products)
                {
                    p.DropExistanceCache();
                    verify = verificationList.Where(x => x.Product == p.Name && x.Warehouse == w.Name).FirstOrDefault();
                    verify.QuantityDestiny = p.GetExistence(w);
                    p.DropExistanceCache();
                }
            }
            LogOut();
            sw.Stop();
            return sw.Elapsed;
        }

        public void LogOut()
        {
            General.fCierraEmpresa();
            General.fTerminaSDK();
        }

        internal List<Product> GetProducts(Company source)
        {
            const string PRODUCT_SQL = "SELECT CIDPRODUCTO Id, CCODIGOPRODUCTO Code, CNOMBREPRODUCTO Name, CCONTROLEXISTENCIA ExistanceControl FROM admProductos WHERE CSTATUSPRODUCTO = 1 AND (CTIPOPRODUCTO = 1 OR CTIPOPRODUCTO = 2) ORDER BY CNOMBREPRODUCTO";
            return SQLService.GetObjects<Product>(PRODUCT_SQL, source);
        }

        internal List<Company> GetCompanies()
        {
            const string COMPANY_SQL = "SELECT CIDEMPRESA Id, CNOMBREEMPRESA Name, CRUTADATOS DataPath FROM Empresas WHERE CNOMBREEMPRESA != '(Predeterminada)' ORDER BY CNOMBREEMPRESA";
            return SQLService.GetObjects<Company>(COMPANY_SQL);
        }

        internal List<Warehouse> GetWarehouses(Company source)
        {
            const string WAREHOUSE_SQL = "SELECT CIDALMACEN Id, CCODIGOALMACEN Code, CNOMBREALMACEN Name FROM admAlmacenes WHERE CCODIGOALMACEN != '(Ninguno)' AND CCODIGOALMACEN != '999' ORDER BY CNOMBREALMACEN";
            return SQLService.GetObjects<Warehouse>(WAREHOUSE_SQL, source);
        }

        string GetCurrentError()
        {
            StringBuilder str = new StringBuilder(300);
            General.fError(_Error, str, 300);
            return str.ToString().Trim();
        }

        internal TraspasoResult TraspasoExistencias(TraspasoParameters TParameters)
        {
            TraspasoResult result = new TraspasoResult();
            List<string> series = new List<string>();
            const string codigoConcepto = "34";
            const string serie = "";
            double existance = 0;
            double folio = 0;
            int documentoId = 0;
            int movimientoId = 0;
            int consecutivo = 1;
            string currentWarehouse = string.Empty;
            string currentProduct = string.Empty;

            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Login(TParameters.Source);
                List<Product> ProductsWithExistance = TParameters.Products.Where(x => x.ExistanceControl != 4).ToList();
                List<Product> ProductsWithSeries = TParameters.Products.Where(x => x.ExistanceControl == 4).ToList();
                foreach (Warehouse w in TParameters.Warehouses)
                {
                    foreach(Product p in ProductsWithExistance)
                    {
                        p.GetExistence(w);
                    }
                }
                LogOut();
                sw.Stop();
                result.TimeToRead = sw.Elapsed;

                sw.Restart();
                Login(TParameters.DestinationDb);
                foreach(Warehouse w in TParameters.Warehouses)
                {
                    _Error = Documentos.fSiguienteFolio(codigoConcepto, "", ref folio);
                    currentWarehouse = w.Name;
                    if (_Error == 0)
                    {
                        tDocumento documento = new tDocumento()
                        {
                            aCodConcepto = codigoConcepto,
                            aFolio = folio,
                            aSerie = serie,
                            aFecha = DateTime.Today.ToString("MM/dd/yyyy")
                        };
                        _Error = Documentos.fAltaDocumento(ref documentoId, ref documento);

                        foreach (Product p in ProductsWithExistance)
                        {
                            currentProduct = p.Name;
                            if (_Error == 0)
                            {
                                existance = p.GetExistence(w);
                                if (existance > 0)
                                {
                                    tMovimiento movto = new tMovimiento();
                                    movto.aCodAlmacen = w.Code;
                                    movto.aCodProdSer = p.Code;
                                    movto.aConsecutivo = consecutivo;
                                    movto.aUnidades = existance;
                                    _Error = Movimientos.fAltaMovimiento(documentoId, ref movimientoId, ref movto);
                                }
                                consecutivo++;
                            }
                            if(_Error != 0)
                            {
                                result.Errors.Add(string.Format("Almacen: {0}, Producto: {1}, Detalles: {2}", currentWarehouse, currentProduct, GetCurrentError()));
                            }
                        }
                    }
                }

                consecutivo = 0;
                foreach (Warehouse w in TParameters.Warehouses)
                {
                    _Error = Documentos.fSiguienteFolio(codigoConcepto, "", ref folio);
                    currentWarehouse = w.Name;
                    if (_Error == 0)
                    {

                        tDocumento documento = new tDocumento()
                        {
                            aCodConcepto = codigoConcepto,
                            aFolio = folio,
                            aSerie = serie,
                            aFecha = DateTime.Today.ToString("MM/dd/yyyy")
                        };
                        _Error = Documentos.fAltaDocumento(ref documentoId, ref documento);

                        foreach (Product p in ProductsWithSeries)
                        {
                            if (_Error == 0)
                            {
                                currentProduct = p.Name;
                                series = p.GetSeries(w, TParameters.Source).Select(x => x.SeriesNumber).ToList();
                                if (series.Count > 0)
                                {
                                    tMovimiento movto = new tMovimiento();
                                    movto.aCodAlmacen = w.Code;
                                    movto.aCodProdSer = p.Code;
                                    movto.aConsecutivo = consecutivo;
                                    _Error = Movimientos.fAltaMovimiento(documentoId, ref movimientoId, ref movto);

                                    foreach (string s in series)
                                    {
                                        if (_Error == 0)
                                        {
                                            tSeriesCapas movtoSerie = new tSeriesCapas() { aSeries = s };
                                            _Error = Movimientos.fAltaMovimientoSeriesCapas(movimientoId, ref movtoSerie);
                                            if(_Error != 0)
                                            {
                                                result.Errors.Add(string.Format("Almacen: {0}, Producto: {1}, Serie: {2}, Detalles: {3}", currentWarehouse, currentProduct, s, GetCurrentError()));
                                            }
                                        }
                                    }
                                    consecutivo++;
                                }
                            }
                        }
                    }
                }
                if(result.Errors.Count <= 0)
                {
                    result.Errors.Add("No hubo errores durante este traspaso");
                }
                sw.Stop();
                result.TimeToImport = sw.Elapsed;
                LogOut();
                return result;
            }
            catch(AccessViolationException ave)
            {
                throw new TraspasoExistenciasException("Ocurrio un error al realizar el traspaso de información, revise los permisos en las carpetas de CONTPAQ I Comercial", ave);
            }
        }

        
    }
}
