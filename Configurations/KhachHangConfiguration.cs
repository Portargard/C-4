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
    internal class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KhachHang");

            builder.HasKey(c => c.IdKH);
            builder.Property(c => c.TenKh).HasColumnName("TenKhachHang").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(c => c.SDT).HasColumnName("SDT").HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(c => c.DiaChi).HasColumnName("ĐiaChi").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(c => c.GioiTinh).HasColumnName("GioiTinh").HasColumnType("int").IsRequired();
            builder.HasIndex(c => c.TaiKoan).IsUnique();
            builder.Property(c => c.MatKhau).HasColumnName("MatKhau").HasColumnType("nvarchar(16)");

            builder.HasOne(x => x.Carts).WithOne(x => x.KhachHangs).HasForeignKey<Cart>(c => c.IdKH);
        }
    }
}
