namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sysMenus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sysMenus()
        {
            sysFunction = new HashSet<sysFunction>();
            sysPermissList = new HashSet<sysPermissList>();
        }

        [Key]
        public int mID { get; set; }

        public int mParentID { get; set; }

        [Required]
        [StringLength(100)]
        public string mName { get; set; }

        [Required]
        [StringLength(200)]
        public string mUrl { get; set; }

        public string mArea { get; set; }

        public string mController { get; set; }

        public string mAction { get; set; }

        public int mSortid { get; set; }

        public int mStatus { get; set; }

        [Required]
        [StringLength(30)]
        public string mPicname { get; set; }

        public int mLevel { get; set; }

        [StringLength(50)]
        public string mExp1 { get; set; }

        public int? mExp2 { get; set; }

        public int mCreatorID { get; set; }

        public DateTime mCreateTime { get; set; }

        public int? mUpdateID { get; set; }

        public DateTime mUpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysFunction> sysFunction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysPermissList> sysPermissList { get; set; }
    }
}
