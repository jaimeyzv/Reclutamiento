using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.Model
{
    public class PuestoModel: BaseModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Conocimientos Técnicos")]
        [DataType(DataType.MultilineText)]
        public string ConocimientoTecnico { get; set; }
    }
}
