namespace A_1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Hall_View_Models : DbContext
    {
        public Hall_View_Models()
            : base("name=Hall_View_Models")
        {
        }

        public virtual DbSet<Hall_View> Hall_View { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall_View>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Hall_View>()
                .Property(e => e.HallName)
                .IsUnicode(false);

            modelBuilder.Entity<Hall_View>()
                .Property(e => e.fee)
                .IsUnicode(false);

            modelBuilder.Entity<Hall_View>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Hall_View>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hall_View>()
                .Property(e => e.rating)
                .HasPrecision(1, 0);

            modelBuilder.Entity<Hall_View>()
                .Property(e => e.latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<Hall_View>()
                .Property(e => e.longitude)
                .HasPrecision(11, 8);
        }
    }
}
