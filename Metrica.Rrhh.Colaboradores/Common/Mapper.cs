using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metrica.Rrhh.Colaboradores.Common
{
    public static class Mapper
    {
        #region "Model"
        public static List<RequerimientoModel> AsModel(this List<RequerimientoDTO> dto)
        {
            List<RequerimientoModel> retval = new List<RequerimientoModel>();
            dto.ForEach(x => retval.Add(x.AsModel()));
            return retval;
        }

        public static RequerimientoModel AsModel(this RequerimientoDTO dto)
        {
            return new RequerimientoModel
            {
                Id = dto.Id,
                Accion = dto.Accion,
                Cliente = dto.Cliente != null?dto.Cliente.AsModel(): null,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado,
                FechaCreacion = dto.FechaCreacion,
                FechaModificacion = dto.FechaModificacion,
                FechaTentativa = dto.FechaTentativa,
                OrdenCompra = dto.OrdenCompra,
                Perfil = dto.Perfil,
                Postulaciones = dto.Postulaciones != null? dto.Postulaciones.AsModel() : null,
                RangoSalario = dto.RangoSalario,
                UsuarioCreacion = dto.UsuarioCreacion,
                UsuarioModificacion = dto.UsuarioModificacion
            };
        }

        public static ClienteModel AsModel(this ClienteDTO dto)
        {
            return new ClienteModel
            {
                Id = dto.Id,
                Accion = dto.Accion,
                Contacto = dto.Contacto,
                Direccion = dto.Direccion,
                EmailContacto = dto.EmailContacto,
                FechaCreacion = dto.FechaCreacion,
                FechaModificacion = dto.FechaModificacion,
                RazonSocial = dto.RazonSocial,
                Ruc = dto.Ruc,
                Telefono = dto.Telefono,
                TelefonoContacto = dto.TelefonoContacto,
                UsuarioCreacion = dto.UsuarioCreacion,
                UsuarioModificacion = dto.UsuarioModificacion
            };
        }

        public static List<ClienteModel> AsModel(this List<ClienteDTO> dto)
        {
            List<ClienteModel> retval = new List<ClienteModel>();
            dto.ForEach(x => retval.Add(x.AsModel()));
            return retval;
        }

        public static PerfilModel AsModel(this PerfilDTO dto)
        {
            return new PerfilModel
            {
                Codigo = dto.Codigo,
                Descripcion = dto.Descripcion
            };
        }

        public static PostulanteModel AsModel(this PostulanteDTO dto)
        {
            return new PostulanteModel
            {
                Accion = dto.Accion,
                ApellidoMaterno = dto.ApellidoMaterno,
                ApellidoPaterno = dto.ApellidoPaterno,
                Cv = dto.Cv,
                Departamento = dto.Departamento,
                Direccion = dto.Direccion,
                Disponibilidad = dto.Disponibilidad,
                Distrito = dto.Distrito,
                Dni = dto.Dni,
                Email = dto.Email,
                IdCliente = dto.IdCliente,
                RazonSocial = dto.RazonSocial,
                Estado = dto.Estado,
                EstadoCivil = dto.EstadoCivil,
                FechaCreacion = dto.FechaCreacion,
                FechaFinContrato = dto.FechaFinContrato,
                FechaIniContrato = dto.FechaIniContrato,
                FechaModificacion = dto.FechaModificacion,
                FechaNacimiento = dto.FechaNacimiento,
                FechaPostulacion = dto.FechaPostulacion,
                GradoEstudio = dto.GradoEstudio,
                IdPuesto = dto.IdPuesto,
                IdRequerimiento = dto.IdRequerimiento,
                Nombres = dto.Nombres,
                NumeroHijos = dto.NumeroHijos,
                Observacion = dto.Observacion,
                Pretencion = dto.Pretencion,
                Provincia = dto.Provincia,
                Puesto = dto.Puesto,
                Sexo = dto.Sexo,
                TelefonoCasa = dto.TelefonoCasa,
                TelefonoPersonal = dto.TelefonoPersonal,
                UsuarioCreacion = dto.UsuarioCreacion,
                UsuarioModificacion = dto.UsuarioModificacion
            };
        }

        public static List<PostulanteModel> AsModel(this List<PostulanteDTO> dto)
        {
            List<PostulanteModel> retval = new List<PostulanteModel>();
            dto.ForEach(x => retval.Add(x.AsModel()));
            return retval;
        }

        public static List<PuestoModel> AsModel(this List<PuestoDTO> dto)
        {
            List<PuestoModel> retval = new List<PuestoModel>();
            dto.ForEach(x => retval.Add(x.AsModel()));
            return retval;
        }

        public static PuestoModel AsModel(this PuestoDTO dto)
        {
            return new PuestoModel
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Accion = dto.Accion,
                UsuarioCreacion = dto.UsuarioCreacion,
                FechaCreacion = dto.FechaCreacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                FechaModificacion = dto.FechaModificacion
            };
        }

        public static List<ItemModel> AsModel(this List<ItemDTO> dto)
        {
            List<ItemModel> retval = new List<ItemModel>();
            dto.ForEach(x => retval.Add(x.AsModel()));
            return retval;
        }

        public static ItemModel AsModel(this ItemDTO dto)
        {
            return new ItemModel
            {
             Codigo = dto.Codigo,
             Valor = dto.Valor
            };
        }

        public static CandidatoModel AsModel(this CandidatoDTO dto)
        {
            return new CandidatoModel
            {
                Cv = dto.Cv,
                Dni = dto.Dni,
                Nombres = dto.Nombres,
                Sexo = dto.Sexo,
                Disponibilidad = dto.Disponibilidad,
                Estado = dto.Estado,
                Pretencion = dto.Pretencion,
                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno = dto.ApellidoMaterno,
                IdPuesto = dto.IdPuesto,
                Puesto = dto.Puesto,
                Direccion = dto.Direccion,
                Distrito = dto.Distrito,
                Provincia = dto.Provincia,
                Departamento = dto.Departamento,
                ConocimientoTecnico = dto.ConocimientoTecnico,
                TelefonoPersonal = dto.TelefonoPersonal,
                TelefonoCasa = dto.TelefonoCasa,
                Email = dto.Email,
                EstadoCivil = dto.EstadoCivil,
                NumeroHijos = dto.NumeroHijos,
                GradoEstudio = dto.GradoEstudio,
                FechaNacimiento = dto.FechaNacimiento,
                Observacion = dto.Observacion,
                Experiencias = dto.Experiencias != null ? dto.Experiencias.AsModel() : null,
                Estudios = dto.Estudios != null ? dto.Estudios.AsModel() : null,
                UsuarioCreacion = dto.UsuarioCreacion,
                FechaCreacion = dto.FechaCreacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                FechaModificacion = dto.FechaModificacion
            };
        }

        public static ExperienciaModel AsModel(this ExperienciaDTO dto)
        {
            return new ExperienciaModel
            {
                Accion = dto.Accion,
                Cargo = dto.Cargo,
                Detalle = dto.Detalle,
                Empresa = dto.Empresa,
                FechaFin = dto.FechaFin,
                FechaInicio = dto.FechaInicio,
                Id = dto.Id,
                Tipo = dto.Tipo,
                UsuarioCreacion = dto.UsuarioCreacion,
                FechaCreacion = dto.FechaCreacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                FechaModificacion = dto.FechaModificacion
            };
        }

        public static List<ExperienciaModel> AsModel(this List<ExperienciaDTO> dto)
        {
            List<ExperienciaModel> retval = new List<ExperienciaModel>();
            dto.ForEach(x => retval.Add(x.AsModel()));
            return retval;
        }

        public static List<CandidatoModel> AsModel(this List<CandidatoDTO> dto)
        {
            List<CandidatoModel> retval = new List<CandidatoModel>();
            dto.ForEach(x => retval.Add(x.AsModel()));
            return retval;
        }

        public static EmpleadoModel AsModel(this EmpleadoDTO dto)
        {
            return new EmpleadoModel
            {
                Cv = dto.Cv,
                Dni = dto.Dni,
                Nombres = dto.Nombres,
                Sexo = dto.Sexo,
                Disponibilidad = dto.Disponibilidad,
                Estado = dto.Estado,
                Pretencion = dto.Pretencion,
                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno = dto.ApellidoMaterno,
                IdPuesto = dto.IdPuesto,
                Puesto = dto.Puesto,
                Direccion = dto.Direccion,
                Distrito = dto.Distrito,
                Provincia = dto.Provincia,
                Departamento = dto.Departamento,
                ConocimientoTecnico = dto.ConocimientoTecnico,
                TelefonoPersonal = dto.TelefonoPersonal,
                TelefonoCasa = dto.TelefonoCasa,
                Email = dto.Email,
                EstadoCivil = dto.EstadoCivil,
                NumeroHijos = dto.NumeroHijos,
                GradoEstudio = dto.GradoEstudio,
                FechaNacimiento = dto.FechaNacimiento,
                Observacion = dto.Observacion,
                Experiencias = dto.Experiencias != null ? dto.Experiencias.AsModel() : null,
                Estudios = dto.Estudios != null ? dto.Estudios.AsModel() : null,
                UsuarioCreacion = dto.UsuarioCreacion,
                FechaCreacion = dto.FechaCreacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                FechaModificacion = dto.FechaModificacion,
                Usuario = dto.Usuario,
                Cliente = dto.Cliente.AsModel(),
                FechaIngreso = dto.FechaIngreso,
                FechaSalida = dto.FechaSalida,
                TotalVacaciones = dto.TotalVacaciones,
                FechaIniContrato = dto.FechaIniContrato,
                FechaFinContrato = dto.FechaFinContrato
            };
        }

        public static List<EmpleadoModel> AsModel(this List<EmpleadoDTO> dto)
        {
            List<EmpleadoModel> retval = new List<EmpleadoModel>();
            dto.ForEach(x => retval.Add(x.AsModel()));
            return retval;
        }
        #endregion

        #region "DTO"
        public static List<RequerimientoDTO> AsDTO(this List<RequerimientoModel> model)
        {
            List<RequerimientoDTO> retval = new List<RequerimientoDTO>();
            model.ForEach(x => retval.Add(x.AsDTO()));
            return retval;
        }

        public static RequerimientoDTO AsDTO(this RequerimientoModel model)
        {
            return new RequerimientoDTO
            {
                Id = model.Id,
                Accion = model.Accion,
                Cliente = model.Cliente != null? model.Cliente.AsDTO(): null,
                Descripcion = model.Descripcion,
                Estado = model.Estado,
                FechaCreacion = model.FechaCreacion,
                FechaModificacion = model.FechaModificacion,
                FechaTentativa = model.FechaTentativa,
                OrdenCompra = model.OrdenCompra,
                Perfil = model.Perfil,
                Postulaciones = model.Postulaciones != null? model.Postulaciones.AsDTO()  : null,
                RangoSalario = model.RangoSalario,
                UsuarioCreacion = model.UsuarioCreacion,
                UsuarioModificacion = model.UsuarioModificacion
            };
        }

        public static ClienteDTO AsDTO(this ClienteModel model)
        {
            return new ClienteDTO
            {
                Id = model.Id,
                Accion = model.Accion,
                Contacto = model.Contacto,
                Direccion = model.Direccion,
                EmailContacto = model.EmailContacto,
                FechaCreacion = model.FechaCreacion,
                FechaModificacion = model.FechaModificacion,
                RazonSocial = model.RazonSocial,
                Ruc = model.Ruc,
                Telefono = model.Telefono,
                TelefonoContacto = model.TelefonoContacto,
                UsuarioCreacion = model.UsuarioCreacion,
                UsuarioModificacion = model.UsuarioModificacion
            };
        }

        public static List<ClienteDTO> AsDTO(this List<ClienteModel> model)
        {
            List<ClienteDTO> retval = new List<ClienteDTO>();
            model.ForEach(x => retval.Add(x.AsDTO()));
            return retval;
        }

        public static PerfilDTO AsDTO(this PerfilModel model)
        {
            return new PerfilDTO
            {
                Codigo = model.Codigo,
                Descripcion = model.Descripcion
            };
        }

        public static PostulanteDTO AsDTO(this PostulanteModel model)
        {
            return new PostulanteDTO
            {
                Accion = model.Accion,
                ApellidoMaterno = model.ApellidoMaterno,
                ApellidoPaterno = model.ApellidoPaterno,
                Cv = model.Cv,
                Departamento = model.Departamento,
                Direccion = model.Direccion,
                Disponibilidad = model.Disponibilidad,
                Distrito = model.Distrito,
                Dni = model.Dni,
                IdCliente = model.IdCliente,
                RazonSocial = model.RazonSocial,
                Email = model.Email,
                Estado = model.Estado,
                EstadoCivil = model.EstadoCivil,
                FechaCreacion = model.FechaCreacion,
                FechaFinContrato = model.FechaFinContrato,
                FechaIniContrato = model.FechaIniContrato,
                FechaModificacion = model.FechaModificacion,
                FechaNacimiento = model.FechaNacimiento,
                FechaPostulacion = model.FechaPostulacion,
                GradoEstudio = model.GradoEstudio,
                IdPuesto = model.IdPuesto,
                IdRequerimiento = model.IdRequerimiento,
                Nombres = model.Nombres,
                NumeroHijos = model.NumeroHijos,
                Observacion = model.Observacion,
                Pretencion = model.Pretencion,
                Provincia = model.Provincia,
                Puesto = model.Puesto,
                Sexo = model.Sexo,
                TelefonoCasa = model.TelefonoCasa,
                TelefonoPersonal = model.TelefonoPersonal,
                UsuarioCreacion = model.UsuarioCreacion,
                UsuarioModificacion = model.UsuarioModificacion
            };
        }

        public static List<PostulanteDTO> AsDTO(this List<PostulanteModel> model)
        {
            List<PostulanteDTO> retval = new List<PostulanteDTO>();
            model.ForEach(x => retval.Add(x.AsDTO()));
            return retval;
        }

        public static PuestoDTO AsDTO(this PuestoModel model)
        {
            return new PuestoDTO
            {
                Id = model.Id,
                Accion = model.Accion,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                UsuarioCreacion = model.UsuarioCreacion,
                FechaCreacion = model.FechaCreacion,
                UsuarioModificacion = model.UsuarioModificacion,
                FechaModificacion = model.FechaModificacion
            };
        }

        public static List<PuestoDTO> AsDTO(this List<PuestoModel> model)
        {
            List<PuestoDTO> retval = new List<PuestoDTO>();
            model.ForEach(x => retval.Add(x.AsDTO()));
            return retval;
        }

        public static List<ItemDTO> AsDTO(this List<ItemModel> model)
        {
            List<ItemDTO> retval = new List<ItemDTO>();
            model.ForEach(x => retval.Add(x.AsDTO()));
            return retval;
        }

        public static ItemDTO AsDTO(this ItemModel model)
        {
            return new ItemDTO
            {
                Codigo = model.Codigo,
                Valor = model.Valor
            };
        }

        public static CandidatoDTO AsDTO(this CandidatoModel model)
        {
            return new CandidatoDTO
            {
                Cv = model.Cv,
                Dni = model.Dni,
                Nombres = model.Nombres,
                Sexo = model.Sexo,
                Disponibilidad = model.Disponibilidad,
                Estado = model.Estado,
                Pretencion = model.Pretencion,
                ApellidoPaterno = model.ApellidoPaterno,
                ApellidoMaterno = model.ApellidoMaterno,
                IdPuesto = model.IdPuesto,
                Puesto = model.Puesto,
                Direccion = model.Direccion,
                Distrito = model.Distrito,
                Provincia = model.Provincia,
                Departamento = model.Departamento,
                ConocimientoTecnico = model.ConocimientoTecnico,
                TelefonoPersonal = model.TelefonoPersonal,
                TelefonoCasa = model.TelefonoCasa,
                Email = model.Email,
                EstadoCivil = model.EstadoCivil,
                NumeroHijos = model.NumeroHijos,
                GradoEstudio = model.GradoEstudio,
                FechaNacimiento = model.FechaNacimiento,
                Observacion = model.Observacion,
                Experiencias = model.Experiencias != null ? model.Experiencias.AsDTO() : null,
                Estudios = model.Estudios != null ? model.Estudios.AsDTO() : null,
                UsuarioCreacion = model.UsuarioCreacion,
                FechaCreacion = model.FechaCreacion,
                UsuarioModificacion = model.UsuarioModificacion,
                FechaModificacion = model.FechaModificacion
            };
        }

        public static ExperienciaDTO AsDTO(this ExperienciaModel model)
        {
            return new ExperienciaDTO
            {
                Accion = model.Accion,
                Cargo = model.Cargo,
                Detalle = model.Detalle,
                Empresa = model.Empresa,
                FechaFin = model.FechaFin,
                FechaInicio = model.FechaInicio,
                Id = model.Id,
                Tipo = model.Tipo,
                UsuarioCreacion = model.UsuarioCreacion,
                FechaCreacion = model.FechaCreacion,
                UsuarioModificacion = model.UsuarioModificacion,
                FechaModificacion = model.FechaModificacion
            };
        }

        public static List<ExperienciaDTO> AsDTO(this List<ExperienciaModel> model)
        {
            List<ExperienciaDTO> retval = new List<ExperienciaDTO>();
            model.ForEach(x => retval.Add(x.AsDTO()));
            return retval;
        }

        public static List<CandidatoDTO> AsDTO(this List<CandidatoModel> model)
        {
            List<CandidatoDTO> retval = new List<CandidatoDTO>();
            model.ForEach(x => retval.Add(x.AsDTO()));
            return retval;
        }

        public static EmpleadoDTO AsDTO(this EmpleadoModel model)
        {
            return new EmpleadoDTO
            {
                Cv = model.Cv,
                Dni = model.Dni,
                Nombres = model.Nombres,
                Sexo = model.Sexo,
                Disponibilidad = model.Disponibilidad,
                Estado = model.Estado,
                Pretencion = model.Pretencion,
                ApellidoPaterno = model.ApellidoPaterno,
                ApellidoMaterno = model.ApellidoMaterno,
                IdPuesto = model.IdPuesto,
                Puesto = model.Puesto,
                Direccion = model.Direccion,
                Distrito = model.Distrito,
                Provincia = model.Provincia,
                Departamento = model.Departamento,
                ConocimientoTecnico = model.ConocimientoTecnico,
                TelefonoPersonal = model.TelefonoPersonal,
                TelefonoCasa = model.TelefonoCasa,
                Email = model.Email,
                EstadoCivil = model.EstadoCivil,
                NumeroHijos = model.NumeroHijos,
                GradoEstudio = model.GradoEstudio,
                FechaNacimiento = model.FechaNacimiento,
                Observacion = model.Observacion,
                Experiencias = model.Experiencias != null ? model.Experiencias.AsDTO() : null,
                Estudios = model.Estudios != null ? model.Estudios.AsDTO() : null,
                UsuarioCreacion = model.UsuarioCreacion,
                FechaCreacion = model.FechaCreacion,
                UsuarioModificacion = model.UsuarioModificacion,
                FechaModificacion = model.FechaModificacion,
                Usuario = model.Usuario,
                Cliente = model.Cliente.AsDTO(),
                FechaIngreso = model.FechaIngreso,
                FechaSalida = model.FechaSalida,
                TotalVacaciones = model.TotalVacaciones,
                FechaIniContrato = model.FechaIniContrato,
                FechaFinContrato = model.FechaFinContrato,
            };
        }

        public static List<EmpleadoDTO> AsDTO(this List<EmpleadoModel> model)
        {
            List<EmpleadoDTO> retval = new List<EmpleadoDTO>();
            model.ForEach(x => retval.Add(x.AsDTO()));
            return retval;
        }
        #endregion

    }
}