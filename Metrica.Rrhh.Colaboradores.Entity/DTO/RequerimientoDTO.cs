using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.DTO
{
    public class RequerimientoDTO: BaseDTO
    {
        public int Id { get; set; }
        public string Perfil { get; set; }
        public ClienteDTO Cliente { get; set; }
        public string Estado { get; set; }
        public DateTime FechaTentativa { get; set; }
        public string RangoSalario { get; set; }
        public string Descripcion { get; set; }
        public string OrdenCompra { get; set; }
        public List<PostulanteDTO> Postulaciones { get; set; }
    }
}
