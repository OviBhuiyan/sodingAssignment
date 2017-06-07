using System.Web;
using System.Web.Mvc;

namespace SODING_INDIVIDUAL_ASSIGNMENT
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
