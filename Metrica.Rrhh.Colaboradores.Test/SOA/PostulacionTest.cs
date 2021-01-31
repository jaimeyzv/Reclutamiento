using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Metrica.Rrhh.Colaboradores.Test.SOA
{
    [TestClass]
    public class PostulacionTest
    {
        int retval = -1;

        [TestMethod]
        public void Registrar()
        {
            using (WSPostulacion.PostulacionServiceClient wsCliente = new WSPostulacion.PostulacionServiceClient())
            {
                retval = wsCliente.Insertar(new Entity.DTO.PostulanteDTO
                {
                    Accion = 1,//1 Registrar
                    IdRequerimiento = 2011,
                    Dni = "46456813",
                    Estado = "RE",
                    Pretencion = 5000,
                    Disponibilidad = 1,
                    UsuarioCreacion = "marcos.luna"


                });
            }
            Assert.AreEqual(retval > 0, true);
        }

        [TestMethod]
        public void Actualizar()
        {
            using (WSPostulacion.PostulacionServiceClient wsCliente = new WSPostulacion.PostulacionServiceClient())
            {
                retval = wsCliente.Actualizar(new Entity.DTO.PostulanteDTO
                {
                   
                    Accion = 2,
                    IdRequerimiento = 2011,
                    Dni = "46456813",
                    Estado = "RE",
                    Pretencion = 6000,
                    Disponibilidad = 1,
                    UsuarioCreacion = "marcos.luna"
                });
            }
            Assert.AreEqual(retval > 0, true);
        }

        [TestMethod]
        public void Listar()
        {
            List<Entity.DTO.PostulanteDTO> dtoResponse = null;
            using (WSPostulacion.PostulacionServiceClient wsCliente = new WSPostulacion.PostulacionServiceClient())
            {

                dtoResponse = wsCliente.Listar(new Entity.DTO.PostulanteDTO{ Dni = "46456813"});
               
                //Assert.IsNotNull(dtoResponse);
            }
            Assert.IsNotNull(dtoResponse);
        }

        [TestMethod]
        public void Eliminar()
        {
            using (WSPostulacion.PostulacionServiceClient wsCliente = new WSPostulacion.PostulacionServiceClient())
            {
                retval = wsCliente.Eliminar(new Entity.DTO.PostulanteDTO { Dni = "46456813" });
            }
            Assert.AreEqual(retval > 0, true);
        }
    }
}
