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
    [ServiceContract(Namespace = "http://MetricaAndina/Colaboradores/IPuestoService")]
    public interface IPuestoService
    {
        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "?estado={estado}&filtro={filtro}", RequestFormat = WebMessageFormat.Json)]
        List<PuestoDTO> Listar(string estado, string filtro);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "{id}", RequestFormat = WebMessageFormat.Json)]
        PuestoDTO Obtener(string id);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "", RequestFormat = WebMessageFormat.Json)]
        int Insertar(PuestoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "{id}", RequestFormat = WebMessageFormat.Json)]
        int Actualizar(string id, PuestoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "{id}", RequestFormat = WebMessageFormat.Json)]
        int Eliminar(string id);
    }
}
