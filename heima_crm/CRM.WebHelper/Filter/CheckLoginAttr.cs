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
  
    public class CheckLoginAttr:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.ActionDescriptor.IsDefined(typeof(SkipLoginAttribute),false)||filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipLoginAttribute),false))
            {
                return;
            }
            if (filterContext.HttpContext.Session[Keys.LoginUserinfo] == null )
            {
                var httpCookie = filterContext.HttpContext.Request.Cookies[Keys.IsRemember];
                if (httpCookie != null)
                {
                    string uid = httpCookie.Value;
                    if (uid!="")
                    {
                        int userid = int.Parse(uid);
                        var IContainer= CacheMng.GetData<IContainer>(Keys.AutofacIContainer);
                        IsysUserInfoServices userInfoServices = IContainer.Resolve<IsysUserInfoServices>();
                        var userinfo = userInfoServices.QueryWhere(u => u.uID == userid).FirstOrDefault();
                        if (userinfo!=null)
                        {
                            HttpContext.Current.Session[Keys.LoginUserinfo] = userinfo;
                            return;
                        }
                    }

                }

                ViewResult view = new ViewResult();
                view.ViewName = "/Areas/admin/Views/login/nologin.cshtml";
                filterContext.Result = view;

            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}
