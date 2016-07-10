using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.IServer;
using CRM.Model;
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

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add([Bind(Include = "KType,KName,Kvalue,KRemark")]sysKeyValue model)
        {
            if (ModelState.IsValid)
            {
                return AjaxFail("实体验证失败");
            }
            model.ParentID = 0;
            keyvalSer.AddOrUpdate(model);
            keyvalSer.SaveChanges();
            return base.AjaxSuccess("good");
        }
        public ActionResult GetKeyVallist()
        {
            string quertstr = HttpContext.Request["KName"];
            int pagesize = Convert.ToInt32(HttpContext.Request["pagesize"]);
            int pageindex= Convert.ToInt32(HttpContext.Request["page"]);
            int rowscout;
            IEnumerable<sysKeyValue> query;
            if (quertstr!=null)
            {
               
                query = keyvalSer.QueryByPage(m => m.KName.Contains(quertstr), m => m.KType, pagesize, pageindex,
                    out rowscout);
            }
            else
            {
                query = keyvalSer.QueryByPage(m =>true, m => m.KType, pagesize, pageindex,
                    out rowscout);
            }
          
            //todo 一定记得select ，要不然报循环引用错误
            var jsondata = from sysKeyValue in query
                           select new
                           {
                               sysKeyValue.KID,
                               sysKeyValue.KType,
                               sysKeyValue.KName,
                               sysKeyValue.Kvalue
                           };


            return Json(new { Rows = jsondata, Total = rowscout }
            );
        }
    }
}