using System.Web;
using System.Web.Mvc;

namespace Chris.Samples.MvcExam.CodeFirst
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}