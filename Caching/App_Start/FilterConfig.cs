using System.Web;
using System.Web.Mvc;

namespace Chris.Samples.MvcExam.Caching
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}