using Metrica.Rrhh.Colaboradores.BL;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Service.Extension;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Metrica.Rrhh.Colaboradores.Service.REST
{
    [ServiceBehavior(Namespace = "http://MetricaAndina/Colaboradores/SeguridadService")]
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class SeguridadService : ISeguridadService
    {
        private BSeguridad bSeguridad = new BSeguridad();

        public UsuarioDTO IniciarSesion(string usuario, string password)
        {
            try
            {
                //UsuarioDTO usuarioDTO = null;
                //Acceso.Acceso proxyAcceso = new Acceso.Acceso();
                //Acceso.UsuarioDTO proxyUsuario = proxyAcceso.IniciarSesion(usuario, password);
                //if (proxyUsuario != null)
                //{
                //    usuarioDTO = bSeguridad.Obtener(new UsuarioDTO { Usuario = proxyUsuario.usuario, Perfil = new PerfilDTO { Codigo = proxyUsuario.usuario == "marcos.luna" ? "ADM" : proxyUsuario.tipo_usuario.ToUpper() } });
                //}
                //else
                //{
                //    throw new Exception("Error al validar credenciales en el sistema");
                //}
                //if (proxyUsuario.esUpc)
                //{
                //    usuarioDTO.Nombres = proxyUsuario.nombres;
                //    usuarioDTO.ApellidoPaterno = proxyUsuario.apellidoPaterno;
                //    usuarioDTO.ApellidoMaterno = proxyUsuario.apellidoMaterno;
                //    usuarioDTO.EsUPC = true;
                //}
                //else
                //    usuarioDTO.EsUPC = false;

                //return usuarioDTO;

                UsuarioDTO usuarioDTO = null;

                usuarioDTO = bSeguridad.Obtener(new UsuarioDTO {
                    Usuario = usuario,
                    Perfil = new PerfilDTO { Codigo = "ADM" }
                 });
                
                return usuarioDTO;
            }
            catch(Exception ex)
            {
                throw new WebFaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, System.Net.HttpStatusCode.InternalServerError);
                //throw new FaultException<FaultDTO>(new FaultDTO { FaultId = "-99", FaultDescription = ex.Message }, new FaultReason(ex.Message));
            }
        }
    }
}
