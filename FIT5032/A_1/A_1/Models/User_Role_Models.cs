namespace A_1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class User_Role_Models : DbContext
    {
        public User_Role_Models()
            : base("name=User_Role_Models")
        {
        }

        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
