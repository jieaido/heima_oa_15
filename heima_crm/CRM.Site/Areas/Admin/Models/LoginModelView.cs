using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Site.Areas.Admin.Models
{
    public class LoginModelView
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage = "用户名不许为空")]
        public string LoginName { get; set; }
        [DisplayName("密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public String LoginPassword { get; set; }
        [DisplayName("验证码")]
        [Required(ErrorMessage = "验证码不能为空")]
        public string Vcode { get; set; }   
    }
}