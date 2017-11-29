namespace Assignment1_Apple.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("APPLE")]
    public partial class APPLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public APPLE()
        {
            IPHONEs = new HashSet<IPHONE>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PRODUCT_ID { get; set; }

        public int LOCATION_CODE { get; set; }

        [Required]
        [StringLength(50)]
        public string ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string CITY { get; set; }

        [Required]
        [StringLength(50)]
        public string PROVINCE { get; set; }

        [Required]
        [StringLength(50)]
        public string COUNTRY { get; set; }

        [Required]
        [StringLength(50)]
        public string CUSTOMER_CARE { get; set; }

        [Required]
        [StringLength(50)]
        public string PRODUCTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IPHONE> IPHONEs { get; set; }
    }
}
