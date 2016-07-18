using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CRM.IServer;
using CRM.Model;
using CRM.WebHelper;

namespace CRM.Site.Areas.Admin.Controllers
{
    public class OrganStructController : BaseController
    {
        public OrganStructController(IsysOrganStructServices organStructServices, IsysKeyValueServices keyValueServices)
        {
            organSer = organStructServices;
            keyvalSer = keyValueServices;
        }

        // GET: Admin/OrganStruct
        public ActionResult Index()
        {
           // var ss= GetallInts(20);
            return View();
        }

        public ActionResult Getlist()
        {
            var result = from or1 in organSer.QueryWhere(S => true)
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
                var tempitem = new SelectListItem
                {
                    Text = sysKeyValue.KName,
                    Value = sysKeyValue.KID.ToString()
                };
                list.Add(tempitem);
            }
            if (list.Count > 0)
            {
                list[0].Selected = true;
            }
            ViewData.Add("catelid", list);
            var listOrgan = new List<SelectListItem>();
            listOrgan.Add(new SelectListItem {Text = "顶级", Value = "-1"});
            foreach (var organ in organSer.QueryWhere(o => true))
            {
                var tempitem = new SelectListItem
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
                model.osCreateTime = DateTime.Now;
                model.osUpdateID = UserManger.GetUserInfoName().uID;
                model.osUpdateTime = DateTime.Now;
                model.osLevel = GetOrganLevel(model.osParentID);
                organSer.AddOrUpdate(model);
                organSer.SaveChanges();
                return AjaxSuccess("添加成功！");
            }

            return null;
        }

        public ActionResult edit(int id)
        {
            var modellevel = organSer.QueryWhere(o => o.osID == id).FirstOrDefault().osLevel;
            var result = from or1 in organSer.QueryWhere(o => o.osLevel < modellevel)
                select new SelectListItem()
                {
                    
                    Text = or1.osName,
                    Value = or1.osID.ToString()
                };
            ViewData.Add("pidd",result);
            return View();
        }

        [HttpPost]
        public ActionResult edit(sysOrganStruct model)
        {
            return null;
        }

        protected int GetOrganLevel(sysOrganStruct model)
        {
            return GetOrganLevel(model.osParentID);
        }

        protected int GetOrganLevel(int  pid)
        {
            int level = 0;
            var tempmodel = organSer.QueryWhere(o => o.osID == pid).FirstOrDefault();
            while (tempmodel != null)
            {
                level += 1;
                tempmodel = organSer.QueryWhere(o => o.osID == tempmodel.osParentID).FirstOrDefault();
            }
            return level;


        }
        /// <summary>
        /// 获取该组织节点的所有叶子节点
        /// </summary>
        /// <param name="osid"></param>
        /// <returns></returns>
        protected List<sysOrganStruct> GetLeafIds(int osid)
        {
            List<sysOrganStruct> osids=new List<sysOrganStruct>();
            var tempmodel = organSer.QueryWhere(o => o.osParentID == osid);
            foreach (var os1   in tempmodel)
            {
                osids.Add(os1);
               osids.AddRange(GetLeafIds(os1.osID));  
            }
            


            return osids;
        } 

    }
}