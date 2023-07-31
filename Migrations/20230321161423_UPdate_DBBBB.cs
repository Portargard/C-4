using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4_ChauSolution.Migrations
{
    public partial class UPdate_DBBBB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "ChiTietSP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "HinhAnh",
                table: "ChiTietSP",
                type: "image",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
