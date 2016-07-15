﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Common;
using CRM.IServer;
using CRM.Model;
using CRM.WebHelper;
using CRM.WebHelper.attrs;

namespace CRM.Site.Areas.Admin.Controllers
{   [Skipcheckpermiss]
    public class AdminHomeController : BaseController
    {
        public AdminHomeController(IsysMenusServices isysMenusServices)
        {
            base.menuSer = isysMenusServices;
           
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session[Keys.LoginUserinfo]==null)
            {
                return RedirectToRoute(new {Controller = "Home", Action = "Index"});
            }
            ViewBag.menus = MenuManger.GetMenus();
            var ss = Session[Keys.LoginUserinfo];
            {
              //  var loginuserinfo = Session[Keys.LoginUserinfo] as sysUserInfo;
                return  View();
            }
           
        }

        
      
    }
}

