using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Metrica.Rrhh.Colaboradores.Test.Mensajeria
{
    [TestClass]
    public class NotificacionTest
    {
        [TestMethod]
        public void RegistrarMensaje()
        {
            try
            {
                using (WSNotificacion.NotificacionServiceClient ws = new WSNotificacion.NotificacionServiceClient())
                {
                    ws.EnviarEmail(new Entity.DTO.EmailDTO { Asunto = "Pruba test mensajeria", Destinatario = "marcos.luna@metricaandina.com", Mensaje = "Pruenba exitosa", TipoEmail = Entity.DTO.TipoMensaje.Requerimiento });
                    Assert.AreEqual(true, true);//Si llega a este punto no hay error
                }
            }catch(Exception ex)
            {
                Assert.AreEqual(true, false);//Si llega a este punto hay error en la prueba
            }
        }

        [TestMethod]
        public void ProcesarMensajes()
        {
            try
            {
                using (WSNotificacion.NotificacionServiceClient ws = new WSNotificacion.NotificacionServiceClient())
            {
                ws.EnviarEmailPendientesQueue();
                Assert.AreEqual(true, true);//Si llega a este punto no hay error
            }
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, false);//Si llega a este punto hay error en la prueba
            }
        }
    }
}
