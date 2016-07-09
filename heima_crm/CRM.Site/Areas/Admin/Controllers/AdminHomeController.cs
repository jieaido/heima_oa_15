using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Common;
using CRM.IServer;
using CRM.Model;
using CRM.WebHelper;

namespace CRM.Site.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        public AdminHomeController(IsysMenusServices isysMenusServices)
        {
            base.menuSer = isysMenusServices;
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session[Keys.LoginUserinfo]==null)
            {
                return RedirectToRoute(new {Controller = "Home", Action = "Index"});
            }
            ViewBag.menus = GetMenus();
            var ss = Session[Keys.LoginUserinfo];
            {
              //  var loginuserinfo = Session[Keys.LoginUserinfo] as sysUserInfo;
                return  View();
            }
           
        }

        public Node GetMenus()
        {
           Node Nodes=new Node();
           var querymenus= menuSer.QueryOrderBy(m => m.mParentID==-1, m => m.mSortid);
            foreach (var querymenu in querymenus)
            {
               var node= Nodes.Add(new Node() {Nodeitem = querymenu});
                Addchildnode(querymenu.mID,node);
            }
            return Nodes;
        }

        private void Addchildnode(int id,Node node)
        {
            var querymenus = menuSer.QueryOrderBy(m => m.mParentID == id, m => m.mSortid);
            foreach (var querymenu in querymenus)
            {
                var n= node.Add(new Node() {Nodeitem = querymenu});
                Addchildnode(querymenu.mID,n);

            }
        }
    }
}

public class Node
{
    public sysMenus Nodeitem;
    public List<Node> ChildNodes=new List<Node>();

    public Node Add(Node node)
    {
        ChildNodes.Add(node);
        return ChildNodes.Last();
    }
}