using Metrica.Rrhh.Colaboradores.DAL;
using Metrica.Rrhh.Colaboradores.DAL.Interfaz;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.BL
{
    public class BUtil
    {
        #region "Propiedades"
        private readonly IDUtil daUtil = null;
        public BUtil()
        {
            daUtil = new DUtil();
        }
        #endregion

        public List<ItemDTO> ListarEstadoXDominio(int dominio)
        {
            return daUtil.ListarEstadoXDominio(dominio);
        }

        public List<ItemDTO> ListarSkillTecnico(int idPuesto)
        {
            return daUtil.ListarSkillTecnico(idPuesto);
        }

        public List<ItemDTO> ListarDistritos(string ubigeo)
        {
            return daUtil.ListarDistritos(ubigeo);
        }
    }
}
