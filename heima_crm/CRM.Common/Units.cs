using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common
{
    public  static class Units
    {
        // ReSharper disable once InconsistentNaming
        public static string MD5Encryt(string msg)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 md = MD5.Create())
            {
                var data = md.ComputeHash(Encoding.UTF8.GetBytes(msg));


                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                foreach (var t in data)
                {
                    sBuilder.Append(t.ToString("x2"));
                }
            }


            return sBuilder.ToString();

        }
    }
}
