//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsEffectDatabaseConn
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee
    {
        public employee()
        {
            this.employees1 = new HashSet<employee>();
        }
    
        public int employeeid { get; set; }
        public Nullable<int> fk_departments_dept_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public Nullable<int> managerid { get; set; }
    
        public virtual department department { get; set; }
        public virtual ICollection<employee> employees1 { get; set; }
        public virtual employee employee1 { get; set; }
    }
}