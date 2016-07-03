namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wfWorkBranch")]
    public partial class wfWorkBranch
    {
        [Key]
        public int wfbID { get; set; }

        public int wfnID { get; set; }

        [Required]
        [StringLength(20)]
        public string wfnToken { get; set; }

        public int wfNodeID { get; set; }

        public int fCreatorID { get; set; }

        public DateTime fCreateTime { get; set; }

        public int? fUpdateID { get; set; }

        public DateTime fUpdateTime { get; set; }

        public virtual wfWorkNodes wfWorkNodes { get; set; }

        public virtual wfWorkNodes wfWorkNodes1 { get; set; }
    }
}
