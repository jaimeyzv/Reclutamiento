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
    [ServiceBehavior(Namespace = "http://MetricaAndina/Colaboradores/RequerimientoService")]
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class RequerimientoService : IRequerimientoService
    {
        private BRequerimiento bRequerimiento = new BRequerimiento();
        public int Actualizar(RequerimientoDTO entity)
        {
            try
            {
                return bRequerimiento.Actualizar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Eliminar(RequerimientoDTO entity)
        {
            try
            {
                return bRequerimiento.Eliminar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Insertar(RequerimientoDTO entity)
        {
            try
            {
                return bRequerimiento.Insertar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public List<RequerimientoDTO> Listar(RequerimientoDTO entity)
        {
            try
            {
                return bRequerimiento.Listar(entity);
            }catch(Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public RequerimientoDTO Obtener(RequerimientoDTO entity)
        {
            try
            {
                return bRequerimiento.Obtener(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }
    }
}
