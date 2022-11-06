﻿using INStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace INStore.EntityFramework
{
    public class INStoreDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<StoreItems> StoreItems { get; set; }
        public DbSet<StoreItemProperties> StoreItemProperties { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SellingHistory> SellingHistory { get; set; }
        public DbSet<Receipts> Receipts { get; set; }
        public INStoreDbContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
