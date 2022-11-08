using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INStore.EntityFramework.Migrations
{
    public partial class @int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeShiftStartsAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeShiftEndsAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeSalary = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceipttTotal = table.Column<double>(type: "float", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeofSellingOperation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeAccountinfo = table.Column<bool>(type: "bit", nullable: true),
                    AddDeleteItems = table.Column<bool>(type: "bit", nullable: true),
                    ViewMYStore = table.Column<bool>(type: "bit", nullable: true),
                    ViewEmployeeInfo = table.Column<bool>(type: "bit", nullable: true),
                    ViewVendorsAndCustomersInfo = table.Column<bool>(type: "bit", nullable: true),
                    ViewSettings = table.Column<bool>(type: "bit", nullable: true),
                    ViewDashboard = table.Column<bool>(type: "bit", nullable: true),
                    ViewTools = table.Column<bool>(type: "bit", nullable: true),
                    MakeRefund = table.Column<bool>(type: "bit", nullable: true),
                    CancelOrders = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorePhoneNumber = table.Column<int>(type: "int", nullable: true),
                    StoreCurrency = table.Column<int>(type: "int", nullable: true),
                    StoreRecieptSize = table.Column<int>(type: "int", nullable: true),
                    StoreBarcodeLength = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreItemProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemBarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSellingPrice = table.Column<double>(type: "float", nullable: true),
                    ItemPurchasingPrice = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItemProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountState = table.Column<bool>(type: "bit", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellingHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<int>(type: "int", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber = table.Column<int>(type: "int", nullable: true),
                    ItemSellingPrice = table.Column<double>(type: "float", nullable: true),
                    ItemTotalCost = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellingHistory_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    ItemPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumberInStore = table.Column<int>(type: "int", nullable: true),
                    ItemNumberInStock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreItems_StoreItemProperties_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StoreItemProperties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellingHistory_ReceiptId",
                table: "SellingHistory",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreItems_ItemId",
                table: "StoreItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SellingHistory");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "StoreItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "StoreItemProperties");
        }
    }
}
