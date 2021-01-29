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
    public class DRequerimiento: IDRequerimiento
    {
        #region "Propiedades"
        protected static Database db = DConexion.Instance().GetSqlDatabase();
        #endregion

        public int Actualizar(RequerimientoDTO entity)
        {
            return EjecutarMantenimiento(entity, 2);
        }

        public int ActualizarEstado(RequerimientoDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(RequerimientoDTO entity)
        {
            return EjecutarMantenimiento(entity, 3);
        }

        public int Insertar(RequerimientoDTO entity)
        {
            return EjecutarMantenimiento(entity, 1);
         }

        public List<RequerimientoDTO> Listar()
        {
            throw new NotImplementedException();
        }

        public List<RequerimientoDTO> Listar(RequerimientoDTO entity)
        {
            
            List<RequerimientoDTO> retval = new List<RequerimientoDTO>();
            RequerimientoDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_requerimientos"))
            {
                db.AddInParameter(cmd, "adFechaIni", DbType.Date, entity.FechaCreacion);
                db.AddInParameter(cmd, "adFechaFin", DbType.Date, entity.FechaModificacion);
                db.AddInParameter(cmd, "aiIdCliente", DbType.Int32, entity.Cliente == null ? 0 :entity.Cliente.Id);
                db.AddInParameter(cmd, "acEstado", DbType.String, entity.Estado);
                db.AddInParameter(cmd, "avTexto", DbType.String, entity.Descripcion);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new RequerimientoDTO();
                        item.Id = int.Parse(dr["Id_Requerimiento"].ToString());
                        item.Perfil = dr["Perfil"].ToString();
                        item.Cliente = new ClienteDTO { Ruc = dr["Ruc"].ToString(), RazonSocial = dr["Razon_Social"].ToString() };
                        item.Estado = dr["Estado"].ToString();
                        item.FechaTentativa = DateTime.Parse(dr["Fecha_Tentativa"].ToString());
                        item.RangoSalario = dr["Rango_Salario"].ToString();
                        item.UsuarioCreacion = dr["Usuario_Creacion"].ToString();
                        item.OrdenCompra = dr["OrdenCompra"].ToString();
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }

        public RequerimientoDTO Obtener(RequerimientoDTO entity)
        {
            RequerimientoDTO item = null;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_requerimiento_por_id"))
            {
                db.AddInParameter(cmd, "aiId_Requerimiento", DbType.Int32, entity.Id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        item = new RequerimientoDTO();
                        item.Id = int.Parse(dr["Id_Requerimiento"].ToString());
                        item.Perfil = dr["Perfil"].ToString();
                        item.Cliente = new ClienteDTO { Id = (int)dr["Id_Cliente"], Ruc = dr["Ruc"].ToString(), RazonSocial = dr["Razon_Social"].ToString() };
                        item.Estado = dr["Estado"].ToString();
                        item.FechaTentativa = DateTime.Parse(dr["Fecha_Tentativa"].ToString());
                        item.RangoSalario = dr["Rango_Salario"].ToString();
                        item.Descripcion = dr["Descripcion"].ToString();
                        item.OrdenCompra = dr["OrdenCompra"].ToString();
                    }
                }
            }
            return item;
        }

        #region "Metodos Privados"
        private int EjecutarMantenimiento(RequerimientoDTO entity, int accion)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_reg_requerimiento"))
            {
                db.AddInParameter(cmd, "aitype", DbType.Int16, accion);
                db.AddInParameter(cmd, "aiId_Requerimiento", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "avPerfil", DbType.String, entity.Perfil);
                db.AddInParameter(cmd, "aiId_Cliente", DbType.Int32, entity.Cliente != null? entity.Cliente.Id:0);
                db.AddInParameter(cmd, "acEstado", DbType.String, entity.Estado);
                db.AddInParameter(cmd, "aFecha_Tentativa", DbType.Date, entity.FechaTentativa != DateTime.MinValue? entity.FechaTentativa: DateTime.Now);
                db.AddInParameter(cmd, "avRango_Salario", DbType.String, entity.RangoSalario);
                db.AddInParameter(cmd, "avOrden_Compra", DbType.String, entity.OrdenCompra);
                db.AddInParameter(cmd, "avDescripcion", DbType.String, entity.Descripcion);
                db.AddInParameter(cmd, "avUsuario_Creacion", DbType.String, entity.UsuarioCreacion);
                db.AddInParameter(cmd, "avUsuario_Modificacion", DbType.String, entity.UsuarioModificacion);
                if(accion == 1)
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
