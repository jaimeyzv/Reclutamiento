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
    [ServiceContract(Namespace = "http://MetricaAndina/Colaboradores/IRequerimientoService")]
    public interface IRequerimientoService
    {
        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        RequerimientoDTO Obtener(RequerimientoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        List<RequerimientoDTO> Listar(RequerimientoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Insertar(RequerimientoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Actualizar(RequerimientoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Eliminar(RequerimientoDTO entity);

    }
}
