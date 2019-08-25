namespace DataService.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ATVEntities : DbContext
    {
        public ATVEntities()
            : base("name=ATVEntities")
        {
        }

        public virtual DbSet<BusinessLog> BusinessLogs { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractDetail> ContractDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Duration> Durations { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<PriceTag> PriceTags { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleHasMenuItem> RoleHasMenuItems { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractDetail>()
                .Property(e => e.ProductName)
                .IsFixedLength();

            modelBuilder.Entity<CustomerType>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.CustomerType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuItem>()
                .HasMany(e => e.RoleHasMenuItems)
                .WithRequired(e => e.MenuItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleHasMenuItems)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
