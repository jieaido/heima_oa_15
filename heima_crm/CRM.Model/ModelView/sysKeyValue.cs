//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM.Model.ModelView
{
    using System;
    using System.Collections.Generic;
    
    using System.ComponentModel;
     using System.ComponentModel.DataAnnotations;
    public partial class sysKeyValueView
    {
     
    
        public int KID { get; set; }
        public int ParentID { get; set; }
        public int KType { get; set; }
        public string KName { get; set; }
        public string Kvalue { get; set; }
        public string KRemark { get; set; }
    
        public virtual ICollection<sysOrganStructView> sysOrganStruct { get; set; }
        public virtual ICollection<sysRoleView> sysRole { get; set; }
        public virtual ICollection<wfProcessView> wfProcess { get; set; }
        public virtual ICollection<wfRequestFormView> wfRequestForm { get; set; }
        public virtual ICollection<wfRequestFormView> wfRequestForm1 { get; set; }
        public virtual ICollection<wfWorkNodesView> wfWorkNodes { get; set; }
        public virtual ICollection<wfWorkNodesView> wfWorkNodes1 { get; set; }
    }
}
