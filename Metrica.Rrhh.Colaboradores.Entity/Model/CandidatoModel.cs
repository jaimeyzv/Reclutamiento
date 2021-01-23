using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.Model
{
    public class CandidatoModel : BaseModel
    {
        [Required]
        [Display(Name = "CV")]
        public string Cv { get; set; }
        [Required]
        [MaxLength(15)]
        public string Dni { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Sexo { get; set; }
        public int Disponibilidad { get; set; }
        public string Estado { get; set; }
        [Required]
        [Display(Name = "Pretención")]
        public int Pretencion { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno{ get; set; }
        [Required]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public int IdPuesto { get; set; }
        public string Puesto { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string ConocimientoTecnico { get; set; }
        [Display(Name = "Teléfono Personal")]
        [Required]
        public string TelefonoPersonal { get; set; }
        [Display(Name = "Teléfono Casa")]
        public string TelefonoCasa { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }
        [Display(Name = "Número Hijos")]
        public int NumeroHijos { get; set; }
        public string GradoEstudio { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }
        public List<ExperienciaModel> Experiencias { get; set; }
        public List<ExperienciaModel> Estudios { get; set; }
        public string NombresCompleto { get { return Nombres + " " + ApellidoPaterno + " " + ApellidoMaterno; } }
    }
}
