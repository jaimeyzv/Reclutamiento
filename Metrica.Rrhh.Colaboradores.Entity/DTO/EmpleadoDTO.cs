using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.DTO
{
    public class EmpleadoDTO : CandidatoDTO
    {
        public string Usuario { get; set; }
        public ClienteDTO Cliente { get; set; }
        //public string Estado { get; set; }
        public double Sueldo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int TotalVacaciones { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaIniContrato { get; set; }
        public DateTime? FechaFinContrato { get; set; }
        public void Candidato(CandidatoDTO eBase)
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
        }
    }
}
