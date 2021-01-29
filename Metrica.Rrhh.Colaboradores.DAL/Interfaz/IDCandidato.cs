using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.DAL.Interfaz
{
    public interface IDCandidato : IDMantenimiento<CandidatoDTO, int>
    {
        List<ExperienciaDTO> ListarExperiencias(string dni);
        int RegistarExperiencias(ExperienciaDTO entity, string dni, string usuario);
    }
}
