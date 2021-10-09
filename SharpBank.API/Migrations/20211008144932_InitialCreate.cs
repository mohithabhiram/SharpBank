using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpBank.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    IFSC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.IFSC);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountNumber", "Balance", "Password", "UserName" },
                values: new object[,]
                {
                    { "001", 0m, null, "Shriram" },
                    { "201", 0m, null, "Vijith" },
                    { "301", 0m, null, "Sagar" },
                    { "401", 0m, null, "Balaji" }
                });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "IFSC", "BankName" },
                values: new object[,]
                {
                    { "001", "Yaxis" },
                    { "002", "YesBI" },
                    { "003", "FDHC" },
                    { "004", "YCYCY" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Bank");
        }
    }
}
