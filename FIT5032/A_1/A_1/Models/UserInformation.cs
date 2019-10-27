namespace A_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInformation")]
    public partial class UserInformation
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        public DateTime? createDate { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
