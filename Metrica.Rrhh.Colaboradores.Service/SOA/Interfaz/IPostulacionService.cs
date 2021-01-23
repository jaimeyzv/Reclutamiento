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
    [ServiceContract(Namespace = "http://MetricaAndina/Colaboradores/IPostulacionService")]
    public interface IPostulacionService
    {
        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        List<PostulanteDTO> Listar(PostulanteDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Insertar(PostulanteDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Actualizar(PostulanteDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Eliminar(PostulanteDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Aprobar(PostulanteDTO entity);
    }
}
