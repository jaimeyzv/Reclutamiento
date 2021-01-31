using Metrica.Rrhh.Colaboradores.BL.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.BL
{
    public class BClientService
    {
        protected WSNotificacion.INotificacionServiceChannel ObtenerServicioNotificacion()
        {
            return new ServiceClientFactory<WSNotificacion.INotificacionServiceChannel>().Create(ConfigurationManager.AppSettings.Get("rutaSoap") + "NotificacionService.svc");
        }

        protected WSPostulacion.IPostulacionServiceChannel ObtenerServicioPostulacion()
        {
            return new ServiceClientFactory<WSPostulacion.IPostulacionServiceChannel>().Create(ConfigurationManager.AppSettings.Get("rutaSoap") + "PostulacionService.svc");
        }

        protected WSCliente.IClienteServiceChannel ObtenerServicioCliente()
        {
            return new ServiceClientFactory<WSCliente.IClienteServiceChannel>().Create(ConfigurationManager.AppSettings.Get("rutaSoap") + "ClienteService.svc");
        }

        protected WSCandidato.ICandidatoServiceChannel ObtenerServicioCandidato()
        {
            return new ServiceClientFactory<WSCandidato.ICandidatoServiceChannel>().Create(ConfigurationManager.AppSettings.Get("rutaSoap") + "CandidatoService.svc");
        }

        protected WSEmpleado.IEmpleadoServiceChannel ObtenerServicioEmpleado()
        {
            return new ServiceClientFactory<WSEmpleado.IEmpleadoServiceChannel>().Create(ConfigurationManager.AppSettings.Get("rutaSoap") + "EmpleadoService.svc");
        }
    }
}
