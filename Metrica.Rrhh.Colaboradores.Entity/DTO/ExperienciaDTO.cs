using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.DTO
{
    public class ExperienciaDTO: BaseDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Detalle { get; set; }
    }
}
