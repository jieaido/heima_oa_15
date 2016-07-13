using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;

namespace CRM.WebHelper
{
    public static class MenuManger
    {
        public static  Node GetMenus()
        {
            var ss = UserManger.GetMenusByUser(UserManger.GetUserInfoName().uID);
            Node nodes = new Node();
            var querymenus = ss.Where(m => m.mParentID == -1).OrderBy(m => m.mSortid);
            // var querymenus= menuSer.QueryOrderBy(m => m.mParentID==-1, m => m.mSortid);
            foreach (var querymenu in querymenus)
            {
                var node = nodes.Add(new Node() { Nodeitem = querymenu });
                Addchildnode(querymenu.mID, node);
            }
            return nodes;
        }

        private static void Addchildnode(int id, Node node)
        {
            var ss = UserManger.GetMenusByUser(UserManger.GetUserInfoName().uID);
            var querymenus = ss.Where(m => m.mParentID == id).OrderBy(m => m.mSortid);
            foreach (var querymenu in querymenus)
            {
                var n = node.Add(new Node() { Nodeitem = querymenu });
                Addchildnode(querymenu.mID, n);

            }
        }
    }
    public class Node
    {
        public sysMenus Nodeitem;
        public List<Node> ChildNodes = new List<Node>();

        public Node Add(Node node)
        {
            ChildNodes.Add(node);
            return ChildNodes.Last();
        }
    }
}
