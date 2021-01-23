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
    [ServiceContract(Namespace = "http://MetricaAndina/Colaboradores/INotificacionService")]
    public interface INotificacionService
    {
        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        void EnviarEmail(EmailDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        void EnviarEmailPendientesQueue();
    }
}
