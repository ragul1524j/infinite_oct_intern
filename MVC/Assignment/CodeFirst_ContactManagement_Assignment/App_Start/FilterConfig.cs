using System.Web;
using System.Web.Mvc;

namespace CodeFirst_ContactManagement_Assignment
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
