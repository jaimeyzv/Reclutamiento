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
    [ServiceContract(Namespace = "http://MetricaAndina/Colaboradores/ICandidatoService")]
    public interface ICandidatoService
    {
        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        List<CandidatoDTO> Listar(CandidatoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        CandidatoDTO Obtener(CandidatoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Insertar(CandidatoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Actualizar(CandidatoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Eliminar(CandidatoDTO entity);
    }
}
