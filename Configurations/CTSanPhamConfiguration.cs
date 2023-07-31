using C4_ChauSolution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_ChauSolution.Configurations
{
    internal class CTSanPhamConfiguration : IEntityTypeConfiguration<ChiTietSanPham>
    {
        public void Configure(EntityTypeBuilder<ChiTietSanPham> builder)
        {
            builder.ToTable("ChiTietSP");

            builder.HasKey(c => c.IdChiTietSP);
            builder.Property(c => c.TenLoaiSp).IsRequired();
            builder.Property(c => c.TenNhaCungCap).IsRequired();
            builder.Property(c => c.TenSp).IsRequired();
            builder.Property(c => c.TenDonVi).IsRequired();
            builder.Property(c => c.TenDanhMuc).IsRequired();
            builder.Property(c => c.GiaBan).HasColumnName("GiaBan").HasColumnType("int");
            builder.Property(c => c.GiaNhap).HasColumnName("GiaNhap").HasColumnType("int");
            builder.Property(c => c.SoLuong).HasColumnName("SoLuong").HasColumnType("int");
            builder.Property(c => c.HinhAnh).HasColumnName("HinhAnh").HasColumnType("nvarchar(1000)");


        }
    }
}
