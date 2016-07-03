namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysOrganStruct")]
    public partial class sysOrganStruct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sysOrganStruct()
        {
            sysRole = new HashSet<sysRole>();
            sysUserInfo = new HashSet<sysUserInfo>();
            sysUserInfo1 = new HashSet<sysUserInfo>();
            sysUserInfo2 = new HashSet<sysUserInfo>();
        }

        [Key]
        public int osID { get; set; }

        public int osParentID { get; set; }

        [Required]
        [StringLength(100)]
        public string osName { get; set; }

        [Required]
        [StringLength(50)]
        public string osCode { get; set; }

        public int osCateID { get; set; }

        public int? osLevel { get; set; }

        [StringLength(100)]
        public string osShortName { get; set; }

        [StringLength(500)]
        public string osRemark { get; set; }

        public int? osStatus { get; set; }

        public int? osCreatorID { get; set; }

        public DateTime osCreateTime { get; set; }

        public int? osUpdateID { get; set; }

        public DateTime osUpdateTime { get; set; }

        public virtual sysKeyValue sysKeyValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysRole> sysRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysUserInfo> sysUserInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysUserInfo> sysUserInfo1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysUserInfo> sysUserInfo2 { get; set; }
    }
}
