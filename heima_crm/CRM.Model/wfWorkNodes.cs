namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class wfWorkNodes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public wfWorkNodes()
        {
            wfProcess = new HashSet<wfProcess>();
            wfWorkBranch = new HashSet<wfWorkBranch>();
            wfWorkBranch1 = new HashSet<wfWorkBranch>();
        }

        [Key]
        public int wfnID { get; set; }

        public int wfID { get; set; }

        public int wfnOrderNo { get; set; }

        public int wfNodeType { get; set; }

        [Required]
        [StringLength(50)]
        public string wfNodeTitle { get; set; }

        [StringLength(1000)]
        public string wfnBizMethod { get; set; }

        public decimal wfnMaxNum { get; set; }

        public int wfnRoleType { get; set; }

        public int? wfnExt1 { get; set; }

        [StringLength(100)]
        public string wfnExt2 { get; set; }

        public int fCreatorID { get; set; }

        public DateTime fCreateTime { get; set; }

        public int? fUpdateID { get; set; }

        public DateTime? fUpdateTime { get; set; }

        public virtual sysKeyValue sysKeyValue { get; set; }

        public virtual sysKeyValue sysKeyValue1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfProcess> wfProcess { get; set; }

        public virtual wfWork wfWork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfWorkBranch> wfWorkBranch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfWorkBranch> wfWorkBranch1 { get; set; }
    }
}
