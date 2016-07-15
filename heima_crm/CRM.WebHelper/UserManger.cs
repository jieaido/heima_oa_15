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
using CRM.Model.ModelView;

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

        /// <summary>
        /// 根据用户id获取做菜单项
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static IEnumerable<sysMenus> GetMenusByUser(int uid)
        {
            var IContainer = CacheMng.GetData<IContainer>(Keys.AutofacIContainer);
            IsysUserInfoServices userInfoServices = IContainer.Resolve<IsysUserInfoServices>();
            HashSet<sysMenus> menulList = new HashSet<sysMenus>();
            var permisslist = userInfoServices.GetPermissListByUser(uid);


            foreach (var sysPermissList in permisslist)
            {
                menulList.Add(sysPermissList.sysMenus);
            }


            return menulList;
        }

        /// <summary>
        /// 根据用户id和url查找菜单下的功能按钮
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IEnumerable<sysFunction> GetFunctionsByUser(int uid, string url)
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

        /// <summary>
        /// 根据用户id获取用户的权限
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static IEnumerable<PermissMenuFunModel> GetPermissMenuFun(int uid)
        {
            var container = CacheMng.GetData<IContainer>(Keys.AutofacIContainer);
            IsysUserInfoServices userInfoServices = container.Resolve<IsysUserInfoServices>();
            var permisslist = userInfoServices.GetPermissListByUser(uid);
            var result = from permiss1 in permisslist
                select new PermissMenuFunModel()
                {
                    pid = permiss1.plid,
                    mid = permiss1.sysMenus.mID,
                    mName = permiss1.sysMenus.mName,
                    murl = permiss1.sysMenus.mUrl,
                    marea = permiss1.sysMenus.mArea,
                    mcontroller = permiss1.sysMenus.mController,
                    maction = permiss1.sysMenus.mAction,
                    fid = permiss1.sysFunction.fID,
                    fname = permiss1.sysFunction.fName,
                    ffuntion = permiss1.sysFunction.fFunction
                };

            return result;
        }
    }
}