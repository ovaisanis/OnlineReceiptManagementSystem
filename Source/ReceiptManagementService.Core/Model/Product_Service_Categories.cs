//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReceiptManagement.Core.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product_Service_Categories
    {
        public Product_Service_Categories()
        {
            this.Product_Service_SubCategories = new HashSet<Product_Service_SubCategories>();
            this.Products_Services = new HashSet<Products_Services>();
        }
    
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
    
        public virtual ICollection<Product_Service_SubCategories> Product_Service_SubCategories { get; set; }
        public virtual ICollection<Products_Services> Products_Services { get; set; }
    }
}
