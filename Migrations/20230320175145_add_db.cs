using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4_ChauSolution.Migrations
{
    public partial class add_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "KhachHang",
                columns: table => new
                {
                    IdKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ĐiaChi = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.IdKH);
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
                name: "NhanVien",
                columns: table => new
                {
                    IdNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IdLoaiTk = table.Column<bool>(type: "bit", nullable: false),
                    TrangThaiTK = table.Column<bool>(type: "bit", nullable: false),
                    TrangThaiPass = table.Column<bool>(type: "bit", nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NamSinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ĐiaChi = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SĐT = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IdNhanVien);
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

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    IdKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.IdKH);
                    table.ForeignKey(
                        name: "FK_Cart_KhachHang_IdKH",
                        column: x => x.IdKH,
                        principalTable: "KhachHang",
                        principalColumn: "IdKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNhanVien = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.IdHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSP",
                columns: table => new
                {
                    IdChiTietSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLoaiSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNhaCungCap = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDonVi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HinhAnh = table.Column<byte[]>(type: "image", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "decimal", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal", nullable: false),
                    SoLuong = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSP", x => x.IdChiTietSP);
                    table.ForeignKey(
                        name: "FK_ChiTietSP_DanhMuc_IdDanhMuc",
                        column: x => x.IdDanhMuc,
                        principalTable: "DanhMuc",
                        principalColumn: "IdDanhMuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSP_DonVi_IdDonVi",
                        column: x => x.IdDonVi,
                        principalTable: "DonVi",
                        principalColumn: "IdDonVi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSP_LoaiSanPham_IdLoaiSp",
                        column: x => x.IdLoaiSp,
                        principalTable: "LoaiSanPham",
                        principalColumn: "IdLoaiSp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSP_NhaCungCap_IdDonVi",
                        column: x => x.IdDonVi,
                        principalTable: "NhaCungCap",
                        principalColumn: "IdNhaCungCap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSP_SanPham_IdSp",
                        column: x => x.IdSp,
                        principalTable: "SanPham",
                        principalColumn: "IdSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChiTietSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDetail_Cart_IdKH",
                        column: x => x.IdKH,
                        principalTable: "Cart",
                        principalColumn: "IdKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetail_ChiTietSP_IdChiTietSP",
                        column: x => x.IdChiTietSP,
                        principalTable: "ChiTietSP",
                        principalColumn: "IdChiTietSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    IdCTHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChiTietSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal", nullable: false),
                    SoLuongMua = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.IdCTHoaDon);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_ChiTietSP_IdChiTietSP",
                        column: x => x.IdChiTietSP,
                        principalTable: "ChiTietSP",
                        principalColumn: "IdChiTietSP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_IdCTHoaDon",
                        column: x => x.IdCTHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "IdHoaDon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_IdChiTietSP",
                table: "CartDetail",
                column: "IdChiTietSP");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_IdKH",
                table: "CartDetail",
                column: "IdKH");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_IdChiTietSP",
                table: "ChiTietHoaDon",
                column: "IdChiTietSP");

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

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdNhanVien",
                table: "HoaDon",
                column: "IdNhanVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "ChiTietSP");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "KhachHang");

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

            migrationBuilder.DropTable(
                name: "NhanVien");
        }
    }
}
