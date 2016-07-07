using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace CRM.WebHelper
{
   public class CacheMng
   {
       public static T GetData<T>(string name)where T:class 
       {
           return  HttpRuntime.Cache[name] as T;
       }

       public static void SetData(string name, object obj)
       {
           HttpRuntime.Cache[name] = obj;
       }
    }

}
