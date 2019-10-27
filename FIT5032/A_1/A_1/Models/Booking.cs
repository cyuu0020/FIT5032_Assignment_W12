namespace A_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
     
    [Table("Booking")]
    public partial class Booking
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string CustomerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BookingDate { get; set; }

        public TimeSpan? BookingTime { get; set; }

        public int? hallId { get; set; }

        [StringLength(10)]
        public string fee { get; set; }


        [Display(Name = "Rating")]
        [Range(0, 5, ErrorMessage = "range between 0 and 5")]
        public int? rating { get; set; }

        public string comment { get; set; }

        public DateTime? ratingDate { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        public DateTime? createDate { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
