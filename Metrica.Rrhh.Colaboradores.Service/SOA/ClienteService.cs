using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Metrica.Rrhh.Colaboradores.BL;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Service.Extension;

namespace Metrica.Rrhh.Colaboradores.Service.SOA
{
    [ServiceBehavior(Namespace = "http://MetricaAndina/Colaboradores/ClienteService")]
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class ClienteService : IClienteService
    {
        private BCliente bCliente = new BCliente();

        public List<ClienteDTO> Listar()
        {
            try
            {
                return bCliente.Listar();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }
    }
}
