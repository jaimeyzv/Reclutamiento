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
    public class BCliente
    {
        #region "Propiedades"
        private readonly IDCliente daCliente = null;
        public BCliente()
        {
            daCliente = new DCliente();
        }
        #endregion

        public List<ClienteDTO> Listar()
        {
            return daCliente.Listar();
        }
    }
}
