using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CRM.Common;
using CRM.IServer;
using CRM.Site.Areas.Admin.Models;
using CRM.WebHelper;

namespace CRM.Site.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IsysUserInfoServices userInfo)
        {
            base.userinfoSer = userInfo;
        }
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModelView lmv)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return AjaxFail("验证错误");
                }
                if (Session[Keys.Vcode].ToString() == null || !string.Equals(Session[Keys.Vcode].ToString(), lmv.Vcode, StringComparison.OrdinalIgnoreCase))
                {
                   return  AjaxFail("验证码错误");
                }
                var userinfo =
                    userinfoSer.QueryWhere(u => u.uLoginName == lmv.LoginName && u.uLoginPWD == lmv.LoginPassword)
                        .FirstOrDefault();
                if ( userinfo== null)
                {
                 return   AjaxFail("用户名密码错误");
                }
                Session[Keys.LoginUserinfo] = userinfo;
                return AjaxSuccess("登陆成功");
            }
            catch (Exception exception)
            {
                return AjaxError(exception);
            }
            return View();

        }
        public ActionResult Vcode()
        {
            string vcode = GetVcode(4);
            Session[Keys.Vcode] = vcode;
            byte[] bytes;
            using (Image img = new Bitmap(100, 45))
            {
                Graphics g = Graphics.FromImage(img);
                InstalledFontCollection ifc = new InstalledFontCollection();

                g.DrawString(vcode, new Font(ifc.Families[2], 20), new SolidBrush(Color.Teal), 4, 4);
               
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Png);
                    bytes = ms.ToArray();
                };
               

            }
            
          
            return File(bytes,"image/png");
        }

        private string GetVcode(int p  )
        {
            Random rand=new Random();
            string str = "ABCDEFGHKLMNQPZXRYW234578";
            StringBuilder result=new StringBuilder();
            for (int i = 0; i < p; i++)
            {
                result.Append(str[rand.Next(str.Length)]);
            }
            return result.ToString();

        }
    }
}