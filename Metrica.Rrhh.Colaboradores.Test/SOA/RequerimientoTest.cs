using System;
using Metrica.Rrhh.Colaboradores.Test.WSRequerimiento;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Metrica.Rrhh.Colaboradores.Test.SOA
{
    [TestClass]
    public class RequerimientoTest
    {
        int retval= 1017;

        [TestMethod]
        public void Registrar()
        {
            using(WSRequerimiento.RequerimientoServiceClient wsCliente= new WSRequerimiento.RequerimientoServiceClient())
            {
                retval = wsCliente.Insertar(new WSRequerimiento.RequerimientoDTO
                {
                    Accion = 1,//1 Registrar
                    Perfil = "Analista .NET MVC Automatizacion Test UPC 25866",
                    Cliente = new ClienteDTO { Id = 1, RazonSocial="Metrica Andina" },
                    Estado = "RE",
                    Descripcion = "Analista con 2 años de experiencia",
                    FechaTentativa = DateTime.Now,
                    OrdenCompra = "999999-04",
                    RangoSalario = "5000-6000",
                    UsuarioCreacion = "mlunap"
                });
            }
            Assert.AreEqual(retval > 0, true);
        }

        [TestMethod]
        public void Actualizar()
        {
            using (WSRequerimiento.RequerimientoServiceClient wsCliente = new WSRequerimiento.RequerimientoServiceClient())
            {
                retval = wsCliente.Actualizar(new WSRequerimiento.RequerimientoDTO
                {
                    Id= 2027,
                    Accion = 2,
                    Perfil = "Analista programador .NET  Test UPC Edti",
                    Cliente = new ClienteDTO { Id = 1 , RazonSocial = "Metrica Andina"},
                    Estado = "RE",
                    Descripcion = "Conocimientos en .NET con 4 años de experiencia",
                    FechaTentativa = DateTime.Now,
                    OrdenCompra = "201550-04",
                    RangoSalario = "5000-6000",
                    UsuarioCreacion = "mlunap"
                });
            }
            Assert.AreEqual(retval > 0, true);
        }

        [TestMethod]
        public void Consultar()
        {
            RequerimientoDTO dtoResponse= null;
            using (WSRequerimiento.RequerimientoServiceClient wsCliente = new WSRequerimiento.RequerimientoServiceClient())
            {
                dtoResponse = wsCliente.Obtener(new WSRequerimiento.RequerimientoDTO{Id= 2027 });
            }
            Assert.AreNotEqual(dtoResponse, null);
        }

        [TestMethod]
        public void Eliminar()
        {
            using (WSRequerimiento.RequerimientoServiceClient wsCliente = new WSRequerimiento.RequerimientoServiceClient())
            {
                retval = wsCliente.Eliminar(new WSRequerimiento.RequerimientoDTO{Id = 2027 });
            }
            Assert.AreEqual(retval > 0, true);
        }
    }
}
