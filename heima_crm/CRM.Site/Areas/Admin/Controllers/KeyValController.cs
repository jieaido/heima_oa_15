using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.IServer;
using CRM.Model;
using CRM.Model.ModelView;
using CRM.WebHelper;
using CRM.WebHelper.attrs;

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
            if (!ModelState.IsValid)
            {
                return AjaxFail("实体验证失败");
            }
            model.ParentID = 0;
            keyvalSer.AddOrUpdate(model);
            keyvalSer.SaveChanges();
            return base.AjaxSuccess("good");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            /*todo 这个参数最好用id，用其他的比如kid会报错误    <title>对于“CRM.Site.Areas.Admin.Controllers.KeyValController”中方法“System.Web.Mvc.ActionResult Edit
            (Int32)”的不可以为 null 的类型“System.Int32”的参数“kid”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。< br > 参数*/

            var model = keyvalSer.QueryWhere(s => s.KID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "KID,KType,KName,Kvalue,KRemark")]sysKeyValue model)
        {
            if (!ModelState.IsValid)
            {
                return AjaxFail("实体验证失败");
            }
            
            keyvalSer.AddOrUpdate(model);
            keyvalSer.SaveChanges();
            return AjaxSuccess("修改成功");
        }

        public ActionResult Delete(string id)
        {
           
           
            string[] ids = id.Split(',');
            foreach (var m_id in ids)
            {
                if (!string.IsNullOrEmpty(m_id))
                {
                    int Tempid = int.Parse(m_id);
                    keyvalSer.Delete(keyvalSer.QueryWhere(s => s.KID == Tempid).FirstOrDefault());
                }
              
            }
            keyvalSer.SaveChanges();
            return AjaxSuccess("成功");
        }

        [Skipcheckpermiss]
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