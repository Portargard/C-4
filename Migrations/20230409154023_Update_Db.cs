using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4_ChauSolution.Migrations
{
    public partial class Update_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdLoaiTk",
                table: "NhanVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IdLoaiTk",
                table: "NhanVien",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
