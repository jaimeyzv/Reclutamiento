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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Metrica.Rrhh.Colaboradores.Controllers
{
    public class EmpleadoController : BaseController
    {
        // GET: Empleado
        public ActionResult Index(string estado, string cliente, string puesto, string filtro_por, int? page)
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

        // GET: Empleado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            try
            {
                CandidatoViewModel model = new CandidatoViewModel();
                model.EsEmpleado = true;
                model.FechaIniContrato = DateTime.Now;
                model.Clientes = ListarClientes();
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
                return RetornarExcepcion(ex);
            }
        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Create(CandidatoViewModel model)
        {
            try
            {
                EmpleadoModel data = model;
                if (model.Adjunto.HasFile())
                {
                    data.Cv = model.Dni + Path.GetExtension(model.Adjunto.FileName);
                    if (System.IO.File.Exists(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv)))
                        System.IO.File.Delete(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv));
                    model.Adjunto.SaveAs(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv));
                }
                data.Estado = "RE";
                data.Cliente = new ClienteModel { Id = model.IdCliente };
                data.UsuarioCreacion = UsuarioLogin().Usuario;
                data.Experiencias = data.Experiencias.Where(x => x.Accion != 0).ToList();
                data.Estudios = data.Estudios.Where(x => x.Accion != 0).ToList();
                using (WSEmpleado.IEmpleadoServiceChannel wsCliente = ObtenerServicioEmpleado())
                    wsCliente.Insertar(data.AsDTO());
                Mostrar_Mensaje_Ok("Empleado guardado correctamente");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
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

        // GET: Empleado/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                using (WSEmpleado.IEmpleadoServiceChannel wsCliente = ObtenerServicioEmpleado())
                {
                    CandidatoViewModel model = new CandidatoViewModel(wsCliente.Obtener(new EmpleadoDTO { Dni = id }).AsModel());
                    model.Sexos = ListarSexos();
                    model.Accion = 2;
                    if (!string.IsNullOrEmpty(model.Cv))
                        model.Cv = Path.Combine(ConfigurationManager.AppSettings.Get("rutaWebDoc"), "CV", model.Cv);
                    model.EstadosCiviles = ListarEstadosCiviles();
                    model.Distritos = ListarDistritos("000001");
                    model.Puestos = ListarPuestos();
                    model.Clientes = ListarClientes();
                    model.Skill = ListarSkillTecnico(model.IdPuesto);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return RetornarExcepcion(ex);
            }
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, CandidatoViewModel model)
        {
            try
            {
                EmpleadoModel data = model;
                data.Dni = id;
                if (model.Adjunto.HasFile())
                {
                    data.Cv = model.Dni + Path.GetExtension(model.Adjunto.FileName);
                    if (System.IO.File.Exists(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv)))
                        System.IO.File.Delete(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv));
                    model.Adjunto.SaveAs(Path.Combine(ConfigurationManager.AppSettings.Get("rutaLocalDoc"), "CV", data.Cv));
                }
                //data.Estado = "RE";
                data.Cliente = new ClienteModel { Id = model.IdCliente };
                data.Experiencias = data.Experiencias.Where(x => x.Accion != 0).ToList();
                data.Estudios = data.Estudios.Where(x => x.Accion != 0).ToList();
                data.UsuarioModificacion = UsuarioLogin().Usuario;
                using (WSEmpleado.IEmpleadoServiceChannel wsCliente = ObtenerServicioEmpleado())
                    wsCliente.Actualizar(data.AsDTO());
                Mostrar_Mensaje_Ok("Empleado actualizado correctamente");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.Sexos = ListarSexos();
                model.Clientes = ListarClientes();
                model.EstadosCiviles = ListarEstadosCiviles();
                model.Distritos = ListarDistritos("000001");
                model.Puestos = ListarPuestos();
                model.Skill = ListarSkillTecnico(model.IdPuesto);
                return View(model);
            }
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                using (WSEmpleado.IEmpleadoServiceChannel wsCliente = ObtenerServicioEmpleado())
                    wsCliente.Eliminar(new EmpleadoDTO { Dni = id, UsuarioModificacion = UsuarioLogin().Usuario });
                Mostrar_Mensaje_Ok("Contrato cancelado correctamente.");
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

        // POST: Empleado/Delete/5
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

        public ActionResult Exportar(string estado, string cliente, string puesto, string filtro_por)
        {
            try
            {
                if (estado == "-")
                    estado = null;
                if (filtro_por == "-")
                    filtro_por = null;
                using (WSEmpleado.IEmpleadoServiceChannel wsCliente = ObtenerServicioEmpleado())
                {
                    List<EmpleadoModel> retval = wsCliente.Listar(new EmpleadoDTO
                    {
                        Cliente = new ClienteDTO { Id = int.Parse(cliente) },
                        Estado = estado,
                        IdPuesto = int.Parse(puesto),
                        Observacion = filtro_por == "" ? null : filtro_por
                    }).AsModel();
                    List<BoundField> column = new List<BoundField>();
                    column.Add(new BoundField { DataField = "Dni", HeaderText = "DNI" });
                    column.Add(new BoundField { DataField = "Usuario", HeaderText = "Usuario" });
                    column.Add(new BoundField { DataField = "NombresCompleto", HeaderText = "Nombres" });
                    column.Add(new BoundField { DataField = "Pretencion", HeaderText = "Sueldo" });
                    column.Add(new BoundField { DataField = "Puesto", HeaderText = "Puesto" });
                    column.Add(new BoundField { DataField = "Cliente", HeaderText = "Cliente" });
                    column.Add(new BoundField { DataField = "TelefonoPersonal", HeaderText = "Telefono" });
                    column.Add(new BoundField { DataField = "FechaIniContrato", HeaderText = "Inicio Contrato" });
                    column.Add(new BoundField { DataField = "FechaFinContrato", HeaderText = "Fin Contrato" });
                    column.Add(new BoundField { DataField = "TotalVacaciones", HeaderText = "Vacaciones Pendientes" });
                    var data = ExportarExcel(retval, column, "Empleado");
                    Response.Output.Write(data.ToString());
                    Response.Flush();
                    Response.End();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RetornarExcepcion(ex);
            }
        }
    }
}
