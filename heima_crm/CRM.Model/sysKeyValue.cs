namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysKeyValue")]
    public partial class sysKeyValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sysKeyValue()
        {
            sysOrganStruct = new HashSet<sysOrganStruct>();
            sysRole = new HashSet<sysRole>();
            wfProcess = new HashSet<wfProcess>();
            wfRequestForm = new HashSet<wfRequestForm>();
            wfRequestForm1 = new HashSet<wfRequestForm>();
            wfWorkNodes = new HashSet<wfWorkNodes>();
            wfWorkNodes1 = new HashSet<wfWorkNodes>();
        }

        [Key]
        public int KID { get; set; }

        public int ParentID { get; set; }

        public int KType { get; set; }

        [Required]
        [StringLength(100)]
        public string KName { get; set; }

        [StringLength(20)]
        public string Kvalue { get; set; }

        [StringLength(100)]
        public string KRemark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysOrganStruct> sysOrganStruct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysRole> sysRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfProcess> wfProcess { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfRequestForm> wfRequestForm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfRequestForm> wfRequestForm1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfWorkNodes> wfWorkNodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wfWorkNodes> wfWorkNodes1 { get; set; }
    }
}
