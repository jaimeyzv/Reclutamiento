using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.Model
{
    public class UsuarioModel : EmpleadoModel
    {
        public bool EsUPC { get; set; }
        public string Password { get; set; }
        public PerfilModel Perfil { get; set; }
        public DateTime? FechaUltimaSesion { get; set; }
        public bool CambiarPassword { get; set; }
        public List<PaginaModel> Accesos { get; set; }
    }

    public class AuxDTOUsuarioModel
    {
        public UsuarioModel UsuarioDTO { get; set; }
    }
}
