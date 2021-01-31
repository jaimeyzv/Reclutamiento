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
    public class DPostulacion : IDPostulacion
    {
        #region "Propiedades"
        protected static Database db = DConexion.Instance().GetSqlDatabase();
        #endregion

        public int Actualizar(PostulanteDTO entity)
        {
            return EjecutarMantenimiento(entity, 2);
        }

        public int ActualizarEstado(PostulanteDTO entity)
        {
            return EjecutarMantenimiento(entity, entity.Accion);
        }

        public int Eliminar(PostulanteDTO entity)
        {
            return EjecutarMantenimiento(entity, 3);
        }

        public int Insertar(PostulanteDTO entity)
        {
            return EjecutarMantenimiento(entity, 1);
        }

        public List<PostulanteDTO> Listar()
        {
            throw new NotImplementedException();
        }

        public List<PostulanteDTO> Listar(PostulanteDTO entity)
        {
            List<PostulanteDTO> retval = new List<PostulanteDTO>();
            PostulanteDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand(entity.Accion == 1? "sp_sel_postulaciones": "sp_sel_postulaciones_por_idreq"))
            {
                if(entity.Accion == 1)
                {
                    db.AddInParameter(cmd, "aiId_Cliente", DbType.Int32, entity.IdCliente);
                    db.AddInParameter(cmd, "acEstado", DbType.String, entity.Estado);
                    db.AddInParameter(cmd, "avFiltro", DbType.String, entity.Observacion);
                }
                else
                {
                    db.AddInParameter(cmd, "aiId_Requerimiento", DbType.Int32, entity.IdRequerimiento);
                }
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new PostulanteDTO();
                        item.Dni = dr["Dni"].ToString();
                        item.Email = dr["Email"].ToString();
                        item.ApellidoPaterno = dr["Apellido_Paterno"].ToString();
                        item.ApellidoMaterno = dr["Apellido_Materno"].ToString();
                        item.Nombres = dr["Nombres"].ToString();
                        item.IdPuesto = int.Parse(dr["IdPuesto"].ToString());
                        item.Pretencion = int.Parse(dr["Prentencion"].ToString());
                        item.Disponibilidad = int.Parse(dr["Disponibilidad"].ToString());
                        item.Estado = dr["Estado"].ToString();
                        item.FechaPostulacion = DateTime.Parse(dr["Fecha_Postulacion"].ToString());
                        item.Observacion = dr["Observacion"].ToString();
                        if (entity.Accion == 1)
                        {
                            item.IdCliente = int.Parse(dr["Id_Cliente"].ToString());
                            item.RazonSocial = dr["Razon_Social"].ToString();
                            item.IdRequerimiento = int.Parse(dr["Id_Requerimiento"].ToString());
                            item.Puesto = dr["Perfil"].ToString();
                        }
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }

        public PostulanteDTO Obtener(PostulanteDTO entity)
        {
            PostulanteDTO item = null;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_postulacion_req_dni"))
            {
                db.AddInParameter(cmd, "aiId_Requerimiento", DbType.Int32, entity.IdRequerimiento);
                db.AddInParameter(cmd, "avDni", DbType.String, entity.Dni);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new PostulanteDTO();
                        item.Dni = dr["Dni"].ToString();
                        item.ApellidoPaterno = dr["Apellido_Paterno"].ToString();
                        item.ApellidoMaterno = dr["Apellido_Materno"].ToString();
                        item.Nombres = dr["Nombres"].ToString();
                        item.Pretencion = int.Parse(dr["Prentencion"].ToString());
                        item.Disponibilidad = int.Parse(dr["Disponibilidad"].ToString());
                        item.Estado = dr["Estado"].ToString();
                        item.FechaPostulacion = DateTime.Parse(dr["Fecha_Postulacion"].ToString());
                    }
                }
            }
            return item;
        }

        #region "Metodos Privados"
        private int EjecutarMantenimiento(PostulanteDTO entity, int accion)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_reg_postulacion"))
            {
                db.AddInParameter(cmd, "aitype", DbType.Int16, accion);
                db.AddInParameter(cmd, "avDni", DbType.String, entity.Dni);
                db.AddInParameter(cmd, "aiId_Requerimiento", DbType.Int32, entity.IdRequerimiento);
                db.AddInParameter(cmd, "adPrentencion", DbType.Double, entity.Pretencion);
                db.AddInParameter(cmd, "aiDisponibilidad", DbType.Int32, entity.Disponibilidad);
                db.AddInParameter(cmd, "acEstado", DbType.String, entity.Estado);
                db.AddInParameter(cmd, "aFecha_Postulacion", DbType.Date, entity.FechaPostulacion == DateTime.MinValue? DateTime.Now : entity.FechaPostulacion);
                db.AddInParameter(cmd, "avObservacion", DbType.String, entity.Observacion);
                db.AddInParameter(cmd, "avUsuario_Creacion", DbType.String, entity.UsuarioCreacion);
                db.AddInParameter(cmd, "avUsuario_Modificacion", DbType.String, entity.UsuarioModificacion);
                db.ExecuteNonQuery(cmd);
                return 1;
            }
        }
        #endregion
    }
}
