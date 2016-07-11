using System.Web;
using System.Web.Mvc;
using CRM.WebHelper.Filter;

namespace CRM.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new  CheckLoginAttr());
        }
    }
}
