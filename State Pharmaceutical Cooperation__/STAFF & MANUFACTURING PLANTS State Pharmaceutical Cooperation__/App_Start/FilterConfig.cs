using System.Web;
using System.Web.Mvc;

namespace STAFF___MANUFACTURING_PLANTS_State_Pharmaceutical_Cooperation__
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
