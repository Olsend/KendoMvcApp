//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KendoMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_state
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_state()
        {
            this.tbl_city = new HashSet<tbl_city>();
        }
    
        public int State_ID { get; set; }
        public Nullable<int> Country_ID { get; set; }
        public string State_Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_city> tbl_city { get; set; }
        public virtual tbl_country tbl_country { get; set; }
    }
}
