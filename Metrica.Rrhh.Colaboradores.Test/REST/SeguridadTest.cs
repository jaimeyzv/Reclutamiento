using System;
using System.Net.Http;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Metrica.Rrhh.Colaboradores.Test.REST
{
    [TestClass]
    public class SeguridadTest
    {
        [TestMethod]
        public void IniciarSesion()
        {
            using (HttpClient httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:19560/SeguridadService.svc/");
                var response = httpclient.PostAsJsonAsync(httpclient.BaseAddress, new { usuario = "marcos.luna", password = "ML7001" }).Result;
                response.EnsureSuccessStatusCode();
                AuxDTOUsuarioModel usuarioDTO = response.Content.ReadAsAsync<AuxDTOUsuarioModel>().Result;
                Assert.AreEqual(true, usuarioDTO.UsuarioDTO.ApellidoPaterno.ToLower() == "luna");

            }
        }
    }
}
