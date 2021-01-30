using Metrica.Rrhh.Colaboradores.DAL.Common;
using Metrica.Rrhh.Colaboradores.DAL.Interfaz;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.DAL
{
    public class DCliente : IDCliente
    {
        #region "Propiedades"
        protected static Database db = DConexion.Instance().GetSqlDatabase();
        #endregion

        public int Actualizar(ClienteDTO entity)
        {
            throw new NotImplementedException();
        }

        public int ActualizarEstado(ClienteDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(ClienteDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Insertar(ClienteDTO entity)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDTO> Listar()
        {
            List<ClienteDTO> retval = new List<ClienteDTO>();
            ClienteDTO item;
            using (DbCommand cmd = db.GetStoredProcCommand("sp_sel_clientes"))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        item = new ClienteDTO();
                        item.Id = int.Parse(dr["Id_Cliente"].ToString());
                        item.Ruc = dr["Ruc"].ToString();
                        item.RazonSocial = dr["Razon_Social"].ToString();
                        item.Direccion = dr["Direccion"].ToString();
                        item.Telefono = dr["Telefono"].ToString();
                        item.Contacto = dr["Contacto"].ToString();
                        retval.Add(item);
                    }
                }
            }
            return retval;
        }

        public List<ClienteDTO> Listar(ClienteDTO entity)
        {
            throw new NotImplementedException();
        }

        public ClienteDTO Obtener(ClienteDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
