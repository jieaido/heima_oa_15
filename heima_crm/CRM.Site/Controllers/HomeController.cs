using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.EntityMapping;
using CRM.IServer;

namespace CRM.Site.Controllers
{
    public class HomeController : Controller
    {
        private IsysUserInfoServices _sysUserInfo;

        public HomeController(IsysUserInfoServices sysUserInfo )
        {
            _sysUserInfo = sysUserInfo;
        }
        public ActionResult Index()
        {
            var sv = _sysUserInfo.QueryOrderBy(x => true, x => x.uID).Select(s=>s.EntityMap());
            return View(sv);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}