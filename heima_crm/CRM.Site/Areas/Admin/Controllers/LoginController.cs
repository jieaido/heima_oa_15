using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.IServer;
using CRM.WebHelper;

namespace CRM.Site.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IsysUserInfoServices userInfo)
        {
            base.userinfoSer = userInfo;
        }
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }
    }
}