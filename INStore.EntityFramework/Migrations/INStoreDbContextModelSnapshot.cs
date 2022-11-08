﻿// <auto-generated />
using System;
using INStore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("INStore.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("INStore.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmployeeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("EmployeeSalary")
                        .HasColumnType("float");

                    b.Property<DateTime?>("EmployeeShiftEndsAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EmployeeShiftStartsAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("INStore.Domain.Models.Receipts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceiptDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("ReceipttTotal")
                        .HasColumnType("float");

                    b.Property<string>("TypeofSellingOperation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("INStore.Domain.Models.SellingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemNumber")
                        .HasColumnType("int");

                    b.Property<double?>("ItemSellingPrice")
                        .HasColumnType("float");

                    b.Property<double?>("ItemTotalCost")
                        .HasColumnType("float");

                    b.Property<int?>("ReceiptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptId");

                    b.ToTable("SellingHistory");
                });

            modelBuilder.Entity("INStore.Domain.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("AddDeleteItems")
                        .HasColumnType("bit");

                    b.Property<bool?>("CancelOrders")
                        .HasColumnType("bit");

                    b.Property<bool?>("ChangeAccountinfo")
                        .HasColumnType("bit");

                    b.Property<bool?>("MakeRefund")
                        .HasColumnType("bit");

                    b.Property<bool?>("ViewDashboard")
                        .HasColumnType("bit");

                    b.Property<bool?>("ViewEmployeeInfo")
                        .HasColumnType("bit");

                    b.Property<bool?>("ViewMYStore")
                        .HasColumnType("bit");

                    b.Property<bool?>("ViewSettings")
                        .HasColumnType("bit");

                    b.Property<bool?>("ViewTools")
                        .HasColumnType("bit");

                    b.Property<bool?>("ViewVendorsAndCustomersInfo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("INStore.Domain.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("StoreBarcodeLength")
                        .HasColumnType("int");

                    b.Property<int?>("StoreCurrency")
                        .HasColumnType("int");

                    b.Property<string>("StoreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StorePhoneNumber")
                        .HasColumnType("int");

                    b.Property<int?>("StoreRecieptSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("INStore.Domain.Models.StoreItemProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ItemBarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ItemPurchasingPrice")
                        .HasColumnType("float");

                    b.Property<double?>("ItemSellingPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("StoreItemProperties");
                });

            modelBuilder.Entity("INStore.Domain.Models.StoreItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemNumberInStock")
                        .HasColumnType("int");

                    b.Property<int?>("ItemNumberInStore")
                        .HasColumnType("int");

                    b.Property<string>("ItemPlace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("StoreItems");
                });

            modelBuilder.Entity("INStore.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("AccountState")
                        .HasColumnType("bit");

                    b.Property<string>("AdminPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("INStore.Domain.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("VendorAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorType")
                        .HasColumnType("nvarchar(max)");

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
