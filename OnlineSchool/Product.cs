//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineSchool
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductCategory = new HashSet<ProductCategory>();
        }
    
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Characteristic { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Lengh { get; set; }
        public byte[] MainPhoto { get; set; }
        public byte[] AdditionallyPhoto { get; set; }
        public int ManufacturerId { get; set; }
        public Nullable<int> PurchaseHistoryId { get; set; }
    
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual PurchaseHistory PurchaseHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
