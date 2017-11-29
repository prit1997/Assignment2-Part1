using System.Web;
using System.Web.Mvc;

namespace Assignment2_Part1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Force SSL 
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
