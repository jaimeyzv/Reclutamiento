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
    public class BCandidato
    {
        #region "Propiedades"
        private readonly IDCandidato daCandidato = null;
        public BCandidato()
        {
            daCandidato = new DCandidato();
        }
        #endregion

        public List<CandidatoDTO> Listar(CandidatoDTO entity)
        {
            return daCandidato.Listar(entity);
        }

        public CandidatoDTO Obtener(CandidatoDTO entity)
        {
            CandidatoDTO retval = daCandidato.Obtener(entity);
            if (retval != null)
            {
                retval.Experiencias = daCandidato.ListarExperiencias(entity.Dni);
                retval.Estudios = retval.Experiencias.Where(x=> x.Tipo == "E").ToList();
                retval.Experiencias = retval.Experiencias.Where(x => x.Tipo == "X").ToList();
            }
            return retval;
        }

        public int Insertar(CandidatoDTO entity)
        {
            int retval = 0;
            using (TransactionScope ts = new TransactionScope())
            {
                retval = daCandidato.Insertar(entity);
                if(retval > 0)
                {
                    if(entity.Experiencias != null)
                    {
                        entity.Experiencias.ForEach(x => daCandidato.RegistarExperiencias(x, entity.Dni, entity.UsuarioCreacion));
                    }
                    if (entity.Estudios != null)
                    {
                        entity.Estudios.ForEach(x => daCandidato.RegistarExperiencias(x, entity.Dni, entity.UsuarioCreacion));
                    }
                }
                ts.Complete();
            }
            return retval;
        }

        public int Actualizar(CandidatoDTO entity)
        {
            int retval = 0;
            using (TransactionScope ts = new TransactionScope())
            {
                retval = daCandidato.Actualizar(entity);
                if (retval > 0)
                {
                    if (entity.Experiencias != null)
                    {
                        entity.Experiencias.ForEach(x => daCandidato.RegistarExperiencias(x, entity.Dni, entity.UsuarioModificacion));
                    }
                    if (entity.Estudios != null)
                    {
                        entity.Estudios.ForEach(x => daCandidato.RegistarExperiencias(x, entity.Dni, entity.UsuarioModificacion));
                    }
                }
                ts.Complete();
            }
            return retval;
        }

        public int Eliminar(CandidatoDTO entity)
        {
            return daCandidato.Eliminar(entity);
        }
    }
}
