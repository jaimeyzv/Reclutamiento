using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metrica.Rrhh.Colaboradores.Models
{
    public class CandidatoViewModel : EmpleadoModel
    {
        public List<PuestoModel> Puestos { get; set; }
        public List<ItemModel> EstadosCiviles { get; set; }
        public List<ItemModel> Sexos { get; set; }
        public List<ItemModel> Distritos { get; set; }
        public List<ItemModel> Skill { get; set; }
        public List<ClienteModel> Clientes { get; set; }
        public HttpPostedFileBase Adjunto { get; set; }
        public bool EsEmpleado { get; set; }
        public int IdCliente { get; set; }

        public CandidatoViewModel()
        {

        }
        public CandidatoViewModel(CandidatoModel eBase)
        {
            ActualizarDatosCandidato(eBase);
        }

        public CandidatoViewModel(EmpleadoModel eBase)
        {
            ActualizarDatosEmpleado(eBase);

        }

        #region "Metodos Privados"
        private void ActualizarDatosEmpleado(EmpleadoModel eBase)
        {
            ActualizarDatosCandidato(eBase);
            Usuario = eBase.Usuario;
            Cliente = eBase.Cliente;
            Pretencion = eBase.Pretencion;
            FechaIngreso = eBase.FechaIngreso;
            FechaSalida = eBase.FechaSalida;
            TotalVacaciones = eBase.TotalVacaciones;
            FechaIniContrato = eBase.FechaIniContrato;
            FechaFinContrato = eBase.FechaFinContrato;
            EsEmpleado = true;
    }
        private void ActualizarDatosCandidato(CandidatoModel eBase)
        {
            Cv = eBase.Cv;
            Dni = eBase.Dni;
            Nombres = eBase.Nombres;
            Sexo = eBase.Sexo;
            Disponibilidad = eBase.Disponibilidad;
            Estado = eBase.Estado;
            Pretencion = eBase.Pretencion;
            ApellidoPaterno = eBase.ApellidoPaterno;
            ApellidoMaterno = eBase.ApellidoMaterno;
            IdPuesto = eBase.IdPuesto;
            Puesto = eBase.Puesto;
            Direccion = eBase.Direccion;
            Distrito = eBase.Distrito;
            Provincia = eBase.Provincia;
            Departamento = eBase.Departamento;
            ConocimientoTecnico = eBase.ConocimientoTecnico;
            TelefonoPersonal = eBase.TelefonoPersonal;
            TelefonoCasa = eBase.TelefonoCasa;
            Email = eBase.Email;
            EstadoCivil = eBase.EstadoCivil;
            NumeroHijos = eBase.NumeroHijos;
            GradoEstudio = eBase.GradoEstudio;
            FechaNacimiento = eBase.FechaNacimiento;
            Observacion = eBase.Observacion;
            Experiencias = eBase.Experiencias;
            Estudios = eBase.Estudios;
            UsuarioCreacion = eBase.UsuarioCreacion;
            FechaCreacion = eBase.FechaCreacion;
            UsuarioModificacion = eBase.UsuarioModificacion;
            FechaModificacion = eBase.FechaModificacion;
            EsEmpleado = false;
        }
        #endregion
    }
}