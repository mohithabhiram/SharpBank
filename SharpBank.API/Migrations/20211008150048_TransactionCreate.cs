using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpBank.API.Migrations
{
    public partial class TransactionCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecepientIFSC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderIFSC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecepientAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionID", "Amount", "RecepientAccount", "RecepientIFSC", "SenderAccount", "SenderIFSC" },
                values: new object[,]
                {
                    { "001", 100.0m, "001", "001", "001", "001" },
                    { "002", 100.0m, "002", "002", "002", "002" },
                    { "003", 100.0m, "003", "001", "001", "003" },
                    { "004", 100.0m, "004", "004", "004", "004" },
                    { "005", 100.0m, "001", "001", "001", "001" },
                    { "006", 100.0m, "002", "003", "001", "002" },
                    { "007", 100.0m, "003", "002", "003", "003" },
                    { "008", 100.0m, "004", "004", "004", "004" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
