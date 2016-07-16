using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.IServer;
using CRM.WebHelper;

namespace CRM.Site.Areas.Admin.Controllers
{
    public class OrganStructController :BaseController
    {

        public OrganStructController(IsysOrganStructServices organStructServices)
        {
            base.organSer = organStructServices;
        }
        // GET: Admin/OrganStruct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Getlist()
        {
            var result= from or1 in organSer.QueryWhere(S => true)
            select new
            {
                or1.osID,
                or1.osParentID,
                or1.osName,
                or1.osCode,
                or1.sysKeyValue.KName,
                or1.osShortName,
                or1.osStatus
            };



            return Json(new {Rows = result, Total = 0});
        }
    }
}