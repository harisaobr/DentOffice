using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentOffice.WebAPI.Migrations
{
    public partial class add_ocjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_Pacijent_PacijentId",
                table: "Ocjene");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_Usluga_UslugaId",
                table: "Ocjene");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ocjene",
                table: "Ocjene");

            migrationBuilder.RenameTable(
                name: "Ocjene",
                newName: "Ocjenes");

            migrationBuilder.RenameColumn(
                name: "UslugaId",
                table: "Ocjenes",
                newName: "KorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjene_UslugaId",
                table: "Ocjenes",
                newName: "IX_Ocjenes_KorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjene_PacijentId",
                table: "Ocjenes",
                newName: "IX_Ocjenes_PacijentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "KorisnikId",
                table: "Ocjene",
                newName: "UslugaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjenes_PacijentId",
                table: "Ocjene",
                newName: "IX_Ocjene_PacijentId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjenes_KorisnikId",
                table: "Ocjene",
                newName: "IX_Ocjene_UslugaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ocjene",
                table: "Ocjene",
                column: "OcjenaId");

            migrationBuilder.UpdateData(
                table: "MedicinskiKarton",
                keyColumn: "MedicinskiKartonID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 7, 4, 18, 0, 16, 299, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "Racun",
                keyColumn: "RacunID",
                keyValue: 1,
                column: "DatumIzdavanjaRacuna",
                value: new DateTime(2022, 7, 4, 18, 0, 16, 299, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 1,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 6, 18, 0, 16, 295, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 2,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 8, 18, 0, 16, 298, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 3,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 9, 18, 0, 16, 298, DateTimeKind.Local).AddTicks(1597));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 4,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 14, 18, 0, 16, 298, DateTimeKind.Local).AddTicks(1604));

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_Pacijent_PacijentId",
                table: "Ocjene",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "PacijentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_Usluga_UslugaId",
                table: "Ocjene",
                column: "UslugaId",
                principalTable: "Usluga",
                principalColumn: "UslugaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
