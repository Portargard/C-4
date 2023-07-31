using C4_ChauSolution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C4_ChauSolution.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable("CartDetail");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdChiTietSP).IsRequired();
            builder.Property(x=>x.IdKH);
            builder.Property(x => x.SoLuong).HasColumnName("SoLuong").HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Cart).WithMany(x => x.CartDetails).HasForeignKey(x => x.IdKH);
            builder.HasOne(c=>c.ChiTietSanPham).WithMany(x => x.CartDetails).HasForeignKey(x => x.IdChiTietSP);
        }
    }
}
