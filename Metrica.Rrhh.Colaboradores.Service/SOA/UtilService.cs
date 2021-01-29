using Metrica.Rrhh.Colaboradores.BL;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Service.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Service.SOA
{
    [ServiceBehavior(Namespace = "http://MetricaAndina/Colaboradores/UtilService")]
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class UtilService : IUtilService
    {
        private BUtil bUtil = new BUtil();
        public List<ItemDTO> ListarDistritos(string ubigeo)
        {
            try
            {
                return bUtil.ListarDistritos(ubigeo);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public List<ItemDTO> ListarEstadoXDominio(int dominio)
        {
            try
            {
                return bUtil.ListarEstadoXDominio(dominio);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public List<ItemDTO> ListarSkillTecnico(int idPuesto)
        {
            try
            {
                return bUtil.ListarSkillTecnico(idPuesto);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }
    }
}
