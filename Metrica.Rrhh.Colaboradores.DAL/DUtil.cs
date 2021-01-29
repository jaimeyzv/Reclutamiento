using Metrica.Rrhh.Colaboradores.DAL.Common;
using Metrica.Rrhh.Colaboradores.DAL.Interfaz;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.DAL
{
    public class DUtil : IDUtil
    {
        #region "Propiedades"
        protected static Database db = DConexion.Instance().GetSqlDatabase();
        #endregion

        public List<ItemDTO> ListarEstadoXDominio(int dominio)
        {
            List<ItemDTO> retval = new List<ItemDTO>();
            ItemDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_estado_por_dominio"))
            {
                db.AddInParameter(cmd, "aiDominio", DbType.Int16, dominio);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new ItemDTO();
                        item.Codigo = dr["Codigo"].ToString();
                        item.Valor = dr["Descripcion"].ToString();
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }

        public List<ItemDTO> ListarSkillTecnico(int idPuesto)
        {
            List<ItemDTO> retval = new List<ItemDTO>();
            ItemDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_skill"))
            {
                db.AddInParameter(cmd, "aiId_Puesto", DbType.Int32, idPuesto);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new ItemDTO();
                        item.Codigo = dr["Id_Puesto"].ToString();
                        item.Valor = dr["Nombre"].ToString();
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }

        public List<ItemDTO> ListarDistritos(string ubigeo)
        {
            List<ItemDTO> retval = new List<ItemDTO>();
            ItemDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_distrito"))
            {
                db.AddInParameter(cmd, "acCodigo_Ubigeo", DbType.String, ubigeo);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new ItemDTO();
                        item.Codigo = dr["Codigo"].ToString();
                        item.Valor = dr["Nombre"].ToString();
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }
    }
}
