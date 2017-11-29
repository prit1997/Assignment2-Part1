namespace Assignment1_Apple.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IPHONE")]
    public partial class IPHONE
    {
        [Key]
        [StringLength(50)]
        public string SERIAL_NO { get; set; }

        public int PRODUCT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PRODUCT_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string PRODUCT_SERIES { get; set; }

        [Required]
        [StringLength(50)]
        public string PRODUCT_STORAGE { get; set; }

        [Required]
        [StringLength(50)]
        public string PRODUCT_PROCESSOR { get; set; }

        public virtual APPLE APPLE { get; set; }
    }
}
