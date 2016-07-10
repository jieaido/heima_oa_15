using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.IServer;
using CRM.WebHelper;

namespace CRM.Site.Areas.Admin.Controllers
{
    public class KeyValController : BaseController
    {
        public KeyValController(IsysKeyValueServices iSysKeyValueServices)
        {
            base.keyvalSer = iSysKeyValueServices;
        }
        // GET: Admin/KeyVal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetKeyVallist()
        {
            var query = keyvalSer.QueryOrderBy(m => true, m => m.KID);
            //todo 一定记得select ，要不然报循环引用错误
            var jsondata = from sysKeyValue in query
                           select new
                           {
                               sysKeyValue.KID,
                               sysKeyValue.KType,
                               sysKeyValue.KName,
                               sysKeyValue.Kvalue
                           };


            return Json(new { Rows = jsondata, Total = "12" },JsonRequestBehavior.AllowGet);
        }
    }
}