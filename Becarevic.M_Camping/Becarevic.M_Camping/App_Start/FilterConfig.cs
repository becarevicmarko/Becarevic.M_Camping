using System.Web;
using System.Web.Mvc;

namespace Becarevic.M_Camping
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
