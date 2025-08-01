//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdvancedProgramming.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int InventoryID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> UnitsInStock { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string ModifiedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
