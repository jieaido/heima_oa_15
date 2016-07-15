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

             var r2= from permiss1 in permisslist
            select new
            {
                permiss1.plid,
                permiss1.sysMenus.mID,
                permiss1.sysMenus.mName,
                permiss1.sysMenus.mUrl,
                permiss1.sysMenus.mArea,
                permiss1.sysMenus.mController,
                permiss1.sysMenus.mAction,
                permiss1.sysFunction.fID,
                permiss1.sysFunction.fName,
                permiss1.sysFunction.fFunction
            };


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

        public static void getdfd(int id)
        {
            var IContainer = CacheMng.GetData<IContainer>(Keys.AutofacIContainer);
           
            var funlist= IContainer.Resolve<IsysFunctionServices>().QueryWhere(s => true);

            var r1 = GetMenusByUser(id);
        
            var r2 = from menu1 in GetMenusByUser(id)
                join fun1 in funlist on menu1.mID equals fun1.mID
                
                select new
                {
                    menu1.mID,
                    menu1.mAction,
                    menu1.mArea,
                    menu1.mController,
                    menu1.mName,
                    fun1.fFunction,
                    fun1.fName
                };
            return;















        }
    }
}
