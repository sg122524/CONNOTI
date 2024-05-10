using System.Web;
using System.Web.Mvc;

namespace CONNOTI_PROYECTO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
