using System.Web;
using System.Web.Mvc;

namespace WebUIAngularJS_1_x
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
