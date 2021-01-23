using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.DTO
{
    [KnownType(typeof(EmpleadoDTO))]
    public class CandidatoDTO : BaseDTO
    {
        public string Cv { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public int Disponibilidad { get; set; }
        public string Estado { get; set; }
        public int Pretencion { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdPuesto { get; set; }
        public string Puesto { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string ConocimientoTecnico { get; set; }
        public string TelefonoPersonal { get; set; }
        public string TelefonoCasa { get; set; }
        public string Email { get; set; }
        public string EstadoCivil { get; set; }
        public int NumeroHijos { get; set; }
        public string GradoEstudio { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Observacion { get; set; }
        public List<ExperienciaDTO> Experiencias { get; set; }
        public List<ExperienciaDTO> Estudios { get; set; }
    }
}
