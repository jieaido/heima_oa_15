namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysPermissList")]
    public partial class sysPermissList
    {
        [Key]
        public int plid { get; set; }

        public int rID { get; set; }

        public int mID { get; set; }

        public int fID { get; set; }

        public int plCreatorID { get; set; }

        public DateTime plCreateTime { get; set; }

        public virtual sysFunction sysFunction { get; set; }

        public virtual sysMenus sysMenus { get; set; }

        public virtual sysRole sysRole { get; set; }
    }
}
