using C4_ChauSolution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C4_ChauSolution.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(x => x.IdKH);
            builder.Property(x=>x.Description).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
