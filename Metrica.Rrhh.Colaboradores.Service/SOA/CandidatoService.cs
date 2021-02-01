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
    [ServiceBehavior(Namespace = "http://MetricaAndina/Colaboradores/CandidatoService")]
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class CandidatoService : ICandidatoService
    {
        BCandidato bCandidato = new BCandidato();

        public int Actualizar(CandidatoDTO entity)
        {
            try
            {
                return bCandidato.Actualizar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Eliminar(CandidatoDTO entity)
        {
            try
            {
                return bCandidato.Eliminar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Insertar(CandidatoDTO entity)
        {
            try
            {
                return bCandidato.Insertar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public List<CandidatoDTO> Listar(CandidatoDTO entity)
        {
            try
            {
                return bCandidato.Listar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public CandidatoDTO Obtener(CandidatoDTO entity)
        {
            try
            {
                return bCandidato.Obtener(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }
    }
}
