using Metrica.Rrhh.Colaboradores.BL;
using Metrica.Rrhh.Colaboradores.Common;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using Metrica.Rrhh.Colaboradores.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metrica.Rrhh.Colaboradores.Controllers
{
    public class CandidatoController : BaseController
    {
        // GET: Candidato
        public ActionResult Index(string estado, string puesto, string fecha_ini, string fecha_fin, string filtro_por, int? page)
        {
            try
            {
                if (fecha_ini == null)
                {
                    fecha_ini = DateTime.Now.AddDays(-90).ToString("yyyy-MM-dd");
                    fecha_fin = DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (string.IsNullOrEmpty(puesto))
                    puesto = "0";
                ViewBag.estado = estado;
                ViewBag.puesto = puesto;
                ViewBag.fecha_ini = fecha_ini;
                ViewBag.fecha_fin = fecha_fin;
                ViewBag.filtro_por = filtro_por;
                int paginaActual = (page ?? 1);
                ViewBag.puestos = new SelectList(ListarPuestos(), "Id", "Nombre");
                using (WSCandidato.ICandidatoServiceChannel wsCliente = ObtenerServicioCandidato())
                    return View(new PagedList.PagedList<CandidatoModel>(wsCliente.Listar(new CandidatoDTO
                    {
                        FechaCreacion = DateTime.Parse(fecha_ini),
                        FechaModificacion = DateTime.Parse(fecha_fin).AddDays(1),
                        Estado = estado,
                        IdPuesto = int.Parse(puesto),
                        Observacion = filtro_por == "" ? null : filtro_por
                    }).AsModel(), paginaActual, 5));
            }catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new PagedList.PagedList<CandidatoModel>(new List<CandidatoModel>(), 1, 1));
            }
        }

        // GET: Candidato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidato/Create
        public ActionResult Create()
        {
            try
            {
                CandidatoViewModel model = new CandidatoViewModel();
                model.Sexos = ListarSexos();
                model.EstadosCiviles = ListarEstadosCiviles();
                model.Distritos = ListarDistritos("000001");
                model.Puestos = ListarPuestos();
                model.Skill = ListarSkillTecnico(model.Puestos[0].Id);
                model.FechaNacimiento = DateTime.Now.AddYears(-20);
                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // POST: Candidato/Create
        [HttpPost]
        public ActionResult Create(CandidatoViewModel model)
        {
            try
            {
                CandidatoModel data = model;
                if (model.Adjunto.HasFile())
                {
                    data.Cv = model.Dni + Path.GetExtension(model.Adjunto.FileName);
                    if (System.IO.File.Exists(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv)))
                        System.IO.File.Delete(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv));
                    model.Adjunto.SaveAs(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv));
                }
                data.Estado = "RE";
                data.UsuarioCreacion = UsuarioLogin().Usuario;
                data.Experiencias = data.Experiencias.Where(x => x.Accion != 0).ToList();
                data.Estudios = data.Estudios.Where(x => x.Accion != 0).ToList();
                using (WSCandidato.ICandidatoServiceChannel wsCliente = ObtenerServicioCandidato())
                    wsCliente.Insertar(data.AsDTO());
                Mostrar_Mensaje_Ok("Candidato guardado correctamente");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.Sexos = ListarSexos();
                model.EstadosCiviles = ListarEstadosCiviles();
                model.Distritos = ListarDistritos("000001");
                model.Puestos = ListarPuestos();
                model.Skill = ListarSkillTecnico(model.IdPuesto);
                return View(model);
                //return Create();
            }
        }

        // GET: Candidato/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                CandidatoViewModel model = null;
                using (WSCandidato.ICandidatoServiceChannel wsCliente = ObtenerServicioCandidato())
                    model = new CandidatoViewModel(wsCliente.Obtener(new CandidatoDTO { Dni = id }).AsModel());
                model.Sexos = ListarSexos();
                model.Accion = 2;
                if (!string.IsNullOrEmpty(model.Cv))
                    model.Cv = Path.Combine(ConfigurationManager.AppSettings.Get("rutaWebDoc"), "CV", model.Cv);
                model.EstadosCiviles = ListarEstadosCiviles();
                model.Distritos = ListarDistritos("000001");
                model.Puestos = ListarPuestos();
                model.Skill = ListarSkillTecnico(model.IdPuesto);
                return View(model);
            }
            catch (Exception ex)
            {
                return RetornarExcepcion(ex);
            }
        }

        // POST: Candidato/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, CandidatoViewModel model)
        {
            try
            {
                CandidatoModel data = model;
                data.Dni = id;
                if (model.Adjunto.HasFile())
                {
                    data.Cv = model.Dni + Path.GetExtension(model.Adjunto.FileName);
                    if (System.IO.File.Exists(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv)))
                        System.IO.File.Delete(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv));
                    model.Adjunto.SaveAs(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv));
                }
                //data.Estado = "RE";
                data.Experiencias = data.Experiencias.Where(x => x.Accion != 0).ToList();
                data.Estudios = data.Estudios.Where(x => x.Accion != 0).ToList();
                data.UsuarioModificacion = UsuarioLogin().Usuario;
                using (WSCandidato.ICandidatoServiceChannel wsCliente = ObtenerServicioCandidato())
                    wsCliente.Actualizar(data.AsDTO());
                Mostrar_Mensaje_Ok("Candidato actualizado correctamente");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.Sexos = ListarSexos();
                model.EstadosCiviles = ListarEstadosCiviles();
                model.Distritos = ListarDistritos("000001");
                model.Puestos = ListarPuestos();
                model.Skill = ListarSkillTecnico(model.IdPuesto);
                return View(model);
            }
        }

        // GET: Candidato/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                using (WSCandidato.ICandidatoServiceChannel wsCliente = ObtenerServicioCandidato())
                    wsCliente.Eliminar(new CandidatoDTO { Dni = id, UsuarioModificacion = UsuarioLogin().Usuario });
                Mostrar_Mensaje_Ok("Candidato eliminado correctamente.");
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

        // POST: Candidato/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
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

        [HttpGet]
        public JsonResult SkillTecnico(int id)
        {
            try
            {
                return Json(new { Success = true, Message = "Correcto", Data = ListarSkillTecnico(id) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message, Data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Para registar postulante en RequerimientoController
        [HttpGet]
        public JsonResult CandidatoPostulante(string estado, int puesto, string filtro)
        {
            try
            {
                using (WSCandidato.ICandidatoServiceChannel wsCliente = ObtenerServicioCandidato())
                    return Json(new { Success = true, Message = "Correcto", Data = wsCliente.Listar(new CandidatoDTO { Estado = estado, IdPuesto = puesto, Observacion = filtro }).AsModel() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message, Data = "" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
