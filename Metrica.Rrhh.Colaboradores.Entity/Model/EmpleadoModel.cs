using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.Model
{
    public class EmpleadoModel : CandidatoModel
    {
        [Display(Name = "Usuario/Usuario Correo")]
        public string Usuario { get; set; }
        public ClienteModel Cliente { get; set; }
        //public string Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int TotalVacaciones { get; set; }
        [Required]
        [Display(Name ="Inicio Contrato")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaIniContrato { get; set; }
        [Display(Name = "Fin Contrato")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FechaFinContrato { get; set; }
        public void Candidato(CandidatoModel eBase)
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
