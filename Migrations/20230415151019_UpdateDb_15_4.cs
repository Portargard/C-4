using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4_ChauSolution.Migrations
{
    public partial class UpdateDb_15_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MatKhau",
                table: "KhachHang",
                type: "nvarchar(16)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaiKoan",
                table: "KhachHang",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TongTien",
                table: "HoaDon",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<int>(
                name: "SoLuong",
                table: "ChiTietSP",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<int>(
                name: "GiaNhap",
                table: "ChiTietSP",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<int>(
                name: "GiaBan",
                table: "ChiTietSP",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "ChiTietSP",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongMua",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<int>(
                name: "DonGia",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_TaiKoan",
                table: "KhachHang",
                column: "TaiKoan",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KhachHang_TaiKoan",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "MatKhau",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "TaiKoan",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "ChiTietSP");

            migrationBuilder.AlterColumn<decimal>(
                name: "TongTien",
                table: "HoaDon",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "SoLuong",
                table: "ChiTietSP",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaNhap",
                table: "ChiTietSP",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaBan",
                table: "ChiTietSP",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "SoLuongMua",
                table: "ChiTietHoaDon",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "DonGia",
                table: "ChiTietHoaDon",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
