using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4_ChauSolution.Migrations
{
    public partial class Update_Db_Today_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_IdCTHoaDon",
                table: "ChiTietHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_IdHoaDon",
                table: "ChiTietHoaDon",
                column: "IdHoaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_IdHoaDon",
                table: "ChiTietHoaDon",
                column: "IdHoaDon",
                principalTable: "HoaDon",
                principalColumn: "IdHoaDon",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_IdHoaDon",
                table: "ChiTietHoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_IdHoaDon",
                table: "ChiTietHoaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_IdCTHoaDon",
                table: "ChiTietHoaDon",
                column: "IdCTHoaDon",
                principalTable: "HoaDon",
                principalColumn: "IdHoaDon",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
