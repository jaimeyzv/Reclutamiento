using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.SW
{
    class ServiceManager
    {
        static private ILog logger = LogManager.GetLogger(typeof(ServiceManager));
        public void Start()
        {
            try
            {
                using(WSNotificacion.NotificacionServiceClient wsCliente = new WSNotificacion.NotificacionServiceClient())
                {
                    wsCliente.EnviarEmailPendientesQueue();
                }
            }catch(Exception ex)
            {
                logger.Error(ex);
            }
            Thread.Sleep(1000 * 60);
        }
    }
}
