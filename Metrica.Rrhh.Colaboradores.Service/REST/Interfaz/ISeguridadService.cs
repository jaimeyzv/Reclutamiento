using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Service.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Service.REST
{
    [ServiceContract(Namespace = "http://MetricaAndina/Colaboradores/ISeguridadService")]
    public interface ISeguridadService
    {
        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "", 
            BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json)]
        [return: MessageParameter(Name = "UsuarioDTO")]
        UsuarioDTO IniciarSesion(string usuario, string password);
    }
}
