using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C4_ChauSolution.Models;

namespace C4_ChauSolution.Configurations
{
    internal class CTHoaDonConfiguration : IEntityTypeConfiguration<ChiTietHoaDon>
    {
        public void Configure(EntityTypeBuilder<ChiTietHoaDon> builder)
        {
            builder.ToTable("ChiTietHoaDon");
            builder.HasKey(c => c.IdCTHoaDon);
            builder.Property(x => x.IdChiTietSP).IsRequired();
            builder.Property(x => x.IdHoaDon).IsRequired();
            builder.Property(c => c.DonGia).HasColumnName("DonGia").HasColumnType("int");
            builder.Property(c => c.SoLuongMua).HasColumnName("SoLuongMua").HasColumnType("int");
            builder.HasOne(c => c.ChiTietSanPham).WithMany(c => c.ChiTietHoaDons).HasForeignKey(c => c.IdChiTietSP);
            builder.HasOne(c => c.HoaDon).WithMany(c => c.ChiTietHoaDons).HasForeignKey(c => c.IdHoaDon);
        }
    }
}
