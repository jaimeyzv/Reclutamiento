using Metrica.Rrhh.Colaboradores.DAL;
using Metrica.Rrhh.Colaboradores.DAL.Interfaz;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Metrica.Rrhh.Colaboradores.BL
{
    public class BEmpleado: BClientService
    {
        #region "Propiedades"
        private readonly IDEmpleado daEmpleado = null;
        public BEmpleado()
        {
            daEmpleado = new DEmpleado();
        }
        #endregion

        public EmpleadoDTO Obtener(EmpleadoDTO entity)
        {
            EmpleadoDTO retval = daEmpleado.Obtener(entity);
            using (WSCandidato.ICandidatoServiceChannel wsCliente = ObtenerServicioCandidato())
                retval.Candidato(wsCliente.Obtener(entity));
            return retval;
        }

        public List<EmpleadoDTO> Listar(EmpleadoDTO entity)
        {
            return daEmpleado.Listar(entity);
        }

        public int Actualizar(EmpleadoDTO entity)
        {
            using (WSCandidato.ICandidatoServiceChannel wsCliente = ObtenerServicioCandidato())
            {
                int retval = wsCliente.Actualizar(entity);
                if (retval > 0)
                    retval = daEmpleado.Actualizar(entity);
                return retval;
            }
        }

        public int Eliminar(EmpleadoDTO entity)
        {
            return daEmpleado.Eliminar(entity);
        }

        public int Insertar(EmpleadoDTO entity)
        {
            using (WSCandidato.ICandidatoServiceChannel wsCliente = ObtenerServicioCandidato())
            {
                CandidatoDTO candidatoDTO = entity;
                int retval = wsCliente.Insertar(candidatoDTO);
                if (retval > 0)
                {
                    retval = daEmpleado.Insertar(entity);
                }
                return retval;
            }
        }
    }
}
