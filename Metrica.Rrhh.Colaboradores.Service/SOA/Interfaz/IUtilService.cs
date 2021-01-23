using Metrica.Rrhh.Colaboradores.BL.WSNotificacion;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Service.SOA
{
    [ServiceContract(Namespace = "http://MetricaAndina/Colaboradores/IUtilService")]
    public interface IUtilService
    {
        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        List<ItemDTO> ListarEstadoXDominio(int dominio);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        List<ItemDTO> ListarSkillTecnico(int idPuesto);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        List<ItemDTO> ListarDistritos(string ubigeo);
    }
}
