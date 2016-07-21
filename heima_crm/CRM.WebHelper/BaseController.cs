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
        /// <summary>
        /// 返回成功ajax
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ActionResult AjaxSuccess(string message)
        {
            return Json(new { Status = (int)AjaxResultEnums.Success, msg = message });
        }
        /// <summary>
        /// 返回未登陆ajax
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ActionResult AjaxNologin(string message)
        {
            return Json(new { Status = (int)AjaxResultEnums.NoLogin, msg = message });
        }
        /// <summary>
        /// 返回ex故障
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected ActionResult AjaxError(Exception ex)
        {
            return Json(new { Status = (int)AjaxResultEnums.Error, msg = ex.Message });
        }
        /// <summary>
        /// 返回逻辑错误ajax
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ActionResult AjaxFail(string msg)
        {
            return Json(new { Status = (int)AjaxResultEnums.Fail, msg = msg });
        }
    }
}
