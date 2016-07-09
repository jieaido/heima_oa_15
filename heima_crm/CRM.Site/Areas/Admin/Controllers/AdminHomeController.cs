using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Common;
using CRM.Model;

namespace CRM.Site.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session[Keys.LoginUserinfo]==null)
            {
                return RedirectToRoute(new {Controller = "Home", Action = "Index"});
            }

            var ss = Session[Keys.LoginUserinfo];
            {
              //  var loginuserinfo = Session[Keys.LoginUserinfo] as sysUserInfo;
                return  View();
            }
           
        }
    }
}