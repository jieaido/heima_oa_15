namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sysUserInfo_Role
    {
        [Key]
        public int urID { get; set; }

        public int uID { get; set; }

        public int rID { get; set; }

        public virtual sysRole sysRole { get; set; }

        public virtual sysUserInfo sysUserInfo { get; set; }
    }
}
