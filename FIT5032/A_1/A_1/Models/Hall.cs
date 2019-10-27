namespace A_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hall")]
    public partial class Hall
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hall()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }

        [StringLength(128)]
        public string OwnerId { get; set; }

        public string Description { get; set; }


        [Display(Name = "Hall Name")]
        [Required(ErrorMessage = "Please enter a hall name.")]
        public string HallName { get; set; }

        [StringLength(10)]
        [Display(Name = "Fee")]
        [Required(ErrorMessage = "Please enter the fee of the hall.")]
        public string fee { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an address")]
        public string Address { get; set; }

        public DateTime? createDate { get; set; }

        public TimeSpan? openTime { get; set; }

        public TimeSpan? closeTime { get; set; }

        [StringLength(1)]
        public string status { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? rating { get; set; }

        [Column(TypeName = "numeric")]
        [Range(-90, 90, ErrorMessage = "range between -90 and 90")]

        public decimal? latitude { get; set; }

        [Column(TypeName = "numeric")]
        [Range(-180, 180, ErrorMessage = "range between -180 and 180")]
        public decimal? longitude { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
