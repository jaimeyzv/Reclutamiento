using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.DAL.Interfaz
{
    public interface IDSeguridad: IDMantenimiento<UsuarioDTO, string>
    {
        List<PaginaDTO> ObtenerAcceso(string sPerfil);
    }
}
