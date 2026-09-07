using System.Web;
using System.Web.Mvc;

namespace SUPPLIERS_State_pharmaceutical_Cooperation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
