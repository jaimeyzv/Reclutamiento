using Metrica.Rrhh.Colaboradores.DAL;
using Metrica.Rrhh.Colaboradores.DAL.Interfaz;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.BL
{
    public class BRequerimiento: BClientService
    {
        #region "Propiedades"
        private readonly IDRequerimiento daRequerimiento = null;
        public BRequerimiento()
        {
            daRequerimiento = new DRequerimiento();
        }
        #endregion

        public RequerimientoDTO Obtener(RequerimientoDTO entity)
        {
            RequerimientoDTO req = daRequerimiento.Obtener(entity);
            if (req != null)
            {
                using (WSPostulacion.IPostulacionServiceChannel wsCliente = ObtenerServicioPostulacion())
                    req.Postulaciones = wsCliente.Listar(new PostulanteDTO { IdRequerimiento = req.Id });
            }
            return req;
        }

        public List<RequerimientoDTO> Listar(RequerimientoDTO entity)
        {
            return daRequerimiento.Listar(entity);
        }

        public int Insertar(RequerimientoDTO entity)
        {
            int retval = 0;
            if((retval= daRequerimiento.Insertar(entity)) > 0)
            {
                try
                {
                    using (WSNotificacion.INotificacionServiceChannel wsCliente = ObtenerServicioNotificacion())
                    {
                        EmailDTO emailDTO = new EmailDTO();
                        emailDTO.Destinatario = ConfigurationManager.AppSettings.Get("rrhhMail");
                        emailDTO.Asunto = "Nuevo Requerimiento de Personal";
                        emailDTO.TipoEmail = TipoMensaje.Requerimiento;
                        emailDTO.Mensaje = string.Format("Se ha generado un requerimiento para el cliente <b>{0}</b> con el perfil de <b>{1}</b> y su fecha de posible ingreso es <b>{2}</b>", entity.Cliente.RazonSocial, entity.Perfil, entity.FechaTentativa.ToString("yyyy-MM-dd"));
                        wsCliente.EnviarEmail(emailDTO);
                    }
                }catch(Exception ex)
                {
                    retval = -99;
                }
            }
            return retval;
        }

        public int Actualizar(RequerimientoDTO entity)
        {
            return daRequerimiento.Actualizar(entity);
        }

        public int Eliminar(RequerimientoDTO entity)
        {
            int retval = 0;
            if ((retval = daRequerimiento.Eliminar(entity)) > 0)
            {
                try
                {
                    using (WSNotificacion.INotificacionServiceChannel wsCliente = ObtenerServicioNotificacion())
                    {
                        EmailDTO emailDTO = new EmailDTO();
                        emailDTO.Destinatario = ConfigurationManager.AppSettings.Get("rrhhMail");
                        emailDTO.Asunto = string.Format("Requerimiento de Personal #{0} Cancelado", entity.Id);
                        emailDTO.TipoEmail = TipoMensaje.Requerimiento;
                        emailDTO.Mensaje = string.Format("El requerimiento <b>#{0}</b> fue cancelado", entity.Id);
                        wsCliente.EnviarEmail(emailDTO);
                    }
                }
                catch (Exception ex)
                {
                    retval = -99;
                }
            }
            return retval;
        }
    }
}
