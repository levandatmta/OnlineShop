namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Bills = new HashSet<Bill>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage ="Trường này không được để trống")]
        public string Username { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Password { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Name { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Address { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        [Range(100000000,9999999999,ErrorMessage ="Số điện thoại phải là 10 số")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]

        public DateTime? Birthday { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [Display(Name ="Type(Default = Client)")]
        public int? Type { get; set; }

        public DateTime? CreateDate { get; set; }
        //[Required(ErrorMessage = "Trường này không được để trống")]
        //[Display(Name ="Status(Default = true)")]

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
