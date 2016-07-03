namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wfRequestForm")]
    public partial class wfRequestForm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public wfRequestForm()
        {
            wfProcess = new HashSet<wfProcess>();
        }

        [Key]
        public int wfRFID { get; set; }

        public int wfID { get; set; }

        [Required]
        [StringLength(100)]
        public string wfRFTitle { get; set; }

        [StringLength(1000)]
        public string wfRFRemark { get; set; }

        public int wfRFPriority { get; set; }

        public int wfRFStatus { get; set; }

        [StringLength(100)]
        public string wfRFExt1 { get; set; }

        public int? wfRFExt2 { get; set; }

        [StringLength(2)]
        public string wfRFLogicSymbol { get; set; }

        public decimal wfRFNum { get; set; }

        public int fCreatorID { get; set; }

        public DateTime fCreateTime { get; set; }

        public DateTime? fUpdateTime { get; set; }

        public virtual sysKeyValue sysKeyValue { get; set; }

        public virtual sysKeyValue sysKeyValue1 { get; set; }

        public virtual sysUserInfo sysUserInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfProcess> wfProcess { get; set; }

        public virtual wfWork wfWork { get; set; }
    }
}
