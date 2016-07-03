namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysRole")]
    public partial class sysRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sysRole()
        {
            sysPermissList = new HashSet<sysPermissList>();
            sysUserInfo_Role = new HashSet<sysUserInfo_Role>();
        }

        [Key]
        public int rID { get; set; }

        public int? eDepID { get; set; }

        public int RoleType { get; set; }

        [StringLength(50)]
        public string rName { get; set; }

        [StringLength(100)]
        public string rRemark { get; set; }

        public int rSort { get; set; }

        public int rStatus { get; set; }

        public int rCreatorID { get; set; }

        public DateTime rCreateTime { get; set; }

        public int? rUpdateID { get; set; }

        public DateTime rUpdateTime { get; set; }

        public virtual sysKeyValue sysKeyValue { get; set; }

        public virtual sysOrganStruct sysOrganStruct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysPermissList> sysPermissList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysUserInfo_Role> sysUserInfo_Role { get; set; }
    }
}
