using Microsoft.EntityFrameworkCore.Migrations;

namespace DentOffice.WebAPI.Migrations
{
    public partial class fixup_payment_cc_2ndattempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_Payment_PaymentId1",
                table: "CreditCard");

            migrationBuilder.DropIndex(
                name: "IX_CreditCard_PaymentId1",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "PaymentId1",
                table: "CreditCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "CreditCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId1",
                table: "CreditCard",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_PaymentId1",
                table: "CreditCard",
                column: "PaymentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_Payment_PaymentId1",
                table: "CreditCard",
                column: "PaymentId1",
                principalTable: "Payment",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
