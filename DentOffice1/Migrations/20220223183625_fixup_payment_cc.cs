using Microsoft.EntityFrameworkCore.Migrations;

namespace DentOffice.WebAPI.Migrations
{
    public partial class fixup_payment_cc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Odobreno",
                table: "Termin",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Payment_KorisnikId",
                table: "Payment",
                column: "KorisnikId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Korisnik_KorisnikId",
                table: "Payment",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_Payment_PaymentId1",
                table: "CreditCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Korisnik_KorisnikId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_KorisnikId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_CreditCard_PaymentId1",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "PaymentId1",
                table: "CreditCard");

            migrationBuilder.AlterColumn<bool>(
                name: "Odobreno",
                table: "Termin",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
