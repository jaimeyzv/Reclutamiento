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
    public class DSeguridad : IDSeguridad
    {
        #region "Propiedades"
        protected static Database db = DConexion.Instance().GetSqlDatabase();
        #endregion

        public string Actualizar(UsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public string ActualizarEstado(UsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(UsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public string Insertar(UsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDTO> Listar()
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDTO> Listar(UsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public UsuarioDTO Obtener(UsuarioDTO entity)
        {
            UsuarioDTO usuario = null;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_iniciar_sesion_v2"))
            {
                db.AddInParameter(cmd, "avUsuario", DbType.String, entity.Usuario);
                db.AddInParameter(cmd, "avPassword", DbType.String, entity.Perfil.Codigo);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        usuario = new UsuarioDTO();
                        usuario.Usuario = entity.Usuario;
                        usuario.Perfil = new PerfilDTO { Codigo = dr["Codigo_Perfil"].ToString(), Descripcion = dr["Descripcion_Perfil"].ToString() };
                        //usuario.FechaUltimaSesion = dr["Fecha_Ultima_Sesion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Fecha_Ultima_Sesion"].ToString());
                        //usuario.CambiarPassword = dr["Cambiar_Password"].Equals("1");
                        usuario.Nombres = dr["Nombres"].ToString();
                        usuario.ApellidoPaterno = dr["Apellido_Paterno"].ToString();
                        usuario.ApellidoMaterno = dr["Apellido_Materno"].ToString();
                        usuario.Dni = dr["Dni"].ToString();
                        usuario.Direccion = dr["Direccion"].ToString();
                        usuario.Email = dr["EmailPersonal"].ToString();
                        usuario.EstadoCivil = dr["Estado_Civil"].ToString();
                        usuario.GradoEstudio = dr["Grado_Estudio"].ToString();
                        usuario.NumeroHijos = int.Parse(dr["Numero_Hijos"].ToString());
                        usuario.TelefonoCasa = dr["Telefono_Casa"].ToString();
                        usuario.TelefonoPersonal = dr["Telefono_Personal"].ToString();
                        usuario.Cargo = dr["Cargo"].ToString();
                        usuario.Estado = dr["Estado"].ToString();
                        usuario.FechaIngreso = DateTime.Parse(dr["Fecha_Ingreso"].ToString());
                        usuario.Sueldo = double.Parse(dr["Sueldo"].ToString());
                        usuario.TotalVacaciones = int.Parse(dr["Total_Vacaciones"].ToString());
                        usuario.FechaFinContrato = dr["Fecha_Fin_Contrato"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Fecha_Fin_Contrato"].ToString());
                        usuario.Cliente = new ClienteDTO {Ruc= dr["Ruc"].ToString(), RazonSocial= dr["Razon_Social"].ToString() };
                    }
                }
            }
            return usuario;
        }

        public List<PaginaDTO> ObtenerAcceso(string sPerfil)
        {
            List<PaginaDTO> retval = new List<PaginaDTO>();
            PaginaDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_pagina_por_perfil"))
            {
                db.AddInParameter(cmd, "acPerfil", DbType.String, sPerfil);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new PaginaDTO();
                        item.IdPagina = int.Parse(dr["Id_Pagina"].ToString());
                        item.IdPaginaPadre = dr["Id_Pagina_Padre"] == DBNull.Value? 0: int.Parse(dr["Id_Pagina_Padre"].ToString());
                        item.Titulo = dr["Titulo"].ToString();
                        item.Descripcion = dr["Descripcion"].ToString();
                        item.Controlador = dr["Controlador"].ToString();
                        item.Accion = dr["Accion"].ToString();
                        item.Icono = dr["icono"].ToString();
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }
    }
}
