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
    public class DPuesto : IDPuesto
    {
        #region "Propiedades"
        protected static Database db = DConexion.Instance().GetSqlDatabase();

        public int Actualizar(PuestoDTO entity)
        {
            return EjecutarMantenimiento(entity, 2);
        }

        public int ActualizarEstado(PuestoDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(PuestoDTO entity)
        {
            return EjecutarMantenimiento(entity, 3);
        }

        public int Insertar(PuestoDTO entity)
        {
            return EjecutarMantenimiento(entity, 1);
        }

        public List<PuestoDTO> Listar()
        {
            throw new NotImplementedException();
        }

        public List<PuestoDTO> Listar(PuestoDTO entity)
        {
            List<PuestoDTO> retval = new List<PuestoDTO>();
            PuestoDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_puestos"))
            {
                db.AddInParameter(cmd, "acEstado", DbType.String, entity.Estado);
                db.AddInParameter(cmd, "avFiltro", DbType.String, entity.Nombre);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new PuestoDTO();
                        item.Id = int.Parse(dr["Id"].ToString());
                        item.Nombre = dr["Nombre"].ToString();
                        item.Descripcion = dr["Descripcion"].ToString();
                        item.Estado = dr["Estado"].ToString();
                        item.UsuarioCreacion = dr["Usuario_Creacion"].ToString();
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }

        public PuestoDTO Obtener(PuestoDTO entity)
        {
            PuestoDTO item = null;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_puesto_por_id"))
            {
                db.AddInParameter(cmd, "aiId", DbType.String, entity.Id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        item = new PuestoDTO();
                        item.Id = int.Parse(dr["Id"].ToString());
                        item.Estado = dr["Estado"].ToString();
                        item.Nombre = dr["Nombre"].ToString();
                        item.Descripcion = dr["Descripcion"].ToString();
                        item.ConocimientoTecnico = dr["Conocimiento_Tecnico"].ToString();
                    }
                }
            }
            return item;
        }
        #endregion

        #region "Metodos Privados"
        private int EjecutarMantenimiento(PuestoDTO entity, int accion)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_reg_puestos"))
            {
                db.AddInParameter(cmd, "aitype", DbType.Int16, accion);
                db.AddInParameter(cmd, "aiId", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "avNombre", DbType.String, entity.Nombre);
                db.AddInParameter(cmd, "avDescripcion", DbType.String, entity.Descripcion);
                db.AddInParameter(cmd, "avUsuario_Creacion", DbType.String, entity.UsuarioCreacion);
                db.AddInParameter(cmd, "avUsuario_Modificacion", DbType.String, entity.UsuarioModificacion);
                db.AddInParameter(cmd, "avConocimientoTecnico", DbType.String, entity.ConocimientoTecnico);
                if (accion == 1)
                {
                    return int.Parse(db.ExecuteScalar(cmd).ToString());
                }
                else
                {
                    db.ExecuteNonQuery(cmd);
                    return entity.Id;
                }
            }
        }
        #endregion
    }
}
