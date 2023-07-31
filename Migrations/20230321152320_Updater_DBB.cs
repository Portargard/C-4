using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4_ChauSolution.Migrations
{
    public partial class Updater_DBB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_DanhMuc_IdDanhMuc",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_DonVi_IdDonVi",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_LoaiSanPham_IdLoaiSp",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_NhaCungCap_IdDonVi",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_SanPham_IdSp",
                table: "ChiTietSP");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "DonVi");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietSP_IdDanhMuc",
                table: "ChiTietSP");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietSP_IdDonVi",
                table: "ChiTietSP");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietSP_IdLoaiSp",
                table: "ChiTietSP");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietSP_IdSp",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "IdDanhMuc",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "IdDonVi",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "IdLoaiSp",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "IdNhaCungCap",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "IdSp",
                table: "ChiTietSP");

            migrationBuilder.AddColumn<string>(
                name: "TenDanhMuc",
                table: "ChiTietSP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenDonVi",
                table: "ChiTietSP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenLoaiSp",
                table: "ChiTietSP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenNhaCungCap",
                table: "ChiTietSP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenSp",
                table: "ChiTietSP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenDanhMuc",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "TenDonVi",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "TenLoaiSp",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "TenNhaCungCap",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "TenSp",
                table: "ChiTietSP");

            migrationBuilder.AddColumn<Guid>(
                name: "IdDanhMuc",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdDonVi",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdLoaiSp",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdNhaCungCap",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdSp",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    IdDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.IdDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "DonVi",
                columns: table => new
                {
                    IdDonVi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDonVi = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVi", x => x.IdDonVi);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    IdLoaiSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenLoaiSp = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.IdLoaiSp);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    IdNhaCungCap = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNhaCC = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.IdNhaCungCap);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    IdSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.IdSp);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdDanhMuc",
                table: "ChiTietSP",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdDonVi",
                table: "ChiTietSP",
                column: "IdDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdLoaiSp",
                table: "ChiTietSP",
                column: "IdLoaiSp");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdSp",
                table: "ChiTietSP",
                column: "IdSp");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_DanhMuc_IdDanhMuc",
                table: "ChiTietSP",
                column: "IdDanhMuc",
                principalTable: "DanhMuc",
                principalColumn: "IdDanhMuc",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_DonVi_IdDonVi",
                table: "ChiTietSP",
                column: "IdDonVi",
                principalTable: "DonVi",
                principalColumn: "IdDonVi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_LoaiSanPham_IdLoaiSp",
                table: "ChiTietSP",
                column: "IdLoaiSp",
                principalTable: "LoaiSanPham",
                principalColumn: "IdLoaiSp",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_NhaCungCap_IdDonVi",
                table: "ChiTietSP",
                column: "IdDonVi",
                principalTable: "NhaCungCap",
                principalColumn: "IdNhaCungCap",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_SanPham_IdSp",
                table: "ChiTietSP",
                column: "IdSp",
                principalTable: "SanPham",
                principalColumn: "IdSp",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
