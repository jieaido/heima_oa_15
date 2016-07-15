using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Autofac;
using CRM.Common;
using CRM.IServer;
using CRM.WebHelper.attrs;

namespace CRM.WebHelper.Filter
{
  
    public class CheckPermissionAttr:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.ActionDescriptor.IsDefined(typeof(SkipcheckpermissAttribute),false)||filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipcheckpermissAttribute),false))
            {
                return;
            }

            string getactionname = filterContext.ActionDescriptor.ActionName.ToLower();
            string getcontrollername = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            string areasname = "";
            if (filterContext.RequestContext.RouteData.DataTokens.ContainsKey("area"))
            {
                areasname = filterContext.RequestContext.RouteData.DataTokens["area"].ToString().ToLower();
            }

             var  Permissmenufun= UserManger.GetPermissMenuFun(UserManger.GetUserInfoName().uID);
            bool tempok1 = Permissmenufun.Any(p => p.murl.ToLower() == filterContext.HttpContext.Request.RawUrl.ToLower());
            bool tempok2 =
                Permissmenufun.Any(
                    p =>
                        p.marea.ToLower() == areasname && p.mcontroller.ToLower() == getcontrollername &&
                        p.ffuntion.ToLower() == getactionname.ToLower());
            if (tempok1||tempok2)
            {
                return;
            }
           

           

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    JsonResult jsonResult = new JsonResult();
                    jsonResult.Data = new {Status = (int) AjaxResultEnums.Error, msg = "没有权限"};
                    jsonResult.JsonRequestBehavior=JsonRequestBehavior.AllowGet;
                    filterContext.Result = jsonResult;
                }
                else
                {
                    ViewResult view = new ViewResult();
                    view.ViewName = "/Areas/admin/Views/login/nologin.cshtml";
                    filterContext.Result = view;
                }


               

            
            
            base.OnActionExecuting(filterContext);
        }
    }
}
