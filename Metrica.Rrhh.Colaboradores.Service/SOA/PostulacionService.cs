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
    [ServiceBehavior(Namespace = "http://MetricaAndina/Colaboradores/PostulacionService")]
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class PostulacionService : IPostulacionService
    {
        private BPostulacion bPostulacion = new BPostulacion();

        public int Actualizar(PostulanteDTO entity)
        {
            try
            {
                return bPostulacion.Actualizar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Aprobar(PostulanteDTO entity)
        {
            try
            {
                return bPostulacion.Aprobar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Eliminar(PostulanteDTO entity)
        {
            try
            {
                return bPostulacion.Eliminar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Insertar(PostulanteDTO entity)
        {
            try
            {
                return bPostulacion.Insertar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public List<PostulanteDTO> Listar(PostulanteDTO entity)
        {
            try
            {
                return bPostulacion.Listar(entity);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }
    }
}
