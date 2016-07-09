using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CRM.Common;
using CRM.Model;

namespace CRM.WebHelper
{
    public class UserManger
    {
        public static sysUserInfo GetUserInfoName()
        {
            var userinfo = HttpContext.Current.Session[Keys.LoginUserinfo] == null
                ? null
                : HttpContext.Current.Session[Keys.LoginUserinfo] as sysUserInfo;
            return userinfo;
        }
    }
}
