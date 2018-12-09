namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Image { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Link { get; set; }
        [Display(Name = "CreateDate (Default = Getnow)")]

        public DateTime? CreateDate { get; set; }
        [Display(Name = "Status(Default = true)")]
        public bool? Status { get; set; }
    }
}
