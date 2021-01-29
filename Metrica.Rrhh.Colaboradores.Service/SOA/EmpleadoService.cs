using Metrica.Rrhh.Colaboradores.BL;
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
    [ServiceBehavior(Namespace = "http://MetricaAndina/Colaboradores/EmpleadoService")]
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class EmpleadoService : IEmpleadoService
    {
        BEmpleado bEmpleado = new BEmpleado();
        public int Actualizar(EmpleadoDTO entity)
        {
            try
            {
                return bEmpleado.Actualizar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Eliminar(EmpleadoDTO entity)
        {
            try
            {
                return bEmpleado.Eliminar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Insertar(EmpleadoDTO entity)
        {
            try
            {
                return bEmpleado.Insertar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public List<EmpleadoDTO> Listar(EmpleadoDTO entity)
        {
            try
            {
                return bEmpleado.Listar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public EmpleadoDTO Obtener(EmpleadoDTO entity)
        {
            try
            {
                return bEmpleado.Obtener(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }
    }
}
