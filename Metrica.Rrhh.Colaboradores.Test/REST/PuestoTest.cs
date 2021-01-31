using System;
using System.Net;
using System.Net.Http;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Web.Script.Serialization;


namespace Metrica.Rrhh.Colaboradores.Test.REST
{
    

    [TestClass]
    public class PuestoTest
    {
        [TestMethod]
        public void Registar()
        {
            using (HttpClient httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:19560/PuestoService.svc/");
                var response = httpclient.PostAsJsonAsync(httpclient.BaseAddress, new PuestoDTO
                {
                    Nombre = "Analista .NET Prueba Automatica",
                    UsuarioCreacion = "jorge",
                    ConocimientoTecnico = "sql",
                }).Result.Content.ReadAsStringAsync();

                int id = int.Parse(response.Result);
                Assert.AreEqual(true, id > 0);

            }
        }

        [TestMethod]
        public void Obtener()
        {
            using (HttpClient httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:19560/PuestoService.svc/15");
                HttpResponseMessage response = httpclient.GetAsync(httpclient.BaseAddress).Result;
                response.EnsureSuccessStatusCode();
                PuestoDTO puestoDTO = response.Content.ReadAsAsync<PuestoDTO>().Result;
                Assert.AreEqual(15, puestoDTO.Id);
            }
        }

        [TestMethod]
        public void Actualizar()
        {
            using (HttpClient httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:19560/PuestoService.svc/15");
                HttpResponseMessage response = httpclient.PutAsJsonAsync(httpclient.BaseAddress, new PuestoDTO
                {
                    Nombre = "Analista Junior .NET qqqq Test"
                }).Result;

                response = httpclient.GetAsync(httpclient.BaseAddress).Result;
                response.EnsureSuccessStatusCode();
                PuestoDTO puestoDTO = response.Content.ReadAsAsync<PuestoDTO>().Result;
                Assert.AreEqual("Analista Junior .NET qqqq Test", puestoDTO.Nombre);
            }
        }

        [TestMethod]
        public void Eliminar()
        {
            using (HttpClient httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:19560/PuestoService.svc/15");

                var response = httpclient.DeleteAsync(httpclient.BaseAddress).Result.Content.ReadAsStringAsync();

                int id = int.Parse(response.Result);
                Assert.AreEqual(true, id > 0);
            }
        }

    }
}
