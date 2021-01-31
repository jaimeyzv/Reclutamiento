using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using Metrica.Rrhh.Colaboradores.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Metrica.Rrhh.Colaboradores.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }

        // POST: Seguridad/Index
        [HttpPost]
        public async Task<ActionResult> Index(LoginModel model)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                using (var httpclient = new HttpClient())
                {
                    HttpResponseMessage response = null;
                    httpclient.BaseAddress = new Uri(Constantes.RutaRest + "SeguridadService.svc/");
                    response = await httpclient.PostAsJsonAsync(httpclient.BaseAddress, new { usuario = model.Usuario, password = model.Password });
                    //response.EnsureSuccessStatusCode();
                    if (response.StatusCode == HttpStatusCode.OK)
                        usuario = (await response.Content.ReadAsAsync<AuxDTOUsuarioModel>()).UsuarioDTO;
                    else
                        throw new Exception(await response.Content.ReadAsStringAsync());
                }
                if (usuario != null)
                {
                    Session["Usuario"] = usuario;
                    Session["NroNotificaciones"] = 9;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "No se encontró usuario en sistema");
                    return View(model);
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
