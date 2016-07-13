using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.WebHelper;

namespace CRM.Site.Areas.Admin.Controllers
{
    public class FunctionController : Controller
    {
        // GET: Admin/Function
        public ActionResult GetFunctionsByUser(string url)
        {

           var function=  UserManger.GetFunctionsByUser(UserManger.GetUserInfoName().uID, url);
            List<object> menuNodes=new List<object>();
            foreach (var sysFunction in function)
            {
                MenuNode mn = new MenuNode()
                {
                    text = sysFunction.fName,
                    click = sysFunction.fFunction,
                    icon = sysFunction.fPicname
                };
                menuNodes.Add(mn);
                menuNodes.Add(new MenuLine()
                {
                    line = "true"
                });
            }

            return Json(menuNodes);
        }
    }
                            //{ text: '增加', click: add, icon: 'add' },
                            //{ line: true },
                            //{ text: '修改', click: edit, icon: 'modify' },
                            //{ line: true },
                            //{ text: '删除', click: del }
    public class MenuNode
    {
        public string text;
        public string click;
        public string icon;
    }

    public class MenuLine
    {
        public string line;
    }
}