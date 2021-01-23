using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.DTO
{

    public class UsuarioDTO : EmpleadoDTO
    {
        public bool EsUPC { get; set; }
        public string Password { get; set; }
        public PerfilDTO Perfil { get; set; }
        public DateTime? FechaUltimaSesion { get; set; }
        public bool CambiarPassword { get; set; }
        public List<PaginaDTO> Accesos { get; set; }

    }
}
