using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            object val = Session["val"];
            return View("Index", val);
        }

        [HttpPost]
        public ActionResult Put(string value)
        {
            Session["val"] = value;
            Response.Cookies.Add(new HttpCookie("val", value));
            return RedirectToAction("Index");
        }

        public ActionResult Cookie()
        {
            var cookie = Request.Cookies["val"];
            return View((object)cookie.Value);
        }

        public ActionResult Local()
        {
            return View();
        }
    }
}
