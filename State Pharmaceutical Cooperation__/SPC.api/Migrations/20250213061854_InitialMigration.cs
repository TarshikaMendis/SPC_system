using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPC.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Inventory_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drug_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturing_Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Stock_Quantity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Supplier_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Expiry_Date = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unit_Price = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Last_Restock_Date = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Batch_Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders_Details",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pharmacy_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Drug_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Batch_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity_Ordered = table.Column<int>(type: "int", nullable: false),
                    Unit_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total_Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Details", x => x.Order_Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

    

            migrationBuilder.CreateTable(
                name: "StaffManufacturing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffManufacturing", x => x.id);
                });

           

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenderApprovals",
                columns: table => new
                {
                    ApprovalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderID = table.Column<int>(type: "int", nullable: false),
                    DrugName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderApprovals", x => x.ApprovalId);
                });

            migrationBuilder.CreateTable(
                name: "TenderProposal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DrugName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProposedDeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderProposal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    TenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuantityRequired = table.Column<int>(type: "int", nullable: false),
                    TenderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.TenderID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");


            migrationBuilder.DropTable(
                name: "Inventory_Details");

            migrationBuilder.DropTable(
                name: "Orders_Details");

            migrationBuilder.DropTable(
                name: "Pharmacies");


            migrationBuilder.DropTable(
                name: "StaffManufacturing");


            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "TenderApprovals");

            migrationBuilder.DropTable(
                name: "TenderProposal");

            migrationBuilder.DropTable(
                name: "Tenders");
        }
    }
}
