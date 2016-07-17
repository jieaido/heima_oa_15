using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.IServer;
using CRM.Model;
using CRM.WebHelper;
using CRM.WebHelper.attrs;

namespace CRM.Site.Areas.Admin.Controllers
{[Skipcheckpermiss]
    public class OrganStructController :BaseController
    {

        public OrganStructController(IsysOrganStructServices organStructServices,IsysKeyValueServices keyValueServices)
        {
            base.organSer = organStructServices;
            base.keyvalSer = keyValueServices;
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
        [HttpGet]
        public ActionResult add()
        {
            var list = new List<SelectListItem>();
            foreach (var sysKeyValue in keyvalSer.QueryWhere(k => k.KType == 1))
            {
                var tempitem = new SelectListItem()
                {
                    Text = sysKeyValue.KName,
                    Value = sysKeyValue.KID.ToString()
                };
                list.Add(tempitem);
            }
            if (list.Count>0)
            {
                list[0].Selected = true;
            }
            ViewData.Add("catelid",list);
            var listOrgan = new List<SelectListItem>();
            listOrgan.Add(new SelectListItem() {Text ="顶级",Value = "-1"});
            foreach (var organ in organSer.QueryWhere(o => true))
            {
                var tempitem = new SelectListItem()
                {
                    Text = organ.osName,
                    Value = organ.osID.ToString()
                };
                listOrgan.Add(tempitem);
            }
            ViewData.Add("pid", listOrgan);
            
            return View();
        }
        [HttpPost]
    public ActionResult add(sysOrganStruct model)
        {
            if (ModelState.IsValid)
            {
                model.osCreatorID = UserManger.GetUserInfoName().uID;
                model.osCreateTime=DateTime.Now;
                model.osUpdateID = UserManger.GetUserInfoName().uID;
                model.osUpdateTime=DateTime.Now;
                model.osLevel = 1;
                organSer.AddOrUpdate(model);
                organSer.SaveChanges();
                return AjaxSuccess("添加成功！");
            }
           
            return null;

        }
    }
}