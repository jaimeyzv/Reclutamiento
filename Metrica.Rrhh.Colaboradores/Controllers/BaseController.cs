using Metrica.Rrhh.Colaboradores.Common;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Metrica.Rrhh.Colaboradores.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Usuario"] == null)
            {
                filterContext.Result = Redirect("~/Seguridad");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        protected void Mostrar_Mensaje_Ok(string mensaje)
        {
            Mostrar_Mensaje(mensaje, "success");
        }

        protected void Mostrar_Mensaje_Error(string mensaje)
        {
            Mostrar_Mensaje(mensaje, "error");
        }

        protected void Mostrar_Mensaje_Info(string mensaje)
        {
            Mostrar_Mensaje(mensaje, "info");
        }

        private void Mostrar_Mensaje(string mensaje, string tipo)
        {
            TempData["mensaje"] = mensaje;
            TempData["tipo_mensaje"] = tipo;
        }

        protected UsuarioModel UsuarioLogin()
        {
            return (Session["Usuario"] as UsuarioModel);
        }

        protected List<ItemModel> ListarEstadosCiviles()
        {
            return new List<ItemModel> { new ItemModel { Codigo = "S", Valor = "Soltero" }, new ItemModel { Codigo = "C", Valor = "Casado" }, new ItemModel { Codigo = "D", Valor = "Divorciado" }, new ItemModel { Codigo = "V", Valor = "Viudo" } };
        }

        protected List<ItemModel> ListarSexos()
        {
            return new List<ItemModel> { new ItemModel { Codigo = "M", Valor = "Masculino" }, new ItemModel { Codigo = "F", Valor = "Femenino" }};
        }

        protected ActionResult RetornarExcepcion(Exception ex)
        {
            ViewData["Error"] = ex.Message;
            return View("../Shared/Error");
        }

        protected StringWriter ExportarExcel(object data, List<BoundField> columns, string nombreArchivo)
        {
            var grid = new GridView();
            grid.AutoGenerateColumns = false;
            grid.HeaderStyle.BackColor = Color.Black;
            grid.HeaderStyle.ForeColor = Color.White;
            columns.ForEach(x => grid.Columns.Add(x));
            grid.DataSource = data;
            grid.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}_{1}.xls", nombreArchivo, DateTime.Now.ToString("yyyyMMdd")));
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            return sw;
        }

        #region "Metodos para acceder a servicios"
        protected string ObtenerURLPuestoService()
        {
            return Constantes.RutaRest + "PuestoService.svc/";
        }

        protected List<PuestoModel> ListarPuestos(string estado = "", string filtro = "")
        {
            List<PuestoModel> puestos = new List<PuestoModel>();
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri(ObtenerURLPuestoService() + string.Format("?estado={0}&filtro={1}", estado, filtro));
                HttpResponseMessage response = httpclient.GetAsync(httpclient.BaseAddress).Result;
                //response.EnsureSuccessStatusCode();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    puestos = response.Content.ReadAsAsync<List<PuestoModel>>().Result;
                else
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
            }
            return puestos;
        }

        protected WSUtil.IUtilServiceChannel ObtenerServicioUtil()
        {
            return new ServiceClientFactory<WSUtil.IUtilServiceChannel>().Create(Constantes.RutaSoap + "UtilService.svc");
        }

        protected WSRequerimiento.IRequerimientoServiceChannel ObtenerServicioRequerimiento()
        {
            return new ServiceClientFactory<WSRequerimiento.IRequerimientoServiceChannel>().Create(Constantes.RutaSoap + "RequerimientoService.svc");
        }

        protected WSCliente.IClienteServiceChannel ObtenerServicioCliente()
        {
            return new ServiceClientFactory<WSCliente.IClienteServiceChannel>().Create(Constantes.RutaSoap + "ClienteService.svc");
        }

        protected WSPostulacion.IPostulacionServiceChannel ObtenerServicioPostulacion()
        {
            return new ServiceClientFactory<WSPostulacion.IPostulacionServiceChannel>().Create(Constantes.RutaSoap + "PostulacionService.svc");
        }

        protected WSCandidato.ICandidatoServiceChannel ObtenerServicioCandidato()
        {
            return new ServiceClientFactory<WSCandidato.ICandidatoServiceChannel>().Create(Constantes.RutaSoap + "CandidatoService.svc");
        }

        protected WSEmpleado.IEmpleadoServiceChannel ObtenerServicioEmpleado()
        {
            return new ServiceClientFactory<WSEmpleado.IEmpleadoServiceChannel>().Create(Constantes.RutaSoap + "EmpleadoService.svc");
        }
        #endregion

        protected List<ItemModel> ListarEstadoXDominio(int id)
        {
            using (WSUtil.IUtilServiceChannel wsCliente = ObtenerServicioUtil())
                return wsCliente.ListarEstadoXDominio(id).AsModel();
        }

        protected List<ItemModel> ListarDistritos(string ubigeo)
        {
            using (WSUtil.IUtilServiceChannel wsCliente = ObtenerServicioUtil())
                return wsCliente.ListarDistritos(ubigeo).AsModel();
        }

        protected List<ItemModel> ListarSkillTecnico(int idPuesto)
        {
            using (WSUtil.IUtilServiceChannel wsCliente = ObtenerServicioUtil())
                return wsCliente.ListarSkillTecnico(idPuesto).AsModel();
        }

        protected List<ClienteModel> ListarClientes()
        {
            using (WSCliente.IClienteServiceChannel wsCliente = ObtenerServicioCliente())
                return wsCliente.Listar().AsModel();
        }
    }
}