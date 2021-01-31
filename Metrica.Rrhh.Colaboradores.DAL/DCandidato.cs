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
    public class DCandidato : IDCandidato
    {
        #region "Propiedades"
        protected static Database db = DConexion.Instance().GetSqlDatabase();
        #endregion

        #region "Experiencia"
        public int RegistarExperiencias(ExperienciaDTO entity, string dni, string usuario)
        {
            return EjecutarMantenimientoExperiencia(entity, dni, usuario);
        }

        public List<ExperienciaDTO> ListarExperiencias(string dni)
        {
            List<ExperienciaDTO> retval = new List<ExperienciaDTO>();
            ExperienciaDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_experiencia_candidato_por_dni"))
            {
                db.AddInParameter(cmd, "avDni", DbType.String, dni);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new ExperienciaDTO();
                        item.Id = int.Parse(dr["Id_Experiencia"].ToString());
                        //item.Dni = dr["Dni"].ToString();
                        item.Cargo = dr["Titulo"].ToString();
                        item.Tipo = dr["Tipo"].ToString();
                        item.Empresa = dr["Empresa"].ToString();
                        item.Detalle = dr["Descripcion"].ToString();
                        item.FechaInicio = DateTime.Parse(dr["Fecha_Inicio"].ToString());
                        if (dr["Fecha_Fin"] != DBNull.Value)
                            item.FechaFin = DateTime.Parse(dr["Fecha_Fin"].ToString());
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }
        #endregion

        public int Actualizar(CandidatoDTO entity)
        {
            return EjecutarMantenimiento(entity, 2);
        }

        public int ActualizarEstado(CandidatoDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(CandidatoDTO entity)
        {
            return EjecutarMantenimiento(entity, 3);
        }

        public int Insertar(CandidatoDTO entity)
        {
            return EjecutarMantenimiento(entity, 1);
        }

        public List<CandidatoDTO> Listar()
        {
            throw new NotImplementedException();
        }

        public List<CandidatoDTO> Listar(CandidatoDTO entity)
        {
            List<CandidatoDTO> retval = new List<CandidatoDTO>();
            CandidatoDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_candidatos"))
            {
                db.AddInParameter(cmd, "adFechaIni", DbType.Date, entity.FechaCreacion);
                db.AddInParameter(cmd, "adFechaFin", DbType.Date, entity.FechaModificacion);
                db.AddInParameter(cmd, "aiIdPuesto", DbType.Int32, entity.IdPuesto);
                db.AddInParameter(cmd, "acEstado", DbType.String, entity.Estado);
                db.AddInParameter(cmd, "avFiltro", DbType.String, entity.Observacion);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new CandidatoDTO();
                        item.Dni = dr["Dni"].ToString();
                        item.Nombres = dr["Nombres"].ToString();
                        item.ApellidoPaterno = dr["Apellido_Paterno"].ToString();
                        item.ApellidoMaterno = dr["Apellido_Materno"].ToString();
                        item.Direccion = dr["Direccion"].ToString();
                        item.TelefonoPersonal = dr["Telefono_Personal"].ToString();
                        item.Observacion = dr["Observacion"].ToString();
                        item.Pretencion = int.Parse(dr["Pretencion"].ToString());
                        item.IdPuesto = int.Parse(dr["IdPuesto"].ToString());
                        item.Puesto = dr["Puesto"].ToString();
                        item.Estado = dr["Estado"].ToString();
                        item.Email = dr["Email"].ToString();
                        item.FechaCreacion = DateTime.Parse(dr["Fecha_Creacion"].ToString());
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }

        public CandidatoDTO Obtener(CandidatoDTO entity)
        {
            CandidatoDTO retval = null;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_candidato_por_dni"))
            {
                db.AddInParameter(cmd, "avDni", DbType.String, entity.Dni);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        retval = new CandidatoDTO();
                        retval.Dni = dr["Dni"].ToString();
                        retval.Nombres = dr["Nombres"].ToString();
                        retval.ApellidoPaterno = dr["Apellido_Paterno"].ToString();
                        retval.ApellidoMaterno = dr["Apellido_Materno"].ToString();
                        retval.Direccion = dr["Direccion"].ToString();
                        retval.TelefonoPersonal = dr["Telefono_Personal"].ToString();
                        retval.Observacion = dr["Observacion"].ToString();
                        retval.IdPuesto = int.Parse(dr["IdPuesto"].ToString());
                        //retval.Puesto = dr["Puesto"].ToString();
                        retval.Estado = dr["Estado"].ToString();
                        retval.FechaNacimiento = DateTime.Parse(dr["Fecha_Nacimiento"].ToString());
                        retval.Distrito = dr["Distrito"].ToString();
                        retval.Provincia = dr["Provincia"].ToString();
                        retval.Departamento = dr["Departamento"].ToString();
                        retval.TelefonoCasa = dr["Telefono_Casa"].ToString();
                        retval.Email = dr["Email"].ToString();
                        retval.EstadoCivil = dr["Estado_Civil"].ToString();
                        retval.NumeroHijos = int.Parse(dr["Numero_Hijos"].ToString());
                        retval.GradoEstudio = dr["Grado_Estudio"].ToString();
                        retval.Sexo = dr["Sexo"].ToString();
                        retval.Disponibilidad = int.Parse(dr["Disponibilidad"].ToString());
                        retval.Pretencion = int.Parse(dr["Pretencion"].ToString());
                        retval.Cv = dr["Cv"].ToString();
                        retval.ConocimientoTecnico = dr["Conocimientos"].ToString();
                    }
                }
            }
            return retval;
        }

        #region "Metodos Privados"
        private int EjecutarMantenimiento(CandidatoDTO entity, int accion)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_reg_candidato"))
            {
                db.AddInParameter(cmd, "aitype", DbType.Int16, accion);
                db.AddInParameter(cmd, "avDni", DbType.String, entity.Dni);
                db.AddInParameter(cmd, "avNombres", DbType.String, entity.Nombres);
                db.AddInParameter(cmd, "avApellido_Paterno", DbType.String, entity.ApellidoPaterno);
                db.AddInParameter(cmd, "avApellido_Materno", DbType.String, entity.ApellidoMaterno);
                db.AddInParameter(cmd, "avDireccion", DbType.String, entity.Direccion);
                db.AddInParameter(cmd, "avDistrito", DbType.String, entity.Distrito);
                db.AddInParameter(cmd, "avProvincia", DbType.String, entity.Provincia);
                db.AddInParameter(cmd, "avDepartamento", DbType.String, entity.Departamento);
                db.AddInParameter(cmd, "avTelefono_Personal", DbType.String, entity.TelefonoPersonal);
                db.AddInParameter(cmd, "avTelefono_Casa", DbType.String, entity.TelefonoCasa);
                db.AddInParameter(cmd, "avEmail", DbType.String, entity.Email);
                db.AddInParameter(cmd, "acEstado_Civil", DbType.String, entity.EstadoCivil);
                db.AddInParameter(cmd, "aiNumero_Hijos", DbType.Int32, entity.NumeroHijos);
                db.AddInParameter(cmd, "avGrado_Estudio", DbType.String, entity.GradoEstudio);
                db.AddInParameter(cmd, "avObservacion", DbType.String, entity.Observacion);
                db.AddInParameter(cmd, "avUsuario_Creacion", DbType.String, entity.UsuarioCreacion);
                db.AddInParameter(cmd, "avUsuario_Modificacion", DbType.String, entity.UsuarioModificacion);
                db.AddInParameter(cmd, "acEstado", DbType.String, entity.Estado);
                db.AddInParameter(cmd, "acSexo", DbType.String, entity.Sexo);
                db.AddInParameter(cmd, "aiDisponibilidad", DbType.Int32, entity.Disponibilidad);
                db.AddInParameter(cmd, "adPretencion", DbType.Int32, entity.Pretencion);
                db.AddInParameter(cmd, "avCv", DbType.String, entity.Cv);
                db.AddInParameter(cmd, "aiIdPuesto", DbType.Int32, entity.IdPuesto);
                if(entity.FechaNacimiento == DateTime.MinValue)
                    db.AddInParameter(cmd, "adFecha_Nacimiento", DbType.Date, null);
                else
                    db.AddInParameter(cmd, "adFecha_Nacimiento", DbType.Date, entity.FechaNacimiento);
                db.AddInParameter(cmd, "avConocimientos", DbType.String, entity.ConocimientoTecnico);
                db.ExecuteNonQuery(cmd);
                return 1;
            }
        }

        private int EjecutarMantenimientoExperiencia(ExperienciaDTO entity, string dni, string usuario)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_reg_experiencia_candidato"))
            {
                db.AddInParameter(cmd, "aitype", DbType.Int16, entity.Accion);
                db.AddInParameter(cmd, "aiId_Experiencia", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "avDni", DbType.String, dni);
                db.AddInParameter(cmd, "avTitulo", DbType.String, entity.Cargo);
                db.AddInParameter(cmd, "avEmpresa", DbType.String, entity.Empresa);
                db.AddInParameter(cmd, "avDescripcion", DbType.String, entity.Detalle);
                db.AddInParameter(cmd, "aFecha_Inicio", DbType.Date, entity.FechaInicio);
                db.AddInParameter(cmd, "aFecha_Fin", DbType.Date, entity.FechaFin);
                db.AddInParameter(cmd, "acTipo", DbType.String, entity.Tipo);
                db.AddInParameter(cmd, "avUsuario_Creacion", DbType.String, usuario);
                db.AddInParameter(cmd, "avUsuario_Modificacion", DbType.String, usuario);

                if (entity.Accion == 1)
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
