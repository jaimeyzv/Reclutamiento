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
    [ServiceContract(Namespace = "http://MetricaAndina/Colaboradores/IClienteService")]
    public interface IClienteService
    {
        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        List<ClienteDTO> Listar();
    }
}
