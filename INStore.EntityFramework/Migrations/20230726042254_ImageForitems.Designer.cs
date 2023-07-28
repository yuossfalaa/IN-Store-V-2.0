﻿// <auto-generated />
using System;
using INStore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace INStore.EntityFramework.Migrations
{
    [DbContext(typeof(INStoreDbContext))]
    [Migration("20230726042254_ImageForitems")]
    partial class ImageForitems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("INStore.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("INStore.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmployeeAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeJob")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeePhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("EmployeeSalary")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("EmployeeShiftEndsAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EmployeeShiftStartsAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("INStore.Domain.Models.Receipts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReceiptDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("ReceiptTotal")
                        .HasColumnType("REAL");

                    b.Property<int?>("UserID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("paymentStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("typeofSellingOperation")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserID");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("INStore.Domain.Models.SellingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ItemNumber")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ItemSellingPrice")
                        .HasColumnType("REAL");

                    b.Property<double>("ItemTotalCost")
                        .HasColumnType("REAL");

                    b.Property<int>("ReceiptID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptID");

                    b.ToTable("SellingHistory");
                });

            modelBuilder.Entity("INStore.Domain.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AddDeleteItems")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CancelOrders")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ChangeAccountInfo")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MakeRefund")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ViewDashboard")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ViewEmployeeInfo")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ViewMyStore")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ViewSettings")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ViewTools")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ViewVendorsAndCustomersInfo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("INStore.Domain.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoreBarCodeLength")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoreCurrency")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StorePhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("storeReceiptSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("INStore.Domain.Models.StoreItemProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemBarCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ItemPurchasingPrice")
                        .HasColumnType("REAL");

                    b.Property<double>("ItemSellingPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("StoreItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StoreItemId")
                        .IsUnique();

                    b.ToTable("StoreItemProperties");
                });

            modelBuilder.Entity("INStore.Domain.Models.StoreItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemNumberInStock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemNumberInStore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoreItemPropertiesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("StoreItems");
                });

            modelBuilder.Entity("INStore.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdminPasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SettingsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("INStore.Domain.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VendorAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VendorPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("VendorTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VendorTypeId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("INStore.Domain.Models.VendorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("vendorType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VendorTypes");
                });

            modelBuilder.Entity("INStore.Domain.Models.Receipts", b =>
                {
                    b.HasOne("INStore.Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("INStore.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("INStore.Domain.Models.SellingHistory", b =>
                {
                    b.HasOne("INStore.Domain.Models.Receipts", "Receipt")
                        .WithMany("SoldItems")
                        .HasForeignKey("ReceiptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("INStore.Domain.Models.Settings", b =>
                {
                    b.HasOne("INStore.Domain.Models.User", "User")
                        .WithOne("Settings")
                        .HasForeignKey("INStore.Domain.Models.Settings", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("INStore.Domain.Models.StoreItemProperties", b =>
                {
                    b.HasOne("INStore.Domain.Models.StoreItems", "StoreItem")
                        .WithOne("Item")
                        .HasForeignKey("INStore.Domain.Models.StoreItemProperties", "StoreItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoreItem");
                });

            modelBuilder.Entity("INStore.Domain.Models.User", b =>
                {
                    b.HasOne("INStore.Domain.Models.Employee", "Employee")
                        .WithOne("User")
                        .HasForeignKey("INStore.Domain.Models.User", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("INStore.Domain.Models.Vendor", b =>
                {
                    b.HasOne("INStore.Domain.Models.VendorType", "VendorType")
                        .WithMany()
                        .HasForeignKey("VendorTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("VendorType");
                });

            modelBuilder.Entity("INStore.Domain.Models.Employee", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("INStore.Domain.Models.Receipts", b =>
                {
                    b.Navigation("SoldItems");
                });

            modelBuilder.Entity("INStore.Domain.Models.StoreItems", b =>
                {
                    b.Navigation("Item")
                        .IsRequired();
                });

            modelBuilder.Entity("INStore.Domain.Models.User", b =>
                {
                    b.Navigation("Settings")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
