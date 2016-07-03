namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysFunction")]
    public partial class sysFunction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sysFunction()
        {
            sysPermissList = new HashSet<sysPermissList>();
        }

        [Key]
        public int fID { get; set; }

        public int mID { get; set; }

        [Required]
        [StringLength(100)]
        public string fName { get; set; }

        [Required]
        [StringLength(100)]
        public string fFunction { get; set; }

        [StringLength(100)]
        public string fPicname { get; set; }

        public int? fStatus { get; set; }

        public int fCreatorID { get; set; }

        public DateTime fCreateTime { get; set; }

        public int? fUpdateID { get; set; }

        public DateTime fUpdateTime { get; set; }

        public virtual sysMenus sysMenus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sysPermissList> sysPermissList { get; set; }
    }
}
