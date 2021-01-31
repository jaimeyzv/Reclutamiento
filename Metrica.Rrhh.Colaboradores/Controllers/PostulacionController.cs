using Metrica.Rrhh.Colaboradores.BL;
using Metrica.Rrhh.Colaboradores.Common;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Metrica.Rrhh.Colaboradores.Controllers
{
    public class PostulacionController : BaseController
    {
        public ActionResult Index(string estado, string cliente, string filtro_por, int? page)
        {
            if (string.IsNullOrEmpty(cliente))
                cliente = "0";
            ViewBag.estado = estado;
            ViewBag.cliente = cliente;
            ViewBag.filtro_por = filtro_por;
            int paginaActual = (page ?? 1);
            ViewBag.clientes = new SelectList(ListarClientes(), "Id", "RazonSocial");
            using (WSPostulacion.IPostulacionServiceChannel wsCliente = ObtenerServicioPostulacion())
                return View(new PagedList.PagedList<PostulanteModel>(wsCliente.Listar(new PostulanteDTO
                {
                    Estado = estado == "" ? null : estado,
                    IdCliente = int.Parse(cliente),
                    Observacion = filtro_por == "" ? null : filtro_por,
                    Accion = 1

                }).AsModel(), paginaActual, 5));
        }

        public ActionResult Exportar(string estado, string cliente, string filtro_por)
        {
            try
            {
                if (string.IsNullOrEmpty(cliente))
                    cliente = "0";
                using (WSPostulacion.IPostulacionServiceChannel wsCliente = ObtenerServicioPostulacion())
                {
                    List<PostulanteDTO> retval = wsCliente.Listar(new PostulanteDTO
                    {
                        Estado = estado == "" ? null : estado,
                        IdCliente = int.Parse(cliente),
                        Observacion = filtro_por == "" ? null : filtro_por,
                        Accion = 1

                    });
                    List<BoundField> column = new List<BoundField>();
                    column.Add(new BoundField { DataField = "IdRequerimiento", HeaderText = "Nro Req." });
                    column.Add(new BoundField { DataField = "Dni", HeaderText = "DNI" });
                    column.Add(new BoundField { DataField = "NombresCompleto", HeaderText = "Nombres" });
                    column.Add(new BoundField { DataField = "Pretencion", HeaderText = "Pretención Salarial" });
                    column.Add(new BoundField { DataField = "Puesto", HeaderText = "Perfil" });
                    column.Add(new BoundField { DataField = "RazonSocial", HeaderText = "Cliente" });
                    column.Add(new BoundField { DataField = "Disponibilidad", HeaderText = "Disponibilidad" });
                    column.Add(new BoundField { DataField = "Estado", HeaderText = "Estado" });
                    var data = ExportarExcel(retval, column, "Postulaciones");
                    Response.Output.Write(data.ToString());
                    Response.Flush();
                    Response.End();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RetornarExcepcion(ex);
            }
        }
    }
}
