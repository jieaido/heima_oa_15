namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wfProcess")]
    public partial class wfProcess
    {
        [Key]
        public int wfPID { get; set; }

        public int wfRFID { get; set; }

        public int wfProcessor { get; set; }

        public int wfRFStatus { get; set; }

        [StringLength(200)]
        public string wfPDescription { get; set; }

        public int wfnID { get; set; }

        [StringLength(100)]
        public string wfPExt1 { get; set; }

        public int? wfPExt2 { get; set; }

        public int fCreatorID { get; set; }

        public DateTime fCreateTime { get; set; }

        public DateTime? fUpdateTime { get; set; }

        public virtual sysKeyValue sysKeyValue { get; set; }

        public virtual wfRequestForm wfRequestForm { get; set; }

        public virtual wfWorkNodes wfWorkNodes { get; set; }
    }
}
