using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.DAL.Common
{
    public class DConexion
    {
        #region "Custom"
        private static readonly DConexion _instance = new DConexion();
        public static DConexion Instance()
        {
            return _instance;
        }
        #endregion

        public SqlDatabase GetSqlDatabase()
        {
            string sConexion = ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString();
            return new SqlDatabase(sConexion);
        }
        public SqlDatabase GetSqlDatabase(string sConexion)
        {
            return new SqlDatabase(sConexion);
        }
    }
}
