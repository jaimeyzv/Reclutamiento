using System.Web;
using System.Web.Mvc;

namespace Metrica.Rrhh.Colaboradores
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
