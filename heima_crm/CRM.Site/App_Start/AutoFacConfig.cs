using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using CRM.Common;
using CRM.IServer;
using CRM.WebHelper;

namespace CRM.Site.App_Start
{
    public class AutoFacConfig
    {
        public static void Register()
        {
            //实例化一个创建容器
            var Builder = new ContainerBuilder();
            //将控制器放到那个程序集
            Assembly controlName=Assembly.Load("CRM.Site");
            Builder.RegisterControllers(controlName);

            //注册仓储类的所有实例对象
            Assembly repoName = Assembly.Load("CRM.Repository");
            //注册程序集中所有类的实例已实现接口存储
            Builder.RegisterTypes(repoName.GetTypes()).AsImplementedInterfaces();

            //注册逻辑层的所有实例对象
            Assembly serverName = Assembly.Load("CRM.Server");
            //注册程序集中所有类的实例已实现接口存储
            Builder.RegisterTypes(serverName.GetTypes()).AsImplementedInterfaces();
            //创建autofac容器
            var c = Builder.Build();
            CacheMng.SetData(Keys.AutofacIContainer,c);

           
            //将mvc的对象实例由automvc来创建
            DependencyResolver.SetResolver(new AutofacDependencyResolver(c));
        }
    }
}