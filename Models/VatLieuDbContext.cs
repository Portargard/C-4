using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C4_ChauSolution.Models
{
    public class VatLieuDbContext : DbContext
    {
        public VatLieuDbContext()
        {
        }

        public VatLieuDbContext(DbContextOptions<VatLieuDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.
                UseSqlServer(@"Data Source=DESKTOP-OKDB069;Initial Catalog=C4_DB;Integrated Security=True"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } 
        public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }         
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        
       
    }
}
