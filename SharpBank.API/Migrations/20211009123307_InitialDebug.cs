using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpBank.API.Migrations
{
    public partial class InitialDebug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IFSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    IFSC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.IFSC);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecepientIFSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderIFSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecepientAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "Balance", "IFSC", "Password", "UserName" },
                values: new object[,]
                {
                    { "001", 0m, "001", null, "Shriram" },
                    { "101", 0m, "004", null, "Vijith" },
                    { "201", 0m, "002", null, "Sagar" },
                    { "301", 0m, "001", null, "Balaji" },
                    { "401", 0m, "003", null, "Mohith" }
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "IFSC", "BankName", "ImagePath" },
                values: new object[,]
                {
                    { "003", "FDHC", null },
                    { "004", "YCYCY", null },
                    { "001", "Yaxis", null },
                    { "002", "YesBI", null }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "Amount", "RecepientAccount", "RecepientIFSC", "SenderAccount", "SenderIFSC" },
                values: new object[,]
                {
                    { "007", 1.3m, "003", "002", "003", "003" },
                    { "001", 121.70m, "001", "001", "001", "001" },
                    { "002", 3441.02m, "002", "002", "002", "002" },
                    { "003", 1023.0m, "003", "001", "001", "003" },
                    { "004", 710.6m, "004", "004", "004", "004" },
                    { "005", 100.0m, "001", "001", "001", "001" },
                    { "006", 10.0894m, "002", "003", "001", "002" },
                    { "008", 0.1209m, "004", "004", "004", "004" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
