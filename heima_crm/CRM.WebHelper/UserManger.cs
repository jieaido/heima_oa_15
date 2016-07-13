using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Autofac;
using CRM.Common;
using CRM.IServer;
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

        public static IEnumerable<sysMenus> GetMenusByUser(int uid)
        {
            var IContainer = CacheMng.GetData<IContainer>(Keys.AutofacIContainer);
            IsysUserInfoServices userInfoServices = IContainer.Resolve<IsysUserInfoServices>();
            HashSet<sysMenus> menulList=new HashSet<sysMenus>();
            var permisslist= userInfoServices.GetPermissListByUser(uid);
            
            foreach (var sysPermissList in permisslist)
            {
                menulList.Add(sysPermissList.sysMenus);
            }
            
            return menulList;
        }

        public static IEnumerable<sysFunction> GetFunctionsByUser(int uid,string url)
        {

            var IContainer = CacheMng.GetData<IContainer>(Keys.AutofacIContainer);
            IsysUserInfoServices userInfoServices = IContainer.Resolve<IsysUserInfoServices>();
            var permisslist = userInfoServices.GetPermissListByUser(uid);
            HashSet<sysFunction> sysFunctions = new HashSet<sysFunction>();
            foreach (var sysPermissList in permisslist)
            {
                if (sysPermissList.sysMenus.mUrl.ToLower() == url.ToLower())
                {
                    sysFunctions.Add(sysPermissList.sysFunction);
                }
               
            }
            return sysFunctions;

        } 
    }
}
