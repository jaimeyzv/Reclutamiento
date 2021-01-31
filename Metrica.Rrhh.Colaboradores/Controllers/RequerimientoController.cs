using Metrica.Rrhh.Colaboradores.BL;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using Metrica.Rrhh.Colaboradores.Models;
using Metrica.Rrhh.Colaboradores.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace Metrica.Rrhh.Colaboradores.Controllers
{
    public class RequerimientoController : BaseController
    {
        // GET: Requerimiento
        public ActionResult Index(string est_pe, string cliente, string fecha_ini, string fecha_fin, string filtro_por,   int? page)
        {
            try
            {
                if (fecha_ini == null)
                {
                    fecha_ini = DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd");
                    fecha_fin = DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (string.IsNullOrEmpty(cliente))
                    cliente = "0";
                ViewBag.est_pe = est_pe;
                ViewBag.cliente = cliente;
                ViewBag.fecha_ini = fecha_ini;
                ViewBag.fecha_fin = fecha_fin;
                ViewBag.filtro_por = filtro_por;
                ViewBag.clientes = new SelectList(ListarClientes(), "Id", "RazonSocial");
                int paginaActual = (page ?? 1);

                using (WSRequerimiento.IRequerimientoServiceChannel wsCliente = ObtenerServicioRequerimiento())
                {
                    return View(new PagedList.PagedList<RequerimientoModel>(wsCliente.Listar(new RequerimientoDTO
                    {
                        FechaCreacion = DateTime.Parse(fecha_ini),
                        FechaModificacion = DateTime.Parse(fecha_fin).AddDays(1),
                        Estado = est_pe == "" ? null : est_pe,
                        Cliente = new ClienteDTO { Id = int.Parse(cliente) },
                        Descripcion = filtro_por == "" ? null : filtro_por

                    }).AsModel(), paginaActual, 5));
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new PagedList.PagedList<RequerimientoModel>(new List<RequerimientoModel>(), 1, 1));
            }
        }

        // GET: Requerimiento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Requerimiento/Create
        public ActionResult Create()
        {
            try
            {
                RequerimientoViewModel model = new RequerimientoViewModel();
                model.FechaTentativa = DateTime.Now;
                model.Estados = ListarEstadoXDominio(Constantes.Estados.Requerimiento);
                model.Clientes = ListarClientes();
                model.NombreCliente = model.Clientes[0].RazonSocial;
                return View(model);
            }
            catch(Exception ex)
            {
                return View(ex);
            }
            
        }

        // POST: Requerimiento/Create
        [HttpPost]
        public ActionResult Create(RequerimientoViewModel model)
        {
            try
            {
                RequerimientoModel data = model;
                model.UsuarioCreacion = UsuarioLogin().Usuario;
                model.Estado = "RE";
                data.Cliente = new ClienteModel { Id = model.IdCliente, RazonSocial = model.NombreCliente };
                int response;
                using(WSRequerimiento.IRequerimientoServiceChannel wsCliente = ObtenerServicioRequerimiento())
                    response = wsCliente.Insertar(data.AsDTO());
                Mostrar_Mensaje_Ok("Requerimiento guardado correctamente" + (response == -99? ", pero hubo error el enviar email" : "."));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.Clientes = ListarClientes();
                model.Estados = ListarEstadoXDominio(Constantes.Estados.Requerimiento);
                return View(model);
            }
        }

        // GET: Requerimiento/Edit/5
        public ActionResult Edit(int id)
        {
            RequerimientoViewModel model;
            using (WSRequerimiento.IRequerimientoServiceChannel wsCliente = ObtenerServicioRequerimiento())
                model = new RequerimientoViewModel(wsCliente.Obtener(new RequerimientoDTO { Id = id }).AsModel());
            model.Clientes = ListarClientes();
            model.Estados = ListarEstadoXDominio(Constantes.Estados.Requerimiento);
            return View(model);
        }

        // POST: Requerimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RequerimientoViewModel model)
        {
            try
            {
                RequerimientoModel req = new RequerimientoModel();
                req.Id = model.Id;
                req.Perfil = model.Perfil;
                req.Cliente = new ClienteModel { Id = model.IdCliente};
                req.Estado = model.Estado;
                req.FechaTentativa = model.FechaTentativa;
                req.RangoSalario = model.RangoSalario;
                req.Descripcion = model.Descripcion;
                req.OrdenCompra = model.OrdenCompra;
                req.Postulaciones = model.Postulaciones;
                req.UsuarioModificacion = UsuarioLogin().Usuario;
                using (WSRequerimiento.IRequerimientoServiceChannel wsCliente = ObtenerServicioRequerimiento())
                    wsCliente.Actualizar(req.AsDTO());
                Mostrar_Mensaje_Ok("Requerimiento actualizado correctamente.");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.Clientes = ListarClientes();
                model.Estados = ListarEstadoXDominio(Constantes.Estados.Requerimiento);
                return View(model);
            }
        }

        // GET: Requerimiento/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (WSRequerimiento.IRequerimientoServiceChannel wsCliente = ObtenerServicioRequerimiento())
                    wsCliente.Eliminar(new RequerimientoDTO { Id = id, UsuarioModificacion = UsuarioLogin().Usuario});
                Mostrar_Mensaje_Ok("Requerimiento eliminado correctamente.");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //ModelState.AddModelError(string.Empty, ex.Message);
                Mostrar_Mensaje_Error("Error: " + ex.Message);
                //return View("Index");
                return RedirectToAction("Index");
            }
        }

        // POST: Requerimiento/Delete/5
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

        public ActionResult Postulantes(int id)
        {
            try
            {
                RequerimientoViewModel model;
                using (WSRequerimiento.IRequerimientoServiceChannel wsCliente = ObtenerServicioRequerimiento())
                    model = new RequerimientoViewModel(wsCliente.Obtener(new RequerimientoDTO { Id = id }).AsModel());
                
                ViewBag.puestos = new SelectList(ListarPuestos(), "Id", "Nombre");
                return View(model);
            }catch(Exception ex)
            {
                return RetornarExcepcion(ex);
            }
        }

        [HttpPost]
        public JsonResult Postulantes(int id, PostulanteModel model)
        {
            try
            {
                if (model.Accion == 1)
                {
                    model.IdRequerimiento = id;
                    model.FechaPostulacion = DateTime.Now;
                    model.UsuarioCreacion = UsuarioLogin().Usuario;
                    model.Estado = "RE";
                    using (WSPostulacion.IPostulacionServiceChannel wsCliente = ObtenerServicioPostulacion())
                        wsCliente.Insertar(model.AsDTO());
                }
                else
                {
                    model.IdRequerimiento = id;
                    model.UsuarioModificacion = UsuarioLogin().Usuario;
                    if (model.Accion == 2)
                        using (WSPostulacion.IPostulacionServiceChannel wsCliente = ObtenerServicioPostulacion())
                            wsCliente.Actualizar(model.AsDTO());
                    else
                    {
                        model.Estado = "AP";
                        using (WSPostulacion.IPostulacionServiceChannel wsCliente = ObtenerServicioPostulacion())
                            wsCliente.Aprobar(model.AsDTO());
                    }
                }
                return Json(new { Success = true, Message = "Correcto", Data = model});
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}
