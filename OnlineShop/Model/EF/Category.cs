namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Name { get; set; }

        public long? ParentID { get; set; }

        public int? DisPlayOrder { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }
        [Display(Name ="Default getnow()")]

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
