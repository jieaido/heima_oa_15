using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            SetCatelid();
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

        private void SetCatelid()
        {
          
            var list=new SelectList(keyvalSer.QueryWhere(k => k.KType == 1),"KID","KName",1);
            list.FirstOrDefault().Selected = true;
            ViewData.Add("osCateID", list);
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

        public ActionResult Edit(int id)
        {
            var modellevel = GetLeafIds(id);

            var result = from or1 in organSer.QueryWhere(p => true)
                where !modellevel.Contains(or1)
                select new
                {

                    Text = or1.osName,
                    Value = or1.osID.ToString()
                };
            var enumerable = result as IList ?? result.ToList();
            enumerable.Add(new {Text = "顶级", Value = "-1"});
            var ss=new SelectList(enumerable,"Value","Text");
           
            ViewData.Add("pidd", ss);
            SetCatelid();
            var os = organSer.QueryWhere(s => s.osID == id).FirstOrDefault();
            return View(os);
        }

        [HttpPost]
        public ActionResult Edit(sysOrganStruct model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var ss= from ms in ModelState.Values
                    select new
                    {
                        ms.Errors
                    };
                    return AjaxFail(Json(ss).Data.ToString());

                }
                model.osUpdateTime = DateTime.Now;
                model.osUpdateID = UserManger.GetUserInfoName().uID;
                model.osLevel = GetOrganLevel(model.osParentID);
                organSer.AddOrUpdate(model);
                organSer.SaveChanges();

                return AjaxSuccess("编辑成功!");

            }
            catch (Exception ex)
            {

                return  AjaxError(ex);
            }



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

        public ActionResult del(int id)
        {
            var result = GetLeafIds(id);
            foreach (var sysOrganStruct in result)
            {
                organSer.Delete(sysOrganStruct);
            }
            organSer.Delete(organSer.QueryWhere(o => o.osID == id).FirstOrDefault());
            organSer.SaveChanges();
            
            return  AjaxSuccess("删除成功!");
        }
    }
}