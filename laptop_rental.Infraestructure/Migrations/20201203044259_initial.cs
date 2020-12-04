using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace laptop_rental.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    fullName = table.Column<string>(type: "text", nullable: false),
                    isLegal = table.Column<bool>(type: "boolean", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    cnpj = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    stockAmount = table.Column<int>(type: "integer", nullable: false),
                    dailyPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    dailyLateFee = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rentDate = table.Column<string>(type: "text", nullable: false),
                    rentExpirationDate = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: true),
                    fullPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    customerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    laptopId = table.Column<int>(type: "integer", nullable: false),
                    rentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentItems_Laptops_laptopId",
                        column: x => x.laptopId,
                        principalTable: "Laptops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentItems_Rents_rentId",
                        column: x => x.rentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentItems_laptopId",
                table: "RentItems",
                column: "laptopId");

            migrationBuilder.CreateIndex(
                name: "IX_RentItems_rentId",
                table: "RentItems",
                column: "rentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_customerId",
                table: "Rents",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentItems");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
