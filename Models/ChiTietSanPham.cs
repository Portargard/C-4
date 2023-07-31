using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_ChauSolution.Models
{
    public class ChiTietSanPham
    {
        public Guid IdChiTietSP { get; set; }
        public string TenLoaiSp { get; set; }
        public string TenNhaCungCap { get; set; }
        public string TenSp { get; set; }
        public string TenDanhMuc { get; set; }
        public string TenDonVi { get; set; }

        public string HinhAnh { get; set; }
        public int GiaNhap { get; set; }
        public int GiaBan { get; set; }
        public int SoLuong { get; set; }

        public virtual List<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }

    }
}
