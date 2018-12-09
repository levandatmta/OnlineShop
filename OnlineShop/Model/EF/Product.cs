namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
            ProductColors = new HashSet<ProductColor>();
            ProductSizes = new HashSet<ProductSize>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Code { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Description { get; set; }

        [StringLength(500)]
        public string Detail { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [Range(0,(double)9999999999,ErrorMessage ="Trường nhập vào phải là số")]

        public decimal? Price { get; set; }
        [Display(Name ="Default = 0")]
        [Range(0, (double)100, ErrorMessage = "Trường nhập vào phải là số")]
        public int? Discount { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [Range(0, (double)100, ErrorMessage = "Trường nhập vào phải là số nhỏ hơn 100")]
        public int? Quantity { get; set; }
        public long? CategoryID { get; set; }

        [StringLength(10)]
        public string MetaTile { get; set; }

        public long? ProducerID { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]

        public int? Warranty { get; set; }
        [Display(Name ="Default = true")]

        public bool? Status { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public DateTime? TopHot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual Category Category { get; set; }

        public virtual Producer Producer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductColor> ProductColors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
