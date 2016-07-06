using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WebHelper.attrs
{[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = false)]
    public class Skiploginattr:Attribute
    {
    }
}
