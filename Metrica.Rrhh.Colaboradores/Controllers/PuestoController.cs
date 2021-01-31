using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Mvc;

namespace Metrica.Rrhh.Colaboradores.Controllers
{
    public class PuestoController : BaseController
    {
        // GET: Puesto
        public ActionResult Index(string estado, string filtro_por, int? page)
        {
            try
            {
                ViewBag.estado = estado;
                ViewBag.filtro_por = filtro_por;
                int paginaActual = (page ?? 1);
                return View(new PagedList.PagedList<PuestoModel>(ListarPuestos(estado, filtro_por), paginaActual, 5));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new PagedList.PagedList<PuestoModel>(new List<PuestoModel>(), 1, 1));
            }
        }

        // GET: Puesto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Puesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puesto/Create
        [HttpPost]
        public ActionResult Create(PuestoModel model)
        {
            try
            {
                model.UsuarioCreacion = UsuarioLogin().Usuario;
                model.Estado = "RE";
                using (var httpclient = new HttpClient())
                {
                    httpclient.BaseAddress = new Uri(ObtenerURLPuestoService());
                    HttpResponseMessage response = httpclient.PostAsJsonAsync(httpclient.BaseAddress, model).Result;
                    //response.EnsureSuccessStatusCode();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        Mostrar_Mensaje_Ok("Puesto guardado correctamente");
                    else
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // GET: Puesto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                PuestoModel model = null;
                using (var httpclient = new HttpClient())
                {
                    httpclient.BaseAddress = new Uri(ObtenerURLPuestoService() + id);
                    HttpResponseMessage response = httpclient.GetAsync(httpclient.BaseAddress).Result;
                    //response.EnsureSuccessStatusCode();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        model = response.Content.ReadAsAsync<PuestoModel>().Result;
                    else
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return RetornarExcepcion(ex);
            }
        }

        // POST: Puesto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PuestoModel model)
        {
            try
            {
                model.UsuarioCreacion = UsuarioLogin().Usuario;
                model.Estado = "RE";
                using (var httpclient = new HttpClient())
                {
                    httpclient.BaseAddress = new Uri(ObtenerURLPuestoService()+ id);
                    HttpResponseMessage response = httpclient.PutAsJsonAsync(httpclient.BaseAddress, model).Result;
                    //response.EnsureSuccessStatusCode();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        Mostrar_Mensaje_Ok("Puesto editado correctamente");
                    else
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // GET: Puesto/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (var httpclient = new HttpClient())
                {
                    httpclient.BaseAddress = new Uri(ObtenerURLPuestoService() + id);
                    HttpResponseMessage response = httpclient.DeleteAsync(httpclient.BaseAddress).Result;
                    //response.EnsureSuccessStatusCode();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        Mostrar_Mensaje_Ok("Puesto eliminado correctamente");
                    else
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError(string.Empty, ex.Message);
                Mostrar_Mensaje_Error("Error: " + ex.Message);
                //return View("Index");
                return RedirectToAction("Index");
            }
        }

        // POST: Puesto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
