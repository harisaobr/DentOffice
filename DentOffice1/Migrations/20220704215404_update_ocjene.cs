using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentOffice.WebAPI.Migrations
{
    public partial class update_ocjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocjenes_Korisnik_KorisnikId",
                table: "Ocjenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjenes_Pacijent_PacijentId",
                table: "Ocjenes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ocjenes",
                table: "Ocjenes");

            migrationBuilder.RenameTable(
                name: "Ocjenes",
                newName: "Ocjene");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjenes_PacijentId",
                table: "Ocjene",
                newName: "IX_Ocjene_PacijentId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjenes_KorisnikId",
                table: "Ocjene",
                newName: "IX_Ocjene_KorisnikId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ocjene",
                table: "Ocjene",
                column: "OcjenaId");

            migrationBuilder.UpdateData(
                table: "MedicinskiKarton",
                keyColumn: "MedicinskiKartonID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 7, 4, 23, 54, 3, 286, DateTimeKind.Local).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "Racun",
                keyColumn: "RacunID",
                keyValue: 1,
                column: "DatumIzdavanjaRacuna",
                value: new DateTime(2022, 7, 4, 23, 54, 3, 287, DateTimeKind.Local).AddTicks(1425));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 1,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 6, 23, 54, 3, 281, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 2,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 8, 23, 54, 3, 285, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 3,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 9, 23, 54, 3, 285, DateTimeKind.Local).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 4,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 14, 23, 54, 3, 285, DateTimeKind.Local).AddTicks(7613));

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_Korisnik_KorisnikId",
                table: "Ocjene",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_Pacijent_PacijentId",
                table: "Ocjene",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "PacijentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_Korisnik_KorisnikId",
                table: "Ocjene");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_Pacijent_PacijentId",
                table: "Ocjene");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ocjene",
                table: "Ocjene");

            migrationBuilder.RenameTable(
                name: "Ocjene",
                newName: "Ocjenes");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjene_PacijentId",
                table: "Ocjenes",
                newName: "IX_Ocjenes_PacijentId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjene_KorisnikId",
                table: "Ocjenes",
                newName: "IX_Ocjenes_KorisnikId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ocjenes",
                table: "Ocjenes",
                column: "OcjenaId");

            migrationBuilder.UpdateData(
                table: "MedicinskiKarton",
                keyColumn: "MedicinskiKartonID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 7, 4, 19, 0, 7, 170, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Racun",
                keyColumn: "RacunID",
                keyValue: 1,
                column: "DatumIzdavanjaRacuna",
                value: new DateTime(2022, 7, 4, 19, 0, 7, 170, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 1,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 6, 19, 0, 7, 166, DateTimeKind.Local).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 2,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 8, 19, 0, 7, 169, DateTimeKind.Local).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 3,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 9, 19, 0, 7, 169, DateTimeKind.Local).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 4,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 14, 19, 0, 7, 169, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjenes_Korisnik_KorisnikId",
                table: "Ocjenes",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "KorisnikID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjenes_Pacijent_PacijentId",
                table: "Ocjenes",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "PacijentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
