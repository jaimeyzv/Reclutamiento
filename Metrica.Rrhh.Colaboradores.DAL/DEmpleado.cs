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
    public class DEmpleado : IDEmpleado
    {
        #region "Propiedades"
        protected static Database db = DConexion.Instance().GetSqlDatabase();
        #endregion

        public int Actualizar(EmpleadoDTO entity)
        {
            return EjecutarMantenimiento(entity, 2);
        }

        public int ActualizarEstado(EmpleadoDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(EmpleadoDTO entity)
        {
            return EjecutarMantenimiento(entity, 3);
        }

        public int Insertar(EmpleadoDTO entity)
        {
            return EjecutarMantenimiento(entity, 1);
        }

        public List<EmpleadoDTO> Listar()
        {
            throw new NotImplementedException();
        }

        public List<EmpleadoDTO> Listar(EmpleadoDTO entity)
        {
            List<EmpleadoDTO> retval = new List<EmpleadoDTO>();
            EmpleadoDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_empleados"))
            {
                //db.AddInParameter(cmd, "adFechaIni", DbType.Date, entity.FechaCreacion);
                //db.AddInParameter(cmd, "adFechaFin", DbType.Date, entity.FechaModificacion);
                db.AddInParameter(cmd, "aiIdPuesto", DbType.Int32, entity.IdPuesto);
                db.AddInParameter(cmd, "aiIdCliente", DbType.Int32, entity.Cliente.Id);
                db.AddInParameter(cmd, "acEstado", DbType.String, entity.Estado);
                db.AddInParameter(cmd, "avFiltro", DbType.String, entity.Observacion);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new EmpleadoDTO();
                        item.Dni = dr["Dni"].ToString();
                        item.Nombres = dr["Nombres"].ToString();
                        item.ApellidoPaterno = dr["Apellido_Paterno"].ToString();
                        item.ApellidoMaterno = dr["Apellido_Materno"].ToString();
                        item.Usuario = dr["Usuario"].ToString();
                        item.Cliente = new ClienteDTO { Id = int.Parse(dr["Id_Cliente"].ToString()), RazonSocial = dr["Razon_Social"].ToString() };
                        //item.Direccion = dr["Direccion"].ToString();
                        item.TelefonoPersonal = dr["Telefono_Personal"].ToString();
                        //item.Observacion = dr["Observacion"].ToString();
                        //item.Pretencion = int.Parse(dr["Pretencion"].ToString());
                        item.TotalVacaciones = int.Parse(dr["Total_Vacaciones"].ToString());
                        item.IdPuesto = int.Parse(dr["Id_Cargo"].ToString());
                        item.Puesto = dr["Puesto"].ToString();
                        item.Pretencion = int.Parse(dr["Sueldo"].ToString()); 
                        item.Estado = dr["Estado"].ToString();
                        item.FechaIniContrato = DateTime.Parse(dr["Fecha_Ini_Contrato"].ToString());
                        if(dr["Fecha_Fin_Contrato"] != DBNull.Value)
                            item.FechaFinContrato = DateTime.Parse(dr["Fecha_Fin_Contrato"].ToString());
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }

        public EmpleadoDTO Obtener(EmpleadoDTO entity)
        {
            EmpleadoDTO retval = null;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_empleado_por_dni"))
            {
                db.AddInParameter(cmd, "avDni", DbType.String, entity.Dni);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        retval = new EmpleadoDTO();
                        retval.Dni = dr["Dni"].ToString();
                        retval.Usuario = dr["Usuario"].ToString();
                        retval.Cliente = new ClienteDTO { Id = int.Parse(dr["Id_Cliente"].ToString()) };
                        retval.Pretencion = int.Parse(dr["Sueldo"].ToString());
                        retval.FechaIngreso = DateTime.Parse(dr["Fecha_Ingreso"].ToString());
                        retval.FechaIniContrato = DateTime.Parse(dr["Fecha_Ini_Contrato"].ToString());
                        if(dr["Fecha_Fin_Contrato"] != DBNull.Value)
                            retval.FechaFinContrato = DateTime.Parse(dr["Fecha_Fin_Contrato"].ToString());
                        retval.TotalVacaciones = int.Parse(dr["Total_Vacaciones"].ToString());
                        //retval.Nombres = dr["Nombres"].ToString();
                        //retval.ApellidoPaterno = dr["Apellido_Paterno"].ToString();
                        //retval.ApellidoMaterno = dr["Apellido_Materno"].ToString();
                        //retval.Direccion = dr["Direccion"].ToString();
                        //retval.TelefonoPersonal = dr["Telefono_Personal"].ToString();
                        //retval.Observacion = dr["Observacion"].ToString();
                        retval.IdPuesto = int.Parse(dr["Id_Cargo"].ToString());
                        retval.Estado = dr["Estado"].ToString();
                        //retval.FechaNacimiento = DateTime.Parse(dr["Fecha_Nacimiento"].ToString());
                        //retval.Distrito = dr["Distrito"].ToString();
                        //retval.Provincia = dr["Provincia"].ToString();
                        //retval.Departamento = dr["Departamento"].ToString();
                        //retval.TelefonoCasa = dr["Telefono_Casa"].ToString();
                        //retval.Email = dr["Email"].ToString();
                        //retval.EstadoCivil = dr["Estado_Civil"].ToString();
                        //retval.NumeroHijos = int.Parse(dr["Numero_Hijos"].ToString());
                        //retval.GradoEstudio = dr["Grado_Estudio"].ToString();
                        //retval.Sexo = dr["Sexo"].ToString();
                        //retval.Disponibilidad = int.Parse(dr["Disponibilidad"].ToString());
                        //retval.Pretencion = int.Parse(dr["Pretencion"].ToString());
                        //retval.Cv = dr["Cv"].ToString();
                        //retval.ConocimientoTecnico = dr["Conocimientos"].ToString();
                    }
                }
            }
            return retval;
        }

        #region "Metodos Privados"
        private int EjecutarMantenimiento(EmpleadoDTO entity, int accion)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("sp_reg_empleado"))
            {
                db.AddInParameter(cmd, "aitype", DbType.Int16, accion);
                db.AddInParameter(cmd, "avDni", DbType.String, entity.Dni);
                db.AddInParameter(cmd, "avUsuario", DbType.String, entity.Usuario);
                db.AddInParameter(cmd, "aiId_Cliente", DbType.Int32, entity.Cliente == null ? 0 : entity.Cliente.Id);
                db.AddInParameter(cmd, "adSueldo", DbType.Int32, entity.Pretencion);
                db.AddInParameter(cmd, "acEstado", DbType.String, entity.Estado);
                db.AddInParameter(cmd, "aiTotal_Vacaciones", DbType.Int32, entity.TotalVacaciones);
                db.AddInParameter(cmd, "aiId_Cargo", DbType.Int32, entity.IdPuesto);
                if(entity.FechaIniContrato == DateTime.MinValue)
                    db.AddInParameter(cmd, "aFecha_Ini_Contrato", DbType.Date, null);
                else
                    db.AddInParameter(cmd, "aFecha_Ini_Contrato", DbType.Date, entity.FechaIniContrato);
                db.AddInParameter(cmd, "aFecha_Fin_Contrato", DbType.Date, entity.FechaFinContrato);
                db.AddInParameter(cmd, "avUsuario_Creacion", DbType.String, entity.UsuarioCreacion);
                db.AddInParameter(cmd, "avUsuario_Modificacion", DbType.String, entity.UsuarioModificacion);
                db.ExecuteNonQuery(cmd);
                return 1;
            }
        }
        #endregion
    }
}
