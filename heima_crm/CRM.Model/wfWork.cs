namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wfWork")]
    public partial class wfWork
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public wfWork()
        {
            wfRequestForm = new HashSet<wfRequestForm>();
            wfWorkNodes = new HashSet<wfWorkNodes>();
        }

        [Key]
        public int wfID { get; set; }

        [Required]
        [StringLength(50)]
        public string wfTitle { get; set; }

        public int wfStatus { get; set; }

        [StringLength(200)]
        public string wfRemark { get; set; }

        public int fCreatorID { get; set; }

        public DateTime fCreateTime { get; set; }

        public int? fUpdateID { get; set; }

        public DateTime fUpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfRequestForm> wfRequestForm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfWorkNodes> wfWorkNodes { get; set; }
    }
}
