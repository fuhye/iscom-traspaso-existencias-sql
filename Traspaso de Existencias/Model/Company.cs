using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traspaso_de_Existencias.Model
{
    internal class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DataPath { get; set; }

        private string _Database;
        public string GetDatabase()
        {
            if (string.IsNullOrEmpty(_Database))
            {
                string[] split = DataPath.Split('\\');
                _Database = split[split.Length - 1];
            }
            return _Database;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
