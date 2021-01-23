using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.DTO
{
    public class PostulanteDTO: CandidatoDTO
    {
        public int IdRequerimiento { get; set; }
        public int IdCliente { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaPostulacion { get; set; }
        public DateTime FechaIniContrato { get; set; }
        public DateTime? FechaFinContrato { get; set; }
    }
}
