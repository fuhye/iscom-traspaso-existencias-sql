using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Traspaso_de_Existencias.Error;
using Traspaso_de_Existencias.Model;
using Traspaso_de_Existencias.Properties;

namespace Traspaso_de_Existencias.Services
{
    class SQLService
    {
        private static SQLService _Instance;

        public static SQLService Instance
        {
            get
            {
                if(ReferenceEquals(_Instance, null))
                {
                    _Instance = new SQLService();
                }
                return _Instance;
            }
        }

        private SQLService()
        {

        }

        internal string GetCONPAQConnectionString(string CompanyDb = "CompacWAdmin")
        {
            Settings c = Settings.Default;
            return string.Format("Server={0};Database={1};User Id={2};Password = {3}; ", c.ServerInstance, CompanyDb, c.Username, c.Password);
        }

        internal List<T> GetObjects<T>(string query, Company source) where T : new()
        {
            try
            {
                List<T> POCOs = new List<T>();
                using (SqlConnection conn = new SqlConnection(GetCONPAQConnectionString(source.GetDatabase())))
                {
                    conn.Open();
                    using (SqlCommand cm = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                T POCO = new T();
                                PropertyInfo[] Properties = POCO.GetType().GetProperties();
                                foreach (PropertyInfo Prop in Properties)
                                {
                                    Prop.SetValue(POCO, dr[Prop.Name]);
                                }
                                POCOs.Add(POCO);
                            }
                        }
                    }
                }
                return POCOs;
            }
            catch(SqlException sex)
            {
                throw new TraspasoExistenciasException("Ocurrio un error al recuperar las existencias a traspasar", sex);
            }
        }

        internal List<T> GetObjects<T>(string query) where T : new()
        {
            try
            {
                List<T> POCOs = new List<T>();
                using (SqlConnection conn = new SqlConnection(GetCONPAQConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cm = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                T POCO = new T();
                                PropertyInfo[] Properties = POCO.GetType().GetProperties();
                                foreach (PropertyInfo Prop in Properties)
                                {
                                    Prop.SetValue(POCO, dr[Prop.Name]);
                                }
                                POCOs.Add(POCO);
                            }
                        }
                    }
                }
                return POCOs;
            }
            catch (SqlException sex)
            {
                throw new TraspasoExistenciasException("Ocurrio un error al recuperar las existencias a traspasar", sex);
            }
        }

        public void TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetCONPAQConnectionString()))
                {
                    conn.Open();
                }
            }
            catch(SqlException sex)
            {
                throw new TraspasoExistenciasException("Ocurrio un error al probar la conexión verifique sus credenciales", sex);
            }
            catch(Exception ex)
            {
                throw new TraspasoExistenciasException("Ocurrio un error desconocido al probar la conexión verifique sus credenciales", ex);
            }
        }
    }
}
