using INStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace INStore.EntityFramework
{
    public class INStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorType> VendorTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StoreItems> StoreItems { get; set; }
        public DbSet<StoreItemProperties> StoreItemProperties { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SellingHistory> SellingHistory { get; set; }
        public DbSet<Receipts> Receipts { get; set; }
        public INStoreDbContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Store Item / Properties Relation
            // Configure the one-to-one relationship between StoreItems and StoreItemProperties
            modelBuilder.Entity<StoreItems>()
                .HasOne(s => s.Item)
                .WithOne(i => i.StoreItem)
                .HasForeignKey<StoreItemProperties>(i => i.StoreItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region User Relations
            // Configure the one-to-one relationship between User and Employee
            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<User>(u => u.EmployeeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
            // Configure the one-to-one relationship between User and Settings
            modelBuilder.Entity<User>()
                .HasOne(u => u.Settings)
                .WithOne(s => s.User)
                .HasForeignKey<Settings>(s => s.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region SellingHistory Relations
            // Configure the one-to-many relationship between Receipts and SellingHistory
            modelBuilder.Entity<SellingHistory>()
                .HasOne(s => s.Receipt)
                .WithMany(r => r.SoldItems)
                .HasForeignKey(s => s.ReceiptID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Vendor Relations  
            // Configure the one-to-many relationship between Vendor and VendorType
            modelBuilder.Entity<Vendor>()
             .HasOne(r => r.VendorType)
             .WithMany()
             .HasForeignKey(r => r.VendorTypeId)
             .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Receipts Relations
            // Configure the one-to-many relationship between Receipts and Customer
            modelBuilder.Entity<Receipts>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the many-to-one relationship between Receipts and User
            modelBuilder.Entity<Receipts>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the one-to-many relationship between Receipts and SellingHistory
            modelBuilder.Entity<Receipts>()
                .HasMany(r => r.SoldItems)
                .WithOne(s => s.Receipt)
                .HasForeignKey(s => s.ReceiptID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
            base.OnModelCreating(modelBuilder);
        }

    }
}
