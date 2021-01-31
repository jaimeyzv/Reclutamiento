using Metrica.Rrhh.Colaboradores.BL;
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
    [ServiceBehavior(Namespace = "http://MetricaAndina/Colaboradores/PuestoService")]
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class PuestoService : IPuestoService
    {
        BPuesto bPuesto = new BPuesto();

        public int Actualizar(string id, PuestoDTO entity)
        {
            try
            {
                entity.Id = int.Parse(id);
                return bPuesto.Actualizar(entity);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, System.Net.HttpStatusCode.InternalServerError);
                //throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }

        public int Eliminar(string id)
        {
            try
            {
                return bPuesto.Eliminar(new PuestoDTO { Id = int.Parse(id) });
            }
            catch (Exception ex)
            {
                throw new WebFaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public int Insertar(PuestoDTO entity)
        {
            try
            {
                return bPuesto.Insertar(entity);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public List<PuestoDTO> Listar(string estado, string filtro)
        {
            try
            {
                return bPuesto.Listar(new PuestoDTO { Estado = estado, Nombre = filtro});
            }
            catch (Exception ex)
            {
                throw new WebFaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public PuestoDTO Obtener(string id)
        {
            try
            {
                return bPuesto.Obtener(new PuestoDTO { Id = int.Parse(id)});
            }
            catch (Exception ex)
            {
                throw new WebFaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
