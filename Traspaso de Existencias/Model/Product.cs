using ComercialSDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traspaso_de_Existencias.Services;

namespace Traspaso_de_Existencias.Model
{
    internal class Product
    {
        SQLService SQLService;
        List<Serie> _Series;
        Dictionary<string, double> _Existances;
        public Product()
        {
            SQLService = SQLService.Instance;
            _Existances = new Dictionary<string, double>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ExistanceControl { get; set; }
        public List<Serie> GetSeries(Warehouse warehouse, Company company)
        {
            return SQLService.GetObjects<Serie>(string.Format("SELECT CNUMEROSERIE SeriesNumber FROM admNumerosSerie WHERE CIDALMACEN = {0} AND CESTADO = 1 AND CIDPRODUCTO = {1}", warehouse.Id, Id), company);
        }

        public void DropExistanceCache()
        {
            _Existances = new Dictionary<string, double>();
        }

        public double GetExistence(Warehouse warehouse)
        {
            if (_Existances.Keys.Contains(warehouse.Code))
            {
                return _Existances[warehouse.Code];
            }
            else
            {
                double existencia = 0;
                string ano, mes, dia;
                ano = DateTime.Today.Year.ToString();
                mes = DateTime.Today.Month.ToString();
                dia = DateTime.Today.Day.ToString();
                string producto = Code;
                string almacen = warehouse.Code;
                int error = Productos.fRegresaExistencia(producto, almacen, ano, mes, dia, ref existencia);
                _Existances.Add(warehouse.Code, existencia);
                return existencia;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Code, Name);
        }
    }
}
