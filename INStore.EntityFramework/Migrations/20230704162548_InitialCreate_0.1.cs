using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INStore.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_01 : Migration
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
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeName = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeAddress = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeDescription = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeePhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeJob = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeShiftStartsAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployeeShiftEndsAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployeeSalary = table.Column<double>(type: "REAL", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoreName = table.Column<string>(type: "TEXT", nullable: false),
                    StorePhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    StoreCurrency = table.Column<int>(type: "INTEGER", nullable: false),
                    storeReceiptSize = table.Column<int>(type: "INTEGER", nullable: false),
                    StoreBarCodeLength = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoreItemPropertiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemNumberInStore = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemNumberInStock = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vendorType = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    AdminPasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    AccountState = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SettingsId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreItemProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    ItemDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ItemBarCode = table.Column<string>(type: "TEXT", nullable: false),
                    ItemSellingPrice = table.Column<double>(type: "REAL", nullable: false),
                    ItemPurchasingPrice = table.Column<double>(type: "REAL", nullable: false),
                    StoreItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItemProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreItemProperties_StoreItems_StoreItemId",
                        column: x => x.StoreItemId,
                        principalTable: "StoreItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VendorName = table.Column<string>(type: "TEXT", nullable: false),
                    VendorPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    VendorAddress = table.Column<string>(type: "TEXT", nullable: false),
                    VendorTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_VendorTypes_VendorTypeId",
                        column: x => x.VendorTypeId,
                        principalTable: "VendorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceiptTotal = table.Column<double>(type: "REAL", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    typeofSellingOperation = table.Column<int>(type: "INTEGER", nullable: false),
                    paymentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChangeAccountInfo = table.Column<bool>(type: "INTEGER", nullable: false),
                    AddDeleteItems = table.Column<bool>(type: "INTEGER", nullable: false),
                    ViewMyStore = table.Column<bool>(type: "INTEGER", nullable: false),
                    ViewEmployeeInfo = table.Column<bool>(type: "INTEGER", nullable: false),
                    ViewVendorsAndCustomersInfo = table.Column<bool>(type: "INTEGER", nullable: false),
                    ViewSettings = table.Column<bool>(type: "INTEGER", nullable: false),
                    ViewDashboard = table.Column<bool>(type: "INTEGER", nullable: false),
                    ViewTools = table.Column<bool>(type: "INTEGER", nullable: false),
                    MakeRefund = table.Column<bool>(type: "INTEGER", nullable: false),
                    CancelOrders = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellingHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceiptID = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    ItemNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemSellingPrice = table.Column<double>(type: "REAL", nullable: false),
                    ItemTotalCost = table.Column<double>(type: "REAL", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellingHistory_Receipts_ReceiptID",
                        column: x => x.ReceiptID,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CustomerId",
                table: "Receipts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_UserID",
                table: "Receipts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SellingHistory_ReceiptID",
                table: "SellingHistory",
                column: "ReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_UserId",
                table: "Settings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreItemProperties_StoreItemId",
                table: "StoreItemProperties",
                column: "StoreItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorTypeId",
                table: "Vendors",
                column: "VendorTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellingHistory");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "StoreItemProperties");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "StoreItems");

            migrationBuilder.DropTable(
                name: "VendorTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
