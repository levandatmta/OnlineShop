namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Email { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]

        [StringLength(500)]
        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }
    }
}
