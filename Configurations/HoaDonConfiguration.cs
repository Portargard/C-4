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
    internal class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");

            builder.HasKey(c => c.IdHoaDon);
            builder.Property(c => c.IdNhanVien).IsRequired();
            builder.Property(c => c.TongTien).HasColumnName("TongTien").HasColumnType("int").IsRequired();
            builder.Property(c => c.NgayThanhToan).HasColumnName("NgayThanhToan").HasColumnType("datetime").IsRequired();
            builder.Property(c => c.NgayTao).HasColumnName("NgayTao").HasColumnType("datetime").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnName("TrangThai").HasColumnType("int");

            builder.HasOne(c => c.NhanVien).WithMany(c => c.HoaDons).HasForeignKey(c => c.IdNhanVien);
        }
    }
}
