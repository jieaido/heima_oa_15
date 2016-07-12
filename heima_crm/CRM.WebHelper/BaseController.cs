using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CRM.Common;
using CRM.IServer;


namespace CRM.WebHelper
{
    public class BaseController:Controller
    {
        protected IsysFunctionServices funSer;
        protected IsysKeyValueServices keyvalSer;
        protected IsysMenusServices menuSer;
        protected IsysOrganStructServices organSer;
        protected IsysPermissListServices permissSer;
        protected IsysRoleServices roleSer;
        protected IsysUserInfoServices userinfoSer;
        protected IsysUserInfo_RoleServices userinfoRoleSer;
        protected IwfProcessServices processSer;
        protected IwfRequestFormServices requestformSer;
        protected IwfWorkServices workSer;
        protected IwfWorkBranchServices workbranchSer;
        protected IwfWorkNodesServices worknodesSer;

        protected ActionResult AjaxSuccess(string message)
        {
            return Json(new { Status = (int)AjaxResultEnums.Success, msg = message });
        }
        protected ActionResult AjaxNologin(string message)
        {
            return Json(new { Status = (int)AjaxResultEnums.NoLogin, msg = message });
        }
        protected ActionResult AjaxError(Exception ex)
        {
            return Json(new { Status = (int)AjaxResultEnums.Error, msg = ex.Message });
        }
        protected ActionResult AjaxFail(string msg)
        {
            return Json(new { Status = (int)AjaxResultEnums.Fail, msg = msg });
        }
    }
}
