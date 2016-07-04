using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;

namespace CRM.Repository
{
    public class BaseDbContext:CRMContext

    {
        public BaseDbContext() :base()
        {
            
        }
    }
}
