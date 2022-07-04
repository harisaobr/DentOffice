using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentOffice.WebAPI.Migrations
{
    public partial class drop_creditcard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Payment__CreditC__44FF419A",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CreditCardID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CreditCardID",
                table: "Payment");

            migrationBuilder.UpdateData(
                table: "MedicinskiKarton",
                keyColumn: "MedicinskiKartonID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 7, 4, 17, 31, 40, 696, DateTimeKind.Local).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "Racun",
                keyColumn: "RacunID",
                keyValue: 1,
                column: "DatumIzdavanjaRacuna",
                value: new DateTime(2022, 7, 4, 17, 31, 40, 696, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 1,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 6, 17, 31, 40, 687, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 2,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 8, 17, 31, 40, 694, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 3,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 9, 17, 31, 40, 694, DateTimeKind.Local).AddTicks(2831));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 4,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 14, 17, 31, 40, 694, DateTimeKind.Local).AddTicks(2843));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCardID",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    CreditCardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardID);
                    table.ForeignKey(
                        name: "FK__CreditCar__Koris__38996AB5",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "MedicinskiKarton",
                keyColumn: "MedicinskiKartonID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 7, 3, 17, 9, 25, 83, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Racun",
                keyColumn: "RacunID",
                keyValue: 1,
                column: "DatumIzdavanjaRacuna",
                value: new DateTime(2022, 7, 3, 17, 9, 25, 83, DateTimeKind.Local).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 1,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 5, 17, 9, 25, 76, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 2,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 7, 17, 9, 25, 81, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 3,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 8, 17, 9, 25, 81, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 4,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 13, 17, 9, 25, 81, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CreditCardID",
                table: "Payment",
                column: "CreditCardID");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_KorisnikID",
                table: "CreditCard",
                column: "KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK__Payment__CreditC__44FF419A",
                table: "Payment",
                column: "CreditCardID",
                principalTable: "CreditCard",
                principalColumn: "CreditCardID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
