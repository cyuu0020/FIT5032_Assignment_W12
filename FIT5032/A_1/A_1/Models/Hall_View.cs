namespace A_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hall_View
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(128)]
        public string OwnerId { get; set; }

        public string Description { get; set; }

        public string HallName { get; set; }

        [StringLength(10)]
        public string fee { get; set; }

        public string Address { get; set; }

        public DateTime? createDate { get; set; }

        public TimeSpan? openTime { get; set; }

        public TimeSpan? closeTime { get; set; }

        [StringLength(1)]
        public string status { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? rating { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? latitude { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? longitude { get; set; }
        [Display(Name = "Rating")]
        public int? rating1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(256)]
        public string UserName { get; set; }
    }
}
