using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Service.SOA;

namespace Metrica.Rrhh.Colaboradores.Test.SOA
{
    
    [TestClass]
    public class CandidatoTest
    {
        int retval = -1;
        public CandidatoTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }


        [TestMethod]
        public void Registrar()
        {
            
            using (WSCandidato.CandidatoServiceClient wsCliente = new WSCandidato.CandidatoServiceClient())
            {
                retval = wsCliente.Insertar(new CandidatoDTO { Estado = "RE",
                    Dni = "46456813",
                    Nombres = "Jorge",
                    ApellidoPaterno = "Mini",
                    ApellidoMaterno = "Pezo",
                    Direccion = "",
                    Disponibilidad = 1,
                    TelefonoPersonal = "123456788",
                    EstadoCivil = "S",
                    IdPuesto = 1,
                    Sexo = "M",
                    Pretencion = 5000,
                    FechaNacimiento = DateTime.Now,
                    Email = ""
                });
                   
            }
            Assert.AreEqual(retval > 0, true);
        }

        [TestMethod]
        public void Actualizar()
        {
            using (WSCandidato.CandidatoServiceClient wsCliente = new WSCandidato.CandidatoServiceClient())
            {
                retval = wsCliente.Actualizar(new CandidatoDTO
                {

                    Estado = "RE",
                    Dni = "46456813",
                    Nombres = "Jorge Manuel",
                    ApellidoPaterno = "Mini",
                    ApellidoMaterno = "Pezo",
                    Direccion = "",
                    Disponibilidad = 1,
                    TelefonoPersonal = "123456788",
                    EstadoCivil = "S",
                    IdPuesto = 1,
                    Sexo = "M",
                    Pretencion = 5000,
                    FechaNacimiento = DateTime.Now,
                    Email = ""
                });
            }
            Assert.AreEqual(retval > 0, true);
        }

        [TestMethod]
        public void Consultar()
        {
            CandidatoDTO dtoResponse = null;
            using (WSCandidato.CandidatoServiceClient wsCliente = new WSCandidato.CandidatoServiceClient())
            {
                dtoResponse = wsCliente.Obtener(new CandidatoDTO { Dni = "46456813" });
                //dtoResponse = wsCliente.ObtenerAsync(new WSRequerimiento.RequerimientoDTO { Id = 2017 }).Result;

                //Assert.IsNotNull(dtoResponse);
            }
            Assert.IsNotNull(dtoResponse);
        }

        [TestMethod]
        public void Eliminar()
        {
            using (WSCandidato.CandidatoServiceClient wsCliente = new WSCandidato.CandidatoServiceClient())
            {
                retval = wsCliente.Eliminar(new CandidatoDTO { Dni = "46456813" });
            }
            Assert.AreEqual(retval > 0, true);
        }
    }
}
