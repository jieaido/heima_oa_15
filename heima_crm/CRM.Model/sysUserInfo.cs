namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysUserInfo")]
    public partial class sysUserInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sysUserInfo()
        {
            sysUserInfo_Role = new HashSet<sysUserInfo_Role>();
            wfRequestForm = new HashSet<wfRequestForm>();
        }

        [Key]
        public int uID { get; set; }

        [Required]
        [StringLength(100)]
        public string uLoginName { get; set; }

        [Required]
        [StringLength(100)]
        public string uLoginPWD { get; set; }

        [Required]
        [StringLength(100)]
        public string uRealName { get; set; }

        [StringLength(50)]
        public string uTelphone { get; set; }

        [StringLength(15)]
        public string uMobile { get; set; }

        [StringLength(30)]
        public string uEmial { get; set; }

        [StringLength(12)]
        public string uQQ { get; set; }

        public int uGender { get; set; }

        public int uStatus { get; set; }

        public int uCompanyID { get; set; }

        public int? uDepID { get; set; }

        public int? uWorkGroupID { get; set; }

        [StringLength(500)]
        public string uRemark { get; set; }

        public int uCreatorID { get; set; }

        public DateTime uCreateTime { get; set; }

        public int? uUpdateID { get; set; }

        public DateTime uUpdateTime { get; set; }

        public virtual sysOrganStruct sysOrganStruct { get; set; }

        public virtual sysOrganStruct sysOrganStruct1 { get; set; }

        public virtual sysOrganStruct sysOrganStruct2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysUserInfo_Role> sysUserInfo_Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfRequestForm> wfRequestForm { get; set; }
    }
}
