using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentOffice.WebAPI.Migrations
{
    public partial class add_ocjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ocjene",
                columns: table => new
                {
                    OcjenaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacijentId = table.Column<int>(type: "int", nullable: false),
                    UslugaId = table.Column<int>(type: "int", nullable: false),
                    Kreirano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ocjena = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjene", x => x.OcjenaId);
                    table.ForeignKey(
                        name: "FK_Ocjene_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "PacijentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocjene_Usluga_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluga",
                        principalColumn: "UslugaID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_PacijentId",
                table: "Ocjene",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_UslugaId",
                table: "Ocjene",
                column: "UslugaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.UpdateData(
                table: "MedicinskiKarton",
                keyColumn: "MedicinskiKartonID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 7, 4, 17, 56, 20, 164, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Racun",
                keyColumn: "RacunID",
                keyValue: 1,
                column: "DatumIzdavanjaRacuna",
                value: new DateTime(2022, 7, 4, 17, 56, 20, 164, DateTimeKind.Local).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 1,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 6, 17, 56, 20, 161, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 2,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 8, 17, 56, 20, 163, DateTimeKind.Local).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 3,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 9, 17, 56, 20, 163, DateTimeKind.Local).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminID",
                keyValue: 4,
                column: "DatumVrijeme",
                value: new DateTime(2022, 7, 14, 17, 56, 20, 163, DateTimeKind.Local).AddTicks(6870));
        }
    }
}
