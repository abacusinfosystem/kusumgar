//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KusumgarDatabaseEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_Product
    {
        public int Product_Id { get; set; }
        public string Product_Code { get; set; }
        public int Product_Category_Id { get; set; }
        public int Product_SubCategory_Id { get; set; }
        public string Product_Name { get; set; }
        public string Size { get; set; }
        public string COD { get; set; }
        public int Product_Type { get; set; }
        public bool Original_Manufacturer { get; set; }
        public string Inspection_Facility { get; set; }
        public string Testing_Facility { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}
