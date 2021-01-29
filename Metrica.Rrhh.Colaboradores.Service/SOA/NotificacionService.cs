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
    [ServiceBehavior(Namespace = "http://MetricaAndina/Colaboradores/NotificacionService")]
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class NotificacionService : INotificacionService
    {
        private BNotificacion bNotificacion = new BNotificacion();
        public void EnviarEmail(EmailDTO entity)
        {
            try
            {
                //bNotificacion.RegistrarEmail(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public void EnviarEmailPendientesQueue()
        {
            try
            {
                //bNotificacion.EnviarEmailPendientesQueue();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }
    }
}
