using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INStore.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addingEmployeeToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerAddress = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceipttTotal = table.Column<double>(type: "REAL", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    TypeofSellingOperation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChangeAccountinfo = table.Column<bool>(type: "INTEGER", nullable: true),
                    AddDeleteItems = table.Column<bool>(type: "INTEGER", nullable: true),
                    ViewMYStore = table.Column<bool>(type: "INTEGER", nullable: true),
                    ViewEmployeeInfo = table.Column<bool>(type: "INTEGER", nullable: true),
                    ViewVendorsAndCustomersInfo = table.Column<bool>(type: "INTEGER", nullable: true),
                    ViewSettings = table.Column<bool>(type: "INTEGER", nullable: true),
                    ViewDashboard = table.Column<bool>(type: "INTEGER", nullable: true),
                    ViewTools = table.Column<bool>(type: "INTEGER", nullable: true),
                    MakeRefund = table.Column<bool>(type: "INTEGER", nullable: true),
                    CancelOrders = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoreName = table.Column<string>(type: "TEXT", nullable: true),
                    StorePhoneNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    StoreCurrency = table.Column<int>(type: "INTEGER", nullable: true),
                    StoreRecieptSize = table.Column<int>(type: "INTEGER", nullable: true),
                    StoreBarcodeLength = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreItemProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ItemBarCode = table.Column<string>(type: "TEXT", nullable: true),
                    ItemSellingPrice = table.Column<double>(type: "REAL", nullable: true),
                    ItemPurchasingPrice = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItemProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    AdminPasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    AccountState = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VendorName = table.Column<string>(type: "TEXT", nullable: true),
                    VendorPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    VendorAddress = table.Column<string>(type: "TEXT", nullable: true),
                    VendorType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellingHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceiptId = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemSellingPrice = table.Column<double>(type: "REAL", nullable: true),
                    ItemTotalCost = table.Column<double>(type: "REAL", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemPlace = table.Column<string>(type: "TEXT", nullable: true),
                    ItemNumberInStore = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemNumberInStock = table.Column<int>(type: "INTEGER", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeName = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeAddress = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeDescription = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeePhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeJob = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeShiftStartsAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EmployeeShiftEndsAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EmployeeSalary = table.Column<double>(type: "REAL", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellingHistory_ReceiptId",
                table: "SellingHistory",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreItems_ItemId",
                table: "StoreItems",
                column: "ItemId");
        }

        /// <inheritdoc />
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
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "StoreItemProperties");
        }
    }
}
