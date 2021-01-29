using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.DAL.Interfaz
{
    public interface IDUtil
    {
        List<ItemDTO> ListarEstadoXDominio(int dominio);
        List<ItemDTO> ListarSkillTecnico(int idPuesto);
        List<ItemDTO> ListarDistritos(string ubigeo);
    }
}
