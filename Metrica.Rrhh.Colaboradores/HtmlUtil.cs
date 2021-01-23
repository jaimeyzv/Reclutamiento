using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metrica.Rrhh.Colaboradores
{
    public static class HtmlUtil
    {
        public static string IdMenuActivo(this HtmlHelper html)
        {
            var routeData = html.ViewContext.RouteData;
            return (string)routeData.Values["controller"] + "Index"; //(string)routeData.Values["action"];
        }

        public static bool MostrarBreadcrumb(this HtmlHelper html)
        {
            var routeData = html.ViewContext.RouteData;
            var routeControl = (string)routeData.Values["controller"];
            return routeControl != "Caso" && routeControl != "Home" && routeControl != "Usuario" && routeControl != "Grupo" && routeControl != "Rol";
        }

        public static string ConvertirAString(this List<ItemModel> items)
        {
            string retval = "";
            foreach (ItemModel item in items)
                retval += item.Valor + ",";
            return retval;
        }

        public static bool HasFile(this HttpPostedFileBase file)
        {
            return file != null && file.ContentLength > 0;
        }
    }


}