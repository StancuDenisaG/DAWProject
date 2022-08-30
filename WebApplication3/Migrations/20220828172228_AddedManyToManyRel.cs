using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class AddedManyToManyRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Cars_CarId",
                table: "Insurance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance");

            migrationBuilder.RenameTable(
                name: "Insurance",
                newName: "Insurances");

            migrationBuilder.RenameIndex(
                name: "IX_Insurance_CarId",
                table: "Insurances",
                newName: "IX_Insurances_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurances",
                table: "Insurances",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Accidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarAccidents",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    AccidentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAccidents", x => new { x.CarId, x.AccidentId });
                    table.ForeignKey(
                        name: "FK_CarAccidents_Accidents_AccidentId",
                        column: x => x.AccidentId,
                        principalTable: "Accidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarAccidents_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarAccidents_AccidentId",
                table: "CarAccidents",
                column: "AccidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Cars_CarId",
                table: "Insurances",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Cars_CarId",
                table: "Insurances");

            migrationBuilder.DropTable(
                name: "CarAccidents");

            migrationBuilder.DropTable(
                name: "Accidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurances",
                table: "Insurances");

            migrationBuilder.RenameTable(
                name: "Insurances",
                newName: "Insurance");

            migrationBuilder.RenameIndex(
                name: "IX_Insurances_CarId",
                table: "Insurance",
                newName: "IX_Insurance_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Cars_CarId",
                table: "Insurance",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
