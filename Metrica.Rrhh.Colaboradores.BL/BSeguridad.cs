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
    public class BSeguridad
    {
        #region "Propiedades"
        private readonly IDSeguridad daSeguridad = null;
        public BSeguridad()
        {
            daSeguridad = new DSeguridad();
        }
        #endregion

        public UsuarioDTO Obtener(UsuarioDTO entity)
        {
            UsuarioDTO usuario = daSeguridad.Obtener(entity);
            if (usuario != null)
                usuario.Accesos = daSeguridad.ObtenerAcceso(usuario.Perfil.Codigo);
            else
                throw new Exception("No se encontró usuario en el sistema");
            return usuario;
        }
    }
}
