using Metrica.Rrhh.Colaboradores.BL.WSNotificacion;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Service.SOA
{
    [ServiceContract(Namespace = "http://MetricaAndina/Colaboradores/IEmpleadoService")]
    public interface IEmpleadoService
    {
        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        EmpleadoDTO Obtener(EmpleadoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        List<EmpleadoDTO> Listar(EmpleadoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Actualizar(EmpleadoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Eliminar(EmpleadoDTO entity);

        [OperationContract]
        [FaultContract(typeof(FaultDTO))]
        int Insertar(EmpleadoDTO entity);
    }
}
