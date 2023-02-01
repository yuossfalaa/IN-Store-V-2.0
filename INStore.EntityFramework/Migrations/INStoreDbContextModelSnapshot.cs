﻿// <auto-generated />
using System;
using INStore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace INStore.EntityFramework.Migrations
{
    [DbContext(typeof(INStoreDbContext))]
    partial class INStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("INStore.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerPhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("INStore.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmployeeAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeJob")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeePhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<double?>("EmployeeSalary")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("EmployeeShiftEndsAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EmployeeShiftStartsAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("INStore.Domain.Models.Receipts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReceiptDate")
                        .HasColumnType("TEXT");

                    b.Property<double?>("ReceipttTotal")
                        .HasColumnType("REAL");

                    b.Property<string>("TypeofSellingOperation")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("INStore.Domain.Models.SellingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ItemNumber")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("ItemSellingPrice")
                        .HasColumnType("REAL");

                    b.Property<double?>("ItemTotalCost")
                        .HasColumnType("REAL");

                    b.Property<int?>("ReceiptId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptId");

                    b.ToTable("SellingHistory");
                });

            modelBuilder.Entity("INStore.Domain.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("AddDeleteItems")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("CancelOrders")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ChangeAccountinfo")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("MakeRefund")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ViewDashboard")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ViewEmployeeInfo")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ViewMYStore")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ViewSettings")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ViewTools")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ViewVendorsAndCustomersInfo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("INStore.Domain.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StoreBarcodeLength")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StoreCurrency")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StoreName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StorePhoneNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StoreRecieptSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("INStore.Domain.Models.StoreItemProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemBarCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<double?>("ItemPurchasingPrice")
                        .HasColumnType("REAL");

                    b.Property<double?>("ItemSellingPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("StoreItemProperties");
                });

            modelBuilder.Entity("INStore.Domain.Models.StoreItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ItemNumberInStock")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ItemNumberInStore")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemPlace")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("StoreItems");
                });

            modelBuilder.Entity("INStore.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountState")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminPasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("INStore.Domain.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("VendorAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("VendorName")
                        .HasColumnType("TEXT");

                    b.Property<string>("VendorPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("VendorType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("INStore.Domain.Models.SellingHistory", b =>
                {
                    b.HasOne("INStore.Domain.Models.Receipts", "Receipt")
                        .WithMany("SoldItems")
                        .HasForeignKey("ReceiptId");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("INStore.Domain.Models.StoreItems", b =>
                {
                    b.HasOne("INStore.Domain.Models.StoreItemProperties", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("INStore.Domain.Models.Receipts", b =>
                {
                    b.Navigation("SoldItems");
                });
#pragma warning restore 612, 618
        }
    }
}
