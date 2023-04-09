using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JwtAuthAPI.Migrations
{
    public partial class InitialCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountHolderName = table.Column<string>(maxLength: 40, nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 40, nullable: false),
                    AccountType = table.Column<string>(maxLength: 40, nullable: false),
                    Gender = table.Column<string>(maxLength: 40, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    Picture = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(maxLength: 500, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    BalanceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalBalance = table.Column<decimal>(nullable: false),
                    AccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.BalanceID);
                    table.ForeignKey(
                        name: "FK_Balances_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    DepositID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountHolderName = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    DepositDate = table.Column<DateTime>(nullable: false),
                    AccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.DepositID);
                    table.ForeignKey(
                        name: "FK_Deposits_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferMoneys",
                columns: table => new
                {
                    TransferMoneyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderAccountNo = table.Column<string>(nullable: true),
                    RecipientAccountNo = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    DepositDate = table.Column<DateTime>(nullable: false),
                    AccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferMoneys", x => x.TransferMoneyID);
                    table.ForeignKey(
                        name: "FK_TransferMoneys_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_AccountID",
                table: "Balances",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_AccountID",
                table: "Deposits",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferMoneys_AccountID",
                table: "TransferMoneys",
                column: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "TransferMoneys");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
