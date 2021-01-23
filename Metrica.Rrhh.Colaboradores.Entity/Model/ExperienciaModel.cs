using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.Model
{
    public class ExperienciaModel : BaseModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Cargo { get; set; }
        //public string Dni { get; set; }
        public string Empresa { get; set; }
        [DisplayFormat(DataFormatString ="yyyy-MM-dd")]
        public DateTime FechaInicio { get; set; }
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime? FechaFin { get; set; }
        public string Detalle { get; set; }
    }
}
