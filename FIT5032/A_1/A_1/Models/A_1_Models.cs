namespace A_1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class A_1_Models : DbContext
    {
        public A_1_Models()
            : base("name=A_1_Models")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Hall> Hall { get; set; }
        public virtual DbSet<UserInformation> UserInformation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Booking)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Hall)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.OwnerId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.UserInformation)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Booking>()
                .Property(e => e.fee)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Hall>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Hall>()
                .Property(e => e.HallName)
                .IsUnicode(false);

            modelBuilder.Entity<Hall>()
                .Property(e => e.fee)
                .IsUnicode(false);

            modelBuilder.Entity<Hall>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Hall>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hall>()
                .Property(e => e.rating)
                .HasPrecision(1, 0);

            modelBuilder.Entity<Hall>()
                .Property(e => e.latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<Hall>()
                .Property(e => e.longitude)
                .HasPrecision(11, 8);
        }
    }
}
