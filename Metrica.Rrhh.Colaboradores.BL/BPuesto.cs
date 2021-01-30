using Metrica.Rrhh.Colaboradores.DAL;
using Metrica.Rrhh.Colaboradores.DAL.Interfaz;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.BL
{
    public class BPuesto
    {
        #region "Propiedades"
        private readonly IDPuesto daPuesto = null;
        public BPuesto()
        {
            daPuesto = new DPuesto();
        }
        #endregion

        public List<PuestoDTO> Listar()
        {
            return daPuesto.Listar(new PuestoDTO { });
        }

        public List<PuestoDTO> Listar(PuestoDTO entity)
        {
            return daPuesto.Listar(entity);
        }

        public PuestoDTO Obtener(PuestoDTO entity)
        {
            return daPuesto.Obtener(entity);
        }

        public int Insertar(PuestoDTO entity)
        {
            return daPuesto.Insertar(entity);
        }

        public int Actualizar(PuestoDTO entity)
        {
            return daPuesto.Actualizar(entity);
        }

        public int Eliminar(PuestoDTO entity)
        {
            return daPuesto.Eliminar(entity);
        }
    }
}
